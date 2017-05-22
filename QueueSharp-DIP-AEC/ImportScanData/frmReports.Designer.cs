namespace ImportScanData
{
    partial class frmReports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbReqType = new System.Windows.Forms.ComboBox();
            this.cbPatentType = new System.Windows.Forms.ComboBox();
            this.dtSendDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtSendDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnReport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ประเภทคำขอ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ประเภทสิทธิบัตร :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "วันที่นำเข้า :";
            // 
            // cbReqType
            // 
            this.cbReqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReqType.FormattingEnabled = true;
            this.cbReqType.Location = new System.Drawing.Point(116, 6);
            this.cbReqType.Name = "cbReqType";
            this.cbReqType.Size = new System.Drawing.Size(290, 21);
            this.cbReqType.TabIndex = 4;
            // 
            // cbPatentType
            // 
            this.cbPatentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPatentType.FormattingEnabled = true;
            this.cbPatentType.Location = new System.Drawing.Point(116, 31);
            this.cbPatentType.Name = "cbPatentType";
            this.cbPatentType.Size = new System.Drawing.Size(290, 21);
            this.cbPatentType.TabIndex = 5;
            // 
            // dtSendDateFrom
            // 
            this.dtSendDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSendDateFrom.Location = new System.Drawing.Point(116, 55);
            this.dtSendDateFrom.Name = "dtSendDateFrom";
            this.dtSendDateFrom.Size = new System.Drawing.Size(107, 20);
            this.dtSendDateFrom.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "ถึง";
            // 
            // dtSendDateTo
            // 
            this.dtSendDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSendDateTo.Location = new System.Drawing.Point(283, 55);
            this.dtSendDateTo.Name = "dtSendDateTo";
            this.dtSendDateTo.Size = new System.Drawing.Size(107, 20);
            this.dtSendDateTo.TabIndex = 8;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(116, 81);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(107, 23);
            this.btnReport.TabIndex = 12;
            this.btnReport.Text = "แสดงรายงาน";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 127);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(407, 23);
            this.progressBar1.TabIndex = 13;
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Location = new System.Drawing.Point(12, 111);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(0, 13);
            this.lblProgressStatus.TabIndex = 14;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 159);
            this.Controls.Add(this.lblProgressStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.dtSendDateTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtSendDateFrom);
            this.Controls.Add(this.cbPatentType);
            this.Controls.Add(this.cbReqType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmReports";
            this.Text = "แสดงรายงาน";
            this.Load += new System.EventHandler(this.frmReports_Load);
            this.Shown += new System.EventHandler(this.frmReports_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbReqType;
        private System.Windows.Forms.ComboBox cbPatentType;
        private System.Windows.Forms.DateTimePicker dtSendDateFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtSendDateTo;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressStatus;
    }
}