using System;
using System.Collections.Generic;
using Xunit;

namespace ContentManager.Test
{
    public class GetFilesShould
    {

        internal static Dictionary<Types.InputType, IEnumerable<string>> MockWrapGit(Configuration configuration)
        {
            var blog = new List<string>();
            var feeds = new List<string>();
            var projects = new List<string>();
            var study = new List<string>();
            var paths = new Dictionary<Types.InputType, IEnumerable<string>>();
            paths[Types.InputType.blog] = blog;
            paths[Types.InputType.feeds] = feeds;
            paths[Types.InputType.projects] = projects;
            paths[Types.InputType.study] = study;
            return paths;
        }

        [Fact]
        public void ReturnsContentFromAllFolders()
        {
            var configuration = new Configuration();
            configuration.BuildType = Types.BuildType.origin;
            configuration.TypesToProcess = Types.GetTypes(Types.InputType.all);
            configuration.RootPath = GetSrc.SrcPath();
            Func<Configuration, Dictionary<Types.InputType, IEnumerable<string>>> gitHelper = MockWrapGit;
            var files = GetFiles.FromBuildType(configuration, gitHelper);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnAll(files);
        }

        [Theory]
        [InlineData(Types.InputType.blog)]
        [InlineData(Types.InputType.feeds)]
        [InlineData(Types.InputType.projects)]
        [InlineData(Types.InputType.study)]
        public void ReturnsContentSpecificFolder(Types.InputType type)
        {
            var configuration = new Configuration();
            configuration.BuildType = Types.BuildType.origin;
            configuration.TypesToProcess = Types.GetTypes(type);
            configuration.RootPath = GetSrc.SrcPath();
            Func<Configuration, Dictionary<Types.InputType, IEnumerable<string>>> gitHelper = MockWrapGit;
            var files = GetFiles.FromBuildType(configuration, gitHelper);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnSingleType(type, files);
        }
    }
}
