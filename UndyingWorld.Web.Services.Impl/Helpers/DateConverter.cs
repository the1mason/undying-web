using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndyingWorld.Web.Services.Impl.Helpers
{
    public static class DateConverter
    {
        public static DateTime NormalizeAuthmeDate(long dateDenormalized)
        {
            if (dateDenormalized < 20200000000000)
            {
                DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                string s = dateDenormalized.ToString();
                double d = double.Parse(s);
                return dt.AddMilliseconds(d);
            }
            
            return ConvertFromDateLong(20200000000000);
        }

        private static DateTime ConvertFromDateLong(long dateLong)
        {
            string dateString = dateLong.ToString();

            CultureInfo provider = CultureInfo.InvariantCulture;
            
            return DateTime.ParseExact(dateString, "yyyyMMddHHmmss", provider);
        }
    }
}
