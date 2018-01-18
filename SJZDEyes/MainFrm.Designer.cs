namespace SJZDEyes
{
    partial class MainFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chartTimer = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.ImageDataSave = new System.Windows.Forms.Button();
            this.ImageDataViewBtn = new System.Windows.Forms.Button();
            this.ShowAllLinesBtn = new System.Windows.Forms.Button();
            this.SnapBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PatientAcqTabControl = new System.Windows.Forms.TabControl();
            this.SystemSettingLbl = new System.Windows.Forms.Label();
            this.SearchPatientLbl = new System.Windows.Forms.Label();
            this.NewPatientLbl = new System.Windows.Forms.Label();
            this.NewScanLbl = new System.Windows.Forms.Label();
            this.newPatientControl1 = new UserControlsLib.NewPatientControl();
            this.patientSearchControl1 = new UserControlsLib.PatientSearchControl();
            this.systemSettingControl1 = new UserControlsLib.SystemSettingControl();
            this.newScanControl1 = new UserControlsLib.NewScanControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ShowTimeTextBox = new System.Windows.Forms.TextBox();
            this.TitlePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.ShowTimeTextBox);
            this.TitlePanel.Size = new System.Drawing.Size(1415, 38);
            this.TitlePanel.Controls.SetChildIndex(this.CloseBtn, 0);
            this.TitlePanel.Controls.SetChildIndex(this.MaxBtn, 0);
            this.TitlePanel.Controls.SetChildIndex(this.MinBtn, 0);
            this.TitlePanel.Controls.SetChildIndex(this.TitleLbl, 0);
            this.TitlePanel.Controls.SetChildIndex(this.ShowTimeTextBox, 0);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(1335, 0);
            this.MinBtn.Size = new System.Drawing.Size(26, 36);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(1361, 0);
            this.MaxBtn.Size = new System.Drawing.Size(26, 36);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(1387, 0);
            this.CloseBtn.Size = new System.Drawing.Size(26, 36);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(159, 989);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "开始采集";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(281, 989);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "停止采集";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chartTimer
            // 
            this.chartTimer.Interval = 10;
            this.chartTimer.Tick += new System.EventHandler(this.chartTimer_Tick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(388, 992);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 37);
            this.button3.TabIndex = 9;
            this.button3.Text = "相机设置";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ImageDataSave
            // 
            this.ImageDataSave.BackColor = System.Drawing.SystemColors.Control;
            this.ImageDataSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ImageDataSave.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageDataSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImageDataSave.Location = new System.Drawing.Point(522, 992);
            this.ImageDataSave.Name = "ImageDataSave";
            this.ImageDataSave.Size = new System.Drawing.Size(162, 37);
            this.ImageDataSave.TabIndex = 10;
            this.ImageDataSave.Text = "图像数据保存";
            this.ImageDataSave.UseVisualStyleBackColor = false;
            this.ImageDataSave.Click += new System.EventHandler(this.ImageDataSave_Click);
            // 
            // ImageDataViewBtn
            // 
            this.ImageDataViewBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ImageDataViewBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ImageDataViewBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ImageDataViewBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ImageDataViewBtn.Location = new System.Drawing.Point(720, 992);
            this.ImageDataViewBtn.Name = "ImageDataViewBtn";
            this.ImageDataViewBtn.Size = new System.Drawing.Size(157, 37);
            this.ImageDataViewBtn.TabIndex = 11;
            this.ImageDataViewBtn.Text = "查看图像数据";
            this.ImageDataViewBtn.UseVisualStyleBackColor = false;
            this.ImageDataViewBtn.Click += new System.EventHandler(this.ImageDataViewBtn_Click);
            // 
            // ShowAllLinesBtn
            // 
            this.ShowAllLinesBtn.BackColor = System.Drawing.SystemColors.Control;
            this.ShowAllLinesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowAllLinesBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowAllLinesBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ShowAllLinesBtn.Location = new System.Drawing.Point(890, 992);
            this.ShowAllLinesBtn.Name = "ShowAllLinesBtn";
            this.ShowAllLinesBtn.Size = new System.Drawing.Size(103, 37);
            this.ShowAllLinesBtn.TabIndex = 12;
            this.ShowAllLinesBtn.Text = "显示图像";
            this.ShowAllLinesBtn.UseVisualStyleBackColor = false;
            this.ShowAllLinesBtn.Click += new System.EventHandler(this.ShowAllLinesBtn_Click);
            // 
            // SnapBtn
            // 
            this.SnapBtn.BackColor = System.Drawing.SystemColors.Control;
            this.SnapBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SnapBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SnapBtn.Location = new System.Drawing.Point(999, 992);
            this.SnapBtn.Name = "SnapBtn";
            this.SnapBtn.Size = new System.Drawing.Size(75, 41);
            this.SnapBtn.TabIndex = 13;
            this.SnapBtn.Text = "截图";
            this.SnapBtn.UseVisualStyleBackColor = false;
            this.SnapBtn.Click += new System.EventHandler(this.SnapBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.PatientAcqTabControl);
            this.panel1.Location = new System.Drawing.Point(12, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1391, 652);
            this.panel1.TabIndex = 9;
            // 
            // PatientAcqTabControl
            // 
            this.PatientAcqTabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.PatientAcqTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.PatientAcqTabControl.ItemSize = new System.Drawing.Size(200, 60);
            this.PatientAcqTabControl.Location = new System.Drawing.Point(3, 3);
            this.PatientAcqTabControl.Multiline = true;
            this.PatientAcqTabControl.Name = "PatientAcqTabControl";
            this.PatientAcqTabControl.Padding = new System.Drawing.Point(500, 100);
            this.PatientAcqTabControl.SelectedIndex = 0;
            this.PatientAcqTabControl.Size = new System.Drawing.Size(1382, 643);
            this.PatientAcqTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.PatientAcqTabControl.TabIndex = 5;
            this.PatientAcqTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PatientAcqTabControl_DrawItem);
            this.PatientAcqTabControl.SelectedIndexChanged += new System.EventHandler(this.PatientAcqTabControl_SelectedIndexChanged);
            this.PatientAcqTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.PatientAcqTabControl_Selected);
            this.PatientAcqTabControl.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.PatientAcqTabControl_ControlAdded);
            // 
            // SystemSettingLbl
            // 
            this.SystemSettingLbl.AutoSize = true;
            this.SystemSettingLbl.BackColor = System.Drawing.Color.Transparent;
            this.SystemSettingLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SystemSettingLbl.ForeColor = System.Drawing.Color.White;
            this.SystemSettingLbl.Location = new System.Drawing.Point(1233, 95);
            this.SystemSettingLbl.Name = "SystemSettingLbl";
            this.SystemSettingLbl.Size = new System.Drawing.Size(93, 20);
            this.SystemSettingLbl.TabIndex = 7;
            this.SystemSettingLbl.Text = "系统设置";
            this.SystemSettingLbl.Click += new System.EventHandler(this.SystemSettingLbl_Click);
            this.SystemSettingLbl.Paint += new System.Windows.Forms.PaintEventHandler(this.label13_Paint);
            // 
            // SearchPatientLbl
            // 
            this.SearchPatientLbl.AutoSize = true;
            this.SearchPatientLbl.BackColor = System.Drawing.Color.Transparent;
            this.SearchPatientLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchPatientLbl.ForeColor = System.Drawing.Color.White;
            this.SearchPatientLbl.Location = new System.Drawing.Point(936, 95);
            this.SearchPatientLbl.Name = "SearchPatientLbl";
            this.SearchPatientLbl.Size = new System.Drawing.Size(93, 20);
            this.SearchPatientLbl.TabIndex = 7;
            this.SearchPatientLbl.Text = "检索病人";
            this.SearchPatientLbl.Click += new System.EventHandler(this.SearchPatientLbl_Click);
            // 
            // NewPatientLbl
            // 
            this.NewPatientLbl.AutoSize = true;
            this.NewPatientLbl.BackColor = System.Drawing.Color.Transparent;
            this.NewPatientLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewPatientLbl.ForeColor = System.Drawing.Color.White;
            this.NewPatientLbl.Location = new System.Drawing.Point(769, 95);
            this.NewPatientLbl.Name = "NewPatientLbl";
            this.NewPatientLbl.Size = new System.Drawing.Size(93, 20);
            this.NewPatientLbl.TabIndex = 7;
            this.NewPatientLbl.Text = "新增病人";
            this.NewPatientLbl.Click += new System.EventHandler(this.NewPatientLbl_Click);
            // 
            // NewScanLbl
            // 
            this.NewScanLbl.AutoSize = true;
            this.NewScanLbl.BackColor = System.Drawing.Color.Transparent;
            this.NewScanLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NewScanLbl.ForeColor = System.Drawing.Color.White;
            this.NewScanLbl.Location = new System.Drawing.Point(1088, 98);
            this.NewScanLbl.Name = "NewScanLbl";
            this.NewScanLbl.Size = new System.Drawing.Size(93, 20);
            this.NewScanLbl.TabIndex = 7;
            this.NewScanLbl.Text = "新增采集";
            this.NewScanLbl.Click += new System.EventHandler(this.NewScanLbl_Click);
            this.NewScanLbl.Paint += new System.Windows.Forms.PaintEventHandler(this.label13_Paint);
            // 
            // newPatientControl1
            // 
            this.newPatientControl1.Location = new System.Drawing.Point(173, 3);
            this.newPatientControl1.Name = "newPatientControl1";
            this.newPatientControl1.Size = new System.Drawing.Size(88, 80);
            this.newPatientControl1.TabIndex = 18;
            this.newPatientControl1.Load += new System.EventHandler(this.newPatientControl1_Load);
            // 
            // patientSearchControl1
            // 
            this.patientSearchControl1.Location = new System.Drawing.Point(340, 3);
            this.patientSearchControl1.Name = "patientSearchControl1";
            this.patientSearchControl1.Size = new System.Drawing.Size(84, 80);
            this.patientSearchControl1.TabIndex = 17;
            this.patientSearchControl1.Load += new System.EventHandler(this.patientSearchControl1_Load);
            // 
            // systemSettingControl1
            // 
            this.systemSettingControl1.Location = new System.Drawing.Point(637, 3);
            this.systemSettingControl1.Name = "systemSettingControl1";
            this.systemSettingControl1.Size = new System.Drawing.Size(80, 80);
            this.systemSettingControl1.TabIndex = 16;
            this.systemSettingControl1.Load += new System.EventHandler(this.systemSettingControl1_Load);
            // 
            // newScanControl1
            // 
            this.newScanControl1.Location = new System.Drawing.Point(486, 3);
            this.newScanControl1.Name = "newScanControl1";
            this.newScanControl1.Size = new System.Drawing.Size(87, 80);
            this.newScanControl1.TabIndex = 20;
            this.newScanControl1.Load += new System.EventHandler(this.newScanControl1_Load);
            this.newScanControl1.MouseEnter += new System.EventHandler(this.newScanControl1_MouseEnter);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.NewPatientLbl);
            this.panel3.Controls.Add(this.SystemSettingLbl);
            this.panel3.Controls.Add(this.NewScanLbl);
            this.panel3.Controls.Add(this.SearchPatientLbl);
            this.panel3.Location = new System.Drawing.Point(12, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1391, 121);
            this.panel3.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("隶书", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(577, 97);
            this.label2.TabIndex = 23;
            this.label2.Text = "眼科OCT系统";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.systemSettingControl1);
            this.panel4.Controls.Add(this.newScanControl1);
            this.panel4.Controls.Add(this.patientSearchControl1);
            this.panel4.Controls.Add(this.newPatientControl1);
            this.panel4.Location = new System.Drawing.Point(600, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(785, 86);
            this.panel4.TabIndex = 22;
            // 
            // ShowTimeTextBox
            // 
            this.ShowTimeTextBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ShowTimeTextBox.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowTimeTextBox.ForeColor = System.Drawing.Color.White;
            this.ShowTimeTextBox.Location = new System.Drawing.Point(1090, 2);
            this.ShowTimeTextBox.Name = "ShowTimeTextBox";
            this.ShowTimeTextBox.Size = new System.Drawing.Size(243, 31);
            this.ShowTimeTextBox.TabIndex = 4;
            this.ShowTimeTextBox.Text = "2018-01-15 17:50:30";
            this.ShowTimeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 826);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SnapBtn);
            this.Controls.Add(this.ShowAllLinesBtn);
            this.Controls.Add(this.ImageDataViewBtn);
            this.Controls.Add(this.ImageDataSave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Name = "MainFrm";
            this.Text = "欢迎使用！";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFrm_Paint);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.ImageDataSave, 0);
            this.Controls.SetChildIndex(this.ImageDataViewBtn, 0);
            this.Controls.SetChildIndex(this.ShowAllLinesBtn, 0);
            this.Controls.SetChildIndex(this.SnapBtn, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer chartTimer;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button ImageDataSave;
        private System.Windows.Forms.Button ImageDataViewBtn;
        private System.Windows.Forms.Button ShowAllLinesBtn;
        private System.Windows.Forms.Button SnapBtn;
        public System.Windows.Forms.TabControl PatientAcqTabControl;
        public System.Windows.Forms.Label SystemSettingLbl;
        public System.Windows.Forms.Label SearchPatientLbl;
        public System.Windows.Forms.Label NewPatientLbl;
        private System.Windows.Forms.Panel panel1;
        private UserControlsLib.SystemSettingControl systemSettingControl1;
        private UserControlsLib.PatientSearchControl patientSearchControl1;
        private UserControlsLib.NewPatientControl newPatientControl1;
        public System.Windows.Forms.Label NewScanLbl;
        private UserControlsLib.NewScanControl newScanControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox ShowTimeTextBox;
    }
}

