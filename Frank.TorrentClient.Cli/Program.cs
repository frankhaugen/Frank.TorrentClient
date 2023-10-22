using System.CommandLine;
using Frank.TorrentClient.TorrentEventArgs;

namespace Frank.TorrentClient.Cli;

internal class Program
{
    static async Task<int> Main(string[] args)
    {
        var val1 = "--file";
        var val2 = "/home/frank/repos/Frank.TorrentClient/Test/Frank.TorrentClientTest/Files/debian-9.3.0-s390x-netinst.torrent";
        var val3 = "--directory";
        var val4 = "/home/frank/Downloads";

        if (args == null || args.Length == 0)
        {
            Console.WriteLine("No arguments provided");
            throw new ArgumentNullException(nameof(args));
            //args = new[] { val1, val2, val3, val4 };
        }

        var fileOption = new Option<string>(
            name: "--file",
            description: "The file to read and display on the console.");
        fileOption.AddAlias("-f");

        var directoryOption = new Option<string>(
            name: "--directory",
            description: "The directory to save the torrent to.");
        directoryOption.AddAlias("-d");

        var rootCommand = new RootCommand("Download a torrent file.");
        rootCommand.AddOption(fileOption);
        rootCommand.AddOption(directoryOption);

        rootCommand.SetHandler(async (file, directory) => 
            {

                var fileInfo = new FileInfo(file);
                var directoryInfo = new DirectoryInfo(directory);
                await HandleCommandLine(fileInfo, directoryInfo); 
            },
            fileOption,
            directoryOption);

        return await rootCommand.InvokeAsync(args);
    }

    private static async Task HandleCommandLine(FileInfo torrentFile, DirectoryInfo outputDirectory)
    {
        if (torrentFile == null)
        {
            Console.WriteLine("Error: Missing torrent file argument.");
            return;
        }

        if (!torrentFile.Exists)
        {
            Console.WriteLine($"Error: File '{torrentFile.FullName}' does not exist.");
            return;
        }

        if (!torrentFile.Extension.Equals(".torrent", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Error: File '{torrentFile.FullName}' is not a .torrent file.");
            return;
        }

        if (outputDirectory == null)
        {
            Console.WriteLine("Error: Missing output directory argument.");
            return;
        }

        if (!outputDirectory.Exists)
        {
            Console.WriteLine($"Error: Directory '{outputDirectory.FullName}' does not exist.");
            return;
        }

        var torrentInfoIsValid = TorrentInfo.TryLoad(torrentFile.FullName, out var torrent);

        if (!torrentInfoIsValid)
        {
            Console.WriteLine($"Error: File '{torrentFile.FullName}' is not a valid .torrent file.");
            return;
        }

        var torrentClient = new TorrentClient(4000, outputDirectory.FullName);

        torrentClient.Start();

        torrentClient.TorrentStarted += StartedHandler;
        torrentClient.TorrentStopped += StoppedHandler;
        torrentClient.TorrentHashing += HashingHandler;
        torrentClient.TorrentSeeding += SeedingHandler;
        torrentClient.TorrentLeeching += LeechingHandler;

        torrentClient.Start(torrent);

        var count = 0;

        while (GetProgressInfo(torrentClient, torrent).CompletedPercentage < 100)
        {
            var progressInfo = GetProgressInfo(torrentClient, torrent);
            Console.WriteLine($"Torrent '{torrent.InfoHash}' is {progressInfo.CompletedPercentage}% complete.");
            await Task.Delay(1000);

            if (count++ > 120 && progressInfo.CompletedPercentage < 1)
            {
                break;
            }
        }
    }

    private static TorrentProgressInfo GetProgressInfo(TorrentClient torrentClient, TorrentInfo torrent)
    {
        return torrentClient.GetProgressInfo(torrent.InfoHash);
    }

    private static void LeechingHandler(object sender, TorrentLeechingEventArgs e)
    {
        var args = sender as TorrentClient;
        if (args == null)
        {
            
        }

        Console.WriteLine($"Torrent '{sender.GetType().Name}' leeching.");
    }

    private static void SeedingHandler(object sender, TorrentSeedingEventArgs e)
    {
        Console.WriteLine($"Torrent '{sender.GetType().Name}' seeding.");
    }

    private static void HashingHandler(object sender, TorrentHashingEventArgs e)
    {
        Console.WriteLine($"Torrent '{sender.GetType().Name}' hashing.");
    }

    private static void StoppedHandler(object sender, TorrentStoppedEventArgs e)
    {
        Console.WriteLine($"Torrent '{sender.GetType().Name}' stopped.");
    }

    private static void StartedHandler(object sender, TorrentStartedEventArgs e)
    {
        Console.WriteLine($"Torrent '{sender.GetType().Name}' started.");
    }
}