namespace Frank.TorrentClient.Gui3.Extensions;

public static class ListExtensions
{
    public static List<T> ClearAnd<T>(this List<T> source)
    {
        source.Clear();
        return source;
    }

    public static void Then<T>(this T source, Action action) => action.Invoke();

}