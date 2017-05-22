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
    Public TbCounterQueueID As Long = 0
    Public QcID As Long = 0

    Private Sub frmServiceConfirm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult <> Windows.Forms.DialogResult.Yes Then
            If Me.DialogResult <> Windows.Forms.DialogResult.OK Then
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
        End If
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




    Private Sub btnComfirm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComfirm.Click
        If CheckQCStatus(TbCounterQueueID, 4) = True Then
            Dim trans As New LinqDB.ConnectDB.TransactionDB
            If UpdateQCStatus(2, QcID, TbCounterQueueID, "QC Confirm", trans.Trans) = True Then
                trans.CommitTransaction()
                Me.DialogResult = Windows.Forms.DialogResult.Yes
                Me.Close()
            Else
                trans.RollbackTransaction()
                MessageBox.Show("Database Connection Fail!!! Please try again.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

End Class