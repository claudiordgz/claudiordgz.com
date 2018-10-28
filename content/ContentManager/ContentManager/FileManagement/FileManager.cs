using ContentManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Markdig;

namespace ContentManager.FileManagement
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

        public static string GetSummaryFromContent(string content)
        {
            return "";
        }

        public static string GetThumbnailFromFrontMatterOrContent(FrontMatter frontMatter, string content)
        {
            return "";
        }

        public static string GetDefaultThumbnails()
        {
            return "";
        }

        public static string Blog (string file)
        {
            string contents = File.ReadAllText(file);
            MarkdownPipeline pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseYamlFrontMatter()
                .Build();
            string result = Markdown.ToHtml(contents, pipeline);
            FrontMatter frontMatter = FrontMatterManager.GetFrontMatter(contents);
            BlogPost model = new BlogPost
            {
                Headline = frontMatter.Title,
                Id = frontMatter.Slug,
                Summary = "",
                Tags = frontMatter.Tags,
                DateCreated = FrontMatterManager.FromDateTimeToISOString(frontMatter.Created.Value),
                DateUpdated = frontMatter.Updated.HasValue ? FrontMatterManager.FromDateTimeToISOString(frontMatter.Updated.Value) : "",
                DatePublished = frontMatter.Updated.HasValue ? FrontMatterManager.FromDateTimeToISOString(frontMatter.Published.Value) : ""
            };
            string o = JsonConvert.SerializeObject(model);
            return o;
        }

        public static string Feeds (string file)
        {
            string[] pieces = file.Split(Path.DirectorySeparatorChar);
            Feed model = new Feed();
            string o = JsonConvert.SerializeObject(model);
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
            string[] pieces = file.Split(Path.DirectorySeparatorChar);
            Project model = new Project();
            string o = JsonConvert.SerializeObject(model);
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
            string[] pieces = file.Split(Path.DirectorySeparatorChar);
            Study model = new Study();
            string o = JsonConvert.SerializeObject(model);
            return o;
        }

        public static Dictionary<Types.InputType, Func<string, string>> TypeToImplementationDict()
        {
            Dictionary<Types.InputType, Func<string, string>> config = new Dictionary<Types.InputType, Func<string, string>>
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
            Dictionary<Types.InputType, Func<string, string>> configuration = TypeToImplementationDict();
            foreach (KeyValuePair<Types.InputType, IEnumerable<string>> section in files)
            {
                Func<string, string> implementation = configuration[section.Key];
                foreach (string file in section.Value)
                {
                    // translate file into model object
                    //   - read file
                    //   - translate yaml frontmatter
                    //   - translate markdown content
                    //   - Assemble Model object
                    string model = implementation(file);
                }
            }
        }
    }
}
