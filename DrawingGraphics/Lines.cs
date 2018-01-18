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
    public class Lines : GraphicsInterface,IDisposable
    {
        public UInt64 m_LinesID;//线对象ID
        public Graphics m_Graphics;//画布句柄
        public Point m_StartPoint;//画线的起点
        public Point m_EndPoint;//画线的终点
        public Pen m_Pen = new Pen(Color.Red,1);//画笔  
        public Pen m_DashPen = new Pen(Color.White, 1);//虚线画笔      
        public bool m_IsDrawDashFrame = true;//是否虚线框
        public Brush m_Brush = Brushes.Red;//画刷
        private int _GraphicType = 1;//
        /// <summary>
        /// 线的类型值，实现接口
        /// </summary>
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
        /// <summary>
        /// 线的构造方法
        /// </summary>
        /// <param name="LinesID"></param>
        /// <param name="StartPoint"></param>
        /// <param name="EndPoint"></param>
        public Lines(UInt64 LinesID, Point StartPoint, Point EndPoint)
        {
            this.m_LinesID = LinesID;
            this.m_StartPoint = StartPoint;
            this.m_EndPoint = EndPoint;
            //this.m_Graphics = g;          
        }
        /// <summary>
        /// 画线方法，实现接口
        /// </summary>
        public void DrawingGraphics()
        {
            m_Pen.Color = Color.Red;
            m_Pen.DashStyle = DashStyle.Solid;
            m_Graphics.DrawLine(m_Pen, m_StartPoint, m_EndPoint);
            //获取直线与水平方向的夹角
            //int _getAngle = m_TempLine.GetAngleBeteenHorizontation();
            //计算线段间的长度
            int _getLength = GetLineLength();
            //获取线段中间点的坐标
            Point _MiddlePoiont = getMiddlePoint();
            //实时显示线段的长度值
            m_Graphics.DrawString(_getLength.ToString(), new Font("arial", 14, FontStyle.Regular), m_Brush, _MiddlePoiont);

            //获取线段两端的垂直线段的斜率
            double k;
            Point[] _VeticalSegmentPoints = new Point[4];

            Point[] _VeticalSegmentPoints1 = new Point[2];//存放垂直线段上的两个点
            Point[] _VeticalSegmentPoints2 = new Point[2]; //存放垂直线段上的两个点

            bool _getVerticalGradientFlg = this.getVeticalLineGradient(this.m_EndPoint,this.m_StartPoint,out k);
            if (_getVerticalGradientFlg)//获取垂直线段的斜成功的话
            {
                //获取与线垂直的两条线段的点               
                _VeticalSegmentPoints1 = this.getVertcialLineTwoPoint(this.m_StartPoint,k);
                _VeticalSegmentPoints2 = this.getVertcialLineTwoPoint(this.m_EndPoint, k);
                _VeticalSegmentPoints[0] = _VeticalSegmentPoints1[0];
                _VeticalSegmentPoints[1] = _VeticalSegmentPoints1[1];
                _VeticalSegmentPoints[2] = _VeticalSegmentPoints2[1];
                _VeticalSegmentPoints[3] = _VeticalSegmentPoints2[0];
            }
            else//获取垂直线段的斜失败的话
            {
                _VeticalSegmentPoints1[0] = new Point(this.m_StartPoint.X, this.m_StartPoint.Y + 10);
                _VeticalSegmentPoints1[1] = new Point(this.m_StartPoint.X, this.m_StartPoint.Y - 10);
                _VeticalSegmentPoints2[0] = new Point(this.m_EndPoint.X, this.m_EndPoint.Y - 10);
                _VeticalSegmentPoints2[1] = new Point(this.m_EndPoint.X, this.m_EndPoint.Y + 10);
                _VeticalSegmentPoints[0] = _VeticalSegmentPoints1[0];
                _VeticalSegmentPoints[1] = _VeticalSegmentPoints1[1];
                _VeticalSegmentPoints[2] = _VeticalSegmentPoints2[0];
                _VeticalSegmentPoints[3] = _VeticalSegmentPoints2[1];

            }
            //画与当前线段垂直的两条线段
            float _OriginalPenWidth0 = m_Pen.Width;//保存原来的宽度     
            m_Pen.Width = 1;
            m_Graphics.DrawLine(m_Pen, _VeticalSegmentPoints1[0], _VeticalSegmentPoints1[1]);
            m_Graphics.DrawLine(m_Pen, _VeticalSegmentPoints2[0], _VeticalSegmentPoints2[1]);
            m_Pen.Width = _OriginalPenWidth0;
            //画虚线框
            if (m_IsDrawDashFrame)
            {
                float _OriginalPenWidth = m_Pen.Width;//保存原来的宽度                
                Color _OriginalPenColor =  m_Pen.Color;//保存原来的颜色
                //显示范围稍微大一点
                Point[] _NewVeticalSegmentPoints = new Point[4];
                _NewVeticalSegmentPoints[0] = new Point(_VeticalSegmentPoints[0].X - 5, _VeticalSegmentPoints[0].Y + 5);
                _NewVeticalSegmentPoints[1] = new Point(_VeticalSegmentPoints[1].X - 5, _VeticalSegmentPoints[1].Y - 5);
                _NewVeticalSegmentPoints[2] = new Point(_VeticalSegmentPoints[2].X + 5, _VeticalSegmentPoints[2].Y - 5);
                _NewVeticalSegmentPoints[3] = new Point(_VeticalSegmentPoints[3].X + 5, _VeticalSegmentPoints[3].Y + 5);            
                //Pen _WhitePen = new Pen(Color.White, 1);
                m_Pen.Color = Color.White;
                //_WhitePen.DashStyle = DashStyle.Dash;
                m_Graphics.DrawLine(m_Pen, m_StartPoint, m_EndPoint);//再画一次白线
                //画与当前线段垂直的两条线段

                m_Pen.Width = 1;
                m_Graphics.DrawLine(m_Pen, _VeticalSegmentPoints1[0], _VeticalSegmentPoints1[1]);
                m_Graphics.DrawLine(m_Pen, _VeticalSegmentPoints2[0], _VeticalSegmentPoints2[1]);

                //画提示的交叉点，即所有点都画交叉点  
                m_Pen.Color = Color.Red;
                DrawRemaking(m_StartPoint);
                DrawRemaking(m_EndPoint);

                //画范围框
                m_DashPen.DashStyle = DashStyle.DashDot;
                m_Pen.Color = Color.White;
                m_Graphics.DrawPolygon(m_DashPen, _NewVeticalSegmentPoints);

                m_Pen.Width = _OriginalPenWidth;//恢复宽度
                m_Pen.DashStyle = DashStyle.Solid;
                m_Pen.Color = _OriginalPenColor;//恢复颜色
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
            this.m_Graphics.DrawLine(m_Pen, _LeftTopPoint, _RightBttomPoint);
            this.m_Graphics.DrawLine(m_Pen, _LeftBttomPoint, _RightTopPoint);
        }
        /// <summary>
        /// 检测X,Y点是否落在线所在的范围之中，原理：计算X,Y到线的高度小于限定值，同时，限定X的的范围
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsContained(int x, int y)
        {
            double a, b, c;
            double delta1 ;
            double delta2 ;
            int h;
            //求三角形的高度h
            a = Math.Sqrt((x - m_StartPoint.X) * (x - m_StartPoint.X) + (y - m_StartPoint.Y) * (y - m_StartPoint.Y));
            b = Math.Sqrt((m_StartPoint.X - m_EndPoint.X) * (m_StartPoint.X - m_EndPoint.X) + (m_StartPoint.Y - m_EndPoint.Y) * (m_StartPoint.Y - m_EndPoint.Y));
            c = Math.Sqrt((x - m_EndPoint.X) * (x - m_EndPoint.X) + (y - m_EndPoint.Y) * (y - m_EndPoint.Y));
            h = (int)Math.Sqrt(a * a - (a * a + b * b - c * c) * (a * a + b * b - c * c) / (4 * b * b));
            //限定鼠标点击处与起点、终点的距离范围
            int Len1 = 10, Len2 = 10;//距离限定值

            if (m_EndPoint.X > m_StartPoint.X)//终点坐标大于起点坐标
            {
                if ((x >= m_StartPoint.X) && (x <= m_EndPoint.X))//鼠标点击处位线范围的中间区域
                {
                    if (h < Len1) return true;
                }
                else if (x < m_StartPoint.X)//鼠标点击处位于起点之外
                {
                    delta1 = Math.Abs(x - m_StartPoint.X);
                    if (h < Len1 && (delta1 < Len2)) return true;
                }
                else if (x > m_EndPoint.X)//鼠标点击处位于终点之外
                {
                    delta2 = Math.Abs(x - m_EndPoint.X);
                    if (h < Len1 && (delta2 < Len2)) return true;
                }
            }
            else//终点坐标不大于起点坐标
            {
                if ((x >= m_EndPoint.X) && (x <= m_StartPoint.X))//鼠标点击处位线范围的中间区域
                {
                    if (h < Len1) return true;
                }
                else if (x < m_EndPoint.X)//鼠标点击处位于终点之外
                {
                    delta1 = Math.Abs(x - m_EndPoint.X);
                    if (h < Len1 && (delta1 < Len2)) return true;
                }
                else if (x > m_StartPoint.X)//鼠标点击处位于起点之外
                {
                    delta2 = Math.Abs(x - m_StartPoint.X);
                    if (h < Len1 && (delta2 < Len2)) return true;
                }
            }          
            return false;
        }
        /// <summary>
        /// 计算当前直线与水平方向的夹角，目的是用于显示线的长度值旋转角度所用
        /// </summary>
        /// <returns></returns>
        public int GetAngleBeteenHorizontation()
        {
            Point _firstPoint = this.m_StartPoint;
            Point _centrePoint = this.m_EndPoint;
            Point _secondPoint = new Point(this.m_EndPoint.X + 200,this.m_EndPoint.Y);//第三点是与中心点处于同一水平线上，人为定义X轴坐标为：X +２００
            //求三点夹角
            double _angleDouble = GetAngle(_firstPoint, _centrePoint, _secondPoint);
            return (int)_angleDouble;
        }
        /// <summary>
        /// 快速求出三点之间的夹角
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="centrePoint"></param>
        /// <param name="secondPoint"></param>
        /// <returns></returns>        
        public double GetAngle(Point firstPoint,Point centrePoint,Point secondPoint)
        {
            Point first = firstPoint;//角的第一个点
            Point cen = centrePoint; //角的顶点
            Point second = secondPoint;//角的每二个点
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
        /// <summary>
        /// 实现接品的Dispose方法
        /// </summary>
        public void Dispose()
        {
            //调用带参数的Dispose方法，释放托管和非托管资源
            Dispose(true);
            //手动调用了Dispose释放资源，那么析构函数就是不必要的了，这里阻止GC调用析构函数
            //System.GC.SuppressFinalize(this);
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="isRealseSoureFlg"></param>
        protected void Dispose(bool isRealseSoureFlg)
        {
            if (isRealseSoureFlg)
            {
                ///TODO:在这里加入清理"托管资源"的代码，应该是xxx.Dispose();
                //GC.Collect();//
                this.m_Pen.Dispose();//
            }
            ///TODO:在这里加入清理"非托管资源"的代码
        }
        /// <summary>
        /// 计算线段的长度
        /// </summary>
        /// <returns></returns>
        public int GetLineLength()
        {
            double _Len = Math.Sqrt((this.m_EndPoint.X - this.m_StartPoint.X) * (this.m_EndPoint.X - this.m_StartPoint.X) + (this.m_EndPoint.Y - this.m_StartPoint.Y) * (this.m_EndPoint.Y - this.m_StartPoint.Y));
            return (int)_Len;
        }
        /// <summary>
        /// 获取线段中间位置的点的坐标
        /// </summary>
        /// <returns></returns>
        public Point getMiddlePoint()
        {
                Point EndPoint = this.m_EndPoint; Point StartPoint = this.m_StartPoint;
            // 计算斜率
            //double k = ((double)(EndPoint.Y - StartPoint.Y)) / (EndPoint.X - StartPoint.X);
            double k ;
            //尝试获取线段的斜率
            bool _IsGetGradientFlg = getLineGradient(EndPoint, StartPoint,out k);
            if (_IsGetGradientFlg)//获取成功
            {
                //求中间点的X坐标
                int _MiddlePointX = StartPoint.X + (int)((EndPoint.X - StartPoint.X) / 2);
                // 根据斜率，计算中间点的Y坐标
                double _MiddlePointYDouble = k * (_MiddlePointX - StartPoint.X) + StartPoint.Y;
                int _MiddlePointY = (int)_MiddlePointYDouble;
                return new Point(_MiddlePointX, _MiddlePointY);
            }
            else//获取失败，说明斜率为无穷大，即此线段与X轴垂直
            {                
                return new Point(StartPoint.X, StartPoint.Y + (int)((EndPoint.Y - StartPoint.Y)/2));
            }           
        }
        /// <summary>
        /// 求当前线段的斜率
        /// </summary>
        /// <param name="myEndPoint"></param>
        /// <param name="myStartPoint"></param>
        /// <param name="myGradient"></param>
        /// <returns></returns>
        public bool getLineGradient(Point myEndPoint,Point myStartPoint, out double myGradient)
        {
            if (myEndPoint.X - myStartPoint.X == 0)//如果当前线段是垂直X轴的话
            {
                myGradient = 0;//在此以0赋值，但没有意义，因为不用到
                return false;//返回失败，代表斜率为无穷大
            }
            else
            {
                // 计算斜率
                myGradient = (double)(myEndPoint.Y - myStartPoint.Y) / (double)(myEndPoint.X - myStartPoint.X);
                return true;//返回为成功，代表斜率有数值
            }          
        }
        /// <summary>
        /// 获取与此线段垂直线的斜率
        /// </summary>
        /// <param name="myEndPoint"></param>
        /// <param name="myStartPoint"></param>
        /// <param name="myGradient"></param>
        /// <returns></returns>
        public bool getVeticalLineGradient(Point myEndPoint, Point myStartPoint, out double myVeticalGradient)
        {
            double k = 0 ;
            //尝试获取线段的斜率
            bool _IsGetGradientFlg = getLineGradient(myEndPoint, myStartPoint,out k);
            if (_IsGetGradientFlg)//获取成功
            {
                if (k == 0)//当前线段与X轴平行的话
                {
                    myVeticalGradient = 0;//垂直线的斜率定义为0，没有意义，实际上它是无穷大
                    return false;
                }
                else
                {
                    myVeticalGradient = -1/k;//垂直线的斜率(原理：垂直相交的两条直线的斜率相乘为-1
                    return true; 
                }               
            }
            else//获取失败，说明当前线段的斜率为无穷大，即此线段与X轴垂直
            {
                myVeticalGradient = 0;//此时垂直线段的斜率为0
                return true;
            }
        }

        //根据已知线段的斜率及线段上的一个点，求出此点附近相邻的2个点（注：相邻的X的差为人为设定值）
        public Point[] getVertcialLineTwoPoint(Point myPoint,double k)
        {
            double m = 10;//设定值，即垂直线上的点与相交点的距离
            Point[] _getTwoPoints = new Point[2];
            //根据公式推导：ABS(x - x0) = Math.Sqrt(m * m /(1 + k * k))
            double _XDouble1 = (double)myPoint.X + Math.Sqrt(m * m / (1 + k * k));//计算出垂直线的一个点的X坐标
            double _XDouble2 = (double)myPoint.X - Math.Sqrt(m * m / (1 + k * k));//计算出垂直线的一个点的X坐标

            int _x1 = (int)_XDouble1;//强制转换成整形           
            int _x2 = (int)_XDouble2;//强制转换成整形

            //根据公式推导：Y = y0 + sqrt(m * m - (x -x0) * (x -x0))
            double _YDouble1 = (double)myPoint.Y + Math.Sqrt(m * m - (_XDouble1 - (double)myPoint.X) * (_XDouble1 - (double)myPoint.X));//计算出垂直线的一个点的Y坐标
            double _YDouble2 = (double)myPoint.Y - Math.Sqrt(m * m - (_XDouble1 - (double)myPoint.X) * (_XDouble1 - (double)myPoint.X));//计算出垂直线的一个点的Y坐标

            int _y1 = (int)_YDouble1;//强制转换成整形           
            int _y2 = (int)_YDouble2;//强制转换成整形

            _getTwoPoints[0] = new Point(_x1, _y1);//取得起点位置与线垂直方向上的第一个点
            _getTwoPoints[1] = new Point(_x2, _y2);//取得起点位置与线垂直方向上的第二个点

            //Console.WriteLine(k.ToString() + "---" +_x1.ToString() + "--" + _x2.ToString() + "--" + _YDouble1.ToString() + "--"+ _YDouble2.ToString());
            ////求与起点处相垂直的两个点的坐标
            //int _PointX1 = myPoint.X - 50;
            //// 根据斜率，计算点1的Y坐标
            //double _PointY1Double = myPoint.Y - k * (myPoint.X - _PointX1);
            //int _PointY1 = (int)_PointY1Double;
            //_getTwoPoints[0] =  new Point(_PointX1, _PointY1);//取得起点位置与线垂直方向上的第一个点

            //int _PointX2 = myPoint.X + 50;
            //// 根据斜率，计算点2 的Y坐标
            //double _PointY2Double = myPoint.Y + k * (_PointX2 - myPoint.X);
            //int _PointY2 = (int)_PointY2Double;
            //_getTwoPoints[1] = new Point(_PointX2, _PointY2);//取得起点位置与线垂直方向上的第二个点
            return _getTwoPoints;
        }
    }
}
