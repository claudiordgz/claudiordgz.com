using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace ContentManager.Test
{
    public static class AnallyExpect
    {
        public static void MarkDownOrXmlFiles(string file)
        {
            string ext = Path.GetExtension(file);
            bool condition = ext.Contains("opml") || ext.Contains("xml") || ext.Contains("md");
            Assert.True(condition);
        }

        public static void MarkdownXmlOrOpmlFilesOnAll(Dictionary<Types.InputType, IEnumerable<string>> files)
        {
            // blog, feeds, study, projects
            Assert.Equal(4, files.Count);
            foreach (KeyValuePair<Types.InputType, IEnumerable<string>> entry in files)
            {
                Types.InputType type = entry.Key;
                foreach (string file in entry.Value)
                {
                    MarkDownOrXmlFiles(file);
                    Assert.Contains(type.ToString("g"), file);
                }
            }
        }

        public static void MarkdownXmlOrOpmlFilesOnSingleType(Types.InputType type, Dictionary<Types.InputType, IEnumerable<string>> files)
        {
            // blog, feeds, study, projects
            Assert.Single(files);
            foreach (KeyValuePair<Types.InputType, IEnumerable<string>> entry in files)
            {
                Assert.Equal(type, entry.Key);
                foreach (string file in entry.Value)
                {
                    MarkDownOrXmlFiles(file);
                    Assert.Contains(type.ToString("g"), file);
                }
            }
        }
    }
}
