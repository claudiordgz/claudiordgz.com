using Xunit;
using FluentAssertions;
using Xunit.Abstractions;
using ContentManager.Util;

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
        public void HandlesSshRemoteAndHttpsRemote(string remoteUrl)
        {
            (string user, string repository) = Git.GetUserAndRepository(remoteUrl);
            user.Should().Be("claudiordgz-website");
            repository.Should().Be("content");
        }
    }
}
