Imports System.Data.SQLite
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class System_User
    Dim itm As ListViewItem
    '### Change the "Data Source" path to point to our own LMS Database
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim cmd As SQLite.SQLiteCommand
    Private Shared DES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider

    Public Shared Function MD5Hash(ByVal value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function

    Public Shared Function Encrypt(ByVal stringToEncrypt As String, ByVal key As String) As String
        DES.Key = System_User.MD5Hash(key)
        DES.Mode = CipherMode.ECB
        Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function

    Public Shared Function Decrypt(ByVal encryptedString As String, ByVal key As String) As String

        DES.Key = System_User.MD5Hash(key)
        DES.Mode = CipherMode.ECB

        Dim Buffer As Byte() = Convert.FromBase64String(encryptedString)
        Return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function

    Private Sub showAddEdit(mode As Boolean)
        gbxAddEdit.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        showUSC(uscMainmenu)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        AddItemToListView()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditItemInListView()
    End Sub

    Private Sub AddItemToListView()

        btnSave.Enabled = True
        dr = db.ExecuteReader("select * from tbl_users")
        Dim maxId As Integer = 0
        gbxAddEdit.Text = "Add User Information"
        showAddEdit(True)

        While dr.Read = True
            If maxId < dr.Item(0) Then maxId = dr.Item(0)
        End While

        txtusername.Focus()
        txtUid.Text = maxId + 1
        txtusername.Text = ""
        txtPassword.Text = ""
        cmbUtype.Text = ""
    End Sub

    Private Sub EditItemInListView()

        gbxAddEdit.Text = "Edit User Information"
        If ListView1.SelectedItems.Count > 0 Then 'make sure there is a selected item to modify
            txtUid.Text = ListView1.FocusedItem.Text
            Try
                dr = db.ExecuteReader("select user_id , user_name, user_password, user_type  from tbl_users WHERE user_id=" & ListView1.FocusedItem.Text)

                If dr.HasRows Then
                    showAddEdit(True)
                    
                    txtUid.Text = dr.Item("user_id").ToString
                    txtusername.Text = dr.Item("user_name").ToString
                    'txtEncrypted.Text = dr.Item("user_password")
                    'txtDecrypted.Text = Decrypt(txtEncrypted.Text, "Keys")
                    'txtPassword.Text = Decrypt(txtEncrypted.Text, "Keys")
                    Dim pass = dr.Item("user_password")
                    Dim decryptPass = Decrypt(pass, "Keys")
                    txtPassword.Text = decryptPass
                    'cmbUtype.Text = dr.Item("user_type").ToString
                    If dr.Item("user_type") = 0 Then 'in process
                        cmbUtype.Text = "Super Administrator"
                    ElseIf dr.Item("user_type") = 1 Then
                        cmbUtype.Text = "Administrator"
                    ElseIf dr.Item("user_type") = 2 Then
                        cmbUtype.Text = "Encoder"
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try

        Else
            MessageBox.Show("Please select record to edit.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        showAddEdit(False)
    End Sub

    Private Sub LoadListview()
        ListView1.Items.Clear()
        Try
            dr = db.ExecuteReader("SELECT * from tbl_users")
            If dr.HasRows Then
                '### You can also use loops for multiple-row result
                Do While dr.Read
                    Dim utype = (CInt(dr.Item("user_type")))
                    itm = Me.ListView1.Items.Add(dr.Item("user_id").ToString)
                    itm.SubItems.Add(dr.Item("user_name").ToString)
                    itm.SubItems.Add(dr.Item("user_password").ToString)
                    If utype = 0 Then
                        itm.SubItems.Add("Super Administrator")
                    ElseIf utype = 1 Then
                        itm.SubItems.Add("Administrator")
                    ElseIf utype = 2 Then
                        itm.SubItems.Add("Encoder")
                    End If

                Loop
            Else
                MsgBox("No record of System Users", vbInformation + vbOKOnly, "No User")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub System_User_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showAddEdit(False)
        LoadListview()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If gbxAddEdit.Text = "Add User Information" Then
            'validation empty fields
            If txtusername.Text = "" Or txtPassword.Text = "" Or cmbUtype.Text = "" Then
                MsgBox("Please fill in the blank fields.", MsgBoxStyle.Exclamation, "Fill in the fields.")
                Exit Sub
            End If

            'add
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)

            Try
                data.Add("user_name", txtusername.Text)
                Dim encryptPass = Encrypt(txtPassword.Text, "Keys")
                data.Add("user_password", encryptPass)
                'data.Add("user_type", cmbUtype.Text)
                If cmbUtype.Text = "Super Admin" Then 'in process
                    data.Add("user_type", "0")
                ElseIf cmbUtype.Text = "Admin" Then
                    data.Add("user_type", "1")
                ElseIf cmbUtype.Text = "Encoder" Then
                    data.Add("user_type", "2")
                End If

                rec = db.ExecuteNonQuery("INSERT INTO tbl_users values(NULL,@user_name,@user_password,@user_type)", data)

                If Not rec < 1 Then
                    MessageBox.Show("Record saved!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    showAddEdit(False)
                    LoadListview()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try

        ElseIf gbxAddEdit.Text = "Edit User Information" Then
            'update
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)

            Try
                data.Add("user_name", txtusername.Text)
                Dim encryptPass = Encrypt(txtPassword.Text, "Keys")
                data.Add("user_password", encryptPass)
                'data.Add("user_type", cmbUtype.Text)
                If cmbUtype.Text = "Super Admin" Then 'in process
                    data.Add("user_type", "0")
                ElseIf cmbUtype.Text = "Admin" Then
                    data.Add("user_type", "1")
                ElseIf cmbUtype.Text = "Encoder" Then
                    data.Add("user_type", "2")
                End If

                rec = db.ExecuteNonQuery("UPDATE tbl_users SET user_name=@user_name, user_password=@user_password, user_type=@user_type WHERE user_id=" & txtUid.Text, data)

                If Not rec < 1 Then
                    MessageBox.Show("Record updated!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    showAddEdit(False)
                    LoadListview()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try
        End If
        
    End Sub
    'Private con As New SQLiteConnection

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs)
        EditItemInListView()
        showAddEdit(True)
    End Sub

End Class
