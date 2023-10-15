﻿using System;
using DefensiveProgrammingFramework;

namespace Frank.TorrentClient.TorrentEventArgs;

/// <summary>
///     The torrent starting event arguments.
/// </summary>
public sealed class TorrentStartedEventArgs : EventArgs
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="TorrentStartedEventArgs" /> class.
    /// </summary>
    /// <param name="torrentInfo">The torrent information.</param>
    public TorrentStartedEventArgs(TorrentInfo torrentInfo)
    {
        torrentInfo.CannotBeNull();

        this.TorrentInfo = torrentInfo;
    }

    /// <summary>
    ///     Prevents a default instance of the <see cref="TorrentStartedEventArgs" /> class from being created.
    /// </summary>
    private TorrentStartedEventArgs()
    {
    }

    /// <summary>
    ///     Gets the torrent information.
    /// </summary>
    /// <value>
    ///     The torrent information.
    /// </value>
    public TorrentInfo TorrentInfo { get; private set; }
}
