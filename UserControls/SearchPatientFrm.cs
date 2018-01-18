using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DBHelperLib;
using System.IO;
using SkinLib;
namespace UserControlsLib
{
    public partial class SearchPatientFrm : NewStyleFrm
    {
        List<string> m_checkedNameList = new List<string>();
        int rowindex = -1;//右击所选中的行
        Form m_Mainfrm = null;
        TabControl m_PatientAcquTabctrl = null;
        string m_AcquisitionPath = "";
        public SearchPatientFrm(TabControl PatientAcquTabctrl,string AcquisitionPath)
        {
            InitializeComponent();
            //PatientInfosTable.RowsDefaultCellStyle.Font = new Font("宋体", 14, FontStyle.Strikeout);
            //PatientInfosTable.RowsDefaultCellStyle.ForeColor = Color.Blue;
            //PatientInfosTable.RowsDefaultCellStyle.BackColor = Color.Red;
            //this.m_Mainfrm = Mainfrm;
            this.m_PatientAcquTabctrl = PatientAcquTabctrl;
            this.m_AcquisitionPath = AcquisitionPath;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (this.SearchTextBox.Text == "")
            {
                //MessageBox.Show("检索内容为空，请输入!");
                MessageBoxFrm.ShowMesg("检索内容为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            bool m_FieldOptionFlg = false;
            m_checkedNameList.Clear();
            foreach (Control ctrl in this.fieldOptionControl1.Controls)
            {
                CheckBox cbox = (CheckBox)ctrl;
                if (cbox.Checked == true)
                {
                    m_FieldOptionFlg = true;
                    //将勾选中的内容压入字段列表中
                    m_checkedNameList.Add(ctrl.Name);
                }
                else
                {
                    m_FieldOptionFlg = false;
                }
            }
            if (m_checkedNameList.Count <=0)
            {
                //MessageBox.Show("未选中检索字段，请选择!");
                MessageBoxFrm.ShowMesg("未选中检索字段，请选择!", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            //开始检索操作
            bool m_IsNumberFlg = IsNumeric(SearchTextBox.Text);
            bool m_IsDateFlg = IsDate(SearchTextBox.Text);
            //string sql = "select * from tb_Patients where ";
            string sql = "select PatientID as 病人ID,Name as 姓名,Case Gender when 1 then '男' when 0 then '女' end as 性别,Race as 民族,Birthday as 出生日期,Telephone as 电话,Email as 邮箱,Address as 地址,Memo as 诊断,Firstname as 名字,Lastname as 姓氏,Prefix as 前缀,subfix as 后缀,SFZID as 身份证 from tb_Patients where";
            if (m_IsNumberFlg)
            {                
                if (this.m_checkedNameList.Contains("PatientIDCheckBox"))
                {
                    sql = sql + " PatientID = " + SearchTextBox.Text + " or";
                }
                if (this.m_checkedNameList.Contains("SFZIDCheckBox"))
                {
                    sql = sql + " SFZID = " + SearchTextBox.Text + " or";
                }

                //删除尾部最后一个or字符
                sql = sql.TrimEnd("or".ToCharArray());
                //如果没有选中病人ID且没有选中身份证ID
                if (!sql.Contains("PatientID =") && !sql.Contains("SFZID ="))
                {
                    using (DataTable _dtClear = new DataTable())
                    {
                        this.PatientInfosTable.Visible = false;
                        this.PatientInfosTable.DataSource = _dtClear;
                        //MessageBox.Show("未检索到病人记录！");
                        MessageBoxFrm.ShowMesg("未检索到病人记录！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.InformationIco);

                    }
                }
                else
                {
                    //根据查询条件查询记录
                    using (DataTable dt = DBHelper.SelectRecordByCondition(sql))
                    {
                        this.PatientInfosTable.Visible = true;
                        this.PatientInfosTable.DataSource = dt;
                        //单双行显示不同颜色
                        //ShowTwoDefferentColor();
                    }
                }

            }
            else if (m_IsDateFlg)//如果输入的是一个日期值
            {
                //MessageBox.Show("您输入了一个日期！");
                //字段中选择了出生日期
                if (this.m_checkedNameList.Contains("BirthdayCheckBox"))
                {
                    //string sqlBirthday = "select * from tb_Patients where Birthday =cast('" + SearchTextBox.Text + "' as datetime)";
                    string sqlBirthday = "select PatientID as 病人ID,Name as 姓名,Case Gender when 1 then '男' when 0 then '女' end as 性别,Race as 民族,Birthday as 出生日期,Telephone as 电话,Email as 邮箱,Address as 地址,Memo as 诊断,Firstname as 名字,Lastname as 姓氏,Prefix as 前缀,subfix as 后缀,SFZID as 身份证 from tb_Patients where Birthday =cast('" + SearchTextBox.Text + "' as datetime)";
                    //根据查询条件查询记录
                    using (DataTable dt = DBHelper.SelectRecordByCondition(sqlBirthday))
                    {
                        this.PatientInfosTable.Visible = true;
                        this.PatientInfosTable.DataSource = dt;
                        //单双行显示不同颜色
                        //ShowTwoDefferentColor();
                    }
                }
                else
                {
                    using (DataTable _dtClear = new DataTable())
                    {
                        this.PatientInfosTable.Visible = false;
                        this.PatientInfosTable.DataSource = _dtClear;
                        //MessageBox.Show("未检索到病人记录！");
                        MessageBoxFrm.ShowMesg("未检索到病人记录！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.InformationIco);
                    }
                }

            }
            else//输入的条件既不是数字，也不是日期
            {
                if (this.m_checkedNameList.Contains("NameCheckBox"))
                {
                    sql = sql + " Name = '" + SearchTextBox.Text + "' or";
                }
                if (this.m_checkedNameList.Contains("GenderCheckBox"))
                {
                    if (SearchTextBox.Text == "男" || SearchTextBox.Text == "女")
                    {                      
                        int m_genderVal = (SearchTextBox.Text == "男") ? 1 : 0;
                        sql = sql + " Gender = " + m_genderVal + " or";                       
                    }                    
                }
                if (this.m_checkedNameList.Contains("RaceCheckBox"))
                {
                    sql = sql + " Race = '" + SearchTextBox.Text + "' or";
                }

                //删除尾部最后一个or字符
                sql = sql.TrimEnd("or".ToCharArray());
                //如果没有选中病人Name且没有选中Gender和Race
                if (!sql.Contains("Name =") && !sql.Contains("Gender =")&& !sql.Contains("Race ="))
                {
                    using (DataTable _dtClear = new DataTable())
                    {
                        this.PatientInfosTable.Visible = false;
                        this.PatientInfosTable.DataSource = _dtClear;
                        //MessageBox.Show("未检索到病人记录！");
                        MessageBoxFrm.ShowMesg("未检索到病人记录！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.InformationIco);
                    }
                }
                else
                {
                    //根据查询条件查询记录
                    using (DataTable dt = DBHelper.SelectRecordByCondition(sql))
                    {
                        this.PatientInfosTable.Visible = true;
                        this.PatientInfosTable.DataSource = dt;
                        //单双行显示不同颜色
                        //ShowTwoDefferentColor();
                    }
                }
            }
       }
        /// <summary>
        /// 输入是否为数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public  bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        /// <summary>
        /// 输入是否为日期
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsDate(string date)
        {
            try
            {
                DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        ///  //检索全部病人信息记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchAllBtn_Click(object sender, EventArgs e)
        {
            this.PatientInfosTable.Visible = true;
            DataTable m_allPatientInfos = DBHelper.GetAllPatientInfos();
            this.PatientInfosTable.DataSource = m_allPatientInfos;
            //单双行显示不同颜色
            //ShowTwoDefferentColor();
        }

        /// <summary>
        /// 右击病人列表中弹出右击菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatientInfosTable_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    PatientInfosTable.ClearSelection();
                    PatientInfosTable.Rows[e.RowIndex].Selected = true;
                    rowindex = e.RowIndex;
                    ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
                    contextMenuStrip1.Items.Add("删除记录");
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    //contextMenuStrip1.Click += new EventHandler(contextMenuStrip1_ItemClicked);
                    contextMenuStrip1.Items[0].Click += new EventHandler(DeleteItemClicked);
                }
            }
        }
        /// <summary>
        /// 删除病人记录响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItemClicked(object sender, EventArgs e)
        {         
            DialogResult m_DialogResult =  MessageBox.Show("确定删除此记录?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (m_DialogResult == DialogResult.Cancel) return;
            if (this.PatientInfosTable.CurrentRow != null)
            {
                if (rowindex != -1)
                {               
                    //删除数据表tb_Patients对应的记录
                    DBHelper.DeletePatientInfoByPatientsID(UInt64.Parse(PatientInfosTable.Rows[rowindex].Cells[0].Value.ToString()));
                    //重新更新列表
                    DataTable m_allPatientInfos = DBHelper.GetAllPatientInfos();
                    this.PatientInfosTable.DataSource = m_allPatientInfos;
                    //单双行显示不同颜色
                    //ShowTwoDefferentColor();
                }
            }
        }

        //
        public void ShowTwoDefferentColor()
        {
            for (int i = 0; i < this.PatientInfosTable.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    this.PatientInfosTable.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
                    //this.PatientInfosTable.Rows[i].DefaultCellStyle.Font = this.splitContainer1.Font;
                }
                else
                {
                    this.PatientInfosTable.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                    //this.PatientInfosTable.Rows[i].DefaultCellStyle.Font = this.splitContainer1.Font;
                }
            }

        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void PatientInfosTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                PatientInfosTable.ClearSelection();
                PatientInfosTable.Rows[e.RowIndex].Selected = true;
                string m_PatientIDStr = PatientInfosTable.Rows[e.RowIndex].Cells[0].Value.ToString();
                string m_PatientName = PatientInfosTable.Rows[e.RowIndex].Cells[1].Value.ToString();
                bool m_IsExitSamePatientIDFlg = false;
                for (int i = 0; i < this.m_PatientAcquTabctrl.TabPages.Count; i++)
                {
                    if (this.m_PatientAcquTabctrl.TabPages[i].Text.Contains(m_PatientIDStr))
                    {
                        m_IsExitSamePatientIDFlg = true;                        
                        break;
                    }
                }

                if (m_IsExitSamePatientIDFlg)//如果存在相同的记录
                {
                    //MessageBox.Show("在采集列表中已存在相同的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBoxFrm.ShowMesg("在采集列表中已存在相同的记录！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.WarnningIco);
                } else
                {
                    //在程序目录下新增病人ID文件夹，用来存放历史采集数据
                    // 创建目录病人ID文件夹
                    if (Directory.Exists(m_AcquisitionPath + m_PatientIDStr) == false)//如果不存在就创建file文件夹
                    {
                        DirectoryInfo d = Directory.CreateDirectory(m_AcquisitionPath + m_PatientIDStr);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.m_PatientAcquTabctrl.Visible = true;//控件可见
                    TabPage m_newPage = new TabPage();                  
                    m_newPage.Text = "姓名：" + m_PatientName + "\r\n" + "ID:" + m_PatientIDStr + "\r\n";
                    m_newPage.Name = m_PatientName + ";" + m_PatientIDStr;//为后续传值给采集界面所用
                    //this.m_PatientAcquTabctrl.Controls.Add(m_newPage);
                    LoadAcqImagesFrm m_LoadAcqImagesFrm = new LoadAcqImagesFrm();
                    m_LoadAcqImagesFrm.Dock = DockStyle.Fill;
                    m_LoadAcqImagesFrm.m_AcqPath = m_AcquisitionPath + m_PatientIDStr;//采集存放路径
                    m_LoadAcqImagesFrm.m_PatientID = m_PatientIDStr;//存放病人ID
                    m_LoadAcqImagesFrm.TopLevel = false;
                    m_LoadAcqImagesFrm.FormBorderStyle = FormBorderStyle.None;
                    m_newPage.Controls.Add(m_LoadAcqImagesFrm);
                    this.m_PatientAcquTabctrl.TabPages.Add(m_newPage);
                    m_LoadAcqImagesFrm.Show();
                    this.m_PatientAcquTabctrl.SelectedIndex = this.m_PatientAcquTabctrl.TabPages.Count - 1;                    
                }
            }
        }

        private void SearchPatientFrm_Load(object sender, EventArgs e)
        {
            List<object> m_ButtonList = new List<object>();
            m_ButtonList = new List<object>();
            m_ButtonList.Add(this.SearchAllBtn);
            m_ButtonList.Add(this.SearchBtn);
            m_ButtonList.Add(this.OKBtn);
            SkinFile.MadeNewSkinForControls(m_ButtonList);

            base.TitleLbl.Text = "检索病人";
            base.MaxBtn.Visible = false;
            this.PatientInfosTable.Visible = false;
            List<Object> m_NewSkinObjectList = new List<Object>();//需要换肤的窗体列表
            m_NewSkinObjectList.Add(this);
            m_NewSkinObjectList.Add(this.groupBox1);
            //m_NewSkinObjectList.Add(this.fieldOptionControl1);            
            SkinLib.SkinFile.MadeNewSkinForControls(m_NewSkinObjectList);
        }
    }
}
