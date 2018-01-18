using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace OCTCalLib
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential,CharSet = CharSet.Ansi)]
    public struct tOCTAlgorithmParasSettings
    {

        /// int
        public int streamNum;

        /// int
        public int Width;

        /// int
        public int Height;

        /// size_t->unsigned int
        public System.UInt64 count;

        /// unsigned int
        public uint InterpGridSize;

        /// unsigned int
        public uint InterpBlockSize;

        /// unsigned int
        public uint SubGridSize;

        /// unsigned int
        public uint SubBlockSize;

        /// float
        public float C0;

        /// float
        public float C1;

        /// float
        public float C2;

        /// float
        public float C3;

        /// float
        public float a2;

        /// float
        public float a3;
    }




    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct tOCTAlgorithmParas
    {
        /// int*
        public System.IntPtr streams;

        /// int*
        public System.IntPtr cufftPlan;

        /// short*
        public System.IntPtr d_background;

        /// float*
        public System.IntPtr d_hi;

        /// float*
        public System.IntPtr d_B;

        /// float*
        public System.IntPtr d_C;

        /// float*
        public System.IntPtr d_dx;

        /// int*
        public System.IntPtr d_xxstep;

        /// int*
        public System.IntPtr d_H;

        /// float*
        public System.IntPtr d_D;

        /// float*
        public System.IntPtr d_bi;

        /// float*
        public System.IntPtr d_di;

        /// short*
        public System.IntPtr d_y;

        /// short*
        public System.IntPtr h_y;

        /// float*
        public System.IntPtr d_yy;

        /// unsigned char*
        //[System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)]
        //public string d_OCTOutputDatas;
        public System.IntPtr d_OCTOutputDatas;

        /// int
        public int streamNum;

        /// int
        public int Width;

        /// int
        public int Height;

        /// size_t->unsigned int
        //public uint count;
        public System.UInt64 count;

        /// unsigned int
        public uint InterpGridSize;

        /// unsigned int
        public uint InterpBlockSize;

        /// unsigned int
        public uint SubGridSize;

        /// unsigned int
        public uint SubBlockSize;

        /// unsigned int
        public uint StartIndex;

        /// unsigned int
        public uint EndIndex;
    }


    public class OCTCal
    {
        /*
        函数：写入二进制数据
        参数：Datas是需要写入的数据指针
        count是写入数据的个数
        返回：0则是success
        */
        //GPUDLL_API int WriteBinData(char* path, short* Datas, size_t count);
        //[DllImport(@"E:\SJZD-ele\SJZDProject2017120501-opencv\SJZDEyes\OCT\bin\Debug\gpudll.dll", CharSet = CharSet.Ansi, EntryPoint = "WriteBinData", CallingConvention = CallingConvention.Cdecl)]
        [DllImport("gpudll", CharSet = CharSet.Ansi, EntryPoint = "WriteBinData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int WriteBinData(string path, System.IntPtr Datas, System.UInt64 count);


        /*
        函数：读取二进制数据
        参数：Datas是需要读取的数据指针
        count是写入数据的个数
        返回：0则是success
        */
        //GPUDLL_API int ReadBinData(char* path, short* Datas, size_t count);
        //[DllImport(@"E:\SJZD-ele\SJZDProject2017120501-opencv\SJZDEyes\OCT\bin\Debug\gpudll.dll", CharSet = CharSet.Ansi, EntryPoint = "ReadBinData", CallingConvention = CallingConvention.Cdecl)]
        [DllImport("gpudll", CharSet = CharSet.Ansi, EntryPoint = "ReadBinData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ReadBinData(string path, System.IntPtr Datas, System.UInt64 count);

        /*
        函数：初始化OCT计算资源
        参数：OCTAlgorithmParas是需要初始化的结构体数据指针
        OCTAlgorithmParasSettings是传入参数的结构体指针
        返回：0则是success
        */
        
        [DllImport("gpudll", CharSet = CharSet.Ansi, EntryPoint = "InitOCTAlgorithmParas", CallingConvention = CallingConvention.Cdecl)]    
        public static extern int InitOCTAlgorithmParas(ref tOCTAlgorithmParas OCTAlgorithmParas, ref tOCTAlgorithmParasSettings OCTAlgorithmParasSettings);


        [DllImport("gpudll", CharSet = CharSet.Ansi, EntryPoint = "InitOCTAlogrithmOutputDatas", CallingConvention = CallingConvention.Cdecl)]      
        public static extern System.IntPtr InitOCTAlogrithmOutputDatas(System.UInt64 count);

        /*
        函数：OCT计算
        参数：h_OCTOutputDatas是输出数据指针
        pDatas是输入数据指针
        OCTAlgorithmParas是OCT计算资源
        返回：0则是success
        */
        //GPUDLL_API int OCTEXE(unsigned char* h_OCTOutputDatas, short* pDatas, tOCTAlgorithmParas* OCTAlgorithmParas);
        [DllImport("gpudll", CharSet = CharSet.Ansi, EntryPoint = "OCTEXE", CallingConvention = CallingConvention.Cdecl)]
        public static extern int OCTEXE(System.IntPtr h_OCTOutputDatas, System.IntPtr pDatas, ref tOCTAlgorithmParas OCTAlgorithmParas);



        /*
        函数：OCT计算资源释放
        参数：OCTAlgorithmParas是OCT计算资源
        返回：0则是success
        */
        //GPUDLL_API int OCTAlgorithmParasFree(tOCTAlgorithmParas *OCTAlgorithmParas, unsigned char *h_OCTOutputDatas);
        [DllImport("gpudll")]
        public static extern int OCTAlgorithmParasFree(ref tOCTAlgorithmParas OCTAlgorithmParas, System.IntPtr h_OCTOutputDatas);


    }
}
