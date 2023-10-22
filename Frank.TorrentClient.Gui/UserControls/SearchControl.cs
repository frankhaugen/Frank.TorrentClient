using System.Diagnostics;

using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

using Frank.TorrentClient.Gui.Pages;
using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui.UserControls;

public class SearchControl : StackPanel
{
    private readonly SearchResults<TorrentSearchResult> _searchResults = new();
    private readonly ISearchProvider<TorrentSearchResult> _searchProvider;

    public SearchControl(ISearchProvider<TorrentSearchResult> searchProvider, IDataTemplate dataTemplate)
    {
        _searchProvider = searchProvider;
        _searchResults.Items.ItemTemplate = dataTemplate;

        Orientation = Orientation.Vertical;

        SearchBox searchBox = new(async query => await SearchAsync(query));

        Children.Add(searchBox);
        Children.Add(_searchResults);
    }

    private async Task SearchAsync(string query)
    {
        _searchResults.Data.Clear();

        IEnumerable<TorrentSearchResult> results = await _searchProvider.GetSearchResults(query);

        foreach (TorrentSearchResult result in results)
        {
            _searchResults.Data.Add(result);
        }
    }
}