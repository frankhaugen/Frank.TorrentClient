namespace Frank.TorrentClient.Search;

internal interface ITorrentSearcher
{
    IEnumerable<Uri> Search(string search);
}