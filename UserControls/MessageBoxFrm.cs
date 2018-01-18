using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkinLib;
namespace UserControlsLib
{
   public class MessageBoxFrm
    {
        private static NewStyleFrm _NewStyleFrm;//自定义窗体的父窗体
        public static DialogResult ShowMesg(string MesgContent,string MesgTitle,MessageBoxButtons messageBoxButtons, MessageBoxNewIco messageBoxNewIcon)
        {            
            switch (messageBoxButtons)
            {
                case MessageBoxButtons.OK:
                    _NewStyleFrm = new MessageBoxOK(MesgContent,MesgTitle, messageBoxNewIcon);
                    break;
                case MessageBoxButtons.OKCancel:
                    _NewStyleFrm = new MessageBoxOKCancel(MesgContent,MesgTitle, messageBoxNewIcon);
                    break;
                
            }         


            return _NewStyleFrm.ShowDialog();
        }

       
    }
}
