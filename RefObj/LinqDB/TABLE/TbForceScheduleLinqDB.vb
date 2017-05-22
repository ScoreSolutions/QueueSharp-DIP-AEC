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
    'Represents a transaction for TB_FORCE_SCHEDULE table LinqDB.
    '[Create by  on May, 22 2015]
    Public Class TbForceScheduleLinqDB
        Public sub TbForceScheduleLinqDB()

        End Sub 
        ' TB_FORCE_SCHEDULE
        Const _tableName As String = "TB_FORCE_SCHEDULE"
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
        Dim _FORCE_DATE As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _WAIT As  System.Nullable(Of Long)  = 0
        Dim _START_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _END_TIME As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _SLOT As  System.Nullable(Of Long)  = 0
        Dim _START_SLOT As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)
        Dim _END_SLOT As  System.Nullable(Of DateTime)  = New DateTime(1,1,1)

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
        <Column(Storage:="_FORCE_DATE", DbType:="DateTime")>  _
        Public Property FORCE_DATE() As  System.Nullable(Of DateTime) 
            Get
                Return _FORCE_DATE
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _FORCE_DATE = value
            End Set
        End Property 
        <Column(Storage:="_WAIT", DbType:="Int")>  _
        Public Property WAIT() As  System.Nullable(Of Long) 
            Get
                Return _WAIT
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _WAIT = value
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
        <Column(Storage:="_SLOT", DbType:="Int")>  _
        Public Property SLOT() As  System.Nullable(Of Long) 
            Get
                Return _SLOT
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _SLOT = value
            End Set
        End Property 
        <Column(Storage:="_START_SLOT", DbType:="DateTime")>  _
        Public Property START_SLOT() As  System.Nullable(Of DateTime) 
            Get
                Return _START_SLOT
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _START_SLOT = value
            End Set
        End Property 
        <Column(Storage:="_END_SLOT", DbType:="DateTime")>  _
        Public Property END_SLOT() As  System.Nullable(Of DateTime) 
            Get
                Return _END_SLOT
            End Get
            Set(ByVal value As  System.Nullable(Of DateTime) )
               _END_SLOT = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_DATE = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_DATE = New DateTime(1,1,1)
            _FORCE_DATE = New DateTime(1,1,1)
            _WAIT = 0
            _START_TIME = New DateTime(1,1,1)
            _END_TIME = New DateTime(1,1,1)
            _SLOT = 0
            _START_SLOT = New DateTime(1,1,1)
            _END_SLOT = New DateTime(1,1,1)
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


        '/// Returns an indication whether the current data is inserted into TB_FORCE_SCHEDULE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FORCE_SCHEDULE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FORCE_SCHEDULE table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from TB_FORCE_SCHEDULE table successfully.
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


        '/// Returns an indication whether the record of TB_FORCE_SCHEDULE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of TB_FORCE_SCHEDULE by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As TbForceScheduleLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of TB_FORCE_SCHEDULE by specified FORCE_DATE key is retrieved successfully.
        '/// <param name=cFORCE_DATE>The FORCE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByFORCE_DATE(cFORCE_DATE As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("FORCE_DATE = " & DB.SetDateTime(cFORCE_DATE) & " ", trans)
        End Function

        '/// Returns an duplicate data record of TB_FORCE_SCHEDULE by specified FORCE_DATE key is retrieved successfully.
        '/// <param name=cFORCE_DATE>The FORCE_DATE key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByFORCE_DATE(cFORCE_DATE As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("FORCE_DATE = " & DB.SetDateTime(cFORCE_DATE) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FORCE_SCHEDULE by specified END_TIME_SLOT_START_TIME key is retrieved successfully.
        '/// <param name=cEND_TIME_SLOT_START_TIME>The END_TIME_SLOT_START_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByEND_TIME_SLOT_START_TIME(cEND_TIME As DateTime, cSLOT As Integer, cSTART_TIME As DateTime, trans As SQLTransaction) As Boolean
            Return doChkData("END_TIME = " & DB.SetDateTime(cEND_TIME) & " AND SLOT = " & DB.SetDouble(cSLOT) & " AND START_TIME = " & DB.SetDateTime(cSTART_TIME), trans)
        End Function

        '/// Returns an duplicate data record of TB_FORCE_SCHEDULE by specified END_TIME_SLOT_START_TIME key is retrieved successfully.
        '/// <param name=cEND_TIME_SLOT_START_TIME>The END_TIME_SLOT_START_TIME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByEND_TIME_SLOT_START_TIME(cEND_TIME As DateTime, cSLOT As Integer, cSTART_TIME As DateTime, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("END_TIME = " & DB.SetDateTime(cEND_TIME) & " AND SLOT = " & DB.SetDouble(cSLOT) & " AND START_TIME = " & DB.SetDateTime(cSTART_TIME) & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of TB_FORCE_SCHEDULE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into TB_FORCE_SCHEDULE table successfully.
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


        '/// Returns an indication whether the current data is updated to TB_FORCE_SCHEDULE table successfully.
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


        '/// Returns an indication whether the current data is deleted from TB_FORCE_SCHEDULE table successfully.
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

            cmbParam(5) = New SqlParameter("@_FORCE_DATE", SqlDbType.DateTime)
            If _FORCE_DATE.Value.Year > 1 Then 
                cmbParam(5).Value = _FORCE_DATE.Value
            Else
                cmbParam(5).Value = DBNull.value
            End If

            cmbParam(6) = New SqlParameter("@_WAIT", SqlDbType.Int)
            If _WAIT IsNot Nothing Then 
                cmbParam(6).Value = _WAIT.Value
            Else
                cmbParam(6).Value = DBNull.value
            End IF

            cmbParam(7) = New SqlParameter("@_START_TIME", SqlDbType.DateTime)
            If _START_TIME.Value.Year > 1 Then 
                cmbParam(7).Value = _START_TIME.Value
            Else
                cmbParam(7).Value = DBNull.value
            End If

            cmbParam(8) = New SqlParameter("@_END_TIME", SqlDbType.DateTime)
            If _END_TIME.Value.Year > 1 Then 
                cmbParam(8).Value = _END_TIME.Value
            Else
                cmbParam(8).Value = DBNull.value
            End If

            cmbParam(9) = New SqlParameter("@_SLOT", SqlDbType.Int)
            If _SLOT IsNot Nothing Then 
                cmbParam(9).Value = _SLOT.Value
            Else
                cmbParam(9).Value = DBNull.value
            End IF

            cmbParam(10) = New SqlParameter("@_START_SLOT", SqlDbType.DateTime)
            If _START_SLOT.Value.Year > 1 Then 
                cmbParam(10).Value = _START_SLOT.Value
            Else
                cmbParam(10).Value = DBNull.value
            End If

            cmbParam(11) = New SqlParameter("@_END_SLOT", SqlDbType.DateTime)
            If _END_SLOT.Value.Year > 1 Then 
                cmbParam(11).Value = _END_SLOT.Value
            Else
                cmbParam(11).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of TB_FORCE_SCHEDULE by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("force_date")) = False Then _force_date = Convert.ToDateTime(Rdr("force_date"))
                        If Convert.IsDBNull(Rdr("wait")) = False Then _wait = Convert.ToInt32(Rdr("wait"))
                        If Convert.IsDBNull(Rdr("start_time")) = False Then _start_time = Convert.ToDateTime(Rdr("start_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then _end_time = Convert.ToDateTime(Rdr("end_time"))
                        If Convert.IsDBNull(Rdr("slot")) = False Then _slot = Convert.ToInt32(Rdr("slot"))
                        If Convert.IsDBNull(Rdr("start_slot")) = False Then _start_slot = Convert.ToDateTime(Rdr("start_slot"))
                        If Convert.IsDBNull(Rdr("end_slot")) = False Then _end_slot = Convert.ToDateTime(Rdr("end_slot"))
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


        '/// Returns an indication whether the record of TB_FORCE_SCHEDULE by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As TbForceScheduleLinqDB
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
                        If Convert.IsDBNull(Rdr("force_date")) = False Then _force_date = Convert.ToDateTime(Rdr("force_date"))
                        If Convert.IsDBNull(Rdr("wait")) = False Then _wait = Convert.ToInt32(Rdr("wait"))
                        If Convert.IsDBNull(Rdr("start_time")) = False Then _start_time = Convert.ToDateTime(Rdr("start_time"))
                        If Convert.IsDBNull(Rdr("end_time")) = False Then _end_time = Convert.ToDateTime(Rdr("end_time"))
                        If Convert.IsDBNull(Rdr("slot")) = False Then _slot = Convert.ToInt32(Rdr("slot"))
                        If Convert.IsDBNull(Rdr("start_slot")) = False Then _start_slot = Convert.ToDateTime(Rdr("start_slot"))
                        If Convert.IsDBNull(Rdr("end_slot")) = False Then _end_slot = Convert.ToDateTime(Rdr("end_slot"))
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


        'Get Insert Statement for table TB_FORCE_SCHEDULE
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, FORCE_DATE, WAIT, START_TIME, END_TIME, SLOT, START_SLOT, END_SLOT)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATE_BY, INSERTED.CREATE_DATE, INSERTED.UPDATE_BY, INSERTED.UPDATE_DATE, INSERTED.FORCE_DATE, INSERTED.WAIT, INSERTED.START_TIME, INSERTED.END_TIME, INSERTED.SLOT, INSERTED.START_SLOT, INSERTED.END_SLOT
                Sql += " VALUES("
                sql += "@_CREATE_BY" & ", "
                sql += "@_CREATE_DATE" & ", "
                sql += "@_UPDATE_BY" & ", "
                sql += "@_UPDATE_DATE" & ", "
                sql += "@_FORCE_DATE" & ", "
                sql += "@_WAIT" & ", "
                sql += "@_START_TIME" & ", "
                sql += "@_END_TIME" & ", "
                sql += "@_SLOT" & ", "
                sql += "@_START_SLOT" & ", "
                sql += "@_END_SLOT"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table TB_FORCE_SCHEDULE
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATE_BY = " & "@_CREATE_BY" & ", "
                Sql += "CREATE_DATE = " & "@_CREATE_DATE" & ", "
                Sql += "UPDATE_BY = " & "@_UPDATE_BY" & ", "
                Sql += "UPDATE_DATE = " & "@_UPDATE_DATE" & ", "
                Sql += "FORCE_DATE = " & "@_FORCE_DATE" & ", "
                Sql += "WAIT = " & "@_WAIT" & ", "
                Sql += "START_TIME = " & "@_START_TIME" & ", "
                Sql += "END_TIME = " & "@_END_TIME" & ", "
                Sql += "SLOT = " & "@_SLOT" & ", "
                Sql += "START_SLOT = " & "@_START_SLOT" & ", "
                Sql += "END_SLOT = " & "@_END_SLOT" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table TB_FORCE_SCHEDULE
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table TB_FORCE_SCHEDULE
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, FORCE_DATE, WAIT, START_TIME, END_TIME, SLOT, START_SLOT, END_SLOT FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
