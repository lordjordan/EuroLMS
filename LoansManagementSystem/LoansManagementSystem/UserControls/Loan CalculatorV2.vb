﻿Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Xml


Public Class Loan_CalculatorV2
    Dim active_loan_id As Long = 0
    Dim isLOADING As Boolean = False

    Dim RPTCalculator As New LoanCalculator

    Private Sub computeTotalLoan()
        If Val(txtTerms.Text) < 1 Or Val(cboInterest.Text) <= 0 Or Val(txtPrincipal.Text) < 1 Or _
            Not IsNumeric(txtPrincipal.Text) Or _
            Not IsNumeric(cboInterest.Text) Or _
            Not IsNumeric(txtTerms.Text) Or _
            isLOADING Then
            txtTotalLoanAmount.Text = 0
            txtTotalInterest.Text = 0
            txtMonthlyInterest.Text = 0
            txtBiMonthlyAmort.Text = 0

            Exit Sub
        End If

        Dim TotalLoanAmount As Double = 0
        Dim TotalInterest As Double = 0
        Dim principal As Long, interest_rate As Double, terms As Integer

        principal = Val(txtPrincipal.Text)
        interest_rate = Val(cboInterest.Text) / 100
        terms = Val(txtTerms.Text)
        TotalInterest = (principal * interest_rate * terms)
        TotalLoanAmount = principal + TotalInterest

        txtTotalLoanAmount.Text = FormatNumber(TotalLoanAmount, 2)
        txtTotalInterest.Text = FormatNumber(TotalInterest, 2)
        txtMonthlyInterest.Text = FormatNumber(Val(TotalInterest / terms), 2)
        txtBiMonthlyAmort.Text = FormatNumber((TotalLoanAmount / terms / 2), 2)
    End Sub

    Private Sub clearClientProfileBox()
        'For Each Control In gbxAddEdit.Controls
        '    If TypeOf Control Is TextBox Then
        '        Control.Text = ""     'Clear all text
        '    End If
        'Next Control

        For Each Control In Me.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control

        'For Each Control In gbxLoanData2.Controls
        '    If TypeOf Control Is TextBox Then
        '        Control.Text = ""     'Clear all text
        '    End If
        'Next Control
    End Sub
    Private Sub showReport(mode As Boolean)
        gbxPreview.Visible = mode
        gbxPreview.Enabled = mode
        gbxAddEdit.Enabled = Not mode
    End Sub

    Private Function validateInputs() As Boolean

        If txtPrincipal.Text.Trim = "" Then
            MsgBox("Cannot save this record. Please put a value for principal first.", MsgBoxStyle.Critical, "New Loan Application - Error")
            txtPrincipal.Select()
            Return False
        End If

        If cboInterest.Text.Trim = "" Then
            MsgBox("Cannot save this record. Please put an interest rate first.", MsgBoxStyle.Critical, "New Loan Application - Error")
            cboInterest.Select()
            Return False
        End If

        If txtTerms.Text.Trim = "" Then
            MsgBox("Cannot save this record. Please put a value for terms first.", MsgBoxStyle.Critical, "New Loan Application - Error")
            txtTerms.Select()
            Return False
        End If

        If Val(txtTotalLoanAmount.Text.Trim) = 0 Then
            MsgBox("Cannot save this record. Please put a valid loan.", MsgBoxStyle.Critical, "New Loan Application - Error")
            txtPrincipal.Select()
            Return False
        End If
        Return True
    End Function


    'Private Sub toggleClientSearch(Optional mode As Boolean = False)
    '    gbxShowClient.Visible = mode
    '    gbxShowClient.Enabled = mode
    '    If mode Then
    '        gbxShowClient.BringToFront()
    '    Else
    '        gbxShowClient.SendToBack()
    '    End If

    '    gbxClientData.Enabled = Not mode

    'End Sub

    'Private Sub toggleLoanApplication(Optional mode As Boolean = False)
    '    gbxAddEdit.Visible = mode
    '    gbxAddEdit.Enabled = mode
    '    If mode Then
    '        gbxAddEdit.BringToFront()
    '    Else
    '        gbxAddEdit.SendToBack()
    '    End If

    '    gbxAddEdit.Enabled = Not mode

    '    pnlMain.Enabled = Not mode
    'End Sub

    'Private Sub toggleVerifyActivation(Optional mode As Boolean = False)
    '    gbxVerifyActivation.Visible = mode
    '    gbxVerifyActivation.Enabled = mode
    '    If mode Then
    '        gbxVerifyActivation.BringToFront()
    '    Else
    '        gbxVerifyActivation.SendToBack()
    '    End If

    '    gbxClientData.Enabled = Not mode

    '    pnlMain.Enabled = Not mode
    'End Sub
    'Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    '    toggleLoanApplication()
    'End Sub

    'Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    If validateInputs() = False Then Exit Sub

    '    If gbxAddEdit.Text = "New Loan Application" Then
    '        saveNewForm()
    '    Else
    '        saveEditForm()
    '    End If

    '    saveCollectibles()

    '    MsgBox("Record saved!", MsgBoxStyle.Information)
    '    toggleLoanApplication()
    '    LoadListView()
    '    'toggleLoanApplication()
    'End Sub

    Private Function computeLateFee(principal As Double) As String
        Dim fee As String = "0"
        If principal <= 10000 Then
            fee = "300.00"
        ElseIf principal <= 20000 Then
            fee = "400.00"
        Else
            fee = "500.00"
        End If

        Return fee

    End Function
    Private Sub saveCollectibles()
        If gbxAddEdit.Text = "Edit Loan Application" Then
            'Dim ddate(DataGridView1.RowCount - 1) As DueDateObj
            Using db1 As New DBHelper(My.Settings.ConnectionString)
                'Dim dr As SQLite.SQLiteDataReader
                Dim rec As Integer
                Try
                    Dim data As New Dictionary(Of String, Object)
                    data.Add("loan_id", active_loan_id)
                    rec = db1.ExecuteNonQuery("delete from tbl_collectibles where loan_id = @loan_id", data)


                    'dr = db1.ExecuteReader("select * from tbl_collectibles where loan_id=@loan_id")

                    'If dr.HasRows Then
                    '    Dim index As Byte = 0
                    '    Dim ddate(DataGridView1.RowCount - 1) As DueDateObj
                    '    Do While dr.Read
                    '        ddate(index) = New DueDateObj(dr.Item("ctb_id"), DataGridView1.Item(1, index).Value)
                    '    Loop


                    'End If

                Catch ex As Exception

                End Try
            End Using

        End If

        Dim rows As Byte = DataGridView1.RowCount - 1
        For i = 0 To rows - 1
            Using db2 As New DBHelper(My.Settings.ConnectionString)
                Dim rec As Integer
                Try
                    Dim data As New Dictionary(Of String, Object)
                    ''Dim t1, t2, t3, t4, t5, t6 As New TextBox
                    ''t1.Text = active_loan_id
                    ''t2.Text = DateToStr(Format(DataGridView1.Item(1, i).Value, "short date"))
                    ''t3.Text = NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2))
                    ''t4.Text = "000000000000"
                    ''t5.Text = NumToStr(computeLateFee(Val(txtPrincipal.Text.Trim.Replace(",", ""))))
                    ''t6.Text = "0"

                    data.Add("loan_id", active_loan_id)
                    data.Add("due_date", DateToStr(Format(DataGridView1.Item(1, i).Value, "short date")))
                    data.Add("payable_amt", NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2)))
                    data.Add("collected_amt", "000000000000")
                    data.Add("penalty_amt", NumToStr(computeLateFee(Val(txtPrincipal.Text.Trim.Replace(",", "")))))
                    data.Add("penalty_status", "0")
                    data.Add("previous_balance", "000000000000")

                    rec = db2.ExecuteNonQuery("insert into tbl_collectibles values(NULL, @loan_id, @due_date, @payable_amt, " & _
                                             "@collected_amt, @penalty_amt, @penalty_status, @previous_balance) ", data)

                    If Not rec < 1 Then

                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    db2.Dispose()
                End Try

            End Using
        Next






        ''        Dim size As Byte = Val(txtTerms.Text) * 2
        ''        Dim DueDates(size) As Date
        ''        Dim startDate As Date = dtStart.Value
        ''        Dim endDate As Date = dtStart.Value
        ''        Dim xDay As Byte = Format(startDate, "dd")
        ''        Dim yDay As Byte '= IIf(xDay < 28, (xDay + 15) Mod 30, 15)

        ''        If xDay <= 7 Then
        ''            xDay = 5
        ''            yDay = 20
        ''        ElseIf xDay <= 12 Then
        ''            xDay = 10
        ''            yDay = 25
        ''        ElseIf xDay <= 17 Then
        ''            xDay = 15
        ''            yDay = 31
        ''        ElseIf xDay <= 22 Then
        ''            xDay = 20
        ''            yDay = 5
        ''        ElseIf xDay <= 27 Then
        ''            xDay = 25
        ''            yDay = 10
        ''        Else
        ''            xDay = 31
        ''            yDay = 15
        ''            'yDay = (xDay + 15) Mod 30
        ''        End If
        ''        DueDates(0) = startDate
        ''        For i = 1 To size Step 2

        ''            'DueDates(i) = New Date()
        ''            If xDay < yDay Then
        ''                Dim dayfixer As Byte = 0
        ''Fix:
        ''                Try
        ''                    DueDates(i) = New Date(DueDates(i - 1).Year, DueDates(i - 1).Month, yDay - dayfixer)

        ''                Catch ex As Exception
        ''                    dayfixer = dayfixer + 1
        ''                    GoTo Fix
        ''                End Try
        ''            Else
        ''                DueDates(i) = New Date(DueDates(i - 1).Year, DueDates(i - 1).Month, yDay)
        ''                DueDates(i).AddMonths(1)
        ''            End If

        ''            DueDates(i + 1) = DueDates(i - 1).AddMonths(1)

        ''            'DueDates(i) = DueDates(i - 1).AddDays(15)

        ''            '' ''If Format(DueDates(i - 1), "dd") < 29 Then
        ''            'DueDates(i + 1) = DueDates(i - 1).AddMonths(1)
        ''            '' ''End If

        ''        Next

        ''        For Each petsa In DueDates
        ''            'MsgBox(petsa)
        ''        Next
    End Sub
    Private Sub saveNewForm()
        Using db As New DBHelper(My.Settings.ConnectionString)
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Try

                'data.Add("client_id", txtClientID.Text)
                data.Add("principal", NumToStr(FormatNumber(txtPrincipal.Text, 2)))
                data.Add("amortization", NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2)))
                data.Add("date_start", Format(dtStart.Value, "yyyyMMdd"))
                data.Add("date_end", Format(dtEnd.Value, "yyyyMMdd"))
                data.Add("interest_percentage", cboInterest.Text)
                data.Add("date_approved", "00000000")
                data.Add("date_enrolled", Format(Now, "yyyyMMdd"))
                data.Add("terms", Val(txtTerms.Text))
                ' data.Add("application_status", cboApplicationStatus.SelectedIndex)
                ' data.Add("loan_status", cboLoanStatus.SelectedIndex)
                ' data.Add("loan_remarks", txtLoanRemarks.Text)


                rec = db.ExecuteNonQuery("insert into tbl_loans values(NULL, @client_id, @principal, @amortization, @date_start, @date_end, " & _
                                         "@interest_percentage, @date_approved, @date_enrolled , @terms, @application_status, @loan_status, " & _
                                         "@loan_remarks)", data)

                If Not rec < 1 Then
                    'MsgBox("Record saved!", MsgBoxStyle.Information)
                    'toggleLoanApplication()
                    'LoadListView()
                    Dim dr As SQLite.SQLiteDataReader
                    dr = db.ExecuteReader("select max(loan_id) as id from tbl_loans")
                    active_loan_id = dr.Item("id")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose()
            End Try

        End Using

        ''Using db3 As New DBHelper(My.Settings.ConnectionString)
        ''    'Dim rec As Integer
        ''    Dim data As New Dictionary(Of String, Object)
        ''    Try

        ''        Dim dr As SQLite.SQLiteDataReader
        ''        dr = db3.ExecuteReader("select max(loan_id) as id from tbl_loans")
        ''        active_loan_id = dr.Item("id")

        ''    Catch ex As Exception
        ''        MsgBox(ex.ToString)
        ''    Finally
        ''        db3.Dispose()
        ''    End Try

        ''End Using


        'Dim dr As SQLite.SQLiteDataReader

    End Sub

    Private Sub saveEditForm()
        Using db As New DBHelper(My.Settings.ConnectionString)
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Try

                ' data.Add("client_id", txtClientID.Text)
                data.Add("principal", NumToStr(FormatNumber(txtPrincipal.Text, 2)))
                data.Add("amortization", NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2)))
                data.Add("date_start", Format(dtStart.Value, "yyyyMMdd"))
                data.Add("date_end", Format(dtEnd.Value, "yyyyMMdd"))
                data.Add("interest_percentage", cboInterest.Text)
                data.Add("date_approved", "00000000")
                data.Add("date_enrolled", Format(Now, "yyyyMMdd"))
                data.Add("terms", Val(txtTerms.Text))
                ' data.Add("application_status", cboApplicationStatus.SelectedIndex)
                ' data.Add("loan_status", cboLoanStatus.SelectedIndex)
                ' data.Add("loan_remarks", txtLoanRemarks.Text)
                data.Add("loan_id", active_loan_id)


                rec = db.ExecuteNonQuery("update tbl_loans set client_id = @client_id, principal = @principal, amortization = @amortization, date_start = @date_start, date_end = @date_end, " & _
                                         "interest_percentage = @interest_percentage, date_approved = @date_approved, date_enrolled = @date_enrolled , terms = @terms, application_status = @application_status, loan_status = @loan_status, " & _
                                         "loan_remarks = @loan_remarks where loan_id = @loan_id;", data)

                If Not rec < 1 Then
                    'MsgBox("Record saved!", MsgBoxStyle.Information)
                    'toggleLoanApplication()
                    'LoadListView()
                    'Dim dr As SQLite.SQLiteDataReader
                    'dr = db.ExecuteReader("select max(loan_id) as id from tbl_loans")
                    'active_loan_id = dr.Item("id")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose()
            End Try

        End Using

    End Sub

    'Public Sub LoadListView()
    '    lvLoanList.Items.Clear()
    '    Using db As New DBHelper(My.Settings.ConnectionString)
    '        Dim dr As SQLite.SQLiteDataReader

    '        'Dim rec As Integer
    '        Dim data As New Dictionary(Of String, Object)
    '        Try
    '            data.Add("SearchText", txtSearchLoan.Text.Trim)
    '            'data.Add("client_id", txtClientID.Text)
    '            'data.Add("principal", numTostr(txtPrincipal.Text))
    '            'data.Add("amortization", txtBiMonthlyAmort.Text)
    '            'data.Add("date_start", Format(dtStart.Value, "yyyyMMdd"))
    '            'data.Add("date_end", Format(dtEnd.Value, "yyyyMMdd"))
    '            'data.Add("interest_percentage", cboInterest.Text)
    '            'data.Add("date_approved", "00000000")
    '            'data.Add("date_enrolled", Format(Now, "yyyyMMdd"))
    '            'data.Add("terms", Val(txtTerms.Text))
    '            'data.Add("application_status", cboApplicationStatus.SelectedIndex)
    '            'data.Add("loan_status", cboLoanStatus.SelectedIndex)
    '            'data.Add("loan_remarks", txtLoanRemarks.Text)


    '            'rec = db.ExecuteNonQuery("insert into tbl_loans values(NULL, @client_id, @principal, @amortization, @date_start, @date_end, " & _
    '            '                         "@interest_percentage, @date_approved, @date_enrolled , @terms, @application_status, @loan_status, " & _
    '            '                         "@loan_remarks)", data)

    '            dr = db.ExecuteReader("select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
    '                            "terms, date_start, date_end, application_status, loan_status, loan_remarks " & _
    '                            "from tbl_loans L " & _
    '                            "left join tbl_clients C on L.client_id = C.client_id " & _
    '                            "left join tbl_branches B on C.branch_id = B.branch_id " & _
    '                            "left join tbl_company Co on B.company_id = Co.company_id " & _
    '                            "where loan_id like '%" & txtSearchLoan.Text & "%'  or first_name like '%" & txtSearchLoan.Text & "%' " & _
    '                            " or middle_name like '%" & txtSearchLoan.Text & "%' or last_name like '%" & txtSearchLoan.Text & "%' " & _
    '                            "or L.client_id like '%" & txtSearchLoan.Text & "%' or branch_name like '%" & txtSearchLoan.Text & "%' " & _
    '                            "or company_name like '%" & txtSearchLoan.Text & "%'")

    '            If dr.HasRows Then
    '                Do While dr.Read
    '                    '  Dim itmx As ListViewItem = lvLoanList.Items.Add(dr.Item("loan_id").ToString)
    '                    itmx.SubItems.Add(dr.Item("name").ToString)
    '                    itmx.SubItems.Add(StrToNum(dr.Item("principal").ToString))
    '                    itmx.SubItems.Add(StrToNum(dr.Item("amortization").ToString))
    '                    itmx.SubItems.Add(dr.Item("interest_percentage").ToString)
    '                    itmx.SubItems.Add(dr.Item("terms").ToString)
    '                    itmx.SubItems.Add(StrToDate(dr.Item("date_start").ToString))
    '                    itmx.SubItems.Add(StrToDate(dr.Item("date_end").ToString))
    '                    '  itmx.SubItems.Add(cboApplicationStatus.Items(dr.Item("application_status").ToString))
    '                    ' itmx.SubItems.Add(cboLoanStatus.Items(dr.Item("loan_status").ToString))
    '                    itmx.SubItems.Add(dr.Item("loan_remarks").ToString)


    '                Loop
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try

    '    End Using

    'End Sub
    'Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click

    '    lvClientList.Items.Clear()

    '    Dim data As New Dictionary(Of String, Object)
    '    data.Add("searchkey1", "%" + txtSearchClient.Text + "%")
    '    data.Add("searchkey2", "%" & txtSearchClient.Text & "%")
    '    data.Add("searchkey3", "%" + txtSearchClient.Text + "%")

    '    Dim db As New DBHelper(My.Settings.ConnectionString)
    '    Dim dr As SQLite.SQLiteDataReader

    '    Try
    '        dr = db.ExecuteReader("select client_id, employee_no, last_name, first_name, middle_name, company_name, branch_name, credit_limit " & _
    '                        "from tbl_clients as A " & _
    '                        "left join tbl_branches as B on A.branch_id=B.branch_id " & _
    '                        "left join tbl_company as C on B.company_id=C.company_id " & _
    '                        "where last_name like '%" & txtSearchClient.Text & "%' or " & _
    '                        "first_name like '%" & txtSearchClient.Text & "%' or " & _
    '                        "middle_name like '%" & txtSearchClient.Text & "%' or " & _
    '                        "company_name like '%" & txtSearchClient.Text & "%' or " & _
    '                        "branch_name like '%" & txtSearchClient.Text & "%' ")

    '        'dr = db.ExecuteReader("select client_id, last_name, first_name, middle_name from tbl_clients " & _
    '        '                      "where last_name like '%" & txtSearchClient.Text & "%' or " & _
    '        '                    "first_name like '%" & txtSearchClient.Text & "%' or " & _
    '        '                    "middle_name like '%" & txtSearchClient.Text & "%'")
    '        'dr = db.ExecuteReader("select client_id, last_name, first_name, middle_name from tbl_clients " & _
    '        '                      "where last_name like '@searchkey1' or " & _
    '        '                    "first_name like '@searchkey2' or " & _
    '        '                    "middle_name like '@searchkey3'", data)
    '        'dr = db.ExecuteReader("select client_id, last_name, first_name, middle_name from tbl_clients " & _
    '        '                      "where first_name like '%ne%'", data)
    '        If dr.HasRows Then
    '            Do While dr.Read
    '                Dim itmx As ListViewItem = lvClientList.Items.Add(dr.Item("client_id").ToString)
    '                itmx.SubItems.Add(dr.Item("last_name").ToString & ", " & dr.Item("first_name").ToString & " " & dr.Item("middle_name").ToString)
    '                itmx.SubItems.Add(dr.Item("company_name").ToString)
    '                itmx.SubItems.Add(dr.Item("branch_name").ToString)
    '                'itmx.SubItems.Add(dr.Item("company_name").ToString)
    '                itmx.SubItems.Add(dr.Item("employee_no").ToString)
    '                itmx.SubItems.Add(dr.Item("credit_limit").ToString)

    '            Loop
    '        End If
    '    Catch ex As Exception

    '    End Try




    'End Sub

    'Private Sub txtSearchClient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchClient.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        btnSearchClient_Click(Me, e)
    '    End If
    'End Sub


    'Private Sub txtSearchClient_TextChanged(sender As Object, e As EventArgs) Handles txtSearchClient.TextChanged

    'End Sub

    Private Sub selectUser(listindex As Long)

    End Sub

    'Private Sub btnSelectSearchClient_Click(sender As Object, e As EventArgs) Handles btnSelectSearchClient.Click
    '    Try
    '        txtClientID.Text = lvClientList.SelectedItems.Item(0).Text
    '        txtName.Text = lvClientList.SelectedItems.Item(0).SubItems(1).Text
    '        txtCompany.Text = lvClientList.SelectedItems.Item(0).SubItems(2).Text
    '        txtBranch.Text = lvClientList.SelectedItems.Item(0).SubItems(3).Text
    '        lblEmployeeNumber.Text = lvClientList.SelectedItems.Item(0).SubItems(4).Text
    '        txtCreditLimit.Text = FormatNumber(lvClientList.SelectedItems.Item(0).SubItems(5).Text, 2)
    '        txtAvailableCredit.Text = ComputeAvailableCredit(txtClientID.Text)
    '        toggleClientSearch()

    '    Catch ex As Exception
    '        MsgBox("Please select a valid client first. You can filter or search client data through the 'search box' and then click the 'search button'", MsgBoxStyle.Exclamation)
    '    End Try
    'End Sub

    'Private Function ComputeAvailableCredit(ClientID As String) As String
    '    Return txtCreditLimit.Text
    'End Function

    Private Function evadeWeekends(petsa As Date) As Date
        'petsa = petsa.AddMonths(Val(txtTerms.Text.Trim))
        While petsa.DayOfWeek = DayOfWeek.Saturday OrElse petsa.DayOfWeek = DayOfWeek.Sunday
            petsa = petsa.AddDays(1)
        End While
        Return petsa
    End Function

    Private Sub ComputeEndDate()
        Dim petsa As Date = dtStart.Value
        If Val(txtTerms.Text.Trim) = 0 Then
            dtEnd.Value = petsa
            Exit Sub
        End If


        Dim size As Byte = Val(txtTerms.Text) * 2
        Dim DueDates(size) As Date
        Dim startDate As Date = dtStart.Value
        Dim endDate As Date = dtStart.Value
        Dim xDay As Byte = Format(startDate, "dd")
        Dim yDay As Byte '= IIf(xDay < 28, (xDay + 15) Mod 30, 15)

        If xDay <= 7 Then
            xDay = 5
            yDay = 20
        ElseIf xDay <= 12 Then
            xDay = 10
            yDay = 25
        ElseIf xDay <= 17 Then
            xDay = 15
            yDay = 31
        ElseIf xDay <= 22 Then
            xDay = 20
            yDay = 5
        ElseIf xDay <= 27 Then
            xDay = 25
            yDay = 10
        Else
            xDay = 31
            yDay = 15
            'yDay = (xDay + 15) Mod 30
        End If
        DueDates(0) = startDate
        For i = 1 To size Step 2
            Dim dayfixer As Byte = 0

            'DueDates(i) = New Date()
            If xDay < yDay Then
Fix1:
                Try
                    DueDates(i) = New Date(DueDates(i - 1).Year, DueDates(i - 1).Month, yDay - dayfixer)

                Catch ex As Exception
                    dayfixer = dayfixer + 1
                    GoTo Fix1
                End Try
            Else
                DueDates(i) = New Date(DueDates(i - 1).Year, DueDates(i - 1).Month, yDay).AddMonths(1)
                'DueDates(i).AddMonths(1)
            End If

            DueDates(i + 1) = DueDates(i - 1).AddMonths(1)
            dayfixer = 0
Fix2:
            Try
                DueDates(i + 1) = New Date(DueDates(i + 1).Year, DueDates(i + 1).Month, xDay - dayfixer)

            Catch ex As Exception
                dayfixer = dayfixer + 1
                GoTo Fix2
            End Try

            DueDates(i) = evadeWeekends(DueDates(i))
            DueDates(i + 1) = evadeWeekends(DueDates(i + 1))
            'DueDates(i) = DueDates(i - 1).AddDays(15)

            '' ''If Format(DueDates(i - 1), "dd") < 29 Then
            'DueDates(i + 1) = DueDates(i - 1).AddMonths(1)
            '' ''End If

        Next
        Dim ddates(size) As DueDateObj
        For id = 0 To size
            ddates(id) = New DueDateObj(id + 1, DueDates(id).Date)
        Next
        ddates(size) = Nothing
        'ReDim ddates(size - 1)
        DataGridView1.DataSource = ddates ' DueDates  '
        DataGridView1.Columns(0).HeaderText = "#"
        DataGridView1.Columns(0).Width = 40
        DataGridView1.Columns(1).HeaderText = "Due Date"
        DataGridView1.Columns(1).Width = 140
        'DataGridView1.AllowUserToAddRows = False
        'DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        'DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        'DataGridView1.AllowUserToAddRows = True

        dtEnd.Value = DueDates(size - 1)
        'DataGridView1.Columns.
    End Sub

    'Private Sub lvClientList_DoubleClick(sender As Object, e As EventArgs) Handles lvClientList.DoubleClick
    '    btnSelectSearchClient_Click(sender, e)
    'End Sub

    'Private Sub lvClientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvClientList.SelectedIndexChanged

    'End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtPrincipal_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or IsNumeric(txtPrincipal.Text) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPrincipal_TextChanged(sender As Object, e As EventArgs)
        computeTotalLoan()
    End Sub

    Private Sub txtTerms_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Up Then
            txtTerms.Text = Val(txtTerms.Text) + 1
        ElseIf e.KeyCode = Keys.Down And Val(txtTerms.Text.Trim) > 0 Then
            txtTerms.Text = Val(txtTerms.Text) - 1

        End If
    End Sub

    Private Sub txtTerms_KeyPress(sender As Object, e As KeyPressEventArgs)

    End Sub

    Private Sub txtTerms_TextChanged(sender As Object, e As EventArgs) Handles txtTerms.TextChanged
        computeTotalLoan()
        ComputeEndDate()


    End Sub

    Private Sub cboInterest_SelectedIndexChanged(sender As Object, e As EventArgs)
        computeTotalLoan()
    End Sub

    Private Sub cboInterest_TextChanged(sender As Object, e As EventArgs)
        computeTotalLoan()
    End Sub

    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs)
        ComputeEndDate()

    End Sub

    'Private Sub txtLoanRemarks_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoanRemarks.KeyPress

    'End Sub

    'Private Sub LoansV2_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
    '    LoadListView()
    'End Sub

    'Private Sub LoansV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    LoadListView()
    'End Sub

    'Private Sub btnSearchLoan_Click(sender As Object, e As EventArgs) Handles btnSearchLoan.Click
    '    LoadListView()
    'End Sub

    'Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
    '    Try
    '        If lvLoanList.FocusedItem.SubItems(9).Text <> cboLoanStatus.Items(0) Then
    '            MsgBox("This loan is currently " & lvLoanList.FocusedItem.SubItems(9).Text & " and cannot be editted.", MsgBoxStyle.Critical, "Unable to edit")
    '            Exit Sub
    '        End If
    '        active_loan_id = lvLoanList.FocusedItem.Text.Trim
    '        loadEditForm(active_loan_id)

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Sub

    'Private Sub loadEditForm(loan_id As Long)
    '    Using db As New DBHelper(My.Settings.ConnectionString)

    '        'Dim rec As Integer
    '        Try
    '            gbxAddEdit.Text = "Edit Loan Application"
    '            Dim dr As SQLite.SQLiteDataReader
    '            Dim data As New Dictionary(Of String, Object)
    '            data.Add("loan_id", loan_id)

    '            dr = db.ExecuteReader("select loan_id, L.client_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
    '                            "terms, date_start, date_end, application_status, loan_status, " & _
    '                            "Co.company_name, B.branch_name, loan_remarks " & _
    '                            "from tbl_loans L " & _
    '                            "left join tbl_clients C on L.client_id = C.client_id " & _
    '                            "left join tbl_branches B on C.branch_id = B.branch_id " & _
    '                            "left join tbl_company Co on B.company_id = Co.company_id " & _
    '                            "where loan_id = @loan_id", data)

    '            If dr.HasRows Then

    '                isLOADING = True

    '                toggleLoanApplication(True)
    '                clearClientProfileBox()

    '                txtClientID.Text = dr.Item("client_id")
    '                txtName.Text = dr.Item("name")
    '                txtCompany.Text = dr.Item("company_name")
    '                txtPrincipal.Text = StrToNum(dr.Item("principal"), 2, False)
    '                txtBranch.Text = dr.Item("branch_name")
    '                'txtBiMonthlyAmort.Text = dr.Item("loan_id")
    '                txtLoanRemarks.Text = dr.Item("loan_remarks")
    '                dtStart.Value = StrToDate(dr.Item("date_start"))
    '                cboApplicationStatus.SelectedIndex = dr.Item("application_status")
    '                cboLoanStatus.SelectedIndex = dr.Item("loan_status")

    '                isLOADING = False

    '                txtTerms.Text = dr.Item("terms")

    '            End If

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        Finally
    '            db.Dispose()
    '            isLOADING = False
    '        End Try

    '    End Using
    'End Sub

    'Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
    '    Dim isVERIFIED As Boolean = False

    '    Using db As New DBHelper(My.Settings.ConnectionString)
    '        Dim dr As SQLite.SQLiteDataReader
    '        'Dim cmd As SQLite.SQLiteCommand
    '        Dim data As New Dictionary(Of String, Object)
    '        Dim user As String = txtUser.Text
    '        Dim pass As String = txtPassword.Text
    '        'Dim Usertype As String = lblUtype.Text
    '        If txtUser.Text = "" And txtPassword.Text = "" Then
    '            MsgBox("Please provide username and password.", MsgBoxStyle.Exclamation, "Authentication Error")
    '            toggleVerifyActivation()
    '            Exit Sub

    '        End If

    '        Try
    '            dr = db.ExecuteReader("select * from tbl_users where user_name like '%" & txtUser.Text & "%' and user_password like '%" & Encrypt(txtPassword.Text, "Keys") & "%' ")
    '            If dr.HasRows Then
    '                Do While dr.Read
    '                    Dim encryptPass = Encrypt(txtPassword.Text, "Keys")
    '                    Dim uname = (dr.Item("user_name").ToString)
    '                    Dim upass = (dr.Item("user_password").ToString)
    '                    'Dim utype = (CInt(dr.Item("user_type")))
    '                    'lblUtype.Text = utype
    '                    If uname = txtUser.Text And upass = encryptPass Then
    '                        isVERIFIED = True

    '                    End If
    '                Loop
    '            Else
    '                MessageBox.Show("Username and Password do not match..", "Authentication Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '                'Clear all fields
    '                txtPassword.Text = ""
    '                txtUser.Text = ""
    '                txtUser.Focus()
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        Finally
    '            db.Dispose()
    '        End Try

    '    End Using

    '    If isVERIFIED Then
    '        Using db2 As New DBHelper(My.Settings.ConnectionString)
    '            Try
    '                Dim rec As Integer
    '                Dim data2 As New Dictionary(Of String, Object)

    '                data2.Add("loan_id", lvLoanList.FocusedItem.Text)
    '                rec = db2.ExecuteNonQuery("update tbl_loans set loan_status=1 where loan_id=@loan_id", data2)

    '                MsgBox("Loan successfuly activated!", MsgBoxStyle.Information, "Activate Loan")
    '            Catch ex As Exception
    '                MsgBox(ex.Message, MsgBoxStyle.Critical)
    '            Finally
    '                db2.Dispose()
    '            End Try

    '        End Using
    '    End If

    '    toggleVerifyActivation()
    '    LoadListView()
    'End Sub

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


    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        showUSC(uscMainmenu)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'codes
        Dim row As DataRow = Nothing
        Dim DS As New DataSet
        Dim rptLoanCalculateAttack As New LoanCalculator
        'mag a-add na sa dataset (DS)
        DS.Tables.Add("LoanCalculator")
        'lagay tayo ng columns
        With DS.Tables(0).Columns
            .Add("PrincipalAmount")
            .Add("InterestRate")
            .Add("Term")
            .Add("DateStart")
            .Add("DateEnd")
            .Add("MonthlyInterest")
            .Add("BiMonthlyInterest")
            .Add("TotalInterest")
            .Add("TotalLoanAmount")
            .Add("AssessedBy")
        End With

        row = DS.Tables(0).NewRow
        row(0) = txtPrincipal.Text
        row(1) = cboInterest.Text
        row(2) = txtTerms.Text
        row(3) = Format(dtStart.Value, "MM/dd/yyyy")
        row(4) = Format(dtEnd.Value, "MM/dd/yyyy")
        row(5) = txtMonthlyInterest.Text
        row(6) = txtBiMonthlyAmort.Text
        row(7) = txtTotalInterest.Text
        row(8) = txtTotalLoanAmount.Text
        row(9) = txtAsses.Text
        DS.Tables(0).Rows.Add(row)

        DS.WriteXml("XML\LoanCalculator.xml")

        Dim dsLoanCalculator As New DataSet
        dsLoanCalculator = New DSreports
        Dim dsLoanCalculatorTemp As New DataSet
        dsLoanCalculatorTemp = New DataSet()
        dsLoanCalculatorTemp.ReadXml("XML\LoanCalculator.xml")
        dsLoanCalculator.Merge(dsLoanCalculatorTemp.Tables(0))
        rptLoanCalculateAttack = New LoanCalculator
        rptLoanCalculateAttack.SetDataSource(dsLoanCalculator)
        crvLoanCalculator.ReportSource = (rptLoanCalculateAttack)
        showReport(True)

        'computeTotalLoan()
        'ComputeEndDate()
        ''codes
        'Dim row As DataRow = Nothing
        'Dim DS As New DataSet
        'Dim rptLoanCalculateAttack As New LoanCalculator
        ''mag a-add na sa dataset (DS)
        'DS.Tables.Add("Loan Calculator")
        ''lagay tayo ng columns
        'With DS.Tables(0).Columns
        '    .Add("Principal_amount")
        '    .Add("Interest")
        '    .Add("Term")
        '    .Add("Date_start")
        '    .Add("Date_end")
        '    .Add("Monthly_interest")
        '    .Add("Bi_monthly")
        '    .Add("total_interest")
        '    .Add("total_loan_amount")
        'End With

        'row = DS.Tables(0).NewRow
        'row(0) = txtPrincipal.Text
        'row(1) = cboInterest.Text
        'row(2) = txtTerms.Text
        'row(3) = Format(dtStart.Value, "MM/dd/yyyy")
        'row(4) = Format(dtEnd.Value, "MM/dd/yyyy")
        'row(5) = txtMonthlyInterest.Text
        'row(6) = txtBiMonthlyAmort.Text
        'row(7) = txtTotalInterest.Text
        'row(8) = txtTotalLoanAmount.Text
        'DS.Tables(0).Rows.Add(row)

        'DS.WriteXml("XML\LoanCalculator.xml")

        'Dim dsLoanCalculator As New DataSet
        'dsLoanCalculator = New DataSetReport
        'Dim dsLoanCalculatorTemp As New DataSet
        'dsLoanCalculatorTemp = New DataSet()
        'dsLoanCalculatorTemp.ReadXml("XML\LoanCalculator.xml")
        'dsLoanCalculator.Merge(dsLoanCalculatorTemp.Tables(0))
        'rptLoanCalculateAttack = New LoanCalculator
        'rptLoanCalculateAttack.SetDataSource(dsLoanCalculator)
        'crvLoanCalculator.ReportSource = (rptLoanCalculateAttack)




        'Dim MyNode() As TreeNode
        'Dim writer As New XmlTextWriter("LoanCalculator.xml", System.Text.Encoding.UTF8)
        'writer.WriteStartDocument(True)
        'writer.Formatting = Formatting.Indented
        'writer.Indentation = 2
        'writer.WriteStartElement("Table")
        'CreateNode(1, "Principal_Amount", "1000", writer)
        'CreateNode(2, "Interest_rete", "2000", writer)
        'CreateNode(3, "Term", "3000", writer)
        'CreateNode(4, "Date_start", "4000", writer)
        'CreateNode(5, "Mounthly_Interest", "5000", writer)
        'CreateNode(6, "Bi_Mounthly_Amount", "6000", writer)
        'CreateNode(7, "Total_Interest", "7000", writer)
        'CreateNode(8, "Total_Loan_Amount", "8000", writer)
        'writer.WriteEndElement()
        'writer.WriteEndDocument()
        'writer.Close()




        'Dim DS As New DataSetReport
        'Dim DT As New DataTable


        'Dim myReport As New LoanCalculator()

        'myReport.PrintOptions.PrinterName = ""
        'myReport.PrintOptions.PaperSize = CrystalDecisions.[Shared].PaperSize.PaperA4
        'myReport.PrintOptions.PrinterDuplex = CrystalDecisions.[Shared].PrinterDuplex.Default

        'Dim myMargins = myReport.PrintOptions.PageMargins
        'myMargins.topMargin = 10
        'myMargins.bottomMargin = 10
        'myMargins.leftMargin = 10
        'myMargins.rightMargin = 10

        'myReport.PrintOptions.ApplyPageMargins(myMargins)
        'myReport.PrintToPrinter(1, True, 1, 999)


        'Dim rpt As New LoanCalculator
        'rpt.DataSourceConnections.Item(0).SetConnection("", "" & sysDB, False)
        'RPTCalculator.ReportSource = rpt
        'RPTCalculator.PrintReport()

        '    Try
        '        Me.Cursor = Cursors.WaitCursor
        '        If Len(cboPrintOption.Text) > 0 Then
        '            Select Case cboPrintOption.Text
        '                Case "Export to PDF"
        '                    ExportToPDF()
        '                    MsgBox("Export Done!")
        '                Case "Print to Printer"
        '                    RPTCalculator.PrintToPrinter(1, True, 0, 0)
        '                    MsgBox("Print to printer done! ")
        '            End Select
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.ToString)
        '    End Try



        'End Sub

        'Private Sub CreateNode(ByVal PAmount As Integer, ByVal IRate As Integer, ByVal Term As Integer, _
        '                       ByVal MInterest As Integer, ByVal TInterest As Integer, ByVal TLAmount As Integer, _
        '                       ByVal DStart As Integer, ByVal DEnd As Integer, ByVal writer As XmlTextWriter)
        '    writer.WriteStartElement("Principal Amount")
        '    writer.WriteStartElement("Principal_Amount")
        '    writer.WriteString(PAmount)
        '    writer.WriteEndDocument()
        '    writer.WriteStartElement("Interest rate")
        '    writer.WriteStartElement("Interest_rate")
        '    writer.WriteString(IRate)
        '    writer.WriteEndDocument()
        '    writer.WriteStartElement("Term")
        '    writer.WriteStartElement("Term")
        '    writer.WriteString(Term)
        '    writer.WriteEndDocument()
        '    writer.WriteStartElement("Monthly Interest")
        '    writer.WriteStartElement("Monthly_Interest")
        '    writer.WriteString(MInterest)
        '    writer.WriteEndDocument()
        '    writer.WriteStartElement("Bi-mounthly Amount")
        '    writer.WriteStartElement("Bi_Monthly_Amount")
        '    writer.WriteString(BMinterest)
        '    writer.WriteEndDocument()
    End Sub
    Private Sub ExportToPDF()
        'Dim myReport As New LoanCalculator()
        'myReport.Load()

        'Dim myExportOptions As New CrystalDecisions.Shared.ExportOptions()
        'Dim myDiskFileDestinationOption As New CrystalDecisions.Shared.DiskFileDestinationOptions()
        'Dim myFormatTypeOptions As New CrystalDecisions.Shared.PdfRtfWordFormatOptions()


        'myDiskFileDestinationOption.DiskFileName =
        '    "C:\CrystalReports\Chapter09\test.pdf"
        'myExportOptions = myReport.ExportOptions

        'With myExportOptions
        '    .ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile
        '    .ExportDestinationType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat
        '    .DestinationOptions = myDiskFileDestinationOption
        '    .FormatOptions = myFormatTypeOptions
        'End With

        'myReport.Export()
        'MsgBox("Your report has been exported in PDF format and saved to C:\CrystalReports\Chapter09\test.pdf")
        Try
            Dim Calculator As ExportOptions
            Dim DFDOCalculator As New DiskFileDestinationOptions()
            Dim FTOCalculator As New PdfRtfWordFormatOptions()
            DFDOCalculator.DiskFileName = Application.StartupPath() & "\Report Generated\PDF\Loan CalculatorV2 - " & txtPrincipal.Text & ".pdf"
            Calculator = RPTCalculator.ExportOptions
            With Calculator
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = DFDOCalculator
                .ExportFormatOptions = FTOCalculator
            End With
            RPTCalculator.Export()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub ProcessReport(Optional ByVal xEmpCode As String = "")


        Try
            If Len(xEmpCode) <> 0 Then
                Loan_calculatorV2(xEmpCode)
            Else
                Loan_calculatorV2()
            End If

            Dim DSLoanCalculator As New DSreports

            DSLoanCalculator = New DSreports()
            Dim DSLoanCalculatorTemp As New DSreports

            DSLoanCalculator = New DSreports()
            DSLoanCalculatorTemp.ReadXml(Application.StartupPath() & "xml\LoanCalculator.xml ")
            DSLoanCalculator.Merge(DSLoanCalculatorTemp.Tables(0))
            RPTCalculator = New LoanCalculator
            RPTCalculator.SetDataSource(DSLoanCalculator.Tables(0))
            RPTCalculator.SetParameterValue("Pincipal_Amount", txtPrincipal.Text)
            RPTCalculator.SetParameterValue("Interest_Rate", cboInterest.Text)
            RPTCalculator.SetParameterValue("Term", txtTerms.Text)
            RPTCalculator.SetParameterValue("Date_start", dtStart.Text)
            RPTCalculator.SetParameterValue("Date_end", dtEnd.Text)
            RPTCalculator.SetParameterValue("Monthly_Interest", txtMonthlyInterest.Text)
            RPTCalculator.SetParameterValue("Bi_Monthly_Amort", txtBiMonthlyAmort.Text)
            RPTCalculator.SetParameterValue("Total_Interest", txtTotalInterest.Text)
            RPTCalculator.SetParameterValue("Total_Loan_Amount", txtTotalLoanAmount.Text)
            crvLoanCalculator.ReportSource = RPTCalculator

            gpPrintOption.Visible = True
        Catch ex As Exception
            gpPrintOption.Visible = False
            MsgBox(ex.Message)
        End Try
    End Sub

    'Public Overridable ReadOnly Property ExportOptions As CrystalDecisions.Shared.ExportOptions
    '    Get

    '    End Get
    'End Property

    Public Overridable Sub PrintToPrinter(nCopies As Integer, collated As Boolean, startPageN As Integer, endPageN As Integer)

    End Sub

    Private Sub Loan_calculatorV2(xEmpCode As String)
        Throw New NotImplementedException
    End Sub

    Private Sub Loan_calculatorV2()
        Throw New NotImplementedException
    End Sub



    'Private Sub InvokePrint(ByVal sender As Object, ByVal e As RoutedEventArgs)

    '    Dim pDialog As New PrintDialog()
    '    pDialog.PageRangeSelection = PageRageSelection.AllPages
    '    pDialog.UserPageRangeEnable = True

    '    Dim print? As Boolean = pDialog.ShowDialog()
    '    If print = True Then
    '        Dim xmlDocument As New xmlDocument("XML\LoanCalculator.xml", FileAccess.ReadWrite)
    '        Dim fixedDocSeq As FixedDocumentSequence = xmlDocument.GetFixedDocumentSequence()
    '        pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job")

    '    End If
    'End Sub

    'Protected Sub Page_Init(sender As Object, e As EventArgs)
    '    If LoanCalculator.ProcessPrintJob(Request) Then

    '        Dim ds As New DSreports()
    '        ds.ReadXml(Server.MapPath("XML\LoanCalculator.xml"))

    '        Dim myCrystalReport As New ReportDocument()
    '        myCrystalReport.LoadServer.MapPath("XML\LoanCalculator.xml")
    '    End If
    'End Sub

    Private Sub Loan_CalculatorV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim myReport As New LoanCalculator()
        'CrystalReportViewer1.ReportSource = myReport
        'myReport.Load()
        'MsgBox(myReport.SummaryInfo.ReportTitle.ToString())
    End Sub

    'Private Sub report_InitReport(ByVal sender As Object, ByVal myEvent As System.EventArgs) Handles LoanCalculator.InitReport
    '    MsgBox("Report loaded fine")
    'End Sub

    Private Sub report_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim reportpath As String
        'reportpath = Application.StartupPath & "LoanCalculator.rpt"
        'Dim objrpt As New ReportDocument

        'Dim DataSet As New CRDataSet

        ''If DataSet.Tables.Count <> 0 Then
        ''    DataSet.WriteXml("xml\LoanCalculator.xml")
        ''End If

        ''objrpt.Load(reportpath)
        ''Me.CrystalReportViewer1.Refresh()



        'objrpt.SetParameterValue("PAmount", txtPrincipal.Text)
        'objrpt.SetParameterValue("IRate", cboInterest.Text)
        'objrpt.SetParameterValue("Term", txtTerms.Text)
        'objrpt.SetParameterValue("MInterest", txtMonthlyInterest.Text)
        'objrpt.SetParameterValue("BMinterest", txtBiMonthlyAmort.Text)
        'objrpt.SetParameterValue("TInterest", txtTotalInterest.Text)
        'objrpt.SetParameterValue("TLAmount", txtTotalLoanAmount.Text)
        'objrpt.SetParameterValue("DStart", dtStart.Text)
        'objrpt.SetParameterValue("DEnd", dtEnd.Text)
        'Me.CrystalReportViewer1.ReportSource = objrpt
        'Me.CrystalReportViewer1.Show()
    End Sub


    'Module XmlModule

    'Class LoanCalculator
    '    Public Sub New(ByVal Principal_Amount As Integer, ByVal Interest_rate As Integer, ByVal Term As Integer, ByVal Date_start As Integer, _
    '    '               ByVal Date_end As Integer, ByVal Monthly_Interest As Integer, ByVal Bi_Monthly_Amount As Integer, ByVal Total_Interest As Integer, _
    '                       ByVal Total_Loan_Amount As Integer)

    '    Me._Principal_amount = Principal_Amount
    '    Me._Interest_rate = Interest_rate
    '    Me._Term = Term
    '    Me._Date_start = Date_start
    '    Me._Date_end = Date_end
    '    Me._Monthly_Interest = Monthly_Interest
    '    Me._Bi_Monthly_Interest = Bi_Monthly_Amount
    '    Me._Total_Interest = Total_Interest
    '    Me._Total_Loan_Amount = Total_Loan_Amount


    'End Sub

    '    Public _Principal_amount As Integer
    '    Public _Interest_rate As Integer
    '    Public _Term As Integer
    '    Public _Date_start As Integer
    '    Public _Date_end As Integer
    '    Public _Monthly_Interest As Integer
    '    Public _Bi_Monthly_Interest As Integer
    '    Public _Total_Interest As Integer
    '    Public _Total_Loan_Amount As Integer
    'End Class

    'Sub Main()
    '    Dim Settings As XmlWriterSettings = New XmlWriterSettings()
    '    Settings.Indent = True

    '    Using write As XmlWriter = XmlWriter.Create("C:\Loancalculator.xml", Settings)

    '        write.WriteStartDocument()
    '        write.WriteStartElement("LoanCalculator")

    '        Dim LoanCal As New LoanCalculator
    '        For Each LoanCal In LoanCalculator
    '            write.WriteStartElement("Loan Calculator")
    '            write.WriteElementString("ID", LoanCalculator._Principal.ToString)

    '        Next
    '    End Using

    'End Sub

    Private Sub bntClose_Click(sender As Object, e As EventArgs) Handles bntClose.Click
        showReport(False)
    End Sub
End Class
