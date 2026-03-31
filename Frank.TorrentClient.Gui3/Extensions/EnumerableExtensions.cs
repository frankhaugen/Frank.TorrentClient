namespace Frank.TorrentClient.Gui3.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector) => source.ToList().GroupBy(selector).Select(group => @group.First());
    
    public static IEnumerable<string?> ToStrings<T>(this IEnumerable<T> source)
    {
        var output = new List<string?>();

        foreach (var value in source)
            output.Add(value!.ToString());

        return output;
    }

    public static IEnumerable<T> DoForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var value in source)
        {
            action.Invoke(value);
        }

        return source;
    }
}