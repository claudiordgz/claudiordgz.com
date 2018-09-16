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
            var configuration = FileManager.TypeToImplementationDict();
            var srcPath = GetSrc.SrcPath();
            var combinedPath = Path.Combine(srcPath, "blog");
            combinedPath = Path.Combine(combinedPath, "posts");
            combinedPath = Path.Combine(combinedPath, "the-mothfng-facebook-feed-dialog.md");
            var implementation = configuration[Types.InputType.blog];
            var model = implementation(combinedPath);
        }

        [Fact]
        public void ParsesTitleSlugAndDraftFlag ()
        {
            string mockPost = @"---
title: Docker Installation Notes
slug: docker-installation-notes
draft: true
---
<my-component>Some-data</my-component>
";
            var frontMatter = FileManager.GetFrontMatter(mockPost);
            Assert.Equal("Docker Installation Notes", frontMatter.Title);
            Assert.Equal("docker-installation-notes", frontMatter.Slug);
            Assert.Null(frontMatter.Published);
            Assert.Null(frontMatter.Updated);
            Assert.True(frontMatter.IsDraft);
        }

        [Fact]
        public void ParsesDateTimes ()
        {
            var builder = new StringBuilder();
            var publishedDate = "1970-01-01T00:00:00.0000000Z";
            var updatedDate = "2014-12-05T01:10:29.9040000Z";
            builder.AppendFormat(@"---
title: Some Title
slug: some-slug
date_published: {0}
date_updated: {1}
---
<my-component>Some-data</my-component>
", publishedDate, updatedDate);
            var mockPost = builder.ToString();
            var frontMatter = FileManager.GetFrontMatter(mockPost);
            string pbDate = frontMatter.Published.Value.ToString("o");
            string upDate = frontMatter.Updated.Value.ToString("o");
            Assert.Equal(publishedDate, pbDate);
            Assert.Equal(updatedDate, upDate);
        }
    }
}
