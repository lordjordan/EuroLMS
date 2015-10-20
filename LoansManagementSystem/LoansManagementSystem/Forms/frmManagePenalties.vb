Public Class frmManagePenalties
    Public principal, monthlyRate, totalPaymentBiMonth As Double
    Public biMonInterest As Decimal
    Public interest As Double
    Public bilangNGhulog, daysNgmonth As Integer
    Public dateStart, dateEnd, dueDate As DateTime

    
    Dim a, b, c, splitter() As String
    Dim itm As ListViewItem
    '### Change the "Data Source" path to point to our own LMS Database
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim rec As Integer
    Dim data As New Dictionary(Of String, Object)
    Dim colorChanger As Boolean

    'adjustments
    Dim excess, payableAmount, collectedAmount, penaltyAmount, previousBalance, currPenaltyAmount, storedValue As Double
    Dim ctr As Integer
    Dim conV As String
    Dim con As New SQLite.SQLiteConnection
    Dim ds As New DataSet
    Dim da As SQLite.SQLiteDataAdapter
    Dim query As String
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
                    a = dr.Item("due_date").ToString().Substring(0, 4)
                    b = dr.Item("due_date").ToString().Substring(4, 2)
                    c = dr.Item("due_date").ToString().Substring(6, 2)
                    dueDate = CDate(b & "/" & c & "/" & a)
                    itm = lvDuedate.Items.Add(dueDate)
                    itm.SubItems.Add(CDbl(dr.Item("penalty_amt").ToString.Insert(6, ".")))

                    Select Case dr.Item("penalty_status")
                        Case 0
                            itm.SubItems.Add("Unprocessed")
                        Case 1
                            itm.SubItems.Add("Penalized")
                        Case 2
                            itm.SubItems.Add("Removed")
                    End Select

                    itm.SubItems.Add(dr.Item("ctb_id").ToString)
                    If colorChanger = True Then
                        itm.BackColor = Color.LemonChiffon
                        colorChanger = False
                    Else
                        itm.BackColor = Color.LightCyan
                        colorChanger = True
                    End If
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
            'managing penalties 
            For x = 1 To lvDuedate.Items.Count Step 1
                'Try
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


                'Catch ex As Exception
                '    MsgBox(ex.ToString)
                '    MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
                'End Try
                data.Clear()

            Next
            MessageBox.Show("Records updated!", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            'adjusting technique pa.

            con.ConnectionString = "Data Source=D:\LMSdb\LMS.s3db; Version=3;"
            query = "SELECT ctb_id,due_date , penalty_status ,payable_amt , collected_amt,previous_balance,penalty_amt FROM tbl_collectibles WHERE due_date <= '" & _
                                  Format(CDate(uscCollectibles.lvCollectibles.FocusedItem.SubItems(1).Text), "yyyyMMdd") & "' AND " & _
                                  "loan_id = " & uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text
            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "collectibles")
            'MsgBox(ds.Tables("collectibles").Rows(0).Item(0) & " " & ds.Tables("collectibles").Rows(0).Item(4))
            ctr = 0
            excess = 0
            payableAmount = 0
            collectedAmount = 0
            previousBalance = 0
            penaltyAmount = 0
            storedValue = 0
            Dim rembal As Double
            rembal = 0
            For x = 1 To ds.Tables("collectibles").Rows.Count Step 1
                Select Case ds.Tables("collectibles").Rows(x - 1).Item(2).ToString
                    Case 0
                        currPenaltyAmount = ds.Tables("collectibles").Rows(x - 1).Item(6).ToString.Insert(6, ".")
                    Case 1
                        currPenaltyAmount = ds.Tables("collectibles").Rows(x - 1).Item(6).ToString.Insert(6, ".")
                    Case Else
                        currPenaltyAmount = 0
                End Select
                payableAmount = CDbl(ds.Tables("collectibles").Rows(x - 1).Item(3).ToString.Insert(6, "."))
                collectedAmount = CDbl(ds.Tables("collectibles").Rows(x - 1).Item(4).Insert(6, "."))
                previousBalance = rembal 'rembal
                excess = (payableAmount + previousBalance + currPenaltyAmount) - collectedAmount
                'storedValue = Math.Abs(excess)     
                If excess < 0 Then
                    storedValue += Math.Abs(excess)
                    collectedAmount = CDbl(ds.Tables("collectibles").Rows(x - 1).Item(4).Insert(6, ".")) - Math.Abs(excess)
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
                    ds.Tables("collectibles").Rows(x - 1).Item(4) = splitter(0) & splitter(1)
                    data.Add("collected_amt", splitter(0) & splitter(1))
                    For y = 1 To lvDuedate.Items.Count Step 1
                        If ds.Tables("collectibles").Rows(x - 1).Item(1) = Format(CDate(lvDuedate.Items(y - 1).Text), "yyyyMMdd") Then
                            conV = lvDuedate.Items(y - 1).SubItems(1).Text
                            Exit For
                        End If
                    Next
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
                    ds.Tables("collectibles").Rows(x - 1).Item(6) = splitter(0) & splitter(1)
                    data.Add("penalty_amt", splitter(0) & splitter(1))

                    rembal = 0
                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt , penalty_amt=@penalty_amt " & _
                                     " WHERE ctb_id=" & ds.Tables("collectibles").Rows(x - 1).Item(0), data)
                    data.Clear()
                Else
                    'gamitin ang storedValue
                    If storedValue - excess < 0 Then
                        collectedAmount = CDbl(ds.Tables("collectibles").Rows(x - 1).Item(4).Insert(6, ".")) + storedValue
                        storedValue = 0
                    Else
                        collectedAmount = (CDbl(ds.Tables("collectibles").Rows(x - 1).Item(4).Insert(6, ".")) + storedValue) - excess
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
                    ds.Tables("collectibles").Rows(x - 1).Item(4) = splitter(0) & splitter(1)
                    data.Add("collected_amt", splitter(0) & splitter(1))
                    For y = 1 To lvDuedate.Items.Count Step 1
                        If ds.Tables("collectibles").Rows(x - 1).Item(1) = Format(CDate(lvDuedate.Items(y - 1).Text), "yyyyMMdd") Then
                            conV = lvDuedate.Items(y - 1).SubItems(1).Text
                            Exit For
                        End If
                    Next
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
                    ds.Tables("collectibles").Rows(x - 1).Item(6) = splitter(0) & splitter(1)
                    data.Add("penalty_amt", splitter(0) & splitter(1))
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
                    ds.Tables("collectibles").Rows(x - 1).Item(4) = splitter(0) & splitter(1)
                    data.Add("previous_balance", splitter(0) & splitter(1))
                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt , penalty_amt=@penalty_amt, previous_balance=@previous_balance " & _
                                     " WHERE ctb_id=" & ds.Tables("collectibles").Rows(x - 1).Item(0), data)
                    data.Clear()
                    rembal = (payableAmount + rembal + currPenaltyAmount) - collectedAmount
                End If
            Next
            'after loop next values are important for determining if the loans have balance or none.
            con.Close()
            ds.Clear()
            Me.Close()
            uscCollectibles.lvDuedates.Items.Clear()
            dr = db.ExecuteReader("SELECT due_date, principal,ctb_id,penalty_amt FROM tbl_collectibles INNER JOIN tbl_loans ON tbl_collectibles.loan_id " & _
                                  "= tbl_loans.loan_id WHERE penalty_status= 0 AND due_date <'" & _
                                  Format(Date.Now, "yyyyMMdd") & "' AND tbl_collectibles.loan_id = " & uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text _
                                  & " ORDER BY due_date ASC")
            If dr.HasRows Then
                Do While dr.Read
                    a = dr.Item("due_date").ToString().Substring(0, 4)
                    b = dr.Item("due_date").ToString().Substring(4, 2)
                    c = dr.Item("due_date").ToString().Substring(6, 2)
                    dueDate = CDate(b & "/" & c & "/" & a)
                    itm = uscCollectibles.lvDuedates.Items.Add(dueDate) 'casted
                    itm.SubItems.Add(CDbl(dr.Item("penalty_amt").ToString.Insert(6, ".")))
                    itm.SubItems.Add(dr.Item("ctb_id").ToString)
                    If colorChanger = True Then
                        itm.BackColor = Color.LemonChiffon
                        colorChanger = False
                    Else
                        itm.BackColor = Color.LightCyan
                        colorChanger = True
                    End If
                Loop
                splitter = Split(uscCollectibles.lvCollectibles.FocusedItem.SubItems(11).Text, ",") 'splitting ng ctb_id
                For y = 1 To splitter.Length Step 1
                    For x = 1 To uscCollectibles.lvDuedates.Items.Count Step 1
                        If splitter(y - 1) = uscCollectibles.lvDuedates.Items(x - 1).SubItems(2).Text Then
                            uscCollectibles.lvDuedates.Items(x - 1).Checked = True

                        End If
                        If Not uscCollectibles.lvDuedates.Items(x - 1).SubItems(1).Text.Contains(".") Then
                            uscCollectibles.lvDuedates.Items(x - 1).SubItems(1).Text &= ".00"
                        End If
                    Next
                Next
            End If
            uscCollectibles.btnCancelColl.Enabled = False
            'showData()
            uscCollectibles.gbxClientCollectible.BringToFront()
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
End Class