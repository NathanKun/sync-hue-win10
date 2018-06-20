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
            this.SuspendLayout();
            // 
            // radioButtonslayout
            // 
            this.radioButtonslayout.Location = new System.Drawing.Point(10, 10);
            this.radioButtonslayout.Name = "radioButtonslayout";
            this.radioButtonslayout.Size = new System.Drawing.Size(280, 280);
            this.radioButtonslayout.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.radioButtonslayout);
            this.Name = "FormMain";
            this.Text = "Sync Hue Win10";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel radioButtonslayout;
    }
}

