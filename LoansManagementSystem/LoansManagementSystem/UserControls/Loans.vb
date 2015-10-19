Public Class Loans
    Public principal, monthlyRate, totalPaymentBiMonth, amount, oBal As Double
    Public biMonInterest As Decimal
    Public interest As Double
    Public bilangNGhulog, daysNgmonth, interestRate As Integer
    Public dateStart, dateEnd As DateTime
    Dim itm As ListViewItem
    Dim db As New DBHelper("Data Source=" & My.Settings.ConString & "; Version=3;")
    Dim dr As SQLite.SQLiteDataReader

    Private Sub showAddEdit(mode As Boolean)
        gbxAddEdit.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub
    Private Sub showClient(mode As Boolean)
        gbxShowClient.BringToFront()
        gbxShowClient.Visible = mode
        gbxAddEdit.Enabled = Not mode
    End Sub

    Private Sub showLoanInfo(mode As Boolean)
        gbxLoanInfo.BringToFront()
        gbxLoanInfo.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        showUSC(uscMainmenu)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        showAddEdit(False)

        'clearing the forms
        lblClientID.Text = ""
        lblFullname.Text = ""
        lblEmployeeNo.Text = ""
        lblDateHired.Text = ""
        dtStart.Value = Date.Now
        dtEnd.Value = Date.Now
        txtPrincipal.Clear()
        cbxInterest.Text = ""
        lblAmort.Text = ""
        lblAmortWOInt.Text = ""
        lblGrossAm.Text = ""
        txtLoanRemarks.Text = ""

        frmClientRequirement.Close()
        frmComaker.Close()

    End Sub



    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        gbxAddEdit.Text = "Add new loan application"
        showAddEdit(True)

    End Sub
   
    Private Sub chkboxRestructure_CheckedChanged(sender As Object, e As EventArgs) Handles chkboxRestructure.CheckedChanged
        If chkboxRestructure.Checked = False Then
            chkboxRestructure.Text = "NO"
        Else
            chkboxRestructure.Text = "YES"
        End If
    End Sub
    Private Sub Loans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dapat meron dito matik na mag uupdate ang loan status ng active or finish or inc depende sa date start at date end.

        lvLoanList.Items.Clear()
        Try

            'default in process
            dr = db.ExecuteReader("SELECT loan_id, last_name || ' ' || first_name || ' ' || middle_name  as name, principal, amortization, interest_percentage, date_start, date_end" & _
                                  ", application_status, loan_status FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE application_status= 0")
            If dr.HasRows Then

                Do While dr.Read

                    itm = Me.lvLoanList.Items.Add(dr.Item("loan_id").ToString)
                    itm.SubItems.Add(dr.Item("name").ToString)
                    itm.SubItems.Add(dr.Item("principal").ToString)
                    itm.SubItems.Add(dr.Item("amortization").ToString)
                    itm.SubItems.Add(dr.Item("interest_percentage").ToString)
                    itm.SubItems.Add(Format(CDate(dr.Item("date_start").ToString), "MM/dd/yyyy"))
                    itm.SubItems.Add(Format(CDate(dr.Item("date_end").ToString), "MM/dd/yyyy"))
                    If dr.Item("application_status").ToString = 0 Then
                        itm.SubItems.Add("In process")
                        itm.SubItems.Add("N/A")
                    End If
                Loop

            Else
                MsgBox("No ""in process"" loans", vbInformation + vbOKOnly, "No loans")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'add client lang, update pa
        Dim totalPayment, creditLimit, totalPrin As Double

        Dim radioValue As Integer
        If radApproved.Checked = True Then
            radioValue = 1
        ElseIf radDeclined.Checked = True Then
            radioValue = 5
        ElseIf radReturn.Checked = True Then
            radioValue = 4
        Else
            radioValue = 0
        End If

        'Dim dateNow As DateTime
        'dateNow = (DateTime.Today.AddDays(+1)) + Now.TimeOfDay
        'MsgBox(dateNow)
        'Exit Sub
        'validations blank fields
        If lblClientID.Text = "" Or txtPrincipal.Text = "" Or cbxInterest.Text = "" _
            Or txtLoanRemarks.Text = "" Then
            MsgBox("Some fields are empty.", vbExclamation + vbOKOnly, "Please fill up.")
            Exit Sub
        End If
        'validations in date start and date end
        'If dtStart.Value >= dtEnd.Value Then
        '    MsgBox("Please check the date, Invalid set of date", vbExclamation + vbOKOnly, "Invalid")
        '    Exit Sub
        'End If
        'validations in values of principals nasa keypress event na

        'validations in requirements
        'Dim db As New DBHelper("Data Source= F:\eom's file\Programs Guide Style!\LoansManagementSystem\LoansManagementSystem\bin\Debug\LMS.s3db;Version=3;")
        'Dim dr As SQLite.SQLiteDataReader
        'Try


        '    dr = db.ExecuteReader("SELECT client_id FROM tbl_requirements WHERE client_id=" & lblClientID.Text)
        '    If dr.HasRows = False Then
        '        MsgBox("Please attach requirements", vbExclamation + vbOKOnly, "No requirements")
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try


        'warningan kung tama na ang principal value for double check lang :)
        'validation collect all payment of active loan tas ibangga sa credit limit nya
        'pwede i module
        ''Try
        dr = db.ExecuteReader("SELECT credit_limit FROM tbl_clients WHERE client_id = " & lblClientID.Text)
        If dr.HasRows Then
            creditLimit = CDbl(dr.Item("credit_limit").ToString)
        End If

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        dr = db.ExecuteReader("SELECT SUM(principal) as 'total' FROM tbl_loans WHERE client_id =" & lblClientID.Text _
                              & " AND loan_status = 1")

        If dr.HasRows Then
            If dr.Item("total").ToString <> "" Then
                totalPrin = CDbl(dr.Item("total").ToString) + CDbl(txtPrincipal.Text)
            Else
                totalPrin = 0
            End If
        End If


        dr = db.ExecuteReader("SELECT SUM(amount) as 'total' FROM tbl_payments INNER JOIN tbl_loans" & _
                              " ON tbl_payments.loan_id = tbl_loans.loan_id WHERE tbl_loans.client_id= " & _
                               lblClientID.Text & " AND tbl_loans.loan_status = 1")
        If dr.HasRows Then
            If dr.Item("total").ToString <> "" Then
                'base sa totalPayment

                totalPayment = CDbl(dr.Item("total").ToString)
                '
            Else
                totalPayment = 0
            End If
        End If
        If CDbl(txtPrincipal.Text) > creditLimit Then
            MsgBox("The amount of principal is greater than the Credit limit issued for this client.\n Available Pricipal: " & totalPayment, vbExclamation + vbOKOnly, "Principal not available.")
            Exit Sub
        ElseIf CDbl(txtPrincipal.Text) - totalPayment > creditLimit Then 'eto pa finalization
            MsgBox("The amount of principal is greater than the Available Principal for this client.\n Available Pricipal: " & totalPayment, vbExclamation + vbOKOnly, "Principal not available.")
            Exit Sub
        End If

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        'saving
        'pwede imodule


        Dim rec As Integer
        Dim data As New Dictionary(Of String, Object)
        'try
        data.Add("client_id", lblClientID.Text)
        data.Add("principal", txtPrincipal.Text)
        data.Add("amortization", lblAmort.Text)
        data.Add("date_start", Format(dtStart.Value, "MM/dd/yyyy"))
        data.Add("date_end", Format(dtEnd.Value, "MM/dd/yyyy"))
        data.Add("interest_percentage", cbxInterest.Text)
        data.Add("date_enrolled", Format(Now, "MM/dd/yyyy"))
        data.Add("loan_remarks", txtLoanRemarks.Text)

        'pwede mag if condition
        'rec = db.ExecuteNonQuery("INSERT INTO tbl_loans (client_id, principal, amortization, date_start, date_end, interest_percentage, date_enrolled, loan_remarks)" & _
        '                        " VALUES (@client_id, @principal, @amortization, @date_start, @date_end, @interest_percentage, @date_enrolled, @loan_remarks)", data)
        rec = db.ExecuteNonQuery("INSERT INTO tbl_loans VALUES(NULL,@client_id, @principal, @amortization, @date_start, @date_end, @interest_percentage,NULL,@date_enrolled,0,0, @loan_remarks)", data)
        If Not rec < 1 Then
            MsgBox("Record saved!", MsgBoxStyle.Information)
        End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
        MsgBox("Test LOL")
        Call Loans_Load(sender, e)
    End Sub
    Private Sub linkRequirements_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkRequirements.LinkClicked
        frmClientRequirement.ShowDialog()
    End Sub


    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        lvClientList.Items.Clear()
        showClient(True)
        'pwedeng i-module
    End Sub
    Private Sub btnClientBack_Click(sender As Object, e As EventArgs) Handles btnClientBack.Click
        showClient(False)
    End Sub
    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click
        'pwede imodule
        lvClientList.Items.Clear()
        Try

            dr = db.ExecuteReader("SELECT client_id, last_name, first_name, middle_name, branch_id, employee_no FROM tbl_clients" & _
                                  " WHERE first_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or last_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or middle_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or branch_id LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or employee_no LIKE '%" & txtSearchClient.Text.Trim & "%' ")
            If dr.HasRows Then

                Do While dr.Read
                    itm = Me.lvClientList.Items.Add(dr.Item("client_id").ToString)
                    itm.SubItems.Add(dr.Item("last_name").ToString & ", " & dr.Item("first_name").ToString & ", " & dr.Item("middle_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_id").ToString)
                    itm.SubItems.Add(dr.Item("employee_no").ToString)
                Loop

            Else
                MsgBox("No record found", vbInformation + vbOKOnly, "Record not found")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub lvClientList_DoubleClick(sender As Object, e As EventArgs) Handles lvClientList.DoubleClick
        'getting clients information

        'Label26.Text = ListView2.FocusedItem.Text

        dr = db.ExecuteReader("SELECT client_id, first_name || ' ' || last_name || ' ' || middle_name as name, employee_no" & _
                              ", date_hired  FROM tbl_clients WHERE client_id=" & lvClientList.FocusedItem.Text)
        If dr.HasRows Then
            'sa gbxaddeditloan
            lblClientID.Text = dr.Item("client_id").ToString
            lblFullname.Text = dr.Item("name").ToString
            lblEmployeeNo.Text = dr.Item("employee_no").ToString
            lblDateHired.Text = Format(CDate(dr.Item("date_hired").ToString), "MM/dd/yyyy")

        End If
        showClient(False)
    End Sub

    Private Sub txtPrincipal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrincipal.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cbxInterest_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbxInterest.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dtStart_TextChanged(sender As Object, e As EventArgs) Handles dtStart.TextChanged
        If dtStart.Value < Date.Now Then
            MsgBox("Invalid set of date " & vbCrLf & dtStart.Value & " is not valid.", MsgBoxStyle.Exclamation, "Set date is past.")

        End If
        If txtTerms.Text <> "" Then
            dateStart = dtStart.Value
            daysNgmonth = DateTime.DaysInMonth(dateStart.Year, dateStart.Month)
            'principal/bilangNghulog  = bayad w/out interest /Monthly rate
            'principal*interestRate = totalPaymentPerMonth
            'monthlyrate/2 =bi-Monthly Interest
            'principal = CDbl(txtPrincipal.Text)
            'monthlyRate = principal / bilangNGhulog
            'biMonInterest = (CInt(cbxInterest.Text) / 100) / 2
            'interest = principal * biMonInterest
            'totalPaymentBiMonth = monthlyRate + interest
            'lblAmort.Text = totalPaymentBiMonth
            bilangNGhulog = CInt(txtTerms.Text) * 2

            Do Until bilangNGhulog = 1

                Select Case daysNgmonth
                    Case 28
                        If dateStart.Day < 13 Then
                            dateStart = dateStart.AddDays(+15)
                        ElseIf dateStart.Day = 28 Then
                            dateStart = dateStart.AddDays(+15)
                            'Continue Do
                        Else
                            dateStart = dateStart.AddDays(+13)
                        End If
                    Case 29
                        If dateStart.Day < 13 Then
                            dateStart = dateStart.AddDays(+15)
                        ElseIf dateStart.Day = 29 Then
                            dateStart = dateStart.AddDays(+15)
                            'Continue Do
                        Else
                            dateStart = dateStart.AddDays(+14)
                        End If
                    Case 31
                        If dateStart.Day < 16 Then
                            dateStart = dateStart.AddDays(+15)
                        Else
                            dateStart = dateStart.AddDays(+16)
                        End If
                    Case Else
                        dateStart = dateStart.AddDays(+15)
                End Select
                daysNgmonth = DateTime.DaysInMonth(dateStart.Year, dateStart.Month)
                bilangNGhulog -= 1
            Loop
            dtEnd.Value = dateStart
        End If
    End Sub
    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs) Handles dtStart.ValueChanged
        
    End Sub
    Public Sub dtEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtEnd.ValueChanged
        If dtEnd.Value < dtStart.Value Then
            dtEnd.Value = dtStart.Value
        End If
        txtPrincipal.Clear()
        cbxInterest.Text = ""

    End Sub




    Private Sub cbxInterest_TextChanged(sender As Object, e As EventArgs) Handles cbxInterest.TextChanged

        dateStart = dtStart.Value
        dateEnd = dtEnd.Value
        If cbxInterest.Text = "" Or txtPrincipal.Text = "" Then
            lblAmort.Text = ""
        Else

            'calculate the range at bilang ng hulog
            'ilagay ang bilang ng months sa variable
            'loop ang pag add until ma reach ang date end
            daysNgmonth = DateTime.DaysInMonth(dateStart.Year, dateStart.Month)
            bilangNGhulog = 1

            Do Until dateStart >= dateEnd
                'if february?
                'kunin nextdate para mag fixed e.g 30-15 , 15-30 or 2-17, 17 - 2
                Select Case daysNgmonth

                    Case 28
                        If dateStart.Day < 13 Then
                            dateStart = dateStart.AddDays(+15)
                        ElseIf dateStart.Day = 28 Then
                            dateStart = dateStart.AddDays(+15)
                            'Continue Do
                        Else
                            dateStart = dateStart.AddDays(+13)
                        End If
                    Case 29
                        If dateStart.Day < 13 Then
                            dateStart = dateStart.AddDays(+15)
                        ElseIf dateStart.Day = 29 Then
                            dateStart = dateStart.AddDays(+15)
                            'Continue Do
                        Else
                            dateStart = dateStart.AddDays(+14)
                        End If
                    Case 31
                        If dateStart.Day < 16 Then
                            dateStart = dateStart.AddDays(+15)
                        Else
                            dateStart = dateStart.AddDays(+16)
                        End If
                    Case Else
                        dateStart = dateStart.AddDays(+15)
                End Select
                daysNgmonth = DateTime.DaysInMonth(dateStart.Year, dateStart.Month)
                bilangNGhulog += 1


            Loop
            'principal/bilangNghulog  = bayad w/out interest /Monthly rate
            'principal*interestRate = totalPaymentPerMonth
            'monthlyrate/2 =bi-Monthly Interest
            principal = CDbl(txtPrincipal.Text)
            monthlyRate = principal / bilangNGhulog
            biMonInterest = (CInt(cbxInterest.Text) / 100) / 2
            interest = principal * biMonInterest
            totalPaymentBiMonth = monthlyRate + interest
            lblAmort.Text = totalPaymentBiMonth
            lblAmortWOInt.Text = monthlyRate
            lblGrossAm.Text = totalPaymentBiMonth * bilangNGhulog
        End If
        bilangNGhulog = 0
    End Sub

    Private Sub txtPrincipal_TextChanged(sender As Object, e As EventArgs) Handles txtPrincipal.TextChanged
        cbxInterest.Text = ""

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        gbxAddEdit.Text = "Edit loan"
        showAddEdit(True)
    End Sub

    Private Sub btnUploadLoanApplcation_Click(sender As Object, e As EventArgs) Handles btnUploadLoanApplcation.Click
        Dim strPath As String
        'Dim row, col, i As Integer
        'i = 0
        With OpenFileDialog1
            .Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            .ShowDialog()
            strPath = .FileName
        End With

    End Sub

 

    Private Sub gbxShowCoMakers_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSearchLoan_Click(sender As Object, e As EventArgs) Handles btnSearchLoan.Click
        lvLoanList.Items.Clear()
        'Try
        dr = db.ExecuteReader("")
        'condition
        If LCase(txtSearchLoan.Text) Like "*in process*" Then
            dr = db.ExecuteReader("SELECT loan_id, last_name || ' ' || first_name || ' ' || middle_name  as name, principal, amortization, interest_percentage, date_start, date_end" & _
                                  ", application_status, loan_status FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE application_status= 0")
        ElseIf LCase(txtSearchLoan.Text) Like "*active*" Or LCase(txtSearchLoan.Text) Like "*approved*" Then
            dr = db.ExecuteReader("SELECT loan_id, last_name || ' ' || first_name || ' ' || middle_name  as name, principal, amortization, interest_percentage, date_start, date_end" & _
                                  ", application_status, loan_status FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE application_status= 1")
        ElseIf LCase(txtSearchLoan.Text) Like "*completed*" Then
            dr = db.ExecuteReader("SELECT loan_id, last_name || ' ' || first_name || ' ' || middle_name  as name, principal, amortization, interest_percentage, date_start, date_end" & _
                                  ", application_status, loan_status FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE loan_status= 2")
        ElseIf LCase(txtSearchLoan.Text) Like "*restructured*" Then
            dr = db.ExecuteReader("SELECT loan_id, last_name || ' ' || first_name || ' ' || middle_name  as name, principal, amortization, interest_percentage, date_start, date_end" & _
                                  ", application_status, loan_status FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE loan_status= 3")
        ElseIf LCase(txtSearchLoan.Text) Like "*returned*" Then
            dr = db.ExecuteReader("SELECT loan_id, last_name || ' ' || first_name || ' ' || middle_name  as name, principal, amortization, interest_percentage, date_start, date_end" & _
                                  ", application_status, loan_status FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE application_status= 4")
        ElseIf LCase(txtSearchLoan.Text) Like "*declined*" Then
            dr = db.ExecuteReader("SELECT loan_id, last_name || ' ' || first_name || ' ' || middle_name  as name, principal, amortization, interest_percentage, date_start, date_end" & _
                                  ", application_status, loan_status FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE application_status= 5")
        Else
            dr = db.ExecuteReader("SELECT loan_id, last_name || ' ' || first_name || ' ' || middle_name  as name, principal, amortization, interest_percentage, date_start, date_end" & _
                                  ", application_status, loan_status FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id" & _
                                  " WHERE loan_id LIKE  '%" & txtSearchLoan.Text.Trim & "%' " & _
                                  " or first_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                  " or last_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                  " or middle_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                  " or branch_id LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                  " or employee_no LIKE '%" & txtSearchLoan.Text.Trim & "%' ")
        End If

        If dr.HasRows Then

            Do While dr.Read

                itm = Me.lvLoanList.Items.Add(dr.Item("loan_id").ToString)
                itm.SubItems.Add(dr.Item("name").ToString)
                itm.SubItems.Add(dr.Item("principal").ToString)
                itm.SubItems.Add(dr.Item("amortization").ToString)
                itm.SubItems.Add(dr.Item("interest_percentage").ToString)
                itm.SubItems.Add(Format(CDate(dr.Item("date_start").ToString), "MM/dd/yyyy"))
                itm.SubItems.Add(Format(CDate(dr.Item("date_end").ToString), "MM/dd/yyyy"))
                If dr.Item("application_status").ToString = 0 Then 'in process
                    itm.SubItems.Add("In process")
                    itm.SubItems.Add("N/A")
                ElseIf dr.Item("application_status").ToString = 1 Then
                    itm.SubItems.Add("Approved")
                    itm.SubItems.Add("Active")
                ElseIf dr.Item("application_status").ToString = 4 Then
                    itm.SubItems.Add("Returned")
                    itm.SubItems.Add("N/A")
                ElseIf dr.Item("appiclation_status").ToString = 5 Then
                    itm.SubItems.Add("Declined")
                    itm.SubItems.Add("N/A")
                End If
                If dr.Item("loan_status").ToString = 2 Then 'in process
                    itm.SubItems(7).Text = "Approved"
                    itm.SubItems(8).Text = "Completed"
                ElseIf dr.Item("loan_status").ToString = 3 Then
                    itm.SubItems(7).Text = "Approved"
                    itm.SubItems(8).Text = "Restructured"
                End If
            Loop

        Else
            MsgBox("No record of loans", vbInformation + vbOKOnly, "No loans")
        End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical)
        'End Try
    End Sub

    Private Sub lvLoanList_DoubleClick(sender As Object, e As EventArgs) Handles lvLoanList.DoubleClick
        lblInfoLoanID.Text = lvLoanList.FocusedItem.Text
        dr = db.ExecuteReader("SELECT loan_id, first_name || ' ' || last_name || ' ' || middle_name as name, date_approved" & _
                              ", date_start, date_end, principal, interest_percentage FROM tbl_loans" & _
                              " INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id" & _
                              " WHERE loan_id=" & lvLoanList.FocusedItem.Text)
        If dr.HasRows Then
            'sa gbxLoanInfo
            'Format(CDate(dr.Item("birth_date").ToString), "MM/dd/yyyy")) displaying date for user
            If LCase(lvLoanList.FocusedItem.SubItems(8).Text) = "active" Or LCase(lvLoanList.FocusedItem.SubItems(8).Text) = "completed" _
                Or LCase(lvLoanList.FocusedItem.SubItems(8).Text) = "restructured" Then
                lblInfoLoanID.Text = dr.Item("loan_id").ToString
                lblInfoName.Text = dr.Item("name").ToString
                lblDtAppvdInfo.Text = Format(CDate(dr.Item("date_approved").ToString), "MM/dd/yyyy")
                lblDtStartInfo.Text = Format(CDate(dr.Item("date_start").ToString), "MM/dd/yyyy")
                lblDtEndInfo.Text = Format(CDate(dr.Item("date_end").ToString), "MM/dd/yyyy")
                lblLoanInfoPrin.Text = dr.Item("principal").ToString
                lblIntrInfo.Text = dr.Item("interest_percentage").ToString & " %"
                dateStart = CDate(dr.Item("date_start"))
                dateEnd = CDate(dr.Item("date_end"))
                interestRate = CInt(dr.Item("interest_percentage"))
            Else
                MsgBox("The loan is in process.", MsgBoxStyle.Information, "No payment history")
                Exit Sub
            End If
        End If
        'calculating terms, ramaining balance, and overall total
        daysNgmonth = DateTime.DaysInMonth(dateStart.Year, dateStart.Month)
        bilangNGhulog = 1

        Do Until dateStart >= dateEnd
            'if february?
            'kunin nextdate para mag fixed e.g 30-15 , 15-30 or 2-17, 17 - 2

            Select Case daysNgmonth

                Case 28
                    If dateStart.Day < 13 Then
                        dateStart = dateStart.AddDays(+15)
                    ElseIf dateStart.Day = 28 Then
                        dateStart = dateStart.AddDays(+15)
                        'Continue Do
                    Else
                        dateStart = dateStart.AddDays(+13)
                    End If
                Case 29
                    If dateStart.Day < 13 Then
                        dateStart = dateStart.AddDays(+15)
                    ElseIf dateStart.Day = 29 Then
                        dateStart = dateStart.AddDays(+15)
                        'Continue Do
                    Else
                        dateStart = dateStart.AddDays(+14)
                    End If
                Case 31
                    If dateStart.Day < 16 Then
                        dateStart = dateStart.AddDays(+15)
                    Else
                        dateStart = dateStart.AddDays(+16)
                    End If
                Case Else
                    dateStart = dateStart.AddDays(+15)
            End Select
            daysNgmonth = DateTime.DaysInMonth(dateStart.Year, dateStart.Month)
            bilangNGhulog += 1

        Loop
        lblTermsInfo.Text = bilangNGhulog
        principal = CDbl(lblLoanInfoPrin.Text)
        monthlyRate = principal / bilangNGhulog
        biMonInterest = (interestRate / 100) / 2
        interest = principal * biMonInterest
        totalPaymentBiMonth = monthlyRate + interest
        lblOverallTotInfo.Text = totalPaymentBiMonth * bilangNGhulog

        dr = db.ExecuteReader("SELECT * FROM tbl_payments WHERE loan_id= " & lblInfoLoanID.Text)
        amount = 0
        oBal = principal
        If dr.HasRows Then
            Do While dr.Read
                oBal = oBal - monthlyRate
                itm = lvPayments.Items.Add(dr.Item("payment_id").ToString)
                itm.SubItems.Add(Format(CDate(dr.Item("date_stamp").ToString), "MM/dd/yyyy"))
                itm.SubItems.Add(oBal)
                itm.SubItems.Add(monthlyRate)
                itm.SubItems.Add(dr.Item("amortization").ToString)
                itm.SubItems.Add(interest)
                itm.SubItems.Add(totalPaymentBiMonth)
                itm.SubItems.Add(dr.Item("amount").ToString)
                   
                    amount = CDbl(dr.Item("amount").ToString) + amount

            Loop

        Else
            MsgBox("No payment history", MsgBoxStyle.Information, "LMS")

        End If
        lblRembalInfo.Text = CDbl(lblOverallTotInfo.Text) - amount
        showLoanInfo(True)
    End Sub
    Private Sub btnLoanBack_Click(sender As Object, e As EventArgs) Handles btnLoanBack.Click
        showLoanInfo(False)
    End Sub

    Private Sub txtTerms_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTerms.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub



    Private Sub txtTerms_TextChanged(sender As Object, e As EventArgs) Handles txtTerms.TextChanged
        If txtTerms.Text = "0" Then
            txtTerms.Text = ""
        ElseIf txtTerms.Text = "" Then
            dtEnd.Value = Date.Now
        End If
        If txtTerms.Text <> "" Then
            dateStart = dtStart.Value
            daysNgmonth = DateTime.DaysInMonth(dateStart.Year, dateStart.Month)
            'principal/bilangNghulog  = bayad w/out interest /Monthly rate
            'principal*interestRate = totalPaymentPerMonth
            'monthlyrate/2 =bi-Monthly Interest
            'principal = CDbl(txtPrincipal.Text)
            'monthlyRate = principal / bilangNGhulog
            'biMonInterest = (CInt(cbxInterest.Text) / 100) / 2
            'interest = principal * biMonInterest
            'totalPaymentBiMonth = monthlyRate + interest
            'lblAmort.Text = totalPaymentBiMonth
            bilangNGhulog = CInt(txtTerms.Text) * 2

            Do Until bilangNGhulog = 1

                Select Case daysNgmonth
                    Case 28
                        If dateStart.Day < 13 Then
                            dateStart = dateStart.AddDays(+15)
                        ElseIf dateStart.Day = 28 Then
                            dateStart = dateStart.AddDays(+15)
                            'Continue Do
                        Else
                            dateStart = dateStart.AddDays(+13)
                        End If
                    Case 29
                        If dateStart.Day < 13 Then
                            dateStart = dateStart.AddDays(+15)
                        ElseIf dateStart.Day = 29 Then
                            dateStart = dateStart.AddDays(+15)
                            'Continue Do
                        Else
                            dateStart = dateStart.AddDays(+14)
                        End If
                    Case 31
                        If dateStart.Day < 16 Then
                            dateStart = dateStart.AddDays(+15)
                        Else
                            dateStart = dateStart.AddDays(+16)
                        End If
                    Case Else
                        dateStart = dateStart.AddDays(+15)
                End Select
                daysNgmonth = DateTime.DaysInMonth(dateStart.Year, dateStart.Month)
                bilangNGhulog -= 1
            Loop
            dtEnd.Value = dateStart
        End If
    End Sub

 
    Private Sub linkCoMakers_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkCoMakers.LinkClicked
        frmComaker.ShowDialog()
    End Sub

    Private Sub cbxInterest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxInterest.SelectedIndexChanged

    End Sub
End Class