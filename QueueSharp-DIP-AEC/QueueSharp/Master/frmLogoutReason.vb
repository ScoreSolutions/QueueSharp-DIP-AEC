Imports QueueSharp.Org.Mentalis.Files
Imports Engine.Common.ShopConnectDBENG

Public Class frmLogoutReason

    Dim sql As String = ""
    Dim dt_data As New DataTable

    Sub Add()
        txtName.Text = ""
        txtName.Enabled = True
        txtID.Text = "0"
        txtSearch.Text = ""
        cbProductive.Checked = True
        cbProductive.Enabled = True
        txtSearch.Enabled = False
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbSearch.Enabled = False
        cbActive.Checked = True
        cbActive.Enabled = True
    End Sub

    Sub Edit()
        txtName.Enabled = True
        txtSearch.Text = ""
        txtSearch.Enabled = False
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbSearch.Enabled = False
        cbProductive.Enabled = True
        cbActive.Enabled = True
    End Sub

    Sub Clear()
        txtName.Text = ""
        txtName.Enabled = False
        txtID.Text = "0"
        txtName.Enabled = False
        txtSearch.Enabled = True
        cbActive.Checked = False
        cbActive.Enabled = False
        cbProductive.Checked = False
        cbProductive.Enabled = False
        Grid.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        cbSearch.Enabled = True
    End Sub

    Private Sub ShowData()
        sql = "select id,name,productive,active_status,case when productive = 1 then 'Productive' else 'Non Productive' end as pro, "
        sql += " case when active_status = 1 then 'Active' else 'Inactive' end as status "
        sql += " from MS_LOGOUT_REASON order by name"
        dt_data = getDataTable(sql)
        Grid.DataSource = dt_data

        SearchData()
    End Sub

    Private Sub SearchData()
        Try
            Select Case cbSearch.SelectedIndex
                Case 0
                    dt_data.DefaultView.RowFilter = "name like '%" & txtSearch.Text.Trim & "%'"
                Case 1
                    dt_data.DefaultView.RowFilter = "name like '%" & txtSearch.Text.Trim & "%' and active_status = 1"
                Case 2
                    dt_data.DefaultView.RowFilter = "name like '%" & txtSearch.Text.Trim & "%' and active_status = 0"
            End Select
        Catch ex As Exception : End Try
    End Sub

    Private Function Validation() As Boolean

        If txtName.Text.Trim = "" Then
            MessageBox.Show("Please enter Reason.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If CheckDuplicate("MS_LOGOUT_REASON", "name", txtName.Text.Trim, txtID.Text) = True Then
            MessageBox.Show("The Reason already exists! Please re-enter the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
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

    Private Sub frmCustomerType_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cbSearch.SelectedIndex = 1
        ShowData()
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim Productive As Int32 = 0
            If cbProductive.Checked Then
                Productive = 1
            End If
            Dim Active As Int32 = 0
            If cbActive.Checked Then
                Active = 1
            End If

            Dim lnq As New LinqDB.TABLE.MsLogoutReasonLinqDB
            If txtID.Text > "0" Then
                lnq.GetDataByPK(txtID.Text, Nothing)
            End If
            lnq.NAME = txtName.Text
            lnq.PRODUCTIVE = Productive
            lnq.ACTIVE_STATUS = Active

            Dim trans As New LinqDB.ConnectDB.TransactionDB
            Dim ret As Boolean = False
            If lnq.ID > 0 Then
                ret = lnq.UpdateByPK(myUser.username, trans.Trans)
            Else
                ret = lnq.InsertData(myUser.username, trans.Trans)
            End If
            If ret = True Then
                trans.CommitTransaction()
                MessageBox.Show("Your input data has successfully been saved.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Clear()
                ShowData()
                SearchData()
            Else
                trans.RollbackTransaction()
                MessageBox.Show(lnq.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            lnq = Nothing
        End If
    End Sub

    Private Sub GridDepartment_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grid.CellMouseDoubleClick
        If Grid.RowCount > 0 Then
            Edit()
        End If
    End Sub

    Private Sub txtDepartmentName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbProductive.Focus()
        End If
    End Sub

    Private Sub cbProductive_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbProductive.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbActive.Focus()
        End If
    End Sub

    Private Sub cbInActive_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbActive.KeyPress
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
            txtName.Text = Grid.SelectedRows(0).Cells("Reason").Value.ToString.Trim
            txtID.Text = Grid.SelectedRows(0).Cells("id").Value.ToString.Trim
            cbProductive.Checked = Grid.SelectedRows(0).Cells("productive").Value
            cbActive.Checked = Grid.SelectedRows(0).Cells("active_status").Value
        Catch ex As Exception : End Try
    End Sub

End Class