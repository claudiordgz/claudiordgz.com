using System;
using System.Linq;
using CommandLine;
using System.Collections.Generic;
using LibGit2Sharp;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace ContentManager
{

    class Program
    {
        [ExcludeFromCodeCoverage]
        public static Options MapOptionsToResults (Configuration config, Options opts)
        {
            Enum.TryParse(opts.Input, out Types.InputType iType);
            Enum.TryParse(opts.Type, out Types.BuildType bType);
            config.BuildType = bType;
            config.InputType = iType;
            config.Verbose = opts.Verbose;
            config.UserConfiguration = opts.Config;
            return opts;
        }

        public static Func<IEnumerable<Error>, Options> notParsedFunc = _ => throw new Exception("failed parsing");

        [ExcludeFromCodeCoverage]
        static Configuration ParseArguments (string [] args)
        {
            string gitDirectory = Environment.GetEnvironmentVariable("CODEBUILD_SRC_DIR");
            Configuration config = new Configuration();
            Parser.Default.ParseArguments<Options>(args)
                .MapResult(opts => MapOptionsToResults(config, opts),
                notParsedFunc);
            return config;
        }

        public static Dictionary<Types.InputType, IEnumerable<string>> FilterByTypes (Dictionary<Types.InputType, IEnumerable<string>> files, Configuration configuration)
        {
            return files.Where(item => configuration.TypesToProcess.Contains(item.Key))
                    .ToDictionary(p => p.Key, p => p.Value);
        }

        [ExcludeFromCodeCoverage]
        static Dictionary<Types.InputType, IEnumerable<string>> WrapGit(Configuration configuration)
        {
            using (Repository repo = new Repository(configuration.GitDirectory))
            {
                GetFilesFromDiff gitHelper = new GetFilesFromDiff(repo, configuration.GitDirectory, "content");
                Dictionary<Types.InputType, IEnumerable<string>> f = gitHelper.getFilesFromDiff();
                return FilterByTypes(f, configuration);
            }
        }

        [ExcludeFromCodeCoverage]
        static void Main(string[] args)
        {
            Configuration configuration = ParseArguments(args);
            configuration.TypesToProcess = configuration.GetTypes();
            Func<Configuration, Dictionary<Types.InputType, IEnumerable<string>>> gitHelper = WrapGit;
            Dictionary<Types.InputType, IEnumerable<string>> files = GetFiles.FromBuildType(configuration, gitHelper);
        }
    }
}

