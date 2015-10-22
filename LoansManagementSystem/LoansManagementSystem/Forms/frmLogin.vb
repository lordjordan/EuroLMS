Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class frmLogin
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim cmd As SQLite.SQLiteCommand

    Private Const EM_SETCUEBANNER As Integer = &H1501

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Private Sub SetCueText(ByVal control As Control, ByVal text As String)
        SendMessage(control.Handle, EM_SETCUEBANNER, 0, text)
    End Sub
    Private Shared DES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider

    Public Shared Function MD5Hash(ByVal value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function

    Public Shared Function Encrypt(ByVal stringToEncrypt As String, ByVal key As String) As String
        DES.Key = frmLogin.MD5Hash(key)
        DES.Mode = CipherMode.ECB
        Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function
    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        'login()
        Dim data As New Dictionary(Of String, Object)
        Dim user As String = txtUser.Text
        Dim pass As String = txtPassword.Text
        Dim Usertype As String = lblUtype.Text
        If txtUser.Text = "" And txtPassword.Text = "" Then
            MsgBox("Please provide username and password.", MsgBoxStyle.Exclamation, "Authentication Error")
        End If

        Try
            dr = db.ExecuteReader("select * from tbl_users where user_name like '%" & txtUser.Text & "%' and user_password like '%" & Encrypt(txtPassword.Text, "Keys") & "%' ")
            If dr.HasRows Then
                Do While dr.Read
                    Dim encryptPass = Encrypt(txtPassword.Text, "Keys")
                    Dim uname = (dr.Item("user_name").ToString)
                    Dim upass = (dr.Item("user_password").ToString)
                    Dim utype = (CInt(dr.Item("user_type")))
                    lblUtype.Text = utype
                    If uname = txtUser.Text And upass = encryptPass Then
                        If utype = 0 Then
                            'MessageBox.Show("Welcome Super Admin")
                            MessageBox.Show("Login successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmMainPanel.Close()
                            frmMainPanel.Show()
                            Me.Hide()

                        ElseIf utype = 1 Then
                            'MessageBox.Show("Welcome Administrator!")
                            MessageBox.Show("Login successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmMainPanel.Close()
                            frmMainPanel.Show()
                            Me.Hide()

                        ElseIf utype = 2 Then
                            'MessageBox.Show("Welcome Encoder!")
                            MessageBox.Show("Login successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmMainPanel.Close()
                            frmMainPanel.Show()
                            Me.Hide()

                        End If

                        'ElseIf txtPassword.Text = "" And uname = txtUser.Text Then
                        '    MsgBox("Please provide password.", MsgBoxStyle.Exclamation, "Authentication Error")
                        '    txtPassword.Focus()
                        'ElseIf txtUser.Text = " " And upass = txtPassword.Text Then
                        '    MsgBox("Please provide username.", MsgBoxStyle.Exclamation, "Authentication Error")
                        '    txtUser.Focus()
                        'ElseIf txtUser.Text = "" And txtPassword.Text = "" Then
                        '    MsgBox("Please provide username and password.", MsgBoxStyle.Exclamation, "Authentication Error")
                        '    Exit Sub
                    End If
                Loop
            Else
                MessageBox.Show("Username and Password do not match..", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Clear all fields
                txtPassword.Text = ""
                txtUser.Text = ""
                txtUser.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'frmMainPanel.Close()
        txtUser.Text = ""
        txtPassword.Text = ""
        SetCueText(txtUser, "Username")
        SetCueText(txtPassword, "Password")

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Application.Exit()
    End Sub

    Private Sub txtPassword_Enter(sender As Object, e As EventArgs) Handles txtPassword.Enter
        'login()
        Dim data As New Dictionary(Of String, Object)
        Dim user As String = txtUser.Text
        Dim pass As String = txtPassword.Text
        Dim Usertype As String = lblUtype.Text
        Try
            dr = db.ExecuteReader("select * from tbl_users where user_name like '%" & txtUser.Text & "%' and user_password like '%" & txtPassword.Text & "%' ")
            If dr.HasRows Then
                Do While dr.Read

                    Dim uname = (dr.Item("user_name").ToString)
                    Dim upass = (dr.Item("user_password").ToString)
                    Dim utype = (CInt(dr.Item("user_type")))
                    lblUtype.Text = utype
                    If uname = txtUser.Text And upass = txtPassword.Text Then
                        If utype = 0 Then
                            'MessageBox.Show("Welcome Super Admin")
                            MessageBox.Show("Login successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmMainPanel.Show()
                            Me.Hide()

                        ElseIf utype = 1 Then
                            'MessageBox.Show("Welcome Administrator!")
                            MessageBox.Show("Login successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmMainPanel.Show()
                            Me.Hide()

                        ElseIf utype = 2 Then
                            'MessageBox.Show("Welcome Encoder!")
                            MessageBox.Show("Login successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            frmMainPanel.Show()
                            Me.Hide()

                        End If

                        'ElseIf txtPassword.Text = "" And uname = txtUser.Text Then
                        '    MsgBox("Please provide password.", MsgBoxStyle.Exclamation, "Authentication Error")
                        '    txtPassword.Focus()
                        'ElseIf txtUser.Text = " " And upass = txtPassword.Text Then
                        '    MsgBox("Please provide username.", MsgBoxStyle.Exclamation, "Authentication Error")
                        '    txtUser.Focus()
                    ElseIf txtUser.Text = "" And txtPassword.Text = "" Then
                        MsgBox("Please provide username and password.", MsgBoxStyle.Exclamation, "Authentication Error")
                        Exit Sub
                    End If
                Loop
            Else
                MessageBox.Show("Username and Password do not match..", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'Clear all fields
                txtPassword.Text = ""
                txtUser.Text = ""
                txtUser.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnLog_Click(Me, e)
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class