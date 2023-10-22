namespace Frank.TorrentClient.Service;

public class TorrentsConfiguration
{
    public string DownloadDirectory { get; set; }
    public string TorrentsDirectory { get; set; }
    public int Port { get; set; } = 4000;
}