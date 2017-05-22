Imports QueueSharp.Org.Mentalis.Files
Public Class frmSkill

    Dim sql As String = ""
    Dim dt_data As New DataTable

    Sub Add()
        txtName.Text = ""
        txtName.Enabled = True
        txtID.Text = "0"
        cmbRequisitionType.Enabled = True
        cmbRequisitionType.SelectedIndex = 0
        txtSearch.Text = ""
        txtSearch.Enabled = False
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbSearch.Enabled = False
        cbActive.Checked = True
        cbActive.Enabled = True
        GridItem.Enabled = True
        If GridItem.Rows.Count > 0 Then
            For i As Int32 = 0 To GridItem.Rows.Count - 1
                GridItem.Rows(i).Cells("cb").Value = False
            Next
        End If
    End Sub

    Sub Edit()
        txtSearch.Text = ""
        txtName.Enabled = True
        cmbRequisitionType.Enabled = True
        txtSearch.Enabled = False
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbSearch.Enabled = False
        GridItem.Enabled = True
        cbActive.Enabled = True
    End Sub

    Sub Clear()
        txtName.Text = ""
        txtID.Text = "0"
        cmbRequisitionType.SelectedIndex = 0
        cmbRequisitionType.Enabled = False
        txtName.Enabled = False
        txtSearch.Enabled = True
        cbActive.Checked = False
        cbActive.Enabled = False
        Grid.Enabled = True
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        cbSearch.Enabled = True
        GridItem.Enabled = False
        If GridItem.Rows.Count > 0 Then
            For i As Int32 = 0 To GridItem.Rows.Count - 1
                GridItem.Rows(i).Cells("cb").Value = False
            Next
        End If
    End Sub

    Private Sub ShowData()
        sql = " select MS_SKILL.id,skill_name,MS_SKILL.active_status,"
        sql += " case when MS_SKILL.active_status = 1 then 'Active' else 'Inactive' end as status ,requisition_type_name,ms_requisition_type_id "
        sql += " from MS_SKILL inner join MS_REQUISITION_TYPE on MS_SKILL.ms_requisition_type_id = MS_REQUISITION_TYPE.id "
        sql += " order by skill_name"
        dt_data = getDataTable(sql)
        Grid.DataSource = dt_data
        SearchData()
    End Sub

    Private Sub SearchData()
        Try
            Select Case cbSearch.SelectedIndex
                Case 0
                    dt_data.DefaultView.RowFilter = "skill_name like '%" & txtSearch.Text.Trim & "%'"
                Case 1
                    dt_data.DefaultView.RowFilter = "skill_name like '%" & txtSearch.Text.Trim & "%' and active_status = 1"
                Case 2
                    dt_data.DefaultView.RowFilter = "skill_name like '%" & txtSearch.Text.Trim & "%' and active_status = 0"
            End Select
        Catch ex As Exception : End Try
    End Sub

    Private Function Validation() As Boolean
        If txtName.Text.Trim = "" Then
            MessageBox.Show("Please enter the Skill.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If cmbRequisitionType.SelectedIndex = 0 Then
            MessageBox.Show("Please enter the Requisition Type.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRequisitionType.Focus()
            Return False
        End If

        If CheckDuplicate("MS_SKILL", "skill_name", txtName.Text.Trim, txtID.Text) = True Then
            MessageBox.Show("The Skill already exists! Please re-enter the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        Dim chk As Boolean = False
        For i As Int32 = 0 To GridItem.Rows.Count - 1
            If GridItem.Rows(i).Cells("cb").Value = True Then
                chk = True
                Exit For
            End If
        Next
        If chk = False Then
            MessageBox.Show("Please select the service.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

        Dim sql As String = ""
        Dim rtDt As New DataTable
        sql = " select id, requisition_type_name from MS_REQUISITION_TYPE order by order_seq"
        rtDt = getDataTable(sql)
        Dim rtDr As DataRow = rtDt.NewRow
        rtDr("id") = "0"
        rtDr("requisition_type_name") = "Select"
        rtDt.Rows.InsertAt(rtDr, 0)

        cmbRequisitionType.ValueMember = "id"
        cmbRequisitionType.DisplayMember = "requisition_type_name"
        cmbRequisitionType.DataSource = rtDt

        Dim dt As New DataTable
        dt = New DataTable
        sql = "select id,item_name_th "
        sql += " from MS_SERVICE "
        sql += " where active_status='1' "
        sql += " and id not in (select ms_service_id_reject from MS_SERVICE_REJECT) "
        sql += " order by item_order asc"
        dt = getDataTable(sql)
        GridItem.DataSource = dt

        ShowData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim Active As Int32 = 0
            If cbActive.Checked Then
                Active = 1
            End If

            Dim lnq As New LinqDB.TABLE.MsSkillLinqDB
            If txtID.Text > 0 Then
                lnq.GetDataByPK(txtID.Text, Nothing)
            End If

            lnq.SKILL_NAME = txtName.Text
            lnq.MS_REQUISITION_TYPE_ID = cmbRequisitionType.SelectedValue
            lnq.ACTIVE_STATUS = Active

            Dim ret As Boolean = False
            Dim trans As New LinqDB.ConnectDB.TransactionDB
            If lnq.ID > 0 Then
                ret = lnq.UpdateByPK(myUser.username, trans.Trans)
                If ret = True Then
                    sql = "delete from MS_SKILL_SERVICE where ms_skill_id = " & lnq.ID
                    ret = executeSQL(sql, trans.Trans, False)
                End If
            Else
                ret = lnq.InsertData(myUser.username, trans.Trans)
            End If

            If ret = True Then
                For i As Int32 = 0 To GridItem.Rows.Count - 1
                    If GridItem.Rows(i).Cells("cb").Value = True Then
                        'Dim id_skill As String = FindID("TB_SKILL_ITEM")
                        'sql = "insert into TB_SKILL_ITEM(id,skill_id,item_id,create_by,create_date) "
                        'sql += values(" & id_skill & "," & id & "," & GridItem.Rows(i).Cells("item_id").Value & "," & myUser.user_id & ",getdate())"
                        'executeSQL(sql)

                        Dim skLnq As New LinqDB.TABLE.MsSkillServiceLinqDB
                        skLnq.MS_SKILL_ID = lnq.ID
                        skLnq.MS_SERVICE_ID = GridItem.Rows(i).Cells("service_id").Value

                        ret = skLnq.InsertData(myUser.username, trans.Trans)
                        skLnq = Nothing
                        If ret = False Then
                            Exit For
                        End If
                    End If
                Next
            End If

            If ret = True Then
                trans.CommitTransaction()

                MessageBox.Show("Your input data has successfully been saved.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Clear()
                ShowData()
                SearchData()
            Else
                trans.RollbackTransaction()
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
            txtName.Text = Grid.SelectedRows(0).Cells("skill_name").Value.ToString.Trim
            txtID.Text = Grid.SelectedRows(0).Cells("id").Value.ToString.Trim
            cbActive.Checked = Grid.SelectedRows(0).Cells("active_status").Value
            cmbRequisitionType.SelectedValue = Grid.SelectedRows(0).Cells("ms_requisition_type_id").Value

            If GridItem.Rows.Count > 0 Then
                For i As Int32 = 0 To GridItem.Rows.Count - 1
                    GridItem.Rows(i).Cells("cb").Value = False
                Next
            End If

            If txtID.Text.Trim <> "" Then
                Dim dt As New DataTable
                sql = "select * from MS_SKILL_SERVICE where ms_skill_id = " & txtID.Text
                dt = getDataTable(sql)
                If dt.Rows.Count > 0 Then
                    For i As Int32 = 0 To dt.Rows.Count - 1
                        For j As Int32 = 0 To GridItem.Rows.Count - 1
                            If Trim(dt.Rows(i).Item("ms_service_id").ToString) = Trim(GridItem.Rows(j).Cells("service_id").Value.ToString) Then
                                GridItem.Rows(j).Cells("cb").Value = True
                            End If
                        Next
                    Next
                End If
            End If
        Catch ex As Exception : End Try
    End Sub

End Class