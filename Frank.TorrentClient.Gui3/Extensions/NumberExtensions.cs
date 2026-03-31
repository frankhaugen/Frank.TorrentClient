using System.Globalization;
using System.Numerics;
using System.Windows.Controls;

namespace Frank.TorrentClient.Gui3.Extensions;

public static class NumberExtensions
{
    public static Label ToLabel<T>(this T number) where T : INumber<T> =>
        new Label 
        {
            Content = number.ToString("00", CultureInfo.InvariantCulture) 
        };
    
    public static int ToInt<T>(this T number) where T : IUnsignedNumber<T> => Convert.ToInt32(number);
}