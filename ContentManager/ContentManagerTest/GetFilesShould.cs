using System;
using Xunit;
using ContentManager;
using System.IO;

namespace ContentManager.Tests
{
    public class GetFilesShould
    {

        [Fact]
        public void ReturnBlogPostsFiles()
        {
            var srcPath = Environment.GetEnvironmentVariable("CODEBUILD_SRC_DIR");
            var types = Types.GetAllTypes(Types.InputType.all);
            var files = GetFiles.getAllFiles(types, srcPath);
            Console.WriteLine(srcPath);
            var a = 1;
        }
    }
}
