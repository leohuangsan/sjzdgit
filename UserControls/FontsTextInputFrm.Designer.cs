namespace UserControlsLib
{
    partial class FontsTextInputFrm
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
            this.myUserControl1 = new UserControlsLib.MyUserControl();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.InfoLbl = new System.Windows.Forms.Label();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(386, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(264, 0);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(304, 0);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(344, 0);
            // 
            // myUserControl1
            // 
            this.myUserControl1.BackColor = System.Drawing.Color.Transparent;
            this.myUserControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.myUserControl1.Location = new System.Drawing.Point(265, 128);
            this.myUserControl1.Name = "myUserControl1";
            this.myUserControl1.Size = new System.Drawing.Size(90, 34);
            this.myUserControl1.TabIndex = 1;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InputTextBox.Location = new System.Drawing.Point(49, 77);
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(306, 30);
            this.InputTextBox.TabIndex = 2;
            // 
            // InfoLbl
            // 
            this.InfoLbl.AutoSize = true;
            this.InfoLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InfoLbl.ForeColor = System.Drawing.Color.White;
            this.InfoLbl.Location = new System.Drawing.Point(46, 51);
            this.InfoLbl.Name = "InfoLbl";
            this.InfoLbl.Size = new System.Drawing.Size(135, 20);
            this.InfoLbl.TabIndex = 3;
            this.InfoLbl.Text = "请输入文本：";
            // 
            // FontsTextInputFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 174);
            this.Controls.Add(this.InfoLbl);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.myUserControl1);
            this.Name = "FontsTextInputFrm";
            this.Text = "FontsTextInputFrm";
            this.Load += new System.EventHandler(this.FontsTextInputFrm_Load);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.Controls.SetChildIndex(this.myUserControl1, 0);
            this.Controls.SetChildIndex(this.InputTextBox, 0);
            this.Controls.SetChildIndex(this.InfoLbl, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MyUserControl myUserControl1;
        public System.Windows.Forms.TextBox InputTextBox;
        public System.Windows.Forms.Label InfoLbl;
    }
}