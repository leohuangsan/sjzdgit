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
    public class Angles : GraphicsInterface
    {
        public UInt64 m_AnglesID;//角度对象ID
        public Graphics m_Graphics;//画布句柄
        public Point[] m_AnglesPointArray;//角度点的数组
        public Pen m_Pen = new Pen(Color.Red, 1);//画笔
        public bool m_IsDrawDashFrame;
        private int _GraphicType = 3;//
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

        public Angles(UInt64 AnglesID, Point[] AnglesPointArray)
        {
            this.m_AnglesID = AnglesID;
            this.m_AnglesPointArray = AnglesPointArray;
            //this.m_Graphics = g;         
        }
        //画出多条线构成的角
        public void DrawingGraphics()
        {
            m_Graphics.DrawLines(m_Pen, m_AnglesPointArray);
            int m_AngelVal = (int)GetAngle();//获取角度值
             //画角度值
            m_Graphics.DrawString(m_AngelVal.ToString() + "度", new Font("宋体", 14, FontStyle.Italic), Brushes.Red, m_AnglesPointArray[1]);
            //画角度
            if (m_IsDrawDashFrame)
            {
                float _OriginalPenWidth = m_Pen.Width;
                Color _OriginalPenColor = m_Pen.Color;
                //获取多边形的范围矩形框
                Rectangle _PolygonFrameRect = this.getPolygonFrame();
                m_Pen.DashStyle = DashStyle.DashDot;
                m_Pen.Width = 1;
                m_Pen.Color = Color.White;
                m_Graphics.DrawRectangle(m_Pen, _PolygonFrameRect);
                //画白色角度值
                m_Graphics.DrawString(m_AngelVal.ToString() + "度", new Font("宋体", 14, FontStyle.Italic), Brushes.White, m_AnglesPointArray[1]);
                //再画一次白色角

                m_Pen.Width = _OriginalPenWidth;//恢复原来的宽
                m_Pen.DashStyle = DashStyle.Solid;
                m_Graphics.DrawLines(m_Pen, m_AnglesPointArray);
              
                //画提示的交叉点，即所有点都画交叉点
                m_Pen.DashStyle = DashStyle.Solid;
                m_Pen.Width = 1;
                m_Pen.Color = Color.Red;
                foreach (Point _AnglesPoint in this.m_AnglesPointArray)
                {
                    DrawRemaking(_AnglesPoint);
                }
                m_Pen.Color = _OriginalPenColor;//恢复原来的颜色
                m_Pen.Width = _OriginalPenWidth;//恢复原来的宽
            }
        }

        //快速求出三点之间的夹角
        public double GetAngle()
        {
            Point first = m_AnglesPointArray[0];//角的第一个点
            Point cen = m_AnglesPointArray[1]; //角的顶点
            Point second = m_AnglesPointArray[2];//角的每二个点
            const double M_PI = 3.1415926535897;
            double ma_x = first.X - cen.X;
            double ma_y = first.Y - cen.Y;
            double mb_x = second.X - cen.X;
            double mb_y = second.Y - cen.Y;
            double v1 = (ma_x * mb_x) + (ma_y * mb_y);
            double ma_val = Math.Sqrt(ma_x * ma_x + ma_y * ma_y);
            double mb_val = Math.Sqrt(mb_x * mb_x + mb_y * mb_y);
            double cosM = v1 / (ma_val * mb_val);
            double angleAMB = Math.Acos(cosM) * 180 / M_PI;
            return angleAMB;
        }
        public void DrawingArc(Pen myPen, Point[] PointsArray)
        {
            m_Graphics.DrawCurve(myPen, PointsArray);
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
            return new Rectangle(_FrameStartPoint, new Size(_FrameWidth, _FrameHeight));
        }
        /// <summary>
        /// 鼠标点击处是否落在多边形的范围内
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsContained(int x, int y)
        {
            //获取多边形的范围矩形框
            Rectangle _PolygonFrameRect = this.getPolygonFrame();
            if (_PolygonFrameRect.Contains(x, y)) return true;
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
        //获取多边形最靠上边的点
        public Point getMostTopPoint()
        {
            Point _MostTopPoint = new Point(10000, 10000);//存放最大Y值
            foreach (Point _myPoint in this.m_AnglesPointArray)
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
            foreach (Point _myPoint in this.m_AnglesPointArray)
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
            foreach (Point _myPoint in this.m_AnglesPointArray)
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
            foreach (Point _myPoint in this.m_AnglesPointArray)
            {
                if (_myPoint.X > _MostRightPoint.X)
                {
                    _MostRightPoint = _myPoint;//找到最大的那一个值
                }
            }
            return _MostRightPoint;
        }

        //获取角的两边上的所有点
        public List<List<Point>> GetAllDotsOnAngleSides()
        {
            List<List<Point>> m_AllDotsOnAngleSides = new List<List<Point>>();
            m_AllDotsOnAngleSides.Add(GetDots(m_AnglesPointArray[1], m_AnglesPointArray[0]));
            m_AllDotsOnAngleSides.Add(GetDots(m_AnglesPointArray[1], m_AnglesPointArray[2]));
            return m_AllDotsOnAngleSides;
        }

        public List<Point> GetDots(Point Point1,Point Point2)
        {
            List<Point> m_AnglesSideDots = new List<Point>();//边的所有点
            for (int i = Point1.X + 1; i < Point2.X; i++)
            {
                // 计算斜率
                double k = ((double)(Point1.Y - Point2.Y)) / (Point1.X - Point2.X);
                // 根据斜率，计算y坐标
                double y = k * (i - Point1.X) + Point1.Y;
                // 简单判断一下y是不是整数
                //double d = y - (int)y;
                //if (0.001 > d && d > -0.001)
                //{
                //Console.Write("点的坐标：{0},{1}", i, (int)y);
                //}
                m_AnglesSideDots.Add(new Point(i,(int)y));//说明，这是近似点，只是用来画角度的弧线
            }
            return m_AnglesSideDots;
        }
    }
}
