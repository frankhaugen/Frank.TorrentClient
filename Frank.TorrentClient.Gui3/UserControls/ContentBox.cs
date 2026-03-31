using System.Windows;
using System.Windows.Controls;

namespace Frank.TorrentClient.Gui3.UserControls;

public class ContentBox : GroupBox
{
    private readonly ScrollViewer _scrollViewer = new();
    public ContentBox(string header, UIElement content)
    {
        Header = header;
        _scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        _scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        _scrollViewer.CanContentScroll = true;
        _scrollViewer.Content = content;
        Content = _scrollViewer;
    }
}