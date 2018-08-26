using System.IO;
using Xunit;

namespace ContentManager.Test
{
    public static class AnallyExpect
    {
        public static void MarkDownOrXmlFiles(string file)
        {
            var ext = Path.GetExtension(file);
            var condition = ext.Contains("opml") || ext.Contains("xml") || ext.Contains("md");
            Assert.True(condition);
        }
    }
}
