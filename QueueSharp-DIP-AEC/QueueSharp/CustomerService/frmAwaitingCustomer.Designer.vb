﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAwaitingCustomer
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBoxViewCustomerEnd = New CodeVendor.Controls.Grouper()
        Me.GridWait = New System.Windows.Forms.DataGridView()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.item_name_th = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cuswait = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaxWaitingTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label05 = New System.Windows.Forms.Label()
        Me.nudTime = New System.Windows.Forms.NumericUpDown()
        Me.ButRefresh = New System.Windows.Forms.Button()
        Me.CheckTimer = New System.Windows.Forms.CheckBox()
        Me.timerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisition_type_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.patent_type_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tb_register_queue_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancelQueue = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBoxViewCustomerEnd.SuspendLayout()
        CType(Me.GridWait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTime, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.GridWait)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.Grid)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.Label05)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.nudTime)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.ButRefresh)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.CheckTimer)
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
        Me.GroupBoxViewCustomerEnd.Size = New System.Drawing.Size(1027, 499)
        Me.GroupBoxViewCustomerEnd.TabIndex = 25
        '
        'GridWait
        '
        Me.GridWait.AllowUserToAddRows = False
        Me.GridWait.AllowUserToDeleteRows = False
        Me.GridWait.AllowUserToResizeRows = False
        Me.GridWait.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridWait.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridWait.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.app_no, Me.requisition_type_name, Me.patent_type_name, Me.tb_register_queue_id, Me.colCancelQueue})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridWait.DefaultCellStyle = DataGridViewCellStyle1
        Me.GridWait.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.GridWait.Location = New System.Drawing.Point(523, 21)
        Me.GridWait.Margin = New System.Windows.Forms.Padding(4)
        Me.GridWait.MultiSelect = False
        Me.GridWait.Name = "GridWait"
        Me.GridWait.ReadOnly = True
        Me.GridWait.RowHeadersVisible = False
        Me.GridWait.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GridWait.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridWait.ShowCellErrors = False
        Me.GridWait.ShowCellToolTips = False
        Me.GridWait.ShowEditingIcon = False
        Me.GridWait.Size = New System.Drawing.Size(490, 463)
        Me.GridWait.TabIndex = 31
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_name_th, Me.id, Me.cuswait, Me.MaxWaitingTime})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grid.Location = New System.Drawing.Point(10, 21)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.ShowCellErrors = False
        Me.Grid.ShowCellToolTips = False
        Me.Grid.ShowEditingIcon = False
        Me.Grid.Size = New System.Drawing.Size(505, 463)
        Me.Grid.TabIndex = 30
        '
        'item_name_th
        '
        Me.item_name_th.DataPropertyName = "item_name_th"
        Me.item_name_th.HeaderText = "Service"
        Me.item_name_th.Name = "item_name_th"
        Me.item_name_th.ReadOnly = True
        Me.item_name_th.Width = 200
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'cuswait
        '
        Me.cuswait.DataPropertyName = "cuswait"
        Me.cuswait.HeaderText = "Num. of Item."
        Me.cuswait.Name = "cuswait"
        Me.cuswait.ReadOnly = True
        Me.cuswait.Width = 120
        '
        'MaxWaitingTime
        '
        Me.MaxWaitingTime.DataPropertyName = "waiting_time"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.MaxWaitingTime.DefaultCellStyle = DataGridViewCellStyle2
        Me.MaxWaitingTime.HeaderText = "Max W.T"
        Me.MaxWaitingTime.Name = "MaxWaitingTime"
        Me.MaxWaitingTime.ReadOnly = True
        Me.MaxWaitingTime.Width = 150
        '
        'Label05
        '
        Me.Label05.AutoSize = True
        Me.Label05.BackColor = System.Drawing.Color.Transparent
        Me.Label05.Location = New System.Drawing.Point(348, 27)
        Me.Label05.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label05.Name = "Label05"
        Me.Label05.Size = New System.Drawing.Size(65, 18)
        Me.Label05.TabIndex = 28
        Me.Label05.Text = "seconds"
        Me.Label05.Visible = False
        '
        'nudTime
        '
        Me.nudTime.Location = New System.Drawing.Point(280, 25)
        Me.nudTime.Margin = New System.Windows.Forms.Padding(4)
        Me.nudTime.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudTime.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudTime.Name = "nudTime"
        Me.nudTime.Size = New System.Drawing.Size(62, 24)
        Me.nudTime.TabIndex = 29
        Me.nudTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudTime.Value = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudTime.Visible = False
        '
        'ButRefresh
        '
        Me.ButRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.ButRefresh.Location = New System.Drawing.Point(14, 21)
        Me.ButRefresh.Margin = New System.Windows.Forms.Padding(4)
        Me.ButRefresh.Name = "ButRefresh"
        Me.ButRefresh.Size = New System.Drawing.Size(112, 32)
        Me.ButRefresh.TabIndex = 26
        Me.ButRefresh.Text = "Refresh"
        Me.ButRefresh.UseVisualStyleBackColor = True
        Me.ButRefresh.Visible = False
        '
        'CheckTimer
        '
        Me.CheckTimer.AutoSize = True
        Me.CheckTimer.Location = New System.Drawing.Point(134, 26)
        Me.CheckTimer.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckTimer.Name = "CheckTimer"
        Me.CheckTimer.Size = New System.Drawing.Size(145, 22)
        Me.CheckTimer.TabIndex = 27
        Me.CheckTimer.Text = "Update data every"
        Me.CheckTimer.UseVisualStyleBackColor = True
        Me.CheckTimer.Visible = False
        '
        'timerRefresh
        '
        Me.timerRefresh.Enabled = True
        Me.timerRefresh.Interval = 10000
        '
        'app_no
        '
        Me.app_no.DataPropertyName = "app_no"
        Me.app_no.FillWeight = 71.75085!
        Me.app_no.HeaderText = "App No"
        Me.app_no.Name = "app_no"
        Me.app_no.ReadOnly = True
        '
        'requisition_type_name
        '
        Me.requisition_type_name.DataPropertyName = "requisition_type_name"
        Me.requisition_type_name.FillWeight = 75.32797!
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
        Me.patent_type_name.Width = 200
        '
        'tb_register_queue_id
        '
        Me.tb_register_queue_id.DataPropertyName = "tb_register_queue_id"
        Me.tb_register_queue_id.HeaderText = "tb_register_queue_id"
        Me.tb_register_queue_id.Name = "tb_register_queue_id"
        Me.tb_register_queue_id.ReadOnly = True
        Me.tb_register_queue_id.Visible = False
        '
        'colCancelQueue
        '
        Me.colCancelQueue.HeaderText = "Cancel Queue"
        Me.colCancelQueue.Name = "colCancelQueue"
        Me.colCancelQueue.ReadOnly = True
        Me.colCancelQueue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCancelQueue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCancelQueue.Text = "Cancel Queue"
        Me.colCancelQueue.UseColumnTextForButtonValue = True
        Me.colCancelQueue.Width = 150
        '
        'frmAwaitingCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1038, 501)
        Me.Controls.Add(Me.GroupBoxViewCustomerEnd)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmAwaitingCustomer"
        Me.ShowInTaskbar = False
        Me.Text = "Awaiting Customer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBoxViewCustomerEnd.ResumeLayout(False)
        Me.GroupBoxViewCustomerEnd.PerformLayout()
        CType(Me.GridWait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxViewCustomerEnd As CodeVendor.Controls.Grouper
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents Label05 As System.Windows.Forms.Label
    Friend WithEvents nudTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents ButRefresh As System.Windows.Forms.Button
    Friend WithEvents CheckTimer As System.Windows.Forms.CheckBox
    Friend WithEvents timerRefresh As System.Windows.Forms.Timer
    Friend WithEvents GridWait As System.Windows.Forms.DataGridView
    Friend WithEvents item_name_th As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cuswait As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxWaitingTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents requisition_type_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patent_type_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tb_register_queue_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancelQueue As System.Windows.Forms.DataGridViewButtonColumn
End Class
