using Avalonia;
using Avalonia.Controls;

using Frank.TorrentClient.Gui.Pages;
using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui;

public class MainWindow : Window
{
    private ISearchProvider<Torrent> _searchProvider;
    private TabControl _tabControl;

    public MainWindow()
    {
        SetupWindow();

        // Create an instance of your search provider
        _searchProvider = new TorrentSearchProvider();

        // Create TabControl and assign it to the window content
        _tabControl = new TabControl();
        Content = _tabControl;

        // Define the tabs
        TabItem searchTab = new() { Header = "Search", Content = new SearchPage<Torrent>(_searchProvider) };
        TabItem downloadsTab = new()
        {
            Header = "Downloads", Content = new TextBlock { Text = "Downloads content goes here" }
        };
        TabItem aboutTab = new() { Header = "About", Content = new TextBlock { Text = "About content goes here" } };

        // Add tabs to the TabControl
        _tabControl.Items.Add(searchTab);
        _tabControl.Items.Add(downloadsTab);
        _tabControl.Items.Add(aboutTab);

        this.AttachDevTools();
    }

    private void SetupWindow()
    {
        // Set the Window's properties
        Title = "Torrent App";
        Width = 800;
        Height = 600;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }
}