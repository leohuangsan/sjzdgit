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
    public partial class PatientSearchControl : UserControl
    {
        public PatientSearchControl()
        {
            InitializeComponent();
        }

        private void PatientSearchBtn_MouseEnter(object sender, EventArgs e)
        {
            this.PatientSearchBtn.ForeColor = Color.Yellow;
        }

        private void PatientSearchBtn_MouseLeave(object sender, EventArgs e)
        {
            this.PatientSearchBtn.ForeColor = Color.Black;
        }
    }
}
