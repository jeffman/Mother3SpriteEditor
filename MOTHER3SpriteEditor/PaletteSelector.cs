using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MOTHER3SpriteEditor
{
    public partial class PaletteSelector : UserControl
    {
        // The Sprite reference
        Sprite sprite;

        // The palette boxes
        Label[] lblPal = new Label[16];
        Label[] lblCurPal = new Label[2];

        List<EditorInterface> updateEditor = new List<EditorInterface>();

        public byte[] PalIndex;

        public void AddEditor(EditorInterface e)
        {
            updateEditor.Add(e);
        }

        public Sprite Sprite
        {
            get { return sprite; }
            set
            {
                sprite = value;
                UpdateView();
            }
        }

        public PaletteSelector()
        {
            InitializeComponent();
            for (int i = 0; i < 16; i++)
            {
                lblPal[i] = new Label();
                lblPal[i].AutoSize = false;
                lblPal[i].Visible = true;
                lblPal[i].Enabled = false;
                lblPal[i].Width = 16;
                lblPal[i].Height = 16;
                lblPal[i].Left = 38 + ((i & 7) * 18);
                lblPal[i].Top = 2 + ((i >> 3) * 18);
                lblPal[i].BackColor = SystemColors.AppWorkspace;
                lblPal[i].MouseClick += new MouseEventHandler(lblPal_MouseClick);
                lblPal[i].DoubleClick += new EventHandler(PaletteSelector_DoubleClick);
                this.Controls.Add(lblPal[i]);
            }
            for (int i = 0; i < 2; i++)
            {
                lblCurPal[i] = new Label();
                lblCurPal[i].AutoSize = false;
                lblCurPal[i].Visible = true;
                lblCurPal[i].Enabled = false;
                lblCurPal[i].Width = 20;
                lblCurPal[i].Height = 20;
                lblCurPal[i].Top = 2 + (i * 14);
                lblCurPal[i].Left = 2 + (i * 14);
                lblCurPal[i].BackColor = SystemColors.AppWorkspace;
                this.Controls.Add(lblCurPal[i]);
            }
            lblCurPal[0].BringToFront();
        }

        void PaletteSelector_DoubleClick(object sender, EventArgs e)
        {
            byte index;
            for (index = 0; index < 16; index++)
                if (((Label)sender) == lblPal[index]) break;

            dlgColor.Color = sprite.GetPalColor(index);
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                sprite.SetPalColor(index, Color.FromArgb(
                    dlgColor.Color.R & 0xF8,
                    dlgColor.Color.G & 0xF8,
                    dlgColor.Color.B & 0xF8));
                UpdateView();
                foreach (EditorInterface ed in updateEditor)
                {
                    ed.IsChanged = true;
                    ed.UpdateView();
                }
            }
        }

        public void UpdateView()
        {
            if (sprite == null)
            {
                // Clear the boxes
                for (int i = 0; i < 16; i++)
                {
                    lblPal[i].BackColor = SystemColors.AppWorkspace;
                    lblPal[i].Enabled = false;

                    if (i < 2)
                    {
                        lblCurPal[i].BackColor = SystemColors.AppWorkspace;
                        lblCurPal[i].Enabled = false;
                    }
                }
            }
            else
            {
                // Fill the boxes
                for (int i = 0; i < 16; i++)
                {
                    lblPal[i].BackColor = sprite.GetPalColor(i);
                    lblPal[i].Enabled = true;
                }

                if (PalIndex == null)
                {
                    PalIndex = new byte[]{1, 0};
                }

                lblCurPal[0].BackColor = lblPal[PalIndex[0]].BackColor;
                lblCurPal[1].BackColor = lblPal[PalIndex[1]].BackColor;
            }
        }

        private void lblPal_MouseClick(object sender, MouseEventArgs e)
        {
            byte index;
            for (index = 0; index < 16; index++)
                if (((Label)sender) == lblPal[index]) break;

            if (e.Button == MouseButtons.Left)
                PalIndex[0] = index;
            else
                PalIndex[1] = index;

            lblCurPal[0].BackColor = lblPal[PalIndex[0]].BackColor;
            lblCurPal[1].BackColor = lblPal[PalIndex[1]].BackColor;
        }
    }
}
