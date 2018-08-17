using System;
using CommandLine;
using System.Collections.Generic;
using System.Linq;

namespace ContentManager
{

    class Program
    {

        class Configuration
        {
            public Types.InputType InputType { get; set; }
            public Types.BuildType BuildType { get; set; }
            public Boolean verbose { get; set; }
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
                    config.verbose = opts.Verbose;
                    return opts;
                },
                _ => throw new Exception("failed parsing"));
            return config;
        }

        static void Main(string[] args)
        {
            var configuration = parseArguments(args);
            var mTypes = Types.GetAllTypes(configuration.InputType);
            var srcPath = Environment.GetEnvironmentVariable("CODEBUILD_SRC_DIR");
            var files = configuration.BuildType == Types.BuildType.origin ? 
                GetFiles.getAllFiles(mTypes, srcPath) : GetFiles.getFilesFromDiff(srcPath);

        }
    }
}

