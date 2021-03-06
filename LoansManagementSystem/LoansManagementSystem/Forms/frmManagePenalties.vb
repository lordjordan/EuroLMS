﻿Public Class frmManagePenalties
    Public principal, monthlyRate, totalPaymentBiMonth As Double
    Public biMonInterest As Decimal
    Public interest As Double
    Public bilangNGhulog, daysNgmonth As Integer
    Public dateStart, dateEnd, dueDate As DateTime

    'Dim dateFrom, getLastmonth As DateTime
    Dim penalty, previous_bal, penalty1 As Double
    Dim splitter(), concats, tagakuhaNgID, getMaxDate, bID(), cID() As String
    Dim itm As ListViewItem
    Private lvwColumnSorter, lvwColumnSorter1 As ListViewColumnSorter

    '### Change the "Data Source" path to point to our own LMS Database
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim rec As Integer
    Dim data As New Dictionary(Of String, Object)

    'adjustments
    Dim excess, payableAmount, collectedAmount, previousBalance, currPenaltyAmount, _
        storedValue, rembal As Double
    Dim ctr As Integer
    Dim conV As String
    Dim con As New SQLite.SQLiteConnection
    Dim ds, ds1 As New DataSet
    Dim da, da1 As SQLite.SQLiteDataAdapter
    Dim query, query1 As String
    Private Sub btnCancelPenalties_Click(sender As Object, e As EventArgs) Handles btnCancelPenalties.Click
        Me.Hide()
        uscCollectibles.gbxClientCollectible.Visible = True
    End Sub


    Private Sub showEditAmount(mode As Boolean)
        gbxEditAmount.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub

    Private Sub frmManagePenalties_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            lvDuedate.Items.Clear()
            lblLoanID.Text = uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text
            dr = db.ExecuteReader("SELECT ctb_id,due_date,penalty_amt , penalty_status FROM tbl_collectibles WHERE due_date < '" & _
                                  Format(Date.Now, "yyyyMMdd") & "' AND " & _
                                  "loan_id = " & uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text)


            If dr.HasRows Then

                Do While dr.Read
                    
                    itm = lvDuedate.Items.Add(StrToDate(dr.Item("due_date").ToString))
                    itm.SubItems.Add(CDbl(StrToNum(dr.Item("penalty_amt").ToString)))

                    Select Case dr.Item("penalty_status")
                        Case 0
                            itm.SubItems.Add("Unprocessed")
                        Case 1
                            itm.SubItems.Add("Penalized")
                        Case 2
                            itm.SubItems.Add("Removed")
                    End Select

                    itm.SubItems.Add(dr.Item("ctb_id").ToString)
                   
                Loop
                For x = 1 To lvDuedate.Items.Count Step 1
                    If Not lvDuedate.Items(x - 1).SubItems(1).Text.Contains(".") Then
                        lvDuedate.Items(x - 1).SubItems(1).Text &= ".00"
                    End If
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()

        End Try
    End Sub

    Private Sub btnRemovePenalties_Click(sender As Object, e As EventArgs) Handles btnRemovePenalties.Click
        If lvDuedate.SelectedItems.Count > 0 Then
            If lvDuedate.FocusedItem.SubItems(2).Text = "Removed" Then
                MsgBox("The status was already ""Removed""", vbInformation + vbOKOnly, "Cannot removed")
                Exit Sub
            End If
            Select Case MessageBox.Show("Are you sure you want to change the status to ""Removed"" ?" _
                                        , "Removing date penalty of " & lvDuedate.FocusedItem.Text _
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    lvDuedate.FocusedItem.SubItems(2).Text = "Removed"
            End Select
        Else
            MsgBox("Please select a Date", vbExclamation + vbOKOnly, "No date selected")
            Exit Sub
        End If
    End Sub

    Private Sub btnEditPenalties_Click(sender As Object, e As EventArgs) Handles btnEditPenalties.Click
        If lvDuedate.SelectedItems.Count > 0 Then
            showEditAmount(True)
        Else
            MsgBox("Please select a Record", vbExclamation + vbOKOnly, "No Record selected")
            Exit Sub
        End If
    End Sub

    Private Sub btnCancelColl_Click(sender As Object, e As EventArgs) Handles btnCancelColl.Click
        showEditAmount(False)
        txtAmount.Clear()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            lvDuedate.FocusedItem.SubItems(1).Text = Math.Round(CDbl(txtAmount.Text), 2)
        Catch ex As Exception
            MsgBox("Invalid input of amount", vbExclamation + vbOKOnly)
            Exit Sub
        End Try

        If Not lvDuedate.FocusedItem.SubItems(1).Text.Contains(".") Then
            lvDuedate.FocusedItem.SubItems(1).Text &= ".00"
        End If

        showEditAmount(False)
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnSaveExit_Click(sender As Object, e As EventArgs) Handles btnSaveExit.Click
        Try
            'version 2

            'tignan si payment? YES
            Cursor = Cursors.WaitCursor
            Dim totalInPayment, payableAmt As Double
            dr = db.ExecuteReader("SELECT SUM(amount) as TotalAmount FROM tbl_payments WHERE loan_id = " & uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text & " AND payment_status= 0")
            If dr.HasRows Then
                If dr.Item("TotalAmount").ToString <> "" Then
                    conV = dr.Item("TotalAmount").ToString

                    Do Until conV.Length = 8
                        conV = conV.Insert(0, "0")
                    Loop
                    totalInPayment = CDbl(StrToNum(conV))
                End If
            End If
            'managing penalties 
            For x = 1 To lvDuedate.Items.Count Step 1
                'converting to varchar mga amounts
                splitter = Split(lvDuedate.Items(x - 1).SubItems(1).Text, ".")
                If splitter(1).Length = 1 Then
                    splitter(1) &= "0"
                End If
                Do Until splitter(0).Length = 6
                    splitter(0) = splitter(0).Insert(0, "0")
                Loop
                'add data in dictionary
                data.Add("due_date", Format(CDate(lvDuedate.Items(x - 1).Text), "yyyyMMdd"))
                data.Add("penalty_amt", splitter(0) & splitter(1))
                Select Case lvDuedate.Items(x - 1).SubItems(2).Text
                    Case "Unprocessed"
                        data.Add("penalty_status", 0)
                    Case "Penalized"
                        data.Add("penalty_status", 1)
                    Case "Removed"
                        data.Add("penalty_status", 2)
                End Select
                'updating penalties
                rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET due_date=@due_date, penalty_amt=@penalty_amt," & _
                                         " penalty_status=@penalty_status  WHERE ctb_id=" & lvDuedate.Items(x - 1).SubItems(3).Text, data)
                data.Clear()
            Next
            con.ConnectionString = My.Settings.ConnectionString
            query = "SELECT ctb_id, loan_id, due_date, collected_amt, penalty_status, penalty_amt, payable_amt FROM tbl_collectibles WHERE loan_id=" & _
                uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text
            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "collectibles")
            For x = 1 To ds.Tables("collectibles").Rows.Count Step 1
                'time to allocate the total payment
                If ds.Tables("collectibles").Rows(x - 1).Item("penalty_status").ToString = 1 Then
                    payableAmt = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) + _
                        CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("penalty_amt").ToString))
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
                        data.Add("previoSus_balance", "00000000")
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
            'adjust na previous balance lang
            ds.Clear()
            previousBalance = 0
            query = "SELECT ctb_id, previous_balance, payable_amt, penalty_status, penalty_amt, collected_amt FROM tbl_collectibles WHERE loan_id = " & _
                uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text & " ORDER BY due_date ASC"
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
            con.Close()
            ds.Clear()
            penalty = 0
            uscCollectibles.lvDuedates.Items.Clear()
            dr = db.ExecuteReader("SELECT due_date, principal,ctb_id,penalty_amt FROM tbl_collectibles INNER JOIN tbl_loans ON tbl_collectibles.loan_id " & _
                                  "= tbl_loans.loan_id WHERE penalty_status= 0 AND due_date <'" & _
                                  Format(Date.Now, "yyyyMMdd") & "' AND tbl_collectibles.loan_id = " & uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text _
                                  & " ORDER BY due_date ASC")
            If dr.HasRows Then
                Do While dr.Read

                    dueDate = StrToDate(dr.Item("due_date").ToString)
                    itm = uscCollectibles.lvDuedates.Items.Add(dueDate) 'casted
                    itm.SubItems.Add(CDbl(StrToNum(dr.Item("penalty_amt").ToString)))
                    itm.SubItems.Add(dr.Item("ctb_id").ToString)
                  
                Loop
                splitter = Split(uscCollectibles.lvCollectibles.FocusedItem.SubItems(11).Text, ",") 'splitting ng ctb_id
                For y = 1 To splitter.Length Step 1
                    For x = 1 To uscCollectibles.lvDuedates.Items.Count Step 1
                        If splitter(y - 1) = uscCollectibles.lvDuedates.Items(x - 1).SubItems(2).Text Then
                            uscCollectibles.lvDuedates.Items(x - 1).Checked = True
                            penalty += CDbl(uscCollectibles.lvDuedates.Items(x - 1).SubItems(1).Text)
                        End If
                        If Not uscCollectibles.lvDuedates.Items(x - 1).SubItems(1).Text.Contains(".") Then
                            uscCollectibles.lvDuedates.Items(x - 1).SubItems(1).Text &= ".00"
                        End If
                    Next
                Next
            End If
            'payable amount
            dr = db.ExecuteReader("SELECT payable_amt , collected_amt , previous_balance from tbl_collectibles where due_date = " _
                                  & DateToStr(uscCollectibles.lvCollectibles.FocusedItem.SubItems(1).Text))


            'MsgBox(dr.Item("payable_amt").ToString & " _____ " & dr.Item("collected_amt").ToString & " _____ " & _
            '    dr.Item("previous_balance").ToString & " _____ " & penalty & "---" & DateToStr(uscCollectibles.lvCollectibles.FocusedItem.SubItems(1).Text))
            payableAmt = CDbl(StrToNum(dr.Item("payable_amt").ToString)) + CDbl(StrToNum(dr.Item("collected_amt").ToString)) + _
                CDbl(StrToNum(dr.Item("previous_balance").ToString)) + penalty

            uscCollectibles.lblPayableAmount.Text = payableAmt
            uscCollectibles.btnCancelColl.Enabled = False
            uscCollectibles.gbxClientCollectible.BringToFront()

            MsgBox("Records of penalties are updated!", MsgBoxStyle.Information, "Sucessfully updated!")
            Me.Close()
            Cursor = Cursors.Arrow
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
            con.Dispose() 'dalawa lang to
        End Try





    End Sub

    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        'restore mga deleted dues at magiging 0 ang status means unprocess
        If lvDuedate.SelectedItems.Count > 0 Then
            If lvDuedate.FocusedItem.SubItems(2).Text <> "Removed" Then
                MsgBox("Please select ""Removed"" status to restore.", vbInformation + vbOKOnly, "Please select")
                Exit Sub
            End If
            Select Case MessageBox.Show("Are you sure you want to change the status to ""Unprocess"" ?" _
                                        , "Removing date penalty of " & lvDuedate.FocusedItem.Text _
                                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    lvDuedate.FocusedItem.SubItems(2).Text = "Unprocessed"
            End Select
        Else
            MsgBox("Please select a Date", vbExclamation + vbOKOnly, "No date selected")
            Exit Sub
        End If
    End Sub

    Private Function checkPenalty(principal As Double, dueDate As Date)
        Dim amount As Integer

        If dueDate < Date.Now Then
            If principal <= 10000 Then
                amount = 300
            ElseIf principal >= 10000 And principal = 20000 Then
                amount = 400
            Else
                amount = 500
            End If
        Else
            amount = 0
        End If
        Return amount
    End Function
    Public Sub ShowData()
        Cursor = Cursors.WaitCursor
        Dim pangIlan As Integer
        Dim penaltyVal As Double
        uscCollectibles.lvCollectibles.Items.Clear()
        con.ConnectionString = My.Settings.ConnectionString
        'version 2
        Try




            query = "SELECT ctb_id,tblCol.loan_id as LoanID, MAX(due_date) as petsa, last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
                "payable_amt, previous_balance as previ , principal, date_start, date_end , interest_percentage,collected_amt as colsi ,terms, penalty_status,penalty_amt " & _
                "FROM  (SELECT ctb_id , loan_id, due_date, payable_amt, previous_balance,collected_amt,penalty_status,penalty_amt " & _
                "FROM tbl_collectibles  WHERE due_date <= '" & Format(Date.Now, "yyyyMMdd") & "') as tblCol " & _
                "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
                "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_status = 1 " & _
                "GROUP BY tblCol.loan_id"
            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "collectibles")

            For x = 1 To ds.Tables("collectibles").Rows.Count Step 1


                Select Case ds.Tables("collectibles").Rows(x - 1).Item("penalty_status").ToString

                    Case 2
                        If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("colsi").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) _
                            + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("previ").ToString)) Then
                            'find the date that is !=.
                            dr = db.ExecuteReader("SELECT ctb_id,tblCol.loan_id as LoanID, due_date as petsa , last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
                           "payable_amt, previous_balance, principal, date_start, date_end , interest_percentage,collected_amt,terms,penalty_status,penalty_amt " & _
                           "FROM  (SELECT ctb_id , loan_id , due_date , payable_amt, previous_balance,collected_amt,penalty_status,penalty_amt " & _
                           "FROM tbl_collectibles  WHERE due_date > '" & Format(Date.Now, "yyyyMMdd") & "' AND loan_id =" & ds.Tables("collectibles").Rows(x - 1).Item("loanID").ToString & ") as tblCol " & _
                           "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
                           "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_status = 1")
                            If dr.HasRows Then
                                Do While dr.Read

                                    If CDbl(StrToNum(dr.Item("collected_amt").ToString)) = CDbl(StrToNum(dr.Item("payable_amt").ToString)) _
                                             + CDbl(StrToNum(dr.Item("previous_balance").ToString)) Then
                                        Continue Do
                                    Else
                                        populateMe()
                                        Exit Do
                                    End If

                                Loop

                            End If

                        Else
                            populateCurrentMe(x)
                        End If
                    Case 1
                        If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("colsi").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) _
                             + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("previ").ToString)) + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("penalty_amt").ToString)) Then
                            'find the date that is !=.
                            dr = db.ExecuteReader("SELECT ctb_id,tblCol.loan_id as LoanID, due_date as petsa , last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
                           "payable_amt, previous_balance, principal, date_start, date_end , interest_percentage,collected_amt,terms,penalty_status,penalty_amt " & _
                           "FROM  (SELECT ctb_id , loan_id , due_date , payable_amt, previous_balance,collected_amt,penalty_status,penalty_amt " & _
                           "FROM tbl_collectibles  WHERE due_date > '" & Format(Date.Now, "yyyyMMdd") & "' AND loan_id =" & ds.Tables("collectibles").Rows(x - 1).Item("loanID").ToString & ") as tblCol " & _
                           "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
                           "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_status = 1")
                            If dr.HasRows Then
                                Do While dr.Read

                                    If CDbl(StrToNum(dr.Item("collected_amt").ToString)) = CDbl(StrToNum(dr.Item("payable_amt").ToString)) _
                                             + CDbl(StrToNum(dr.Item("previous_balance").ToString)) Then
                                        Continue Do
                                    Else
                                        populateMe()
                                        Exit Do
                                    End If

                                Loop

                            End If
                        Else
                            populateCurrentMe(x)
                        End If
                    Case 0

                        If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("colsi").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) _
                        + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("previ").ToString)) Then
                            'find the date that is !=.
                            dr = db.ExecuteReader("SELECT ctb_id,tblCol.loan_id as LoanID, due_date as petsa , last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
                       "payable_amt, previous_balance, principal, date_start, date_end , interest_percentage,collected_amt,terms,penalty_status,penalty_amt " & _
                       "FROM  (SELECT ctb_id , loan_id , due_date , payable_amt, previous_balance,collected_amt,penalty_status,penalty_amt " & _
                       "FROM tbl_collectibles  WHERE due_date > '" & Format(Date.Now, "yyyyMMdd") & "'AND loan_id =" & ds.Tables("collectibles").Rows(x - 1).Item("loanID").ToString & ") as tblCol " & _
                       "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
                       "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_status = 1")
                            If dr.HasRows Then
                                Do While dr.Read
                                    If CDbl(StrToNum(dr.Item("collected_amt").ToString)) = CDbl(StrToNum(dr.Item("payable_amt").ToString)) _
                                             + CDbl(StrToNum(dr.Item("previous_balance").ToString)) Then
                                        Continue Do
                                    Else
                                        populateMe()
                                        Exit Do
                                    End If

                                Loop

                            End If
                        Else
                            populateCurrentMe(x)
                        End If

                End Select

                pangIlan = 0
                penaltyVal = 0
                For y = 1 To uscCollectibles.lvCollectibles.Items.Count Step 1
                    dr = db.ExecuteReader("SELECT * FROM tbl_collectibles WHERE loan_id = " & uscCollectibles.lvCollectibles.Items(y - 1).SubItems(0).Text & _
                                          " ORDER BY due_date ASC")
                    If dr.HasRows Then

                        Do While dr.Read
                            dueDate = StrToDate(dr.Item("due_date").ToString)

                            If dueDate = uscCollectibles.lvCollectibles.Items(y - 1).SubItems(1).Text Then
                                If dr.Item("penalty_status").ToString = 0 Then
                                    concats &= dr.Item("ctb_id").ToString
                                End If
                                uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text = CDbl(StrToNum(dr.Item("previous_balance").ToString))
                                If dr.Item("penalty_status").ToString = 2 Then
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text = (CDbl(StrToNum(dr.Item("payable_amt").ToString)) + uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString))
                                Else
                                    If dueDate >= CDate(Format(Date.Now, "MM/dd/yyyyy")) Then
                                        uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal
                                        uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text = (CDbl(StrToNum(dr.Item("payable_amt").ToString)) + uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString))
                                    Else
                                        uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal + CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                                        uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text = (CDbl(StrToNum(dr.Item("payable_amt").ToString)) + uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text + CDbl(StrToNum(dr.Item("penalty_amt").ToString)) + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString))
                                    End If
                                End If
                                uscCollectibles.lvCollectibles.Items(y - 1).SubItems(11).Text = concats
                                If Not uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text.Contains(".") Then
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text &= ".00"
                                End If
                                If Not uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text.Contains(".") Then
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text &= ".00"
                                End If
                                If Not uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text.Contains(".") Then
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text &= ".00"
                                End If
                                Exit Do
                            Else
                                'if condition sa penalty status
                                If dr.Item("penalty_status").ToString = 0 Then
                                    penaltyVal += CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                                    concats &= dr.Item("ctb_id").ToString & ","
                                End If


                            End If
                            pangIlan += 1

                        Loop
                        pangIlan = 0
                        previous_bal = 0
                        penaltyVal = 0
                        concats = ""
                    End If
                Next

            Next
            ds.Clear()
            'pag pa umpisa pa lang  ang date nya (si "FRESH") eto ang gawin upang lumabassss ang katassss ng utang.
            query = "SELECT  last_name || ', ' || first_name || ' ' || middle_name as Name, tbl_loans.loan_id as loanID, max(collected_amt) as colsi , date_start as petsa, min( previous_balance) as previ, payable_amt, principal " & _
                " , terms, interest_percentage FROM tbl_collectibles" & _
                " INNER JOIN tbl_loans ON tbl_collectibles.loan_id = tbl_loans.loan_id INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id" & _
                " WHERE loan_status = 1 and date_start > '" & Format(Date.Now, "yyyyMMdd") & "'" & _
                " group by loanID"

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "collectibles")
            For x = 1 To ds.Tables("collectibles").Rows.Count Step 1

                If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("colsi").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) _
                            + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("previ").ToString)) Then
                    'find the date that is !=.
                    dr = db.ExecuteReader("SELECT ctb_id,tblCol.loan_id as LoanID, due_date as petsa , last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
                   "payable_amt, previous_balance, principal, date_start, date_end , interest_percentage,collected_amt,terms,penalty_status,penalty_amt " & _
                   "FROM  (SELECT ctb_id , loan_id , due_date , payable_amt, previous_balance,collected_amt,penalty_status,penalty_amt " & _
                   "FROM tbl_collectibles  WHERE due_date > '" & ds.Tables("collectibles").Rows(x - 1).Item("date_start").ToString & "' AND loan_id =" & ds.Tables("collectibles").Rows(x - 1).Item("loanID").ToString & ") as tblCol " & _
                   "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
                   "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_status = 1")
                    If dr.HasRows Then
                        Do While dr.Read
                            If CDbl(StrToNum(dr.Item("collected_amt").ToString)) = CDbl(StrToNum(dr.Item("payable_amt").ToString)) _
                                     + CDbl(StrToNum(dr.Item("previous_balance").ToString)) Then
                                Continue Do
                            Else
                                populateMe()
                                Exit Do
                            End If
                        Loop

                    End If

                Else
                    populateCurrentMe(x)
                End If
            Next

            pangIlan = 0
            penaltyVal = 0
            For y = 1 To uscCollectibles.lvCollectibles.Items.Count Step 1
                dr = db.ExecuteReader("SELECT * FROM tbl_collectibles WHERE loan_id = " & uscCollectibles.lvCollectibles.Items(y - 1).SubItems(0).Text & _
                                      " ORDER BY due_date ASC")
                If dr.HasRows Then
                    Do While dr.Read
                        dueDate = StrToDate(dr.Item("due_date").ToString)
                        If dueDate = uscCollectibles.lvCollectibles.Items(y - 1).SubItems(1).Text Then
                            If dr.Item("penalty_status").ToString = 0 Then
                                concats &= dr.Item("ctb_id").ToString
                            End If
                            uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text = CDbl(StrToNum(dr.Item("previous_balance").ToString))
                            If dr.Item("penalty_status").ToString = 2 Then
                                uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text = FormatNumber(penaltyVal, 2)
                                uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text = FormatNumber((CDbl(StrToNum(dr.Item("payable_amt").ToString)) + uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString)), 2)
                            Else
                                If dueDate >= CDate(Format(Date.Now, "MM/dd/yyyyy")) Then
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text = FormatNumber(penaltyVal, 2)
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text = FormatNumber((CDbl(StrToNum(dr.Item("payable_amt").ToString)) + uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString)), 2)
                                Else
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text = FormatNumber(penaltyVal + CDbl(StrToNum(dr.Item("penalty_amt").ToString)), 2)
                                    uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text = FormatNumber((CDbl(StrToNum(dr.Item("payable_amt").ToString)) + uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text + CDbl(StrToNum(dr.Item("penalty_amt").ToString)) + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString)), 2)
                                End If
                            End If
                            uscCollectibles.lvCollectibles.Items(y - 1).SubItems(11).Text = concats
                            If Not uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text.Contains(".") Then
                                uscCollectibles.lvCollectibles.Items(y - 1).SubItems(3).Text &= ".00"
                            End If
                            If Not uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text.Contains(".") Then
                                uscCollectibles.lvCollectibles.Items(y - 1).SubItems(6).Text &= ".00"
                            End If
                            If Not uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text.Contains(".") Then
                                uscCollectibles.lvCollectibles.Items(y - 1).SubItems(7).Text &= ".00"
                            End If
                            Exit Do
                        Else
                            'if condition sa penalty status
                            If dr.Item("penalty_status").ToString = 0 Then
                                penaltyVal += CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                                concats &= dr.Item("ctb_id").ToString & ","
                            End If

                        End If
                        pangIlan += 1
                    Loop
                    pangIlan = 0
                    previous_bal = 0
                    penaltyVal = 0
                    concats = ""
                End If
            Next
            ds.Clear()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
        Cursor = Cursors.Arrow
        ' END OF VERSION 2







    End Sub

    Private Sub populateMe()
        itm = uscCollectibles.lvCollectibles.Items.Add(dr.Item("loanID").ToString)

        itm.SubItems.Add(StrToDate(dr.Item("petsa").ToString)) 'casted
        itm.SubItems.Add(dr.Item("Name").ToString)
        itm.SubItems.Add(":)") 'try to check next process payable amount


        itm.SubItems.Add(FormatNumber(CDbl(StrToNum(dr.Item("collected_amt").ToString)), 2)) 'collected amount
        itm.SubItems.Add("") 'inputted amount
        itm.SubItems.Add("") 'checking status for penalty next process

        principal = CDbl(StrToNum(dr.Item("principal").ToString))
        monthlyRate = principal / (CDbl(dr.Item("terms").ToString) * 2)
        biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
        interest = principal * biMonInterest

        itm.SubItems.Add(FormatNumber(CDbl(StrToNum(dr.Item("previous_balance").ToString)), 2))  'previous balance next process

        itm.SubItems.Add(FormatNumber(Math.Round(monthlyRate, 2), 2)) 'may formula principal amount

        itm.SubItems.Add(interest)    'interest

        itm.SubItems.Add("")    'oustanding balance next process
        itm.SubItems.Add("")    'ctb_id's penalty
        itm.SubItems.Add(dr.Item("ctb_id").ToString)    'ctb_id specific

    End Sub
    Private Sub populateCurrentMe(num As Integer)
        itm = uscCollectibles.lvCollectibles.Items.Add(ds.Tables("collectibles").Rows(num - 1).Item("loanID").ToString)

        itm.SubItems.Add(StrToDate(ds.Tables("collectibles").Rows(num - 1).Item("petsa").ToString)) 'casted
        itm.SubItems.Add(ds.Tables("collectibles").Rows(num - 1).Item("Name").ToString)
        itm.SubItems.Add(":)") 'try to check next process payable amount


        itm.SubItems.Add(FormatNumber(CDbl(StrToNum(ds.Tables("collectibles").Rows(num - 1).Item("colsi").ToString)), 2)) 'collected amount
        itm.SubItems.Add("") 'inputted amount
        itm.SubItems.Add("") 'checking status for penalty next process

        principal = CDbl(StrToNum(ds.Tables("collectibles").Rows(num - 1).Item("principal").ToString))
        monthlyRate = principal / (CDbl(ds.Tables("collectibles").Rows(num - 1).Item("terms").ToString) * 2)
        biMonInterest = (CInt(ds.Tables("collectibles").Rows(num - 1).Item("interest_percentage").ToString) / 100) / 2
        interest = principal * biMonInterest

        itm.SubItems.Add(FormatNumber(CDbl(StrToNum(ds.Tables("collectibles").Rows(num - 1).Item("previ").ToString)), 2))   'previous balance next process
        itm.SubItems.Add(FormatNumber(Math.Round(monthlyRate, 2), 2)) 'may formula principal amount

        itm.SubItems.Add(interest)    'interest

        itm.SubItems.Add("")    'oustanding balance next process
        itm.SubItems.Add("")    'ctb_id's penalty
        itm.SubItems.Add(ds.Tables("collectibles").Rows(num - 1).Item("ctb_id").ToString)    'ctb_id specific

    End Sub
End Class