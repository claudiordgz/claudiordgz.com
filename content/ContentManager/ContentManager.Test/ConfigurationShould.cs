using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContentManager.Test
{
    public class ConfigurationShould
    {
        [Fact]
        public void ConfigurationPopulatesAuthors()
        {
            (string GitDirectory, string ContentDirectory) = GetSrc.SrcPath();
            Configuration configuration = new Configuration(GitDirectory, ContentDirectory);
            configuration.Defaults.Authors.Should().NotBeEmpty();
        }

        [Fact]
        public void ThumbnailPathMustBeSet()
        {
            (string GitDirectory, string ContentDirectory) = GetSrc.SrcPath();
            Configuration configuration = new Configuration(GitDirectory, ContentDirectory);
            configuration.Defaults.ThumbnailDirectory.Should().NotBeEmpty();
        }

        [Fact]
        public void CreditsMustBeDefinedy()
        {
            (string GitDirectory, string ContentDirectory) = GetSrc.SrcPath();
            Configuration configuration = new Configuration(GitDirectory, ContentDirectory);
            configuration.Defaults.Credits.Should().NotBeEmpty();
        }

        [Fact]
        public void ThumbnailsMustBeDefined()
        {
            (string GitDirectory, string ContentDirectory) = GetSrc.SrcPath();
            Configuration configuration = new Configuration(GitDirectory, ContentDirectory);
            configuration.Defaults.Thumbnails.Should().NotBeEmpty();
        }
    }
}
