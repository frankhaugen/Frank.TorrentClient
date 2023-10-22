namespace Frank.TorrentClient.Service.Storage;

public class TorrentStorageService : ITorrentStorageService
{
    private readonly DataStorage<TorrentFile> _dataStorageService;

    public TorrentStorageService(DataStorage<TorrentFile> dataStorageService)
    {
        _dataStorageService = dataStorageService;
    }
    
    public void Save(TorrentFile torrentFile)
    {
        _dataStorageService.AddItem(torrentFile);
    }
    
    public IEnumerable<TorrentFile> GetTorrentFiles()
    {
        return _dataStorageService.GetItems();
    }
    
    public void Remove(TorrentFile torrentFile)
    {
        _dataStorageService.RemoveItem(torrentFile);
    }
    
    public void RefreshData()
    {
        _dataStorageService.RefreshData();
    }
}