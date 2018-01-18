namespace ShowAllLines
{
    partial class ShowAllLinesByOpencvFrm
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(1320, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(1198, 0);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(1238, 0);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(1278, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(10, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1298, 690);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(1325, 0);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(172, 701);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // ShowAllLinesByOpencvFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 742);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ShowAllLinesByOpencvFrm";
            this.Text = "1000条线光强";
            this.Load += new System.EventHandler(this.ShowAllLinesByOpencvFrm_Load);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.imageBox1, 0);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Emgu.CV.UI.ImageBox imageBox1;
    }
}