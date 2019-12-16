using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MOTHER3SpriteEditor
{
    public partial class ViewerInterface : UserControl
    {
        // The current Sprite references
        Sprite sprite;

        // Editor variables
        Bitmap toDraw;
        int scaleFactor = 1;
        public int Highlight = -1;

        public Sprite Sprite
        {
            get { return sprite; }
            set
            {
                sprite = value;
                UpdateView();
            }
        }

        public int ScaleFactor
        {
            get { return scaleFactor; }
            set
            {
                scaleFactor = value;
                UpdateView();
            }
        }

        public ViewerInterface()
        {
            InitializeComponent();
        }

        public void UpdateView()
        {
            if (sprite == null)
            {
                pSprite.Image = null;
                return;
            }
            if ((sprite.NumSubSprites <= 0) || sprite.NumSprites == 0)
            {
                pSprite.Image = null;
                return;
            }

            Size spriteSize = sprite.GetSpriteSize();
            toDraw = new Bitmap(spriteSize.Width * scaleFactor, 
                spriteSize.Height * scaleFactor,
                PixelFormat.Format32bppArgb);

            //this.BackColor = sprite.GetPalColor(0);
            pSprite.Image = toDraw;
            sprite.RenderSprite(toDraw, 0, 0, scaleFactor, Highlight);
            pSprite.Refresh();

            //GC.Collect();
        }

    }
}
