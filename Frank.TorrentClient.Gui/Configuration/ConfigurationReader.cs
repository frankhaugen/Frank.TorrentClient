using Microsoft.Extensions.Configuration;

namespace Frank.TorrentClient.Gui.Configuration;

public static class ConfigurationReader
{
    public static IConfiguration GetConfiguration()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        return configuration;
    }
}