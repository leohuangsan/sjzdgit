namespace UserControlsLib
{
    partial class MyUserControl
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
            this.MyUserBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MyUserBtn
            // 
            this.MyUserBtn.BackColor = System.Drawing.Color.Transparent;
            this.MyUserBtn.BackgroundImage = global::UserControlsLib.Properties.Resources.Button11;
            this.MyUserBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MyUserBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyUserBtn.FlatAppearance.BorderSize = 0;
            this.MyUserBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.MyUserBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.MyUserBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyUserBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MyUserBtn.ForeColor = System.Drawing.Color.White;
            this.MyUserBtn.Location = new System.Drawing.Point(0, 0);
            this.MyUserBtn.Name = "MyUserBtn";
            this.MyUserBtn.Size = new System.Drawing.Size(207, 72);
            this.MyUserBtn.TabIndex = 0;
            this.MyUserBtn.UseVisualStyleBackColor = false;
            this.MyUserBtn.MouseEnter += new System.EventHandler(this.UserBtn_MouseEnter);
            this.MyUserBtn.MouseLeave += new System.EventHandler(this.UserBtn_MouseLeave);
            // 
            // MyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.MyUserBtn);
            this.Name = "MyUserControl";
            this.Size = new System.Drawing.Size(207, 72);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button MyUserBtn;
    }
}
