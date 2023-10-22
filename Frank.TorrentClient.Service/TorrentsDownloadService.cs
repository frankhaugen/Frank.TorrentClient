using Frank.TorrentClient.TorrentEventArgs;

using Microsoft.Extensions.Options;

namespace Frank.TorrentClient.Service;

public class TorrentsDownloadService : ITorrentsDownloadService
{
    private readonly TorrentClient _torrentClient;
    
    public TorrentsDownloadService(IOptions<TorrentsConfiguration> options)
    {
        _torrentClient = new TorrentClient(options.Value.Port, options.Value.TorrentsDirectory);
        _torrentClient.Start();
        
        _torrentClient.TorrentStarted += TorrentClientOnTorrentStarted;
        _torrentClient.TorrentStopped += TorrentClientOnTorrentStopped;
        _torrentClient.TorrentHashing += TorrentClientOnTorrentHashing;
        _torrentClient.TorrentLeeching += TorrentClientOnTorrentLeeching;
        _torrentClient.TorrentSeeding += TorrentClientOnTorrentSeeding;
    }

    public event EventHandler<IEnumerable<TorrentProgressInfo>>? TorrentProgressChanged;
    
    public void StartDownload(TorrentFile torrentFile)
    {
        var file = torrentFile.Source;
        if (file.Exists && TorrentInfo.TryLoad(file.FullName, out var torrentInfo))
            _torrentClient.Start(torrentInfo);
        else
            throw new Exception("Failed to load torrent info");
    }
    
    public void StopDownload(TorrentFile torrentFile)
    {
        var file = torrentFile.Source;
        if (file.Exists && TorrentInfo.TryLoad(file.FullName, out var torrentInfo))
            _torrentClient.Stop(torrentInfo.InfoHash);
        else
            throw new Exception("Failed to load torrent info");
    }
    
    public IEnumerable<TorrentProgressInfo> GetTorrentProgressInfos() => _torrentClient.GetProgressInfo();
    public TorrentProgressInfo GetTorrentProgressInfo(TorrentFile torrentFile) => GetTorrentProgressInfo(torrentFile.Source);
    
    private void HandleTorrentEvent(TorrentClient client, TorrentInfo torrentInfo)
    {
        var progressInfo = GetTorrentProgressInfo(torrentInfo);
        TorrentProgressChanged?.Invoke(this, new[] {progressInfo});    
    }
    
    private void HandleTorrentEvent(object? sender, TorrentInfo torrentInfo)
    {
        if (sender is TorrentClient client) 
            HandleTorrentEvent(client, torrentInfo);
        else
            throw new ArgumentException("Sender is not a TorrentClient", nameof(sender));
    }
    
    private TorrentProgressInfo GetTorrentProgressInfo(FileSystemInfo torrentFileSource) => GetTorrentProgressInfo(TorrentInfo.TryLoad(torrentFileSource.FullName, out var torrentInfo) ? torrentInfo : throw new Exception("Failed to load torrent info"));
    private TorrentProgressInfo GetTorrentProgressInfo(TorrentInfo torrentInfo) => _torrentClient.GetProgressInfo(torrentInfo.InfoHash);

    
    private void TorrentClientOnTorrentSeeding(object? sender, TorrentSeedingEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
    private void TorrentClientOnTorrentLeeching(object? sender, TorrentLeechingEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
    private void TorrentClientOnTorrentHashing(object? sender, TorrentHashingEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
    private void TorrentClientOnTorrentStopped(object? sender, TorrentStoppedEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
    private void TorrentClientOnTorrentStarted(object? sender, TorrentStartedEventArgs e) => HandleTorrentEvent(sender, e.TorrentInfo);
}