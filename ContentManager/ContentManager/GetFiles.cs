using System;
using System.IO;
using LibGit2Sharp;
using System.Collections.Generic;

namespace ContentManager
{
    public static class GetFiles
    {
        public static Dictionary<Types.InputType, HashSet<string>> getFilesFromDiff(string pathToSrc)
        {
            using (var repo = new Repository(pathToSrc))
            {
                string tag = repo.Describe(repo.Head.Tip, new DescribeOptions
                {
                    OnlyFollowFirstParent = true,
                    MinimumCommitIdAbbreviatedSize = 0,
                    Strategy = DescribeStrategy.Tags
                });
                Tag lastTag = repo.Tags[tag];
                Commit commitFromLastTag = repo.Lookup<Commit>(lastTag.Target.Sha);
                TreeChanges changes = repo.Diff.Compare<TreeChanges>(
                    commitFromLastTag.Tree,
                    repo.Head.Tip.Tree
                );
                var paths = new Dictionary<Types.InputType, HashSet<string>>
                {
                    { Types.InputType.blog, new HashSet<string>() },
                    { Types.InputType.feeds, new HashSet<string>() },
                    { Types.InputType.projects, new HashSet<string>() },
                    { Types.InputType.study, new HashSet<string>() }
                };
                foreach (TreeEntryChanges ch in changes)
                {
                    var p = ch.Path;
                    if (p.StartsWith(Types.InputType.blog.ToString("G")))
                    {
                        paths[Types.InputType.blog].Add(p);
                    }
                    else if (p.StartsWith(Types.InputType.feeds.ToString("G")))
                    {
                        paths[Types.InputType.feeds].Add(p);
                    }
                    else if (p.StartsWith(Types.InputType.projects.ToString("G")))
                    {
                        paths[Types.InputType.projects].Add(p);
                    }
                    else if (p.StartsWith(Types.InputType.study.ToString("G")))
                    {
                        paths[Types.InputType.study].Add(p);
                    } // else ignore
                }
                return paths;
            }
        }

        private static HashSet<string> blog (string path)
        {
            HashSet<string> paths = new HashSet<string>();
            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in Directory.GetFiles(d, "*"))
                {
                    paths.Add(f);
                }
            }
            return paths;
        }

        private static HashSet<string> feeds(string path)
        {
            HashSet<string> paths = new HashSet<string>();
            foreach (string f in Directory.GetFiles(path, "*"))
            {
                paths.Add(f);
            }
            return paths;
        }

        private static HashSet<string> projects(string path)
        {
            HashSet<string> paths = new HashSet<string>();
            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in Directory.GetFiles(d, "*"))
                {
                    paths.Add(f);
                }
            }
            return paths;
        }

        private static HashSet<string> study(string path)
        {
            HashSet<string> paths = new HashSet<string>();
            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in Directory.GetFiles(d, "*"))
                {
                    paths.Add(f);
                }
            }
            return paths;
        }

        private static Dictionary<Types.InputType, Func<string, HashSet<string>>> TypeToImplementationDict()
        {
            var config = new Dictionary<Types.InputType, Func<string, HashSet<string>>>
            {
                { Types.InputType.blog, blog },
                { Types.InputType.feeds, feeds },
                { Types.InputType.projects, projects },
                { Types.InputType.study, study }
            };
            return config;
        }

        public static Dictionary<Types.InputType, HashSet<string>> getAllFiles(Dictionary<Types.InputType, List<string>> types, string pathToSrc)
        {
            var paths = new Dictionary<Types.InputType, HashSet<string>> ();
            var configuration = TypeToImplementationDict();
            foreach(var entry in types)
            {
                var pathToPosts = Path.Combine(pathToSrc, entry.Key.ToString("G"));
                var impl = configuration[entry.Key];
                var list = impl(pathToPosts);
                paths.Add(entry.Key, list);
            }
            return paths;
        }

    }
}
