using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest.PeerWireProtocol.Messages;

/// <summary>
///     The keep alive message test.
/// </summary>
[TestClass]
public class KeepAliveMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void KeepAliveMessage_TryDecode()
    {
        KeepAliveMessage message;
        var offset = 0;
        var data = "00000000".ToByteArray();

        if (KeepAliveMessage.TryDecode(data, ref offset, out message))
        {
            Assert.AreEqual(4, message.Length);
            CollectionAssert.AreEqual(data, message.Encode());
        }
        else
        {
            Assert.Fail();
        }
    }
}