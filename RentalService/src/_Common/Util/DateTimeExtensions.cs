using System.Runtime.InteropServices;

namespace Common.Util;

public static class DateTimeExtensions
{
    public static DateTime GetBrazilianTime(this DateTime data)
    {
        var timeZoneId = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? "E. South America Standard Time"
            : "America/Sao_Paulo";
            
        var timezone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return TimeZoneInfo.ConvertTime(data, timezone);
    }
}