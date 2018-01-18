namespace NIIntensityGraphSpace
{
    partial class IntensityGraphCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sampleIntensityGraph = new NationalInstruments.UI.WindowsForms.IntensityGraph();
            this.colorScale1 = new NationalInstruments.UI.ColorScale();
            this.intensityCursor1 = new NationalInstruments.UI.IntensityCursor();
            this.intensityPlot1 = new NationalInstruments.UI.IntensityPlot();
            this.intensityXAxis1 = new NationalInstruments.UI.IntensityXAxis();
            this.intensityYAxis1 = new NationalInstruments.UI.IntensityYAxis();
            ((System.ComponentModel.ISupportInitialize)(this.sampleIntensityGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intensityCursor1)).BeginInit();
            this.SuspendLayout();
            // 
            // sampleIntensityGraph
            // 
            this.sampleIntensityGraph.ColorScales.AddRange(new NationalInstruments.UI.ColorScale[] {
            this.colorScale1});
            this.sampleIntensityGraph.Cursors.AddRange(new NationalInstruments.UI.IntensityCursor[] {
            this.intensityCursor1});
            this.sampleIntensityGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleIntensityGraph.Location = new System.Drawing.Point(0, 0);
            this.sampleIntensityGraph.Name = "sampleIntensityGraph";
            this.sampleIntensityGraph.Plots.AddRange(new NationalInstruments.UI.IntensityPlot[] {
            this.intensityPlot1});
            this.sampleIntensityGraph.Size = new System.Drawing.Size(2048, 1000);
            this.sampleIntensityGraph.TabIndex = 0;
            this.sampleIntensityGraph.XAxes.AddRange(new NationalInstruments.UI.IntensityXAxis[] {
            this.intensityXAxis1});
            this.sampleIntensityGraph.YAxes.AddRange(new NationalInstruments.UI.IntensityYAxis[] {
            this.intensityYAxis1});
            // 
            // intensityPlot1
            // 
            this.intensityPlot1.ColorScale = this.colorScale1;
            this.intensityPlot1.XAxis = this.intensityXAxis1;
            this.intensityPlot1.YAxis = this.intensityYAxis1;
            // 
            // IntensityGraphCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sampleIntensityGraph);
            this.Name = "IntensityGraphCtrl";
            this.Size = new System.Drawing.Size(2048, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.sampleIntensityGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intensityCursor1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public NationalInstruments.UI.WindowsForms.IntensityGraph sampleIntensityGraph;
        public NationalInstruments.UI.ColorScale colorScale1;
        public NationalInstruments.UI.IntensityCursor intensityCursor1;
        public NationalInstruments.UI.IntensityPlot intensityPlot1;
        public NationalInstruments.UI.IntensityXAxis intensityXAxis1;
        public NationalInstruments.UI.IntensityYAxis intensityYAxis1;
        //public NationalInstruments.UI.IntensityXAxis xAxis;
        //public NationalInstruments.UI.IntensityYAxis yAxis;
        //public System.Windows.Forms.Button button1;

        //public NationalInstruments.UI.ColorScale colorScale1;
        //public NationalInstruments.UI.IntensityCursor intensityCursor1;
        //public NationalInstruments.UI.IntensityPlot intensityPlot1;
    }
}
