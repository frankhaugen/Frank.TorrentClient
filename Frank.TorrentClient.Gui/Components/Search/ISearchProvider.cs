namespace Frank.TorrentClient.Gui.Pages.Search;

public interface ISearchProvider<T>
{
    Task<IEnumerable<SearchResultItem<T>>> GetSearchResults(string query);
}