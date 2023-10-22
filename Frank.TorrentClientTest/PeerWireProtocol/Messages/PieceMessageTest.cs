using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest.PeerWireProtocol.Messages;

/// <summary>
///     The piece message test.
/// </summary>
[TestClass]
public class PieceMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void TestTryDecodePieceMessge()
    {
        PieceMessage message;
        var offset = 0;
        var data = "0000000B070000000500000006ABCD".ToByteArray();
        bool isIncomplete;

        if (PieceMessage.TryDecode(data, ref offset, data.Length, out message, out isIncomplete))
        {
            Assert.AreEqual(15, message.Length);
            Assert.AreEqual(5, message.PieceIndex);
            Assert.AreEqual(6, message.BlockOffset);
            Assert.AreEqual(171, message.Data[0]);
            Assert.AreEqual(205, message.Data[1]);
            Assert.AreEqual(false, isIncomplete);
            Assert.AreEqual(data.Length, offset);
            CollectionAssert.AreEqual(data, message.Encode());
        }
        else
        {
            Assert.Fail();
        }
    }
}