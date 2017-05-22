Imports QueueSharp.Org.Mentalis.Files

Public Class frmEndByService
    Dim mm As Int32 = 0
    Dim ss As Int32 = 0
    Dim TimeStamp As Int32 = 0
    Dim ServiceTime As Int32 = 0
    Dim clickX As Integer = 0
    Dim clickY As Integer = 0
    Public RegisterQueueID As Long = 0
    Public AppNo As String
    Public RequisitionTypeID As String
    Public PatentTypeID As String
    Dim dt_Button As New DataTable
    Dim tmp0 = frmDialogCustomerInfo.Width
    Dim dt_customerProfile As New DataTable
    Dim ServiceEnd As String = ""
    Dim isShown As Boolean = False
    Dim isSmall As Boolean = False
    Dim AgentAddService As Boolean = False
    Dim HeightNow As Int32 = 0
    Dim Filefrist As Boolean = True
    Dim ClickEndTime As DateTime
    Dim ChkDiffTimeCloseQM As Boolean = False
    Dim IsHoldQueue As Boolean = False
    Dim TbRegisterQueueHoldID As Long = 0

    Dim RejectInfo As String = ""


    Private Sub frmEndByService_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        StartTime = New DateTime(1, 1, 1)
        frmMain.Show()
    End Sub

    Private Sub frmEndByService_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        Me.Left = ini.ReadInteger("E_LEFT")
        Me.Top = ini.ReadInteger("E_TOP")
        lblQueue.Text = AppNo
        ClickEndTime = FindDateNow()
    End Sub

    

    'Private Function DeleteQmTransferLog(ByVal Qid As String) As Boolean
    '    Dim sql As String = "delete from TB_QM_TRANSFER_LOG"
    '    sql += " where tb_counter_queue_id='" & Qid & "' and datediff(d,getdate(),service_date)=0"
    '    Return executeSQL(sql)
    'End Function

    

    Sub ShowButton()
        Dim sql As String = ""
        Dim btn As New Button
        Dim lbl = New Label

        'หา Service ทั้งหมดของคิวนี้
        sql = "  select a.item_name_th, a.app_no,a.ms_requisition_type_id,a.requisition_type_name,"
        sql += " a.ms_patent_type_id, a.patent_type_name"
        sql += " ,a.start_time,a.[status],a.priority_value, a.ms_service_id,"
        sql += " '' color,a.tb_register_queue_id, a.tb_counter_queue_id,a.item_order,"
        sql += " isnull(rh.id,0) tb_register_queue_hole_id , rh.hold_time, rh.unhold_time, DATEDIFF(s,hold_time,unhold_time) hold_sec,"
        sql += " qc.id qc_id, qc.reject_comment"
        sql += " from vw_counter_queue a "
        sql += " left join TB_REGISTER_QUEUE_HOLD rh on rh.tb_register_queue_id = a.tb_register_queue_id and rh.ms_counter_id='" & myUser.counter_id & "' and rh.ms_user_id='" & myUser.user_id & "' "
        sql += " left join TB_COUNTER_QUEUE_QC qc on a.tb_counter_queue_id=qc.tb_counter_queue_id_newjob"
        sql += "  where a.[status] = 2"
        sql += " and a.tb_register_queue_id= '" & RegisterQueueID & "'"
        sql += " order by a.priority_value,a.register_time,a.item_order  "

        dt_Button = getDataTable(sql)
        If dt_Button.Rows.Count > 0 Then
            'หา Service ที่ Counter นี้ สามารถให้บริการได้
            sql = " select distinct ss.ms_service_id, s.item_name_th"
            sql += " from MS_SKILL_SERVICE ss"
            sql += " inner join MS_SERVICE s on s.id=ss.ms_service_id"
            sql += " inner join MS_COUNTER_SKILL ck on ss.ms_skill_id=ck.ms_skill_id"
            sql += " where ck.ms_counter_id='" & myUser.counter_id & "'"

            sql += " union all "

            sql += "  select distinct sr.ms_service_id_reject ms_service_id, s.item_name_th"
            sql += " from MS_SKILL_SERVICE ss"
            sql += " inner join MS_SERVICE_REJECT sr on sr.ms_service_id=ss.ms_service_id"
            sql += " inner join MS_SERVICE s on s.id=sr.ms_service_id_reject"
            sql += " inner join MS_COUNTER_SKILL ck on ss.ms_skill_id=ck.ms_skill_id"
            sql += " where ck.ms_counter_id='" & myUser.counter_id & "'"
            Dim tmpCS As DataTable = getDataTable(sql)

            Dim i As Int32 = 0
            For i = 0 To dt_Button.Rows.Count - 1
                Dim dr As DataRow = dt_Button.Rows(i)
                Dim Active As Boolean = True
                tmpCS.DefaultView.RowFilter = "ms_service_id='" & dr("ms_service_id") & "'"
                If tmpCS.DefaultView.Count > 0 Then
                    'Active = False

                    'แสดงปุ่มเฉพาะ Service ที่ให้บริการได้
                    btn = New Button
                    AddBtn(btn, "txt_" & dr("ms_service_id").ToString, dr("item_name_th").ToString, dr("tb_counter_queue_id"), Active)
                    btn = New Button
                    AddBtn(btn, dt_Button.Rows(i).Item("ms_service_id").ToString, "End", dr("tb_counter_queue_id"), Active)
                    Me.Height = Me.Height + 46

                    'ถุ้าเป็นการแก้ไขจากคิวที่ Reject ให้แสดงรายละเอียดการแก้ไขด้วย
                    If Convert.IsDBNull(dr("qc_id")) = False Then
                        RejectInfo += dr("item_name_th") & ":" & vbNewLine
                        RejectInfo += dr("reject_comment") & vbNewLine & vbNewLine
                    End If
                End If
                tmpCS.DefaultView.RowFilter = ""
            Next

            If myUser.skill_id > 0 Then
                btn = New Button
                If AgentAddService = True Then
                    AddBtn(btn, "Add", "Add Services", 0, False)
                Else
                    AddBtn(btn, "Add", "Add Services", 0)
                End If
                Me.Height = Me.Height + 46
                ''**********************************
            End If

            If Convert.IsDBNull(dt_Button.Rows(0)("unhold_time")) = True Then
                IsHoldQueue = True
                btn = New Button
                AddBtn(btn, "Hold", "Hold", 0)
                Me.Height = Me.Height + 46

                StartTime = Convert.ToDateTime(dt_Button.Rows(0)("start_time"))
            Else
                'ถ้าเป็นการเข้าหน้าจอมาหลังจากการ Hold
                Dim HTSec As Long = DateDiff(DateInterval.Second, Convert.ToDateTime(dt_Button.Rows(0)("start_time")), Convert.ToDateTime(dt_Button.Rows(0)("hold_time")))
                StartTime = DateAdd(DateInterval.Second, 0 - HTSec, Convert.ToDateTime(dt_Button.Rows(0)("unhold_time")))
                TbRegisterQueueHoldID = Convert.ToInt64(dt_Button.Rows(0)("tb_register_queue_hole_id"))
            End If
        End If
    End Sub

    Sub AddLabel(ByVal lbl As Label, ByVal id As Int32, ByVal name As String)
        Dim Font As Font = New Font("Angsana", 14, FontStyle.Bold, GraphicsUnit.Pixel)
        With lbl
            .Width = 190
            .Height = 40
            .Name = id
            .Text = name
            .Font = Font
            .AutoSize = False
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.LightSeaGreen
            .ForeColor = Color.White
        End With
        FLP.Controls.Add(lbl)
    End Sub

    Sub AddBtn(ByVal btn As Button, ByVal btn_id As String, ByVal Text As String, tbCounterQueueID As String, Optional ByVal Active As Boolean = True)
        Dim Font As Font = New Font("Angsana", 14, FontStyle.Bold, GraphicsUnit.Pixel)
        With btn
            .Width = 321
            .Height = 40
            .Name = btn_id
            .Text = Text
            .TextAlign = ContentAlignment.MiddleLeft
            .Tag = tbCounterQueueID
            .Font = Font
            .AutoSize = False
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            If StringFromLeft(btn_id, 3) = "txt" Then
                If Active Then
                    .BackColor = Color.LightSeaGreen
                Else
                    .BackColor = Color.LightGray
                End If
                .ForeColor = Color.White
                .FlatAppearance.BorderColor = Color.White
                .Width = 240
                '.Enabled = False
                ttServiceToolTip.SetToolTip(btn, Text)   'ถ้า Set Enabled=False แล้ว Tool Tip จะไม่แสดง
            Else
                Select Case btn_id.Trim
                    Case "Transfer"
                        .BackColor = Color.Orange
                        .ForeColor = Color.White
                        .FlatAppearance.BorderColor = Color.White
                        .TextAlign = ContentAlignment.MiddleCenter
                        .Cursor = Cursors.Hand
                    Case "Cancel"
                        .BackColor = Color.Red
                        .ForeColor = Color.White
                        .FlatAppearance.BorderColor = Color.White
                        .TextAlign = ContentAlignment.MiddleCenter
                        .Cursor = Cursors.Hand
                    Case "Hold"
                        .BackColor = Color.Red
                        .ForeColor = Color.White
                        .FlatAppearance.BorderColor = Color.White
                        .TextAlign = ContentAlignment.MiddleCenter
                        .Cursor = Cursors.Hand
                    Case "Add"
                        If Active Then
                            .BackColor = Color.RoyalBlue
                            .ForeColor = Color.White
                            .FlatAppearance.BorderColor = Color.White
                            .Cursor = Cursors.Hand
                        Else
                            .BackColor = Color.LightGray
                            .ForeColor = Color.Black
                            .FlatAppearance.BorderColor = Color.White
                            .Enabled = False
                        End If
                        .TextAlign = ContentAlignment.MiddleCenter
                    Case Else
                        'ปุ่ม End
                        If Active Then
                            .BackColor = Color.ForestGreen
                            .Cursor = Cursors.Hand
                        Else
                            .BackColor = Color.LightGray
                            .Enabled = False
                            .Text = "None"
                        End If
                        .ForeColor = Color.White
                        .FlatAppearance.BorderColor = Color.White
                        .Width = 74
                        .TextAlign = ContentAlignment.MiddleCenter
                End Select
            End If
        End With
        FLP.Controls.Add(btn)
        AddHandler btn.Click, AddressOf CheckEndService
    End Sub

    Private Sub CheckEndService(ByVal Sender As Object, ByVal e As EventArgs)
        
        Dim btn As Button = Sender
        Select Case btn.Name
            Case "Transfer" 'Tranfer
                'Dim num As Int32 = 0
                'For i = 0 To dt_Button.Rows.Count - 1
                '    For j As Int32 = 0 To FLP.Controls.Count - 1
                '        If FLP.Controls(j).Name = dt_Button.Rows(i).Item("item_id").ToString Then
                '            If FLP.Controls(j).Text <> "End" And FLP.Controls(j).Text <> "None" Then
                '                num = num + 1
                '            End If
                '        End If
                '    Next
                'Next

                'If num = 0 Then
                '    showNotify("Attention", "Cannot Transfer Queue")
                '    Exit Sub
                'End If

                'If ServiceEnd.Trim <> "" Then
                '    Dim sql As String = ""
                '    sql = "update tb_counter_queue "
                '    sql += " set combo_item_end = '" & ServiceEnd & "' "
                '    sql += " where datediff(d,getdate(),service_date)=0 and item_id in (" & ServiceEnd & ")"
                '    executeSQL(sql)
                'End If
                ''InsertLog(lblQueue.Text, lblCustomerID.Text, myUser.user_id, 0, myUser.counter_id, 1, "Transfer", Nothing, vDateNow)

                ''ถ้า Transfer
                'ExitForm(True)
                'Threading.Thread.Sleep(3000)
                ''QM.WriteTextQueueID("")
                ''QM.CloseQM()
            Case "Cancel" 'Cancel Service
                'Dim f As New frmServiceCancel
                'f.QueueNo = lblQueue.Text
                'f.CustomerID = lblCustomerID.Text
                'f.StatusCustomer = 2
                'f.Flag = "frmEndByService"
                'f.CountEnd = 2

                'Dim num As Int32 = 0
                'For i = 0 To dt_Button.Rows.Count - 1
                '    For j As Int32 = 0 To FLP.Controls.Count - 1
                '        If FLP.Controls(j).Name = dt_Button.Rows(i).Item("item_id").ToString Then
                '            If FLP.Controls(j).Text <> "End" And FLP.Controls(j).Text <> "None" Then
                '                num = num + 1
                '            End If
                '        End If
                '    Next
                'Next
                'If num = 0 Then
                '    f.FristEnd = True
                'End If

                'If f.ShowDialog = Windows.Forms.DialogResult.OK Then
                '    'Hold
                '    ExitForm(False)
                'ElseIf f.DialogResult = Windows.Forms.DialogResult.Yes Then
                '    'Cancel
                '    Dim sql As String = ""
                '    Dim dt As New DataTable
                '    'sql = "select id,item_id,status from TB_COUNTER_QUEUE where datediff(d,getdate(),service_date)=0 and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "' and status = 5 order by status"
                '    dt = getDataTable(sql)
                '    For i As Int32 = 0 To dt.Rows.Count - 1
                '        Try
                '            FLP.Controls("txt_" & dt.Rows(i).Item("item_id").ToString).BackColor = Color.Gray
                '            FLP.Controls(dt.Rows(i).Item("item_id").ToString).BackColor = Color.Gray
                '            FLP.Controls(dt.Rows(i).Item("item_id").ToString).ForeColor = Color.White
                '            FLP.Controls(dt.Rows(i).Item("item_id").ToString).Enabled = False
                '            FLP.Controls(dt.Rows(i).Item("item_id").ToString).Text = "Cancel"

                '            DeleteQmTransferLog(dt.Rows(i).Item("id").ToString)
                '        Catch ex As Exception : End Try
                '    Next

                '    ' ''Update assign_time ของ Service ที่เหลือ
                '    'Dim EndTime As String = FindDateNow().ToString("yyyy-MM-dd HH:mm:ss.fff", New Globalization.CultureInfo("en-US"))
                '    'sql = " update tb_counter_queue "
                '    'sql += " set assign_time = '" & EndTime & "',call_time = '" & EndTime & "',start_time = '" & EndTime & "' "
                '    'sql += " where datediff(d,getdate(),service_date)=0 "
                '    'sql += " and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "' and status = 2"
                '    'executeSQL(sql)

                '    If CheckCloseFrom() Then
                '        ''ถ้า Cancel ทุก Service
                '        ExitForm(True)
                '    End If
                'End If
            Case "Add"
                AddService(btn)
            Case "Hold"
                HoldQueue(btn)
            Case Else
                EndService(btn)
        End Select
    End Sub

    Private Sub AddService(btn As Button)
        Dim f As New frmAddServiceCustomer
        f.TbRegisterQueueID = RegisterQueueID
        'f.Mobile = lblCustomerID.Text
        If f.ShowDialog = Windows.Forms.DialogResult.Yes Then
            AgentAddService = True
            If myUser.skill_id > 0 Then
                FLP.Controls.RemoveByKey("Transfer")
                FLP.Controls.RemoveByKey("Add")
            End If
            FLP.Controls.RemoveByKey("Cancel")

            Dim New_btn As Button
            Dim sql As String = ""
            Dim dt_add As New DataTable
            sql = "select top 1 cq.ms_service_id,cq.item_name_th,isnull(SCH.ms_service_id,0) as active "
            sql += " from vw_counter_queue cq "
            sql += " left join ("
            sql += "        select ss.ms_service_id, s.item_name_th"
            sql += "        from MS_SKILL_SERVICE ss"
            sql += "        inner join MS_SERVICE s on s.id=ss.ms_service_id"
            sql += "        inner join MS_COUNTER_SKILL ck on ss.ms_skill_id=ck.ms_skill_id"
            sql += "        where ck.ms_counter_id='" & myUser.counter_id & "'"
            sql += " ) as SCH on cq.ms_service_id = SCH.ms_service_id "
            sql += " where cq.tb_register_queue_id = '" & RegisterQueueID & "' "
            sql += " order by cq.tb_counter_queue_id desc"

            dt_add = getDataTable(sql)
            If dt_add.Rows.Count > 0 Then
                New_btn = New Button
                Dim Active As Boolean = False
                If dt_add.Rows(0).Item("active") > 0 Then
                    Active = True
                End If
                AddBtn(New_btn, "txt_" & dt_add.Rows(0).Item("ms_service_id").ToString, dt_add.Rows(0).Item("item_name_th").ToString, btn.Tag, Active)

                New_btn = New Button
                AddBtn(New_btn, dt_add.Rows(0).Item("ms_service_id").ToString, "End", btn.Tag, Active)
                Me.Height = Me.Height + 46
            End If

            If myUser.skill_id > 0 Then
                'New_btn = New Button
                'AddBtn(New_btn, "Transfer", "Transfer Queue", 0)
                ''******* POC รอบ2 ไม่ต้องแสดง ********
                New_btn = New Button
                AddBtn(New_btn, "Add", "Add Services", 0, False)
                ''**********************************
                If dt_Button.Rows.Count = 1 Then
                    Me.Height = Me.Height + 46
                End If
            End If

            If IsHoldQueue = False Then
                New_btn = New Button
                AddBtn(New_btn, "Hold", "Hold", 0)
                Me.Height = Me.Height + 46
            End If

            CheckService()
        End If
    End Sub

    Private Sub HoldQueue(btn As Button)
        'เมื่อกด Hold
        'Insert ข้อมูลลง Table TB_REGISTER_QUEUE_HOLD และ hold_status='Y'
        'Update ข้อมูลใน Table TB_COUNTER_QUEUE.tb_register_queue_hold_id
        'Logout เลย

        'Logout after Hold
        frmMain.timerCheckForce.Enabled = False
        frmMain.timerForce.Enabled = False
        frmMain.TimerCheckStatus.Enabled = False
        Dim f As New frmReason
        f.Reason = 1
        If f.ShowDialog = Windows.Forms.DialogResult.Yes Then
            Dim lnq As New LinqDB.TABLE.TbRegisterQueueHoldLinqDB
            lnq.TB_REGISTER_QUEUE_ID = RegisterQueueID
            lnq.HOLD_TIME = FindDateNow()
            lnq.MS_COUNTER_ID = myUser.counter_id
            lnq.MS_USER_ID = myUser.user_id
            lnq.HOLD_STATUS = "Y"

            Dim trans As New LinqDB.ConnectDB.TransactionDB
            If lnq.InsertData(myUser.username, trans.Trans) Then
                Dim sql As String = "update tb_counter_queue "
                sql += " set status='6'"
                sql += " , tb_register_queue_hold_id = '" & lnq.ID & "'"
                sql += " where tb_register_queue_id='" & RegisterQueueID & "'"
                sql += " and status='2'"

                If executeSQL(sql, trans.Trans, True) = True Then
                    trans.CommitTransaction()

                    Dim Mlnq As New LinqDB.TABLE.MsUserLinqDB
                    Mlnq.GetDataByPK(myUser.user_id, Nothing)
                    If Mlnq.ID > 0 Then
                        Mlnq.MS_COUNTER_ID = 0
                        Mlnq.MS_SKILL_ID = 0
                        Mlnq.IP_ADDRESS = ""

                        trans = New LinqDB.ConnectDB.TransactionDB
                        If Mlnq.UpdateByPK(myUser.username, trans.Trans) = True Then
                            trans.CommitTransaction()

                            Me.Close()
                            Me.Hide()
                            frmMain.CloseAllChildForm()
                            UpdateCounterStatus(myUser.counter_id, False)
                            Me.Text = Me.Text.Replace(myUser.fulllname, "-")
                            Dim frmL As New frmLogin
                            frmL.ExitApp = True
                            If frmL.ShowDialog() = Windows.Forms.DialogResult.Yes Then
                                SetUnholdQueue(RegisterQueueID, lnq.ID)

                                Dim ff As New frmEndByService
                                ff.AppNo = AppNo
                                ff.RegisterQueueID = RegisterQueueID
                                ff.RequisitionTypeID = RequisitionTypeID
                                ff.PatentTypeID = PatentTypeID
                                frmMain.Hide()
                                ff.ShowDialog()
                                frmMain.Show()

                                Dim frm As New frmServiceQueue
                                frm.MdiParent = frmMain
                                frm.Show()

                                frmMain.timerCheckForce.Enabled = True
                                frmMain.BtnLogout.Enabled = True
                            End If
                            frmL.Close()
                        Else
                            trans.RollbackTransaction()
                        End If
                        Mlnq = Nothing
                    End If
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Else
            frmMain.timerCheckForce.Enabled = True
        End If
    End Sub

    Private Sub EndService(btn As Button)
        'End Service
        If btn.BackColor = Color.ForestGreen Then
            Dim sql As String = ""
            sql += "select s.is_scan, s.is_key, cq.id tb_counter_queue_id "
            sql += " from ms_service s "
            sql += " inner join tb_counter_queue cq on cq.ms_service_id=s.id"
            sql += " where s.id='" & btn.Name & "'"
            sql += " and cq.tb_register_queue_id='" & RegisterQueueID & "'"
            Dim sDt As DataTable = getDataTable(sql)
            If sDt.Rows.Count > 0 Then
                If sDt.Rows(0)("is_scan") = "Y" Then
                    Me.Hide()
                    Dim frm As New frmScanPageQty
                    frm.DocPageType = frmScanPageQty.DocumentPageType.SCAN
                    frm.TbCounterQueueID = Convert.ToInt64(sDt.Rows(0)("tb_counter_queue_id"))
                    frm.ShowDialog()
                    Me.Show()
                End If

                If sDt.Rows(0)("is_key") = "Y" Then
                    Me.Hide()
                    Dim frm As New frmScanPageQty
                    frm.DocPageType = frmScanPageQty.DocumentPageType.KEY
                    frm.TbCounterQueueID = Convert.ToInt64(sDt.Rows(0)("tb_counter_queue_id"))
                    frm.ShowDialog()
                    Me.Show()
                End If
            End If
            sDt.Dispose()

            Dim dDateNow As DateTime = FindDateNow()
            Dim vDateNow As String = FixDateTime(dDateNow)

            'Disable End Button
            For i As Integer = 0 To FLP.Controls.Count - 1
                If FLP.Controls(i).Text = "End" Then
                    FLP.Controls(i).Enabled = False
                End If
            Next

            If TimeStamp = 0 Then
                If Filefrist = True Then
                    btn.Text = lblTime.Text
                    TimeStamp = (mm * 60) + ss
                    Filefrist = False
                Else
                    TimeStamp = (((mm * 60) + ss) - ServiceTime)
                    btn.Text = (TimeStamp \ 60).ToString.PadLeft(2, "0") & ":" & (TimeStamp Mod 60).ToString.PadLeft(2, "0")
                End If
            Else
                'หาเวลา Start Time
                TimeStamp = (((mm * 60) + ss) - ServiceTime)
                btn.Text = (TimeStamp \ 60).ToString.PadLeft(2, "0") & ":" & (TimeStamp Mod 60).ToString.PadLeft(2, "0")
            End If
            ServiceTime = ServiceTime + TimeStamp

            Dim trans As New LinqDB.ConnectDB.TransactionDB
            sql = "update TB_COUNTER_QUEUE "
            sql += " set status = 3,end_time = " & vDateNow & ","
            sql += " [ms_user_id] = " & myUser.user_id
            sql += " ,tb_register_queue_hold_id = '" & TbRegisterQueueHoldID & "'"
            sql += " where  tb_register_queue_id = '" & RegisterQueueID & "' "
            sql += " and ms_counter_id='" & myUser.counter_id & "' and status = 2 and ms_service_id = " & btn.Name
            executeSQL(sql, trans.Trans, True)
            TbRegisterQueueHoldID = 0

            'ข้อมูล btn.Tag = TbCounterQueueID
            InsertLog(btn.Tag, myUser.user_id, myUser.counter_id, btn.Name, 3, "", trans.Trans, dDateNow)
            'sql = "declare @EndTime as datetime;select @EndTime = (select MAX(end_time) from TB_COUNTER_QUEUE where DATEDIFF(d,GETDATE(),service_date)=0 and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "')" & vbCrLf
            sql = " update tb_counter_queue "
            sql += " set assign_time = " & vDateNow & ",call_time = " & vDateNow & ",start_time = " & vDateNow & " "
            sql += " where tb_register_queue_id = '" & RegisterQueueID & "'"
            sql += " and ms_counter_id = '" & myUser.counter_id & "' and status = 2"
            executeSQL(sql, trans.Trans, True)
            trans.CommitTransaction()

            btn.BackColor = Color.Gray
            btn.Enabled = False
            FLP.Controls("txt_" & btn.Name).BackColor = Color.Gray

            sql = "select id, datediff(s,start_time,getdate()) diff_time "
            sql += " from tb_counter_queue "
            sql += " where tb_register_queue_id='" & RegisterQueueID & "' and ms_service_id = " & btn.Name
            Dim dt As New DataTable
            dt = getDataTable(sql)
            If dt.Rows.Count > 0 Then
                ClickEndTime = dDateNow
                '#############################
                If ServiceEnd = "" Then
                    ServiceEnd = btn.Name
                Else
                    ServiceEnd = ServiceEnd & "," & btn.Name
                End If
            End If
            dt.Dispose()

            If CheckCloseFrom() Then
                ExitForm(True, vDateNow)
            Else
                For i As Integer = 0 To FLP.Controls.Count - 1
                    If FLP.Controls(i).Text = "End" Then
                        FLP.Controls(i).Enabled = True
                    End If
                Next
            End If
        End If
    End Sub

    Function FindServiceTime(ByVal Parameter As String)
        Dim ret(1) As String
        For i As Int32 = 0 To FLP.Controls.Count - 1
            If CInt(FLP.Controls(i).Name) > 0 And FLP.Controls(i).Text <> "End" Then
                Select Case Parameter
                    Case "Min"
                        If ret(0) = "" Then
                            ret(0) = FLP.Controls(i).Text
                            ret(1) = FLP.Controls(i).Name
                        Else
                            If CDate(ret(0)) < FLP.Controls(i).Text Then
                                ret(0) = FLP.Controls(i).Text
                                ret(1) = FLP.Controls(i).Name
                            End If
                        End If
                    Case "Max"
                        If ret(0) = "" Then
                            ret(0) = FLP.Controls(i).Text
                            ret(1) = FLP.Controls(i).Name
                        Else
                            If CDate(ret(0)) > FLP.Controls(i).Text Then
                                ret(0) = FLP.Controls(i).Text
                                ret(1) = FLP.Controls(i).Name
                            End If
                        End If
                End Select
            End If
        Next
        Return ret
    End Function

    Private Sub frmFloat_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, Gp.MouseMove, FLP.MouseMove, PanelCus.MouseMove, lblTime.MouseMove, lblTimeS.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Me.Left = Me.Left + (e.X - clickX)
            Me.Top = Me.Top + (e.Y - clickY)
        End If
    End Sub

    Private Sub frmFloat_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, Gp.MouseUp, FLP.MouseUp, PanelCus.MouseUp, lblTime.MouseUp, lblTimeS.MouseUp
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        ini.Write("E_LEFT", Me.Left)
        ini.Write("E_TOP", Me.Top)
    End Sub

    Private Sub frmFloat_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, Gp.MouseDown, FLP.MouseDown, PanelCus.MouseDown, lblTime.MouseDown, lblTimeS.MouseDown
        clickX = e.X
        clickY = e.Y
    End Sub

    Private Sub Down_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.MouseHover, Gp.MouseHover, FLP.MouseHover, PanelCus.MouseHover, lblTime.MouseHover, lblTimeS.MouseHover
        Dim ini As New IniReader(INIFileName)
        ini.Section = "SETTING"
        Me.Left = ini.ReadInteger("E_LEFT")
        Me.Top = ini.ReadInteger("E_TOP")
    End Sub

    Private Sub TimerCountServed_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCountServed.Tick
        SetViewTime()
    End Sub

    Sub ExitForm(ByVal ShowMessage As Boolean, vDateNow As String)
        Dim sql As String = ""
        Dim dt As New DataTable
        Me.Close()

        If CreateTransaction("frmEndByService_ExitForm") = True Then
            Dim ret As Boolean = False

            'Update Status ของ Service ที่ไม่ได้ทำกับ User คนนี้
            sql = "update TB_COUNTER_QUEUE "
            sql += " set status = 1,assign_time = " & vDateNow & ",start_time = NULL,end_time = NULL,"
            sql += " [ms_user_id] = 0, ms_counter_id = 0 "
            sql += " where tb_register_queue_id = '" & RegisterQueueID & "' and status = 2"
            ret = executeSQL(sql, shTrans, True)

            If ret = True Then
                ClearMainDisplay(myUser.counter_id, shTrans)
                CommitTransaction()
            Else
                RollbackTransaction()
            End If
            AgentAddService = False
        End If
    End Sub

    Function CheckCloseFrom() As Boolean
        Dim num As Int32 = 0
        For i = 0 To dt_Button.Rows.Count - 1
            For j As Int32 = 0 To FLP.Controls.Count - 1
                If FLP.Controls(j).Text = "End" Then
                    num = num + 1
                End If
            Next
        Next

        If num = 0 Then
            Return True
        End If
        Return False
    End Function

#Region "EndAllService"
    'Dim sql As String = ""
    'Dim dt As New DataTable
    'Dim dt_temp As New DataTable
    'Dim dt_ChoseItem As New DataTable
    'Dim dr As DataRow
    'With dt_ChoseItem
    '    .Columns.Add("item_id", GetType(System.String))
    '    .Columns.Add("avg_time", GetType(System.String))
    'End With

    ''หาค่า KPI ของแต่ละ Service
    'sql = "select tb1.user_id,tb1.item_id,item_name,isnull(avg_time,item_time * 60) as avg_time  from (select TB_USER.id as user_id,TB_ITEM.id as item_id,item_name,item_time from TB_USER cross join TB_ITEM where TB_USER.id = " & myUser.user_id & " and TB_ITEM.active_status = 1) as TB1 left join TB_AVG_USER_SERVICETIME as TB2 on TB1.user_id = tb2.user_id and tb1.item_id = tb2.item_id"
    'dt = getDataTable(sql)
    'If dt.Rows.Count > 0 Then
    '    Dim TotalAvgTime As Int32 = 0
    '    Dim TotalTime As Int32 = 0 'เวลาที่ใช้ในการให้บริการ
    '    TotalTime = (mm * 60) + ss
    '    For i = 0 To dt_Button.Rows.Count - 1
    '        For j As Int32 = 0 To FLP.Controls.Count - 1
    '            If FLP.Controls(j).Name.ToString = dt_Button.Rows(i).Item("item_id").ToString Then
    '                If FLP.Controls(j).Enabled = True Then
    '                    dt.DefaultView.RowFilter = "item_id = " & FLP.Controls(j).Name
    '                    dt_temp = dt.DefaultView.ToTable
    '                    dr = dt_ChoseItem.NewRow
    '                    dr("item_id") = dt_temp.Rows(0).Item("item_id").ToString
    '                    dr("avg_time") = dt_temp.Rows(0).Item("avg_time").ToString
    '                    dt_ChoseItem.Rows.Add(dr)
    '                    TotalAvgTime = TotalAvgTime + dt_temp.Rows(0).Item("avg_time")
    '                End If
    '            End If
    '        Next
    '    Next

    '    Dim AvgTime As Int32 = 0
    '    For x As Int32 = 0 To dt_ChoseItem.Rows.Count - 1
    '        AvgTime = AvgTime + (dt_ChoseItem.Rows(x).Item("avg_time") / TotalAvgTime) * TotalTime
    '        If x = 0 Then
    '            sql = "update TB_COUNTER_QUEUE set status = 3,end_time = DATEADD(ss," & AvgTime & ",start_time),[user_id] = " & myUser.user_id & " where datediff(D,GETDATE(),service_date)=0 and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "' and item_id = " & dt_ChoseItem.Rows(x).Item("item_id") & " and status = 2"
    '        Else
    '            sql = "declare @StartTime as datetime;select @StartTime = (select MAX(end_time) from TB_COUNTER_QUEUE where DATEDIFF(d,GETDATE(),service_date)=0 and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "' and status = 3);" & vbCrLf
    '            sql &= "update TB_COUNTER_QUEUE set status = 3,start_time = @StartTime,end_time = DATEADD(ss," & AvgTime & ",start_time),[user_id] = " & myUser.user_id & " where datediff(D,GETDATE(),service_date)=0 and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "' and item_id = " & dt_ChoseItem.Rows(x).Item("item_id") & " and status = 2"
    '        End If
    '        executeSQL(sql)
    '        InsertLog(FixDB(QueueNo), FixDB(CustomerID), myUser.user_id, dt_ChoseItem.Rows(x).Item("item_id"), myUser.counter_id, 3)
    '    Next
    'End If
#End Region

    Private Sub frmEndByService_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Height = 135
        FLP.Controls.Clear()
        ShowButton()

        If RejectInfo <> "" Then
            isShown = False
            btnRejectInfo_Click(Nothing, Nothing)
        End If

        SetViewTime()
        TimerCountServed.Enabled = True
    End Sub

    Public StartTime As New DateTime(1, 1, 1)
    Private Sub SetViewTime()

        If StartTime.Year <> 1 Then
            Dim CurrTime As Integer = DateDiff(DateInterval.Second, StartTime, FindDateNow())
            Dim UseTime As String = GetTimeFormat(CurrTime)
            mm = Split(UseTime, ":")(0)
            ss = Split(UseTime, ":")(1)
        End If
        lblTime.Text = CStr(mm).PadLeft(2, "0") & ":" & CStr(ss).PadLeft(2, "0")
        lblTimeS.Text = CStr(mm).PadLeft(2, "0") & ":" & CStr(ss).PadLeft(2, "0")
    End Sub

    Private Function GetTimeFormat(ByVal TimeSec As Long) As String
        'แปลงเวลาจากวินาทีไปเป็น mm:ss
        Dim tMin As Integer = 0
        Dim tSec As Integer = 0

        tMin = Math.Floor(TimeSec / 60)
        tSec = TimeSec Mod 60
        Return tMin.ToString.PadLeft(2, "0") & ":" & tSec.ToString.PadLeft(2, "0")
    End Function

    Private Sub frmEndByService_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'frmDialogCustomerInfo.Top = Me.Top + 5
        'frmDialogCustomerInfo.Left = Me.Left - frmDialogCustomerInfo.Width + 2

        frmDialogRejectInfo.Top = Me.Top + 5
        frmDialogRejectInfo.Left = Me.Left + Me.Width + 2
    End Sub

    Private Sub btnRejectInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRejectInfo.Click
        If isShown = False Then
            frmDialogRejectInfo.Visible = True
            frmDialogRejectInfo.Show()
            frmDialogRejectInfo.Width = 545
            frmDialogRejectInfo.Left = Me.Left + Me.Width + 2
            frmDialogRejectInfo.Top = Me.Top + 5
            Me.Activate()

            'Dim Tmp As Integer = 285
            'frmDialogRejectInfo.Width = 1
            'frmDialogRejectInfo.Owner = Me
            'frmDialogRejectInfo.Top = Me.Top
            'frmDialogRejectInfo.Left = Me.Left = frmDialogRejectInfo.Width + 2
            'For i As Integer = 1 To Tmp Step 5
            '    frmDialogRejectInfo.Left -= 5
            '    frmDialogRejectInfo.Width += 5
            '    Application.DoEvents()
            'Next
            'frmDialogRejectInfo.Width = Tmp
            frmDialogRejectInfo.txtRejectInfo.Text = RejectInfo
            isShown = True
        Else
            Me.TopMost = True
            'Dim tmp As Integer = frmDialogRejectInfo.Width
            'For i As Integer = tmp To 0 Step -1
            '    frmDialogRejectInfo.Width = i
            '    frmDialogRejectInfo.Left = (Me.Left + Me.Width + 2) - frmDialogRejectInfo.Width
            '    Application.DoEvents()
            'Next
            Me.Activate()
            frmDialogRejectInfo.Visible = False
            isShown = False
        End If
    End Sub

    Private Sub btnTop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTop.Click
        If isSmall = False Then
            HeightNow = Me.Height
            lblTimeS.Visible = True
            isSmall = True
            Me.Height = 72
        Else
            lblTimeS.Visible = False
            Me.Height = HeightNow
            isSmall = False
        End If
    End Sub

    Sub CheckService()
        Dim sql As String = ""

        'sql = "select item_id,item_name,1 as active  from TB_COUNTER_QUEUE left join TB_ITEM on TB_COUNTER_QUEUE.item_id = TB_ITEM.id where DATEDIFF(D,GETDATE(),service_date)=0 and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "' and status in (2,3,5) and item_id = " & myUser.service_id & "" & vbCrLf
        'sql &= "union all" & vbCrLf
        'sql &= "select item_id,item_name,2 as active  from TB_COUNTER_QUEUE left join TB_ITEM on TB_COUNTER_QUEUE.item_id = TB_ITEM.id where DATEDIFF(D,GETDATE(),service_date)=0 and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "' and status in (2,3,5) and item_id in (select item_id from TB_USER_SERVICE_SCHEDULE where DATEDIFF(D,GETDATE(),service_date)=0 and active_status = 1 and user_id = " & myUser.user_id & ") and item_id <> " & myUser.service_id & " " & vbCrLf
        'sql &= "union all" & vbCrLf
        'sql &= "select item_id,item_name,3 as active  from TB_COUNTER_QUEUE left join TB_ITEM on TB_COUNTER_QUEUE.item_id = TB_ITEM.id where DATEDIFF(D,GETDATE(),service_date)=0 and queue_no = '" & FixDB(QueueNo) & "' and customer_id = '" & FixDB(CustomerID) & "' and status in (2,3,5) and item_id not in (select item_id from TB_USER_SERVICE_SCHEDULE where DATEDIFF(D,GETDATE(),service_date)=0 and active_status = 1 and user_id = " & myUser.user_id & ")" & vbCrLf
        'sql &= "order by active asc"

        dt_Button = getDataTable(sql)
    End Sub

End Class
