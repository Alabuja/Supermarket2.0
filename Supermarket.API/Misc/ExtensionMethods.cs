using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Misc
{
    public static class ExtensionMethods
    {
        #region IHostingEnvironment

        public static string Test = "Test";
        public static bool IsTest(this IHostingEnvironment env)
        {
            return env.IsEnvironment(Test);
        }
        public static bool IsTestOrDevelopment(this IHostingEnvironment env)
        {
            return env.IsAnyEnvironment(EnvironmentName.Development, Test);
        }
        public static bool IsAnyEnvironment(this IHostingEnvironment env, params string[] envs)
        {
            return envs.ToList().Any(_env => env.IsEnvironment(_env));
        }
        #endregion
    }
}
