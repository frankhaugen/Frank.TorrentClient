using DefensiveProgrammingFramework;

using Frank.TorrentClient.Search;

using Microsoft.Extensions.Options;

namespace Frank.TorrentClient.Service;

public class TorrentSearchService : ITorrentSearchService
{
    private readonly ISearchProvider<TorrentSearchResult> _searchProvider;
    private readonly IOptions<TorrentsConfiguration> _options;

    public TorrentSearchService(ISearchProvider<TorrentSearchResult> searchProvider, IOptions<TorrentsConfiguration> options)
    {
        _searchProvider = searchProvider;
        _options = options;
    }
    
    public async Task<IEnumerable<TorrentSearchResult>> SearchAsync(string query)
    {
        return await _searchProvider.GetSearchResults(query);
    }
    
    public TorrentFile SelectResult(TorrentSearchResult torrent)
    {
        torrent.IsNotNull();
        var file = torrent.Uri.DownloadToLocation(new DirectoryInfo(_options.Value.TorrentsDirectory));
        var torrentFile = new TorrentFile
        {
            Name = torrent.Name,
            Source = file,
            Origin = torrent.Uri,
        };
        return torrentFile;
    }
}