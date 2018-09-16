using System;
using System.Collections.Generic;
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
            var configuration = FileManager.TypeToImplementationDict();
            var srcPath = GetSrc.SrcPath();
            var combinedPath = Path.Combine(srcPath, "blog");
            combinedPath = Path.Combine(combinedPath, "posts");
            combinedPath = Path.Combine(combinedPath, "the-mothfng-facebook-feed-dialog.md");
            var implementation = configuration[Types.InputType.blog];
            var model = implementation(combinedPath);
        }

        [Fact]
        public void ReturnsExpectedFrontMatter()
        {
            string mockPost = @"---
title: Docker Installation Notes
slug: docker-installation-notes
date_published: 1970-01-01T00:00:00.000Z
date_updated:   2014-12-05T01:10:29.904Z
draft: true
---
<my-component>Some-data</my-component>
";
            var frontMatter = FileManager.GetFrontMatter(mockPost);
            Assert.Equal("Docker Installation Notes", frontMatter.Title);
            Assert.Equal("docker-installation-notes", frontMatter.Slug);
            Assert.True(frontMatter.IsDraft);
        }
    }
}
