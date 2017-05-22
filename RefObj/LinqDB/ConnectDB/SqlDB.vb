﻿Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing

Namespace ConnectDB
    Public MustInherit Class SqlDB
        Protected Shared ErrorConnectionString As String = MessageResources.MSGEC001
        Private Shared ErrorConnection As String = MessageResources.MSGEC002
        Private Shared ErrorSetCommandConnection As String = MessageResources.MSGEC003
        Private Shared ErrorInvalidCommandType As String = MessageResources.MSGEC004
        Private Shared ErrorDuplicateParameter As String = MessageResources.MSGEC006
        Private Shared ErrorNullParameter As String = MessageResources.MSGEC005
        Private Shared ErrorExecuteNonQuery As String = MessageResources.MSGEC010
        Private Shared ErrorExecuteReader As String = MessageResources.MSGEC011
        Private Shared ErrorExecuteTable As String = MessageResources.MSGEC012
        Private Shared ErrorExecuteScalar As String = MessageResources.MSGEC013
        Private Shared ErrorDatabaseOther As String = MessageResources.MSGEC901
        Private Shared ErrorUndefined As String = MessageResources.MSGEC902

        Protected Shared _err As String
        Public Shared ReadOnly Property ErrorMessage()
            Get
                Return _err
            End Get
        End Property

        Friend Shared Function SetDouble(ByVal number As System.Nullable(Of Double)) As String
            Dim ret As String
            If Convert.IsDBNull(number) Then
                ret = "NULL"
            ElseIf number Is Nothing Then
                ret = "NULL"
            Else
                ret = number.ToString()
            End If
            Return ret
        End Function
        Friend Shared Function SetDecimal(ByVal number As System.Nullable(Of Decimal)) As String
            Dim ret As String
            If Convert.IsDBNull(number) Then
                ret = "NULL"
            ElseIf number Is Nothing Then
                ret = "NULL"
            Else
                ret = number.ToString()
            End If
            Return ret
        End Function
        Friend Shared Function SetString(ByVal str As String) As String
            Dim ret As String = ""
            If str Is Nothing Or str.Trim() = "" Then
                ret = "NULL"
            Else
                ret = Chr(39) & str.Trim().Replace("'", "''") & Chr(39)
            End If
            Return ret
        End Function
        Friend Shared Function SetDate() As String
            Return SetDateTime(DateTime.Today)
        End Function
        Friend Shared Function SetDate(ByVal DateIn As DateTime) As String
            Return SetDateTime(DateIn)
        End Function
        Friend Shared Function SetDateTime() As String
            Return SetDateTime(DateTime.Today)
        End Function
        Friend Shared Function SetDate(DateIn As String) As String
            'แปลง Format วันที่จาก dd/mm/yyyy (ปี พ.ศ.) ให้อยู่ในรูป yyyy-MM-dd เพื่อทำการ Insert ลง DB
            Dim ret As String = ""
            If DateIn.Length = 10 Then
                Dim tmpDate() As String = Split(DateIn, "/")
                Dim yy As Integer = Convert.ToInt32(tmpDate(2)) - 543
                Dim mm As Integer = tmpDate(1)
                Dim dd As Integer = tmpDate(0)

                ret = SetDate(New Date(yy, mm, dd))
            Else
                ret = "NULL"
            End If

            Return ret
        End Function
        Friend Shared Function SetDateTime(ByVal DateIn As DateTime) As String
            Dim ret As String = ""
            If DateIn.Year = 1 Or Convert.IsDBNull(DateIn) Then
                ret = "NULL"
            ElseIf DateIn.Year > 2500 Then
                Dim vYear As String = DateIn.Year - 543
                ret = "'" & vYear & "-" & DateIn.ToString("MM-dd HH:mm:ss") & "'"
            Else
                ret = "'" & DateIn.Year & "-" & DateIn.ToString("MM-dd HH:mm:ss") & "'"
            End If
            Return ret
        End Function

        Friend Shared Function SetImage(ImageIn As Image) As Byte()
            Dim ret As Byte() = Nothing
            If ImageIn IsNot Nothing Then
                Dim imageConverter As New ImageConverter()
                ret = DirectCast(imageConverter.ConvertTo(ImageIn, GetType(Byte())), Byte())
            End If

            Return ret
        End Function
        Friend Shared Function GetExceptionMessage(ByVal ex As SqlException) As String
            Return String.Format(ErrorDatabaseOther, ex.ErrorCode.ToString(), ex.Message)
        End Function

        Friend Shared Function GetDateDiff(DateFrom As DateTime, DateTo As DateTime) As Integer
            Return DateDiff(DateInterval.Day, DateFrom, DateTo)
        End Function
        Friend Shared Function GetMonthDiff(DateFrom As DateTime, DateTo As DateTime) As Integer
            Return DateDiff(DateInterval.Month, DateFrom, DateTo)
        End Function
        Friend Shared Function GetYearDiff(DateFrom As DateTime, DateTo As DateTime) As Integer
            Return DateDiff(DateInterval.Year, DateFrom, DateTo)
        End Function
        Friend Shared Function GetHourDiff(TimeFrom As DateTime, TimeTo As DateTime) As Integer
            Return DateDiff(DateInterval.Hour, TimeFrom, TimeTo)
        End Function
        Friend Shared Function GetMinuteDiff(TimeFrom As DateTime, TimeTo As DateTime) As Integer
            Return DateDiff(DateInterval.Minute, TimeFrom, TimeTo)
        End Function
        Friend Shared Function GetSecondDiff(TimeFrom As DateTime, TimeTo As DateTime) As Integer
            Return DateDiff(DateInterval.Second, TimeFrom, TimeTo)
        End Function

        Public Shared Function GetNextID(ByVal fldName As String, ByVal tbName As String, ByVal trans As SqlTransaction, ConnStr As String) As Long
            Dim ret As Long
            Dim Sql As String = "select max(" & fldName & ") maxID from " & tbName
            Dim dt As DataTable = ExecuteTable(Sql, Nothing, trans, Nothing, ConnStr)
            If dt.Rows.Count > 0 Then
                If Convert.IsDBNull(dt.Rows(0)("maxID")) = False Then
                    ret = Convert.ToInt64(dt.Rows(0)("maxID").ToString()) + 1
                Else
                    ret = 1
                End If
            Else
                ret = 1
            End If
            Return ret
        End Function

        Protected Shared Function GetLastID(ByVal tbName As String, ByVal trans As SqlTransaction, ConnStr As String) As Long
            Dim ret As Long
            Dim Sql As String = "select IDENT_CURRENT('" & tbName & "') lastID "
            Dim dt As DataTable = ExecuteTable(Sql, Nothing, trans, Nothing, ConnStr)
            If Convert.IsDBNull(dt.Rows(0)("lastID")) = False Then
                ret = Convert.ToInt64(dt.Rows(0)("lastID").ToString())
            Else
                ret = 1
            End If

            Return ret
        End Function

        Public Shared Function GetDateNow(ByVal rtType As String, ByVal trans As SqlTransaction, ConnStr As String) As String
            'rtType = D  ให้คืนค่าเป็นวันที่ในรูปแบบ yyyy-MM-dd
            'rtType = T  ให้คืนค่าเป็นเวลาปัจจุบัน hh:mm
            Dim ret As String
            Dim dt As DataTable = ExecuteTable("select convert(varchar(10),getdate(),120) date_now, CONVERT(varchar(5),getdate(),108) time_now", Nothing, trans, Nothing, ConnStr)
            If rtType = "D" Then
                ret = dt.Rows(0)("date_now")
            ElseIf rtType = "T" Then
                ret = dt.Rows(0)("time_now")
            Else
                ret = dt.Rows(0)("date_now") & " " & dt.Rows(0)("time_now")
            End If

            Return ret
        End Function

        Public Shared Function GetDateNowFromDB(ByVal trans As SqlTransaction) As Date
            Dim ret As String
            Dim dt As DataTable = ExecuteTable("select getdate() date_now", Nothing, trans, Nothing, "")
            ret = dt.Rows(0)("date_now")
            Return ret
        End Function

#Region "Execute Non Query"
        Public Shared Function ExecuteNonQuery(ByVal Sql As String) As Boolean
            Return ExecuteNonQuery(Sql, Nothing, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal conn As SqlConnection) As Boolean
            Return ExecuteNonQuery(Sql, conn, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal trans As SqlTransaction) As Boolean
            Return ExecuteNonQuery(Sql, Nothing, trans, Nothing)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter) As Boolean
            Return ExecuteNonQuery(Sql, Nothing, trans, cmdParms)
        End Function
        Public Shared Function ExecuteNonQuery(ByVal Sql As String, conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter) As Boolean
            Return ExecuteNonQuery(Sql, conn, trans, cmdParms, GetConnectionString)
        End Function

        Protected Shared Function ExecuteNonQuery(ByVal Sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdParms() As SqlParameter, ConnStr As String) As Boolean
            Dim retval As Boolean = False
            Dim command As New SqlCommand

            Try
                If trans Is Nothing Then
                    conn = GetConnection(ConnStr)
                    BuildCommand(command, conn, trans, CommandType.Text, Sql, cmdParms)
                    command.ExecuteNonQuery()
                    retval = True
                Else
                    If trans IsNot Nothing And conn Is Nothing Then
                        conn = trans.Connection
                    End If

                    BuildCommand(command, trans.Connection, trans, CommandType.Text, Sql, cmdParms)
                    command.ExecuteNonQuery()
                    retval = True
                End If
            Catch ex As ApplicationException
                _err = "ApplicationException : " & Sql & " $$$$ " & ex.Message
                retval = False
            Catch ex As SqlException
                _err = "SqlException : " & Sql & " $$$$ " & ex.Message
                retval = False
            Catch ex As Exception
                _err = "Exception : " & Sql & " $$$$ " & ex.Message
                retval = False
            End Try

            Return retval
        End Function
#End Region

#Region "Execure Table"
        Private Shared Function ExecuteTable(ByVal sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, cmdParam() As SqlParameter, ConnStr As String) As DataTable
            Dim cmd As New SqlCommand
            Dim adapter As New SqlDataAdapter
            adapter.SelectCommand = cmd
            Dim LetClose As Boolean = False
            Dim dt As New DataTable
            Try
                If trans IsNot Nothing And conn Is Nothing Then
                    conn = trans.Connection
                ElseIf conn Is Nothing Then
                    conn = GetConnection(ConnStr)
                    LetClose = True
                End If

                BuildCommand(cmd, conn, trans, CommandType.Text, sql, cmdParam)
                adapter.Fill(dt)
                adapter.Dispose()
                If LetClose = True Then
                    cmd.Dispose()
                    conn.Close()
                End If
            Catch ex As ApplicationException
                _err = "ApplicationException : " & sql & " $$$$ " & ex.Message
                adapter.Dispose()
            Catch ex As SqlException
                _err = "SqlException : " & sql & " $$$$ " & ex.Message
                adapter.Dispose()
            Catch ex As Exception
                _err = "Exception : " & sql & " $$$$ " & ex.Message
                adapter.Dispose()
            End Try

            Return dt
        End Function

        Public Shared Function ExecuteTable(ByVal sql As String) As DataTable
            Return ExecuteTable(sql, Nothing, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, cmdParam() As SqlParameter) As DataTable
            Return ExecuteTable(sql, Nothing, Nothing, cmdParam)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal conn As SqlConnection) As DataTable
            Return ExecuteTable(sql, conn, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal trans As SqlTransaction) As DataTable
            Return ExecuteTable(sql, Nothing, trans, Nothing)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, ByVal trans As SqlTransaction, cmdParam() As SqlParameter) As DataTable
            Return ExecuteTable(sql, Nothing, trans, cmdParam, GetConnectionString)
        End Function
        Public Shared Function ExecuteTable(ByVal sql As String, conn As SqlConnection, ByVal trans As SqlTransaction, cmdParam() As SqlParameter) As DataTable
            Return ExecuteTable(sql, conn, trans, cmdParam, GetConnectionString)
        End Function

#End Region

#Region "Execute Reader"

        Public Shared Function ExecuteReader(ByVal Sql As String) As SqlDataReader
            Return ExecuteReader(Sql, Nothing, Nothing)
        End Function
        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal trans As SqlTransaction) As SqlDataReader
            Return ExecuteReader(Sql, Nothing, trans)
        End Function

        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection) As SqlDataReader
            Return ExecuteReader(Sql, conn, Nothing)
        End Function
        Public Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SqlDataReader
            Return ExecuteReader(Sql, conn, trans, GetConnectionString)
        End Function
        Protected Shared Function ExecuteReader(ByVal Sql As String, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ConnStr As String) As SqlDataReader
            Dim command As New SqlCommand()
            Dim reader As SqlDataReader
            Dim LetClose As Boolean = False

            Try
                If trans IsNot Nothing And conn Is Nothing Then
                    conn = trans.Connection
                ElseIf conn Is Nothing Then
                    conn = GetConnection(ConnStr)
                    LetClose = True
                End If

                BuildCommand(command, conn, trans, CommandType.Text, Sql, Nothing)
                If LetClose = True Then
                    reader = command.ExecuteReader(CommandBehavior.CloseConnection)
                Else
                    reader = command.ExecuteReader()
                End If
            Catch ex As ApplicationException
                _err = "ApplicationException : " & Sql & " $$$$ " & ex.Message
            Catch ex As SqlException
                _err = "SqlException : " & Sql & " $$$$ " & ex.Message
            Catch ex As Exception
                _err = "Exception : " & Sql & " $$$$ " & ex.Message
            End Try

            Return reader
        End Function
#End Region

        Public Shared Function GetConnection(ByVal connString As String) As SqlConnection
            Dim conn As SqlConnection
            Try
                conn = New SqlConnection(connString)
                conn.Open()
                Return conn
            Catch ex As ApplicationException
                'Throw ex
                _err = ex.Message
            Catch ex As SqlException
                _err = ex.Message
                'Throw New ApplicationException(ErrorConnection, ex)
            Catch ex As Exception
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
                _err = ex.Message
            End Try
        End Function

        Friend Shared Function ChkConnection(ByVal connString As String) As Boolean
            Dim ret As Boolean = False
            Dim conn As SqlConnection
            Try
                conn = New SqlConnection(connString)
                conn.Open()

                ret = True
            Catch ex As ApplicationException
                'Throw ex
                _err = ex.Message
                ret = False
            Catch ex As SqlException
                Try
                    conn = New SqlConnection(connString)
                    conn.Open()
                    ret = True
                Catch ex1 As SqlException
                    _err = ex1.Message
                    ret = False
                End Try
            Catch ex As Exception
                'Throw New ApplicationException(GetExceptionMessage(ex), ex)
                _err = ex.Message
                ret = False
            End Try

            Return ret
        End Function

        Private Shared Sub BuildCommand(ByVal cmd As SqlCommand, ByVal conn As SqlConnection, ByVal trans As SqlTransaction, ByVal cmdType As CommandType, ByVal cmdText As String, ByVal cmdParms() As SqlParameter)
            If conn.State <> ConnectionState.Open Then
                Try
                    conn.Open()
                Catch ex As SqlException
                    'Throw New ApplicationException(GetExceptionMessage(ex), ex)
                    _err = ex.Message
                Catch ex As ApplicationException
                    'Throw (ex)
                    _err = ex.Message
                Catch ex As Exception
                    'Throw New ApplicationException(ErrorConnection, ex)
                    _err = ex.Message
                End Try
            End If

            Try
                cmd.Connection = conn
            Catch ex As Exception
                'Throw New ApplicationException(ErrorSetCommandConnection, ex)
                _err = ex.Message
            End Try
            cmd.CommandText = cmdText

            If trans IsNot Nothing Then
                cmd.Transaction = trans
            End If

            Try
                cmd.CommandType = cmdType
                cmd.CommandTimeout = 240
            Catch ex As ArgumentException
                'Throw New ApplicationException(ErrorInvalidCommandType, ex)
                _err = ex.Message
            End Try

            If cmdParms IsNot Nothing Then
                For Each parm As SqlParameter In cmdParms
                    Try
                        cmd.Parameters.Add(parm)
                    Catch ex As ArgumentNullException
                        'Throw New ApplicationException(ErrorNullParameter, ex)
                        _err = ex.Message
                    Catch ex As ArgumentException
                        'Throw New ApplicationException(ErrorDuplicateParameter, ex)
                        _err = ex.Message
                    End Try
                Next
            End If
        End Sub

#Region "Get Connection String"
        Protected Shared ReadOnly Property INIFileName() As IniReader
            Get
                Dim INIFlie As String = "C:\Windows\QueueSharp-DIP-AEC.ini"
                Dim ini As New IniReader(INIFlie)
                ini.Section = "Setting"
                Return ini
            End Get
        End Property

        Private Shared ReadOnly Property GetConnectionString() As String
            Get
                Try
                    Dim ini As IniReader = INIFileName
                    Dim DBServerName As String = ini.ReadString("MainServer")
                    Dim DBDatabaseName As String = ini.ReadString("MainDatabase")
                    Dim DBDbUserID As String = ini.ReadString("MainUsername")
                    Dim DBDbPwd As String = DeCripPwd(ini.ReadString("MainPassword"))
                    ini = Nothing

                    Dim ret As String = "Data Source=" & DBServerName & ";Initial Catalog=" & DBDatabaseName & ";User ID=" & DBDbUserID & ";Password=" & DBDbPwd

                    Return ret
                Catch ex As Exception
                    Throw New ApplicationException(ErrorConnectionString, ex)
                End Try
            End Get
        End Property

        Public Shared Function GetConnection() As SqlConnection
            Return GetConnection(GetConnectionString)
        End Function


        Public Shared Function ChkConnection() As Boolean
            Return ChkConnection(GetConnectionString)
        End Function
#End Region

#Region " Encrypt/Decrypt "
        Private Shared EncryptionKey As String = "scoresolutions14"
        Public Shared Function EnCripPwd(ByVal passString As String) As String
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim encrypted As String = ""
            Try
                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(EncryptionKey))
                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)
                AES.Key = hash
                AES.Mode = Security.Cryptography.CipherMode.ECB
                Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
                Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(passString)
                encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

            Catch ex As Exception
            End Try

            Return encrypted
        End Function

        Public Shared Function DeCripPwd(ByVal passString As String) As String
            Dim AES As New System.Security.Cryptography.RijndaelManaged
            Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
            Dim decrypted As String = ""
            Try
                Dim hash(31) As Byte
                Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(EncryptionKey))
                Array.Copy(temp, 0, hash, 0, 16)
                Array.Copy(temp, 0, hash, 15, 16)
                AES.Key = hash
                AES.Mode = Security.Cryptography.CipherMode.ECB
                Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
                Dim Buffer As Byte() = Convert.FromBase64String(passString)
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Catch ex As Exception
            End Try

            Return decrypted
        End Function
#End Region
    End Class
End Namespace

