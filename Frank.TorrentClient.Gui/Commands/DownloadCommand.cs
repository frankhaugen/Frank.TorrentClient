using Frank.TorrentClient.Search;

namespace Frank.TorrentClient.Gui.Commands;

public class DownloadCommand : GenericBaseCommand<TorrentSearchResult>
{
    public DownloadCommand(Action<TorrentSearchResult> action) : base(action)
    {
    }
}