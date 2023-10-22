namespace Frank.TorrentClient.Service.Storage;

public interface IDataStorage<T> where T : class, new()
{
    void RefreshData();
    void AddItem(T item);
    IEnumerable<T> GetItems();
    T? GetItem(Func<T, bool> predicate);
    void RemoveItem(T item);
}