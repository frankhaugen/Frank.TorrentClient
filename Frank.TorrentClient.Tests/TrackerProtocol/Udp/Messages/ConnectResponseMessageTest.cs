using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.TrackerProtocol.Udp.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClient.Tests.TrackerProtocol.Udp.Messages;

/// <summary>
///     The connect response message test.
/// </summary>
[TestClass]
public class ConnectResponseMessageTest
{
    /// <summary>
    ///     Tests the try decode message.
    /// </summary>
    [TestMethod]
    public void ConnectResponseMessage_TryDecode()
    {
        ConnectResponseMessage message;
        var data = "00000000000033000000041727101980".ToByteArray();

        if (ConnectResponseMessage.TryDecode(data, 0, out message))
        {
            Assert.AreEqual(16, message.Length);
            Assert.AreEqual(0, (int)message.Action);
            Assert.AreEqual(13056, message.TransactionId);
            CollectionAssert.AreEqual(data, message.Encode());
        }
        else
        {
            Assert.Fail();
        }
    }
}