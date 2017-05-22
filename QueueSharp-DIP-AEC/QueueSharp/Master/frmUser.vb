'Imports Security
Imports Engine.Common

Public Class frmUser

    Dim sql As String = ""
    Dim dt_data As New DataTable

    Sub Add()
        txtFname.Text = ""
        txtID.Text = ""
        txtSearch.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtRePassword.Text = ""
        txtLname.Text = ""
        txtUsername.Enabled = True
        txtPassword.Enabled = True
        txtRePassword.Enabled = True
        txtLname.Enabled = True
        cbActive.Checked = False
        txtFname.Enabled = True
        txtSearch.Enabled = False
        cbActive.Enabled = True
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbTitel.Enabled = True
        cbGroup.Enabled = True
        cbSearch.Enabled = False
        cbActive.Checked = True
    End Sub

    Sub Edit()
        txtSearch.Text = ""
        txtUsername.Enabled = True
        txtPassword.Enabled = True
        txtRePassword.Enabled = True
        txtLname.Enabled = True
        txtFname.Enabled = True
        txtSearch.Enabled = False
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbActive.Enabled = True
        cbTitel.Enabled = True
        cbGroup.Enabled = True
        cbSearch.Enabled = False
    End Sub

    Sub Clear()
        txtFname.Text = ""
        txtID.Text = ""
        txtFname.Enabled = False
        txtUsername.Enabled = False
        txtPassword.Enabled = False
        txtRePassword.Enabled = False
        txtLname.Enabled = False
        txtSearch.Enabled = True
        cbActive.Checked = False
        cbActive.Enabled = False
        Grid.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        cbTitel.Enabled = False
        cbGroup.Enabled = False
        cbSearch.Enabled = True
    End Sub

    Private Sub ShowData()
        sql = "select x.id,ms_title_id,fname,lname,ms_group_id,username,[password],x.active_status,"
        sql += " title_name + ' ' + fname + ' ' + lname as fullname,group_name,"
        sql += " case when x.active_status = 1 then 'Active' else 'Inactive' end as status "
        sql += " from MS_USER x "
        sql += " left join MS_TITLE y on x.ms_title_id = y.id "
        sql += " left join MS_GROUPUSER z on x.ms_group_id = z.id "
        sql += " order by fname"
        dt_data = getDataTable(sql)
        Grid.DataSource = dt_data
        SearchData()
    End Sub

    Private Sub SearchData()
        Try
            Select Case cbSearch.SelectedIndex
                Case 0
                    dt_data.DefaultView.RowFilter = "username like '%" & txtSearch.Text.Trim & "%' or fname like '%" & txtSearch.Text.Trim & "%' or lname like '%" & txtSearch.Text.Trim & "%' or group_name like '%" & txtSearch.Text.Trim & "%'"
                Case 1
                    dt_data.DefaultView.RowFilter = "(username like '%" & txtSearch.Text.Trim & "%' or fname like '%" & txtSearch.Text.Trim & "%' or lname like '%" & txtSearch.Text.Trim & "%' or group_name like '%" & txtSearch.Text.Trim & "%') and active_status = 1"
                Case 2
                    dt_data.DefaultView.RowFilter = "(username like '%" & txtSearch.Text.Trim & "%' or fname like '%" & txtSearch.Text.Trim & "%' or lname like '%" & txtSearch.Text.Trim & "%' or group_name like '%" & txtSearch.Text.Trim & "%') and active_status = 0"
            End Select
        Catch ex As Exception : End Try
    End Sub

    Private Function Validation() As Boolean

        If txtFname.Text.Trim = "" Then
            MessageBox.Show("Please enter the Name.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFname.Focus()
            Return False
        End If

        If txtLname.Text.Trim = "" Then
            MessageBox.Show("Please enter the Surname.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLname.Focus()
            Return False
        End If

        If txtUsername.Text.Trim = "" Then
            MessageBox.Show("Please enter Username.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        If txtPassword.Text.Trim = "" Then
            MessageBox.Show("Please enter Password.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        If txtRePassword.Text.Trim = "" Then
            MessageBox.Show("Please enter Re Password.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRePassword.Focus()
            Return False
        End If

        If txtPassword.Text.Trim <> txtRePassword.Text.Trim Then
            MessageBox.Show("password and confirm password don't match", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRePassword.Focus()
            Return False
        End If


        If CheckDuplicate("MS_USER", "username", txtUsername.Text.Trim, txtID.Text) = True Then
            MessageBox.Show("The Username already exists! Please re-enter the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
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
        Grid.AutoGenerateColumns = False
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "select id,title_name from MS_TITLE order by title_code"
        dt = getDataTable(sql)
        With cbTitel
            .DataSource = dt
            .DisplayMember = "title_name"
            .ValueMember = "id"
        End With
        dt = New DataTable
        sql = "select id,group_name from MS_GROUPUSER where active_status = 1 order by group_code"
        dt = getDataTable(sql)
        With cbGroup
            .DataSource = dt
            .DisplayMember = "group_name"
            .ValueMember = "id"
        End With

        

        cbSearch.SelectedIndex = 1

        ShowData()
        SearchData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim Active As Int32 = 0
            If cbActive.Checked Then
                Active = 1
            End If

            Dim PW As String = Engine.Common.FunctionEng.EnCripPwd(txtPassword.Text.Trim)

            If txtID.Text = "" Then
                ''Insert
                'Dim id_user As String = FindID("MS_USER")
                sql = "insert into MS_USER(ms_title_id,fname,lname,ms_group_id,username,[password],active_status,create_by,create_date,ms_counter_id,ms_skill_id)  "
                sql += " values(" & cbTitel.SelectedValue & ",'" & FixDB(txtFname.Text) & "','" & FixDB(txtLname.Text) & _
                    "'," & cbGroup.SelectedValue & ",'" & FixDB(txtUsername.Text) & "','" & FixDB(PW) & "'," & Active & "," & myUser.user_id & ",getdate(),0,0)"
                executeSQL(sql)
            Else
                ''Update
                sql = "update MS_USER set ms_title_id = " & cbTitel.SelectedValue & ",fname = '" & FixDB(txtFname.Text) & "',lname = '" & FixDB(txtLname.Text) & _
                    "',ms_group_id = " & cbGroup.SelectedValue & ",username = '" & FixDB(txtUsername.Text) & "',[password] = '" & FixDB(PW) & _
                    "',active_status = " & Active & ",update_by = " & myUser.user_id & ",update_date = getdate() where id = " & txtID.Text
                executeSQL(sql)
            End If

            MessageBox.Show("Your input data has successfully been saved.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Clear()
            ShowData()
            SearchData()
        End If
    End Sub

    Private Sub GridDepartment_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grid.CellMouseDoubleClick
        If Grid.RowCount > 0 Then
            Edit()
        End If
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            cbTitel.Focus()
        End If
    End Sub

    Private Sub cbTitel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbTitel.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtFname.Focus()
        End If
    End Sub

    Private Sub txtFname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFname.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtLname.Focus()
        End If
    End Sub

    Private Sub txtLname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLname.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbGroup.Focus()
        End If
    End Sub

    Private Sub cbGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbGroup.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtUsername.Focus()
        End If
    End Sub

    Private Sub txtUsername_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtRePassword.Focus()
        End If
    End Sub

    Private Sub txtRePassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRePassword.KeyPress
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


    Private Sub Grid_SelectionChanged(sender As Object, e As EventArgs) Handles Grid.SelectionChanged
        Try

            txtFname.Text = Grid.SelectedRows(0).Cells("fname").Value.ToString.Trim
            txtLname.Text = Grid.SelectedRows(0).Cells("lname").Value.ToString.Trim
            txtUsername.Text = Grid.SelectedRows(0).Cells("username").Value.ToString.Trim
            Dim PW As String = Engine.Common.FunctionEng.DeCripPwd(Grid.SelectedRows(0).Cells("password").Value.ToString.Trim)
            txtPassword.Text = PW

            cbTitel.SelectedValue = Grid.SelectedRows(0).Cells("ms_title_id").Value.ToString
            cbGroup.SelectedValue = Grid.SelectedRows(0).Cells("ms_group_id").Value.ToString
            cbActive.Checked = Grid.SelectedRows(0).Cells("active_status").Value
            txtID.Text = Grid.SelectedRows(0).Cells("id").Value.ToString.Trim
      
        Catch ex As Exception : End Try
    End Sub

End Class