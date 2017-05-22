Imports System.Drawing.Printing
Imports KioskElo.Org.Mentalis.Files
Imports Engine.Common.ShopConnectDBENG
Imports Engine.Kiosk
Imports Engine.Kiosk.KioskModule

Public Class frmChooseService

    Dim dt_displayservice As New DataTable

    Dim PrintQueue As KioskChooseServiceENG.Print

    Private Sub btnMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMain.Click
        'CountVDO = 0
        'Me.Close()
        frmRegister.BringToFront()
    End Sub


    Private Sub frmChooseService_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ChangeLanguage()
    End Sub

    Public Sub RenderService()
        'FLP.Hide()
        'FLP.Controls.Clear()
        'Dim sql As String = ""
        'sql = "exec SP_DisplayService " & CustomerTypeID
        'dt_displayservice = getDataTable(sql, SoftwareName, "frmChooseService_RenderService")

        'If dt_displayservice.Rows.Count > 0 Then
        '    'msgDebug += "Query : " & DateTime.Now.ToString("hh:mm:ss.fff") & vbCrLf
        '    For i As Int32 = 0 To dt_displayservice.Rows.Count - 1
        '        AddItem1(dt_displayservice.Rows(i).Item("id").ToString, dt_displayservice.Rows(i).Item(itemname_field).ToString, dt_displayservice.Rows(i).Item("count_agent").ToString)
        '        additem2(dt_displayservice.Rows(i).Item("id").ToString, dt_displayservice.Rows(i).Item("count_queue").ToString)
        '        additem3(dt_displayservice.Rows(i).Item("id").ToString, dt_displayservice.Rows(i).Item("wait_time").ToString)
        '        additem4(dt_displayservice.Rows(i).Item("id").ToString, dt_displayservice.Rows(i).Item("app_queue").ToString)
        '    Next
        '    'msgDebug += "Render : " & DateTime.Now.ToString("hh:mm:ss.fff") & vbCrLf
        'End If
        'dt_displayservice.Dispose()
        'FLP.Show()
        ''MessageBox.Show(msgDebug)
    End Sub

    Public Sub RenderObject()
        'PrintQueue.CountQueue = ""
        'PrintQueue.ListService = ""
        'PrintQueue.Mobile = ""
        'PrintQueue.WaitingTime = ""
        'PrintQueue.QueueNo = ""

        'btnAppointment.Visible = True

        'Dim eng As New KioskChooseServiceENG
        ''Dim sql As String = ""
        ''Dim dt As New DataTable
        ''sql = "select top 1 id from TB_APPOINTMENT_SCHEDULE where datediff(d,app_date,GETDATE()) = 0"
        ''dt = getDataTable(sql, INIFileName, SoftwareName, "frmChooseService_RenderObject")

        'Dim dt As New DataTable
        'dt = eng.CheckAppointmentSchedule(SoftwareName, "frmChooseService_RenderObject")
        'If dt.Rows.Count = 0 Then
        '    btnAppointment.Visible = False
        'Else
        '    If CustomerApp = False Then
        '        btnAppointment.Visible = False
        '    Else
        '        'sql = "select top 1 id from tb_counter_queue where datediff(d,getdate(),service_date)=0 and status in (1,2,4) and customer_id = '" & FixDB(Mobile) & "'"
        '        'dt = getDataTable(sql, INIFileName, SoftwareName, "frmChooseService_RenderObject")
        '        dt = eng.CheckQueueCustomerInShop(Mobile, SoftwareName, "frmChooseService_RenderObject")
        '        If dt.Rows.Count > 0 Then
        '            btnAppointment.Visible = False
        '        End If
        '    End If
        'End If
        'dt.Dispose()

        ''ดึงข้อมูล Campaign
        'If CustomerAIS = True Then
        '    TimerCampaign.Enabled = True
        'End If

        ''Hard Code โลด
        'lblCategory.Text = ""
        'If SMECorporateType = "SME" Then
        '    lblCategory.Text = SMECorporateType
        'End If
        'If InStr(NetworkType, "3G") > 0 Then
        '    lblCategory.Text += "     3G"
        'End If
        'Dim clr As Color = ColorTranslator.FromHtml("#FFFFFF")
        'lblCategory.BackColor = clr
        ''Application.DoEvents()
    End Sub

    Private Sub frmChooseService_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'RenderService()
        PictureBox6.BackgroundImage = Image.FromFile(Application.StartupPath & "/images/logoChooseService.jpg")

    End Sub

    Sub AddItem1(ByVal id As Integer, ByVal Item As String, ByVal agent As Integer)
        Dim lbl As New Label
        Dim Font As Font = New Font("Microsoft Sans Serif", 25, FontStyle.Bold, GraphicsUnit.Pixel)
        With lbl
            .Width = 320
            .Height = 45
            .Name = id
            .Text = Item
            .Font = Font
            .AutoSize = False
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.White
            .Enabled = True
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        FLP.Controls.Add(lbl)
        AddHandler lbl.MouseClick, AddressOf CheckItem
    End Sub

    Sub additem2(ByVal id As Integer, ByVal item As String)
        Dim lbl As New Label
        Dim Font As Font = New Font("Microsoft Sans Serif", 25, FontStyle.Bold, GraphicsUnit.Pixel)
        With lbl
            .Width = 80
            .Height = 45
            .Name = id
            .Text = item
            .Font = Font
            .AutoSize = False
            .FlatStyle = FlatStyle.Flat
            .TextAlign = ContentAlignment.MiddleRight
        End With
        FLP.Controls.Add(lbl)
    End Sub

    Sub additem3(ByVal id As Integer, ByVal item As String)
        Dim lbl As New Label
        Dim Font As Font = New Font("Microsoft Sans Serif", 25, FontStyle.Bold, GraphicsUnit.Pixel)
        With lbl
            .Width = 115
            .Height = 45
            .Font = Font
            .TextAlign = ContentAlignment.MiddleRight
            .Text = item
            .AutoSize = False
            .FlatStyle = FlatStyle.Flat
        End With
        FLP.Controls.Add(lbl)
    End Sub

    Sub additem4(ByVal id As Integer, ByVal item As String)
        Dim lbl As New Label
        Dim Font As Font = New Font("Microsoft Sans Serif", 25, FontStyle.Bold, GraphicsUnit.Pixel)
        With lbl
            .Width = 80
            .Height = 45
            .Name = id
            .Text = item
            .Font = Font
            .TextAlign = ContentAlignment.MiddleRight
            .AutoSize = False
            .FlatStyle = FlatStyle.Flat
        End With
        FLP.Controls.Add(lbl)
    End Sub

    Private Sub CheckItem(ByVal Sender As Object, ByVal e As EventArgs)
        'CountVDO = 0
        'Dim lbl As Label = Sender
        'If lbl.BackColor = Color.White Then
        '    Dim num As Int32 = 0
        '    For i As Int32 = 0 To FLP.Controls.Count - 1
        '        If FLP.Controls(i).BackColor = Color.LightSeaGreen Then
        '            num = num + 1
        '        End If
        '    Next
        '    '************************ Config
        '    If num = k_serve Then
        '        ShowDialogBox(msgMaximum & k_serve & msgService, msgWarning)
        '        Exit Sub
        '    End If

        '    lbl.BackColor = Color.LightSeaGreen
        '    lbl.ForeColor = Color.White
        'Else
        '    lbl.BackColor = Color.White
        '    lbl.ForeColor = Color.Black
        'End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Me.Cursor = Cursors.WaitCursor
        ''CountVDO = 0
        'If Validation() = False Then
        '    Me.Cursor = Cursors.Default
        '    Exit Sub
        'End If

        'Dim dDateNow As DateTime = FindDateNow(SoftwareName, "frmChooseService_btnOK.Click")
        'Dim vDateNow As String = FixDateTime(dDateNow)
        ''Dim DeBug As String = DateTime.Now.ToString("HH:mm:ss.fff") & " : Start" & vbNewLine
        'Dim WaitingTime As String = ""
        'Dim sql As String = ""
        'Dim AllService As String = ""
        'For i As Int32 = 0 To FLP.Controls.Count - 1
        '    If FLP.Controls(i).BackColor = Color.LightSeaGreen Then
        '        If AllService = "" Then
        '            AllService = FLP.Controls(i).Name
        '        Else
        '            AllService = AllService & "," & FLP.Controls(i).Name
        '        End If
        '    End If
        'Next

        'Dim ItemUser As String = ""
        'Dim dt As New DataTable

        'Dim dt_temp As New DataTable
        'dt_displayservice.DefaultView.RowFilter = "id in (" & AllService & ")"
        'dt_displayservice.DefaultView.Sort = " wait_time,item_wait,item_time,item_order"
        'dt_temp = dt_displayservice.DefaultView.ToTable
        'dt_displayservice.DefaultView.RowFilter = ""

        'Dim ItemID As String = ""
        'Dim ItemName As String = ""
        'Dim ItemTime As String = ""
        'Dim CountQueue As String = ""
        'Dim HideWaitTime As String = ""

        'Dim eng As New KioskChooseServiceENG
        'Dim Queue As String = ""
        'Queue = eng.FindQueueNo(Mobile, dt_temp.Rows(0).Item("id").ToString, CustomerTypeID, SoftwareName, "frmChooseService_btnOK.Click")
        'If Queue <> "" Then
        '    'DeBug += DateTime.Now.ToString("HH:mm:ss.fff") & " : Before Insert Service" & vbNewLine
        '    Dim CurrDB As String = CheckCurrentDB()
        '    For j As Int32 = 0 To dt_temp.Rows.Count - 1
        '        If ItemUser = "" Then
        '            ItemUser = dt_temp.Rows(j).Item("id").ToString
        '        Else
        '            ItemUser = ItemUser & "," & dt_temp.Rows(j).Item("id").ToString
        '        End If
        '        InsertService(Mobile, CustomerTypeID, dt_temp.Rows(j).Item("id").ToString, CustomerName, Segment, Queue, 0, NetworkType, vDateNow, CurrDB, SoftwareName, "frmChooseService_btnOK.Click")
        '    Next
        '    'DeBug += DateTime.Now.ToString("HH:mm:ss.fff") & " : End Insert Service" & vbNewLine

        '    ItemID = dt_temp.Rows(0).Item("id").ToString
        '    ItemName = dt_temp.Rows(0).Item(itemname_field).ToString
        '    If CInt(dt_temp.Rows(0).Item("time")) <= CInt(k_disable) Then
        '        ItemTime = dt_temp.Rows(0).Item("time").ToString
        '    End If
        '    CountQueue = dt_temp.Rows(0).Item("count_queue").ToString
        '    HideWaitTime = dt_temp.Rows(0)("disable_ticket_waiting_time").ToString
        '    '***************************************************

        '    eng.UpdateQueueNo(SoftwareName, "frmChooseService_btnOK.Click", vDateNow, CurrDB, Mobile, AllService, Segment, Queue, ItemID)
        'Else
        '    ShowDialogBox(msgPlsChkQSetting & vbCrLf & msgOfService & ItemName, msgWarning)
        '    sql = "delete from TB_COUNTER_QUEUE where datediff(d,getdate(),service_date)=0 "
        '    executeSQL(sql, SoftwareName, "frmChooseService.Click")
        '    Me.Cursor = Cursors.Default
        '    eng = Nothing
        '    Exit Sub
        'End If

        'Dim Item() As String = ItemUser.Split(",")
        'Dim ListItem As String = ""
        'For i As Int32 = 0 To Item.Length - 1
        '    dt = New DataTable
        '    dt_displayservice.DefaultView.RowFilter = "id = " & Item(i)
        '    dt = dt_displayservice.DefaultView.ToTable
        '    If ListItem = "" Then
        '        ListItem = dt.Rows(0).Item(itemname_field).ToString
        '    Else
        '        ListItem = ListItem & "," & dt.Rows(0).Item(itemname_field).ToString
        '    End If
        'Next
        'dt_displayservice.DefaultView.RowFilter = ""
        'btnMain.Enabled = False
        'btnOK.Enabled = False
        'btnAppointment.Enabled = False
        ''DeBug += DateTime.Now.ToString("HH:mm:ss.fff") & " : Befor Update Waiting Time" & vbNewLine
        'If Language = "TH" Then
        '    If dt_temp.Rows.Count > 1 Then
        '        lblMsg.Text = lblMsg.Text.Replace("[H]", msgPleastaketicket)
        '        'ถ้าเลือกมาหลาย service
        '        lblMsg.Text = lblMsg.Text.Replace("[Y]", msgYouwillbeservefirstwith)
        '        lblMsg.Text = lblMsg.Text.Replace("[S]", dt_temp.Rows(0).Item(itemname_field).ToString & msgBefore)

        '        If HideWaitTime = "0" Then
        '            If ItemTime <> "" Then
        '                lblMsg.Text = lblMsg.Text.Replace("[X]", msgPlsWaitForAbout & ItemTime & msgMinute)
        '            Else
        '                lblMsg.Text = lblMsg.Text.Replace("[X]", "")
        '            End If
        '        Else
        '            lblMsg.Text = lblMsg.Text.Replace("[X]", "")
        '        End If
        '    Else
        '        'ถ้าเลือกมา service เดียว
        '        lblMsg.Text = lblMsg.Text.Replace("[H]", msgPleastaketicket)
        '        lblMsg.Text = lblMsg.Text.Replace("[Y]", msgYouwillbeservefirstwith)
        '        lblMsg.Text = lblMsg.Text.Replace("[S]", dt_temp.Rows(0).Item(itemname_field).ToString)

        '        If HideWaitTime = "0" Then
        '            If ItemTime <> "" Then
        '                lblMsg.Text = lblMsg.Text.Replace("[X]", msgPlsWaitForAbout & ItemTime & msgMinute)
        '            Else
        '                lblMsg.Text = lblMsg.Text.Replace("[X]", "")
        '            End If
        '        Else
        '            lblMsg.Text = lblMsg.Text.Replace("[X]", "")
        '        End If
        '    End If
        'Else
        '    lblMsg.Text = lblMsg.Text.Replace("[H]", msgPleastaketicket)
        '    If dt_temp.Rows.Count > 1 Then
        '        'ถ้าเลือกมาหลาย service
        '        lblMsg.Text = lblMsg.Text.Replace("[Y]", msgYouwillbeservefirstwith)
        '        lblMsg.Text = lblMsg.Text.Replace("[S]", dt_temp.Rows(0).Item(itemname_field).ToString)

        '        If HideWaitTime = "0" Then
        '            If ItemTime <> "" Then
        '                lblMsg.Text = lblMsg.Text.Replace("[X]", msgWithinabout & ItemTime & msgMinute)
        '            Else
        '                lblMsg.Text = lblMsg.Text.Replace("[X]", "")
        '            End If
        '        Else
        '            lblMsg.Text = lblMsg.Text.Replace("[X]", "")
        '        End If
        '    Else
        '        lblMsg.Text = lblMsg.Text.Replace("[Y]", msgYouwillservewith)
        '        lblMsg.Text = lblMsg.Text.Replace("[S]", dt_temp.Rows(0).Item(itemname_field).ToString)

        '        If HideWaitTime = "0" Then
        '            If ItemTime <> "" Then
        '                lblMsg.Text = lblMsg.Text.Replace("[X]", msgAbout & ItemTime & msgMinute)
        '            Else
        '                lblMsg.Text = lblMsg.Text.Replace("[X]", "")
        '            End If
        '        Else
        '            lblMsg.Text = lblMsg.Text.Replace("[X]", "")
        '        End If
        '    End If
        'End If

        'Me.Cursor = Cursors.Default
        'TimerEnd.Enabled = True
        
    End Sub

    Private Function Validation() As Boolean
        '*************** เช็คการกรอกข้อมูล ***************
        Dim chk As Boolean = False
        Dim num As Int32 = 0
        For i As Int32 = 0 To FLP.Controls.Count - 1
            If FLP.Controls(i).BackColor = Color.LightSeaGreen Then
                chk = True
                num = num + 1
                Exit For
            End If
        Next

        If chk = False Then
            ShowDialogBox(msgPleaseChooseOneService, msgWarning)

            'PanelMsg.Visible = True
            'lblMsg.Text = lblMsg.Text.Replace("[H]", "")
            'lblMsg.Text = lblMsg.Text.Replace("[Y]", msgPleaseChooseOneService)
            'lblMsg.Text = lblMsg.Text.Replace("[S]", "")
            'lblMsg.Text = lblMsg.Text.Replace("[X]", "")
            'frmDialogMsg.Close()

            'PanelMsg.Visible = False
            Return False

        End If

        Return True
    End Function

    Private Sub btnAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppointment.Click
        'Dim sql As String = ""


        'CountVDO = 0
        'If Mobile = "" Then
        '    ShowDialogBox(msgCannotBBooked, msgWarning)
        '    Exit Sub
        'End If

        ''*************** เช็คการกรอกข้อมูล ***************
        'Dim chk As Boolean = False
        'Dim num As Int32 = 0
        'For i As Int32 = 0 To FLP.Controls.Count - 1
        '    If FLP.Controls(i).BackColor = Color.LightSeaGreen Then
        '        chk = True
        '        num = num + 1
        '    End If
        'Next

        'If chk = False Then
        '    ShowDialogBox(msgPleaseChooseOneService, msgWarning)
        '    Exit Sub
        'End If

        'If num > k_max_appointment Then
        '    If Language = "TH" Then
        '        ShowDialogBox(msgMaxServiceApp & k_max_appointment & msgService, msgWarning)
        '        Exit Sub
        '    Else
        '        ShowDialogBox(msgMaxServiceApp & k_max_appointment & msgService, msgWarning)
        '        Exit Sub
        '    End If
        'End If

        'Dim serviceId As String = ""
        'For i As Integer = 0 To FLP.Controls.Count - 1
        '    If FLP.Controls.Item(i).BackColor = Color.LightSeaGreen Then
        '        If serviceId = "" Then
        '            serviceId = FLP.Controls.Item(i).Name
        '        Else
        '            serviceId = FLP.Controls.Item(i).Name & "," & serviceId
        '        End If
        '    End If
        'Next

        'Dim eng As New KioskChooseServiceENG
        'Dim dt As New DataTable
        ''sql = "select item_name,item_name_th  from TB_ITEM where active_status = 1 and id in (" & serviceId & ") and id not in (select item_id from TB_APPOINTMENT_ITEM where DATEDIFF(D,GETDATE(),app_date)=0)"
        ''dt = getDataTable(sql, INIFileName, SoftwareName, "frmChooseService_btnAppointment_Click")
        'dt = eng.CheckServiceAppointment(serviceId, INIFileName, SoftwareName, "frmChooseService_btnAppointment_Click")
        'If dt.Rows.Count > 0 Then
        '    Dim ListItem As String = ""
        '    For i As Int32 = 0 To dt.Rows.Count - 1
        '        If ListItem = "" Then
        '            ListItem = dt.Rows(i).Item(itemname_field).ToString
        '        Else
        '            ListItem = ListItem & vbCrLf & dt.Rows(i).Item(itemname_field).ToString
        '        End If
        '    Next
        '    dt.Dispose()
        '    eng = Nothing
        '    ShowDialogBox(msgYouChooseTheService & vbCrLf & vbCrLf & ListItem & vbCrLf & vbCrLf & msgBookingNotAllowed, msgWarning)
        '    Exit Sub
        'End If
        'eng = Nothing

        ''กรณีจองแล้วไม่มาตามนัด(NoShow) x ครั้ง ภายใน X วัน ก็จะติด Backlist ไปนาน x วัน
        'Dim f As New frmDialogMsg
        'Try
        '    Dim wsBl As New ShopWebServiceMain.WebServiceAPI
        '    wsBl.Url = m_webservice_url
        '    Dim p As New ShopWebServiceMain.AppointmentCheckBacklistResultPara
        '    p = wsBl.CheckBlackList(Mobile)
        '    If p.IsBackList = True Then
        '        If Language = "TH" Then
        '            f.lblText.Text = Mobile & vbCrLf & vbCrLf & msgCannotAppoinment & vbCrLf & vbCrLf & msgPleasmakeanew & vbCrLf & msgAppointmentAgain & p.NewAppointmentDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        '        Else
        '            f.lblText.Text = Mobile & vbCrLf & vbCrLf & msgCannotAppoinment & vbCrLf & msgPleasmakeanew & vbCrLf & msgAppointmentAgain & vbCrLf & p.NewAppointmentDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US")) & msgOnward
        '        End If

        '        f.btnConfirm.Visible = False
        '        f.btnCancel.Visible = False
        '        f.btnOK.Visible = False

        '        If Language = "TH" Then
        '            f.btnMain.Text = "หน้าหลัก"
        '        Else
        '            f.btnMain.Text = "Main Menu"
        '        End If

        '        p = Nothing
        '        wsBl = Nothing

        '        f.btnMain.Visible = True
        '        f.ShowDialog()
        '        btnMain.PerformClick()
        '        Exit Sub
        '    End If
        '    p = Nothing
        '    wsBl = Nothing
        'Catch ex As Exception
        '    Try
        '        Dim sqlLog As String = "insert into tb_error_log ([id],[create_by],[create_date],[update_by],[update_date],[log_date],[error_message],[sql_command],[client_ip],[version])"
        '        sqlLog += " values(" & FindID("tb_error_log", INIFileName, SoftwareName, "frmChooseService_btnAppointment.Click") & ", 1, getdate(),null,null,"
        '        sqlLog += " getdate(), 'btnAppointment.btnAppointment_Click " & ex.Message & "', null, '" & Engine.Common.FunctionEng.GetIPAddress & "', '" & frmRegister.getMyVersion & "')"
        '        executeSQL(sqlLog, INIFileName, SoftwareName, "frmChooseService_btnAppointment.Click")

        '        Dim wsBl As New ShopWebServiceDisplay.WebServiceAPI
        '        wsBl.Url = d_webservice_url
        '        Dim p As New ShopWebServiceDisplay.AppointmentCheckBacklistResultPara
        '        p = wsBl.CheckBlackList(Mobile)
        '        If p.IsBackList = True Then
        '            f.btnMain.Visible = True
        '            f.btnPrevious.Visible = False
        '            f.btnOK.Visible = False
        '            If Language = "TH" Then
        '                f.lblText.Text = Mobile & vbCrLf & vbCrLf & msgCannotAppoinment & vbCrLf & vbCrLf & msgPleasmakeanew & vbCrLf & msgAppointmentAgain & p.NewAppointmentDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("th-TH"))
        '            Else
        '                'f.lblText.Text = Mobile & vbCrLf & vbCrLf & msgCannotAppoinment & vbCrLf & vbCrLf & msgPleasmakeanew & vbCrLf & msgAppointmentAgain & vbCrLf & p.NewAppointmentDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US")) & msgOnward
        '                f.lblText.Text = Mobile & vbCrLf & vbCrLf & msgCannotAppoinment & vbCrLf & msgPleasmakeanew & vbCrLf & msgAppointmentAgain & vbCrLf & p.NewAppointmentDate.ToString("dd/MM/yyyy", New Globalization.CultureInfo("en-US")) & msgOnward
        '            End If

        '            f.btnConfirm.Visible = False
        '            f.btnCancel.Visible = False
        '            f.btnOK.Visible = False

        '            If Language = "TH" Then
        '                f.btnMain.Text = "หน้าหลัก"
        '            Else
        '                f.btnMain.Text = "Main Menu"
        '            End If

        '            p = Nothing
        '            wsBl = Nothing

        '            f.btnMain.Visible = True
        '            f.ShowDialog()
        '            btnMain.PerformClick()
        '            Exit Sub
        '        End If
        '        p = Nothing
        '        wsBl = Nothing
        '    Catch ey As Exception : End Try

        'End Try

        'frmAppointment.Show()
        'frmAppointment.ChooseService = serviceId
    End Sub

    'Private Sub pb_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseMove, FLP.MouseMove
    '    CountVDO = 0
    'End Sub


    Private Sub TimerEnd_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerEnd.Tick
        TimerEnd.Enabled = False
        'Me.Close()
        lblMsg.Text = "[H]" & vbNewLine & vbNewLine
        lblMsg.Text += "[Y]" & vbNewLine
        lblMsg.Text += "[S]" & vbNewLine & vbNewLine
        lblMsg.Text += "[X]"

        PanelMsg.Visible = False
        btnMain.Enabled = True
        btnOK.Enabled = True
        btnAppointment.Enabled = True
        frmRegister.BringToFront()
    End Sub
End Class