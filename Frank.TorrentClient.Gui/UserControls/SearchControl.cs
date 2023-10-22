using System.Diagnostics;

using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

using Frank.TorrentClient.Gui.Pages;
using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui.UserControls;

public class SearchControl : StackPanel
{
    private readonly SearchResults<Torrent> _searchResults = new();
    private readonly ISearchProvider<Torrent> _searchProvider;

    public SearchControl(ISearchProvider<Torrent> searchProvider, IDataTemplate dataTemplate)
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

        IEnumerable<Torrent> results = await _searchProvider.GetSearchResults(query);

        foreach (Torrent result in results)
        {
            _searchResults.Data.Add(result);
        }
    }
}