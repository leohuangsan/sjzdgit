using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SkinLib;

namespace SJZDEyes
{
    public partial class FirstLineShowFrm : NewStyleFrm
    {
        public IntPtr pObjectShort;
        public short[] m_ShortArray ;

        public FirstLineShowFrm()
        {
            InitializeComponent();
            m_ShortArray = new short[2048 * 1000];
    }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //m_ShareMenInstace.Write(m_ImgRowColDataBytes, 0, 2048 * 1000 * 2);//Write share memory 

            Marshal.Copy(this.pObjectShort, m_ShortArray, 0, 2048 * 1000);

            this.chart1.Series[0].Points.Clear();
            //m_ImgRowColData
            for (int lineNum = 0; lineNum < 1; lineNum++)
            {
                for (int x = 0; x < 2048; x++)
                {
                    this.chart1.Series[0].Points.AddY(m_ShortArray[lineNum * 2048 + x]);
                }
            }
            // Show the image information
            //this.AcquizationCntLbl.Text = ulNBImageAcquired.ToString();
            //this.ImageWidthLbl.Text = USB3WinAPI.ImageInfos.iImageWidth.ToString();
            //this.ImageHeightLbl.Text = USB3WinAPI.ImageInfos.iImageHeight.ToString();
            //this.ImagePixelTypeLbl.Text = USB3WinAPI.ImageInfos.eImagePixelType.ToString();
            //this.ImageSizeLbl.Text = USB3WinAPI.ImageInfos.iImageSize.ToString();
            //this.LinePitchLbl.Text = USB3WinAPI.ImageInfos.iLinePitch.ToString();
            //this.OffsetXLbl.Text = USB3WinAPI.ImageInfos.iOffsetX.ToString();
            //this.HorizontalFlipLbl.Text = USB3WinAPI.ImageInfos.iHorizontalFlip.ToString();
            //this.MissedTriggersLbl.Text = USB3WinAPI.ImageInfos.iNbMissedTriggers.ToString();
            //this.LineLostLbl.Text = USB3WinAPI.ImageInfos.iNbLineLost.ToString();
            //this.ImageAcquiredLbl.Text = USB3WinAPI.ImageInfos.iNbImageAcquired.ToString();
            //this.GrabbedLbl.Text = ulNBImageAcquired.ToString();
            //fpsgrabbedLblStr = (1000 / 8.33).ToString();
            //fpsgrabbedLblStr = fpsgrabbedLblStr.Substring(0, fpsgrabbedLblStr.IndexOf('.')) + fpsgrabbedLblStr.Substring(fpsgrabbedLblStr.IndexOf('.'), 3);
            //if (ulNBImageAcquired != 0)
            //{
            //    //this.fpsgrabbedLbl.Text = fpsgrabbedLblStr;
            //    //this.fpsdispLbl.Text = (1000 / this.chartTimer.Interval).ToString();
            //}
        }

        private void FirstLineShowFrm_Load(object sender, EventArgs e)
        {
            base.TitleLbl.Text = "显示第一条线";
            base.MaxBtn.Visible = false;
        }
    }
}
