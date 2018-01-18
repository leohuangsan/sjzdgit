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
using System.Runtime.InteropServices;
using GlobalToolSpace;
using System.IO;
using SkinLib;
using UserControlsLib;
using LogLib;

namespace SJZDEyes
{
    public partial class CameraControlFrm : Form
    {
       public System.IntPtr m_hCamera;
       public tImageInfos m_tImageInfos;
       public static Dictionary<string, string> m_CameraCtrlAddrList = new Dictionary<string, string>();//Use for storing camera control address.

        //public CameraControlFrm(System.IntPtr hCamera)
        public CameraControlFrm()
        {
            InitializeComponent();
            //打开相机
            this.m_hCamera = OpenUSB3Camera();

        }
        /// <summary>
        /// Read camera control parameter button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                //MessageBox.Show("输入的数据不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBoxFrm.ShowMesg("输入的数据不能为空！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
            }
            else
            {
                if (m_hCamera == null)
                {
                    //MessageBox.Show("相机未打开，无法读取！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBoxFrm.ShowMesg("相机未打开，无法读取！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                    return;
                }
                ulong m_ulAddress = Convert.ToUInt64("0x" + textBox1.Text, 16);//HEX string to ulong
                int m_size = int.Parse(textBox2.Text);             
                                         
                byte[] m_ReadRegisterBytes = GlobalTools.ReadUSB3Register(this.m_hCamera, m_ulAddress, m_size);//Read USB3 Register by address
                string m_ReadRegisterBytesToStr = GlobalTools.ChangeByteToCorrespondStr(m_ReadRegisterBytes, m_size);//Change bytes to 16 hex string               
                textBox4.Text = m_ReadRegisterBytesToStr;//Show the reading data by 16 hex string
                string m_reverseStr = GlobalTools.ReverseBytesStr(m_ReadRegisterBytesToStr);//Revse byte-string
                if(m_size == 4) textBox3.Text = Convert.ToUInt64("0x" + m_reverseStr, 16).ToString(); //Turn bytes to int
                else textBox3.Text = System.Text.Encoding.ASCII.GetString(m_ReadRegisterBytes);//Turn bytes(ASSCII) to string
            }
        }
        /// <summary>
        /// 将参数写入到相机中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                //MessageBox.Show("输入的数据不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBoxFrm.ShowMesg("输入的数据不能为空！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
            }
            else
            {    
                //Strat to write register           
                ulong m_ulAddress = Convert.ToUInt64("0x" + textBox5.Text, 16);//HEX Address string to ulong
                int m_size = int.Parse(textBox6.Text);//Turn data size string to int             
                byte[] sendBytes = GlobalTools.HexStringToHexBytes(textBox8.Text);
                GlobalTools.WriteUSB3Register(this.m_hCamera, m_ulAddress, sendBytes, m_size);
                MessageBoxFrm.ShowMesg("参数写入完成！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.OKIco);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] m_AddressVal1 = m_CameraCtrlAddrList[comboBox1.Text].Split(',');
            textBox1.Text = m_AddressVal1[0];//Show the address
            textBox2.Text = m_AddressVal1[1];//Show the return value length
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] m_AddressVal2 = m_CameraCtrlAddrList[comboBox2.Text].Split(',');
            textBox5.Text = m_AddressVal2[0];//Show the address
            textBox6.Text = m_AddressVal2[1];//Show the address
            textBox7.Text = "";
            textBox8.Text = "";
        }
        /// <summary>
        /// Input data to Write to Register
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(textBox6.Text) == 4)
            {   
                //Write 4 bytes int data to Register            
                if (textBox7.Text !="")
                {
                    System.Int64 m_LongVal = 0;
                    bool m_intFlag = System.Int64.TryParse(textBox7.Text, out m_LongVal);
                    if (m_intFlag)
                    {
                        if (m_LongVal >= 4294967296)//over 4 bytes?
                        {
                            //MessageBox.Show("Input val is overFlow,it is bigger than 4 bytes!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBoxFrm.ShowMesg("输入值过大，超过4字节！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);

                            textBox7.Text = "";
                            textBox8.Text = "";
                        }
                        else
                        {
                            //if the input data is correct,change it into 16 hex
                            //reverse 16 hex string and show it by textbox8
                            string m_hexVal = Convert.ToString(m_LongVal, 16);
                            m_hexVal = m_hexVal.PadLeft(8,'0');
                            string m_reverseStr = GlobalTools.ReverseBytesStr(m_hexVal);//Revse byte-string
                            textBox8.Text = m_reverseStr;
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Input Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBoxFrm.ShowMesg("输入错误！", "提示", MessageBoxButtons.OK, MessageBoxNewIco.ErrorIco);
                        textBox7.Text = "";
                        textBox8.Text = "";
                    }
                }                  
               
            }
            else if (int.Parse(textBox6.Text) == 64 || int.Parse(textBox6.Text) == 16)
            {
                //Wrtite string to 
                textBox8.Text = GlobalTools.StringToAsciiStr(textBox7.Text, int.Parse(textBox6.Text));
            }
        }

        private void CameraControlFrm_Load(object sender, EventArgs e)
        {
            //Read Camera Control Address
            List<object> m_ButtonList = new List<object>();
            m_ButtonList = new List<object>();
            m_ButtonList.Add(this.button1);
            m_ButtonList.Add(this.button2);          
            SkinFile.MadeNewSkinForControls(m_ButtonList);



            string m_CameraCtrlAddrPath = System.AppDomain.CurrentDomain.BaseDirectory + @"Config.ini";
            StreamReader sr = new StreamReader(m_CameraCtrlAddrPath, Encoding.Default);
            String m_readLineStr = "";//Read a line string
            string m_AddressName = "";//Represents the camera register address name.
            string m_AddressVal = "";//It contains the Address/returning value length/R or W
            m_CameraCtrlAddrList.Clear();
            while ((m_readLineStr = sr.ReadLine()) != null)
            {
                if (m_readLineStr.Contains("=0x"))
                {
                    m_AddressName = m_readLineStr.Substring(0, m_readLineStr.IndexOf("=0x"));
                    m_AddressVal = m_readLineStr.Substring(m_readLineStr.IndexOf("=0x") + 3, m_readLineStr.Length - (m_AddressName.Length + 3));
                    //Console.WriteLine(m_AddressName.ToString() + ":" + m_AddressVal);
                    m_CameraCtrlAddrList.Add(m_AddressName, m_AddressVal);
                }
            }

            //Add camera control address to Address name combox for reading or writting
            for (int i = 0; i < m_CameraCtrlAddrList.Count; i++)
            {
                if (!m_CameraCtrlAddrList.ElementAt(i).Value.ToString().Contains("WO"))
                {
                    comboBox1.Items.Add(m_CameraCtrlAddrList.ElementAt(i).Key);
                    comboBox1.Text = comboBox1.Items[0].ToString();//default address name
                }
                if (!m_CameraCtrlAddrList.ElementAt(i).Value.ToString().Contains("RO"))
                {
                    comboBox2.Items.Add(m_CameraCtrlAddrList.ElementAt(i).Key);
                    comboBox2.Text = comboBox2.Items[0].ToString();//default address name
                }
            }
        }
        public IntPtr OpenUSB3Camera()
        {
            int nError = -1;
            IntPtr hCamera = new IntPtr();
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
            //ulong m_ulAddress = Convert.ToUInt64("0x12100", 16);//HEX Address string to ulong
            //int m_size = 4;//4个字节的长度           
            //byte[] sendBytes = GlobalTools.HexStringToHexBytes("0a000000");//100微秒
            //GlobalTools.WriteUSB3Register(hCamera, m_ulAddress, sendBytes, m_size);

            //Thread.Sleep(100);  
            return hCamera;
        }

        public void CloseUSB3Camera(IntPtr hCamera)
        {
            if (hCamera == null) return;
            int nError = -1;
            nError = USB3WinAPI.USB3_StopAcquisition(hCamera);
            //if (nError == USB3WinAPI.CAM_ERR_SUCCESS) this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_StopAcquisition success!"); }));

            if (nError == USB3WinAPI.CAM_ERR_SUCCESS) LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_StopAcquisition success!");
            else throw new Exception("USB3_StopAcquisition" + nError);

            //printf("USB3_FlushBuffers\n");                   
            nError = USB3WinAPI.USB3_FlushBuffers(hCamera);
            //if (nError == USB3WinAPI.CAM_ERR_SUCCESS) this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_FlushBuffers success!"); }));
            if (nError == USB3WinAPI.CAM_ERR_SUCCESS) LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_FlushBuffers success!");
            else throw new Exception("USB3_FlushBuffers" + nError);

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
            nError = USB3WinAPI.USB3_TerminateLibrary();
            //if (nError == USB3WinAPI.CAM_ERR_SUCCESS) this.listBox1.BeginInvoke(new Action(() => { this.listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_TerminateLibrary success!"); }));
            if (nError == USB3WinAPI.CAM_ERR_SUCCESS) LogFile.Log(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + ":USB3_TerminateLibrary success!");
            else throw new Exception("USB3_TerminateLibrary Error:" + nError);
        }

        private void CameraControlFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭相机，释放资源
            CloseUSB3Camera(this.m_hCamera);
        }
    }
}
