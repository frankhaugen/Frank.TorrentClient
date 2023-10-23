using Avalonia.Controls;

using Frank.TorrentClient.Gui.UserControls;
using Frank.TorrentClient.Service;

namespace Frank.TorrentClient.Gui.Pages;

public class SearchPage : UserControl
{
    private readonly ITorrentService _torrentService;
    private SearchControl _searchControl;

    public SearchPage(ITorrentService torrentService)
    {
        _torrentService = torrentService;
        _searchControl = new SearchControl(_torrentService);
        Content = _searchControl;
    }
}