<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyHistory
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBoxViewCustomerEnd = New CodeVendor.Controls.Grouper()
        Me.lblServe = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.cbUser = New System.Windows.Forms.ComboBox()
        Me.Counter_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisition_type_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.patent_type_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.service = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.waiting_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.served_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total_waiting_time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.row = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBoxViewCustomerEnd.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBoxViewCustomerEnd
        '
        Me.GroupBoxViewCustomerEnd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxViewCustomerEnd.BackgroundColor = System.Drawing.Color.White
        Me.GroupBoxViewCustomerEnd.BackgroundGradientColor = System.Drawing.Color.SkyBlue
        Me.GroupBoxViewCustomerEnd.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.GroupBoxViewCustomerEnd.BorderColor = System.Drawing.Color.SteelBlue
        Me.GroupBoxViewCustomerEnd.BorderThickness = 1.0!
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.lblServe)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.Label6)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.Label4)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.Grid)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.cbUser)
        Me.GroupBoxViewCustomerEnd.CustomGroupBoxColor = System.Drawing.Color.White
        Me.GroupBoxViewCustomerEnd.GroupImage = Nothing
        Me.GroupBoxViewCustomerEnd.GroupTitle = ""
        Me.GroupBoxViewCustomerEnd.Location = New System.Drawing.Point(6, -2)
        Me.GroupBoxViewCustomerEnd.Margin = New System.Windows.Forms.Padding(6)
        Me.GroupBoxViewCustomerEnd.MinimumSize = New System.Drawing.Size(3, 1)
        Me.GroupBoxViewCustomerEnd.Name = "GroupBoxViewCustomerEnd"
        Me.GroupBoxViewCustomerEnd.Padding = New System.Windows.Forms.Padding(45, 39, 45, 39)
        Me.GroupBoxViewCustomerEnd.PaintGroupBox = False
        Me.GroupBoxViewCustomerEnd.RoundCorners = 10
        Me.GroupBoxViewCustomerEnd.ShadowColor = System.Drawing.Color.DarkGray
        Me.GroupBoxViewCustomerEnd.ShadowControl = True
        Me.GroupBoxViewCustomerEnd.ShadowThickness = 3
        Me.GroupBoxViewCustomerEnd.Size = New System.Drawing.Size(973, 499)
        Me.GroupBoxViewCustomerEnd.TabIndex = 25
        '
        'lblServe
        '
        Me.lblServe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblServe.Location = New System.Drawing.Point(178, 467)
        Me.lblServe.Name = "lblServe"
        Me.lblServe.Size = New System.Drawing.Size(52, 18)
        Me.lblServe.TabIndex = 38
        Me.lblServe.Text = "0"
        Me.lblServe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 467)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 18)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Total customer served."
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 467)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 18)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Queue"
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Counter_name, Me.DataGridViewTextBoxColumn1, Me.requisition_type_name, Me.patent_type_name, Me.service, Me.waiting_time, Me.served_time, Me.Status_name, Me.total_waiting_time, Me.row})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid.DefaultCellStyle = DataGridViewCellStyle2
        Me.Grid.Location = New System.Drawing.Point(15, 57)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.ShowCellErrors = False
        Me.Grid.ShowCellToolTips = False
        Me.Grid.ShowEditingIcon = False
        Me.Grid.Size = New System.Drawing.Size(940, 405)
        Me.Grid.TabIndex = 32
        '
        'cbUser
        '
        Me.cbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUser.FormattingEnabled = True
        Me.cbUser.Location = New System.Drawing.Point(15, 23)
        Me.cbUser.Margin = New System.Windows.Forms.Padding(4)
        Me.cbUser.Name = "cbUser"
        Me.cbUser.Size = New System.Drawing.Size(276, 26)
        Me.cbUser.TabIndex = 31
        '
        'Counter_name
        '
        Me.Counter_name.DataPropertyName = "Counter_name"
        Me.Counter_name.HeaderText = "Counter"
        Me.Counter_name.Name = "Counter_name"
        Me.Counter_name.ReadOnly = True
        Me.Counter_name.Width = 110
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "app_no"
        Me.DataGridViewTextBoxColumn1.HeaderText = "App No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 105
        '
        'requisition_type_name
        '
        Me.requisition_type_name.DataPropertyName = "requisition_type_name"
        Me.requisition_type_name.HeaderText = "Requisition Type"
        Me.requisition_type_name.Name = "requisition_type_name"
        Me.requisition_type_name.ReadOnly = True
        Me.requisition_type_name.Width = 200
        '
        'patent_type_name
        '
        Me.patent_type_name.DataPropertyName = "patent_type_name"
        Me.patent_type_name.HeaderText = "Patent Type"
        Me.patent_type_name.Name = "patent_type_name"
        Me.patent_type_name.ReadOnly = True
        Me.patent_type_name.Visible = False
        Me.patent_type_name.Width = 110
        '
        'service
        '
        Me.service.DataPropertyName = "service"
        Me.service.HeaderText = "Service"
        Me.service.Name = "service"
        Me.service.ReadOnly = True
        Me.service.Width = 250
        '
        'waiting_time
        '
        Me.waiting_time.DataPropertyName = "waiting_time"
        Me.waiting_time.HeaderText = "Waiting Time"
        Me.waiting_time.Name = "waiting_time"
        Me.waiting_time.ReadOnly = True
        Me.waiting_time.Width = 120
        '
        'served_time
        '
        Me.served_time.DataPropertyName = "served_time"
        Me.served_time.HeaderText = "Handling Time"
        Me.served_time.Name = "served_time"
        Me.served_time.ReadOnly = True
        Me.served_time.Width = 130
        '
        'Status_name
        '
        Me.Status_name.DataPropertyName = "Status_name"
        Me.Status_name.HeaderText = "Status"
        Me.Status_name.Name = "Status_name"
        Me.Status_name.ReadOnly = True
        Me.Status_name.Width = 117
        '
        'total_waiting_time
        '
        Me.total_waiting_time.DataPropertyName = "total_waiting_time"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.total_waiting_time.DefaultCellStyle = DataGridViewCellStyle1
        Me.total_waiting_time.HeaderText = "TotalWaiting"
        Me.total_waiting_time.Name = "total_waiting_time"
        Me.total_waiting_time.ReadOnly = True
        Me.total_waiting_time.Width = 150
        '
        'row
        '
        Me.row.DataPropertyName = "row"
        Me.row.HeaderText = "row"
        Me.row.Name = "row"
        Me.row.ReadOnly = True
        Me.row.Visible = False
        '
        'frmDailyHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 501)
        Me.Controls.Add(Me.GroupBoxViewCustomerEnd)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDailyHistory"
        Me.ShowInTaskbar = False
        Me.Text = "Daily History"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBoxViewCustomerEnd.ResumeLayout(False)
        Me.GroupBoxViewCustomerEnd.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxViewCustomerEnd As CodeVendor.Controls.Grouper
    Friend WithEvents cbUser As System.Windows.Forms.ComboBox
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents lblServe As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Counter_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents requisition_type_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patent_type_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents service As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents waiting_time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents served_time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total_waiting_time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents row As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
