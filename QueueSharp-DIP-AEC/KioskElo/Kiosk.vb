
Imports System.Data.SqlClient
Imports KioskElo.Org.Mentalis.Files
Imports System.IO
Imports Engine.Common.ShopConnectDBENG
Imports Engine.Kiosk.KioskModule

Module Kiosk

    Public Const SoftwareName As String = "KioskElo"
    'Public INIFileName As String = Application.StartupPath & "\Kiosk.ini"  'Parth ที่ใช้เก็บไฟล์ .ini
    
    
#Region "All Error"
    Sub showFormError(ByVal Message As String)
        Dim f As New frmErrorMessage
        f.txtMassage.Text = Message
        f.ShowDialog()
        f.Dispose()
    End Sub
#End Region

    Function ShowDialogBox(ByVal Text As String, ByVal HeadText As String, Optional ByVal btnYesNo As Boolean = False) As Boolean
        'Dim f As New frmDialogMsg
        If btnYesNo = True Then
            frmDialogMsg.btnOK.Visible = False
            frmDialogMsg.btnPrevious.Visible = False
            frmDialogMsg.btnMain.Visible = False
            frmDialogMsg.btnConfirm.Visible = True
            frmDialogMsg.btnCancel.Visible = True
        Else
            frmDialogMsg.btnConfirm.Visible = False
            frmDialogMsg.btnCancel.Visible = False
            frmDialogMsg.btnOK.Visible = False
            frmDialogMsg.btnPrevious.Visible = False
            frmDialogMsg.btnMain.Visible = True
            frmDialogMsg.btnMain.Text = msgDialogBtnOK
        End If
        frmDialogMsg.Text = HeadText
        frmDialogMsg.lblText.Text = Text
        If frmDialogMsg.ShowDialog() = Windows.Forms.DialogResult.Yes Then
            Return True
        End If
        Return False
    End Function

    Sub LoadConfig()
        'Dim ChkDB As String = CheckConnDbServer()
        'If ChkDB.Trim <> "" Then
        '    ShowDialogBox(ChkDB, msgWarning)
        'End If

        If CheckUpdateConfig(SoftwareName, "KioskElo_LoadConfig") = False Then
            ShowDialogBox(Engine.Kiosk.KioskModule.ErrorMessage, msgWarning)
            Application.Exit()
        End If
    End Sub

    Public Sub showNotify(ByVal Title As String, ByVal text As String)
        Dim ntfy As New TaskBarNotifier
        With ntfy
            .CloseButtonClickEnabled = True
            .TitleClickEnabled = False
            .TextClickEnabled = False
            .DrawTextFocusRect = True
            .KeepVisibleOnMouseOver = True
            .ReShowOnMouseOver = True
            .TransparencyKey = Color.PaleTurquoise

            Dim Image As Image = System.Drawing.Image.FromFile(Application.StartupPath & "\alert.png")
            Dim Image1 As Image = System.Drawing.Image.FromFile(Application.StartupPath & "\close.bmp")
            .SetBackgroundBitmap(Image, Color.FromArgb(255, 0, 255))
            '.SetCloseBitmap(Image1, Color.FromArgb(255, 0, 255), New Point(225, 34))
            .TitleRectangle = New Rectangle(80, 25, 300, 30)
            .TextRectangle = New Rectangle(-65, -40, 400, 300)
            .Show(Title, text, 500, 2000, 1000)
        End With
    End Sub
    
End Module
