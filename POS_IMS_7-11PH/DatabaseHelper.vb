Imports System.Data.SqlClient
Imports Dapper

Public Class DatabaseHelper
    Private Shared ReadOnly ConnectionString As String = "Server=LAPTOP-83UHRN5N\SQLEXPRESS;Database=POS_7Eleven;User = sa;Password = B1Admin"

    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

    Public Shared Function Query(Of T)(sql As String, Optional parameters As Object = Nothing) As IEnumerable(Of T)
        Using conn = GetConnection()
            conn.Open()
            Return conn.Query(Of T)(sql, parameters)
        End Using
    End Function

    Public Shared Sub Execute(sql As String, Optional parameters As Object = Nothing)
        Using conn = GetConnection()
            conn.Open()
            conn.Execute(sql, parameters)
        End Using
    End Sub
End Class