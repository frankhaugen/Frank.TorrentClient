namespace Frank.TorrentClient.Gui3.UserControls;

public struct GridSpans
{
    public uint RowSpan { get; }
    public uint ColumnSpan { get; }

    public GridSpans(uint rowSpan, uint columnSpan)
    {
        RowSpan = rowSpan;
        ColumnSpan = columnSpan;
    }
}