using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest.PeerWireProtocol.Messages;

/// <summary>
///     The port message test.
/// </summary>
[TestClass]
public class PortMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void PortMessage_TryDecode()
    {
        PortMessage message;
        var offset = 0;
        bool isIncomplete;
        var data = "00000003090FAC".ToByteArray();

        if (PortMessage.TryDecode(data, ref offset, data.Length, out message, out isIncomplete))
        {
            Assert.AreEqual(7, message.Length);
            Assert.AreEqual(4012, message.Port);
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