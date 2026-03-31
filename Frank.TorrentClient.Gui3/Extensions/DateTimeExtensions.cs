using System.Globalization;
using System.IO;

namespace Frank.TorrentClient.Gui3.Extensions;

public static class DateTimeExtensions
{
    public static int GetWeekInYear(this DateTime dateTime) => ISOWeek.GetWeekOfYear(dateTime);
    public static int GetWeekInYear(this DateOnly date) => ISOWeek.GetWeekOfYear(date.ToDateTime());
    
    public static int GetWeeksInYear(this DateTime dateTime) => ISOWeek.GetWeeksInYear(dateTime.Year);
    public static int GetWeeksInYear(this DateOnly date) => ISOWeek.GetWeeksInYear(date.Year);
    
    public static string CreateFileNameForDate(this DateTime dateTime, string extension) => $"{dateTime:yyyyMMdd-HHmmss}.{extension.TrimStart('.')}";
    public static string CreateFileNameForDate(this DateOnly date, string extension) => $"{date:yyyyMMdd}.{extension.TrimStart('.')}";
    
    public static FileInfo CreateFileInfoForDate(this DateTime dateTime, DirectoryInfo baseDirectory, string extension) => new FileInfo(Path.Combine(baseDirectory.FullName, dateTime.Year.ToString(), dateTime.Month.ToString("00"),dateTime.CreateFileNameForDate(extension)));
    public static FileInfo CreateFileInfoForDate(this DateOnly date, DirectoryInfo baseDirectory, string extension) => new FileInfo(Path.Combine(baseDirectory.FullName, date.Year.ToString(), date.Month.ToString("00"),date.CreateFileNameForDate(extension)));
    
    public static DateTime ToDateTime(this DateOnly date) => date.ToDateTime(TimeOnly.MinValue);
}