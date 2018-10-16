using Xunit;
using ContentManager.Test;

namespace ContentManager.Tests
{
    public class GetFilesFromDirectoryTreeShould
    {

        [Fact]
        public void ReturnsContentFromAllFoldersByTypesAndSrcPath()
        {
            string srcPath = GetSrc.SrcPath();
            System.Collections.Generic.List<Types.InputType> types = Types.GetTypes(Types.InputType.all);
            System.Collections.Generic.Dictionary<Types.InputType, System.Collections.Generic.IEnumerable<string>> files = GetFilesFromDirectoryTree.GetAllFiles(types, srcPath);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnAll(files);
        }

        [Theory]
        [InlineData(Types.InputType.blog)]
        [InlineData(Types.InputType.feeds)]
        [InlineData(Types.InputType.projects)]
        [InlineData(Types.InputType.study)]
        public void ReturnsContentSpecificFolderByTypesAndSrcPath(Types.InputType type)
        {
            string srcPath = GetSrc.SrcPath();
            System.Collections.Generic.List<Types.InputType> types = Types.GetTypes(type);
            System.Collections.Generic.Dictionary<Types.InputType, System.Collections.Generic.IEnumerable<string>> files = GetFilesFromDirectoryTree.GetAllFiles(types, srcPath);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnSingleType(type, files);
        }

        [Fact]
        public void ReturnsContentFromAllFoldersByConfiguration()
        {
            Configuration configuration = new Configuration(GetSrc.SrcPath())
            {
                InputType = Types.InputType.all,
                BuildType = Types.BuildType.origin,
                Verbose = false
            };
            configuration.TypesToProcess = configuration.GetTypes();
            System.Collections.Generic.Dictionary<Types.InputType, System.Collections.Generic.IEnumerable<string>> files = GetFilesFromDirectoryTree.GetAllFiles(configuration);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnAll(files);
        }

        [Theory]
        [InlineData(Types.InputType.blog)]
        [InlineData(Types.InputType.feeds)]
        [InlineData(Types.InputType.projects)]
        [InlineData(Types.InputType.study)]
        public void ReturnsContentSpecificFolderByConfiguration(Types.InputType type)
        {
            Configuration configuration = new Configuration(GetSrc.SrcPath())
            {
                InputType = type,
                BuildType = Types.BuildType.origin,
                Verbose = false
            };
            configuration.TypesToProcess = configuration.GetTypes();
            System.Collections.Generic.Dictionary<Types.InputType, System.Collections.Generic.IEnumerable<string>> files = GetFilesFromDirectoryTree.GetAllFiles(configuration);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnSingleType(type, files);
        }
    }
}
