namespace MOTHER3SpriteEditor
{
    partial class frmSpriteProperties
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpriteProperties));
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudXOff = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudYOff = new System.Windows.Forms.NumericUpDown();
            this.cboSubSprite = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblGfxAddress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTileAddress = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPalAddress = new System.Windows.Forms.Label();
            this.spriteViewer = new MOTHER3SpriteEditor.ViewerInterface();
            ((System.ComponentModel.ISupportInitialize)(this.nudXOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYOff)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(220, 187);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "X-offset (relative):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Y-offset (relative):";
            // 
            // nudXOff
            // 
            this.nudXOff.Location = new System.Drawing.Point(107, 34);
            this.nudXOff.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.nudXOff.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.nudXOff.Name = "nudXOff";
            this.nudXOff.Size = new System.Drawing.Size(47, 20);
            this.nudXOff.TabIndex = 28;
            this.nudXOff.ValueChanged += new System.EventHandler(this.nudXOff_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "pixels";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "pixels";
            // 
            // nudYOff
            // 
            this.nudYOff.Location = new System.Drawing.Point(107, 60);
            this.nudYOff.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.nudYOff.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            -2147483648});
            this.nudYOff.Name = "nudYOff";
            this.nudYOff.Size = new System.Drawing.Size(47, 20);
            this.nudYOff.TabIndex = 30;
            this.nudYOff.ValueChanged += new System.EventHandler(this.nudYOff_ValueChanged);
            // 
            // cboSubSprite
            // 
            this.cboSubSprite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubSprite.FormattingEnabled = true;
            this.cboSubSprite.Location = new System.Drawing.Point(107, 7);
            this.cboSubSprite.Name = "cboSubSprite";
            this.cboSubSprite.Size = new System.Drawing.Size(64, 21);
            this.cboSubSprite.TabIndex = 32;
            this.cboSubSprite.SelectedIndexChanged += new System.EventHandler(this.cboSubSprite_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Sub-sprite:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(104, 88);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(0, 13);
            this.lblWidth.TabIndex = 34;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(104, 114);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(0, 13);
            this.lblHeight.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Width:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Height:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Tileset address:";
            // 
            // lblGfxAddress
            // 
            this.lblGfxAddress.AutoSize = true;
            this.lblGfxAddress.Location = new System.Drawing.Point(104, 140);
            this.lblGfxAddress.Name = "lblGfxAddress";
            this.lblGfxAddress.Size = new System.Drawing.Size(0, 13);
            this.lblGfxAddress.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Tile address:";
            // 
            // lblTileAddress
            // 
            this.lblTileAddress.AutoSize = true;
            this.lblTileAddress.Location = new System.Drawing.Point(104, 166);
            this.lblTileAddress.Name = "lblTileAddress";
            this.lblTileAddress.Size = new System.Drawing.Size(0, 13);
            this.lblTileAddress.TabIndex = 46;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Palette address:";
            // 
            // lblPalAddress
            // 
            this.lblPalAddress.AutoSize = true;
            this.lblPalAddress.Location = new System.Drawing.Point(104, 192);
            this.lblPalAddress.Name = "lblPalAddress";
            this.lblPalAddress.Size = new System.Drawing.Size(0, 13);
            this.lblPalAddress.TabIndex = 48;
            // 
            // spriteViewer
            // 
            this.spriteViewer.AutoScroll = true;
            this.spriteViewer.AutoScrollMargin = new System.Drawing.Size(3, 3);
            this.spriteViewer.BackColor = System.Drawing.SystemColors.Control;
            this.spriteViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spriteViewer.Location = new System.Drawing.Point(199, 7);
            this.spriteViewer.Name = "spriteViewer";
            this.spriteViewer.ScaleFactor = 1;
            this.spriteViewer.Size = new System.Drawing.Size(96, 96);
            this.spriteViewer.Sprite = null;
            this.spriteViewer.TabIndex = 0;
            // 
            // frmSpriteProperties
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 214);
            this.Controls.Add(this.lblPalAddress);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTileAddress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblGfxAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboSubSprite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudYOff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudXOff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.spriteViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSpriteProperties";
            this.Text = "Sprite Properties";
            ((System.ComponentModel.ISupportInitialize)(this.nudXOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYOff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ViewerInterface spriteViewer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudXOff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudYOff;
        private System.Windows.Forms.ComboBox cboSubSprite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblGfxAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTileAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPalAddress;
    }
}