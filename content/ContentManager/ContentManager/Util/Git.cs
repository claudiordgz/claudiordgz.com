using LibGit2Sharp;
using System;
using System.IO;
using System.Linq;

namespace ContentManager.Util
{
    public class GithubUtilFatalError : Exception
    {
        public GithubUtilFatalError(string message) : base(message) { }
    }

    public class RepositorySettings
    {
        public RepositorySettings (string username, string branchName, string repoName)
        {
            User = username;
            Branch = branchName;
            Repository = repoName;
        }

        public string User { get; }
        public string Branch { get; }
        public string Repository { get; }
    }

    public class Git
    {
        /// <summary>
        /// We need a valid url to an asset such as
        /// https://raw.githubusercontent.com/username/repository/branch_name/path_to_file.ext
        /// </summary>
        /// <param name="pathToAsset"></param>
        /// <returns>The path to the asset in Github</returns>
        private static Uri GetUrlWithBranch(RepositorySettings repoProperties, string rootPath, string pathToAsset)
        {
            string username = repoProperties.User;
            string repository = repoProperties.Repository;
            string branchName = repoProperties.Branch;
            string path = Path.DirectorySeparatorChar == '\\' ?
                pathToAsset.Replace(Path.DirectorySeparatorChar, '/') :
                pathToAsset;
            return new Uri($"https://raw.githubusercontent.com/{username}/{repository}/{branchName}/{path}");
        }

        public static Uri AssembleUrlToAssetOnGithub(RepositorySettings repoProperties, string rootPath, string pathToAsset)
        {
            string fullPath = Path.GetFullPath(new Uri(Path.Combine(rootPath, pathToAsset)).LocalPath);
            if (File.Exists(fullPath))
            {
                return GetUrlWithBranch(repoProperties, rootPath, pathToAsset);
            } else
            {
                throw new GithubUtilFatalError("url cannot be assembled: path is invalid");
            }
        }

        public static (string user, string repository) GetUserAndRepository(string remoteUrl)
        {
            if (remoteUrl.Contains("https"))
            {
                string[] pieces = remoteUrl.Split(".com/");
                string[] userAndRepo = pieces[1].Split("/");
                return (user: userAndRepo[0], repository: userAndRepo[1]);
            }
            else
            {
                string[] pieces = remoteUrl.Split(":");
                string url = pieces[0];
                string[] userAndRepo = pieces[1].Split("/");
                return (user: userAndRepo[0], repository: userAndRepo[1].Replace(".git", ""));
            }
        }

        /// <summary>
        /// Gets username, repository name, and branch name from the github repo.
        /// If you do funny business with the Remote URL this won't work
        /// </summary>
        /// <param name="rootPath">Path to base github folder</param>
        /// <returns>username, repository, and branch name</returns>
        public static RepositorySettings GetCurrentGithubProperties(string rootPath)
        {
            using (Repository repo = new Repository(rootPath))
            {
                string currentHash = repo.Head.Tip.Sha;
                string remoteUrl = repo.Network.Remotes.First().Url;
                (string user, string repository) = GetUserAndRepository(remoteUrl);
                foreach (Branch b in repo.Branches)
                {
                    if (b.Tip.Sha == currentHash)
                    {
                        // handle remote branches
                        string branchName = b.FriendlyName.Contains("origin/") ?
                            b.FriendlyName.Replace("origin/", "") :
                            b.FriendlyName;
                        return new RepositorySettings(user, branchName, repository);
                    }
                }
            }
            throw new GithubUtilFatalError("there was no active branch to return");
        }
    }
}
