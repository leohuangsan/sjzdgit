using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AveBitmapLib
{

    //输入结构体  
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct visionAveInfo
    {
        public double matchScale;//匹配缩放率
        public int xyPianYiMax;//允许XY方向单独偏移的最大值
        public int aveMethor;//求叠加和平均方法， 可选1  2
        public byte modelInfoShow_Flag;//是否显示模板信息
        public byte findInfoShow_Flag;//是否显示目标信息
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    //输出结构体 
    public struct visionAveOutput
    {
        public int width;//输出图像宽度
        public int height;//输出图像高度
        public int step;//输出图像阶数
        public IntPtr data;//输出图像数据指针
        public byte resultFlag;//输出是否成功标志
    }

    public class AveBitmapCal
    {
        [DllImport("visionAve_DLL_one.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void visionCloseAllWindows();//关闭opencv显示窗口

        [DllImport("visionAve_DLL_one.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int fnvisionAve_DLL_one(string[] filename, int fileNum);


        /*************************************************************
       *********** 平均图处理函数1
       **************************************************************/
        [DllImport("visionAve_DLL_one.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int viAveAddImg(string filename);//Emgucv往结构加入图像
        [DllImport("visionAve_DLL_one.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int visionAveFunc(visionAveInfo aveInfo);//读取bmp图像的平均图程序



        /*************************************************************
       *********** 平均图处理函数2
       **************************************************************/
        [DllImport("visionAve_DLL_one.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int viAvePro_AddImg(IntPtr image);//Emgucv往结构加入图像
        [DllImport("visionAve_DLL_one.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int visionAveFunc_Pro(visionAveInfo aveInfo);//Emgucv往结构的平均图程序
        [DllImport("visionAve_DLL_one.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int viAvePro_ClearBuf();//Emgucv往结构的清空缓存

        [DllImport("visionAve_DLL_one.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern visionAveOutput getAveOutputImg();
    }
}
