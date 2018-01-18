using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USB3WinApiSpace;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;

namespace GlobalToolSpace
{
    public class GlobalTools
    {
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //public static string readIniValue(string Key)
        //{
        //    string Path = System.AppDomain.CurrentDomain.BaseDirectory + "DataBase.Ini";
        //    StringBuilder temp = new StringBuilder(255);

        //    int i = GetPrivateProfileString(Environment.UserName, Key, "", temp, 255, Path);
        //    return temp.ToString();
        //}

        //public static string readIniValue(string section, string Key)
        //{
        //    string Path = System.AppDomain.CurrentDomain.BaseDirectory + "DataBase.Ini";
        //    StringBuilder temp = new StringBuilder(255);

        //    int i = GetPrivateProfileString(section, Key, "", temp, 255, Path);
        //    return temp.ToString();
        //}

        public static string readIniValue(string FileName, string section, string Key)
        {
            string Path = System.AppDomain.CurrentDomain.BaseDirectory + FileName;
            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString(section, Key, "", temp, 255, Path);
            return temp.ToString();
        }
        ////写INI文件 
        //public static void WriteIniValue(string Section, string Key, string Value)
        //{
        //    //if (Path == "" || Path == null)
        //    string Path = System.AppDomain.CurrentDomain.BaseDirectory + "DataBase.Ini";
        //    if (Section == "")
        //        Section = Environment.UserName;
        //    WritePrivateProfileString(Section, Key, Value, Path);
        //}
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
        /// <summary>
        /// Change a int variable into conressponding two HEX char,for example:int valiable = 32 => hex valiable = 20
        /// </summary>
        /// <param name="sourceByte"></param>
        /// <returns></returns>
        public static string ChangeByteToCorrespondStr(byte[] soureBytes, int size)
        {
            StringBuilder m_AllHex = new StringBuilder();
            m_AllHex.Clear();
            for (int i = 0; i < size; i++)
            {
                string m_Hex = Convert.ToString(soureBytes[i], 16);
                if (m_Hex.Length < 2) m_Hex = "0" + m_Hex;
                m_AllHex.Append(m_Hex);
            }
            return m_AllHex.ToString();
        }
        /// <summary>
        /// Reverse bytes string becasue of the little endian memory in usb3 camera.
        /// </summary>
        /// <param name="soureStr"></param>
        /// <returns></returns>
        public static string ReverseBytesStr(string soureStr)
        {
            StringBuilder m_newBuiler = new StringBuilder();
            for (int i = soureStr.Length / 2 - 1; i >= 0; i--)
            {
                string subStr = soureStr.Substring(i * 2, 2);
                m_newBuiler.Append(subStr);
            }
            return m_newBuiler.ToString();
        }

        public static string ReverseBytesStrOneByOne(string soureStr)
        {
            StringBuilder m_newBuiler = new StringBuilder();
            for (int i = soureStr.Length - 1; i >= 0; i--)
            {
                string subStr = soureStr.Substring(i, 1);
                m_newBuiler.Append(subStr);
            }
            return m_newBuiler.ToString();
        }

        /// <summary>
        /// Read USB3 Register value by register address
        /// </summary>
        /// <param name="hCamera"></param>
        /// <param name="ulAddress"></param>
        /// <param name="sizeCount"></param>
        /// <returns></returns>
        public static byte[] ReadUSB3Register(IntPtr hCamera, ulong ulAddress, int sizeCount)
        {
            try
            {
                byte[] targetreadBytes = new byte[sizeCount];
                UInt64 m_piSize = (UInt64)sizeCount;
                ulong m_ulAddress = ulAddress;
                byte[] m_unmanageBuffer = new byte[sizeCount];
                GCHandle hObject = GCHandle.Alloc(m_unmanageBuffer, GCHandleType.Pinned);//difine this is the unmanaged memory
                IntPtr pObject = hObject.AddrOfPinnedObject();
                Int32 readValue = USB3WinAPI.USB3_ReadRegister(hCamera, m_ulAddress, pObject, ref m_piSize);
                Marshal.Copy(pObject, targetreadBytes, 0, sizeCount);
                if (hObject.IsAllocated) hObject.Free();//Free the unmanaged memory
                return targetreadBytes;
            }
            catch (Exception ep)
            {
                return null;
            }
        }
        /// <summary>
        /// Write USB3 Register value by register address
        /// </summary>
        /// <param name="hCamera"></param>
        /// <param name="ulAddress"></param>
        /// <param name="sendBytes"></param>
        /// <param name="sizeCount"></param>
        public static void WriteUSB3Register(IntPtr hCamera, ulong ulAddress, byte[] sendBytes, int sizeCount)
        {
            try
            {
                UInt64 m_piSize = (UInt64)sizeCount;
                ulong m_ulAddress = ulAddress;
                GCHandle hObject = GCHandle.Alloc(sendBytes, GCHandleType.Pinned);//Indicate unmanaged memory
                IntPtr pObject = hObject.AddrOfPinnedObject();
                Int32 readValue = USB3WinAPI.USB3_WriteRegister(hCamera, m_ulAddress, pObject, ref m_piSize);
                if (hObject.IsAllocated) hObject.Free();
            }
            catch (Exception ep)
            {

            }
        }
        /// <summary>
        /// Hex String To Hex Bytes
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] HexStringToHexBytes(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                //Console.WriteLine(returnBytes[i].ToString());
            }
            return returnBytes;
        }

        public static bool IsNumeric(string value)
        {
            //return Regex.IsMatch(value, @"^[+-]?/d*[.]?/d*$");

            return Regex.IsMatch(value, @"^[+-]?\d*[.]?\d*$");
        }
        /// <summary>
        /// Change a string into Ascii code string ,if the string length is not equals size val,then we add '0' to compensend.
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string StringToAsciiStr(string sourceStr, int size)
        {
            byte[] m_AsciiCode = Encoding.Default.GetBytes(sourceStr);
            StringBuilder m_sb = new StringBuilder();
            for (int i = 0; i < m_AsciiCode.Length; i++)
            {
                m_sb.Append(m_AsciiCode[i].ToString("x2"));//Change to 1 byte 16 hex string
            }
            string m_ChangedStr = m_sb.ToString();
            m_ChangedStr = m_ChangedStr.PadRight(size * 2, '0');
            return m_ChangedStr;
        }

        //快速求出三点之间的夹角
        public static double GetAngle(Point first, Point cen, Point second)
        {
            const double M_PI = 3.1415926535897;
            double ma_x = first.X - cen.X;
            double ma_y = first.Y - cen.Y;
            double mb_x = second.X - cen.X;
            double mb_y = second.Y - cen.Y;
            double v1 = (ma_x * mb_x) + (ma_y * mb_y);
            double ma_val = Math.Sqrt(ma_x * ma_x + ma_y * ma_y);
            double mb_val = Math.Sqrt(mb_x * mb_x + mb_y * mb_y);
            double cosM = v1 / (ma_val * mb_val);
            double angleAMB = Math.Acos(cosM) * 180 / M_PI;
            return angleAMB;
        }

        //求2个坐标点之间的距离
        public static int GetLengthBeteenTwoPoint(Point OrigialPoint,Point CurrentPoint)
        {
            //double _length = Math.Sqrt(((double)CurrentPoint.X - (double)OrigialPoint.X) * ((double)CurrentPoint.X - (double)OrigialPoint.X) + ((double)CurrentPoint.Y - (double)OrigialPoint.Y) * ((double)CurrentPoint.Y - (double)OrigialPoint.Y));
            double _length = Math.Sqrt((CurrentPoint.X - OrigialPoint.X) * (CurrentPoint.X - OrigialPoint.X) + (CurrentPoint.Y - OrigialPoint.Y) * (CurrentPoint.Y - OrigialPoint.Y));
            return (int)_length;
        }
    }

    public class myTools
    {
        private string _myToolName = "";

        public myTools(string myToolName)
        {
            _myToolName = myToolName;

        }  
    
    }
 }
