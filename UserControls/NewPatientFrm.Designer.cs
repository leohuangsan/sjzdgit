namespace UserControlsLib
{
    partial class NewPatientFrm
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
            this.GenderLbl = new System.Windows.Forms.Label();
            this.SFZIDLbl = new System.Windows.Forms.Label();
            this.RaceLbl = new System.Windows.Forms.Label();
            this.BirthdayLbl = new System.Windows.Forms.Label();
            this.PatientIDLbl = new System.Windows.Forms.Label();
            this.NameLbl = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.GenderTextBox = new System.Windows.Forms.TextBox();
            this.RaceTextBox = new System.Windows.Forms.TextBox();
            this.BirthdayTextBox = new System.Windows.Forms.TextBox();
            this.PatientIDTextBox = new System.Windows.Forms.TextBox();
            this.SFZIDTextBox = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(416, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(294, 0);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(334, 0);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(374, 0);
            // 
            // GenderLbl
            // 
            this.GenderLbl.AutoSize = true;
            this.GenderLbl.BackColor = System.Drawing.Color.Transparent;
            this.GenderLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GenderLbl.ForeColor = System.Drawing.Color.White;
            this.GenderLbl.Location = new System.Drawing.Point(48, 114);
            this.GenderLbl.Name = "GenderLbl";
            this.GenderLbl.Size = new System.Drawing.Size(72, 20);
            this.GenderLbl.TabIndex = 0;
            this.GenderLbl.Text = "性别：";
            // 
            // SFZIDLbl
            // 
            this.SFZIDLbl.AutoSize = true;
            this.SFZIDLbl.BackColor = System.Drawing.Color.Transparent;
            this.SFZIDLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SFZIDLbl.ForeColor = System.Drawing.Color.White;
            this.SFZIDLbl.Location = new System.Drawing.Point(48, 284);
            this.SFZIDLbl.Name = "SFZIDLbl";
            this.SFZIDLbl.Size = new System.Drawing.Size(93, 20);
            this.SFZIDLbl.TabIndex = 1;
            this.SFZIDLbl.Text = "身份证：";
            // 
            // RaceLbl
            // 
            this.RaceLbl.AutoSize = true;
            this.RaceLbl.BackColor = System.Drawing.Color.Transparent;
            this.RaceLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RaceLbl.ForeColor = System.Drawing.Color.White;
            this.RaceLbl.Location = new System.Drawing.Point(48, 158);
            this.RaceLbl.Name = "RaceLbl";
            this.RaceLbl.Size = new System.Drawing.Size(72, 20);
            this.RaceLbl.TabIndex = 2;
            this.RaceLbl.Text = "民族：";
            // 
            // BirthdayLbl
            // 
            this.BirthdayLbl.AutoSize = true;
            this.BirthdayLbl.BackColor = System.Drawing.Color.Transparent;
            this.BirthdayLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BirthdayLbl.ForeColor = System.Drawing.Color.White;
            this.BirthdayLbl.Location = new System.Drawing.Point(48, 200);
            this.BirthdayLbl.Name = "BirthdayLbl";
            this.BirthdayLbl.Size = new System.Drawing.Size(114, 20);
            this.BirthdayLbl.TabIndex = 3;
            this.BirthdayLbl.Text = "出生日期：";
            // 
            // PatientIDLbl
            // 
            this.PatientIDLbl.AutoSize = true;
            this.PatientIDLbl.BackColor = System.Drawing.Color.Transparent;
            this.PatientIDLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatientIDLbl.ForeColor = System.Drawing.Color.White;
            this.PatientIDLbl.Location = new System.Drawing.Point(48, 241);
            this.PatientIDLbl.Name = "PatientIDLbl";
            this.PatientIDLbl.Size = new System.Drawing.Size(115, 20);
            this.PatientIDLbl.TabIndex = 4;
            this.PatientIDLbl.Text = "病人ID号：";
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.BackColor = System.Drawing.Color.Transparent;
            this.NameLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameLbl.ForeColor = System.Drawing.Color.White;
            this.NameLbl.Location = new System.Drawing.Point(48, 67);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(72, 20);
            this.NameLbl.TabIndex = 5;
            this.NameLbl.Text = "姓名：";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameTextBox.Location = new System.Drawing.Point(151, 66);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(212, 30);
            this.NameTextBox.TabIndex = 6;
            this.NameTextBox.Text = "马超";
            // 
            // GenderTextBox
            // 
            this.GenderTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GenderTextBox.Location = new System.Drawing.Point(151, 113);
            this.GenderTextBox.Name = "GenderTextBox";
            this.GenderTextBox.Size = new System.Drawing.Size(212, 30);
            this.GenderTextBox.TabIndex = 6;
            this.GenderTextBox.Text = "男";
            // 
            // RaceTextBox
            // 
            this.RaceTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RaceTextBox.Location = new System.Drawing.Point(151, 157);
            this.RaceTextBox.Name = "RaceTextBox";
            this.RaceTextBox.Size = new System.Drawing.Size(212, 30);
            this.RaceTextBox.TabIndex = 6;
            this.RaceTextBox.Text = "汉";
            // 
            // BirthdayTextBox
            // 
            this.BirthdayTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BirthdayTextBox.Location = new System.Drawing.Point(151, 201);
            this.BirthdayTextBox.Name = "BirthdayTextBox";
            this.BirthdayTextBox.Size = new System.Drawing.Size(212, 30);
            this.BirthdayTextBox.TabIndex = 6;
            this.BirthdayTextBox.Text = "1987-10-12";
            // 
            // PatientIDTextBox
            // 
            this.PatientIDTextBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PatientIDTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatientIDTextBox.Location = new System.Drawing.Point(151, 240);
            this.PatientIDTextBox.Name = "PatientIDTextBox";
            this.PatientIDTextBox.ReadOnly = true;
            this.PatientIDTextBox.Size = new System.Drawing.Size(212, 30);
            this.PatientIDTextBox.TabIndex = 6;
            // 
            // SFZIDTextBox
            // 
            this.SFZIDTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SFZIDTextBox.Location = new System.Drawing.Point(151, 283);
            this.SFZIDTextBox.Name = "SFZIDTextBox";
            this.SFZIDTextBox.Size = new System.Drawing.Size(212, 30);
            this.SFZIDTextBox.TabIndex = 6;
            this.SFZIDTextBox.Text = "440223165987452365";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveBtn.Location = new System.Drawing.Point(275, 326);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(87, 40);
            this.SaveBtn.TabIndex = 7;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CancelBtn.Location = new System.Drawing.Point(145, 326);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(87, 40);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // NewPatientFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 395);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.SFZIDTextBox);
            this.Controls.Add(this.PatientIDTextBox);
            this.Controls.Add(this.BirthdayTextBox);
            this.Controls.Add(this.RaceTextBox);
            this.Controls.Add(this.GenderTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.PatientIDLbl);
            this.Controls.Add(this.BirthdayLbl);
            this.Controls.Add(this.RaceLbl);
            this.Controls.Add(this.SFZIDLbl);
            this.Controls.Add(this.GenderLbl);
            this.Name = "NewPatientFrm";
            this.Text = "新增病人信息";
            this.Load += new System.EventHandler(this.NewPatientFrm_Load);
            this.Controls.SetChildIndex(this.GenderLbl, 0);
            this.Controls.SetChildIndex(this.SFZIDLbl, 0);
            this.Controls.SetChildIndex(this.RaceLbl, 0);
            this.Controls.SetChildIndex(this.BirthdayLbl, 0);
            this.Controls.SetChildIndex(this.PatientIDLbl, 0);
            this.Controls.SetChildIndex(this.NameLbl, 0);
            this.Controls.SetChildIndex(this.NameTextBox, 0);
            this.Controls.SetChildIndex(this.GenderTextBox, 0);
            this.Controls.SetChildIndex(this.RaceTextBox, 0);
            this.Controls.SetChildIndex(this.BirthdayTextBox, 0);
            this.Controls.SetChildIndex(this.PatientIDTextBox, 0);
            this.Controls.SetChildIndex(this.SFZIDTextBox, 0);
            this.Controls.SetChildIndex(this.SaveBtn, 0);
            this.Controls.SetChildIndex(this.CancelBtn, 0);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GenderLbl;
        private System.Windows.Forms.Label SFZIDLbl;
        private System.Windows.Forms.Label RaceLbl;
        private System.Windows.Forms.Label BirthdayLbl;
        private System.Windows.Forms.Label PatientIDLbl;
        private System.Windows.Forms.Label NameLbl;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox GenderTextBox;
        private System.Windows.Forms.TextBox RaceTextBox;
        private System.Windows.Forms.TextBox BirthdayTextBox;
        private System.Windows.Forms.TextBox PatientIDTextBox;
        private System.Windows.Forms.TextBox SFZIDTextBox;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button CancelBtn;
    }
}