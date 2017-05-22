Imports System.Data
Imports System.Drawing
Imports QueueSharp.Org.Mentalis.Files
Imports System.IO

Public Class frmServiceQueue

    'Dim IconCount(50) As String 'เป็นตัวแปรที่เก็บจำนวน Column ที่แสดง Icon 
    Dim GV_Height As Int32
    Dim ShowItemDisplay(20) As String

    Private Sub frmServiceQueue_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        FormServiceShow = False
        frmMain.btnNotifier.Visible = False
    End Sub

    Private Sub frmServiceFIFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Q
                btnCall.PerformClick()
            Case Keys.C
                btnCancel.PerformClick()
        End Select
    End Sub

#Region "Sub Show Customer Wait in room and Show Customer End Service in room"
    Sub showcustomerwait()
        Dim dt As New DataTable
        Dim sql As String = ""

        'กรณีปกติ
        sql = "exec SP_ShowCustomerWait " & myUser.counter_id & "," & myUser.skill_id

        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("wait_time")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("wait_time") = CalServiceWaitingTime(dt.Rows(i)("date_now"), dt.Rows(i)("register_time"))
            Next
        End If

        GridWait.AutoGenerateColumns = False
        GridWait.DataSource = dt
        
        lblCountCustomer.Text = "No. Waiting : " & dt.Rows.Count
        'FormatGridWait()
        avgServiceTime()
        Application.DoEvents()
        dt.Dispose()
    End Sub

    Sub ShowDDLSkill()

        Dim dt_skill As New DataTable
        Dim sql As String = ""
        sql = "select  k.id, k.skill_name"
        sql += " from MS_COUNTER_SKILL ck"
        sql += " inner join MS_SKILL k on k.id=ck.ms_skill_id"
        sql += " where k.active_status = 1"
        sql += " and ck.ms_counter_id = '" & myUser.counter_id & "'"
        sql += " order by k.skill_name"

        dt_skill = getDataTable(sql)
        If dt_skill.Rows.Count > 0 Then
            With cbSkill
                .DataSource = dt_skill
                .ValueMember = "id"
                .DisplayMember = "skill_name"
            End With

            myUser.skill_id = dt_skill.Rows(0).Item("id").ToString
            If myUser.skill_id > 0 Then
                cbSkill.SelectedValue = myUser.skill_id
                Dim uLnq As New LinqDB.TABLE.MsUserLinqDB
                uLnq.GetDataByPK(myUser.user_id, Nothing)
                If uLnq.ID > 0 Then
                    uLnq.MS_SKILL_ID = myUser.skill_id

                    Dim trans As New LinqDB.ConnectDB.TransactionDB
                    If uLnq.UpdateByPK(myUser.username, trans.Trans) Then
                        trans.CommitTransaction()
                    Else
                        trans.RollbackTransaction()
                    End If
                End If
                uLnq = Nothing
            Else
                cbSkill.SelectedIndex = 0
                myUser.skill_id = cbSkill.SelectedValue
            End If
        End If

    End Sub
    Sub showcustomerend()
        Dim dt As New DataTable
        Dim sql As String = ""
        sql = "exec SP_ShowCustomerEnd " & myUser.user_id
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            dt.Columns.Add("wait_time")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("wait_time") = CalServiceWaitingTime(dt.Rows(i)("date_now"), dt.Rows(i)("register_time"))
            Next
        End If
        GridEnd.DataSource = dt

        'dt = New DataTable
        'sql = "select id from TB_COUNTER_QUEUE where DATEDIFF(D,GETDATE(),service_date) = 0 and status in (3,5,8) and TB_COUNTER_QUEUE.user_id = " & myUser.user_id & " group by queue_no"
        'dt = getDataTable(sql)
        lblServe.Text = dt.Rows.Count.ToString
        dt.Dispose()
    End Sub

#End Region

    'หา สถานะของลูกค้าที่ยังคงค้างอยู่ที่ห้อง
    Sub FindQueueService()
        Dim dt As New DataTable
        Dim sql As String = ""
        sql = "exec SP_UnfinishedCustomer " & myUser.counter_id & "," & myUser.user_id
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            frmMain.timerCheckForce.Enabled = False
            frmMain.timerForce.Enabled = False
            frmMain.BtnLogout.Enabled = False

            Select Case dt.Rows(0).Item("status").ToString
                Case "2"
                    Dim ff As New frmEndByService
                    ff.AppNo = dt.Rows(0).Item("app_no").ToString
                    ff.RegisterQueueID = dt.Rows(0)("tb_register_queue_id")
                    ff.RequisitionTypeID = dt.Rows(0)("ms_requisition_type_id")
                    ff.PatentTypeID = dt.Rows(0)("ms_patent_type_id")
                    frmMain.Hide()
                    ff.ShowDialog()
                    frmMain.Show()

                    frmMain.timerCheckForce.Enabled = True
                    frmMain.BtnLogout.Enabled = True
                Case "4"
                    Dim f As New frmServiceConfirm
                    f.AppNo = dt.Rows(0)("app_no").ToString
                    f.MsRequisitionTypeID = dt.Rows(0)("ms_requisition_type_id").ToString
                    f.MsPatentTypeID = dt.Rows(0)("ms_patent_type_id").ToString
                    f.RequisitionTypeName = dt.Rows(0)("requisition_type_name").ToString
                    f.PatentTypeName = dt.Rows(0)("patent_type_name")
                    f.RegisterDate = Convert.ToDateTime(dt.Rows(0).Item("register_time")).ToString("dd/MM/yyyy HH:mm:ss", New Globalization.CultureInfo("th-TH"))
                    f.ServiceName = dt.Rows(0)("item_name_th")
                    f.TbRegisterQueueID = dt.Rows(0)("tb_register_queue_id")

                    If f.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                        If CheckQueueStatus(dt.Rows(0).Item("tb_register_queue_id").ToString, dt.Rows(0).Item("status").ToString) = True Then
                            UpdateQueueStatus(1, dt.Rows(0).Item("tb_register_queue_id"), dt.Rows(0).Item("tb_counter_queue_id"), dt.Rows(0).Item("ms_service_id"), "")
                        Else
                            MessageBox.Show("The information has already been updated by the other user.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    End If
                    showcustomerwait()
                    FindQueueService()

                    frmMain.timerCheckForce.Enabled = True
                    frmMain.BtnLogout.Enabled = True
            End Select


            
        Else
            txtDisplayQueue.Text = ""
            lblQueue.Text = "-"
            lblCustomerID.Text = "-"
            lbltype.Text = "-"
            FLP.Enabled = True
        End If
        dt.Dispose()
    End Sub

    Private Sub InteractButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCall.MouseDown
        btnCall.Top += 3
        btnCall.Left += 3
    End Sub

    Private Sub InteractButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCall.MouseUp
        btnCall.Top -= 3
        btnCall.Left -= 3
    End Sub

    Public Sub btnCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCall.Click
        If txtDisplayQueue.Text <> "" Then Exit Sub
        btnCall.Enabled = False
        GridWait.Enabled = False
        frmMain.timerCheckForce.Enabled = False
        frmMain.timerForce.Enabled = False
        frmMain.BtnLogout.Enabled = False

        Dim dt As New DataTable
        Dim sql As String = ""
        Dim Chk As Boolean = False
        sql = "exec SP_ShowCustomerWait " & myUser.counter_id & "," & myUser.skill_id

        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            For i As Int32 = 0 To dt.Rows.Count - 1
                Dim CurrStatus As Int32 = dt.Rows(i).Item("status").ToString
                Dim DateNow As DateTime = FindDateNow()
                If CreateTransaction("frmServiceQueue_btnCall_Click") = True Then
                    If UpdateCallStatus(dt.Rows(i)("tb_register_queue_id"), DateNow, shTrans) = True Then
                        CommitTransaction()

                        showcustomerwait()
                        Dim f As New frmServiceConfirm
                        f.AppNo = dt.Rows(i)("app_no").ToString
                        f.MsRequisitionTypeID = dt.Rows(i)("ms_requisition_type_id").ToString
                        f.MsPatentTypeID = dt.Rows(i)("ms_patent_type_id").ToString
                        f.RequisitionTypeName = dt.Rows(i)("requisition_type_name").ToString
                        f.PatentTypeName = dt.Rows(i)("patent_type_name")
                        f.RegisterDate = Convert.ToDateTime(dt.Rows(i).Item("register_time")).ToString("dd/MM/yyyy HH:mm:ss", New Globalization.CultureInfo("th-TH"))
                        f.ServiceName = dt.Rows(i)("item_name_th")
                        f.TbRegisterQueueID = dt.Rows(i)("tb_register_queue_id")
                        frmMain.BtnLogout.Enabled = True

                        If f.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                            'ปิด Dialog ไปเลย
                            Dim ret As Boolean = False
                            Dim trans As New LinqDB.ConnectDB.TransactionDB
                            Select Case CurrStatus
                                Case 8
                                    ret = UpdateQueueStatus(8, dt.Rows(i).Item("tb_register_queue_id"), 0, dt.Rows(i)("ms_service_id"), "", trans.Trans)
                                Case Else
                                    ret = UpdateQueueStatus(1, dt.Rows(i).Item("tb_register_queue_id"), 0, dt.Rows(i)("ms_service_id"), "", trans.Trans)
                            End Select

                            If ret = True Then
                                trans.CommitTransaction()
                            Else
                                trans.RollbackTransaction()
                            End If

                        ElseIf f.DialogResult = Windows.Forms.DialogResult.OK Then
                            'Miss Call
                        ElseIf f.DialogResult = Windows.Forms.DialogResult.Yes Then
                            Dim ff As New frmEndByService
                            ff.AppNo = dt.Rows(i).Item("app_no").ToString
                            ff.RegisterQueueID = dt.Rows(i)("tb_register_queue_id")
                            ff.RequisitionTypeID = dt.Rows(i)("ms_requisition_type_id")
                            ff.PatentTypeID = dt.Rows(i)("ms_patent_type_id")
                            frmMain.Hide()
                            ff.ShowDialog()
                            frmMain.Show()
                        End If
                        showcustomerwait()
                        FindQueueService()
                        Exit For
                    Else
                        RollbackTransaction()
                        If AutoForceQueue = False Then
                            MessageBox.Show("The information has already been updated by the other user.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                        showcustomerwait()
                    End If
                    Else
                        showcustomerwait()
                    End If
            Next
            frmMain.timerCheckForce.Enabled = True
        End If
        dt.Dispose()
        btnCall.Enabled = True
        GridWait.Enabled = True
        frmMain.BtnLogout.Enabled = True
    End Sub

    Private Sub ButRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshWait.Click
        showcustomerwait()
    End Sub

    Private Sub ButRefresh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showcustomerend()
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabMessagePage.SelectedIndexChanged
        Select Case TabMessagePage.SelectedTab.Name.ToUpper
            Case "TabServicePage".ToUpper
                showcustomerwait()
                'CheckTimerWait.Checked = True
                'timerRefreshWait.Enabled = True
            Case "TabViewPage".ToUpper
                showcustomerend()
                'timerRefreshWait.Enabled = False
        End Select
    End Sub

    Private Sub frmServiceFIFO_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.ControlBox = False
        GridItem.Columns("item_id").Visible = False
    End Sub

    Private Sub frmServiceQueue_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        FormServiceShow = True
        frmMain.timerCheckForce.Enabled = True
        GV_Height = GroupBoxView.Height
        CheckTimerWait.Checked = True
        CheckCounterFunction()
        lblRoomName.Text = myUser.counter_name
        ShowDDLSkill()
        FindQueueService()
        frmMain.btnNotifier.Visible = True
        CheckQuickService()
        avgServiceTime()
        GridWait.AutoGenerateColumns = False
        GridEnd.AutoGenerateColumns = False
        timerRefreshWait.Interval = AutoRefresh()

        If AutoForceQueue = True Then
            btnCall_Click(Nothing, Nothing)
            AutoForceQueue = False
        End If


        showcustomerwait()
        btnCall.Enabled = True
        GridWait.Enabled = True
    End Sub

    
    'Function CheckUserServiceItem(ByVal ItemID As Int32) As Boolean
    '    'เช็คว่าวันนี้ User ทำ Service อะไรได้บ้าง
    '    Dim sql As String = ""
    '    Dim dt As New DataTable
    '    sql = "select item_id from TB_USER_SERVICE_SCHEDULE where DATEDIFF(D,GETDATE(),service_date)=0 and user_id = " & myUser.user_id & " and item_id = " & ItemID & " and active_status = 1"
    '    dt = getDataTable(sql)
    '    If dt.Rows.Count > 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    'Private Sub CheckItemDisplay(ByVal Sender As Object, ByVal e As EventArgs)
    '    Dim chk As CheckBox = Sender
    '    Dim sql As String = ""
    '    Dim dt As New DataTable
    '    If chk.Checked = True Then
    '        sql = "select id from TB_USER_SERVICE_LOG where DATEDIFF(D,GETDATE(),service_date)=0 and item_id = " & chk.Name & " and [USER_ID] = " & myUser.user_id
    '        dt = getDataTable(sql)
    '        If dt.Rows.Count > 0 Then
    '            sql = "update TB_USER_SERVICE_LOG set active_status = 1 where DATEDIFF(D,GETDATE(),service_date)=0and item_id = " & chk.Name & " and [USER_ID] = " & myUser.user_id
    '            executeSQL(sql)
    '        Else
    '            sql = "declare @ID as int; select @ID = (select isnull(MAX(id + 1),1) as id from TB_USER_SERVICE_LOG); insert into TB_USER_SERVICE_LOG(id,service_date,[user_id],item_id,active_status) values(@ID,GETDATE()," & myUser.user_id & "," & chk.Name & ",1)"
    '            executeSQL(sql)
    '        End If
    '    Else
    '        sql = "update TB_USER_SERVICE_LOG set active_status = 0 where DATEDIFF(D,GETDATE(),service_date)=0 and item_id = " & chk.Name & " and [USER_ID] = " & myUser.user_id
    '        executeSQL(sql)
    '    End If
    '    showcustomerwait()
    'End Sub

    Private Sub GroupBoxView_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GroupBoxView.KeyPress
        If UCase(e.KeyChar) = "Q"c Then
            btnCall.PerformClick()
        ElseIf UCase(e.KeyChar) = "C"c Then
            btnCancel.PerformClick()
        End If
    End Sub

    Private Sub txtQueue_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQueue.KeyPress
        If e.KeyChar = Chr(13) Then
            If txtQueue.Text <> "" Then
                QuickService(txtQueue.Text)
                txtQueue.Text = ""
            End If
        End If
    End Sub

    Public Sub GridWait_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridWait.CellMouseClick
        'If GridWait.Rows.Count > 0 Then
        '    frmMain.timerCheckForce.Enabled = False
        '    frmMain.timerForce.Enabled = False
        '    frmMain.BtnLogout.Enabled = False

        '    If GridWait.SelectedRows(0).Cells(e.ColumnIndex).Value.ToString.ToUpper = "CANCEL" Then
        '        Dim sql As String = ""
        '        Dim dt As New DataTable
        '        sql = "select app_no,status "
        '        sql += " from TB_COUNTER_QUEUE "
        '        sql += " where tb_counter_queue_id  = '" & FixDB(GridWait.SelectedRows(0).Cells("tb_counter_queue_id").Value.ToString) & "' "
        '        sql += " and status = 1 "

        '        dt = getDataTable(sql)
        '        If dt.Rows.Count > 0 Then
        '            Dim f As New frmServiceCancel
        '            f.CustomerTypeID = GridWait.SelectedRows(0).Cells("customertype_id").Value.ToString
        '            f.QueueNo = GridWait.SelectedRows(0).Cells("queue_no").Value.ToString
        '            f.CustomerID = GridWait.SelectedRows(0).Cells("customer_id").Value.ToString
        '            f.StatusCustomer = dt.Rows(0).Item("status").ToString
        '            f.ShowDialog()
        '            showcustomerwait()
        '            FindQueueService()

        '        Else
        '            MessageBox.Show("The information has already been updated by the other user.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If
        '    End If

        '    frmMain.timerCheckForce.Enabled = True
        '    frmMain.BtnLogout.Enabled = True
        'End If
    End Sub

    Public Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If txtDisplayQueue.Text <> "" Then
            'If CheckQueueStatus(dt.Rows(0).Item("tb_register_queue_id"), 2) = True Then
            '    Dim f As New frmServiceCancel
            '    f.CustomerTypeID = txtCustomerTypeID.Text
            '    f.QueueNo = lblQueue.Text
            '    f.CustomerID = lblCustomerID.Text
            '    f.StatusCustomer = 2
            '    If f.ShowDialog = Windows.Forms.DialogResult.Yes Then
            '        showcustomerwait()
            '        FindQueueService()
            '    End If
            'Else
            '    MessageBox.Show("The information has already been updated by the other user.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        End If
    End Sub

    Function CheckCustomerUnfinished() As Boolean
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "exec SP_UnfinishedCustomer " & myUser.counter_id
        dt = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            MessageBox.Show("กรุณาจบการบริการของลูกค้า ก่อนเรียกคิวถัดไปมารับบริการ", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return True
        End If
        Return False
    End Function

    Sub CheckQuickService()
        If CounterFunction.QuickService = 1 Then
            GroupBoxView.Height = GV_Height
            GroupBoxView.Height = GroupBoxView.Height - 40
            pnQuickService.Visible = True
            txtQueue.Focus()
        Else
            GroupBoxView.Height = GV_Height
            pnQuickService.Visible = False
        End If
    End Sub

    Private Sub QuickService(ByVal AppNo As String)
        Dim dt As New DataTable
        dt = GridWait.DataSource
        Dim dt_tmp As New DataTable
        If dt.Rows.Count > 0 Then
            dt.DefaultView.RowFilter = "app_no = '" & FixDB(AppNo) & "'"
            If dt.DefaultView.Count > 0 Then
                dt_tmp = dt.DefaultView.ToTable
                Dim vDateNow As DateTime = FindDateNow()
                If UpdateQuickServiceCallStatus(dt_tmp.Rows(0)("tb_register_queue_id"), vDateNow) = True Then
                    FindQueueService()

                End If
                showcustomerwait()
            End If
            dt.DefaultView.RowFilter = ""
        End If
    End Sub

    'Private Sub timerRefreshWait_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerRefreshWait.Tick
    '    If TabMessagePage.SelectedTab.Name <> "TabServicePage" Then Exit Sub
    '    showcustomerwait()
    'End Sub

    Private Sub FormatGridWait()

        For i As Integer = 0 To GridWait.Rows.Count - 1
            Try
                With GridWait.Rows(i).DefaultCellStyle
                    If GridWait.Rows(i).Cells("color").Value.ToString <> "" And IsNumeric(GridWait.Rows(i).Cells("color").Value.ToString) Then
                        Dim Color As Color = Drawing.Color.FromArgb(CInt(GridWait.Rows(i).Cells("color").Value.ToString))
                        .ForeColor = Drawing.Color.White
                        .SelectionForeColor = Drawing.Color.White
                        .BackColor = Color
                        .SelectionBackColor = Color
                    Else
                        Dim Color As Color = Drawing.Color.White
                        .ForeColor = Drawing.Color.Black
                        .SelectionForeColor = Drawing.Color.Black
                        .BackColor = Color
                        .SelectionBackColor = Color
                    End If
                End With

                GridWait.Item("Cancel", i).Style.BackColor = Drawing.Color.MistyRose
                GridWait.Item("Cancel", i).Style.SelectionBackColor = Drawing.Color.MistyRose
                GridWait.Item("Cancel", i).Style.ForeColor = Drawing.Color.Black
                GridWait.Item("Cancel", i).Style.SelectionForeColor = Drawing.Color.Black
                Application.DoEvents()
            Catch ex As Exception

            End Try
        Next

    End Sub


    Public FloatHwnd As Form = Nothing
    Private Sub btnCompactView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompactView.Click
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        If ini.ReadString("compactsite") = "" Then
            ini.Write("compactsite", "M")
            frmCompactView_M.Show()
            FloatHwnd = frmCompactView_M
        Else
            Select Case ini.ReadString("compactsite").ToString.ToUpper
                Case "B"
                    frmCompactView_B.Show()
                    FloatHwnd = frmCompactView_B
                Case "M"
                    frmCompactView_M.Show()
                    FloatHwnd = frmCompactView_M
                Case "S"
                    frmCompactView_S.Show()
                    FloatHwnd = frmCompactView_S
            End Select
        End If
        AddHandler FloatHwnd.FormClosed, AddressOf CloseFormFloat
        frmMain.Hide()
    End Sub

    Public Sub CloseFormFloat(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        FloatHwnd = Nothing
        showcustomerwait()
        FindQueueService()
    End Sub

    'Private Sub btnMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMessage.Click
    '    TimerMessageCounter.Enabled = False
    '    TimerMessageCounterColor.Enabled = False
    '    frmMain.TimerBeep.Enabled = False
    '    If MsgShow = False Then
    '        Dim f As New frmWriteMessage
    '        f.ShowDialog()
    '    Else
    '        Dim f As New frmMessageCounter
    '        f.ShowDialog()
    '        btnMessage.BackColor = Drawing.Color.White
    '        btnMessage.ForeColor = Drawing.Color.Black
    '    End If
    '    TimerMessageCounter.Enabled = True
    '    TimerMessageCounterColor.Enabled = True
    'End Sub

    '#Region "TabMsg"
    '    Private Sub Grid_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '        If Grid.Rows.Count > 0 Then
    '            lblQueue_msg.Text = Grid.SelectedRows(0).Cells("queue_no_msg").Value.ToString
    '            lblCustomerID_msg.Text = Grid.SelectedRows(0).Cells("customer_id_msg").Value.ToString
    '            txtMsg.Focus()
    '        End If
    '    End Sub

    '    Sub AddTime()
    '        Dim j As String = ""
    '        For i As Int32 = 0 To 23
    '            j = CStr(i)
    '            ComboH.Items.Add(j.ToString.PadLeft(2, CChar("0")))
    '        Next

    '        For i As Int32 = 0 To 60
    '            If i > 59 Then
    '                Exit For
    '            End If
    '            j = CStr(i)
    '            i = i + 5
    '            If CInt(j) < 10 Then
    '                j = "0" & j
    '            End If
    '            i = i - 1
    '            ComboM.Items.Add(j)
    '        Next
    '    End Sub

    '    Sub findtime()
    '        Dim mm As String = FindDateNow.Hour.ToString.PadLeft(2, CChar("0"))
    '        Dim nn As String = FindDateNow.Minute.ToString.PadLeft(2, CChar("0"))
    '        Dim n As Int32 = CInt(nn) Mod 5
    '        If n <> 0 Then
    '            n = (5 - n) + CInt(nn)
    '            nn = CStr(n).ToString.PadLeft(2, CChar("0"))
    '            If nn = "60" Then
    '                nn = "00"
    '                mm = CStr(CInt(mm) + 1)
    '            End If
    '        End If
    '        Try
    '            ComboH.SelectedIndex = ComboH.FindString(mm)
    '            ComboM.SelectedIndex = ComboM.FindString(nn)
    '        Catch ex As Exception : End Try
    '    End Sub

    '    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '        If lblQueue_msg.Text = "-" Then
    '            MessageBox.Show("กรุณาระบุลูกค้า ที่ต้องการส่งข้อความ !!!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        If txtMsg.Text.Trim = "" Then
    '            MessageBox.Show("กรุณากรอกข้อความที่ต้องการจะส่ง !!!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        Dim dt_tmp As New DataTable
    '        Dim time_select As String = ComboH.SelectedItem.ToString & ":" & ComboM.SelectedItem.ToString
    '        Dim time_now As String = FindDateNow.ToShortTimeString
    '        dt_tmp = getDataTable("select datediff(n,'" & time_select & "','" & time_now & "') as dd")
    '        If dt_tmp.Rows.Count > 0 Then
    '            If CInt(dt_tmp.Rows(0)("dd").ToString) > 0 Then
    '                MessageBox.Show("ไม่สามารถระบุเวลา ย้อนหลังได้  !!!", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Exit Sub
    '            End If
    '        End If

    '        Dim sql As String = ""
    '        sql = "declare @ID as int; select @ID = (select isnull(MAX(id + 1),1) as id from TB_message);insert into TB_message(id,queue_no,customer_id,message,message_date,message_status,create_by,create_date) values(@ID,'" & FixDB(lblQueue_msg.Text) & "','" & FixDB(lblCustomerID_msg.Text) & "','" & FixDB(txtMsg.Text) & "','" & FixDate(FindDateNow) & " " & time_select & "',1," & myUser.user_id & ",getdate())"
    '        executeSQL(sql)
    '        MessageBox.Show("ข้อความถูกส่งเรียบร้อยแล้ว ", "ส่งข้อความ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        txtSearch.Text = ""
    '        lblCustomerID_msg.Text = ""
    '        lblQueue_msg.Text = "-"
    '    End Sub

    '    Private Sub TextSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
    '        If Asc(e.KeyChar) = 13 Then
    '            Grid_CellMouseDoubleClick(Nothing, Nothing)
    '        End If
    '    End Sub

    '#End Region

    'Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim sql As String = ""
    '    Dim dt As New DataTable
    '    sql = "select * from TB_MESSAGE_COUNTER where message_status = 1 and DATEDIFF(D,GETDATE(),create_date)=0 and counter_id = " & myUser.counter_id & " order by create_date asc"
    '    dt = getDataTable(sql)
    '    If dt.Rows.Count > 0 Then
    '        MsgShow = True
    '    End If
    'End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If MsgShow = True Then

    '        If btnMessage.BackColor = Drawing.Color.White Then
    '            btnMessage.BackColor = Drawing.Color.Yellow
    '            btnMessage.ForeColor = Drawing.Color.Red
    '        ElseIf btnMessage.BackColor = Drawing.Color.Yellow Then
    '            btnMessage.BackColor = Drawing.Color.Blue
    '            btnMessage.ForeColor = Drawing.Color.Yellow
    '        ElseIf btnMessage.BackColor = Drawing.Color.Blue Then
    '            btnMessage.BackColor = Drawing.Color.Yellow
    '            btnMessage.ForeColor = Drawing.Color.Red
    '        End If
    '        frmMain.TimerBeep.Enabled = True
    '    End If
    'End Sub

    Sub CheckCounterFunction()
        If myUser.counter_id > 0 Then
            Dim sql As String = ""
            Dim dt As New DataTable
            sql = "select quickservice from MS_COUNTER where id = " & myUser.counter_id
            dt = getDataTable(sql)
            If dt.Rows.Count > 0 Then
                CounterFunction.QuickService = dt.Rows(0).Item("quickservice")
                'CounterFunction.SpeedLane = dt.Rows(0).Item("speed_lane")
                'CounterFunction.Beep = dt.Rows(0).Item("beep")
                'CounterFunction.ReturnCase = dt.Rows(0).Item("return_case")
                'CounterFunction.Swap = dt.Rows(0).Item("auto_swap")
            End If
        End If
    End Sub

    Private Sub btnExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpand.Click
        If btnExpand.Tag.ToString = "EXP" Then
            Me.WindowState = FormWindowState.Maximized
            btnExpand.Text = "      Window"
            btnExpand.Tag = "WND"
            Me.MdiParent = Nothing
        Else
            Me.WindowState = FormWindowState.Maximized
            btnExpand.Text = "      Expand"
            btnExpand.Tag = "EXP"
            Me.MdiParent = frmMain
        End If

        If CounterFunction.QuickService = 1 Then
            GV_Height = GroupBoxView.Height + 40
        Else
            GV_Height = GroupBoxView.Height
        End If
    End Sub

    Private Sub GridWait_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridWait.CellMouseDoubleClick
        If txtDisplayQueue.Text <> "" Then Exit Sub
        Try
            btnCall.Enabled = False
            GridWait.Enabled = False
            frmMain.timerCheckForce.Enabled = False
            frmMain.timerForce.Enabled = False
            frmMain.BtnLogout.Enabled = False

            Dim sql As String = ""
            Dim DateNow As String = FindDateNow()
            If CreateTransaction("frmServiceQueue_GridWait_CellMouseDoubleClick") = True Then

                If UpdateCallStatus(GridWait.SelectedRows(0).Cells("tb_register_queue_id").Value, DateNow, shTrans) = True Then
                    CommitTransaction()

                    Dim vCounterQueueID As Long = GridWait.SelectedRows(0).Cells("tb_counter_queue_id").Value

                    showcustomerwait()
                    Dim f As New frmServiceConfirm

                    sql = "select app_no, ms_requisition_type_id,ms_patent_type_id,requisition_type_name,patent_type_name,"
                    sql += " register_time, item_name_th,ms_service_id, tb_register_queue_id, tb_counter_queue_id,status"
                    sql += " from vw_counter_queue "
                    sql += " where tb_counter_queue_id= '" & vCounterQueueID & "'"

                    Dim dt As DataTable = getDataTable(sql)
                    If dt.Rows.Count > 0 Then
                        Dim dr As DataRow = dt.Rows(0)
                        f.AppNo = dr("app_no")
                        f.MsRequisitionTypeID = dr("ms_requisition_type_id")
                        f.MsPatentTypeID = dr("ms_patent_type_id")
                        f.RequisitionTypeName = dr("requisition_type_name")
                        f.PatentTypeName = dr("patent_type_name")
                        f.RegisterDate = Convert.ToDateTime(dr("register_time")).ToString("dd/MM/yyyy HH:mm:ss", New Globalization.CultureInfo("th-TH"))
                        f.ServiceName = dr("item_name_th")
                        f.TbRegisterQueueID = dr("tb_register_queue_id")
                        frmMain.BtnLogout.Enabled = True

                        Dim CurrStatus As String = dr("status")

                        If f.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                            Dim ret As Boolean = False
                            Dim trans As New LinqDB.ConnectDB.TransactionDB
                            Select Case CurrStatus
                                Case 8
                                    ret = UpdateQueueStatus(8, dr("tb_register_queue_id"), 0, dr("ms_service_id"), "", trans.Trans)
                                Case Else
                                    ret = UpdateQueueStatus(1, dr("tb_register_queue_id"), 0, dr("ms_service_id"), "", trans.Trans)
                            End Select

                            If ret = True Then
                                trans.CommitTransaction()
                            Else
                                trans.RollbackTransaction()
                            End If
                        ElseIf f.DialogResult = Windows.Forms.DialogResult.OK Then
                            'Misscell
                        ElseIf f.DialogResult = Windows.Forms.DialogResult.Yes Then
                            Dim ff As New frmEndByService

                            ff.AppNo = dr("app_no").ToString
                            ff.RegisterQueueID = dr("tb_register_queue_id")
                            ff.RequisitionTypeID = dr("ms_requisition_type_id")
                            ff.PatentTypeID = dr("ms_patent_type_id")
                            frmMain.Hide()
                            ff.ShowDialog()
                            frmMain.Show()
                        End If
                        showcustomerwait()
                        FindQueueService()
                    Else
                        MessageBox.Show("The information has already been updated by the other user.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        showcustomerwait()
                        FindQueueService()
                    End If
                    dt.Dispose()
                Else
                    RollbackTransaction()

                    MessageBox.Show("The information has already been updated by the other user.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    showcustomerwait()
                    FindQueueService()
                End If
            Else
                showcustomerwait()
            End If
        Catch ex As Exception : End Try

        frmMain.timerCheckForce.Enabled = True
        frmMain.BtnLogout.Enabled = True
        btnCall.Enabled = True
        GridWait.Enabled = True
    End Sub

    Sub avgServiceTime()
        'Dim sql As String = ""
        'Dim dt As New DataTable
        'sql = "select TB_ITEM.id,item_name ," & vbNewLine
        'sql += " case when avg(DATEDIFF(SS,start_time,end_time)) IS null " & vbNewLine
        'sql += " then '-' " & vbNewLine
        'sql += " else case when avg(DATEDIFF(SS,start_time,end_time))/ 60 > 9 " & vbNewLine
        'sql += "    then CONVERT(varchar(10),avg(DATEDIFF(SS,start_time,end_time)) / 60) " & vbNewLine
        'sql += "    else right(('0' + CONVERT(varchar(10),avg(DATEDIFF(SS,start_time,end_time)) / 60)),2) " & vbNewLine
        'sql += "    end + ':' + right(('0' + convert(varchar(10),avg(DATEDIFF(SS,start_time,end_time)) % 60)),2) " & vbNewLine
        'sql += " end as servicetime ," & vbNewLine
        'sql += " count(1) as serve " & vbNewLine
        'sql += " from TB_COUNTER_QUEUE " & vbNewLine
        'sql += " left join TB_ITEM on TB_COUNTER_QUEUE.item_id = TB_ITEM.id " & vbNewLine
        'sql += " where DATEDIFF(D,GETDATE(),service_date)=0 and status = 3 " & vbNewLine
        'sql += " and user_id = " & myUser.user_id & vbNewLine
        'sql += " group by TB_ITEM.id,item_name " & vbNewLine
        'sql += " order by item_name" & vbNewLine
        'dt = getDataTable(sql)
        'GridItem.Columns("item_id").Visible = False
        'GridItem.AutoGenerateColumns = False
        'GridItem.DataSource = dt
    End Sub

    Private Sub timerRefreshWait_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerRefreshWait.Tick
        showcustomerwait()
    End Sub

    Private Sub cbSkill_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbSkill.SelectionChangeCommitted
        myUser.skill_id = cbSkill.SelectedValue
        Dim sql As String = "update ms_user"
        sql += " set ms_skill_id='" & myUser.skill_id & "'"
        sql += " where id='" & myUser.user_id & "'"
        If executeSQL(sql, False) = True Then
            showcustomerwait()

            frmMain.timerCheckForce.Enabled = False
            frmMain.timerForce.Enabled = False
            frmMain.timerCheckForce.Enabled = True
        End If
    End Sub
End Class