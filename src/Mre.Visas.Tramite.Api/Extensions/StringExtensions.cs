using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mre.Visas.Tramite.Api.Extensions
{
    /// <summary>
    /// Extension methods for String class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Adds a char to end of given string if it does not ends with the char.
        /// </summary>
        public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (str.EndsWith(c.ToString(), comparisonType))
            {
                return str;
            }

            return str + c;
        }
    }
}
