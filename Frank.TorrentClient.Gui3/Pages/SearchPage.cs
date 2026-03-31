using System.Collections.Concurrent;
using System.Windows.Controls;

using Frank.TorrentClient.Search;
using Frank.TorrentClient.Service;

namespace Frank.TorrentClient.Gui3.Pages;

public class SearchPage : Page
{
    private readonly StackPanel _stackPanel = new();
    private readonly SearchInput _searchInput;
    private readonly SearchResults _searchResultsPage;
    
    private readonly ITorrentSearchService _torrentSearchService;
    
    public SearchPage(ITorrentSearchService torrentSearchService)
    {
        _torrentSearchService = torrentSearchService;
        _searchInput = new SearchInput();
        _searchResultsPage = new SearchResults();
        _stackPanel.Children.Add(_searchInput);
        _stackPanel.Children.Add(_searchResultsPage);
        Content = _stackPanel;
        
        _searchInput.SearchEventRaised += SearchInputOnSearchEventRaised;
    }

    private async void SearchInputOnSearchEventRaised(object? sender, string e)
    {
        var results = await _torrentSearchService.SearchAsync(e);
        
        _searchResultsPage.SetSearchResults(results);
    }
}

public class SearchResults : UserControl
{
    private readonly ConcurrentBag<TorrentSearchResult> _results = new();

    public SearchResults()
    {
        var dataGrid = new DataGrid();
        
        dataGrid.ItemsSource = _results;
        dataGrid.DataContext = _results;
        
        Content = dataGrid;
    }
    
    public void SetSearchResults(IEnumerable<TorrentSearchResult> results)
    {
        _results.Clear();
        foreach (var result in results)
        {
            _results.Add(result);
        }
    }
}