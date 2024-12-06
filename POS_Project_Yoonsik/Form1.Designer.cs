namespace POS_Project_Yoonsik
{
    partial class POSProgram
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.POSTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // POSTitle
            // 
            this.POSTitle.AutoSize = true;
            this.POSTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.POSTitle.Location = new System.Drawing.Point(312, 9);
            this.POSTitle.Name = "POSTitle";
            this.POSTitle.Size = new System.Drawing.Size(119, 19);
            this.POSTitle.TabIndex = 0;
            this.POSTitle.Text = "POS Program";
            this.POSTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.POSTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // POSProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.POSTitle);
            this.Name = "POSProgram";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label POSTitle;
    }
}

