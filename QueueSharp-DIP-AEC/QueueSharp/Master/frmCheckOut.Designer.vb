<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckOut))
        Me.Grouper1 = New CodeVendor.Controls.Grouper()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.GridCheckOut = New System.Windows.Forms.DataGridView()
        Me.Grid = New System.Windows.Forms.DataGridView()
        Me.selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.app_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.CheckoutSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CheckoutAppNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grouper1.SuspendLayout()
        CType(Me.GridCheckOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Grouper1.Controls.Add(Me.btnRemove)
        Me.Grouper1.Controls.Add(Me.btnAdd)
        Me.Grouper1.Controls.Add(Me.GridCheckOut)
        Me.Grouper1.Controls.Add(Me.Grid)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(5, 33)
        Me.Grouper1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(886, 554)
        Me.Grouper1.TabIndex = 26
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(415, 186)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(94, 38)
        Me.btnRemove.TabIndex = 14
        Me.btnRemove.Text = "<< Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(415, 84)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(94, 38)
        Me.btnAdd.TabIndex = 13
        Me.btnAdd.Text = "Add >>"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GridCheckOut
        '
        Me.GridCheckOut.AllowUserToAddRows = False
        Me.GridCheckOut.AllowUserToDeleteRows = False
        Me.GridCheckOut.AllowUserToOrderColumns = True
        Me.GridCheckOut.AllowUserToResizeColumns = False
        Me.GridCheckOut.AllowUserToResizeRows = False
        Me.GridCheckOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCheckOut.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.GridCheckOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridCheckOut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CheckoutSelected, Me.CheckoutAppNo})
        Me.GridCheckOut.Location = New System.Drawing.Point(551, 23)
        Me.GridCheckOut.MultiSelect = False
        Me.GridCheckOut.Name = "GridCheckOut"
        Me.GridCheckOut.RowHeadersVisible = False
        Me.GridCheckOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridCheckOut.Size = New System.Drawing.Size(318, 519)
        Me.GridCheckOut.TabIndex = 12
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
        Me.Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.selected, Me.app_no, Me.id})
        Me.Grid.Location = New System.Drawing.Point(9, 23)
        Me.Grid.MultiSelect = False
        Me.Grid.Name = "Grid"
        Me.Grid.RowHeadersVisible = False
        Me.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid.Size = New System.Drawing.Size(368, 519)
        Me.Grid.TabIndex = 11
        '
        'selected
        '
        Me.selected.FalseValue = "0"
        Me.selected.HeaderText = ""
        Me.selected.Name = "selected"
        Me.selected.TrueValue = "1"
        Me.selected.Width = 60
        '
        'app_no
        '
        Me.app_no.DataPropertyName = "app_no"
        Me.app_no.FillWeight = 194.9239!
        Me.app_no.HeaderText = "เลขที่คำขอ"
        Me.app_no.Name = "app_no"
        Me.app_no.Width = 200
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'btnCheckOut
        '
        Me.btnCheckOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnCheckOut.Image = Global.QueueSharp.My.Resources.Resources.check
        Me.btnCheckOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCheckOut.Location = New System.Drawing.Point(752, 2)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(122, 40)
        Me.btnCheckOut.TabIndex = 12
        Me.btnCheckOut.Text = "Check Out"
        Me.btnCheckOut.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCheckOut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Search : "
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(88, 9)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(197, 26)
        Me.txtSearch.TabIndex = 28
        '
        'CheckoutSelected
        '
        Me.CheckoutSelected.FalseValue = "0"
        Me.CheckoutSelected.HeaderText = ""
        Me.CheckoutSelected.Name = "CheckoutSelected"
        Me.CheckoutSelected.TrueValue = "1"
        Me.CheckoutSelected.Width = 60
        '
        'CheckoutAppNo
        '
        Me.CheckoutAppNo.DataPropertyName = "app_no"
        Me.CheckoutAppNo.FillWeight = 194.9239!
        Me.CheckoutAppNo.HeaderText = "เลขที่คำขอ"
        Me.CheckoutAppNo.Name = "CheckoutAppNo"
        Me.CheckoutAppNo.Width = 200
        '
        'frmCheckOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(896, 592)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCheckOut)
        Me.Controls.Add(Me.Grouper1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckOut"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Check Out"
        Me.Grouper1.ResumeLayout(False)
        CType(Me.GridCheckOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Grouper1 As CodeVendor.Controls.Grouper
    Friend WithEvents Grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnCheckOut As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents GridCheckOut As System.Windows.Forms.DataGridView
    Friend WithEvents selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents app_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents CheckoutSelected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CheckoutAppNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
