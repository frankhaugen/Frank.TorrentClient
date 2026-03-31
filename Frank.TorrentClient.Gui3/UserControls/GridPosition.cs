namespace Frank.TorrentClient.Gui3.UserControls;

public struct GridPosition
{
    public uint Row { get; }
    public uint Column { get; }

    public GridPosition(uint row, uint column)
    {
        Row = row;
        Column = column;
    }
}