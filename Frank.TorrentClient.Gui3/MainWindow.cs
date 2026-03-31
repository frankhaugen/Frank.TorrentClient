using System.Windows;
using System.Windows.Controls;

using Frank.TorrentClient.Gui3.Pages;

namespace Frank.TorrentClient.Gui3;

public class MainWindow : Window
{
    private readonly SearchPage _page;
    public MainWindow(SearchPage page)
    {
        _page = page;
        
        Title = "Frank.TorrentClient.Gui3";
        Width = 800;
        Height = 600;
        Content = _page;
    }
    
}