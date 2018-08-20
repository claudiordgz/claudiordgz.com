using System;
using Xunit;
using System.IO;

namespace ContentManager.Tests
{
    public class GetAllFilesShould
    {
        internal static string getSrcPath ()
        {
            var binPath = Directory.GetCurrentDirectory();
            var rPath = Path.Combine(binPath, "../../../../..");
            return Path.GetFullPath((new Uri(rPath)).LocalPath);
        }

        internal static void AnallyExpectMarkdownFiles (string file)
        {
            var ext = Path.GetExtension(file);
            var condition = ext.Contains("opml") || ext.Contains("xml") || ext.Contains("md");
            Assert.True(condition);
        }

        [Fact]
        public void ReturnsContentFromAllFolders()
        {
            var srcPath = getSrcPath();
            var types = Types.GetTypes(Types.InputType.all);
            var files = GetFiles.getAllFiles(types, srcPath);
            // blog, feeds, study, projects
            Assert.Equal(4, files.Count);
            foreach(var entry in files)
            {
                foreach(var file in entry.Value)
                {
                    AnallyExpectMarkdownFiles(file);
                }
            }
        }

        [Theory]
        [InlineData(Types.InputType.blog)]
        [InlineData(Types.InputType.feeds)]
        [InlineData(Types.InputType.projects)]
        [InlineData(Types.InputType.study)]
        public void ReturnsContentSpecificFolder(Types.InputType type)
        {
            var srcPath = getSrcPath();
            var types = Types.GetTypes(type);
            var files = GetFiles.getAllFiles(types, srcPath);
            // blog, feeds, study, projects
            Assert.Single(files);
            foreach (var entry in files)
            {
                Assert.Equal(type, entry.Key);
                foreach (var file in entry.Value)
                {
                    AnallyExpectMarkdownFiles(file);
                }
            }
        }
    }
}
