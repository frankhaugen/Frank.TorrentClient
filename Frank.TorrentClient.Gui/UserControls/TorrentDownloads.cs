using System.Collections.ObjectModel;

using Avalonia.Controls;

using Avalonia.Layout;

using Frank.TorrentClient.Gui.Configuration;
using Frank.TorrentClient.TorrentEventArgs;

namespace Frank.TorrentClient.Gui.UserControls;

public class TorrentDownloads : UserControl
{
    private readonly TorrentClient _torrentClient;
    private readonly DirectoryInfo _watchDirectory;

    public TorrentDownloads()
    {
        var settings = ConfigurationReader.GetTorrentClientSettings();
        var directories = ConfigurationReader.GetTorrentDirectories();
        
        _watchDirectory = new DirectoryInfo(directories.WatchDirectory);
        if (!_watchDirectory.Exists)
            _watchDirectory.Create();
        
        _watchDirectory.Refresh();
        
        var torrents = _watchDirectory.EnumerateFiles("*.torrent");
        
        _torrentClient = new TorrentClient(settings.Port, directories.WatchDirectory);
        
        
        _torrentClient.Start();
        
        Items.VerticalAlignment = VerticalAlignment.Stretch;
        Items.HorizontalAlignment = HorizontalAlignment.Stretch;
        Items.ItemsSource = Data;
        Items.DataContext = Data;
        
        Content = Items;
        
        _torrentClient.TorrentStarted += TorrentClientOnTorrentStarted;
        _torrentClient.TorrentStopped += TorrentClientOnTorrentStopped;
        _torrentClient.TorrentHashing += TorrentClientOnTorrentHashing;
        _torrentClient.TorrentLeeching += TorrentClientOnTorrentLeeching;
        _torrentClient.TorrentSeeding += TorrentClientOnTorrentSeeding;
    }
    
    private ObservableCollection<TorrentInfo> Data { get; } = new();
    
    public ListBox Items { get; } = new();

    public void Add(TorrentInfo torrentInfo)
    {
        Data.Add(torrentInfo);
        _torrentClient.Start();
    }
    
    public void Remove(TorrentInfo torrentInfo)
    {
        Data.Remove(torrentInfo);
        _torrentClient.Stop(torrentInfo.InfoHash);
    }
    
    private void HandleTorrentEvent(TorrentClient client, TorrentInfo torrentInfo)
    {
        
    }
    
    private void HandleTorrentEvent(object? sender, TorrentInfo torrentInfo)
    {
        if (sender is TorrentClient client) 
            HandleTorrentEvent(client, torrentInfo);
        else
            throw new ArgumentException("Sender is not a TorrentClient", nameof(sender));
    }
    
    private void TorrentClientOnTorrentSeeding(object? sender, TorrentSeedingEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
    private void TorrentClientOnTorrentLeeching(object? sender, TorrentLeechingEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
    private void TorrentClientOnTorrentHashing(object? sender, TorrentHashingEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
    private void TorrentClientOnTorrentStopped(object? sender, TorrentStoppedEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
    private void TorrentClientOnTorrentStarted(object? sender, TorrentStartedEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
}