using System.Text.Json;

namespace Frank.TorrentClient.Service.Storage;

public class FileStorage<T> : IFileStorage<T> where T : class
{
    private readonly string _path = Path.Combine(AppContext.BaseDirectory, typeof(T).Name + ".json");

    public void Save(T data)
    {
        string jsonData = JsonSerializer.Serialize(data);
        File.WriteAllText(_path, jsonData);
    }

    public T? Load()
    {
        if (!File.Exists(_path))
        {
            return null;
        }

        string jsonData = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<T>(jsonData);
    }
}