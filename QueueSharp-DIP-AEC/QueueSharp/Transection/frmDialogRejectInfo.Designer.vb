<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialogRejectInfo
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtRejectInfo = New System.Windows.Forms.TextBox()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Honeydew
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtRejectInfo)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(546, 162)
        Me.Panel3.TabIndex = 3
        '
        'txtRejectInfo
        '
        Me.txtRejectInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRejectInfo.Enabled = False
        Me.txtRejectInfo.Location = New System.Drawing.Point(0, 0)
        Me.txtRejectInfo.Multiline = True
        Me.txtRejectInfo.Name = "txtRejectInfo"
        Me.txtRejectInfo.Size = New System.Drawing.Size(544, 160)
        Me.txtRejectInfo.TabIndex = 0
        '
        'frmDialogRejectInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(546, 162)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDialogRejectInfo"
        Me.ShowInTaskbar = False
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtRejectInfo As System.Windows.Forms.TextBox
End Class
