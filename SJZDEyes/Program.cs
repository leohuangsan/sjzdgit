using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using UserRight;

namespace SJZDEyes
{
    public enum WelcomeEnum { WaitingStatus,EnterStatus }
    static class Program
    {       
       private static WelcomeEnum _welcomeEnum = WelcomeEnum.WaitingStatus;
       public static WelcomeEnum m_welcomeEnum
       {
           get { return _welcomeEnum; }
           set { _welcomeEnum = value; }       
       }
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //LoginFrm m_LoginFrm = new LoginFrm();
            Login m_LoginFrm = new Login();
            m_LoginFrm.StartPosition = FormStartPosition.CenterParent;
            m_LoginFrm.ShowDialog();
            if (m_LoginFrm.DialogResult == DialogResult.Cancel)
            {
                return;
            }


            //MessageBox.Show(m_LoginFrm.m_LogDoctorName);
            //WelcomFrm _welcomFrm = new WelcomFrm();
            //_welcomFrm.StartPosition = FormStartPosition.CenterScreen;
            //_welcomFrm.ShowDialog();

            //if (_welcomFrm.DialogResult == DialogResult.OK)
            Application.Run(new MainFrm(m_LoginFrm.m_LogDoctorID,m_LoginFrm.m_LogDoctorName));

            //_welcomFrm.Dispose();
            //WelcomFrm _welcomFrm = null;            
            //bool _waitingFlg = true;
            //while (_waitingFlg)
            //{
            //    switch (m_welcomeEnum)
            //    {
            //        case WelcomeEnum.WaitingStatus:
            //            if( _welcomFrm ==null)
            //            {
            //                 _welcomFrm = new WelcomFrm();
            //                 _welcomFrm.Show();
            //            }
            //            if (_welcomFrm.DialogResult == DialogResult.OK)
            //            {
            //                m_welcomeEnum = WelcomeEnum.EnterStatus;
            //            }
            //            break;
            //        case WelcomeEnum.EnterStatus:
            //            Application.Run(new Form1());
            //            _waitingFlg = false;
            //            break;
            //    }
            //    Thread.Sleep(1000);
            //}
            //if (_welcomFrm.DialogResult == DialogResult.Cancel) // 取消登录
            //    return;
            //else
            //{
            //    if (_welcomFrm.DialogResult == DialogResult.OK)
            //        Application.Run(new Form1());
            //}           
        }
    }
}
