Public Class PaymentHistory
    Dim itm As ListViewItem
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim rec As Integer
    Dim data As New Dictionary(Of String, Object)


    Public principal, monthlyRate, totalPaymentBiMonth, collectedAmount, rembal As Double
    Public biMonInterest As Decimal
    Public interest, penalty As Double
    Dim splitter() As String

    Dim excess, payableAmount, previousBalance, currPenaltyAmount, _
        storedValue As Double
    Dim ctr As Integer
    Dim conV As String
    Dim con As New SQLite.SQLiteConnection
    Dim ds As New DataSet
    Dim da As SQLite.SQLiteDataAdapter
    Dim query As String


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        uscPaymentHistory = New PaymentHistory
        For Each Control In pnlMain.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
            If TypeOf Control Is RadioButton Then
                Control.checked = False 'clear all checked radiobutton
            End If
        Next Control
        lvPH.Clear()
        showUSC(uscMainmenu)
        uscPaymentHistory = New PaymentHistory
    End Sub
    Private Sub showClient(mode As Boolean)
        gbxShowClient.Visible = mode
        gbxShowClient.Enabled = mode
        If mode Then
            gbxShowClient.BringToFront()
        Else
            gbxShowClient.SendToBack()
        End If

        pnlMain.Enabled = Not mode

    End Sub
    Private Sub PaymentHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbxShowClient.BringToFront()
    End Sub



    Private Sub btnClientBack_Click(sender As Object, e As EventArgs) Handles btnClientBack.Click
        showClient(False)
    End Sub


    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click
        Try
            lvClientList.Items.Clear()

            dr = db.ExecuteReader("SELECT employee_no ,tbl_clients.client_id as clientid, tblLoans.loan_id as loanid, " & _
                                  "last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                  "principal, company_name, branch_name FROM (SELECT * FROM tbl_loans WHERE loan_status <> 0 ) as tblLoans " & _
                                   " INNER JOIN tbl_clients ON tblLoans.client_id = tbl_clients.client_id " & _
                                  "INNER JOIN tbl_branches ON tbl_clients.branch_id = tbl_branches.branch_id INNER JOIN tbl_company ON tbl_branches.company_id= " & _
                                  "tbl_company.company_id " & _
                                  "WHERE tblLoans.loan_id LIKE  '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or first_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or last_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or middle_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or branch_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or company_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or tbl_clients.client_id LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or employee_no LIKE '%" & txtSearchLoan.Text.Trim & "%'")
            If dr.HasRows Then
                ctr = 1
                Do While dr.Read
                    itm = lvClientList.Items.Add(dr.Item("employee_no").ToString)
                    itm.SubItems.Add(dr.Item("clientid").ToString)
                    itm.SubItems.Add(dr.Item("loanid").ToString)
                    itm.SubItems.Add(dr.Item("name").ToString)
                    itm.SubItems.Add(CDbl(StrToNum(dr.Item("principal").ToString)))
                    If Not lvClientList.Items(ctr - 1).SubItems(4).Text.Contains(".") Then
                        lvClientList.Items(ctr - 1).SubItems(4).Text &= ".00"
                    End If

                    itm.SubItems.Add(dr.Item("company_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_name").ToString)
                  
                    ctr += 1
                Loop
            Else
                MsgBox("Record not found", MsgBoxStyle.Exclamation + vbOKOnly, "No data")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()

        End Try

    End Sub

    Private Sub pnlMain_Paint(sender As Object, e As PaintEventArgs) Handles pnlMain.Paint

    End Sub

    Private Sub btnViewLoan_Click(sender As Object, e As EventArgs)
        showClient(True)
        For Each Control In gbxShowClient.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control

    End Sub

    Private Sub btnSelectSearchClient_Click(sender As Object, e As EventArgs) Handles btnSelectSearchClient.Click
        Try
            Dim totalPayables As Double
            totalPayables = 0
            lvPH.Items.Clear()

            collectedAmount = 0
            penalty = 0
            If lvClientList.SelectedItems.Count > 0 Then
                'get all penalty amount
                dr = db.ExecuteReader("SELECT penalty_amt,penalty_status, payable_amt FROM tbl_collectibles WHERE loan_id = " & lvClientList.FocusedItem.SubItems(2).Text)

                If dr.HasRows Then

                    Do While dr.Read
                        If dr.Item("penalty_status").ToString = 1 Then
                            penalty += CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                        End If
                        txtTotalPenalties.Text = penalty
                        If Not txtTotalPenalties.Text.Contains(".") Then
                            txtTotalPenalties.Text &= ".00"
                        End If
                        totalPayables += CDbl(StrToNum(dr.Item("payable_amt").ToString))
                    Loop

                End If

                dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                      "date_stamp , amount,penalty_amt,payment_status FROM tbl_payments INNER JOIN tbl_collectibles ON tbl_payments.ctb_id =tbl_collectibles.ctb_id " & _
                                      "INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                      "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                      lvClientList.FocusedItem.SubItems(2).Text & " AND payment_status = 0 ORDER BY date_stamp ASC")
                ctr = 0
                Do While dr.Read

                    itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                    itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                    itm.SubItems.Add(FormatNumber(CDbl(StrToNum(dr.Item("amount").ToString))))
                    If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                        lvPH.Items(ctr).SubItems(2).Text &= ".00"
                    End If

                    If dr.Item("payment_status").ToString = 1 Then
                        itm.SubItems.Add("VOIDED")

                    Else
                        itm.SubItems.Add(" ")
                        collectedAmount += lvPH.Items(ctr).SubItems(2).Text
                    End If


                    ctr += 1
                Loop
                txtLoanid.Text = lvClientList.FocusedItem.SubItems(2).Text
                txtname.Text = lvClientList.FocusedItem.SubItems(3).Text

                dr = db.ExecuteReader("SELECT principal, terms, interest_percentage, date_end, date_start FROM tbl_loans WHERE loan_id =" & lvClientList.FocusedItem.SubItems(2).Text)


                principal = CDbl(StrToNum(dr.Item("principal").ToString))
                monthlyRate = principal / (CInt(dr.Item("terms").ToString) * 2)
                biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
                interest = principal * biMonInterest
                totalPaymentBiMonth = monthlyRate + interest
                rembal = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
                txtPrincipalAmt.Text = FormatNumber(principal, 2)
                txtTerms.Text = dr.Item("terms").ToString
                txtTotalLoanAmount.Text = FormatNumber(totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2), 2)
                txtDateStart.Text = StrToDate(dr.Item("date_start").ToString)
                txtDateEnd.Text = StrToDate(dr.Item("date_end").ToString)

                conV = collectedAmount
                If Not conV.Contains(".") Then
                    conV &= ".00"
                End If
                txtCollectedAmt.Text = FormatNumber(conV - penalty, 2)
                txtBalance.Text = FormatNumber((rembal - CDbl(txtCollectedAmt.Text)), 2)
                If Not txtBalance.Text.Contains(".") Then
                    txtBalance.Text &= ".00"
                End If
                If Not txtCollectedAmt.Text.Contains(".") Then
                    txtCollectedAmt.Text &= ".00"
                End If
                If Not txtPrincipalAmt.Text.Contains(".") Then
                    txtPrincipalAmt.Text &= ".00"
                End If
                If Not txtTotalLoanAmount.Text.Contains(".") Then
                    txtTotalLoanAmount.Text &= ".00"
                End If
                'terms left
            Else
                txtTotalPenalties.Clear()
                MsgBox("Please select a loan", MsgBoxStyle.Exclamation + vbOKOnly)

            End If
            conV = ""
            rembal = 0

            ctr = 0
            If lvPH.Items.Count = 0 Then
                btn_void.Enabled = False
            Else
                btn_void.Enabled = True
            End If

            showClient(False)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()

        End Try

    End Sub

    Private Sub lvClientList_DoubleClick(sender As Object, e As EventArgs) Handles lvClientList.DoubleClick
        btnSelectSearchClient_Click(sender, e)
    End Sub



    Private Sub btnViewLoan_Click_1(sender As Object, e As EventArgs) Handles btnViewLoan.Click
        showClient(True)
        lvClientList.Items.Clear()
        For Each Control In pnlMain.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
            If TypeOf Control Is RadioButton Then
                Control.checked = False 'clear all checked radiobutton
            End If
        Next Control
    End Sub

    Private Sub btn_void_Click(sender As Object, e As EventArgs) Handles btn_void.Click
        Try
            Cursor = Cursors.WaitCursor
            If radVoid.Checked = True Then
                MsgBox("Please choose normal or all only", vbExclamation + vbOKOnly, "Can't generate report")
                Exit Sub
            End If
            If lvPH.SelectedItems.Count <> 0 Then
                'voiding
                If lvPH.FocusedItem.SubItems(3).Text = "VOIDED" Then
                    MsgBox("This payment is already voided.", vbExclamation + vbOKOnly, "Invalid")
                Else
                    If MsgBox("Are you sure you want to void this payment?", vbInformation + vbYesNo, "Voiding...") = MsgBoxResult.Yes Then
                        rec = db.ExecuteNonQuery("UPDATE tbl_collectibles set collected_amt = '00000000' WHERE loan_id = " & txtLoanid.Text)
                        rec = db.ExecuteNonQuery("UPDATE tbl_payments set payment_status = 1 WHERE payment_id = " & lvPH.FocusedItem.Text)
                        'adjustment technique
                        Dim totalInPayment, payableAmt As Double
                        dr = db.ExecuteReader("SELECT SUM(amount) as TotalAmount FROM tbl_payments WHERE loan_id = " & txtLoanid.Text & " AND payment_status= 0")
                        If dr.HasRows Then
                            If dr.Item("TotalAmount").ToString <> "" Then
                                conV = dr.Item("TotalAmount").ToString


                                Do Until conV.Length = 8
                                    conV = conV.Insert(0, "0")
                                Loop
                                totalInPayment = CDbl(StrToNum(conV))
                            End If
                        End If
                        con.ConnectionString = My.Settings.ConnectionString
                        query = "SELECT ctb_id, loan_id, due_date, collected_amt, penalty_status, penalty_amt, payable_amt FROM tbl_collectibles WHERE loan_id=" & _
                            txtLoanid.Text & " ORDER by due_date ASC"
                        da = New SQLite.SQLiteDataAdapter(query, con)
                        da.Fill(ds, "collectibles")
                        For x = 1 To ds.Tables("collectibles").Rows.Count Step 1
                            'time to allocate the total payment
                            If ds.Tables("collectibles").Rows(x - 1).Item("penalty_status").ToString = 1 Then
                                payableAmt = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) + _
                                    CDbl(ds.Tables("collectibles").Rows(x - 1).Item("penalty_amt"))
                                If totalInPayment >= payableAmt Then
                                    totalInPayment = totalInPayment - payableAmt
                                    conV = FormatNumber(payableAmt, 2)
                                    conV = Replace(conV, ",", "")
                                    If Not conV.Contains(".") Then
                                        conV &= ".00"
                                    End If
                                    splitter = Split(conV, ".")

                                    If splitter(1).Length = 1 Then
                                        splitter(1) &= "0"
                                    End If
                                    Do Until splitter(0).Length = 6
                                        splitter(0) = splitter(0).Insert(0, "0")
                                    Loop
                                    data.Add("collected_amt", splitter(0) & splitter(1))
                                    data.Add("previous_balance", "00000000")
                                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt,previous_balance=@previous_balance " & _
                                                             "WHERE ctb_id=" & ds.Tables("collectibles").Rows(x - 1).Item("ctb_id").ToString, data)


                                Else
                                    conV = FormatNumber(totalInPayment, 2)
                                    conV = Replace(conV, ",", "")
                                    If Not conV.Contains(".") Then
                                        conV &= ".00"
                                    End If
                                    splitter = Split(conV, ".")

                                    If splitter(1).Length = 1 Then
                                        splitter(1) &= "0"
                                    End If
                                    Do Until splitter(0).Length = 6
                                        splitter(0) = splitter(0).Insert(0, "0")
                                    Loop
                                    data.Add("collected_amt", splitter(0) & splitter(1))
                                    data.Add("previous_balance", "00000000")
                                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt,previous_balance=@previous_balance " & _
                                                             "WHERE ctb_id=" & ds.Tables("collectibles").Rows(x - 1).Item("ctb_id").ToString, data)
                                    totalInPayment = 0
                                End If
                                data.Clear()
                            Else
                                payableAmt = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString))
                                If totalInPayment >= payableAmt Then
                                    totalInPayment = totalInPayment - payableAmt
                                    conV = FormatNumber(payableAmt, 2)
                                    conV = Replace(conV, ",", "")
                                    If Not conV.Contains(".") Then
                                        conV &= ".00"
                                    End If
                                    splitter = Split(conV, ".")

                                    If splitter(1).Length = 1 Then
                                        splitter(1) &= "0"
                                    End If
                                    Do Until splitter(0).Length = 6
                                        splitter(0) = splitter(0).Insert(0, "0")
                                    Loop
                                    data.Add("collected_amt", splitter(0) & splitter(1))
                                    data.Add("previous_balance", "00000000")
                                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt,previous_balance=@previous_balance " & _
                                                             "WHERE ctb_id=" & ds.Tables("collectibles").Rows(x - 1).Item("ctb_id").ToString, data)


                                Else
                                    conV = FormatNumber(totalInPayment, 2)
                                    conV = Replace(conV, ",", "")
                                    If Not conV.Contains(".") Then
                                        conV &= ".00"
                                    End If
                                    splitter = Split(conV, ".")

                                    If splitter(1).Length = 1 Then
                                        splitter(1) &= "0"
                                    End If
                                    Do Until splitter(0).Length = 6
                                        splitter(0) = splitter(0).Insert(0, "0")
                                    Loop
                                    data.Add("collected_amt", splitter(0) & splitter(1))
                                    data.Add("previous_balance", "00000000")
                                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt,previous_balance=@previous_balance " & _
                                                             "WHERE ctb_id=" & ds.Tables("collectibles").Rows(x - 1).Item("ctb_id").ToString, data)
                                    totalInPayment = 0
                                End If
                                data.Clear()
                            End If

                        Next
                        ds.Clear()

                        query = "SELECT collected_amt, payable_amt, ctb_id FROM tbl_collectibles WHERE loan_id = " & txtLoanid.Text
                        da = New SQLite.SQLiteDataAdapter(query, con)
                        da.Fill(ds, "collectibles")

                        If ds.Tables("collectibles").Rows.Count <> 0 Then
                            For z = 1 To ds.Tables("collectibles").Rows.Count Step 1
                                If CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("collected_amt").ToString)) = 0 Then
                                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET penalty_status = 0 WHERE ctb_id =" & _
                                                             ds.Tables("collectibles").Rows(z - 1).Item("ctb_id").ToString)
                                End If
                            Next

                        End If
                        ds.Clear()
                        previousBalance = 0
                        query = "SELECT ctb_id, previous_balance, payable_amt, penalty_status, penalty_amt, collected_amt FROM tbl_collectibles WHERE loan_id = " & _
                            txtLoanid.Text
                        da = New SQLite.SQLiteDataAdapter(query, con)
                        da.Fill(ds, "collectibles")
                        For x = 1 To ds.Tables("collectibles").Rows.Count Step 1
                            'update
                            conV = previousBalance
                            If Not conV.Contains(".") Then
                                conV &= ".00"
                            End If
                            splitter = Split(conV, ".")

                            If splitter(1).Length = 1 Then
                                splitter(1) &= "0"
                            End If
                            Do Until splitter(0).Length = 6
                                splitter(0) = splitter(0).Insert(0, "0")
                            Loop
                            ds.Tables("collectibles").Rows(x - 1).Item("previous_balance") = splitter(0) & splitter(1)
                            data.Add("previous_balance", splitter(0) & splitter(1))

                            rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET  previous_balance=@previous_balance " & _
                                                 " WHERE ctb_id=" & ds.Tables("collectibles").Rows(x - 1).Item(0), data)
                            data.Clear()

                            If ds.Tables("collectibles").Rows(x - 1).Item("penalty_status").ToString = 1 Then

                                If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) _
                                                      + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("previous_balance").ToString)) Then
                                    previousBalance += 0
                                Else
                                    previousBalance += (CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) + _
                                    CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("penalty_amt").ToString))) - CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString))
                                End If

                            Else
                                If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) Then
                                    previousBalance += 0
                                Else
                                    previousBalance += (CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString))) - CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString))
                                End If
                            End If
                        Next
                        rec = db.ExecuteNonQuery("UPDATE tbl_loans SET loan_status = 1 WHERE loan_id =" & _
                                                             txtLoanid.Text)
                        con.Close()

                        MsgBox("Payment was voided successfully", MsgBoxStyle.Information, "Voided")

                    End If
                End If

            Else
                MsgBox("Please select a payment to voided.", MsgBoxStyle.Exclamation + vbOKOnly, "No payment selected.")
            End If

            btnSelectSearchClient_Click(sender, e)
            Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
    End Sub

    
    Private Sub radAll_CheckedChanged(sender As Object, e As EventArgs) Handles radAll.CheckedChanged
        Try
            lvPH.Items.Clear()
            If radAll.Checked = True Then
                If txtLoanid.Text <> "" Then
                    dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                         "date_stamp , amount, payment_status FROM tbl_payments INNER JOIN tbl_collectibles ON tbl_payments.ctb_id =tbl_collectibles.ctb_id " & _
                                         "INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                         "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                         txtLoanid.Text)
                    ctr = 0
                    If dr.HasRows Then
                        Do While dr.Read
                            itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                            itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                            itm.SubItems.Add(CDbl(StrToNum(dr.Item("amount").ToString)))
                            If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                                lvPH.Items(ctr).SubItems(2).Text &= ".00"
                            End If


                            If dr.Item("payment_status").ToString = 1 Then
                                itm.SubItems.Add("VOIDED")

                            Else
                                itm.SubItems.Add(" ")
                                collectedAmount += lvPH.Items(ctr).SubItems(2).Text
                            End If

                            ctr += 1
                        Loop
                    Else
                        MsgBox("No data", vbExclamation)
                    End If
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
    End Sub

    Private Sub radNorm_CheckedChanged(sender As Object, e As EventArgs) Handles radNorm.CheckedChanged
        Try
            lvPH.Items.Clear()
            If radNorm.Checked = True Then
                If txtLoanid.Text <> "" Then
                    dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                         "date_stamp , amount, payment_status FROM tbl_payments INNER JOIN tbl_collectibles ON tbl_payments.ctb_id =tbl_collectibles.ctb_id " & _
                                         "INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                         "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                         txtLoanid.Text & " AND payment_status= 0 ")
                    ctr = 0
                    If dr.HasRows Then
                        Do While dr.Read

                            itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                            itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                            itm.SubItems.Add(CDbl(StrToNum(dr.Item("amount").ToString)))
                            If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                                lvPH.Items(ctr).SubItems(2).Text &= ".00"
                            End If
                            If dr.Item("payment_status").ToString = 1 Then
                                itm.SubItems.Add("VOIDED")

                            Else
                                itm.SubItems.Add("")
                                collectedAmount += lvPH.Items(ctr).SubItems(2).Text
                            End If

                            ctr += 1
                        Loop
                    Else
                        MsgBox("No data", vbExclamation)
                    End If
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
    End Sub

    Private Sub radVoid_CheckedChanged(sender As Object, e As EventArgs) Handles radVoid.CheckedChanged
        Try
            lvPH.Items.Clear()
            If radVoid.Checked = True Then
                If txtLoanid.Text <> "" Then
                    dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                         "date_stamp , amount, payment_status FROM tbl_payments INNER JOIN tbl_collectibles ON tbl_payments.ctb_id =tbl_collectibles.ctb_id " & _
                                         "INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                         "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                         txtLoanid.Text & " AND payment_status= 1")
                    ctr = 0
                    If dr.HasRows Then
                        Do While dr.Read

                            itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                            itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                            itm.SubItems.Add(CDbl(StrToNum(dr.Item("amount").ToString)))
                            If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                                lvPH.Items(ctr).SubItems(2).Text &= ".00"
                            End If

                            If dr.Item("payment_status").ToString = 1 Then
                                itm.SubItems.Add("VOIDED")

                            Else
                                itm.SubItems.Add("")
                                collectedAmount += lvPH.Items(ctr).SubItems(2).Text
                            End If

                            ctr += 1
                        Loop
                    Else
                        MsgBox("No data", vbExclamation)
                    End If
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
    End Sub

    Private Sub lvClientList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvClientList.SelectedIndexChanged

    End Sub
    Private Sub showSoa(mode As Boolean)
        gbxPrint.BringToFront()
        gbxPrint.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub
    Private Sub btnPrintShow_Click(sender As Object, e As EventArgs) Handles btnPrintShow.Click
        'codes
        Try
            Dim row1 As DataRow = Nothing
            Dim row2 As DataRow = Nothing
            Dim DS As New DataSet
            Dim rptSOA As New SOA
            'mag a-add na sa dataset (DS)
            DS.Tables.Add("SOA")
            'lagay tayo ng columns
            With DS.Tables(0).Columns
                .Add("loan_id")
                .Add("name")
                .Add("balance")
                .Add("collected_amt")
                .Add("total_penalties")
                .Add("principal_amt")
                .Add("gross_amt")
                .Add("terms")
                .Add("date_start")
                .Add("date_end")
                .Add("payment_id")
                .Add("date_process")
                .Add("amount")
                .Add("payment_stats")
            End With





            For x = 1 To lvPH.Items.Count Step 1
                row1 = DS.Tables(0).NewRow
                row1(0) = txtLoanid.Text
                row1(1) = txtname.Text
                row1(2) = txtBalance.Text
                row1(3) = txtCollectedAmt.Text
                row1(4) = txtTotalPenalties.Text
                row1(5) = txtPrincipalAmt.Text
                row1(6) = txtTotalLoanAmount.Text
                row1(7) = txtTerms.Text
                row1(8) = txtDateStart.Text
                row1(9) = txtDateEnd.Text
                row1(10) = lvPH.Items(x - 1).Text
                row1(11) = lvPH.Items(x - 1).SubItems(1).Text
                row1(12) = lvPH.Items(x - 1).SubItems(2).Text
                row1(13) = lvPH.Items(x - 1).SubItems(3).Text
                DS.Tables(0).Rows.Add(row1)
            Next


            DS.WriteXml("XML\SOA.xml")

            Dim dsSoa As New DataSet
            dsSoa = New DSreports
            Dim dsSoaTemp As New DataSet
            dsSoaTemp = New DataSet()
            showSoa(True)
            dsSoaTemp.ReadXml("XML\SOA.xml")
            dsSoa.Merge(dsSoaTemp.Tables(0))
            'dsSoa.Merge(dsSoaTemp.Tables(1))
            rptSOA = New SOA
            rptSOA.SetDataSource(dsSoa)
            crvSoa.ReportSource = rptSOA
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
      
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showSoa(False)
    End Sub
End Class
