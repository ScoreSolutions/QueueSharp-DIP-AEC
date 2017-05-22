using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinqDB.TABLE;

namespace ImportScanData
{
    public partial class frmCheckData : Form
    {
        public frmCheckData()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void SearchData() {
            if (txtAppNo.Text.Trim() != "") { 
                TsFileScanSummaryLinqDB lnq = new TsFileScanSummaryLinqDB();
                DataTable dt = lnq.GetDataList("app_no='" + txtAppNo.Text.Trim() + "'", "id", null);
                if (dt.Rows.Count > 0) {
                    dt.Columns.Add("no");
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        dt.Rows[i]["no"] = (i + 1).ToString();
                    }
                }
                
                gvDataList.AutoGenerateColumns = false;
                gvDataList.DataSource = dt;
            }
        }
    }
}
