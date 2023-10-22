using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

using FileWatcherEx;

using Frank.TorrentClient.Gui.Configuration;
using Frank.TorrentClient.Gui.Pages;
using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui;

public class MainWindow : Window
{
    public MainWindow()
    {
        // Initialize dependencies
        var searchProvider = new TorrentSearchProvider();
        var dataTemplate = new FuncDataTemplate<Torrent>((x, y) => new TorrentViewItem(x));
        var fileSystemWatcherEx = new FileSystemWatcherEx(ConfigurationReader.GetTorrentDirectories().WatchDirectory)
        {
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
        };

        // Initialize tabs
        TabItem searchTab = new() { Header = "Search", Content = new SearchPage(searchProvider, dataTemplate) };
        TabItem downloadsTab = new() { Header = "Downloads", Content = new DownloadPage(fileSystemWatcherEx) };
        TabItem aboutTab = new() { Header = "About", Content = new AboutPage() };
        
        // Initialize tab control
        TabControl tabControl = new();
        tabControl.Items.Add(searchTab);
        tabControl.Items.Add(downloadsTab);
        tabControl.Items.Add(aboutTab);

        // Initialize Content
        Content = tabControl;
        this.AttachDevTools();
    }
    
    protected override void OnInitialized()
    {
        TempFilesHelper.Initialize();

        Title = "Torrent App";
        Width = 800;
        Height = 600;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        base.OnInitialized();
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        TempFilesHelper.Dispose();
        base.OnClosing(e);
    }
}