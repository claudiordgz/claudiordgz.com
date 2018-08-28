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
            var ext = Path.GetExtension(file);
            var condition = ext.Contains("opml") || ext.Contains("xml") || ext.Contains("md");
            Assert.True(condition);
        }

        public static void MarkdownXmlOrOpmlFilesOnAll(Dictionary<Types.InputType, IEnumerable<string>> files)
        {
            // blog, feeds, study, projects
            Assert.Equal(4, files.Count);
            foreach (var entry in files)
            {
                var type = entry.Key;
                foreach (var file in entry.Value)
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
            foreach (var entry in files)
            {
                Assert.Equal(type, entry.Key);
                foreach (var file in entry.Value)
                {
                    MarkDownOrXmlFiles(file);
                    Assert.Contains(type.ToString("g"), file);
                }
            }
        }
    }
}
