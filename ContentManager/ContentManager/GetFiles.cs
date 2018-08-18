using System;
using System.IO;
using System.Linq;
using LibGit2Sharp;
using System.Collections.Generic;

namespace ContentManager
{
    public static class GetFiles
    {
        public static Dictionary<Types.InputType, IEnumerable<string>> getFilesFromDiff(string pathToSrc)
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
                var paths = new Dictionary<Types.InputType, IEnumerable<string>>
                {
                    { Types.InputType.blog, new List<string>() },
                    { Types.InputType.feeds, new List<string>() },
                    { Types.InputType.projects, new List<string>() },
                    { Types.InputType.study, new List<string>() }
                };
                foreach (TreeEntryChanges ch in changes)
                {
                    var p = ch.Path;
                    if (p.StartsWith(Types.InputType.blog.ToString("G")))
                    {
                        paths[Types.InputType.blog].ToList().Add(p);
                    }
                    else if (p.StartsWith(Types.InputType.feeds.ToString("G")))
                    {
                        paths[Types.InputType.feeds].ToList().Add(p);
                    }
                    else if (p.StartsWith(Types.InputType.projects.ToString("G")))
                    {
                        paths[Types.InputType.projects].ToList().Add(p);
                    }
                    else if (p.StartsWith(Types.InputType.study.ToString("G")))
                    {
                        paths[Types.InputType.study].ToList().Add(p);
                    } // else ignore
                }
                return paths;
            }
        }

        private static IEnumerable<string> Blog(string path)
        {
            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in Directory.GetFiles(d, "*"))
                {
                    yield return f;
                }
            }
        }

        private static IEnumerable<string> Feeds(string path)
        {
            foreach (string f in Directory.GetFiles(path, "*"))
            {
                var extension = Path.GetExtension(f);
                if (extension.Contains("xml") || extension.Contains("opml"))
                {
                    yield return f;
                }
            }
        }

        private static IEnumerable<string> ListOfLists (string path)
        {
            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in Directory.GetFiles(d, "*"))
                {
                    yield return f;
                }
                foreach (string innerD in Directory.GetDirectories(d, "*"))
                {
                    foreach (string f in Directory.GetFiles(innerD, "*"))
                    {
                        yield return f;
                    }
                }
            }
        }

        private static IEnumerable<string> Projects(string path) { return ListOfLists(path); }

        private static IEnumerable<string> Study(string path) { return ListOfLists(path); }

        private static Dictionary<Types.InputType, Func<string, IEnumerable<string>>> TypeToImplementationDict()
        {
            var config = new Dictionary<Types.InputType, Func<string, IEnumerable<string>>>
            {
                { Types.InputType.blog, Blog },
                { Types.InputType.feeds, Feeds },
                { Types.InputType.projects, Projects },
                { Types.InputType.study, Study }
            };
            return config;
        }

        public static Dictionary<Types.InputType, IEnumerable<string>> getAllFiles(Dictionary<Types.InputType, List<string>> types, string pathToSrc)
        {
            var paths = new Dictionary<Types.InputType, IEnumerable<string>> ();
            var configuration = TypeToImplementationDict();
            foreach(var entry in types)
            {
                var pathToPosts = Path.Combine(pathToSrc, entry.Key.ToString("G"));
                var impl = configuration[entry.Key];
                var generator = impl(pathToPosts);
                paths.Add(entry.Key, generator);
            }
            return paths;
        }

    }
}
