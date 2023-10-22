using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClient.Tests.PeerWireProtocol.Messages;

/// <summary>
///     The choke message test.
/// </summary>
[TestClass]
public class ChokeMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void ChokeMessage_TryDecode()
    {
        ChokeMessage message;
        var offset = 0;
        bool isIncomplete;
        var data = "0000000100".ToByteArray();

        if (ChokeMessage.TryDecode(data, ref offset, data.Length, out message, out isIncomplete))
        {
            Assert.AreEqual(5, message.Length);
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