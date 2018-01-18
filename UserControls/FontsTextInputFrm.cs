using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkinLib;

namespace UserControlsLib
{
    public partial class FontsTextInputFrm : NewStyleFrm
    {
        public FontsTextInputFrm()
        {
            InitializeComponent();
            base.TitleLbl.Text = "文本输入！";
            this.myUserControl1.MyUserBtn.Text = "确定";
        }

        private void FontsTextInputFrm_Load(object sender, EventArgs e)
        {
            myUserControl1.MyUserBtn.Click += myUserControl1_Click;
        }

        private void myUserControl1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
