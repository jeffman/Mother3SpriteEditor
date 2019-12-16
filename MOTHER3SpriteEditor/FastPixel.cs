using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

class FastPixel
{
    private System.Drawing.Imaging.BitmapData bmpData = new System.Drawing.Imaging.BitmapData();
    unsafe private byte* bmpPtr;
    private bool locked = false;
    private bool _isAlpha = false;
    private Bitmap _bitmap;
    private int _width;
    private int _height;

    public int Width { get { return _width; } }
    public int Height { get { return _height; } }
    public bool IsAlphaBitmap { get { return _isAlpha; } }

    public void New(Bitmap bitmap)
    {
        if (bitmap.PixelFormat == (bitmap.PixelFormat | System.Drawing.Imaging.PixelFormat.Indexed))
        {
            throw new Exception("Cannot lock an indexed image.");
            //return;
        }
        _bitmap = bitmap;
        _isAlpha = (_bitmap.PixelFormat == (_bitmap.PixelFormat | System.Drawing.Imaging.PixelFormat.Alpha));
        _width = bitmap.Width;
        _height = bitmap.Height;
    }

    public void Lock()
    {
        if (locked)
        {
            throw new Exception("Bitmap already locked.");
            //return;
        }
        Rectangle rect = new Rectangle(0, 0, Width, Height);
        bmpData = _bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, _bitmap.PixelFormat);
        unsafe { bmpPtr = (byte*)bmpData.Scan0; }

        locked = true;
    }

    public void Unlock()
    {
        if (!locked)
        {
            throw new Exception("Bitmap not locked.");
            //return;
        }

        _bitmap.UnlockBits(bmpData);
        locked = false;
    }

    public void SetPixel(int x, int y, Color colour)
    {
        if (!locked)
        {
            throw new Exception("Bitmap not locked.");
            //return;
        }

        if (y > (Height - 1)) return;
        if (x > (Width - 1)) return;

        unsafe
        {
            if (IsAlphaBitmap)
            {
                int index = ((y * Width + x) * 4);
                bmpPtr[index] = colour.B;
                bmpPtr[index + 1] = colour.G;
                bmpPtr[index + 2] = colour.R;
                bmpPtr[index + 3] = colour.A;
            }
            else
            {
                int index = ((y * Width + x) * 3);
                bmpPtr[index] = colour.B;
                bmpPtr[index + 1] = colour.G;
                bmpPtr[index + 2] = colour.R;
            }
        }
    }

    public Color GetPixel(int x, int y)
    {
        if (!locked)
        {
            throw new Exception("Bitmap not locked.");
        }

        unsafe
        {
            if (IsAlphaBitmap)
            {
                int index = ((y * Width + x) * 4);
                int b = bmpPtr[index];
                int g = bmpPtr[index + 1];
                int r = bmpPtr[index + 2];
                int a = bmpPtr[index + 3];
                return Color.FromArgb(a, r, g, b);
            }
            else
            {
                int index = ((y * Width + x) * 3);
                int b = bmpPtr[index];
                int g = bmpPtr[index + 1];
                int r = bmpPtr[index + 2];
                return Color.FromArgb(r, g, b);
            }
        }
    }
}
