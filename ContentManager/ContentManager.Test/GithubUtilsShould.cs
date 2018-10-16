using Xunit;
using FluentAssertions;

namespace ContentManager.Test
{
    public class GithubUtilsShould
    {
        [Fact]
        public void GetsRepositoryProperties()
        {
            string srcPath = GetSrc.SrcPath();
            Util.RepositorySettings props = Util.Git.GetCurrentGithubProperties(srcPath);
            props.User.Should().NotBeEmpty("User needs to be defined");
            props.Branch.Should().NotBeEmpty("Branch needs to be defined");
            props.Repository.Should().NotBeEmpty("Repository needs to be defined");
            props.User.Should().NotBeNullOrWhiteSpace("User needs to be defined");
            props.Branch.Should().NotBeNullOrWhiteSpace("Branch needs to be defined");
            props.Repository.Should().NotBeNullOrWhiteSpace("Repository needs to be defined");
        }
    }
}
