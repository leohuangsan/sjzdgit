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
    public class Polygons : GraphicsInterface
    {
        public UInt64 m_PolygonID;//多边形对象ID
        public Graphics m_Graphics;//画布句柄
        public Point[] m_PolygonPointArray;//多边形点的数组
        public Pen m_Pen = new Pen(Color.Red, 1);//画笔
        public bool m_IsDrawDashFrame = true;//是否虚线框
        private int _GraphicType = 2;//
        public int GraphicType
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
        public Polygons(UInt64 PolygonID, Point[] PolygonPointArray)
        {
            this.m_PolygonID = PolygonID;
            this.m_PolygonPointArray = PolygonPointArray;
            //this.m_Graphics = g;         
        }
        public void DrawingGraphics()
        {            
            m_Graphics.DrawPolygon(m_Pen, m_PolygonPointArray);
            if (m_IsDrawDashFrame)
            {               
                //获取多边形的范围矩形框
                Rectangle _PolygonFrameRect = this.getPolygonFrame();
                Color _originalePenColor = m_Pen.Color;//先将画笔颜色保存起来
                float _originalePenWidth = m_Pen.Width;//先将画笔宽度保存起来

                m_Pen.DashStyle = DashStyle.Solid;
                m_Pen.Color = Color.White;
                m_Graphics.DrawPolygon(m_Pen, m_PolygonPointArray);
                m_Pen.DashStyle = DashStyle.Dot;
                m_Pen.Width = 2;                          
                m_Graphics.DrawRectangle(m_Pen, _PolygonFrameRect);//画虚线的矩形框
                //画提示的交叉点，即所有点都画交叉点
                m_Pen.DashStyle = DashStyle.Solid;
                m_Pen.Width = 1;
                m_Pen.Color = Color.Red;
                foreach (Point _PolygonPoint in this.m_PolygonPointArray)
                {                   
                    DrawRemaking(_PolygonPoint);
                }
                //恢复画笔原来的设颜色、宽度
                m_Pen.Color = _originalePenColor;
                m_Pen.Width = _originalePenWidth;
                m_Pen.DashStyle = DashStyle.Solid;
            }
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
            this.m_Graphics.DrawLine(m_Pen,_LeftTopPoint, _RightBttomPoint);
            this.m_Graphics.DrawLine(m_Pen, _LeftBttomPoint, _RightTopPoint);
        }
        /// <summary>
        /// 获取多边形范围的矩形框
        /// </summary>
        /// <returns></returns>
        public Rectangle getPolygonFrame()
        {
            Point[] _FramePoints = new Point[4];//存放图形范围的4个点
            Point _MostLeftPoint = this.getMostLeftPoint();//获取最左侧的点
            Point _MostBottomPoint = this.getMostBottomPoint();//获取最下面的点
            Point _MostRightPoint = this.getMostRightPoint();//获取最右侧的点
            Point _MostTopPoint = this.getMostTopPoint();//获取最上面的点
            _FramePoints[0] = new Point(_MostLeftPoint.X, _MostTopPoint.Y);//计算得到矩形左上角的点
            _FramePoints[1] = new Point(_MostLeftPoint.X, _MostBottomPoint.Y);//计算得到矩形左下角的点
            _FramePoints[2] = new Point(_MostRightPoint.X, _MostLeftPoint.Y);//计算得到矩形右下角的点
            _FramePoints[3] = new Point(_MostRightPoint.X, _MostTopPoint.Y);//计算得到矩形右上角的点
            //重新构建一个范围稍大一点的矩形（含起点、长、宽）
            Point _FrameStartPoint = new Point(_FramePoints[0].X - 4, _FramePoints[0].Y - 4);
            int _FrameWidth = _FramePoints[2].X - _FramePoints[1].X + 8;
            int _FrameHeight = _FramePoints[1].Y - _FramePoints[0].Y + 8;
            return new Rectangle(_FrameStartPoint,new Size(_FrameWidth, _FrameHeight));
        }
        /// <summary>
        /// 鼠标点击处是否落在多边形的范围内
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsContained(int x,int y)
        {
            //获取多边形的范围矩形框
            Rectangle _PolygonFrameRect = this.getPolygonFrame();
            if (_PolygonFrameRect.Contains(x, y)) return true;
            else return false;
        }

        //获取多边形最靠上边的点
        public Point getMostTopPoint()
        {
           Point _MostTopPoint = new Point(10000,10000);//存放最大Y值
            foreach (Point _myPoint in this.m_PolygonPointArray)
            {
                if (_myPoint.Y < _MostTopPoint.Y)
                {
                    _MostTopPoint = _myPoint;//找到最大的那一个值
                }
            }
            return _MostTopPoint;
        }

        //获取多边形最靠下边的点
        public Point getMostBottomPoint()
        {
            Point _MostBottomPoint = new Point(0, 0);//存放最大Y值
            foreach (Point _myPoint in this.m_PolygonPointArray)
            {
                if (_myPoint.Y > _MostBottomPoint.Y)
                {
                    _MostBottomPoint = _myPoint;//找到最大的那一个值
                }
            }
            return _MostBottomPoint;
        }

        //获取多边形最靠左边的点
        public Point getMostLeftPoint()
        {
            Point _MostLeftPoint = new Point(10000, 10000);//存放最大Y值
            foreach (Point _myPoint in this.m_PolygonPointArray)
            {
                if (_myPoint.X < _MostLeftPoint.X)
                {
                    _MostLeftPoint = _myPoint;//找到最大的那一个值
                }
            }
            return _MostLeftPoint;
        }

        //获取多边形最靠右边的点
        public Point getMostRightPoint()
        {
            Point _MostRightPoint = new Point(0, 0);//存放最大Y值
            foreach (Point _myPoint in this.m_PolygonPointArray)
            {
                if (_myPoint.X > _MostRightPoint.X)
                {
                    _MostRightPoint = _myPoint;//找到最大的那一个值
                }
            }
            return _MostRightPoint;
        }
    }
}
