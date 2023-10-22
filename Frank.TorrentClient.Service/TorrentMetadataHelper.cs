using bzTorrent.Data;

namespace Frank.TorrentClient.Service;

public static class TorrentMetadataHelper
{
    public static IMetadata? GetMetadataFromFile(FileInfo torrentFile) => Metadata.FromFile(torrentFile.FullName);
    public static IMetadata? GetMetadataFromBytes(byte[] torrentBytes) => Metadata.FromBuffer(torrentBytes);
    public static IMetadata? GetMetadataFromUrl(Uri torrentUrl) => GetMetadataFromBytes(torrentUrl.Download());
}