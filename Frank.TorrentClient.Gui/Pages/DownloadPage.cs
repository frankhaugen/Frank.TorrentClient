using Avalonia.Controls;

using DefensiveProgrammingFramework;

using FileWatcherEx;

using Frank.TorrentClient.Gui.UserControls;

namespace Frank.TorrentClient.Gui.Pages;

public class DownloadPage : UserControl
{
    private readonly IFileSystemWatcherEx _fileSystemWatcherEx;
    private readonly TorrentDownloads _torrentDownloads;

    public DownloadPage(IFileSystemWatcherEx fileSystemWatcherEx)
    {
        _fileSystemWatcherEx = fileSystemWatcherEx;
        _torrentDownloads = new TorrentDownloads();
        
        _fileSystemWatcherEx.OnChanged += FileSystemWatcherExOnOnChanged;
    }

    private void FileSystemWatcherExOnOnChanged(object? sender, FileChangedEvent e)
    {
        if (e.ChangeType.IsNotOneOf(ChangeType.CREATED, ChangeType.CHANGED, ChangeType.DELETED))
            return;
        
        var file = new FileInfo(e.FullPath);
        if (file.Extension != ".torrent")
            return;

        if (!TorrentInfo.TryLoad(file.FullName, out var torrentInfo))
            return;

        switch (e.ChangeType)
        {
            case ChangeType.CHANGED:
                break;
            case ChangeType.CREATED:
                _torrentDownloads.Add(torrentInfo);
                break;
            case ChangeType.DELETED:
                _torrentDownloads.Remove(torrentInfo);
                break;
            case ChangeType.RENAMED:
                break;
            case ChangeType.LOG:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}