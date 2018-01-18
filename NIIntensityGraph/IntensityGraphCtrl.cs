using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.UI;
using NationalInstruments.UI.WindowsForms;

namespace NIIntensityGraphSpace
{
    public partial class IntensityGraphCtrl : UserControl
    {
        public IntensityGraphCtrl()
        {
            InitializeComponent();
            InitializeColorScale();
            //PlotIntensityData();
        }
        private void PlotIntensityData()
        {
            // Generate Data
            int numPoints = 211;
            double[,] zData = new double[numPoints, numPoints];
            for (int i = 0; i < numPoints; i++)
            {
                for (int j = 0; j < numPoints; j++)
                {
                    zData[i, j] = i * i + j * j;
                }
            }

            // Scale the colorscale depending on the data generated.
            //colorScale1.ScaleColorScale(new Range(0, zData[numPoints - 1, numPoints - 1]));
            colorScale1.ScaleColorScale(new Range(0, 2000));

            // Plot the Data.
            intensityPlot1.Plot(zData);
        }
        private void InitializeColorScale()
        {
            // Initialize the ColorScale corresponding to VIBGYOR
            colorScale1.Range = new Range(0, 4096);
            colorScale1.HighColor = Color.White;
            //colorScale1.ColorMap.Add(5, Color.Indigo);
            //colorScale1.ColorMap.Add(4, Color.Blue);
            //colorScale1.ColorMap.Add(3, Color.Green);
            //colorScale1.ColorMap.Add(2, Color.Yellow);
            //colorScale1.ColorMap.Add(1, Color.Black);
            colorScale1.LowColor = Color.Black;
        }
    }
}
