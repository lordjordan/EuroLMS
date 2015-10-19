Imports System.Runtime.InteropServices
Public Class frmLogin
    Dim db As New DBHelper("Data Source=C:\Users\JORDAN\Desktop\LoansManagementSystem\LMS.s3db; Version=3;")
    Dim dr As SQLite.SQLiteDataReader
    Dim cmd As SQLite.SQLiteCommand

    Private Const EM_SETCUEBANNER As Integer = &H1501

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Private Sub SetCueText(ByVal control As Control, ByVal text As String)
        SendMessage(control.Handle, EM_SETCUEBANNER, 0, text)
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        'Dim rec As Integer
        Dim data As New Dictionary(Of String, Object)
        'Dim user As String = txtUser.Text
        'Dim pass As String = txtPassword.Text


        'If txtUser.Text = "" Or txtPassword.Text = "" Then
        '    MsgBox("Please provide username and password.", MsgBoxStyle.Exclamation, "Authentication Error")
        'Else

        '    data.Add("user_name", txtUser.Text)
        '    data.Add("user_password", txtPassword.Text)
        '    dr = db.ExecuteReader("SELECT user_name, user_password from tbl_users WHERE user_name = '" & txtUser.Text & "' and user_password= '" & txtPassword.Text & "'")

        '    If dr.HasRows Then
        '        MessageBox.Show("Login successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        frmMainPanel.Show()
        Me.Hide()
        '    Else
        '        MessageBox.Show("Username and Password do not match..", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        'Clear all fields
        '        txtPassword.Text = ""
        '        txtUser.Text = ""
        '        txtUser.Focus()
        '    End If

        'End If

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetCueText(txtUser, "Username")
        SetCueText(txtPassword, "Password")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub
End Class