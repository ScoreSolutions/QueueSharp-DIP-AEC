Imports System.Data.SqlClient
Imports LinqDB.TABLE

Public Class frmScanPageQty

    Dim _DocPageType As DocumentPageType
    Public WriteOnly Property DocPageType As DocumentPageType
        Set(value As DocumentPageType)
            _DocPageType = value
        End Set
    End Property


    Public WriteOnly Property TbCounterQueueID As Long
        Set(value As Long)
            txtID.Text = value
        End Set
    End Property

    Sub SetRequisitionData()
        Dim sql As String = "select requisition_type_name, patent_type_name, app_no"
        sql += " from vw_counter_queue "
        sql += " where tb_counter_queue_id='" & txtID.Text & "'"

        Dim dt As DataTable = getDataTable(sql)
        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            lblAppNo.Text = dr("app_no")
            lblPatentType.Text = dr("patent_type_name")
            lblReqType.Text = dr("requisition_type_name")
        End If
        dt.Dispose()
    End Sub



    Sub ShowDocumentList()
        Dim sql As String = ""
        Dim dt_data As New DataTable

        sql = " select id,document_name,document_type "
        sql += " from MS_DOCUMENT "
        sql += " where active_status='Y'"
        sql += " order by order_seq"
        dt_data = getDataTable(sql)

        dt_data.DefaultView.RowFilter = "document_type='1'"
        Dim mDt As New DataTable
        mDt = dt_data.DefaultView.ToTable.Copy
        GridMainDoc.AutoGenerateColumns = False
        GridMainDoc.DataSource = mDt

        dt_data.DefaultView.RowFilter = "document_type='2'"
        Dim cDt As New DataTable
        cDt = dt_data.DefaultView.ToTable.Copy
        GridComposeDoc.AutoGenerateColumns = False
        GridComposeDoc.DataSource = cDt

        dt_data.DefaultView.RowFilter = ""
    End Sub

    Function Validation() As Boolean
        'If txtCode.Text.Trim = "" Then
        '    MessageBox.Show("Please enter the Counter Code.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtCode.Focus()
        '    Return False
        'End If

        'If txtName.Text.Trim = "" Then
        '    MessageBox.Show("Please enter the Counter Name.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtName.Focus()
        '    Return False
        'End If

        'If CheckDuplicate("MS_counter", "counter_code", txtCode.Text.Trim, txtID.Text) = True Then
        '    MessageBox.Show("The Counter Code already exists! Please re-enter the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtCode.Focus()
        '    Return False
        'End If

        'If CheckDuplicate("MS_counter", "counter_name", txtName.Text.Trim, txtID.Text) = True Then
        '    MessageBox.Show("The Counter Name already exists! Please re-enter the new one.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    txtCode.Focus()
        '    Return False
        'End If

        'Dim chk As Boolean = False
        'For i As Int32 = 0 To GridSkill.Rows.Count - 1
        '    If GridSkill.Rows(i).Cells("cb").Value = "1" Then
        '        chk = True
        '        Exit For
        '    End If
        'Next
        'If chk = False Then
        '    MessageBox.Show("Please select Skill.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return False
        'End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Validation() Then
            Dim ret As Boolean = False
            Dim trans As New LinqDB.ConnectDB.TransactionDB

            For Each grv As DataGridViewRow In GridMainDoc.Rows
                Dim sql As String = ""
                If _DocPageType = DocumentPageType.SCAN Then
                    If grv.Cells("page_qty").Value IsNot Nothing Then
                        If grv.Cells("page_qty").Value.ToString <> "" Then
                            Dim lnq As New TbCounterQueueScanPageLinqDB
                            lnq.TB_COUNTER_QUEUE_ID = txtID.Text
                            lnq.MS_DOCUMENT_ID = grv.Cells("doc_id").Value
                            lnq.PAGE_QTY = grv.Cells("page_qty").Value.ToString

                            ret = lnq.InsertData(myUser.username, trans.Trans)
                            If ret = False Then
                                Exit For
                            End If
                        End If
                    End If
                ElseIf _DocPageType = DocumentPageType.KEY Then
                    If grv.Cells("page_qty").Value IsNot Nothing Then
                        If grv.Cells("page_qty").Value.ToString <> "" Then
                            Dim lnq As New TbCounterQueueKeyPageLinqDB
                            lnq.TB_COUNTER_QUEUE_ID = txtID.Text
                            lnq.MS_DOCUMENT_ID = grv.Cells("doc_id").Value
                            lnq.PAGE_QTY = grv.Cells("page_qty").Value.ToString

                            ret = lnq.InsertData(myUser.username, trans.Trans)
                            If ret = False Then
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next

            For Each grv As DataGridViewRow In GridComposeDoc.Rows
                Dim sql As String = ""
                If _DocPageType = DocumentPageType.SCAN Then
                    
                    If grv.Cells("c_page_qty").Value IsNot Nothing Then
                        If grv.Cells("c_page_qty").Value.ToString <> "" Then
                            Dim lnq As New TbCounterQueueScanPageLinqDB
                            lnq.TB_COUNTER_QUEUE_ID = txtID.Text
                            lnq.MS_DOCUMENT_ID = grv.Cells("c_doc_id").Value
                            lnq.PAGE_QTY = grv.Cells("c_page_qty").Value.ToString
                            ret = lnq.InsertData(myUser.username, trans.Trans)
                            If ret = False Then
                                Exit For
                            End If
                        End If
                    End If
                ElseIf _DocPageType = DocumentPageType.KEY Then
                    
                    If grv.Cells("c_page_qty").Value IsNot Nothing Then
                        If grv.Cells("c_page_qty").Value.ToString <> "" Then
                            Dim lnq As New TbCounterQueueKeyPageLinqDB
                            lnq.TB_COUNTER_QUEUE_ID = txtID.Text
                            lnq.MS_DOCUMENT_ID = grv.Cells("c_doc_id").Value
                            lnq.PAGE_QTY = grv.Cells("c_page_qty").Value.ToString
                            ret = lnq.InsertData(myUser.username, trans.Trans)
                            If ret = False Then
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next

            If ret = True Then
                trans.CommitTransaction()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                trans.RollbackTransaction()
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
            End If
            Me.Close()
        End If
    End Sub

    Private Sub frmScanPageQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetRequisitionData()
        ShowDocumentList()

        If _DocPageType = DocumentPageType.KEY Then
            Me.Text = "จำนวนหน้าของเอกสารที่คีย์ข้อมูล"
        Else
            Me.Text = "จำนวนหน้าของเอกสารที่สแกน"
        End If
    End Sub


    Private Sub GridComposeDoc_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GridComposeDoc.EditingControlShowing
        Dim txtGridviewEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
        AddHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
    End Sub

    Private Sub txtGridviewEdit_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'Test for numeric value or backspace in first column
        'If dtgtaophieunhapxuat.CurrentCell.ColumnIndex = 0 Then
        If IsNumeric(e.KeyChar.ToString()) Or e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = False 'if numeric display
        Else
            e.Handled = True  'if non numeric don't display
        End If
        'End If
    End Sub

    Private Sub GridMainDoc_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles GridMainDoc.EditingControlShowing
        Dim txtGridviewEdit As TextBox = e.Control
        'remove any existing handler
        RemoveHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
        AddHandler txtGridviewEdit.KeyPress, AddressOf txtGridviewEdit_Keypress
    End Sub

    Public Enum DocumentPageType
        SCAN = 1
        KEY = 2
    End Enum

End Class

