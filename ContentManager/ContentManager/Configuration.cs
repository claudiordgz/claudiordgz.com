using ContentManager.Models;
using ContentManager.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ContentManager
{

    public class Configuration
    {

        private string configurationFile;

        [Required]
        public string ConfigurationFile
        {

            get
            {
                return configurationFile;
            }
            set
            {
                configurationFile = value;
                ProcessConfigurationFile(configurationFile);
            }
        }

        private string gitDirectory;

        [Required]
        public string GitDirectory
        {

            get
            {
                return gitDirectory;
            }
            set
            {
                gitDirectory = value;
                GithubProperties = Git.GetCurrentGithubProperties(gitDirectory);
            }
        }

        private string contentDirectory;

        [Required]
        public string ContentDirectory
        {
            get
            {
                return contentDirectory;
            }
            set
            {
                contentDirectory = value;
            }
        }

        public Types.InputType InputType { get; set; }
        public Types.BuildType BuildType { get; set; }
        public bool Verbose { get; set; }
        public string UserConfiguration { get; set; }
        public RepositorySettings GithubProperties { get; set; }
        public List<Types.InputType> TypesToProcess { get; set; }
        public SiteDefaults Defaults { get; set; }

        public List<Types.InputType> GetTypes()
        {
            return Types.GetTypes(InputType);
        }

        private void ProcessConfigurationFile(string configFile)
        {
            string contents = File.ReadAllText(Path.GetFullPath(Path.Combine(ContentDirectory, configFile)));
            YamlStream yaml = new YamlStream();
            StringReader input = new StringReader(contents);

            Deserializer deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            Defaults = deserializer.Deserialize<SiteDefaults>(input);
        }
    }
}
