Imports System.Data.SQLite

Public Class DBHelper
    Property Connected As Boolean
    Property Connectionstring As String
    Private con As New SQLiteConnection
    Private cmd As New SQLiteCommand


    Public Sub New()
        Connected = False
    End Sub

    Public Sub New(ConnectionString As String)
        Connected = False
        Me.Connectionstring = ConnectionString

    End Sub

    Private Function BuildCommand(ByRef cmd As SQLiteCommand, params As Dictionary(Of String, Object)) As SQLiteCommand
        Try
            con = New SQLiteConnection(Connectionstring)
            cmd.Connection = con
            AddParameters(cmd, params)
            con.Open()
            Connected = True
        Catch ex As Exception
            Connected = False
            MsgBox("Unable to connect to the database", MsgBoxStyle.Critical)
        End Try

        Return cmd


    End Function

    Private Sub AddParameters(ByRef cmd As SQLiteCommand, params As Dictionary(Of String, Object))
        If params Is Nothing Then Exit Sub
        For Each kvp As KeyValuePair(Of String, Object) In params
            cmd.Parameters.AddWithValue(kvp.Key, kvp.Value)
        Next
    End Sub

    Public Function ExecuteReader(commandText As String, Optional params As Dictionary(Of String, Object) = Nothing) As SQLiteDataReader
        cmd.CommandText = commandText
        Using cmd
            BuildCommand(cmd, params)
            Return cmd.ExecuteReader()
        End Using
        con.Close()

    End Function

    Public Function ExecuteNonQuery(commandText As String, Optional params As Dictionary(Of String, Object) = Nothing) As Integer
        cmd.CommandText = commandText
        Using cmd
            BuildCommand(cmd, params)
            Return cmd.ExecuteNonQuery
        End Using
    End Function

End Class