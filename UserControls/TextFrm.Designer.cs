namespace UserControlsLib
{
    partial class TextFrm
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
            this.FontTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FontTextBox
            // 
            this.FontTextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FontTextBox.Location = new System.Drawing.Point(4, 5);
            this.FontTextBox.Name = "FontTextBox";
            this.FontTextBox.Size = new System.Drawing.Size(153, 30);
            this.FontTextBox.TabIndex = 0;
            this.FontTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FontTextBox_KeyPress);
            // 
            // TextFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(161, 40);
            this.Controls.Add(this.FontTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TextFrm";
            this.Text = "TextFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox FontTextBox;
    }
}