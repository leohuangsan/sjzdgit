namespace UserControlsLib
{
    partial class NewScanControl
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
            this.NewScanBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewScanBtn
            // 
            this.NewScanBtn.BackgroundImage = global::UserControlsLib.Properties.Resources.新增采集;
            this.NewScanBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewScanBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewScanBtn.FlatAppearance.BorderSize = 2;
            this.NewScanBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewScanBtn.Location = new System.Drawing.Point(0, 0);
            this.NewScanBtn.Name = "NewScanBtn";
            this.NewScanBtn.Size = new System.Drawing.Size(119, 113);
            this.NewScanBtn.TabIndex = 0;
            this.NewScanBtn.UseVisualStyleBackColor = true;
            this.NewScanBtn.MouseEnter += new System.EventHandler(this.NewScanBtn_MouseEnter);
            this.NewScanBtn.MouseLeave += new System.EventHandler(this.NewScanBtn_MouseLeave);
            // 
            // NewScanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NewScanBtn);
            this.Name = "NewScanControl";
            this.Size = new System.Drawing.Size(119, 113);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button NewScanBtn;
    }
}
