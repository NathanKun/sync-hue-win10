namespace SyncHueWin10.view
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonslayout = new System.Windows.Forms.FlowLayoutPanel();
            this.labelHint = new System.Windows.Forms.Label();
            this.rangerBrightness = new CustomRangeSelectorControl.RangeSelectorControl();
            this.buttonSetRange = new System.Windows.Forms.Button();
            this.trackBarSaturation = new System.Windows.Forms.TrackBar();
            this.labelSaturation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButtonslayout
            // 
            this.radioButtonslayout.Location = new System.Drawing.Point(8, 8);
            this.radioButtonslayout.Margin = new System.Windows.Forms.Padding(2);
            this.radioButtonslayout.Name = "radioButtonslayout";
            this.radioButtonslayout.Size = new System.Drawing.Size(370, 224);
            this.radioButtonslayout.TabIndex = 0;
            // 
            // labelHint
            // 
            this.labelHint.Location = new System.Drawing.Point(6, 409);
            this.labelHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(308, 23);
            this.labelHint.TabIndex = 1;
            this.labelHint.Text = "labelHint";
            this.labelHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rangerBrightness
            // 
            this.rangerBrightness.BackColor = System.Drawing.Color.LightBlue;
            this.rangerBrightness.DelimiterForRange = ",";
            this.rangerBrightness.DisabledBarColor = System.Drawing.Color.Gray;
            this.rangerBrightness.DisabledRangeLabelColor = System.Drawing.Color.Gray;
            this.rangerBrightness.GapFromLeftMargin = ((uint)(10u));
            this.rangerBrightness.GapFromRightMargin = ((uint)(10u));
            this.rangerBrightness.HeightOfThumb = 20F;
            this.rangerBrightness.InFocusBarColor = System.Drawing.Color.Magenta;
            this.rangerBrightness.InFocusRangeLabelColor = System.Drawing.Color.Green;
            this.rangerBrightness.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rangerBrightness.LeftThumbImagePath = null;
            this.rangerBrightness.Location = new System.Drawing.Point(8, 237);
            this.rangerBrightness.MiddleBarWidth = ((uint)(3u));
            this.rangerBrightness.Name = "rangerBrightness";
            this.rangerBrightness.OutputStringFontColor = System.Drawing.Color.Black;
            this.rangerBrightness.Range1 = "10";
            this.rangerBrightness.Range2 = "90";
            this.rangerBrightness.RangeString = "Brightness";
            this.rangerBrightness.RangeValues = "0,10,20,30,40,50,60,70,80,90,100";
            this.rangerBrightness.RightThumbImagePath = null;
            this.rangerBrightness.Size = new System.Drawing.Size(370, 80);
            this.rangerBrightness.TabIndex = 6;
            this.rangerBrightness.ThumbColor = System.Drawing.Color.Purple;
            this.rangerBrightness.WidthOfThumb = 10F;
            this.rangerBrightness.XMLFileName = null;
            // 
            // buttonSetRange
            // 
            this.buttonSetRange.Location = new System.Drawing.Point(319, 409);
            this.buttonSetRange.Name = "buttonSetRange";
            this.buttonSetRange.Size = new System.Drawing.Size(59, 23);
            this.buttonSetRange.TabIndex = 7;
            this.buttonSetRange.Text = "Set";
            this.buttonSetRange.UseVisualStyleBackColor = true;
            this.buttonSetRange.Click += new System.EventHandler(this.ButtonSetRange_Click);
            // 
            // trackBarSaturation
            // 
            this.trackBarSaturation.Location = new System.Drawing.Point(8, 323);
            this.trackBarSaturation.Name = "trackBarSaturation";
            this.trackBarSaturation.Size = new System.Drawing.Size(364, 45);
            this.trackBarSaturation.TabIndex = 8;
            // 
            // labelSaturation
            // 
            this.labelSaturation.AutoSize = true;
            this.labelSaturation.Location = new System.Drawing.Point(13, 355);
            this.labelSaturation.Name = "labelSaturation";
            this.labelSaturation.Size = new System.Drawing.Size(65, 12);
            this.labelSaturation.TabIndex = 9;
            this.labelSaturation.Text = "Saturation";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 514);
            this.Controls.Add(this.labelSaturation);
            this.Controls.Add(this.trackBarSaturation);
            this.Controls.Add(this.buttonSetRange);
            this.Controls.Add(this.rangerBrightness);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.radioButtonslayout);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Sync Hue Win10";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSaturation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel radioButtonslayout;
        private System.Windows.Forms.Label labelHint;
        private CustomRangeSelectorControl.RangeSelectorControl rangerBrightness;
        private System.Windows.Forms.Button buttonSetRange;
        private System.Windows.Forms.TrackBar trackBarSaturation;
        private System.Windows.Forms.Label labelSaturation;
    }
}

