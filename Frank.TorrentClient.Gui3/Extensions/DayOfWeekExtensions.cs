using System.Globalization;
using System.Windows.Controls;

namespace Frank.TorrentClient.Gui3.Extensions;

public static class DayOfWeekExtensions
{
    
    public static Label ToLabel(this DayOfWeek dayOfWeek) => new() {Content = dayOfWeek.ToShortString()};
    
    public static string ToShortString(this DayOfWeek dayOfWeek) => CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedDayName(dayOfWeek);
    public static string ToLongString(this DayOfWeek dayOfWeek) => CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dayOfWeek);
}