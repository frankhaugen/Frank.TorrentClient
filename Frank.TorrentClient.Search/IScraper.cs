namespace Frank.TorrentClient.Search;

public interface IScraper
{
    IEnumerable<Uri> GetTorrentLinks(string query);
}