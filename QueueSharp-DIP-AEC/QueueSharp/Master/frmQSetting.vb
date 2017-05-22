Public Class frmQSetting

    Dim dt_data As New DataTable

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim config_name As String = ""
        Dim config_value As String = ""
        Dim config_desc As String = ""
        Dim New_ As Boolean = False
        Dim sql As String = ""
        Dim dt As New DataTable

        config_name = "q_refresh"
        config_value = nud_q_refresh.Value.ToString
        config_desc = "(Queue) Refresh data every"

        sql = "select * from CF_SETTING where config_name = '" & config_name & "'"
        dt = getDataTable(sql)
        If dt.Rows.Count = 0 Then
            Dim id As Int32 = FindID("CF_SETTING")
            sql = "insert into CF_SETTING(id,config_name,config_value,config_desc,create_by,create_date) values(" & id & ",'" & config_name & "','" & config_value & "','" & config_desc & "'," & myUser.username & ",getdate())"
        Else
            sql = "update CF_SETTING "
            sql += " set config_value = '" & config_value & "',"
            sql += " update_by = '" & myUser.username & "',update_date = getdate() "
            sql += " where config_name = '" & config_name & "'"
        End If
        executeSQL(sql)

        MessageBox.Show("Your input data has successfully been saved.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub frmSetting_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "select * from CF_SETTING where config_name in ('q_refresh','q_con_ldap')"
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                Try
                    Select Case dt.Rows(i).Item("config_name").ToString.Trim
                        Case "q_refresh" 'Refresh
                            nud_q_refresh.Value = dt.Rows(i).Item("config_value").ToString
                    End Select
                Catch ex As Exception : End Try
            Next
        End If
    End Sub

End Class