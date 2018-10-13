﻿using ContentManager.FileManagement;
using ContentManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContentManager.Test
{
    public class FrontMatterShould
    {
        [Fact]
        public void ParsesTitleSlugAndDraftFlag()
        {
            string mockPost = @"---
title: Docker Installation Notes
slug: docker-installation-notes
author: oreo
draft: true
date_created: 2018-10-13T16:08:55+00:00
---
<my-component>Some-data</my-component>
";
            FrontMatter frontMatter = FrontMatterManager.GetFrontMatter(mockPost);
            Assert.Equal("Docker Installation Notes", frontMatter.Title);
            Assert.Equal("docker-installation-notes", frontMatter.Slug);
            Assert.Null(frontMatter.Published);
            Assert.Null(frontMatter.Updated);
            Assert.True(frontMatter.IsDraft);
        }

        [Theory]
        [MemberData(nameof(GetFrontMatterFormatExceptionPosts))]
        public void WillExplodeIfFrontMatterHasNoStartOrEnd(string mockPost, string message)
        {
            Exception ex = Assert.Throws<FrontMatterFormatException>(() => FrontMatterManager.GetFrontMatter(mockPost));
            Assert.Equal(message, ex.Message);
        }

        [Theory]
        [MemberData(nameof(GetFrontMatterMissingFieldsExceptionPosts))]
        public void WillExplodeIfFieldIsRequired(string mockPost, string message)
        {
            Exception ex = Assert.Throws<FrontMatterMissingFieldsException>(() => FrontMatterManager.GetFrontMatter(mockPost));
            Assert.Equal(message, ex.Message);
        }

        /// <summary>
        /// Makes sure saved time and string time passed are the same. Time is saved in
        /// UTC
        /// </summary>
        /// <param name="mockPost">The Mock Content with a Valid FrontMatter</param>
        /// <param name="publishedDate">String with date_published</param>
        /// <param name="updatedDate">String with date_updated</param>
        [Theory]
        [MemberData(nameof(GetDatesAndMockPost))]
        public void ParsesDateTimesAndIsDraftNull(string mockPost, string publishedDate, string updatedDate)
        {
            var frontMatter = FrontMatterManager.GetFrontMatter(mockPost);
            DateTime pbDate = frontMatter.Published.Value;
            DateTime upDate = frontMatter.Updated.Value;
            DateTime publishedDateTime = FrontMatterManager.FromISODateString(publishedDate);
            DateTime updatedDateTime = FrontMatterManager.FromISODateString(updatedDate);
            Assert.Equal(publishedDateTime.Ticks, pbDate.Ticks);
            Assert.Equal(updatedDateTime.Ticks, upDate.Ticks);
            Assert.Null(frontMatter.IsDraft);
        }

        [Theory]
        [MemberData(nameof(GetDatesExceptions))]
        public void CheckDateTimeParsingThrows(string mockPost)
        {
            Exception ex = Assert.Throws<FormatException>(() => FrontMatterManager.GetFrontMatter(mockPost));
        }

        public static string mockDateTemplate = @"---
title: Some Title
slug: some-slug
author: oreo
date_created: 2018-10-13T16:08:55-05:00
date_published: {0}
date_updated: {1}
---
<my-component>Some-data</my-component>
";

        public static IEnumerable<object[]> GetDatesAndMockPost()
        {
            var t1PublishedDate = "1950-01-01T00:00:00Z";
            var t1UpdateDate = "2018-10-13T16:08:55-05:00";
            var builder = new StringBuilder();

            builder.AppendFormat(mockDateTemplate, t1PublishedDate, t1UpdateDate);
            var t1MockPost = builder.ToString();
            builder.Clear();

            var allData = new List<object[]>
            {
                new object[]
                {
                     t1MockPost,
                     t1PublishedDate,
                     t1UpdateDate
                }
            };
            return allData;
        }

        public static IEnumerable<object[]> GetDatesExceptions()
        {
            var builder = new StringBuilder();

            builder.AppendFormat(mockDateTemplate, "lsdfkj", ";sadfl");
            var t1MockPost = builder.ToString();
            builder.Clear();

            builder.AppendFormat(mockDateTemplate, "1950-01-01T00:00:00Z", ";sadfl");
            var t2MockPost = builder.ToString();
            builder.Clear();

            builder.AppendFormat(mockDateTemplate, "lsdfkj", "1950-01-01T00:00:00Z");
            var t3MockPost = builder.ToString();
            builder.Clear();

            builder.AppendFormat(mockDateTemplate, "", "");
            var t4MockPost = builder.ToString();
            builder.Clear();

            var allData = new List<object[]>
            {
                new object[] { t1MockPost },
                new object[] { t2MockPost },
                new object[] { t3MockPost },
                new object[] { t4MockPost }
            };
            return allData;
        }

        public static IEnumerable<object[]> GetFrontMatterFormatExceptionPosts()
        {
            return new List<object[]>
            {
                new object[]
                {
                    @"
title: some-title
slug: some-slug
author: oreo
---
<my-component>Some-data</my-component>
",
                "Where is the FrontMatter? I need it, starts with: ---\n"
                },
                new object[]
                {
                    @"---
title: some-title
slug: some-slug
author: oreo

<my-component>Some-data</my-component>
",
                "Where is the FrontMatter Ending? I need that too, ends with: ---\n"
                }
            };
        }

        public static IEnumerable<object[]> GetFrontMatterMissingFieldsExceptionPosts()
        {
            return new List<object[]>
            {
                new object[]
                {
                    @"---
title: 
slug: some-slug
---
<my-component>Some-data</my-component>
",
                "'title' is mandatory"
                },
                new object[]
                {
                    @"---
slug: some-slug
---
<my-component>Some-data</my-component>
",
                "'title' is mandatory"
                },
                new object[]
                {
                    @"---
title: some-title
slug: 
---
<my-component>Some-data</my-component>
",
                "'slug' is mandatory"
                },
                new object[]
                {
                    @"---
title: some-title
---
<my-component>Some-data</my-component>
",
                "'slug' is mandatory"
                },
                new object[]
                {
                    @"---
title: some-title
slug: some-slug
author:
---
<my-component>Some-data</my-component>
",
                "'author' is mandatory"
                },
                new object[]
                {
                    @"---
title: some title
slug: some-slug
---
<my-component>Some-data</my-component>
",
                "'author' is mandatory"
                },
                new object[]
                {
                    @"---
title: some title
slug: some-slug
author: some author
---
<my-component>Some-data</my-component>
",
                "'date_created' is mandatory"
                },
                new object[]
                {
                    @"---
title: some title
slug: some-slug
author: some author
date_created:
---
<my-component>Some-data</my-component>
",
                "'date_created' is mandatory"
                },
            };
        }
    }
}
