namespace SJZDEyes
{
    partial class AvePreviewFrm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.PreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TitlePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(1022, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(942, 0);
            this.MinBtn.Size = new System.Drawing.Size(26, 36);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(968, 0);
            this.MaxBtn.Size = new System.Drawing.Size(26, 36);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(994, 0);
            this.CloseBtn.Size = new System.Drawing.Size(26, 36);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PreviewPictureBox);
            this.panel1.Location = new System.Drawing.Point(4, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 577);
            this.panel1.TabIndex = 0;
            // 
            // PreviewPictureBox
            // 
            this.PreviewPictureBox.Location = new System.Drawing.Point(8, 3);
            this.PreviewPictureBox.Name = "PreviewPictureBox";
            this.PreviewPictureBox.Size = new System.Drawing.Size(1000, 571);
            this.PreviewPictureBox.TabIndex = 0;
            this.PreviewPictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(4, 627);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 129);
            this.panel2.TabIndex = 1;
            // 
            // AvePreviewFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AvePreviewFrm";
            this.Text = "AvePreviewFrm";
            this.Load += new System.EventHandler(this.AvePreviewFrm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox PreviewPictureBox;
        private System.Windows.Forms.Panel panel2;
    }
}