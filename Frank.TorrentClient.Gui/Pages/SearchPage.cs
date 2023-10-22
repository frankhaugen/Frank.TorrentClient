using Avalonia.Controls;
using Avalonia.Controls.Templates;

using Frank.TorrentClient.Gui.UserControls;
using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui.Pages;

public class SearchPage : UserControl
{
    private readonly ISearchProvider<Torrent> _searchProvider;
    private SearchControl _searchControl;

    public SearchPage(ISearchProvider<Torrent> searchProvider, IDataTemplate dataTemplate)
    {
        _searchProvider = searchProvider;
        _searchControl = new SearchControl(_searchProvider, dataTemplate);
        Content = _searchControl;
    }
}