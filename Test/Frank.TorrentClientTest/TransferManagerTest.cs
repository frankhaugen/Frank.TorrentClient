using System.Threading;
using Frank.TorrentClient;
using Frank.TorrentClient.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest;

/// <summary>
///     The transfer manager test.
/// </summary>
[TestClass]
public class TransferManagerTest
{
    /// <summary>
    ///     Initializes this instance.
    /// </summary>
    [TestInitialize]
    public void Initialize()
    {
        @"Test\".DeleteDirectoryRecursively();
    }

    /// <summary>
    ///     Tests the peer transfer.
    /// </summary>
    [TestMethod]
    public void TestTransferManager()
    {
        TorrentInfo torrent;
        PersistenceManager pm;
        ThrottlingManager tm;
        TransferManager transfer;

        TorrentInfo.TryLoad(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", out torrent);

        tm = new ThrottlingManager();
        tm.WriteSpeedLimit = 1024 * 1024;
        tm.ReadSpeedLimit = 1024 * 1024;

        pm = new PersistenceManager(@"Test\", torrent.Length, torrent.PieceLength, torrent.PieceHashes, torrent.Files);

        transfer = new TransferManager(4000, torrent, tm, pm);
        transfer.Start();

        while (transfer.CompletedPercentage < 100) Thread.Sleep(1000);
    }
}