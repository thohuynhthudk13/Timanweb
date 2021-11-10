using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIMAN.Web.FormatCurrency
{
    public static class FormatCurency
    {
        public static string Currency(this decimal value)
        {
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");

            return String.Format(info, "{0:c}", value);
        }
    }
}
