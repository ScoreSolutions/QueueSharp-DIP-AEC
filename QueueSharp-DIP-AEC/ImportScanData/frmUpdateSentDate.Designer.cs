namespace ImportScanData
{
    partial class frmUpdateSentDate
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
            this.cbReqType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtSendDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtImportFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // cbReqType
            // 
            this.cbReqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReqType.FormattingEnabled = true;
            this.cbReqType.Location = new System.Drawing.Point(120, 12);
            this.cbReqType.Name = "cbReqType";
            this.cbReqType.Size = new System.Drawing.Size(428, 21);
            this.cbReqType.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "ประเภทคำขอ :";
            // 
            // dtSendDate
            // 
            this.dtSendDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSendDate.Location = new System.Drawing.Point(120, 39);
            this.dtSendDate.Name = "dtSendDate";
            this.dtSendDate.Size = new System.Drawing.Size(107, 20);
            this.dtSendDate.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "วันที่นำใส่แฟ้ม :";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 113);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(522, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(436, 68);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(31, 23);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(473, 68);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtImportFile
            // 
            this.txtImportFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtImportFile.Enabled = false;
            this.txtImportFile.Location = new System.Drawing.Point(120, 68);
            this.txtImportFile.Name = "txtImportFile";
            this.txtImportFile.Size = new System.Drawing.Size(310, 20);
            this.txtImportFile.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Excel File :";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(29, 97);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel 2007/2010/2013|*.xlsx";
            // 
            // frmUpdateSentDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 147);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtImportFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dtSendDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbReqType);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateSentDate";
            this.Text = "frmUpdateSentDate";
            this.Load += new System.EventHandler(this.frmUpdateSentDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbReqType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtSendDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtImportFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}