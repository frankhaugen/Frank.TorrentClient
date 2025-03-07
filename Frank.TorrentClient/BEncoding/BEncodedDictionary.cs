// <auto-generated />
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DefensiveProgrammingFramework;
using Frank.TorrentClient.Exceptions;
using Frank.TorrentClient.Extensions;

namespace Frank.TorrentClient.BEncoding
{
    /// <summary>
    /// The BEncoded Dictionary.
    /// </summary>
    public class BEncodedDictionary : BEncodedValue, IDictionary<BEncodedString, BEncodedValue>
    {
        #region Private Fields

        /// <summary>
        /// The dictionary.
        /// </summary>
        private SortedDictionary<BEncodedString, BEncodedValue> dictionary;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BEncodedDictionary"/> class.
        /// </summary>
        public BEncodedDictionary()
        {
            this.dictionary = new SortedDictionary<BEncodedString, BEncodedValue>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the number of elements contained in the <see cref="System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <value>The number of elements contained in the <see cref="System.Collections.Generic.ICollection`1" />.</value>
        public int Count
        {
            get
            {
                return this.dictionary.Count;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="System.Collections.Generic.ICollection`1" /> is read-only.
        /// </summary>
        /// <value>true if the <see cref="System.Collections.Generic.ICollection`1" /> is read-only; otherwise, false.</value>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets an <see cref="System.Collections.Generic.ICollection`1" /> containing the keys of the <see cref="System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <value>An <see cref="System.Collections.Generic.ICollection`1" /> containing the keys of the object that implements <see cref="System.Collections.Generic.IDictionary`2" />.</value>
        public ICollection<BEncodedString> Keys
        {
            get
            {
                return this.dictionary.Keys;
            }
        }

        /// <summary>
        /// Gets an <see cref="System.Collections.Generic.ICollection`1" /> containing the values in the <see cref="System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <value>An <see cref="System.Collections.Generic.ICollection`1" /> containing the values in the object that implements <see cref="System.Collections.Generic.IDictionary`2" />.</value>
        public ICollection<BEncodedValue> Values
        {
            get
            {
                return this.dictionary.Values;
            }
        }

        #endregion Public Properties

        #region Public Indexers

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <value>The BEncoded value.</value>
        public BEncodedValue this[BEncodedString key]
        {
            get
            {
                key.CannotBeNull();

                return this.dictionary[key];
            }

            set
            {
                this.dictionary[key] = value;
            }
        }

        #endregion Public Indexers

        #region Public Methods

        /// <summary>
        /// Decodes the torrent.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <value>The BEncoded dictionary.</value>
        public static BEncodedDictionary DecodeTorrent(byte[] bytes)
        {
            bytes.CannotBeNullOrEmpty();

            return DecodeTorrent(new MemoryStream(bytes));
        }

        /// <summary>
        /// Decodes the torrent.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <value>The BEncoded dictionary.</value>
        public static BEncodedDictionary DecodeTorrent(Stream stream)
        {
            stream.CannotBeNull();

            return DecodeTorrent(new RawReader(stream));
        }

        /// <summary>
        /// Special decoding method for torrent files - allows dictionary attributes to be out of order for the
        /// overall torrent file, but imposes strict rules on the info dictionary.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <value>
        /// The BEncoded dictionary.
        /// </value>
        public static BEncodedDictionary DecodeTorrent(RawReader reader)
        {
            reader.CannotBeNull();

            BEncodedString key = null;
            BEncodedValue value = null;
            BEncodedDictionary torrent = new BEncodedDictionary();

            if (reader.ReadByte() != 'd')
            {
                throw new BEncodingException("Invalid data found. Aborting"); // Remove the leading 'd'
            }

            while (reader.PeekByte() != -1 &&
                   reader.PeekByte() != 'e')
            {
                key = (BEncodedString)BEncodedValue.Decode(reader);         // keys have to be BEncoded strings

                if (reader.PeekByte() == 'd')
                {
                    value = new BEncodedDictionary();

                    if (key.Text.ToLower().Equals("info"))
                    {
                        ((BEncodedDictionary)value).DecodeInternal(reader, true);
                    }
                    else
                    {
                        ((BEncodedDictionary)value).DecodeInternal(reader, false);
                    }
                }
                else
                {
                    value = BEncodedValue.Decode(reader);                     // the value is a BEncoded value
                }

                torrent.dictionary.Add(key, value);
            }

            if (reader.ReadByte() != 'e')
            {
                throw new BEncodingException("Invalid data found. Aborting");
            }

            return torrent;
        }

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        public void Add(BEncodedString key, BEncodedValue value)
        {
            key.CannotBeNull();
            value.CannotBeNull();

            this.dictionary.Add(key, value);
        }

        /// <summary>
        /// Adds an item to the <see cref="System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="System.Collections.Generic.ICollection`1" />.</param>
        public void Add(KeyValuePair<BEncodedString, BEncodedValue> item)
        {
            this.dictionary.Add(item.Key, item.Value);
        }

        /// <summary>
        /// Removes all items from the <see cref="System.Collections.Generic.ICollection`1" />.
        /// </summary>
        public void Clear()
        {
            this.dictionary.Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="System.Collections.Generic.ICollection`1" /> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="System.Collections.Generic.ICollection`1" />.</param>
        /// <value>
        /// true if <paramref name="item" /> is found in the <see cref="System.Collections.Generic.ICollection`1" />; otherwise, false.
        /// </value>
        public bool Contains(KeyValuePair<BEncodedString, BEncodedValue> item)
        {
            if (!this.dictionary.ContainsKey(item.Key))
            {
                return false;
            }
            else
            {
                return this.dictionary[item.Key].Equals(item.Value);
            }
        }

        /// <summary>
        /// Determines whether the <see cref="System.Collections.Generic.IDictionary`2" /> contains an element with the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="System.Collections.Generic.IDictionary`2" />.</param>
        /// <value>
        /// true if the <see cref="System.Collections.Generic.IDictionary`2" /> contains an element with the key; otherwise, false.
        /// </value>
        public bool ContainsKey(BEncodedString key)
        {
            key.CannotBeNull();

            return this.dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Copies the automatic.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        public void CopyTo(KeyValuePair<BEncodedString, BEncodedValue>[] array, int arrayIndex)
        {
            array.CannotBeNullOrEmpty();
            arrayIndex.MustBeGreaterThanOrEqualTo(0);

            this.dictionary.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Encodes the dictionary to a byte[]
        /// </summary>
        /// <param name="buffer">The buffer to encode the data to</param>
        /// <param name="offset">The offset to start writing the data to</param>
        /// <value>The number of bytes wncoded.</value>
        public override int Encode(byte[] buffer, int offset)
        {
            buffer.CannotBeNullOrEmpty();
            offset.MustBeGreaterThanOrEqualTo(0);

            int written = 0;

            buffer[offset] = (byte)'d'; // dictionaries start with 'd'
            written++;

            foreach (KeyValuePair<BEncodedString, BEncodedValue> keypair in this)
            {
                written += keypair.Key.Encode(buffer, offset + written);
                written += keypair.Value.Encode(buffer, offset + written);
            }

            buffer[offset + written] = (byte)'e'; // dictionaries end with 'e'

            written++;

            return written;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <value>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </value>
        public override bool Equals(object obj)
        {
            BEncodedValue val;
            BEncodedDictionary other = obj as BEncodedDictionary;

            if (other == null)
            {
                return false;
            }

            if (this.dictionary.Count != other.dictionary.Count)
            {
                return false;
            }

            foreach (KeyValuePair<BEncodedString, BEncodedValue> keypair in this.dictionary)
            {
                if (!other.TryGetValue(keypair.Key, out val))
                {
                    return false;
                }

                if (!keypair.Value.Equals(val))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// value an enumerator that iterates through the collection.
        /// </summary>
        /// <value>
        /// A <see cref="System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </value>
        public IEnumerator<KeyValuePair<BEncodedString, BEncodedValue>> GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        /// <summary>
        /// value an enumerator that iterates through a collection.
        /// </summary>
        /// <value>
        /// An <see cref="System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </value>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        /// <summary>
        /// value a hash code for this instance.
        /// </summary>
        /// <value>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </value>
        public override int GetHashCode()
        {
            int result = 0;

            foreach (KeyValuePair<BEncodedString, BEncodedValue> keypair in this.dictionary)
            {
                result ^= keypair.Key.GetHashCode();
                result ^= keypair.Value.GetHashCode();
            }

            return result;
        }

        /// <summary>
        /// value the size of the dictionary in bytes using UTF8 encoding
        /// </summary>
        /// <value>The length in bytes.</value>
        public override int LengthInBytes()
        {
            int length = 0;

            length += 1;   // Dictionaries start with 'd'

            foreach (KeyValuePair<BEncodedString, BEncodedValue> keypair in this.dictionary)
            {
                length += keypair.Key.LengthInBytes();
                length += keypair.Value.LengthInBytes();
            }

            length += 1;   // Dictionaries end with 'e'

            return length;
        }

        /// <summary>
        /// Removes the element with the specified key from the <see cref="System.Collections.Generic.IDictionary`2" />.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <value>
        /// true if the element is successfully removed; otherwise, false.  This method also value false if <paramref name="key" /> was not found in the original <see cref="System.Collections.Generic.IDictionary`2" />.
        /// </value>
        public bool Remove(BEncodedString key)
        {
            key.CannotBeNull();

            return this.dictionary.Remove(key);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="System.Collections.Generic.ICollection`1" />.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="System.Collections.Generic.ICollection`1" />.</param>
        /// <value>
        /// true if <paramref name="item" /> was successfully removed from the <see cref="System.Collections.Generic.ICollection`1" />; otherwise, false. This method also value false if <paramref name="item" /> is not found in the original <see cref="System.Collections.Generic.ICollection`1" />.
        /// </value>
        public bool Remove(KeyValuePair<BEncodedString, BEncodedValue> item)
        {
            return this.dictionary.Remove(item.Key);
        }

        /// <summary>
        /// value a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <value>
        /// A <see cref="System.String" /> that represents this instance.
        /// </value>
        public override string ToString()
        {
            return Encoding.UTF8.GetString(this.Encode());
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method value, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value" /> parameter. This parameter is passed uninitialized.</param>
        /// <value>
        /// true if the object that implements <see cref="System.Collections.Generic.IDictionary`2" /> contains an element with the specified key; otherwise, false.
        /// </value>
        public bool TryGetValue(BEncodedString key, out BEncodedValue value)
        {
            key.CannotBeNull();

            return this.dictionary.TryGetValue(key, out value);
        }

        #endregion Public Methods

        #region Internal Methods

        /// <summary>
        /// Decodes the internal.
        /// </summary>
        /// <param name="reader">The reader.</param>
        internal override void DecodeInternal(RawReader reader)
        {
            reader.CannotBeNull();

            this.DecodeInternal(reader, reader.StrictDecoding);
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Decodes the internal.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="strictDecoding">if set to <c>true</c> [strict decoding].</param>
        /// <exception cref="BEncodingException">
        /// Invalid data found. Aborting
        /// or
        /// or
        /// Invalid data found. Aborting
        /// </exception>
        private void DecodeInternal(RawReader reader, bool strictDecoding)
        {
            reader.CannotBeNull();

            BEncodedString key = null;
            BEncodedValue value = null;
            BEncodedString oldkey = null;

            if (reader.ReadByte() != 'd')
            {
                throw new BEncodingException("Invalid data found. Aborting"); // Remove the leading 'd'
            }

            while (reader.PeekByte() != -1 &&
                   reader.PeekByte() != 'e')
            {
                key = (BEncodedString)BEncodedValue.Decode(reader);         // keys have to be BEncoded strings

                if (oldkey != null &&
                    oldkey.CompareTo(key) > 0)
                {
                    if (strictDecoding)
                    {
                        throw new BEncodingException($"Illegal BEncodedDictionary. The attributes are not ordered correctly. Old key: {oldkey}, New key: {key}");
                    }
                }

                oldkey = key;
                value = BEncodedValue.Decode(reader);                     // the value is a BEncoded value
                this.dictionary.Add(key, value);
            }

            if (reader.ReadByte() != 'e')
            {
                throw new BEncodingException("Invalid data found. Aborting");
            }
        }

        #endregion Private Methods
    }
}
