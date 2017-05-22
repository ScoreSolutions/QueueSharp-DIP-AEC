namespace ImportScanData
{
    partial class frmImportScanDataFromBrowser
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
            this.txtImportFile = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgressStatus = new System.Windows.Forms.Label();
            this.btnCheckData = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnUpdateSendDate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtImportFile
            // 
            this.txtImportFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtImportFile.Enabled = false;
            this.txtImportFile.Location = new System.Drawing.Point(30, 12);
            this.txtImportFile.Name = "txtImportFile";
            this.txtImportFile.Size = new System.Drawing.Size(410, 20);
            this.txtImportFile.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(483, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(446, 9);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel 2007/2010/2013|*.xlsx";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(30, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(528, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // lblProgressStatus
            // 
            this.lblProgressStatus.AutoSize = true;
            this.lblProgressStatus.Location = new System.Drawing.Point(27, 70);
            this.lblProgressStatus.Name = "lblProgressStatus";
            this.lblProgressStatus.Size = new System.Drawing.Size(0, 13);
            this.lblProgressStatus.TabIndex = 4;
            // 
            // btnCheckData
            // 
            this.btnCheckData.Location = new System.Drawing.Point(30, 95);
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.Size = new System.Drawing.Size(75, 23);
            this.btnCheckData.TabIndex = 5;
            this.btnCheckData.Text = "Check Data";
            this.btnCheckData.UseVisualStyleBackColor = true;
            this.btnCheckData.Click += new System.EventHandler(this.btnCheckData_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(483, 95);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Reports";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnUpdateSendDate
            // 
            this.btnUpdateSendDate.Location = new System.Drawing.Point(371, 95);
            this.btnUpdateSendDate.Name = "btnUpdateSendDate";
            this.btnUpdateSendDate.Size = new System.Drawing.Size(106, 23);
            this.btnUpdateSendDate.TabIndex = 7;
            this.btnUpdateSendDate.Text = "อัพเดทวันที่นำส่ง";
            this.btnUpdateSendDate.UseVisualStyleBackColor = true;
            this.btnUpdateSendDate.Click += new System.EventHandler(this.btnUpdateSendDate_Click);
            // 
            // frmImportScanDataFromBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 130);
            this.Controls.Add(this.btnUpdateSendDate);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCheckData);
            this.Controls.Add(this.lblProgressStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtImportFile);
            this.Name = "frmImportScanDataFromBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Scan Data From Browser";
            this.Shown += new System.EventHandler(this.frmImportScanDataFromBrowser_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImportFile;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressStatus;
        private System.Windows.Forms.Button btnCheckData;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnUpdateSendDate;

    }
}

