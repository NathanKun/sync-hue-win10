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
            this.SuspendLayout();
            // 
            // radioButtonslayout
            // 
            this.radioButtonslayout.Location = new System.Drawing.Point(10, 10);
            this.radioButtonslayout.Name = "radioButtonslayout";
            this.radioButtonslayout.Size = new System.Drawing.Size(280, 280);
            this.radioButtonslayout.TabIndex = 0;
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Location = new System.Drawing.Point(10, 300);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(46, 17);
            this.labelHint.TabIndex = 1;
            this.labelHint.Text = "labelHint";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 330);
            this.Controls.Add(this.labelHint);
            this.Controls.Add(this.radioButtonslayout);
            this.Name = "FormMain";
            this.Text = "Sync Hue Win10";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel radioButtonslayout;
        private System.Windows.Forms.Label labelHint;
    }
}

