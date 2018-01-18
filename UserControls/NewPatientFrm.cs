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
using System.IO;
using SkinLib;
using UserControlsLib;

namespace UserControlsLib
{
    public partial class NewPatientFrm : NewStyleFrm
    {
        TabControl m_PatientAcquTabctrl = null;
        string m_AcquisitionPath = "";//采集图片所保存的目录
        public NewPatientFrm(TabControl PatientAcquTabctrl,String AcquisitionPath)
        {
            InitializeComponent();
            this.m_PatientAcquTabctrl = PatientAcquTabctrl;
            this.m_AcquisitionPath = AcquisitionPath;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void NewPatientFrm_Load(object sender, EventArgs e)
        {
            List<object> m_ButtonList = new List<object>();
            m_ButtonList = new List<object>();
            m_ButtonList.Add(this.SaveBtn);
            m_ButtonList.Add(this.CancelBtn);
            SkinFile.MadeNewSkinForControls(m_ButtonList);
            base.TitleLbl.Text = "新增病人";
            base.MaxBtn.Visible = false;
            //自动生成病人ID号
            this.PatientIDTextBox.Text = DBHelper.GenerateUserID().ToString();
            //MessageBox.Show("id");
            List<Object> m_NewSkinObjectList = new List<Object>();//需要换肤的窗体列表
            m_NewSkinObjectList.Add(this);
            SkinLib.SkinFile.MadeNewSkinForControls(m_NewSkinObjectList);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (this.NameTextBox.Text.Equals(""))
            {
                //MessageBox.Show("姓名不能为空！");
                MessageBoxFrm.ShowMesg("姓名不能为空！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            if (this.GenderTextBox.Text.Equals(""))
            {
                //MessageBox.Show("性别不能为空！");
                MessageBoxFrm.ShowMesg("性别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            } else if (this.GenderTextBox.Text.Trim() !="男" && this.GenderTextBox.Text.Trim() != "女")
            {
                //MessageBox.Show("性别输入不正确！");
                MessageBoxFrm.ShowMesg("性别输入不正确！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            if (this.RaceTextBox.Text.Equals(""))
            {
                //MessageBox.Show("民族不能为空！");
                MessageBoxFrm.ShowMesg("民族不能为空！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            if (this.BirthdayTextBox.Text.Equals(""))
            {
                //MessageBox.Show("出生日期不能为空！");
                MessageBoxFrm.ShowMesg("出生日期不能为空！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            if (this.PatientIDTextBox.Text.Equals(""))
            {
                //MessageBox.Show("病人ID不能为空！");
                MessageBoxFrm.ShowMesg("病人ID不能为空！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            if (this.SFZIDTextBox.Text.Equals(""))
            {
                //MessageBox.Show("身份证号不能为空！");
                MessageBoxFrm.ShowMesg("身份证号不能为空！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }

           
            //将新增加的病人添加的当前病人采集列表中
            bool m_IsExitSamePatientIDFlg = false;
            for (int i = 0; i < this.m_PatientAcquTabctrl.TabPages.Count; i++)
            {
                if (this.m_PatientAcquTabctrl.TabPages[i].Text.Contains(PatientIDTextBox.Text))
                {
                    m_IsExitSamePatientIDFlg = true;
                    break;
                }
            }

            if (m_IsExitSamePatientIDFlg)//如果存在相同的记录
            {
                //MessageBox.Show("在采集列表中已存在相同的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBoxFrm.ShowMesg("在采集列表中已存在相同的记录！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.WarnningIco);
            }
            else
            {               
                //DialogResult m_result =  MessageBox.Show("病人信息保存成功！");
                //MessageBoxOK m_MessageFrm = new MessageBoxOK("病人信息保存成功！", "提示");
                //m_MessageFrm.MessageTextBox.Text = "在采集列表中已存在相同的记录在采集列表中已存在相同的记录在采集列表中已存在相同的记录在采集列表中已存在相同的记录";
                //DialogResult m_result =  m_MessageFrm.ShowDialog();
                DialogResult m_result = MessageBoxFrm.ShowMesg("病人信息保存成功！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.OKIco);

                if (m_result == DialogResult.OK || m_result == DialogResult.Cancel)//如果用户点击了提示框中的OK后，开始加载历史采集的图片
                {
                    //在程序目录下新增病人ID文件夹，用来存放历史采集数据
                    // 创建目录病人ID文件夹
                    if (Directory.Exists(this.m_AcquisitionPath + PatientIDTextBox.Text) == false)//如果不存在就创建file文件夹
                    {
                        DirectoryInfo d = Directory.CreateDirectory(this.m_AcquisitionPath + PatientIDTextBox.Text);
                    }
                    //新增病人窗口消失
                    this.DialogResult = DialogResult.OK;
                    //新增TABPAGE
                    this.m_PatientAcquTabctrl.Visible = true;//控件可见
                    TabPage m_newPage = new TabPage();                  
                    m_newPage.Text = "姓名:" + NameTextBox.Text + "\r\n" + "ID:" + PatientIDTextBox.Text + "\r\n";
                    m_newPage.Name =  NameTextBox.Text + ";" + PatientIDTextBox.Text;//为后续传值给采集界面所用
                    LoadAcqImagesFrm m_LoadAcqImagesFrm = new LoadAcqImagesFrm();
                    //添加皮肤背景
                    Image image = SkinLib.SkinResource.BackGround2;
                    m_LoadAcqImagesFrm.BackgroundImage = image;
                    m_LoadAcqImagesFrm.BackgroundImageLayout = ImageLayout.Stretch;

                    m_LoadAcqImagesFrm.Dock = DockStyle.Fill;
                    m_LoadAcqImagesFrm.m_AcqPath = m_AcquisitionPath + PatientIDTextBox.Text;//采集存放路径
                    m_LoadAcqImagesFrm.m_PatientID = PatientIDTextBox.Text;//存放病人ID
                    m_LoadAcqImagesFrm.TopLevel = false;
                    m_LoadAcqImagesFrm.FormBorderStyle = FormBorderStyle.None;
                    m_newPage.Controls.Add(m_LoadAcqImagesFrm);
                    this.m_PatientAcquTabctrl.TabPages.Add(m_newPage);
                    m_LoadAcqImagesFrm.Show();
                    //设定当前新增的TAB为选中的TAB项
                    this.m_PatientAcquTabctrl.SelectedIndex = this.m_PatientAcquTabctrl.TabPages.Count - 1;

                    //插入病人信息到数据库中
                    //InsertPatientInfo(string Name, bool Gender, string Race, DateTime Birthday, UInt64 PatientID, UInt64 SFZID)
                    DBHelper.InsertPatientInfo(NameTextBox.Text, GenderTextBox.Text, RaceTextBox.Text, BirthdayTextBox.Text, UInt64.Parse(PatientIDTextBox.Text), UInt64.Parse(SFZIDTextBox.Text));
                }               
            }
            //this.DialogResult = DialogResult.OK;
            //MessageBox.Show("病人信息保存成功！");
        }
    }
}
