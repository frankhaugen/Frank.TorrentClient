using System.Windows.Input;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui.UserControls;

public class TorrentSearchResultViewItem : UserControl
{
    public TorrentSearchResultViewItem(TorrentSearchResult torrent, ICommand downloadCommand) =>
        Content ??= new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            Children =
            {
                new Button
                {
                    Content = "Download",
                    Command = downloadCommand,
                    Margin = new Thickness(2.5, 3, 2.5, 3)
                },
                new TextBlock { Text = torrent.Name, Margin = new Thickness(5, 3, 2.5, 3) },
                new TextBlock { Text = torrent.Uri.ToString(), Margin = new Thickness(2.5, 3, 2.5, 3) }
            }
        };
}