using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Extensions
{
    public static class StringSupport
    {
        public static string ToLowerAndFirstToUpper(this string str)
        {
            StringBuilder builder = new StringBuilder(str.ToLower());
            if (str.Length != 0)
            {
                builder[0] = Char.ToUpper(builder[0]);
            }
            return builder.ToString();
        }
    }
}
