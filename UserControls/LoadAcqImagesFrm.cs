using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UserControlsLib
{
    public partial class LoadAcqImagesFrm : Form
    {
       public List<string> imageLists = new List<string>();
        //ImageList imageList1 = new ImageList();
        private static object lockers = new object();
        public string m_AcqPath = "";
        public string m_PatientID = "";

        public LoadAcqImagesFrm()
        {
            InitializeComponent();
            //imageList1.ImageSize = new Size(200,200);
            //this.BackColor = Color.LightGreen;
            Image image = SkinLib.SkinResource.BackGround2;
            listView1.BackgroundImage = image;
            listView1.BackgroundImageLayout = ImageLayout.Stretch;
         
        }
        public void LoadImageFiles()
        {
            imageList1.Images.Clear();
            listView1.Items.Clear();
            imageLists.Clear();
            //刷新Listview
            BindListView();

        }

        private void BindListView()
        {            
            string sql = "select Resultpath from tb_Acquisitions where PatientID = " + this.m_PatientID;
            using (DataTable dt =  DBHelperLib.DBHelper.SelectRecordByCondition(sql))
            {
                if (dt.Rows.Count == 0)
                {
                    return;
                }
                else
                {
                    for (int i = 0; i< dt.Rows.Count; i++)
                    {
                        string m_Resultpath = dt.Rows[i][0].ToString();
                        imageLists.Add(@m_Resultpath);
                    }                    
                }
            }
            //DirectoryInfo dir = new DirectoryInfo(m_AcqPath);
            //FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
            //foreach (FileSystemInfo i in fileinfo)
            //{
            //    if (i is DirectoryInfo)            //判断是否文件夹
            //    {
            //        //DirectoryInfo subdir = new DirectoryInfo(i.FullName);
            //        //subdir.Delete(true);          //删除子目录和文件
            //    }
            //    else
            //    {
            //        //File.Delete(i.FullName);      //删除指定文件
            //        imageLists.Add(@i.FullName);
            //    }
            //}
            for (int i = 0; i < imageLists.Count; i++)
            {
                imageList1.Images.Add(System.Drawing.Image.FromFile(imageLists[i].ToString()));
                listView1.Items.Add(System.IO.Path.GetFileName(imageLists[i].ToString()), i);
                listView1.Items[i].ImageIndex = i;
                listView1.Items[i].Name = imageLists[i].ToString();//绝对路径 + 文件名.扩展名
                //listView1.Items[i].Text = imageLists[i].ToString();
                listView1.Items[i].Text = System.IO.Path.GetFileName(imageLists[i].ToString());
                listView1.Items[i].Font = new Font("宋体", 9, FontStyle.Regular);

            }
        }

      

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right && e.Clicks == 1)
            //{
            //    //MessageBox.Show( "您单击了鼠标右键！");
            //    ContextMenuStrip onlyfornumber1 = new ContextMenuStrip();
            //    //右键菜单加入一个hello选项
            //    onlyfornumber1.Items.Add("删除全部");
            //    //onlyfornumber1.Items.Add("删除");
            //    //点击hello选项时发生onlyfornumber3_Click事件
            //    onlyfornumber1.Items[0].Click += onlyfornumberDelAll_Click;
            //    //onlyfornumber1.Items[1].Click += onlyfornumberDel_Click;
            //    onlyfornumber1.Show(listView1, e.X, e.Y);
            //}
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right && e.Clicks == 1)
            //{
            //    //MessageBox.Show("您单击了鼠标右键！");
            //    //contextMenuStrip1 =
            //    ContextMenuStrip onlyfornumber3 = new ContextMenuStrip();
            //    //右键菜单加入一个hello选项
            //    onlyfornumber3.Items.Add("编辑");
            //    onlyfornumber3.Items.Add("删除");
            //    //点击hello选项时发生onlyfornumber3_Click事件
            //    onlyfornumber3.Items[0].Click += onlyfornumber3_Click;
            //    onlyfornumber3.Items[1].Click += onlyfornumberDel_Click;
            //    onlyfornumber3.Show(listView1, e.X, e.Y);
            //}
        }

        private void onlyfornumber3_Click(object sender, EventArgs e)
        {            
            if (listView1.SelectedItems.Count == 0) return;
            //MessageBox.Show(listView1.SelectedItems[0].Name);
            string _AcqIDstr = listView1.SelectedItems[0].Text.TrimEnd(".bmp".ToArray());
            UInt64 _AcqID = UInt64.Parse(_AcqIDstr);
            AcqResultAnalizeFrm m_AcqResultAnalizeFrm = new AcqResultAnalizeFrm();
            //Bitmap m_ResqultBitmap = new Bitmap(listView1.SelectedItems[0].Name);
            m_AcqResultAnalizeFrm.m_AcqID = _AcqID;//采集ID传入窗体中
            m_AcqResultAnalizeFrm.m_LoadAcqImagesFrm = this;//当前窗体引用传入
            //m_AcqResultAnalizeFrm.AnalizePictrueBox.BackgroundImage = m_ResqultBitmap;
            //m_AcqResultAnalizeFrm.OriginalPictrueBox.BackgroundImage = m_ResqultBitmap;
            m_AcqResultAnalizeFrm.m_AcqResltFile = listView1.SelectedItems[0].Name;
            m_AcqResultAnalizeFrm.StartPosition = FormStartPosition.CenterScreen;
            m_AcqResultAnalizeFrm.ShowDialog();
        }
        /// <summary>
        /// 删除LISTVIEW中的图像及硬盘中的图像
        /// </summary>
        public void DeleteImageFromListViewDsik(string NeedToDelImageName)
        {         
            //if (listView1.SelectedItems.Count == 0) return;
            //MessageBox.Show(listView1.SelectedItems[0].Name);
            string m_NeedToDelImageName = NeedToDelImageName;//获取要被删除的图片文件名
            int m_DelFileIndexInList = -1;
            foreach (string aFile in imageLists)
            {
                m_DelFileIndexInList = imageLists.IndexOf(aFile);//获取当前aFile的索引 

            }
            listView1.Items.Clear();
            //imageList1.Images[m_DelFileIndexInList].Dispose();

            foreach (Image _image in imageList1.Images)
            {
                _image.Dispose();                
            }
            
                      
            //imageList1.Images.RemoveAt(m_DelFileIndexInList);
            imageList1.Images.Clear();
            imageLists.Remove(@m_NeedToDelImageName);

            System.GC.Collect();//强制回收垃圾，否则会报另一个进程正在使用此文件
            System.Threading.Thread.Sleep(500);
            lock (lockers)
            {
                if (File.Exists(@m_NeedToDelImageName))
                {
                    FileInfo finfo = new FileInfo(@m_NeedToDelImageName);
                   
                    try
                    {
                        if (finfo.Exists)
                        {
                            finfo.Attributes = FileAttributes.Archive;
                            finfo.Delete();
                            //仅当文件被删除成功后才删除数据库中采集表中的记录
                            //string m_AcqID = Path.GetFileNameWithoutExtension(@m_NeedToDelImageName).Trim();//获取不含扩展名的文件名，即采集ID
                            //DBHelperLib.DBHelper.DeleteAcqRecordByAcqID(UInt64.Parse(m_AcqID));//删除对应的采集记录
                           
                        }
                        //File.Delete(m_NeedToDelImageName);                  
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("文件被占用，请重新删除！");
                    }
                }                
            }
        }


        private void onlyfornumberDel_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            //MessageBox.Show(listView1.SelectedItems[0].Name);
            string m_NeedToDelImageName = listView1.SelectedItems[0].Name;//获取要被删除的图片文件名
            int m_DelFileIndexInList = -1;
            foreach (string aFile in imageLists)
            {
                m_DelFileIndexInList = imageLists.IndexOf(aFile);//获取当前aFile的索引 

            }           
            listView1.Items.Clear();           
            imageList1.Images[m_DelFileIndexInList].Dispose();
            
            System.GC.Collect();//强制回收垃圾，否则会报另一个进程正在使用此文件
            imageList1.Images.RemoveAt(m_DelFileIndexInList);         
            imageLists.Remove(@m_NeedToDelImageName);

           
            lock (lockers)
            {
                if (File.Exists(@m_NeedToDelImageName))
                {
                    FileInfo finfo = new FileInfo(@m_NeedToDelImageName);                    
                    System.Threading.Thread.Sleep(200);
                    try
                    {
                        if (finfo.Exists)
                        {
                            finfo.Attributes = FileAttributes.Normal;
                            finfo.Delete();
                            //仅当文件被删除成功后才删除数据库中采集表中的记录
                            string m_AcqID = Path.GetFileNameWithoutExtension(@m_NeedToDelImageName).Trim();//获取不含扩展名的文件名，即采集ID
                            DBHelperLib.DBHelper.DeleteAcqRecordByAcqID(UInt64.Parse(m_AcqID));//删除对应的采集记录
                            DBHelperLib.DBHelper.DeleteRecords("tb_Graphics","AcquisitionID = " + m_AcqID);//删除对应的图形

                            //finfo.Close();
                        }
                        //File.Delete(m_NeedToDelImageName);                  
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("文件被占用，请重新删除！");
                    }
                }
                LoadImageFiles();
            }
        }
        private void onlyfornumberDelAll_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            for (int i = 0; i < imageLists.Count; i++)
            {
                //imageList1.Images[i] = null;
                imageList1.Images[i].Dispose();
                System.GC.Collect();//强制回收垃圾，否则会报另一个进程正在使用此文件
                //imageList1.Images.RemoveAt(i);
                if (File.Exists(@imageLists[i].ToString()))
                {
                    FileInfo finfo = new FileInfo(@imageLists[i].ToString());                    
                    System.Threading.Thread.Sleep(200);
                    try
                    {
                        if (finfo.Exists)
                        {
                            finfo.Attributes = FileAttributes.Normal;
                            finfo.Delete();
                            //仅当文件被删除成功后才删除数据库中采集表中的记录
                            string m_AcqID = Path.GetFileNameWithoutExtension(@imageLists[i].ToString()).Trim();//获取不含扩展名的文件名，即采集ID
                            DBHelperLib.DBHelper.DeleteAcqRecordByAcqID(UInt64.Parse(m_AcqID));//删除对应的采集记录
                            DBHelperLib.DBHelper.DeleteRecords("tb_Graphics", "AcquisitionID = " + m_AcqID);//删除对应的图形
                        }                                 
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show("文件被占用，请重新删除！");
                        break;                     
                    }
                }
            }
            imageLists.Clear();
            LoadImageFiles();
        }

        private void LoadAcqImagesFrm_Load(object sender, EventArgs e)
        {
            LoadImageFiles();
        }

        private void listView1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                //MessageBox.Show( "您单击了鼠标右键！");
                ContextMenuStrip onlyfornumber1 = new ContextMenuStrip();
                //右键菜单加入一个hello选项
                onlyfornumber1.Items.Add("删除全部");
                //onlyfornumber1.Items.Add("删除");
                //点击hello选项时发生onlyfornumber3_Click事件
                onlyfornumber1.Items[0].Click += onlyfornumberDelAll_Click;
                //onlyfornumber1.Items[1].Click += onlyfornumberDel_Click;
                onlyfornumber1.Show(listView1, e.X, e.Y);
            }
        }

        private void listView1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                //MessageBox.Show("您单击了鼠标右键！");
                //contextMenuStrip1 =
                ContextMenuStrip onlyfornumber3 = new ContextMenuStrip();
                //右键菜单加入一个hello选项
                onlyfornumber3.Items.Add("图像分析");
                onlyfornumber3.Items.Add("图像删除");
                //点击hello选项时发生onlyfornumber3_Click事件
                onlyfornumber3.Items[0].Click += onlyfornumber3_Click;
                onlyfornumber3.Items[1].Click += onlyfornumberDel_Click;
                onlyfornumber3.Show(listView1, e.X, e.Y);
            }
        }

        private void listView1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            //MessageBox.Show(listView1.SelectedItems[0].Text);
            string _AcqIDstr = listView1.SelectedItems[0].Text.TrimEnd(".bmp".ToArray());
            UInt64 _AcqID = UInt64.Parse(_AcqIDstr);
            AcqResultAnalizeFrm m_AcqResultAnalizeFrm = new AcqResultAnalizeFrm();
            m_AcqResultAnalizeFrm.m_AcqID = _AcqID;//采集ID传入窗体中
            m_AcqResultAnalizeFrm.m_LoadAcqImagesFrm = this;//当前窗体引用传入
            //Bitmap m_ResqultBitmap = new Bitmap(listView1.SelectedItems[0].Name);
            //m_AcqResultAnalizeFrm.AnalizePictrueBox.BackgroundImage = m_ResqultBitmap;
            //m_AcqResultAnalizeFrm.OriginalPictrueBox.BackgroundImage = m_ResqultBitmap;
            m_AcqResultAnalizeFrm.m_AcqResltFile = listView1.SelectedItems[0].Name;
            m_AcqResultAnalizeFrm.StartPosition = FormStartPosition.CenterScreen;
            m_AcqResultAnalizeFrm.ShowDialog();
        }
    }
}
