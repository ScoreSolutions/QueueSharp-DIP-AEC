<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtFname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.group_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ms_title_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ms_group_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.password = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.active_status = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBoxButton = New CodeVendor.Controls.Grouper()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtRePassword = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbGroup = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbTitel = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.cbActive = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Grouper1 = New CodeVendor.Controls.Grouper()
        Me.cbSearch = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxButton.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Grouper1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtID.Location = New System.Drawing.Point(339, 145)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(56, 24)
        Me.txtID.TabIndex = 15
        Me.txtID.Visible = False
        '
        'txtFname
        '
        Me.txtFname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFname.Enabled = False
        Me.txtFname.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtFname.Location = New System.Drawing.Point(117, 87)
        Me.txtFname.MaxLength = 50
        Me.txtFname.Name = "txtFname"
        Me.txtFname.Size = New System.Drawing.Size(200, 24)
        Me.txtFname.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(59, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Name :"
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
        Me.Grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.group_name, Me.user_code, Me.fullname, Me.username, Me.ms_title_id, Me.fname, Me.lname, Me.ms_group_id, Me.password, Me.id, Me.active_status, Me.status})
        Me.Grid.Location = New System.Drawing.Point(9, 52)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(864, 305)
        Me.Grid.TabIndex = 11
        '
        'group_name
        '
        Me.group_name.DataPropertyName = "group_name"
        Me.group_name.HeaderText = "Group"
        Me.group_name.Name = "group_name"
        Me.group_name.ReadOnly = True
        Me.group_name.Width = 140
        '
        'user_code
        '
        Me.user_code.DataPropertyName = "user_code"
        Me.user_code.FillWeight = 5.076141!
        Me.user_code.HeaderText = "User Code"
        Me.user_code.Name = "user_code"
        Me.user_code.ReadOnly = True
        Me.user_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.user_code.Visible = False
        Me.user_code.Width = 140
        '
        'fullname
        '
        Me.fullname.DataPropertyName = "fullname"
        Me.fullname.FillWeight = 194.9239!
        Me.fullname.HeaderText = "Name"
        Me.fullname.Name = "fullname"
        Me.fullname.ReadOnly = True
        Me.fullname.Width = 300
        '
        'username
        '
        Me.username.DataPropertyName = "username"
        Me.username.HeaderText = "Username"
        Me.username.Name = "username"
        Me.username.ReadOnly = True
        Me.username.Width = 140
        '
        'ms_title_id
        '
        Me.ms_title_id.DataPropertyName = "ms_title_id"
        Me.ms_title_id.HeaderText = "title_id"
        Me.ms_title_id.Name = "ms_title_id"
        Me.ms_title_id.ReadOnly = True
        Me.ms_title_id.Visible = False
        '
        'fname
        '
        Me.fname.DataPropertyName = "fname"
        Me.fname.HeaderText = "fname"
        Me.fname.Name = "fname"
        Me.fname.ReadOnly = True
        Me.fname.Visible = False
        '
        'lname
        '
        Me.lname.DataPropertyName = "lname"
        Me.lname.HeaderText = "lname"
        Me.lname.Name = "lname"
        Me.lname.ReadOnly = True
        Me.lname.Visible = False
        '
        'ms_group_id
        '
        Me.ms_group_id.DataPropertyName = "ms_group_id"
        Me.ms_group_id.HeaderText = "group_id"
        Me.ms_group_id.Name = "ms_group_id"
        Me.ms_group_id.ReadOnly = True
        Me.ms_group_id.Visible = False
        '
        'password
        '
        Me.password.DataPropertyName = "password"
        Me.password.HeaderText = "password"
        Me.password.Name = "password"
        Me.password.ReadOnly = True
        Me.password.Visible = False
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
        'status
        '
        Me.status.DataPropertyName = "status"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.status.DefaultCellStyle = DataGridViewCellStyle1
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
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
        Me.GroupBoxButton.Controls.Add(Me.Panel1)
        Me.GroupBoxButton.Controls.Add(Me.cbGroup)
        Me.GroupBoxButton.Controls.Add(Me.Label6)
        Me.GroupBoxButton.Controls.Add(Me.Label4)
        Me.GroupBoxButton.Controls.Add(Me.cbTitel)
        Me.GroupBoxButton.Controls.Add(Me.Label5)
        Me.GroupBoxButton.Controls.Add(Me.txtLname)
        Me.GroupBoxButton.Controls.Add(Me.cbActive)
        Me.GroupBoxButton.Controls.Add(Me.txtID)
        Me.GroupBoxButton.Controls.Add(Me.btnCancel)
        Me.GroupBoxButton.Controls.Add(Me.btnAdd)
        Me.GroupBoxButton.Controls.Add(Me.Label2)
        Me.GroupBoxButton.Controls.Add(Me.btnSave)
        Me.GroupBoxButton.Controls.Add(Me.txtFname)
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
        Me.GroupBoxButton.Size = New System.Drawing.Size(886, 229)
        Me.GroupBoxButton.TabIndex = 24
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtRePassword)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtUsername)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(339, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(319, 119)
        Me.Panel1.TabIndex = 36
        '
        'txtRePassword
        '
        Me.txtRePassword.Enabled = False
        Me.txtRePassword.Location = New System.Drawing.Point(139, 77)
        Me.txtRePassword.MaxLength = 20
        Me.txtRePassword.Name = "txtRePassword"
        Me.txtRePassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtRePassword.Size = New System.Drawing.Size(167, 24)
        Me.txtRePassword.TabIndex = 34
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 18)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Re Password :"
        '
        'txtUsername
        '
        Me.txtUsername.Enabled = False
        Me.txtUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtUsername.Location = New System.Drawing.Point(139, 13)
        Me.txtUsername.MaxLength = 20
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(167, 24)
        Me.txtUsername.TabIndex = 30
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label8.Location = New System.Drawing.Point(35, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 18)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "User Name :"
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Location = New System.Drawing.Point(139, 47)
        Me.txtPassword.MaxLength = 20
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(167, 24)
        Me.txtPassword.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 18)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Password :"
        '
        'cbGroup
        '
        Me.cbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGroup.Enabled = False
        Me.cbGroup.FormattingEnabled = True
        Me.cbGroup.Location = New System.Drawing.Point(117, 23)
        Me.cbGroup.Name = "cbGroup"
        Me.cbGroup.Size = New System.Drawing.Size(192, 26)
        Me.cbGroup.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(53, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 18)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Group :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 18)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Title Name :"
        '
        'cbTitel
        '
        Me.cbTitel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTitel.Enabled = False
        Me.cbTitel.FormattingEnabled = True
        Me.cbTitel.Location = New System.Drawing.Point(117, 55)
        Me.cbTitel.Name = "cbTitel"
        Me.cbTitel.Size = New System.Drawing.Size(78, 26)
        Me.cbTitel.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 18)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Surname :"
        '
        'txtLname
        '
        Me.txtLname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLname.Enabled = False
        Me.txtLname.Location = New System.Drawing.Point(117, 117)
        Me.txtLname.MaxLength = 50
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(200, 24)
        Me.txtLname.TabIndex = 2
        '
        'cbActive
        '
        Me.cbActive.AutoSize = True
        Me.cbActive.Checked = True
        Me.cbActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbActive.Enabled = False
        Me.cbActive.Location = New System.Drawing.Point(117, 147)
        Me.cbActive.Name = "cbActive"
        Me.cbActive.Size = New System.Drawing.Size(66, 22)
        Me.cbActive.TabIndex = 5
        Me.cbActive.Text = "Active"
        Me.cbActive.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Enabled = False
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCancel.Image = Global.QueueSharp.My.Resources.Resources.Close
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(533, 175)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 40)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnAdd.Image = Global.QueueSharp.My.Resources.Resources.Add
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(339, 175)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(91, 40)
        Me.btnAdd.TabIndex = 6
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
        Me.btnSave.Location = New System.Drawing.Point(436, 175)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 40)
        Me.btnSave.TabIndex = 7
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
        Me.Grouper1.Controls.Add(Me.cbSearch)
        Me.Grouper1.Controls.Add(Me.Label3)
        Me.Grouper1.Controls.Add(Me.txtSearch)
        Me.Grouper1.Controls.Add(Me.Grid)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(6, 219)
        Me.Grouper1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(886, 369)
        Me.Grouper1.TabIndex = 25
        '
        'cbSearch
        '
        Me.cbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSearch.FormattingEnabled = True
        Me.cbSearch.Items.AddRange(New Object() {"All", "Active", "Inactive"})
        Me.cbSearch.Location = New System.Drawing.Point(318, 18)
        Me.cbSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.cbSearch.Name = "cbSearch"
        Me.cbSearch.Size = New System.Drawing.Size(140, 26)
        Me.cbSearch.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 18)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Search :"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(72, 19)
        Me.txtSearch.MaxLength = 100
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(237, 24)
        Me.txtSearch.TabIndex = 9
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(896, 592)
        Me.Controls.Add(Me.GroupBoxButton)
        Me.Controls.Add(Me.Grouper1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUser"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxButton.ResumeLayout(False)
        Me.GroupBoxButton.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtFname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxButton As CodeVendor.Controls.Grouper
    Friend WithEvents Grouper1 As CodeVendor.Controls.Grouper
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cbActive As System.Windows.Forms.CheckBox
    Friend WithEvents cbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLname As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbTitel As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtRePassword As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents group_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents user_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fullname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ms_title_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ms_group_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents password As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents active_status As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
