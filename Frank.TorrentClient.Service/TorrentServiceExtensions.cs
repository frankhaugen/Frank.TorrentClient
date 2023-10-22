using Frank.TorrentClient.Search;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.TorrentClient.Service;

public static class TorrentServiceExtensions
{
    public static IServiceCollection AddTorrentService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TorrentsConfiguration>(configuration.GetSection(nameof(TorrentsConfiguration)));
        
        services.AddSingleton<ISearchProvider<TorrentSearchResult>, TorrentSearchProvider>();
        services.AddSingleton<ITorrentSearchService, TorrentSearchService>();
        services.AddSingleton<ITorrentsDownloadService, TorrentsDownloadService>();
        services.AddSingleton<ITorrentService, TorrentService>();

        return services;
    }
}