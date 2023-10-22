using Avalonia.Controls;

using Frank.TorrentClient.Gui.UserControls;
using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui.Pages;

public class SearchPage<T> : UserControl
{
    private readonly ISearchProvider<T> _searchProvider;
    private SearchControl<T> _searchControl;

    public SearchPage(ISearchProvider<T> searchProvider)
    {
        _searchProvider = searchProvider;
        _searchControl = new SearchControl<T>(_searchProvider);
        Content = _searchControl;
    }
}