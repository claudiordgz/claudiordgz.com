using ContentManager.Models;
using ContentManager.Util;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ContentManager
{

    public class Configuration
    {
        public Configuration(string gitDirectory, string contentDirectory)
        {
            GitDirectory = gitDirectory;
            ContentDirectory = contentDirectory;
            ProcessConfigurationFile();
            GithubProperties = Git.GetCurrentGithubProperties(gitDirectory);
        }

        public Types.InputType InputType { get; set; }
        public Types.BuildType BuildType { get; set; }
        public bool Verbose { get; set; }
        public string GitDirectory { get; set; }
        public string ContentDirectory { get; set; }
        public RepositorySettings GithubProperties { get; set; }
        public List<Types.InputType> TypesToProcess { get; set; }
        public SiteDefaults Defaults { get; set; }

        public static string ConfigurationFileName => configurationFileName;

        public List<Types.InputType> GetTypes()
        {
            return Types.GetTypes(InputType);
        }

        // TODO: Move this to an Argument from main
        private const string configurationFileName = "configuration.yml";
        private readonly string[] configurationKeys = new string[] { "thumbnailDirectory", "authors", "credits", "thumbnails" };

        private void ProcessConfigurationFile ()
        {
            string contents = File.ReadAllText(Path.GetFullPath(Path.Combine(ContentDirectory, configurationFileName)));
            YamlStream yaml = new YamlStream();
            StringReader input = new StringReader(contents);

            Deserializer deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            Defaults = deserializer.Deserialize<SiteDefaults>(input);
        }
    }
}
