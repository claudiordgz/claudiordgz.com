using System;
using System.Collections.Generic;
using System.Text;

namespace ContentManager
{
    public static class GetFiles
    {
        public static Dictionary<Types.InputType, IEnumerable<string>> FromBuildType(Configuration configuration,
            Func<Configuration, Dictionary<Types.InputType, IEnumerable<string>>> gitHelper)
        {
            if (configuration.BuildType == Types.BuildType.origin)
            {
                return GetFilesFromDirectoryTree.GetAllFiles(configuration.TypesToProcess, configuration.RootPath);
            }
            else
            {
                return gitHelper(configuration);
            }
        }
    }
}
