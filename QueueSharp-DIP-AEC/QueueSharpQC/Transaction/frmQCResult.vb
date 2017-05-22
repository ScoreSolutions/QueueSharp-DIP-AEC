Imports System.Data.SqlClient
Imports LinqDB.TABLE

Public Class frmQCResult
    Dim _EndServiceTime As DateTime
    Public WriteOnly Property TbQcID As Long
        Set(value As Long)
            txtID.Text = value
        End Set
    End Property

    Public ReadOnly Property EndServiceTime As DateTime
        Get
            Return _EndServiceTime
        End Get
    End Property

    Sub SetRequisitionData()
        'txtID.Text = 12250

        Dim sql As String = "select q.tb_register_queue_id, q.requisition_type_name, q.patent_type_name, q.app_no"
        sql += " from vw_counter_queue q "
        sql += " inner join tb_counter_queue_qc qc on q.tb_counter_queue_id=qc.tb_counter_queue_id_qc"
        sql += " where qc.id='" & txtID.Text & "'"

        Dim dt As DataTable = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            lblAppNo.Text = dr("app_no")
            lblPatentType.Text = dr("patent_type_name")
            lblReqType.Text = dr("requisition_type_name")
        End If
        dt.Dispose()
    End Sub

    Function Validation() As Boolean
        If chkFailScan.Checked Or chkFailKey.Checked Or chkFailHole.Checked Or chkFailPublic.Checked Or chkFailCert.Checked Then
            If txtResultFailDesc.Text.Trim = "" Then
                MessageBox.Show("กรุณาระบุรายละเอียดที่ต้องแก้ไข", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtResultFailDesc.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Function SaveRejectData(dDateNow As DateTime, TbCounterQueueIDReject As Long, trans As LinqDB.ConnectDB.TransactionDB) As Boolean
        Dim ret As Boolean = False
        Try
            'โดยให้ Add เป็นชื่อ Service ที่เป็นการแก้ไข
            'เอาข้อมูล Service มาก่อน
            Dim sql As String = "select q.id, q.tb_register_queue_id, q.assign_time, q.call_time, q.start_time, q.end_time, "
            sql += " sr.ms_service_id_reject, q.ms_service_id "
            sql += " from TB_COUNTER_QUEUE q"
            sql += " inner join MS_SERVICE_REJECT sr on q.ms_service_id=sr.ms_service_id "
            sql += " where q.id='" & TbCounterQueueIDReject & "' "
            Dim dt As DataTable = getDataTable(sql, trans.Trans)
            If dt.Rows.Count > 0 Then
                'Insert ใน TB_COUNTER_QUEUE เพื่อ Add Service ที่ Reject
                Dim eLnq As New TbCounterQueueLinqDB
                eLnq.TB_REGISTER_QUEUE_ID = dt.Rows(0)("tb_register_queue_id")
                eLnq.MS_SERVICE_ID = dt.Rows(0)("ms_service_id_reject")
                'eLnq.ASSIGN_TIME = dDateNow
                eLnq.STATUS = 1

                If eLnq.InsertData(myUser.username, trans.Trans) Then
                    InsertLog(TbCounterQueueIDReject, myUser.user_id, myUser.counter_id, eLnq.MS_SERVICE_ID, 1, "QC Add Reject", trans.Trans, dDateNow)

                    'Update Status Service เดิม
                    sql = "update TB_COUNTER_QUEUE "
                    sql += " set status = 9,"   'Reject
                    sql += " call_time = assign_time ,"
                    sql += " start_time = assign_time, "
                    sql += " end_time = assign_time "
                    sql += " where id= '" & TbCounterQueueIDReject & "'"

                    If executeSQL(sql, trans.Trans, True) = True Then
                        Dim lnq As New TbCounterQueueQcLinqDB
                        lnq.GetDataByPK(txtID.Text, trans.Trans)
                        If lnq.ID > 0 Then
                            lnq.QC_END_TIME = dDateNow
                            lnq.STATUS = 3
                            lnq.REJECT_COMMENT = txtResultFailDesc.Text

                            ret = lnq.UpdateByPK(myUser.username, trans.Trans)
                        End If
                        lnq = Nothing
                        InsertLog(TbCounterQueueIDReject, myUser.user_id, myUser.counter_id, dt.Rows(0)("ms_service_id"), 9, "QC Reject", trans.Trans, dDateNow)
                    Else
                        ret = False
                        MessageBox.Show("Error Update Data : " & sql, "Error")
                    End If
                Else
                    ret = False
                    MessageBox.Show("Error Update Data : " & eLnq.ErrorMessage, "Error")
                End If
            End If
            dt.Dispose()
        Catch ex As Exception
            MessageBox.Show("Exception : " & ex.Message & vbNewLine & ex.StackTrace, "Exception")
            ret = False
        End Try
        Return ret
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim ret As Boolean = False
            _EndServiceTime = FindDateNow()
            Dim trans As New LinqDB.ConnectDB.TransactionDB
            If rdiResultPass.Checked = True Then
                'Insert QC Job
                Dim lnq As New TbCounterQueueQcLinqDB
                lnq.GetDataByPK(txtID.Text, trans.Trans)
                If lnq.ID > 0 Then
                    lnq.QC_RESULT = "Y"
                    lnq.STATUS = "3"
                    lnq.QC_END_TIME = _EndServiceTime
                    lnq.QC_BY = myUser.username

                    If lnq.UpdateByPK(myUser.username, trans.Trans) = True Then
                        ret = True
                    Else
                        ret = False
                        MessageBox.Show("Insert Data Error : " & lnq.ErrorMessage, "Error")
                    End If
                End If
                lnq = Nothing
            Else
                ret = True
                If chkFailHole.Checked = True Then
                    ret = SaveRejectData(_EndServiceTime, cbFailHold.SelectedValue, trans)
                End If
                If ret = True Then
                    If chkFailKey.Checked = True Then
                        ret = SaveRejectData(_EndServiceTime, cbFailKey.SelectedValue, trans)
                    End If
                End If

                If ret = True Then
                    If chkFailScan.Checked = True Then
                        ret = SaveRejectData(_EndServiceTime, cbFailScan.SelectedValue, trans)
                    End If
                End If

                If ret = True Then
                    If chkFailPublic.Enabled = True Then
                        ret = SaveRejectData(_EndServiceTime, cbFailPublic.SelectedValue, trans)
                    End If
                End If

                If ret = True Then
                    If chkFailCert.Enabled = True Then
                        ret = SaveRejectData(_EndServiceTime, cbFailCert.SelectedValue, trans)
                    End If
                End If
            End If

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

        SetFailServiceDDL()
    End Sub

    Private Sub SetFailServiceDDL()
        Dim sql As String = "select q.tb_counter_queue_id, q.item_name_th, q.is_scan,q.is_key, q.is_hold, q.ms_service_id, q.status"
        sql += " from vw_counter_queue q"
        sql += " inner join tb_counter_queue_qc qc on q.tb_counter_queue_id=qc.tb_counter_queue_id_qc"
        sql += " where qc.id='" & txtID.Text & "'"

        Dim dt As DataTable = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.RowFilter = "is_hold='Y' and status=3 "
            If dt.DefaultView.Count > 0 Then
                Dim hDt As New DataTable
                hDt = dt.DefaultView.ToTable.Copy
                SetServiceFail(cbFailHold, hDt)
            Else
                chkFailHole.Enabled = False
            End If

            dt.DefaultView.RowFilter = "is_key='Y' and status=3 "
            If dt.DefaultView.Count > 0 Then
                Dim kDt As New DataTable
                kDt = dt.DefaultView.ToTable.Copy
                SetServiceFail(cbFailKey, kDt)
            Else
                chkFailKey.Enabled = False
            End If

            dt.DefaultView.RowFilter = "is_scan='Y' and status=3 "
            If dt.DefaultView.Count > 0 Then
                Dim sDt As New DataTable
                sDt = dt.DefaultView.ToTable.Copy
                SetServiceFail(cbFailScan, sDt)
            Else
                chkFailScan.Enabled = False
            End If

            dt.DefaultView.RowFilter = "ms_service_id=13 or ms_service_id=33  and status=3"
            If dt.DefaultView.Count > 0 Then
                Dim pDt As New DataTable
                pDt = dt.DefaultView.ToTable.Copy
                SetServiceFail(cbFailPublic, pDt)
            Else
                chkFailPublic.Enabled = False
            End If

            dt.DefaultView.RowFilter = "ms_service_id=24 or ms_service_id=34  and status=3"
            If dt.DefaultView.Count > 0 Then
                Dim cDt As New DataTable
                cDt = dt.DefaultView.ToTable.Copy
                SetServiceFail(cbFailCert, cDt)
            Else
                chkFailCert.Enabled = False
            End If

        End If
        dt.Dispose()
    End Sub

    Private Sub SetServiceFail(ddl As ComboBox, dt As DataTable)
        If dt.Rows.Count > 0 Then
            ddl.DisplayMember = "item_name_th"
            ddl.ValueMember = "tb_counter_queue_id"
            ddl.DataSource = dt
        Else
            ddl.DataSource = dt
        End If
    End Sub

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
            chkFailScan.Checked = False
            chkFailKey.Checked = False
            chkFailHole.Checked = False
            chkFailPublic.Checked = False
            chkFailCert.Checked = False
            txtResultFailDesc.Text = ""
            txtResultFailDesc.Enabled = False
        End If
    End Sub

    Private Sub chkFailScan_CheckedChanged(sender As Object, e As EventArgs) Handles chkFailScan.CheckedChanged
        If chkFailScan.Checked Then
            rdiResultPass.Checked = False
            txtResultFailDesc.Enabled = True
            cbFailScan.Enabled = True
        Else
            cbFailScan.Enabled = True
        End If
    End Sub

    Private Sub chkFailKey_CheckedChanged(sender As Object, e As EventArgs) Handles chkFailKey.CheckedChanged
        If chkFailKey.Checked Then
            rdiResultPass.Checked = False
            txtResultFailDesc.Enabled = True
            cbFailKey.Enabled = True
        Else
            cbFailKey.Enabled = False
        End If
    End Sub

    Private Sub chkFailHole_CheckedChanged(sender As Object, e As EventArgs) Handles chkFailHole.CheckedChanged
        If chkFailHole.Checked Then
            rdiResultPass.Checked = False
            txtResultFailDesc.Enabled = True
            cbFailHold.Enabled = True
        Else
            cbFailHold.Enabled = False
        End If
    End Sub

    Private Sub chkFailPublic_CheckedChanged(sender As Object, e As EventArgs) Handles chkFailPublic.CheckedChanged
        If chkFailPublic.Checked Then
            rdiResultPass.Checked = False
            txtResultFailDesc.Enabled = True
            cbFailPublic.Enabled = True
        Else
            cbFailPublic.Enabled = False
        End If
    End Sub

    Private Sub chkFailCert_CheckedChanged(sender As Object, e As EventArgs) Handles chkFailCert.CheckedChanged
        If chkFailCert.Checked Then
            rdiResultPass.Checked = False
            txtResultFailDesc.Enabled = True
            cbFailCert.Enabled = True
        Else
            cbFailCert.Enabled = False
        End If
    End Sub
End Class

