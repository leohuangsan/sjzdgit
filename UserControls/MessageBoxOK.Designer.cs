namespace UserControlsLib
{
    partial class MessageBoxOK
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
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConfirmMyUserControl = new UserControlsLib.MyUserControl();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(337, 31);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(215, 0);
            this.MinBtn.Size = new System.Drawing.Size(40, 29);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(255, 0);
            this.MaxBtn.Size = new System.Drawing.Size(40, 29);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(295, 0);
            this.CloseBtn.Size = new System.Drawing.Size(40, 29);
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(164)))), ((int)(((byte)(241)))));
            this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MessageTextBox.ForeColor = System.Drawing.Color.White;
            this.MessageTextBox.Location = new System.Drawing.Point(69, 55);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(256, 48);
            this.MessageTextBox.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UserControlsLib.Properties.Resources.OKIcon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ConfirmMyUserControl
            // 
            this.ConfirmMyUserControl.BackColor = System.Drawing.Color.Transparent;
            this.ConfirmMyUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConfirmMyUserControl.Location = new System.Drawing.Point(256, 117);
            this.ConfirmMyUserControl.Name = "ConfirmMyUserControl";
            this.ConfirmMyUserControl.Size = new System.Drawing.Size(69, 28);
            this.ConfirmMyUserControl.TabIndex = 2;
            // 
            // MessageBoxOK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 157);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.ConfirmMyUserControl);
            this.Name = "MessageBoxOK";
            this.Text = "提示";
            this.Load += new System.EventHandler(this.MessageFrm_Load);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.Controls.SetChildIndex(this.ConfirmMyUserControl, 0);
            this.Controls.SetChildIndex(this.MessageTextBox, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public MyUserControl ConfirmMyUserControl;
        public System.Windows.Forms.TextBox MessageTextBox;
        public System.Windows.Forms.PictureBox pictureBox1;
    }
}