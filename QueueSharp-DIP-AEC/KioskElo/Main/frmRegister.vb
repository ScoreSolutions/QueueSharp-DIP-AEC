Imports System.Drawing.Printing
Imports KioskElo.Org.Mentalis.Files
Imports Engine.Common.ShopConnectDBENG
Imports Engine.Kiosk
Imports Engine.Kiosk.KioskModule
Imports System.IO
Imports LinqDB.TABLE

Public Class frmRegister

    Dim PrintQueue As KioskRegisterENG.Print

    Public Function getMyVersion() As String
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly.GetName().Version
        Return version.Major & "." & version.Minor & "." & version.Build & "." & version.Revision
    End Function

    Private Sub RegisterOKClick()
        Dim sql As String = ""
        CheckUpdateConfig(SoftwareName, "frmRegister_RegisterOKClick")


        Dim spLnq As New MsServicePriorityLinqDB
        Dim dt As DataTable = spLnq.GetDataList("ms_requisition_type_id='" & cmbReqType.SelectedValue & "' and ms_patent_type_id='" & cmbPatentType.SelectedValue & "'", "", Nothing)
        If dt.Rows.Count > 0 Then
            Dim vDateNow As DateTime = Engine.Common.FunctionEng.GetDateNowFromDB()

            'Insert Data to Register Queue
            Dim lnq As New TbRegisterQueueLinqDB
            lnq.APP_NO = txtReqNo.Text.Trim
            lnq.MS_REQUISITION_TYPE_ID = cmbReqType.SelectedValue
            lnq.MS_PATENT_TYPE_ID = cmbPatentType.SelectedValue
            lnq.REGISTER_TIME = vDateNow

            Dim trans As New LinqDB.ConnectDB.TransactionDB
            If lnq.InsertData("RegisterOKClick", trans.Trans) = True Then
                'Insert Data To Counter Queue
                Dim re As Boolean = False
                For Each dr As DataRow In dt.Rows
                    Dim cqLnq As New TbCounterQueueLinqDB
                    cqLnq.TB_REGISTER_QUEUE_ID = lnq.ID
                    cqLnq.MS_SERVICE_ID = dr("ms_service_id")
                    cqLnq.MS_COUNTER_ID = 0
                    cqLnq.MS_USER_ID = 0
                    cqLnq.ASSIGN_TIME = vDateNow
                    cqLnq.STATUS = 1

                    re = cqLnq.InsertData("KIOSK", trans.Trans)
                    If re = False Then
                        Exit For
                    End If
                Next

                If re = True Then
                    trans.CommitTransaction()
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtReqNo.Text = ""
                    cmbPatentType.SelectedValue = 0
                    cmbReqType.SelectedValue = 0
                Else
                    trans.RollbackTransaction()
                End If
            Else
                trans.RollbackTransaction()
            End If
            lnq = Nothing
        Else
            MessageBox.Show("ไม่พบข้อมูลการตั้งค่าการใช้งาน", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        dt.Dispose()
        spLnq = Nothing

        'ChangeLanguage()

        'frmChooseService.RenderObject()
        'frmChooseService.RenderService()
        'frmChooseService.BringToFront()


    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If txtReqNo.Text.Trim = "" Then
            MessageBox.Show("กรุณาระบุเลขที่คำขอฯ")
            txtReqNo.Focus()
            Exit Sub
        End If
        If txtReqNo.Text.Trim.Length <> 10 Then
            MessageBox.Show("กรุณาระบุเลขที่คำขอฯ ให้ครบ 10 หลัก")
            txtReqNo.SelectAll()
            Exit Sub
        End If

        If cmbReqType.SelectedValue = 0 Then
            MessageBox.Show("กรุณาเลือกประเภทคำขอฯ")
            cmbReqType.Focus()
            Exit Sub
        End If

        If cmbPatentType.SelectedValue = 0 Then
            MessageBox.Show("กรุณาเลือกประเภทสิทธิบัตร")
            cmbPatentType.Focus()
            Exit Sub
        End If

        btnOK.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        RegisterOKClick()
        btnOK.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CountVDO = 0
        If txtReqNo.Text.Trim <> "" Then
            If StringFromRight(txtReqNo.Text, 1) = "-" Then
                txtReqNo.Text = txtReqNo.Text.Substring(0, (txtReqNo.Text.Length - 2))
            Else
                txtReqNo.Text = txtReqNo.Text.Substring(0, (txtReqNo.Text.Length - 1))
            End If

        End If
    End Sub

    Private Sub TimerVDO_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerVDO.Tick
        'Try
        '    If CountVDO < MaxCountVDO Then
        '        CountVDO = CountVDO + 1
        '    Else
        '        TimerVDO.Enabled = False
        '        frmDialogMsg.Hide()
        '        txtReqNo.Text = ""
        '        If frmVDO.ShowDialog = Windows.Forms.DialogResult.Yes Then
        '            frmDialogMsg.Close()
        '            frmVDO.Close()
        '            CountVDO = 0
        '            TimerVDO.Enabled = True
        '        End If
        '    End If
        'Catch ex As Exception : End Try

    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    'Private Sub pb_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseMove
    '    CountVDO = 0
    'End Sub

    Private Sub frmRegister_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        Application.DoEvents()
        LoadConfig()
        LoadDataToDropdownlist()
        'MaxCountVDO = k_vdo * 60

        Dim eng As New KioskRegisterENG
        eng.DeleteQueueIfNoQueue(SoftwareName, "frmRegister_Shown")

        frmChooseService.Show()
        Me.BringToFront()

        'สำหรับ Bypass SSL กรณีเรียก WebService ผ่าน https://
        System.Net.ServicePointManager.ServerCertificateValidationCallback = _
          Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, _
          chain As System.Security.Cryptography.X509Certificates.X509Chain, _
          sslerror As System.Net.Security.SslPolicyErrors) True
    End Sub

    Private Sub LoadDataToDropdownlist()
        Dim rtLnq As New MsRequisitionTypeLinqDB
        Dim rtDt As DataTable = rtLnq.GetDataList("active_status='1'", "order_seq", Nothing)
        If rtDt.Rows.Count > 0 Then
            Dim dr As DataRow = rtDt.NewRow
            dr("id") = 0
            dr("requisition_type_name") = "เลือก"
            rtDt.Rows.InsertAt(dr, 0)

            cmbReqType.DataSource = rtDt
            cmbReqType.ValueMember = "id"
            cmbReqType.DisplayMember = "requisition_type_name"
        End If
        rtLnq = Nothing

        Dim ptLnq As New MsPatentTypeLinqDB
        Dim ptDt As DataTable = ptLnq.GetDataList("active_status='1'", "id", Nothing)
        If ptDt.Rows.Count > 0 Then
            Dim dr As DataRow = ptDt.NewRow
            dr("id") = 0
            dr("patent_type_name") = "เลือก"
            ptDt.Rows.InsertAt(dr, 0)

            cmbPatentType.DataSource = ptDt
            cmbPatentType.ValueMember = "id"
            cmbPatentType.DisplayMember = "patent_type_name"
        End If
        ptLnq = Nothing
    End Sub


    Private Sub DeleteFileFromCaptureAppointment(ByVal MobileNo As String)
        Dim eng As New KioskBaseENG
        Dim Path As String = eng.GetCaptureAppointmentPath
        If File.Exists(Path & MobileNo & ".jpg") = True Then
            File.Delete(Path & MobileNo & ".jpg")
        End If
        eng = Nothing
    End Sub

#Region "Print"
    Private Sub pd_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pd.PrintPage
        'Dim eng As New KioskRegisterENG
        'eng.PrintQueueAppointTicket(e, INIFileName, SoftwareName, "frmRegister_pd.PrintPage", PrintQueue)
        'eng = Nothing

        'CheckNotify()
    End Sub

#End Region




    Private Sub txtReqNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReqNo.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
            Case Else
                e.Handled = True
        End Select
    End Sub
End Class