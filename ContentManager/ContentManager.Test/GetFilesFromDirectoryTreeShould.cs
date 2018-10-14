using Xunit;
using ContentManager.Test;

namespace ContentManager.Tests
{
    public class GetFilesFromDirectoryTreeShould
    {

        [Fact]
        public void ReturnsContentFromAllFoldersByTypesAndSrcPath()
        {
            var srcPath = GetSrc.SrcPath();
            var types = Types.GetTypes(Types.InputType.all);
            var files = GetFilesFromDirectoryTree.GetAllFiles(types, srcPath);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnAll(files);
        }

        [Theory]
        [InlineData(Types.InputType.blog)]
        [InlineData(Types.InputType.feeds)]
        [InlineData(Types.InputType.projects)]
        [InlineData(Types.InputType.study)]
        public void ReturnsContentSpecificFolderByTypesAndSrcPath(Types.InputType type)
        {
            var srcPath = GetSrc.SrcPath();
            var types = Types.GetTypes(type);
            var files = GetFilesFromDirectoryTree.GetAllFiles(types, srcPath);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnSingleType(type, files);
        }

        [Fact]
        public void ReturnsContentFromAllFoldersByConfiguration()
        {
            var configuration = new Configuration(GetSrc.SrcPath())
            {
                InputType = Types.InputType.all,
                BuildType = Types.BuildType.origin,
                Verbose = false
            };
            configuration.TypesToProcess = configuration.GetTypes();
            var files = GetFilesFromDirectoryTree.GetAllFiles(configuration);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnAll(files);
        }

        [Theory]
        [InlineData(Types.InputType.blog)]
        [InlineData(Types.InputType.feeds)]
        [InlineData(Types.InputType.projects)]
        [InlineData(Types.InputType.study)]
        public void ReturnsContentSpecificFolderByConfiguration(Types.InputType type)
        {
            var configuration = new Configuration(GetSrc.SrcPath())
            {
                InputType = type,
                BuildType = Types.BuildType.origin,
                Verbose = false
            };
            configuration.TypesToProcess = configuration.GetTypes();
            var files = GetFilesFromDirectoryTree.GetAllFiles(configuration);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnSingleType(type, files);
        }
    }
}
