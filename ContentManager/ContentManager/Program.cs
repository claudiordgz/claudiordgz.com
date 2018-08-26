using System;
using System.Linq;
using CommandLine;
using System.Collections.Generic;
using LibGit2Sharp;
using System.Diagnostics.CodeAnalysis;

namespace ContentManager
{

    class Program
    {

        [ExcludeFromCodeCoverage]
        static Configuration ParseArguments (string [] args)
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

        [ExcludeFromCodeCoverage]
        static Dictionary<Types.InputType, IEnumerable<string>> WrapGit(Configuration configuration)
        {
            using (var repo = new Repository(configuration.RootPath))
            {
                var gitHelper = new GetFilesFromDiff(repo, configuration.RootPath);
                var f = gitHelper.getFilesFromDiff();
                var files = f.Where(item => configuration.TypesToProcess.Contains(item.Key))
                    .ToDictionary(p => p.Key, p => p.Value);
                return files;
            }
        }

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            var configuration = ParseArguments(args);
            configuration.TypesToProcess = Types.GetTypes(configuration.InputType);
            configuration.RootPath = Environment.GetEnvironmentVariable("CODEBUILD_SRC_DIR");
            Func<Configuration, Dictionary<Types.InputType, IEnumerable<string>>> gitHelper = WrapGit;
            var files = GetFiles.FromBuildType(configuration, gitHelper);
        }
    }
}

