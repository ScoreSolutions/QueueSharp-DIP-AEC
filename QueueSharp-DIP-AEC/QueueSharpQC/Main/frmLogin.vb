Imports System.Data
Imports System.Data.SqlClient
Imports QueueSharpQC.Org.Mentalis.Files
Imports System.Threading

Public Class frmLogin

    Dim Sql As String = ""
    Public ExitApp As Boolean = False
    Public Serve As Boolean = False     'เช็คว่า User สามารถใช้งานเมนูนี้ได้หรือไม่ ถ้าใช้ได้ตอน Login ก็ให้เปิดเมนูนี้เลย
    Public Register As Boolean = False  'เช็คว่า User สามารถใช้งานเมนูนี้ได้หรือไม่ ถ้าใช้ได้ตอน Login ก็ให้เปิดเมนูนี้เลย
    Public CheckCam As Boolean = False

    Private Sub TextUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtPassword.Focus()
        End If
    End Sub

    Private Sub TextPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If cbCounter.Enabled = True Then
                cbCounter.Focus()
            Else
                btnLogin.Focus()
            End If

        End If
    End Sub

    Private Sub cbCounter_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbCounter.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLogin.PerformClick()
        End If
    End Sub

    Sub save_ini()
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("userlogin", txtUserName.Text)
        ini.Write("counter", cbCounter.SelectedValue.ToString)
        ini = Nothing
    End Sub

    Sub read_ini()
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        If CStr(ini.ReadString("userlogin")) <> "" Then
            txtUserName.Text = CStr(ini.ReadString("userlogin"))
            txtPassword.Focus()
            txtPassword.SelectAll()
            cbCounter.SelectedValue = ini.ReadInteger("counter")
        Else
            txtUserName.Text = ""
            txtPassword.Text = ""
            txtUserName.Focus()
        End If
        ini = Nothing
    End Sub

    Private Function Validation() As Boolean
        Try
            If txtUserName.Text.Trim = "" Then
                MessageBox.Show("Please enter Username", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUserName.Focus()
                Return False
            End If

            If txtPassword.Text.Trim = "" Then
                MessageBox.Show("Please enter Password", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return False
            End If

            If CDbl(cbCounter.SelectedValue) = 0 Then
                MessageBox.Show("Please select Counter", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cbCounter.Focus()
                Return False
            End If

            

            Return True
        Catch ex As Exception
            Return False
        End Try
        
    End Function

    Private Function ChkCurrentLogin() As Boolean
        'ตรวจสอบว่าผู้ใช้กำลังอยู่ในระบบที่เครื่องเดียวกันอยู่แล้วหรือไม่
        Dim ret As Boolean = False
        Dim sql As String = "select id, ip_address  from tb_user where username='" & txtUserName.Text & "' "
        Dim dt As DataTable = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("ip_address").ToString = GetIPAddress() Then
                'ถ้า User เดียวกัน มา Login ที่เครื่องเดียวกันแล้วก็ ให้ตรวจสอบว่าเปิดโปรแกรม Q# ค้างอยู่หรือไม่
                Dim pCount As Int16 = 0
                Dim pList() As Process = Process.GetProcessesByName("QueueSharp.vshost")
                If pList.Length = 0 Then
                    pList = Process.GetProcessesByName("QueueSharp")
                    If pList.Length > 0 Then
                        pCount += pList.Length
                    End If
                Else
                    pCount += pList.Length
                    pList = Process.GetProcessesByName("QueueSharp")
                    pCount += pList.Length
                End If

                If pCount > 1 Then
                    ret = True
                End If
            End If
        Else
            'ถ้าผู้ใช้ยังไม่ได้ Login ตรวจสอบว่า Counter ที่เลือกถูกใช้งานไปแล้วหรือไม่
            Dim sql2 As String = "select id, ip_address from tb_user where counter_id = '" & cbCounter.SelectedValue & "' "
            Dim dt2 As DataTable = getDataTable(sql2)
            If dt2.Rows.Count > 0 Then
                If dt2.Rows(0)("ip_address") = GetIPAddress() Then
                    ret = False
                Else
                    ret = True
                End If
            End If
        End If

        Return ret
    End Function

    Public Sub Login(ByVal UserName As String, ByVal Pwd As String, lnq As LinqDB.TABLE.MsUserLinqDB)
        myUser.username = txtUserName.Text
        myUser.user_id = lnq.ID
        myUser.fulllname = lnq.FNAME & " " & lnq.LNAME
        myUser.counter_id = cbCounter.SelectedValue
        myUser.counter_name = cbCounter.Text
        myUser.ip_address = GetIPAddress()

        Sql = "select ms_skill_id "
        Sql += " from MS_COUNTER_SKILL "
        Sql += " where ms_counter_id = " & myUser.counter_id
        Dim dt As New DataTable
        dt = getDataTable(Sql)
        If dt.Rows.Count > 0 Then
            myUser.skill_id = dt.Rows(0).Item("ms_skill_id").ToString
        Else
            myUser.skill_id = 0
        End If

        UpdateCounterStatus(cbCounter.SelectedValue, True)
        LastService.LastQueue = ""
        LastService.LastRoom = ""
        LastService.LastService = ""
        save_ini()
        ExitApp = False
        frmMain.Text = Replace(frmMain.Text, "[-]", "[" & myUser.fulllname & "]")
        'FindMenuList(myUser.user_id)
        If txtUserName.Enabled = True Then
            LogLogin(1)
        End If

        Me.DialogResult = Windows.Forms.DialogResult.Yes
        'Me.Close()
        'ClearUnitDisplay(False)
    End Sub

    Private Sub butlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Me.Cursor = Cursors.WaitCursor
        btnLogin.Enabled = False
        'Dim lic As New ScoreLicense.ScoreLicense("QSHARP")
        'lic.SerializedLicenseKey

        If Validation() = True Then

            'Encrypt
            Dim PW As String = Engine.Common.FunctionEng.EnCripPwd(txtPassword.Text.Trim)
            '*****************************

            Dim lnq As New LinqDB.TABLE.MsUserLinqDB
            lnq.ChkDataByUSERNAME(txtUserName.Text.Trim, Nothing)
            If lnq.ID > 0 Then

                If lnq.MS_COUNTER_ID <> 0 And lnq.MS_SKILL_ID <> 0 And lnq.IP_ADDRESS <> "" Then
                    Me.Cursor = Cursors.Default
                    btnLogin.Enabled = True
                    MessageBox.Show("This user has already login.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If lnq.PASSWORD <> PW Then
                    Me.Cursor = Cursors.Default
                    btnLogin.Enabled = True
                    MessageBox.Show("Invalid password", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                Else
                    Dim sql = ""
                    Dim dt_tmp As New DataTable
                    sql = "select * from MS_GROUPUSER where active_status = 1 and id = " & lnq.MS_GROUP_ID
                    dt_tmp = getDataTable(sql)
                    If dt_tmp.Rows.Count = 0 Then
                        MessageBox.Show("Group User can't active", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Default
                        btnLogin.Enabled = True
                        dt_tmp.Dispose()
                        Exit Sub
                    End If

                    dt_tmp = New DataTable
                    sql = "select id from ms_user where username='" & FixDB(txtUserName.Text.Trim) & "' and counter_id <> 0 "
                    dt_tmp = getDataTable(sql)
                    If dt_tmp.Rows.Count > 0 Then
                        MessageBox.Show("This User already exists! Please re-enter the new one", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Default
                        btnLogin.Enabled = True
                        dt_tmp.Dispose()
                        Exit Sub
                    End If
                    dt_tmp.Dispose()

                    Dim trans As New LinqDB.ConnectDB.TransactionDB
                    sql = "update MS_USER set ms_counter_id = " & cbCounter.SelectedValue & " "
                    sql += " where id = '" & lnq.ID & "' and (ms_counter_id=0 or ms_counter_id is null)"
                    If executeSQL(sql, trans.Trans, True) = True Then
                        Dim cDt = New DataTable
                        sql = "select ms_counter_id from ms_user "
                        sql += " where ms_counter_id = " & cbCounter.SelectedValue.ToString
                        sql += " and id<>'" & lnq.ID & "'"
                        cDt = getDataTable(sql, trans.Trans)
                        If cDt.Rows.Count > 0 Then
                            trans.RollbackTransaction()
                            cDt.Dispose()
                            MessageBox.Show("Counter has been updated by the other user", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.Cursor = Cursors.Default
                            btnLogin.Enabled = True
                            ShowCounter()
                            Exit Sub
                        Else
                            trans.CommitTransaction()

                            Login(txtUserName.Text, txtPassword.Text, lnq)
                            frmMain.TimerCheckStatus.Enabled = True
                            frmMain.timerCheckForce.Enabled = True
                        End If
                    Else
                        trans.RollbackTransaction()
                        MessageBox.Show("Counter has been updated by the other user", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.Cursor = Cursors.Default
                        btnLogin.Enabled = True
                        ShowCounter()
                        Exit Sub
                    End If
                End If
            End If
            lnq = Nothing
        End If
        Me.Cursor = Cursors.Default
        btnLogin.Enabled = True
    End Sub
#Region "QM Process"
    Private Sub ClearQMLog()
        Dim QMLogMonth As String = Engine.Common.ShopConnectDBENG.GetShopConfig("QMLogMonth", "QueueSharp", "frmLogin_ClearQMLog")

        If QMLogMonth.Trim <> "" Then
            Dim MMonth As String = DateAdd(DateInterval.Month, (0 - Convert.ToInt16(QMLogMonth)), DateTime.Today).ToString("yyyyMM", New Globalization.CultureInfo("en-US"))
            Dim DDay As String = DateAdd(DateInterval.Month, (0 - Convert.ToInt16(QMLogMonth)), DateTime.Today).ToString("yyyyMMdd", New Globalization.CultureInfo("en-US"))

            'Clear Event Log
            If IO.Directory.Exists(Application.StartupPath & "\QM\EventLog") = True Then
                Dim EventLogFld() As String = IO.Directory.GetDirectories(Application.StartupPath & "\QM\EventLog")
                For Each Dir As String In EventLogFld
                    Dim dInfo As New IO.DirectoryInfo(Dir)
                    If dInfo.Name < MMonth Then
                        IO.Directory.Delete(Dir, True)
                        dInfo = Nothing
                        Continue For
                    End If

                    For Each f As String In IO.Directory.GetFiles(Dir)
                        Dim fInfo As New IO.FileInfo(f)
                        If fInfo.LastWriteTime.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) < DDay Then
                            IO.File.Delete(f)
                        End If
                        fInfo = Nothing
                    Next
                Next
            End If

            'Clear Error Log
            If IO.Directory.Exists(Application.StartupPath & "\QM\ErrorLog") = True Then
                Dim ErrorLogFld() As String = IO.Directory.GetDirectories(Application.StartupPath & "\QM\ErrorLog")
                For Each Dir As String In ErrorLogFld
                    Dim dInfo As New IO.DirectoryInfo(Dir)
                    If dInfo.Name < MMonth Then
                        IO.Directory.Delete(Dir, True)
                        dInfo = Nothing
                        Continue For
                    End If

                    For Each f As String In IO.Directory.GetFiles(Dir)
                        Dim fInfo As New IO.FileInfo(f)
                        If fInfo.LastWriteTime.ToString("yyyyMMdd", New Globalization.CultureInfo("en-US")) < DDay Then
                            IO.File.Delete(f)
                        End If
                        fInfo = Nothing
                    Next
                Next
            End If
        End If
    End Sub
#End Region    'QM Process
    Private Sub frmLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ExitApp = True Then
            System.Environment.Exit(0)
        End If
        If Me.DialogResult <> Windows.Forms.DialogResult.Yes Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Dim cDt As New DataTable
    Private Sub frmLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        frmMain.TimerCheckStatus.Enabled = False
        ShowCounter()
        read_ini()
    End Sub

    Sub ShowCounter()
        Dim sql As String = ""
        Dim dt As New DataTable
        sql = "select id,counter_name "
        sql += " from MS_COUNTER "
        sql += " where active_status = 1 "
        sql += " and id not in (select distinct isnull(ms_counter_id,0) from ms_user) "
        sql += " and counter_qc='1'"
        sql += " order by counter_code"
        dt = getDataTable(sql)

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.NewRow
            dr("id") = 0
            dr("counter_name") = ""
            dt.Rows.InsertAt(dr, 0)

            If dt.Rows.Count <> cDt.Rows.Count Then
                With cbCounter
                    .DataSource = dt
                    .DisplayMember = "counter_name"
                    .ValueMember = "id"
                End With

                Dim ini As New IniReader(INIFileName)
                ini.Section = "SETTING"
                cbCounter.SelectedValue = ini.ReadInteger("counter")
                ini = Nothing

                cDt = dt.Copy
            End If
        End If
    End Sub

    'Sub FindMenuList(ByVal UserID As Integer)
    '    Dim sql As String = ""
    '    Dim dt As New DataTable
    '    sql = "select z.ms_menu_id,MS_MENU.menu_name   " & vbNewLine
    '    sql += " from MS_GROUPUSER x " & vbNewLine
    '    sql += " left join MS_USER y on x.id = y.ms_group_id " & vbNewLine
    '    sql += " left join MS_GROUPUSER_MENU z on x.id = z.ms_groupuser_id " & vbNewLine
    '    sql += " left join MS_MENU on z.ms_menu_id = MS_MENU.id " & vbNewLine
    '    sql += " where y.id = " & UserID
    '    dt = getDataTable(sql)
    '    If dt.Rows.Count > 0 Then
    '        DisableFormMainButton()
    '        For i As Int32 = 0 To dt.Rows.Count - 1
    '            Select Case CInt(dt.Rows(i).Item("ms_menu_id").ToString)
    '                Case 1
    '                    'frmMain.btnSegment.Enabled = True
    '                    'Register = True
    '                Case 2
    '                    frmMain.BtnServe.Enabled = True
    '                    Serve = True
    '                Case 3
    '                    frmMain.BtnHistory.Enabled = True
    '                Case 4
    '                    frmMain.BtnAwaiting.Enabled = True
    '                Case 5
    '                    frmMain.BtnCounterStatus.Enabled = True
    '                Case 6
    '                    frmMain.BtnCusInfo.Enabled = True
    '                Case 7
    '                    'frmMain.BtnCusType.Enabled = True
    '                Case 8
    '                    frmMain.BtnCounter.Enabled = True
    '                Case 9
    '                    frmMain.BtnItem.Enabled = True
    '                Case 10
    '                    frmMain.BtnGroupUser.Enabled = True
    '                Case 11
    '                    frmMain.BtnUser.Enabled = True
    '                Case 12
    '                    frmMain.btnLogoutReason.Enabled = True
    '                Case 13
    '                    'frmMain.btnHoldReason.Enabled = True
    '                Case 14
    '                    frmMain.btnSkill.Enabled = True
    '                Case 15
    '                    frmMain.btnServicePriority.Enabled = True
    '                Case 16
    '                    'frmMain.btnSetting.Enabled = True
    '                    'Case 17
    '                    '    frmMain.btnAppointment.Enabled = True
    '                Case 18
    '                    frmMain.btnForce.Enabled = True
    '                Case 19
    '                    'frmMain.BtnAppointmentCustomer.Enabled = True
    '                    'Case 20
    '                    '    frmMain.btnMDSetting.Enabled = True
    '                Case 21
    '                    frmMain.btnQSetting.Enabled = True
    '            End Select
    '        Next
    '    End If

    'End Sub

    'Sub DisableFormMainButton()
    '    'frmMain.btnSegment.Enabled = False
    '    frmMain.BtnServe.Enabled = False
    '    frmMain.BtnHistory.Enabled = False
    '    frmMain.BtnAwaiting.Enabled = False
    '    frmMain.BtnCounterStatus.Enabled = False
    '    frmMain.BtnCusInfo.Enabled = False
    '    'frmMain.BtnCusType.Enabled = False
    '    frmMain.BtnCounter.Enabled = False
    '    frmMain.BtnItem.Enabled = False
    '    frmMain.BtnGroupUser.Enabled = False
    '    frmMain.BtnUser.Enabled = False
    '    frmMain.btnLogoutReason.Enabled = False
    '    'frmMain.btnHoldReason.Enabled = False
    '    frmMain.btnServicePriority.Enabled = False
    '    frmMain.btnSkill.Enabled = False
    '    'frmMain.btnSetting.Enabled = False
    '    frmMain.btnForce.Enabled = False
    '    'frmMain.BtnAppointmentCustomer.Enabled = False
    '    'frmMain.btnMDSetting.Enabled = False
    '    frmMain.btnQSetting.Enabled = False
    'End Sub

    Dim LastRefreshTime As DateTime = DateTime.Now
    Dim AutoRefreshSec As String = Engine.Common.ShopConnectDBENG.GetShopConfig("LoginCounterRefreshSec", "QueueSharp", "frmLogin_CheckCounter.Tick")
    Private Sub CheckCounter_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCounter.Tick
        Try
            If AutoRefreshSec.Trim = "" Then
                AutoRefreshSec = "1"
            End If
            If DateAdd(DateInterval.Second, Convert.ToInt16(AutoRefreshSec), LastRefreshTime) < DateTime.Now Then
                ShowCounter()
                LastRefreshTime = DateTime.Now
                AutoRefreshSec = Engine.Common.ShopConnectDBENG.GetShopConfig("LoginCounterRefreshSec", "QueueSharp", "frmLogin_CheckCounter.Tick")
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub cbCounter_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCounter.SelectionChangeCommitted
        If cbCounter.SelectedValue <> 0 Then
            Dim ini As New IniReader(INIFileName)
            ini.Section = "SETTING"
            ini.Write("counter", cbCounter.SelectedValue.ToString)
            ini = Nothing
        End If
    End Sub
End Class