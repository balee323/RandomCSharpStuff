Imports System.Data
Imports System.Data.SqlClient  ' for dataSource
Imports System.Configuration

''' <summary>
''' Author:  Brian Lee
''' Connection Class Utility
''' </summary>
Public Class Connection


    'Pick a connection
    '****************************************
    'for using database file

    'for SQL Express
    '   Private ConnString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\temp\ProductWarehouse.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
    '   Private ConnString As String = "Data Source=.\SQLEXPRESS10;AttachDbFilename=C:\temp\ProductWarehouse.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
    'for MSSQLSERVER   -->  might have to change the permissions on the .mdf and .ldf - set to read& write 

    Private ConnString As String = ""



    'Private SqlConn As SqlConnection
    Private Shared SqlConn As SqlConnection
    Private Shared IsOpen As Boolean = False

        Private ShowConnStatus As Boolean
        Private ErrorMsg As String = ""


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ConnString"> Pass Connection String as Parameter</param>
    Public Sub New(ByVal ConnString As String)
        SqlConn = New SqlConnection()
        Me.ConnString = ConnString
        ' DBConn_Open()
    End Sub

    'Default Constructor
    Public Sub New()

        Try
            '  Me.ConnString = ConfigurationManager.AppSettings("DBConn")
            '  ConnString = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\temp\TwitterDatabase\TwitterData.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
            '  ConnString = "Data Source=.\SQLEXPRESS;Database=TwitterData;Integrated Security=True; Connect Timeout=5;User Instance=True;"

            ConnString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Temp\TwitterDatabase\TwitterData.mdf;Integrated Security=True;Connect Timeout=5" 'This is the only way this works
        Catch ex As Exception
            'Error using App.configuration, using default connection string
            ConnString = "Data Source=.;AttachDbFilename=C:\Temp\TwitterDatabase\TwitterData.mdf;Integrated Security=True;Connect Timeout=5;"

            MsgBox("Connection.VB: Error with Assigning connection String From App.config")
        End Try

        SqlConn = New SqlConnection()

        'DBConn_Open()

    End Sub

    Public Function test() As Boolean
            Dim ConnectionStatus As Boolean = False

            Try
                DBConn_Open()
                ConnectionStatus = getConnStatus()
                DBConn_close()
            Catch ex As Exception
                ConnectionStatus = False
            End Try


        Return ConnectionStatus
        End Function


        Private Sub DBConn_close()
            Try
            SqlConn.Close()
            SqlConn.Dispose()

        Catch ex As Exception
                MsgBox(ex.Message)
                ErrorMsg = ex.Message
            End Try

        End Sub

        Private Sub DBConn_Open()

            If IsOpen = False Then
                Try
                    SqlConn.ConnectionString = ConnString
                    SqlConn.Open()
                Catch ex As Exception
                'Error handling code here....
                MsgBox(ex.Message)
                ' ErrorMsg = ex.Message
                End
            End Try
            End If

            If ShowConnStatus Then
                '   MsgBox("Connection is Open = " & CBool(SqlConn.State()))
            End If

        End Sub


        Private Function getConnStatus() As Boolean
            Return CBool(SqlConn.State)
        End Function


        Public Function getErrorMsg() As String
            Return ErrorMsg
        End Function

        Public Function SqlCmdSingleReturn(ByVal cmdText As String) As String

            DBConn_Open()

            Dim sqlDataAdapter As New SqlDataAdapter()

            Dim reader As SqlDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = cmdText

            cmd.CommandType = CommandType.Text
            cmd.Connection = SqlConn

            reader = cmd.ExecuteReader()

            Dim returnedPass As String = ""

            If reader.HasRows Then
                reader.Read()
                returnedPass = reader.GetString(0)

            End If

            reader.Close()
            SqlConn.Close()

            Return returnedPass

        End Function


        Public Function SqlCmdReturn(ByVal cmdText As String) As DataSet

            DBConn_Open()

            Dim sqlDataAdapter As New SqlDataAdapter()
            Dim dataSet As New DataSet()

            Dim cmd As New SqlCommand()
            cmd.CommandText = cmdText

            cmd.CommandType = CommandType.Text
            cmd.Connection = SqlConn

            sqlDataAdapter.SelectCommand = cmd

            Try
                sqlDataAdapter.Fill(dataSet, "Data")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            SqlConn.Close()

            Return dataSet

        End Function


        Public Sub InsertUpdateDB(ByVal cmdText As String)

            DBConn_Open()

        Dim cmd As New SqlCommand()
            cmd.CommandText = cmdText

            cmd.CommandType = CommandType.Text
            cmd.Connection = SqlConn
            cmd.ExecuteScalar()

            SqlConn.Close()

        End Sub


    ''' <summary>
    ''' Author: Brian Lee
    '''  Function Stored procedure with optional parameters.  Pass Stored Procedure Name as String, Optional Parameters as Dictionary(of String, String) -> Parameter Name and Value
    ''' </summary>
    Public Sub ExecuteNoReturnStoredProcedure(StoredProcName As String, Optional Params As Dictionary(Of String, String) = Nothing)

        DBConn_Open()
        If SqlConn.State = ConnectionState.Open Then

            Dim myCommand As New SqlCommand(StoredProcName)
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.Connection = SqlConn

            If Params IsNot Nothing Then
                For Each param In Params
                    Dim key As String = param.Key
                    Dim value As String = param.Value
                    myCommand.Parameters.AddWithValue("@" & key, SqlDbType.VarChar).Value = value
                Next
            End If

            myCommand.ExecuteNonQuery()

        End If

        DBConn_close()

    End Sub


    Public Function ExecuteReturnStoredProcedure(StoredProcName As String, Optional Params As Dictionary(Of String, String) = Nothing) As String
        Dim Returned As String = ""

        DBConn_Open()
        If SqlConn.State = ConnectionState.Open Then

            Dim myCommand As New SqlCommand(StoredProcName)
            myCommand.CommandType = CommandType.StoredProcedure
            myCommand.Connection = SqlConn

            If Params IsNot Nothing Then
                For Each param In Params
                    Dim key As String = param.Key
                    Dim value As String = param.Value
                    myCommand.Parameters.AddWithValue("@" & key, SqlDbType.VarChar).Value = value
                Next
            End If

            Returned = myCommand.ExecuteScalar() 'returns 1 record

        End If

        DBConn_close()

        Return Returned
    End Function




End Class

