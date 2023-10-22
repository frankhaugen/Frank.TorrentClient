using System.Collections.ObjectModel;

using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Service;

public interface ITorrentService
{
    Task<IEnumerable<TorrentSearchResult>> SearchAsync(string query);
    void SelectResultToDownload(TorrentSearchResult torrent);
    
    ObservableCollection<TorrentProgressInfo> Torrents { get; }
}