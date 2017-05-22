Imports System.Data.SqlClient
Imports System.IO
Imports QueueSharp.Org.Mentalis.Files
Imports Engine.Common.ShopConnectDBENG

Public Class frmService

    Dim sql As String = ""
    Dim dt_data As New DataTable

    Sub Add()
        txtName_th.Text = ""
        txtName_th.Enabled = True
        txtID.Text = "0"
        txtSearch.Text = ""
        cbInActive.Checked = True
        cbInActive.Enabled = True
        cbServeMultiple.Checked = False
        cbServeMultiple.Enabled = True
        chkInputKeyPageAfterEnd.Checked = False
        chkInputKeyPageAfterEnd.Enabled = True
        chkInputScanPageAfterEnd.Checked = False
        chkInputScanPageAfterEnd.Enabled = True
        nudTime.Enabled = True
        nudWait.Enabled = True
        txtSearch.Enabled = False
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbSearch.Enabled = False
        nudTime.Value = 0
        nudWait.Value = 0
        txtItemOrder.Enabled = True
        txtItemOrder.Text = dt_data.Rows.Count + 1
        btnOrder.Enabled = False
    End Sub

    Sub Edit()
        txtSearch.Text = ""
        txtName_th.Enabled = True
        nudTime.Enabled = True
        nudWait.Enabled = True
        txtSearch.Enabled = False
        cbInActive.Enabled = True
        chkInputKeyPageAfterEnd.Enabled = True
        chkInputScanPageAfterEnd.Enabled = True
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbSearch.Enabled = False
        txtItemOrder.Enabled = True
        btnOrder.Enabled = False
        cbServeMultiple.Enabled = True
        
    End Sub

    Sub Clear()
        txtID.Text = "0"
        txtName_th.Text = ""
        nudTime.Enabled = False
        nudWait.Enabled = False
        txtSearch.Enabled = True
        cbInActive.Checked = False
        cbInActive.Enabled = False
        chkInputKeyPageAfterEnd.Checked = False
        chkInputKeyPageAfterEnd.Enabled = False
        chkInputScanPageAfterEnd.Checked = False
        chkInputScanPageAfterEnd.Enabled = False
        Grid.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        cbSearch.Enabled = True
        txtName_th.Enabled = False
        txtItemOrder.Text = ""
        txtItemOrder.Enabled = False
        btnOrder.Enabled = True
        cbServeMultiple.Enabled = False
    End Sub

    Private Sub ShowData()
        sql = "select x.id,x.std_wt,x.std_ht,x.active_status, " & vbNewLine
        sql += " x.item_order,item_name_th," & vbNewLine
        sql += " case when x.active_status = 1 then 'Active' else 'Inactive' end as status, " & vbNewLine
        sql += " serve_multiple_queue,is_scan,is_key "
        sql += " from ms_service x " & vbNewLine
        sql += " order by item_order,item_name_th" & vbNewLine
        dt_data = getDataTable(sql)
        Grid.AutoGenerateColumns = False
        Grid.DataSource = dt_data
        SearchData()
    End Sub

    Private Sub SearchData()
        Try
            Select Case cbSearch.SelectedIndex
                Case 0
                    dt_data.DefaultView.RowFilter = "item_name_th like '%" & txtSearch.Text.Trim & "%'"
                Case 1
                    dt_data.DefaultView.RowFilter = "item_name_th like '%" & txtSearch.Text.Trim & "%' and active_status = 1"
                Case 2
                    dt_data.DefaultView.RowFilter = "item_name_th like '%" & txtSearch.Text.Trim & "%' and active_status = 0"
            End Select
        Catch ex As Exception : End Try

    End Sub

    Private Function Validation() As Boolean
        If txtName_th.Text.Trim = "" Then
            MessageBox.Show("Please enter the Item Name In Thai.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName_th.Focus()
            Return False
        End If


        If txtItemOrder.Text.Trim = "" Then
            MessageBox.Show("Please enter the Item Order.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemOrder.Focus()
            Return False
        End If

        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "select * from ms_service"
        dt = getDataTable(sql)
        Dim Ord As Int32 = 0
        If txtID.Text = "0" Then
            Ord = dt.Rows.Count + 1
        Else
            Ord = dt.Rows.Count
        End If

        If CInt(txtItemOrder.Text) > Ord Then
            MessageBox.Show("This Max Item Order is " & Ord.ToString, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtItemOrder.Focus()
            Return False
        End If

        If CheckDuplicate("MS_SERVICE", "item_name_th", txtName_th.Text.Trim, txtID.Text) = True Then
            MessageBox.Show("Item Name In Thai already exists! Please re-enter the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName_th.Focus()
            Return False
        End If


        Return True
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Add()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear()
        ShowData()
    End Sub

    Private Sub frmService_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cbSearch.SelectedIndex = 1
        ShowData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim Active As Int32 = 0
            If cbInActive.Checked Then
                Active = 1
            End If

            Dim ServeMultiple As String = "N"
            If cbServeMultiple.Checked = True Then
                ServeMultiple = "Y"
            End If

            Dim IsScan As String = "N"
            If chkInputScanPageAfterEnd.Checked = True Then
                IsScan = "Y"
            End If

            Dim IsKey As String = "N"
            If chkInputKeyPageAfterEnd.Checked = True Then
                IsKey = "Y"
            End If

            Dim lnq As New LinqDB.TABLE.MsServiceLinqDB
            If txtID.Text > "0" Then
                lnq.GetDataByPK(txtID.Text, Nothing)
            End If
            lnq.ITEM_NAME_TH = txtName_th.Text
            lnq.STD_WT = nudWait.Value
            lnq.STD_HT = nudTime.Value
            lnq.ITEM_ORDER = txtItemOrder.Text
            lnq.SERVE_MULTIPLE_QUEUE = ServeMultiple
            lnq.ACTIVE_STATUS = Active
            lnq.IS_SCAN = IsScan
            lnq.IS_KEY = IsKey

            Dim ret As Boolean = False
            Dim trans As New LinqDB.ConnectDB.TransactionDB
            If lnq.ID > 0 Then
                'Update
                'sql = "select item_order from ms_service where id = " & txtID.Text
                'dt = getDataTable(sql, trans.Trans)
                'Order = lnq.ITEM_ORDER

                sql = "update MS_SERVICE set item_order = " & CInt(txtItemOrder.Text) - 1 & " "
                sql += " where item_order = '" & txtItemOrder.Text & "'"
                ret = lnq.UpdateBySql(sql, trans.Trans)
                If ret = True Then
                    ret = lnq.UpdateByPK(myUser.username, trans.Trans)
                End If
            Else
                ret = lnq.InsertData(myUser.username, trans.Trans)
            End If

            If ret = True Then
                txtID.Text = lnq.ID
                '********* ReOrder ********
                If CInt(txtItemOrder.Text) > lnq.ITEM_ORDER Then
                    sql = "select *  from MS_SERVICE  where item_order <= " & txtItemOrder.Text & "  order by item_order asc"
                    Dim dt As New DataTable
                    dt = getDataTable(sql, trans.Trans)
                    For i As Int32 = 0 To dt.Rows.Count - 1
                        sql = "update MS_SERVICE set item_order = " & i + 1 & " where id = " & dt.Rows(i).Item("id")
                        ret = executeSQL(sql, trans.Trans, False)
                        If ret = False Then
                            Exit For
                        End If
                    Next
                Else
                    sql = "select *  from MS_SERVICE  where item_order < " & txtItemOrder.Text & "  order by item_order asc"
                    Dim dt As New DataTable
                    dt = getDataTable(sql, trans.Trans)
                    For i As Int32 = 0 To dt.Rows.Count - 1
                        sql = "update MS_SERVICE set item_order = " & i + 1 & " where id = " & dt.Rows(i).Item("id")
                        ret = executeSQL(sql, trans.Trans, False)
                        If ret = False Then
                            Exit For
                        End If
                    Next

                    If ret = True Then
                        sql = "select *  from MS_SERVICE  where item_order >= " & txtItemOrder.Text & " and id <> '" & txtID.Text & "' order by item_order asc"
                        dt = New DataTable
                        dt = getDataTable(sql, trans.Trans)
                        For i As Int32 = 0 To dt.Rows.Count - 1
                            sql = "update MS_SERVICE set item_order = " & txtItemOrder.Text + i + 1 & " where id = " & dt.Rows(i).Item("id")
                            ret = executeSQL(sql, trans.Trans, False)
                            If ret = False Then
                                Exit For
                            End If
                        Next
                    End If
                End If

                If ret = True Then
                    trans.CommitTransaction()
                    '**************************
                    MessageBox.Show("Your input data has successfully been saved.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Clear()
                    ShowData()
                Else
                    trans.RollbackTransaction()
                End If

            Else
                trans.RollbackTransaction()
            End If
        End If
    End Sub

    Private Sub GridDepartment_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grid.CellMouseDoubleClick
        If Grid.RowCount > 0 Then
            Edit()
        End If
    End Sub

    Private Sub txtName_th_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName_th.KeyPress
        If Asc(e.KeyChar) = 13 Then
            nudTime.Focus()
        End If
    End Sub

    Private Sub nudTime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudTime.KeyPress
        If Asc(e.KeyChar) = 13 Then
            nudWait.Focus()
        End If
    End Sub

    Private Sub nudWait_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudWait.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtItemOrder.Focus()
        End If
    End Sub

    

    Private Sub cbInActive_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbInActive.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub txtSearch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyUp
        SearchData()
    End Sub

    Private Sub cbSearch_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSearch.SelectionChangeCommitted
        SearchData()
    End Sub

    Private Sub Grid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.SelectionChanged
        Try
            txtName_th.Text = Grid.SelectedRows(0).Cells("item_name_th").Value.ToString.Trim
            nudTime.Value = Grid.SelectedRows(0).Cells("std_ht").Value.ToString.Trim
            nudWait.Value = Grid.SelectedRows(0).Cells("std_wt").Value.ToString.Trim
            txtID.Text = Grid.SelectedRows(0).Cells("id").Value.ToString.Trim
            cbInActive.Checked = Grid.SelectedRows(0).Cells("active_status").Value
            chkInputKeyPageAfterEnd.Checked = (Grid.SelectedRows(0).Cells("is_key").Value = "Y")
            chkInputScanPageAfterEnd.Checked = (Grid.SelectedRows(0).Cells("is_scan").Value = "Y")
            txtItemOrder.Text = Grid.SelectedRows(0).Cells("item_order").Value.ToString.Trim
            cbServeMultiple.Checked = (Grid.SelectedRows(0).Cells("serve_multiple_queue").Value = "Y")
            
        Catch ex As Exception : End Try
    End Sub


    Private Sub btnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrder.Click
        Dim sql As String = ""
        Dim dt As New DataTable
        Dim countActive As Int32 = 0
        sql = "select id,item_order  from tb_item where active_status = 1 order by item_order asc"
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                sql = "update tb_item set item_order = " & i + 1 & " where id = " & dt.Rows(i).Item("id")
                executeSQL(sql)
            Next
        End If

        countActive = dt.Rows.Count
        dt = New DataTable
        sql = "select id,item_order  from tb_item where active_status = 0 order by item_order asc"
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                sql = "update tb_item set item_order = " & countActive + i + 1 & " where id = " & dt.Rows(i).Item("id")
                executeSQL(sql)
            Next
        End If

        ShowData()
    End Sub

End Class