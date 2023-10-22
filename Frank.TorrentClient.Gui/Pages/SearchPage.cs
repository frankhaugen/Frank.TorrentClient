using Avalonia.Controls;
using Avalonia.Layout;

using Frank.TorrentClient.Gui.Components.Search;
using Frank.TorrentClient.Gui.UserControls;

namespace Frank.TorrentClient.Gui.Pages;

public class SearchPage : UserControl
{
    private readonly ISearchProvider<Person> _searchProvider;
    private SearchBox _searchBox;
    private SearchResults<Person> _searchResults;

    public SearchPage(ISearchProvider<Person> searchProvider)
    {
        _searchProvider = searchProvider;

        _searchBox = new SearchBox(query => Search(query));
        _searchResults = new SearchResults<Person>();

        StackPanel panel = new() { Orientation = Orientation.Vertical };
        panel.Children.Add(_searchBox);
        panel.Children.Add(_searchResults);

        Content = panel;
    }

    private void Search(string query)
    {
        // Invoke the search provider and update the results
        _searchProvider.GetSearchResults(query).ContinueWith(task =>
        {
            _searchResults.Items = task.Result;
        });
    }
}