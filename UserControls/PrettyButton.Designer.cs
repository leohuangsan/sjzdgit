namespace UserControlsLib
{
    partial class PrettyButton
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
            this.CoustomBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CoustomBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 97);
            this.panel1.TabIndex = 0;
            // 
            // CoustomBtn
            // 
            this.CoustomBtn.BackColor = System.Drawing.Color.Transparent;
            this.CoustomBtn.BackgroundImage = global::UserControlsLib.Properties.Resources.Green1;
            this.CoustomBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CoustomBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CoustomBtn.FlatAppearance.BorderSize = 0;
            this.CoustomBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CoustomBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CoustomBtn.ForeColor = System.Drawing.Color.White;
            this.CoustomBtn.Location = new System.Drawing.Point(0, 0);
            this.CoustomBtn.Name = "CoustomBtn";
            this.CoustomBtn.Size = new System.Drawing.Size(156, 97);
            this.CoustomBtn.TabIndex = 0;
            this.CoustomBtn.Text = "PrettyButton";
            this.CoustomBtn.UseVisualStyleBackColor = false;
            // 
            // PrettyButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "PrettyButton";
            this.Size = new System.Drawing.Size(156, 97);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button CoustomBtn;
    }
}
