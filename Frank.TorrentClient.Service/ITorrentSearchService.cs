using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Service;

public interface ITorrentSearchService
{
    Task<IEnumerable<TorrentSearchResult>> SearchAsync(string query);
    TorrentFile SelectResult(TorrentSearchResult torrent);
}