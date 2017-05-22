<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegister
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
        Me.components = New System.ComponentModel.Container()
        Me.TimerVDO = New System.Windows.Forms.Timer(Me.components)
        Me.txtReqNo = New System.Windows.Forms.TextBox()
        Me.pd = New System.Drawing.Printing.PrintDocument()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbReqType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPatentType = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TimerVDO
        '
        Me.TimerVDO.Interval = 1000
        '
        'txtReqNo
        '
        Me.txtReqNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtReqNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReqNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtReqNo.ForeColor = System.Drawing.Color.Black
        Me.txtReqNo.Location = New System.Drawing.Point(337, 144)
        Me.txtReqNo.MaxLength = 10
        Me.txtReqNo.Name = "txtReqNo"
        Me.txtReqNo.Size = New System.Drawing.Size(412, 42)
        Me.txtReqNo.TabIndex = 0
        Me.txtReqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pd
        '
        '
        'btnOK
        '
        Me.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.btnOK.BackgroundImage = Global.KioskElo.My.Resources.Resources.Untitled_1
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOK.Location = New System.Drawing.Point(337, 357)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(207, 77)
        Me.btnOK.TabIndex = 3
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'pb
        '
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pb.Location = New System.Drawing.Point(0, 0)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(1366, 768)
        Me.pb.TabIndex = 18
        Me.pb.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(150, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 42)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "เลขที่คำขอ"
        '
        'cmbReqType
        '
        Me.cmbReqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReqType.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbReqType.FormattingEnabled = True
        Me.cmbReqType.Location = New System.Drawing.Point(337, 211)
        Me.cmbReqType.Name = "cmbReqType"
        Me.cmbReqType.Size = New System.Drawing.Size(595, 39)
        Me.cmbReqType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(99, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(206, 42)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "ประเภทคำขอ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 268)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(249, 42)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "ประเภทสิทธิบัตร"
        '
        'cmbPatentType
        '
        Me.cmbPatentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPatentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.cmbPatentType.FormattingEnabled = True
        Me.cmbPatentType.Location = New System.Drawing.Point(337, 274)
        Me.cmbPatentType.Name = "cmbPatentType"
        Me.cmbPatentType.Size = New System.Drawing.Size(595, 39)
        Me.cmbPatentType.TabIndex = 2
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Transparent
        Me.btnExit.BackgroundImage = Global.KioskElo.My.Resources.Resources.Close
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Location = New System.Drawing.Point(1, 1)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(26, 23)
        Me.btnExit.TabIndex = 65
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'frmRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbPatentType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbReqType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtReqNo)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.pb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmSlot"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimerVDO As System.Windows.Forms.Timer
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtReqNo As System.Windows.Forms.TextBox
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents pd As System.Drawing.Printing.PrintDocument
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbReqType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPatentType As System.Windows.Forms.ComboBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
