using System.Collections.ObjectModel;

namespace Frank.TorrentClient.Service;

public interface ITorrentsDownloadService
{
    public ObservableCollection<Torrent> ActiveTorrents { get; }
    void StartDownload(TorrentFile torrentFile);
    void StopDownload(TorrentFile torrentFile);
    IEnumerable<TorrentProgressInfo> GetTorrentProgressInfos();
    TorrentProgressInfo GetTorrentProgressInfo(TorrentFile torrentFile);
}