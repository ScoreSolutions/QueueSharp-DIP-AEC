using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqDB.TABLE;
using LinqDB.ConnectDB;

namespace ImportScanData
{
    public partial class frmUpdateSentDate : Form
    {
        public frmUpdateSentDate()
        {
            InitializeComponent();
        }

        private void LoadDataToDropdownlist()
        {
            MsRequisitionTypeLinqDB rtLnq = new MsRequisitionTypeLinqDB();
            string rtSql = "select id, epatent_type_name ";
            rtSql += " from MS_REQUISITION_TYPE ";
            rtSql += " where epatent_type_name is not null ";
            rtSql += " and active_status=1";
            rtSql += " order by epatent_type_name";

            DataTable rtDt = rtLnq.GetListBySql(rtSql, null);
            if (rtDt.Rows.Count > 0)
            {
                DataRow dr = rtDt.NewRow();
                dr["id"] = "0";
                dr["epatent_type_name"] = "เลือก";
                rtDt.Rows.InsertAt(dr, 0);

                cbReqType.DataSource = rtDt;
                cbReqType.ValueMember = "id";
                cbReqType.DisplayMember = "epatent_type_name";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DataTable dt = FunctionENG.getDataTableFromExcel(txtImportFile.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                progressBar1.Maximum = dt.Rows.Count;
                progressBar1.Value = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    progressBar1.Value += 1;
                    lblProgress.Text = "App No: " + dr["app_no"].ToString() + "   Current Row:" + progressBar1.Value + "   Total Row:" + dt.Rows.Count;
                    Application.DoEvents();

                    string AppNo = dr["app_no"].ToString();
                    TsFileRequisitionInfoLinqDB infLnq = new TsFileRequisitionInfoLinqDB();
                    infLnq.ChkDataByAPP_NO_MS_REQUISITION_TYPE_ID(AppNo,Convert.ToInt64(cbReqType.SelectedValue), null);

                    if (infLnq.ID > 0) {
                        infLnq.SEND_DATE = dtSendDate.Value.Date;

                        bool re = true;
                        TransactionDB trans = new TransactionDB();
                        re = infLnq.UpdateByPK("UpdateSendDate", trans.Trans);

                        if (re == false)
                        {
                            trans.RollbackTransaction();
                            //MessageBox.Show(infLnq.ErrorMessage + "  เลขที่คำขอ:" + AppNo + "   RowID:" + progressBar1.Value);
                            Engine.Common.FunctionEng.CreateLogFile(Application.StartupPath + @"\ImportError_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", "AppNo=" + AppNo + "  " + infLnq.ErrorMessage);
                            continue;
                        }
                        else {
                            trans.CommitTransaction();
                        }
                    }
                }

                MessageBox.Show("Complete");
            }
        }

        private void frmUpdateSentDate_Load(object sender, EventArgs e)
        {
            LoadDataToDropdownlist();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtImportFile.Text = openFileDialog1.FileName;
            }
        }
    }
}
