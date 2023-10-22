using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.TrackerProtocol.Udp.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClient.Tests.TrackerProtocol.Udp.Messages;

/// <summary>
///     The connect message test.
/// </summary>
[TestClass]
public class ConnectMessageTest
{
    /// <summary>
    ///     Tests the try decode message.
    /// </summary>
    [TestMethod]
    public void ConnectMessage_TryDecode()
    {
        ConnectMessage message;
        var data = "00000417271019800000000000003300".ToByteArray();

        if (ConnectMessage.TryDecode(data, 0, out message))
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