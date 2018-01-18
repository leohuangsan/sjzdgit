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
using SkinLib;
using USB3WinApiSpace;
using LogLib;
using GlobalToolSpace;
namespace SJZDEyes
{
    public partial class SystemSettingFrm : NewStyleFrm
    {
        public static Mutex mutex;
        public MainFrm m_MainFrm = null;
        public CameraControlFrm m_CameraControlFrm;
        public SystemSettingFrm()
        {
            InitializeComponent();
            bool flag = false;
            string mutexName = "SystemSettingFrm";
            mutex = new System.Threading.Mutex(true, mutexName, out flag);
            //第一个参数:true--给调用线程赋予互斥体的初始所属权  
            //第一个参数:互斥体的名称  
            //第三个参数:返回值,如果调用线程已被授予互斥体的初始所属权,则返回true  
            if (!flag)
            {
                //MessageBox.Show("只能运行一个客户端程序！", "请确定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //Environment.Exit(1);//退出程序  
            }
        }

        private void SystemSettingFrm_Load(object sender, EventArgs e)
        {
            //新增TABPAGE
            base.TitleLbl.Text = "相机设置";
            base.MaxBtn.Visible = false;
            TabPage m_newPage = new TabPage();
            //m_newPage.BackColor = Color.FromArgb(37, 164, 241);
            m_newPage.BackColor = Color.Red;
            m_newPage.Text = "相机设置";
            m_newPage.Name = "相机设置";
            m_CameraControlFrm = new CameraControlFrm();
            m_CameraControlFrm.Dock = DockStyle.Fill;
            m_CameraControlFrm.TopLevel = false;
            m_CameraControlFrm.FormBorderStyle = FormBorderStyle.None;
            m_newPage.Controls.Add(m_CameraControlFrm);
            this.SettingTabControl.TabPages.Add(m_newPage);
            m_CameraControlFrm.Show();
            //设定当前新增的TAB为选中的TAB项
            this.SettingTabControl.SelectedIndex = this.SettingTabControl.TabPages.Count - 1;
        }

        private void SystemSettingFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭相机资源           
            this.m_CameraControlFrm.CloseUSB3Camera(m_CameraControlFrm.m_hCamera);
        }
    }
}
