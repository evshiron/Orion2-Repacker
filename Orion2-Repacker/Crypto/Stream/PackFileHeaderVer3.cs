﻿using System.IO;

namespace Orion.Crypto.Stream
{
    public class PackFileHeaderVer3 : PackFileHeaderVerBase
    {
        private readonly uint uVer;
        private uint dwCompressionFlag;
        private int dwFileIndex;
        private uint dwEncodedFileSize;
        private int dwReserved;
        private ulong dwCompressedFileSize;
        private ulong dwFileSize;
        private ulong dwOffset;

        private PackFileHeaderVer3(uint uVer)
        {
            this.uVer = uVer;
        }

        public static PackFileHeaderVer3 ParseHeader(BinaryReader pReader, uint uVer)
        {
            return new PackFileHeaderVer3(uVer)
            {
                dwCompressionFlag = pReader.ReadUInt32(),
                dwFileIndex = pReader.ReadInt32(),
                dwEncodedFileSize = pReader.ReadUInt32(),
                dwReserved = pReader.ReadInt32(),
                dwCompressedFileSize = pReader.ReadUInt64(),
                dwFileSize = pReader.ReadUInt64(),
                dwOffset = pReader.ReadUInt64()
            };
        }

        public uint GetVer()
        {
            return uVer;
        }

        public int GetFileIndex()
        {
            return dwFileIndex;
        }

        public uint GetCompressionFlag()
        {
            return dwCompressionFlag;
        }

        public ulong GetOffset()
        {
            return dwOffset;
        }

        public ulong GetEncodedFileSize()
        {
            return dwEncodedFileSize;
        }

        public ulong GetCompressedFileSize()
        {
            return dwCompressedFileSize;
        }

        public ulong GetFileSize()
        {
            return dwFileSize;
        }
    }
}
