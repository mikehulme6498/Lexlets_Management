using System;

namespace LexLetsManagement
{
    static class ExtensionMethods
    {
        public static string ToCamelCase(this string input)
        {
            if (!string.IsNullOrEmpty(input) && input.Length > 1)
            {
                return Char.ToUpperInvariant(input[0]) + input.Substring(1);
            }
            return input;

        }
    }
}
