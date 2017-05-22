Imports QueueSharp.Org.Mentalis.Files
Public Class frmServicePriority

    Dim sql As String = ""
    Dim dt_data As New DataTable

    Sub Add()
        cmbPatentType.Enabled = True
        cmbPatentType.SelectedValue = "0"
        cmbRequisitionType.Enabled = True
        cmbRequisitionType.SelectedValue = "0"
        txtSearch.Text = ""
        txtSearch.Enabled = False
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbSearch.Enabled = False
        GridItem.Enabled = True
        If GridItem.Rows.Count > 0 Then
            For i As Int32 = 0 To GridItem.Rows.Count - 1
                GridItem.Rows(i).Cells("cb").Value = False
            Next
        End If
    End Sub

    Sub Edit()
        cmbPatentType.Enabled = True
        cmbRequisitionType.Enabled = True
        txtSearch.Text = ""
        txtSearch.Enabled = False
        Grid.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        btnAdd.Enabled = False
        cbSearch.Enabled = False
        GridItem.Enabled = True
    End Sub

    Sub Clear()
        cmbPatentType.Enabled = False
        cmbRequisitionType.Enabled = False
        txtSearch.Enabled = True
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
        sql = " select rt.requisition_type_id, rt.requisition_type_name, rt.patent_type_id, rt.patent_type_name, " & vbNewLine
        sql += " rt.rt_active_status, rt.pt_active_status, rt.order_seq,count(sp.id) assign_service" & vbNewLine
        sql += " from " & vbNewLine
        sql += "	(select rt.id requisition_type_id, rt.requisition_type_name, rt.order_seq, pt.id patent_type_id, pt.patent_type_name, " & vbNewLine
        sql += "    rt.active_status rt_active_status, pt.active_status pt_active_status" & vbNewLine
        sql += "	from MS_REQUISITION_TYPE rt,MS_PATENT_TYPE pt) rt" & vbNewLine
        sql += " left join MS_SERVICE_PRIORITY sp on rt.requisition_type_id=sp.ms_requisition_type_id and rt.patent_type_id=sp.ms_patent_type_id" & vbNewLine
        sql += " group by rt.requisition_type_id, rt.requisition_type_name, rt.patent_type_id, rt.patent_type_name," & vbNewLine
        sql += " rt.rt_active_status, rt.pt_active_status,rt.order_seq" & vbNewLine
        sql += " order by rt.order_seq,rt.patent_type_name" & vbNewLine

        dt_data = getDataTable(sql)
        Grid.AutoGenerateColumns = False
        Grid.DataSource = dt_data
        SearchData()
    End Sub

    Private Sub SearchData()
        Try
            Select Case cbSearch.SelectedIndex
                Case 0
                    dt_data.DefaultView.RowFilter = "requisition_type_name like '%" & txtSearch.Text.Trim & "%' or patent_type_name like '%" & txtSearch.Text & "%'"
                Case 1
                    dt_data.DefaultView.RowFilter = "(requisition_type_name like '%" & txtSearch.Text.Trim & "%' or patent_type_name like '%" & txtSearch.Text & "%') and rt_active_status = 1"
                Case 2
                    dt_data.DefaultView.RowFilter = "(requisition_type_name like '%" & txtSearch.Text.Trim & "%' or patent_type_name like '%" & txtSearch.Text & "%') and rt_active_status = 0"
            End Select
        Catch ex As Exception : End Try
    End Sub

    Private Function Validation() As Boolean
        If cmbRequisitionType.SelectedValue = "0" Then
            MessageBox.Show("Please select Requisition Type.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRequisitionType.Focus()
            Return False
        End If

        If cmbPatentType.SelectedValue = "0" Then
            MessageBox.Show("Please select Patent Type.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRequisitionType.Focus()
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

    Private Sub frmServicePriority_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
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


        Dim ptDt As New DataTable
        sql = " select id, patent_type_name from MS_PATENT_TYPE order by patent_type_name"
        ptDt = getDataTable(sql)
        Dim ptDr As DataRow = ptDt.NewRow
        ptDr("id") = "0"
        ptDr("patent_type_name") = "Select"
        ptDt.Rows.InsertAt(ptDr, 0)

        cmbPatentType.ValueMember = "id"
        cmbPatentType.DisplayMember = "patent_type_name"
        cmbPatentType.DataSource = ptDt

        Dim dt As New DataTable
        'dt = New DataTable
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
            Dim ret As Boolean = False
            Dim trans As New LinqDB.ConnectDB.TransactionDB

            Dim lnq As New LinqDB.TABLE.MsServicePriorityLinqDB
            Dim dt As DataTable = lnq.GetDataList("ms_requisition_type_id='" & cmbRequisitionType.SelectedValue & "' and ms_patent_type_id='" & cmbPatentType.SelectedValue & "'", "", trans.Trans)
            If dt.Rows.Count > 0 Then
                For Each dr As DataRow In dt.Rows
                    ret = lnq.DeleteByPK(dr("id"), trans.Trans)
                    If ret = False Then
                        trans.RollbackTransaction()
                        MessageBox.Show(lnq.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Next
            Else
                ret = True
            End If

            If ret = True Then
                For i As Int32 = 0 To GridItem.Rows.Count - 1
                    If GridItem.Rows(i).Cells("cb").Value = True Then
                        Dim spLnq As New LinqDB.TABLE.MsServicePriorityLinqDB
                        spLnq.MS_REQUISITION_TYPE_ID = cmbRequisitionType.SelectedValue
                        spLnq.MS_PATENT_TYPE_ID = cmbPatentType.SelectedValue
                        spLnq.MS_SERVICE_ID = GridItem.Rows(i).Cells("service_id").Value

                        ret = spLnq.InsertData(myUser.username, trans.Trans)
                        spLnq = Nothing
                        If ret = False Then
                            Exit For
                        End If
                    End If
                Next

                If ret = True Then
                    trans.CommitTransaction()

                    MessageBox.Show("Your input data has successfully been saved.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Clear()
                    ShowData()
                    SearchData()
                Else
                    trans.RollbackTransaction()
                End If
            End If
            lnq = Nothing
        End If
    End Sub

    Private Sub GridDepartment_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Grid.CellMouseDoubleClick
        If Grid.RowCount > 0 Then
            Edit()
        End If
    End Sub

    Private Sub cbInActive_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
            cmbRequisitionType.SelectedValue = Grid.SelectedRows(0).Cells("requisition_type_id").Value
            cmbPatentType.SelectedValue = Grid.SelectedRows(0).Cells("patent_type_id").Value

            If GridItem.Rows.Count > 0 Then
                For i As Int32 = 0 To GridItem.Rows.Count - 1
                    GridItem.Rows(i).Cells("cb").Value = False
                Next
            End If

            Dim dt As New DataTable
            sql = " select * from MS_SERVICE_PRIORITY "
            sql += " where ms_requisition_type_id = '" & cmbRequisitionType.SelectedValue & "'"
            sql += " and ms_patent_type_id='" & cmbPatentType.SelectedValue & "'"
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
            dt.Dispose()
        Catch ex As Exception : End Try
    End Sub

End Class