using System.Windows;

namespace Frank.TorrentClient.Gui3.UserControls;

public struct GridCellDefinition
{
    public UIElement Content { get; }
    public GridPosition Position { get; }
    public GridSpans Spans { get; }

    public GridCellDefinition(UIElement content, GridPosition position, GridSpans spans)
    {
        Content = content;
        Position = position;
        Spans = spans;
    }
}