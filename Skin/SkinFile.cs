using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SkinLib
{
    public enum MessageBoxNewIco { ErrorIco,OKIco,InformationIco,QuestionIco,WarnningIco}
    public class SkinFile
    {
        public static void MadeNewSkinForButton(List<Button> ButtonList)
        {
            foreach (Button m_earchButton in ButtonList)
            {
                // C#中则是：项目命名空间.资源文件所在文件夹名.资源文件名 
                //例如：istr = assm.GetManifestResourceStream("项目命名空间.资源文件所在文件夹名.资源文件名");
                Image image = SkinLib.SkinResource.Green;
                m_earchButton.BackgroundImage = image;//加载背景图片
                m_earchButton.BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸
                m_earchButton.FlatStyle = FlatStyle.Flat;//扁平
                m_earchButton.FlatAppearance.BorderSize = 0;//无边框
                m_earchButton.FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下时透明
                m_earchButton.FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标移到时透明
                m_earchButton.BackColor = Color.Transparent;
                m_earchButton.ForeColor = Color.White;//字体为白色
            }
        }

        public static void MadeNewSkinForForm(List<Form> FormList)
        {
            foreach (Form m_FormButton in FormList)
            {                
                Image image = SkinLib.SkinResource.BackGround2;
                m_FormButton.BackgroundImage = image;//加载背景图片
                m_FormButton.BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸               
            }
        }

        public static void MadeNewSkinForControls(List<object> objectList)
        {
            foreach (object m_earchObject in objectList)
            {                
                if (m_earchObject is Form)
                {
                    Image image = SkinLib.SkinResource.BackGround2;
                    ((Form)m_earchObject).BackgroundImage = image;//加载背景图片
                    ((Form)m_earchObject).BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸    
                    continue;                  
                }

                if (m_earchObject is Button)
                {
                    // C#中则是：项目命名空间.资源文件所在文件夹名.资源文件名 
                    //例如：istr = assm.GetManifestResourceStream("项目命名空间.资源文件所在文件夹名.资源文件名");
                    Image image = SkinLib.SkinResource.Button11;
                    ((Button)m_earchObject).BackgroundImage = image;//加载背景图片
                    ((Button)m_earchObject).BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸
                    ((Button)m_earchObject).FlatStyle = FlatStyle.Flat;//扁平
                    ((Button)m_earchObject).FlatAppearance.BorderSize = 0;//无边框
                    ((Button)m_earchObject).FlatAppearance.MouseDownBackColor = Color.Transparent;//鼠标按下时透明
                    ((Button)m_earchObject).FlatAppearance.MouseOverBackColor = Color.Transparent;//鼠标移到时透明
                    ((Button)m_earchObject).BackColor = Color.Transparent;
                    ((Button)m_earchObject).ForeColor = Color.White;//字体为白色
                    continue;
                }
                if (m_earchObject is Panel)
                {
                    Image image = SkinLib.SkinResource.BackGround2;
                    ((Panel)m_earchObject).BackgroundImage = image;//加载背景图片
                    ((Panel)m_earchObject).BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸 
                    continue;
                }

                if (m_earchObject is UserControl)
                {
                    Image image = SkinLib.SkinResource.BackGround2;
                    ((UserControl)m_earchObject).BackgroundImage = image;//加载背景图片
                    ((UserControl)m_earchObject).BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸 
                    continue;
                }

                if (m_earchObject is Label)
                {
                    Image image = SkinLib.SkinResource.BackGround2;
                    ((Label)m_earchObject).BackgroundImage = image;//加载背景图片
                    ((Label)m_earchObject).BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸 
                    continue;
                }
                if (m_earchObject is TextBox)
                {
                    Image image = SkinLib.SkinResource.BackGround2;
                    ((TextBox)m_earchObject).BackgroundImage = image;//加载背景图片
                    ((TextBox)m_earchObject).BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸    
                    continue;
                }
                if (m_earchObject is GroupBox)
                {
                    Image image = SkinLib.SkinResource.BackGround2;
                    ((GroupBox)m_earchObject).BackgroundImage = image;//加载背景图片
                    ((GroupBox)m_earchObject).BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸    
                    continue;
                }

                if (m_earchObject is TabControl)
                {
                    Image image = SkinLib.SkinResource.BackGround2;
                    ((TabControl)m_earchObject).BackgroundImage = image;//加载背景图片
                    
                    ((TabControl)m_earchObject).BackgroundImageLayout = ImageLayout.Stretch;//图片拉伸  
                    //Console.WriteLine("This is tabcontrol");       
                    foreach (TabPage m_tabPage in ((TabControl)m_earchObject).TabPages)
                    {
                        m_tabPage.BackgroundImage = image;
                        m_tabPage.BackgroundImageLayout = ImageLayout.Stretch;

                    }
                    continue;
                }
            }
        }
    }
}
