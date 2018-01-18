namespace UserRight
{
    partial class Login
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
            this.CancelLoginBtn = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.UsernameCbx = new System.Windows.Forms.ComboBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.UserNameLbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginIDcombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.Size = new System.Drawing.Size(542, 38);
            // 
            // MinBtn
            // 
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.Location = new System.Drawing.Point(420, 0);
            // 
            // MaxBtn
            // 
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.Location = new System.Drawing.Point(460, 0);
            // 
            // CloseBtn
            // 
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.Location = new System.Drawing.Point(500, 0);
            // 
            // CancelLoginBtn
            // 
            this.CancelLoginBtn.BackColor = System.Drawing.Color.Transparent;
            this.CancelLoginBtn.FlatAppearance.BorderSize = 0;
            this.CancelLoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelLoginBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CancelLoginBtn.Location = new System.Drawing.Point(333, 200);
            this.CancelLoginBtn.Name = "CancelLoginBtn";
            this.CancelLoginBtn.Size = new System.Drawing.Size(93, 41);
            this.CancelLoginBtn.TabIndex = 12;
            this.CancelLoginBtn.Text = "取消";
            this.CancelLoginBtn.UseVisualStyleBackColor = false;
            this.CancelLoginBtn.Click += new System.EventHandler(this.CancelLoginBtn_Click);
            this.CancelLoginBtn.MouseEnter += new System.EventHandler(this.CancelLoginBtn_MouseEnter);
            this.CancelLoginBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CancelLoginBtn_MouseMove);
            // 
            // LoginBtn
            // 
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginBtn.Location = new System.Drawing.Point(441, 200);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(84, 41);
            this.LoginBtn.TabIndex = 11;
            this.LoginBtn.Text = "登录";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordTxt.Location = new System.Drawing.Point(296, 141);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.PasswordChar = '*';
            this.PasswordTxt.Size = new System.Drawing.Size(234, 30);
            this.PasswordTxt.TabIndex = 10;
            this.PasswordTxt.Text = "1";
            // 
            // UsernameCbx
            // 
            this.UsernameCbx.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UsernameCbx.FormattingEnabled = true;
            this.UsernameCbx.Location = new System.Drawing.Point(294, 99);
            this.UsernameCbx.Name = "UsernameCbx";
            this.UsernameCbx.Size = new System.Drawing.Size(236, 28);
            this.UsernameCbx.TabIndex = 9;
            this.UsernameCbx.Text = "Admin";
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.BackColor = System.Drawing.Color.Transparent;
            this.PasswordLbl.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordLbl.ForeColor = System.Drawing.Color.White;
            this.PasswordLbl.Location = new System.Drawing.Point(190, 146);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(100, 21);
            this.PasswordLbl.TabIndex = 7;
            this.PasswordLbl.Text = "密  码：";
            // 
            // UserNameLbl
            // 
            this.UserNameLbl.AutoSize = true;
            this.UserNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.UserNameLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserNameLbl.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UserNameLbl.ForeColor = System.Drawing.Color.White;
            this.UserNameLbl.Location = new System.Drawing.Point(190, 101);
            this.UserNameLbl.Name = "UserNameLbl";
            this.UserNameLbl.Size = new System.Drawing.Size(98, 21);
            this.UserNameLbl.TabIndex = 8;
            this.UserNameLbl.Text = "用户名：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UserRight.Properties.Resources.Login;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(3, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 208);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // LoginIDcombobox
            // 
            this.LoginIDcombobox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginIDcombobox.FormattingEnabled = true;
            this.LoginIDcombobox.Location = new System.Drawing.Point(292, 55);
            this.LoginIDcombobox.Name = "LoginIDcombobox";
            this.LoginIDcombobox.Size = new System.Drawing.Size(238, 28);
            this.LoginIDcombobox.TabIndex = 15;
            this.LoginIDcombobox.Text = "20180104140920";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(188, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "登录ID：";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(542, 264);
            this.Controls.Add(this.LoginIDcombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CancelLoginBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordTxt);
            this.Controls.Add(this.UsernameCbx);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.UserNameLbl);
            this.DoubleBuffered = true;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Controls.SetChildIndex(this.TitlePanel, 0);
            this.Controls.SetChildIndex(this.UserNameLbl, 0);
            this.Controls.SetChildIndex(this.PasswordLbl, 0);
            this.Controls.SetChildIndex(this.UsernameCbx, 0);
            this.Controls.SetChildIndex(this.PasswordTxt, 0);
            this.Controls.SetChildIndex(this.LoginBtn, 0);
            this.Controls.SetChildIndex(this.CancelLoginBtn, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.LoginIDcombobox, 0);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button CancelLoginBtn;
        public System.Windows.Forms.Button LoginBtn;
        public System.Windows.Forms.TextBox PasswordTxt;
        public System.Windows.Forms.ComboBox UsernameCbx;
        public System.Windows.Forms.Label PasswordLbl;
        public System.Windows.Forms.Label UserNameLbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ComboBox LoginIDcombobox;
        public System.Windows.Forms.Label label1;
    }
}