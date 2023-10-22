using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

using Frank.TorrentClient.Gui.Commands;
using Frank.TorrentClient.Gui.Configuration;
using Frank.TorrentClient.Gui.Utils;
using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui;

public class TorrentViewItem : UserControl
{
    public TorrentViewItem(Torrent torrent) =>
        Content = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            Children =
            {
                new Button
                {
                    Content = "Download",
                    Command = new DownloadCommand(async x => await Downloader.DownloadAsync(torrent.Uri, new DirectoryInfo(ConfigurationReader.GetTorrentDirectories().WatchDirectory))),
                    Margin = new Thickness(2.5, 3, 2.5, 3)
                },
                new TextBlock { Text = torrent.Name, Margin = new Thickness(5, 3, 2.5, 3) },
                new TextBlock { Text = torrent.Uri.ToString(), Margin = new Thickness(2.5, 3, 2.5, 3) }
            }
        };
}

public class TorrentDownloadViewItem : UserControl
{
    public TorrentDownloadViewItem(TorrentInfo torrentInfo, TorrentProgressInfo torrentProgress) =>
        Content = new StackPanel()
        {
            Orientation = Orientation.Horizontal,
            Children =
            {
                new TextBlock { Text = torrentInfo.InfoHash, Margin = new Thickness(5, 3, 2.5, 3) },
            }
        };
}