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
using System.Threading;

namespace UserControlsLib
{
    public partial class MaganiferFrm : NewStyleFrm
    {
        //public static Mutex MaganiferFrmMutex;
        //public static bool flag = false;
       public DrawingTypeEnum m_DrawingTypeEnum;
        public MaganiferFrm()
        {
            InitializeComponent();
            base.MaxBtn.Visible = false;
           
            //string mutexName = "MaganiferFrm";
            //MaganiferFrmMutex = new System.Threading.Mutex(true, mutexName, out flag);
            //第一个参数:true--给调用线程赋予互斥体的初始所属权  
            //第一个参数:互斥体的名称  
            //第三个参数:返回值,如果调用线程已被授予互斥体的初始所属权,则返回true  
            //if (!flag)
            //{
            //    //    //MessageBox.Show("只能运行一个客户端程序！", "请确定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    //    //Environment.Exit(1);//退出程序  
            //    //this.Dispose();
            //}
        }

        private void MaganiferFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MaganiferFrm.flag = true;//互斥量标识置为假，代表下次可以NEW一个此窗体实例
            //MaganiferFrmMutex.Close();
            this.m_DrawingTypeEnum = DrawingTypeEnum.None;//切换成非绘图模式
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MaganiferFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_DrawingTypeEnum = DrawingTypeEnum.None;//切换成非绘图模式
        }
    }
}
