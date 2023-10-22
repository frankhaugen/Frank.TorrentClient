using FileWatcherEx;

using Frank.TorrentClient.Service.Storage;

using Microsoft.Extensions.Options;

namespace Frank.TorrentClient.Service;

public class TorrentService : ITorrentService
{
    private readonly IOptions<TorrentsConfiguration> _options;
    private readonly TorrentClient _torrentClient;
    private readonly IFileSystemWatcherWrapper _fileSystemWatcher;
    private readonly ITorrentStorageService _storageService;

    public TorrentService(IOptions<TorrentsConfiguration> options, ITorrentStorageService storageService)
    {
        _options = options;
        _storageService = storageService;

        var fileSystemWatcher = new FileSystemWatcherWrapper()
        {
            Path = _options.Value.TorrentsDirectory,
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime,
            EnableRaisingEvents = true,
            IncludeSubdirectories = false,
            Filters = { "*.torrent" }
        };
        
        fileSystemWatcher.Created += FileSystemWatcherOnCreated;
        
        _fileSystemWatcher = fileSystemWatcher;
        
        _torrentClient = new TorrentClient(_options.Value.Port, _options.Value.TorrentsDirectory);
        _torrentClient.Start();
    }

    private void FileSystemWatcherOnCreated(object sender, FileSystemEventArgs e)
    {
        
    }
    
    public void FindTorrents()
    {
        var torrents = _storageService.GetTorrentFiles();
        
        
        
        foreach (var torrent in torrents)
        {
            _storageService.Save(torrent);
        }
    }


    public void Dispose()
    {
        _fileSystemWatcher.Dispose();
        _torrentClient.Dispose();
    }
}