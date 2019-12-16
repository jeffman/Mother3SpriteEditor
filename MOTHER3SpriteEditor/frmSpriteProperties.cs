using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MOTHER3SpriteEditor
{
    public partial class frmSpriteProperties : Form
    {
        private Sprite sprite;
        private Sprite.SubSprite subSprite;
        List<ViewerInterface> viewers = new List<ViewerInterface>();
        List<EditorInterface> editors = new List<EditorInterface>();
        private bool updating;

        public Sprite Sprite
        {
            get { return sprite; }
            set
            {
                sprite = value;
                spriteViewer.Sprite = sprite;
                UpdateValues();
            }
        }

        public void AddViewer(ViewerInterface viewer)
        {
            viewers.Add(viewer);
        }

        public void AddEditor(EditorInterface editor)
        {
            editors.Add(editor);
        }

        public ViewerInterface SpriteViewer
        {
            get { return spriteViewer; }
        }

        public frmSpriteProperties()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmSpriteProperties_FormClosing);
            AddViewer(spriteViewer);
        }

        void frmSpriteProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            sprite = null;
            e.Cancel = true;
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateValues()
        {
            cboSubSprite.Items.Clear();

            if (sprite == null || sprite.NumSubSprites < 1)
            {
                cboSubSprite.Enabled = false;
                nudXOff.Enabled = false;
                nudYOff.Enabled = false;
                lblWidth.Text = "-";
                lblHeight.Text = "-";
                lblGfxAddress.Text = "-";
                lblTileAddress.Text = "-";
                lblPalAddress.Text = "-";
            }
            else
            {
                for (int i = 0; i < sprite.NumSubSprites; i++)
                {
                    cboSubSprite.Items.Add(i.ToString());
                }
                cboSubSprite.SelectedIndex = 0;
                cboSubSprite_SelectedIndexChanged(null, null);
                cboSubSprite.Enabled = true;
                nudXOff.Enabled = true;
                nudYOff.Enabled = true;
            }
        }

        private void cboSubSprite_SelectedIndexChanged(object sender, EventArgs e)
        {
            updating = true;
            subSprite = sprite.GetSubSprite(cboSubSprite.SelectedIndex);
            nudXOff.Value = subSprite.OffsetX;
            nudYOff.Value = subSprite.OffsetY;
            lblWidth.Text = subSprite.WidthInPixels.ToString() + " pixels";
            lblHeight.Text = subSprite.HeightInPixels.ToString() + " pixels";
            lblGfxAddress.Text = "0x" + subSprite.tileSet.Address.ToString("X");
            lblTileAddress.Text = "0x" + (subSprite.tileSet.Address +
                (subSprite.Tile << 5)).ToString("X") + " (tile 0x" +
                subSprite.Tile.ToString("X") + ")";
            lblPalAddress.Text = "0x" + subSprite.pal.Address.ToString("X");
            UpdateStuff();
            updating = false;
        }

        private void nudXOff_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            subSprite.OffsetX = (int)nudXOff.Value;
            UpdateStuff();
        }

        private void nudYOff_ValueChanged(object sender, EventArgs e)
        {
            if (updating) return;
            subSprite.OffsetY = (int)nudYOff.Value;
            UpdateStuff();
        }

        private void UpdateStuff()
        {
            spriteViewer.Highlight = cboSubSprite.SelectedIndex;
            foreach (ViewerInterface v in viewers)
                v.UpdateView();
            if (updating) return;
            foreach (EditorInterface ei in editors)
                ei.IsChanged = true;
        }
    }
}
