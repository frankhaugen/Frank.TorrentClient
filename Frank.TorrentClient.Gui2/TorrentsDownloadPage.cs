using Frank.TorrentClient.Service;

namespace Frank.TorrentClient.Gui2;

public class TorrentsDownloadPage : Page
{
    private readonly ITorrentService _torrentService;
    
    public TorrentsDownloadPage(ITorrentService torrentService)
    {
        _torrentService = torrentService;
        
        var torrents = _torrentService.Torrents;
        
        var listView = new ListView
        {
            ItemsSource = torrents,
            ItemTemplate = new DataTemplate(() =>
            {
                var label = new Label();
                label.SetBinding(Label.TextProperty, "Name");
                return new ViewCell
                {
                    View = label
                };
            })
        };
        
        this.AddLogicalChild(listView);
    }
}