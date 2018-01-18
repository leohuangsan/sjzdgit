using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SJZDEyes
{
    public partial class ShowAveMapFrm : Form
    {
        public static Mutex mutex;
        public ShowAveMapFrm()
        {
            InitializeComponent();
            bool flag = false;
            string mutexName = "Global\\" + "ShowAveMap";
            mutex = new System.Threading.Mutex(true, mutexName, out flag);
            //第一个参数:true--给调用线程赋予互斥体的初始所属权  
            //第一个参数:互斥体的名称  
            //第三个参数:返回值,如果调用线程已被授予互斥体的初始所属权,则返回true  
            if (!flag)
            {
                //MessageBox.Show("只能运行一个客户端程序！", "请确定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(1);//退出程序  
            }
        }
    }
}
