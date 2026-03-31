namespace Frank.TorrentClient.Gui3.Extensions;

public static class DictionaryExtensions
{
    /// <summary>
    /// Maps a dynamic from a dictionary to a complex type
    /// </summary>
    /// <typeparam name="T">Whatever type you want to populate</typeparam>
    /// <param name="source"></param>
    /// <param name="key">The key for the dictionary, defaults uses nameof(T)</param>
    /// <param name="throwOnFailure">If a value is wrong type, or key is missing should it throw</param>
    /// <returns></returns>
    public static T GetValue<T>(this IReadOnlyDictionary<string, dynamic> source, string? key = null, bool throwOnFailure = false) where T : class, new()
    {
        if (string.IsNullOrWhiteSpace(key))
            key = nameof(T);

        if (source.TryGetValue(key, out var value) && value is T result)
            return result;

        if (throwOnFailure)
            throw new ArgumentOutOfRangeException(nameof(key), key, $"The Dictionary does not contain a key presented, or the type is wrong");

        return new T();
    }
}