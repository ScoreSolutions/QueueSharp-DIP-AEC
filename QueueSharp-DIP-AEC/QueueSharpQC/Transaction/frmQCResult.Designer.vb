<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQCResult
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQCResult))
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxButton = New CodeVendor.Controls.Grouper()
        Me.cbFailCert = New System.Windows.Forms.ComboBox()
        Me.cbFailPublic = New System.Windows.Forms.ComboBox()
        Me.cbFailScan = New System.Windows.Forms.ComboBox()
        Me.cbFailKey = New System.Windows.Forms.ComboBox()
        Me.cbFailHold = New System.Windows.Forms.ComboBox()
        Me.chkFailPublic = New System.Windows.Forms.CheckBox()
        Me.chkFailCert = New System.Windows.Forms.CheckBox()
        Me.chkFailHole = New System.Windows.Forms.CheckBox()
        Me.chkFailKey = New System.Windows.Forms.CheckBox()
        Me.chkFailScan = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtResultFailDesc = New System.Windows.Forms.TextBox()
        Me.rdiResultPass = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPatentType = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblReqType = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAppNo = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBoxButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtID.Location = New System.Drawing.Point(592, 23)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(56, 24)
        Me.txtID.TabIndex = 15
        Me.txtID.Text = "0"
        Me.txtID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "เลขที่คำขอ :"
        '
        'GroupBoxButton
        '
        Me.GroupBoxButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxButton.BackgroundColor = System.Drawing.Color.White
        Me.GroupBoxButton.BackgroundGradientColor = System.Drawing.Color.SkyBlue
        Me.GroupBoxButton.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.GroupBoxButton.BorderColor = System.Drawing.Color.SteelBlue
        Me.GroupBoxButton.BorderThickness = 1.0!
        Me.GroupBoxButton.Controls.Add(Me.cbFailCert)
        Me.GroupBoxButton.Controls.Add(Me.cbFailPublic)
        Me.GroupBoxButton.Controls.Add(Me.cbFailScan)
        Me.GroupBoxButton.Controls.Add(Me.cbFailKey)
        Me.GroupBoxButton.Controls.Add(Me.cbFailHold)
        Me.GroupBoxButton.Controls.Add(Me.chkFailPublic)
        Me.GroupBoxButton.Controls.Add(Me.chkFailCert)
        Me.GroupBoxButton.Controls.Add(Me.chkFailHole)
        Me.GroupBoxButton.Controls.Add(Me.chkFailKey)
        Me.GroupBoxButton.Controls.Add(Me.chkFailScan)
        Me.GroupBoxButton.Controls.Add(Me.Label3)
        Me.GroupBoxButton.Controls.Add(Me.txtResultFailDesc)
        Me.GroupBoxButton.Controls.Add(Me.rdiResultPass)
        Me.GroupBoxButton.Controls.Add(Me.Label2)
        Me.GroupBoxButton.Controls.Add(Me.lblPatentType)
        Me.GroupBoxButton.Controls.Add(Me.Label5)
        Me.GroupBoxButton.Controls.Add(Me.lblReqType)
        Me.GroupBoxButton.Controls.Add(Me.Label4)
        Me.GroupBoxButton.Controls.Add(Me.lblAppNo)
        Me.GroupBoxButton.Controls.Add(Me.txtID)
        Me.GroupBoxButton.Controls.Add(Me.Label1)
        Me.GroupBoxButton.CustomGroupBoxColor = System.Drawing.Color.White
        Me.GroupBoxButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBoxButton.GroupImage = Nothing
        Me.GroupBoxButton.GroupTitle = ""
        Me.GroupBoxButton.Location = New System.Drawing.Point(6, -7)
        Me.GroupBoxButton.MinimumSize = New System.Drawing.Size(1, 1)
        Me.GroupBoxButton.Name = "GroupBoxButton"
        Me.GroupBoxButton.Padding = New System.Windows.Forms.Padding(20)
        Me.GroupBoxButton.PaintGroupBox = False
        Me.GroupBoxButton.RoundCorners = 10
        Me.GroupBoxButton.ShadowColor = System.Drawing.Color.DarkGray
        Me.GroupBoxButton.ShadowControl = True
        Me.GroupBoxButton.ShadowThickness = 3
        Me.GroupBoxButton.Size = New System.Drawing.Size(664, 343)
        Me.GroupBoxButton.TabIndex = 24
        '
        'cbFailCert
        '
        Me.cbFailCert.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFailCert.Enabled = False
        Me.cbFailCert.FormattingEnabled = True
        Me.cbFailCert.Location = New System.Drawing.Point(332, 214)
        Me.cbFailCert.Name = "cbFailCert"
        Me.cbFailCert.Size = New System.Drawing.Size(309, 26)
        Me.cbFailCert.TabIndex = 35
        '
        'cbFailPublic
        '
        Me.cbFailPublic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFailPublic.Enabled = False
        Me.cbFailPublic.FormattingEnabled = True
        Me.cbFailPublic.Location = New System.Drawing.Point(332, 187)
        Me.cbFailPublic.Name = "cbFailPublic"
        Me.cbFailPublic.Size = New System.Drawing.Size(309, 26)
        Me.cbFailPublic.TabIndex = 34
        '
        'cbFailScan
        '
        Me.cbFailScan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFailScan.Enabled = False
        Me.cbFailScan.FormattingEnabled = True
        Me.cbFailScan.Location = New System.Drawing.Point(332, 160)
        Me.cbFailScan.Name = "cbFailScan"
        Me.cbFailScan.Size = New System.Drawing.Size(309, 26)
        Me.cbFailScan.TabIndex = 33
        '
        'cbFailKey
        '
        Me.cbFailKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFailKey.Enabled = False
        Me.cbFailKey.FormattingEnabled = True
        Me.cbFailKey.Location = New System.Drawing.Point(332, 133)
        Me.cbFailKey.Name = "cbFailKey"
        Me.cbFailKey.Size = New System.Drawing.Size(309, 26)
        Me.cbFailKey.TabIndex = 32
        '
        'cbFailHold
        '
        Me.cbFailHold.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFailHold.Enabled = False
        Me.cbFailHold.FormattingEnabled = True
        Me.cbFailHold.Location = New System.Drawing.Point(332, 106)
        Me.cbFailHold.Name = "cbFailHold"
        Me.cbFailHold.Size = New System.Drawing.Size(309, 26)
        Me.cbFailHold.TabIndex = 31
        '
        'chkFailPublic
        '
        Me.chkFailPublic.AutoSize = True
        Me.chkFailPublic.Location = New System.Drawing.Point(135, 189)
        Me.chkFailPublic.Name = "chkFailPublic"
        Me.chkFailPublic.Size = New System.Drawing.Size(179, 22)
        Me.chkFailPublic.TabIndex = 30
        Me.chkFailPublic.Text = "แก้ไขข้อมูลประกาศโฆษณา"
        Me.chkFailPublic.UseVisualStyleBackColor = True
        '
        'chkFailCert
        '
        Me.chkFailCert.AutoSize = True
        Me.chkFailCert.Location = New System.Drawing.Point(135, 216)
        Me.chkFailCert.Name = "chkFailCert"
        Me.chkFailCert.Size = New System.Drawing.Size(161, 22)
        Me.chkFailCert.TabIndex = 29
        Me.chkFailCert.Text = "แก้ไขข้อมูล Certificate"
        Me.chkFailCert.UseVisualStyleBackColor = True
        '
        'chkFailHole
        '
        Me.chkFailHole.AutoSize = True
        Me.chkFailHole.Location = New System.Drawing.Point(135, 108)
        Me.chkFailHole.Name = "chkFailHole"
        Me.chkFailHole.Size = New System.Drawing.Size(137, 22)
        Me.chkFailHole.TabIndex = 28
        Me.chkFailHole.Text = "แก้ไขงานปรุเอกสาร"
        Me.chkFailHole.UseVisualStyleBackColor = True
        '
        'chkFailKey
        '
        Me.chkFailKey.AutoSize = True
        Me.chkFailKey.Location = New System.Drawing.Point(135, 135)
        Me.chkFailKey.Name = "chkFailKey"
        Me.chkFailKey.Size = New System.Drawing.Size(128, 22)
        Me.chkFailKey.TabIndex = 27
        Me.chkFailKey.Text = "แก้ไขงานคีย์ข้อมูล"
        Me.chkFailKey.UseVisualStyleBackColor = True
        '
        'chkFailScan
        '
        Me.chkFailScan.AutoSize = True
        Me.chkFailScan.Location = New System.Drawing.Point(135, 162)
        Me.chkFailScan.Name = "chkFailScan"
        Me.chkFailScan.Size = New System.Drawing.Size(114, 22)
        Me.chkFailScan.TabIndex = 26
        Me.chkFailScan.Text = "แก้ไขงานสแกน"
        Me.chkFailScan.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 233)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 18)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "สิ่งที่ต้องแก้ไข :"
        '
        'txtResultFailDesc
        '
        Me.txtResultFailDesc.Enabled = False
        Me.txtResultFailDesc.Location = New System.Drawing.Point(22, 252)
        Me.txtResultFailDesc.Multiline = True
        Me.txtResultFailDesc.Name = "txtResultFailDesc"
        Me.txtResultFailDesc.Size = New System.Drawing.Size(619, 79)
        Me.txtResultFailDesc.TabIndex = 24
        '
        'rdiResultPass
        '
        Me.rdiResultPass.AutoSize = True
        Me.rdiResultPass.Location = New System.Drawing.Point(135, 86)
        Me.rdiResultPass.Name = "rdiResultPass"
        Me.rdiResultPass.Size = New System.Drawing.Size(49, 22)
        Me.rdiResultPass.TabIndex = 22
        Me.rdiResultPass.TabStop = True
        Me.rdiResultPass.Text = "ผ่าน"
        Me.rdiResultPass.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 18)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "ผลการตรวจสอบ :"
        '
        'lblPatentType
        '
        Me.lblPatentType.AutoSize = True
        Me.lblPatentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPatentType.Location = New System.Drawing.Point(365, 23)
        Me.lblPatentType.Name = "lblPatentType"
        Me.lblPatentType.Size = New System.Drawing.Size(0, 18)
        Me.lblPatentType.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(270, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 18)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "ประเภทแฟ้ม :"
        '
        'lblReqType
        '
        Me.lblReqType.AutoSize = True
        Me.lblReqType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblReqType.Location = New System.Drawing.Point(117, 55)
        Me.lblReqType.Name = "lblReqType"
        Me.lblReqType.Size = New System.Drawing.Size(0, 18)
        Me.lblReqType.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 18)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "ประเภทคำขอ :"
        '
        'lblAppNo
        '
        Me.lblAppNo.AutoSize = True
        Me.lblAppNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAppNo.Location = New System.Drawing.Point(102, 23)
        Me.lblAppNo.Name = "lblAppNo"
        Me.lblAppNo.Size = New System.Drawing.Size(0, 18)
        Me.lblAppNo.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnSave.Image = Global.QueueSharpQC.My.Resources.Resources.Save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(572, 341)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 40)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmQCResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(674, 387)
        Me.Controls.Add(Me.GroupBoxButton)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmQCResult"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ผลการตรวจสอบความถูกต้อง"
        Me.GroupBoxButton.ResumeLayout(False)
        Me.GroupBoxButton.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxButton As CodeVendor.Controls.Grouper
    Friend WithEvents lblPatentType As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblReqType As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAppNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtResultFailDesc As System.Windows.Forms.TextBox
    Friend WithEvents rdiResultPass As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkFailHole As System.Windows.Forms.CheckBox
    Friend WithEvents chkFailKey As System.Windows.Forms.CheckBox
    Friend WithEvents chkFailScan As System.Windows.Forms.CheckBox
    Friend WithEvents chkFailPublic As System.Windows.Forms.CheckBox
    Friend WithEvents chkFailCert As System.Windows.Forms.CheckBox
    Friend WithEvents cbFailCert As System.Windows.Forms.ComboBox
    Friend WithEvents cbFailPublic As System.Windows.Forms.ComboBox
    Friend WithEvents cbFailScan As System.Windows.Forms.ComboBox
    Friend WithEvents cbFailKey As System.Windows.Forms.ComboBox
    Friend WithEvents cbFailHold As System.Windows.Forms.ComboBox
End Class
