using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClient.Tests.PeerWireProtocol.Messages;

/// <summary>
///     The interested message test.
/// </summary>
[TestClass]
public class UninterestedMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void UninterestedMessage_TryDecode()
    {
        UninterestedMessage message;
        var offset = 0;
        bool isIncomplete;
        var data = "0000000103".ToByteArray();

        if (UninterestedMessage.TryDecode(data, ref offset, data.Length, out message, out isIncomplete))
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