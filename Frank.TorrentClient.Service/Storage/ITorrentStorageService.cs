namespace Frank.TorrentClient.Service.Storage;

public interface ITorrentStorageService
{
    void Save(TorrentFile torrentFile);
    IEnumerable<TorrentFile> GetTorrentFiles();
    void Remove(TorrentFile torrentFile);
    void RefreshData();
}