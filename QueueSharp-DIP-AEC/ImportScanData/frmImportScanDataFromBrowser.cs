using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using mshtml;
using SHDocVw;
using IEAutomation;
using LinqDB.TABLE;
using LinqDB.ConnectDB;
using OfficeOpenXml;
using System.IO;

namespace ImportScanData
{
    public partial class frmImportScanDataFromBrowser : Form

    {
        InternetExplorer IE;
        IniReader ini = new IniReader(Application.StartupPath + @"\Config.ini");
        string dbLinkIP;
        public frmImportScanDataFromBrowser()
        {
            InitializeComponent();
        }

        

        private RequisitionDateInfo GetRequisitionDateInfo(string AppNo) {
            RequisitionDateInfo ret = new RequisitionDateInfo();
            string sql = "select isnull(frm_submit_date,SYS_SUBMIT_DATE) frm_submit_date, receive_date ";
            sql += " from [" + dbLinkIP + "].PATENTSYSTEM.dbo.REQUISITION rq";
            sql += " where app_no='" + AppNo + "'";
            sql += " and formtype=1";

            DataTable dt = Engine.Common.FunctionEng.ExecuteDataTable(sql);
            if (dt.Rows.Count > 0) {
                if(Convert.IsDBNull(dt.Rows[0]["receive_date"])==false){
                    ret.FILING_DATE = Convert.ToDateTime(dt.Rows[0]["frm_submit_date"]);
                }
                if (Convert.IsDBNull(dt.Rows[0]["receive_date"]) == false)
                {
                    ret.RECEIVE_DATE = Convert.ToDateTime(dt.Rows[0]["receive_date"]);
                }
            }
            return ret;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtImportFile.Text.Trim() == "") {
                MessageBox.Show("กรุณาเลือกไฟล์ที่ต้องการนำเข้าข้อมูล");
                return;
            }


            IEDriver sIE = new IEAutomation.IEDriver();
            IE = sIE.GetIEBrowser("iexplore", "https://epatent.ipthailand.go.th/ePatent/App-Exam/DocImageAll.aspx");
            if (IE == null) {
                IE = sIE.GetIEBrowser("iexplore", "https://10.10.18.171/ePatent/App-Exam/DocImageAll.aspx");
            }
            if (IE == null)
            {
                IE = sIE.GetIEBrowser("iexplore", "http://epatent.ipthailand.go.th/ePatent/App-Exam/DocImageAll.aspx");
            }
            if (IE == null)
            {
                IE = sIE.GetIEBrowser("iexplore", "http://10.10.18.171/ePatent/App-Exam/DocImageAll.aspx");
            }

            if (IE != null)
            {
                DataTable dt = FunctionENG.getDataTableFromExcel(txtImportFile.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    progressBar1.Maximum = dt.Rows.Count;
                    progressBar1.Value = 0;

                    foreach (DataRow dr in dt.Rows)
                    {
                        progressBar1.Value += 1;
                        lblProgressStatus.Text = "App No: " + dr["app_no"].ToString() + "   Current Row:" + progressBar1.Value + "   Total Row:" + dt.Rows.Count;
                        Application.DoEvents();

                        string AppNo = dr["app_no"].ToString();
                        string ReqTypeName = dr["requisition_type_name"].ToString();
                        string PatentTypeName = dr["patent_type_name"].ToString();
                        //DateTime PrepareDate = Engine.Common.FunctionEng.cStrToDateTime3(dr["prepare_date"].ToString());
                        //DateTime SendDate = Engine.Common.FunctionEng.cStrToDateTime3(dr["send_date"].ToString());
                        RequisitionDateInfo DateInfo = GetRequisitionDateInfo(AppNo);
                        
                        try
                        {
                            MsRequisitionTypeLinqDB rqLnq = new MsRequisitionTypeLinqDB();
                            rqLnq.ChkDataByWhere("requisition_type_name='" + ReqTypeName + "'",null);
                            if(rqLnq.ID==0){
                                MessageBox.Show("ไม่พบข้อมูลประเภทคำขอ " + ReqTypeName + "  เลขที่คำขอ:" + AppNo + "   RowID:"+progressBar1.Value);
                                return;
                            }

                            MsPatentTypeLinqDB ptLnq = new MsPatentTypeLinqDB();
                            ptLnq.ChkDataByWhere("patent_type_name = '" + PatentTypeName + "'", null);
                            if (ptLnq.ID == 0) {
                                MessageBox.Show("ไม่พบข้อมูลประเภทแฟ้ม " + PatentTypeName + "  เลขที่คำขอ:" + AppNo + "   RowID:" + progressBar1.Value);
                                return;
                            }
                            
                            TsFileRequisitionInfoLinqDB infLnq = new TsFileRequisitionInfoLinqDB();
                            infLnq.ChkDataByAPP_NO_MS_REQUISITION_TYPE_ID(AppNo, rqLnq.ID, null);

                            infLnq.APP_NO = AppNo;
                            if (DateInfo.FILING_DATE.Year != 1){
                                infLnq.FILING_DATE = DateInfo.FILING_DATE;
                            }
                            if (DateInfo.RECEIVE_DATE.Year != 1)
                            {
                                infLnq.RECEIVE_DATE = DateInfo.RECEIVE_DATE;
                            }
                            infLnq.MS_REQUISITION_TYPE_ID = rqLnq.ID;
                            infLnq.MS_PATENT_TYPE_ID = ptLnq.ID;
                            //infLnq.PREPARE_DATE = PrepareDate;
                            //infLnq.SEND_DATE = SendDate;

                            bool re = true;
                            TransactionDB trans = new TransactionDB();
                            if (infLnq.ID == 0)
                            {
                                re = infLnq.InsertData("Import", trans.Trans);
                            }
                            else {
                                re = infLnq.UpdateByPK("Import", trans.Trans);
                            }

                            if (re == false) {
                                trans.RollbackTransaction();
                                //MessageBox.Show(infLnq.ErrorMessage + "  เลขที่คำขอ:" + AppNo + "   RowID:" + progressBar1.Value);
                                Engine.Common.FunctionEng.CreateLogFile(Application.StartupPath + @"\ImportError_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", "AppNo=" + AppNo + "  " + infLnq.ErrorMessage);
                                continue;
                            }

                            sIE.SetInputStringValue("ctl00$MainContent$txtAppNo", AppNo);
                            sIE.ClickButton("ctl00$MainContent$btnSearch");

                            HTMLTable tb = sIE.GetTableElement("ctl00_MainContent_gvMain");
                            if (tb.rows.length > 1)
                            {
                                TsFileScanSummaryLinqDB lnq = new TsFileScanSummaryLinqDB();
                                DataTable tmpDt = lnq.GetDataList("app_no='" + AppNo + "'", "", trans.Trans);
                                if (tmpDt.Rows.Count > 0)
                                {
                                    //TransactionDB trans = new TransactionDB();
                                    foreach (DataRow tmpDr in tmpDt.Rows)
                                    {
                                        re = lnq.DeleteByPK(Convert.ToInt64(tmpDr["id"]), trans.Trans);
                                        if (re == false)
                                            break;
                                    }
                                    if (re == false)
                                    {
                                        trans.RollbackTransaction();
                                    }
                                    lnq = null;
                                }

                                if (re == true)
                                {
                                    int iRow = 0;
                                    foreach (HTMLTableRow tbr in tb.rows)
                                    {
                                        if (iRow == 0)
                                        {
                                            iRow += 1;
                                            continue;
                                        }

                                        HTMLTableCell CellReqNo = (HTMLTableCell)tbr.cells.item(2);
                                        HTMLTableCell CellReqType = (HTMLTableCell)tbr.cells.item(3);
                                        HTMLTableCell CellFilingDate = (HTMLTableCell)tbr.cells.item(4);
                                        HTMLTableCell CellImportDate = (HTMLTableCell)tbr.cells.item(5);
                                        HTMLTableCell CellDocType = (HTMLTableCell)tbr.cells.item(9);
                                        HTMLTableCell CellPageQty = (HTMLTableCell)tbr.cells.item(10);
                                        //HTMLTableCell CellVersion = (HTMLTableCell)tbr.cells.item(11);

                                        string ReqNo = CellReqNo.innerHTML.Trim();
                                        string ReqType = CellReqType.innerHTML.Trim();
                                        string FilingDate = CellFilingDate.innerHTML.Trim();
                                        string ImportDate = CellImportDate.innerHTML.Trim();
                                        string DocType = CellDocType.innerHTML.Trim();
                                        string PageQty = CellPageQty.innerHTML.Trim();
                                        string vVersion = GetString((HTMLTableCell)tbr.cells.item(11));

                                        //string vData = "AppNo=" + AppNo + ": PatentType=" + PatentType + ": FilingDate=" + FilingDate + ": ImportDate=" + ImportDate + ": " + DocType + ": PageQty=" + PageQty + ": Verion=" + vVersion;

                                        //Engine.Common.FunctionEng.CreateLogFile(vData);
                                        lnq = new TsFileScanSummaryLinqDB();
                                        lnq.APP_NO = AppNo;
                                        lnq.REQ_NO = ReqNo;
                                        lnq.REQUISITION_TYPE_NAME = ReqType;
                                        lnq.FILING_DATE = Engine.Common.FunctionEng.cStrToDateTime2(FilingDate);
                                        lnq.IMPORT_DATE = Engine.Common.FunctionEng.cStrToDateTime2(ImportDate);
                                        lnq.DOC_TYPE_NAME = DocType;
                                        lnq.PAGE_QTY = Convert.ToInt64(PageQty);
                                        lnq.DOC_VERSION = vVersion;

                                        re = lnq.InsertData("Import", trans.Trans);
                                        if (re == false) {
                                            Engine.Common.FunctionEng.CreateLogFile(Application.StartupPath + @"\ImportError_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", "AppNo=" + AppNo + "  "  +  infLnq.ErrorMessage);
                                            continue;
                                        }
                                        iRow += 1;
                                    }                                    
                                }
                            }

                            if (re == true)
                            {
                                trans.CommitTransaction();
                            }
                            else
                            {
                                trans.RollbackTransaction();
                            }
                        }
                        catch (Exception ex)
                        {
                            Engine.Common.FunctionEng.CreateLogFile(Application.StartupPath + @"\ImportError_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", ex.Message + "\n" + ex.StackTrace);
                        }

                    }
                    MessageBox.Show("Complete");
                }
            }
            else {
                MessageBox.Show("กรุณาเปิดระบบ ePatent และเข้าหน้าจอ เมนูหลัก > แสดงเอกสาร");
            }
        }


        private string GetString(HTMLTableCell tbr) {
            string ret = "";
            try {
                if (tbr != null)
                {
                    if (tbr.innerHTML != null)
                    {
                        ret = tbr.innerHTML;
                    }
                    else {
                        ret = "";
                    }
                }
                else {
                    ret = "";
                }
            }
            catch (Exception ex) {
                ret = "";
            }

            return ret;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                txtImportFile.Text = openFileDialog1.FileName;
            }
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            frmCheckData frm = new frmCheckData();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReports frm = new frmReports();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void frmImportScanDataFromBrowser_Shown(object sender, EventArgs e)
        {
            ini.Section = "AppConfig";
            dbLinkIP = ini.ReadString("ePATENT_DBLINK");
        }

        private void btnUpdateSendDate_Click(object sender, EventArgs e)
        {
            frmUpdateSentDate frm = new frmUpdateSentDate();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
