namespace Frank.TorrentClient.Search;

public class TorrentSearchResult
{
    public TorrentSearchResult(Uri uri)
    {
        Name = uri.Segments.Last();
        Uri = uri;
    }
    
    public TorrentSearchResult()
    {
    }

    public Uri Uri { get; set; }
    
    public string Name { get; set; }
}