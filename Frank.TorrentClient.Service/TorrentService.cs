using System.Collections.ObjectModel;

using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Service;

public class TorrentService : ITorrentService
{
    private readonly ITorrentSearchService _searchService;
    private readonly ITorrentsDownloadService _downloadService;
    
    public TorrentService(ITorrentSearchService searchService, ITorrentsDownloadService downloadService)
    {
        _searchService = searchService;
        _downloadService = downloadService;
    }
    
    public ObservableCollection<Torrent> Torrents => _downloadService.ActiveTorrents;
    
    public async Task<IEnumerable<TorrentSearchResult>> SearchAsync(string query)
    {
        return await _searchService.SearchAsync(query);
    }
    
    public void SelectResultToDownload(TorrentSearchResult torrent)
    {
        var torrentFile = _searchService.SelectResult(torrent);
        _downloadService.StartDownload(torrentFile);
    }
}