Imports QueueSharpQC.Org.Mentalis.Files

Public Class frmEndByService
    Dim mm As Int32 = 0
    Dim ss As Int32 = 0
    Dim TimeStamp As Int32 = 0
    Dim ServiceTime As Int32 = 0
    Dim clickX As Integer = 0
    Dim clickY As Integer = 0
    Public CounterQueueID As Long = 0
    Public vQcID As Long = 0
    Public AppNo As String
    Public RequisitionTypeID As String
    Public PatentTypeID As String
    Dim dt_Button As New DataTable
    'Dim tmp0 = frmDialogCustomerInfo.Width
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
    'Dim TbRegisterQueueHoldID As Long = 0


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

        'หา Service ที่ต้องการทำ QC
        sql = "  select 'ตรวจสอบ' + a.item_name_th item_name_th, a.app_no,a.ms_requisition_type_id,a.requisition_type_name,"
        sql += " a.ms_patent_type_id, a.patent_type_name"
        sql += " ,qc.qc_start_time,qc.[status],a.priority_value, a.ms_service_id,"
        sql += " '' color,a.tb_register_queue_id, a.tb_counter_queue_id,a.item_order "
        sql += " from vw_counter_queue a "
        sql += " inner join TB_COUNTER_QUEUE_QC qc on a.tb_counter_queue_id=qc.tb_counter_queue_id_qc"
        sql += " where qc.[status] = 2"
        sql += " and qc.id = '" & vQcID & "'"
        sql += " order by a.priority_value,a.register_time,a.item_order  "

        dt_Button = getDataTable(sql)
        If dt_Button.Rows.Count > 0 Then
            
            Dim dr As DataRow = dt_Button.Rows(0)
            Dim Active As Boolean = True

            btn = New Button
            AddBtn(btn, "txt_" & dr("ms_service_id").ToString, dr("item_name_th").ToString, dr("tb_counter_queue_id"), Active)
            btn = New Button
            AddBtn(btn, dr("ms_service_id").ToString, "End", dr("tb_counter_queue_id"), Active)
            Me.Height = Me.Height + 46

            StartTime = Convert.ToDateTime(dt_Button.Rows(0)("qc_start_time"))
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
        EndQueue(btn)
    End Sub

    Private Sub EndQueue(btn As Button)
        'End Queue
        If btn.BackColor = Color.ForestGreen Then
            Dim sql As String = ""
            sql += "select cq.id tb_counter_queue_id, cq.tb_register_queue_id "
            sql += " from tb_counter_queue cq "
            sql += " inner join tb_counter_queue_qc qc on cq.id=qc.tb_counter_queue_id_qc"
            sql += " where  qc.id='" & vQcID & "'"
            Dim sDt As DataTable = getDataTable(Sql)
            If sDt.Rows.Count > 0 Then
                Me.Hide()
                Dim frm As New frmQCResult
                frm.TbQcID = vQcID
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
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

                    btn.BackColor = Color.Gray
                    btn.Enabled = False
                    FLP.Controls("txt_" & btn.Name).BackColor = Color.Gray

                    ExitForm()
                End If
                Me.Show()
            End If
            sDt.Dispose()
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

    Sub ExitForm()
        Me.Close()
    End Sub


    Private Sub frmEndByService_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Height = 135
        FLP.Controls.Clear()
        ShowButton()

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
        frmDialogCustomerInfo.Top = Me.Top + 5
        frmDialogCustomerInfo.Left = Me.Left - frmDialogCustomerInfo.Width + 2
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

End Class
