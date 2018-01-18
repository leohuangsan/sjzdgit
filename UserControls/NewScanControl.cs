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
    public partial class NewScanControl : UserControl
    {
        public NewScanControl()
        {
            InitializeComponent();
        }

        private void NewScanBtn_MouseEnter(object sender, EventArgs e)
        {
            this.NewScanBtn.ForeColor = Color.Yellow;
        }

        private void NewScanBtn_MouseLeave(object sender, EventArgs e)
        {
            this.NewScanBtn.ForeColor = Color.Black;
        }
    }
}
