using Frank.TorrentClient.Service;

namespace Frank.TorrentClient.Gui2;

public class MainPage : TabbedPage
{
    private readonly ITorrentService _torrentService;

    public MainPage(ITorrentService torrentService)
    {
        _torrentService = torrentService;

        Children.Add(new TorrentsDownloadPage(_torrentService));
    }
}