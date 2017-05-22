<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScanPageQty
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScanPageQty))
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridMainDoc = New System.Windows.Forms.DataGridView()
        Me.GroupBoxButton = New CodeVendor.Controls.Grouper()
        Me.lblPatentType = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblReqType = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAppNo = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Grouper1 = New CodeVendor.Controls.Grouper()
        Me.GridComposeDoc = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.document_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.page_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doc_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_document_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_page_qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_doc_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GridMainDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxButton.SuspendLayout()
        Me.Grouper1.SuspendLayout()
        CType(Me.GridComposeDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.txtID.Location = New System.Drawing.Point(558, 52)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(56, 24)
        Me.txtID.TabIndex = 15
        Me.txtID.Text = "0"
        Me.txtID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.Location = New System.Drawing.Point(22, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "เลขที่คำขอ :"
        '
        'GridMainDoc
        '
        Me.GridMainDoc.AllowUserToAddRows = False
        Me.GridMainDoc.AllowUserToDeleteRows = False
        Me.GridMainDoc.AllowUserToResizeColumns = False
        Me.GridMainDoc.AllowUserToResizeRows = False
        Me.GridMainDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridMainDoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridMainDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridMainDoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.document_name, Me.page_qty, Me.doc_id})
        Me.GridMainDoc.Location = New System.Drawing.Point(9, 47)
        Me.GridMainDoc.MultiSelect = False
        Me.GridMainDoc.Name = "GridMainDoc"
        Me.GridMainDoc.RowHeadersVisible = False
        Me.GridMainDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridMainDoc.Size = New System.Drawing.Size(293, 308)
        Me.GridMainDoc.TabIndex = 5
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
        Me.GroupBoxButton.Controls.Add(Me.lblPatentType)
        Me.GroupBoxButton.Controls.Add(Me.Label5)
        Me.GroupBoxButton.Controls.Add(Me.lblReqType)
        Me.GroupBoxButton.Controls.Add(Me.Label4)
        Me.GroupBoxButton.Controls.Add(Me.lblAppNo)
        Me.GroupBoxButton.Controls.Add(Me.txtID)
        Me.GroupBoxButton.Controls.Add(Me.Label1)
        Me.GroupBoxButton.CustomGroupBoxColor = System.Drawing.Color.White
        Me.GroupBoxButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.GroupBoxButton.GroupImage = Nothing
        Me.GroupBoxButton.GroupTitle = ""
        Me.GroupBoxButton.Location = New System.Drawing.Point(6, -3)
        Me.GroupBoxButton.MinimumSize = New System.Drawing.Size(1, 1)
        Me.GroupBoxButton.Name = "GroupBoxButton"
        Me.GroupBoxButton.Padding = New System.Windows.Forms.Padding(20)
        Me.GroupBoxButton.PaintGroupBox = False
        Me.GroupBoxButton.RoundCorners = 10
        Me.GroupBoxButton.ShadowColor = System.Drawing.Color.DarkGray
        Me.GroupBoxButton.ShadowControl = True
        Me.GroupBoxButton.ShadowThickness = 3
        Me.GroupBoxButton.Size = New System.Drawing.Size(664, 94)
        Me.GroupBoxButton.TabIndex = 24
        '
        'lblPatentType
        '
        Me.lblPatentType.AutoSize = True
        Me.lblPatentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblPatentType.Location = New System.Drawing.Point(365, 23)
        Me.lblPatentType.Name = "lblPatentType"
        Me.lblPatentType.Size = New System.Drawing.Size(0, 18)
        Me.lblPatentType.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label5.Location = New System.Drawing.Point(270, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 18)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "ประเภทแฟ้ม :"
        '
        'lblReqType
        '
        Me.lblReqType.AutoSize = True
        Me.lblReqType.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblReqType.Location = New System.Drawing.Point(117, 55)
        Me.lblReqType.Name = "lblReqType"
        Me.lblReqType.Size = New System.Drawing.Size(0, 18)
        Me.lblReqType.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 18)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "ประเภทคำขอ :"
        '
        'lblAppNo
        '
        Me.lblAppNo.AutoSize = True
        Me.lblAppNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.lblAppNo.Location = New System.Drawing.Point(102, 23)
        Me.lblAppNo.Name = "lblAppNo"
        Me.lblAppNo.Size = New System.Drawing.Size(0, 18)
        Me.lblAppNo.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 18)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "เอกสารหลัก"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.btnSave.Image = Global.QueueSharp.My.Resources.Resources.Save
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(564, 457)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 40)
        Me.btnSave.TabIndex = 11
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
        Me.Grouper1.Controls.Add(Me.GridComposeDoc)
        Me.Grouper1.Controls.Add(Me.Label2)
        Me.Grouper1.Controls.Add(Me.Label10)
        Me.Grouper1.Controls.Add(Me.GridMainDoc)
        Me.Grouper1.CustomGroupBoxColor = System.Drawing.Color.White
        Me.Grouper1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Grouper1.GroupImage = Nothing
        Me.Grouper1.GroupTitle = ""
        Me.Grouper1.Location = New System.Drawing.Point(6, 86)
        Me.Grouper1.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Grouper1.Name = "Grouper1"
        Me.Grouper1.Padding = New System.Windows.Forms.Padding(20)
        Me.Grouper1.PaintGroupBox = False
        Me.Grouper1.RoundCorners = 10
        Me.Grouper1.ShadowColor = System.Drawing.Color.DarkGray
        Me.Grouper1.ShadowControl = True
        Me.Grouper1.ShadowThickness = 3
        Me.Grouper1.Size = New System.Drawing.Size(664, 365)
        Me.Grouper1.TabIndex = 25
        '
        'GridComposeDoc
        '
        Me.GridComposeDoc.AllowUserToAddRows = False
        Me.GridComposeDoc.AllowUserToDeleteRows = False
        Me.GridComposeDoc.AllowUserToResizeColumns = False
        Me.GridComposeDoc.AllowUserToResizeRows = False
        Me.GridComposeDoc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridComposeDoc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.GridComposeDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridComposeDoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_document_name, Me.c_page_qty, Me.c_doc_id})
        Me.GridComposeDoc.Location = New System.Drawing.Point(308, 47)
        Me.GridComposeDoc.MultiSelect = False
        Me.GridComposeDoc.Name = "GridComposeDoc"
        Me.GridComposeDoc.RowHeadersVisible = False
        Me.GridComposeDoc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GridComposeDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridComposeDoc.Size = New System.Drawing.Size(348, 308)
        Me.GridComposeDoc.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label2.Location = New System.Drawing.Point(305, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 18)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "เอกสารประกอบ"
        '
        'document_name
        '
        Me.document_name.DataPropertyName = "document_name"
        Me.document_name.FillWeight = 28.24859!
        Me.document_name.HeaderText = "ชื่อเอกสาร"
        Me.document_name.Name = "document_name"
        Me.document_name.ReadOnly = True
        Me.document_name.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.document_name.Width = 200
        '
        'page_qty
        '
        Me.page_qty.DataPropertyName = "page_qty"
        Me.page_qty.FillWeight = 171.7514!
        Me.page_qty.HeaderText = "จำนวนหน้า"
        Me.page_qty.Name = "page_qty"
        Me.page_qty.Width = 80
        '
        'doc_id
        '
        Me.doc_id.DataPropertyName = "id"
        Me.doc_id.HeaderText = "id"
        Me.doc_id.Name = "doc_id"
        Me.doc_id.Visible = False
        '
        'c_document_name
        '
        Me.c_document_name.DataPropertyName = "document_name"
        Me.c_document_name.FillWeight = 28.24859!
        Me.c_document_name.HeaderText = "ชื่อเอกสาร"
        Me.c_document_name.Name = "c_document_name"
        Me.c_document_name.ReadOnly = True
        Me.c_document_name.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.c_document_name.Width = 240
        '
        'c_page_qty
        '
        Me.c_page_qty.DataPropertyName = "page_qty"
        Me.c_page_qty.FillWeight = 171.7514!
        Me.c_page_qty.HeaderText = "จำนวนหน้า"
        Me.c_page_qty.Name = "c_page_qty"
        Me.c_page_qty.Width = 80
        '
        'c_doc_id
        '
        Me.c_doc_id.DataPropertyName = "id"
        Me.c_doc_id.HeaderText = "id"
        Me.c_doc_id.Name = "c_doc_id"
        Me.c_doc_id.Visible = False
        '
        'frmScanPageQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(674, 502)
        Me.Controls.Add(Me.GroupBoxButton)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Grouper1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScanPageQty"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "จำนวนหน้าที่สแกน"
        CType(Me.GridMainDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxButton.ResumeLayout(False)
        Me.GroupBoxButton.PerformLayout()
        Me.Grouper1.ResumeLayout(False)
        Me.Grouper1.PerformLayout()
        CType(Me.GridComposeDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridMainDoc As System.Windows.Forms.DataGridView
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxButton As CodeVendor.Controls.Grouper
    Friend WithEvents Grouper1 As CodeVendor.Controls.Grouper
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPatentType As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblReqType As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAppNo As System.Windows.Forms.Label
    Friend WithEvents GridComposeDoc As System.Windows.Forms.DataGridView
    Friend WithEvents document_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents page_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doc_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_document_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_page_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_doc_id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
