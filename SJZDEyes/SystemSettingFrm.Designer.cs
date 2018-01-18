namespace SJZDEyes
{
    partial class SystemSettingFrm
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
            this.SettingTabControl = new System.Windows.Forms.TabControl();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(941, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(819, 0);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(859, 0);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(899, 0);
            // 
            // SettingTabControl
            // 
            this.SettingTabControl.Location = new System.Drawing.Point(8, 44);
            this.SettingTabControl.Name = "SettingTabControl";
            this.SettingTabControl.SelectedIndex = 0;
            this.SettingTabControl.Size = new System.Drawing.Size(925, 398);
            this.SettingTabControl.TabIndex = 1;
            // 
            // SystemSettingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 454);
            this.Controls.Add(this.SettingTabControl);
            this.Name = "SystemSettingFrm";
            this.Text = "SystemSettingFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SystemSettingFrm_FormClosing);
            this.Load += new System.EventHandler(this.SystemSettingFrm_Load);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.Controls.SetChildIndex(this.SettingTabControl, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SettingTabControl;
    }
}