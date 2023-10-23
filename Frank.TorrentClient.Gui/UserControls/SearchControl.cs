using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

using Frank.TorrentClient.Gui.Commands;
using Frank.TorrentClient.Search;
using Frank.TorrentClient.Service;

namespace Frank.TorrentClient.Gui.UserControls;

public class SearchControl : StackPanel
{
    private readonly SearchResults<TorrentSearchResult> _searchResults = new();
    private readonly ITorrentService _torrentService;

    public SearchControl(ITorrentService torrentService)
    {
        _torrentService = torrentService;
        
        _searchResults.Items.ItemTemplate = new FuncDataTemplate<TorrentSearchResult>((x, y) => new TorrentSearchResultViewItem(x, new DownloadCommand(result => _torrentService.SelectResultToDownload(x))));

        Orientation = Orientation.Vertical;

        SearchBox searchBox = new(async query => await SearchAsync(query));
        Children.Add(searchBox);
        Children.Add(_searchResults);
    }

    private async Task SearchAsync(string query)
    {
        _searchResults.Data.Clear();

        IEnumerable<TorrentSearchResult> results = await _torrentService.SearchAsync(query);

        foreach (TorrentSearchResult result in results)
        {
            _searchResults.Data.Add(result);
        }
    }
}