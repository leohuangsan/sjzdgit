using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkinLib
{

    public partial class NewStyleFrm : Form
    {
        // 窗体的屏幕坐标  
        Point formPoint;

        // 鼠标光标的屏幕坐标  
        Point mousePoint;

        public NewStyleFrm()
        {
            InitializeComponent();
        }

        private void MaxBtn_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                return;
            }

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public virtual void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void NewStyleFrm_MouseDown(object sender, MouseEventArgs e)
        {
            // 获取窗体的屏幕坐标(x,y)  
            formPoint = this.Location;

            // 获取鼠标光标的位置（屏幕坐标）  
            mousePoint = Control.MousePosition;
        }

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            // 获取窗体的屏幕坐标(x,y)  
            formPoint = this.Location;

            // 获取鼠标光标的位置（屏幕坐标）  
            mousePoint = Control.MousePosition;
        }

        private void NewStyleFrm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //获取鼠标移动时的屏幕坐标  
                Point mousePos = Control.MousePosition;

                //改变窗体位置  
                this.Location = new Point(formPoint.X + mousePos.X - mousePoint.X, formPoint.Y + mousePos.Y - mousePoint.Y);
            }
        }

        private void TitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //获取鼠标移动时的屏幕坐标  
                Point mousePos = Control.MousePosition;

                //改变窗体位置  
                this.Location = new Point(formPoint.X + mousePos.X - mousePoint.X, formPoint.Y + mousePos.Y - mousePoint.Y);
            }
        }

        private void NewStyleFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void NewStyleFrm_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush m_Brush = new SolidBrush(Color.Gray);
            Pen myPen = new Pen(Color.FromArgb(100, 100, 100));           
            Rectangle tabRect = new Rectangle(0, 0, this.Width -1, this.Height -1);          
            e.Graphics.DrawRectangle(myPen, tabRect);
        }
    }
}
