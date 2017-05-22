Imports System.Data.SqlClient
Imports LinqDB.TABLE

Public Class frmQCResultTmp

    Public WriteOnly Property TbCounterQueueID As Long
        Set(value As Long)
            txtID.Text = value
        End Set
    End Property
    Public WriteOnly Property TbRegisterQueueID As Long
        Set(value As Long)
            txtRegisterQueueID.Text = value
        End Set
    End Property

    Sub SetRequisitionData()
        txtRegisterQueueID.Text = 10020

        Dim sql As String = "select tb_counter_queue_id, requisition_type_name, patent_type_name, app_no, ms_service_id, item_name_th, is_hold,is_key,is_scan"
        sql += " from vw_counter_queue "
        sql += " where tb_register_queue_id='" & txtRegisterQueueID.Text & "'"

        Dim dt As DataTable = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            lblAppNo.Text = dt.Rows(0)("app_no")
            lblPatentType.Text = dt.Rows(0)("patent_type_name")
            lblReqType.Text = dt.Rows(0)("requisition_type_name")


            dt.DefaultView.RowFilter = "is_hold='Y' or is_scan='Y' or is_key='Y' or ms_service_id=13 or ms_service_id=24"
            Dim tmpDt As New DataTable
            tmpDt = dt.DefaultView.ToTable.Copy
            If tmpDt.Rows.Count = 0 Then
                tmpDt.Columns.Add("ms_service_id")
                tmpDt.Columns.Add("item_name_th")
            End If

            Dim dr As DataRow = tmpDt.NewRow
            dr("ms_service_id") = 0
            dr("item_name_th") = "เลือก"
            tmpDt.Rows.InsertAt(dr, 0)

            cbServiceReject.DisplayMember = "item_name_th"
            cbServiceReject.ValueMember = "ms_service_id"
            cbServiceReject.DataSource = tmpDt
        End If
        'dt.Dispose()
    End Sub

    Function Validation() As Boolean
        If rdiResultFail.Checked = True Then
            If txtResultFailDesc.Text.Trim = "" Then
                MessageBox.Show("กรุณาระบุรายละเอียดที่ต้องแก้ไข", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtResultFailDesc.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim ret As Boolean = False
            Dim trans As New LinqDB.ConnectDB.TransactionDB





            If ret = True Then
                trans.CommitTransaction()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                trans.RollbackTransaction()
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
            Me.Close()
        End If
    End Sub

    Private Sub frmScanPageQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRequisitionData()


    End Sub

    'Private Sub SetFailServiceDDL()
    '    Dim sql As String = "select s.id, s.item_name_th, s.is_scan,s.is_key, s.is_hold,s.active_status, isnull(sr.id,0) sr_id"
    '    sql += " from MS_SERVICE s"
    '    sql += " left join MS_SERVICE_REJECT sr on s.id=sr.ms_service_id"
    '    sql += " where s.active_status='1'"

    '    Dim dt As DataTable = getDataTable(sql)
    '    If dt.Rows.Count > 0 Then
    '        dt.DefaultView.RowFilter = "is_hold='Y' and sr_id<>0"
    '        Dim hDt As New DataTable
    '        hDt = dt.DefaultView.ToTable.Copy
    '        SetServiceFail(cbFailHold, hDt)

    '        dt.DefaultView.RowFilter = "is_key='Y' and sr_id<>0"
    '        Dim kDt As New DataTable
    '        kDt = dt.DefaultView.ToTable.Copy
    '        SetServiceFail(cbFailKey, kDt)

    '        dt.DefaultView.RowFilter = "is_scan='Y' and sr_id<>0"
    '        Dim sDt As New DataTable
    '        sDt = dt.DefaultView.ToTable.Copy
    '        SetServiceFail(cbFailScan, sDt)

    '        dt.DefaultView.RowFilter = "id=13"
    '        Dim pDt As New DataTable
    '        pDt = dt.DefaultView.ToTable.Copy
    '        SetServiceFail(cbFailPublic, pDt)

    '        dt.DefaultView.RowFilter = "id=24"
    '        Dim cDt As New DataTable
    '        cDt = dt.DefaultView.ToTable.Copy
    '        SetServiceFail(cbFailCert, cDt)
    '    End If
    '    dt.Dispose()
    'End Sub

    'Private Sub SetServiceFail(ddl As ComboBox, dt As DataTable)
    '    If dt.Rows.Count > 0 Then
    '        ddl.DisplayMember = "item_name_th"
    '        ddl.ValueMember = "id"
    '        ddl.DataSource = dt
    '    Else
    '        ddl.DataSource = dt
    '    End If

    'End Sub

    Private Sub GridComposeDoc_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        Dim txtGridviewEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
        AddHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
    End Sub

    Private Sub txtGridviewEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Test for numeric value or backspace in first column
        'If dtgtaophieunhapxuat.CurrentCell.ColumnIndex = 0 Then
        If IsNumeric(e.KeyChar.ToString()) Or e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = False 'if numeric display
        Else
            e.Handled = True  'if non numeric don't display
        End If
        'End If
    End Sub

    Private Sub GridMainDoc_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs)
        Dim txtGridviewEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
        AddHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
    End Sub

    Private Sub rdiResultPass_CheckedChanged(sender As Object, e As EventArgs) Handles rdiResultPass.CheckedChanged
        If rdiResultPass.Checked = True Then
            cbServiceReject.Enabled = False

            txtResultFailDesc.Text = ""
            txtResultFailDesc.Enabled = False
        End If
    End Sub

    Private Sub rdiResultFail_CheckedChanged(sender As Object, e As EventArgs) Handles rdiResultFail.CheckedChanged
        If rdiResultFail.Checked = True Then
            txtResultFailDesc.Enabled = True
            cbServiceReject.Enabled = True
        Else
            cbServiceReject.Enabled = False
        End If
    End Sub
End Class

