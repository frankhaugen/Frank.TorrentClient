using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;

using Frank.TorrentClient.Gui.UserControls;
using Frank.TorrentClient.Service;

namespace Frank.TorrentClient.Gui.Pages;

public class DownloadPage : UserControl
{
    private readonly ITorrentService _torrentService;

    public DownloadPage(ITorrentService torrentService)
    {
        _torrentService = torrentService;
        
        Items.VerticalAlignment = VerticalAlignment.Stretch;
        Items.HorizontalAlignment = HorizontalAlignment.Stretch;        
        
        Items.ItemsSource = _torrentService.Torrents;
        Items.DataContext = _torrentService.Torrents;
        
        Items.ItemTemplate = new FuncDataTemplate<TorrentProgressInfo>((x, y) => new TorrentDownloadViewItem(x));
        
        Content = Items;
    }
    
    public ListBox Items { get; } = new ListBox();
}