using System;
using System.IO;
using LibGit2Sharp;
using CommandLine;
using System.Collections.Generic;

namespace ContentManager
{

    class Program
    {
        enum InputType
        {
            ALL,
            BLOG,
            FEEDS,
            PROJECTS,
            STUDY
        } 

        enum BuildType
        {
            ORIGIN,
            INCREMENTAL
        }

        public static HashSet<string> getFilesFromDiff (string pathToSrc)
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
                HashSet<string> paths = new HashSet<string>();
                foreach (TreeEntryChanges ch in changes)
                {
                    paths.Add(ch.Path);
                }
                return paths;
            }
        }

        public static HashSet<string> getAllFiles (string pathToSrc)
        {
            HashSet<string> paths = new HashSet<string>();
            foreach (string d in Directory.GetDirectories(pathToSrc))
            {
                foreach (string f in Directory.GetFiles(d, "*"))
                {
                    paths.Add(f);
                }
            }
            return paths;
        }

        static void Main(string[] args)
        {
            var config = Parser.Default.ParseArguments<Options>(args)
                .MapResult(opts => {
                    var cfg = new Dictionary<string, object>();
                    Enum.TryParse(opts.Input, out InputType iType);
                    Enum.TryParse(opts.Type, out BuildType bType);
                    cfg.Add("buildType", bType);
                    cfg.Add("inputType", iType);
                    cfg.Add("verbose", opts.Verbose);
                    return cfg;
                },
                _ => throw new Exception("failed parsing"));
            string srcPath = Environment.GetEnvironmentVariable("CODEBUILD_SRC_DIR");
            Dictionary<string, HashSet<string>> AllPaths = new Dictionary<string, HashSet<string>>();
            AllPaths.Add("blog", )
            var files = getAllFiles(srcPath);
        }
    }
}

