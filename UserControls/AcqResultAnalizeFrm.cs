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
using DrawingGraphicsLib;
using GlobalToolSpace;
using System.IO;

namespace UserControlsLib
{
    public enum DrawingTypeEnum { None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines}
   
    public partial class AcqResultAnalizeFrm : NewStyleFrm
    {
        //用户画图时的图形类型
        private DrawingTypeEnum _drawingTypeEnum = DrawingTypeEnum.None;//私有画图类型枚举
        public DrawingTypeEnum m_drawingTypeEnum
        {
            get { return _drawingTypeEnum; }
            set { _drawingTypeEnum = value; }
        }
        //采集ID
        public UInt64 m_AcqID;

        //采集后分析结果（即图片）所在的硬盘目录
        public string m_AcqResltFile;

        //采集后分析结果（即有图形叠加分析的图片）
        public Bitmap m_ResqultBitmap;

        //采集后分析前的结果（即采集的源图片）
        public Bitmap m_OriginalBitmap;


        //LoadAcqImagesFrm窗体引用
        public LoadAcqImagesFrm m_LoadAcqImagesFrm;

        //线列表
        public List<Lines> m_LinesList = new List<Lines>();
        //public Dictionary<int,Lines> m_LinesDictonary = new Dictionary<int,Lines>();
        //箭头列表
        public List<Arrow> m_ArrowList = new List<Arrow>();

        //字体列表
        public List<Fonts> m_FontsList = new List<Fonts>();

        //鼠标按下时将此时的坐标压入列表中
        //public List<Point> MouseDownPointList = new List<Point>();

        //线的起始坐标值
        public List<Point> m_LineStartPointList = new List<Point>();

        //线的结束坐标值
        public Point m_LineEndPoint;

        //画字体的开始坐标
        public Point m_FontStartPoint;

        //字体内容
        public string m_FontTexts = "Text";

        //多边形的点列表
        public List<Point> m_PolygonPointList = new List<Point>();

        //未封闭多边形的点列表
        public List<Point> m_MultiLinesPointList = new List<Point>();

        //多边形的结束点坐标值
        public Point m_PolygonEndPoint;

        //多边形列表
        public List<Polygons> m_PolygonList = new List<Polygons>();

        //未封闭多边形列表
        public List<MultiLines> m_MultiLinesList = new List<MultiLines>();
        
        //角度列表
        public List<Angles> m_AnglesList = new List<Angles>();

        //多边形的点列表
        public List<Point> m_AnglesPointList = new List<Point>();

        //角度的结束点坐标值
        public Point m_AnglesEndPoint;

        //未封闭多边形的结束点坐标值
        public Point m_MultiLinesEndPoint;

        //创建新图位图 
        Bitmap m_bitmap = new Bitmap(1000, 1024);// 新图的宽高
        System.Drawing.Graphics g;

        //放大镜窗体
        MaganiferFrm m_MaganiferFrm = null;

        //MaganiferFrm _maganiferFrm = new MaganiferFrm();
        //在非画图时，鼠标按下时的坐标值
        public List<Point> m_MouseDonwPointAtNoneTypeList = new List<Point>();
        public Point m_MouseDonwPointAtNoneType;
        //在非画图时所选中的图形列表，仅存一个对象实例
        public List<GraphicsInterface> m_SelectedGraphicsList = new List<GraphicsInterface>();

        //鼠标点击处的位置到线的起点间的长度
        public int m_MousePressPosToLineStartLen;

        //鼠标点击处的位置到线的终点间的长度
        public int m_MousePressPosToLineEndLen;

        //两点间X轴方向的长度差
        public int deltaX;

        //两点间Y轴方向的长度差
        public int deltaY;

        //公用画笔
        public Pen m_SharePen = new Pen(Color.Red,4);

        //画笔的宽度
        public int m_PenWidth = 4;//默认为4

        //公用画刷
        public Brush m_ShareBrush = Brushes.Red;

        //新建一个系统内部使用的线对象，用于频繁使用，减少CPU开销
        public Lines m_TempLine = new Lines(0,new Point(0,0),new Point(1,1));

        //新建一个系统内部使用的箭头线段对象，用于频繁使用，减少CPU开销
        public Arrow m_TempArrow = new Arrow(0, new Point(0, 0), new Point(1, 1));

        //新建一个系统内部使用的箭头文本对象，用于频繁使用，减少CPU开销
        //public Fonts m_TempFonts = new Fonts(0, "", new Font("宋体", 15, FontStyle.Regular), new Point(1, 1));
        //定义一个箭头
        //修改箭头大小
        System.Drawing.Drawing2D.AdjustableArrowCap m_ShareLineCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5,5, true);

        //定义一个箭头专用画笔
        Pen m_ArrowPen = new Pen(Color.Red, 1);

        //提示对象
        ToolTip toolTip1 = new ToolTip();



        public AcqResultAnalizeFrm()
        {
            InitializeComponent();
            //g = Graphics.FromImage(m_bitmap);
            //m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            //m_SharePen.Color = Color.Red;         
        }

        private void AcqResultAnalizeFrm_Load(object sender, EventArgs e)
        {
            base.TitleLbl.Text = "图像分析";
            base.MaxBtn.Visible = false;
            //原始采集图片路径
            using (DataTable DtResult = DBHelperLib.DBHelper.QueryRecords("tb_Acquisitions", "OriginalPath", "AcquisitionID = " + this.m_AcqID))
            {              
                string _OriginalPathFile = DtResult.Rows[0]["OriginalPath"].ToString().Trim();
                this.m_OriginalBitmap = new Bitmap(_OriginalPathFile);
                this.AnalizePictrueBox.BackgroundImage = m_OriginalBitmap;
                this.OriginalPictrueBox.BackgroundImage = m_OriginalBitmap;
            }

            //    this.m_ResqultBitmap = new Bitmap(m_AcqResltFile);
            //this.AnalizePictrueBox.BackgroundImage = m_ResqultBitmap;
            //this.OriginalPictrueBox.BackgroundImage = m_ResqultBitmap;

            //加载采集ID对应的分析图形对象
            //1.加载线段对象
            DataTable dtLines = DBHelperLib.DBHelper.QueryRecords("tb_Graphics", "GraphicID,AcquisitionID,StartPoint,EndPoint,ObjType,PenWidth,PenColor", "AcquisitionID = " + this.m_AcqID + " And ObjType = 1" );
            if (dtLines.Rows.Count >0)
            {
                for (int r =0; r < dtLines.Rows.Count; r++)
                {
                    string[] startPointStr = dtLines.Rows[r]["StartPoint"].ToString().Split(':');//分割字符串起点
                    Point _startPiont = new Point(int.Parse(startPointStr[0].Trim()), int.Parse(startPointStr[1].Trim()));//还原起点
                    string[] endPointStr = dtLines.Rows[r]["EndPoint"].ToString().Split(':');//分割字符串起点
                    Point _endPont = new Point(int.Parse(endPointStr[0].Trim()), int.Parse(endPointStr[1].Trim()));//还原起点
                     //将线对象压入列表，保存下来
                    m_LinesList.Add(new Lines(UInt64.Parse(dtLines.Rows[r]["GraphicID"].ToString()), _startPiont, _endPont));
                }               
            }
            //2.加载箭头线段对象None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
            DataTable dtArrows = DBHelperLib.DBHelper.QueryRecords("tb_Graphics", "GraphicID,AcquisitionID,StartPoint,EndPoint,ObjType,PenWidth,PenColor", "AcquisitionID = " + this.m_AcqID + " And ObjType = 6");
            if (dtArrows.Rows.Count > 0)
            {
                for (int r = 0; r < dtArrows.Rows.Count; r++)
                {
                    string[] startPointStr = dtArrows.Rows[r]["StartPoint"].ToString().Split(':');//分割字符串起点
                    Point _startPiont = new Point(int.Parse(startPointStr[0].Trim()), int.Parse(startPointStr[1].Trim()));//还原起点
                    string[] endPointStr = dtArrows.Rows[r]["EndPoint"].ToString().Split(':');//分割字符串起点
                    Point _endPont = new Point(int.Parse(endPointStr[0].Trim()), int.Parse(endPointStr[1].Trim()));//还原起点
                                                                                                                   //将线对象压入列表，保存下来
                    m_ArrowList.Add(new Arrow(UInt64.Parse(dtArrows.Rows[r]["GraphicID"].ToString()), _startPiont, _endPont));
                }
            }

            //3.加载角对象None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
            DataTable dtAngles = DBHelperLib.DBHelper.QueryRecords("tb_Graphics", "GraphicID,AcquisitionID,Points,ObjType", "AcquisitionID = " + this.m_AcqID + " And ObjType = 3");
            if (dtAngles.Rows.Count > 0)
            {
                for (int r = 0; r < dtAngles.Rows.Count; r++)
                {
                    Point[] _getPointArray = this.GetPointArrayByStrArray(dtAngles.Rows[r]["Points"].ToString());
                   m_AnglesList.Add(new Angles(UInt64.Parse(dtAngles.Rows[r]["GraphicID"].ToString()), _getPointArray));
                }
            }

            //4.加载封闭多边形的对象None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
            DataTable dtPolygons = DBHelperLib.DBHelper.QueryRecords("tb_Graphics", "GraphicID,AcquisitionID,Points,ObjType", "AcquisitionID = " + this.m_AcqID + " And ObjType = 2");
            if (dtPolygons.Rows.Count > 0)
            {
                for (int r = 0; r < dtPolygons.Rows.Count; r++)
                {
                    Point[] _getPointArray = this.GetPointArrayByStrArray(dtPolygons.Rows[r]["Points"].ToString());
                    m_PolygonList.Add(new Polygons(UInt64.Parse(dtPolygons.Rows[r]["GraphicID"].ToString()), _getPointArray));
                }
            }

            //5.加载未封闭多边形的对象None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
            DataTable dtMultiLines = DBHelperLib.DBHelper.QueryRecords("tb_Graphics", "GraphicID,AcquisitionID,Points,ObjType", "AcquisitionID = " + this.m_AcqID + " And ObjType = 7");
            if (dtMultiLines.Rows.Count > 0)
            {
                for (int r = 0; r < dtMultiLines.Rows.Count; r++)
                {
                    Point[] _getPointArray = this.GetPointArrayByStrArray(dtMultiLines.Rows[r]["Points"].ToString());
                    m_MultiLinesList.Add(new MultiLines(UInt64.Parse(dtMultiLines.Rows[r]["GraphicID"].ToString()), _getPointArray));
                }
            }
            //6.加载字体的对象None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
            DataTable dtFonts = DBHelperLib.DBHelper.QueryRecords("tb_Graphics", "GraphicID,AcquisitionID,StartPoint,ObjType,FontText,FontSize,FontFamilyName,FontStyle", "AcquisitionID = " + this.m_AcqID + " And ObjType = 5");
            if (dtFonts.Rows.Count > 0)
            {
                for (int r = 0; r < dtFonts.Rows.Count; r++)
                {
                    string[] startPointStr = dtFonts.Rows[r]["StartPoint"].ToString().Split(':');//分割字符串起点
                    Point _startPiont = new Point(int.Parse(startPointStr[0].Trim()), int.Parse(startPointStr[1].Trim()));//还原起点
                    string _FontFamilyName = dtFonts.Rows[r]["FontFamilyName"].ToString();
                    float _FontSize = float.Parse(dtFonts.Rows[r]["FontSize"].ToString());
                    FontStyle _FontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), dtFonts.Rows[r]["FontStyle"].ToString());

                    Font _Font = new Font(_FontFamilyName, _FontSize, _FontStyle);
                    m_FontsList.Add(new Fonts(UInt64.Parse(dtFonts.Rows[r]["GraphicID"].ToString()), dtFonts.Rows[r]["FontText"].ToString(), _Font, _startPiont));
                }
            }
        }

        //根据点的字串形式获取点的数组
        public Point[] GetPointArrayByStrArray(string StrArray)
        {           
            string[] _PointStrArray = StrArray.Split(';');
            Point[] _PointArray = new Point[_PointStrArray.Count()];
            int index = -1;
            foreach (string PointStr in _PointStrArray)
            {
                ++index;
                string[] _PointPos = PointStr.Split(':');
                _PointArray[index] = new Point(int.Parse(_PointPos[0].Trim()),int.Parse(_PointPos[1].Trim()));    
            }
            return _PointArray;
        }

        private void DrawingPolygonBtn_Click(object sender, EventArgs e)
        {
            m_drawingTypeEnum = DrawingTypeEnum.Polygon;//修改画图类型为画多边形
            m_PolygonPointList.Clear();
            this.m_SelectedGraphicsList.Clear();//被选中的图像对象清空，当无效
        }

        private void DrawingFontBtn_Click(object sender, EventArgs e)
        {
            m_drawingTypeEnum = DrawingTypeEnum.Fonts;
            this.m_SelectedGraphicsList.Clear();//被选中的图像对象清空，当无效
            //FontsTextInputFrm m_FontsTextInputFrm = new FontsTextInputFrm();
            //m_FontsTextInputFrm.StartPosition = FormStartPosition.CenterScreen;
            //DialogResult m_DialogResult =  m_FontsTextInputFrm.ShowDialog();
            //if (m_DialogResult == DialogResult.OK)
            //{
            //this.m_FontTexts = m_FontsTextInputFrm.InputTextBox.Text;
            //}
        }

        private void DrawingTangleBtn_Click(object sender, EventArgs e)
        {
            m_drawingTypeEnum = DrawingTypeEnum.Angle;
            m_AnglesPointList.Clear();
            this.m_SelectedGraphicsList.Clear();//被选中的图像对象清空，当无效

        }

        private void AcqResultAnalizeFrm_MouseMove(object sender, MouseEventArgs e)
        {
            //this.TitleLbl.Text = string.Format("X={0},Y={1}", e.X, e.Y);
        }

        private void AnalizePictrueBox_MouseMove(object sender, MouseEventArgs e)
        {
            //this.TitleLbl.Text = string.Format("X={0},Y={1}", e.X, e.Y);
            m_LineEndPoint = new Point(e.X, e.Y);//记录鼠标move时刻的坐标值,将移动过程中的坐标作为线的终点来刷新           
            m_PolygonEndPoint = m_LineEndPoint;
            m_AnglesEndPoint = m_LineEndPoint;
            m_MultiLinesEndPoint = m_LineEndPoint;
            switch (m_drawingTypeEnum)
            {
                case DrawingTypeEnum.Line:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    this.AnalizePictrueBox.Invalidate();//鼠标移动过程中触发paint事件，重绘图形
                    break;
                case DrawingTypeEnum.Arrow:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    this.AnalizePictrueBox.Invalidate();//鼠标移动过程中触发paint事件，重绘图形
                    break;

                case DrawingTypeEnum.Fonts:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    break;

                case DrawingTypeEnum.Polygon:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    this.AnalizePictrueBox.Invalidate();
                    break;

                case DrawingTypeEnum.Angle:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    if (m_AnglesPointList.Count >=3)
                    {
                        break;
                    }
                    this.AnalizePictrueBox.Invalidate();
                    break;

                case DrawingTypeEnum.MultiLines:
                    this.AnalizePictrueBox.Invalidate();
                    break;

                case DrawingTypeEnum.None:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    //如选中的图形，只要鼠标在选中的图形中就改变鼠标形状；否则保持默认
                    if (m_SelectedGraphicsList.Count > 0)//如果已选中了某一个图形对象的话
                    {
                        GraphicsInterface _grahics = m_SelectedGraphicsList.ElementAt(0);//取一个对象出来
                        switch (_grahics.GraphicType)
                        {
                            //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow
                            case 1://line
                                Lines _selectLine = (Lines)_grahics;//拆箱，强制转换成线对象                               
                                if (_selectLine.IsContained(e.X, e.Y))
                                    this.Cursor = System.Windows.Forms.Cursors.Hand;
                                else
                                    this.Cursor = System.Windows.Forms.Cursors.Default;
                                break;
                            case 2://Polygon
                                Polygons _selectPolygons = (Polygons)_grahics;//拆箱，强制转换成多边形对象
                                if (_selectPolygons.IsContained(e.X, e.Y))
                                    this.Cursor = System.Windows.Forms.Cursors.Hand;
                                else
                                    this.Cursor = System.Windows.Forms.Cursors.Default;
                                break;
                            case 3://Angle
                                Angles _selectAngles = (Angles)_grahics;//拆箱，强制转换成角对象
                                if (_selectAngles.IsContained(e.X, e.Y))
                                    this.Cursor = System.Windows.Forms.Cursors.Hand;
                                else
                                    this.Cursor = System.Windows.Forms.Cursors.Default;
                                break;
                               
                            case 5://Fonts
                                Fonts _selectFonts = (Fonts)_grahics;//拆箱，强制转换成字体对象
                                _selectFonts.m_Graphics = this.CreateGraphics();
                                if (_selectFonts.IsContained(e.X, e.Y))
                                    this.Cursor = System.Windows.Forms.Cursors.Hand;
                                else
                                    this.Cursor = System.Windows.Forms.Cursors.Default;
                                break;
                            case 6://Arrow
                                Arrow _selectArrow = (Arrow)_grahics;//拆箱，强制转换成箭头对象                                                   
                                if (_selectArrow.IsContained(e.X, e.Y))
                                    this.Cursor = System.Windows.Forms.Cursors.Hand;
                                else
                                    this.Cursor = System.Windows.Forms.Cursors.Default;                              
                                break;
                            case 7://MultiLines
                                MultiLines _selectMultiLines = (MultiLines)_grahics;//拆箱，强制转换成未封闭多边形对象
                                if (_selectMultiLines.IsContained(e.X, e.Y))
                                    this.Cursor = System.Windows.Forms.Cursors.Hand;
                                else
                                    this.Cursor = System.Windows.Forms.Cursors.Default;
                                break;


                        }
                    }
                    else//没有选中任何图形时恢复鼠标形状
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }

                    if (e.Button == MouseButtons.Left)//在非画图时，鼠标按下时移动它
                    {
                        //Console.WriteLine(e.X.ToString() + ":" +  e.Y.ToString());
                        if (m_SelectedGraphicsList.Count > 0)//如果已选中了某一个图形对象的话
                        {
                            GraphicsInterface _grahics = m_SelectedGraphicsList.ElementAt(0);//取一个对象出来
                            switch (_grahics.GraphicType)
                            {
                                //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow
                                case 1://line
                                    Lines _selectLine = (Lines)_grahics;//拆箱，强制转换成线对象
                                    //判定点击处的坐标是否与线的起点重合
                                     m_MousePressPosToLineStartLen = GlobalTools.GetLengthBeteenTwoPoint(m_MouseDonwPointAtNoneType,_selectLine.m_StartPoint);
                                    if (m_MousePressPosToLineStartLen < 10)
                                    {
                                        //MessageBox.Show("选中的线的起点！");
                                        //用户选中了线的起点，准备移动鼠标
                                        //修改线的起点坐标值
                                        _selectLine.m_StartPoint.X = e.X;
                                        _selectLine.m_StartPoint.Y = e.Y;

                                        m_MouseDonwPointAtNoneType.X = e.X;
                                        m_MouseDonwPointAtNoneType.Y = e.Y;
                                        this.AnalizePictrueBox.Invalidate();//重绘
                                        break;
                                    }
                                    //判定点击处的坐标是否与线的终点重合
                                    m_MousePressPosToLineEndLen = GlobalTools.GetLengthBeteenTwoPoint(m_MouseDonwPointAtNoneType, _selectLine.m_EndPoint);
                                    if (m_MousePressPosToLineEndLen < 10)
                                    {
                                        //MessageBox.Show("选中的线的终点！");
                                        _selectLine.m_EndPoint.X = e.X;
                                        _selectLine.m_EndPoint.Y = e.Y;

                                        m_MouseDonwPointAtNoneType.X = e.X;
                                        m_MouseDonwPointAtNoneType.Y = e.Y;
                                        this.AnalizePictrueBox.Invalidate();//重绘
                                        break;
                                    }

                                    //以上两种情况都不是，即鼠标点击处在线的中间部分，鼠标移动时整体平移
                                     deltaX = e.X - m_MouseDonwPointAtNoneType.X;
                                     deltaY = e.Y - m_MouseDonwPointAtNoneType.Y;
                                    //更新线起点、终点的坐标
                                    _selectLine.m_EndPoint.X = _selectLine.m_EndPoint.X + deltaX;
                                    _selectLine.m_EndPoint.Y = _selectLine.m_EndPoint.Y + deltaY;

                                    _selectLine.m_StartPoint.X = _selectLine.m_StartPoint.X + deltaX;
                                    _selectLine.m_StartPoint.Y = _selectLine.m_StartPoint.Y + deltaY;

                                    m_MouseDonwPointAtNoneType.X = e.X;
                                    m_MouseDonwPointAtNoneType.Y = e.Y;

                                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                                    break;
                                case 2://Polygon
                                    Polygons _selectPolygons = (Polygons)_grahics;//拆箱，强制转换成多边形对象
                                    //判定点击处的坐标是否与多边形的任意一个点重合，如是，则说明用户想移动多边形的某一个点，而非整个多边形                                    
                                    for (int k = 0; k < _selectPolygons.m_PolygonPointArray.Count();k++)//遍历多边形中的每一个点
                                    {                                        
                                        m_MousePressPosToLineStartLen = GlobalTools.GetLengthBeteenTwoPoint(m_MouseDonwPointAtNoneType, _selectPolygons.m_PolygonPointArray[k]);
                                        if (m_MousePressPosToLineStartLen < 10)
                                        {
                                            //用户选中了多边形的一个点，准备移动鼠标
                                            //修改多边形中被选中点的坐标值
                                            _selectPolygons.m_PolygonPointArray[k].X = e.X;
                                            _selectPolygons.m_PolygonPointArray[k].Y = e.Y;
                                            m_MouseDonwPointAtNoneType.X = e.X;
                                            m_MouseDonwPointAtNoneType.Y = e.Y;
                                            this.AnalizePictrueBox.Invalidate();//重绘
                                            return;
                                        }
                                    }
                                    //以上情况都不是，即鼠标点击处在多边形线的中间部分，鼠标移动时整体平移
                                    deltaX = e.X - m_MouseDonwPointAtNoneType.X;
                                    deltaY = e.Y - m_MouseDonwPointAtNoneType.Y;
                                    for (int n = 0; n < _selectPolygons.m_PolygonPointArray.Count(); n++)//遍历多边形中的每一个点
                                    {                                                                      
                                        //更新边形每一个点的坐标                                    
                                        _selectPolygons.m_PolygonPointArray[n].X = _selectPolygons.m_PolygonPointArray[n].X + deltaX;
                                        _selectPolygons.m_PolygonPointArray[n].Y = _selectPolygons.m_PolygonPointArray[n].Y + deltaY;

                                        m_MouseDonwPointAtNoneType.X = e.X;
                                        m_MouseDonwPointAtNoneType.Y = e.Y;
                                        this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                                    }                                    
                                    break;

                                case 3://Angle
                                    Angles _selectAngles = (Angles)_grahics;//拆箱，强制转换成角对象
                                    //判定点击处的坐标是否与多边形的任意一个点重合，如是，则说明用户想移动角的某一个点，而非整个角                                    
                                    for (int k = 0; k < _selectAngles.m_AnglesPointArray.Count(); k++)//遍历角中的每一个点
                                    {
                                        m_MousePressPosToLineStartLen = GlobalTools.GetLengthBeteenTwoPoint(m_MouseDonwPointAtNoneType, _selectAngles.m_AnglesPointArray[k]);
                                        if (m_MousePressPosToLineStartLen < 10)
                                        {
                                            //用户选中了角的一个点，准备移动鼠标
                                            //修改角中被选中点的坐标值
                                            _selectAngles.m_AnglesPointArray[k].X = e.X;
                                            _selectAngles.m_AnglesPointArray[k].Y = e.Y;
                                            m_MouseDonwPointAtNoneType.X = e.X;
                                            m_MouseDonwPointAtNoneType.Y = e.Y;
                                            this.AnalizePictrueBox.Invalidate();//重绘
                                            return;
                                        }
                                    }
                                    //以情况都不是，即鼠标点击处在多边形线的中间部分，鼠标移动时整体平移
                                    deltaX = e.X - m_MouseDonwPointAtNoneType.X;
                                    deltaY = e.Y - m_MouseDonwPointAtNoneType.Y;
                                    for (int n = 0; n < _selectAngles.m_AnglesPointArray.Count(); n++)//遍历多边形中的每一个点
                                    {
                                        //更新角度每一个点的坐标                                    
                                        _selectAngles.m_AnglesPointArray[n].X = _selectAngles.m_AnglesPointArray[n].X + deltaX;
                                        _selectAngles.m_AnglesPointArray[n].Y = _selectAngles.m_AnglesPointArray[n].Y + deltaY;

                                        m_MouseDonwPointAtNoneType.X = e.X;
                                        m_MouseDonwPointAtNoneType.Y = e.Y;
                                        this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                                    }
                                    break;
                                case 5://fonts
                                    Fonts _selectFonts = (Fonts)_grahics;//拆箱，强制转换成字体对象
                                    deltaX = e.X - m_MouseDonwPointAtNoneType.X;
                                    deltaY = e.Y - m_MouseDonwPointAtNoneType.Y;
                                    //更新角度每一个点的坐标                                    
                                    _selectFonts.m_StartPoint.X = _selectFonts.m_StartPoint.X + deltaX;
                                    _selectFonts.m_StartPoint.Y = _selectFonts.m_StartPoint.Y + deltaY;

                                    m_MouseDonwPointAtNoneType.X = e.X;
                                    m_MouseDonwPointAtNoneType.Y = e.Y;
                                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形

                                    break;
                                case 6://Arrows
                                    Arrow _selectArrow = (Arrow)_grahics;//拆箱，强制转换成线对象
                                                                         //判定点击处的坐标是否与线的起点重合
                                    m_MousePressPosToLineStartLen = GlobalTools.GetLengthBeteenTwoPoint(m_MouseDonwPointAtNoneType, _selectArrow.m_StartPoint);
                                    if (m_MousePressPosToLineStartLen < 10)
                                    {
                                        //MessageBox.Show("选中的线的起点！");
                                        //用户选中了线的起点，准备移动鼠标
                                        //修改线的起点坐标值
                                        _selectArrow.m_StartPoint.X = e.X;
                                        _selectArrow.m_StartPoint.Y = e.Y;

                                        m_MouseDonwPointAtNoneType.X = e.X;
                                        m_MouseDonwPointAtNoneType.Y = e.Y;
                                        this.AnalizePictrueBox.Invalidate();//重绘
                                        break;
                                    }
                                    //判定点击处的坐标是否与线的终点重合
                                     m_MousePressPosToLineEndLen = GlobalTools.GetLengthBeteenTwoPoint(m_MouseDonwPointAtNoneType, _selectArrow.m_EndPoint);
                                    if (m_MousePressPosToLineEndLen < 10)
                                    {
                                        //MessageBox.Show("选中的线的终点！");
                                        _selectArrow.m_EndPoint.X = e.X;
                                        _selectArrow.m_EndPoint.Y = e.Y;

                                        m_MouseDonwPointAtNoneType.X = e.X;
                                        m_MouseDonwPointAtNoneType.Y = e.Y;
                                        this.AnalizePictrueBox.Invalidate();//重绘
                                        break;
                                    }

                                    //以上两种情况都不是，即鼠标点击处在线的中间部分，鼠标移动时整体平移
                                     deltaX = e.X - m_MouseDonwPointAtNoneType.X;
                                     deltaY = e.Y - m_MouseDonwPointAtNoneType.Y;
                                    //更新线起点、终点的坐标
                                    _selectArrow.m_EndPoint.X = _selectArrow.m_EndPoint.X + deltaX;
                                    _selectArrow.m_EndPoint.Y = _selectArrow.m_EndPoint.Y + deltaY;

                                    _selectArrow.m_StartPoint.X = _selectArrow.m_StartPoint.X + deltaX;
                                    _selectArrow.m_StartPoint.Y = _selectArrow.m_StartPoint.Y + deltaY;

                                    m_MouseDonwPointAtNoneType.X = e.X;
                                    m_MouseDonwPointAtNoneType.Y = e.Y;

                                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                                    break;
                                case 7://MultiLines
                                    MultiLines _selectMultiLines = (MultiLines)_grahics;//拆箱，强制转换成未封闭多边形对象
                                    //判定点击处的坐标是否与多边形的任意一个点重合，如是，则说明用户想移动角的某一个点，而非整个角                                    
                                    for (int k = 0; k < _selectMultiLines.m_MultiLinesPointArray.Count(); k++)//遍历角中的每一个点
                                    {
                                        m_MousePressPosToLineStartLen = GlobalTools.GetLengthBeteenTwoPoint(m_MouseDonwPointAtNoneType, _selectMultiLines.m_MultiLinesPointArray[k]);
                                        if (m_MousePressPosToLineStartLen < 10)
                                        {
                                            //用户选中了角的一个点，准备移动鼠标
                                            //修改角中被选中点的坐标值
                                            _selectMultiLines.m_MultiLinesPointArray[k].X = e.X;
                                            _selectMultiLines.m_MultiLinesPointArray[k].Y = e.Y;
                                            m_MouseDonwPointAtNoneType.X = e.X;
                                            m_MouseDonwPointAtNoneType.Y = e.Y;
                                            this.AnalizePictrueBox.Invalidate();//重绘
                                            return;
                                        }
                                    }
                                    //以情况都不是，即鼠标点击处在多边形线的中间部分，鼠标移动时整体平移
                                    deltaX = e.X - m_MouseDonwPointAtNoneType.X;
                                    deltaY = e.Y - m_MouseDonwPointAtNoneType.Y;
                                    for (int n = 0; n < _selectMultiLines.m_MultiLinesPointArray.Count(); n++)//遍历多边形中的每一个点
                                    {
                                        //更新角度每一个点的坐标                                    
                                        _selectMultiLines.m_MultiLinesPointArray[n].X = _selectMultiLines.m_MultiLinesPointArray[n].X + deltaX;
                                        _selectMultiLines.m_MultiLinesPointArray[n].Y = _selectMultiLines.m_MultiLinesPointArray[n].Y + deltaY;

                                        m_MouseDonwPointAtNoneType.X = e.X;
                                        m_MouseDonwPointAtNoneType.Y = e.Y;
                                        this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                                    }
                                    break;
                            }

                        }
                        
                    }
                        break;
                case DrawingTypeEnum.Maganifer:
                        //放大镜窗体所对应的内存位图
                        Bitmap m_PartBitMap = new Bitmap(400, 400);                    
                        Graphics m_g = Graphics.FromImage(m_PartBitMap);
                        m_g.DrawImage(m_bitmap, new Rectangle(0, 0, 400, 400), new Rectangle(e.X - 50, e.Y - 50, 100, 100), GraphicsUnit.Pixel);
                        m_MaganiferFrm.pictureBox1.Image = m_PartBitMap;                                                         
                    break;
            }            
          }

        /// <summary>
        /// 画线按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawingLineBtn_Click(object sender, EventArgs e)
        {
            m_drawingTypeEnum = DrawingTypeEnum.Line;//修改画图类型为画线
            this.m_LineStartPointList.Clear();//清除起点坐标点，等待首次按下时压入
            this.m_SelectedGraphicsList.Clear();//被选中的图像对象清空，当无效
        }

        private void DrawingArrowBtn_Click(object sender, EventArgs e)
        {
            m_drawingTypeEnum = DrawingTypeEnum.Arrow;//修改画图类型为画箭头
            this.m_LineStartPointList.Clear();//清除起点坐标点，等待首次按下时压入
            this.m_SelectedGraphicsList.Clear();//被选中的图像对象清空，当无效
        }

        private void DrawingMagniferBtn_Click(object sender, EventArgs e)
        {
            m_drawingTypeEnum = DrawingTypeEnum.Maganifer;//修改画图类型为画放大镜
            this.m_SelectedGraphicsList.Clear();//被选中的图像对象清空，当无效
            this.AnalizePictrueBox.DrawToBitmap(m_bitmap,new Rectangle(0,0,1000,1024));

            if (m_MaganiferFrm == null || m_MaganiferFrm.IsDisposed)
            {
                m_MaganiferFrm = new MaganiferFrm();
                m_MaganiferFrm.m_DrawingTypeEnum = this.m_drawingTypeEnum;//图形枚举作为参数传入放大镜窗体中
            }
            m_MaganiferFrm.Show();
        }

        //鼠标左键按下
        private void AnalizePictrueBox_MouseDown(object sender, MouseEventArgs e)
        {
            //this.m_SelectedGraphicsList.Clear();
            //鼠标单击左键       
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {            
                //判定用户所选择的画图类型
                switch (m_drawingTypeEnum)
                {
                    case DrawingTypeEnum.Line:
                        //MessageBox.Show(m_drawingTypeEnum.ToString());
                        if (m_LineStartPointList.Count == 0)
                        {
                            m_LineStartPointList.Add(new Point(e.X, e.Y));//首次按下的坐标为线的起点                           
                        } else
                        {
                            m_LineEndPoint = new Point(e.X, e.Y);//非首次按下的坐标为线的终点
                            this.AnalizePictrueBox.Invalidate();
                            //修改画图类型为NONE,防止鼠标在移动时一直跟着光标显示直线
                            m_drawingTypeEnum = DrawingTypeEnum.None;
                            //将线对象压入列表，保存下来
                            m_LinesList.Add(new Lines(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")), m_LineStartPointList.ElementAt(0),m_LineEndPoint));                           
                        }                                                                                        
                        break;
                    case DrawingTypeEnum.Arrow:
                        //MessageBox.Show(m_drawingTypeEnum.ToString());
                        if (m_LineStartPointList.Count == 0)
                        {
                            m_LineStartPointList.Add(new Point(e.X, e.Y));//首次按下的坐标为线的起点                           
                        }
                        else
                        {
                            m_LineEndPoint = new Point(e.X, e.Y);//非首次按下的坐标为线的终点
                            this.AnalizePictrueBox.Invalidate();
                            //修改画图类型为NONE,防止鼠标在移动时一直跟着光标显示直线
                            m_drawingTypeEnum = DrawingTypeEnum.None;
                            //将箭头对象压入列表，保存下来
                            m_ArrowList.Add(new Arrow(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")),m_LineStartPointList.ElementAt(0), m_LineEndPoint));
                        }
                        break;

                    case DrawingTypeEnum.Fonts:
                        //MessageBox.Show(m_drawingTypeEnum.ToString());
                        m_FontStartPoint = new Point(e.X, e.Y);//字体的开始位置
                        //SizeF sizeF = e.Graphics.MeasureString(m_FontTexts, new Font("arial", 14, FontStyle.Regular));

                        //Rectangle rect = new Rectangle(m_FontStartPoint.X, m_FontStartPoint.Y, (int)sizeF.Width, (int)sizeF.Height);
                        m_FontsList.Add(new Fonts(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")), m_FontTexts, new Font("arial", 14, FontStyle.Regular), m_FontStartPoint));
                        this.AnalizePictrueBox.Invalidate();                       

                        break;

                    case DrawingTypeEnum.Polygon:
                        //MessageBox.Show(m_drawingTypeEnum.ToString());
                        m_PolygonPointList.Add(new Point(e.X, e.Y));
                        this.AnalizePictrueBox.Invalidate();
                        break;

                    case DrawingTypeEnum.Angle:
                        //MessageBox.Show(m_drawingTypeEnum.ToString());
                        if (m_AnglesPointList.Count < 2)
                        {
                            m_AnglesPointList.Add(new Point(e.X, e.Y));
                            this.AnalizePictrueBox.Invalidate();
                        }
                        else if (m_AnglesPointList.Count == 2)
                        {
                            m_AnglesPointList.Add(new Point(e.X, e.Y));
                            //画完角度，保存到列表中
                            Angles m_Angles = new Angles(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")), m_AnglesPointList.ToArray());
                            m_AnglesList.Add(m_Angles);
                            this.AnalizePictrueBox.Invalidate();
                        }                                         
                        break;

                    case DrawingTypeEnum.None:
                        //MessageBox.Show(m_drawingTypeEnum.ToString());
                        //m_MouseDonwPointAtNoneTypeList.Clear();
                        //m_MouseDonwPointAtNoneTypeList.Add(new Point(e.X, e.Y));
                        //System.Threading.Thread.Sleep(10);
                        m_MouseDonwPointAtNoneType = new Point(e.X, e.Y);
                        this.AnalizePictrueBox.Invalidate();
                        break;
                    case DrawingTypeEnum.Maganifer:
                        //MessageBox.Show(m_drawingTypeEnum.ToString());
                        break;
                    case DrawingTypeEnum.MultiLines:
                        //MessageBox.Show(m_drawingTypeEnum.ToString());
                        m_MultiLinesPointList.Add(new Point(e.X, e.Y));
                        this.AnalizePictrueBox.Invalidate();
                        break;

                }
            }

            //鼠标右击
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                switch (m_drawingTypeEnum)
                {
                    case DrawingTypeEnum.Line:                        
                        break;
                    case DrawingTypeEnum.Arrow:                        
                        break;
                    case DrawingTypeEnum.Fonts:                     
                        break;
                    case DrawingTypeEnum.Polygon:
                        //保存多边形                       
                        //将多边形对象压入列表，保存下来
                        Polygons _savePolygon = new Polygons(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")), m_PolygonPointList.ToArray());
                        m_PolygonList.Add(_savePolygon);
                        //停止绘制实时刷新，转为保存后从内存读取出来刷新。
                        m_drawingTypeEnum = DrawingTypeEnum.None;
                        break;

                    case DrawingTypeEnum.Angle:
                      
                        break;

                    case DrawingTypeEnum.None:
                        //弹出修改对象的右键菜单
                        if (m_SelectedGraphicsList.Count <= 0) return;//如果没有图形被选中，则不弹出右击菜单
                        ContextMenuStrip m_GrahpicsMenu = new ContextMenuStrip();
                        //右键菜单加入一个删除选项
                        m_GrahpicsMenu.Items.Add("删除"); //添加一个删除菜单项                     
                        m_GrahpicsMenu.Items[0].Click += GrahpicsMenu_Click;//删除菜单功能
                        m_GrahpicsMenu.Show(this.AnalizePictrueBox,e.X,e.Y);//弹出右击菜单
                        break;
                    case DrawingTypeEnum.Maganifer:
                        
                        break;
                    case DrawingTypeEnum.MultiLines:
                        //保存多边形                       
                        //将多边形对象压入列表，保存下来
                        MultiLines _saveMultiLines = new MultiLines(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")), m_MultiLinesPointList.ToArray());
                        m_MultiLinesList.Add(_saveMultiLines);
                        //停止绘制实时刷新，转为保存后从内存读取出来刷新。
                        m_drawingTypeEnum = DrawingTypeEnum.None;
                        break;

                }
            }
            //鼠标双击
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //MessageBox.Show("DoubleClicked!");
                switch (m_drawingTypeEnum)
                {
                    case DrawingTypeEnum.Line:
                        break;
                    case DrawingTypeEnum.Arrow:
                        break;
                    case DrawingTypeEnum.Fonts:
                        break;
                    case DrawingTypeEnum.Polygon:                       
                        break;
                    case DrawingTypeEnum.Angle:
                        break;
                    case DrawingTypeEnum.None:
                        //修改字体内容
                        foreach (Fonts m_Fonts in m_FontsList)
                        {
                            m_Fonts.m_Graphics = this.AnalizePictrueBox.CreateGraphics();
                            if (m_Fonts.IsContained(e.X, e.Y))
                            {
                                TextFrm _TextFrm = new TextFrm();
                                Point _PicPoint = new Point(e.X, e.Y);
                               //注意：一定要将窗体的起点位置设置成手动，否则不会生效的
                                _TextFrm.StartPosition = System.Windows.Forms.FormStartPosition.Manual;                               
                                //（这里将双击处的位置装换成相对于屏幕的坐标再赋给子窗体）
                                _TextFrm.Left = this.AnalizePictrueBox.PointToScreen(new Point(e.X, e.Y)).X;
                                _TextFrm.Top = this.AnalizePictrueBox.PointToScreen(new Point(e.X, e.Y)).Y;
                                _TextFrm.ShowDialog();
                                if (_TextFrm.DialogResult == DialogResult.OK)
                                {
                                    if (_TextFrm.TextContext == "")//用户未输入任何内容
                                    {
                                        MessageBoxFrm.ShowMesg("输入为空！","提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                                        break;
                                    }
                                    m_Fonts.m_FontsText = _TextFrm.TextContext;
                                    this.AnalizePictrueBox.Invalidate();//重绘
                                }
                                break;
                            }
                           
                        }

                        break;
                    case DrawingTypeEnum.Maganifer:
                        break;
                }
            } 

       }

        /// <summary>
        /// 图形被选中后，右击弹出的“删除”菜单的功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrahpicsMenu_Click(object sender, EventArgs e)
        {
            if (m_SelectedGraphicsList.Count <= 0)
            {
                MessageBoxFrm.ShowMesg("你没有选中图形！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.WarnningIco);
                return;
            }
            //弹出确认删除消息框
            if (MessageBoxFrm.ShowMesg("确定要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxNewIco.QuestionIco) != DialogResult.OK) return;
            GraphicsInterface _grahics = m_SelectedGraphicsList.ElementAt(0);//取一个对象出来
            switch (_grahics.GraphicType)
            {
                //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow
                case 1://line
                    Lines _selectLine = (Lines)_grahics;//拆箱，强制转换成线对象
                    m_LinesList.Remove(_selectLine);//在内存列表中删除线对象
                    m_SelectedGraphicsList.Clear();//被选中的图形对象列表清空
                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                    break;
                case 2://Polygon
                    Polygons _selectPolygons = (Polygons)_grahics;//拆箱，强制转换成多边形对象
                    m_PolygonList.Remove(_selectPolygons);//在内存列表中删除多边形对象
                    m_SelectedGraphicsList.Clear();//被选中的图形对象列表清空
                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                    break;

                case 3://Angle
                    Angles _selectAngles = (Angles)_grahics;//拆箱，强制转换成角度对象
                    m_AnglesList.Remove(_selectAngles);//在内存列表中删除角对象
                    m_SelectedGraphicsList.Clear();//被选中的图形对象列表清空
                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                    break;
                case 5://fonts
                    Fonts _selectFonts = (Fonts)_grahics;//拆箱，强制转换成字体对象
                    m_FontsList.Remove(_selectFonts);//在内存列表中删除字体对象
                    m_SelectedGraphicsList.Clear();//被选中的图形对象列表清空
                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                    break;
                case 6://Arrows
                    Arrow _selectArrow = (Arrow)_grahics;//拆箱，强制转换成箭头对象
                    m_ArrowList.Remove(_selectArrow);//在内存列表中删除箭头对象
                    m_SelectedGraphicsList.Clear();//被选中的图形对象列表清空
                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                    break;
                case 7://MultiLines
                    MultiLines _selectMultiLines = (MultiLines)_grahics;//拆箱，强制转换成未封闭多边形对象
                    m_MultiLinesList.Remove(_selectMultiLines);//在内存列表中删除角对象
                    m_SelectedGraphicsList.Clear();//被选中的图形对象列表清空
                    this.AnalizePictrueBox.Invalidate();//重新绘制一次图形
                    break;
            }
        }
        /// <summary>
        /// Paint事件所执行的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalizePictrueBox_Paint(object sender, PaintEventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;//鼠标形状默认
            #region//首先刷新之前所画好的图形（这些图形保存在列表中）
            foreach (Lines m_Line in m_LinesList)
            {               
                m_Line.m_IsDrawDashFrame = false;//不画出虚线框
                m_Line.m_Graphics = e.Graphics;//画布句柄 
                m_Line.DrawingGraphics();//画线
            }
            foreach (Arrow m_Arrow in m_ArrowList)
            {
                ////带箭头的画笔                
                m_Arrow.m_Graphics = e.Graphics;
                m_Arrow.m_IsDrawDashFrame = false;//不画虚线框
                m_Arrow.DrawingGraphics();                
            }
            foreach (Fonts m_Fonts in m_FontsList)
            {
                //e.Graphics.DrawString(m_Fonts.m_FontsText, m_Fonts.m_Font, Brushes.Red, m_Fonts.m_StartPoint);
                m_Fonts.m_Graphics = e.Graphics;
                m_Fonts.m_IsDrawDashFrame = false;
                m_Fonts.DrawingGraphics();
            }
            //读取多边形列表对象来刷新显示
            foreach (Polygons m_Polygons in m_PolygonList)
            {
                m_Polygons.m_Graphics = e.Graphics;                
                m_Polygons.m_IsDrawDashFrame = false;
                m_Polygons.DrawingGraphics();
            }

            //读取未封闭多边形列表对象来刷新显示
            foreach (MultiLines m_MultiLines in m_MultiLinesList)
            {
                m_MultiLines.m_Graphics = e.Graphics;
                //this.m_SharePen.Color = Color.Red;
                //this.m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                //this.m_SharePen.Width = m_PenWidth;
                //m_MultiLines.m_Pen = this.m_SharePen;
                m_MultiLines.m_IsDrawDashFrame = false;
                m_MultiLines.DrawingGraphics();
            }
            //读取角度列表对象来刷新显示
            foreach (Angles m_Angles in m_AnglesList)
            {
                m_Angles.m_Graphics = e.Graphics;
                //this.m_SharePen.Color = Color.Red;
                //this.m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                //this.m_SharePen.Width = m_PenWidth;
                //m_Angles.m_Pen = this.m_SharePen;
                m_Angles.m_IsDrawDashFrame = false;
                m_Angles.DrawingGraphics();
            }
            #endregion

            #region//刷新当前正在绘制的图形（包括绘制过程图形）
            //判定用户所选择的画图类型
            switch (m_drawingTypeEnum)
            {
                case DrawingTypeEnum.Line:                    
                    if (this.m_LineStartPointList.Count != 1) return;//如果首次按下,则列表中有一个点，否则说明没有按下过鼠标左键      
                    //给临时使用的线对象m_TempLine赋值
                    m_TempLine.m_Graphics = e.Graphics;//画布句柄
                    m_TempLine.m_StartPoint = this.m_LineStartPointList.ElementAt(0);//线的起点赋值
                    m_TempLine.m_EndPoint = this.m_LineEndPoint;//线的终点赋值 
                    //m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//修改画笔属性
                    //m_SharePen.Color = Color.Red;
                    m_TempLine.m_IsDrawDashFrame = false;//不画出虚线框
                    //m_TempLine.m_Pen = m_SharePen;//画笔                 
                    //m_TempLine.m_Brush = Brushes.Red;//画刷
                    m_TempLine.DrawingGraphics();//画线条

                    break;
                case DrawingTypeEnum.Arrow:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    if (this.m_LineStartPointList.Count != 1) return;//如果首次按下,则列表中有一个点，否则说明没有按下过鼠标左键             
                    //带箭头的画笔
                    //m_ArrowPen.CustomEndCap = this.m_ShareLineCap;
                    //m_ArrowPen.CustomStartCap = this.m_ShareLineCap;
                    //m_ArrowPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//实线 
                    //m_ArrowPen.Color = Color.Red;//红色画笔
                    m_TempArrow.m_Graphics = e.Graphics;
                    m_TempArrow.m_StartPoint = this.m_LineStartPointList.ElementAt(0);//线的起点赋值
                    m_TempArrow.m_EndPoint = this.m_LineEndPoint;//线的终点赋值 
                    //m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//修改画笔属性
                    //m_SharePen.Color = Color.Red;
                    m_TempArrow.m_IsDrawDashFrame = false;//不画出虚线框
                    //m_TempArrow.m_Pen = m_SharePen;//画笔  
                    //m_TempArrow.redArrowPen = m_ArrowPen;//箭头画笔
                    //m_TempArrow.m_Brush = Brushes.Red;//画刷
                    m_TempArrow.DrawingGraphics();//画线条                  
  
                    break;
                case DrawingTypeEnum.Fonts:
                    
                    //Font _newFont = new Font("宋体", 14, FontStyle.Regular);
                    //Fonts m_TempFonts = new Fonts(0, this.m_FontTexts, _newFont,this.m_FontStartPoint);
                    //m_TempFonts.m_Graphics = e.Graphics;                   
                    //m_TempFonts.m_IsDrawDashFrame = false;
                    //m_TempFonts.DrawingGraphics();
                    m_drawingTypeEnum = DrawingTypeEnum.None;//仅刷新一次
                    break;

                case DrawingTypeEnum.Polygon:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    //Point[] myPointArray ={ new Point(0, 0), new Point(50, 30), new Point(30, 60) };
                    if (m_PolygonPointList.Count < 1) return;//如果没有2个点或以上，是不能画多边形
                    //Point[] myPointArray = m_PolygonPointList.ToArray();
                    Point[] myNewPointArray = new Point[m_PolygonPointList.Count + 1];
                    int i = -1;
                    foreach (Point PolygonPoint in m_PolygonPointList)
                    {
                        ++i;
                        myNewPointArray[i] = PolygonPoint;                                     
                    }
                    myNewPointArray[i+1] = this.m_PolygonEndPoint;//将鼠标移动时的坐标加入，给人感觉是实时显示
                    e.Graphics.DrawPolygon(new Pen(Color.Red,1), myNewPointArray);
                    break;

                case DrawingTypeEnum.MultiLines:                   
                    if (m_MultiLinesPointList.Count < 1) return;//如果没有2个点或以上，是不能画多边形             
                    Point[] myNewMultiLinesPointArray = new Point[m_MultiLinesPointList.Count + 1];
                    int m = -1;
                    foreach (Point MultiLinesPoint in m_MultiLinesPointList)
                    {
                        ++m;
                        myNewMultiLinesPointArray[m] = MultiLinesPoint;
                    }
                    myNewMultiLinesPointArray[m + 1] = this.m_MultiLinesEndPoint;//将鼠标移动时的坐标加入，给人感觉是实时显示
                    e.Graphics.DrawLines(new Pen(Color.Red, 1), myNewMultiLinesPointArray);
                    break;

                case DrawingTypeEnum.Angle:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    //Point[] LinesPointsArray = new Point[3] { new Point(100, 100), new Point(100, 200), new Point(200, 200) };
                    //e.Graphics.DrawLines(new Pen(Color.Red, 5), LinesPointsArray);
                    //double m_Angle = GlobalTools.GetAngle(new Point(100, 100), new Point(200, 200), new Point(10000, 200));
                    //Console.WriteLine(m_Angle.ToString());
                    if (m_AnglesPointList.Count < 1 ) return;//如果没有2个点或以上，是不能画角度
                    //Point[] myPointArray = m_PolygonPointList.ToArray();

                    if (m_AnglesPointList.Count <= 2)
                    {
                        Point[] myNewAnglePointArray = new Point[m_AnglesPointList.Count + 1];
                        int n = -1;
                        foreach (Point AnglesPoint in m_AnglesPointList)
                        {
                            ++n;
                            myNewAnglePointArray[n] = AnglesPoint;
                        }
                        myNewAnglePointArray[n + 1] = this.m_PolygonEndPoint;//将鼠标移动时的坐标加入，给人感觉是实时显示
                        e.Graphics.DrawLines(new Pen(Color.Red, 1), myNewAnglePointArray);
                    }
                    else if (m_AnglesPointList.Count == 3)//等于3个点时，代表角度已画完，停止实时刷新
                    {
                        e.Graphics.DrawLines(new Pen(Color.Red, 1), m_AnglesPointList.ToArray());
                        m_drawingTypeEnum = DrawingTypeEnum.None;//
                    }
                    
                    break;

                case DrawingTypeEnum.None:
                    //重绘用户所选中的图形对象
                    if (m_SelectedGraphicsList.Count > 0)//如果已选中了某一个图形对象的话
                    {
                        GraphicsInterface _grahics = m_SelectedGraphicsList.ElementAt(0);//取一个对象出来
                        switch (_grahics.GraphicType)
                        {
                            //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow
                            case 1://line
                                Lines _selectLine = (Lines)_grahics;//拆箱，强制转换成线对象                               
                                _selectLine.m_Graphics = e.Graphics;//画布句柄                           
                                //m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//修改画笔属性
                                //m_SharePen.Color = Color.White;
                                //m_SharePen.Width = this.m_PenWidth;
                                _selectLine.m_IsDrawDashFrame = true;//不画出虚线框
                                //_selectLine.m_Pen = m_SharePen;//画笔                 
                                //_selectLine.m_Brush = Brushes.White;//画刷
                                _selectLine.DrawingGraphics();//画线条    
                                break;
                            case 2://Polygon
                                Polygons _selectPolygons = (Polygons)_grahics;//拆箱，强制转换成多边形对象
                                _selectPolygons.m_Graphics = e.Graphics;
                                //this.m_SharePen.Color = Color.White;
                                //this.m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                                //this.m_SharePen.Width = m_PenWidth;
                                //_selectPolygons.m_Pen = this.m_SharePen;
                                _selectPolygons.m_IsDrawDashFrame = true;
                                _selectPolygons.DrawingGraphics();
                                break;
                            case 3://Angle
                                Angles _selectAngles = (Angles)_grahics;//拆箱，强制转换成角对象
                                _selectAngles.m_Graphics = e.Graphics;
                                //this.m_SharePen.Color = Color.White;//画选中色
                                //this.m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                                //this.m_SharePen.Width = m_PenWidth;
                                //_selectAngles.m_Pen = this.m_SharePen;
                                _selectAngles.m_IsDrawDashFrame = true;
                                _selectAngles.DrawingGraphics();
                                break;

                            case 5://Fonts
                                Fonts _selectFonts = (Fonts)_grahics;//拆箱，强制转换成字体对象
                                _selectFonts.m_Graphics = e.Graphics;
                                _selectFonts.m_IsDrawDashFrame = true;
                                _selectFonts.DrawingGraphics();
                                break;
                            case 6://Arrow
                                Arrow _selectArrow = (Arrow)_grahics;//拆箱，强制转换成箭头对象                                                   
                                //                                     //带箭头的画笔
                                //m_ArrowPen.CustomEndCap = this.m_ShareLineCap;
                                //m_ArrowPen.CustomStartCap = this.m_ShareLineCap;
                                //m_ArrowPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//实线 
                                //m_ArrowPen.Color = Color.White;//绿色画笔
                                _selectArrow.m_Graphics = e.Graphics;
                                //m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//修改画笔属性
                                //m_SharePen.Color = Color.White;
                                //m_SharePen.Width = this.m_PenWidth;
                                _selectArrow.m_IsDrawDashFrame = true; //不画出虚线框
                                //_selectArrow.m_Pen = m_SharePen;//画笔  
                                //_selectArrow.redArrowPen = m_ArrowPen;//箭头画笔
                                //_selectArrow.m_Brush = Brushes.White;//画刷
                                _selectArrow.DrawingGraphics();//画线箭头    
                                break;
                            case 7://MultiLines
                                MultiLines _selectMultiLines = (MultiLines)_grahics;//拆箱，强制转换成未封闭多边形对象
                                _selectMultiLines.m_Graphics = e.Graphics;
                                //this.m_SharePen.Color = Color.White;//画选中色
                                //this.m_SharePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                                //this.m_SharePen.Width = m_PenWidth;
                                //_selectMultiLines.m_Pen = this.m_SharePen;
                                _selectMultiLines.m_IsDrawDashFrame = true;
                                _selectMultiLines.DrawingGraphics();
                                break;
                        }
                    }

                    break;
                case DrawingTypeEnum.Maganifer:
                    //MessageBox.Show(m_drawingTypeEnum.ToString());
                    break;
            }
            #endregion           

        }

        private void MultiLinesBtn_Click(object sender, EventArgs e)
        {
            m_drawingTypeEnum = DrawingTypeEnum.MultiLines;
            m_MultiLinesPointList.Clear();
            this.m_SelectedGraphicsList.Clear();//被选中的图像对象清空，当无效
        }

        //在鼠标左击后弹起事件时，开始执行图像的选中操作
        private void AnalizePictrueBox_MouseUp(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(m_drawingTypeEnum.ToString());
            m_MouseDonwPointAtNoneType.X = e.X;
            m_MouseDonwPointAtNoneType.Y = e.Y;
            m_SelectedGraphicsList.Clear();//在查找是否有选中的图形对象前，选清空选中图形列表

            //如果用户选中了某条直线，则重新以另一种颜色绘制此直线
            foreach (Lines m_Line in m_LinesList)
            {               
                if (m_Line.IsContained(m_MouseDonwPointAtNoneType.X, (m_MouseDonwPointAtNoneType.Y)))
                {
                    m_SelectedGraphicsList.Clear();
                    m_SelectedGraphicsList.Add(m_Line);//将选中的图形对象压入列表中，以待后续处理                                           
                    this.AnalizePictrueBox.Invalidate();
                    return;
                }
            }
            //如果用户选中了某个箭头，则重新以另一种颜色绘制此箭头
            foreach (Arrow m_Arrow in m_ArrowList)
            {
                //if (m_Arrow.IsContained(m_MouseDonwPointAtNoneTypeList.ElementAt(0).X, m_MouseDonwPointAtNoneTypeList.ElementAt(0).Y))
                if (m_Arrow.IsContained(m_MouseDonwPointAtNoneType.X, m_MouseDonwPointAtNoneType.Y))
                {
                    m_SelectedGraphicsList.Clear();
                    m_SelectedGraphicsList.Add(m_Arrow);//将选中的图形对象压入列表中，以待后续处理                                                           
                    this.AnalizePictrueBox.Invalidate();
                    return;
                }
            }

            //如果用户选中了某个多边形，则重新以另一种颜色绘制此多边形
            foreach (Polygons m_Polygons in m_PolygonList)
            {
                //找出多边形中的每一条边（直线）,加载到多边形对应的线列表中
                //List<Lines> _PolygonAllLineList = new List<Lines>();//存放多边形的所有边
                for (int j = 0; j < m_Polygons.m_PolygonPointArray.Count(); j++)
                {
                    if (j == m_Polygons.m_PolygonPointArray.Count() - 1)//最后一个点要与第一个点组成一条线
                    {
                        Lines _PolygonLine = new Lines(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmssfff")), m_Polygons.m_PolygonPointArray[j], m_Polygons.m_PolygonPointArray[0]);
                        if (_PolygonLine.IsContained(m_MouseDonwPointAtNoneType.X, (m_MouseDonwPointAtNoneType.Y)))
                        {
                            m_SelectedGraphicsList.Clear();
                            m_SelectedGraphicsList.Add(m_Polygons);//将选中的图形对象压入列表中，以待后续处理                                  
                            this.AnalizePictrueBox.Invalidate();
                            return;
                        }
                    }
                    else//当前点与相邻的后一个点组成一条线
                    {
                        Lines _PolygonLine = new Lines(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmssfff")), m_Polygons.m_PolygonPointArray[j], m_Polygons.m_PolygonPointArray[j + 1]);
                        if (_PolygonLine.IsContained(m_MouseDonwPointAtNoneType.X, (m_MouseDonwPointAtNoneType.Y)))
                        {
                            m_SelectedGraphicsList.Clear();
                            m_SelectedGraphicsList.Add(m_Polygons);//将选中的图形对象压入列表中，以待后续处理                                    
                            this.AnalizePictrueBox.Invalidate();
                            return;
                        }
                    }
                }

                //如果没有选中多边形的某条边的话，再检测鼠标是否落入多边形的范围框内
                if (m_Polygons.IsContained(m_MouseDonwPointAtNoneType.X, m_MouseDonwPointAtNoneType.Y))
                {
                    m_SelectedGraphicsList.Clear();
                    m_SelectedGraphicsList.Add(m_Polygons);//将选中的图形对象压入列表中，以待后续处理 
                    this.AnalizePictrueBox.Invalidate();
                    return;
                }
            }

            //如果用户选中了某个未封闭多边形，则重新以另一种颜色绘制此角
            foreach (MultiLines m_MultiLines in m_MultiLinesList)
            {
                //找出角中的每一条边（直线）,加载到角对应的线列表中                       
                for (int j = 0; j < m_MultiLines.m_MultiLinesPointArray.Count() - 1; j++)
                {
                    //当前点与相邻的后一个点组成一条线                            
                    Lines _MultiLinesLine = new Lines(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmssfff")), m_MultiLines.m_MultiLinesPointArray[j], m_MultiLines.m_MultiLinesPointArray[j + 1]);
                    if (_MultiLinesLine.IsContained(m_MouseDonwPointAtNoneType.X, (m_MouseDonwPointAtNoneType.Y)))
                    {
                        m_SelectedGraphicsList.Clear();
                        m_SelectedGraphicsList.Add(m_MultiLines);//将选中的图形对象压入列表中，以待后续处理                                      
                        this.AnalizePictrueBox.Invalidate();
                        return;
                    }
                }
                //如果没有选中角度的某条边的话，再检测鼠标是否落入角度的范围框内
                if (m_MultiLines.IsContained(m_MouseDonwPointAtNoneType.X, m_MouseDonwPointAtNoneType.Y))
                {
                    m_SelectedGraphicsList.Clear();
                    m_SelectedGraphicsList.Add(m_MultiLines);//将选中的图形对象压入列表中，以待后续处理
                    this.AnalizePictrueBox.Invalidate();
                    return;
                }
            }

            //如果用户选中了某个角，则重新以另一种颜色绘制此角
            foreach (Angles m_Angles in m_AnglesList)
            {
                //找出角中的每一条边（直线）,加载到角对应的线列表中                       
                for (int j = 0; j < m_Angles.m_AnglesPointArray.Count() - 1; j++)
                {
                    //当前点与相邻的后一个点组成一条线                            
                    Lines _AnglesLine = new Lines(UInt64.Parse(DateTime.Now.ToString("yyyyMMddhhmmssfff")), m_Angles.m_AnglesPointArray[j], m_Angles.m_AnglesPointArray[j + 1]);
                    if (_AnglesLine.IsContained(m_MouseDonwPointAtNoneType.X, (m_MouseDonwPointAtNoneType.Y)))
                    {
                        m_SelectedGraphicsList.Clear();
                        m_SelectedGraphicsList.Add(m_Angles);//将选中的图形对象压入列表中，以待后续处理
                        this.AnalizePictrueBox.Invalidate();
                        return;
                    }
                }
                //如果没有选中角度的某条边的话，再检测鼠标是否落入角度的范围框内
                if (m_Angles.IsContained(m_MouseDonwPointAtNoneType.X, m_MouseDonwPointAtNoneType.Y))
                {
                    m_SelectedGraphicsList.Clear();
                    m_SelectedGraphicsList.Add(m_Angles);//将选中的图形对象压入列表中，以待后续处理
                    this.AnalizePictrueBox.Invalidate();
                    return;
                }
            }

            //用户是否选中的某个字体
            foreach (Fonts m_Fonts in m_FontsList)
            {
                m_Fonts.m_Graphics = this.AnalizePictrueBox.CreateGraphics();//用于计算文本长宽
                if (m_Fonts.IsContained(m_MouseDonwPointAtNoneType.X, m_MouseDonwPointAtNoneType.Y))
                {
                    m_SelectedGraphicsList.Clear();
                    m_SelectedGraphicsList.Add(m_Fonts);//将选中的图形对象压入列表中，以待后续处理,比如：移动、删除操作                           
                    this.AnalizePictrueBox.Invalidate();
                    return;
                }
            }
            //即使最后一个图形对象都没有选中的情况下，也要刷新一次图形，目的是去掉选中色
            //this.m_SelectedGraphicsList.Clear();//被选中的图像对象清空，当无效
            Console.WriteLine("this.m_SelectedGraphicsList.count:" + this.m_SelectedGraphicsList.Count);
            this.AnalizePictrueBox.Invalidate();
        }

        private void CurrentLineWidthSetBtn_Click(object sender, EventArgs e)
        {
            this.m_PenWidth++;
            if (this.m_PenWidth >= 10)
            {
                this.m_PenWidth = 1;
            }

            if (m_SelectedGraphicsList.Count > 0)//如果已选中了某一个图形对象的话
            {
                GraphicsInterface _grahics = m_SelectedGraphicsList.ElementAt(0);//取一个对象出来
                switch (_grahics.GraphicType)
                {
                    //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow
                    case 1://line
                        Lines _selectLine = (Lines)_grahics;//拆箱，强制转换成线对象                               
                        _selectLine.m_Pen.Width = this.m_PenWidth;
                        break;
                    case 2://Polygon
                        Polygons _selectPolygons = (Polygons)_grahics;//拆箱，强制转换成多边形对象
                        _selectPolygons.m_Pen.Width = this.m_PenWidth;
                        break;
                    case 3://Angle
                        Angles _selectAngles = (Angles)_grahics;//拆箱，强制转换成角对象
                        _selectAngles.m_Pen.Width = this.m_PenWidth;
                        break;

                    case 5://Fonts
                        Fonts _selectFonts = (Fonts)_grahics;//拆箱，强制转换成字体对象
                       
                        break;
                    case 6://Arrow
                        Arrow _selectArrow = (Arrow)_grahics;//拆箱，强制转换成箭头对象                                                   
                        _selectArrow.m_Pen.Width = this.m_PenWidth;
                        _selectArrow.redArrowPen.Width = this.m_PenWidth;
                        break;
                    case 7://MultiLines
                        MultiLines _selectMultiLines = (MultiLines)_grahics;//拆箱，强制转换成未封闭多边形对象
                        _selectMultiLines.m_Pen.Width = this.m_PenWidth;
                        break;
                }
            }




            this.AnalizePictrueBox.Invalidate();//清除图像后重画
        }

        private void CurrentDelBtn_Click(object sender, EventArgs e)
        {
            GrahpicsMenu_Click(sender, e);//调用删除菜单的功能
        }

        private void CurrentColorSetBtn_Click(object sender, EventArgs e)
        {

        }

        private void CurrentFontSetBtn_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 删除所有图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllDelBtn_Click(object sender, EventArgs e)
        {
            //弹出确认删除消息框
            if (MessageBoxFrm.ShowMesg("确定要全部删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxNewIco.QuestionIco) != DialogResult.OK) return;
            #region//删除之前所有画好的图形（这些图形保存在列表中）
            m_LinesList.Clear();
            m_ArrowList.Clear();
            m_FontsList.Clear();
            m_PolygonList.Clear();
            m_MultiLinesList.Clear();
            m_AnglesList.Clear();
            m_SelectedGraphicsList.Clear();//被选中的图像也同样要删除它
            #endregion

            //清除数据库中的所有图形
            //DBHelperLib.DBHelper.DeleteRecords("tb_Graphics", "AcquisitionID = " + this.m_AcqID);
            this.AnalizePictrueBox.Invalidate();//清除图像后重画


        }

        private void AllLineWidthBtn_Click(object sender, EventArgs e)
        {
            this.m_PenWidth++;
            if (this.m_PenWidth >= 10)
            {
                this.m_PenWidth = 1;
            }

            #region//所画好的图形的画笔宽度
            foreach (Lines m_Line in m_LinesList)
            {
                m_Line.m_Pen.Width = m_PenWidth;
            }
            foreach (Arrow m_Arrow in m_ArrowList)
            {
                ////带箭头的画笔                
                m_Arrow.m_Pen.Width = m_PenWidth;
                m_Arrow.redArrowPen.Width = m_PenWidth;
            }
            foreach (Fonts m_Fonts in m_FontsList)
            {
                //m_Arrow.m_Pen.Width = m_PenWidth;
            }
            //读取多边形列表对象来刷新显示
            foreach (Polygons m_Polygons in m_PolygonList)
            {
                m_Polygons.m_Pen.Width = m_PenWidth;
            }

            //读取未封闭多边形列表对象来刷新显示
            foreach (MultiLines m_MultiLines in m_MultiLinesList)
            {
                m_MultiLines.m_Pen.Width = m_PenWidth;
            }
            //读取角度列表对象来刷新显示
            foreach (Angles m_Angles in m_AnglesList)
            {
                m_Angles.m_Pen.Width = m_PenWidth;
            }
            #endregion
            this.AnalizePictrueBox.Invalidate();//清除图像后重画
        }

        private void DrawingLineBtn_MouseHover(object sender, EventArgs e)
        {           
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
            toolTip1.UseFading = true;
            toolTip1.Show("画线段", this.DrawingLineBtn);
        }

        private void DrawingPolygonBtn_MouseHover(object sender, EventArgs e)
        {

        }

        private void DrawingPolygonBtn_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
            toolTip1.UseFading = true;
            toolTip1.Show("画多边形", this.DrawingPolygonBtn);
        }

        private void DrawingFontBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
            toolTip1.UseFading = true;
            toolTip1.Show("画文字", this.DrawingFontBtn);
        }

        private void DrawingTangleBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
            toolTip1.UseFading = true;
            toolTip1.Show("画角度", this.DrawingTangleBtn);
        }

        private void DrawingArrowBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
            toolTip1.UseFading = true;
            toolTip1.Show("画箭头线段", this.DrawingArrowBtn);
        }

        private void MultiLinesBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
            toolTip1.UseFading = true;
            toolTip1.Show("画多线段", this.MultiLinesBtn);
        }

        private void DrawingMagniferBtn_MouseHover(object sender, EventArgs e)
        {
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
            toolTip1.UseFading = true;
            toolTip1.Show("放大镜", this.DrawingMagniferBtn);
        }

        /// <summary>
        /// 保存图形按钮执行方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //清空数据表中原来的旧图形（当然了，没有修改过的图形也会被清空，但数据量不大，不影响性能）
            //DBHelperLib.DBHelper.DeleteRecords("tb_Lines","AcquisitionID =" + this.m_AcqID.ToString());
            //DBHelperLib.DBHelper.DeleteRecords("tb_Arrows", "AcquisitionID =" + this.m_AcqID.ToString());
            //DBHelperLib.DBHelper.DeleteRecords("tb_MultiLines", "AcquisitionID =" + this.m_AcqID.ToString());
            //DBHelperLib.DBHelper.DeleteRecords("tb_Polygons", "AcquisitionID =" + this.m_AcqID.ToString());
            //DBHelperLib.DBHelper.DeleteRecords("tb_Fonts", "AcquisitionID =" + this.m_AcqID.ToString());
            //DBHelperLib.DBHelper.DeleteRecords("tb_Angles", "AcquisitionID =" + this.m_AcqID.ToString());

            DBHelperLib.DBHelper.DeleteRecords("tb_Graphics", "AcquisitionID =" + this.m_AcqID.ToString());


            #region//插入内存中所有的图形到数据库中
            foreach (Lines m_Line in m_LinesList)
            {               
                string _penColor = m_Line.m_Pen.Color.A.ToString() + ":" + m_Line.m_Pen.Color.R.ToString() + ":" + m_Line.m_Pen.Color.G.ToString() + ":" + m_Line.m_Pen.Color.B.ToString();
                string _tabName = "tb_Graphics";
                string _fields = "GraphicID,AcquisitionID,StartPoint,EndPoint,ObjType,PenWidth,PenColor";
                string _vals = m_Line.m_LinesID + "," + this.m_AcqID + ",'" + m_Line.m_StartPoint.X + ":" + m_Line.m_StartPoint.Y + "','" + m_Line.m_EndPoint.X + ":" + m_Line.m_EndPoint.Y + "'," + 1 + "," + m_Line.m_Pen.Width + ",'" + _penColor + "'";
                DBHelperLib.DBHelper.InsertRecords(_tabName,_fields,_vals);
            }
            foreach (Arrow m_Arrow in m_ArrowList)
            {
                //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
                string _penColor = m_Arrow.m_Pen.Color.A.ToString() + ":" + m_Arrow.m_Pen.Color.R.ToString() + ":" + m_Arrow.m_Pen.Color.G.ToString() + ":" + m_Arrow.m_Pen.Color.B.ToString();
                string _tabName = "tb_Graphics";
                string _fields = "GraphicID,AcquisitionID,StartPoint,EndPoint,ObjType,PenWidth,PenColor";
                string _vals = m_Arrow.m_ArrowID + "," + this.m_AcqID + ",'" + m_Arrow.m_StartPoint.X + ":" + m_Arrow.m_StartPoint.Y + "','" + m_Arrow.m_EndPoint.X + ":" + m_Arrow.m_EndPoint.Y + "'," + 6 + "," + m_Arrow.m_Pen.Width + ",'" + _penColor + "'";
                DBHelperLib.DBHelper.InsertRecords(_tabName, _fields, _vals);
            }
            foreach (Fonts m_Fonts in m_FontsList)
            {
                //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
                string _penColor = m_Fonts.m_Pen.Color.A.ToString() + ":" + m_Fonts.m_Pen.Color.R.ToString() + ":" + m_Fonts.m_Pen.Color.G.ToString() + ":" + m_Fonts.m_Pen.Color.B.ToString();
                string _tabName = "tb_Graphics";
                string _fields = "GraphicID,AcquisitionID,StartPoint,ObjType,PenWidth,PenColor,FontText,FontSize,FontFamilyName,FontStyle";
                string _vals = m_Fonts.m_FontsID + "," + this.m_AcqID + ",'" + m_Fonts.m_StartPoint.X + ":" + m_Fonts.m_StartPoint.Y + "',"  + 5 + "," + m_Fonts.m_Pen.Width + ",'" + _penColor + "','" + m_Fonts.m_FontsText +  "'," + m_Fonts.m_Font.Size + ",'" + m_Fonts.m_Font.FontFamily.Name + "','" + m_Fonts.m_Font.Style + "'";
                DBHelperLib.DBHelper.InsertRecords(_tabName, _fields, _vals);

            }
            //插入多边形列表对象
            foreach (Polygons m_Polygons in m_PolygonList)
            {
                //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
                string _penColor = m_Polygons.m_Pen.Color.A.ToString() + ":" + m_Polygons.m_Pen.Color.R.ToString() + ":" + m_Polygons.m_Pen.Color.G.ToString() + ":" + m_Polygons.m_Pen.Color.B.ToString();
                string _pointsStr = "";
                foreach (Point _point in m_Polygons.m_PolygonPointArray)
                {
                    _pointsStr = _pointsStr + _point.X + ":" + _point.Y + ";";//收集多边形的所有的点
                }
                _pointsStr = _pointsStr.TrimEnd(';');//去除最后一个分号
                string _tabName = "tb_Graphics";
                string _fields = "GraphicID,AcquisitionID,Points,ObjType,PenWidth,PenColor";
                string _vals = m_Polygons.m_PolygonID + "," + this.m_AcqID + ",'" + _pointsStr  + "'," + 2 + "," + m_Polygons.m_Pen.Width + ",'" + _penColor + "'";
                DBHelperLib.DBHelper.InsertRecords(_tabName, _fields, _vals);
            }

            //插入未封闭多边形列表对象
            foreach (MultiLines m_MultiLines in m_MultiLinesList)
            {
                //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
                string _penColor = m_MultiLines.m_Pen.Color.A.ToString() + ":" + m_MultiLines.m_Pen.Color.R.ToString() + ":" + m_MultiLines.m_Pen.Color.G.ToString() + ":" + m_MultiLines.m_Pen.Color.B.ToString();
                string _pointsStr = "";
                foreach (Point _point in m_MultiLines.m_MultiLinesPointArray)
                {
                    _pointsStr = _pointsStr + _point.X + ":" + _point.Y + ";";//收集多边形的所有的点
                }
                _pointsStr = _pointsStr.TrimEnd(';');//去除最后一个分号
                string _tabName = "tb_Graphics";
                string _fields = "GraphicID,AcquisitionID,Points,ObjType,PenWidth,PenColor";
                string _vals = m_MultiLines.m_MultiLinesID + "," + this.m_AcqID + ",'" + _pointsStr + "'," + 7 + "," + m_MultiLines.m_Pen.Width + ",'" + _penColor + "'";
                DBHelperLib.DBHelper.InsertRecords(_tabName, _fields, _vals);
            }
            //插入角度列表对象
            foreach (Angles m_Angles in m_AnglesList)
            {
                //None,Line,Polygon,Angle,Maganifer,Fonts,Arrow,MultiLines
                string _penColor = m_Angles.m_Pen.Color.A.ToString() + ":" + m_Angles.m_Pen.Color.R.ToString() + ":" + m_Angles.m_Pen.Color.G.ToString() + ":" + m_Angles.m_Pen.Color.B.ToString();
                string _pointsStr = "";
                foreach (Point _point in m_Angles.m_AnglesPointArray)
                {
                    _pointsStr = _pointsStr + _point.X + ":" + _point.Y + ";";//收集多边形的所有的点
                }
                _pointsStr = _pointsStr.TrimEnd(';');//去除最后一个分号
                string _tabName = "tb_Graphics";
                string _fields = "GraphicID,AcquisitionID,Points,ObjType,PenWidth,PenColor";
                string _vals = m_Angles.m_AnglesID + "," + this.m_AcqID + ",'" + _pointsStr + "'," + 3 + "," + m_Angles.m_Pen.Width + ",'" + _penColor + "'";
                DBHelperLib.DBHelper.InsertRecords(_tabName, _fields, _vals);
            }
            #endregion

           #region//重新保存分析结果为bitmap并刷新listview

            using (DataTable DtResult = DBHelperLib.DBHelper.QueryRecords("tb_Acquisitions", "ResultPath", "AcquisitionID = " + this.m_AcqID))
            {                
                string _Filepath = DtResult.Rows[0]["Resultpath"].ToString().Trim();              
                string m_NeedToDelImageName = _Filepath;//获取要被删除的图片文件名
                int m_DelFileIndexInList = -1;
                //清空listview原来加载的图片             
                foreach (Image _image in m_LoadAcqImagesFrm.imageList1.Images)
                {
                    _image.Dispose();//释放所有的图片对象
                }
                Bitmap _myBitMap = new Bitmap(1000, 1024);                
                //将绘图区的图拷贝到内存bitmap图片中
                this.AnalizePictrueBox.DrawToBitmap(_myBitMap, new Rectangle(0, 0, 1000, 1024));
                //清空listview原来加载的图片
                m_LoadAcqImagesFrm.listView1.Items.Clear();              
                m_LoadAcqImagesFrm.imageList1.Images.Clear();
                m_LoadAcqImagesFrm.imageLists.Remove(@m_NeedToDelImageName);
                System.GC.Collect();//强制回收垃圾，否则会报另一个进程正在使用此文件
                System.Threading.Thread.Sleep(1000);
                //删除原来的分析结果文件
                if (File.Exists(@m_NeedToDelImageName))
                {
                    FileInfo finfo = new FileInfo(@m_NeedToDelImageName);
                    try
                    {
                        if (finfo.Exists)
                        {
                            finfo.Attributes = FileAttributes.Archive;
                            File.Delete(@m_NeedToDelImageName);
                            //仅当文件被删除成功后才删除数据库中采集表中的记录
                            //string m_AcqID = Path.GetFileNameWithoutExtension(@m_NeedToDelImageName).Trim();//获取不含扩展名的文件名，即采集ID
                        }
                        //File.Delete(m_NeedToDelImageName);                  
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("文件被占用，请重新删除！");
                    }
                }
                //重新覆盖原料来的结果文件（.bmp)
                _myBitMap.Save(@_Filepath);
                //释放Bitmap
                _myBitMap.Dispose();
                //更新listview的图片展示
                this.m_LoadAcqImagesFrm.LoadImageFiles();//刷新一下显示的最近修改的图片                                
            }
            #endregion;
        }
    }
    }

