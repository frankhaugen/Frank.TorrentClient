using bzTorrent.Data;

namespace Frank.TorrentClient.Search;

public static class TempFilesHelper
{
    private static string TempDirectory = string.Empty;
    private static bool _initialized = false;

    public static void Initialize()
    {
        TempDirectory = Path.Combine(Path.GetTempPath(), "Frank.TorrentClient.Search");
        Directory.CreateDirectory(TempDirectory);
        _initialized = true;
    }

    public static async Task<FileInfo> GetFileFromUriAsync(Uri uri)
    {
        if (!_initialized)
            throw new InvalidOperationException("TempFilesHelper has not been initialized.");
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(uri);
        response.EnsureSuccessStatusCode();

        var tempFilePath = Path.Combine(TempDirectory, Path.GetFileName(uri.LocalPath));
        await File.WriteAllBytesAsync(tempFilePath, await response.Content.ReadAsByteArrayAsync());

        return new FileInfo(tempFilePath);
    }

    public static void Dispose()
    {
        Directory.Delete(TempDirectory, true);
    }
}