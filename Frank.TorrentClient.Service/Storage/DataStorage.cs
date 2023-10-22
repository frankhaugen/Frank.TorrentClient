namespace Frank.TorrentClient.Service.Storage;

public class DataStorage<T> : IDataStorage<T> where T : class, new()
{
    private readonly FileStorage<List<T>> _fileStorage;
    private readonly List<T> _data;

    public DataStorage()
    {
        _fileStorage = new FileStorage<List<T>>();
        _data = _fileStorage.Load() ?? Activator.CreateInstance<List<T>>();
    }
    
    public void RefreshData()
    {
        _data.Clear();
        _data.AddRange(_fileStorage.Load() ?? Activator.CreateInstance<List<T>>());
    }

    public void AddItem(T item)
    {
        _data.Add(item);
        SaveChanges();
    }

    public IEnumerable<T> GetItems()
    {
        return _data.AsReadOnly();
    }

    public T? GetItem(Func<T, bool> predicate)
    {
        return _data.FirstOrDefault(predicate);
    }

    public void RemoveItem(T item)
    {
        _data.Remove(item);
        SaveChanges();
    }

    private void SaveChanges()
    {
        _fileStorage.Save(_data);
    }
}