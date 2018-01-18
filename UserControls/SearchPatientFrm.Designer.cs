namespace UserControlsLib
{
    partial class SearchPatientFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SearchAllBtn = new System.Windows.Forms.Button();
            this.fieldOptionControl1 = new UserControlsLib.FieldOptionControl();
            this.label2 = new System.Windows.Forms.Label();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.PatientInfosTable = new System.Windows.Forms.DataGridView();
            this.OKBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TitlePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatientInfosTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(1126, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(1004, 0);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(1044, 0);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(1084, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SearchAllBtn);
            this.groupBox1.Controls.Add(this.fieldOptionControl1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SearchBtn);
            this.groupBox1.Controls.Add(this.SearchTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1102, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检索内容:";
            // 
            // SearchAllBtn
            // 
            this.SearchAllBtn.ForeColor = System.Drawing.Color.Black;
            this.SearchAllBtn.Location = new System.Drawing.Point(720, 33);
            this.SearchAllBtn.Name = "SearchAllBtn";
            this.SearchAllBtn.Size = new System.Drawing.Size(114, 33);
            this.SearchAllBtn.TabIndex = 5;
            this.SearchAllBtn.Text = "全部检索";
            this.SearchAllBtn.UseVisualStyleBackColor = true;
            this.SearchAllBtn.Click += new System.EventHandler(this.SearchAllBtn_Click);
            // 
            // fieldOptionControl1
            // 
            this.fieldOptionControl1.BackColor = System.Drawing.Color.Transparent;
            this.fieldOptionControl1.Location = new System.Drawing.Point(3, 108);
            this.fieldOptionControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.fieldOptionControl1.Name = "fieldOptionControl1";
            this.fieldOptionControl1.Size = new System.Drawing.Size(1090, 50);
            this.fieldOptionControl1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "检索字段：";
            // 
            // SearchBtn
            // 
            this.SearchBtn.ForeColor = System.Drawing.Color.Black;
            this.SearchBtn.Location = new System.Drawing.Point(589, 33);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(114, 33);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "条件检索";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(73, 36);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(484, 30);
            this.SearchTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(126, 83);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(127, 24);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(259, 83);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(127, 24);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // PatientInfosTable
            // 
            this.PatientInfosTable.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.PatientInfosTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PatientInfosTable.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(164)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PatientInfosTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PatientInfosTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PatientInfosTable.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PatientInfosTable.Location = new System.Drawing.Point(3, 3);
            this.PatientInfosTable.Name = "PatientInfosTable";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatientInfosTable.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.PatientInfosTable.RowTemplate.Height = 23;
            this.PatientInfosTable.Size = new System.Drawing.Size(1096, 482);
            this.PatientInfosTable.TabIndex = 1;
            this.PatientInfosTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PatientInfosTable_CellDoubleClick);
            this.PatientInfosTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.PatientInfosTable_CellMouseDown);
            // 
            // OKBtn
            // 
            this.OKBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKBtn.Location = new System.Drawing.Point(1036, 724);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 30);
            this.OKBtn.TabIndex = 2;
            this.OKBtn.Text = "确定";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PatientInfosTable);
            this.panel1.Location = new System.Drawing.Point(12, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 491);
            this.panel1.TabIndex = 3;
            // 
            // SearchPatientFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 758);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchPatientFrm";
            this.Text = "病人检索";
            this.Load += new System.EventHandler(this.SearchPatientFrm_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.OKBtn, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatientInfosTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox1;
        //public System.Windows.Forms.CheckBox NameCheckBox;
        //public System.Windows.Forms.CheckBox GenderCheckBox;
        //public System.Windows.Forms.CheckBox RaceCheckBox;
        //public System.Windows.Forms.CheckBox BirthdayCheckBox;
        //public System.Windows.Forms.CheckBox PatientIDCheckBox;
        //public System.Windows.Forms.CheckBox SFZIDCheckBox;
        public System.Collections.Generic.List<System.Windows.Forms.CheckBox> fieldsCheckboxList;
        public FieldOptionControl fieldOptionControl1;
        private System.Windows.Forms.DataGridView PatientInfosTable;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button SearchAllBtn;
        private System.Windows.Forms.Panel panel1;
    }
}