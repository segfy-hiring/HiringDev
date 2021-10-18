using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SkillTestSegfy.Utils
{
    public static class DateTimeUtils
    {
        static DateTimeUtils()
        {
            CulturePtBr = CultureInfo.GetCultureInfo("pt-BR");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                TimeZonePtBr = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                TimeZonePtBr = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }
        }

        private static CultureInfo CulturePtBr { get; }
        private static TimeZoneInfo TimeZonePtBr { get; }

        public static string ConvertDateTimeToUser(DateTime dateTime)
        {
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            dateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZonePtBr);
            return dateTime.ToString("g", CulturePtBr);
        }
    }
}
