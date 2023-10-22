using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui.Commands;

public class DownloadCommand : GenericBaseCommand<Torrent>
{
    public DownloadCommand(Action<Torrent> action) : base(action)
    {
    }
}