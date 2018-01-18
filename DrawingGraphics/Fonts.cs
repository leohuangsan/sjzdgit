using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace DrawingGraphicsLib
{
    public class Fonts : GraphicsInterface
    {
        public UInt64 m_FontsID;//字体对象ID
        public Graphics m_Graphics;//画布句柄
        public Point m_StartPoint;//画字体的起点      
        public Pen m_Pen = new Pen(Color.Red, 3);//画笔
        public Font m_Font;//字体
        public string m_FontsText = "";//字体内容
        public Rectangle m_FontRect;//字体矩形，包括字体起点及长、宽
        public bool m_IsDrawDashFrame ;//是否虚线框
        private int _GraphicType = 5;//图形类型
        public int GraphicType//图形类型，实现接口的图形类型
        {
            get
            {
                return _GraphicType;
            }
            set
            {
                _GraphicType = value;
            }
        }
        //public Fonts(UInt64 FontsID,string FontsText,Font fontSizeTye,Rectangle FontRect)
        public Fonts(UInt64 FontsID, string FontsText, Font fontSizeTye, Point StartPoint)
        {
            this.m_StartPoint = StartPoint;
            this.m_FontsText = FontsText;//字体内容
            this.m_FontsID = FontsID;//字体实体ID
            //this.m_FontRect = FontRect;//字体矩形，含起点、长和宽
            this.m_Font = fontSizeTye;//字体对象，含大小，字体类型
            //this.m_Graphics = g;

        }
        /// <summary>
        /// 画字体方法
        /// </summary>
        public void DrawingGraphics()
        {          
            m_Graphics.DrawString(m_FontsText, m_Font, Brushes.Red, m_StartPoint);
            if (m_IsDrawDashFrame)
            {
                Font _newFont = new Font("宋体", 14, FontStyle.Regular);
                SizeF sizeF = m_Graphics.MeasureString(m_FontsText, _newFont);                
                Rectangle rect = new Rectangle(m_StartPoint.X - 2, m_StartPoint.Y - 4, (int)sizeF.Width + 12, (int)sizeF.Height + 12);
                m_Pen.DashStyle = DashStyle.Dot;
                m_Pen.Color = Color.White;
                m_Graphics.DrawRectangle(m_Pen,rect);
                m_Graphics.DrawString(m_FontsText, m_Font, Brushes.White, m_StartPoint);//再画一次绿色
                m_Pen.DashStyle = DashStyle.Solid;
                m_Pen.Color = Color.Red;
            }
        }
        /// <summary>
        /// 输入的坐标点是否落在字体上，返回布尔值
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsContained(int x, int y)
        {
            Font _newFont = new Font("宋体", 14, FontStyle.Regular);
            SizeF sizeF = m_Graphics.MeasureString(m_FontsText, _newFont);           
            Rectangle rect = new Rectangle(m_StartPoint.X, m_StartPoint.Y, (int)sizeF.Width, (int)sizeF.Height);
            if (rect.Contains(x, y)) return true;
            else return false;
        }

        /// <summary>
        /// 以点为中心，画一个交叉，作为选中的提示点
        /// </summary>
        /// <param name="SourcePoint"></param>
        public void DrawRemaking(Point SourcePoint)
        {
            int _Len = 8;
            Point _LeftTopPoint = new Point(SourcePoint.X - _Len, SourcePoint.Y - _Len);
            Point _LeftBttomPoint = new Point(SourcePoint.X - _Len, SourcePoint.Y + _Len);
            Point _RightBttomPoint = new Point(SourcePoint.X + _Len, SourcePoint.Y + _Len);
            Point _RightTopPoint = new Point(SourcePoint.X + _Len, SourcePoint.Y - _Len);
            this.m_Graphics.DrawLine(m_Pen, _LeftTopPoint, _RightBttomPoint);
            this.m_Graphics.DrawLine(m_Pen, _LeftBttomPoint, _RightTopPoint);
        }
    }
}
