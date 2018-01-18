namespace UserControlsLib
{
    partial class SystemSettingControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SystemSettingBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SystemSettingBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(122, 117);
            this.panel1.TabIndex = 0;
            // 
            // SystemSettingBtn
            // 
            this.SystemSettingBtn.BackgroundImage = global::UserControlsLib.Properties.Resources.参数设置;
            this.SystemSettingBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SystemSettingBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SystemSettingBtn.FlatAppearance.BorderSize = 2;
            this.SystemSettingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SystemSettingBtn.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SystemSettingBtn.ForeColor = System.Drawing.Color.Black;
            this.SystemSettingBtn.Location = new System.Drawing.Point(0, 0);
            this.SystemSettingBtn.Name = "SystemSettingBtn";
            this.SystemSettingBtn.Size = new System.Drawing.Size(122, 117);
            this.SystemSettingBtn.TabIndex = 0;
            this.SystemSettingBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SystemSettingBtn.UseVisualStyleBackColor = true;
            this.SystemSettingBtn.MouseEnter += new System.EventHandler(this.SystemSettingBtn_MouseEnter);
            this.SystemSettingBtn.MouseLeave += new System.EventHandler(this.SystemSettingBtn_MouseLeave);
            // 
            // SystemSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SystemSettingControl";
            this.Size = new System.Drawing.Size(122, 117);
            this.MouseEnter += new System.EventHandler(this.SystemSettingControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.SystemSettingControl_MouseLeave);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button SystemSettingBtn;
    }
}
