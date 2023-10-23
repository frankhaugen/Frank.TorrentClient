using System.Collections.ObjectModel;

using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Service;

public interface ITorrentService
{
    Task<IEnumerable<TorrentSearchResult>> SearchAsync(string query);
    void SelectResultToDownload(TorrentSearchResult torrent);
    
    ObservableCollection<Torrent> Torrents { get; }
}