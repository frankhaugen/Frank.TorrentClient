using Frank.TorrentClient.Service.Storage;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.TorrentClient.Service;

public static class TorrentServiceExtensions
{
    public static IServiceCollection AddTorrentService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TorrentsConfiguration>(configuration.GetSection(nameof(TorrentsConfiguration)));
        
        services.AddSingleton<IDataStorage<TorrentFile>, DataStorage<TorrentFile>>();
        services.AddSingleton<ITorrentStorageService, TorrentStorageService>();
        
        services.AddSingleton<ITorrentService, TorrentService>();

        return services;
    }
}