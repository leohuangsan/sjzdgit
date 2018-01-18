using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USB3WinApiSpace;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;
using ShareMemLib;
using OCTCalLib;
using Emgu.CV.UI;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using AveBitmapLib;
using System.Diagnostics;
using ConfigCPUCoreLib;
using UserControlsLib;
using System.Collections.Concurrent;
using LogLib;
using DBHelperLib;
using System.Drawing;
using SkinLib;


namespace SJZDEyes
{
    public enum snapEnum {WaittingSanp,InitializeOCTResoure,ReadUSB3Data,WriteBinaryFile,ReadBinaryFile,OCTCal,SaveBitmap,ReleaseOCTResource,AveBitmapCal,ShowBitmap }
    public partial class MainFrm : NewStyleFrm
    {
        //采集所放的目录 
        public static string m_AcqPath = "E:\\Acquistions\\";
        //医生登录ID
        public string m_LogDoctorID;
        //医生的用户名
        public string m_DoctorName;

        //刷新系统当前时间的线程
        System.Threading.Thread _ShowRealtimeThread;
        public MainFrm(string LogDoctorID,string DoctorName)
        {
            InitializeComponent();
            this.m_LogDoctorID = LogDoctorID;
            this.m_DoctorName = DoctorName;
            base.TitleLbl.Text = "欢迎使用眼科OCT系统!" + "    当前医生登录ID：" + LogDoctorID + "  医生用户名：" + DoctorName;
            base.MaxBtn.Enabled = false;
            base.MaxBtn.Visible = false;
            this.StartPosition = FormStartPosition.CenterScreen;       
            systemSettingControl1.SystemSettingBtn.Click += SystemSettingBtnClick;
            patientSearchControl1.PatientSearchBtn.Click += PatientSearchBtnClick;
            newPatientControl1.NewPatientBtn.Click += NewPatientBtnClick;
            newScanControl1.NewScanBtn.Click += NewScanBtn_Click;
            List<Object> m_NewSkinObjectList = new List<Object>();//需要换肤的窗体列表
            m_NewSkinObjectList.Add(this);            
            SkinLib.SkinFile.MadeNewSkinForControls(m_NewSkinObjectList);
            //初始时病人采集列表不可见
            this.PatientAcqTabControl.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.PatientAcqTabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainTabControl_MouseDown);
            _ShowRealtimeThread = new Thread(ShowNowTimeProc);
            _ShowRealtimeThread.IsBackground = true;
            //_ShowRealtimeThread.Start();
        }


        public void ShowNowTimeProc()
        {
            while (true)
            {
                this.BeginInvoke(new Action(() => { this.ShowTimeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); }));
                System.Threading.Thread.Sleep(100);
            }
            

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            //m_StartAcqFlg = true;////启动采集信号：false代表启动；ture代表停止
            ////启动采集线程，采集USB3相机数据
            // _ImageAcquredThread = new Thread(AcqureImageProc);
            //_ImageAcquredThread.IsBackground = true;
            ////_ImageAcquredThread.Priority = ThreadPriority.Highest;
            //_ImageAcquredThread.Start();

            ////启动OCT计算线程
            //_OCTCalThread = new Thread(OCTCalProc);
            //_OCTCalThread.Priority = ThreadPriority.Highest;
            //_OCTCalThread.IsBackground = true;
            //_OCTCalThread.Start();

            ////启动显示实时数据线程
            //_RealTimeShowThread = new Thread(RealTimeShowProc);
            //_RealTimeShowThread.IsBackground = true;
            //_RealTimeShowThread.Start();


            //m_ShowOneLineThread = new System.Threading.Thread(ChartShowOneLineProc);
            //m_ShowOneLineThread.IsBackground = true;
            //m_ShowOneLineThread.Start();
            //chartTimer.Enabled = true;//启动计算时器开始显示一条线的图形

            //this.button1.Enabled = false;
            //this.button2.Enabled = true;
            //this.button3.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //m_StartAcqFlg = false;//Set stop Flag and let image acquization stop
            //this.button1.Enabled = true;
            //this.button2.Enabled = false;
            //this.button3.Enabled = false;
            ////this.m_ShowOneLineThread.Abort();
            //chartTimer.Enabled = false;
            ////关闭采集线程，停止采集USB3相机数据      
            ////_ImageAcquredThread.Abort();

            ////关闭OCT计算线程          
            //_OCTCalThread.Abort();

            ////关闭显示实时数据线程     
            //_RealTimeShowThread.Abort();

        }
        private void AcquizationCntLbl_Click(object sender, EventArgs e)
        {

        }
        private void chartTimer_Tick(object sender, EventArgs e)
        {
            ////m_ShareMenInstace.Write(m_ImgRowColDataBytes, 0, 2048 * 1000 * 2);//Write share memory           
            //this.chart1.Series[0].Points.Clear();
            ////m_ImgRowColData
            //for (int lineNum = 0; lineNum < 1; lineNum++)
            //{
            //    for (int x = 0; x < 2048; x++)
            //    {
            //        this.chart1.Series[0].Points.AddY(m_ImgRowColData[lineNum * 2048 + x]);
            //    }
            //}
            //// Show the image information
            ////this.AcquizationCntLbl.Text = ulNBImageAcquired.ToString();
            ////this.ImageWidthLbl.Text = USB3WinAPI.ImageInfos.iImageWidth.ToString();
            ////this.ImageHeightLbl.Text = USB3WinAPI.ImageInfos.iImageHeight.ToString();
            ////this.ImagePixelTypeLbl.Text = USB3WinAPI.ImageInfos.eImagePixelType.ToString();
            ////this.ImageSizeLbl.Text = USB3WinAPI.ImageInfos.iImageSize.ToString();
            ////this.LinePitchLbl.Text = USB3WinAPI.ImageInfos.iLinePitch.ToString();
            ////this.OffsetXLbl.Text = USB3WinAPI.ImageInfos.iOffsetX.ToString();
            ////this.HorizontalFlipLbl.Text = USB3WinAPI.ImageInfos.iHorizontalFlip.ToString();
            ////this.MissedTriggersLbl.Text = USB3WinAPI.ImageInfos.iNbMissedTriggers.ToString();
            ////this.LineLostLbl.Text = USB3WinAPI.ImageInfos.iNbLineLost.ToString();
            ////this.ImageAcquiredLbl.Text = USB3WinAPI.ImageInfos.iNbImageAcquired.ToString();
            ////this.GrabbedLbl.Text = ulNBImageAcquired.ToString();
            //fpsgrabbedLblStr = (1000 / 8.33).ToString();
            //fpsgrabbedLblStr = fpsgrabbedLblStr.Substring(0, fpsgrabbedLblStr.IndexOf('.')) + fpsgrabbedLblStr.Substring(fpsgrabbedLblStr.IndexOf('.'), 3);
            //if (ulNBImageAcquired != 0)
            //{
            //    //this.fpsgrabbedLbl.Text = fpsgrabbedLblStr;
            //    //this.fpsdispLbl.Text = (1000 / this.chartTimer.Interval).ToString();
            //}
        }

        //private void ChartShowOneLineProc()
        //{
        //    while (true)
        //    {
        //        //Console.WriteLine("1:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
        //        //m_ShareMenInstace.Write(m_ImgRowColDataBytes,0,2048 * 1000 *2);//Write share memory               
        //        //Console.WriteLine("2:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
        //        //Show image in chart control          
        //        //this.chart1.Series[0].Points.Clear();
        //            this.BeginInvoke(new System.Action(() => {
        //            this.chart1.Series[0].Points.Clear();
        //            //m_ImgRowColData
        //            for (int lineNum = 0; lineNum < 1; lineNum++)
        //            {
        //                for (int x = 0; x < 2048; x++)
        //                {
        //                    this.chart1.Series[0].Points.AddY(m_ImgRowColData[lineNum * 2048 + x]);
        //                }
        //            }
        //            //this.AcquizationCntLbl.Text = ulNBImageAcquired.ToString();
        //            //this.ImageWidthLbl.Text = USB3WinAPI.ImageInfos.iImageWidth.ToString();
        //            //this.ImageHeightLbl.Text = USB3WinAPI.ImageInfos.iImageHeight.ToString();
        //            //this.ImagePixelTypeLbl.Text = USB3WinAPI.ImageInfos.eImagePixelType.ToString();
        //            //this.ImageSizeLbl.Text = USB3WinAPI.ImageInfos.iImageSize.ToString();
        //            //this.LinePitchLbl.Text = USB3WinAPI.ImageInfos.iLinePitch.ToString(); 
        //            //this.OffsetXLbl.Text = USB3WinAPI.ImageInfos.iOffsetX.ToString(); 
        //            //this.HorizontalFlipLbl.Text = USB3WinAPI.ImageInfos.iHorizontalFlip.ToString();
        //            //this.MissedTriggersLbl.Text = USB3WinAPI.ImageInfos.iNbMissedTriggers.ToString(); 
        //            //this.LineLostLbl.Text = USB3WinAPI.ImageInfos.iNbLineLost.ToString(); 
        //            //this.ImageAcquiredLbl.Text = USB3WinAPI.ImageInfos.iNbImageAcquired.ToString(); 
        //            //this.GrabbedLbl.Text = ulNBImageAcquired.ToString();
        //            fpsgrabbedLblStr = (1000 / 8.33).ToString();
        //            fpsgrabbedLblStr = fpsgrabbedLblStr.Substring(0, fpsgrabbedLblStr.IndexOf('.')) + fpsgrabbedLblStr.Substring(fpsgrabbedLblStr.IndexOf('.'), 3);
        //            if (ulNBImageAcquired != 0)
        //            {
        //                //this.fpsgrabbedLbl.Text = fpsgrabbedLblStr; 
        //                //this.fpsdispLbl.Text = (1000 / this.chartTimer.Interval).ToString();
        //            }
        //        }));       

        //        System.Threading.Thread.Sleep(10);

        //    }
            
        //}

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ShowRealtimeThread.Abort();//关闭显示时间的线程
            //if (m_StartAcqFlg)
            //{
            //    MessageBox.Show("Please stop image acquisition before closing this windows,Thanks!", "关闭提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    e.Cancel = true;//Cancel the closing for windows form            
            //}
            //else
            //{
            //    this.m_ShowOneLineThread.Abort();
            //}
        }
        /// <summary>
        /// Cemara Control setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //if (m_StartAcqFlg)
            //{
            //    CameraControlFrm m_CameraControlFrm = new CameraControlFrm(hCamera);
            //    m_CameraControlFrm.StartPosition = FormStartPosition.CenterParent;
            //    m_CameraControlFrm.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Camera is not opened,you can not control it!","提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        /// <summary>
        /// Save the image data,just for snap.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageDataSave_Click(object sender, EventArgs e)
        {
            //m_ImageDataBuilder.Clear();
            //for (int index = 0; index < 2048; index++)
            //{
            //    //m_ImageDataBuilder.Append(Convert.ToString(target[index], 2) + ",");//Change into Binary and save it by stringbuilder            
            //    m_ImageDataBuilder.Append(Convert.ToString(m_ImgRowColData[index], 2) + ",");//Change into Binary and save it by stringbuilder      
            //}
            ////Console.WriteLine(m_ImageDataBuilder.ToString().TrimEnd(','));
            //string m_FilePath = System.AppDomain.CurrentDomain.BaseDirectory  + @"imagedata.txt";
            //string m_WriteStr = m_ImageDataBuilder.ToString().TrimEnd(',');            
            // FileWrite(m_FilePath, m_WriteStr);//Save image data by file
            ////Console.WriteLine(FileRead(m_FilePath));
            ////System.Diagnostics.Process.Start("notepad.exe", m_FilePath);
            //MessageBox.Show("Image data is saved successfully!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        /// <summary>
        /// Use StreamReader to read txt data line by line
        /// </summary>
        /// <param name="path"></param>
        public string FileRead(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String m_readLineStr = "";
            //while ((m_readLineStr = sr.ReadLine()) != null)
            //{
            //    //Console.WriteLine(m_readLineStr.ToString());

            //}
            m_readLineStr = sr.ReadLine();
            return m_readLineStr;
        }
        /// <summary>
        /// Use StreamReader to write txt data line by line
        /// </summary>
        /// <param name="path"></param>
        public void FileWrite(string path,string writeStr)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //Start to write data
            sw.Write(writeStr);
            //Clear buffer
            sw.Flush();
            //Close Stream
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// Show image data by widnows form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageDataViewBtn_Click(object sender, EventArgs e)
        {
            //ShowImageDataFrm m_ShowImageDataFrm = ShowImageDataFrm.GetInstance();//Get ShowImageDataFrm's single instance
            //string m_ShowData = FileRead(m_FilePath);
            //m_ShowImageDataFrm.textBox1.Clear();//Clear listbox.
            //m_ShowImageDataFrm.textBox1.Text = m_ShowData;
            //m_ShowImageDataFrm.StartPosition = FormStartPosition.CenterParent;
            //m_ShowImageDataFrm.Activate();
            //m_ShowImageDataFrm.Show();
        }

        private void ShowAllLinesBtn_Click(object sender, EventArgs e)
        {
            //ShowAllLinesFrm m_ShowAllLinesFrm = new ShowAllLinesFrm();
            //m_ShowAllLinesFrm.Show();

            //TestShowFrm m_ShowAllLinesFrm = new TestShowFrm();
            //m_ShowAllLinesFrm.Show();

            //bool flag = false;
            //string mutexName = "Global\\" + "ShowLines";
            //using (mutex = new System.Threading.Mutex(true, mutexName, out flag))
            //{
            //    //第一个参数:true--给调用线程赋予互斥体的初始所属权  
            //    //第一个参数:互斥体的名称  
            //    //第三个参数:返回值,如果调用线程已被授予互斥体的初始所属权,则返回true  
            //    if (!flag)
            //    {
            //        //MessageBox.Show("ShowLines Form is running！", "请确定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
            //    }
            //    else
            //    {
            //        //MessageBox.Show("ShowLines Form is not running！", "请确定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        string path = System.AppDomain.CurrentDomain.BaseDirectory;
            //        Console.WriteLine(path);
            //        //System.Diagnostics.Process.Start(@"E:\SJZD-ele\SJZDProject2017120701-opencv\SJZDEyes\ShowAllLines\bin\Debug\" + "ShowAllLines.exe");
            //    }
            //}           
        }

        /// <summary>
        /// 载图按钮，已改为存储数据，不用此按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnapBtn_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread m_snapThrad = new Thread(doSnapShotProc);
            //m_snapThrad.IsBackground = true;
            //m_snapThrad.Start();


        }   
        private void NewPatientBtn_Click(object sender, EventArgs e)
        {
            //NewPatientFrm m_NewPatientFrm = new NewPatientFrm(this.PatientAcqTabControl, m_AcqPath);
            //m_NewPatientFrm.StartPosition = FormStartPosition.CenterScreen;
            //m_NewPatientFrm.ShowDialog();
        }
        private void NewPatientBtnClick(object sender, EventArgs e)
        {
            NewPatientFrm m_NewPatientFrm = new NewPatientFrm(this.PatientAcqTabControl, m_AcqPath);
            m_NewPatientFrm.StartPosition = FormStartPosition.CenterScreen;
            m_NewPatientFrm.ShowDialog();
        }
        private void SearchPatientBtn_Click(object sender, EventArgs e)
        {
            //SearchPatientFrm m_SearchPatientFrm = new SearchPatientFrm(this.PatientAcqTabControl,m_AcqPath);
            //m_SearchPatientFrm.StartPosition = FormStartPosition.CenterScreen;
            //m_SearchPatientFrm.ShowDialog();
        }
        private void PatientSearchBtnClick(object sender, EventArgs e)
        {
            SearchPatientFrm m_SearchPatientFrm = new SearchPatientFrm(this.PatientAcqTabControl, m_AcqPath);
            m_SearchPatientFrm.StartPosition = FormStartPosition.CenterScreen;
            m_SearchPatientFrm.ShowDialog();
        }

        private void PatientAcqTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void PatientAcqTabControl_Selected(object sender, TabControlEventArgs e)
        {
            
        }

        private void MainFrm_Paint(object sender, PaintEventArgs e)
        {
                      
        }

        private void PatientAcqTabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            
        }
        const int CLOSE_SIZE = 25;
        //点击，新增tabpage都会触发DrawItem事件
        private void PatientAcqTabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
           
            //MessageBox.Show((this.PatientAcqTabControl.TabPages.Count - 1).ToString());
            SolidBrush m_Brush = new SolidBrush(Color.Black);
            Font tabFont = new Font(e.Font, FontStyle.Bold);
            StringFormat tabSFT = new StringFormat();
            Rectangle tabRect = new Rectangle(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width - 10, e.Bounds.Height - 4);
            //选中TAB，改变背景色
            for (int i = 0; i < this.PatientAcqTabControl.TabPages.Count; i++)
            {               
                if (this.PatientAcqTabControl.SelectedIndex == i)
                {
                    Rectangle m_currentTabRect = this.PatientAcqTabControl.GetTabRect(i);                    
                    ////sizemode 设置成 fixed才能设置tab  的高宽                   
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), m_currentTabRect);//填充背景色
                    e.Graphics.DrawRectangle(Pens.Red, m_currentTabRect);//画边框 
                }
                else
                {
                    Rectangle m_currentTabRect = this.PatientAcqTabControl.GetTabRect(i);                    
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), m_currentTabRect);                   
                    e.Graphics.DrawRectangle(Pens.Red, m_currentTabRect);
                }
                //写上字体，如：姓名、ID
                e.Graphics.DrawString(this.PatientAcqTabControl.TabPages[i].Text, new Font("宋体", 16), m_Brush, this.PatientAcqTabControl.GetTabRect(i), tabSFT);

                //画关闭按钮
                try
                {
                    Rectangle myTabRect = this.PatientAcqTabControl.GetTabRect(i);
                    //先添加TabPage属性   
                    //e.Graphics.DrawString(this.PatientAcqTabControl.TabPages[e.Index].Text, this.Font, SystemBrushes.ControlText, myTabRect.X + 2, myTabRect.Y + 2);

                    //再画一个矩形框
                    using (Pen p = new Pen(Color.White))
                    {
                        myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                        myTabRect.Width = CLOSE_SIZE;
                        myTabRect.Height = CLOSE_SIZE;
                        e.Graphics.DrawRectangle(p, myTabRect);
                    }
                    //填充矩形框
                    Color recColor = e.State == DrawItemState.Selected ? Color.White : Color.White;
                    using (Brush b = new SolidBrush(recColor))
                    {
                        e.Graphics.FillRectangle(b, myTabRect);
                    }
                    //画关闭符号
                    using (Pen objpen = new Pen(Color.Black))
                    {
                        ////=============================================
                        //自己画X
                        ////"\"线
                        Point p1 = new Point(myTabRect.X + 3, myTabRect.Y + 3);
                        Point p2 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + myTabRect.Height - 3);
                        e.Graphics.DrawLine(objpen, p1, p2);
                        ////"/"线
                        Point p3 = new Point(myTabRect.X + 3, myTabRect.Y + myTabRect.Height - 3);
                        Point p4 = new Point(myTabRect.X + myTabRect.Width - 3, myTabRect.Y + 3);
                        e.Graphics.DrawLine(objpen, p3, p4);

                        ////=============================================
                        //使用图片
                        //Bitmap bt = new Bitmap(image);
                        //Point p5 = new Point(myTabRect.X, 4);
                        //e.Graphics.DrawImage(bt, p5);
                        //e.Graphics.DrawString(this.MainTabControl.TabPages[e.Index].Text, this.Font, objpen.Brush, p5);
                    }
                    //e.Graphics.Dispose();
           

                }
                catch (Exception)
                { }
            }
        }

        //关闭按钮功能
        private void MainTabControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X, y = e.Y;
                //计算关闭区域   
                Rectangle myTabRect = this.PatientAcqTabControl.GetTabRect(this.PatientAcqTabControl.SelectedIndex);

                myTabRect.Offset(myTabRect.Width - (CLOSE_SIZE + 3), 2);
                myTabRect.Width = CLOSE_SIZE;
                myTabRect.Height = CLOSE_SIZE;

                //如果鼠标在区域内就关闭选项卡   
                bool isClose = x > myTabRect.X && x < myTabRect.Right && y > myTabRect.Y && y < myTabRect.Bottom;
                if (isClose == true)
                {
                    //DialogResult drt = MessageBox.Show("确定关闭吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    DialogResult drt = MessageBoxFrm.ShowMesg("确定关闭吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxNewIco.QuestionIco);

                    if (drt == DialogResult.OK)
                    this.PatientAcqTabControl.TabPages.Remove(this.PatientAcqTabControl.SelectedTab);

                    if (this.PatientAcqTabControl.TabPages.Count <= 0)
                    {
                        this.PatientAcqTabControl.Visible = false; //控件可见
                    }
                }
            }
        }

        private void NewAqcuistionBtn_Click(object sender, EventArgs e)
        {
            //if (this.PatientAcqTabControl.SelectedIndex < 0)
            //{
            //    MessageBox.Show("没有选中病人，请重新操作！");
            //    return;
            //}
            //if (m_StartAcqFlg == true)
            //{
            //    //MessageBox.Show("正在采集中！");               
            //}
            //else
            //{
            //    //启动采集信号：true代表启动；false代表停止  
            //    m_StartAcqFlg = true;
            //    this.StateTextBox.Text = "正在采集中...";
            //    //启动采集线程，采集USB3相机数据
            //    _ImageAcquredThread = new Thread(AcqureImageProc);
            //    _ImageAcquredThread.IsBackground = true;
            //    //_ImageAcquredThread.Priority = ThreadPriority.Highest;
            //    _ImageAcquredThread.Start();
            //}
            ////this.tabPage2.Show();
            ////tabControl1.SelectedIndex = 2;
            //string[] m_NamePatientIDArray = this.PatientAcqTabControl.TabPages[this.PatientAcqTabControl.SelectedIndex].Name.Split(';');
            //this.NameTextBox.Text = m_NamePatientIDArray[0];
            //this.PatientIDTextBox.Text = m_NamePatientIDArray[1];
        }

        private void StateLbl_Click(object sender, EventArgs e)
        {

        }

        private void StateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void StopAcqBtn_Click(object sender, EventArgs e)
        {
            //DialogResult m_dialogResult = MessageBox.Show("确定停止采集吗？","提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (m_dialogResult == DialogResult.Cancel) return;
            //m_StartAcqFlg = false;//关闭采集线程，停止采集USB3相机数据   
            //this.StateTextBox.Text = "采集结束...";
            //this.button1.Enabled = true;
            //this.button2.Enabled = false;
            //this.button3.Enabled = false;
            ////this.m_ShowOneLineThread.Abort();
            //chartTimer.Enabled = false;
            ////关闭采集线程，停止采集USB3相机数据      
            ////_ImageAcquredThread.Abort();

            ////关闭OCT计算线程          
            ////_OCTCalThread.Abort();

            ////关闭显示实时数据线程     
            ////_RealTimeShowThread.Abort();
        }

        private void SaveImageDataBtn_Click(object sender, EventArgs e)
        {
            ////如果没有启动采集，则不进行采集，通知用户
            //if (!StateTextBox.Text.Contains("采集中"))
            //{
            //    MessageBox.Show("对不起，系统未启动采集功能，请先启动采集！","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //m_SaveDataPressFlg = true;//启动截图，即存储数据
        }

        private void NameLbl_Click(object sender, EventArgs e)
        {

        }

        private void ParameterSettingBtn_Click(object sender, EventArgs e)
        {
            //SystemSettingFrm m_SystemSettingFrm = new SystemSettingFrm();
            //m_SystemSettingFrm.m_MainFrm = this;//传入主窗体引用
            //m_SystemSettingFrm.Text = "系统设置";

            //m_SystemSettingFrm.StartPosition = FormStartPosition.CenterScreen;
            //m_SystemSettingFrm.ShowDialog();
        }
        private void SystemSettingBtnClick(object sender, EventArgs e)
        {
            this.systemSettingControl1.SystemSettingBtn.ForeColor = Color.Yellow;

            SystemSettingFrm m_SystemSettingFrm = new SystemSettingFrm();
            m_SystemSettingFrm.m_MainFrm = this;//传入主窗体引用
            m_SystemSettingFrm.Text = "系统设置";

            m_SystemSettingFrm.StartPosition = FormStartPosition.CenterScreen;
            m_SystemSettingFrm.ShowDialog();
        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
        private void UserControlStartCoustomBtnClick(object sender, EventArgs e)
        {
            chartTimer.Enabled = true;//启动计算时器开始显示一条线的图形
        }
        private void UserControlStopCoustomBtnClick(object sender, EventArgs e)
        {
            chartTimer.Enabled = false;//停止计算时器开始显示一条线的图形
        }
        private void StartFirtLineBtn_Click(object sender, EventArgs e)
        {
            chartTimer.Enabled = true;//启动计算时器开始显示一条线的图形
        }

        private void EndFirtLineBtn_Click(object sender, EventArgs e)
        {
            chartTimer.Enabled = false;//停止计算时器开始显示一条线的图形
        }
       /// <summary>
       /// 启动采集
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void StartAcqBtn_Click(object sender, EventArgs e)
        {
            //if (this.PatientAcqTabControl.SelectedIndex < 0 || PatientIDTextBox.Text =="")
            //{
            //    MessageBox.Show("没有选中病人，请重新操作！");
            //    return;
            //}
            //if (m_StartAcqFlg == true)
            //{
            //    //MessageBox.Show("正在采集中！");               
            //}
            //else
            //{
            //    //启动采集信号：true代表启动；false代表停止  
            //    m_StartAcqFlg = true;
            //    this.StateTextBox.Text = "正在采集中...";
            //    //启动采集线程，采集USB3相机数据
            //    _ImageAcquredThread = new Thread(AcqureImageProc);
            //    _ImageAcquredThread.IsBackground = true;
            //    //_ImageAcquredThread.Priority = ThreadPriority.Highest;
            //    _ImageAcquredThread.Start();
            //}
            ////this.tabPage2.Show();
            ////tabControl1.SelectedIndex = 2;
            //string[] m_NamePatientIDArray = this.PatientAcqTabControl.TabPages[this.PatientAcqTabControl.SelectedIndex].Name.Split(';');
            //this.NameTextBox.Text = m_NamePatientIDArray[0];
            //this.PatientIDTextBox.Text = m_NamePatientIDArray[1];
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Brush brush = new SolidBrush(Color.Transparent);
            //Font font = new Font("新宋体", 11);
            ////g.DrawString("XXX", font, brush, 50, 50);
            //g.DrawImage();
            //brush.Dispose();
            //font.Dispose();
        }


        private void NewScanBtn_Click(object sender, EventArgs e)
        {
            if (this.PatientAcqTabControl.SelectedIndex < 0 || this.PatientAcqTabControl.TabPages.Count <= 0)
            {
                //MessageBox.Show("没有选中病人，请重新操作！");
                MessageBoxFrm.ShowMesg("没有选中病人，请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            NewScanFrm m_NewScanFrm = new NewScanFrm();
            string[] m_NamePatientIDArray = this.PatientAcqTabControl.TabPages[this.PatientAcqTabControl.SelectedIndex].Name.Split(';');
            m_NewScanFrm.m_PatientName = m_NamePatientIDArray[0];//姓名
            m_NewScanFrm.m_PatientID = UInt64.Parse(m_NamePatientIDArray[1].Trim());//病人ID
            m_NewScanFrm.m_LogDoctorID = this.m_LogDoctorID;//诊断医生ID
            m_NewScanFrm.m_DoctorName = this.m_DoctorName;//诊断医生用户名
            m_NewScanFrm.m_MainFrm = this;//主窗体的引用
            m_NewScanFrm.StartPosition = FormStartPosition.CenterScreen;
            m_NewScanFrm.ShowDialog();
        }

        private void newPatientControl1_Load(object sender, EventArgs e)
        {

        }

        private void patientSearchControl1_Load(object sender, EventArgs e)
        {

        }

        private void newScanControl1_Load(object sender, EventArgs e)
        {

        }

        private void systemSettingControl1_Load(object sender, EventArgs e)
        {

        }

        private void NewPatientLbl_Click(object sender, EventArgs e)
        {
            NewPatientBtnClick(sender, e);
        }

        private void SearchPatientLbl_Click(object sender, EventArgs e)
        {
            PatientSearchBtnClick(sender, e);
        }

        private void NewScanLbl_Click(object sender, EventArgs e)
        {
            NewScanBtn_Click(sender, e);
        }

        private void SystemSettingLbl_Click(object sender, EventArgs e)
        {
            SystemSettingBtnClick(sender,e);
        }

        private void newScanControl1_MouseEnter(object sender, EventArgs e)
        {
            //this.newScanControl1.NewScanBtn.ForeColor = Color.Yellow;
        }

        private void FirstLineShowBtn_Click(object sender, EventArgs e)
        {
            FirstLineShowFrm m_FirstLineShowFrm = new FirstLineShowFrm();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
