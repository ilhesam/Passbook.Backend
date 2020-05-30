using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ApplicationCore.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToPersianDateTime(this DateTime dateTime)
        {
            var persianCalendar = new PersianCalendar();

            // Example : 1399/01/03 12:05:32
            return persianCalendar.GetYear(dateTime) + "/"
                + persianCalendar.GetMonth(dateTime).ToString("00") + "/"
                + persianCalendar.GetDayOfMonth(dateTime).ToString("00") + " "
                + persianCalendar.GetHour(dateTime).ToString("00") + ":"
                + persianCalendar.GetMinute(dateTime).ToString("00") + ":"
                + persianCalendar.GetSecond(dateTime).ToString("00");
        }
    }
}
