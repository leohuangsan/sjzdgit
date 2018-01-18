using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelperLib;
using SkinLib;
using UserControlsLib;
namespace UserRight
{
    public partial class Login : NewStyleFrm
    {
        List<object> m_ButtonList;
        //登录医生ID
        public string m_LogDoctorID = "";
        //登录医生姓名
        public string m_LogDoctorName = "";
        public Login()
        {
            InitializeComponent();
            m_ButtonList = new List<object>(); m_ButtonList.Add(LoginBtn);
            m_ButtonList.Add(CancelLoginBtn);
            SkinFile.MadeNewSkinForControls(m_ButtonList);
            base.MaxBtn.Enabled = false;
            base.MaxBtn.Visible = false;            
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            //检测是否输入了登录ID,用户名及密码
            if (this.LoginIDcombobox.Text.Equals(""))
            {
                //MessageBox.Show("登录ID不能为空，请输入！");
                MessageBoxFrm.ShowMesg("登录ID不能为空，请输入！","提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }else if (this.UsernameCbx.Text.Equals(""))
            {
                //MessageBox.Show("用户名不能为空，请输入！");
                MessageBoxFrm.ShowMesg("用户名不能为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            else if (this.PasswordTxt.Text.Equals(""))
            {
                //MessageBox.Show("密码不能为空，请输入！");
                MessageBoxFrm.ShowMesg("密码不能为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            //根据所选择的用户与密码查询数据库，检验是否有此用户及密码
            if (DBHelperLib.DBHelper.IsExistUserPasswrod(this.LoginIDcombobox.Text,this.UsernameCbx.Text, this.PasswordTxt.Text))
            {
                m_LogDoctorID = this.LoginIDcombobox.Text;
                m_LogDoctorName = this.UsernameCbx.Text;               
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //MessageBox.Show("登录ID或用户名密码不正确！");
                MessageBoxFrm.ShowMesg("登录ID或用户名密码不正确，请输入！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                this.PasswordTxt.Text = "";
                this.DialogResult = DialogResult.None;
            }
        }

        private void CancelLoginBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //加载所有的用户名到UsernameCbx中，以供用户选择
            using (DataTable dt = DBHelperLib.DBHelper.GetAllUserName())
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.LoginIDcombobox.Items.Add(dt.Rows[i][0].ToString());
                    this.UsernameCbx.Items.Add(dt.Rows[i][1].ToString());
                }
            }
            base.TitleLbl.Text = "欢迎登录!";
        }

        private void CancelLoginBtn_MouseEnter(object sender, EventArgs e)
        {
           
            SkinFile.MadeNewSkinForControls(m_ButtonList);
            //MessageBox.Show("dd");
            //this.CancelLoginBtn.BackColor = Color.Black;
            
        }

        private void CancelLoginBtn_MouseMove(object sender, MouseEventArgs e)
        {
            //this.CancelLoginBtn.BackColor = Color.Transparent;
            //SkinFile.MadeNewSkinForControls(m_ButtonList);
            //MessageBox.Show("dd");
        }
    }
}
