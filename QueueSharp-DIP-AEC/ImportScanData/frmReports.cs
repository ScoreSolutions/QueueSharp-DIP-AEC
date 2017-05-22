using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqDB.TABLE;
using Engine.Common;
using OfficeOpenXml;

namespace ImportScanData
{
    public partial class frmReports : Form
    {
        IniReader ini = new IniReader(Application.StartupPath + @"\Config.ini");
        string dbLinkIP;

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {

        }

        private void frmReports_Shown(object sender, EventArgs e)
        {
            LoadDataToDropdownlist();

            ini.Section = "AppConfig";
            dbLinkIP = ini.ReadString("ePATENT_DBLINK");
        }

        private void LoadDataToDropdownlist() {
            MsRequisitionTypeLinqDB rtLnq = new MsRequisitionTypeLinqDB();
            string rtSql = "select distinct requisition_type_name name_value, requisition_type_name name_display";
            rtSql += " from TS_FILE_SCAN_SUMMARY ";
            rtSql += " order by name_display";

            DataTable rtDt = rtLnq.GetListBySql(rtSql, null);
            if (rtDt.Rows.Count > 0) {
                DataRow dr = rtDt.NewRow();
                dr["name_value"] = "";
                dr["name_display"] = "เลือก";
                rtDt.Rows.InsertAt(dr, 0);

                cbReqType.DataSource = rtDt;
                cbReqType.ValueMember = "name_value";
                cbReqType.DisplayMember = "name_display";
            }

            MsPatentTypeLinqDB ptLnq = new MsPatentTypeLinqDB();
            DataTable ptDt = ptLnq.GetDataList("active_status='1'", "id", null);
            if (ptDt.Rows.Count > 0) {
                DataRow dr = ptDt.NewRow();
                dr["id"] = Convert.ToInt64(0);
                dr["patent_type_name"] = "เลือก";
                ptDt.Rows.InsertAt(dr, 0);

                cbPatentType.DataSource = ptDt;
                cbPatentType.ValueMember = "id";
                cbPatentType.DisplayMember = "patent_type_name";
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (cbReqType.SelectedValue.ToString() == "") {
                MessageBox.Show("กรุณาเลือกประเภทคำขอฯ");
                cbReqType.Focus();
                return;
            }
            if (cbPatentType.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("กรุณาเลือกประเถทสิทธิบัตร");
                cbPatentType.Focus();
                return;
            }

            string sql = "select fc.requisition_type_name, ri.ms_patent_type_id,fc.filing_date,ri.receive_date, fc.app_no, fc.req_no, \n";
            sql += " fc.import_date, convert(varchar(8),fc.import_date,112) sw_import_date,fc.doc_type_name, fc.page_qty,ri.send_date \n";
            sql += " from TS_FILE_SCAN_SUMMARY fc \n";
            sql += " inner join TS_FILE_REQUISITION_INFO ri on ri.app_no=fc.app_no \n";
            sql += " where 1=1 \n";
            if (cbReqType.SelectedValue.ToString() != "")
            {
                sql += " and fc.requisition_type_name = '" + cbReqType.SelectedValue.ToString() + "'\n";
                if (cbReqType.SelectedValue.ToString() == "คำขอรับสิทธิบัตร/อนุสิทธิบัตร") {
                    //ถ้าเป็นคำขอใหม่ ให้เอาเฉพาะเลขที่ขึ้นต้นด้วย 15 เท่านั้น
                    sql += " and SUBSTRING(fc.app_no,1,2)='15'";
                }
            }
            if (cbPatentType.SelectedValue.ToString() != "0")
            {
                sql += " and ri.ms_patent_type_id = '" + cbPatentType.SelectedValue.ToString() + "'\n";
            }
            sql += " and convert(varchar(8),fc.import_date,112) between '" + SetDateFormat(dtSendDateFrom) + "' and '" + SetDateFormat(dtSendDateTo) + "'\n";
            sql += " order by fc.app_no, fc.req_no";
            
            sql = sql.Replace("\n", System.Environment.NewLine);

            DataTable dt = Engine.Common.FunctionEng.ExecuteDataTable(sql);
            if (dt.Rows.Count > 0) {
                using (ExcelPackage pke = new ExcelPackage())
                {
                    ExcelWorksheet sh = pke.Workbook.Worksheets.Add(DateTime.Now.ToString("yyyyMMdd"));
                    
                    //Header Row
                    sh.Cells["A3"].Value = "ลำดับ";
                    sh.Cells["A3:A4"].Merge = true;
                    sh.Cells["A3:A4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sh.Column(1).Width = 15;

                    sh.Cells["B3"].Value = "วันที่ยื่นคำขอ";
                    sh.Cells["B3:B4"].Merge = true;
                    sh.Cells["B3:B4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sh.Column(2).Width = 15;

                    sh.Cells["C3"].Value = "วันที่รับเอกสาร";
                    sh.Cells["C3:C4"].Merge = true;
                    sh.Cells["C3:C4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sh.Column(3).Width = 15;

                    sh.Cells["D3"].Value = "เลขที่คำขอ";
                    sh.Cells["D3:D4"].Merge = true;
                    sh.Cells["D3:D4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sh.Column(4).Width = 15;

                    sh.Cells["E3"].Value = "เลขที่คำร้อง";
                    sh.Cells["E3:E4"].Merge = true;
                    sh.Cells["E3:E4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sh.Column(5).Width = 15;

                    sh.Cells["F3"].Value = "วันที่นำเข้าข้อมูล(คีย์)";
                    sh.Cells["F3:F4"].Merge = true;
                    sh.Cells["F3:F4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sh.Column(6).Width = 20;

                    sh.Cells["G3"].Value = "วันที่สแกนข้อมูล";
                    sh.Cells["G3:G4"].Merge = true;
                    sh.Cells["G3:G4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sh.Column(7).Width = 18;

                    sh.Cells["H3"].Value = "วันที่นำใส่แฟ้ม";
                    sh.Cells["H3:H4"].Merge = true;
                    sh.Cells["H3:H4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    sh.Column(8).Width = 18;

                    int c = 9;
                    DataTable dDt = dt.DefaultView.ToTable(true, "doc_type_name").Copy();
                    dDt.DefaultView.Sort="doc_type_name";
                    foreach (DataRowView dDr in dDt.DefaultView) {
                        sh.Cells[4,c].Value = dDr["doc_type_name"].ToString();
                        sh.Column(c).AutoFit();
                        c += 1;
                    }

                    sh.Cells["I3"].Value = "สแกนเอกสาร";
                    sh.Cells[3,9,3,c].Merge = true;
                    sh.Cells[3, 9, 3, c].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    sh.Column(9).Width = 15;


                    DataTable fDt = dt.DefaultView.ToTable(true, "app_no", "req_no", "filing_date", "receive_date", "import_date", "sw_import_date", "send_date").Copy();

                    progressBar1.Maximum = fDt.Rows.Count;
                    progressBar1.Value = 0;
                        
                    int iRow=5;
                    int ord = 1;
                    string cReqNo = "";
                    foreach (DataRow fDr in fDt.Rows)
                    {
                        if (fDr["req_no"].ToString() != cReqNo)
                        {
                            sh.Cells["A" + iRow].Value = ord.ToString();
                            cReqNo = fDr["req_no"].ToString();
                            ord += 1;
                        //}else{
                        //    sh.Cells["A" + (iRow - 1).ToString() + ":A" + iRow.ToString()].Merge = true;
                        //    sh.Cells["A" + (iRow - 1).ToString() + ":A" + iRow.ToString()].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                        }

                        sh.Cells["B" + iRow].Value = Convert.ToDateTime(fDr["filing_date"]).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"));
                        sh.Cells["C" + iRow].Value = Convert.ToDateTime(fDr["receive_date"]).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"));
                        sh.Cells["D" + iRow].Value = fDr["app_no"].ToString();
                        sh.Cells["E" + iRow].Value = fDr["req_no"].ToString();
                        if (Convert.IsDBNull(fDr["import_date"]) == false)
                        {
                            sh.Cells["F" + iRow].Value = Convert.ToDateTime(fDr["import_date"]).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"));
                            sh.Cells["G" + iRow].Value = Convert.ToDateTime(fDr["import_date"]).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"));
                        }
                        if (Convert.IsDBNull(fDr["send_date"]) == false) {
                            sh.Cells["H" + iRow].Value = Convert.ToDateTime(fDr["send_date"]).ToString("dd/MM/yyyy", new System.Globalization.CultureInfo("th-TH"));
                        }
                        
                        c = 9;
                        foreach (DataRowView dDr in dDt.DefaultView)
                        {
                            dt.DefaultView.RowFilter = "app_no='" + fDr["app_no"].ToString() + "' and req_no='" + fDr["req_no"].ToString() + "' and doc_type_name = '" + dDr["doc_type_name"].ToString() + "' and sw_import_date='" + fDr["sw_import_date"].ToString() + "'";
                            if (dt.DefaultView.Count > 0) {
                                sh.Cells[iRow, c].Value = dt.DefaultView[0]["page_qty"].ToString();
                            }
                            dt.DefaultView.RowFilter = "";
                            c += 1;
                        }
                        iRow += 1;

                        lblProgressStatus.Text = "Current Row :" + (progressBar1.Value + 1).ToString() + " Total Row :" + fDt.Rows.Count;
                        progressBar1.Value += 1;
                        Application.DoEvents();
                    }

                    //Report Header 
                    sh.Cells["A1"].Value = "ใบตรวจรับงานโครงการนำเข้าข้อมูลเพื่อรองรับระบบสิทธิบัตรที่พัฒนาขึ้นใหม่ (AEC) สำนักสิทธิบัตร";
                    sh.Cells["A1:M1"].Merge = true;
                    sh.Cells["A1:M1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    sh.Cells["A2"].Value = cbReqType.SelectedValue.ToString() + " " + cbPatentType.Text + " จำนวน " + (ord-1).ToString() + " คำขอ";
                    sh.Cells["A2:M2"].Merge = true;
                    sh.Cells["A2:M2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    using (ExcelRange r = sh.Cells[1,1,iRow,c])
                    {
                        //r.AutoFitColumns();
                        r.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        r.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        r.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        r.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    }

                    string FolderName = Application.StartupPath + @"\TempExcelReport\";
                    if (System.IO.Directory.Exists(FolderName) == true)
                    {
                        try
                        {
                            System.IO.Directory.Delete(FolderName, true);
                        }
                        catch (Exception ex) { }
                    }

                    System.IO.Directory.CreateDirectory(FolderName);

                    string FileName = FolderName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xlsx";
                    //if (System.IO.File.Exists(FileName) == true) {
                    //    try {
                    //        System.IO.File.SetAttributes(FileName, System.IO.FileAttributes.Normal);
                    //        System.IO.File.Delete(FileName);
                    //    }
                    //    catch (Exception ex) { }
                    //}

                    Byte[] b = pke.GetAsByteArray();
                    System.IO.File.WriteAllBytes(FileName, b);

                    if (System.IO.File.Exists(FileName) == true)
                    {
                        System.Diagnostics.Process.Start(FileName);
                    }

                }
            }
            dt.Dispose();
        }

        private string SetDateFormat(DateTimePicker dtDate) {
            string ret = "";
            ret = dtDate.Value.ToString("yyyyMMdd", new System.Globalization.CultureInfo("en-US"));
            return ret;
        }
    }
}
