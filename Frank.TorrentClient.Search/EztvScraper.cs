using HtmlAgilityPack;

namespace Frank.TorrentClient.Search;

public class EztvScraper : IScraper
{
    public IEnumerable<Uri> GetTorrentLinks(string query)
    {
        var url = $"https://eztv.re/search/{query.Replace(" ", "-")}";
        var web = new HtmlWeb();
        var doc = web.Load(url);

        var links = doc.DocumentNode.SelectNodes("//a[@href]")
            .Where(node => node.Attributes["href"].Value.EndsWith(".torrent"))
            .Select(node => node.Attributes["href"].Value);

        return links.Select(link => new Uri(link, UriKind.Absolute));
    }
}