using Avalonia;
using Avalonia.Controls;

using Frank.TorrentClient.Gui.Configuration;
using Frank.TorrentClient.Gui.Pages;
using Frank.TorrentClient.Service;

using Microsoft.Extensions.DependencyInjection;

namespace Frank.TorrentClient.Gui;

public class MainWindow : Window
{
    public MainWindow()
    {
        // Initialize dependencies
        
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTorrentService(ConfigurationReader.GetConfiguration());
        var serviceProvider = serviceCollection.BuildServiceProvider(new ServiceProviderOptions() { ValidateOnBuild = true, ValidateScopes = true });
        var torrentService = serviceProvider.GetRequiredService<ITorrentService>();

        // Initialize tabs
        TabItem searchTab = new() { Header = "Search", Content = new SearchPage(torrentService) };
        TabItem downloadsTab = new() { Header = "Downloads", Content = new DownloadPage(torrentService) };
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
        Title = "Torrent App";
        Width = 1000;
        Height = 800;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        base.OnInitialized();
    }
}