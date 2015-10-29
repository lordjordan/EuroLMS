
Public Class Company

    Dim itm As ListViewItem
    '### Change the "Data Source" path to point to our own LMS Database
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim cmd As SQLite.SQLiteCommand

    Private Sub showAddEdit(mode As Boolean)
        gbxAddEdit.Visible = mode
        pnlMain.Enabled = Not mode

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        showUSC(uscMainmenu)
    End Sub

    Private Sub btnAddbranch_Click(sender As Object, e As EventArgs) Handles btnAddCompany.Click
        AddItemToListView()
    End Sub

    Private Sub AddItemToListView()
        txtCompanyName.Focus()
        showAddEdit(True)
        dr = db.ExecuteReader("select * from tbl_company")
        Dim maxId As Integer = 0
        gbxAddEdit.Text = "Add New Company"
        showAddEdit(True)

        While dr.Read = True
            If maxId < dr.Item(0) Then maxId = dr.Item(0)
        End While

        txtCompanyName.Focus()
        txtCompanyID.Text = maxId + 1
        txtCompanyName.Text = ""
        txtCompanyAd.Text = ""
        txtCompanyConNum.Text = ""
        txtCompanyContPers.Text = ""
        txtCompanyRemarks.Text = ""
    End Sub
    Private Sub LoadListview()
        ListView1.Items.Clear()
        showAddEdit(False)
        Try
            dr = db.ExecuteReader("Select company_id, company_name, company_address, company_contact_number, company_contact_person, company_remarks from tbl_company")
            If dr.HasRows Then

                '### You can also use loops for multiple-row result
                Do While dr.Read
                    itm = Me.ListView1.Items.Add(dr.Item("company_id").ToString)
                    itm.SubItems.Add(dr.Item("company_name").ToString)
                    itm.SubItems.Add(dr.Item("company_address").ToString)
                    itm.SubItems.Add(dr.Item("company_contact_number").ToString)
                    itm.SubItems.Add(dr.Item("company_contact_person").ToString)
                    itm.SubItems.Add(dr.Item("company_remarks").ToString)
                Loop
            Else
                MsgBox("No record of Company.", vbInformation + vbOKOnly, "No Company")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub validateCompany()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If gbxAddEdit.Text = "Add New Company" Then

            If txtCompanyName.Text = "" Or txtCompanyAd.Text = "" Or txtCompanyConNum.Text = "" Or txtCompanyContPers.Text = "" Or txtCompanyRemarks.Text = "" Then
                MsgBox("Some fields are empty.", MsgBoxStyle.Exclamation, "Please fill up")
                Exit Sub
            Else
                Try
                    dr = db.ExecuteReader("select * from tbl_company where company_name like '%" & txtCompanyName.Text & "%'")

                    If dr.HasRows Then
                        Do While dr.Read
                            Dim companya = (dr.Item("company_name").ToString)
                            If companya = txtCompanyName.Text Then
                                Dim msgRslt As MsgBoxResult = MsgBox("Company name already on the database. Do you want to continue to add this company?", vbExclamation + MsgBoxStyle.YesNo, "Message Alert")
                                If msgRslt = MsgBoxResult.Yes Then

                                    Dim rec As Integer
                                    Dim data As New Dictionary(Of String, Object)
                                    Try
                                        data.Add("company_id", txtCompanyID.Text)
                                        data.Add("company_name", txtCompanyName.Text)
                                        data.Add("company_address", txtCompanyAd.Text)
                                        data.Add("company_contact_number", txtCompanyConNum.Text)
                                        data.Add("company_contact_person", txtCompanyContPers.Text)
                                        data.Add("company_remarks", txtCompanyRemarks.Text)

                                        rec = db.ExecuteNonQuery("INSERT INTO tbl_company values(NULL,@company_name,@company_address,@company_contact_number,@company_contact_person,@company_remarks)", data)
                                        If Not rec < 1 Then
                                            MessageBox.Show("Record saved!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                            showAddEdit(False)
                                            showAddEdit(False)
                                            LoadListview()
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
                        Dim rec As Integer
                        Dim data As New Dictionary(Of String, Object)
                        Try
                            data.Add("company_id", txtCompanyID.Text)
                            data.Add("company_name", txtCompanyName.Text)
                            data.Add("company_address", txtCompanyAd.Text)
                            data.Add("company_contact_number", txtCompanyConNum.Text)
                            data.Add("company_contact_person", txtCompanyContPers.Text)
                            data.Add("company_remarks", txtCompanyRemarks.Text)

                            rec = db.ExecuteNonQuery("INSERT INTO tbl_company values(NULL,@company_name,@company_address,@company_contact_number,@company_contact_person,@company_remarks)", data)
                            If Not rec < 1 Then
                                MessageBox.Show("Record saved!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                showAddEdit(False)
                                showAddEdit(False)
                                LoadListview()
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
            End If




        ElseIf gbxAddEdit.Text = "Edit Company Information" Then
            'update 
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Try
                data.Add("company_id", txtCompanyID.Text)
                data.Add("company_name", txtCompanyName.Text)
                data.Add("company_address", txtCompanyAd.Text)
                data.Add("company_contact_number", txtCompanyConNum.Text)
                data.Add("company_contact_person", txtCompanyContPers.Text)
                data.Add("company_remarks", txtCompanyRemarks.Text)

                rec = db.ExecuteNonQuery("UPDATE tbl_company SET company_name=@company_name, company_address=@company_address, company_contact_number=@company_contact_number, company_contact_person=@company_contact_person, company_remarks=@company_remarks WHERE company_id=" & txtCompanyID.Text, data)

                If Not rec < 1 Then
                    MessageBox.Show("Record updated!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    showAddEdit(False)
                    LoadListview()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
                MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        showAddEdit(False)
    End Sub

    Private Sub Branches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmLogin.lblUtype.Text = 2 Then
            btnEdit.Enabled = False
        End If
        LoadListview()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditItemInListView()
    End Sub
    Private Sub EditItemInListView()
        txtCompanyName.Focus()
        gbxAddEdit.Text = "Edit Company Information"
        If ListView1.SelectedItems.Count > 0 Then 'make sure there is a selected item to modify
            showAddEdit(True)
            txtCompanyID.Text = ListView1.SelectedItems(0).SubItems(0).Text
            txtCompanyName.Text = ListView1.SelectedItems(0).SubItems(1).Text
            txtCompanyAd.Text = ListView1.SelectedItems(0).SubItems(2).Text
            txtCompanyConNum.Text = ListView1.SelectedItems(0).SubItems(3).Text
            txtCompanyContPers.Text = ListView1.SelectedItems(0).SubItems(4).Text
            txtCompanyRemarks.Text = ListView1.SelectedItems(0).SubItems(5).Text
        Else
            MessageBox.Show("Please select record to edit.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub btnSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnSearch.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSearch_Click(Me, e)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ListView1.Items.Clear()
        Dim data As New Dictionary(Of String, Object)
        data.Add("searchkey1", "%" + txtSearch.Text + "%")
        data.Add("searchkey2", "%" & txtSearch.Text & "%")
        data.Add("searchkey3", "%" + txtSearch.Text + "%")

        Dim db As New DBHelper(My.Settings.ConnectionString)
        Dim dr As SQLite.SQLiteDataReader

        Try
            dr = db.ExecuteReader("Select company_id, company_name, company_address, company_contact_number, company_contact_person, company_remarks from tbl_company where company_name like '%" & txtSearch.Text & "%' or " & _
            "company_address like '%" & txtSearch.Text & "%' or " & _
            "company_contact_number like '%" & txtSearch.Text & "%' or " & _
            "company_contact_person like '%" & txtSearch.Text & "%' or " & _
            "company_remarks like '%" & txtSearch.Text & "%' ")
            If dr.HasRows Then
                Do While dr.Read
                    itm = Me.ListView1.Items.Add(dr.Item("company_id").ToString)
                    itm.SubItems.Add(dr.Item("company_name").ToString)
                    itm.SubItems.Add(dr.Item("company_address").ToString)
                    itm.SubItems.Add(dr.Item("company_contact_number").ToString)
                    itm.SubItems.Add(dr.Item("company_contact_person").ToString)
                    itm.SubItems.Add(dr.Item("company_remarks").ToString)
                Loop
            Else
                MsgBox("No search result.", vbInformation + vbOKOnly, "Important Notice")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub txtCompanyConNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCompanyConNum.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintReports
        frm.TabControl1.SelectedTab = frm.TabControl1.TabPages(1)
        frm.lblHeader.Text = "Company Report"
        frm.lblHeader.ForeColor = Color.Tomato
        frm.ShowDialog()
    End Sub
End Class