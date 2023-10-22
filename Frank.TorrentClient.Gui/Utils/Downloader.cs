namespace Frank.TorrentClient.Gui.Utils;

public static class Downloader
{
    public static void Download(Uri uri, DirectoryInfo directory) => DownloadAsync(uri, directory).GetAwaiter().GetResult();
    
    public static async Task DownloadAsync(Uri uri, DirectoryInfo directory)
    {
        using HttpClient client = new();
        using HttpResponseMessage response = await client.GetAsync(uri);
        await using Stream streamToReadFrom = await response.Content.ReadAsStreamAsync();
        var file = new FileInfo(Path.Combine(directory.FullName, uri.Segments.Last()));
        await using FileStream streamToWriteTo = file.Open(FileMode.Create);
        await streamToReadFrom.CopyToAsync(streamToWriteTo);
    }
}