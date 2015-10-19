
'Imports System.Data.SqlClient
'Imports System.Data
'Imports System.IO.Directory
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop
'Imports System.Windows.Forms
'Imports System.Data.OleDb
Imports System.Drawing.Imaging
Imports System.IO

Public Class Clients

    Dim itm As ListViewItem
    '### Change the "Data Source" path to point to our own LMS Database
    Dim db As New DBHelper("Data Source=" & My.Settings.ConString & "; Version=3;")
    Dim dr As SQLite.SQLiteDataReader

    Private Sub showAddEdit(mode As Boolean)
        gbxAddEdit.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        showUSC(uscMainmenu)
    End Sub
    Private Sub loadCombo()
        Try
            dr = db.ExecuteReader("select client_id ,company_name, branch_name, first_name,last_name,middle_name, birth_date, address, contact_number, date_hired," & _
                              "employee_type, employee_no, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE client_id=" & ListView1.FocusedItem.Text)
            If dr.HasRows Then

                Dim index, index2 As Integer
                index = cbxCompany.FindString(dr.Item("company_name").ToString)
                cbxCompany.SelectedIndex = index

                loadBranch()

                index2 = cbxBranch.FindString(dr.Item("branch_name").ToString)
                cbxBranch.SelectedIndex = index2
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If ListView1.SelectedItems.Count > 0 Then
            txt_client.Text = ListView1.FocusedItem.Text
            Try
                dr = db.ExecuteReader("select client_id ,company_name, branch_name, first_name,last_name,middle_name, birth_date, address, contact_number, date_hired," & _
                                  "employee_type, employee_no, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE client_id=" & ListView1.FocusedItem.Text)
                
                If dr.HasRows Then
                    
                    txt_client.Text = dr.Item("client_id").ToString
                    'cbxCompany.Text = dr.Item("company_name").ToString
                    'cbxBranch.Text = dr.Item("branch_name").ToString
                    txt_FName.Text = dr.Item("first_name").ToString
                    txt_LName.Text = dr.Item("last_name").ToString
                    txt_MName.Text = dr.Item("middle_name").ToString
                    txt_address.Text = dr.Item("address").ToString
                    txt_Contact.Text = dr.Item("contact_number").ToString
                    cbxEmpType.Text = dr.Item("employee_type").ToString
                    'pic1.Image = dr.Item("profile_pic")
                    txtEmpNum.Text = dr.Item("employee_no").ToString
                    txt_Credit.Text = dr.Item("credit_limit").ToString
                    Dim bdate = dr.Item("birth_date").ToString
                    Dim dhire = dr.Item("date_hired").ToString
                    Dim bdateyr, bdatemon, bdateday, dhireyr, dhiremon, dhireday As String
                    bdateyr = (dr.Item("birth_date").ToString).Substring(0, 4)
                    bdatemon = (dr.Item("birth_date").ToString).Substring(4, 2)
                    bdateday = (dr.Item("birth_date").ToString).Substring(bdate.Length - 2)
                    dhireyr = (dr.Item("date_hired").ToString).Substring(0, 4)
                    dhiremon = (dr.Item("date_hired").ToString).Substring(4, 2)
                    dhireday = (dr.Item("date_hired").ToString).Substring(bdate.Length - 2)

                    DateTimePicker1.Value = bdatemon & "/" & bdateday & "/" & bdateyr
                    'MessageBox.Show(DateTimePicker1.Value)
                    DateTimePicker2.Value = dhiremon & "/" & dhireday & "/" & dhireyr
                    If dr.Item("employee_type") = 0 Then 'in process
                        cbxEmpType.Text = "Contractual"
                    ElseIf dr.Item("employee_type") = 1 Then
                        cbxEmpType.Text = "Regular"
                    ElseIf dr.Item("employee_type") = 2 Then
                        cbxEmpType.Text = "Probationary"
                    End If

                    cbxCompany.SelectedIndex = cbxCompany.FindString(dr.Item("company_name").ToString)
                    Dim str As String
                    str = dr.Item("branch_name").ToString
                    'str2 = dr.Item("employee_type").ToString
                    loadBranch()
                    cbxBranch.SelectedIndex = cbxBranch.FindString(str)

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try

        Else
            MsgBox("Please select a client.", vbExclamation + vbOKOnly, "No client Selected")
            Exit Sub
        End If

        'latag sa groupbox
        gbxAddEdit.Text = "Edit client"
        showAddEdit(True)

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        cbxCompany.Text = " "
        cbxBranch.Text = " "
        txt_FName.Text = ""
        txt_LName.Text = ""
        txt_MName.Text = ""
        txt_address.Text = ""
        txt_Contact.Text = ""
        cbxEmpType.Text = ""
        txt_Credit.Text = ""
        txtEmpNum.Text = ""
        txt_FName.Focus()
        gbxAddEdit.Text = "Add new client"
        showAddEdit(True)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        
        If gbxAddEdit.Text = "Add new client" Then
            If cbxCompany.Text = "" Or cbxBranch.Text = "" Or txt_FName.Text = "" Or txt_MName.Text = "" Or txt_LName.Text = "" Or txt_address.Text = "" _
                        Or txt_Contact.Text = "" Or cbxEmpType.Text = "" Or txtEmpNum.Text = "" Or txt_Credit.Text = "" Then
                MsgBox("Some fields are empty.", MsgBoxStyle.Exclamation, "Please fill up")
                Exit Sub
            End If

            Try
                dr = db.ExecuteReader("select * from tbl_clients where first_name like '%" & txt_FName.Text & "%' and last_name like '%" & txt_LName.Text & "%' and middle_name like '%" & txt_MName.Text & "%' ")

                If dr.HasRows Then
                    Do While dr.Read
                        Dim pangalan = (dr.Item("first_name").ToString)
                        Dim apelyido = (dr.Item("last_name").ToString)
                        Dim midname = (dr.Item("middle_name").ToString)
                        If pangalan = txt_FName.Text And apelyido = txt_LName.Text And midname = txt_MName.Text Then
                            Dim msgRslt As MsgBoxResult = MsgBox("Name already on the database. Do you want to continue to add this client?", vbExclamation + MsgBoxStyle.YesNo, "Message Alert")
                            If msgRslt = MsgBoxResult.Yes Then
                                Dim rec As Integer
                                Dim data As New Dictionary(Of String, Object)
                                Dim cID, bID As String
                                cID = cbxCompany.SelectedItem
                                bID = cbxBranch.SelectedItem
                                Try
                                    data.Add("company_name", cbxCompany.Text)
                                    data.Add("branch_id", bID.Substring(bID.Length - 3))
                                    data.Add("first_name", txt_FName.Text)
                                    data.Add("last_name", txt_LName.Text)
                                    data.Add("middle_name", txt_MName.Text)
                                    data.Add("birth_date", Format(DateTimePicker1.Value, "yyyyMMdd"))
                                    data.Add("address", txt_address.Text)
                                    data.Add("contact_number", txt_Contact.Text)
                                    If cbxEmpType.Text = "Contractual" Then 'in process
                                        data.Add("employee_type", "0")
                                        'cbxEmpType.Text = "Contractual"
                                    ElseIf cbxEmpType.Text = "Regular" Then
                                        data.Add("employee_type", "1")
                                        'cbxEmpType.Text = "Regular"
                                    ElseIf cbxEmpType.Text = "Probationary" Then
                                        data.Add("employee_type", "2")
                                        'cbxEmpType.Text = "Probationary"
                                    End If
                                    data.Add("employee_no", txtEmpNum.Text)
                                    data.Add("credit_limit", txt_Credit.Text)
                                    data.Add("date_hired", Format(DateTimePicker2.Value, "yyyyMMdd"))
                                    data.Add("profile_pic", imgbyte)

                                    rec = db.ExecuteNonQuery("insert into tbl_clients values(NULL,@first_name,@last_name,@middle_name, @birth_date,@address,@branch_id,@contact_number,@employee_type,@employee_no,@date_hired,@profile_pic,@credit_limit)", data)

                                    If Not rec < 1 Then
                                        MsgBox("Record saved!", MsgBoxStyle.Information)
                                        showAddEdit(False)
                                        LoadListView()
                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.ToString)
                                Finally
                                    db.Dispose() '<--------CHECK THIS!
                                End Try

                            ElseIf msgRslt = MsgBoxResult.No Then
                                MsgBox("Exit saving...")
                                Exit Sub
                            End If
                        End If
                    Loop
                Else
                    'MsgBox("No duplicate of name.", vbInformation + vbOKOnly, "OKIE")
                    Dim rec As Integer
                    Dim data As New Dictionary(Of String, Object)
                    Dim cID, bID As String
                    cID = cbxCompany.SelectedItem
                    bID = cbxBranch.SelectedItem
                    Try
                        'dr = db.ExecuteReader("select client_id ,company_name, branch_name, first_name,last_name,middle_name, birth_date, address, contact_number, date_hired," & _
                        '          "employee_type, employee_no, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE client_id=" & ListView1.FocusedItem.Text)
                        'If dr.HasRows Then

                        'End If

                        data.Add("company_name", cbxCompany.Text)
                        data.Add("branch_id", bID.Substring(bID.Length - 3))
                        data.Add("first_name", txt_FName.Text)
                        data.Add("last_name", txt_LName.Text)
                        data.Add("middle_name", txt_MName.Text)
                        data.Add("birth_date", Format(DateTimePicker1.Value, "yyyyMMdd"))
                        data.Add("address", txt_address.Text)
                        data.Add("contact_number", txt_Contact.Text)
                        'data.Add("employee_type", cbxEmpType.Text)
                        If cbxEmpType.Text = "Contractual" Then 'in process
                            data.Add("employee_type", "0")
                            'cbxEmpType.Text = "Contractual"
                        ElseIf cbxEmpType.Text = "Regular" Then
                            data.Add("employee_type", "1")
                            'cbxEmpType.Text = "Regular"
                        ElseIf cbxEmpType.Text = "Probationary" Then
                            data.Add("employee_type", "2")
                            'cbxEmpType.Text = "Probationary"
                        End If
                        data.Add("employee_no", txtEmpNum.Text)
                        'data.Add("profile_pic", imgbyte)
                        data.Add("credit_limit", txt_Credit.Text)
                        data.Add("date_hired", Format(DateTimePicker2.Value, "yyyyMMdd"))

                        rec = db.ExecuteNonQuery("insert into tbl_clients values(NULL,@first_name,@last_name,@middle_name, @birth_date,@address,@branch_id,@contact_number,@employee_type,@employee_no,@date_hired,NULL,@credit_limit)", data)

                        If Not rec < 1 Then
                            MsgBox("Record saved!", MsgBoxStyle.Information)
                            showAddEdit(False)
                            LoadListView()
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    Finally
                        db.Dispose() '<--------CHECK THIS!
                    End Try
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try


        ElseIf gbxAddEdit.Text = "Edit client" Then
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Dim cID, bID As String
            cID = cbxCompany.SelectedItem
            bID = cbxBranch.SelectedItem

            Try
                data.Add("first_name", txt_FName.Text)
                data.Add("last_name", txt_LName.Text)
                data.Add("middle_name", txt_MName.Text)
                data.Add("birth_date", Format(DateTimePicker1.Value, "yyyyMMdd"))
                data.Add("address", txt_address.Text)
                data.Add("contact_number", txt_Contact.Text)
                'data.Add("employee_type", cbxEmpType.Text)
                If cbxEmpType.Text = "Contractual" Then 'in process
                    data.Add("employee_type", "0")
                    'cbxEmpType.Text = "Contractual"
                ElseIf cbxEmpType.Text = "Regular" Then
                    data.Add("employee_type", "1")
                    'cbxEmpType.Text = "Regular"
                ElseIf cbxEmpType.Text = "Probationary" Then
                    data.Add("employee_type", "2")
                    'cbxEmpType.Text = "Probationary"
                End If
                data.Add("employee_no", txtEmpNum.Text)
                data.Add("credit_limit", txt_Credit.Text)
                data.Add("branch_id", bID.Substring(bID.Length - 3))
                data.Add("date_hired", Format(DateTimePicker2.Value, "yyyyMMdd"))

                Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream
                Dim pic As Byte() = dr.Item("picture")
                imagestream = New System.IO.MemoryStream(pic)
                Picturebox1.Image = Drawing.Image.FromStream(imagestream)
                'data.Add("profile_pic", )

                rec = db.ExecuteNonQuery("UPDATE tbl_clients SET first_name=@first_name, middle_name=@middle_name, last_name=@last_name, birth_date=@birth_date," & _
                                         "address=@address, contact_number=@contact_number, employee_type=@employee_type, employee_no=@employee_no, credit_limit=@credit_limit, branch_id=@branch_id, date_hired=@date_hired, profile_pic=@profile_pic WHERE client_id=" & txt_client.Text, data)

                If Not rec < 1 Then
                    MessageBox.Show("Record updated!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    showAddEdit(False)
                    LoadListView()

                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try
        End If
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        showAddEdit(False)
    End Sub

    Private Sub Clients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmLogin.lblUtype.Text = 2 Then
            btnEdit.Enabled = False
        End If

        LoadListView()
        loadcompany()
        loadEmpType()
        'loadBranch()
    End Sub

    Private Sub loadBranch()
        cbxBranch.Items.Clear()
        Dim cID As String
        cID = cbxCompany.SelectedItem
        Try
            dr = db.ExecuteReader("Select branch_id, branch_name from tbl_branches as B left join tbl_company as C on B.company_id=C.company_id WHERE B.company_id=" & cID.Substring(cID.Length - 3))
            'MsgBox(bID.Substring(bID.Length - 3))
            If dr.HasRows Then
                Do While dr.Read
                    cbxBranch.Items.Add(dr.Item("branch_name") & "                                                              000" & dr.Item("branch_id"))
                Loop
            Else
                MsgBox("No branch data.", vbInformation + vbOKOnly, "Error branch data.")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub
    Private Sub cbxCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCompany.SelectedIndexChanged
        loadBranch()
    End Sub
    Private Sub loadcompany()
        Try
            dr = db.ExecuteReader("Select company_id, company_name from tbl_company")

            If dr.HasRows Then
                Do While dr.Read
                    cbxCompany.Items.Add(dr.Item("company_name") & "                                                             000" & dr.Item("company_id"))
                Loop
            Else
                MsgBox("No company data.", vbInformation + vbOKOnly, "Error company data.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub loadEmpType()
        Try
            dr = db.ExecuteReader("Select employee_type from tbl_clients")

            If dr.HasRows Then
                Do While dr.Read
                    'cbxEmpType.Items.Add(dr.Item("employee_type"))
                    'If dr.Item("employee_type").ToString = 0 Then 'in process
                    '    'cbxEmpType.SelectedIndex = cbxEmpType.FindString(dr.Item("company_name").ToString)
                    '    cbxEmpType.Text = "Contractual"
                    'ElseIf dr.Item("employee_type").ToString = 1 Then
                    '    cbxEmpType.Text = "Regular"
                    'ElseIf dr.Item("employee_type").ToString = 2 Then
                    '    cbxEmpType.Text = "Probationary"
                    'End If
                Loop
            Else
                MsgBox("No employee type.", vbInformation + vbOKOnly, "Error data.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub LoadListView()
        'Dim xx As String
        ListView1.Items.Clear()
        Try
            dr = db.ExecuteReader("select client_id ,company_name, branch_name, first_name,last_name,middle_name, address" & _
                                  ",contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id")

            If dr.HasRows Then

                Do While dr.Read

                    itm = Me.ListView1.Items.Add(dr.Item("client_id").ToString)
                    itm.SubItems.Add(dr.Item("company_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_name").ToString)
                    'itm.SubItems.Add(dr.Item("name").ToString)
                    itm.SubItems.Add(dr.Item("first_name").ToString & " " & dr.Item("middle_name").ToString & " " & dr.Item("last_name").ToString)
                    itm.SubItems.Add(dr.Item("address").ToString)
                    itm.SubItems.Add(dr.Item("contact_number").ToString)
                    itm.SubItems.Add(dr.Item("credit_limit").ToString)
                    'If dr.Item("application_status").ToString = 0 Then
                    '    itm.SubItems.Add("In process")
                    '    itm.SubItems.Add("N/A")
                    'End If
                Loop
            Else
                MsgBox("No in process of Client Data", vbInformation + vbOKOnly, "No data of Clients.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub Btn_add_req_Click(sender As Object, e As EventArgs) Handles Btn_add_req.Click
        frmClientRequirement.ShowDialog()
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try

            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
        Catch ex As Exception

        Finally
            obj = Nothing
        End Try
    End Sub
    Dim imgbyte As Byte() = Nothing
    Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        If OpenFileDialog.ShowDialog = vbOK Then
            Dim myimage As Image = Image.FromFile(OpenFileDialog.FileName)
            Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream

            myimage.Save(imagestream, System.Drawing.Imaging.ImageFormat.Jpeg)
            imgbyte = imagestream.GetBuffer()

            imagestream = New System.IO.MemoryStream(imgbyte)
            Picturebox1.BackgroundImage = Nothing
            Picturebox1.SizeMode = PictureBoxSizeMode.Zoom
            Picturebox1.Image = Drawing.Image.FromStream(imagestream)
            'txtFilename.Text = System.IO.Path.GetFileName(OpenFileDialog.FileName)
        End If
    End Sub

    Private Sub loadImage()
        Dim ms As New IO.MemoryStream
        Picturebox1.Image.Save(ms, Imaging.ImageFormat.Jpeg)
        Dim bytes = ms.ToArray()
        'MsgBox(bytes)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ListView1.Items.Clear()
        Dim data As New Dictionary(Of String, Object)
        data.Add("searchkey1", "%" + txtSearchClient.Text + "%")
        data.Add("searchkey2", "%" & txtSearchClient.Text & "%")
        data.Add("searchkey3", "%" + txtSearchClient.Text + "%")

        Dim db As New DBHelper("Data Source=" & My.Settings.ConString & "; Version=3;")
        Dim dr As SQLite.SQLiteDataReader

        Try
            dr = db.ExecuteReader("select client_id, employee_no, last_name, first_name, middle_name, company_name, branch_name, address,contact_number, credit_limit " & _
                            "from tbl_clients as A " & _
                            "left join tbl_branches as B on A.branch_id=B.branch_id " & _
                            "left join tbl_company as C on B.company_id=C.company_id " & _
                            "where last_name like '%" & txtSearchClient.Text & "%' or " & _
                            "first_name like '%" & txtSearchClient.Text & "%' or " & _
                            "middle_name like '%" & txtSearchClient.Text & "%' or " & _
                            "company_name like '%" & txtSearchClient.Text & "%' or " & _
                            "branch_name like '%" & txtSearchClient.Text & "%' ")
            If dr.HasRows Then
                Do While dr.Read
                    'itm = Me.ListView1.Items.Add(dr.Item("client_id").ToString)
                    'itm.SubItems.Add(dr.Item("company_name").ToString)
                    'itm.SubItems.Add(dr.Item("branch_name").ToString)
                    'itm.SubItems.Add(dr.Item("last_name").ToString & ", " & dr.Item("first_name").ToString & ", " & dr.Item("middle_name").ToString)
                    'itm.SubItems.Add(dr.Item("address").ToString)
                    'itm.SubItems.Add(dr.Item("contact_number").ToString)
                    'itm.SubItems.Add(dr.Item("credit_limit").ToString)

                    Dim itmx As ListViewItem = ListView1.Items.Add(dr.Item("client_id").ToString)
                    itmx.SubItems.Add(dr.Item("company_name").ToString)
                    itmx.SubItems.Add(dr.Item("branch_name").ToString)
                    itmx.SubItems.Add(dr.Item("last_name").ToString & ", " & dr.Item("first_name").ToString & " " & dr.Item("middle_name").ToString)
                    itmx.SubItems.Add(dr.Item("address").ToString)
                    itmx.SubItems.Add(dr.Item("contact_number").ToString)
                    itmx.SubItems.Add(dr.Item("credit_limit").ToString)

                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try

    End Sub

    Private Sub btnSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnSearch.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSearch_Click(Me, e)
        End If
    End Sub

    Private Sub txt_Contact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Contact.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txt_Credit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_Credit.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtEmpNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmpNum.KeyPress
        'If Asc(e.KeyChar) <> 8 Then
        '    If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
        '        e.Handled = True
        '    End If
        'End If
    End Sub

    Private Sub ofd1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        OpenFileDialog.Filter = "Picture Files (*)|*.bmp;*.gif;*.jpg"
        Picturebox1.Image = Image.FromFile(OpenFileDialog.FileName)
        Dim img As Image = Picturebox1.Image
        Dim ms As New System.IO.MemoryStream
        Me.Picturebox1.Image.Save(ms, Me.Picturebox1.Image.RawFormat)
    End Sub
End Class

