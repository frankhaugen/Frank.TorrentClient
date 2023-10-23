using bzTorrent.Data;

namespace Frank.TorrentClient.Service;

public class Torrent
{
    public required TorrentFile TorrentFile { get; init; }
    
    public required TorrentInfo TorrentInfo { get; init; }

    public required IMetadata TorrentMetadata { get; init; }
    
    public TorrentProgressInfo? ProgressInfo { get; set; }
}