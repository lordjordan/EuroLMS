
Public Class LoansV2
    Dim active_loan_id As Long = 0

    Private Sub computeTotalLoan()
        If Val(txtTerms.Text) < 1 Or Val(cboInterest.Text) <= 0 Or Val(txtPrincipal.Text) < 1 Or _
            Not IsNumeric(txtPrincipal.Text) Or _
            Not IsNumeric(cboInterest.Text) Or _
            Not IsNumeric(txtTerms.Text) Then
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

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        toggleLoanApplication()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If gbxAddEdit.Text = "New Loan Application" Then
            If validateInputs() = False Then Exit Sub
            saveNewForm()
            saveCollectibles()
            MsgBox("Record saved!", MsgBoxStyle.Information)
            toggleLoanApplication()
            LoadListView()

        Else

        End If


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
        Dim rows As Byte = DataGridView1.RowCount - 1
        For i = 0 To rows - 1
            Using db2 As New DBHelper("Data Source=D:\LMSdb\LMS.s3db; Version=3;")
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
        Using db As New DBHelper("Data Source=D:\LMSdb\LMS.s3db; Version=3;")
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

        ''Using db3 As New DBHelper("Data Source=D:\LMSdb\LMS.s3db; Version=3;")
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

    Public Sub LoadListView()
        lvLoanList.Items.Clear()
        Using db As New DBHelper("Data Source=D:\LMSdb\LMS.s3db; Version=3;")
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
                                "terms, date_start, date_end, application_status, loan_status " & _
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
                        itmx.SubItems.Add(StrToNum(dr.Item("principal").ToString))
                        itmx.SubItems.Add(StrToNum(dr.Item("amortization").ToString))
                        itmx.SubItems.Add(dr.Item("interest_percentage").ToString)
                        itmx.SubItems.Add(dr.Item("terms").ToString)
                        itmx.SubItems.Add(StrToDate(dr.Item("date_start").ToString))
                        itmx.SubItems.Add(StrToDate(dr.Item("date_end").ToString))
                        itmx.SubItems.Add(dr.Item("application_status").ToString)
                        itmx.SubItems.Add(dr.Item("loan_status").ToString)



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

        Dim db As New DBHelper("Data Source=D:\LMSdb\LMS.s3db; Version=3;")
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
                    itmx.SubItems.Add(dr.Item("credit_limit").ToString)

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
            txtCreditLimit.Text = FormatNumber(lvClientList.SelectedItems.Item(0).SubItems(5).Text, 2)
            txtAvailableCredit.Text = ComputeAvailableCredit(txtClientID.Text)
            toggleClientSearch()

        Catch ex As Exception
            MsgBox("Please select a valid client first. You can filter or search client data through the 'search box' and then click the 'search button'", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ComputeAvailableCredit(ClientID As String) As String
        Return txtCreditLimit.Text
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
        LoadListView()
    End Sub

    Private Sub btnSearchLoan_Click(sender As Object, e As EventArgs) Handles btnSearchLoan.Click
        LoadListView()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        loadEditForm(lvLoanList.FocusedItem.Text)
    End Sub

    Private Sub loadEditForm(loan_id As Long)
        Using db As New DBHelper("Data Source=D:\LMSdb\LMS.s3db; Version=3;")

            'Dim rec As Integer
            Try
                Dim dr As SQLite.SQLiteDataReader
                Dim data As New Dictionary(Of String, Object)
                data.Add("loan_id", loan_id)

                dr = db.ExecuteReader("select loan_id, L.client_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, application_status, loan_status, " & _
                                "Co.company_name, B.branch_name " & _
                                "from tbl_loans L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id = @loan_id", data)

                If dr.HasRows Then
                    toggleLoanApplication(True)
                    clearClientProfileBox()
                    txtName.Text = dr.Item("loan_id")
                    txtName.Text = dr.Item("name")
                    txtCompany.Text = dr.Item("company_name")
                    txtPrincipal.Text = StrToNum(dr.Item("principal"), 2, False)
                    txtBranch.Text = dr.Item("branch_name")
                    'txtBiMonthlyAmort.Text = dr.Item("loan_id")
                    dtStart.Value = StrToDate(dr.Item("date_start"))
                    txtTerms.Text = dr.Item("terms")

                End If

            Catch ex As Exception

            Finally
                db.Dispose()
            End Try

        End Using
    End Sub
End Class
