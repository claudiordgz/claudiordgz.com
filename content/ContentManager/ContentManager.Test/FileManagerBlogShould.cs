using ContentManager.FileManagement;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xunit;

namespace ContentManager.Test
{
    public class FileManagerBlogShould
    {
        [Fact(Skip ="For now")]
        public void ReturnTheModelAsAString()
        {
            Dictionary<Types.InputType, Func<string, string>> configuration = FileManager.TypeToImplementationDict();
            (string _, string ContentDirectory) = GetSrc.SrcPath();
            string combinedPath = Path.Combine(ContentDirectory, "blog");
            combinedPath = Path.Combine(combinedPath, "posts");
            combinedPath = Path.Combine(combinedPath, "the-mothfng-facebook-feed-dialog.md");
            Func<string, string> implementation = configuration[Types.InputType.blog];
            string model = implementation(combinedPath);
        }

        
    }
}
