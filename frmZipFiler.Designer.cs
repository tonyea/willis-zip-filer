namespace WillisZipFiler
{
    partial class frmZipFiler
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
            this.lblEGlob = new System.Windows.Forms.Label();
            this.lblMailType = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txteGlobal = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cmbMailType = new System.Windows.Forms.ComboBox();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblEGlob
            // 
            this.lblEGlob.AutoSize = true;
            this.lblEGlob.Location = new System.Drawing.Point(9, 13);
            this.lblEGlob.Name = "lblEGlob";
            this.lblEGlob.Size = new System.Drawing.Size(43, 13);
            this.lblEGlob.TabIndex = 0;
            this.lblEGlob.Text = "eGlobal";
            // 
            // lblMailType
            // 
            this.lblMailType.AutoSize = true;
            this.lblMailType.Location = new System.Drawing.Point(9, 40);
            this.lblMailType.Name = "lblMailType";
            this.lblMailType.Size = new System.Drawing.Size(53, 13);
            this.lblMailType.TabIndex = 0;
            this.lblMailType.Text = "Mail Type";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(9, 66);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(60, 13);
            this.lblDesc.TabIndex = 0;
            this.lblDesc.Text = "Description";
            // 
            // txteGlobal
            // 
            this.txteGlobal.Location = new System.Drawing.Point(67, 10);
            this.txteGlobal.Name = "txteGlobal";
            this.txteGlobal.Size = new System.Drawing.Size(64, 20);
            this.txteGlobal.TabIndex = 1;
            this.txteGlobal.Leave += new System.EventHandler(this.txteGlobal_Leave);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(67, 62);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(85, 20);
            this.txtDesc.TabIndex = 1;
            // 
            // cmbMailType
            // 
            this.cmbMailType.FormattingEnabled = true;
            this.cmbMailType.Location = new System.Drawing.Point(67, 36);
            this.cmbMailType.Name = "cmbMailType";
            this.cmbMailType.Size = new System.Drawing.Size(64, 21);
            this.cmbMailType.TabIndex = 2;
            this.cmbMailType.Leave += new System.EventHandler(this.cmbMailType_Leave);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(164, 10);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 40);
            this.cmdUpdate.TabIndex = 3;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(164, 56);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 3;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // txtLink
            // 
            this.txtLink.BackColor = System.Drawing.SystemColors.Control;
            this.txtLink.Location = new System.Drawing.Point(12, 88);
            this.txtLink.Multiline = true;
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(227, 58);
            this.txtLink.TabIndex = 1;
            // 
            // frmZipFiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 153);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmbMailType);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txteGlobal);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblMailType);
            this.Controls.Add(this.lblEGlob);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmZipFiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Willis ZipFiler";
            this.Load += new System.EventHandler(this.frmZipFiler_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEGlob;
        private System.Windows.Forms.Label lblMailType;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txteGlobal;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.ComboBox cmbMailType;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.TextBox txtLink;
    }
}