using ContentManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace ContentManager.FileManagement
{
    public class FrontMatterFormatException : Exception
    {
        public FrontMatterFormatException(string message) : base(message) { }
    }

    public class FrontMatterMissingFieldsException : Exception
    {
        public FrontMatterMissingFieldsException(string message) : base(message) { }
    }

    public class FrontMatterManager
    {
        /// DateTime Notes
        /// Timezone should be passed in date
        ///   - updated_date: 2014-12-05T01:10:29-05:00 (would parse to EST)
        ///   - updated_date: 2014-12-05T01:10:29Z (would parse to UTC)

        /// <summary>
        /// Parse ISO 8601 String date (e.g. 2018-09-18T01:57:41Z) to Datetime
        /// </summary>
        /// <param name="date">ISO 8601 String date</param>
        /// <returns>Datetime object</returns>
        /// <exception cref="ArgumentNullException">Thrown when date is null</exception>
        /// <exception cref="FormatException">Thrown date format and culture info are incompatible</exception>
        public static DateTime FromISODateString(string date)
        {
            return DateTime.Parse(date, null, DateTimeStyles.RoundtripKind);
        }

        public static string FromDateTimeToISOString(DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ssK");
        }

        /// <summary>
        /// Guess what? Newlines are different on windows than on linux
        /// We deal with it
        /// </summary>
        /// <param name="contents">Post content to check for newline</param>
        /// <returns>newline specific for system</returns>
        public static string GetNewLineSeparator(string contents)
        {
            var contentsPiece = contents.Substring(0, 6);
            var newLine = contentsPiece.Contains("\r\n") ?
                "\r\n" : "\n";
            return newLine;
        }

        public static DateTime? GetDateTimeFieldFromMapping(YamlMappingNode mapping, string name)
        {
            if (mapping.Children.ContainsKey(name))
            {
                return FromISODateString(mapping.Children[name].ToString());
            }
            else
            {
                return null;
            }
        }

        public static bool? GetFlag(YamlMappingNode mapping, string name)
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

        /// <summary>
        /// Blows up in case required fields are not available
        /// </summary>
        /// <param name="mapping">Variable dictionary from Post</param>
        /// <exception cref="FrontMatterMissingFieldsException">Thrown when required fields are missing</exception>
        public static void FrontMatterContentSanityCheck(YamlMappingNode mapping)
        {
            bool check(string fieldName) => !mapping.Children.ContainsKey(fieldName) || string.IsNullOrEmpty(mapping.Children[fieldName].ToString());
            var REQUIRED_FIELDS = new List<string> { "title", "slug", "author", "date_created" };
            foreach (var field in REQUIRED_FIELDS)
            {
                if (check(field))
                {
                    var msg = string.Format("'{0}' is mandatory", field);
                    throw new FrontMatterMissingFieldsException(msg);
                }
            }
        }

        public static YamlMappingNode ConvertYaml(string frontMatterYaml)
        {
            var input = new StringReader(frontMatterYaml);
            var yaml = new YamlStream();
            yaml.Load(input);
            YamlMappingNode mapping = (YamlMappingNode)yaml.Documents[0].RootNode;
            return mapping;
        }

        public static string GetFrontMatterFromText(string contents)
        {
            var frontMatterSeparator = "---" + GetNewLineSeparator(contents);
            if (!contents.StartsWith(frontMatterSeparator))
            {
                throw new FrontMatterFormatException("Where is the FrontMatter? I need it, starts with: ---\n");
            }
            int pFrom = contents.IndexOf(frontMatterSeparator);
            int pFromLength = frontMatterSeparator.Length;
            int pTo = contents
                .Substring(pFromLength, contents.Length - pFromLength)
                .IndexOf(frontMatterSeparator);
            if (pTo == -1)
            {
                throw new FrontMatterFormatException("Where is the FrontMatter Ending? I need that too, ends with: ---\n");
            }
            return contents.Substring(pFromLength, pTo);
        }

        public static List<string> GetTags(YamlMappingNode mapping)
        {
            return mapping.Children.ContainsKey("tags") ?
                new List<string>(mapping.Children["tags"].ToString().Split(','))
                :
                new List<string>();
        }

        public static FrontMatter SetupFrontMatter (YamlMappingNode mapping)
        {
            DateTime? published = GetDateTimeFieldFromMapping(mapping, "date_published");
            DateTime? updated = GetDateTimeFieldFromMapping(mapping, "date_updated");
            List<string> tags = GetTags(mapping);
            bool? isDraft = GetFlag(mapping, "draft");
            FrontMatter frontMatter = new FrontMatter
            {
                Title = mapping.Children["title"].ToString(),
                Slug = mapping.Children["slug"].ToString(),
                Author = mapping.Children["author"].ToString(),
                Created = GetDateTimeFieldFromMapping(mapping, "date_created").Value,
                Published = published,
                Updated = updated,
                Tags = tags,
                IsDraft = isDraft
            };
            return frontMatter;
        }

        public static FrontMatter GetFrontMatter(string contents)
        {
            string frontMatterYaml = GetFrontMatterFromText(contents);
            YamlMappingNode mapping = ConvertYaml(frontMatterYaml);
            FrontMatterContentSanityCheck(mapping);
            return SetupFrontMatter(mapping);
        }
    }

}
