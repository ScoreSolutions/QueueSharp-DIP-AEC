Imports System.Data.SqlClient
Imports Engine.Common.ShopConnectDBENG

Public Class frmAddServiceCustomer

    Public TbRegisterQueueID As Long = 0

    Private Sub frmAddServiceCustomer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.DialogResult <> Windows.Forms.DialogResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub

    Private Sub frmAddServiceCustomer_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "select id,item_name_th  "
        sql += " from MS_SERVICE "
        sql += " where active_status = 1 and id not in (select ms_service_id from TB_COUNTER_QUEUE where status in (1,2,3,4,5) and tb_register_queue_id = '" & TbRegisterQueueID & "')  order by item_order"
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                AddService(dt.Rows(i).Item("item_name_th").ToString, dt.Rows(i).Item("id").ToString)
            Next
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim ItemID As Int32 = 0
        For i As Int32 = 0 To FLP_Item.Controls.Count - 1
            If FLP_Item.Controls(i).BackColor = Color.RoyalBlue Then
                ItemID = FLP_Item.Controls(i).Name
            End If
        Next

        If ItemID = 0 Then
            MessageBox.Show("You need to select one service to click OK button.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "select top 1 * from vw_counter_queue where  tb_register_queue_id = '" & TbRegisterQueueID & "'  and status = 2 "
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            Dim vDateNow As DateTime = FindDateNow()

            If CreateTransaction("frmAddServiceCustomer_btnAdd_Click") = True Then
                Dim lnq As New LinqDB.TABLE.TbCounterQueueLinqDB
                lnq.TB_REGISTER_QUEUE_ID = TbRegisterQueueID
                lnq.MS_SERVICE_ID = ItemID
                lnq.MS_COUNTER_ID = myUser.counter_id
                lnq.MS_USER_ID = myUser.user_id
                lnq.ASSIGN_TIME = Convert.ToDateTime(dr("assign_time"))
                lnq.CALL_TIME = Convert.ToDateTime(dr("call_time"))
                lnq.START_TIME = Convert.ToDateTime(dr("start_time"))
                lnq.STATUS = 2
                lnq.ADD_SERVICE = 1

                If lnq.InsertData(myUser.username, shTrans) = True Then
                    InsertLog(dt.Rows(0)("tb_counter_queue_id"), myUser.user_id, myUser.counter_id, dr("ms_service_id"), 2, "Add", shTrans, vDateNow)
                    CommitTransaction()

                    Me.DialogResult = Windows.Forms.DialogResult.Yes
                Else
                    RollbackTransaction()
                    SaveQueryErrorLog("Cannon Execute SQL", sql)
                    MessageBox.Show("The selected service already exists! Please select the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
                lnq = Nothing
            Else
                SaveQueryErrorLog("Cannon Create Transaction", "")
                MessageBox.Show("The selected service already exists! Please select the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            MessageBox.Show("The selected service already exists! Please select the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Sub AddService(ByVal ItemName As String, ByVal ItemId As Int32)
        Dim lbl As New Label
        'Dim Font As Font = New Font("Microsoft Sans Serif", 8.25)
        With lbl
            .AutoSize = False
            .Width = 320
            .Height = 30
            .Tag = ItemId.ToString
            .Name = ItemId.ToString
            .Text = ItemName
            .TextAlign = ContentAlignment.MiddleCenter
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.White
            '.Font = Font
        End With
        FLP_Item.Controls.Add(lbl)
        AddHandler lbl.Click, AddressOf CheckStatusItem
    End Sub

    Private Sub CheckStatusItem(ByVal Sender As Object, ByVal e As EventArgs)
        For i As Int32 = 0 To FLP_Item.Controls.Count - 1
            FLP_Item.Controls(i).BackColor = Color.White
            FLP_Item.Controls(i).ForeColor = Color.Black
        Next
        Dim btn As Label = Sender
        If btn.BackColor = Color.White Then
            btn.BackColor = Color.RoyalBlue
            btn.ForeColor = Color.White
        Else
            btn.BackColor = Color.White
            btn.ForeColor = Color.Black
        End If
    End Sub
End Class