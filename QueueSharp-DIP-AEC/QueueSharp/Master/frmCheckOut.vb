Public Class frmCheckOut
    Dim dt As New DataTable
    Private Sub frmCheckOut_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClearTempCheckout()
        ShowData()
    End Sub

    Private Sub ClearTempCheckout()
        Dim sql As String = ""
        sql = " delete from TEMP_CHECKOUT "
        executeSQL(sql)
    End Sub

    Private Sub ShowData()
        Try

            Dim sql As String = " select q.id,q.app_no  "
            sql += " from TB_REGISTER_QUEUE q"
            sql += " where q.checkout_time is null "
            'sql += " and q.id not in (select distinct tb_register_queue_id from TB_COUNTER_QUEUE where status <> 3) "
            sql += " and q.app_no not in (select app_no from temp_checkout)"
            sql += " order by q.app_no "
            dt = getDataTable(sql)
            Grid.DataSource = dt
            Grid.AutoGenerateColumns = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShowCheckoutData()
        Try
            Dim dt As New DataTable
            Dim sql As String = " select app_no  "
            sql += " from TEMP_CHECKOUT"
            dt = getDataTable(sql)
            GridCheckOut.DataSource = dt
            GridCheckOut.AutoGenerateColumns = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        If GridCheckOut.Rows.Count = 0 Then
            MessageBox.Show("Please select file.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim trans As New LinqDB.ConnectDB.TransactionDB
        Try
            Dim ret As Boolean = False
            For i As Int32 = 0 To GridCheckOut.Rows.Count - 1

                Dim AppNo As String = GridCheckOut.Rows(i).Cells("CheckoutAppNo").Value
                Dim cDt As DataTable = getDataTable("select id from tb_register_queue where app_no='" & AppNo & "' and checkout_time is null", trans.Trans)
                If cDt.Rows.Count > 0 Then
                    Dim lnq As New LinqDB.TABLE.TbRegisterQueueLinqDB
                    lnq.GetDataByPK(cDt.Rows(0)("id"), trans.Trans)

                    lnq.CHECKOUT_TIME = DateTime.Now
                    If lnq.ID > 0 Then
                        ret = lnq.UpdateByPK(myUser.username, trans.Trans)
                    End If

                    If ret = False Then
                        trans.RollbackTransaction()
                        MessageBox.Show("Can't save.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                cDt.Dispose()
            Next

            If ret Then
                trans.CommitTransaction()
                MessageBox.Show("Check out complete.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearTempCheckout()
                ShowData()
                ShowCheckoutData()
            End If
        Catch ex As Exception
            trans.RollbackTransaction()
            MessageBox.Show(ex.ToString, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim IsSelected As Boolean = False
        For i As Int32 = 0 To Grid.Rows.Count - 1
            IsSelected = Grid.Rows(i).Cells("selected").Value
            If IsSelected = True Then Exit For
        Next

        If IsSelected = False Then
            MessageBox.Show("Please select file.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        For Each grv As DataGridViewRow In Grid.Rows
            If grv.Cells("selected").Value = 1 Then
                Dim sql As String = "insert into temp_checkout"
                sql += " values('" & grv.Cells("app_no").Value & "')"
                executeSQL(sql)
            End If
        Next

        ShowData()
        ShowCheckoutData()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Dim IsSelected As Boolean = False
        For i As Int32 = 0 To GridCheckOut.Rows.Count - 1
            IsSelected = GridCheckOut.Rows(i).Cells("CheckoutSelected").Value
            If IsSelected = True Then Exit For
        Next

        If IsSelected = False Then
            MessageBox.Show("Please select file.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        For Each grv As DataGridViewRow In GridCheckOut.Rows
            If grv.Cells("CheckoutSelected").Value = 1 Then
                Dim sql As String = "delete from  temp_checkout where app_no='" & grv.Cells("CheckoutAppNo").Value & "'"
                executeSQL(sql)
            End If
        Next

        ShowData()
        ShowCheckoutData()
    End Sub

    Private Sub txtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyUp
        If txtSearch.Text.Trim = "" Then
            dt.DefaultView.RowFilter = "app_no like '%%'"
        ElseIf dt.Rows.Count > 0 Then
            dt.DefaultView.RowFilter = "app_no like '%" & txtSearch.Text & "%'"
        End If
    End Sub
End Class