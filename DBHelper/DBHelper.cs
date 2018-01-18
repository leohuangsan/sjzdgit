using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DBHelperLib
{
    public class DBHelper
    {
        public static SqlConnection m_SqlConnection
        {            
            get
            {
                //SqlConnection conn = new SqlConnection("Data Source=PC-20171108OGNX;Initial Catalog=sjzddb;Persist Security Info=True;User ID=sa;Password=sjzd123456!");
                SqlConnection conn = new SqlConnection("Data Source=PC-20171108OGNX;Initial Catalog=sjzddb;User ID=sa;Password=sjzd123456!");
                //conn.ConnectionTimeout = 60000;
                conn.Open();
                return conn;
            }
        }

        public static int ExecuteNonQuery(string dml)
        {
            using (SqlConnection conn = m_SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand(dml, conn))
                    try
                    {
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
            }
        }

        public static void ExecSql(string dml)
        {
            using (SqlConnection conn = m_SqlConnection)
            {
                using (SqlCommand cmd = new SqlCommand(dml, conn))
                    try
                    {
                        cmd.ExecuteNonQuery();
                        //Thread.Sleep(10);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
            }
        }
        public static DataTable openDataTable(string sql)
        {
            using (SqlConnection conn = m_SqlConnection)
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                        da.Fill(dt);
                    return dt;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        /// <summary>
        /// 获取所有的用户名
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUserName()
        {
            string sql = "select DoctorID,DoctorName from tb_Doctor";
            return openDataTable(sql);
        }
        /// <summary>
        /// 查询数据库，检测是否存在用户输入的用户名及密码，
        /// 输入：string Username,string Passwowrd；输出：bool
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Passwowrd"></param>
        /// <returns></returns>
        public static bool IsExistUserPasswrod(string LoginID,string Username,string Passwowrd)
        {
            string sql = "select DoctorID,DoctorName,Password from tb_Doctor where  DoctorID =" + LoginID + " and  DoctorName = '" + Username + "' and password = '" + Passwowrd + "'";
            using (DataTable dt = DBHelperLib.DBHelper.openDataTable(sql))
            {
                if (dt.Rows.Count <= 0) return false;
                else return true;
            }
        }

        //自动生成病人ID号
        public static UInt64 GenerateUserID()
        {
            UInt64 m_GenerateNewID = 0;
            string m_TodayDateStr = DateTime.Now.ToString("yyyyMMdd");
            string sql = "select PatientID from tb_Patients order by PatientID desc";
            using (DataTable dt = DBHelperLib.DBHelper.openDataTable(sql))
            {
                if (dt.Rows.Count == 0)
                {
                    m_GenerateNewID = UInt64.Parse(m_TodayDateStr + "0001");
                }
                else
                {
                    if (dt.Rows[0][0].ToString().Contains(m_TodayDateStr))
                    {
                        m_GenerateNewID = UInt64.Parse(dt.Rows[0][0].ToString()) + 1;
                    }
                    else
                    {
                        m_GenerateNewID = UInt64.Parse(m_TodayDateStr + "0001");
                    }
                }                
                return m_GenerateNewID;                           
            }
        }

        //生成采集ID号
        public static UInt64 GenerateAcqID(UInt64 PatientIDVal)
        {
            UInt64 m_GenerateAcqID = 0;
            //string m_TodayDateStr = DateTime.Now.ToString("yyyyMMdd");
            string sql = "select AcquisitionID,PatientID,Acquisitionname from tb_Acquisitions where PatientID = " + PatientIDVal + " order by AcquisitionID DESC";
            using (DataTable dt = DBHelperLib.DBHelper.openDataTable(sql))
            {                
                if (dt.Rows.Count == 0)
                {
                    m_GenerateAcqID = UInt64.Parse(PatientIDVal.ToString() + "0001");
                }
                else
                {
                    m_GenerateAcqID = UInt64.Parse(dt.Rows[0][0].ToString()) + 1;
                }
            }
            return m_GenerateAcqID;
        }
        /// <summary>
        /// 插入病人信息到数据库中
        /// </summary>
        /// <returns></returns>
        public static void InsertPatientInfo(string Name,string Gender,string Race,string Birthday,UInt64 PatientID,UInt64 SFZID)
        {
            //string sql = "insert into tb_Patients(PatientID,Name,Gender,Race,Birthday) Values(" + PatientID + ",'" + Name + "'," + 0 + ",'" + Race + "',to_date('" + Birthday + "','yyyymmdd'))" ;
            //cast('2010-01-01' as datetime)
            int m_GenderVal = (Gender=="男") ? 1 : 0;
            string sql = "insert into tb_Patients(PatientID,Name,Gender,Race,Birthday,SFZID) Values(" + PatientID + ",'" + Name + "'," + m_GenderVal + ",'" + Race + "',cast('" + Birthday + "' as datetime)," + SFZID + ")";
            ExecSql(sql);
        }
        /// <summary>
        /// 插入采集信息到数据库中
        /// </summary>
        public static void InsertAcquisitionInfo(UInt64 AcqID,UInt64 PatientID,string OriginalPath, string ResultPath, string LogDoctorID)
        {
            string sql = "insert into tb_Acquisitions(AcquisitionID,PatientID,Originalpath,Resultpath,DoctorID) Values(" + AcqID + "," + PatientID + ",'" + OriginalPath + "','" + ResultPath + "'," + LogDoctorID + ")";
            ExecSql(sql);
        }
        /// <summary>
        /// 获取所有病人信息的记录
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllPatientInfos()
        {
            string sql = "select PatientID as 病人ID,Name as 姓名,Case Gender when 1 then '男' when 0 then '女' end as 性别,Race as 民族,Birthday as 出生日期,Telephone as 电话,Email as 邮箱,Address as 地址,Memo as 诊断,Firstname as 名字,Lastname as 姓氏,Prefix as 前缀,subfix as 后缀,SFZID as 身份证 from tb_Patients order by PatientID";
            return openDataTable(sql);
        }

        /// <summary>
        /// 根据病人ID删除病人记录信息
        /// </summary>
        /// <param name="PatientID"></param>
        public static void DeletePatientInfoByPatientsID(UInt64 PatientID)
        {
            string sql = "delete from tb_Patients where PatientID = " + PatientID;
            ExecSql(sql);
        }
        /// <summary>
        /// 根据给定的条件查询数据库
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable SelectRecordByCondition(string sql)
        {
            return openDataTable(sql);
        }

        //根据指定的采集ID 删除采集列表中记录
        public static void DeleteAcqRecordByAcqID(UInt64 AcquisitionIDVal)
        {
            string sql = "delete from tb_Acquisitions where AcquisitionID = " + AcquisitionIDVal;
            ExecSql(sql);
        }

        //根据条件、表名删除记录
        public static void DeleteRecords(string TableName,string Conditions)
        {
            string sql = "delete from " + TableName + " where " + Conditions;
            ExecSql(sql);
        }
        //根据条件、表名更新记录
        public static void UpdateRecords(string TableName, string SetVal, string Conditions)
        {
            string sql = "Update " + TableName + " set" + SetVal + " where " + Conditions;
            ExecSql(sql);
        }

        //根据值、表名、字段插入记录
        public static void InsertRecords(string TableName, string Fields, string Vals)
        {
            string sql = "Insert into " + TableName + "(" + Fields + ")" + " Values(" + Vals + ")";
            ExecSql(sql);
        }

        // 根据条件、表名、字段查询记录
        public static DataTable QueryRecords(string TableName, string Fields, string Conditions)
        {
            string sql = "select "+ Fields + " from " + TableName + " Where " + Conditions;
            return openDataTable(sql);
        }
    }
}
