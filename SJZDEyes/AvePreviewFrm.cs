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

namespace SJZDEyes
{
    public partial class AvePreviewFrm : NewStyleFrm
    {
        //主窗体引用
        public MainFrm m_MainFrm = null;
        //1字节数组队列
        public ConcurrentQueue<byte[]> m_ConcurrentQueue3 = null;
        //病人ID
        public UInt64 m_PatientID = 0;
        //存在AVE的结果路径
        public string m_AcqPath = "";
        //医生登录ID
        public string m_LogDoctorID;
        //医生的用户名
        public string m_DoctorName;

        public AvePreviewFrm()
        {
            InitializeComponent();
        }

        private void AvePreviewFrm_Load(object sender, EventArgs e)
        {
            base.TitleLbl.Text = "平均图计算";
            base.MaxBtn.Visible = false;
            List<Object> m_NewSkinObjectList = new List<Object>();//需要换肤的窗体列表
            m_NewSkinObjectList.Add(this);
            SkinLib.SkinFile.MadeNewSkinForControls(m_NewSkinObjectList);

            //启动preview平均图计算模块线程
            Thread m_AvePreviewThread = new Thread(AvePreviewProc);
            m_AvePreviewThread.IsBackground = true;
            m_AvePreviewThread.Start();
        }

        //preview平均图计算模块方法
        public void AvePreviewProc()
        {
            //开始平均图计算
            //*********** 性能参数设置 ************
            visionAveInfo aveInfo = new visionAveInfo();
            aveInfo.matchScale = 1;
            aveInfo.xyPianYiMax = 200;
            aveInfo.aveMethor = 1;
            aveInfo.modelInfoShow_Flag = 0;
            aveInfo.findInfoShow_Flag = 0;
            //-------------------------------------
            //LogFile.Log("Error-m_ConcurrentQueue3的个数为：" + m_ConcurrentQueue3.Count);
            ////*********** 读取加载图像 ************
            //获取队列中的数据个数
            int AveCalCount = m_ConcurrentQueue3.Count;
            for (int i = 0; i < AveCalCount; i++)
            {
                byte[] outByteArray = null;
                m_ConcurrentQueue3.TryDequeue(out outByteArray);//从队列3中取出数据
                GCHandle hObject2 = GCHandle.Alloc(outByteArray, GCHandleType.Pinned);
                IntPtr pObject2 = hObject2.AddrOfPinnedObject();//获取非托管内存指针  
                Image<Gray, byte> img = new Image<Gray, byte>(1000, 1024, 1000 * 1, pObject2);
                //img.ToBitmap().Save("e:\\Acquistions\\" + this.PatientIDTextBox.Text + i.ToString() + ".bmp");
               
                AveBitmapCal.viAvePro_AddImg(img);//压入平均图中列表中
                hObject2.Free();//释放资源
            }
            //*********** 平均图处理函数调用 ***********
            AveBitmapCal.visionAveFunc(aveInfo);
            //-------------------------------------

            //************* 输出到C# Bitmap ************
            visionAveOutput aveOutput = AveBitmapCal.getAveOutputImg();
            Image<Gray, byte> img2 = new Image<Gray, byte>(aveOutput.width, aveOutput.height, aveOutput.step, aveOutput.data);
            //pictureBox1.Image = img.ToBitmap();
            Bitmap m_Bitmap = img2.ToBitmap();          
            
            //生成采集ID
            UInt64 m_GenerateAcqID = DBHelper.GenerateAcqID(m_PatientID);
            //string m_Originalpath = m_AcqPath + m_PatientID.ToString() + "\\" + m_GenerateAcqID + ".bmp";

            //采集结果、分析结果的路径定义（未包含文件名）
            string m_Originalpath = m_AcqPath + m_PatientID.ToString() + "\\" + m_GenerateAcqID + "\\" + "Original";
            string m_Resultpath = m_AcqPath + m_PatientID.ToString() + "\\" + m_GenerateAcqID + "\\" + "Result";
            
            //保存图片到硬盘目录下
            if (!Directory.Exists(m_Originalpath))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(m_Originalpath); //新建文件夹   
            }
            if (!Directory.Exists(m_Resultpath))//若文件夹不存在则新建文件夹   
            {
                Directory.CreateDirectory(m_Resultpath); //新建文件夹   
            }
            //路径+文件名
            string m_OriginalFile = m_Originalpath + "\\" + m_GenerateAcqID + ".bmp";
            string m_ResultFile = m_Resultpath + "\\" + m_GenerateAcqID + ".bmp";

            m_Bitmap.Save(m_OriginalFile);
            m_Bitmap.Save(m_ResultFile);

            //插入采集信息到数据库中的tb_Acquistions表中
            DBHelper.InsertAcquisitionInfo(m_GenerateAcqID, m_PatientID, m_OriginalFile, m_ResultFile, m_LogDoctorID);

            //在界面上显示一张图片            
            this.BeginInvoke(new Action(() =>
            {
                this.PreviewPictureBox.Image = m_Bitmap;
            }));
            //释放资源
            //m_Bitmap.Dispose();
            //刷新病人采集列表
            this.m_MainFrm.PatientAcqTabControl.BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < this.m_MainFrm.PatientAcqTabControl.TabPages.Count; i++)
                {
                    if (this.m_MainFrm.PatientAcqTabControl.TabPages[i].Name.Contains(m_PatientID.ToString()))
                    {
                        foreach (Control ctrl in m_MainFrm.PatientAcqTabControl.TabPages[i].Controls)
                        {
                            if (ctrl is LoadAcqImagesFrm)
                            {
                                LoadAcqImagesFrm m_LoadAcqImagesFrm = (LoadAcqImagesFrm)ctrl;
                                m_LoadAcqImagesFrm.LoadImageFiles();
                                break;
                            }
                        }
                        break;
                    }
                }
            }));
            //-------------------------------------
            //************ 清空加载缓存 ************
            AveBitmapCal.viAvePro_ClearBuf();
            //-------------------------------------
        }
    }
}
