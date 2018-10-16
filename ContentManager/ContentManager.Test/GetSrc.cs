using System;
using System.IO;

namespace ContentManager.Test
{
    public static class GetSrc
    {
        public static string SrcPath()
        {
            string binPath = Directory.GetCurrentDirectory();
            string rPath = Path.Combine(binPath, "../../../../..");
            return Path.GetFullPath((new Uri(rPath)).LocalPath);
        }
    }
}
