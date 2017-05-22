Public Class frmDailyHistory

    Private Sub frmDailyHistory_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.ControlBox = False
    End Sub

    Sub ShowUser()
        Dim dt As New DataTable
        Dim sql As String = ""

        sql += " select 0 as id,'----- Show All -----' as FullName,0 as ord" & vbNewLine
        sql += " union all" & vbNewLine
        sql += " select id,FullName,1 as ord" & vbNewLine
        sql += " from (" & vbNewLine
        sql += "    select MS_USER.id,isnull(title_name,'') + ' ' + isnull(fname,'') + ' ' + isnull(lname,'') as FullName " & vbNewLine
        sql += "    from MS_USER " & vbNewLine
        sql += "    left join MS_TITLE on MS_USER.ms_title_id = MS_TITLE.id " & vbNewLine
        sql += "    where MS_USER.id in (select ms_user_id from TB_COUNTER_QUEUE  group by ms_user_id)) as TB1 " & vbNewLine
        sql += " order by ord,FullName" & vbNewLine

        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            cbUser.DataSource = dt
            cbUser.DisplayMember = "FullName"
            cbUser.ValueMember = "id"
            dt = New DataTable
        End If
    End Sub

    Sub showcustomerend(ByVal UserID As Integer)
        Dim dt As New DataTable
        Dim sql As String = ""
        sql = "exec SP_ShowCustomerEnd " & UserID
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("waiting_time")
            dt.Columns.Add("total_waiting_time")

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("waiting_time") = CalServiceWaitingTime(dt.Rows(i)("call_time"), dt.Rows(i)("assign_time"))
                dt.Rows(i)("total_waiting_time") = CalServiceWaitingTime(dt.Rows(i)("call_time"), dt.Rows(i)("register_time"))
            Next
        End If

        Grid.DataSource = dt

        dt = New DataTable
        If UserID = 0 Then
            sql = "select id from TB_COUNTER_QUEUE where  status = 3"
        Else
            sql = "select id from TB_COUNTER_QUEUE where  status = 3 and ms_user_id = " & UserID
        End If

        dt = getDataTable(sql)
        lblServe.Text = dt.Rows.Count.ToString
    End Sub

    Private Sub cbCounter_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUser.SelectionChangeCommitted
        showcustomerend(cbUser.SelectedValue)
    End Sub

    Private Sub frmDailyHistory_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Grid.AutoGenerateColumns = False
        ShowUser()
        showcustomerend(cbUser.SelectedValue)
    End Sub
End Class