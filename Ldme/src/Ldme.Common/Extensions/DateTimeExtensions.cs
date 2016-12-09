using System;

namespace Ldme.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool Between(this DateTime input, DateTime startDate, DateTime endDate)
        {
            return (input > startDate && input < endDate);
        }

        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day).AddDays(1).AddMilliseconds(-1);
        }

        public static DateTime StartOfWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            while (date.DayOfWeek != startOfWeek)
            {
                date = date.AddDays(-1);
            }

            return new DateTime(date.Year, date.Month, date.Day);
        }

        public static DateTime EndOfWeek(this DateTime date, DayOfWeek endOfWeek = DayOfWeek.Sunday)
        {
            while (date.DayOfWeek != endOfWeek)
            {
                date = date.AddDays(1);
            }

            return new DateTime(date.Year, date.Month, date.Day).AddDays(1).AddMilliseconds(-1);
        }

        public static DateTime StartOfMonth(this DateTime date, DayOfWeek endOfWeek = DayOfWeek.Sunday)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static DateTime EndOfMonth(this DateTime date, DayOfWeek endOfWeek = DayOfWeek.Sunday)
        {
            var day = DateTime.DaysInMonth(date.Year, date.Month);
            return new DateTime(date.Year, date.Month, day).AddDays(1).AddMilliseconds(-1);
        }

        public static string ToJsTime(this DateTime date)
        {
            return date.ToUniversalTime() + TimeZoneInfo.Local.GetUtcOffset(date).ToString("c");
        }

        public static string ToDateTimeString(this DateTime? dateTime)
        {
            return dateTime?.ToString("O");
        }

        public static string ToDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("O");
        }
    }
}
