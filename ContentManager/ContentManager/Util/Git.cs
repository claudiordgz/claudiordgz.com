﻿using LibGit2Sharp;
using System;
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
        /// Make sure it's a file
        /// </summary>
        /// <param name="pathToAsset"></param>
        /// <returns></returns>
        private static bool IsPathValid(string pathToAsset)
        {
            return false;
        } 

        private static string GetUrlWithBranch(string pathToAsset)
        {
            return "";
        }

        /// <summary>
        /// We need a valid url to an asset such as
        /// https://raw.githubusercontent.com/username/repository/branch_name/path_to_file.ext
        /// </summary>
        /// <param name="pathToAsset"></param>
        /// <returns></returns>
        public static string AssembleUrlToAssetOnGithub(Repository repoProperties, string pathToAsset)
        {
            if (IsPathValid(pathToAsset))
            {
                string urlToAsset = GetUrlWithBranch(pathToAsset);
                return urlToAsset;
            } else
            {
                throw new GithubUtilFatalError("url cannot be assembled: path is invalid");
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
                string[] pieces = remoteUrl.Split(":");
                string url = pieces[0];
                string[] userAndRepo = pieces[1].Split("/");
                string user = userAndRepo[0];
                string repository = userAndRepo[1].Replace(".git", "");
                foreach (Branch b in repo.Branches.Where(b => !b.IsRemote))
                {
                    if (b.Tip.Sha == currentHash)
                    {
                        return new RepositorySettings(user, b.FriendlyName, repository);
                    }
                }
            }
            throw new GithubUtilFatalError("there was no active branch to return");
        }
    }
}
