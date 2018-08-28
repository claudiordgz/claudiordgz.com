using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace ContentManager.Test
{
    public class FileManagerBlogShould
    {
        [Fact]
        public void ReturnTheModelAsAString()
        {
            var configuration = FileManager.TypeToImplementationDict();
            var srcPath = GetSrc.SrcPath();
            var combinedPath = Path.Combine(srcPath, "blog");
            combinedPath = Path.Combine(combinedPath, "posts");
            combinedPath = Path.Combine(combinedPath, "the-mothfng-facebook-feed-dialog.md");
            var implementation = configuration[Types.InputType.blog];
            var model = implementation(combinedPath);
        }
    }
}
