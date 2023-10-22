namespace Frank.TorrentClient.Service;

public static class UriExtensions
{
    public static bool IsTorrent(this Uri uri) => uri.Segments.Last().EndsWith(".torrent", StringComparison.OrdinalIgnoreCase);
    
    public static bool IsMagnet(this Uri uri) => uri.Scheme.Equals("magnet", StringComparison.OrdinalIgnoreCase);
    
    public static bool IsTorrentOrMagnet(this Uri uri) => uri.IsTorrent() || uri.IsMagnet();
    
    public static byte[] Download(this Uri uri) => new HttpClient().GetByteArrayAsync(uri).GetAwaiter().GetResult();

    public static FileInfo DownloadToLocation(this Uri uri, DirectoryInfo directory)
    {
        var fileName = uri.Segments.Last();
        var file = new FileInfo(Path.Combine(directory.FullName, fileName));
        var bytes = uri.Download();
        File.WriteAllBytes(file.FullName, bytes);
        return file;
    }
    
    public static FileInfo DownloadToTempLocation(this Uri uri) => uri.DownloadToLocation(new DirectoryInfo(Path.GetTempPath()));

    public static FileInfo DownloadToDownloads(this Uri uri) => uri.DownloadToLocation(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)));
}