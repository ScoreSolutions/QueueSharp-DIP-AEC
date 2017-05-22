<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQCResultTmp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQCResultTmp))
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxButton = New CodeVendor.Controls.Grouper()
        Me.cbServiceReject = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtResultFailDesc = New System.Windows.Forms.TextBox()
        Me.rdiResultPass = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPatentType = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblReqType = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAppNo = New System.Windows.Forms.Label()
        Me.rdiResultFail = New System.Windows.Forms.RadioButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtRegisterQueueID = New System.Windows.Forms.TextBox()
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
        Me.GroupBoxButton.Controls.Add(Me.txtRegisterQueueID)
        Me.GroupBoxButton.Controls.Add(Me.rdiResultFail)
        Me.GroupBoxButton.Controls.Add(Me.cbServiceReject)
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
        Me.GroupBoxButton.Size = New System.Drawing.Size(664, 273)
        Me.GroupBoxButton.TabIndex = 24
        '
        'cbServiceReject
        '
        Me.cbServiceReject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbServiceReject.Enabled = False
        Me.cbServiceReject.FormattingEnabled = True
        Me.cbServiceReject.Location = New System.Drawing.Point(225, 111)
        Me.cbServiceReject.Name = "cbServiceReject"
        Me.cbServiceReject.Size = New System.Drawing.Size(416, 26)
        Me.cbServiceReject.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 18)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "สิ่งที่ต้องแก้ไข :"
        '
        'txtResultFailDesc
        '
        Me.txtResultFailDesc.Enabled = False
        Me.txtResultFailDesc.Location = New System.Drawing.Point(22, 176)
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
        'rdiResultFail
        '
        Me.rdiResultFail.AutoSize = True
        Me.rdiResultFail.Location = New System.Drawing.Point(135, 112)
        Me.rdiResultFail.Name = "rdiResultFail"
        Me.rdiResultFail.Size = New System.Drawing.Size(65, 22)
        Me.rdiResultFail.TabIndex = 36
        Me.rdiResultFail.TabStop = True
        Me.rdiResultFail.Text = "ไม่ผ่าน"
        Me.rdiResultFail.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnSave.Image = Global.QueueSharpQC.My.Resources.Resources.Save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(572, 272)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 40)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtRegisterQueueID
        '
        Me.txtRegisterQueueID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtRegisterQueueID.Location = New System.Drawing.Point(592, 53)
        Me.txtRegisterQueueID.Name = "txtRegisterQueueID"
        Me.txtRegisterQueueID.Size = New System.Drawing.Size(56, 24)
        Me.txtRegisterQueueID.TabIndex = 37
        Me.txtRegisterQueueID.Text = "0"
        Me.txtRegisterQueueID.Visible = False
        '
        'frmQCResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(674, 320)
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
    Friend WithEvents cbServiceReject As System.Windows.Forms.ComboBox
    Friend WithEvents rdiResultFail As System.Windows.Forms.RadioButton
    Friend WithEvents txtRegisterQueueID As System.Windows.Forms.TextBox
End Class
