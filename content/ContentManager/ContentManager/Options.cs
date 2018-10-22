using CommandLine;
using System.Diagnostics.CodeAnalysis;

namespace ContentManager
{
    [ExcludeFromCodeCoverage]
    class Options
    {
        [Option('t', "type",
            Required = true,
            HelpText = "Instructs to process diff from latest tag or all content")]
        public string Type { get; set; }

        [Option('i', "input",
            Required = true,
            HelpText = "Instructs to process diff from latest tag or all content")]
        public string Input { get; set; }

        [Option('v', "verbose",
            Default = false,
            HelpText = "Enables all logs")]
        public bool Verbose { get; set; }
    }
}