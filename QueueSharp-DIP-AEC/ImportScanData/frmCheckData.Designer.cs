namespace ImportScanData
{
    partial class frmCheckData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAppNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gvDataList = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRequisitionTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPageQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลขที่คำขอ :";
            // 
            // txtAppNo
            // 
            this.txtAppNo.Location = new System.Drawing.Point(89, 9);
            this.txtAppNo.Name = "txtAppNo";
            this.txtAppNo.Size = new System.Drawing.Size(172, 20);
            this.txtAppNo.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(267, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gvDataList
            // 
            this.gvDataList.AllowUserToAddRows = false;
            this.gvDataList.AllowUserToDeleteRows = false;
            this.gvDataList.AllowUserToResizeColumns = false;
            this.gvDataList.AllowUserToResizeRows = false;
            this.gvDataList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colReqNo,
            this.colRequisitionTypeName,
            this.colFilingDate,
            this.colImportDate,
            this.colDocType,
            this.colPageQty,
            this.colVersion});
            this.gvDataList.Location = new System.Drawing.Point(0, 36);
            this.gvDataList.Name = "gvDataList";
            this.gvDataList.RowHeadersVisible = false;
            this.gvDataList.Size = new System.Drawing.Size(909, 379);
            this.gvDataList.TabIndex = 3;
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "no";
            this.colNo.HeaderText = "ลำดับ";
            this.colNo.Name = "colNo";
            this.colNo.Width = 60;
            // 
            // colReqNo
            // 
            this.colReqNo.DataPropertyName = "req_no";
            this.colReqNo.HeaderText = "เลขที่คำร้อง";
            this.colReqNo.Name = "colReqNo";
            // 
            // colRequisitionTypeName
            // 
            this.colRequisitionTypeName.DataPropertyName = "requisition_type_name";
            this.colRequisitionTypeName.HeaderText = "ประเภทคำขอ";
            this.colRequisitionTypeName.Name = "colRequisitionTypeName";
            this.colRequisitionTypeName.Width = 200;
            // 
            // colFilingDate
            // 
            this.colFilingDate.DataPropertyName = "filing_date";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.colFilingDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFilingDate.HeaderText = "วันที่ยื่นคำขอ";
            this.colFilingDate.Name = "colFilingDate";
            // 
            // colImportDate
            // 
            this.colImportDate.DataPropertyName = "import_date";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.colImportDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colImportDate.HeaderText = "วันที่นำเข้าเอกสาร";
            this.colImportDate.Name = "colImportDate";
            this.colImportDate.Width = 120;
            // 
            // colDocType
            // 
            this.colDocType.DataPropertyName = "doc_type_name";
            this.colDocType.HeaderText = "ประเภทเอกสาร";
            this.colDocType.Name = "colDocType";
            this.colDocType.Width = 150;
            // 
            // colPageQty
            // 
            this.colPageQty.DataPropertyName = "page_qty";
            this.colPageQty.HeaderText = "จำนวนหน้า";
            this.colPageQty.Name = "colPageQty";
            // 
            // colVersion
            // 
            this.colVersion.DataPropertyName = "doc_version";
            this.colVersion.HeaderText = "เวอร์ชั่น";
            this.colVersion.Name = "colVersion";
            this.colVersion.Width = 60;
            // 
            // frmCheckData
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 415);
            this.Controls.Add(this.gvDataList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtAppNo);
            this.Controls.Add(this.label1);
            this.Name = "frmCheckData";
            this.Text = "ตรวจสอบข้อมูลที่นำเข้า";
            ((System.ComponentModel.ISupportInitialize)(this.gvDataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAppNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView gvDataList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReqNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequisitionTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilingDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPageQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
    }
}