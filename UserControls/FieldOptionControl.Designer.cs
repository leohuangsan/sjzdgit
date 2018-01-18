namespace UserControlsLib
{
    partial class FieldOptionControl
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
            this.NameCheckBox = new System.Windows.Forms.CheckBox();
            this.GenderCheckBox = new System.Windows.Forms.CheckBox();
            this.RaceCheckBox = new System.Windows.Forms.CheckBox();
            this.BirthdayCheckBox = new System.Windows.Forms.CheckBox();
            this.PatientIDCheckBox = new System.Windows.Forms.CheckBox();
            this.SFZIDCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // NameCheckBox
            // 
            this.NameCheckBox.AutoSize = true;
            this.NameCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.NameCheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameCheckBox.ForeColor = System.Drawing.Color.White;
            this.NameCheckBox.Location = new System.Drawing.Point(4, 13);
            this.NameCheckBox.Name = "NameCheckBox";
            this.NameCheckBox.Size = new System.Drawing.Size(70, 24);
            this.NameCheckBox.TabIndex = 0;
            this.NameCheckBox.Text = "姓名";
            this.NameCheckBox.UseVisualStyleBackColor = false;
            // 
            // GenderCheckBox
            // 
            this.GenderCheckBox.AutoSize = true;
            this.GenderCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.GenderCheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GenderCheckBox.ForeColor = System.Drawing.Color.White;
            this.GenderCheckBox.Location = new System.Drawing.Point(80, 13);
            this.GenderCheckBox.Name = "GenderCheckBox";
            this.GenderCheckBox.Size = new System.Drawing.Size(70, 24);
            this.GenderCheckBox.TabIndex = 1;
            this.GenderCheckBox.Text = "性别";
            this.GenderCheckBox.UseVisualStyleBackColor = false;
            // 
            // RaceCheckBox
            // 
            this.RaceCheckBox.AutoSize = true;
            this.RaceCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.RaceCheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RaceCheckBox.ForeColor = System.Drawing.Color.White;
            this.RaceCheckBox.Location = new System.Drawing.Point(156, 13);
            this.RaceCheckBox.Name = "RaceCheckBox";
            this.RaceCheckBox.Size = new System.Drawing.Size(70, 24);
            this.RaceCheckBox.TabIndex = 2;
            this.RaceCheckBox.Text = "民族";
            this.RaceCheckBox.UseVisualStyleBackColor = false;
            // 
            // BirthdayCheckBox
            // 
            this.BirthdayCheckBox.AutoSize = true;
            this.BirthdayCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.BirthdayCheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BirthdayCheckBox.ForeColor = System.Drawing.Color.White;
            this.BirthdayCheckBox.Location = new System.Drawing.Point(250, 13);
            this.BirthdayCheckBox.Name = "BirthdayCheckBox";
            this.BirthdayCheckBox.Size = new System.Drawing.Size(112, 24);
            this.BirthdayCheckBox.TabIndex = 3;
            this.BirthdayCheckBox.Text = "出生日期";
            this.BirthdayCheckBox.UseVisualStyleBackColor = false;
            // 
            // PatientIDCheckBox
            // 
            this.PatientIDCheckBox.AutoSize = true;
            this.PatientIDCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.PatientIDCheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatientIDCheckBox.ForeColor = System.Drawing.Color.White;
            this.PatientIDCheckBox.Location = new System.Drawing.Point(368, 13);
            this.PatientIDCheckBox.Name = "PatientIDCheckBox";
            this.PatientIDCheckBox.Size = new System.Drawing.Size(92, 24);
            this.PatientIDCheckBox.TabIndex = 4;
            this.PatientIDCheckBox.Text = "病人ID";
            this.PatientIDCheckBox.UseVisualStyleBackColor = false;
            // 
            // SFZIDCheckBox
            // 
            this.SFZIDCheckBox.AutoSize = true;
            this.SFZIDCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.SFZIDCheckBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SFZIDCheckBox.ForeColor = System.Drawing.Color.White;
            this.SFZIDCheckBox.Location = new System.Drawing.Point(466, 13);
            this.SFZIDCheckBox.Name = "SFZIDCheckBox";
            this.SFZIDCheckBox.Size = new System.Drawing.Size(91, 24);
            this.SFZIDCheckBox.TabIndex = 5;
            this.SFZIDCheckBox.Text = "身份证";
            this.SFZIDCheckBox.UseVisualStyleBackColor = false;
            // 
            // FieldOptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.SFZIDCheckBox);
            this.Controls.Add(this.PatientIDCheckBox);
            this.Controls.Add(this.BirthdayCheckBox);
            this.Controls.Add(this.RaceCheckBox);
            this.Controls.Add(this.GenderCheckBox);
            this.Controls.Add(this.NameCheckBox);
            this.Name = "FieldOptionControl";
            this.Size = new System.Drawing.Size(579, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox NameCheckBox;
        public System.Windows.Forms.CheckBox GenderCheckBox;
        public System.Windows.Forms.CheckBox RaceCheckBox;
        public System.Windows.Forms.CheckBox BirthdayCheckBox;
        public System.Windows.Forms.CheckBox PatientIDCheckBox;
        public System.Windows.Forms.CheckBox SFZIDCheckBox;
    }
}
