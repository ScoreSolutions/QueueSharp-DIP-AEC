<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmService
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmService))
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.GroupBoxButton = New CodeVendor.Controls.Grouper()
        Me.chkInputKeyPageAfterEnd = New System.Windows.Forms.CheckBox()
        Me.chkInputScanPageAfterEnd = New System.Windows.Forms.CheckBox()
        Me.cbServeMultiple = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtItemOrder = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.nudWait = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtName_th = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudTime = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbInActive = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Grouper1 = New CodeVendor.Controls.Grouper()
        Me.btnOrder = New System.Windows.Forms.Button()
        Me.cbSearch = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.item_name_th = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item_order = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.std_ht = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.std_wt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.serve_multiple_queue = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.is_scan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.is_key = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.active_status = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxButton.SuspendLayout()
        CType(Me.nudWait, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grouper1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtID.Location = New System.Drawing.Point(704, 11)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(56, 24)
        Me.txtID.TabIndex = 15
        Me.txtID.Text = "0"
        Me.txtID.Visible = False
        '
        'Grid
        '
        Me.Grid.AllowUserToAddRows = False
        Me.Grid.AllowUserToDeleteRows = False
        Me.Grid.AllowUserToOrderColumns = True
        Me.Grid.AllowUserToResizeColumns = False
        Me.Grid.AllowUserToResizeRows = False
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item_name_th, Me.item_order, Me.std_ht, Me.std_wt, Me.id, Me.serve_multiple_queue, Me.is_scan, Me.is_key, Me.status, Me.active_status})
        Me.Grid.Location = New System.Drawing.Point(9, 49)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(945, 417)
        Me.Grid.TabIndex = 5
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
        Me.GroupBoxButton.Controls.Add(Me.chkInputKeyPageAfterEnd)
        Me.GroupBoxButton.Controls.Add(Me.chkInputScanPageAfterEnd)
        Me.GroupBoxButton.Controls.Add(Me.cbServeMultiple)
        Me.GroupBoxButton.Controls.Add(Me.Label19)
        Me.GroupBoxButton.Controls.Add(Me.Label18)
        Me.GroupBoxButton.Controls.Add(Me.Label17)
        Me.GroupBoxButton.Controls.Add(Me.txtItemOrder)
        Me.GroupBoxButton.Controls.Add(Me.Label13)
        Me.GroupBoxButton.Controls.Add(Me.nudWait)
        Me.GroupBoxButton.Controls.Add(Me.Label14)
        Me.GroupBoxButton.Controls.Add(Me.Label11)
        Me.GroupBoxButton.Controls.Add(Me.txtName_th)
        Me.GroupBoxButton.Controls.Add(Me.Label6)
        Me.GroupBoxButton.Controls.Add(Me.nudTime)
        Me.GroupBoxButton.Controls.Add(Me.Label7)
        Me.GroupBoxButton.Controls.Add(Me.cbInActive)
        Me.GroupBoxButton.Controls.Add(Me.txtID)
        Me.GroupBoxButton.Controls.Add(Me.btnCancel)
        Me.GroupBoxButton.Controls.Add(Me.btnAdd)
        Me.GroupBoxButton.Controls.Add(Me.btnSave)
        Me.GroupBoxButton.CustomGroupBoxColor = System.Drawing.Color.White
        Me.GroupBoxButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBoxButton.GroupImage = Nothing
        Me.GroupBoxButton.GroupTitle = ""
        Me.GroupBoxButton.Location = New System.Drawing.Point(6, -5)
        Me.GroupBoxButton.MinimumSize = New System.Drawing.Size(1, 1)
        Me.GroupBoxButton.Name = "GroupBoxButton"
        Me.GroupBoxButton.Padding = New System.Windows.Forms.Padding(20)
        Me.GroupBoxButton.PaintGroupBox = False
        Me.GroupBoxButton.RoundCorners = 10
        Me.GroupBoxButton.ShadowColor = System.Drawing.Color.DarkGray
        Me.GroupBoxButton.ShadowControl = True
        Me.GroupBoxButton.ShadowThickness = 3
        Me.GroupBoxButton.Size = New System.Drawing.Size(967, 224)
        Me.GroupBoxButton.TabIndex = 24
        '
        'chkInputKeyPageAfterEnd
        '
        Me.chkInputKeyPageAfterEnd.AutoSize = True
        Me.chkInputKeyPageAfterEnd.Enabled = False
        Me.chkInputKeyPageAfterEnd.Location = New System.Drawing.Point(447, 109)
        Me.chkInputKeyPageAfterEnd.Name = "chkInputKeyPageAfterEnd"
        Me.chkInputKeyPageAfterEnd.Size = New System.Drawing.Size(242, 22)
        Me.chkInputKeyPageAfterEnd.TabIndex = 70
        Me.chkInputKeyPageAfterEnd.Text = "Input Key Page After End Service"
        Me.chkInputKeyPageAfterEnd.UseVisualStyleBackColor = True
        '
        'chkInputScanPageAfterEnd
        '
        Me.chkInputScanPageAfterEnd.AutoSize = True
        Me.chkInputScanPageAfterEnd.Enabled = False
        Me.chkInputScanPageAfterEnd.Location = New System.Drawing.Point(190, 109)
        Me.chkInputScanPageAfterEnd.Name = "chkInputScanPageAfterEnd"
        Me.chkInputScanPageAfterEnd.Size = New System.Drawing.Size(251, 22)
        Me.chkInputScanPageAfterEnd.TabIndex = 69
        Me.chkInputScanPageAfterEnd.Text = "Input Scan Page After End Service"
        Me.chkInputScanPageAfterEnd.UseVisualStyleBackColor = True
        '
        'cbServeMultiple
        '
        Me.cbServeMultiple.AutoSize = True
        Me.cbServeMultiple.Enabled = False
        Me.cbServeMultiple.Location = New System.Drawing.Point(190, 81)
        Me.cbServeMultiple.Name = "cbServeMultiple"
        Me.cbServeMultiple.Size = New System.Drawing.Size(119, 22)
        Me.cbServeMultiple.TabIndex = 68
        Me.cbServeMultiple.Text = "Serve Multiple"
        Me.cbServeMultiple.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(148, 318)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(123, 18)
        Me.Label19.TabIndex = 67
        Me.Label19.Text = "XXX = Mobile No"
        Me.Label19.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(32, 318)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 18)
        Me.Label18.TabIndex = 66
        Me.Label18.Text = "URL :"
        Me.Label18.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(99, 54)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 18)
        Me.Label17.TabIndex = 64
        Me.Label17.Text = "Item Order :"
        '
        'txtItemOrder
        '
        Me.txtItemOrder.Enabled = False
        Me.txtItemOrder.Location = New System.Drawing.Point(190, 51)
        Me.txtItemOrder.MaxLength = 3
        Me.txtItemOrder.Name = "txtItemOrder"
        Me.txtItemOrder.Size = New System.Drawing.Size(63, 24)
        Me.txtItemOrder.TabIndex = 63
        Me.txtItemOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label13.Location = New System.Drawing.Point(608, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 18)
        Me.Label13.TabIndex = 58
        Me.Label13.Text = "Minute"
        '
        'nudWait
        '
        Me.nudWait.Enabled = False
        Me.nudWait.Location = New System.Drawing.Point(524, 78)
        Me.nudWait.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.nudWait.Name = "nudWait"
        Me.nudWait.Size = New System.Drawing.Size(78, 24)
        Me.nudWait.TabIndex = 4
        Me.nudWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudWait.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label14.Location = New System.Drawing.Point(349, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 18)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Standard Waiting  Time :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label11.Location = New System.Drawing.Point(53, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(135, 18)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "Item Name In Thai :"
        '
        'txtName_th
        '
        Me.txtName_th.Enabled = False
        Me.txtName_th.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtName_th.Location = New System.Drawing.Point(190, 21)
        Me.txtName_th.MaxLength = 255
        Me.txtName_th.Name = "txtName_th"
        Me.txtName_th.Size = New System.Drawing.Size(414, 24)
        Me.txtName_th.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label6.Location = New System.Drawing.Point(608, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 18)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Minute"
        '
        'nudTime
        '
        Me.nudTime.Enabled = False
        Me.nudTime.Location = New System.Drawing.Point(524, 52)
        Me.nudTime.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.nudTime.Name = "nudTime"
        Me.nudTime.Size = New System.Drawing.Size(78, 24)
        Me.nudTime.TabIndex = 3
        Me.nudTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudTime.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label7.Location = New System.Drawing.Point(345, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(173, 18)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Standard Handling Time :"
        '
        'cbInActive
        '
        Me.cbInActive.AutoSize = True
        Me.cbInActive.Enabled = False
        Me.cbInActive.Location = New System.Drawing.Point(190, 137)
        Me.cbInActive.Name = "cbInActive"
        Me.cbInActive.Size = New System.Drawing.Size(66, 22)
        Me.cbInActive.TabIndex = 9
        Me.cbInActive.Text = "Active"
        Me.cbInActive.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Image = Global.QueueSharp.My.Resources.Resources.Close
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(479, 167)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 40)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnAdd.Image = Global.QueueSharp.My.Resources.Resources.Add
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(287, 167)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 40)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnSave.Image = Global.QueueSharp.My.Resources.Resources.Save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(383, 167)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 40)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Grouper1
        '
        Me.Grouper1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grouper1.BackgroundColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientColor = System.Drawing.Color.SkyBlue
        Me.Grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.Grouper1.BorderColor = System.Drawing.Color.SteelBlue
        Me.Grouper1.BorderThickness = 1.0!
        Me.Grouper1.Controls.Add(Me.btnOrder)
        Me.Grouper1.Controls.Add(Me.cbSearch)
        Me.Grouper1.Controls.Add(Me.Label4)
        Me.Grouper1.Controls.Add(Me.txtSearch)
        Me.Grouper1.Controls.Add(Me.Grid)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(6, 211)
        Me.Grouper1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(967, 476)
        Me.Grouper1.TabIndex = 25
        '
        'btnOrder
        '
        Me.btnOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOrder.Location = New System.Drawing.Point(460, 17)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(102, 26)
        Me.btnOrder.TabIndex = 56
        Me.btnOrder.Text = "ReOrder"
        Me.btnOrder.UseVisualStyleBackColor = True
        '
        'cbSearch
        '
        Me.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearch.FormattingEnabled = True
        Me.cbSearch.Items.AddRange(New Object() {"All", "Active", "Inactive"})
        Me.cbSearch.Location = New System.Drawing.Point(331, 18)
        Me.cbSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSearch.Name = "cbSearch"
        Me.cbSearch.Size = New System.Drawing.Size(105, 26)
        Me.cbSearch.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 18)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Search :"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(74, 18)
        Me.txtSearch.MaxLength = 100
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(250, 24)
        Me.txtSearch.TabIndex = 18
        '
        'item_name_th
        '
        Me.item_name_th.DataPropertyName = "item_name_th"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.item_name_th.DefaultCellStyle = DataGridViewCellStyle1
        Me.item_name_th.HeaderText = "Name (TH)"
        Me.item_name_th.Name = "item_name_th"
        Me.item_name_th.ReadOnly = True
        Me.item_name_th.Width = 300
        '
        'item_order
        '
        Me.item_order.DataPropertyName = "item_order"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.item_order.DefaultCellStyle = DataGridViewCellStyle2
        Me.item_order.HeaderText = "Order"
        Me.item_order.Name = "item_order"
        Me.item_order.ReadOnly = True
        Me.item_order.Width = 70
        '
        'std_ht
        '
        Me.std_ht.DataPropertyName = "std_ht"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.NullValue = Nothing
        Me.std_ht.DefaultCellStyle = DataGridViewCellStyle3
        Me.std_ht.HeaderText = "Std. H.T"
        Me.std_ht.Name = "std_ht"
        Me.std_ht.ReadOnly = True
        Me.std_ht.Width = 85
        '
        'std_wt
        '
        Me.std_wt.DataPropertyName = "std_wt"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.std_wt.DefaultCellStyle = DataGridViewCellStyle4
        Me.std_wt.HeaderText = "Std. W.T"
        Me.std_wt.Name = "std_wt"
        Me.std_wt.ReadOnly = True
        Me.std_wt.Width = 90
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'serve_multiple_queue
        '
        Me.serve_multiple_queue.DataPropertyName = "serve_multiple_queue"
        Me.serve_multiple_queue.FalseValue = "N"
        Me.serve_multiple_queue.HeaderText = "Save Multiple"
        Me.serve_multiple_queue.Name = "serve_multiple_queue"
        Me.serve_multiple_queue.ReadOnly = True
        Me.serve_multiple_queue.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.serve_multiple_queue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.serve_multiple_queue.TrueValue = "Y"
        '
        'is_scan
        '
        Me.is_scan.DataPropertyName = "is_scan"
        Me.is_scan.HeaderText = "Scan"
        Me.is_scan.Name = "is_scan"
        Me.is_scan.ReadOnly = True
        '
        'is_key
        '
        Me.is_key.DataPropertyName = "is_key"
        Me.is_key.HeaderText = "Key"
        Me.is_key.Name = "is_key"
        Me.is_key.ReadOnly = True
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.status.DefaultCellStyle = DataGridViewCellStyle5
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Width = 80
        '
        'active_status
        '
        Me.active_status.DataPropertyName = "active_status"
        Me.active_status.FalseValue = "0"
        Me.active_status.HeaderText = "active_status"
        Me.active_status.Name = "active_status"
        Me.active_status.ReadOnly = True
        Me.active_status.TrueValue = "1"
        Me.active_status.Visible = False
        '
        'frmService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(978, 689)
        Me.Controls.Add(Me.GroupBoxButton)
        Me.Controls.Add(Me.Grouper1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmService"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Service"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxButton.ResumeLayout(False)
        Me.GroupBoxButton.PerformLayout()
        CType(Me.nudWait, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxButton As CodeVendor.Controls.Grouper
    Friend WithEvents Grouper1 As CodeVendor.Controls.Grouper
    Friend WithEvents cbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbInActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtName_th As System.Windows.Forms.TextBox
    Friend WithEvents btnOrder As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents nudWait As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtItemOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbServeMultiple As System.Windows.Forms.CheckBox
    Friend WithEvents chkInputKeyPageAfterEnd As System.Windows.Forms.CheckBox
    Friend WithEvents chkInputScanPageAfterEnd As System.Windows.Forms.CheckBox
    Friend WithEvents item_name_th As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item_order As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents std_ht As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents std_wt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents serve_multiple_queue As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents is_scan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents is_key As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents active_status As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
