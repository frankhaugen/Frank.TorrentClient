namespace Frank.TorrentClient.Gui3.Extensions;

public static class TypeExtensions
{
    public static List<KeyValuePair<string, string>> GetPropertiesAndValues(this Type type)
    {
        var publicProperties = type.GetProperties().Where(x => x.IsPublic());
        var primitiveProperties = publicProperties.Where(x => x.IsPrimitive());
        var properties = new List<KeyValuePair<string, string>>(primitiveProperties.Select(x => new KeyValuePair<string, string>(x.Name, x.GetValue(x)?.ToString() ?? string.Empty)));
        return properties;
    }
}