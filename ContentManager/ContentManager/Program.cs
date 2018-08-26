using System;
using CommandLine;
using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace ContentManager
{

    class Program
    {

        class Configuration
        {
            public Types.InputType InputType { get; set; }
            public Types.BuildType BuildType { get; set; }
            public Boolean Verbose { get; set; }
        }

        static Configuration parseArguments (string [] args)
        {
            var config = new Configuration();
            Parser.Default.ParseArguments<Options>(args)
                .MapResult(opts => {
                    Enum.TryParse(opts.Input, out Types.InputType iType);
                    Enum.TryParse(opts.Type, out Types.BuildType bType);
                    config.BuildType = bType;
                    config.InputType = iType;
                    config.Verbose = opts.Verbose;
                    return opts;
                },
                _ => throw new Exception("failed parsing"));
            return config;
        }

        static void Main(string[] args)
        {
            var configuration = parseArguments(args);
            var mTypes = Types.GetTypes(configuration.InputType);
            var srcPath = Environment.GetEnvironmentVariable("CODEBUILD_SRC_DIR");
            if (configuration.BuildType == Types.BuildType.incremental)
            {
                var files = GetAllFiles.getAllFiles(mTypes, srcPath);
            } else
            {
                using (var repo = new Repository(srcPath))
                {
                    var gitHelper = new GetFilesFromDiff(repo, srcPath);
                    var files = gitHelper.getFilesFromDiff();
                } 
            }

        }
    }
}

