using Frank.TorrentClient.Service;

namespace Frank.TorrentClient.Gui2;

public class App : Application
{
    public App(ITorrentService torrentService)
    {
        MainPage = new MainPage(torrentService);
    }
}