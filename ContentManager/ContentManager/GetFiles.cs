using System;
using System.Collections.Generic;
using System.Text;

namespace ContentManager
{
    public static class GetFiles
    {
        /// <summary>
        /// Uses Configuration to process files in Repository
        ///   - if BuilType.orgin Will process All files
        ///   - else will use Git Tag offset to calculate changes and process those
        /// to retrieve what we need to process
        /// </summary>
        /// <param name="configuration">Configuration is needed to check for changes in defaults, using root path, types that we need to process</param>
        /// <param name="gitHelper">Function to do the Git Tag offset and get list of files to process, injected like this for testability</param>
        /// <returns>The Collection containing the files we need to change</returns>
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
