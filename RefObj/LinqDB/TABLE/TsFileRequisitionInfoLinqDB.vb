Imports System
Imports System.Data 
Imports System.Data.SQLClient
Imports System.Data.Linq 
Imports System.Data.Linq.Mapping 
Imports System.Linq 
Imports System.Linq.Expressions 
Imports DB = LinqDB.ConnectDB.SqlDB
Imports LinqDB.ConnectDB

Namespace TABLE
    'Represents a transaction for TS_FILE_REQUISITION_INFO table LinqDB.
    '[Create by  on August, 13 2015]
    Public Class TsFileRequisitionInfoLinqDB
        Public sub TsFileRequisitionInfoLinqDB()

        End Sub 
        ' TS_FILE_REQUISITION_INFO
        Const _tableName As String = "TS_FILE_REQUISITION_INFO"
        Dim _deletedRow As Int16 = 0

        'Set Common Property
        Dim _error As String = ""
        Dim _information As String = ""
        Dim _haveData As Boolean = False

        Public ReadOnly Property TableName As String
            Get
                Return _tableName
            End Get
        End Property
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _error
            End Get
        End Property
        Public ReadOnly Property InfoMessage As String
            Get
                Return _information
            End Get
        End Property
        Public ReadOnly Property HaveData As Boolean
            Get
                Return _haveData
            End Get
        End Property


        'Generate Field List
        Dim _ID As Long = 0
        Dim _CREATE_BY As String = ""
        Dim _CREATE_DATE As DateTime = New DateTime(1,1,1)
        Dim _UPDATE_BY As  String  = ""
        Dim _UPDATE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _APP_NO As String = ""
        Dim _FILING_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _RECEIVE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _MS_REQUISITION_TYPE_ID As Long = 0
        Dim _MS_PATENT_TYPE_ID As Long = 0
        Dim _PREPARE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SEND_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

        'Generate Field Property 
        <Column(Storage:="_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ID() As Long
            Get
                Return _ID
            End Get
            Set(ByVal value As Long)
               _ID = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_BY", DbType:="VarChar(100) NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_BY() As String
            Get
                Return _CREATE_BY
            End Get
            Set(ByVal value As String)
               _CREATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_CREATE_DATE", DbType:="DateTime NOT NULL ",CanBeNull:=false)>  _
        Public Property CREATE_DATE() As DateTime
            Get
                Return _CREATE_DATE
            End Get
            Set(ByVal value As DateTime)
               _CREATE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_BY", DbType:="VarChar(100)")>  _
        Public Property UPDATE_BY() As  String 
            Get
                Return _UPDATE_BY
            End Get
            Set(ByVal value As  String )
               _UPDATE_BY = value
            End Set
        End Property 
        <Column(Storage:="_UPDATE_DATE", DbType:="DateTime")>  _
        Public Property UPDATE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _UPDATE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _UPDATE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_APP_NO", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property APP_NO() As String
            Get
                Return _APP_NO
            End Get
            Set(ByVal value As String)
               _APP_NO = value
            End Set
        End Property 
        <Column(Storage:="_FILING_DATE", DbType:="DateTime")>  _
        Public Property FILING_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _FILING_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _FILING_DATE = value
            End Set
        End Property 
        <Column(Storage:="_RECEIVE_DATE", DbType:="DateTime")>  _
        Public Property RECEIVE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _RECEIVE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _RECEIVE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_MS_REQUISITION_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_REQUISITION_TYPE_ID() As Long
            Get
                Return _MS_REQUISITION_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _MS_REQUISITION_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_MS_PATENT_TYPE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_PATENT_TYPE_ID() As Long
            Get
                Return _MS_PATENT_TYPE_ID
            End Get
            Set(ByVal value As Long)
               _MS_PATENT_TYPE_ID = value
            End Set
        End Property 
        <Column(Storage:="_PREPARE_DATE", DbType:="DateTime")>  _
        Public Property PREPARE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _PREPARE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _PREPARE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_SEND_DATE", DbType:="DateTime")>  _
        Public Property SEND_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _SEND_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _SEND_DATE = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_DATE = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_DATE = New DateTime(1,1,1)
            _APP_NO = ""
            _FILING_DATE = New DateTime(1,1,1)
            _RECEIVE_DATE = New DateTime(1,1,1)
            _MS_REQUISITION_TYPE_ID = 0
            _MS_PATENT_TYPE_ID = 0
            _PREPARE_DATE = New DateTime(1,1,1)
            _SEND_DATE = New DateTime(1,1,1)
        End Sub

       'Define Public Method 
        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=orderBy>The fields for sort data.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetDataList(whClause As String, orderBy As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(SqlSelect & IIf(whClause = "", "", " WHERE " & whClause) & IIF(orderBy = "", "", " ORDER BY  " & orderBy), trans)
        End Function


        'Execute the select statement with the specified condition and return a System.Data.DataTable.
        '/// <param name=whereClause>The condition for execute select statement.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>The System.Data.DataTable object for specified condition.</returns>
        Public Function GetListBySql(Sql As String, trans As SQLTransaction) As DataTable
            Return DB.ExecuteTable(Sql, trans)
        End Function


        '/// Returns an indication whether the current data is inserted into TS_FILE_REQUISITION_INFO table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Public Function InsertData(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Create_By = LoginName
                _Create_Date = DateTime.Now
                Return doInsert(trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TS_FILE_REQUISITION_INFO table successfully.
        '/// <param name=userID>The current user.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateByPK(LoginName As String,trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                _Update_By = LoginName
                _Update_Date = DateTime.Now
                Return doUpdate("ID = " & DB.SetDouble(_ID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is updated to TS_FILE_REQUISITION_INFO table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TS_FILE_REQUISITION_INFO table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Public Function DeleteByPK(cID As Long, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return doDelete("ID = " & DB.SetDouble(cID), trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the record of TS_FILE_REQUISITION_INFO by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TS_FILE_REQUISITION_INFO by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TsFileRequisitionInfoLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_REQUISITION_INFO by specified APP_NO_MS_REQUISITION_TYPE_ID key is retrieved successfully.
        '/// <param name=cAPP_NO_MS_REQUISITION_TYPE_ID>The APP_NO_MS_REQUISITION_TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByAPP_NO_MS_REQUISITION_TYPE_ID(cAPP_NO As String, cMS_REQUISITION_TYPE_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND MS_REQUISITION_TYPE_ID = " & DB.SetDouble(cMS_REQUISITION_TYPE_ID), trans)
        End Function

        '/// Returns an duplicate data record of TS_FILE_REQUISITION_INFO by specified APP_NO_MS_REQUISITION_TYPE_ID key is retrieved successfully.
        '/// <param name=cAPP_NO_MS_REQUISITION_TYPE_ID>The APP_NO_MS_REQUISITION_TYPE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByAPP_NO_MS_REQUISITION_TYPE_ID(cAPP_NO As String, cMS_REQUISITION_TYPE_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("APP_NO = " & DB.SetString(cAPP_NO) & " AND MS_REQUISITION_TYPE_ID = " & DB.SetDouble(cMS_REQUISITION_TYPE_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TS_FILE_REQUISITION_INFO by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TS_FILE_REQUISITION_INFO table successfully.
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if insert data successfully; otherwise, false.</returns>
        Private Function doInsert(trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            If _haveData = False Then
                Try
                    Dim dt as DataTable = DB.ExecuteTable(SqlInsert, trans, SetParameterData())
                    If dt.Rows.Count = 0 Then
                        _error = DB.ErrorMessage
                        ret = False
                    Else
                        _ID = dt.Rows(0)("ID")
                        _haveData = True
                        ret = True
                    End If
                    _information = MessageResources.MSGIN001
                Catch ex As ApplicationException
                    ret = false
                    _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlInsert
                Catch ex As Exception
                    ret = False
                    _error = MessageResources.MSGEC101 & " Exception :" & ex.ToString() & "### SQL: " & SqlInsert
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEN002 & "### SQL: " & SqlInsert
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is updated to TS_FILE_REQUISITION_INFO table successfully.
        '/// <param name=whText>The condition specify the updating record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Private Function doUpdate(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If _haveData = True Then
                If whText.Trim() <> ""
                    Try
                        ret = DB.ExecuteNonQuery(SqlUpdate & tmpWhere, trans, SetParameterData())
                        If ret = False Then
                            _error = DB.ErrorMessage
                        End If
                        _information = MessageResources.MSGIU001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlUpdate & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC102 & " Exception :" & ex.ToString() & "### SQL: " & SqlUpdate & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGEU003 & "### SQL: " & SqlUpdate & tmpWhere
                End If
            Else
                ret = True
            End If

            Return ret
        End Function


        '/// Returns an indication whether the current data is deleted from TS_FILE_REQUISITION_INFO table successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if delete data successfully; otherwise, false.</returns>
        Private Function doDelete(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " Where " & whText
            If doChkData(whText, trans) = True Then
                If whText.Trim() <> ""
                    Try
                        ret = DB.ExecuteNonQuery(SqlDelete & tmpWhere, trans)
                        If ret = False Then
                            _error = MessageResources.MSGED001
                        End If
                        _information = MessageResources.MSGID001
                    Catch ex As ApplicationException
                        ret = False
                        _error = ex.Message & "ApplicationException :" & ex.ToString() & "### SQL:" & SqlDelete & tmpWhere
                    Catch ex As Exception
                        ret = False
                        _error = MessageResources.MSGEC103 & " Exception :" & ex.ToString() & "### SQL: " & SqlDelete & tmpWhere
                    End Try
                Else
                    ret = False
                    _error = MessageResources.MSGED003 & "### SQL: " & SqlDelete & tmpWhere
                End If
            Else
                ret = True
            End If

            Return ret
        End Function

        Private Function SetParameterData() As SqlParameter()
            Dim cmbParam(11) As SqlParameter
            cmbParam(0) = New SqlParameter("@_ID", SqlDbType.BigInt)
            cmbParam(0).Value = _ID

            cmbParam(1) = New SqlParameter("@_CREATE_BY", SqlDbType.VarChar)
            cmbParam(1).Value = _CREATE_BY

            cmbParam(2) = New SqlParameter("@_CREATE_DATE", SqlDbType.DateTime)
            cmbParam(2).Value = _CREATE_DATE

            cmbParam(3) = New SqlParameter("@_UPDATE_BY", SqlDbType.VarChar)
            If _UPDATE_BY.Trim <> "" Then 
                cmbParam(3).Value = _UPDATE_BY
            Else
                cmbParam(3).Value = DBNull.value
            End If

            cmbParam(4) = New SqlParameter("@_UPDATE_DATE", SqlDbType.DateTime)
            If _UPDATE_DATE.Value.Year > 1 Then 
                cmbParam(4).Value = _UPDATE_DATE.Value
            Else
                cmbParam(4).Value = DBNull.value
            End If

            cmbParam(5) = New SqlParameter("@_APP_NO", SqlDbType.VarChar)
            cmbParam(5).Value = _APP_NO

            cmbParam(6) = New SqlParameter("@_FILING_DATE", SqlDbType.DateTime)
            If _FILING_DATE.Value.Year > 1 Then 
                cmbParam(6).Value = _FILING_DATE.Value
            Else
                cmbParam(6).Value = DBNull.value
            End If

            cmbParam(7) = New SqlParameter("@_RECEIVE_DATE", SqlDbType.DateTime)
            If _RECEIVE_DATE.Value.Year > 1 Then 
                cmbParam(7).Value = _RECEIVE_DATE.Value
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_MS_REQUISITION_TYPE_ID", SqlDbType.BigInt)
            cmbParam(8).Value = _MS_REQUISITION_TYPE_ID

            cmbParam(9) = New SqlParameter("@_MS_PATENT_TYPE_ID", SqlDbType.BigInt)
            cmbParam(9).Value = _MS_PATENT_TYPE_ID

            cmbParam(10) = New SqlParameter("@_PREPARE_DATE", SqlDbType.DateTime)
            If _PREPARE_DATE.Value.Year > 1 Then 
                cmbParam(10).Value = _PREPARE_DATE.Value
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_SEND_DATE", SqlDbType.DateTime)
            If _SEND_DATE.Value.Year > 1 Then 
                cmbParam(11).Value = _SEND_DATE.Value
            Else
                cmbParam(11).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TS_FILE_REQUISITION_INFO by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doChkData(whText As String, trans As SQLTransaction) As Boolean
            Dim ret As Boolean = True
            Dim tmpWhere As String = " WHERE " & whText
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_date")) = False Then _create_date = Convert.ToDateTime(Rdr("create_date"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_date")) = False Then _update_date = Convert.ToDateTime(Rdr("update_date"))
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _app_no = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("filing_date")) = False Then _filing_date = Convert.ToDateTime(Rdr("filing_date"))
                        If Convert.IsDBNull(Rdr("receive_date")) = False Then _receive_date = Convert.ToDateTime(Rdr("receive_date"))
                        If Convert.IsDBNull(Rdr("ms_requisition_type_id")) = False Then _ms_requisition_type_id = Convert.ToInt64(Rdr("ms_requisition_type_id"))
                        If Convert.IsDBNull(Rdr("ms_patent_type_id")) = False Then _ms_patent_type_id = Convert.ToInt64(Rdr("ms_patent_type_id"))
                        If Convert.IsDBNull(Rdr("prepare_date")) = False Then _prepare_date = Convert.ToDateTime(Rdr("prepare_date"))
                        If Convert.IsDBNull(Rdr("send_date")) = False Then _send_date = Convert.ToDateTime(Rdr("send_date"))
                    Else
                        ret = False
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    ret = False
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                ret = False
                _error = MessageResources.MSGEV001
            End If

            Return ret
        End Function


        '/// Returns an indication whether the record of TS_FILE_REQUISITION_INFO by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TsFileRequisitionInfoLinqDB
            ClearData()
            _haveData  = False
            If whText.Trim() <> "" Then
                Dim tmpWhere As String = " WHERE " & whText
                Dim Rdr As SQLDataReader
                Try
                    Rdr = DB.ExecuteReader(SqlSelect() & tmpWhere, trans)
                    If Rdr.Read() Then
                        _haveData = True
                        If Convert.IsDBNull(Rdr("id")) = False Then _id = Convert.ToInt64(Rdr("id"))
                        If Convert.IsDBNull(Rdr("create_by")) = False Then _create_by = Rdr("create_by").ToString()
                        If Convert.IsDBNull(Rdr("create_date")) = False Then _create_date = Convert.ToDateTime(Rdr("create_date"))
                        If Convert.IsDBNull(Rdr("update_by")) = False Then _update_by = Rdr("update_by").ToString()
                        If Convert.IsDBNull(Rdr("update_date")) = False Then _update_date = Convert.ToDateTime(Rdr("update_date"))
                        If Convert.IsDBNull(Rdr("app_no")) = False Then _app_no = Rdr("app_no").ToString()
                        If Convert.IsDBNull(Rdr("filing_date")) = False Then _filing_date = Convert.ToDateTime(Rdr("filing_date"))
                        If Convert.IsDBNull(Rdr("receive_date")) = False Then _receive_date = Convert.ToDateTime(Rdr("receive_date"))
                        If Convert.IsDBNull(Rdr("ms_requisition_type_id")) = False Then _ms_requisition_type_id = Convert.ToInt64(Rdr("ms_requisition_type_id"))
                        If Convert.IsDBNull(Rdr("ms_patent_type_id")) = False Then _ms_patent_type_id = Convert.ToInt64(Rdr("ms_patent_type_id"))
                        If Convert.IsDBNull(Rdr("prepare_date")) = False Then _prepare_date = Convert.ToDateTime(Rdr("prepare_date"))
                        If Convert.IsDBNull(Rdr("send_date")) = False Then _send_date = Convert.ToDateTime(Rdr("send_date"))
                    Else
                        _error = MessageResources.MSGEV002
                    End If

                    Rdr.Close()
                Catch ex As Exception
                    ex.ToString()
                    _error = MessageResources.MSGEC104 & " #### " & ex.ToString()
                End Try
            Else
                _error = MessageResources.MSGEV001
            End If
            Return Me
        End Function



        ' SQL Statements


        'Get Insert Statement for table TS_FILE_REQUISITION_INFO
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, APP_NO, FILING_DATE, RECEIVE_DATE, MS_REQUISITION_TYPE_ID, MS_PATENT_TYPE_ID, PREPARE_DATE, SEND_DATE)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATE_BY, INSERTED.CREATE_DATE, INSERTED.UPDATE_BY, INSERTED.UPDATE_DATE, INSERTED.APP_NO, INSERTED.FILING_DATE, INSERTED.RECEIVE_DATE, INSERTED.MS_REQUISITION_TYPE_ID, INSERTED.MS_PATENT_TYPE_ID, INSERTED.PREPARE_DATE, INSERTED.SEND_DATE
                Sql += " VALUES("
                sql += "@_CREATE_BY" & ", "
                sql += "@_CREATE_DATE" & ", "
                sql += "@_UPDATE_BY" & ", "
                sql += "@_UPDATE_DATE" & ", "
                sql += "@_APP_NO" & ", "
                sql += "@_FILING_DATE" & ", "
                sql += "@_RECEIVE_DATE" & ", "
                sql += "@_MS_REQUISITION_TYPE_ID" & ", "
                sql += "@_MS_PATENT_TYPE_ID" & ", "
                sql += "@_PREPARE_DATE" & ", "
                sql += "@_SEND_DATE"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TS_FILE_REQUISITION_INFO
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATE_BY = " & "@_CREATE_BY" & ", "
                Sql += "CREATE_DATE = " & "@_CREATE_DATE" & ", "
                Sql += "UPDATE_BY = " & "@_UPDATE_BY" & ", "
                Sql += "UPDATE_DATE = " & "@_UPDATE_DATE" & ", "
                Sql += "APP_NO = " & "@_APP_NO" & ", "
                Sql += "FILING_DATE = " & "@_FILING_DATE" & ", "
                Sql += "RECEIVE_DATE = " & "@_RECEIVE_DATE" & ", "
                Sql += "MS_REQUISITION_TYPE_ID = " & "@_MS_REQUISITION_TYPE_ID" & ", "
                Sql += "MS_PATENT_TYPE_ID = " & "@_MS_PATENT_TYPE_ID" & ", "
                Sql += "PREPARE_DATE = " & "@_PREPARE_DATE" & ", "
                Sql += "SEND_DATE = " & "@_SEND_DATE" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TS_FILE_REQUISITION_INFO
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TS_FILE_REQUISITION_INFO
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, APP_NO, FILING_DATE, RECEIVE_DATE, MS_REQUISITION_TYPE_ID, MS_PATENT_TYPE_ID, PREPARE_DATE, SEND_DATE FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
