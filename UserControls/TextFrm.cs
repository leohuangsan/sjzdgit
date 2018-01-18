using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsLib
{
    public partial class TextFrm : Form
    {
        public string TextContext = "";
        public TextFrm()
        {
            InitializeComponent();
        }

        private void FontTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//按下了回车
            {
                //MessageBox.Show("Enter is pressed!");
                this.TextContext = this.FontTextBox.Text;
                this.DialogResult = DialogResult.OK;
            } else if (e.KeyChar == 27)//按下了ESC
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
