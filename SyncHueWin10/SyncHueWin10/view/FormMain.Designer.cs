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
            this.rangeSelectorControl1 = new CustomRangeSelectorControl.RangeSelectorControl();
            this.buttonSetRange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioButtonslayout
            // 
            this.radioButtonslayout.Location = new System.Drawing.Point(8, 8);
            this.radioButtonslayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonslayout.Name = "radioButtonslayout";
            this.radioButtonslayout.Size = new System.Drawing.Size(370, 224);
            this.radioButtonslayout.TabIndex = 0;
            // 
            // labelHint
            // 
            this.labelHint.Location = new System.Drawing.Point(6, 328);
            this.labelHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(286, 23);
            this.labelHint.TabIndex = 1;
            this.labelHint.Text = "labelHint";
            this.labelHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rangeSelectorControl1
            // 
            this.rangeSelectorControl1.BackColor = System.Drawing.Color.LightBlue;
            this.rangeSelectorControl1.DelimiterForRange = ",";
            this.rangeSelectorControl1.DisabledBarColor = System.Drawing.Color.Gray;
            this.rangeSelectorControl1.DisabledRangeLabelColor = System.Drawing.Color.Gray;
            this.rangeSelectorControl1.GapFromLeftMargin = ((uint)(10u));
            this.rangeSelectorControl1.GapFromRightMargin = ((uint)(10u));
            this.rangeSelectorControl1.HeightOfThumb = 20F;
            this.rangeSelectorControl1.InFocusBarColor = System.Drawing.Color.Magenta;
            this.rangeSelectorControl1.InFocusRangeLabelColor = System.Drawing.Color.Green;
            this.rangeSelectorControl1.LabelFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular);
            this.rangeSelectorControl1.LeftThumbImagePath = null;
            this.rangeSelectorControl1.Location = new System.Drawing.Point(8, 237);
            this.rangeSelectorControl1.MiddleBarWidth = ((uint)(3u));
            this.rangeSelectorControl1.Name = "rangeSelectorControl1";
            this.rangeSelectorControl1.OutputStringFontColor = System.Drawing.Color.Black;
            this.rangeSelectorControl1.Range1 = "10";
            this.rangeSelectorControl1.Range2 = "90";
            this.rangeSelectorControl1.RangeString = "Range";
            this.rangeSelectorControl1.RangeValues = "0,10,20,30,40,50,60,70,80,90,100";
            this.rangeSelectorControl1.RightThumbImagePath = null;
            this.rangeSelectorControl1.Size = new System.Drawing.Size(370, 80);
            this.rangeSelectorControl1.TabIndex = 6;
            this.rangeSelectorControl1.ThumbColor = System.Drawing.Color.Purple;
            this.rangeSelectorControl1.WidthOfThumb = 10F;
            this.rangeSelectorControl1.XMLFileName = null;
            // 
            // buttonSetRange
            // 
            this.buttonSetRange.Location = new System.Drawing.Point(297, 328);
            this.buttonSetRange.Name = "buttonSetRange";
            this.buttonSetRange.Size = new System.Drawing.Size(75, 23);
            this.buttonSetRange.TabIndex = 7;
            this.buttonSetRange.Text = "Set Range";
            this.buttonSetRange.UseVisualStyleBackColor = true;
            this.buttonSetRange.Click += new System.EventHandler(this.buttonSetRange_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.buttonSetRange);
            this.Controls.Add(this.rangeSelectorControl1);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.radioButtonslayout);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.Text = "Sync Hue Win10";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel radioButtonslayout;
        private System.Windows.Forms.Label labelHint;
        private CustomRangeSelectorControl.RangeSelectorControl rangeSelectorControl1;
        private System.Windows.Forms.Button buttonSetRange;
    }
}

