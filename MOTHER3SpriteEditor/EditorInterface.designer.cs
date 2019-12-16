namespace MOTHER3SpriteEditor
{
    partial class EditorInterface
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pSprite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // pSprite
            // 
            this.pSprite.Location = new System.Drawing.Point(3, 3);
            this.pSprite.Name = "pSprite";
            this.pSprite.Size = new System.Drawing.Size(68, 44);
            this.pSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pSprite.TabIndex = 0;
            this.pSprite.TabStop = false;
            // 
            // EditorInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(3, 3);
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.pSprite);
            this.Name = "EditorInterface";
            ((System.ComponentModel.ISupportInitialize)(this.pSprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pSprite;
    }
}
