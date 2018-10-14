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
            var rootPath = GetSrc.SrcPath();
            var configuration = new Configuration(rootPath);
            configuration.Defaults.Authors.Should().NotBeEmpty();
        }

        [Fact]
        public void ThumbnailPathMustBeSet()
        {
            var rootPath = GetSrc.SrcPath();
            var configuration = new Configuration(rootPath);
            configuration.Defaults.ThumbnailDirectory.Should().NotBeEmpty();
        }

        [Fact]
        public void CreditsMustBeDefinedy()
        {
            var rootPath = GetSrc.SrcPath();
            var configuration = new Configuration(rootPath);
            configuration.Defaults.Credits.Should().NotBeEmpty();
        }

        [Fact]
        public void ThumbnailsMustBeDefined()
        {
            var rootPath = GetSrc.SrcPath();
            var configuration = new Configuration(rootPath);
            configuration.Defaults.Thumbnails.Should().NotBeEmpty();
        }
    }
}
