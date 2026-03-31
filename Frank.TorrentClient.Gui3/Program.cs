using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

using Frank.TorrentClient.Gui3.Pages;
using Frank.TorrentClient.Service;

namespace Frank.TorrentClient.Gui3;

public static class Program
{
    [STAThread]
    static void Main(params string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        AllocConsole();

        IHost host = Host
            .CreateDefaultBuilder(args)
            // .ConfigureAppConfiguration(((context, builder) =>
            // {
            //     builder.SetBasePath(AppContext.BaseDirectory);
            // }))
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTorrentService(hostContext.Configuration);
                services.AddScoped<Application>();
                services.AddScoped<MainWindow>();
                services.AddScoped<SearchPage>();
                services.AddHostedService<WindowHost>();
            })
            .Build();

        host.Run();
    }

    [DllImport("kernel32")]
    static extern bool AllocConsole();
}