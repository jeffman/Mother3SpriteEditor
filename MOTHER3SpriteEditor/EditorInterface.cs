using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MOTHER3SpriteEditor
{
    public partial class EditorInterface : UserControl
    {
        private enum MouseClickType
        {
            MouseDown = 1,
            MouseUp = 2,
            MouseMove = 4
        };

        private struct SpriteClipboard
        {
            public byte[,] pixels;
            public int width;
            public int height;
            public int x;
            public int y;
        }

        // The current Sprite references
        Sprite sprite;
        Sprite.SubSprite subSprite;
        int subSpriteIndex;

        // Binding controls
        List<ViewerInterface> viewers = new List<ViewerInterface>();
        PaletteSelector palsel;

        // Editor variables
        int scaleFactor = 1;
        public byte[] PalIndex;
        Bitmap toDraw;
        bool gridLines = false;
        Color gridCol;
        Color selCol;
        public EditorTools curTool;

        bool isChanged = false;

        // Clipboard stuff
        SpriteClipboard sClip;
        bool renderSelection = false;

        // Selection stuff
        int selX = 0;
        int selY = 0;
        int selWidth = 0;
        int selHeight = 0;
        bool isDragging = false;
        int startX = 0;
        int startY = 0;
        bool doDragUpdate = false;
        bool isSelecting = false;

        public bool IsChanged
        {
            get { return isChanged; }
            set { isChanged = value; }
        }

        public bool RenderSelection
        {
            get { return renderSelection; }
            set
            {
                renderSelection = value;
                if (sprite == null) return;
                UpdateView();
            }
        }

        public void AddViewer(ViewerInterface view)
        {
            viewers.Add(view);
        }

        public PaletteSelector PalSelector
        {
            get { return palsel; }
            set { palsel = value; }
        }
                
        public Sprite Sprite
        {
            get { return sprite; }
            set
            {
                sprite = value;
                SubSprite = 0;
            }
        }

        public int SubSprite
        {
            get { return subSpriteIndex; }
            set
            {
                subSpriteIndex = value;
                if (sprite != null)
                    if (sprite.NumSubSprites > 0)
                        subSprite = sprite.GetSubSprite(subSpriteIndex);
                UpdateView();
            }
        }

        public Sprite.SubSprite GetSubSprite
        {
            get { return subSprite; }
        }

        public int ScaleFactor
        {
            get { return scaleFactor; }
            set
            {
                scaleFactor = value;
                if (sprite == null) return;
                UpdateView();
            }
        }

        public bool GridLines
        {
            get { return gridLines; }
            set
            {
                gridLines = value;
                if (sprite == null) return;
                UpdateView();
            }
        }

        public Color GridColor
        {
            get { return gridCol; }
            set
            {
                gridCol = value;
                if ((sprite == null) || (gridLines == false)) return;
                UpdateView();
            }
        }

        public Color SelColor
        {
            get { return selCol; }
            set
            {
                selCol = value;
                if ((sprite == null) || renderSelection) return;
                UpdateView();
            }
        }

        public EditorInterface()
        {
            InitializeComponent();
            pSprite.MouseMove += new MouseEventHandler(pSprite_MouseMove);
            pSprite.MouseDown += new MouseEventHandler(pSprite_MouseDown);
            pSprite.MouseUp += new MouseEventHandler(pSprite_MouseUp);
        }

        public void UpdateView()
        {
            if (sprite == null)
            {
                pSprite.Image = null;
                return;
            }
            if (sprite.NumSubSprites <= 0)
            {
                pSprite.Image = null;
                return;
            }

            toDraw = new Bitmap(subSprite.WidthInPixels * scaleFactor + (gridLines ? 1 : 0),
                subSprite.HeightInPixels * scaleFactor + (gridLines ? 1 : 0),
                PixelFormat.Format32bppArgb);
            pSprite.Image = toDraw;
            subSprite.RenderSubSprite(toDraw, 0, 0, scaleFactor, true);
            RenderClipboard(toDraw, sClip, sprite.Pal);
            if (gridLines) RenderGrid(toDraw, scaleFactor, gridCol, selCol);
            pSprite.Refresh();
            //GC.Collect();

            foreach (ViewerInterface v in viewers)
                v.UpdateView();
        }

        public void pSprite_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                MouseHandler(e.Button, e.X, e.Y, MouseClickType.MouseDown);
        }

        public void pSprite_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                MouseHandler(e.Button, e.X, e.Y, MouseClickType.MouseUp);
        }

        public void pSprite_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                MouseHandler(e.Button, e.X, e.Y, MouseClickType.MouseMove);
        }

        private void MouseHandler(MouseButtons mb, int x, int y, MouseClickType mType)
        {
            if (PalIndex == null) throw new Exception("No palette reference.");

            int curPalIndex = (mb == MouseButtons.Left ? 0 : 1);

            // Bounds check
            if (x >= (pSprite.Width - (gridLines ? 1 : 0)))
                x = pSprite.Width - 1 - (gridLines ? 1 : 0);
            if (x < 0) x = 0;
            if (y >= (pSprite.Height - (gridLines ? 1 : 0)))
                y = pSprite.Height - 1 - (gridLines ? 1 : 0);
            if (y < 0) y = 0;

            x -= (x % scaleFactor);
            y -= (y % scaleFactor);
            x /= scaleFactor;
            y /= scaleFactor;

            doDragUpdate = true;

            switch (curTool)
            {
                case EditorTools.Pencil:
                    subSprite.SetPixel(x, y, PalIndex[curPalIndex]);
                    isChanged = true;
                    break;

                case EditorTools.Eyedropper:
                    if (mType == MouseClickType.MouseDown)
                    {
                        palsel.PalIndex[curPalIndex] = subSprite.GetPixel(x, y);
                        palsel.UpdateView();
                    }
                    break;

                case EditorTools.Erase:
                    subSprite.SetPixel(x, y, 0);
                    isChanged = true;
                    break;

                case EditorTools.Bucket:
                    if (mType == MouseClickType.MouseDown)
                    {
                        FillBucket(x, y, subSprite.WidthInPixels,
                            subSprite.HeightInPixels, PalIndex[curPalIndex]);
                        isChanged = true;
                    }
                    break;

                case EditorTools.Select:
                    if (isDragging)
                    {
                    }
                    else
                    {
                        if (mType == MouseClickType.MouseDown)
                        {
                            isSelecting = true;
                            renderSelection = true;
                            sClip.x = x;
                            sClip.y = y;
                            startX = x;
                            startY = y;
                            sClip.width = 1;
                            sClip.height = 1;
                        }
                        else if (mType == MouseClickType.MouseMove && isSelecting)
                        {
                            int newWidth = x - sClip.x + 1;
                            int newHeight = y - sClip.y + 1;
                            //if (newWidth == sClip.width || newHeight == sClip.height)
                                //doDragUpdate = false;
                            sClip.width = newWidth;
                            sClip.height = newHeight;
                        }
                        else if (mType == MouseClickType.MouseUp)
                        {
                            isSelecting = false;
                            doDragUpdate = false;
                        }
                    }
                    break;
            }
            if (doDragUpdate) UpdateView();
            doDragUpdate = false;
        }

        private void FillBucket(int x, int y, int w, int h, byte value)
        {
            bool[,] pixelFlags = new bool[
                subSprite.HeightInPixels, subSprite.WidthInPixels];
            FillRecur(x, y, w, h, value, subSprite.GetPixel(x, y), pixelFlags);
        }

        private void FillRecur(int x, int y, int w, int h, byte value, 
            byte ivalue, bool[,] pFlags)
        {
            subSprite.SetPixel(x, y, value);
            pFlags[y, x] = true;

            if (x > 0) if (!pFlags[y, x - 1] && (subSprite.GetPixel(x - 1, y) == ivalue))
                FillRecur(x - 1, y, w, h, value, ivalue, pFlags);
            if (x < (w - 1)) if (!pFlags[y, x + 1] && (subSprite.GetPixel(x + 1, y) == ivalue))
                FillRecur(x + 1, y, w, h, value, ivalue, pFlags);
            if (y > 0) if (!pFlags[y - 1, x] && (subSprite.GetPixel(x, y - 1) == ivalue))
                FillRecur(x, y - 1, w, h, value, ivalue, pFlags);
            if (y < (h - 1)) if (!pFlags[y + 1, x] && (subSprite.GetPixel(x, y + 1) == ivalue))
                FillRecur(x, y + 1, w, h, value, ivalue, pFlags);
        }

        private void RenderGrid(Bitmap render, int scale, Color gridColor,
            Color selColor)
        {
            FastPixel fs = new FastPixel();
            fs.New(render);
            fs.Lock();

            // Horizontal gridlines
            for (int y = 0; y < render.Height; y += scale)
                for (int x = 0; x < render.Width; x++)
                    fs.SetPixel(x, y, gridColor);

            // Vertical gridlines
            for (int x = 0; x < render.Width; x += scale)
                for (int y = 0; y < render.Height; y++)
                    fs.SetPixel(x, y, gridColor);

            // Selection box
            if (renderSelection)
            {
                for (int x = sClip.x * scale;
                    x < render.Width && x < (sClip.x + sClip.width) * scale;
                    x++)
                {
                    fs.SetPixel(x, sClip.y * scale, selColor);
                    fs.SetPixel(x, (sClip.y + sClip.height) * scale, selColor);
                }
                for (int y = sClip.y * scale;
                    y < render.Height && y < (sClip.y + sClip.height) * scale;
                    y++)
                {
                    fs.SetPixel((sClip.x + sClip.width) * scale, y, selColor);
                    fs.SetPixel(sClip.x * scale, y, selColor);
                }
            }

            fs.Unlock();
        }

        public void FlipX()
        {
            subSprite.FlipX = !subSprite.FlipX;
            isChanged = true;
            UpdateView();
        }

        public void FlipY()
        {
            subSprite.FlipY = !subSprite.FlipY;
            isChanged = true;
            UpdateView();
        }

        public void ClearImage(byte value)
        {
            for (int y = 0; y < subSprite.HeightInPixels; y++)
                for (int x = 0; x < subSprite.WidthInPixels; x++)
                    subSprite.SetPixel(x, y, value);
        }

        public void ClearImage()
        {
            ClearImage(0);
            isChanged = true;
            UpdateView();
        }

        private void RenderClipboard(Bitmap bmp, SpriteClipboard sc, Palette pal)
        {
            if (!renderSelection || sc.pixels == null) return;

            FastPixel fs = new FastPixel();
            fs.New(bmp);
            fs.Lock();

            for (int yy = 0; yy < sc.height; yy++)
            {
                if ((yy + sc.y) >= subSprite.HeightInPixels) return;
                for (int xx = 0; xx < sc.width; xx++)
                {
                    if ((xx + sc.x) >= subSprite.WidthInPixels) break;
                    for (int j = 0; j < scaleFactor; j++)
                        for (int i = 0; i < scaleFactor; i++)
                            fs.SetPixel(i + (sc.x + xx) * scaleFactor,
                                j + (sc.y + yy) * scaleFactor,
                                pal.GetColor(sc.pixels[yy, xx]));
                }
            }

            fs.Unlock();
        }

        public void CopySelection()
        {
            /*selX = 0;
            selY = 0;
            selWidth = subSprite.WidthInPixels;
            selHeight = subSprite.HeightInPixels;
            */
            selX = sClip.x;
            selY = sClip.y;
            selWidth = sClip.width;
            selHeight = sClip.height;
            sClip.pixels = new byte[selHeight, selWidth];
            for (int y = 0; y < selHeight; y++)
                for (int x = 0; x < selWidth; x++)
                    sClip.pixels[y, x] = subSprite.GetPixel(x + selX, y + selY);
            //sClip.width = selWidth;
            //sClip.height = selHeight;
            //sClip.x = selX;
            //sClip.y = selY;
        }

        public void CutSelection()
        {
            CopySelection();

            // Erase the part that was copied
        }

        public void PasteSelection()
        {
            if (sClip.pixels == null) return;

            sClip.x = 0;
            sClip.y = 0;

            for (int y = 0; y < sClip.height; y++)
            {
                if ((y + sClip.y) >= sClip.height) return;
                for (int x = 0; x < sClip.width; x++)
                {
                    if ((x + sClip.x) >= sClip.width) break;
                    subSprite.SetPixel(x + sClip.x, y + sClip.y,
                        sClip.pixels[y, x]);
                }
            }
            RenderSelection = false;
            isChanged = true;
        }
    }
}
