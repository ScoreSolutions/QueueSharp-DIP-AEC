Imports System.Data.SqlClient
Imports QueueSharp.Org.Mentalis.Files
Imports System.IO
Imports System.Net


Public Class frmServiceConfirm

    Public MsRequisitionTypeID As String = ""
    Public RequisitionTypeName As String = ""
    Public MsPatentTypeID As String = ""
    Public PatentTypeName As String = ""
    Public AppNo As String = ""
    Public RegisterDate As String = ""
    Public ServiceName As String = ""
    Public TbRegisterQueueID As Long = 0

    Private Sub frmServiceConfirm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult <> Windows.Forms.DialogResult.Yes Then
            If Me.DialogResult <> Windows.Forms.DialogResult.OK Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
            'Dim sql As String = ""
            'sql = "delete from TB_speaker where datediff(d,getdate(),call_date)=0 and queue_no ='" & FixDB(QueueNo) & "' and counter_id = " & myUser.counter_id
            'executeSQL(sql)
        End If

        Try
            frmUnitDisplay.Close()
        Catch ex As Exception
            'Do nothing
        End Try
    End Sub

    Private Sub frmServiceComfirm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        lblRequisitionTypeName.Text = RequisitionTypeName
        lblPatentTypeName.Text = PatentTypeName
        lblAppNo.Text = AppNo
        lblRegisterDate.Text = RegisterDate
        lblServiceName.Text = ServiceName
        lblStaffName.Text = myUser.fulllname
        lblCounterName.Text = myUser.counter_name

        
        ''***** ShowUnitDisplay *****
        'frmUnitDisplay.Owner = Me
        'frmUnitDisplay.QueueNo = AppNo
        'frmUnitDisplay.Show()
        ''***************************

        btnComfirm.Focus()

    End Sub

    

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHold5.Click
        'If CheckCustomerStatus(QueueNo, CustomerID, 4) = True Then
        '    If CheckHold(QueueNo, CustomerID) = False Then
        '        UpdateQueueStatus(6, myUser.counter_id, 5, QueueNo, CustomerID)
        '    End If

        '    Me.DialogResult = Windows.Forms.DialogResult.OK
        'Else
        '    'MessageBox.Show("Information has updated changed by another terminal !!!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
        'Me.Close()
    End Sub


    Private Sub btnComfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComfirm.Click
        If CheckQueueStatus(TbRegisterQueueID, 4) = True Then
            Dim trans As New LinqDB.ConnectDB.TransactionDB
            If UpdateQueueStatus(2, TbRegisterQueueID, 0, 0, "", trans.Trans) = True Then
                trans.CommitTransaction()
                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Me.Close()
            Else
                trans.RollbackTransaction()
                MessageBox.Show("Database Connection Fail!!! Please try again.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    'Private Sub btnMisscall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ret As Boolean = False
    '    Dim trans As New LinqDB.ConnectDB.TransactionDB
    '    If CheckQueueStatus(TbRegisterQueueID, 4, trans.Trans) = True Then
    '        Dim sql As String = ""
    '        sql = "update tb_counter_queue "
    '        sql += " set status = 8,call_time = assign_time,start_time = assign_time,end_time = assign_time,"
    '        sql += " ms_user_id = " & myUser.user_id & ", ms_counter_id = " & myUser.counter_id
    '        sql += " where tb_register_queue_id='" & TbRegisterQueueID & "' and status = 4"

    '        ret = executeSQL(sql, trans.Trans, True)
    '        If ret = True Then
    '            Dim dt As DataTable = getDataTable("select id, ms_service_id from tb_counter_queue where tb_register_queue_id='" & TbRegisterQueueID & "'", trans.Trans)
    '            If dt.Rows.Count > 0 Then
    '                Dim vDataNow As DateTime = FindDateNow(trans.Trans)
    '                For Each dr As DataRow In dt.Rows
    '                    InsertLog(dr("id"), myUser.user_id, myUser.counter_id, dr("ms_service_id"), 8, "", trans.Trans, vDataNow)
    '                Next
    '            End If
    '            dt.Dispose()

    '            Me.DialogResult = Windows.Forms.DialogResult.OK
    '        End If
    '    End If

    '    If ret = True Then
    '        trans.CommitTransaction()
    '    Else
    '        trans.RollbackTransaction()
    '    End If

    '    Me.Close()
    'End Sub

End Class