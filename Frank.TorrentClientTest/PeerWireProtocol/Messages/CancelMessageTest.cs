using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest.PeerWireProtocol.Messages;

/// <summary>
///     The cancel message test.
/// </summary>
[TestClass]
public class CancelMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void CancelMessage_TryDecode()
    {
        CancelMessage message;
        var offset = 0;
        bool isIncomplete;
        var data = "0000000D08000000050000000600000007".ToByteArray();

        if (CancelMessage.TryDecode(data, ref offset, data.Length, out message, out isIncomplete))
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