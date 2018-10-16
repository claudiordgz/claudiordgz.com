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
            string rootPath = GetSrc.SrcPath();
            Configuration configuration = new Configuration(rootPath);
            configuration.Defaults.Authors.Should().NotBeEmpty();
        }

        [Fact]
        public void ThumbnailPathMustBeSet()
        {
            string rootPath = GetSrc.SrcPath();
            Configuration configuration = new Configuration(rootPath);
            configuration.Defaults.ThumbnailDirectory.Should().NotBeEmpty();
        }

        [Fact]
        public void CreditsMustBeDefinedy()
        {
            string rootPath = GetSrc.SrcPath();
            Configuration configuration = new Configuration(rootPath);
            configuration.Defaults.Credits.Should().NotBeEmpty();
        }

        [Fact]
        public void ThumbnailsMustBeDefined()
        {
            string rootPath = GetSrc.SrcPath();
            Configuration configuration = new Configuration(rootPath);
            configuration.Defaults.Thumbnails.Should().NotBeEmpty();
        }
    }
}
