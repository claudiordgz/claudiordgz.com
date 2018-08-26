using System;
using Xunit;
using System.IO;
using ContentManager.Test;

namespace ContentManager.Tests
{
    public class GetAllFilesShould
    {

        [Fact]
        public void ReturnsContentFromAllFolders()
        {
            var srcPath = GetSrc.SrcPath();
            var types = Types.GetTypes(Types.InputType.all);
            var files = GetAllFiles.getAllFiles(types, srcPath);
            // blog, feeds, study, projects
            Assert.Equal(4, files.Count);
            foreach(var entry in files)
            {
                foreach(var file in entry.Value)
                {
                    AnallyExpect.MarkDownOrXmlFiles(file);
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
            var srcPath = GetSrc.SrcPath();
            var types = Types.GetTypes(type);
            var files = GetAllFiles.getAllFiles(types, srcPath);
            // blog, feeds, study, projects
            Assert.Single(files);
            foreach (var entry in files)
            {
                Assert.Equal(type, entry.Key);
                foreach (var file in entry.Value)
                {
                    AnallyExpect.MarkDownOrXmlFiles(file);
                }
            }
        }
    }
}
