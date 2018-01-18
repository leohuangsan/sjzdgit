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

namespace UserControlsLib
{
    

    public partial class MessageBoxOK : NewStyleFrm
    {
        //消息标题
        public string m_MessageTitle;
        //消息内容
        public string m_MessageContent;
        //消息图标
        public MessageBoxNewIco m_MessageBoxNewIco;

        public MessageBoxOK(string MesgContent, string MesgTitle, MessageBoxNewIco messageBoxNewIco)
        {
            InitializeComponent();
            this.m_MessageContent = MesgContent;
            this.m_MessageTitle = MesgTitle;
            this.m_MessageBoxNewIco = messageBoxNewIco;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void MessageFrm_Load(object sender, EventArgs e)
        {
            base.TitleLbl.Text = this.m_MessageTitle;
            this.MessageTextBox.Text = this.m_MessageContent;
            base.MaxBtn.Visible = false;
            this.ConfirmMyUserControl.MyUserBtn.Text = "确定";
            //this.CancelMyUserControl.MyUserBtn.Text = "取消";
            this.ConfirmMyUserControl.MyUserBtn.Click += ConfirmMyUserControl_Click;
            //this.CancelMyUserControl.MyUserBtn.Click += CancelMyUserControl_Click;
            LoadMessageBoxIco(this.m_MessageBoxNewIco);//加载提示ICO
        }

        public void ConfirmMyUserControl_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        public void CancelMyUserControl_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public void LoadMessageBoxIco(MessageBoxNewIco messageBoxNewIco)
        {

            switch (messageBoxNewIco)
            {
                case MessageBoxNewIco.ErrorIco:
                    this.pictureBox1.BackgroundImage = global::UserControlsLib.Properties.Resources.ErrorIco;
                    
                    break;
                case MessageBoxNewIco.InformationIco:
                    this.pictureBox1.BackgroundImage = global::UserControlsLib.Properties.Resources.InformationIco;

                    break;

                case MessageBoxNewIco.OKIco:
                    this.pictureBox1.BackgroundImage = global::UserControlsLib.Properties.Resources.OKIcon;

                    break;

                case MessageBoxNewIco.QuestionIco:
                    this.pictureBox1.BackgroundImage = global::UserControlsLib.Properties.Resources.QuestionIco;

                    break;

                case MessageBoxNewIco.WarnningIco:
                    this.pictureBox1.BackgroundImage = global::UserControlsLib.Properties.Resources.WarnningIcon;

                    break;


            }
            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
