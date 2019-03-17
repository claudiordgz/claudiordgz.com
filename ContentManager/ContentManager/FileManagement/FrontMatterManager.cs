using ContentManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

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
            return DateTime.ParseExact(date, "yyyy-MM-dd'T'HH:mm:ss.FFFK", CultureInfo.InvariantCulture);
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
            string contentsPiece = contents.Substring(0, 6);
            string newLine = contentsPiece.Contains("\r\n") ?
                "\r\n" : "\n";
            return newLine;
        }

        /// <summary>
        /// Blows up in case required fields are not available
        /// </summary>
        /// <param name="mapping">Variable dictionary from Post</param>
        /// <exception cref="FrontMatterMissingFieldsException">Thrown when required fields are missing</exception>
        private static void FrontMatterContentSanityCheck(FrontMatter frontMatter)
        {
            List<string> REQUIRED_FIELDS = new List<string> { "Title", "Slug", "Author", "Created" };
            foreach (string field in REQUIRED_FIELDS)
            {
                if (frontMatter[field] == null)
                {
                    string msg = string.Format("'{0}' is mandatory", field);
                    throw new FrontMatterMissingFieldsException(msg);
                }
            }
        }

        private static string GetFrontMatterFromText(string contents)
        {
            string frontMatterSeparator = "---" + GetNewLineSeparator(contents);
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

        public static FrontMatter DeserializeContent(string contents)
        {
            try
            {
                string frontMatterYaml = GetFrontMatterFromText(contents);

                YamlStream yaml = new YamlStream();
                StringReader input = new StringReader(frontMatterYaml);

                Deserializer deserializer = new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention())
                    .Build();

                FrontMatter frontMatter = deserializer.Deserialize<FrontMatter>(input);
                return frontMatter;
            }
            catch (Exception e)
            {
                throw new FrontMatterFormatException(e.Message);
            }
        }

        public static FrontMatter GetFrontMatter(string contents)
        {
            FrontMatter frontMatter = DeserializeContent(contents);
            FrontMatterContentSanityCheck(frontMatter);
            return frontMatter;
        }
    }

}
