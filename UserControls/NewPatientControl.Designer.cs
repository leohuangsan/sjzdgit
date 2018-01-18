namespace UserControlsLib
{
    partial class NewPatientControl
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
            this.NewPatientBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewPatientBtn
            // 
            this.NewPatientBtn.BackgroundImage = global::UserControlsLib.Properties.Resources.新增用户;
            this.NewPatientBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NewPatientBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NewPatientBtn.FlatAppearance.BorderSize = 2;
            this.NewPatientBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewPatientBtn.Location = new System.Drawing.Point(0, 0);
            this.NewPatientBtn.Name = "NewPatientBtn";
            this.NewPatientBtn.Size = new System.Drawing.Size(135, 126);
            this.NewPatientBtn.TabIndex = 0;
            this.NewPatientBtn.UseVisualStyleBackColor = true;
            this.NewPatientBtn.MouseEnter += new System.EventHandler(this.NewPatientBtn_MouseEnter);
            this.NewPatientBtn.MouseLeave += new System.EventHandler(this.NewPatientBtn_MouseLeave);
            // 
            // NewPatientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NewPatientBtn);
            this.Name = "NewPatientControl";
            this.Size = new System.Drawing.Size(135, 126);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button NewPatientBtn;
    }
}
