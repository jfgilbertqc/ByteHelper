
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
            if (source == null || length < 1)
            {
                return new byte[] { };
            }

            var dataToReturnLength = startAt + length > source.Length ? source.Length - startAt : length;
            var bytes = new byte[dataToReturnLength];
            Buffer.BlockCopy(source, startAt, bytes, 0, dataToReturnLength);
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

        public static byte[] InsertBytes(this byte[] source, byte[] bytesToInsert, int insertAt)
        {
            if (source == null || source.Length == 0)
            {
                return new byte[] { };
            }

            if (bytesToInsert == null || bytesToInsert.Length == 0 || insertAt > source.Length)
            {
                return source;
            }

            byte[] bytes = new byte[source.Length + bytesToInsert.Length];
            Buffer.BlockCopy(source, 0, bytes, 0, insertAt);
            Buffer.BlockCopy(bytesToInsert, 0, bytes, insertAt, bytesToInsert.Length);
            Buffer.BlockCopy(source, insertAt, bytes, insertAt + bytesToInsert.Length, source.Length - insertAt);

            return bytes;
        }

        public static byte[] RemoveBytes(this byte[] source, int removeAt, int length)
        {

            if (source == null || source.Length == 0)
            {
                return new byte[] { };
            }

            if (removeAt < 0 || removeAt > source.Length || length < 1)
            {
                return source;
            }
            
            byte[] bytes;
            if (removeAt + length > source.Length)
            {
                var subLength = source.Length - removeAt;
                bytes = new byte[subLength];
                Buffer.BlockCopy(source, 0, bytes, 0, subLength);
            }
            else
            {
                bytes = new byte[source.Length - length];
                Buffer.BlockCopy(source, 0, bytes, 0, removeAt);
                Buffer.BlockCopy(source, removeAt + length, bytes, removeAt, source.Length - removeAt - length);

            }
            return bytes;
        }
    }
}
