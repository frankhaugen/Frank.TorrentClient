namespace Frank.TorrentClient.Search;

public class TorrentSearchProvider : ISearchProvider<TorrentSearchResult>
{
    private readonly TorrentSearcher _searcher;
    
    public TorrentSearchProvider() => _searcher = new TorrentSearcher(new EztvScraper());

    public async Task<IEnumerable<TorrentSearchResult>> GetSearchResults(string query) =>
        await Task.FromResult(_searcher.Search(query).Select(torrent => new TorrentSearchResult
        {
            Uri = torrent,
            Name = torrent.Segments.Last(),
        }));
}