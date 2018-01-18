using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace USB3WinApiSpace
{
    public struct tCameraInfo 
    { 
        public char[] pcID;
    }
    public struct tImageInfos
    {
        IntPtr hBuffer;
        IntPtr pDatas;
        int iBufferSize;
        int iImageSize;
        int iOffsetX;
        int iImageWidth;
        int iImageHeight;
        tImagePixelType eImagePixelType;
        int iLinePith;
        int iHorizontalFlip;
        int iNbMissedTriggers;
        int iNbLineLost;
        int iNbImageAcquired;
        int iFrameTriggerNbValidLines;
    }

    public struct tThreadParam
    {
        IntPtr hCamera;
        IntPtr  pbCancel;
        IntPtr pbImageAcquired;
        int ulNbImageToAcquire;
        int ulTimeoutAcq;
        IntPtr pnErrorThreadAcq;   
    
    }
    public enum tImagePixelType
    {
        /*! Unknown Pixel Type */
        eUnknown = 0,
        /*! Pixel Type 8 bit: Mono8 (aligned on 8 bit) */
        eMono8 = 1,
        /*! Pixel Type 10 bit: Mono10 (aligned on 16 bit) */
        eMono10 = 2,
        /*! Pixel Type 11 bit: Mono11 (aligned on 16 bit) */
        eMono11 = 3,
        /*! Pixel Type 12 bit: Mono12 (aligned on 16 bit) */
        eMono12 = 4,
    
    }
    public struct PersonStruct
    {
        public int myOld;
        public string[] Name;
        public string MobilePhone;
        public DateTime Birthday;
    }
    public class USB3WinAPI
    {
        public static  int CAM_ERR_SUCCESS = 0;
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_InitializeLibrary")]
        //Locate SDK resources
        public static extern int USB3_InitializeLibrary();

        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_UpdateCameraList")]
        //This function allows to update the camera list and to get the number of cameras present on the system 
        public static extern int USB3_UpdateCameraList(ref ulong pulNbCameras);


        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
        //This function retrieves the camera info for the given index 
        public static extern int USB3_GetCameraInfo(long numberIndex, ref tCameraInfo pCameraInfo);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
        //Opens the communication to a camera 
        public static extern int USB3_OpenCamera(ref tCameraInfo pCameraInfo, ref IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
         //This function allows to set the image parameters: height of the image and the number of buffers for the images 
         public static extern int USB3_SetImageParameters(IntPtr hCamera, int iImageHeight, int iNbOfBuffer);


         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
         //This function allows to start the acquisition engine for the specified camera  
         public static extern int USB3_StartAcquisition(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
         //This function allows to unblock any waiting call to the USB3_GetBuffer
         public static extern int USB3_AbortGetBuffer(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
         //This function allows to flush all buffers from the output queue to the input queue 
         //if you don't requeue buffer, the acquisition engine risks to have a buffer starvation 
         public static extern int USB3_FlushBuffers(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
         //This function closes the communication with the camera        
         public static extern int USB3_CloseCamera(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
         //This function allows to terminate the Camera Library        
         public static extern int USB3_TerminateLibrary(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
         //This function allows to get a grabbed buffer from the SDK acquisition engine output queue 
         public static extern int USB3_GetBuffer(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x86\CamCmosOctUsb3.dll")]
        //This function allows to requeue a buffer that was successfully obtained via USB3_GetBuffer api to the input queue. 
        //After being requeued, the buffer can be used again by the SDK acquistion engine. 
        //if you don't requeue buffer, the acquisition engine risks to have a buffer starvation 
         public static extern int USB3_RequeueBuffer(IntPtr hCamera,IntPtr hBuffer);






   

        public static string readIniValue(string Key)
        {
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + "DataBase.Ini";
            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString(Environment.UserName, Key, "", temp, 255, Path);
            return temp.ToString();
        }

        public static string readIniValue(string section, string Key)
        {
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + "DataBase.Ini";
            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString(section, Key, "", temp, 255, Path);
            return temp.ToString();
        }

        public static string readIniValue(string FileName, string section, string Key)
        {
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + FileName;
            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString(section, Key, "", temp, 255, Path);
            return temp.ToString();
        }
        //写INI文件 
        public static void WriteIniValue(string Section, string Key, string Value)
        {
            //if (Path == "" || Path == null)
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + "DataBase.Ini";
            if (Section == "")
                Section = Environment.UserName;
            WritePrivateProfileString(Section, Key, Value, Path);
        }
        //写INI文件 
        public static void WriteIniValue(string FileName, string Section, string Key, string Value)
        {
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + FileName;

            Section = Environment.UserName;
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        // 验证文件是否存在，返回布尔值
        public static bool ExistINIFile()
        {
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + "DataBase.Ini";
            return File.Exists(Path);
        }

        // 验证文件是否存在，返回布尔值
        public static bool ExistINIFile(string filename)
        {
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + filename;
            return File.Exists(Path);
        }
    }
}