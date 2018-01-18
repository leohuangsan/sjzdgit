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
    public partial class SystemSettingControl : UserControl
    {
        public SystemSettingControl()
        {
            InitializeComponent();
        }

        private void SystemSettingControl_MouseEnter(object sender, EventArgs e)
        {
            //this.SystemSettingBtn.ForeColor = Color.Yellow;
        }

        private void SystemSettingControl_MouseLeave(object sender, EventArgs e)
        {
            //this.SystemSettingBtn.ForeColor = Color.Black;
        }

        private void SystemSettingBtn_MouseEnter(object sender, EventArgs e)
        {
            this.SystemSettingBtn.ForeColor = Color.Yellow;
        }

        private void SystemSettingBtn_MouseLeave(object sender, EventArgs e)
        {
            this.SystemSettingBtn.ForeColor = Color.Black;
        }
    }
}
