using System.Collections.Generic;
using Xunit;
using LibGit2Sharp;
using Moq;
using System.Linq;

namespace ContentManager.Test
{
    public class GetFilesFromDiffShould
    {

        [Fact]
        public void IgnoresNonContentDirectories()
        {
            var mockChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "ContentManager/ContentManager.Test/GetFilesShould.cs",
                "ContentManager/ContentManager.Test/Properties/launchSettings.json",
                "ContentManager/ContentManager.Test/scripts/checkCoverage.js",
                "ContentManager/ContentManager.sln",
                "ContentManager/ContentManager/GetFiles.cs",
                "ContentManager/ContentManager/Models.cs",
                "ContentManager/ContentManager/Options.cs",
                "ContentManager/ContentManager/Program.cs",
                "ContentManager/ContentManager/Properties/launchSettings.json",
                "ContentManager/ContentManager/Types.cs",
                "ContentManager/ContentManagerTest/UnitTest1.cs",
                "ContentManager/README.md"
            };

            var mockRepo = new Mock<IRepository>();
            var srcPath = GetSrc.SrcPath();
            var gitHelper = new GetFilesFromDiff(mockRepo.Object, srcPath);
            var files = gitHelper.packPaths(mockChanges as IEnumerable<string>);
            Assert.Empty(files);
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void ReturnsContentSpecificFolder(Types.InputType type, IEnumerable<string> list)
        {
            var mockRepo = new Mock<IRepository>();
            var srcPath = GetSrc.SrcPath();
            var gitHelper = new GetFilesFromDiff(mockRepo.Object, srcPath);
            var files = gitHelper.packPaths(list as IEnumerable<string>);
            Assert.Single(files);
            foreach (var entry in files)
            {
                Assert.Equal(type, entry.Key);
                foreach (var file in entry.Value)
                {
                    AnallyExpect.MarkDownOrXmlFiles(file);
                }
            }
        }

        public static IEnumerable<object[]> GetData()
        {
            var blogChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "blog/posts/about-me.md",
                "blog/posts/abstract-factory-cpp.md",
                "blog/posts/ad-generator-thoughts-after-first-commit.md"
            };
            var feedChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "feeds/engineering-blogs.opml",
                "feeds/README.md"
            };
            var projectChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "projects/blog/README.md",
                "projects/blog/posts/redesigning-the-blog.md",
                "projects/README.md",
                "projects/LICENSE"
            };
            var studyChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "study/cormen/README.md",
                "study/cormen/posts/corment-algorithms-ch02.md",
                "study/README.md",
                "study/LICENSE"
            };
            var allData = new List<object[]>
            {
                new object[] { Types.InputType.blog, blogChanges },
                new object[] { Types.InputType.feeds, feedChanges },
                new object[] { Types.InputType.projects, projectChanges },
                new object[] { Types.InputType.study, studyChanges },
            };
            return allData;
        }
    }
}
