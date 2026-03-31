namespace Frank.TorrentClient.Gui2;

public class MainPage : TabbedPage
{
    public MainPage()
    {
        Children.Add(new TorrentsDownloadPage());
    }
}