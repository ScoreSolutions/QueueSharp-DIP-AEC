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
    'Represents a transaction for MS_USER table LinqDB.
    '[Create by  on May, 22 2015]
    Public Class MsUserLinqDB
        Public sub MsUserLinqDB()

        End Sub 
        ' MS_USER
        Const _tableName As String = "MS_USER"
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
        Dim _MS_TITLE_ID As  System.Nullable(Of Long)  = 0
        Dim _FNAME As String = ""
        Dim _LNAME As String = ""
        Dim _MS_GROUP_ID As Long = 0
        Dim _USERNAME As String = ""
        Dim _PASSWORD As String = ""
        Dim _ACTIVE_STATUS As Long = 0
        Dim _MS_COUNTER_ID As Long = 0
        Dim _MS_SKILL_ID As Long = 0
        Dim _IP_ADDRESS As  String  = ""

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
        <Column(Storage:="_MS_TITLE_ID", DbType:="BigInt")>  _
        Public Property MS_TITLE_ID() As  System.Nullable(Of Long) 
            Get
                Return _MS_TITLE_ID
            End Get
            Set(ByVal value As  System.Nullable(Of Long) )
               _MS_TITLE_ID = value
            End Set
        End Property 
        <Column(Storage:="_FNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property FNAME() As String
            Get
                Return _FNAME
            End Get
            Set(ByVal value As String)
               _FNAME = value
            End Set
        End Property 
        <Column(Storage:="_LNAME", DbType:="VarChar(50) NOT NULL ",CanBeNull:=false)>  _
        Public Property LNAME() As String
            Get
                Return _LNAME
            End Get
            Set(ByVal value As String)
               _LNAME = value
            End Set
        End Property 
        <Column(Storage:="_MS_GROUP_ID", DbType:="BigInt NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_GROUP_ID() As Long
            Get
                Return _MS_GROUP_ID
            End Get
            Set(ByVal value As Long)
               _MS_GROUP_ID = value
            End Set
        End Property 
        <Column(Storage:="_USERNAME", DbType:="VarChar(20) NOT NULL ",CanBeNull:=false)>  _
        Public Property USERNAME() As String
            Get
                Return _USERNAME
            End Get
            Set(ByVal value As String)
               _USERNAME = value
            End Set
        End Property 
        <Column(Storage:="_PASSWORD", DbType:="VarChar(500) NOT NULL ",CanBeNull:=false)>  _
        Public Property PASSWORD() As String
            Get
                Return _PASSWORD
            End Get
            Set(ByVal value As String)
               _PASSWORD = value
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
        <Column(Storage:="_MS_COUNTER_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_COUNTER_ID() As Long
            Get
                Return _MS_COUNTER_ID
            End Get
            Set(ByVal value As Long)
               _MS_COUNTER_ID = value
            End Set
        End Property 
        <Column(Storage:="_MS_SKILL_ID", DbType:="Int NOT NULL ",CanBeNull:=false)>  _
        Public Property MS_SKILL_ID() As Long
            Get
                Return _MS_SKILL_ID
            End Get
            Set(ByVal value As Long)
               _MS_SKILL_ID = value
            End Set
        End Property 
        <Column(Storage:="_IP_ADDRESS", DbType:="VarChar(50)")>  _
        Public Property IP_ADDRESS() As  String 
            Get
                Return _IP_ADDRESS
            End Get
            Set(ByVal value As  String )
               _IP_ADDRESS = value
            End Set
        End Property 


        'Clear All Data
        Private Sub ClearData()
            _ID = 0
            _CREATE_BY = ""
            _CREATE_DATE = New DateTime(1,1,1)
            _UPDATE_BY = ""
            _UPDATE_DATE = New DateTime(1,1,1)
            _MS_TITLE_ID = 0
            _FNAME = ""
            _LNAME = ""
            _MS_GROUP_ID = 0
            _USERNAME = ""
            _PASSWORD = ""
            _ACTIVE_STATUS = 0
            _MS_COUNTER_ID = 0
            _MS_SKILL_ID = 0
            _IP_ADDRESS = ""
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


        '/// Returns an indication whether the current data is inserted into MS_USER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_USER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_USER table successfully.
        '/// <returns>true if update data successfully; otherwise, false.</returns>
        Public Function UpdateBySql(Sql As String, trans As SQLTransaction) As Boolean
            If trans IsNot Nothing Then 
                Return DB.ExecuteNonQuery(Sql, trans)
            Else 
                _error = "Transaction Is not null"
                Return False
            End If 
        End Function


        '/// Returns an indication whether the current data is deleted from MS_USER table successfully.
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


        '/// Returns an indication whether the record of MS_USER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByPK(cID As Long, trans As SQLTransaction) As Boolean
            Return doChkData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record and Mapping field to Data Class of MS_USER by specified id key is retrieved successfully.
        '/// <param name=cid>The id key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function GetDataByPK(cID As Long, trans As SQLTransaction) As MsUserLinqDB
            Return doGetData("ID = " & DB.SetDouble(cID), trans)
        End Function


        '/// Returns an indication whether the record of MS_USER by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByUSERNAME(cUSERNAME As String, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " ", trans)
        End Function

        '/// Returns an duplicate data record of MS_USER by specified USERNAME key is retrieved successfully.
        '/// <param name=cUSERNAME>The USERNAME key.</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDuplicateByUSERNAME(cUSERNAME As String, cid As Long, trans As SQLTransaction) As Boolean
            Return doChkData("USERNAME = " & DB.SetString(cUSERNAME) & " " & " And id <> " & DB.SetDouble(cid) & " ", trans)
        End Function


        '/// Returns an indication whether the record of MS_USER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Public Function ChkDataByWhere(whText As String, trans As SQLTransaction) As Boolean
            Return doChkData(whText, trans)
        End Function



        '/// Returns an indication whether the current data is inserted into MS_USER table successfully.
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


        '/// Returns an indication whether the current data is updated to MS_USER table successfully.
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


        '/// Returns an indication whether the current data is deleted from MS_USER table successfully.
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
            Dim cmbParam(14) As SqlParameter
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

            cmbParam(5) = New SqlParameter("@_MS_TITLE_ID", SqlDbType.BigInt)
            If _MS_TITLE_ID IsNot Nothing Then 
                cmbParam(5).Value = _MS_TITLE_ID.Value
            Else
                cmbParam(5).Value = DBNull.value
            End IF

            cmbParam(6) = New SqlParameter("@_FNAME", SqlDbType.VarChar)
            cmbParam(6).Value = _FNAME

            cmbParam(7) = New SqlParameter("@_LNAME", SqlDbType.VarChar)
            cmbParam(7).Value = _LNAME

            cmbParam(8) = New SqlParameter("@_MS_GROUP_ID", SqlDbType.BigInt)
            cmbParam(8).Value = _MS_GROUP_ID

            cmbParam(9) = New SqlParameter("@_USERNAME", SqlDbType.VarChar)
            cmbParam(9).Value = _USERNAME

            cmbParam(10) = New SqlParameter("@_PASSWORD", SqlDbType.VarChar)
            cmbParam(10).Value = _PASSWORD

            cmbParam(11) = New SqlParameter("@_ACTIVE_STATUS", SqlDbType.SmallInt)
            cmbParam(11).Value = _ACTIVE_STATUS

            cmbParam(12) = New SqlParameter("@_MS_COUNTER_ID", SqlDbType.Int)
            cmbParam(12).Value = _MS_COUNTER_ID

            cmbParam(13) = New SqlParameter("@_MS_SKILL_ID", SqlDbType.Int)
            cmbParam(13).Value = _MS_SKILL_ID

            cmbParam(14) = New SqlParameter("@_IP_ADDRESS", SqlDbType.VarChar)
            If _IP_ADDRESS.Trim <> "" Then 
                cmbParam(14).Value = _IP_ADDRESS
            Else
                cmbParam(14).Value = DBNull.value
            End If

            Return cmbParam
        End Function


        '/// Returns an indication whether the record of MS_USER by specified condition is retrieved successfully.
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
                        If Convert.IsDBNull(Rdr("ms_title_id")) = False Then _ms_title_id = Convert.ToInt64(Rdr("ms_title_id"))
                        If Convert.IsDBNull(Rdr("fname")) = False Then _fname = Rdr("fname").ToString()
                        If Convert.IsDBNull(Rdr("lname")) = False Then _lname = Rdr("lname").ToString()
                        If Convert.IsDBNull(Rdr("ms_group_id")) = False Then _ms_group_id = Convert.ToInt64(Rdr("ms_group_id"))
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("password")) = False Then _password = Rdr("password").ToString()
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Convert.ToInt16(Rdr("active_status"))
                        If Convert.IsDBNull(Rdr("ms_counter_id")) = False Then _ms_counter_id = Convert.ToInt32(Rdr("ms_counter_id"))
                        If Convert.IsDBNull(Rdr("ms_skill_id")) = False Then _ms_skill_id = Convert.ToInt32(Rdr("ms_skill_id"))
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
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


        '/// Returns an indication whether the record of MS_USER by specified condition is retrieved successfully.
        '/// <param name=whText>The condition specify the deleting record(s).</param>
        '/// <param name=trans>The System.Data.SQLClient.SQLTransaction used by this System.Data.SQLClient.SQLCommand.</param>
        '/// <returns>true if data is retrieved successfully; otherwise, false.</returns>
        Private Function doGetData(whText As String, trans As SQLTransaction) As MsUserLinqDB
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
                        If Convert.IsDBNull(Rdr("ms_title_id")) = False Then _ms_title_id = Convert.ToInt64(Rdr("ms_title_id"))
                        If Convert.IsDBNull(Rdr("fname")) = False Then _fname = Rdr("fname").ToString()
                        If Convert.IsDBNull(Rdr("lname")) = False Then _lname = Rdr("lname").ToString()
                        If Convert.IsDBNull(Rdr("ms_group_id")) = False Then _ms_group_id = Convert.ToInt64(Rdr("ms_group_id"))
                        If Convert.IsDBNull(Rdr("username")) = False Then _username = Rdr("username").ToString()
                        If Convert.IsDBNull(Rdr("password")) = False Then _password = Rdr("password").ToString()
                        If Convert.IsDBNull(Rdr("active_status")) = False Then _active_status = Convert.ToInt16(Rdr("active_status"))
                        If Convert.IsDBNull(Rdr("ms_counter_id")) = False Then _ms_counter_id = Convert.ToInt32(Rdr("ms_counter_id"))
                        If Convert.IsDBNull(Rdr("ms_skill_id")) = False Then _ms_skill_id = Convert.ToInt32(Rdr("ms_skill_id"))
                        If Convert.IsDBNull(Rdr("ip_address")) = False Then _ip_address = Rdr("ip_address").ToString()
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


        'Get Insert Statement for table MS_USER
        Private ReadOnly Property SqlInsert() As String 
            Get
                Dim Sql As String=""
                Sql += "INSERT INTO " & tableName  & " (CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, MS_TITLE_ID, FNAME, LNAME, MS_GROUP_ID, USERNAME, PASSWORD, ACTIVE_STATUS, MS_COUNTER_ID, MS_SKILL_ID, IP_ADDRESS)"
                Sql += " OUTPUT INSERTED.ID, INSERTED.CREATE_BY, INSERTED.CREATE_DATE, INSERTED.UPDATE_BY, INSERTED.UPDATE_DATE, INSERTED.MS_TITLE_ID, INSERTED.FNAME, INSERTED.LNAME, INSERTED.MS_GROUP_ID, INSERTED.USERNAME, INSERTED.PASSWORD, INSERTED.ACTIVE_STATUS, INSERTED.MS_COUNTER_ID, INSERTED.MS_SKILL_ID, INSERTED.IP_ADDRESS
                Sql += " VALUES("
                sql += "@_CREATE_BY" & ", "
                sql += "@_CREATE_DATE" & ", "
                sql += "@_UPDATE_BY" & ", "
                sql += "@_UPDATE_DATE" & ", "
                sql += "@_MS_TITLE_ID" & ", "
                sql += "@_FNAME" & ", "
                sql += "@_LNAME" & ", "
                sql += "@_MS_GROUP_ID" & ", "
                sql += "@_USERNAME" & ", "
                sql += "@_PASSWORD" & ", "
                sql += "@_ACTIVE_STATUS" & ", "
                sql += "@_MS_COUNTER_ID" & ", "
                sql += "@_MS_SKILL_ID" & ", "
                sql += "@_IP_ADDRESS"
                sql += ")"
                Return sql
            End Get
        End Property


        'Get update statement form table MS_USER
        Private ReadOnly Property SqlUpdate() As String
            Get
                Dim Sql As String = ""
                Sql += "UPDATE " & tableName & " SET "
                Sql += "CREATE_BY = " & "@_CREATE_BY" & ", "
                Sql += "CREATE_DATE = " & "@_CREATE_DATE" & ", "
                Sql += "UPDATE_BY = " & "@_UPDATE_BY" & ", "
                Sql += "UPDATE_DATE = " & "@_UPDATE_DATE" & ", "
                Sql += "MS_TITLE_ID = " & "@_MS_TITLE_ID" & ", "
                Sql += "FNAME = " & "@_FNAME" & ", "
                Sql += "LNAME = " & "@_LNAME" & ", "
                Sql += "MS_GROUP_ID = " & "@_MS_GROUP_ID" & ", "
                Sql += "USERNAME = " & "@_USERNAME" & ", "
                Sql += "PASSWORD = " & "@_PASSWORD" & ", "
                Sql += "ACTIVE_STATUS = " & "@_ACTIVE_STATUS" & ", "
                Sql += "MS_COUNTER_ID = " & "@_MS_COUNTER_ID" & ", "
                Sql += "MS_SKILL_ID = " & "@_MS_SKILL_ID" & ", "
                Sql += "IP_ADDRESS = " & "@_IP_ADDRESS" + ""
                Return Sql
            End Get
        End Property


        'Get Delete Record in table MS_USER
        Private ReadOnly Property SqlDelete() As String
            Get
                Dim Sql As String = "DELETE FROM " & tableName
                Return Sql
            End Get
        End Property


        'Get Select Statement for table MS_USER
        Private ReadOnly Property SqlSelect() As String
            Get
                Dim Sql As String = "SELECT ID, CREATE_BY, CREATE_DATE, UPDATE_BY, UPDATE_DATE, MS_TITLE_ID, FNAME, LNAME, MS_GROUP_ID, USERNAME, PASSWORD, ACTIVE_STATUS, MS_COUNTER_ID, MS_SKILL_ID, IP_ADDRESS FROM " & tableName
                Return Sql
            End Get
        End Property

    End Class
End Namespace
