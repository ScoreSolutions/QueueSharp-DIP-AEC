<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSkill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSkill))
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.GroupBoxButton = New CodeVendor.Controls.Grouper()
        Me.cbActive = New System.Windows.Forms.CheckBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Grouper1 = New CodeVendor.Controls.Grouper()
        Me.cbSearch = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ColorPicker = New System.Windows.Forms.ColorDialog()
        Me.Grouper2 = New CodeVendor.Controls.Grouper()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GridItem = New System.Windows.Forms.DataGridView()
        Me.service_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cb = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.item_name_th = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbRequisitionType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.skill_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Requisition_Type_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ms_requisition_type_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.appointment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.active_status = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.master_skillid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxButton.SuspendLayout()
        Me.Grouper1.SuspendLayout()
        Me.Grouper2.SuspendLayout()
        CType(Me.GridItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtName.Location = New System.Drawing.Point(131, 26)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(327, 24)
        Me.txtName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Skill Name :"
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
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.skill_name, Me.Requisition_Type_Name, Me.id, Me.ms_requisition_type_id, Me.appointment, Me.active_status, Me.status, Me.master_skillid})
        Me.Grid.Location = New System.Drawing.Point(9, 52)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(449, 225)
        Me.Grid.TabIndex = 11
        '
        'GroupBoxButton
        '
        Me.GroupBoxButton.BackgroundColor = System.Drawing.Color.White
        Me.GroupBoxButton.BackgroundGradientColor = System.Drawing.Color.SkyBlue
        Me.GroupBoxButton.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.GroupBoxButton.BorderColor = System.Drawing.Color.SteelBlue
        Me.GroupBoxButton.BorderThickness = 1.0!
        Me.GroupBoxButton.Controls.Add(Me.Label1)
        Me.GroupBoxButton.Controls.Add(Me.cmbRequisitionType)
        Me.GroupBoxButton.Controls.Add(Me.cbActive)
        Me.GroupBoxButton.Controls.Add(Me.txtID)
        Me.GroupBoxButton.Controls.Add(Me.btnCancel)
        Me.GroupBoxButton.Controls.Add(Me.btnAdd)
        Me.GroupBoxButton.Controls.Add(Me.Label2)
        Me.GroupBoxButton.Controls.Add(Me.btnSave)
        Me.GroupBoxButton.Controls.Add(Me.txtName)
        Me.GroupBoxButton.CustomGroupBoxColor = System.Drawing.Color.White
        Me.GroupBoxButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBoxButton.GroupImage = Nothing
        Me.GroupBoxButton.GroupTitle = ""
        Me.GroupBoxButton.Location = New System.Drawing.Point(6, -2)
        Me.GroupBoxButton.MinimumSize = New System.Drawing.Size(1, 1)
        Me.GroupBoxButton.Name = "GroupBoxButton"
        Me.GroupBoxButton.Padding = New System.Windows.Forms.Padding(20)
        Me.GroupBoxButton.PaintGroupBox = False
        Me.GroupBoxButton.RoundCorners = 10
        Me.GroupBoxButton.ShadowColor = System.Drawing.Color.DarkGray
        Me.GroupBoxButton.ShadowControl = True
        Me.GroupBoxButton.ShadowThickness = 3
        Me.GroupBoxButton.Size = New System.Drawing.Size(471, 165)
        Me.GroupBoxButton.TabIndex = 24
        '
        'cbActive
        '
        Me.cbActive.AutoSize = True
        Me.cbActive.Enabled = False
        Me.cbActive.Location = New System.Drawing.Point(131, 90)
        Me.cbActive.Name = "cbActive"
        Me.cbActive.Size = New System.Drawing.Size(66, 22)
        Me.cbActive.TabIndex = 7
        Me.cbActive.Text = "Active"
        Me.cbActive.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtID.Location = New System.Drawing.Point(11, 125)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(56, 24)
        Me.txtID.TabIndex = 15
        Me.txtID.Text = "0"
        Me.txtID.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Image = Global.QueueSharp.My.Resources.Resources.Close
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(323, 117)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 40)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnAdd.Image = Global.QueueSharp.My.Resources.Resources.Add
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(131, 117)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 40)
        Me.btnAdd.TabIndex = 8
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
        Me.btnSave.Location = New System.Drawing.Point(227, 117)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 40)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Grouper1
        '
        Me.Grouper1.BackgroundColor = System.Drawing.Color.White
        Me.Grouper1.BackgroundGradientColor = System.Drawing.Color.SkyBlue
        Me.Grouper1.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.Grouper1.BorderColor = System.Drawing.Color.SteelBlue
        Me.Grouper1.BorderThickness = 1.0!
        Me.Grouper1.Controls.Add(Me.cbSearch)
        Me.Grouper1.Controls.Add(Me.Label3)
        Me.Grouper1.Controls.Add(Me.txtSearch)
        Me.Grouper1.Controls.Add(Me.Grid)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(6, 157)
        Me.Grouper1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(471, 289)
        Me.Grouper1.TabIndex = 25
        '
        'cbSearch
        '
        Me.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearch.FormattingEnabled = True
        Me.cbSearch.Items.AddRange(New Object() {"All", "Active", "Inactive"})
        Me.cbSearch.Location = New System.Drawing.Point(298, 18)
        Me.cbSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSearch.Name = "cbSearch"
        Me.cbSearch.Size = New System.Drawing.Size(160, 26)
        Me.cbSearch.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 18)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Search :"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(75, 19)
        Me.txtSearch.MaxLength = 100
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(216, 24)
        Me.txtSearch.TabIndex = 9
        '
        'Grouper2
        '
        Me.Grouper2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Grouper2.BackgroundColor = System.Drawing.Color.White
        Me.Grouper2.BackgroundGradientColor = System.Drawing.Color.SkyBlue
        Me.Grouper2.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.ForwardDiagonal
        Me.Grouper2.BorderColor = System.Drawing.Color.SteelBlue
        Me.Grouper2.BorderThickness = 1.0!
        Me.Grouper2.Controls.Add(Me.Label10)
        Me.Grouper2.Controls.Add(Me.GridItem)
        Me.Grouper2.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Grouper2.GroupImage = Nothing
        Me.Grouper2.GroupTitle = ""
        Me.Grouper2.Location = New System.Drawing.Point(483, -2)
        Me.Grouper2.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Grouper2.Name = "Grouper2"
        Me.Grouper2.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper2.PaintGroupBox = False
        Me.Grouper2.RoundCorners = 10
        Me.Grouper2.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper2.ShadowControl = True
        Me.Grouper2.ShadowThickness = 3
        Me.Grouper2.Size = New System.Drawing.Size(410, 448)
        Me.Grouper2.TabIndex = 37
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(377, 24)
        Me.Label10.TabIndex = 40
        Me.Label10.Text = "Service"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GridItem
        '
        Me.GridItem.AllowUserToAddRows = False
        Me.GridItem.AllowUserToDeleteRows = False
        Me.GridItem.AllowUserToResizeColumns = False
        Me.GridItem.AllowUserToResizeRows = False
        Me.GridItem.BackgroundColor = System.Drawing.Color.LightGray
        Me.GridItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridItem.ColumnHeadersVisible = False
        Me.GridItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.service_id, Me.cb, Me.item_name_th})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridItem.DefaultCellStyle = DataGridViewCellStyle2
        Me.GridItem.Enabled = False
        Me.GridItem.Location = New System.Drawing.Point(19, 44)
        Me.GridItem.MultiSelect = False
        Me.GridItem.Name = "GridItem"
        Me.GridItem.RowHeadersVisible = False
        Me.GridItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridItem.Size = New System.Drawing.Size(374, 390)
        Me.GridItem.TabIndex = 39
        '
        'service_id
        '
        Me.service_id.DataPropertyName = "id"
        Me.service_id.HeaderText = "item_id"
        Me.service_id.Name = "service_id"
        Me.service_id.Visible = False
        Me.service_id.Width = 5
        '
        'cb
        '
        Me.cb.HeaderText = "cb"
        Me.cb.Name = "cb"
        Me.cb.Width = 20
        '
        'item_name_th
        '
        Me.item_name_th.DataPropertyName = "item_name_th"
        Me.item_name_th.HeaderText = "item_name"
        Me.item_name_th.Name = "item_name_th"
        Me.item_name_th.ReadOnly = True
        Me.item_name_th.Width = 300
        '
        'cmbRequisitionType
        '
        Me.cmbRequisitionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRequisitionType.Enabled = False
        Me.cmbRequisitionType.FormattingEnabled = True
        Me.cmbRequisitionType.Location = New System.Drawing.Point(131, 58)
        Me.cmbRequisitionType.Name = "cmbRequisitionType"
        Me.cmbRequisitionType.Size = New System.Drawing.Size(327, 26)
        Me.cmbRequisitionType.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 18)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Requisition Type :"
        '
        'skill_name
        '
        Me.skill_name.DataPropertyName = "skill_name"
        Me.skill_name.FillWeight = 194.9239!
        Me.skill_name.HeaderText = "Skill Name"
        Me.skill_name.Name = "skill_name"
        Me.skill_name.ReadOnly = True
        Me.skill_name.Width = 180
        '
        'Requisition_Type_Name
        '
        Me.Requisition_Type_Name.DataPropertyName = "Requisition_Type_Name"
        Me.Requisition_Type_Name.HeaderText = "Requisition Type"
        Me.Requisition_Type_Name.Name = "Requisition_Type_Name"
        Me.Requisition_Type_Name.ReadOnly = True
        Me.Requisition_Type_Name.Width = 180
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'ms_requisition_type_id
        '
        Me.ms_requisition_type_id.DataPropertyName = "ms_requisition_type_id"
        Me.ms_requisition_type_id.HeaderText = "ms_requisition_type_id"
        Me.ms_requisition_type_id.Name = "ms_requisition_type_id"
        Me.ms_requisition_type_id.ReadOnly = True
        Me.ms_requisition_type_id.Visible = False
        '
        'appointment
        '
        Me.appointment.DataPropertyName = "appointment"
        Me.appointment.HeaderText = "appointment"
        Me.appointment.Name = "appointment"
        Me.appointment.ReadOnly = True
        Me.appointment.Visible = False
        '
        'active_status
        '
        Me.active_status.DataPropertyName = "active_status"
        Me.active_status.HeaderText = "Active"
        Me.active_status.Name = "active_status"
        Me.active_status.ReadOnly = True
        Me.active_status.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.active_status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.active_status.Visible = False
        Me.active_status.Width = 80
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.status.DefaultCellStyle = DataGridViewCellStyle1
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Width = 80
        '
        'master_skillid
        '
        Me.master_skillid.DataPropertyName = "master_skillid"
        Me.master_skillid.HeaderText = ""
        Me.master_skillid.Name = "master_skillid"
        Me.master_skillid.ReadOnly = True
        Me.master_skillid.Visible = False
        '
        'frmSkill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(905, 450)
        Me.Controls.Add(Me.Grouper2)
        Me.Controls.Add(Me.GroupBoxButton)
        Me.Controls.Add(Me.Grouper1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSkill"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Skill"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxButton.ResumeLayout(False)
        Me.GroupBoxButton.PerformLayout()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        Me.Grouper2.ResumeLayout(False)
        CType(Me.GridItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBoxButton As CodeVendor.Controls.Grouper
    Friend WithEvents Grouper1 As CodeVendor.Controls.Grouper
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbActive As System.Windows.Forms.CheckBox
    Friend WithEvents cbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents ColorPicker As System.Windows.Forms.ColorDialog
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Grouper2 As CodeVendor.Controls.Grouper
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GridItem As System.Windows.Forms.DataGridView
    Friend WithEvents service_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cb As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents item_name_th As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbRequisitionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents skill_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Requisition_Type_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ms_requisition_type_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents appointment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents active_status As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents master_skillid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
