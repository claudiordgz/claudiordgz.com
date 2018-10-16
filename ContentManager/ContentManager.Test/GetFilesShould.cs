using System;
using System.Collections.Generic;
using Xunit;

namespace ContentManager.Test
{
    public class GetFilesShould
    {

        internal static Dictionary<Types.InputType, IEnumerable<string>> MockWrapGit(Configuration configuration)
        {
            List<string> blog = new List<string>();
            List<string> feeds = new List<string>();
            List<string> projects = new List<string>();
            List<string> study = new List<string>();
            Dictionary<Types.InputType, IEnumerable<string>> paths = new Dictionary<Types.InputType, IEnumerable<string>>();
            paths[Types.InputType.blog] = blog;
            paths[Types.InputType.feeds] = feeds;
            paths[Types.InputType.projects] = projects;
            paths[Types.InputType.study] = study;
            return paths;
        }

        [Fact]
        public void ReturnsContentFromAllFolders()
        {
            Configuration configuration = new Configuration(GetSrc.SrcPath())
            {
                InputType = Types.InputType.all,
                BuildType = Types.BuildType.origin,
                Verbose = false
            };
            configuration.TypesToProcess = configuration.GetTypes();
            Func<Configuration, Dictionary<Types.InputType, IEnumerable<string>>> gitHelper = MockWrapGit;
            Dictionary<Types.InputType, IEnumerable<string>> files = GetFiles.FromBuildType(configuration, gitHelper);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnAll(files);
        }

        [Theory]
        [InlineData(Types.InputType.blog)]
        [InlineData(Types.InputType.feeds)]
        [InlineData(Types.InputType.projects)]
        [InlineData(Types.InputType.study)]
        public void ReturnsContentSpecificFolder(Types.InputType type)
        {
            Configuration configuration = new Configuration(GetSrc.SrcPath())
            {
                InputType = type,
                BuildType = Types.BuildType.origin,
                Verbose = false
            };
            configuration.TypesToProcess = configuration.GetTypes();
            Func<Configuration, Dictionary<Types.InputType, IEnumerable<string>>> gitHelper = MockWrapGit;
            Dictionary<Types.InputType, IEnumerable<string>> files = GetFiles.FromBuildType(configuration, gitHelper);
            AnallyExpect.MarkdownXmlOrOpmlFilesOnSingleType(type, files);
        }
    }
}
