namespace SkinLib
{
    partial class NewStyleFrm
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
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.MinBtn = new System.Windows.Forms.Button();
            this.MaxBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(164)))), ((int)(((byte)(241)))));
            this.TitlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TitlePanel.Controls.Add(this.TitleLbl);
            this.TitlePanel.Controls.Add(this.MinBtn);
            this.TitlePanel.Controls.Add(this.MaxBtn);
            this.TitlePanel.Controls.Add(this.CloseBtn);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(668, 25);
            this.TitlePanel.TabIndex = 0;
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            this.TitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseMove);
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLbl.ForeColor = System.Drawing.Color.White;
            this.TitleLbl.Location = new System.Drawing.Point(3, 8);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(0, 20);
            this.TitleLbl.TabIndex = 3;
            // 
            // MinBtn
            // 
            this.MinBtn.BackgroundImage = global::SkinLib.SkinResource.Min;
            this.MinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinBtn.FlatAppearance.BorderSize = 0;
            this.MinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinBtn.Location = new System.Drawing.Point(588, 0);
            this.MinBtn.Name = "MinBtn";
            this.MinBtn.Size = new System.Drawing.Size(26, 23);
            this.MinBtn.TabIndex = 2;
            this.MinBtn.UseVisualStyleBackColor = true;
            this.MinBtn.Click += new System.EventHandler(this.MinBtn_Click);
            // 
            // MaxBtn
            // 
            this.MaxBtn.BackgroundImage = global::SkinLib.SkinResource.Max;
            this.MaxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MaxBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaxBtn.FlatAppearance.BorderSize = 0;
            this.MaxBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaxBtn.Location = new System.Drawing.Point(614, 0);
            this.MaxBtn.Name = "MaxBtn";
            this.MaxBtn.Size = new System.Drawing.Size(26, 23);
            this.MaxBtn.TabIndex = 1;
            this.MaxBtn.UseVisualStyleBackColor = true;
            this.MaxBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MaxBtn_MouseClick);
            // 
            // CloseBtn
            // 
            this.CloseBtn.BackgroundImage = global::SkinLib.SkinResource.Close;
            this.CloseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBtn.FlatAppearance.BorderSize = 0;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBtn.Location = new System.Drawing.Point(640, 0);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(26, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // NewStyleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(164)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(668, 455);
            this.Controls.Add(this.TitlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewStyleFrm";
            this.Text = "NewStyleFrm";
            this.Load += new System.EventHandler(this.NewStyleFrm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewStyleFrm_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NewStyleFrm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewStyleFrm_MouseMove);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel TitlePanel;
        public System.Windows.Forms.Label TitleLbl;
        public System.Windows.Forms.Button MinBtn;
        public System.Windows.Forms.Button MaxBtn;
        public System.Windows.Forms.Button CloseBtn;
    }
}