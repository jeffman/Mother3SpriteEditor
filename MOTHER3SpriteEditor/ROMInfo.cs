using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MOTHER3SpriteEditor
{
    class ROMInfo
    {
        // Graphics addresses
        public static int[] gfxStartAddress = new int[] {
            0x14383E4,
            0x194BC30,
            0x1A012B8,
            0x1A36AA0
        };

        // Palette addresses
        public static int palStartAddress = 0x1A41548;
        public static int palInfoAddress = 0x1433D89;

        // Sprite info addresses
        public static int[] sprStartAddress = new int[] {
            0x1A442A4,
            0x1AE0638,
            0x1AEE4C4,
            0x1AF1ED0
        };

        public static int blockStart = 0x1433D7C;
        public static int blockLength = 0x6BFA14;

        public ROMInfo()
        {
        }

        public static bool IsMother3ROM(FileStream ROMFile)
        {
            // Check if it's a MOTHER 3 ROM

            // Check if it's 32MB
            if (ROMFile.Length != 0x2000000) return false;

            // Check the header
            byte[] headerMatch = 
            {
                0x4D, // 'M'
                0x4F, // 'O'
                0x54, // 'T'
                0x48, // 'H'
                0x45, // 'E'
                0x52, // 'R'
                0x33, // '3'
                0x00,
                0x00,
                0x00,
                0x00,
                0x00,
                0x41, // 'A'
                0x33, // '3'
                0x55, // 'U'
                0x4A  // 'J'
            };

            ROMFile.Seek(0xA0, SeekOrigin.Begin);
            for (int i = 0; i < headerMatch.Length; i++)
                if ((byte)ROMFile.ReadByte() != headerMatch[i]) return false;

            return true;
        }
    }
}
