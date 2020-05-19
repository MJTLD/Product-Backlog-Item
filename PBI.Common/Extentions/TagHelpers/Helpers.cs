using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PBI.Common.Extentions.TagHelpers
{
    public static class Helpers
    {
        public static string ThousandsSeprate(object integerValue)
        {
            if (integerValue != null)
            {
                var num = long.Parse(integerValue.ToString());
                return string.Format(CultureInfo.InvariantCulture, "{0:N0}", num);
            }
            return "";
        }
    }
}
