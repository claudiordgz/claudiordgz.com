using System;
using System.IO;

namespace ContentManager.Test
{
    public static class GetSrc
    {
        public static (string GitDirectory, string ContentDirectory) SrcPath()
        {
            string binPath = Directory.GetCurrentDirectory();
            string gitDirectory = Path.Combine(binPath, "..", "..", "..", "..", "..");
            string contentDirectory = Path.Combine(gitDirectory, "content");
            return (GitDirectory: Path.GetFullPath(new Uri(gitDirectory).LocalPath), ContentDirectory: Path.GetFullPath(new Uri(contentDirectory).LocalPath));
        }
    }
}
