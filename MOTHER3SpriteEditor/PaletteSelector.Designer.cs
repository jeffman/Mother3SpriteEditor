namespace MOTHER3SpriteEditor
{
    partial class PaletteSelector
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
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // dlgColor
            // 
            this.dlgColor.AnyColor = true;
            this.dlgColor.FullOpen = true;
            this.dlgColor.SolidColorOnly = true;
            // 
            // PaletteSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "PaletteSelector";
            this.Size = new System.Drawing.Size(182, 38);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog dlgColor;
    }
}
