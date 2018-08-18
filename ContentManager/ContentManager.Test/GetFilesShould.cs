using System;
using Xunit;
using System.IO;

namespace ContentManager.Tests
{
    public class GetFilesShould
    {

        [Fact]
        public void ReturnAllTypeOfFiles()
        {
            var binPath = Directory.GetCurrentDirectory();
            var rPath = Path.Combine(binPath, "..\\..\\..\\..\\..");
            var srcPath = Path.GetFullPath((new Uri(rPath)).LocalPath);
            var types = Types.GetAllTypes(Types.InputType.all);
            var files = GetFiles.getAllFiles(types, srcPath);
            // blog, feeds, study, projects
            Assert.Equal(4, files.Count);
            foreach(var entry in files)
            {
                foreach(var file in entry.Value)
                {
                    // anally expect markdown files
                    var ext = Path.GetExtension(file);
                    var condition = ext.Contains("opml") || ext.Contains("xml") || ext.Contains("md");
                    Assert.True(condition);
                }
            }
        }
    }
}
