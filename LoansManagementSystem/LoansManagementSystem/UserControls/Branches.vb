
Public Class Branches

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
        uscBranches = New Branches

    End Sub

    Private Sub btnAddbranch_Click(sender As Object, e As EventArgs) Handles btnAddbranch.Click
        AddItemToListView()
    End Sub

    Private Sub AddItemToListView()
        txtBranchName.Focus()
        showAddEdit(True)
        dr = db.ExecuteReader("SELECT branch_id, company_name, branch_name,branch_contact,branch_address,payroll_master from tbl_branches as B LEFT JOIN tbl_company as C on B.company_id=C.company_id")

        gbxAddEdit.Text = "Add New Branches"
        showAddEdit(True)

        'While dr.Read = True
        '    If maxId < dr.Item(0) Then maxId = dr.Item(0)
        'End While

        txtBranchName.Focus()
        cbxCompanyName.Text = ""
        txtBranchName.Text = ""
        txtBranchCon.Text = ""
        txtBranchAd.Text = ""
        txtPayrollMaster.Text = ""
    End Sub
    Private Sub LoadListview()
        ListView1.Items.Clear()
        showAddEdit(False)
        Try
            dr = db.ExecuteReader("SELECT branch_id, company_name, branch_name,branch_contact,branch_address,payroll_master from tbl_branches as B LEFT JOIN tbl_company as C on B.company_id = C.company_id")
            If dr.HasRows Then

                '### You can also use loops for multiple-row result
                Do While dr.Read
                    itm = Me.ListView1.Items.Add(dr.Item("branch_id").ToString)
                    itm.SubItems.Add(dr.Item("company_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_contact").ToString)
                    itm.SubItems.Add(dr.Item("branch_address").ToString)
                    itm.SubItems.Add(dr.Item("payroll_master").ToString)
                Loop
            Else
                MsgBox("No record of Branches.", vbInformation + vbOKOnly, "No Branch")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If gbxAddEdit.Text = "Add New Branches" Then
            'add
            If cbxCompanyName.Text = "" Or txtBranchName.Text = "" Or txtBranchCon.Text = "" Or txtBranchAd.Text = "" Or txtPayrollMaster.Text = "" Then
                MsgBox("Some fields are empty.", MsgBoxStyle.Exclamation, "Please fill up")
                Exit Sub
            End If


            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Dim cID As String
            cID = cbxCompanyName.SelectedItem


            Try
                data.Add("branch_id", txtBranchID.Text)
                data.Add("company_id", cID.Substring(cID.Length - 3))
                data.Add("branch_name", txtBranchName.Text)
                data.Add("branch_address", txtBranchAd.Text)
                data.Add("branch_contact", txtBranchCon.Text)
                data.Add("payroll_master", txtPayrollMaster.Text)

                rec = db.ExecuteNonQuery("insert into tbl_branches values(NULL,@branch_name,@branch_address,@branch_contact,@company_id,@payroll_master)", data)

                If Not rec < 1 Then

                    MessageBox.Show("Record saved!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    showAddEdit(False)
                    LoadListview()
                    clearAll()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try

        ElseIf gbxAddEdit.Text = "Edit Branch" Then
            'update
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Dim cID As String
            cID = cbxCompanyName.SelectedItem

            Try
                data.Add("branch_id", txtBranchID.Text)
                data.Add("company_id", cID.Substring(cID.Length - 3))
                data.Add("branch_name", txtBranchName.Text)
                data.Add("branch_address", txtBranchAd.Text)
                data.Add("branch_contact", txtBranchCon.Text)
                data.Add("payroll_master", txtPayrollMaster.Text)

                rec = db.ExecuteNonQuery("UPDATE tbl_branches SET company_id=@company_id, branch_name=@branch_name, branch_address=@branch_address, branch_contact=@branch_contact, payroll_master=@payroll_master WHERE branch_id=" & txtBranchID.Text, data)

                If Not rec < 1 Then
                    MessageBox.Show("Record Updated!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    showAddEdit(False)
                    LoadListview()
                    clearAll()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try

        End If

    End Sub
    Private Sub clearAll()
        txtBranchID.Text = ""
        cbxCompanyName.Text = ""
        txtBranchName.Text = ""
        txtBranchCon.Text = ""
        txtBranchAd.Text = ""
        txtPayrollMaster.Text = ""
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        showAddEdit(False)
        ListView1.SelectedItems.Clear()
        clearAll()
    End Sub

    Private Sub Branches_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmLogin.lblUtype.Text = 2 Then
            btnEdit.Enabled = False
        End If
        LoadListview()
        loadCompany()
    End Sub
    Private Sub loadcompany()
        Try
            dr = db.ExecuteReader("Select company_id, company_name from tbl_company")

            If dr.HasRows Then
                Do While dr.Read
                    cbxCompanyName.Items.Add(dr.Item("company_name") & "                                                             000" & dr.Item("company_id"))
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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        EditItemInListView()
    End Sub
    
    Private Sub EditItemInListView()

        txtBranchName.Focus()
        gbxAddEdit.Text = "Edit Branch"
        If ListView1.SelectedItems.Count > 0 Then 'make sure there is a selected item to modify
            Try
                dr = db.ExecuteReader("Select branch_id, company_name, branch_name,branch_contact,branch_address,payroll_master from tbl_branches as B LEFT JOIN tbl_company as C on B.company_id=C.company_id WHERE branch_id=" & ListView1.FocusedItem.Text)

                If dr.HasRows Then
                    showAddEdit(True)
                    'txtBranchID.Text = ListView1.SelectedItems(0).SubItems(0).Text
                    'cbxCompanyName.Text = ListView1.SelectedItems(0).SubItems(1).Text
                    'txtBranchName.Text = ListView1.SelectedItems(0).SubItems(2).Text
                    'txtBranchCon.Text = ListView1.SelectedItems(0).SubItems(3).Text
                    'txtBranchAd.Text = ListView1.SelectedItems(0).SubItems(4).Text
                    'txtPayrollMaster.Text = ListView1.SelectedItems(0).SubItems(5).Text
                    txtBranchID.Text = dr.Item("branch_id").ToString
                    txtBranchName.Text = dr.Item("branch_name").ToString
                    txtBranchCon.Text = dr.Item("branch_contact").ToString
                    txtBranchAd.Text = dr.Item("branch_address").ToString
                    txtPayrollMaster.Text = dr.Item("payroll_master").ToString

                    cbxCompanyName.SelectedIndex = cbxCompanyName.FindString(dr.Item("company_name").ToString)
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

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        ListView1.Items.Clear()
        Dim data As New Dictionary(Of String, Object)
        data.Add("searchkey1", "%" + txtSearch.Text + "%")
        data.Add("searchkey2", "%" & txtSearch.Text & "%")
        data.Add("searchkey3", "%" + txtSearch.Text + "%")

        'Dim db As New DBHelper(My.Settings.ConnectionString)
        'Dim dr As SQLite.SQLiteDataReader

        Try
            dr = db.ExecuteReader("select branch_id, company_name, branch_name,branch_contact,branch_address,payroll_master from tbl_branches as B LEFT JOIN tbl_company as C on B.company_id = C.company_id where company_name LIKE'%" & txtSearch.Text & "%' or " & _
                            "branch_name LIKE '%" & txtSearch.Text & "%' or " & _
                            "branch_contact LIKE '%" & txtSearch.Text & "%' or " & _
                            "branch_address LIKE '%" & txtSearch.Text & "%' or " & _
                            "payroll_master LIKE '%" & txtSearch.Text & "%' ")
            If dr.HasRows Then
                Do While dr.Read
                    itm = Me.ListView1.Items.Add(dr.Item("branch_id").ToString)
                    itm.SubItems.Add(dr.Item("company_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_contact").ToString)
                    itm.SubItems.Add(dr.Item("branch_address").ToString)
                    itm.SubItems.Add(dr.Item("payroll_master").ToString)
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

    Private Sub txtBranchCon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBranchCon.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintReports
        frm.TabControl1.SelectedTab = frm.TabControl1.TabPages(2)
        frm.lblHeader.Text = "Branch Report"
        frm.lblHeader.ForeColor = Color.MediumTurquoise
        frm.ShowDialog()
    End Sub
End Class