using Xunit;
using ContentManager.Test;

namespace ContentManager.Tests
{
    public class GetFilesFromDirectoryTreeShould
    {

        [Fact]
        public void ReturnsContentFromAllFolders()
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
        public void ReturnsContentSpecificFolder(Types.InputType type)
        {
            var srcPath = GetSrc.SrcPath();
            var types = Types.GetTypes(type);
            var files = GetFilesFromDirectoryTree.GetAllFiles(types, srcPath);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnSingleType(type, files);
        }
    }
}
