using System;

namespace HMA.Helpers
{
    public static class TimeConverter
    {
        public static double ConvertFromTimeToDouble(double time)
        {
           var result = time/1440.0;
            return Math.Round(result,5);
        }

        public static TimeSpan ConvertFromDoubleToTime(double value)
        {
            var minutes = (value)*1440.0;

            var dateTime = TimeSpan.FromSeconds(minutes);
            return dateTime;
        }
    }
}