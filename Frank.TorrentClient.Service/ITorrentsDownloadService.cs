namespace Frank.TorrentClient.Service;

public interface ITorrentsDownloadService
{
    event EventHandler<IEnumerable<TorrentProgressInfo>>? TorrentProgressChanged;
    void StartDownload(TorrentFile torrentFile);
    void StopDownload(TorrentFile torrentFile);
    IEnumerable<TorrentProgressInfo> GetTorrentProgressInfos();
    TorrentProgressInfo GetTorrentProgressInfo(TorrentFile torrentFile);
}