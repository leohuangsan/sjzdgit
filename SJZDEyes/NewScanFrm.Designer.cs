namespace SJZDEyes
{
    partial class NewScanFrm
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PatientIDTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.StateTextBox = new System.Windows.Forms.TextBox();
            this.SaveImgBtn = new System.Windows.Forms.Button();
            this.StopAcqBtn = new System.Windows.Forms.Button();
            this.FirstLineShowBtn = new System.Windows.Forms.Button();
            this.ThousandLineBtn = new System.Windows.Forms.Button();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(1118, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(996, 0);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(1036, 0);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(1076, 0);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(11, 93);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(958, 792);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "病人ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(234, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(433, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "状态：";
            // 
            // PatientIDTextBox
            // 
            this.PatientIDTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatientIDTextBox.Location = new System.Drawing.Point(84, 51);
            this.PatientIDTextBox.Name = "PatientIDTextBox";
            this.PatientIDTextBox.Size = new System.Drawing.Size(139, 30);
            this.PatientIDTextBox.TabIndex = 4;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NameTextBox.Location = new System.Drawing.Point(299, 51);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(119, 30);
            this.NameTextBox.TabIndex = 5;
            // 
            // StateTextBox
            // 
            this.StateTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StateTextBox.Location = new System.Drawing.Point(492, 51);
            this.StateTextBox.Name = "StateTextBox";
            this.StateTextBox.Size = new System.Drawing.Size(139, 30);
            this.StateTextBox.TabIndex = 6;
            // 
            // SaveImgBtn
            // 
            this.SaveImgBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveImgBtn.Location = new System.Drawing.Point(989, 417);
            this.SaveImgBtn.Name = "SaveImgBtn";
            this.SaveImgBtn.Size = new System.Drawing.Size(106, 43);
            this.SaveImgBtn.TabIndex = 7;
            this.SaveImgBtn.Text = "存储";
            this.SaveImgBtn.UseVisualStyleBackColor = true;
            this.SaveImgBtn.Click += new System.EventHandler(this.SaveImageDataBtn_Click);
            // 
            // StopAcqBtn
            // 
            this.StopAcqBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StopAcqBtn.Location = new System.Drawing.Point(989, 499);
            this.StopAcqBtn.Name = "StopAcqBtn";
            this.StopAcqBtn.Size = new System.Drawing.Size(106, 43);
            this.StopAcqBtn.TabIndex = 7;
            this.StopAcqBtn.Text = "停止";
            this.StopAcqBtn.UseVisualStyleBackColor = true;
            this.StopAcqBtn.Click += new System.EventHandler(this.StopAcqBtn_Click);
            // 
            // FirstLineShowBtn
            // 
            this.FirstLineShowBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FirstLineShowBtn.Location = new System.Drawing.Point(989, 328);
            this.FirstLineShowBtn.Name = "FirstLineShowBtn";
            this.FirstLineShowBtn.Size = new System.Drawing.Size(106, 42);
            this.FirstLineShowBtn.TabIndex = 8;
            this.FirstLineShowBtn.Text = "第一条线";
            this.FirstLineShowBtn.UseVisualStyleBackColor = true;
            this.FirstLineShowBtn.Click += new System.EventHandler(this.FirstLineShowBtn_Click);
            // 
            // ThousandLineBtn
            // 
            this.ThousandLineBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ThousandLineBtn.Location = new System.Drawing.Point(989, 249);
            this.ThousandLineBtn.Name = "ThousandLineBtn";
            this.ThousandLineBtn.Size = new System.Drawing.Size(106, 42);
            this.ThousandLineBtn.TabIndex = 10;
            this.ThousandLineBtn.Text = "一千条线";
            this.ThousandLineBtn.UseVisualStyleBackColor = true;
            this.ThousandLineBtn.Click += new System.EventHandler(this.ThousandLineBtn_Click);
            // 
            // NewScanFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1118, 890);
            this.Controls.Add(this.ThousandLineBtn);
            this.Controls.Add(this.FirstLineShowBtn);
            this.Controls.Add(this.StopAcqBtn);
            this.Controls.Add(this.SaveImgBtn);
            this.Controls.Add(this.StateTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.PatientIDTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "NewScanFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewScanFrm_FormClosing);
            this.Load += new System.EventHandler(this.NewScanFrm_Load);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.PatientIDTextBox, 0);
            this.Controls.SetChildIndex(this.NameTextBox, 0);
            this.Controls.SetChildIndex(this.StateTextBox, 0);
            this.Controls.SetChildIndex(this.SaveImgBtn, 0);
            this.Controls.SetChildIndex(this.StopAcqBtn, 0);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.Controls.SetChildIndex(this.FirstLineShowBtn, 0);
            this.Controls.SetChildIndex(this.ThousandLineBtn, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PatientIDTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox StateTextBox;
        private System.Windows.Forms.Button SaveImgBtn;
        private System.Windows.Forms.Button StopAcqBtn;
        private System.Windows.Forms.Button FirstLineShowBtn;
        private System.Windows.Forms.Button ThousandLineBtn;
    }
}