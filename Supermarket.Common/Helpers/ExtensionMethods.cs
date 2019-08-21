using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Common.Helpers
{
    public static class ExensionMethods
    {
        public static bool IsNull<T>(this T source)
        {
            return source == null;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return (source == null || !source.Any());
        }
    }
}