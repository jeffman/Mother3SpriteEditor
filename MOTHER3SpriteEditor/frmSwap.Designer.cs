namespace MOTHER3SpriteEditor
{
    partial class frmSwap
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboEntry1 = new System.Windows.Forms.ComboBox();
            this.cboEntry2 = new System.Windows.Forms.ComboBox();
            this.btnSwap = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBank1 = new System.Windows.Forms.ComboBox();
            this.cboBank2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "This will swap ALL sprite data between the two\r\ncharacter entries of your choice." +
                "\r\n";
            // 
            // cboEntry1
            // 
            this.cboEntry1.DropDownHeight = 210;
            this.cboEntry1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntry1.FormattingEnabled = true;
            this.cboEntry1.IntegralHeight = false;
            this.cboEntry1.Location = new System.Drawing.Point(12, 72);
            this.cboEntry1.Name = "cboEntry1";
            this.cboEntry1.Size = new System.Drawing.Size(216, 21);
            this.cboEntry1.TabIndex = 8;
            // 
            // cboEntry2
            // 
            this.cboEntry2.DropDownHeight = 210;
            this.cboEntry2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntry2.FormattingEnabled = true;
            this.cboEntry2.IntegralHeight = false;
            this.cboEntry2.Location = new System.Drawing.Point(12, 99);
            this.cboEntry2.Name = "cboEntry2";
            this.cboEntry2.Size = new System.Drawing.Size(216, 21);
            this.cboEntry2.TabIndex = 9;
            // 
            // btnSwap
            // 
            this.btnSwap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwap.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSwap.Location = new System.Drawing.Point(116, 132);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(79, 27);
            this.btnSwap.TabIndex = 10;
            this.btnSwap.Text = "OK";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.cmdSwap_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(201, 132);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 27);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Entry";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Bank";
            // 
            // cboBank1
            // 
            this.cboBank1.DropDownHeight = 210;
            this.cboBank1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank1.FormattingEnabled = true;
            this.cboBank1.IntegralHeight = false;
            this.cboBank1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cboBank1.Location = new System.Drawing.Point(234, 72);
            this.cboBank1.Name = "cboBank1";
            this.cboBank1.Size = new System.Drawing.Size(46, 21);
            this.cboBank1.TabIndex = 14;
            // 
            // cboBank2
            // 
            this.cboBank2.DropDownHeight = 210;
            this.cboBank2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBank2.FormattingEnabled = true;
            this.cboBank2.IntegralHeight = false;
            this.cboBank2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.cboBank2.Location = new System.Drawing.Point(234, 99);
            this.cboBank2.Name = "cboBank2";
            this.cboBank2.Size = new System.Drawing.Size(46, 21);
            this.cboBank2.TabIndex = 15;
            // 
            // frmSwap
            // 
            this.AcceptButton = this.btnSwap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 171);
            this.Controls.Add(this.cboBank2);
            this.Controls.Add(this.cboBank1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.cboEntry2);
            this.Controls.Add(this.cboEntry1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSwap";
            this.Text = "Swap Entries";
            this.Load += new System.EventHandler(this.frmSwap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEntry1;
        private System.Windows.Forms.ComboBox cboEntry2;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBank1;
        private System.Windows.Forms.ComboBox cboBank2;
    }
}