using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//using

namespace ConfigCPUCoreLib
{
    public class ConfigCPUCore
    {
        //SetThreadAffinityMask 指定hThread 运行在 核心 dwThreadAffinityMask  
        [DllImport("kernel32.dll")]
       public static extern UIntPtr SetThreadAffinityMask(IntPtr hThread, UIntPtr dwThreadAffinityMask);

        //得到当前线程的handler  
        [DllImport("kernel32.dll")]
       public static extern IntPtr GetCurrentThread();

        //获取cpu的id号  
       public static ulong SetCpuID(int id)
        {
            ulong cpuid = 0;
            if (id < 0 || id >= System.Environment.ProcessorCount)
            {
                id = 0;
            }
            cpuid |= 1UL << id;

            return cpuid;
        }


        //将当前线程绑定到指定的cpu核心上  
        public static void ConfigCPUCoreProc(ulong cpuid)       
        {
                //ulong cpuid = SetCpuID(core);
                //ulong cpuid = 2;
                SetThreadAffinityMask(GetCurrentThread(), new UIntPtr(cpuid));
        }

    }
}
