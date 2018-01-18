using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.UI;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Runtime.InteropServices;
using ShareMemLib;
using System.Threading;
using OCTCalLib;
using SkinLib;

namespace ShowAllLines
{
    public partial class ShowAllLinesByOpencvFrm : NewStyleFrm
    {
        public ShareMemLib.ShareMem m_ShareMenInstace = new ShareMem();


        public static byte[] m_getImgRowColDataBytes = new byte[2048 * 1000 * 2];//This is the image data array,it is the key data for us to acquire.
        public static short[] m_getImgRowColDataShorts = new short[2048 * 1000];//This is the image data array,it is the key data for us to acquire.
        public static double[] m_getImgRowColDataDoubles = new double[2048 * 1000];//This is the image data array,it is the key data for us to acquire
        public static Mutex mutex;
        public static byte[,,] dFaceBytes3 = new byte[1000, 2048, 1];  //2048*1000


        byte[,,] NewColrByte = new byte[1000, 2048, 1];//定义灰度对应的三维数组
        public static byte[,,] colrByte = new byte[1000, 2048, 1];//定义灰度对应的三维数组
        public static byte[] m_ShortToByteArray = new byte[1000 * 2048];//Change shorts to coresponding byte by rate 256F/4096F

        public static Image<Emgu.CV.Structure.Gray, byte> img1 = new Image<Emgu.CV.Structure.Gray, byte>(1000, 2048);
        byte[,] k = new byte[2048, 1000];
        ImageViewer viewer = new ImageViewer();
        Capture capture;

        tOCTAlgorithmParas _tOCTAlgorithmParas = new tOCTAlgorithmParas();//
        public static byte[] m_ByteArray = new byte[1000 * 2048];

        public static Image<Gray, byte> img2 = new Image<Gray, byte>(2048, 1000);
        //public System.IntPtr m_pDatasFromBuffer = new IntPtr();//读取USB3时的指针

        //public System.IntPtr m_pDatasFromBin = new IntPtr();//读取二进制文件时的内存指针

        //public static byte[] m_BytesArray = new byte[2048 * 1000];
        //GCHandle _handle = GCHandle.Alloc(m_BytesArray, GCHandleType.Pinned);//定义为非托管内存      

        System.IntPtr h_OCTOutputDatas = new IntPtr();//OCT计算后的存储8BIT的内存指针

        public ShowAllLinesByOpencvFrm()
        {
            InitializeComponent();
            m_ShareMenInstace.Init("LinesData", 2048 * 1000 * 2);//Initialize share memory reading instance
            bool flag = false;
            string mutexName = "Global\\" + "ShowLines";
            mutex = new System.Threading.Mutex(true, mutexName, out flag);
            //第一个参数:true--给调用线程赋予互斥体的初始所属权  
            //第一个参数:互斥体的名称  
            //第三个参数:返回值,如果调用线程已被授予互斥体的初始所属权,则返回true  
            if (!flag)
            {
                //MessageBox.Show("只能运行一个客户端程序！", "请确定", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(1);//退出程序  
            }

            //tOCTAlgorithmParasSettings _tOCTAlgorithmParasSettings = new tOCTAlgorithmParasSettings();
            //_tOCTAlgorithmParasSettings.streamNum = 1;
            //_tOCTAlgorithmParasSettings.Width = 2048;
            //_tOCTAlgorithmParasSettings.Height = 1000;
            //_tOCTAlgorithmParasSettings.count = 2048 * 1000;
            //_tOCTAlgorithmParasSettings.InterpGridSize = 1;
            //_tOCTAlgorithmParasSettings.InterpBlockSize = 1000;
            //_tOCTAlgorithmParasSettings.SubGridSize = 2048;
            //_tOCTAlgorithmParasSettings.SubBlockSize = 1000;
            //_tOCTAlgorithmParasSettings.C0 = 775.184f;
            //_tOCTAlgorithmParasSettings.C1 = 7.08487E-2f;
            //_tOCTAlgorithmParasSettings.C2 = -5.90495e-6f;
            //_tOCTAlgorithmParasSettings.C3 = 1.56112e-10f;
            //_tOCTAlgorithmParasSettings.a2 = 0f;
            //_tOCTAlgorithmParasSettings.a3 = 0f;
            //int returnVal = OCTCal.InitOCTAlgorithmParas(ref _tOCTAlgorithmParas, ref _tOCTAlgorithmParasSettings);
            //h_OCTOutputDatas = OCTCal.InitOCTAlogrithmOutputDatas(2048 * 1000);
        }

        private void ShowAllLinesByOpencvFrm_Load(object sender, EventArgs e)
        {
            //byte[,,] dFaceBytes3 = new byte[1000, 2048, 1];  //2048*1000
            //int[,] dFaceBytes0 = new int[1000, 2048];  //2048*1000
            //for (int v = 0; v < 1; v++)
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        for (int j = 0; j < 2048; j++)
            //        {
            //            dFaceBytes3[i, j, v] = 60;
            //        }
            //    }
            //}
            //Console.WriteLine(DateTime.Now.ToString("2:" + "yyyy-MM-dd-hh-mm-ss.fff"));
            //GCHandle hObject = GCHandle.Alloc(dFaceBytes3, GCHandleType.Pinned);//difine this is the unmanaged memory
            //IntPtr pObject = hObject.AddrOfPinnedObject();
            //Console.WriteLine(DateTime.Now.ToString("4:" + "yyyy-MM-dd-hh-mm-ss.fff"));
            //img1.Data = dFaceBytes3;
            //pictureBox1.Image = img1.ToBitmap();
            //Console.WriteLine(DateTime.Now.ToString("4:" + "yyyy-MM-dd-hh-mm-ss.fff"));
            timer1.Enabled = true;
            base.TitleLbl.Text = "1000条线光强灰度图";
            base.MaxBtn.Visible = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("1:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));
            //read byts data from share memory
            m_ShareMenInstace.Read(ref m_getImgRowColDataBytes, 0, 2048 * 1000 *2 );
            //Copy data from bytes to shorts
            Buffer.BlockCopy(m_getImgRowColDataBytes, 0, m_getImgRowColDataShorts, 0, m_getImgRowColDataShorts.Length * 2);
            Console.WriteLine("2:" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss.fff"));

            //m_ShareMenInstace.ReadShorts(ref m_getImgRowColDataShorts, 0, 2048 * 1000 * 2);


            //for (int lineNum = 0; lineNum < 1000; lineNum++)
            //{
            //    for (int x = 0; x < 2048; x++)
            //    {
            //        m_ShowData[x, lineNum] = m_getImgRowColDataShorts[lineNum * 2048 + x];
            //    }
            //}

            //byte[,,] dFaceBytes3 = new byte[1000, 2048, 1];  //2048*1000
            //int[,] dFaceBytes0 = new int[1000, 2048];  //2048*1000

            //byte[] m_ShortToByteArrayUnmanaged = new byte[1000 * 2048];//Change shorts to coresponding byte by rate 256F/4096F
            //  GCHandle hObject1 = GCHandle.Alloc(m_ShortToByteArrayUnmanaged, GCHandleType.Pinned);//定义为非托管内存
            //  IntPtr pObject1 = hObject1.AddrOfPinnedObject();//获取非托管内存指针     

            //将shorts变换成对应的byte
            for (int i = 0; i < 1000 * 2048; i++)
            {
                float rate = 256f / 4096f;
                float k = rate * (float)m_getImgRowColDataShorts[i];
                int kint = (int)k;
                byte[] shi = System.BitConverter.GetBytes(kint);
                m_ShortToByteArray[i] = shi[0];
                //m_ShortToByteArrayUnmanaged[i] = shi[0];
            }


            //OCT计算
            //---------------------------------------------
            GCHandle hObjectRead = GCHandle.Alloc(m_ShortToByteArray, GCHandleType.Pinned);//定义为非托管内存
            
            IntPtr pObjectRead = hObjectRead.AddrOfPinnedObject();//获取非托管内存指针 

            //Image<Gray, byte> imgs = new Image<Gray, byte>(1000, 2048, 1000 * 1, pObjectRead);
            //Bitmap _bitmap = imgs.ToBitmap();
            //System.Diagnostics.Debug.WriteLine("实时显示函数运行时间1：{0}(毫秒)", (DateTime.Now - ts0).Milliseconds);
            //委托给主线程显示
            //this.pictureBox2.Invoke(new Action(() => { this.pictureBox2.Image = _bitmap; }));
            
            //Console.WriteLine("3:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));
            //OCTCal.OCTEXE(h_OCTOutputDatas, pObjectRead, ref _tOCTAlgorithmParas);
            ////将一字节的8位内存块作成bitmap.
            //Console.WriteLine("4:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));
            GCHandle hObject1 = GCHandle.Alloc(colrByte, GCHandleType.Pinned);//定义为非托管内存
            IntPtr pObject1 = hObject1.AddrOfPinnedObject();//获取非托管内存指针 

            //Marshal.Copy(h_OCTOutputDatas, m_ByteArray, 0, 2048 * 1000);//
            Marshal.Copy(m_ShortToByteArray, 0, pObject1, 2048 * 1000);//将一维数据拷贝到三维数组中         


            img2.Data = colrByte;
            pictureBox1.Image = img2.ToBitmap();
            //pictureBox1.Image = _bitmap;
            //-------------------------------------------
            //Console.WriteLine("5:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));

            ////Console.WriteLine("3:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));
            ////byte[,,] colrByte = new byte[1000, 2048, 1];//定义灰度对应的三维数组
            //Console.WriteLine("4:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));
            //GCHandle hObject = GCHandle.Alloc(colrByte, GCHandleType.Pinned);//定义为非托管内存
            //IntPtr pObject = hObject.AddrOfPinnedObject();//获取非托管内存指针           
            //Marshal.Copy(m_ShortToByteArray, 0, pObject, 2048 * 1000);//将一维数据拷贝到三维数组中
            ////Copy(byte[] source, int startIndex, IntPtr destination, int length
            ////Marshal.Copy(pObject1, colrByte,0, 2048 * 1000);//将一维数据拷贝到三维数组中
            //Console.WriteLine("5:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));           
            //Console.WriteLine("6:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));
            //img1.Data = colrByte;
            //imageBox1.Image = img1;
            ////img1.Save("1.bmp");
            //Console.WriteLine("7:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));
            ////pictureBox1.Image = img1.ToBitmap();
            //Console.WriteLine("8:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));
            //hObject.Free();//使用完毕后，将其handle free，这样c#可以正常gc这块内存
            //Console.WriteLine("9:" + DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff"));
        }
    }
}
