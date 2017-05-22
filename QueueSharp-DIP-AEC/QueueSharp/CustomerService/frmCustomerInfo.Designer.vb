<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerInfo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBoxViewCustomerEnd = New CodeVendor.Controls.Grouper()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.requisition_type_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.patent_type_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_name_th = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.Label1)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.txtSearch)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.Grid)
        Me.GroupBoxViewCustomerEnd.Controls.Add(Me.BtnSearch)
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
        Me.GroupBoxViewCustomerEnd.Size = New System.Drawing.Size(869, 499)
        Me.GroupBoxViewCustomerEnd.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 18)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "App No. "
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(78, 23)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(280, 24)
        Me.txtSearch.TabIndex = 31
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.app_no, Me.requisition_type_name, Me.patent_type_name, Me.item_name_th, Me.status_name})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grid.DefaultCellStyle = DataGridViewCellStyle1
        Me.Grid.Location = New System.Drawing.Point(15, 61)
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.ShowCellErrors = False
        Me.Grid.ShowCellToolTips = False
        Me.Grid.ShowEditingIcon = False
        Me.Grid.Size = New System.Drawing.Size(834, 419)
        Me.Grid.TabIndex = 30
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(365, 20)
        Me.BtnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(112, 32)
        Me.BtnSearch.TabIndex = 26
        Me.BtnSearch.Text = "Search"
        Me.BtnSearch.UseVisualStyleBackColor = True
        Me.BtnSearch.Visible = False
        '
        'app_no
        '
        Me.app_no.DataPropertyName = "app_no"
        Me.app_no.HeaderText = "App No"
        Me.app_no.Name = "app_no"
        Me.app_no.ReadOnly = True
        Me.app_no.Width = 150
        '
        'requisition_type_name
        '
        Me.requisition_type_name.DataPropertyName = "requisition_type_name"
        Me.requisition_type_name.HeaderText = "Requistion Type"
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
        Me.patent_type_name.Width = 200
        '
        'item_name_th
        '
        Me.item_name_th.DataPropertyName = "item_name_th"
        Me.item_name_th.HeaderText = "Service"
        Me.item_name_th.Name = "item_name_th"
        Me.item_name_th.ReadOnly = True
        Me.item_name_th.Width = 250
        '
        'status_name
        '
        Me.status_name.DataPropertyName = "status_name"
        Me.status_name.HeaderText = "Status"
        Me.status_name.Name = "status_name"
        Me.status_name.ReadOnly = True
        Me.status_name.Width = 150
        '
        'frmCustomerInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(880, 501)
        Me.Controls.Add(Me.GroupBoxViewCustomerEnd)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCustomerInfo"
        Me.ShowInTaskbar = False
        Me.Text = "Queue Information"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBoxViewCustomerEnd.ResumeLayout(False)
        Me.GroupBoxViewCustomerEnd.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxViewCustomerEnd As CodeVendor.Controls.Grouper
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents requisition_type_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patent_type_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item_name_th As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status_name As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
