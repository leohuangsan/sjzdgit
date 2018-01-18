using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJZDEyes
{
   
    public partial class ShowImageDataFrm : Form
    {
        private static ShowImageDataFrm m_instance = null;//Show Image data form's single instance
        private ShowImageDataFrm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Get ShowImageDataFrm's single instance
        /// </summary>
        /// <returns></returns>
        public static ShowImageDataFrm GetInstance()
        {
            if (m_instance == null) m_instance = new ShowImageDataFrm();
            return m_instance;
        }

        private void ShowImageDataFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Dispose();
            m_instance = null;//Clear the single instance
        }
    }
}
