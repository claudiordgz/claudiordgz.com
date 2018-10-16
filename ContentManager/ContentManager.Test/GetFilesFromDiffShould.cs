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

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            string srcPath = GetSrc.SrcPath();
            GetFilesFromDiff gitHelper = new GetFilesFromDiff(mockRepo.Object, srcPath);
            Dictionary<Types.InputType, IEnumerable<string>> files = gitHelper.PackPaths(mockChanges as IEnumerable<string>);
            Assert.Empty(files);
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void ReturnsContentSpecificFolder(Types.InputType type, IEnumerable<string> list, int fileCount)
        {
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            string srcPath = GetSrc.SrcPath();
            GetFilesFromDiff gitHelper = new GetFilesFromDiff(mockRepo.Object, srcPath);
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
                "blog/README.md",
                "blog/LICENSE",
                "blog/posts/about-me.md",
                "blog/posts/abstract-factory-cpp.md",
                "blog/posts/ad-generator-thoughts-after-first-commit.md"
            };
            List<string> feedChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "feeds/engineering-blogs.opml",
                "feeds/README.md"
            };
            List<string> projectChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "projects/blog/README.md",
                "projects/blog/posts/redesigning-the-blog.md",
                "projects/README.md",
                "projects/LICENSE"
            };
            List<string> studyChanges = new List<string>()
            {
                ".gitignore",
                ".vsts-content-manager.yml",
                "ContentManager/ContentManager.Test/ContentManager.Test.csproj",
                "study/cormen/README.md",
                "study/cormen/posts/corment-algorithms-ch02.md",
                "study/README.md",
                "study/LICENSE"
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
