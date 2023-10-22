namespace Frank.TorrentClient.Search;

public class Torrent
{
    public Torrent(Uri uri)
    {
        Name = uri.Segments.Last();
        Uri = uri;
    }
    
    public Torrent()
    {
    }

    public Uri Uri { get; set; }
    
    public string Name { get; set; }
}