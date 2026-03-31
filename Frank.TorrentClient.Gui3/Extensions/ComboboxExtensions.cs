using System.Windows.Controls;

namespace Frank.TorrentClient.Gui3.Extensions;

public static class ComboboxExtensions
{
    public static void AddItem<T1, T2>(this T1 source, T2 item) where T1 : ComboBox where T2 : ComboBoxItem
    {
        source.Items.Add(item);
    }
}