namespace Frank.TorrentClient.Search;

public interface ISearchProvider<T>
{
    Task<IEnumerable<T>> GetSearchResults(string query);
}