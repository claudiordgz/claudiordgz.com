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
            List<string> mockChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "content/ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "content/ContentManager/ContentManager.Test/GetFilesShould.cs",
                "content/ContentManager/ContentManager.Test/Properties/launchSettings.json",
                "content/ContentManager/ContentManager.Test/scripts/checkCoverage.js",
                "content/ContentManager/ContentManager.sln",
                "content/ContentManager/ContentManager/GetFiles.cs",
                "content/ContentManager/ContentManager/Models.cs",
                "content/ContentManager/ContentManager/Options.cs",
                "content/ContentManager/ContentManager/Program.cs",
                "content/ContentManager/ContentManager/Properties/launchSettings.json",
                "content/ContentManager/ContentManager/Types.cs",
                "content/ContentManager/ContentManagerTest/UnitTest1.cs",
                "content/ContentManager/README.md",
                "backend/someFile.tf",
                "frontend/someOtherFile.js"
            };

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            (string GitDirectory, string ContentDirectory) = GetSrc.SrcPath();
            GetFilesFromDiff gitHelper = new GetFilesFromDiff(mockRepo.Object, GitDirectory, "content");
            Dictionary<Types.InputType, IEnumerable<string>> files = gitHelper.PackPaths(mockChanges as IEnumerable<string>);
            Assert.Empty(files);
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void ReturnsContentSpecificFolder(Types.InputType type, IEnumerable<string> list, int fileCount)
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            (string GitDirectory, string ContentDirectory) = GetSrc.SrcPath();
            GetFilesFromDiff gitHelper = new GetFilesFromDiff(mockRepo.Object, GitDirectory, "content");
            Dictionary<Types.InputType, IEnumerable<string>> files = gitHelper.PackPaths(list as IEnumerable<string>);
            Assert.Single(files);
            foreach (KeyValuePair<Types.InputType, IEnumerable<string>> entry in files)
            {
                Assert.Equal(type, entry.Key);
                Assert.Equal(fileCount, entry.Value.Count());
                foreach (string file in entry.Value)
                {
                    AnallyExpect.MarkDownOrXmlFiles(file);
                    Assert.Contains(type.ToString("g"), file);
                }
            }
        }

        public static IEnumerable<object[]> GetData()
        {
            List<string> blogChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "content/blog/README.md",
                "content/blog/LICENSE",
                "content/blog/posts/about-me.md",
                "content/blog/posts/abstract-factory-cpp.md",
                "content/blog/posts/ad-generator-thoughts-after-first-commit.md"
            };
            List<string> feedChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "content/feeds/engineering-blogs.opml",
                "content/feeds/README.md"
            };
            List<string> projectChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "content/projects/blog/README.md",
                "content/projects/blog/posts/redesigning-the-blog.md",
                "content/projects/README.md",
                "content/projects/LICENSE"
            };
            List<string> studyChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "content/study/cormen/README.md",
                "content/study/cormen/posts/corment-algorithms-ch02.md",
                "content/study/README.md",
                "content/study/LICENSE"
            };
            List<object[]> allData = new List<object[]>
            {
                new object[] { Types.InputType.blog, blogChanges, 3 },
                new object[] { Types.InputType.feeds, feedChanges, 1 },
                new object[] { Types.InputType.projects, projectChanges, 2 },
                new object[] { Types.InputType.study, studyChanges, 2 },
            };
            return allData;
        }
    }
}
