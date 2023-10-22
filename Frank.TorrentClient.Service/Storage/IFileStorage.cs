namespace Frank.TorrentClient.Service.Storage;

public interface IFileStorage<T> where T : class
{
    void Save(T data);
    T? Load();
}