Public Class frmCollectibles
    Public principal, monthlyRate, totalPaymentBiMonth As Double
    Public biMonInterest As Decimal
    Public interest As Double
    Public bilangNGhulog, daysNgmonth As Integer
    Public dateStart, dateEnd, dueDate As DateTime

    'Dim dateFrom, getLastmonth As DateTime
    Dim penalty, previous_bal As Double
    Dim a, b, c, splitter(), concats, tagakuhaNgID, getMaxDate As String
    Dim itm As ListViewItem
    Dim colorChanger As Boolean
    '### Change the "Data Source" path to point to our own LMS Database
    Dim db As New DBHelper("Data Source=" & My.Settings.ConString & "; Version=3;")
    Dim dr As SQLite.SQLiteDataReader
    Dim rec As Integer
    Dim data As New Dictionary(Of String, Object)

    'adjustments
    Dim excess, payableAmount, collectedAmount, previousBalance, currPenaltyAmount, _
        storedValue, rembal As Double
    Dim ctr As Integer
    Dim conV As String
    Dim con As New SQLite.SQLiteConnection
    Dim ds As New DataSet
    Dim da As SQLite.SQLiteDataAdapter
    Dim query As String

    Private Sub showAdvanceSearch(mode As Boolean)
        gbxAdvanceSearch.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub

    Private Sub showCollectibles(mode As Boolean)
        gbxClientCollectible.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub

    Private Sub showPaymentHistory(mode As Boolean)
        gbxPH.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        showUSC(uscMainmenu)

    End Sub


    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        showAdvanceSearch(False)
        'gbxAdvanceSearch.Visible = False
    End Sub

    Public Sub ShowData()
        colorChanger = False
        lvCollectibles.Items.Clear()

        Try
            dr = db.ExecuteReader("SELECT ctb_id,tblCol.loan_id as LoanID, MAX(due_date) as petsa, last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
        "payable_amt, previous_balance, principal, date_start, date_end , interest_percentage,collected_amt,terms " & _
        "FROM  (SELECT ctb_id , loan_id , due_date , payable_amt, previous_balance,collected_amt " & _
        "FROM tbl_collectibles  WHERE due_date <= '" & Format(Date.Now, "yyyyMMdd") & "') as tblCol " & _
        "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
        "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_status = 1 " & _
        "GROUP BY tblCol.loan_id")

            If dr.HasRows Then

                Do While dr.Read
                    itm = lvCollectibles.Items.Add(dr.Item("loanID").ToString)

                    itm.SubItems.Add(StrToDate(dr.Item("petsa").ToString)) 'casted
                    itm.SubItems.Add(dr.Item("Name").ToString)
                    itm.SubItems.Add(":)") 'try to check next process payable amount


                    itm.SubItems.Add(dr.Item("collected_amt").ToString.Insert(6, ".")) 'collected amount
                    itm.SubItems.Add("") 'inputted amount
                    itm.SubItems.Add(checkPenalty(CDbl(dr.Item("principal").ToString.Insert(6, ".")), dueDate)) 'checking status for penalty next process

                    principal = CDbl(dr.Item("principal").ToString.Insert(6, "."))
                    monthlyRate = principal / (CDbl(dr.Item("terms").ToString) * 2)
                    biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
                    interest = principal * biMonInterest

                    itm.SubItems.Add(dr.Item("previous_balance").ToString.Insert(6, "."))    'previous balance next process
                    itm.SubItems.Add(Math.Round(monthlyRate, 2)) 'may formula principal amount

                    itm.SubItems.Add(interest)    'interest

                    itm.SubItems.Add("")    'oustanding balance next process
                    itm.SubItems.Add("")    'ctb_id's penalty
                    itm.SubItems.Add(dr.Item("ctb_id").ToString)    'ctb_id specific
                    If colorChanger = True Then
                        itm.BackColor = Color.LemonChiffon
                        colorChanger = False
                    Else
                        itm.BackColor = Color.LightCyan
                        colorChanger = True
                    End If

                Loop

            End If
            'convert all value to currency
            For x = 1 To lvCollectibles.Items.Count Step 1
                lvCollectibles.Items(x - 1).SubItems(4).Text = CDbl(lvCollectibles.Items(x - 1).SubItems(4).Text)
                lvCollectibles.Items(x - 1).SubItems(6).Text = CDbl(lvCollectibles.Items(x - 1).SubItems(6).Text)
                lvCollectibles.Items(x - 1).SubItems(7).Text = CDbl(lvCollectibles.Items(x - 1).SubItems(7).Text)
                lvCollectibles.Items(x - 1).SubItems(9).Text = CDbl(lvCollectibles.Items(x - 1).SubItems(9).Text)
                If Not lvCollectibles.Items(x - 1).SubItems(4).Text.Contains(".") Then
                    lvCollectibles.Items(x - 1).SubItems(4).Text &= ".00"
                End If
                If Not lvCollectibles.Items(x - 1).SubItems(6).Text.Contains(".") Then
                    lvCollectibles.Items(x - 1).SubItems(6).Text &= ".00"
                End If
                If Not lvCollectibles.Items(x - 1).SubItems(7).Text.Contains(".") Then
                    lvCollectibles.Items(x - 1).SubItems(7).Text &= ".00"
                End If
                If Not lvCollectibles.Items(x - 1).SubItems(8).Text.Contains(".") Then
                    lvCollectibles.Items(x - 1).SubItems(8).Text &= ".00"
                End If
                If Not lvCollectibles.Items(x - 1).SubItems(9).Text.Contains(".") Then
                    lvCollectibles.Items(x - 1).SubItems(9).Text &= ".00"
                End If

            Next
            'payable amount , penalty , previous balance kung meronn
            Dim pangIlan As Integer
            Dim penaltyVal As Double


            pangIlan = 0

            penaltyVal = 0

            For x = 1 To lvCollectibles.Items.Count Step 1
                dr = db.ExecuteReader("SELECT * FROM tbl_collectibles WHERE loan_id = " & lvCollectibles.Items(x - 1).SubItems(0).Text & _
                                      " ORDER BY due_date ASC")
                If dr.HasRows Then

                    Do While dr.Read

                        a = dr.Item("due_date").ToString().Substring(0, 4)
                        b = dr.Item("due_date").ToString().Substring(4, 2)
                        c = dr.Item("due_date").ToString().Substring(6, 2)
                        dueDate = CDate(b & "/" & c & "/" & a)

                        If dueDate = lvCollectibles.Items(x - 1).SubItems(1).Text Then
                            If dr.Item("penalty_status").ToString = 0 Then
                                concats &= dr.Item("ctb_id").ToString
                            End If
                            lvCollectibles.Items(x - 1).SubItems(7).Text = CDbl(dr.Item("previous_balance").ToString.Insert(6, "."))
                            If dr.Item("penalty_status").ToString = 1 Or dr.Item("penalty_status").ToString = 2 Then

                                lvCollectibles.Items(x - 1).SubItems(6).Text = penaltyVal
                                lvCollectibles.Items(x - 1).SubItems(3).Text = CDbl(dr.Item("payable_amt").ToString.Insert(6, ".")) + lvCollectibles.Items(x - 1).SubItems(7).Text
                            Else
                                If dueDate >= CDate(Format(Date.Now, "MM/dd/yyyyy")) Then
                                    lvCollectibles.Items(x - 1).SubItems(6).Text = penaltyVal
                                    lvCollectibles.Items(x - 1).SubItems(3).Text = CDbl(dr.Item("payable_amt").ToString.Insert(6, ".")) + lvCollectibles.Items(x - 1).SubItems(7).Text
                                Else
                                    lvCollectibles.Items(x - 1).SubItems(6).Text = penaltyVal + CDbl(dr.Item("penalty_amt").ToString.Insert(6, "."))
                                    lvCollectibles.Items(x - 1).SubItems(3).Text = CDbl(dr.Item("payable_amt").ToString.Insert(6, ".")) + lvCollectibles.Items(x - 1).SubItems(7).Text + CDbl(dr.Item("penalty_amt").ToString.Insert(6, "."))
                                End If

                            End If
                            lvCollectibles.Items(x - 1).SubItems(11).Text = concats
                            If Not lvCollectibles.Items(x - 1).SubItems(3).Text.Contains(".") Then
                                lvCollectibles.Items(x - 1).SubItems(3).Text &= ".00"
                            End If
                            If Not lvCollectibles.Items(x - 1).SubItems(6).Text.Contains(".") Then
                                lvCollectibles.Items(x - 1).SubItems(6).Text &= ".00"
                            End If
                            If Not lvCollectibles.Items(x - 1).SubItems(7).Text.Contains(".") Then
                                lvCollectibles.Items(x - 1).SubItems(7).Text &= ".00"
                            End If
                            Exit Do

                        Else


                            'if condition sa penalty status
                            If dr.Item("penalty_status").ToString = 0 Then
                                penaltyVal += CDbl(dr.Item("penalty_amt").ToString.Insert(6, "."))
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
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
        


    End Sub

    Private Sub frmCollectibles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        showCollectibles(False)
        ShowData()
    End Sub


    Private Sub btnCancelColl_Click(sender As Object, e As EventArgs) Handles btnCancelColl.Click
        showCollectibles(False)
    End Sub

    Private Sub btnManage_Click(sender As Object, e As EventArgs) Handles btnManage.Click
        frmManagePenalties.ShowDialog()
        
        'frmManagePenalties.ListView2.SubItems.Add(uscCollectibles.ListView1.SelectedItems(0).SubItems(1).Text)
        'frmManagePenalties.ListView2.SubItems.Add(uscCollectibles.ListView1.SelectedItems(0).SubItems(5).Text)

    End Sub


    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub lvCollectibles_DoubleClick(sender As Object, e As EventArgs) Handles lvCollectibles.DoubleClick
        Try
            colorChanger = False
            gbxClientCollectible.Text = "Client payment     (Loan I.D: " & lvCollectibles.FocusedItem.Text & ")"
            lvDuedates.Items.Clear()
            txtAmount.Focus()
            If lvCollectibles.SelectedItems.Count > 0 Then 'make sure there is a selected item to modify


                txtAmount.Text = ""
                txtAmount.Focus()
                itm = Me.lvCollectibles.SelectedItems(0)
                lblPayableAmount.Text = lvCollectibles.FocusedItem.SubItems(3).Text

                dr = db.ExecuteReader("SELECT due_date, principal,ctb_id,penalty_amt FROM tbl_collectibles INNER JOIN tbl_loans ON tbl_collectibles.loan_id " & _
                                      "= tbl_loans.loan_id WHERE penalty_status= 0 AND due_date <'" & _
                                      Format(Date.Now, "yyyyMMdd") & "' AND tbl_collectibles.loan_id = " & lvCollectibles.FocusedItem.SubItems(0).Text _
                                      & " ORDER BY due_date ASC")
                If dr.HasRows Then

                    Do While dr.Read
                        a = dr.Item("due_date").ToString().Substring(0, 4)
                        b = dr.Item("due_date").ToString().Substring(4, 2)
                        c = dr.Item("due_date").ToString().Substring(6, 2)
                        dueDate = CDate(b & "/" & c & "/" & a)
                        itm = lvDuedates.Items.Add(dueDate) 'casted
                        itm.SubItems.Add(dr.Item("penalty_amt").ToString.Insert(6, "."))
                        itm.SubItems.Add(dr.Item("ctb_id").ToString)
                        If colorChanger = True Then
                            itm.BackColor = Color.LemonChiffon
                            colorChanger = False
                        Else
                            itm.BackColor = Color.LightCyan
                            colorChanger = True
                        End If
                    Loop
                    For x = 1 To lvDuedates.Items.Count
                        lvDuedates.Items(x - 1).SubItems(1).Text = CDbl(lvDuedates.Items(x - 1).SubItems(1).Text)
                        If Not lvDuedates.Items(x - 1).SubItems(1).Text.Contains(".") Then
                            lvDuedates.Items(x - 1).SubItems(1).Text &= ".00"
                        End If
                    Next
                    splitter = Split(lvCollectibles.FocusedItem.SubItems(11).Text, ",") 'splitting ng ctb_id

                    For y = 1 To splitter.Length Step 1

                        For x = 1 To lvDuedates.Items.Count Step 1

                            If splitter(y - 1) = lvDuedates.Items(x - 1).SubItems(2).Text Then
                                lvDuedates.Items(x - 1).Checked = True

                            End If
                            If Not lvDuedates.Items(x - 1).SubItems(1).Text.Contains(".") Then
                                lvDuedates.Items(x - 1).SubItems(1).Text &= ".00"
                            End If
                        Next
                    Next



                End If



                showCollectibles(True)
            Else
                MessageBox.Show("Please select Client Collectibles.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
            gbxClientCollectible.BringToFront()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
        
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        'getting checked id at mababago ang amount ng penalty
        Try
            dr = db.ExecuteReader("SELECT MAX(due_date) as petsa FROM tbl_collectibles WHERE  loan_id= " & _
                                 lvCollectibles.FocusedItem.Text)

            If dr.HasRows Then
                If dr.Item("petsa").ToString = Format(CDate(lvCollectibles.FocusedItem.SubItems(1).Text), "yyyyMMdd") Then
                    getMaxDate = dr.Item("petsa").ToString()

                Else
                    getMaxDate = ""
                End If
            End If
            'itm.Text = Me.txtAmount.Text
            If txtAmount.Text <> "" Then
                If getMaxDate <> "" Then
                    If CDbl(txtAmount.Text) > lvCollectibles.FocusedItem.SubItems(3).Text Then
                        MsgBox("This is the last payment for this loan please input an exact amount.", MsgBoxStyle.Exclamation + vbOKOnly, "Input amount is greater than payable amount.")
                        txtAmount.Focus()
                        Exit Sub
                    End If
                Else
                    lvCollectibles.FocusedItem.SubItems(5).Text = CDbl(txtAmount.Text)
                End If

                If Not lvCollectibles.FocusedItem.SubItems(5).Text.Contains(".") Then
                    lvCollectibles.FocusedItem.SubItems(5).Text &= ".00"
                End If

                itm = Nothing

            Else
                MsgBox("No amount input in the field", vbExclamation + vbOKOnly)

            End If
            For x = 1 To lvDuedates.Items.Count Step 1

                If lvDuedates.Items(x - 1).Checked Then
                    tagakuhaNgID &= lvDuedates.Items(x - 1).SubItems(2).Text & ","
                    penalty += CDbl(lvDuedates.Items(x - 1).SubItems(1).Text)
                End If


            Next
            If tagakuhaNgID <> Nothing Then
                If tagakuhaNgID(tagakuhaNgID.Length - 1) = "," Then
                    tagakuhaNgID = tagakuhaNgID.Remove(tagakuhaNgID.Length - 1)
                End If
            Else
                tagakuhaNgID = ""
            End If
            'adjustments listview lang.
            Dim val, val2 As Double
            val = 0
            val2 = 0
            dr = db.ExecuteReader("SELECT previous_balance,payable_amt,due_date FROM tbl_collectibles WHERE due_date = '" & _
                                 Format(CDate(uscCollectibles.lvCollectibles.FocusedItem.SubItems(1).Text), "yyyyMMdd") & "' AND " & _
                                 "loan_id = " & uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text)

            If dr.HasRows Then
                For x = 1 To lvDuedates.Items.Count Step 1
                    If lvDuedates.Items(x - 1).Checked = False Then
                        If dr.Item("due_date").ToString <> Format(CDate(lvDuedates.Items(x - 1).Text), "yyyyMMdd") Then
                            val += CDbl(lvDuedates.Items(x - 1).SubItems(1).Text)
                        End If
                    Else
                        If dr.Item("due_date").ToString = Format(CDate(lvDuedates.Items(x - 1).Text), "yyyyMMdd") Then
                            val2 += CDbl(lvDuedates.Items(x - 1).SubItems(1).Text)
                        End If

                    End If

                Next
                'validations
                lvCollectibles.FocusedItem.SubItems(7).Text = dr.Item("previous_balance").ToString.Insert(6, ".") - val
                lvCollectibles.FocusedItem.SubItems(3).Text = dr.Item("payable_amt").ToString.Insert(6, ".") + CDbl(lvCollectibles.FocusedItem.SubItems(7).Text) + val2
            End If
            lvCollectibles.FocusedItem.SubItems(11).Text = tagakuhaNgID
            lvCollectibles.FocusedItem.SubItems(6).Text = penalty
            If Not lvCollectibles.FocusedItem.SubItems(6).Text.Contains(".") Then
                lvCollectibles.FocusedItem.SubItems(6).Text &= ".00"
            End If
            If Not lvCollectibles.FocusedItem.SubItems(7).Text.Contains(".") Then
                lvCollectibles.FocusedItem.SubItems(7).Text &= ".00"
            End If
            If Not lvCollectibles.FocusedItem.SubItems(3).Text.Contains(".") Then
                lvCollectibles.FocusedItem.SubItems(3).Text &= ".00"
            End If
            penalty = 0
            tagakuhaNgID = ""
            showCollectibles(False)
            btnCancelColl.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
        
    End Sub
    Private Sub EditItemInListView()

        If lvCollectibles.SelectedItems.Count > 0 Then 'make sure there is a selected item to modify
            'frmManagePenalties.ListView2.subitems.add()
            'txtUid.Text = ListView1.SelectedItems(0).SubItems(0).Text
            'txtusername.Text = ListView1.SelectedItems(0).SubItems(1).Text
            'txtPassword.Text = ListView1.SelectedItems(0).SubItems(2).Text
            'cmbUtype.Text = ListView1.SelectedItems(0).SubItems(3).Text
        Else
            MessageBox.Show("Please select record to edit.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)

    End Sub
    Private Function checkPenalty(principal As Double, dueDate As Date)
        Dim amount As Integer
        If dueDate < CDate(Format(Date.Now, "MM/dd/yyyyy")) Then
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

 


 

    Private Sub Process_Click(sender As Object, e As EventArgs) Handles Process.Click
        Try
            Dim colAmount, hasExcess, overallAmount As Double
            Dim colID As Integer
            colAmount = 0
            'process mode

            For x = 1 To lvCollectibles.Items.Count Step 1 'every items in listview
                'pagsamahin ang collected amount at inputted amount
                If lvCollectibles.Items(x - 1).SubItems(5).Text = "" Then
                    Continue For
                End If
                'for tbl_payments :D
                'code here
                dr = db.ExecuteReader("SELECT amount, date_stamp, loan_id FROM tbl_payments WHERE loan_id=" & _
                                      lvCollectibles.Items(x - 1).Text & " AND ctb_id=" & lvCollectibles.Items(x - 1).SubItems(12).Text)
                If dr.HasRows Then
                    hasExcess = dr.Item("amount").ToString.Insert(6, ".") 'inputted amount
                    colAmount = CDbl(lvCollectibles.Items(x - 1).SubItems(4).Text) - hasExcess
                    If colAmount < 0 Then 'conditiones pa
                        'condition ito kung colamount ay nega i plus ito sa collected amount
                        dr = db.ExecuteReader("SELECT  min(ctb_id) as low, collected_amt FROM tbl_collectibles WHERE due_date > '" & _
                                     Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & "' AND loan_id= " & _
                                     lvCollectibles.Items(x - 1).Text)
                        If dr.HasRows Then
                            lvCollectibles.Items(x - 1).SubItems(4).Text = CDbl(dr.Item("collected_amt").ToString.Insert(6, ".")) + colAmount

                        End If
                    Else
                        dr = db.ExecuteReader("SELECT  min(ctb_id) as low, collected_amt FROM tbl_collectibles WHERE due_date > '" & _
                                     Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & "' AND loan_id= " & _
                                     lvCollectibles.Items(x - 1).Text)
                        If dr.HasRows Then
                            lvCollectibles.Items(x - 1).SubItems(4).Text = CDbl(dr.Item("collected_amt").ToString.Insert(6, ".")) + colAmount
                        End If

                    End If
                    If Not lvCollectibles.Items(x - 1).SubItems(4).Text.Contains(".") Then
                        lvCollectibles.Items(x - 1).SubItems(4).Text &= ".00"
                    End If
                End If
                'inputted amount + collected amount
                overallAmount = CDbl(lvCollectibles.Items(x - 1).SubItems(4).Text) + CDbl(lvCollectibles.Items(x - 1).SubItems(5).Text)
                If lvCollectibles.Items(x - 1).SubItems(11).Text <> "" Then
                    splitter = Split(lvCollectibles.Items(x - 1).SubItems(11).Text, ",")
                    For y = 1 To splitter.Length Step 1
                        'update penalty status by ctb_id adjustment
                        rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET penalty_status = 1 WHERE ctb_id =" & splitter(y - 1))
                    Next
                End If

                'need update ng collected amount
                conV = overallAmount
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
                rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt WHERE due_date='" _
                                         & Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & _
                                         "' AND loan_id= " & lvCollectibles.Items(x - 1).SubItems(0).Text, data)
                data.Clear()
                'data set ulit para sa adjustment note: tbl_collectibles ay nag babago bago ng data.....
                con.ConnectionString = "Data Source=" & My.Settings.ConString & "; Version=3;"
                query = "SELECT ctb_id, due_date, penalty_status, payable_amt , collected_amt, previous_balance, penalty_amt FROM tbl_collectibles WHERE due_date <= '" & _
                                      Format(CDate(lvCollectibles.FocusedItem.SubItems(1).Text), "yyyyMMdd") & "' AND " & _
                                      "loan_id = " & lvCollectibles.Items(x - 1).Text
                da = New SQLite.SQLiteDataAdapter(query, con)
                da.Fill(ds, "collectibles")
                'MsgBox(ds.Tables("collectibles").Rows(0).Item(0) & " " & ds.Tables("collectibles").Rows(0).Item(4))
                ctr = 0
                excess = 0
                payableAmount = 0
                collectedAmount = 0
                previousBalance = 0

                storedValue = 0
                rembal = 0
                For z = 1 To ds.Tables("collectibles").Rows.Count Step 1
                    Select Case ds.Tables("collectibles").Rows(z - 1).Item(2).ToString
                        Case 0
                            currPenaltyAmount = ds.Tables("collectibles").Rows(z - 1).Item(6).ToString.Insert(6, ".")
                        Case 1
                            currPenaltyAmount = ds.Tables("collectibles").Rows(z - 1).Item(6).ToString.Insert(6, ".")
                        Case Else
                            currPenaltyAmount = 0
                    End Select
                    payableAmount = CDbl(ds.Tables("collectibles").Rows(z - 1).Item(3).ToString.Insert(6, "."))
                    collectedAmount = CDbl(ds.Tables("collectibles").Rows(z - 1).Item(4).Insert(6, "."))
                    previousBalance = rembal 'rembal
                    excess = (payableAmount + previousBalance + currPenaltyAmount) - collectedAmount
                    If excess < 0 Then
                        storedValue += Math.Abs(excess)
                        collectedAmount = CDbl(ds.Tables("collectibles").Rows(z - 1).Item(4).Insert(6, ".")) - Math.Abs(excess)
                        conV = collectedAmount
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
                        ds.Tables("collectibles").Rows(z - 1).Item(4) = splitter(0) & splitter(1)
                        data.Add("collected_amt", splitter(0) & splitter(1))


                        rembal = 0
                        rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt " & _
                                         " WHERE ctb_id=" & ds.Tables("collectibles").Rows(z - 1).Item(0), data)

                        data.Clear()


                    Else
                        If storedValue - excess < 0 Then
                            collectedAmount = CDbl(ds.Tables("collectibles").Rows(z - 1).Item(4).Insert(6, ".")) + storedValue
                            storedValue = 0
                        Else
                            collectedAmount = (CDbl(ds.Tables("collectibles").Rows(z - 1).Item(4).Insert(6, ".")) + storedValue) - excess
                            storedValue -= excess
                        End If

                        conV = collectedAmount
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
                        ds.Tables("collectibles").Rows(z - 1).Item(4) = splitter(0) & splitter(1)
                        data.Add("collected_amt", splitter(0) & splitter(1))

                        'gamitin ang rembal
                        conV = rembal
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
                        ds.Tables("collectibles").Rows(z - 1).Item(5) = splitter(0) & splitter(1)
                        data.Add("previous_balance", splitter(0) & splitter(1))

                        rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt , previous_balance=@previous_balance " & _
                                         " WHERE ctb_id=" & ds.Tables("collectibles").Rows(z - 1).Item(0), data)

                        data.Clear()
                        rembal = (payableAmount + rembal + currPenaltyAmount) - collectedAmount
                    End If
                Next


                '---------------------here's penalty status? new codes added -----------------
                dr = db.ExecuteReader("SELECT penalty_status FROM tbl_collectibles WHERE due_date = '" & _
                                      Format(CDate(lvCollectibles.FocusedItem.SubItems(1).Text), "yyyyMMdd") & "' AND " & _
                                      "loan_id = " & lvCollectibles.Items(x - 1).Text)

                If dr.Item("penalty_status").ToString = "0" Then
                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET penalty_status = 2 WHERE due_date = '" & _
                                      Format(CDate(lvCollectibles.FocusedItem.SubItems(1).Text), "yyyyMMdd") & "' AND " & _
                                      "loan_id = " & lvCollectibles.Items(x - 1).Text)
                End If

                '-------------------------------end of added code----------------------------'

                dr = db.ExecuteReader("SELECT amount, date_stamp, loan_id, ctb_id FROM tbl_payments" & _
                                          " WHERE ctb_id= " & lvCollectibles.Items(x - 1).SubItems(12).Text)



                If dr.HasRows Then
                    'update
                    data.Add("loan_id", lvCollectibles.Items(x - 1).Text)

                    conV = lvCollectibles.Items(x - 1).SubItems(5).Text
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
                    data.Add("amount", splitter(0) & splitter(1))
                    data.Add("date_stamp", Format(Date.Now, "yyyyMMdd"))

                    rec = db.ExecuteNonQuery("UPDATE tbl_payments SET loan_id=@loan_id, amount=@amount, " & _
                                             "date_stamp=@date_stamp WHERE  ctb_id=" & lvCollectibles.Items(x - 1).SubItems(12).Text, data)

                Else
                    'insert
                    data.Add("loan_id", lvCollectibles.Items(x - 1).Text)

                    conV = lvCollectibles.Items(x - 1).SubItems(5).Text
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
                    data.Add("amount", splitter(0) & splitter(1))
                    data.Add("date_stamp", Format(Date.Now, "yyyyMMdd"))
                    data.Add("ctb_id", lvCollectibles.Items(x - 1).SubItems(12).Text)
                    rec = db.ExecuteNonQuery("INSERT INTO tbl_payments (loan_id, amount, date_stamp, ctb_id) VALUES " & _
                                          "(@loan_id, @amount, @date_stamp, @ctb_id)", data)

                End If
                data.Clear()
                '
                'get min for previousbal
                'tignan natin here kung equal or greater than na ang last payment nya at kapag ganoon loan status will equal
                'to 2 means COMPLETED. code starts here
                'store the ID

                'data.Add("collected_amt",) computation
                dr = db.ExecuteReader("SELECT MIN(due_date) as petsa, min(ctb_id) as low FROM tbl_collectibles WHERE due_date > '" & _
                                     Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & "' AND loan_id= " & _
                                     lvCollectibles.Items(x - 1).Text)

                If dr.HasRows Then
                    If dr.Item("low").ToString <> "" Then
                        colID = CInt(dr.Item("low").ToString)
                        If rembal = 0 Then
                            'stored value
                            conV = storedValue
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
                            conV = rembal
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
                            data.Add("previous_balance", splitter(0) & splitter(1))

                            rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt, previous_balance=" & _
                                                     "@previous_balance WHERE ctb_id=" & colID, data)
                        Else
                            'rembal to get even if it is zero :D
                            conV = rembal
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

                            data.Add("previous_balance", splitter(0) & splitter(1))
                            rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET previous_balance=@previous_balance WHERE ctb_id=" & _
                                                     colID, data)


                        End If
                        data.Clear()
                        ds.Clear()
                        Exit For
                    Else
                        'this is the last payment
                        If rembal = 0 Then
                            'loan status =2 

                            rec = db.ExecuteNonQuery("UPDATE tbl_loans SET loan_status =2  WHERE loan_id =" & lvCollectibles.Items(x - 1).Text)

                        End If


                    End If

                End If
                con.Close()

                ds.Clear()

            Next

            ShowData()
            MsgBox("Process completed!", MsgBoxStyle.Information, "Congratulations!")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
            con.Dispose() ' pag may error eto lang huli kong dinagdag
        End Try
        
        'try catch don't forget
    End Sub



    Private Sub lvDuedates_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lvDuedates.ItemChecked
        'saka na itu

        'Dim val, val3 As Double
        'val = 0

        'val3 = 0
        'payableAmount = lvCollectibles.FocusedItem.SubItems(3).Text
        'If gbxClientCollectible.Enabled = True Then '
        '    For x = 1 To lvDuedates.Items.Count Step 1
        '        If lvDuedates.Items(x - 1).Checked = True Then
        '            val += lvDuedates.Items(x - 1).SubItems(1).Text
        '        End If
        '    Next
        '    val3 = payableAmount - val
        '    For x = 1 To lvDuedates.Items.Count Step 1
        '        If lvDuedates.Items(x - 1).Checked = False Then
        '            val -= CDbl(lvDuedates.Items(x - 1).SubItems(1).Text)
        '        End If
        '    Next
        '    lblPayableAmount.Text = val + val3
        'End If
        
    End Sub

 
 

    Private Sub btnPHback_Click(sender As Object, e As EventArgs) Handles btnPHback.Click
        For Each Control In gbxPH.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control
        showPaymentHistory(False)

    End Sub

    Private Sub btnPH_Click(sender As Object, e As EventArgs) Handles btnPH.Click

        Try
            penalty = 0
            colorChanger = False
            collectedAmount = 0
            lvPH.Items.Clear()
            If lvCollectibles.SelectedItems.Count > 0 Then
                txtLoanid.Text = lvCollectibles.FocusedItem.Text
                txtname.Text = lvCollectibles.FocusedItem.SubItems(2).Text
                'get all penalty amount
                dr = db.ExecuteReader("SELECT penalty_amt,penalty_status FROM tbl_collectibles WHERE loan_id = " & lvCollectibles.FocusedItem.Text)

                If dr.HasRows Then

                    Do While dr.Read
                        If dr.Item("penalty_status").ToString = 1 Then
                            penalty += CDbl(dr.Item("penalty_amt").ToString.Insert(6, ","))
                        End If
                        txtTotalPenalties.Text = penalty
                        If Not txtTotalPenalties.Text.Contains(".") Then
                            txtTotalPenalties.Text &= ".00"
                        End If
                    Loop

                End If
                'balance calculate terms left also please get the gross amt :D
                dr = db.ExecuteReader("SELECT principal, terms, interest_percentage,date_end FROM tbl_loans WHERE loan_id=" & lvCollectibles.FocusedItem.Text)


                principal = CDbl(dr.Item("principal").Insert(6, ".").ToString)
                monthlyRate = principal / (CInt(dr.Item("terms").ToString) * 2)
                biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
                interest = principal * biMonInterest
                totalPaymentBiMonth = monthlyRate + interest
                rembal = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
                txtTerms.Text = dr.Item("terms").ToString
                txtDateEnd.Text = StrToDate(dr.Item("date_end").ToString)
                showPaymentHistory(True)
                dr = db.ExecuteReader("SELECT payment_id, date_stamp, amount,penalty_amt , penalty_status FROM tbl_payments WHERE loan_id=" & txtLoanid.Text & " ORDER by date_stamp ASC")

                If dr.HasRows Then
                    Do While dr.Read

                        itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                        itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                        itm.SubItems.Add(CDbl(dr.Item("amount").Insert(6, ".").ToString))
                        If Not lvPH.Items(ctr).SubItems(2).Text.Contains(".") Then
                            lvPH.Items(ctr).SubItems(2).Text &= ".00"
                        End If
                        collectedAmount += lvPH.Items(ctr).SubItems(2).Text

                        If colorChanger = True Then
                            itm.BackColor = Color.LemonChiffon
                            colorChanger = False
                        Else
                            itm.BackColor = Color.LightCyan
                            colorChanger = True
                        End If
                        ctr += 1

                    Loop
                    conV = collectedAmount
                    If Not conV.Contains(".") Then
                        conV &= ".00"
                    End If
                    txtCollectedAmt.Text = conV - penalty


                    txtBalance.Text = (rembal - CDbl(txtCollectedAmt.Text)) + penalty

                    If Not txtBalance.Text.Contains(".") Then
                        txtBalance.Text &= ".00"
                    End If
                Else
                    txtTotalPenalties.Clear()
                    MsgBox("No payment history", MsgBoxStyle.Information)

                End If


            Else
                MsgBox("No selected data to view Payment history.", vbExclamation + vbOKOnly, "Please select a record.")
            End If

            conV = ""
            rembal = 0

            ctr = 0

            gbxPH.BringToFront()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()

        End Try

    End Sub

    

    Private Sub tsmViewPH_Click(sender As Object, e As EventArgs) Handles tsmViewPH.Click
        btnPH_Click(sender, e)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        showAdvanceSearch(True)
    End Sub

    Private Sub tsmInputAmount_Click(sender As Object, e As EventArgs) Handles tsmInputAmount.Click
        If lvCollectibles.SelectedItems.Count > 0 Then
            lvCollectibles_DoubleClick(sender, e)
        Else
            MsgBox("No selected data.", vbExclamation + vbOKOnly, "Please select a record.")
        End If
    End Sub

    Private Sub tsmManagePenalties_Click(sender As Object, e As EventArgs) Handles tsmManagePenalties.Click
        If lvCollectibles.SelectedItems.Count > 0 Then
            lvCollectibles_DoubleClick(sender, e)
            frmManagePenalties.ShowDialog()
        Else
            MsgBox("No selected data.", vbExclamation + vbOKOnly, "Please select a record.")
        End If
    End Sub
End Class
