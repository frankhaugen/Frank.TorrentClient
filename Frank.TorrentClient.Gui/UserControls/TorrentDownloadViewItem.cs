using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

namespace Frank.TorrentClient.Gui.UserControls;

public class TorrentDownloadViewItem : UserControl
{
    private static readonly Thickness _margin = new Thickness(5, 3, 2.5, 3);

    private readonly ProgressBar _progressBar = new ProgressBar
    {
        Minimum = 0,
        Maximum = 100,
        Width = 200,
        Margin = _margin
    };
    
    private readonly StackPanel _stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
    
    public TorrentDownloadViewItem(TorrentProgressInfo? torrent)
    {
        if (torrent is null)
            return;
        
        try
        {
            _progressBar.Value = Convert.ToDouble(torrent.CompletedPercentage);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            var fileName = new TextBlock { Text = Path.GetFileName(torrent.Files.First().FilePath), Margin = _margin };
            _stackPanel.Children.Add(fileName);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
        
        try
        {
            var downloadSpeed = new TextBlock { Text = ToMegabitsPerSecond(torrent.DownloadSpeed), Margin = _margin };
            _stackPanel.Children.Add(downloadSpeed);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            var downloadSpeedMb = new TextBlock { Text = ToMegabytesPerSecond(torrent.DownloadSpeed), Margin = _margin };
            _stackPanel.Children.Add(downloadSpeedMb);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            var downloadProgress = new TextBlock { Text = torrent.CompletedPercentage.ToString("P"), Margin = _margin };
            _stackPanel.Children.Add(downloadProgress);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            _stackPanel.Children.Add(_progressBar);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            var seeders = new TextBlock { Text = $"{torrent.SeederCount} seeders", Margin = _margin };
            _stackPanel.Children.Add(seeders);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            var leechers = new TextBlock { Text = $"{torrent.LeecherCount} leechers", Margin = _margin };
            _stackPanel.Children.Add(leechers);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            var peers = new TextBlock { Text = $"{torrent.Peers.Count()} peers", Margin = _margin };
            _stackPanel.Children.Add(peers);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            var totalSize = new TextBlock { Text = $"{torrent.Files.Sum(x =>x.Length) * 1024 * 1024:N2} MB", Margin = _margin };
            _stackPanel.Children.Add(totalSize);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }

        try
        {
            var timeRemaining = new TextBlock { Text = GetTimeRemmaining(torrent), Margin = _margin };
            _stackPanel.Children.Add(timeRemaining);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
        
        try
        {
            Content ??= _stackPanel;
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
        }
    }

    private string? GetTimeRemmaining(TorrentProgressInfo torrent)
    {
        var totalBytes = torrent.Files.Sum(x => x.Length);
        var bytesRemaining = totalBytes - torrent.Downloaded;
        var speed = torrent.DownloadSpeed;
        
        if (speed == 0)
            return "∞";
        
        var secondsRemaining = bytesRemaining / speed;
        var timeSpan = TimeSpan.FromSeconds(Convert.ToDouble(secondsRemaining));
        return timeSpan.ToString("c");
    }

    private string? ToMegabytesPerSecond(decimal torrentDownloadSpeed)
    {
        try
        {
            return $"{(torrentDownloadSpeed / 1024 / 1024):N2} MB/s";
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return null;
        }
    }

    private string? ToMegabitsPerSecond(decimal torrentDownloadSpeed)
    {
        try
        {
            return $"{(torrentDownloadSpeed / 1024 / 1024 * 8):N2} Mbit/s";
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return null;
        }
    }
}