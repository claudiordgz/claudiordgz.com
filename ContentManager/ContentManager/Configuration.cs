using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace ContentManager
{
    public class Configuration
    {
        public Configuration(string rootPath)
        {
            RootPath = rootPath;
            ProcessConfigurationFile();
        }

        public Types.InputType InputType { get; set; }
        public Types.BuildType BuildType { get; set; }
        public bool Verbose { get; set; }
        public string RootPath { get; set; }
        public List<Types.InputType> TypesToProcess { get; set; }

        public static string ConfigurationFileName => configurationFileName;

        public List<Types.InputType> GetTypes()
        {
            return Types.GetTypes(InputType);
        }

        private const string configurationFileName = "configuration.yaml";
        private readonly string[] configurationKeys = new string[] { "thumbnailDirectory", "authors", "credits", "thumbnails" };

        private void ProcessConfigurationFile ()
        {
            string contents = File.ReadAllText(Path.GetFullPath(Path.Combine(RootPath, configurationFileName)));
            YamlStream yaml = new YamlStream();
            var input = new StringReader(contents);
            yaml.Load(input);
            YamlMappingNode mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
        }
    }
}
