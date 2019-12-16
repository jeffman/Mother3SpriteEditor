using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MOTHER3SpriteEditor
{
    public partial class frmSwap : Form
    {
        ComboBox entries;
        ROMHandler rom;

        public frmSwap(ComboBox Entries, ROMHandler ROMFile, int bank)
        {
            InitializeComponent();
            this.entries = Entries;
            rom = ROMFile;
            cboBank1.SelectedIndex = bank;
            cboBank2.SelectedIndex = bank;
        }

        private void frmSwap_Load(object sender, EventArgs e)
        {
            // Copy the entries over
            for (int i = 0; i < entries.Items.Count; i++)
            {
                cboEntry1.Items.Add(entries.Items[i]);
                cboEntry2.Items.Add(entries.Items[i]);
            }
            cboEntry1.SelectedIndex = entries.SelectedIndex;
            cboEntry2.SelectedIndex = entries.SelectedIndex;
        }

        private void cmdSwap_Click(object sender, EventArgs e)
        {
            int e1 = cboEntry1.SelectedIndex;
            int e2 = cboEntry2.SelectedIndex;

            if (e1 == e2)
            {
                btnCancel_Click(null, null);
                return;
            }

            // Swap the sprite info pointers
            int pointer1 = rom.ReadWord(
                ROMInfo.sprStartAddress[cboBank1.SelectedIndex] + 4 + (e1 * 4));
            int pointer2 = rom.ReadWord(
                ROMInfo.sprStartAddress[cboBank2.SelectedIndex] + 4 + (e2 * 4));

            rom.WriteWord(
                ROMInfo.sprStartAddress[cboBank1.SelectedIndex] + 4 + (e1 * 4),
                pointer2);
            rom.WriteWord(
                ROMInfo.sprStartAddress[cboBank2.SelectedIndex] + 4 + (e2 * 4),
                pointer1);

            // Swap the graphics pointers
            pointer1 = rom.ReadWord(
                ROMInfo.gfxStartAddress[cboBank1.SelectedIndex] + 4 + (e1 * 4));
            pointer2 = rom.ReadWord(
                ROMInfo.gfxStartAddress[cboBank2.SelectedIndex] + 4 + (e2 * 4));

            rom.WriteWord(
                ROMInfo.gfxStartAddress[cboBank1.SelectedIndex] + 4 + (e1 * 4),
                pointer2);
            rom.WriteWord(
                ROMInfo.gfxStartAddress[cboBank2.SelectedIndex] + 4 + (e2 * 4),
                pointer1);

            // Swap the palette numbers
            byte b1 = (byte)rom.ReadByte(ROMInfo.palInfoAddress + (e1 * 12));
            byte b2 = (byte)rom.ReadByte(ROMInfo.palInfoAddress + (e2 * 12));

            rom.WriteByte(ROMInfo.palInfoAddress + (e1 * 12),
                (byte)((b1 & 0xF0) | (b2 & 0xF)));
            rom.WriteByte(ROMInfo.palInfoAddress + (e2 * 12),
                (byte)((b2 & 0xF0) | (b1 & 0xF)));

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
