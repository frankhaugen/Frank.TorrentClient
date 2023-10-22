using Avalonia.Controls;
using Avalonia.Layout;

using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui.UserControls;

public class SearchControl<T> : StackPanel
{
    private SearchBox _searchBox;
    private SearchResults<T> _searchResults;
    private readonly ISearchProvider<T> _searchProvider;

    public SearchControl(ISearchProvider<T> searchProvider)
    {
        _searchProvider = searchProvider;

        // Initialize the search box with a custom search handler 
        _searchBox = new SearchBox(async query => await SearchAsync(query));

        // Initialize the search results grid
        _searchResults = new SearchResults<T>();

        // Define orientation
        this.Orientation = Orientation.Vertical;

        // Add both controls to the StackPanel
        this.Children.Add(_searchBox);
        this.Children.Add(_searchResults);
    }

    private async Task SearchAsync(string query)
    {
        // Clear the previous results
        _searchResults.ClearResults();

        // Fetch new results and add them to the grid
        var results = await _searchProvider.GetSearchResults(query);
        foreach (var result in results)
        {
            try
            {
                _searchResults.AddResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}