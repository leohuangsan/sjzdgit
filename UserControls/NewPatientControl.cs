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
    public partial class NewPatientControl : UserControl
    {
        public NewPatientControl()
        {
            InitializeComponent();
        }

        private void NewPatientBtn_MouseEnter(object sender, EventArgs e)
        {
            this.NewPatientBtn.ForeColor = Color.Yellow;
        }

        private void NewPatientBtn_MouseLeave(object sender, EventArgs e)
        {
            this.NewPatientBtn.ForeColor = Color.Black;
        }
    }
}
