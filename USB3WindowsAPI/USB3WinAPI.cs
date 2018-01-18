using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace USB3WinApiSpace
{

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct tCameraInfo
    {
        // char myPwd[1024];
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string pcID;
    }
    //public struct tCameraInfo 
    //{ 
    //   public byte[] pcID;
    //}

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public class tImageInfos
    {

        /// void*
        public System.IntPtr hBuffer;

        /// void*
        public System.IntPtr pDatas;

        /// size_t->unsigned int
        public System.UInt64 iBufferSize;

        /// size_t->unsigned int
        public System.UInt64 iImageSize;

        /// size_t->unsigned int
        public System.UInt64 iOffsetX;

        /// size_t->unsigned int
        public System.UInt64 iImageWidth;

        /// size_t->unsigned int
        public System.UInt64 iImageHeight;

       public tImagePixelType eImagePixelType;

        /// size_t->unsigned int
        public System.UInt64 iLinePitch;

        /// unsigned short
        public ushort iHorizontalFlip;

        /// unsigned int
        public System.UInt64 iNbMissedTriggers;

        /// unsigned int
        public System.UInt64 iNbLineLost;

        /// unsigned int
        public System.UInt64 iNbImageAcquired;

        /// unsigned int
        public System.UInt64 iFrameTriggerNbValidLines;
    }  

    //public struct tThreadParam
    //{
    //    IntPtr hCamera;
    //    IntPtr  pbCancel;
    //    IntPtr pbImageAcquired;
    //    int ulNbImageToAcquire;
    //    int ulTimeoutAcq;
    //    IntPtr pnErrorThreadAcq;   
    
    //}
    public enum tImagePixelType
    {

        /// eUnknown -> 0
        eUnknown = 0,

        /// eMono8 -> 1
        eMono8 = 1,

        /// eMono10 -> 2
        eMono10 = 2,

        /// eMono11 -> 3
        eMono11 = 3,

        /// eMono12 -> 4
        eMono12 = 4
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
        public static tImageInfos ImageInfos = new tImageInfos(); //This is the struct that used to store image information
               

        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_InitializeLibrary",CallingConvention = CallingConvention.Cdecl)]
        //Locate SDK resources
        public static extern int USB3_InitializeLibrary();

        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_UpdateCameraList", CallingConvention = CallingConvention.Cdecl)]
        //This function allows to update the camera list and to get the number of cameras present on the system 
        public static extern int USB3_UpdateCameraList(ref ulong pulNbCameras);


        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll",CharSet = CharSet.Ansi,EntryPoint = "USB3_GetCameraInfo", CallingConvention = CallingConvention.Cdecl)]
        //This function retrieves the camera info for the given index 
        public static extern int USB3_GetCameraInfo(ulong numberIndex, ref tCameraInfo pCameraInfo);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_OpenCamera", CallingConvention = CallingConvention.Cdecl)]
        //Opens the communication to a camera 
        public static extern int USB3_OpenCamera(ref tCameraInfo pCameraInfo, ref IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_SetImageParameters", CallingConvention = CallingConvention.Cdecl)]
         //This function allows to set the image parameters: height of the image and the number of buffers for the images 
         public static extern int USB3_SetImageParameters(IntPtr hCamera, uint iImageHeight, uint iNbOfBuffer);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_StartAcquisition", CallingConvention = CallingConvention.Cdecl)]
         //This function allows to start the acquisition engine for the specified camera  
         public static extern int USB3_StartAcquisition(IntPtr hCamera);

        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_StopAcquisition", CallingConvention = CallingConvention.Cdecl)]
        //This function allows to start the acquisition engine for the specified camera  
        public static extern int USB3_StopAcquisition(IntPtr hCamera);

        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_AbortGetBuffer", CallingConvention = CallingConvention.Cdecl)]
         //This function allows to unblock any waiting call to the USB3_GetBuffer
         public static extern int USB3_AbortGetBuffer(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_FlushBuffers", CallingConvention = CallingConvention.Cdecl)]
         //This function allows to flush all buffers from the output queue to the input queue 
         //if you don't requeue buffer, the acquisition engine risks to have a buffer starvation 
         public static extern int USB3_FlushBuffers(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_CloseCamera", CallingConvention = CallingConvention.Cdecl)]
         //This function closes the communication with the camera        
         public static extern int USB3_CloseCamera(IntPtr hCamera);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_TerminateLibrary", CallingConvention = CallingConvention.Cdecl)]
         //This function allows to terminate the Camera Library        
         public static extern int USB3_TerminateLibrary();

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_GetBuffer", CallingConvention = CallingConvention.Cdecl)]
         //This function allows to get a grabbed buffer from the SDK acquisition engine output queue 
         public static extern int USB3_GetBuffer(IntPtr hCamera, tImageInfos pImageInfos,ulong ulTimeoutInMs);

         [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_RequeueBuffer", CallingConvention = CallingConvention.Cdecl)]
        //This function allows to requeue a buffer that was successfully obtained via USB3_GetBuffer api to the input queue. 
        //After being requeued, the buffer can be used again by the SDK acquistion engine. 
        //if you don't requeue buffer, the acquisition engine risks to have a buffer starvation 
         public static extern int USB3_RequeueBuffer(IntPtr hCamera,IntPtr hBuffer);

        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_ReadRegister", CallingConvention = CallingConvention.Cdecl)]
        //This function allows to terminate the Camera Library        
        public static extern int USB3_ReadRegister(IntPtr hCamera,ulong ulAddress, System.IntPtr pBuffer, ref UInt64 piSize);

        [DllImport(@"C:\Program Files\Teledyne e2v\CameraCmosOctUsb3\SDK\lib\x64\CamCmosOctUsb3.dll", CharSet = CharSet.Ansi, EntryPoint = "USB3_WriteRegister", CallingConvention = CallingConvention.Cdecl)]
        //This function allows to terminate the Camera Library        
        public static extern int USB3_WriteRegister(IntPtr hCamera, ulong ulAddress, IntPtr pBuffer, ref UInt64 piSize);
                
    }
}