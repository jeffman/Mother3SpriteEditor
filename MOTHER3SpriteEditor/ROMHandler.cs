using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace MOTHER3SpriteEditor
{
    public class ROMHandler
    {
        private byte[] data;
        private int byteAddress = 0;
        private FileStream rom;

        public int Address
        { get { return byteAddress + ROMInfo.blockStart; } }

        public ROMHandler(FileStream ROMFile)
        {
            // Read the data
            data = new byte[ROMInfo.blockLength];
            ROMFile.Seek(ROMInfo.blockStart, SeekOrigin.Begin);
            ROMFile.Read(data, 0, ROMInfo.blockLength);
            rom = ROMFile;
        }

        #region ROM input

        public int ReadWord(int address)
        {
            Seek(address);
            return ReadWord();
        }
        public int ReadWord()
        {
            int retVal = 0;
            for (int i = 0; i < 4; i++)
                retVal += (data[byteAddress++] << (i * 8));
            return retVal;
        }

        public int ReadHWord(int address)
        {
            Seek(address);
            return ReadHWord();
        }
        public int ReadHWord()
        {
            int retVal = 0;
            for (int i = 0; i < 2; i++)
                retVal += (data[byteAddress++] << (i * 8));
            return retVal;
        }

        public byte ReadByte(int address)
        {
            Seek(address);
            return ReadByte();
        }

        public byte ReadByte()
        {
            return data[byteAddress++];
        }

        public void Seek(int address)
        {
            byteAddress = address - ROMInfo.blockStart;
        }

        public Color ReadColor()
        {
            int tmp = ReadHWord();
            return Color.FromArgb(
                (tmp & 0x1F) << 3,
                ((tmp & 0x3E0) >> 5) << 3,
                ((tmp & 0x7C00) >> 10) << 3);
        }

        public Color ReadColor(int address)
        {
            Seek(address);
            return ReadColor();
        }

        #endregion

        #region ROM output

        public void WriteWord(int address, int value)
        {
            Seek(address);
            WriteWord(value);
        }

        public void WriteWord(int value)
        {
            data[byteAddress++] = (byte)value;
            data[byteAddress++] = (byte)(value >> 8);
            data[byteAddress++] = (byte)(value >> 16);
            data[byteAddress++] = (byte)(value >> 24);
        }

        public void WriteHWord(int address, int value)
        {
            Seek(address);
            WriteHWord(value);
        }

        public void WriteHWord(int value)
        {
            data[byteAddress++] = (byte)value;
            data[byteAddress++] = (byte)(value >> 8);
        }

        public void WriteByte(int address, byte value)
        {
            Seek(address);
            WriteByte(value);
        }

        public void WriteByte(byte value)
        {
            data[byteAddress++] = value;
        }

        public void WriteColor(int address, Color value)
        {
            Seek(address);
            WriteColor(value);
        }

        public void WriteColor(Color value)
        {
            byte r = (byte)(value.R >> 3);
            byte g = (byte)(value.G >> 3);
            byte b = (byte)(value.B >> 3);
            int c = (r & 0x1F) + ((g & 0x1F) << 5) + ((b & 0x1F) << 10);
            WriteByte((byte)c);
            WriteByte((byte)(c >> 8));
        }

        public void SaveChanges()
        {
            rom.Seek(ROMInfo.blockStart, SeekOrigin.Begin);
            rom.Write(data, 0, ROMInfo.blockLength);
        }

        #endregion

    }
}
