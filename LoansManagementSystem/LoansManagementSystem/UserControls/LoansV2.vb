Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports System.Drawing.Drawing2D

Public Class LoansV2
    Dim active_loan_id As Long = 0
    Dim isLOADING As Boolean = False

    Private lvwColumnSorter As ListViewColumnSorter

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

        principal = Val(txtPrincipal.Text.Trim.Replace(",", ""))
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
        For Each Control In gbxClientData.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control

        For Each Control In gbxLoanData1.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control

        For Each Control In gbxLoanData2.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control
    End Sub

    Private Function validateInputs() As Boolean
        If txtClientID.Text.Trim = "" Then
            MsgBox("Cannot save this record. Please select a client first.", MsgBoxStyle.Critical, "New Loan Application - Error")
            toggleClientSearch(True)
            Return False
        End If

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
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        showUSC(uscMainmenu)
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        'gbxAddEdit.Visible = True
        gbxAddEdit.Text = "New Loan Application"
        cboApplicationStatus.SelectedIndex = 0
        cboLoanStatus.SelectedIndex = 0
        Try
            DataGridView1.DataSource = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        toggleLoanApplication(True)
        btnFind_Click(Me, e)

        clearClientProfileBox()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        toggleClientSearch(True)
    End Sub

    Private Sub btnClientBack_Click(sender As Object, e As EventArgs) Handles btnClientBack.Click
        toggleClientSearch()
    End Sub

    Private Sub toggleClientSearch(Optional mode As Boolean = False)
        gbxShowClient.Visible = mode
        gbxShowClient.Enabled = mode
        If mode Then
            gbxShowClient.BringToFront()
        Else
            gbxShowClient.SendToBack()
        End If

        gbxClientData.Enabled = Not mode

    End Sub

    Private Sub toggleLoanApplication(Optional mode As Boolean = False)
        gbxAddEdit.Visible = mode
        gbxAddEdit.Enabled = mode
        If mode Then
            gbxAddEdit.BringToFront()
        Else
            gbxAddEdit.SendToBack()
        End If

        gbxClientData.Enabled = Not mode

        pnlMain.Enabled = Not mode
    End Sub

    Private Sub toggleVerifyActivation(Optional mode As Boolean = False)
        gbxVerifyActivation.Visible = mode
        gbxVerifyActivation.Enabled = mode
        If mode Then
            gbxVerifyActivation.BringToFront()
        Else
            gbxVerifyActivation.SendToBack()
        End If

        gbxClientData.Enabled = Not mode

        pnlMain.Enabled = Not mode
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        toggleLoanApplication()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ComputeAvailableCredit(txtClientID.Text)
        If CDbl(txtAvailableCredit.Text) < CDbl(txtPrincipal.Text) Then

            MsgBox("Principal is exceed to available credit" & vbCrLf & "Available Credit: " & txtAvailableCredit.Text, vbExclamation + vbOKOnly, "Exceed")
            Exit Sub
        End If
        If validateInputs() = False Then Exit Sub

        If gbxAddEdit.Text = "New Loan Application" Then
            saveNewForm()
        Else
            saveEditForm()
        End If

        saveCollectibles()

        MsgBox("Record saved!", MsgBoxStyle.Information)
        toggleLoanApplication()
        LoadListView()
        'toggleLoanApplication()
    End Sub

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

                data.Add("client_id", txtClientID.Text)
                data.Add("principal", NumToStr(FormatNumber(txtPrincipal.Text, 2)))
                data.Add("amortization", NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2)))
                data.Add("date_start", Format(dtStart.Value, "yyyyMMdd"))
                data.Add("date_end", Format(dtEnd.Value, "yyyyMMdd"))
                data.Add("interest_percentage", cboInterest.Text)
                data.Add("date_approved", "00000000")
                data.Add("date_enrolled", Format(Now, "yyyyMMdd"))
                data.Add("terms", Val(txtTerms.Text))
                data.Add("application_status", cboApplicationStatus.SelectedIndex)
                data.Add("loan_status", cboLoanStatus.SelectedIndex)
                data.Add("loan_remarks", txtLoanRemarks.Text)


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

                data.Add("client_id", txtClientID.Text)
                data.Add("principal", NumToStr(FormatNumber(txtPrincipal.Text, 2)))
                data.Add("amortization", NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2)))
                data.Add("date_start", Format(dtStart.Value, "yyyyMMdd"))
                data.Add("date_end", Format(dtEnd.Value, "yyyyMMdd"))
                data.Add("interest_percentage", cboInterest.Text)
                data.Add("date_approved", "00000000")
                data.Add("date_enrolled", Format(Now, "yyyyMMdd"))
                data.Add("terms", Val(txtTerms.Text))
                data.Add("application_status", cboApplicationStatus.SelectedIndex)
                data.Add("loan_status", cboLoanStatus.SelectedIndex)
                data.Add("loan_remarks", txtLoanRemarks.Text)
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

    Public Sub LoadListView()
        lvLoanList.Items.Clear()
        Using db As New DBHelper(My.Settings.ConnectionString)
            Dim dr As SQLite.SQLiteDataReader

            'Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Try
                data.Add("SearchText", txtSearchLoan.Text.Trim)
                'data.Add("client_id", txtClientID.Text)
                'data.Add("principal", numTostr(txtPrincipal.Text))
                'data.Add("amortization", txtBiMonthlyAmort.Text)
                'data.Add("date_start", Format(dtStart.Value, "yyyyMMdd"))
                'data.Add("date_end", Format(dtEnd.Value, "yyyyMMdd"))
                'data.Add("interest_percentage", cboInterest.Text)
                'data.Add("date_approved", "00000000")
                'data.Add("date_enrolled", Format(Now, "yyyyMMdd"))
                'data.Add("terms", Val(txtTerms.Text))
                'data.Add("application_status", cboApplicationStatus.SelectedIndex)
                'data.Add("loan_status", cboLoanStatus.SelectedIndex)
                'data.Add("loan_remarks", txtLoanRemarks.Text)


                'rec = db.ExecuteNonQuery("insert into tbl_loans values(NULL, @client_id, @principal, @amortization, @date_start, @date_end, " & _
                '                         "@interest_percentage, @date_approved, @date_enrolled , @terms, @application_status, @loan_status, " & _
                '                         "@loan_remarks)", data)

                dr = db.ExecuteReader("select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, application_status, loan_status, loan_remarks, company_name, branch_name " & _
                                "from tbl_loans L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id like '%" & txtSearchLoan.Text & "%'  or first_name like '%" & txtSearchLoan.Text & "%' " & _
                                " or middle_name like '%" & txtSearchLoan.Text & "%' or last_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or L.client_id like '%" & txtSearchLoan.Text & "%' or branch_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or company_name like '%" & txtSearchLoan.Text & "%'")

                If dr.HasRows Then
                    Do While dr.Read
                        Dim itmx As ListViewItem = lvLoanList.Items.Add(dr.Item("loan_id").ToString)
                        itmx.SubItems.Add(dr.Item("name").ToString)
                        itmx.SubItems.Add(FormatNumber(StrToNum(dr.Item("principal").ToString), 2))
                        itmx.SubItems.Add(FormatNumber(StrToNum(dr.Item("amortization").ToString), 2))
                        itmx.SubItems.Add(dr.Item("interest_percentage").ToString)
                        itmx.SubItems.Add(dr.Item("terms").ToString)
                        itmx.SubItems.Add(StrToDate(dr.Item("date_start").ToString))
                        itmx.SubItems.Add(StrToDate(dr.Item("date_end").ToString))
                        itmx.SubItems.Add(cboApplicationStatus.Items(dr.Item("application_status").ToString))
                        itmx.SubItems.Add(cboLoanStatus.Items(dr.Item("loan_status").ToString))
                        itmx.SubItems.Add(dr.Item("loan_remarks").ToString)
                        itmx.SubItems.Add(dr.Item("company_name").ToString)
                        itmx.SubItems.Add(dr.Item("branch_name").ToString)


                    Loop
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

    End Sub
    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click

        lvClientList.Items.Clear()

        Dim data As New Dictionary(Of String, Object)
        data.Add("searchkey1", "%" + txtSearchClient.Text + "%")
        data.Add("searchkey2", "%" & txtSearchClient.Text & "%")
        data.Add("searchkey3", "%" + txtSearchClient.Text + "%")

        Dim db As New DBHelper(My.Settings.ConnectionString)
        Dim dr As SQLite.SQLiteDataReader

        Try
            dr = db.ExecuteReader("select client_id, employee_no, last_name, first_name, middle_name, company_name, branch_name, credit_limit " & _
                            "from tbl_clients as A " & _
                            "left join tbl_branches as B on A.branch_id=B.branch_id " & _
                            "left join tbl_company as C on B.company_id=C.company_id " & _
                            "where last_name like '%" & txtSearchClient.Text & "%' or " & _
                            "first_name like '%" & txtSearchClient.Text & "%' or " & _
                            "middle_name like '%" & txtSearchClient.Text & "%' or " & _
                            "company_name like '%" & txtSearchClient.Text & "%' or " & _
                            "branch_name like '%" & txtSearchClient.Text & "%' ")

            'dr = db.ExecuteReader("select client_id, last_name, first_name, middle_name from tbl_clients " & _
            '                      "where last_name like '%" & txtSearchClient.Text & "%' or " & _
            '                    "first_name like '%" & txtSearchClient.Text & "%' or " & _
            '                    "middle_name like '%" & txtSearchClient.Text & "%'")
            'dr = db.ExecuteReader("select client_id, last_name, first_name, middle_name from tbl_clients " & _
            '                      "where last_name like '@searchkey1' or " & _
            '                    "first_name like '@searchkey2' or " & _
            '                    "middle_name like '@searchkey3'", data)
            'dr = db.ExecuteReader("select client_id, last_name, first_name, middle_name from tbl_clients " & _
            '                      "where first_name like '%ne%'", data)
            If dr.HasRows Then
                Do While dr.Read
                    Dim itmx As ListViewItem = lvClientList.Items.Add(dr.Item("client_id").ToString)
                    itmx.SubItems.Add(dr.Item("last_name").ToString & ", " & dr.Item("first_name").ToString & " " & dr.Item("middle_name").ToString)
                    itmx.SubItems.Add(dr.Item("company_name").ToString)
                    itmx.SubItems.Add(dr.Item("branch_name").ToString)
                    'itmx.SubItems.Add(dr.Item("company_name").ToString)
                    itmx.SubItems.Add(dr.Item("employee_no").ToString)
                    Dim cLimit As Integer = dr.Item("credit_limit").ToString
                    itmx.SubItems.Add((cLimit * 0.01).ToString("N2"))
                Loop
            End If
        Catch ex As Exception

        End Try




    End Sub

    Private Sub txtSearchClient_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchClient.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSearchClient_Click(Me, e)
        End If
    End Sub


    Private Sub txtSearchClient_TextChanged(sender As Object, e As EventArgs) Handles txtSearchClient.TextChanged

    End Sub

    Private Sub selectUser(listindex As Long)

    End Sub

    Private Sub btnSelectSearchClient_Click(sender As Object, e As EventArgs) Handles btnSelectSearchClient.Click
        Try
            txtClientID.Text = lvClientList.SelectedItems.Item(0).Text
            txtName.Text = lvClientList.SelectedItems.Item(0).SubItems(1).Text
            txtCompany.Text = lvClientList.SelectedItems.Item(0).SubItems(2).Text
            txtBranch.Text = lvClientList.SelectedItems.Item(0).SubItems(3).Text
            lblEmployeeNumber.Text = lvClientList.SelectedItems.Item(0).SubItems(4).Text
            'txtCreditLimit.Text = FormatNumber(lvClientList.SelectedItems.Item(0).SubItems(5).Text, 2)
            'Dim cLimit As Integer = lvClientList.SelectedItems.Item(0).SubItems(5).Text
            txtCreditLimit.Text = lvClientList.SelectedItems.Item(0).SubItems(5).Text
            txtAvailableCredit.Text = ComputeAvailableCredit(txtClientID.Text)
            toggleClientSearch()
        Catch ex As Exception
            MsgBox("Please select a valid client first. You can filter or search client data through the 'search box' and then click the 'search button'", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ComputeAvailableCredit(ClientID As String) As String
        'codes for available credit (isasama ko pa ba mga penalized o hiwalay na yun????)oo nga pala penalties pa.....
        Dim db As New DBHelper(My.Settings.ConnectionString)
        Dim dr As SQLite.SQLiteDataReader
        Dim data As New Dictionary(Of String, Object)
        Dim totalUtangWInterest, overAllPayment, creditLimit, principal, monthlyRate, biMonInterest, interest _
            , totalPaymentBimonth, rembal, overAllPenaltyStats As Double
        Dim conV As String

        'principal = CDbl(dr.Item("principal").Insert(6, ".").ToString)
        'monthlyRate = principal / (CInt(dr.Item("terms").ToString) * 2)
        'biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
        'interest = principal * biMonInterest
        'totalPaymentBiMonth = monthlyRate + interest
        'rembal = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
        'txtPrincipalAmt.Text = principal
        'txtTerms.Text = dr.Item("terms").ToString
        'txtTotalLoanAmount.Text = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
        'txtDateStart.Text = StrToDate(dr.Item("date_start").ToString)
        'txtDateEnd.Text = StrToDate(dr.Item("date_end").ToString)
        'get the credit limit
        Try
            dr = db.ExecuteReader("SELECT credit_limit FROM tbl_clients WHERE client_id = " & txtClientID.Text)
            If dr.HasRows Then

                creditLimit = StrToNum(dr.Item(0).ToString)

                'creditLimit = dr.Item(0).ToString.Insert(6, ".")
            End If
            'Get all the active loans of the client.
            dr = db.ExecuteReader("SELECT loan_id, principal, interest_percentage, terms FROM tbl_loans INNER JOIN tbl_clients" & _
                                  " ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_clients.client_id =" & txtClientID.Text & _
                                  " AND loan_status = 1")
            If dr.HasRows Then

                Do While dr.Read
                    principal = StrToNum(dr.Item("principal").ToString)
                    monthlyRate = principal / (CInt(dr.Item("terms").ToString) * 2)
                    biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
                    interest = principal * biMonInterest
                    totalPaymentBimonth = monthlyRate + interest
                    totalUtangWInterest = totalPaymentBimonth * (CInt(dr.Item("terms").ToString) * 2)
                    principal = 0
                    monthlyRate = 0
                    biMonInterest = 0
                    interest = 0
                    totalPaymentBimonth = 0
                Loop
            End If
            dr = db.ExecuteReader("SELECT sum(amount) amt from tbl_payments INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                  "WHERE payment_status = 0 AND client_id= " & txtClientID.Text & " AND loan_status= 1")
            If dr.HasRows Then

                If dr.Item("amt").ToString <> "" Then
                  
                    overAllPayment = StrToNum(dr.Item("amt").ToString)
                End If

            End If
            dr = db.ExecuteReader("SELECT sum(penalty_amt) as amt, penalty_status FROM tbl_collectibles INNER JOIN tbl_loans ON tbl_collectibles.loan_id" & _
                                  " = tbl_loans.loan_id  WHERE client_id=" & txtClientID.Text & " AND loan_status = 1 AND penalty_status = 1")

            If dr.HasRows Then
                If dr.Item("amt").ToString <> "" Then
                   
                    overAllPenaltyStats = StrToNum(dr.Item("amt").ToString)

                Else
                    overAllPenaltyStats = 0
                End If
            End If
            'conditiones.
            rembal = totalUtangWInterest - (overAllPayment - overAllPenaltyStats)
            If rembal > creditLimit Then
                Return "0.00"
            ElseIf rembal <= creditLimit Then
                conV = NumToStr(creditLimit - rembal)
                '50000.5
                Return StrToNum(conV)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.Dispose()

        End Try
    End Function

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

            DueDates(i) = DueDates(i)
            DueDates(i + 1) = DueDates(i + 1)
            'DueDates(i) = DueDates(i - 1).AddDays(15)

            '' ''If Format(DueDates(i - 1), "dd") < 29 Then
            'DueDates(i + 1) = DueDates(i - 1).AddMonths(1)
            '' ''End If

        Next
        Dim ddates(size) As DueDateObj
        For id = 0 To size
            ddates(id) = New DueDateObj(id + 1, evadeWeekends(DueDates(id).Date))
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

    Private Sub lvClientList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvClientList.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.lvClientList.Sort()
    End Sub

    Private Sub lvClientList_DoubleClick(sender As Object, e As EventArgs) Handles lvClientList.DoubleClick
        btnSelectSearchClient_Click(sender, e)
    End Sub

    Private Sub lvClientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvClientList.SelectedIndexChanged

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub txtPrincipal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrincipal.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or IsNumeric(txtPrincipal.Text) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPrincipal_TextChanged(sender As Object, e As EventArgs) Handles txtPrincipal.TextChanged
        computeTotalLoan()
    End Sub

    Private Sub txtTerms_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTerms.KeyDown
        If e.KeyCode = Keys.Up Then
            txtTerms.Text = Val(txtTerms.Text) + 1
        ElseIf e.KeyCode = Keys.Down And Val(txtTerms.Text.Trim) > 0 Then
            txtTerms.Text = Val(txtTerms.Text) - 1

        End If
    End Sub

    Private Sub txtTerms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTerms.KeyPress

    End Sub

    Private Sub txtTerms_TextChanged(sender As Object, e As EventArgs) Handles txtTerms.TextChanged
        computeTotalLoan()
        ComputeEndDate()

    End Sub

    Private Sub cboInterest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInterest.SelectedIndexChanged
        computeTotalLoan()
    End Sub

    Private Sub cboInterest_TextChanged(sender As Object, e As EventArgs) Handles cboInterest.TextChanged
        computeTotalLoan()
    End Sub

    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs) Handles dtStart.ValueChanged
        ComputeEndDate()

    End Sub

    Private Sub txtLoanRemarks_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLoanRemarks.KeyPress

    End Sub

    Private Sub LoansV2_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        LoadListView()
    End Sub

    Private Sub LoansV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create an instance of a ListView column sorter and assign it 
        ' to the ListView control.
        lvwColumnSorter = New ListViewColumnSorter()
        Me.lvLoanList.ListViewItemSorter = lvwColumnSorter
        Me.lvClientList.ListViewItemSorter = lvwColumnSorter

        LoadListView()
    End Sub

    Private Sub btnSearchLoan_Click(sender As Object, e As EventArgs) Handles btnSearchLoan.Click
        LoadListView()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            If lvLoanList.FocusedItem.SubItems(9).Text <> cboLoanStatus.Items(0) Then
                MsgBox("This loan is currently " & lvLoanList.FocusedItem.SubItems(9).Text & " and cannot be editted.", MsgBoxStyle.Critical, "Unable to edit")
                Exit Sub
            End If
            active_loan_id = lvLoanList.FocusedItem.Text.Trim
            loadEditForm(active_loan_id)

        Catch ex As NullReferenceException

            MsgBox("Please select a record to edit.", MsgBoxStyle.Critical, "Edit error")
        End Try
    End Sub

    Private Sub loadEditForm(loan_id As Long)

        Using db As New DBHelper(My.Settings.ConnectionString)

            'Dim rec As Integer
            Try
                gbxAddEdit.Text = "Edit Loan Application"
                Dim dr As SQLite.SQLiteDataReader
                Dim data As New Dictionary(Of String, Object)
                data.Add("loan_id", loan_id)

                dr = db.ExecuteReader("select loan_id, L.client_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, application_status, loan_status, credit_limit, " & _
                                "Co.company_name, B.branch_name, loan_remarks " & _
                                "from tbl_loans L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id = @loan_id", data)

                If dr.HasRows Then

                    isLOADING = True

                    toggleLoanApplication(True)
                    clearClientProfileBox()

                    txtClientID.Text = dr.Item("client_id")
                    txtName.Text = dr.Item("name")
                    txtCompany.Text = dr.Item("company_name")
                    txtAvailableCredit.Text = 0
                    txtCreditLimit.Text = StrToNum(dr.Item("credit_limit"), 2, True)
                    txtPrincipal.Text = StrToNum(dr.Item("principal"), 2, True)
                    txtBranch.Text = dr.Item("branch_name")
                    'txtBiMonthlyAmort.Text = dr.Item("loan_id")
                    txtLoanRemarks.Text = dr.Item("loan_remarks")
                    dtStart.Value = StrToDate(dr.Item("date_start"))
                    cboApplicationStatus.SelectedIndex = dr.Item("application_status")
                    cboLoanStatus.SelectedIndex = dr.Item("loan_status")

                    isLOADING = False

                    txtTerms.Text = dr.Item("terms")

                End If
                txtAvailableCredit.Text = ComputeAvailableCredit(txtClientID.Text)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                db.Dispose()
                isLOADING = False
            End Try

        End Using
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        Dim isVERIFIED As Boolean = False

        Using db As New DBHelper(My.Settings.ConnectionString)
            Dim dr As SQLite.SQLiteDataReader
            'Dim cmd As SQLite.SQLiteCommand
            Dim data As New Dictionary(Of String, Object)
            Dim user As String = txtUser.Text
            Dim pass As String = txtPassword.Text
            'Dim Usertype As String = lblUtype.Text
            If txtUser.Text = "" And txtPassword.Text = "" Then
                MsgBox("Please provide username and password.", MsgBoxStyle.Exclamation, "Authentication Error")
                toggleVerifyActivation()
                Exit Sub

            End If

            Try
                dr = db.ExecuteReader("select * from tbl_users where user_name like '%" & txtUser.Text & "%' and user_password like '%" & Encrypt(txtPassword.Text, "Keys") & "%' ")
                If dr.HasRows Then
                    Do While dr.Read
                        Dim encryptPass = Encrypt(txtPassword.Text, "Keys")
                        Dim uname = (dr.Item("user_name").ToString)
                        Dim upass = (dr.Item("user_password").ToString)
                        'Dim utype = (CInt(dr.Item("user_type")))
                        'lblUtype.Text = utype
                        If uname = txtUser.Text And upass = encryptPass Then
                            isVERIFIED = True

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
                db.Dispose()
            End Try

        End Using

        If isVERIFIED Then
            Using db2 As New DBHelper(My.Settings.ConnectionString)
                Try
                    Dim rec As Integer
                    Dim data2 As New Dictionary(Of String, Object)

                    data2.Add("loan_id", lvLoanList.FocusedItem.Text)
                    rec = db2.ExecuteNonQuery("update tbl_loans set loan_status=1 where loan_id=@loan_id", data2)

                    MsgBox("Loan successfuly activated!", MsgBoxStyle.Information, "Activate Loan")
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                Finally
                    db2.Dispose()
                End Try

            End Using
        End If

        toggleVerifyActivation()
        LoadListView()
    End Sub

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


    Private Sub btnActivateLoan_Click(sender As Object, e As EventArgs) Handles btnActivateLoan.Click
        If lvLoanList.SelectedItems.Count = 0 Then
            MsgBox("Please select loan", MsgBoxStyle.Exclamation + vbOKOnly, "No selected loan")
            Exit Sub
        End If
        If lvLoanList.FocusedItem.SubItems(8).Text <> cboApplicationStatus.Items(1) Or lvLoanList.FocusedItem.SubItems(9).Text <> cboLoanStatus.Items(0) Then
            MsgBox("Unable to activated this loan. Please check Application status or Loan Status first.", MsgBoxStyle.Critical, "Unable to activate")
            Exit Sub
        End If
        txtUser.Text = ""
        txtPassword.Text = ""
        SetCueText(txtUser, "Username")
        SetCueText(txtPassword, "Password")
        toggleVerifyActivation(True)
    End Sub

    Private Sub btnCloseVerification_Click(sender As Object, e As EventArgs) Handles btnCloseVerification.Click
        toggleVerifyActivation()
    End Sub

    Private Sub lvLoanList_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvLoanList.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.lvLoanList.Sort()
    End Sub

    Private Sub lvLoanList_DrawColumnHeader(sender As Object, e As DrawListViewColumnHeaderEventArgs) Handles lvLoanList.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub lvLoanList_DrawSubItem(sender As Object, e As DrawListViewSubItemEventArgs) Handles lvLoanList.DrawSubItem
        Dim br As New SolidBrush(Color.Transparent) 'LinearGradientBrush(New Point(0, e.Bounds.Height / 2), New Point(e.Bounds.Width, e.Bounds.Height / 2), Color.FromArgb(255, 150, 150, 150), Color.Transparent)

        If e.Item.Selected Then
            br = New SolidBrush(Color.CornflowerBlue) 'LinearGradientBrush(New Point(0, e.Bounds.Height / 2), New Point(e.Bounds.Width, e.Bounds.Height / 2), Color.FromArgb(255, 150, 150, 150), Color.Transparent)


        End If

        If (e.ColumnIndex = 9 Or e.ColumnIndex = 8) Then
            If e.SubItem.Text = "Active" Or e.SubItem.Text = "Approved" Then
                br = New SolidBrush(Color.LightGreen)
            End If

            If e.SubItem.Text = "Declined" Or e.SubItem.Text = "Force Stop" Then
                br = New SolidBrush(Color.Tomato)
            End If

            If e.SubItem.Text = "Completed" Then
                br = New SolidBrush(Color.Blue)
            End If

            If e.SubItem.Text.ToLower = "in process" Then
                br = New SolidBrush(Color.Yellow)
            End If
        End If


        e.Graphics.FillRectangle(br, e.SubItem.Bounds)

        e.Graphics.DrawRectangle(Pens.Black, e.SubItem.Bounds)
        e.DrawText()
    End Sub

    Private Sub lvLoanList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvLoanList.SelectedIndexChanged
    End Sub

    Private Sub txtSearchLoan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearchLoan.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSearchLoan_Click(Me, e)
        End If
    End Sub

    Private Sub txtSearchLoan_TextChanged(sender As Object, e As EventArgs) Handles txtSearchLoan.TextChanged

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If lvLoanList.FocusedItem.SubItems(9).Text <> cboLoanStatus.Items(0) Then
            MsgBox("This loan is currently " & lvLoanList.FocusedItem.SubItems(9).Text & " and cannot be deleted.", MsgBoxStyle.Critical, "Unable to delete")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, "Delete loan") = MsgBoxResult.No Then Exit Sub

        Using db As New DBHelper(My.Settings.ConnectionString)


            Try
                Dim rec As Integer
                Dim data As New Dictionary(Of String, Object)
                data.Add("loan_id", lvLoanList.FocusedItem.Text)

                rec = db.ExecuteNonQuery("Delete from tbl_loans where loan_id=@loan_id", data)

                rec = db.ExecuteNonQuery("Delete from tbl_collectibles where loan_id=@loan_id", data)

                LoadListView()
                MsgBox("Record deleted!", MsgBoxStyle.Information, "Delete loan")
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                db.Dispose()
            End Try
        End Using
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim frm As New frmPrintReports
        frm.TabControl1.SelectedTab = frm.TabControl1.TabPages(1)
        frm.lblHeader.Text = "Loans Report"
        frm.lblHeader.ForeColor = Color.DarkViolet
        frm.ShowDialog()
    End Sub
End Class
