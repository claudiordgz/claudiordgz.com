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

        public static List<InputType> GetTypes(InputType iType)
        {
            if (iType == InputType.all)
            {
                List<InputType> mTypes = new List<InputType>
                {
                    InputType.blog,
                    InputType.feeds,
                    InputType.projects,
                    InputType.study
                };
                return mTypes;
            }
            else
            {
                List<InputType> mTypes = new List<InputType>{ iType };
                return mTypes;
            }
        }
    }
}
