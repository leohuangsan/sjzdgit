using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlsLib

{
    public partial class MyUserControl : UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
        }

        private void UserBtn_MouseEnter(object sender, EventArgs e)
        {
            //this.UserBtn.BackColor = Color.FromArgb(37, 164, 241);
            //this.UserBtn.BackColor = Color.Transparent;
            this.MyUserBtn.ForeColor = Color.Yellow;
           
        }

        private void UserBtn_MouseLeave(object sender, EventArgs e)
        {
            //this.UserBtn.BackColor = Color.Transparent;
            this.MyUserBtn.ForeColor = Color.White;
        }
    }
}
