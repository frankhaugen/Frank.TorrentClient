using System.IO;
using System.Linq;
using Frank.TorrentClient;
using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest;

/// <summary>
///     The persistence manager test.
/// </summary>
[TestClass]
public class PersistenceManagerTest
{
    /// <summary>
    ///     Tests the persistence manager transfer.
    /// </summary>
    /// <param name="sourcePath">The source path.</param>
    /// <param name="destPath">The dest path.</param>
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataTestMethod]
    public void PersistenceManager_Test(string sourcePath, string destPath)
    {
        if (TorrentInfo.TryLoad(sourcePath, out var torrent))
        {
            using (var src = new PersistenceManager(Path.GetDirectoryName(sourcePath), torrent.Length,
                       torrent.PieceLength, torrent.PieceHashes, torrent.Files))
            {
                using (var dest = new PersistenceManager(destPath, torrent.Length, torrent.PieceLength,
                           torrent.PieceHashes, torrent.Files))
                {
                    for (var pieceIndex = 0; pieceIndex < torrent.PiecesCount; pieceIndex++)
                        dest.Put(torrent.Files, torrent.PieceLength, pieceIndex, src.Get(pieceIndex));

                    Assert.IsTrue(dest.Verify().All(x => x == PieceStatus.Present));
                }
            }

            destPath.DeleteDirectoryRecursively();
        }
        else
        {
            Assert.Fail();
        }
    }

    /// <summary>
    ///     Tests the persistence manager transfer.
    /// </summary>
    /// <param name="sourcePath">The source path.</param>
    /// <param name="destPath">The dest path.</param>
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataRow(@"./Files/test_folder-d984f67af9917b214cd8b6048ab5624c7df6a07a.torrent", @".\Test")]
    [DataTestMethod]
    public void PersistenceManager_Test2(string sourcePath, string destPath)
    {
        PersistenceManager src;

        if (TorrentInfo.TryLoad(sourcePath, out var torrent))
        {
            src = new PersistenceManager(Path.GetDirectoryName(sourcePath), torrent.Length, torrent.PieceLength,
                torrent.PieceHashes, torrent.Files);

            Assert.IsTrue(src.Verify().All(x => x == PieceStatus.Present));
        }
        else
        {
            Assert.Fail();
        }
    }
}