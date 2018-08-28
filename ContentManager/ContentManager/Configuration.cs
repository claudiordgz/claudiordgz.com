using System;
using System.Collections.Generic;

namespace ContentManager
{
    public class Configuration
    {
        public Types.InputType InputType { get; set; }
        public Types.BuildType BuildType { get; set; }
        public Boolean Verbose { get; set; }
        public string RootPath { get; set; }
        public List<Types.InputType> TypesToProcess { get; set; }

        public List<Types.InputType> GetTypes()
        {
            return Types.GetTypes(InputType);
        }
    }
}
