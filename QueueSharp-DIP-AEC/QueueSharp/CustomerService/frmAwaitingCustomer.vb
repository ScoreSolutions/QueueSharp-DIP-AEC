Imports QueueSharp.Org.Mentalis.Files
Imports Engine.Common.ShopConnectDBENG

Public Class frmAwaitingCustomer

    Private Sub AwaitingCustomer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.ControlBox = False
    End Sub

    Sub ShowData()
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "exec SP_AwaitingCustomer"
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("waiting_time")

            Dim vDateNow As DateTime = DateTime.Now
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("waiting_time") = CalServiceWaitingTime(vDateNow, dt.Rows(i)("maxwait"))
            Next
        End If
        Grid.AutoGenerateColumns = False
        Grid.DataSource = dt
    End Sub

    Private Sub frmAwaitingCustomer_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ShowData()
        Grid.AutoGenerateColumns = False
        GridWait.AutoGenerateColumns = False
        timerRefresh.Interval = AutoRefresh()
    End Sub

    Private Sub Grid_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridWait.CellMouseClick
        If GridWait.Rows.Count > 0 Then
            If GridWait.SelectedRows(0).Cells(e.ColumnIndex).Value.ToString.ToUpper = "CANCEL QUEUE" Then
                timerRefresh.Enabled = False
                Dim sql As String = ""
                Dim dt As New DataTable
                sql = "select * from vw_counter_queue where tb_register_queue_id = '" & FixDB(GridWait.SelectedRows(0).Cells("tb_register_queue_id").Value.ToString) & "' and status in (2,4)"
                dt = getDataTable(sql)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("This queue " & GridWait.SelectedRows(0).Cells("app_no").Value.ToString & " is being served ", "Attention")
                    timerRefresh.Interval = AutoRefresh()
                    timerRefresh.Enabled = True
                    Exit Sub
                End If

                Dim f As New frmDialogYesNo
                f.Text = "Confirm"
                f.lblTxt.Text = "Do you want to cancel App No " & GridWait.SelectedRows(0).Cells("app_no").Value.ToString & "?"
                If f.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    If CreateTransaction("frmAwaitingCustomer_Grid_CellMouseClick") = True Then
                        sql = "select tb_counter_queue_id, ms_service_id,item_name_th, app_no,  getdate() datenow "
                        sql += " from VW_COUNTER_QUEUE "
                        sql += " where  status =1 and tb_register_queue_id = '" & FixDB(GridWait.SelectedRows(0).Cells("tb_register_queue_id").Value.ToString) & "'"

                        dt = New DataTable
                        dt = getDataTable(sql, shTrans)
                        If dt.Rows.Count > 0 Then
                            Dim qItemID As Integer = 0
                            Dim IsRollBack As Boolean = False

                            sql = "update TB_COUNTER_QUEUE "
                            sql += " set status = 5,call_time = assign_time,start_time = assign_time,"
                            sql += " end_time = assign_time,ms_user_id = " & myUser.user_id & ","
                            sql += " ms_counter_id = " & myUser.counter_id & " "
                            sql += " where  tb_register_queue_id = '" & FixDB(GridWait.SelectedRows(0).Cells("tb_register_queue_id").Value.ToString) & "' "
                            sql += " and status=1"
                            If executeSQL(sql, shTrans, True) = True Then
                                Dim vDateNow As DateTime = Convert.ToDateTime(dt.Rows(0)("datenow"))

                                For Each dr As DataRow In dt.Rows
                                    InsertLog(dr("tb_counter_queue_id"), myUser.user_id, myUser.counter_id, dr("ms_service_id"), 5, "Cancel Queue From frmAwaitingCustomer", shTrans, vDateNow)
                                Next
                                qItemID = dt.Rows.Count
                            Else
                                IsRollBack = True
                            End If

                            If IsRollBack = False Then
                                CommitTransaction()
                            Else
                                RollbackTransaction()
                            End If
                        Else
                            RollbackTransaction()
                            MessageBox.Show("This queue " & GridWait.SelectedRows(0).Cells("app_no").Value.ToString & " is being served ", "Attention")
                        End If
                    End If

                    ShowData()
                    timerRefresh.Interval = AutoRefresh()
                    timerRefresh.Enabled = True
                End If
                'ElseIf GridWait.SelectedRows(0).Cells(e.ColumnIndex).Value.ToString.ToUpper = "CANCEL SERVICE" Then
                '    timerRefresh.Enabled = False
                '    Dim f As New frmServiceCancel
                '    f.QueueNo = GridWait.SelectedRows(0).Cells("queue_no").Value.ToString
                '    f.CustomerID = GridWait.SelectedRows(0).Cells("customer_id").Value.ToString
                '    f.Flag = "Cancel Service From frmAwaitingCustomer"
                '    f.CountEnd = 1
                '    If f.ShowDialog = Windows.Forms.DialogResult.Yes Then
                '        ShowData()
                '        timerRefresh.Interval = AutoRefresh()
                '        timerRefresh.Enabled = True
                '    End If
            End If
        End If
    End Sub

    Private Sub Grid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.SelectionChanged
        Try
            Dim sql As String = ""
            Dim dt As New DataTable
            sql = "select tb_register_queue_id, app_no,requisition_type_name, patent_type_name "
            sql += " from vw_counter_queue "
            sql += " where  status = 1 and ms_service_id = " & Grid.SelectedRows(0).Cells("id").Value
            dt = getDataTable(sql)
            GridWait.AutoGenerateColumns = False
            GridWait.DataSource = dt
            If GridWait.RowCount > 0 Then
                For i As Int32 = 0 To GridWait.RowCount - 1
                    GridWait.Item("Cancel", i).Style.BackColor = Drawing.Color.MistyRose
                    GridWait.Item("Cancel", i).Style.SelectionBackColor = Drawing.Color.MistyRose
                    GridWait.Item("Cancel", i).Style.ForeColor = Drawing.Color.Black
                    GridWait.Item("Cancel", i).Style.SelectionForeColor = Drawing.Color.Black
                Next
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub timerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerRefresh.Tick
        'ShowData()
    End Sub
End Class