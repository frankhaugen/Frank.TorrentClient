namespace Frank.TorrentClient.Search;

internal class TorrentSearcher : ITorrentSearcher
{
    private readonly IEnumerable<IScraper> _scrapers;

    public TorrentSearcher(params IScraper[] scrapers)
    {
        _scrapers = scrapers;
    }
	
    public TorrentSearcher(IEnumerable<IScraper> scrapers)
    {
        _scrapers = scrapers;
    }
	
    public IEnumerable<Uri> Search(string search)
    {
        return _scrapers.SelectMany(scraper => scraper.GetTorrentLinks(search));
    }
}