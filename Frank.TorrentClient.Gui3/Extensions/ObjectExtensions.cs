namespace Frank.TorrentClient.Gui3.Extensions;

public static class ObjectExtensions
{
    public static T As<T>(this object source) where T : class => (T)source;
}