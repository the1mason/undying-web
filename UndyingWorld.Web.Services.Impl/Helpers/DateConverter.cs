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
                return ConvertFromUnix(dateDenormalized);
            
            return ConvertFromDateString(dateDenormalized);
        }

        private static DateTime ConvertFromDateString(long dateLong)
        {
            string dateString = dateLong.ToString();

            CultureInfo provider = CultureInfo.InvariantCulture;
            
            return DateTime.ParseExact(dateString, "yyyyMMddHHmmss", provider);
        }

        public static DateTime ConvertFromUnix(long dateLong)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dt.AddMilliseconds(dateLong);
        }

        public static long ConvertToUnix(DateTime dateTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTime - dt).TotalMilliseconds;
        }
    }
}
