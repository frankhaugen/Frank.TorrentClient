﻿using System;
using DefensiveProgrammingFramework;
using Frank.TorrentClient.PeerWireProtocol.Messages;

namespace Frank.TorrentClient.PeerWireProtocol.TorrentEventArgs;

/// <summary>
///     The peer message received event arguments.
/// </summary>
public sealed class PeerMessgeReceivedEventArgs : EventArgs
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PeerMessgeReceivedEventArgs" /> class.
    /// </summary>
    /// <param name="message">The message.</param>
    public PeerMessgeReceivedEventArgs(PeerMessage message)
    {
        message.CannotBeNull();

        this.Message = message;
    }

    /// <summary>
    ///     Gets the message.
    /// </summary>
    /// <value>
    ///     The message.
    /// </value>
    public PeerMessage Message { get; private set; }
}
