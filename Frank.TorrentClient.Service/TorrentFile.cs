namespace Frank.TorrentClient.Service;

public class TorrentFile : IEqualityComparer<TorrentFile>
{
    public string Name { get; set; }
    
    public Uri Origin { get; set; }
    
    public FileInfo Source { get; set; }

    public bool Equals(TorrentFile x, TorrentFile y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Origin.Equals(y.Origin) && string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase) && x.Source.Equals(y.Source);
    }

    public int GetHashCode(TorrentFile obj)
    {
        HashCode hashCode = new();
        hashCode.Add(obj.Origin);
        hashCode.Add(obj.Name, StringComparer.OrdinalIgnoreCase);
        hashCode.Add(obj.Source);
        return hashCode.ToHashCode();
    }
    
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals(obj as TorrentFile);
    }

    public bool Equals(TorrentFile? torrentFile)
    {
        if (ReferenceEquals(null, torrentFile)) return false;
        if (ReferenceEquals(this, torrentFile)) return true;
        return Origin.Equals(torrentFile.Origin) && string.Equals(Name, torrentFile.Name, StringComparison.OrdinalIgnoreCase) && Source.Equals(torrentFile.Source);
    }

    public override int GetHashCode() => GetHashCode(this);
}