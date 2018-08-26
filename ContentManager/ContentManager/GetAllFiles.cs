using System;
using System.Collections.Generic;
using System.IO;

namespace ContentManager
{
    public static class GetAllFiles
    {
        private static IEnumerable<string> Blog(string path)
        {
            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in Directory.GetFiles(d, "*"))
                {
                    yield return f;
                }
            }
        }

        private static IEnumerable<string> Feeds(string path)
        {
            foreach (string f in Directory.GetFiles(path, "*"))
            {
                var extension = Path.GetExtension(f);
                if (extension.Contains("xml") || extension.Contains("opml"))
                {
                    yield return f;
                }
            }
        }

        private static IEnumerable<string> ListOfLists(string path)
        {
            foreach (string d in Directory.GetDirectories(path))
            {
                foreach (string f in Directory.GetFiles(d, "*"))
                {
                    yield return f;
                }
                foreach (string innerD in Directory.GetDirectories(d, "*"))
                {
                    foreach (string f in Directory.GetFiles(innerD, "*"))
                    {
                        yield return f;
                    }
                }
            }
        }

        private static IEnumerable<string> Projects(string path) { return ListOfLists(path); }

        private static IEnumerable<string> Study(string path) { return ListOfLists(path); }

        private static Dictionary<Types.InputType, Func<string, IEnumerable<string>>> TypeToImplementationDict()
        {
            var config = new Dictionary<Types.InputType, Func<string, IEnumerable<string>>>
            {
                { Types.InputType.blog, Blog },
                { Types.InputType.feeds, Feeds },
                { Types.InputType.projects, Projects },
                { Types.InputType.study, Study }
            };
            return config;
        }

        public static Dictionary<Types.InputType, IEnumerable<string>> getAllFiles(Dictionary<Types.InputType, List<string>> types, string pathToSrc)
        {
            var paths = new Dictionary<Types.InputType, IEnumerable<string>>();
            var configuration = TypeToImplementationDict();
            foreach (var entry in types)
            {
                var pathToPosts = Path.Combine(pathToSrc, entry.Key.ToString("G"));
                var impl = configuration[entry.Key];
                var generator = impl(pathToPosts);
                paths.Add(entry.Key, generator);
            }
            return paths;
        }
    }
}
