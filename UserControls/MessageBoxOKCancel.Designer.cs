namespace UserControlsLib
{
    partial class MessageBoxOKCancel
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmMyUserControl = new UserControlsLib.MyUserControl();
            this.CancelMyUserControl = new UserControlsLib.MyUserControl();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(334, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(212, 0);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(252, 0);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(292, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UserControlsLib.Properties.Resources.OKIcon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(4, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(164)))), ((int)(((byte)(241)))));
            this.MessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MessageTextBox.ForeColor = System.Drawing.Color.White;
            this.MessageTextBox.Location = new System.Drawing.Point(61, 57);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(256, 48);
            this.MessageTextBox.TabIndex = 6;
            // 
            // ConfirmMyUserControl
            // 
            this.ConfirmMyUserControl.BackColor = System.Drawing.Color.Transparent;
            this.ConfirmMyUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConfirmMyUserControl.Location = new System.Drawing.Point(248, 119);
            this.ConfirmMyUserControl.Name = "ConfirmMyUserControl";
            this.ConfirmMyUserControl.Size = new System.Drawing.Size(69, 28);
            this.ConfirmMyUserControl.TabIndex = 5;
            // 
            // CancelMyUserControl
            // 
            this.CancelMyUserControl.BackColor = System.Drawing.Color.Transparent;
            this.CancelMyUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelMyUserControl.Location = new System.Drawing.Point(153, 119);
            this.CancelMyUserControl.Name = "CancelMyUserControl";
            this.CancelMyUserControl.Size = new System.Drawing.Size(69, 28);
            this.CancelMyUserControl.TabIndex = 8;
            // 
            // MessageBoxOKCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 161);
            this.Controls.Add(this.CancelMyUserControl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.ConfirmMyUserControl);
            this.Name = "MessageBoxOKCancel";
            this.Text = "MessageBoxOKCancel";
            this.Load += new System.EventHandler(this.MessageBoxOKCancel_Load);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.Controls.SetChildIndex(this.ConfirmMyUserControl, 0);
            this.Controls.SetChildIndex(this.MessageTextBox, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.CancelMyUserControl, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox MessageTextBox;
        public MyUserControl ConfirmMyUserControl;
        public MyUserControl CancelMyUserControl;
    }
}