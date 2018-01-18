namespace UserControlsLib
{
    partial class PatientSearchControl
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
            this.PatientSearchBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PatientSearchBtn
            // 
            this.PatientSearchBtn.BackgroundImage = global::UserControlsLib.Properties.Resources.病人检索;
            this.PatientSearchBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PatientSearchBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatientSearchBtn.FlatAppearance.BorderSize = 2;
            this.PatientSearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PatientSearchBtn.Location = new System.Drawing.Point(0, 0);
            this.PatientSearchBtn.Name = "PatientSearchBtn";
            this.PatientSearchBtn.Size = new System.Drawing.Size(135, 118);
            this.PatientSearchBtn.TabIndex = 0;
            this.PatientSearchBtn.UseVisualStyleBackColor = true;
            this.PatientSearchBtn.MouseEnter += new System.EventHandler(this.PatientSearchBtn_MouseEnter);
            this.PatientSearchBtn.MouseLeave += new System.EventHandler(this.PatientSearchBtn_MouseLeave);
            // 
            // PatientSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PatientSearchBtn);
            this.Name = "PatientSearchControl";
            this.Size = new System.Drawing.Size(135, 118);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button PatientSearchBtn;
    }
}
