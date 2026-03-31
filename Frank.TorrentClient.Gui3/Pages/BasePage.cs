using System.Windows.Controls;

namespace Frank.TorrentClient.Gui3.UserControls;

public class BasePage : Page
{
    protected readonly Grid _grid = new();
    protected readonly ContentBox _contentBox;
    
    public BasePage()
    {
        _contentBox = new ContentBox("BasePage", _grid);
        Content = _contentBox;
    }
}