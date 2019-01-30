using CommandLine;
using System.Diagnostics.CodeAnalysis;

namespace ContentManager
{
    [ExcludeFromCodeCoverage]
    class Options
    {
        [Option('t', "build-type",
            Required = true,
            HelpText = "Instructs to process diff from latest tag or all content")]
        public string Type { get; set; }

        [Option('i', "input-type",
            Required = true,
            HelpText = "Instructs to process diff from latest tag or all content")]
        public string Input { get; set; }

        [Option('v', "verbose",
            Default = false,
            HelpText = "Enables all logs")]
        public bool Verbose { get; set; }

        [Option("config",
            Required = true,
            HelpText = "Configuration YAML file")]
        public string Config { get; set; }

        [Option("content",
            Required = true,
            HelpText = "Path to Content")]
        public string Content { get; set; }
    }
}