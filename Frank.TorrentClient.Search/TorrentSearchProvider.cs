namespace Frank.TorrentClient.Search;

public class TorrentSearchProvider : ISearchProvider<Torrent>
{
    private readonly TorrentSearcher _searcher;
    
    public TorrentSearchProvider()
    {
        _searcher = new TorrentSearcher(new EztvScraper());
    }
    
    public async Task<IEnumerable<Torrent>> GetSearchResults(string query)
    {
        var torrents = _searcher.Search(query);
        
        return await Task.FromResult(torrents.Select(torrent => new Torrent
        {
            Uri = torrent,
            Name = torrent.Segments.Last(),
            Description = torrent.Segments.Last()
        }));
    }
}