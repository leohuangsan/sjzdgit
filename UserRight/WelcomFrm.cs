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
namespace UserRight
{
    public partial class WelcomFrm : NewStyleFrm
    {
        public WelcomFrm()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void WelcomFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void WelcomFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
