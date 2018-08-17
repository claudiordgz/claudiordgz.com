using System;
using System.Collections.Generic;
using System.Text;

namespace ContentManager
{
    public static class Types
    {
        public enum InputType
        {
            all,
            blog,
            feeds,
            projects,
            study
        }

        public enum BuildType
        {
            origin,
            incremental
        }

        public static Dictionary<InputType, List<string>> GetAllTypes(InputType iType)
        {
            if (iType == InputType.all)
            {
                var mTypes = new Dictionary<InputType, List<string>>
                {
                    { InputType.blog, new List<string>() },
                    { InputType.feeds, new List<string>() },
                    { InputType.projects, new List<string>() },
                    { InputType.study, new List<string>() }
                };
                return mTypes;
            }
            else
            {
                var mTypes = new Dictionary<InputType, List<string>>
                {
                    { iType, new List<string>() }
                };
                return mTypes;
            }
        }
    }
}
