using System.Windows;
using System.Windows.Controls;

using Frank.TorrentClient.Gui3.Extensions;

namespace Frank.TorrentClient.Gui3.UserControls;

public class GridBuilder
{
    private readonly int _columns;
    private readonly int _rows;
    private readonly Dictionary<GridPosition, GridCellDefinition> _content = new();

    private GridBuilder(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
    }

    public static GridBuilder Create(int rows, int columns) => new(rows, columns);

    public GridBuilder WithContent(UIElement content, int row, int column)
    {
        var gridPosition = new GridPosition((uint)row, (uint)column);
        var gridCellDefinition = new GridCellDefinition(content, gridPosition, new GridSpans(1, 1));
        _content.Add(gridPosition, gridCellDefinition);
        return this;
    }
    
    public GridBuilder WithContent(UIElement content, int row, int column, int rowSpan, int columnSpan)
    {
        var gridPosition = new GridPosition((uint)row, (uint)column);
        var gridCellDefinition = new GridCellDefinition(content, gridPosition, new GridSpans((uint)rowSpan, (uint)columnSpan));
        _content.Add(gridPosition, gridCellDefinition);
        return this;
    }
    
    public GridBuilder WithContent(UIElement content, GridPosition position, GridSpans spans)
    {
        var gridCellDefinition = new GridCellDefinition(content, position, spans);
        _content.Add(position, gridCellDefinition);
        return this;
    }
    
    public GridBuilder WithContent(UIElement content, GridPosition position)
    {
        var gridCellDefinition = new GridCellDefinition(content, position, new GridSpans(1, 1));
        _content.Add(position, gridCellDefinition);
        return this;
    }
    
    public Grid Build()
    {
        var grid = new Grid();
        grid.GenerateGridRowsAndColumns(_rows, _columns);

        foreach (var gridCellDefinition in _content)
        {
            var key = gridCellDefinition.Key;
            var value = gridCellDefinition.Value.Content;
            var spans = gridCellDefinition.Value.Spans;
            grid.Children.Add(value);
            Grid.SetRow(value, key.Row.ToInt());
            Grid.SetColumn(value, key.Column.ToInt());
            Grid.SetRowSpan(value, spans.RowSpan.ToInt());
            Grid.SetColumnSpan(value, spans.ColumnSpan.ToInt());
        }

        return grid;
    }
}