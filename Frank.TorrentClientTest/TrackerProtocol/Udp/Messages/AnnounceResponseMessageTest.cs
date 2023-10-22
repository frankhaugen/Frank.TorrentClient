﻿using System.Linq;
using System.Net;
using Frank.TorrentClient.Extensions;
using Frank.TorrentClient.TrackerProtocol.Udp.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Frank.TorrentClientTest.TrackerProtocol.Udp.Messages;

/// <summary>
///     The announce response message test.
/// </summary>
[TestClass]
public class AnnounceResponseMessageTest
{
    /// <summary>
    ///     Tests the try decode message.
    /// </summary>
    [TestMethod]
    public void AnnounceResponseMessage_TryDecode()
    {
        AnnounceResponseMessage message;
        var data = "00000001 00003300 00000002 00000003 00000004 09080706 2002 01020304 3003".Replace(" ", string.Empty)
            .ToByteArray();

        if (AnnounceResponseMessage.TryDecode(data, 0, out message))
        {
            Assert.AreEqual(32, message.Length);
            Assert.AreEqual(1, (int)message.Action);
            Assert.AreEqual(13056, message.TransactionId);
            Assert.AreEqual(2, message.Interval.TotalSeconds);
            Assert.AreEqual(3, message.LeecherCount);
            Assert.AreEqual(4, message.SeederCount);
            Assert.AreEqual(2, message.Peers.Count());
            Assert.AreEqual(new IPEndPoint(IPAddress.Parse("9.8.7.6"), 8194), message.Peers.ElementAt(0));
            Assert.AreEqual(new IPEndPoint(IPAddress.Parse("1.2.3.4"), 12291), message.Peers.ElementAt(1));
            CollectionAssert.AreEqual(data, message.Encode());
        }
        else
        {
            Assert.Fail();
        }
    }
}