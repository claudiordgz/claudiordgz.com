using System.Linq;
using LibGit2Sharp;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System;

namespace ContentManager
{
    public class GetFilesFromDiff
    {
        private readonly IRepository _repo;
        private readonly string _pathToSrc;

        public GetFilesFromDiff(IRepository repo, string pathToSrc)
        {
            _repo = repo;
            _pathToSrc = pathToSrc;
        }

        internal static bool ShouldDiscardPath(string path)
        {
            string ext = Path.GetExtension(path);
            if (string.IsNullOrEmpty(ext))
            {
                return true;
            }
            // Path.DirectorySeparatorChar returns \\ for windows
            // we're using git
            string[] directories = path.Split('/');
            if (directories.Length == 2 && directories[1].Contains("README"))
            {
                return true;
            }
            return false;
        }

        internal static string CombinePaths(string srcPath, string path)
        {
            string rPath = Path.Combine(srcPath, path);
            return Path.GetFullPath((new Uri(rPath)).LocalPath);
        }

        public Dictionary<Types.InputType, IEnumerable<string>> PackPaths (IEnumerable<string> changedPaths)
        {
            List<string> blog = new List<string>();
            List<string> feeds = new List<string>();
            List<string> projects = new List<string>();
            List<string> study = new List<string>();
            Dictionary<Types.InputType, IEnumerable<string>> paths = new Dictionary<Types.InputType, IEnumerable<string>>();
            foreach (string p in changedPaths)
            {
                if (p.StartsWith(Types.InputType.blog.ToString("G")))
                {
                    if (!paths.ContainsKey(Types.InputType.blog))
                    {
                        paths[Types.InputType.blog] = blog;
                    }
                    if (!ShouldDiscardPath(p))
                    {
                        string nP = CombinePaths(_pathToSrc, p);
                        blog.Add(nP);
                    }
                }
                else if (p.StartsWith(Types.InputType.feeds.ToString("G")))
                {
                    if (!paths.ContainsKey(Types.InputType.feeds))
                    {
                        paths[Types.InputType.feeds] = feeds;
                    }
                    string extension = Path.GetExtension(p);
                    if (extension.Contains("xml") || extension.Contains("opml"))
                    {
                        string nP = CombinePaths(_pathToSrc, p);
                        feeds.Add(nP);
                    }
                }
                else if (p.StartsWith(Types.InputType.projects.ToString("G")))
                {
                    if (!paths.ContainsKey(Types.InputType.projects))
                    {
                        paths[Types.InputType.projects] = projects;
                    }
                    if (!ShouldDiscardPath(p))
                    {
                        string nP = CombinePaths(_pathToSrc, p);
                        projects.Add(nP);
                    }
                }
                else if (p.StartsWith(Types.InputType.study.ToString("G")))
                {
                    if (!paths.ContainsKey(Types.InputType.study))
                    {
                        paths[Types.InputType.study] = study;
                    }
                    if (!ShouldDiscardPath(p))
                    {
                        string nP = CombinePaths(_pathToSrc, p);
                        study.Add(nP);
                    }

                } // else ignore
            }
            return paths;
        }

        public static IEnumerable<string> FilterTreeChangesToPaths (TreeChanges changes)
        {
            return changes.Select(x => x.Path);
        }

        [ExcludeFromCodeCoverage]
        public Dictionary<Types.InputType, IEnumerable<string>> getFilesFromDiff()
        {
            string tag = _repo.Describe(_repo.Head.Tip, new DescribeOptions
            {
                OnlyFollowFirstParent = true,
                MinimumCommitIdAbbreviatedSize = 0,
                Strategy = DescribeStrategy.Tags
            });
            Tag lastTag = _repo.Tags[tag];
            Commit commitFromLastTag = _repo.Lookup<Commit>(lastTag.Target.Sha);
            TreeChanges changes = _repo.Diff.Compare<TreeChanges>(
                commitFromLastTag.Tree,
                _repo.Head.Tip.Tree
            );
            IEnumerable<string> changedPaths = FilterTreeChangesToPaths(changes);
            return PackPaths(changedPaths);
        }

    }
}
