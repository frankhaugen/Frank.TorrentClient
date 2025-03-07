﻿using System;
using System.Runtime.Serialization;

namespace Frank.TorrentClient.Exceptions;

[Serializable]
public class TorrentPersistanceException : Exception
{
    public TorrentPersistanceException()
    {
    }

    public TorrentPersistanceException(string message)
        : base(message)
    {
    }

    public TorrentPersistanceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected TorrentPersistanceException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
