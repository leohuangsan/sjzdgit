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
using SkinLib;
using GlobalToolSpace;


namespace SJZDEyes
{
    public partial class NewScanFrm : NewStyleFrm
    {
        //医生登录ID
        public string m_LogDoctorID;

        //医生的用户名
        public string m_DoctorName;

        //病人ID
        public UInt64 m_PatientID = 0;

        //病人姓名
        public string m_PatientName = "";

        //主窗体的引用
        public MainFrm m_MainFrm = null;

        //采集信号启动、停止标志：false代表启动；ture代表停止
        public static bool m_StartAcqFlg = false;

        //【缓存地址一(16bits)】=>m_ImgRowColData,This is the image data array,it is the key data for us to acquire.
        public static short[] m_ImgRowColData = new short[2048 * 1000];

        //定义为非托管内存
        GCHandle hObjectShort = GCHandle.Alloc(m_ImgRowColData, GCHandleType.Pinned);

        //定义非托管内存指针 
        IntPtr pObjectShort = new IntPtr();    

        //字节数组，用于存在相机的short数组值
        public static byte[] m_ImgRowColDataBytes = new byte[2048 * 1000 * 2];

        //Image acqured count
        public static ulong ulNBImageAcquired = 0;

        //The grabbed frequence per sceond.
        public static string fpsgrabbedLblStr = "";

        //Camera's handle
        public static System.IntPtr hCamera = new IntPtr();       
              
        //共享内存类的实例
        public ShareMemLib.ShareMem m_ShareMenInstace = new ShareMem();

        //按下时，采集的原始图片的个数，可以人工设定此值
        public static int m_AcqSampleCnt = 200;

        //按钮按下时，数据压入队列2中的次数
        public static int m_AcqCnt = 0;

        //OCT计算时的参数
        tOCTAlgorithmParas _tOCTAlgorithmParas = new tOCTAlgorithmParas();//

        //【缓存地址（8bits)=>h_OCTOutputDatas】,OCT计算后的存储8BIT的内存指针
        System.IntPtr h_OCTOutputDatas = new IntPtr();

        //图像采集线程
        public Thread _ImageAcquredThread = null;

        //存储数据线程
        public Thread _SaveDataThread = null;

        //实时数据处理线程
        public Thread _OCTCalThread = null;

        //实时显示线程
        public Thread _RealTimeShowThread = null;

        //采集结果所存放的目录
        public static string m_AcqPath = "E:\\Acquistions\\";

        //【数据队列二(16bits)=>m_ConcurrentQueue2】，采集线程模块所写入的队列二，在存储数据按钮按下时保存16bits的数据
        public static ConcurrentQueue<short[]> m_ConcurrentQueue2 = new ConcurrentQueue<short[]>();

        //【数据队列三(8bits)=>m_ConcurrentQueue3】，存储线程模块所写入的队列三，保存8bits的数据
        public static ConcurrentQueue<byte[]> m_ConcurrentQueue3 = new ConcurrentQueue<byte[]>();

        //存储图像数据按钮按下的标志：true为按下；false未按下
        public static bool m_SaveDataPressFlg = false;

        //存储数据线程扫描的存储信号：true表示开始执行图像存储操作，包括OCT计算、平均图、保存位图等
        public static bool m_SaveDataSig = false;        
        
        public NewScanFrm()
        {
            InitializeComponent();          
            pObjectShort = hObjectShort.AddrOfPinnedObject();
            m_ShareMenInstace.Init("LinesData", 2048 * 1000 * 2);//按字节长度

            //初始化OCT计算所需要的CPU/GPU缓存空间
            tOCTAlgorithmParasSettings _tOCTAlgorithmParasSettings = new tOCTAlgorithmParasSettings();
            _tOCTAlgorithmParasSettings.streamNum = 1;
            _tOCTAlgorithmParasSettings.Width = 2048;
            _tOCTAlgorithmParasSettings.Height = 1000;
            _tOCTAlgorithmParasSettings.count = 2048 * 1000;
            _tOCTAlgorithmParasSettings.InterpGridSize = 100;
            _tOCTAlgorithmParasSettings.InterpBlockSize = 10;
            _tOCTAlgorithmParasSettings.SubGridSize = 16000;
            _tOCTAlgorithmParasSettings.SubBlockSize = 128;
            _tOCTAlgorithmParasSettings.C0 = 835f;
            _tOCTAlgorithmParasSettings.C1 = 0.05f;
            _tOCTAlgorithmParasSettings.C2 = -6.35e-6f;
            _tOCTAlgorithmParasSettings.C3 = 0f;
            _tOCTAlgorithmParasSettings.a2 = 0f;
            _tOCTAlgorithmParasSettings.a3 = 0f;
            int returnVal = OCTCal.InitOCTAlgorithmParas(ref _tOCTAlgorithmParas, ref _tOCTAlgorithmParasSettings);
            h_OCTOutputDatas = OCTCal.InitOCTAlogrithmOutputDatas(2048 * 1000);
        }

        private void NewScanFrm_Load(object sender, EventArgs e)
        {
            List<object> m_ButtonList = new List<object>();
            m_ButtonList = new List<object>();
            m_ButtonList.Add(this.FirstLineShowBtn);
            m_ButtonList.Add(this.SaveImgBtn);
            m_ButtonList.Add(this.StopAcqBtn);
            m_ButtonList.Add(this.ThousandLineBtn);
            SkinFile.MadeNewSkinForControls(m_ButtonList);

            base.TitleLbl.Text = "新增采集";
            base.MaxBtn.Visible = false;
            List<Object> m_NewSkinObjectList = new List<Object>();//需要换肤的窗体列表
            m_NewSkinObjectList.Add(this);
            SkinLib.SkinFile.MadeNewSkinForControls(m_NewSkinObjectList);

            this.PatientIDTextBox.Text = this.m_PatientID.ToString();//将主窗体传入的病人ID赋值给文本框
            this.NameTextBox.Text = this.m_PatientName;//将主窗体传入的病人姓名赋值给文本框

            //存储数据线程
            _SaveDataThread = new Thread(SaveDataProc);
            _SaveDataThread.Priority = ThreadPriority.Highest;
            _SaveDataThread.IsBackground = true;
            _SaveDataThread.Start();


            //(实时数据处理线程）
            _OCTCalThread = new Thread(OCTCalProc);
            _OCTCalThread.Priority = ThreadPriority.Highest;
            _OCTCalThread.IsBackground = true;
            _OCTCalThread.Start();

            //实时数据显示线程
            _RealTimeShowThread = new Thread(RealTimeShowProc);
            _RealTimeShowThread.IsBackground = true;
            _RealTimeShowThread.Start();


            if (this.m_MainFrm.PatientAcqTabControl.SelectedIndex < 0 || PatientIDTextBox.Text == "")
            {
                //MessageBox.Show("没有选中病人，请重新操作！");
                MessageBoxFrm.ShowMesg("没有选中病人，请重新操作！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                return;
            }
            if (m_StartAcqFlg == true)
            {
                //MessageBox.Show("正在采集中！");               
            }
            else
            {
                //启动采集信号：true代表启动；false代表停止  
                m_StartAcqFlg = true;
                this.StateTextBox.Text = "正在采集中...";
                //启动采集线程，采集USB3相机数据
                _ImageAcquredThread = new Thread(AcqureImageProc);
                _ImageAcquredThread.IsBackground = true;
                //_ImageAcquredThread.Priority = ThreadPriority.Highest;
                _ImageAcquredThread.Start();
            }
            //this.tabPage2.Show();
            //tabControl1.SelectedIndex = 2;
            //string[] m_NamePatientIDArray = this.PatientAcqTabControl.TabPages[this.PatientAcqTabControl.SelectedIndex].Name.Split(';');
            //this.NameTextBox.Text = m_NamePatientIDArray[0];
            //this.PatientIDTextBox.Text = m_NamePatientIDArray[1];
        }

        /// <summary>
        /// This Function is used for acquiring image
        /// </summary>
        public void AcqureImageProc()
        {
            ConfigCPUCore.ConfigCPUCoreProc(1);////将当前线程绑定到指定的cpu核心1上  
            int nError = -1;
            IntPtr hThreadPlugUnplug;
            int dwThreadPlugUnplug;
            try
            {
                nError = USB3WinAPI.USB3_InitializeLibrary();
                //this.listBox1.BeginInvoke(new Action(()=> { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")+":USB3_InitializeLibrary success!"); }));
                LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_InitializeLibrary success!");
                if (nError != USB3WinAPI.CAM_ERR_SUCCESS) throw new Exception("USB3_InitializeLibrary");
                ulong ulNbCameras = 0;//[out] Number of cameras found

                nError = USB3WinAPI.USB3_UpdateCameraList(ref ulNbCameras);
                //this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_UpdateCameraList success!"); }));
                LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_UpdateCameraList success!");
                if (nError != USB3WinAPI.CAM_ERR_SUCCESS) throw new Exception("USB3_GetCameraInfo" + nError);

                //this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":Camera(s) found:" + ulNbCameras); }));
                LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":Camera(s) found:" + ulNbCameras);
                if (ulNbCameras == 0) throw new Exception("No Camera found!");

                tCameraInfo CameraInfo = new tCameraInfo();
                CameraInfo.pcID = "";

                for (ulong ulIndex = 0; ulIndex < ulNbCameras; ulIndex++)
                {
                    //this.listBox1.Items.Add("USB3_GetCameraInfo for camera index:" + ulIndex);
                    //this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_GetCameraInfo for camera index:" + ulIndex); }));
                    LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_GetCameraInfo for camera index:" + ulIndex);
                    nError = USB3WinAPI.USB3_GetCameraInfo(ulIndex, ref CameraInfo);
                    if (nError == USB3WinAPI.CAM_ERR_SUCCESS)
                    {
                        //this.listBox1.Items.Add("Camera ID:" + CameraInfo.pcID);
                        //this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":Camera ID:" + CameraInfo.pcID); }));
                        LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":Camera ID:" + CameraInfo.pcID);
                        break;
                    }
                    else
                        throw new Exception("USB3_GetCameraInfo" + nError);
                }
                try
                {
                    //Start to openning camera
                    nError = USB3WinAPI.USB3_OpenCamera(ref CameraInfo, ref hCamera);
                    //if (nError == USB3WinAPI.CAM_ERR_SUCCESS) this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_OpenCamera success and hCamera is:" + hCamera.ToString()); }));
                    if (nError == USB3WinAPI.CAM_ERR_SUCCESS) LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_OpenCamera success and hCamera is:" + hCamera.ToString());
                    else throw new Exception("USB3_OpenCamera" + nError);
                    uint iImageHeight = 1000;
                    uint iNbOfBuffer = 10;

                    //this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_SetImageParameters success!"); }));
                    LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_SetImageParameters success!");

                    //Set image parameters
                    nError = USB3WinAPI.USB3_SetImageParameters(hCamera, iImageHeight, iNbOfBuffer);                    
                                       
                    if (nError != USB3WinAPI.CAM_ERR_SUCCESS) throw new Exception("USB3_SetImageParameters" + nError);
                    //Start image acquistion
                    nError = USB3WinAPI.USB3_StartAcquisition(hCamera);
                    //this.listBox1.Items.Add("USB3_StartAcquisition success!");
                    //this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_StartAcquisition success!"); }));
                    LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_StartAcquisition success!");
                    //设置LinePeriod值=10us,LinePeriod=0x12100,4,RW
                    //Strat to write register           
                    ulong m_ulAddress = Convert.ToUInt64("0x12100", 16);//HEX Address string to ulong
                    int m_size = 4;//4个字节的长度           
                    byte[] sendBytes = GlobalTools.HexStringToHexBytes("e8030000");//10微秒
                    //byte[] sendBytes = GlobalTools.HexStringToHexBytes("10270000");//100微秒
                    GlobalTools.WriteUSB3Register(hCamera, m_ulAddress, sendBytes, m_size);

                    Thread.Sleep(100);

                    if (nError != USB3WinAPI.CAM_ERR_SUCCESS) throw new Exception("USB3_StartAcquisition" + nError);
                    //tImageInfos ImageInfos = new tImageInfos();                    
                    //ImageInfos.iBufferSize = 2048;
                    //ImageInfos.iImageSize = 2048;
                    //ImageInfos.iImageWidth = 1000;
                    //ImageInfos.iOffsetX = 100;
                    //ImageInfos.iImageHeight = 200;
                    //ImageInfos.eImagePixelType = tImagePixelType.eUnknown;                    
                    ulong MAX_TIMEOUT_ACQ_IN_MS = 3000;//ms
                    try
                    {
                        ulNBImageAcquired = 0;//Image acqured count
                        while ((nError == USB3WinAPI.CAM_ERR_SUCCESS) && m_StartAcqFlg)
                        {
                            //Console.WriteLine("start-1111111111111111111:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
                            nError = USB3WinAPI.USB3_GetBuffer(hCamera, USB3WinAPI.ImageInfos, MAX_TIMEOUT_ACQ_IN_MS);
                            //Console.WriteLine("start-2222222222222222222:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
                            if (nError != USB3WinAPI.CAM_ERR_SUCCESS) throw new Exception("USB3_GetBuffer" + nError);
                            ulNBImageAcquired++;
                            // ******************************************
                            // Do something with image ...
                            // ImageInfos.pDatas => contains raw data buffser
                            // ImageInfos.iImageWidth;
                            // ImageInfos.iImageHeight;
                            // ImageInfos.eImagePixelType;
                            // ImageInfos.iImageSize
                            // ImageInfos.iLinePitch
                            // ImageInfos.iOffsetX;
                            // ImageInfos.iHorizontalFlip;
                            // ImageInfos.iNbMissedTriggers;
                            // ImageInfos.iNbLineLost;
                            // ImageInfos.iNbImageAcquired;
                            // ******************************************                          

                            //--------------------------------------
                            //pObjectRead = hObjectRead.AddrOfPinnedObject();//获取非托管内存指针                                           
                            //OCTCal.ReadBinData(@"E:\Mrye\" + "ImageTest6.bin", pObjectRead, 2048 * 1000);
                            //--------------------------------------

                            //如果按下保存数据
                            if (m_SaveDataPressFlg)
                            {                                
                                if (m_AcqCnt < m_AcqSampleCnt)
                                {
                                    DateTime ts0 = DateTime.Now;
                                    //新建一个short数组
                                    short[] shortsArray = new short[2048 * 1000];
                                    //将USB3中的数据拷贝到数组中
                                    Marshal.Copy(USB3WinAPI.ImageInfos.pDatas, shortsArray, 0, 2048 * 1000);                                
                                    //写入数据队列二（16bits)
                                    m_ConcurrentQueue2.Enqueue(shortsArray);
                                    //Console.WriteLine("m_ConcurrentQueue2.count:" + m_ConcurrentQueue2.Count);
                                    //采集个数累加1
                                    m_AcqCnt++;
                                    //System.Diagnostics.Debug.WriteLine("存储数据线程函数运行时间1：{0}(毫秒),采集个数:{1}", (DateTime.Now - ts0).TotalMilliseconds, m_AcqCnt);
                                }
                                else if (m_AcqCnt == m_AcqSampleCnt)
                                {
                                    //m_StartAcqFlg = false; //发送停止采集信号，停止采集线程
                                    m_SaveDataPressFlg = false;//按钮按下标识置为假，不再保存数据
                                   //m_SaveDataSig = true;//给存储数据线程发送信号，启动OCT计算、平均图计算、位图保存等
                                }                               
                            }
                            else
                            {
                                //Console.WriteLine("start0:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
                                Marshal.Copy(USB3WinAPI.ImageInfos.pDatas, m_ImgRowColData, 0, 2048 * 1000);
                                //Console.WriteLine("start1:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));  
                                //--------------------------------------
                                //Console.WriteLine("start2:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
                                //Change short to bytes
                                Buffer.BlockCopy(m_ImgRowColData, 0, m_ImgRowColDataBytes, 0, m_ImgRowColDataBytes.Length);
                                //Console.WriteLine("start2:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
                                m_ShareMenInstace.Write(m_ImgRowColDataBytes, 0, 2048 * 1000 * 2);//Write short array to  share memory                                                                                                                           //Console.WriteLine("start3:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
                            }
                            if (nError == USB3WinAPI.CAM_ERR_SUCCESS)
                            {
                                // You must requeue the buffer to avoid buffer starvation
                                //printf("USB3_RequeueBuffer\n");
                                nError = USB3WinAPI.USB3_RequeueBuffer(hCamera, USB3WinAPI.ImageInfos.hBuffer);
                                if (nError != USB3WinAPI.CAM_ERR_SUCCESS) throw new Exception("USB3_RequeueBuffer" + nError);
                            }                         
                            System.Threading.Thread.Sleep(1);
                            //Console.WriteLine("start4:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
                        }
                    }
                    catch (Exception ep) // catch own CMyException
                    {
                        // Print XRayUsb error reason
                        //MessageBox.Show(ep.Message);
                        //MessageBox.Show(ep.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBoxFrm.ShowMesg(ep.Message, "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                    }
                    //printf("USB3_StopAcquisition\n");                    
                    nError = USB3WinAPI.USB3_StopAcquisition(hCamera);
                    //if (nError == USB3WinAPI.CAM_ERR_SUCCESS) this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_StopAcquisition success!"); }));

                    if (nError == USB3WinAPI.CAM_ERR_SUCCESS) LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_StopAcquisition success!");
                    else throw new Exception("USB3_StopAcquisition" + nError);

                    //printf("USB3_FlushBuffers\n");                   
                    nError = USB3WinAPI.USB3_FlushBuffers(hCamera);
                    //if (nError == USB3WinAPI.CAM_ERR_SUCCESS) this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_FlushBuffers success!"); }));
                    if (nError == USB3WinAPI.CAM_ERR_SUCCESS) LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_FlushBuffers success!");
                    else throw new Exception("USB3_FlushBuffers" + nError);
                }
                catch (Exception E)
                {
                    //MessageBox.Show(E.Message);
                    //MessageBox.Show(E.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBoxFrm.ShowMesg(E.Message, "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                }
                //printf("USB3_CloseCamera\n");
                nError = USB3WinAPI.USB3_CloseCamera(hCamera);
                if (nError == USB3WinAPI.CAM_ERR_SUCCESS)
                {
                    //this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_CloseCamera success!"); }));
                    LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_CloseCamera success!");
                }
                else
                {
                    throw new Exception("USB3_CloseCamera Error:" + nError);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Terminate Library
            //printf("USB3_TerminateLibrary\n");
            nError = USB3WinAPI.USB3_TerminateLibrary();
            //if (nError == USB3WinAPI.CAM_ERR_SUCCESS) this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_TerminateLibrary success!"); }));
            if (nError == USB3WinAPI.CAM_ERR_SUCCESS) LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_TerminateLibrary success!");
            else throw new Exception("USB3_TerminateLibrary Error:" + nError);
            //printf("USB3_TerminateLibrary Error %d\n", nError);
        }
        /// <summary>
        /// OCT计算线程所对应的执行方法
        /// </summary>
        public void OCTCalProc()
        {
            //将当前线程绑定到指定的cpu核心2上  
            ConfigCPUCore.ConfigCPUCoreProc(2);
            while (true)
            {
                //读取缓存地址一(16bits)，获取非托管内存指针                
                IntPtr pObjectShort  = hObjectShort.AddrOfPinnedObject();                
                //开始计算 
                OCTCal.OCTEXE(h_OCTOutputDatas, pObjectShort, ref _tOCTAlgorithmParas); 
                //延时15毫秒             
                //System.Threading.Thread.Sleep(15);
            }
        }

        /// <summary>
        /// 实时显示相机数据线程所对应的方法
        /// </summary>
        public void RealTimeShowProc()
        {
            //将当前线程绑定到指定的cpu核心3上 
            ConfigCPUCore.ConfigCPUCoreProc(3);
            while (true)
            {
                //计时开始
                DateTime ts0 = DateTime.Now;
                //作成opencv图像              
                Image<Gray, byte> imgs = new Image<Gray, byte>(1000, 1024, 1000 * 1, h_OCTOutputDatas);
                Bitmap _bitmap = imgs.ToBitmap();
                System.Diagnostics.Debug.WriteLine("实时显示函数运行时间1：{0}(毫秒)", (DateTime.Now - ts0).Milliseconds);
                //委托给主线程显示
                this.pictureBox2.Invoke(new Action(() => { this.pictureBox2.Image = _bitmap; }));
                //输出显示所耗的时间
                System.Diagnostics.Debug.WriteLine("实时显示函数运行时间2：{0}(毫秒)", (DateTime.Now - ts0).Milliseconds);
                //延时1毫秒
                System.Threading.Thread.Sleep(2);
            }
        }

        /// <summary>
        /// 存储数据线程对应的处理方法:与采集线程同步，将m_ConcurrentQueue2中的数据通过OCT计算后，生成8位数据，压入m_ConcurrentQueue3
        /// </summary>
        public void SaveDataProc()
        {            
            DateTime ts0 = DateTime.Now;
            while (true)               
            {               
                if (m_ConcurrentQueue2.Count >0)
                {
                    //DateTime ts0 = DateTime.Now;
                    short[] outShortArray = null;
                    //从队列2中取出数据
                    m_ConcurrentQueue2.TryDequeue(out outShortArray);
                    GCHandle hObject = GCHandle.Alloc(outShortArray, GCHandleType.Pinned);
                    //获取非托管内存指针  
                    IntPtr pObject = hObject.AddrOfPinnedObject();
                    
                    //OCT计算
                    OCTCal.OCTEXE(h_OCTOutputDatas, pObject, ref _tOCTAlgorithmParas);
                    
                    //System.Threading.Thread.Sleep(30);
                    //写入数据队列三(8bits)
                    byte[] byteArray = new byte[2048 * 1000];
                    Marshal.Copy(h_OCTOutputDatas, byteArray, 0, 2048 * 1000);
                    //将8BITS的数组压入队列3
                    m_ConcurrentQueue3.Enqueue(byteArray);
                    hObject.Free();                                    
                }
                System.Threading.Thread.Sleep(5);                
            }           
        }

        private void StopAcqBtn_Click(object sender, EventArgs e)
        {
            DialogResult m_dialogResult = MessageBox.Show("确定停止采集吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (m_dialogResult == DialogResult.Cancel) return;
            m_StartAcqFlg = false;//关闭采集线程，停止采集USB3相机数据   
            this.StateTextBox.Text = "采集结束...";      
            //this.m_ShowOneLineThread.Abort();
            //chartTimer.Enabled = false;
            //关闭采集线程，停止采集USB3相机数据      
            //_ImageAcquredThread.Abort();
            //关闭OCT计算线程          
            _OCTCalThread.Abort();
            //关闭显示实时数据线程     
            _RealTimeShowThread.Abort();
        }

        public override void CloseBtn_Click(object sender, EventArgs e)
        {
            m_StartAcqFlg = false;//关闭采集线程，停止采集USB3相机数据   
            this.StateTextBox.Text = "采集结束...";
            //this.m_ShowOneLineThread.Abort();
            //chartTimer.Enabled = false;
            //关闭采集线程，停止采集USB3相机数据      
            //_ImageAcquredThread.Abort();
            //关闭OCT计算线程          
            _OCTCalThread.Abort();
            //关闭显示实时数据线程     
            _RealTimeShowThread.Abort();
            this.Dispose();
        }

        private void NewScanFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            //if (MessageBox.Show("确定关闭吗!", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //{
            //    e.Cancel = true;//Cancel the closing for windows form  
            //    return;
            //}
            //else
            //{
            //    this.StateTextBox.Text = "采集结束...";
            //    m_StartAcqFlg = false;//关闭采集线程，停止采集USB3相机数据   
            //    //关闭采集线程，停止采集USB3相机数据      
            //    //_ImageAcquredThread.Abort();

            //    //关闭OCT计算线程          
            //    _OCTCalThread.Abort();

            //    //关闭显示实时数据线程     
            //    _RealTimeShowThread.Abort();
            //}                     
                   
        }
              
        /// <summary>
        /// 存储按钮按下时执行的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveImageDataBtn_Click(object sender, EventArgs e)
        {   
            //(关闭实时数据处理线程）
            _OCTCalThread.Abort();
            //延时，等待实时数据处理线程被关闭
            Thread.Sleep(10);
            //关闭显示实时数据线程
            //_RealTimeShowThread.Abort();         

            //采集次数置成0
            m_AcqCnt = 0;           
            //启动截图，即存储数据
            m_SaveDataPressFlg = true;            
            //启动一个线程，检测采集次数是否完成
            Thread VerifyAcqIsCompleteThread = new Thread(VerifyAcqIsCompleteProc);
            VerifyAcqIsCompleteThread.IsBackground = true;
            VerifyAcqIsCompleteThread.Start();
        }

        public void VerifyAcqIsCompleteProc()
        {
            DateTime ts0 = DateTime.Now;
            //等待存储线程把队列2中的数据计算完后，存入队列3中
            while (m_ConcurrentQueue3.Count < m_AcqSampleCnt)
            {                
                Thread.Sleep(10);                
            }
            //System.Diagnostics.Debug.WriteLine("等待存储数据线程函数计算完成运行时间3：{0}(毫秒)", (DateTime.Now - ts0).TotalMilliseconds);
            //Console.WriteLine("m_ConcurrentQueue3:" + m_ConcurrentQueue3.Count.ToString() + ":m_ConcurrentQueue2=" + m_ConcurrentQueue2.Count.ToString());

            //关闭显示实时数据线程
            _RealTimeShowThread.Abort();

            //委托采集窗口关闭实时显示线程及自身窗体
            this.m_MainFrm.BeginInvoke(new Action(()=>
            {             
                //关闭采集线程，停止采集USB3相机数据   
                m_StartAcqFlg = false;
                //关闭存储数据线程
                _SaveDataThread.Abort();           
                //关闭采集窗体
                this.Dispose();
                AvePreviewFrm m_AvePreviewFrm = new AvePreviewFrm();
                //参数传递
                m_AvePreviewFrm.m_MainFrm = this.m_MainFrm;//主窗体引用
                m_AvePreviewFrm.m_ConcurrentQueue3 = m_ConcurrentQueue3;//1字节数组队列
                m_AvePreviewFrm.m_PatientID = this.m_PatientID;//病人ID
                m_AvePreviewFrm.m_LogDoctorID = this.m_LogDoctorID;//医生ID
                m_AvePreviewFrm.m_DoctorName = this.m_DoctorName;//医生用户名
                m_AvePreviewFrm.m_AcqPath = m_AcqPath;//采集结果存储路径
                m_AvePreviewFrm.StartPosition = FormStartPosition.CenterScreen;
                m_AvePreviewFrm.ShowDialog();
            }));
        }

        private void FirstLineShowBtn_Click(object sender, EventArgs e)
        {            
            FirstLineShowFrm m_FirstLineShowFrm = new FirstLineShowFrm();
            m_FirstLineShowFrm.pObjectShort = this.pObjectShort;
            m_FirstLineShowFrm.StartPosition = FormStartPosition.CenterParent;
            m_FirstLineShowFrm.ShowDialog();
        }

        private void userButton1_MouseMove(object sender, MouseEventArgs e)
        {
            //this.userButton1.BackColor = Color.Transparent;
            //this.userButton1.UserBtn.BackColor = Color.Transparent;
            //MessageBox.Show("D");
        }

        private void ThousandLineBtn_Click(object sender, EventArgs e)
        {
            string m_EXEPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string SubPath = m_EXEPath.Substring(0, m_EXEPath.IndexOf("opencv") + 6);
            string m_showAllLineEXEPath = @SubPath + @"\SJZDEyes\ShowAllLines\bin\Debug\ShowAllLines.exe";
            //MessageBox.Show(m_showAllLineEXEPath);
            System.Diagnostics.Process.Start(m_showAllLineEXEPath);
        }
    }
}
