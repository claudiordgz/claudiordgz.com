using System;
using System.Collections.Generic;
using System.Text;

namespace ContentManager.Util
{
    public class GithubUrlCannotBeAssembledException : Exception
    {
        public GithubUrlCannotBeAssembledException(string message) : base(message) { }
    }

    public class GithubAssetUrl
    {
        /// <summary>
        /// Make sure it's a file
        /// </summary>
        /// <param name="pathToAsset"></param>
        /// <returns></returns>
        private static Boolean IsPathValid(string pathToAsset)
        {
            return false;
        } 

        private static string GetUrlWithBranch(string pathToAsset)
        {
            return "";
        } 

        public static string AssembleUrlToAssetOnGithub(string pathToAsset)
        {
            if (IsPathValid(pathToAsset))
            {
                string urlToAsset = GetUrlWithBranch(pathToAsset);
                return urlToAsset;
            } else
            {
                throw new GithubUrlCannotBeAssembledException("path is invalid");
            }
        }
    }
}
