﻿using Xunit;
using FluentAssertions;
using System.Linq;
using Xunit.Abstractions;
using ContentManager.Util;
using System.IO;
using System;

namespace ContentManager.Test
{
    public class GithubUtilsShould
    {
        [Fact]
        public void GetsRepositoryProperties()
        {
            string srcPath = GetSrc.SrcPath();
            RepositorySettings props = Git.GetCurrentGithubProperties(srcPath);
            props.User.Should().NotBeEmpty("User needs to be defined");
            props.Branch.Should().NotBeEmpty("Branch needs to be defined");
            props.Repository.Should().NotBeEmpty("Repository needs to be defined");
            props.User.Should().NotBeNullOrWhiteSpace("User needs to be defined");
            props.Branch.Should().NotBeNullOrWhiteSpace("Branch needs to be defined");
            props.Repository.Should().NotBeNullOrWhiteSpace("Repository needs to be defined");
        }

        [Theory]
        [InlineData("git@github.com:claudiordgz-website/content.git")]
        [InlineData("https://github.com/claudiordgz-website/content")]
        public void HandleSshRemoteAndHttpsRemote(string remoteUrl)
        {
            (string user, string repository) = Git.GetUserAndRepository(remoteUrl);
            user.Should().Be("claudiordgz-website");
            repository.Should().Be("content");
        }

        [Fact]
        public void GetUrlWithBranchReturnsFullyQualifiedUrl ()
        {
            string srcPath = GetSrc.SrcPath();
            Configuration config = new Configuration(srcPath);
            Models.Thumbnail firstImage = config.Defaults.Thumbnails.First();
            string pathToThumbnail = firstImage.File;
            Uri uriToAsset = Git.AssembleUrlToAssetOnGithub(config.GithubProperties, srcPath, pathToThumbnail);
            uriToAsset.Host.Should().Be("raw.githubusercontent.com");
            string localPath = uriToAsset.LocalPath.Substring(1);
            string[] pathPieces = localPath.Split('/');
            pathPieces[0].Should().Be(config.GithubProperties.User);
            pathPieces[1].Should().Be(config.GithubProperties.Repository);
            pathPieces[2].Should().Be(config.GithubProperties.Branch);
            localPath.Should().EndWith(firstImage.File);
        }
    }
}
