
using System;

namespace ByteHelper
{
    public static class ByteExtensions
    {

        /// <summary>
        /// Get a subset of bytes from a byte array
        /// </summary>
        /// <param name="source">The source byte array</param>
        /// <param name="startAt">The index of the first byte to get.</param>
        /// <param name="length">The length of bytes to get</param>
        /// <returns>An array of bytes.</returns>
        /// <remarks>If the source byte array is null or empty, or if the index and/or length are greater than the
        /// number of bytes in the array, it will return an empty array.</remarks>
        public static byte[] GetBytes(this byte[] source, int startAt, int length)
        {
            if (source == null || startAt + length > source.Length || length < 1)
            {
                return new byte[] { };
            }

            var bytes = new byte[length];
            Buffer.BlockCopy(source, startAt, bytes, 0, length);
            return bytes;

        }

        public static byte[] AppendBytes(this byte[] source, byte[] bytesToAppend)
        {
            if (source == null && bytesToAppend == null)
            {
                return new byte[] { };
            }

            if (source == null)
            {
                return bytesToAppend;
            }

            if (bytesToAppend == null)
            {
                return source;
            }

            var bytes = new byte[source.Length + bytesToAppend.Length];
            Array.Copy(source, bytes, source.Length);
            Array.Copy(bytesToAppend, 0, bytes, source.Length, bytesToAppend.Length);

            return bytes;

        }
    }
}
