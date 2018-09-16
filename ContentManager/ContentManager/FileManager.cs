using ContentManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Markdig;
using YamlDotNet.RepresentationModel;

namespace ContentManager
{
    public class FrontMatter
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime? Published { get; set; }
        public DateTime? Updated { get; set; }
        public List<string> Tags { get; set; }
        public Boolean? IsDraft { get; set; }
    }

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

        public static DateTime FromISODateString (string date)
        {
            return DateTime.Parse(date, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }

        public static string GetNewLineSeparator (string contents)
        {
            var contentsPiece = contents.Substring(0, 6);
            var newLine = contentsPiece.Contains("\r\n") ?
                "\r\n" : "\n";
            return newLine;
        }

        public static DateTime? GetDateTimeFieldFromMapping (YamlMappingNode mapping, string name)
        {
            if (mapping.Children.ContainsKey(name))
            {
                return FromISODateString(mapping.Children[name].ToString());
            } else
            {
                return null;
            }
        }

        public static Boolean? GetFlag(YamlMappingNode mapping, string name)
        {
            if (mapping.Children.ContainsKey(name))
            {
                return mapping.Children[name].ToString() == "true" ? true : false; 
            }
            else
            {
                return null;
            }
        }

        public static FrontMatter GetFrontMatter (string contents)
        {
            var frontMatterSeparator = "---" + GetNewLineSeparator(contents);
            if (!contents.StartsWith(frontMatterSeparator))
            {
                throw new Exception("FrontMatter: Where is the FrontMatter? I need it, starts with: ---\n");
            }
            int pFrom = contents.IndexOf(frontMatterSeparator);
            int pFromLength = frontMatterSeparator.Length;
            int pTo = contents
                .Substring(pFromLength, contents.Length - pFromLength)
                .IndexOf(frontMatterSeparator);
            if (pTo == -1)
            {
                throw new Exception("FrontMatter: Where is the FrontMatter Ending? I need that too, ends with: ---\n");
            }
            var frontMatterYaml = contents.Substring(pFromLength, pTo);
            var input = new StringReader(frontMatterYaml);
            var yaml = new YamlStream();
            yaml.Load(input);
            var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
            if (!mapping.Children.ContainsKey("title"))
            {
                throw new Exception("FrontMatter: title is mandatory");
            }
            if (!mapping.Children.ContainsKey("slug"))
            {
                throw new Exception("FrontMatter: slug is mandatory");
            }
            DateTime? publishedDate = GetDateTimeFieldFromMapping(mapping, "date_published");
            DateTime? updatedDate = GetDateTimeFieldFromMapping(mapping, "date_updated");
            var tags = mapping.Children.ContainsKey("tags") ? new List<string>(mapping.Children["tags"].ToString().Split(',')) : new List<string>();
            var isDraft = GetFlag(mapping, "draft");
            var frontMatter = new FrontMatter
            {
                Title = mapping.Children["title"].ToString(),
                Slug = mapping.Children["slug"].ToString(),
                Published = publishedDate,
                Updated = updatedDate,
                Tags = tags,
                IsDraft = isDraft
            };
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
