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
    'Represents a transaction for TB_COUNTER_QUEUE table LinqDB.
    '[Create by  on August, 20 2015]
    Public Class TbCounterQueueLinqDB
        Public sub TbCounterQueueLinqDB()

        End Sub 
        ' TB_COUNTER_QUEUE
        Const _tableName As String = "TB_COUNTER_QUEUE"
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
        Dim _TB_REGISTER_QUEUE_ID As Long = 0
        Dim _MS_SERVICE_ID As Long = 0
        Dim _MS_COUNTER_ID As  System.Nullable(Of Long)  = 0
        Dim _MS_USER_ID As  System.Nullable(Of Long)  = 0
        Dim _ASSIGN_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _CALL_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _START_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _END_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _STATUS As Long = 0
        Dim _ADD_SERVICE As String = "0"
        Dim _CALL_AUTO_FORCE As String = "0"
        Dim _TB_REGISTER_QUEUE_HOLD_ID As Long = 0

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
        <Column(Storage:="_TB_REGISTER_QUEUE_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property TB_REGISTER_QUEUE_ID() As Long
            Get
                Return _TB_REGISTER_QUEUE_ID
            End Get
            Set(ByVal value As Long)
               _TB_REGISTER_QUEUE_ID = value
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
        <Column(Storage:="_MS_COUNTER_ID", DbType:="BigInt")>  _
        Public Property MS_COUNTER_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_COUNTER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_COUNTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_MS_USER_ID", DbType:="BigInt")>  _
        Public Property MS_USER_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_USER_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_USER_ID = value
            End Set
        End Property 
        <Column(Storage:="_ASSIGN_TIME", DbType:="DateTime")>  _
        Public Property ASSIGN_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _ASSIGN_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _ASSIGN_TIME = value
            End Set
        End Property 
        <Column(Storage:="_CALL_TIME", DbType:="DateTime")>  _
        Public Property CALL_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _CALL_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _CALL_TIME = value
            End Set
        End Property 
        <Column(Storage:="_START_TIME", DbType:="DateTime")>  _
        Public Property START_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _START_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _START_TIME = value
            End Set
        End Property 
        <Column(Storage:="_END_TIME", DbType:="DateTime")>  _
        Public Property END_TIME() As  System.Nullable(Of DateTime) 
            Get
                Return _END_TIME
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _END_TIME = value
            End Set
        End Property 
        <Column(Storage:="_STATUS", DbType:="SmallInt NOT NULL ",CanBeNull:=false)>  _
        Public Property STATUS() As Long
            Get
                Return _STATUS
            End Get
            Set(ByVal value As Long)
               _STATUS = value
            End Set
        End Property 
        <Column(Storage:="_ADD_SERVICE", DbType:="VarChar(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property ADD_SERVICE() As String
            Get
                Return _ADD_SERVICE
            End Get
            Set(ByVal value As String)
               _ADD_SERVICE = value
            End Set
        End Property 
        <Column(Storage:="_CALL_AUTO_FORCE", DbType:="VarChar(1) NOT NULL ",CanBeNull:=false)>  _
        Public Property CALL_AUTO_FORCE() As String
            Get
                Return _CALL_AUTO_FORCE
            End Get
            Set(ByVal value As String)
               _CALL_AUTO_FORCE = value
            End Set
        End Property 
        <Column(Storage:="_TB_REGISTER_QUEUE_HOLD_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property TB_REGISTER_QUEUE_HOLD_ID() As Long
            Get
                Return _TB_REGISTER_QUEUE_HOLD_ID
            End Get
            Set(ByVal value As Long)
               _TB_REGISTER_QUEUE_HOLD_ID = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_DATE = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_DATE = New DateTime(1,1,1)
            _TB_REGISTER_QUEUE_ID = 0
            _MS_SERVICE_ID = 0
            _MS_COUNTER_ID = 0
            _MS_USER_ID = 0
            _ASSIGN_TIME = New DateTime(1,1,1)
            _CALL_TIME = New DateTime(1,1,1)
            _START_TIME = New DateTime(1,1,1)
            _END_TIME = New DateTime(1,1,1)
            _STATUS = 0
            _ADD_SERVICE = "0"
            _CALL_AUTO_FORCE = "0"
            _TB_REGISTER_QUEUE_HOLD_ID = 0
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


        '/// Returns an indication whether the current data is inserted into TB_COUNTER_QUEUE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_COUNTER_QUEUE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_COUNTER_QUEUE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_COUNTER_QUEUE table successfully.
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


        '/// Returns an indication whether the record of TB_COUNTER_QUEUE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_COUNTER_QUEUE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbCounterQueueLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_COUNTER_QUEUE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_COUNTER_QUEUE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_COUNTER_QUEUE table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_COUNTER_QUEUE table successfully.
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
            Dim cmbParam(16) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_TB_REGISTER_QUEUE_ID", SqlDbType.BigInt)
            cmbParam(5).Value = _TB_REGISTER_QUEUE_ID

            cmbParam(6) = New SqlParameter("@_MS_SERVICE_ID", SqlDbType.BigInt)
            cmbParam(6).Value = _MS_SERVICE_ID

            cmbParam(7) = New SqlParameter("@_MS_COUNTER_ID", SqlDbType.BigInt)
            If _MS_COUNTER_ID IsNot Nothing Then 
                cmbParam(7).Value = _MS_COUNTER_ID.Value
            Else
                cmbParam(7).Value = DBNull.value
            End IF

            cmbParam(8) = New SqlParameter("@_MS_USER_ID", SqlDbType.BigInt)
            If _MS_USER_ID IsNot Nothing Then 
                cmbParam(8).Value = _MS_USER_ID.Value
            Else
                cmbParam(8).Value = DBNull.value
            End IF

            cmbParam(9) = New SqlParameter("@_ASSIGN_TIME", SqlDbType.DateTime)
            If _ASSIGN_TIME.Value.Year > 1 Then 
                cmbParam(9).Value = _ASSIGN_TIME.Value
            Else
                cmbParam(9).Value = DBNull.value
            End If

            cmbParam(10) = New SqlParameter("@_CALL_TIME", SqlDbType.DateTime)
            If _CALL_TIME.Value.Year > 1 Then 
                cmbParam(10).Value = _CALL_TIME.Value
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_START_TIME", SqlDbType.DateTime)
            If _START_TIME.Value.Year > 1 Then 
                cmbParam(11).Value = _START_TIME.Value
            Else
                cmbParam(11).Value = DBNull.value
            End If

            cmbParam(12) = New SqlParameter("@_END_TIME", SqlDbType.DateTime)
            If _END_TIME.Value.Year > 1 Then 
                cmbParam(12).Value = _END_TIME.Value
            Else
                cmbParam(12).Value = DBNull.value
            End If

            cmbParam(13) = New SqlParameter("@_STATUS", SqlDbType.SmallInt)
            cmbParam(13).Value = _STATUS

            cmbParam(14) = New SqlParameter("@_ADD_SERVICE", SqlDbType.VarChar)
            cmbParam(14).Value = _ADD_SERVICE

            cmbParam(15) = New SqlParameter("@_CALL_AUTO_FORCE", SqlDbType.VarChar)
            cmbParam(15).Value = _CALL_AUTO_FORCE

            cmbParam(16) = New SqlParameter("@_TB_REGISTER_QUEUE_HOLD_ID", SqlDbType.BigInt)
            cmbParam(16).Value = _TB_REGISTER_QUEUE_HOLD_ID

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_COUNTER_QUEUE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("tb_register_queue_id")) = False Then _tb_register_queue_id = Convert.ToInt64(Rdr("tb_register_queue_id"))
                        If Convert.IsDBNull(Rdr("ms_service_id")) = False Then _ms_service_id = Convert.ToInt64(Rdr("ms_service_id"))
                        If Convert.IsDBNull(Rdr("ms_counter_id")) = False Then _ms_counter_id = Convert.ToInt64(Rdr("ms_counter_id"))
                        If Convert.IsDBNull(Rdr("ms_user_id")) = False Then _ms_user_id = Convert.ToInt64(Rdr("ms_user_id"))
                        If Convert.IsDBNull(Rdr("assign_time")) = False Then _assign_time = Convert.ToDateTime(Rdr("assign_time"))
                        If Convert.IsDBNull(Rdr("call_time")) = False Then _call_time = Convert.ToDateTime(Rdr("call_time"))
                        If Convert.IsDBNull(Rdr("start_time")) = False Then _start_time = Convert.ToDateTime(Rdr("start_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then _end_time = Convert.ToDateTime(Rdr("end_time"))
                        If Convert.IsDBNull(Rdr("status")) = False Then _status = Convert.ToInt16(Rdr("status"))
                        If Convert.IsDBNull(Rdr("add_service")) = False Then _add_service = Rdr("add_service").ToString()
                        If Convert.IsDBNull(Rdr("call_auto_force")) = False Then _call_auto_force = Rdr("call_auto_force").ToString()
                        If Convert.IsDBNull(Rdr("tb_register_queue_hold_id")) = False Then _tb_register_queue_hold_id = Convert.ToInt64(Rdr("tb_register_queue_hold_id"))
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


        '/// Returns an indication whether the record of TB_COUNTER_QUEUE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbCounterQueueLinqDB
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
                        If Convert.IsDBNull(Rdr("tb_register_queue_id")) = False Then _tb_register_queue_id = Convert.ToInt64(Rdr("tb_register_queue_id"))
                        If Convert.IsDBNull(Rdr("ms_service_id")) = False Then _ms_service_id = Convert.ToInt64(Rdr("ms_service_id"))
                        If Convert.IsDBNull(Rdr("ms_counter_id")) = False Then _ms_counter_id = Convert.ToInt64(Rdr("ms_counter_id"))
                        If Convert.IsDBNull(Rdr("ms_user_id")) = False Then _ms_user_id = Convert.ToInt64(Rdr("ms_user_id"))
                        If Convert.IsDBNull(Rdr("assign_time")) = False Then _assign_time = Convert.ToDateTime(Rdr("assign_time"))
                        If Convert.IsDBNull(Rdr("call_time")) = False Then _call_time = Convert.ToDateTime(Rdr("call_time"))
                        If Convert.IsDBNull(Rdr("start_time")) = False Then _start_time = Convert.ToDateTime(Rdr("start_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then _end_time = Convert.ToDateTime(Rdr("end_time"))
                        If Convert.IsDBNull(Rdr("status")) = False Then _status = Convert.ToInt16(Rdr("status"))
                        If Convert.IsDBNull(Rdr("add_service")) = False Then _add_service = Rdr("add_service").ToString()
                        If Convert.IsDBNull(Rdr("call_auto_force")) = False Then _call_auto_force = Rdr("call_auto_force").ToString()
                        If Convert.IsDBNull(Rdr("tb_register_queue_hold_id")) = False Then _tb_register_queue_hold_id = Convert.ToInt64(Rdr("tb_register_queue_hold_id"))
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


        'Get Insert Statement for table TB_COUNTER_QUEUE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, TB_REGISTER_QUEUE_ID, MS_SERVICE_ID, MS_COUNTER_ID, MS_USER_ID, ASSIGN_TIME, CALL_TIME, START_TIME, END_TIME, STATUS, ADD_SERVICE, CALL_AUTO_FORCE, TB_REGISTER_QUEUE_HOLD_ID)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATE_BY, INSERTED.CREATE_DATE, INSERTED.UPDATE_BY, INSERTED.UPDATE_DATE, INSERTED.TB_REGISTER_QUEUE_ID, INSERTED.MS_SERVICE_ID, INSERTED.MS_COUNTER_ID, INSERTED.MS_USER_ID, INSERTED.ASSIGN_TIME, INSERTED.CALL_TIME, INSERTED.START_TIME, INSERTED.END_TIME, INSERTED.STATUS, INSERTED.ADD_SERVICE, INSERTED.CALL_AUTO_FORCE, INSERTED.TB_REGISTER_QUEUE_HOLD_ID
                Sql += " VALUES("
                sql += "@_CREATE_BY" & ", "
                sql += "@_CREATE_DATE" & ", "
                sql += "@_UPDATE_BY" & ", "
                sql += "@_UPDATE_DATE" & ", "
                sql += "@_TB_REGISTER_QUEUE_ID" & ", "
                sql += "@_MS_SERVICE_ID" & ", "
                sql += "@_MS_COUNTER_ID" & ", "
                sql += "@_MS_USER_ID" & ", "
                sql += "@_ASSIGN_TIME" & ", "
                sql += "@_CALL_TIME" & ", "
                sql += "@_START_TIME" & ", "
                sql += "@_END_TIME" & ", "
                sql += "@_STATUS" & ", "
                sql += "@_ADD_SERVICE" & ", "
                sql += "@_CALL_AUTO_FORCE" & ", "
                sql += "@_TB_REGISTER_QUEUE_HOLD_ID"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_COUNTER_QUEUE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATE_BY = " & "@_CREATE_BY" & ", "
                Sql += "CREATE_DATE = " & "@_CREATE_DATE" & ", "
                Sql += "UPDATE_BY = " & "@_UPDATE_BY" & ", "
                Sql += "UPDATE_DATE = " & "@_UPDATE_DATE" & ", "
                Sql += "TB_REGISTER_QUEUE_ID = " & "@_TB_REGISTER_QUEUE_ID" & ", "
                Sql += "MS_SERVICE_ID = " & "@_MS_SERVICE_ID" & ", "
                Sql += "MS_COUNTER_ID = " & "@_MS_COUNTER_ID" & ", "
                Sql += "MS_USER_ID = " & "@_MS_USER_ID" & ", "
                Sql += "ASSIGN_TIME = " & "@_ASSIGN_TIME" & ", "
                Sql += "CALL_TIME = " & "@_CALL_TIME" & ", "
                Sql += "START_TIME = " & "@_START_TIME" & ", "
                Sql += "END_TIME = " & "@_END_TIME" & ", "
                Sql += "STATUS = " & "@_STATUS" & ", "
                Sql += "ADD_SERVICE = " & "@_ADD_SERVICE" & ", "
                Sql += "CALL_AUTO_FORCE = " & "@_CALL_AUTO_FORCE" & ", "
                Sql += "TB_REGISTER_QUEUE_HOLD_ID = " & "@_TB_REGISTER_QUEUE_HOLD_ID" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_COUNTER_QUEUE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_COUNTER_QUEUE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, TB_REGISTER_QUEUE_ID, MS_SERVICE_ID, MS_COUNTER_ID, MS_USER_ID, ASSIGN_TIME, CALL_TIME, START_TIME, END_TIME, STATUS, ADD_SERVICE, CALL_AUTO_FORCE, TB_REGISTER_QUEUE_HOLD_ID FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
