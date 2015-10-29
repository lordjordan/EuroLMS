Public Class PaymentHistory
    Dim itm As ListViewItem
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim rec As Integer
    Dim data As New Dictionary(Of String, Object)
    Dim colorChanger As Boolean

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
            colorChanger = False
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
                    itm.SubItems.Add(CDbl(dr.Item("principal").ToString.Insert(6, ".")))
                    If Not lvClientList.Items(ctr - 1).SubItems(4).Text.Contains(".") Then
                        lvClientList.Items(ctr - 1).SubItems(4).Text &= ".00"
                    End If

                    itm.SubItems.Add(dr.Item("company_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_name").ToString)
                    If colorChanger = True Then
                        itm.BackColor = Color.LemonChiffon
                        colorChanger = False
                    Else
                        itm.BackColor = Color.LightCyan
                        colorChanger = True
                    End If
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
            lvPH.Items.Clear()
            colorChanger = False
            collectedAmount = 0
            penalty = 0
            If lvClientList.SelectedItems.Count > 0 Then
                'get all penalty amount
                dr = db.ExecuteReader("SELECT penalty_amt,penalty_status FROM tbl_collectibles WHERE loan_id = " & lvClientList.FocusedItem.SubItems(2).Text)

                If dr.HasRows Then

                    Do While dr.Read
                        If dr.Item("penalty_status").ToString = 1 Then
                            penalty += CDbl(dr.Item("penalty_amt").ToString.Insert(6, "."))
                        End If
                        txtTotalPenalties.Text = penalty
                        If Not txtTotalPenalties.Text.Contains(".") Then
                            txtTotalPenalties.Text &= ".00"
                        End If
                    Loop

                End If

                dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                      "date_stamp , amount,penalty_amt, penalty_status, payment_status FROM tbl_payments INNER JOIN tbl_collectibles ON tbl_payments.ctb_id =tbl_collectibles.ctb_id " & _
                                      "INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                      "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                      lvClientList.FocusedItem.SubItems(2).Text)
                ctr = 0
                Do While dr.Read

                    itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                    itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                    itm.SubItems.Add(CDbl(dr.Item("amount").ToString.Insert(6, ".")))
                    If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                        lvPH.Items(ctr).SubItems(2).Text &= ".00"
                    End If

                    If dr.Item("penalty_status").ToString = 1 Then
                        itm.SubItems.Add("YES")

                    Else
                        itm.SubItems.Add("NO")

                    End If
                    If dr.Item("payment_status").ToString = 1 Then
                        itm.SubItems.Add("YES")

                    Else
                        itm.SubItems.Add("NO")
                        collectedAmount += lvPH.Items(ctr).SubItems(2).Text
                    End If

                    If colorChanger = True Then
                        itm.BackColor = Color.LemonChiffon
                        colorChanger = False
                    Else
                        itm.BackColor = Color.LightCyan
                        colorChanger = True
                    End If
                    ctr += 1
                Loop
                txtLoanid.Text = lvClientList.FocusedItem.SubItems(2).Text
                txtname.Text = lvClientList.FocusedItem.SubItems(3).Text

                dr = db.ExecuteReader("SELECT principal, terms, interest_percentage, date_end, date_start FROM tbl_loans WHERE loan_id =" & lvClientList.FocusedItem.SubItems(2).Text)


                principal = CDbl(dr.Item("principal").Insert(6, ".").ToString)
                monthlyRate = principal / (CInt(dr.Item("terms").ToString) * 2)
                biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
                interest = principal * biMonInterest
                totalPaymentBiMonth = monthlyRate + interest
                rembal = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
                txtPrincipalAmt.Text = principal
                txtTerms.Text = dr.Item("terms").ToString
                txtTotalLoanAmount.Text = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
                txtDateStart.Text = StrToDate(dr.Item("date_start").ToString)
                txtDateEnd.Text = StrToDate(dr.Item("date_end").ToString)

                conV = collectedAmount
                If Not conV.Contains(".") Then
                    conV &= ".00"
                End If
                txtCollectedAmt.Text = conV - penalty
                txtBalance.Text = (rembal - CDbl(txtCollectedAmt.Text)) + penalty
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

        If lvPH.SelectedItems.Count <> 0 Then
            'voiding
            If lvPH.FocusedItem.SubItems(4).Text = "YES" Then
                MsgBox("This payment is already voided.", vbExclamation + vbOKOnly, "Invalid")
            Else
                If MsgBox("Are you sure you want to void this payment?", vbInformation + vbYesNo, "Voiding...") = MsgBoxResult.Yes Then
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
                            totalInPayment = CDbl(conV.Insert(6, "."))
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
                            payableAmt = CDbl(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString().Insert(6, ".")) + _
                                CDbl(ds.Tables("collectibles").Rows(x - 1).Item("penalty_amt"))
                            If totalInPayment >= payableAmt Then
                                totalInPayment = totalInPayment - payableAmt
                                conV = payableAmt
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
                                conV = totalInPayment
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
                            payableAmt = CDbl(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString().Insert(6, "."))
                            If totalInPayment >= payableAmt Then
                                totalInPayment = totalInPayment - payableAmt
                                conV = payableAmt
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
                                conV = totalInPayment
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

                            End If
                            data.Clear()
                        End If

                    Next
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

                            If CDbl(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString.Insert(6, ".")) = CDbl(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString.Insert(6, ".")) _
                                                  + CDbl(ds.Tables("collectibles").Rows(x - 1).Item("previous_balance").ToString.Insert(6, ".")) Then
                                previousBalance += 0
                            Else
                                previousBalance += (CDbl(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString.Insert(6, ".")) + _
                                CDbl(ds.Tables("collectibles").Rows(x - 1).Item("penalty_amt").ToString.Insert(6, "."))) - CDbl(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString.Insert(6, "."))
                            End If

                        Else
                            If CDbl(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString.Insert(6, ".")) = CDbl(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString.Insert(6, ".")) Then
                                previousBalance += 0
                            Else
                                previousBalance += (CDbl(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString.Insert(6, "."))) - CDbl(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString.Insert(6, "."))
                            End If
                        End If
                    Next

                    ds.Clear()
                    query = "SELECT collected_amt, payable_amt, ctb_id FROM tbl_collectibles WHERE due_date >=  '" & Format(Date.Now, "yyyyMMdd") & "' AND loan_id = " & txtLoanid.Text
                    da = New SQLite.SQLiteDataAdapter(query, con)
                    da.Fill(ds, "collectibles")

                    If ds.Tables("collectibles").Rows.Count <> 0 Then
                        For z = 1 To ds.Tables("collectibles").Rows.Count Step 1
                            If CDbl(ds.Tables("collectibles").Rows(z - 1).Item("collected_amt").ToString.Insert(6, ".")) <> _
                               CDbl(ds.Tables("collectibles").Rows(z - 1).Item("payable_amt").ToString.Insert(6, ".")) Then
                                rec = db.ExecuteNonQuery("UPDATE tbl_loans SET penalty_status = 0 WHERE ctb_id =" & _
                                                         ds.Tables("collectibles").Rows(z - 1).Item("ctb_id").ToString)
                            End If
                        Next
                    End If
                    ds.Clear()
                    con.Close()
                    MsgBox("Payment was voided successfully", MsgBoxStyle.Information, "Voided")

                End If
            End If
        Else
            MsgBox("Please select a payment to voided.", MsgBoxStyle.Exclamation + vbOKOnly, "No payment selected.")
        End If
            
        btnSelectSearchClient_Click(sender, e)
    End Sub

    
    Private Sub radAll_CheckedChanged(sender As Object, e As EventArgs) Handles radAll.CheckedChanged
        lvPH.Items.Clear()
        If radAll.Checked = True Then
            If txtLoanid.Text <> "" Then
                dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                     "date_stamp , amount,penalty_amt, penalty_status, payment_status FROM tbl_payments INNER JOIN tbl_collectibles ON tbl_payments.ctb_id =tbl_collectibles.ctb_id " & _
                                     "INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                     "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                     txtLoanid.Text)
                ctr = 0
                If dr.HasRows Then
                    Do While dr.Read
                        itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                        itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                        itm.SubItems.Add(CDbl(dr.Item("amount").ToString.Insert(6, ".")))
                        If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                            lvPH.Items(ctr).SubItems(2).Text &= ".00"
                        End If

                        If dr.Item("penalty_status").ToString = 1 Then
                            itm.SubItems.Add("YES")
                            itm.SubItems.Add(CDbl(dr.Item("penalty_amt").ToString.Insert(6, ".")))
                        Else
                            itm.SubItems.Add("NO")
                            itm.SubItems.Add("0.00")
                        End If
                        If dr.Item("payment_status").ToString = 1 Then
                            itm.SubItems.Add("YES")

                        Else
                            itm.SubItems.Add("NO")
                            collectedAmount += lvPH.Items(ctr).SubItems(2).Text
                        End If

                        If colorChanger = True Then
                            itm.BackColor = Color.LemonChiffon
                            colorChanger = False
                        Else
                            itm.BackColor = Color.LightCyan
                            colorChanger = True
                        End If
                        ctr += 1
                    Loop
                Else
                    MsgBox("No data", vbExclamation)
                End If
            End If
            

        End If
    End Sub

    Private Sub radNorm_CheckedChanged(sender As Object, e As EventArgs) Handles radNorm.CheckedChanged
        lvPH.Items.Clear()
        If radNorm.Checked = True Then
            If txtLoanid.Text <> "" Then
                dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                     "date_stamp , amount,penalty_amt, penalty_status, payment_status FROM tbl_payments INNER JOIN tbl_collectibles ON tbl_payments.ctb_id =tbl_collectibles.ctb_id " & _
                                     "INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                     "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                     txtLoanid.Text & " AND payment_status= 0 ")
                ctr = 0
                If dr.HasRows Then
                    Do While dr.Read

                        itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                        itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                        itm.SubItems.Add(CDbl(dr.Item("amount").ToString.Insert(6, ".")))
                        If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                            lvPH.Items(ctr).SubItems(2).Text &= ".00"
                        End If

                        If dr.Item("penalty_status").ToString = 1 Then
                            itm.SubItems.Add("YES")
                            itm.SubItems.Add(CDbl(dr.Item("penalty_amt").ToString.Insert(6, ".")))
                        Else
                            itm.SubItems.Add("NO")
                            itm.SubItems.Add("0.00")
                        End If
                        If dr.Item("payment_status").ToString = 1 Then
                            itm.SubItems.Add("YES")

                        Else
                            itm.SubItems.Add("NO")
                            collectedAmount += lvPH.Items(ctr).SubItems(2).Text
                        End If

                        If colorChanger = True Then
                            itm.BackColor = Color.LemonChiffon
                            colorChanger = False
                        Else
                            itm.BackColor = Color.LightCyan
                            colorChanger = True
                        End If
                        ctr += 1
                    Loop
                Else
                    MsgBox("No data", vbExclamation)
                End If
            End If
            

        End If
    End Sub

    Private Sub radVoid_CheckedChanged(sender As Object, e As EventArgs) Handles radVoid.CheckedChanged
        lvPH.Items.Clear()
        If radVoid.Checked = True Then
            If txtLoanid.Text <> "" Then
                dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                     "date_stamp , amount,penalty_amt, penalty_status, payment_status FROM tbl_payments INNER JOIN tbl_collectibles ON tbl_payments.ctb_id =tbl_collectibles.ctb_id " & _
                                     "INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                     "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                     txtLoanid.Text & " AND payment_status= 1")
                ctr = 0
                If dr.HasRows Then
                    Do While dr.Read

                        itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                        itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                        itm.SubItems.Add(CDbl(dr.Item("amount").ToString.Insert(6, ".")))
                        If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                            lvPH.Items(ctr).SubItems(2).Text &= ".00"
                        End If

                        If dr.Item("penalty_status").ToString = 1 Then
                            itm.SubItems.Add("YES")
                            itm.SubItems.Add(CDbl(dr.Item("penalty_amt").ToString.Insert(6, ".")))
                        Else
                            itm.SubItems.Add("NO")
                            itm.SubItems.Add("0.00")
                        End If
                        If dr.Item("payment_status").ToString = 1 Then
                            itm.SubItems.Add("YES")

                        Else
                            itm.SubItems.Add("NO")
                            collectedAmount += lvPH.Items(ctr).SubItems(2).Text
                        End If

                        If colorChanger = True Then
                            itm.BackColor = Color.LemonChiffon
                            colorChanger = False
                        Else
                            itm.BackColor = Color.LightCyan
                            colorChanger = True
                        End If
                        ctr += 1
                    Loop
                Else
                    MsgBox("No data", vbExclamation)
                End If
            End If
            

        End If
    End Sub
End Class
