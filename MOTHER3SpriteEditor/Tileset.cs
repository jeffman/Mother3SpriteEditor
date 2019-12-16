using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MOTHER3SpriteEditor
{
    public class Tileset
    {
        // ROM file references
        ROMHandler rom;
        private int startPointer;
        //public int counter = 0;

        Dictionary<int, byte[,]> tileCache;

        public int Address
        {
            get { return startPointer; }
        }

        public Tileset(ROMHandler romFile, int bank, int mainEntry)
        {
            rom = romFile;
            
            // Compute startPointer
            startPointer = ROMInfo.gfxStartAddress[bank] + rom.ReadWord(
                ROMInfo.gfxStartAddress[bank] + 4 + (4 * mainEntry));

            // Instantiate the cache
            tileCache = new Dictionary<int, byte[,]>();
            //counter++;
        }

        public void AddTileToCache(int tileNum)
        {
            byte[,] tmp = GetTile(tileNum);
        }

        public void AddTileToCache(int tileStart, int count)
        {
            byte[,] tmp;
            for (int i = tileStart; i < (tileStart + count); i++)
                tmp = GetTile(i);
        }

        public byte[,] GetTile(int tileNum)
        {
            // Check if it's already in the cache
            if (tileCache.ContainsKey(tileNum)) return tileCache[tileNum];

            byte[,] pixels = new byte[8, 8];
            //counter++;

            // Get the address of the tile
            int address = startPointer + (tileNum << 5);

            // Parse the tile
            byte tmp = 0;
            rom.Seek(address);
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x += 2)
                {
                    tmp = (byte)rom.ReadByte();
                    pixels[y, x] = (byte)(tmp & 0xF);
                    pixels[y, x + 1] = (byte)((tmp >> 4) & 0xF);
                }
            }

            tileCache.Add(tileNum, pixels);
            return pixels;
        }

        public void SetTile(int tileNum, byte[,] pixels)
        {
            // Explicit copy of pixels to the tile cache
            for (int y = 0; y < 8; y++)
                for (int x = 0; x < 8; x++)
                    tileCache[tileNum][y, x] = pixels[y, x];
        }

        // Get a pixel from the tile cache
        public byte GetPixel(int tileNum, int x, int y)
        {
            if (tileCache.ContainsKey(tileNum))
            {
                return tileCache[tileNum][y, x];
            }
            else
            {
                throw new Exception("The specified tile does not exist in the cache. Did you forget to call GetTile()?");
            }
        }

        // Set a pixel value in the tile cache
        public void SetPixel(int tileNum, int x, int y, byte value)
        {
            if (tileCache.ContainsKey(tileNum))
            {
                tileCache[tileNum][y, x] = value;
            }
            else
            {
                throw new Exception("The specified tile does not exist in the cache. Did you forget to call GetTile()?");
            }
        }

        // Write the tile cache back to the ROM file
        public void ApplyChanges()
        {
            byte[,] pixels;
            byte tmp;

            foreach (KeyValuePair<int, byte[,]> kv in tileCache)
            {
                pixels = kv.Value;
                rom.Seek(startPointer + (kv.Key << 5));

                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x += 2)
                    {
                        tmp = (byte)(pixels[y, x] + (pixels[y, x + 1] << 4));
                        rom.WriteByte(tmp);
                    }
                }
            }
        }
    }
}
