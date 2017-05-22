Imports System.Data.SqlClient

Public Class frmCounter

    Dim sql As String = ""
    Dim dt_data As New DataTable

    Sub Add()
        GridSkill.BackgroundColor = Color.White
        GridSkill.Enabled = True
        If GridSkill.Rows.Count > 0 Then
            For i As Int32 = 0 To GridSkill.Rows.Count - 1
                GridSkill.Rows(i).Cells("cb").Value = False
            Next
        End If

        txtCode.Text = ""
        txtName.Text = ""
        txtID.Text = "0"
        cbActive.Checked = True
        cbQuick.Checked = False
        cbCounterManager.Checked = False
        cbCounterManager.Enabled = True
        cbCounterQC.Checked = False
        cbCounterQC.Enabled = True
        txtCode.Enabled = True
        txtName.Enabled = True
        txtSearch.Enabled = False
        cbActive.Enabled = True
        cbQuick.Enabled = True
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        txtCode.Focus()
        cbSearch.Enabled = False
    End Sub

    Sub Edit()
        txtCode.Enabled = True
        txtName.Enabled = True
        txtSearch.Enabled = False
        cbActive.Enabled = True
        cbQuick.Enabled = True
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        txtCode.Focus()
        cbSearch.Enabled = False
        cbCounterManager.Enabled = True
        cbCounterQC.Enabled = True
        GridSkill.BackgroundColor = Color.White
        GridSkill.Enabled = True
    End Sub

    Sub Clear()
        GridSkill.BackgroundColor = Color.LightGray
        If GridSkill.Rows.Count > 0 Then
            For i As Int32 = 0 To GridSkill.Rows.Count - 1
                GridSkill.Rows(i).Cells("cb").Value = False
            Next
        End If
        GridSkill.Enabled = False
        txtCode.Text = ""
        txtName.Text = ""
        txtID.Text = "0"
        txtCode.Enabled = False
        txtName.Enabled = False
        txtSearch.Enabled = True
        cbActive.Checked = False
        cbActive.Enabled = False
        cbQuick.Checked = False
        cbQuick.Enabled = False
        cbCounterManager.Checked = False
        cbCounterManager.Enabled = False
        cbCounterQC.Checked = False
        cbCounterQC.Enabled = False
        Grid.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        cbSearch.Enabled = True
    End Sub

    Sub ShowData()
        sql = "select id,counter_code,counter_name,active_status,quickservice,counter_manager,counter_qc,"
        sql += " case when active_status = 1 then 'Active' else 'Inactive' end as status "
        sql += " from MS_counter order by counter_name"
        dt_data = getDataTable(Sql)
        Grid.DataSource = dt_data
        SearchData()
    End Sub

    Sub SearchData()
        Try
            Select Case cbSearch.SelectedIndex
                Case 0
                    dt_data.DefaultView.RowFilter = "counter_code like '%" & txtSearch.Text.Trim & "%' or counter_name like '%" & txtSearch.Text.Trim & "%'"
                Case 1
                    dt_data.DefaultView.RowFilter = "(counter_code like '%" & txtSearch.Text.Trim & "%' or counter_name like '%" & txtSearch.Text.Trim & "%') and active_status = 1"
                Case 2
                    dt_data.DefaultView.RowFilter = "(counter_code like '%" & txtSearch.Text.Trim & "%' or counter_name like '%" & txtSearch.Text.Trim & "%') and active_status = 0"
            End Select
        Catch ex As Exception : End Try
    End Sub

    Function Validation() As Boolean
        If txtCode.Text.Trim = "" Then
            MessageBox.Show("Please enter the Counter Code.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return False
        End If

        If txtName.Text.Trim = "" Then
            MessageBox.Show("Please enter the Counter Name.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If CheckDuplicate("MS_counter", "counter_code", txtCode.Text.Trim, txtID.Text) = True Then
            MessageBox.Show("The Counter Code already exists! Please re-enter the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return False
        End If

        If CheckDuplicate("MS_counter", "counter_name", txtName.Text.Trim, txtID.Text) = True Then
            MessageBox.Show("The Counter Name already exists! Please re-enter the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCode.Focus()
            Return False
        End If

        Dim chk As Boolean = False
        For i As Int32 = 0 To GridSkill.Rows.Count - 1
            If GridSkill.Rows(i).Cells("cb").Value = "1" Then
                chk = True
                Exit For
            End If
        Next
        If chk = False Then
            MessageBox.Show("Please select Skill.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Sub frmCounter_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cbSearch.SelectedIndex = 1

        Dim dt As New DataTable
        sql = "select id,skill_name from MS_SKILL where active_status = 1 order by skill_name"
        dt = getDataTable(sql)
        GridSkill.AutoGenerateColumns = False
        GridSkill.DataSource = dt

        ShowData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then

            Dim Active As Int32 = 0
            If cbActive.Checked Then
                Active = 1
            End If

            Dim quick As Int32 = 0
            If cbQuick.Checked Then
                quick = 1
            End If

            Dim counter_manager As Int32 = 0
            If cbCounterManager.Checked Then
                counter_manager = 1
            End If
            Dim CounterQC As String = "0"
            If cbCounterQC.Checked Then
                CounterQC = "1"
            End If

            Dim lnq As New LinqDB.TABLE.MsCounterLinqDB
            If txtID.Text > "0" Then
                lnq.GetDataByPK(txtID.Text, Nothing)
            End If
            lnq.COUNTER_CODE = txtCode.Text
            lnq.COUNTER_NAME = txtName.Text
            lnq.COUNTER_STATUS = "0"
            lnq.QUICKSERVICE = quick
            lnq.AVAILABLE = "0"
            lnq.COUNTER_MANAGER = counter_manager
            lnq.COUNTER_QC = CounterQC
            lnq.ACTIVE_STATUS = Active

            Dim trans As New LinqDB.ConnectDB.TransactionDB
            Dim re As Boolean = False
            If lnq.ID > 0 Then
                re = lnq.UpdateByPK(myUser.username, trans.Trans)
            Else
                re = lnq.InsertData(myUser.username, trans.Trans)
            End If

            If re = True Then
                sql = "delete from ms_counter_skill where ms_counter_id = " & txtID.Text
                re = executeSQL(sql, trans.Trans, False)

                If re = True Then
                    For i As Int32 = 0 To GridSkill.Rows.Count - 1
                        If GridSkill.Rows(i).Cells("cb").Value = "1" Then
                            Dim ckLnq As New LinqDB.TABLE.MsCounterSkillLinqDB
                            ckLnq.MS_COUNTER_ID = lnq.ID
                            ckLnq.MS_SKILL_ID = GridSkill.Rows(i).Cells("skill_id").Value

                            re = ckLnq.InsertData(myUser.username, trans.Trans)
                            If re = False Then
                                Exit For
                            End If
                        End If
                    Next

                    If re = True Then
                        trans.CommitTransaction()

                        MessageBox.Show("Your selected data has successfully been saved.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Clear()
                        ShowData()
                    Else
                        trans.RollbackTransaction()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtName.Focus()
        End If
    End Sub

    Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbQuick.Focus()
        End If
    End Sub

    Private Sub nudUnitDisplay_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            cbQuick.Focus()
        End If
    End Sub

    Private Sub cbSpeed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            cbActive.Focus()
        End If
    End Sub

    Private Sub GridTypeAllow_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            txtID.Text = Grid.SelectedRows(0).Cells("id").Value.ToString.Trim
            txtCode.Text = Grid.SelectedRows(0).Cells("counter_code").Value.ToString.Trim
            txtName.Text = Grid.SelectedRows(0).Cells("counter_name").Value.ToString.Trim
            cbActive.Checked = Grid.SelectedRows(0).Cells("active_status").Value
            cbQuick.Checked = Grid.SelectedRows(0).Cells("quickservice").Value
            cbCounterManager.Checked = Grid.SelectedRows(0).Cells("counter_manager").Value
            cbCounterQC.Checked = Grid.SelectedRows(0).Cells("colCounterQC").Value

            If GridSkill.Rows.Count > 0 Then
                For i As Int32 = 0 To GridSkill.Rows.Count - 1
                    GridSkill.Rows(i).Cells("cb").Value = False
                Next
            End If

            If txtID.Text.Trim > "0" Then
                Dim dt As New DataTable
                sql = "select * from MS_COUNTER_SKILL where ms_counter_id = " & txtID.Text
                dt = getDataTable(sql)
                If dt.Rows.Count > 0 Then
                    For i As Int32 = 0 To dt.Rows.Count - 1
                        For j As Int32 = 0 To GridSkill.Rows.Count - 1
                            If Trim(dt.Rows(i).Item("ms_skill_id").ToString) = GridSkill.Rows(j).Cells("skill_id").Value Then
                                GridSkill.Rows(j).Cells("cb").Value = "1"
                            End If
                        Next
                    Next
                End If
            End If
        Catch ex As Exception : End Try

    End Sub

    Private Sub Grid_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grid.CellMouseDoubleClick
        If Grid.RowCount > 0 Then
            Edit()
        End If
    End Sub

End Class