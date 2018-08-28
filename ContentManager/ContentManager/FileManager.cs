using ContentManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Markdig;
using YamlDotNet.Serialization;
using YamlDotNet.RepresentationModel;
using System.Diagnostics;

namespace ContentManager
{
    /// <summary>
    /// Handles translating files into Objects
    /// Verifies that Each Section has it's own Metadata file if required
    /// Sections that require Metadata:
    ///   - Each Project Directory
    ///   - Each Study Directory
    /// </summary>
    public class FileManager
    {
        public Dictionary<Types.InputType, ITease> Model { get; set; } 

        public static string GetFrontMatter (string contents)
        {
            var frontMatterSeparator = "---\n";
            if (!contents.StartsWith(frontMatterSeparator))
            {
                throw new Exception("Where is the FrontMatter? I need it, starts with: ---\n");
            }
            int pFrom = contents.IndexOf(frontMatterSeparator);
            int pFromLength = frontMatterSeparator.Length;
            int pTo = contents
                .Substring(pFromLength, contents.Length - pFromLength)
                .IndexOf(frontMatterSeparator);
            if (pTo == -1)
            {
                throw new Exception("Where is the FrontMatter Ending? I need that too, ends with: ---\n");
            }
            var frontMatter = contents.Substring(pFromLength, pTo);
            var input = new StringReader(frontMatter);
            var yaml = new YamlStream();
            yaml.Load(input);
            var mapping =
                (YamlMappingNode)yaml.Documents[0].RootNode;

            foreach (var entry in mapping.Children)
            {
                Console.WriteLine(((YamlScalarNode)entry.Key).Value);
            }

            return frontMatter;
        }

        public static string Blog (string file)
        {
            string contents = File.ReadAllText(file);
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseYamlFrontMatter()
                .Build();
            var result = Markdig.Markdown.ToHtml(contents, pipeline);
            var frontMatter = GetFrontMatter(contents);



            var model = new BlogPost();
            var o = JsonConvert.SerializeObject(model);
            return o;
        }

        public static string Feeds (string file)
        {
            var pieces = file.Split(Path.DirectorySeparatorChar);
            var model = new Feed();
            var o = JsonConvert.SerializeObject(model);
            return o;
        }

        /// <summary>
        /// For every directory with README.md on it, create a new Project
        /// For every md file inside the posts directory of that Project, create a Project Post
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string Projects (string file)
        {
            var pieces = file.Split(Path.DirectorySeparatorChar);
            var model = new Project();
            var o = JsonConvert.SerializeObject(model);
            return o;
        }

        /// <summary>
        /// For every directory with README.md on it, create a new Project
        /// For every md file inside the posts directory of that Project, create a Project Post
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string Study (string file)
        {
            var pieces = file.Split(Path.DirectorySeparatorChar);
            var model = new Study();
            var o = JsonConvert.SerializeObject(model);
            return o;
        }

        public static Dictionary<Types.InputType, Func<string, string>> TypeToImplementationDict()
        {
            var config = new Dictionary<Types.InputType, Func<string, string>>
            {
                { Types.InputType.blog, Blog },
                { Types.InputType.feeds, Feeds },
                { Types.InputType.projects, Projects },
                { Types.InputType.study, Study }
            };
            return config;
        }

        public void ProcessFileDictionary (Dictionary<Types.InputType, IEnumerable<string>> files)
        {
            var configuration = TypeToImplementationDict();
            foreach (var section in files)
            {
                var implementation = configuration[section.Key];
                foreach (var file in section.Value)
                {
                    // translate file into model object
                    //   - read file
                    //   - translate yaml frontmatter
                    //   - translate markdown content
                    //   - Assemble Model object
                    var model = implementation(file);
                }
            }
        }
    }
}
