<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCounter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCounter))
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.GroupBoxButton = New CodeVendor.Controls.Grouper()
        Me.GridSkill = New System.Windows.Forms.DataGridView()
        Me.skill_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cb = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.skill = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbCounterManager = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbQuick = New System.Windows.Forms.CheckBox()
        Me.cbActive = New System.Windows.Forms.CheckBox()
        Me.Grouper1 = New CodeVendor.Controls.Grouper()
        Me.cbSearch = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cbCounterQC = New System.Windows.Forms.CheckBox()
        Me.counter_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.counter_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.active_status = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.counter_manager = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.quickservice = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCounterQC = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxButton.SuspendLayout()
        CType(Me.GridSkill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grouper1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtID.Location = New System.Drawing.Point(368, 23)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(56, 24)
        Me.txtID.TabIndex = 15
        Me.txtID.Text = "0"
        Me.txtID.Visible = False
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtName.Location = New System.Drawing.Point(136, 50)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(243, 24)
        Me.txtName.TabIndex = 1
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtCode.Location = New System.Drawing.Point(136, 20)
        Me.txtCode.MaxLength = 20
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(127, 24)
        Me.txtCode.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Counter Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Counter Code :"
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
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.counter_code, Me.counter_name, Me.id, Me.active_status, Me.counter_manager, Me.quickservice, Me.colCounterQC, Me.status})
        Me.Grid.Location = New System.Drawing.Point(9, 50)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(837, 279)
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
        Me.GroupBoxButton.Controls.Add(Me.cbCounterQC)
        Me.GroupBoxButton.Controls.Add(Me.GridSkill)
        Me.GroupBoxButton.Controls.Add(Me.cbCounterManager)
        Me.GroupBoxButton.Controls.Add(Me.Label10)
        Me.GroupBoxButton.Controls.Add(Me.btnCancel)
        Me.GroupBoxButton.Controls.Add(Me.btnAdd)
        Me.GroupBoxButton.Controls.Add(Me.btnSave)
        Me.GroupBoxButton.Controls.Add(Me.cbQuick)
        Me.GroupBoxButton.Controls.Add(Me.cbActive)
        Me.GroupBoxButton.Controls.Add(Me.txtID)
        Me.GroupBoxButton.Controls.Add(Me.txtCode)
        Me.GroupBoxButton.Controls.Add(Me.Label1)
        Me.GroupBoxButton.Controls.Add(Me.Label2)
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
        Me.GroupBoxButton.Size = New System.Drawing.Size(859, 263)
        Me.GroupBoxButton.TabIndex = 24
        '
        'GridSkill
        '
        Me.GridSkill.AllowUserToAddRows = False
        Me.GridSkill.AllowUserToDeleteRows = False
        Me.GridSkill.AllowUserToResizeColumns = False
        Me.GridSkill.AllowUserToResizeRows = False
        Me.GridSkill.BackgroundColor = System.Drawing.Color.LightGray
        Me.GridSkill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridSkill.ColumnHeadersVisible = False
        Me.GridSkill.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.skill_id, Me.cb, Me.skill})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridSkill.DefaultCellStyle = DataGridViewCellStyle2
        Me.GridSkill.Enabled = False
        Me.GridSkill.Location = New System.Drawing.Point(466, 41)
        Me.GridSkill.MultiSelect = False
        Me.GridSkill.Name = "GridSkill"
        Me.GridSkill.RowHeadersVisible = False
        Me.GridSkill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridSkill.Size = New System.Drawing.Size(347, 205)
        Me.GridSkill.TabIndex = 39
        '
        'skill_id
        '
        Me.skill_id.DataPropertyName = "id"
        Me.skill_id.HeaderText = "skill_id"
        Me.skill_id.Name = "skill_id"
        Me.skill_id.ReadOnly = True
        Me.skill_id.Visible = False
        '
        'cb
        '
        Me.cb.FalseValue = "0"
        Me.cb.HeaderText = "cb"
        Me.cb.Name = "cb"
        Me.cb.TrueValue = "1"
        Me.cb.Width = 20
        '
        'skill
        '
        Me.skill.DataPropertyName = "skill_name"
        Me.skill.HeaderText = "skill"
        Me.skill.Name = "skill"
        Me.skill.ReadOnly = True
        Me.skill.Width = 250
        '
        'cbCounterManager
        '
        Me.cbCounterManager.AutoSize = True
        Me.cbCounterManager.Enabled = False
        Me.cbCounterManager.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.cbCounterManager.FlatAppearance.BorderSize = 0
        Me.cbCounterManager.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.cbCounterManager.Location = New System.Drawing.Point(253, 80)
        Me.cbCounterManager.Name = "cbCounterManager"
        Me.cbCounterManager.Size = New System.Drawing.Size(142, 22)
        Me.cbCounterManager.TabIndex = 51
        Me.cbCounterManager.Text = "Counter Manager"
        Me.cbCounterManager.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(463, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 18)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Skill"
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Image = Global.QueueSharp.My.Resources.Resources.Close
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(320, 139)
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
        Me.btnAdd.Location = New System.Drawing.Point(128, 139)
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
        Me.btnSave.Location = New System.Drawing.Point(224, 139)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 40)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbQuick
        '
        Me.cbQuick.AutoSize = True
        Me.cbQuick.Enabled = False
        Me.cbQuick.Location = New System.Drawing.Point(136, 80)
        Me.cbQuick.Name = "cbQuick"
        Me.cbQuick.Size = New System.Drawing.Size(119, 22)
        Me.cbQuick.TabIndex = 3
        Me.cbQuick.Text = "Quick Service"
        Me.cbQuick.UseVisualStyleBackColor = True
        '
        'cbActive
        '
        Me.cbActive.AutoSize = True
        Me.cbActive.Enabled = False
        Me.cbActive.Location = New System.Drawing.Point(253, 108)
        Me.cbActive.Name = "cbActive"
        Me.cbActive.Size = New System.Drawing.Size(66, 22)
        Me.cbActive.TabIndex = 6
        Me.cbActive.Text = "Active"
        Me.cbActive.UseVisualStyleBackColor = True
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
        Me.Grouper1.Controls.Add(Me.cbSearch)
        Me.Grouper1.Controls.Add(Me.Label4)
        Me.Grouper1.Controls.Add(Me.txtSearch)
        Me.Grouper1.Controls.Add(Me.Grid)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(6, 253)
        Me.Grouper1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(859, 339)
        Me.Grouper1.TabIndex = 25
        '
        'cbSearch
        '
        Me.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearch.FormattingEnabled = True
        Me.cbSearch.Items.AddRange(New Object() {"All", "Active", "Inactive"})
        Me.cbSearch.Location = New System.Drawing.Point(320, 17)
        Me.cbSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSearch.Name = "cbSearch"
        Me.cbSearch.Size = New System.Drawing.Size(140, 26)
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
        Me.txtSearch.Location = New System.Drawing.Point(77, 18)
        Me.txtSearch.MaxLength = 100
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(237, 24)
        Me.txtSearch.TabIndex = 18
        '
        'cbCounterQC
        '
        Me.cbCounterQC.AutoSize = True
        Me.cbCounterQC.Enabled = False
        Me.cbCounterQC.Location = New System.Drawing.Point(136, 108)
        Me.cbCounterQC.Name = "cbCounterQC"
        Me.cbCounterQC.Size = New System.Drawing.Size(107, 22)
        Me.cbCounterQC.TabIndex = 52
        Me.cbCounterQC.Text = "Counter QC"
        Me.cbCounterQC.UseVisualStyleBackColor = True
        '
        'counter_code
        '
        Me.counter_code.DataPropertyName = "counter_code"
        Me.counter_code.FillWeight = 28.24859!
        Me.counter_code.HeaderText = "Counter Code"
        Me.counter_code.Name = "counter_code"
        Me.counter_code.ReadOnly = True
        Me.counter_code.Width = 140
        '
        'counter_name
        '
        Me.counter_name.DataPropertyName = "counter_name"
        Me.counter_name.FillWeight = 171.7514!
        Me.counter_name.HeaderText = "Counter Name"
        Me.counter_name.Name = "counter_name"
        Me.counter_name.ReadOnly = True
        Me.counter_name.Width = 250
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
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
        'counter_manager
        '
        Me.counter_manager.DataPropertyName = "counter_manager"
        Me.counter_manager.FalseValue = "0"
        Me.counter_manager.HeaderText = "Counter Manager"
        Me.counter_manager.Name = "counter_manager"
        Me.counter_manager.ReadOnly = True
        Me.counter_manager.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.counter_manager.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.counter_manager.TrueValue = "1"
        Me.counter_manager.Width = 150
        '
        'quickservice
        '
        Me.quickservice.DataPropertyName = "quickservice"
        Me.quickservice.FalseValue = "0"
        Me.quickservice.HeaderText = "Quick Service"
        Me.quickservice.Name = "quickservice"
        Me.quickservice.ReadOnly = True
        Me.quickservice.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.quickservice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.quickservice.TrueValue = "1"
        Me.quickservice.Width = 120
        '
        'colCounterQC
        '
        Me.colCounterQC.DataPropertyName = "counter_qc"
        Me.colCounterQC.FalseValue = "0"
        Me.colCounterQC.HeaderText = "QC"
        Me.colCounterQC.Name = "colCounterQC"
        Me.colCounterQC.ReadOnly = True
        Me.colCounterQC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCounterQC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCounterQC.TrueValue = "1"
        Me.colCounterQC.Width = 50
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.status.DefaultCellStyle = DataGridViewCellStyle1
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        '
        'frmCounter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(869, 594)
        Me.Controls.Add(Me.GroupBoxButton)
        Me.Controls.Add(Me.Grouper1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCounter"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Counter"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxButton.ResumeLayout(False)
        Me.GroupBoxButton.PerformLayout()
        CType(Me.GridSkill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxButton As CodeVendor.Controls.Grouper
    Friend WithEvents Grouper1 As CodeVendor.Controls.Grouper
    Friend WithEvents cbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbActive As System.Windows.Forms.CheckBox
    Friend WithEvents cbQuick As System.Windows.Forms.CheckBox
    Friend WithEvents cbCounterManager As System.Windows.Forms.CheckBox
    Friend WithEvents GridSkill As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents skill_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cb As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents skill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbCounterQC As System.Windows.Forms.CheckBox
    Friend WithEvents counter_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents counter_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents active_status As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents counter_manager As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents quickservice As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCounterQC As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
