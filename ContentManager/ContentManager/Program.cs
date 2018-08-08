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

        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args)
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
            using (var repo = new Repository(srcPath))
            {
                var tag = repo.Describe(repo.Head.Tip, new DescribeOptions
                {
                    OnlyFollowFirstParent = true,
                    Strategy = DescribeStrategy.Tags
                });
                TreeChanges changes = repo.Diff.Compare<TreeChanges>(
                    repo.Lookup<Tree>("eaace96086c5cf4e461f09579c7db0177cecf749"),
                    repo.Head.Tip.Tree
                );
                Console.WriteLine(changes);
            }
        }
    }
}
