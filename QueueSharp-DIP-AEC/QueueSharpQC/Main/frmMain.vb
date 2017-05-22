Imports QueueSharpQC.Org.Mentalis.Files
Imports Engine.Common.ShopConnectDBENG
Imports System.IO
'Imports AlexPilotti.FTPS.Client
'Imports AlexPilotti.FTPS.Common
Imports System.Net
Imports System.Security.Cryptography.X509Certificates

Public Class frmMain
    'Public CheckCam As Boolean = False
    Sub CloseAllChildForm()

        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me Then
                My.Application.OpenForms.Item(i).Close()
            End If
        Next i
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            UpdateCounterStatus(myUser.counter_id, False)
            Dim sql As String = ""
            If myUser.user_id <> "" Then
                sql = "update ms_user set ms_counter_id = 0,ms_service_id = 0, ip_address=null where id =" & myUser.user_id
                executeSQL(sql)
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Function CheckServerIP() As Boolean
        'ตรวจสอบว่า IP ของเครือง MainServer กับ DisplayServer จะต้องไม่ใช่ IP เดียวกัน
        Dim ret As Boolean = False
        Dim ini As New IniReader(INIFileName)
        ini.Section = "Setting"
        If ini.ReadString("Server") = ini.ReadString("Server1") Then
            ret = True
        End If
        ini = Nothing
        Return ret
    End Function

    Private Sub CheckFileList()
        If File.Exists(Application.StartupPath & "\QueueSharp.ini") = False Then
            showFormError("ไม่พบไฟล์ " & Application.StartupPath & "\QM\QueueSharp.ini", True)
        End If

        If File.Exists(Application.StartupPath & "\QSharp.ico") = False Then
            showFormError("ไม่พบไฟล์ " & Application.StartupPath & "\QSharp.ico", True)
        End If
    End Sub

    Private Sub frmMain_RightToLeftChanged(sender As Object, e As EventArgs) Handles Me.RightToLeftChanged

    End Sub

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        CheckFileList()

        mRibbon.RibbonControl.ColorScheme = mRibbon.ColorScheme.Blue
        'UpdateVersion_Company()

        ' ''************** Lincese ************
        'Dim ini As New IniReader(INIFileName)
        'ini.Section = "SETTING"
        'Dim score As New ScoreLicense.ScoreLicense(ApplicationName)
        'If Not score.IsValidLicense(ini.ReadString("License")) Then
        '    Me.Refresh()
        '    Dim f As New frmLicense
        '    If f.ShowDialog() = Windows.Forms.DialogResult.No Then
        '        Application.Exit()
        '    End If
        'End If
        ''***********************************

        

        'สำหรับ Bypass SSL กรณีเรียก WebService ผ่าน https://
        System.Net.ServicePointManager.ServerCertificateValidationCallback = _
          Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, _
          chain As System.Security.Cryptography.X509Certificates.X509Chain, _
          sslerror As System.Net.Security.SslPolicyErrors) True

        'แสดงหน้าจอ Login
        Dim ff As New frmLogin
        ff.ExitApp = True
        If ff.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            TimerChkLogon.Enabled = True

            Dim frm As New frmServiceQueue
            frm.MdiParent = Me
            frm.Show()


            ''เช็คว่ามีคิวที่กำลัง Hold อยู่หรือไม่
            'Dim sql As String = "select rh.id, rh.tb_register_queue_id, rq.app_no,rq.ms_requisition_type_id,rq.ms_patent_type_id "
            'sql += " from TB_REGISTER_QUEUE_HOLD rh"
            'sql += " inner join TB_REGISTER_QUEUE rq on rq.id=rh.tb_register_queue_id "
            'sql += " where rh.hold_status='Y'"
            'sql += " and rh.ms_counter_id='" & myUser.counter_id & "'"
            'sql += " and rh.ms_user_id='" & myUser.user_id & "'"
            'Dim dt As DataTable = getDataTable(sql)
            'If dt.Rows.Count > 0 Then
            '    Dim dr As DataRow = dt.Rows(0)
            '    SetUnholdQueue(dr("tb_register_queue_id"), dr("id"))


            '    Dim ffS As New frmEndByService
            '    ffS.AppNo = dr("app_no")
            '    ffS.RegisterQueueID = dr("tb_register_queue_id")
            '    ffS.RequisitionTypeID = dr("ms_requisition_type_id")
            '    ffS.PatentTypeID = dr("ms_patent_type_id")
            '    Me.Hide()
            '    ffS.ShowDialog()
            '    Dim frm As New frmServiceQueue
            '    frm.MdiParent = Me
            '    frm.Show()

            '    Me.timerCheckForce.Enabled = True
            'Else
            '    Dim frm As New frmServiceQueue
            '    frm.MdiParent = Me
            '    frm.Show()
            'End If
            'dt.Dispose()
        End If
        ff.Close()
    End Sub

    

    'Private Sub RbAboutBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbout.Click
    '    frmAboutBox.ShowDialog()
    'End Sub

    'Private Sub tButLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogout.Click


    'End Sub

    'Private Sub RbDbCfg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmConfigDatabase
    '    f.ShowDialog()
    'End Sub

    'Private Sub RibbonButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrinterConfig.Click
    '    Dim f As New frmConfigPrinter
    '    f.ShowDialog()
    'End Sub

    'Private Sub BtnCusType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmCustomerType
    '    f.ShowDialog()
    'End Sub

    'Private Sub BtnItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItem.Click
    '    CloseAllChildForm()
    '    Dim f As New frmService
    '    f.ShowDialog()
    'End Sub

    'Private Sub btnServicePriority_Click(sender As Object, e As EventArgs) Handles btnServicePriority.Click
    '    CloseAllChildForm()
    '    Dim f As New frmServicePriority
    '    f.ShowDialog
    'End Sub

    'Private Sub BtnRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCounter.Click
    '    CloseAllChildForm()
    '    Dim f As New frmScanPageQty
    '    f.ShowDialog()
    'End Sub

    'Private Sub BtnPriority_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPriorityItem.Click
    '    CloseAllChildForm()
    '    Dim f As New frmPriority
    '    f.ShowDialog()
    'End Sub



    'Private Sub btnItemType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmServiceType
    '    f.ShowDialog()
    'End Sub

    Private Sub BtnServe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CloseAllChildForm()
        Dim f As New frmServiceQueue
        f.MdiParent = Me
        f.Show()
    End Sub

    'Private Sub btnPriorityCustomerType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPriorityCustomerType.Click
    '    CloseAllChildForm()
    '    Dim f As New frmItemOrder
    '    f.ShowDialog()
    'End Sub

    Private Sub btnNotifier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotifier.Click
        If LastService.LastQueue <> "" Then
            If LastService.LastRoom <> "" Then
                showNotify("หมายเลขคิว : " & LastService.LastQueue, "บริการต่อไป : " & LastService.LastService & vbCrLf & LastService.LastRoom)
            Else
                showNotify("หมายเลขคิว : " & LastService.LastQueue, "จบการบริการทั้งหมดของระบบ")
            End If
        End If
    End Sub

    'Private Sub BtnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHistory.Click
    '    CloseAllChildForm()
    '    Dim f As New frmDailyHistory
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub BtnAwaiting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAwaiting.Click
    '    CloseAllChildForm()
    '    Dim f As New frmAwaitingCustomer
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub BtnRoomStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCounterStatus.Click
    '    CloseAllChildForm()
    '    Dim f As New frmRoomStatus
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub BtnCusInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCusInfo.Click
    '    CloseAllChildForm()
    '    Dim f As New frmCustomerInfo
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub BtnGroupUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGroupUser.Click
    '    CloseAllChildForm()
    '    Dim f As New frmGroupUser
    '    f.ShowDialog()
    'End Sub

    'Private Sub BtnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUser.Click
    '    CloseAllChildForm()
    '    Dim f As New frmUser
    '    f.ShowDialog()
    'End Sub

    'Private Sub btnCustomerTypeService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmWorkFlow
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub btnCusEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCusEdit.Click
    '    CloseAllChildForm()
    '    Dim f As New frmEditServiceCustomer
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub btnUnitDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitDisplay.Click
    '    Dim f As New frmConfigUnitDisplay
    '    f.ShowDialog()
    'End Sub

    Private Sub TimerBeep_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.Beep(2000, 500)
    End Sub

    Private Sub btnCusAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim f As New frmAddServiceCustomer
        f.ShowDialog()
    End Sub

    'Private Sub btnSchedulText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSchedulText.Click
    '    CloseAllChildForm()
    '    Dim f As New frmSchedulText
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub btnEmergency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmergency.Click
    '    CloseAllChildForm()
    '    Dim f As New frmEmergencyText
    '    f.ShowDialog()
    'End Sub

    'Private Sub btnRemote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemote.Click
    '    CloseAllChildForm()
    '    Dim f As New frmChannelSelect
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    Private Sub btnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If System.IO.File.Exists(Windows.Forms.Application.StartupPath & "\Report.exe") Then
            Dim proc As New Process()
            proc.StartInfo.FileName = Windows.Forms.Application.StartupPath & "\Report.exe"
            proc.StartInfo.Arguments = ""
            proc.Start()
        Else
            MessageBox.Show("ไม่พบข้อมูลรายงาน !!!" & vbCrLf & Windows.Forms.Application.StartupPath & "\Report.exe", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'Private Sub btnLogoutReason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogoutReason.Click
    '    CloseAllChildForm()
    '    Dim f As New frmLogoutReason
    '    f.ShowDialog()
    'End Sub

    'Private Sub btnHoldReason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmHoldReason
    '    f.ShowDialog()
    'End Sub

    'Private Sub btnSkill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkill.Click
    '    CloseAllChildForm()
    '    Dim f As New frmSkill
    '    f.ShowDialog()
    'End Sub

    'Private Sub btnSegment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmSegment
    '    f.ShowDialog()
    'End Sub

    Private Sub TimerChkLogon_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerChkLogon.Tick
        'Try
        '    Dim sql As String = ""
        '    sql = "update TB_USER set check_update = GETDATE() where id = " & myUser.user_id
        '    executeSQL(sql, False)
        'Catch ex As Exception : End Try
    End Sub

    'Private Sub btnSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmSetting
    '    f.ShowDialog()
    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
        Rbbn.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        Else
            Me.WindowState = FormWindowState.Maximized
        End If
        Rbbn.Focus()
    End Sub

    Private Sub TimerCheckHoldRoom_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCheckHoldRoom.Tick
        'TimerCheckHoldRoom.Enabled = False
        'Dim f As New frmLogin
        'f.ExitApp = True
        'f.cbCounter.Enabled = False
        'f.txtUserName.Enabled = False
        'f.CheckCounter.Enabled = False
        'If f.ShowDialog() = Windows.Forms.DialogResult.Yes Then
        '    TimerChkLogon.Enabled = True
        '    Dim ff As New frmServiceQueue
        '    ff.MdiParent = Me
        '    ff.Show()
        'End If
        'f.Close()
    End Sub

    'Private Sub btnAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmAppointment
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    Private Sub TimerCheckConnection_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCheckConnection.Tick
        'Engine.Common.ShopConnectDBENG.CheckCurrentActiveDB(INIFileName, Conn, "QueueSharp", "frmMain_TimerCheckConnection_Tick")
    End Sub

    'Private Sub btnForce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForce.Click
    '    CloseAllChildForm()
    '    Dim f As New frmForce
    '    f.ShowDialog()
    'End Sub

    Private Sub TimerCheckStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCheckStatus.Tick
        Try
            If myUser.user_id > 0 Then
                Dim sql As String = ""
                Dim dt As New DataTable
                sql = "select ms_counter_id from ms_user where id = " & myUser.user_id & " and ms_counter_id = 0"
                dt = getDataTable(sql)
                If dt.Rows.Count > 0 Then
                    CloseAllChildForm()
                    Dim f As New frmLogin
                    f.ExitApp = True
                    If f.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                        Dim ff As New frmServiceQueue
                        ff.MdiParent = Me
                        ff.Show()
                    End If
                    f.Close()
                End If
            End If
        Catch ex As Exception : End Try
    End Sub

    'Private Sub BtnAppointmentCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmAppointmentCustomer
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    Private Sub timerCheckForce_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerCheckForce.Tick
        timerCheckForce.Enabled = False
        Try
            Dim sql As String = ""
            Dim dt As New DataTable
            sql = "select wait from TB_FORCE_SCHEDULE where DATEDIFF(D,force_date,GETDATE()) = 0 and GETDATE() between start_time and dateadd(minute,slot,end_time)"
            dt = getDataTable(sql)
            If dt.Rows.Count > 0 Then
                If timerForce.Enabled = False Then
                    timerForce.Interval = dt.Rows(0).Item("wait") * 1000
                    timerForce.Enabled = True
                End If
            Else
                timerForce.Enabled = False
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
        timerCheckForce.Enabled = True
    End Sub

    Private Sub timerForce_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerForce.Tick
        timerForce.Enabled = False
        Dim sql As String = ""
        Dim dt As New DataTable
        If myUser.counter_id > 0 And myUser.user_id > 0 Then
            'ห้องที่เป็น back office หรือ counter manager
            sql = "select * from ms_counter where id = " & myUser.counter_id & " and active_status = 1 and counter_manager = 1"
            dt = getDataTable(sql)
            If dt.Rows.Count = 0 Then
                'ถ้าไม่ใช่ห้องที่เป็น counter manager
                sql = "select isnull(ms_counter_id,0) as ms_counter_id from ms_user where id = " & myUser.user_id
                dt = getDataTable(sql)
                If dt.Rows.Count > 0 Then
                    If CInt(dt.Rows(0).Item("ms_counter_id")) > 0 Then
                        sql = "select * from vw_counter_queue "
                        sql += " where status in (2,4) "
                        sql += " and ms_user_id = " & myUser.user_id
                        sql += " and ms_counter_id = " & myUser.counter_id
                        dt = getDataTable(sql)
                        If dt.Rows.Count = 0 Then
                            sql = "exec SP_ShowCustomerWait " & myUser.counter_id & ",0"


                            dt = getDataTable(sql)
                            If dt.Rows.Count > 0 Then
                                CloseAllChildForm()
                                AutoForceQueue = True
                                Dim f As New frmServiceQueue
                                f.MdiParent = Me
                                f.Show()
                            End If
                        End If
                    End If
                End If
            End If
        End If
        timerForce.Enabled = True
    End Sub

    'Private Sub btnMDSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CloseAllChildForm()
    '    Dim f As New frmMDSetting
    '    f.ShowDialog()
    'End Sub

    'Private Sub RibbonButton80_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQSetting.Click
    '    CloseAllChildForm()
    '    Dim f As New frmQSetting
    '    f.ShowDialog()
    'End Sub

    'Dim QMScheduleTransferBackup As String = ""
    'Dim LastQmScheculeRefreshTime As DateTime = DateTime.Now
    'Private Sub TimerCheckBackupQM_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCheckBackupQM.Tick
    '    TimerCheckBackupQM.Enabled = False
    '    QMScheduleTransferBackup = Engine.Common.ShopConnectDBENG.GetShopConfig(INIFileName, "QMScheduleTransferBackup", "QueueSharp", "frmScheduleQM_Load")
    '    If QMScheduleTransferBackup.Trim = "" Then
    '        QMScheduleTransferBackup = "15"
    '    End If
    '    If DateAdd(DateInterval.Minute, Convert.ToDouble(QMScheduleTransferBackup), LastQmScheculeRefreshTime) < DateTime.Now Then
    '        QM.StartQMSchedule()

    '        QMScheduleTransferBackup = Engine.Common.ShopConnectDBENG.GetShopConfig(INIFileName, "QMScheduleTransferBackup", "QueueSharp", "QMSchedule.frmScheduleQM.TimerStartTransferFileQM")
    '        LastQmScheculeRefreshTime = DateTime.Now
    '    End If


    '    TimerCheckBackupQM.Enabled = True
    'End Sub

 
    'Private Sub BtnCheckOut_Click(sender As Object, e As EventArgs) Handles BtnCheckOut.Click
    '    CloseAllChildForm()
    '    Dim f As New frmCheckOut
    '    f.ShowDialog()
    'End Sub


End Class
