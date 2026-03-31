using System.Text;

using CommunityToolkit.Maui;

using Frank.TorrentClient.Service;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Frank.TorrentClient.Gui2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var builder = MauiApp.CreateBuilder();
        builder
            // .CodeMarkupApp<App>(HotReloadSupport.IdeIPs) 
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit(config =>
            {
                config.SetShouldSuppressExceptionsInAnimations(true);
                config.SetShouldSuppressExceptionsInBehaviors(true);
                config.SetShouldSuppressExceptionsInConverters(true);
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Configuration.AddJsonFile("appsettings.json", true);
        builder.Services.AddTorrentService(builder.Configuration);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}