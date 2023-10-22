namespace Frank.TorrentClient.Gui.Components.Search;

public interface ISearchProvider<T>
{
    Task<IEnumerable<SearchResultItem<T>>> GetSearchResults(string query);
}