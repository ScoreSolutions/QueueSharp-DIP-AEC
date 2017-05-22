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
    'Represents a transaction for MS_SERVICE_PRIORITY table LinqDB.
    '[Create by  on May, 22 2015]
    Public Class MsServicePriorityLinqDB
        Public sub MsServicePriorityLinqDB()

        End Sub 
        ' MS_SERVICE_PRIORITY
        Const _tableName As String = "MS_SERVICE_PRIORITY"
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
        Dim _MS_REQUISITION_TYPE_ID As Long = 0
        Dim _MS_PATENT_TYPE_ID As Long = 0
        Dim _MS_SERVICE_ID As Long = 0
        Dim _PRIORITY_VALUE As Long = 0
        Dim _ACTIVE_STATUS As Long = 0

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
        <Column(Storage:="_MS_SERVICE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_SERVICE_ID() As Long
            Get
                Return _MS_SERVICE_ID
            End Get
            Set(ByVal value As Long)
               _MS_SERVICE_ID = value
            End Set
        End Property 
        <Column(Storage:="_PRIORITY_VALUE", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property PRIORITY_VALUE() As Long
            Get
                Return _PRIORITY_VALUE
            End Get
            Set(ByVal value As Long)
               _PRIORITY_VALUE = value
            End Set
        End Property 
        <Column(Storage:="_ACTIVE_STATUS", DbType:="SmallInt NOT NULL ",CanBeNull:=false)>  _
        Public Property ACTIVE_STATUS() As Long
            Get
                Return _ACTIVE_STATUS
            End Get
            Set(ByVal value As Long)
               _ACTIVE_STATUS = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_DATE = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_DATE = New DateTime(1,1,1)
            _MS_REQUISITION_TYPE_ID = 0
            _MS_PATENT_TYPE_ID = 0
            _MS_SERVICE_ID = 0
            _PRIORITY_VALUE = 0
            _ACTIVE_STATUS = 0
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


        '/// Returns an indication whether the current data is inserted into MS_SERVICE_PRIORITY table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SERVICE_PRIORITY table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SERVICE_PRIORITY table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_SERVICE_PRIORITY table successfully.
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


        '/// Returns an indication whether the record of MS_SERVICE_PRIORITY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_SERVICE_PRIORITY by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsServicePriorityLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_SERVICE_PRIORITY by specified MS_PATENT_TYPE_ID_MS_REQUISITION_TYPE_ID_MS_SERVICE_ID key is retrieved successfully.
        '/// <param name=cMS_PATENT_TYPE_ID_MS_REQUISITION_TYPE_ID_MS_SERVICE_ID>The MS_PATENT_TYPE_ID_MS_REQUISITION_TYPE_ID_MS_SERVICE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByMS_PATENT_TYPE_ID_MS_REQUISITION_TYPE_ID_MS_SERVICE_ID(cMS_PATENT_TYPE_ID As Long, cMS_REQUISITION_TYPE_ID As Long, cMS_SERVICE_ID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_PATENT_TYPE_ID = " & DB.SetDouble(cMS_PATENT_TYPE_ID) & " AND MS_REQUISITION_TYPE_ID = " & DB.SetDouble(cMS_REQUISITION_TYPE_ID) & " AND MS_SERVICE_ID = " & DB.SetDouble(cMS_SERVICE_ID), trans)
        End Function

        '/// Returns an duplicate data record of MS_SERVICE_PRIORITY by specified MS_PATENT_TYPE_ID_MS_REQUISITION_TYPE_ID_MS_SERVICE_ID key is retrieved successfully.
        '/// <param name=cMS_PATENT_TYPE_ID_MS_REQUISITION_TYPE_ID_MS_SERVICE_ID>The MS_PATENT_TYPE_ID_MS_REQUISITION_TYPE_ID_MS_SERVICE_ID key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByMS_PATENT_TYPE_ID_MS_REQUISITION_TYPE_ID_MS_SERVICE_ID(cMS_PATENT_TYPE_ID As Long, cMS_REQUISITION_TYPE_ID As Long, cMS_SERVICE_ID As Long, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("MS_PATENT_TYPE_ID = " & DB.SetDouble(cMS_PATENT_TYPE_ID) & " AND MS_REQUISITION_TYPE_ID = " & DB.SetDouble(cMS_REQUISITION_TYPE_ID) & " AND MS_SERVICE_ID = " & DB.SetDouble(cMS_SERVICE_ID) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_SERVICE_PRIORITY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_SERVICE_PRIORITY table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_SERVICE_PRIORITY table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_SERVICE_PRIORITY table successfully.
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
            Dim cmbParam(9) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MS_REQUISITION_TYPE_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _MS_REQUISITION_TYPE_ID

            cmbParam(6) = New SqlParameter("@_MS_PATENT_TYPE_ID", SqlDbType.BigInt)
            cmbParam(6).Value = _MS_PATENT_TYPE_ID

            cmbParam(7) = New SqlParameter("@_MS_SERVICE_ID", SqlDbType.BigInt)
            cmbParam(7).Value = _MS_SERVICE_ID

            cmbParam(8) = New SqlParameter("@_PRIORITY_VALUE", SqlDbType.Int)
            cmbParam(8).Value = _PRIORITY_VALUE

            cmbParam(9) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.SmallInt)
            cmbParam(9).Value = _ACTIVE_STATUS

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_SERVICE_PRIORITY by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_requisition_type_id")) = False Then _ms_requisition_type_id = Convert.ToInt64(Rdr("ms_requisition_type_id"))
                        If Convert.IsDBNull(Rdr("ms_patent_type_id")) = False Then _ms_patent_type_id = Convert.ToInt64(Rdr("ms_patent_type_id"))
                        If Convert.IsDBNull(Rdr("ms_service_id")) = False Then _ms_service_id = Convert.ToInt64(Rdr("ms_service_id"))
                        If Convert.IsDBNull(Rdr("priority_value")) = False Then _priority_value = Convert.ToInt32(Rdr("priority_value"))
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Convert.ToInt16(Rdr("active_status"))
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


        '/// Returns an indication whether the record of MS_SERVICE_PRIORITY by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsServicePriorityLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_requisition_type_id")) = False Then _ms_requisition_type_id = Convert.ToInt64(Rdr("ms_requisition_type_id"))
                        If Convert.IsDBNull(Rdr("ms_patent_type_id")) = False Then _ms_patent_type_id = Convert.ToInt64(Rdr("ms_patent_type_id"))
                        If Convert.IsDBNull(Rdr("ms_service_id")) = False Then _ms_service_id = Convert.ToInt64(Rdr("ms_service_id"))
                        If Convert.IsDBNull(Rdr("priority_value")) = False Then _priority_value = Convert.ToInt32(Rdr("priority_value"))
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Convert.ToInt16(Rdr("active_status"))
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


        'Get Insert Statement for table MS_SERVICE_PRIORITY
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, MS_REQUISITION_TYPE_ID, MS_PATENT_TYPE_ID, MS_SERVICE_ID, PRIORITY_VALUE, ACTIVE_STATUS)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATE_BY, INSERTED.CREATE_DATE, INSERTED.UPDATE_BY, INSERTED.UPDATE_DATE, INSERTED.MS_REQUISITION_TYPE_ID, INSERTED.MS_PATENT_TYPE_ID, INSERTED.MS_SERVICE_ID, INSERTED.PRIORITY_VALUE, INSERTED.ACTIVE_STATUS
                Sql += " VALUES("
                sql += "@_CREATE_BY" & ", "
                sql += "@_CREATE_DATE" & ", "
                sql += "@_UPDATE_BY" & ", "
                sql += "@_UPDATE_DATE" & ", "
                sql += "@_MS_REQUISITION_TYPE_ID" & ", "
                sql += "@_MS_PATENT_TYPE_ID" & ", "
                sql += "@_MS_SERVICE_ID" & ", "
                sql += "@_PRIORITY_VALUE" & ", "
                sql += "@_ACTIVE_STATUS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_SERVICE_PRIORITY
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATE_BY = " & "@_CREATE_BY" & ", "
                Sql += "CREATE_DATE = " & "@_CREATE_DATE" & ", "
                Sql += "UPDATE_BY = " & "@_UPDATE_BY" & ", "
                Sql += "UPDATE_DATE = " & "@_UPDATE_DATE" & ", "
                Sql += "MS_REQUISITION_TYPE_ID = " & "@_MS_REQUISITION_TYPE_ID" & ", "
                Sql += "MS_PATENT_TYPE_ID = " & "@_MS_PATENT_TYPE_ID" & ", "
                Sql += "MS_SERVICE_ID = " & "@_MS_SERVICE_ID" & ", "
                Sql += "PRIORITY_VALUE = " & "@_PRIORITY_VALUE" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_SERVICE_PRIORITY
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_SERVICE_PRIORITY
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, MS_REQUISITION_TYPE_ID, MS_PATENT_TYPE_ID, MS_SERVICE_ID, PRIORITY_VALUE, ACTIVE_STATUS FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
