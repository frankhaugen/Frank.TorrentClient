using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClient.Tests.PeerWireProtocol.Messages;

/// <summary>
///     The have message test.
/// </summary>
[TestClass]
public class HaveMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void HaveMessage_TryDecode()
    {
        HaveMessage message;
        var offset = 0;
        bool isIncomplete;
        var data = "0000000504000000AA".ToByteArray();

        if (HaveMessage.TryDecode(data, ref offset, data.Length, out message, out isIncomplete))
        {
            Assert.AreEqual(9, message.Length);
            Assert.AreEqual(170, message.PieceIndex);
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