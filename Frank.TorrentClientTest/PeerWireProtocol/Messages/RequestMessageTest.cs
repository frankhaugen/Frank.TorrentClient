using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest.PeerWireProtocol.Messages;

/// <summary>
///     The request message test.
/// </summary>
[TestClass]
public class RequestMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void RequestMessage_TryDecode()
    {
        RequestMessage message;
        var offset = 0;
        bool isIncomplete;
        var data = "0000000D06000000050000000600000007".ToByteArray();

        if (RequestMessage.TryDecode(data, ref offset, data.Length, out message, out isIncomplete))
        {
            Assert.AreEqual(17, message.Length);
            Assert.AreEqual(5, message.PieceIndex);
            Assert.AreEqual(6, message.BlockOffset);
            Assert.AreEqual(7, message.BlockLength);
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