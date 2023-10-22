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

    public static TorrentDirectories GetTorrentDirectories()
    {
        IConfiguration configuration = GetConfiguration();
        TorrentDirectories torrentDirectories = new TorrentDirectories();
        configuration.GetSection("TorrentDirectories").Bind(torrentDirectories);
        return torrentDirectories;
    }
    
    public static TorrentClientSettings GetTorrentClientSettings()
    {
        IConfiguration configuration = GetConfiguration();
        TorrentClientSettings torrentClientSettings = new TorrentClientSettings();
        configuration.GetSection("TorrentClientSettings").Bind(torrentClientSettings);
        return torrentClientSettings;
    }
}