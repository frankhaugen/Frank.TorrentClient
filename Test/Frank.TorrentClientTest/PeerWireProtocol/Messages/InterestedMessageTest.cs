using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.PeerWireProtocol.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest.PeerWireProtocol.Messages;

/// <summary>
///     The interested message test.
/// </summary>
[TestClass]
public class InterestedMessageTest
{
    /// <summary>
    ///     Tests the TryDecode() method.
    /// </summary>
    [TestMethod]
    public void InterestedMessage_TryDecode()
    {
        InterestedMessage message;
        var offsetFrom = 0;
        bool isIncomplete;
        var data = "0000000102".ToByteArray();

        if (InterestedMessage.TryDecode(data, ref offsetFrom, data.Length, out message, out isIncomplete))
        {
            Assert.AreEqual(5, message.Length);
            Assert.AreEqual(false, isIncomplete);
            CollectionAssert.AreEqual(data, message.Encode());
        }
        else
        {
            Assert.Fail();
        }
    }
}