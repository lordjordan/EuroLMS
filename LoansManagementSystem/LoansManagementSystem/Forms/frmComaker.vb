Public Class frmComaker
    Dim itm As ListViewItem
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader

    Private Sub showAddCoMaker(mode As Boolean)
        gbxAddCoMaker.Visible = mode
        pnlComaker.Enabled = Not mode
    End Sub
    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click
        showRegularEmployees()
    End Sub

   


   

    Private Sub btnClientBack_Click(sender As Object, e As EventArgs) Handles btnClientBack.Click
        showAddCoMaker(False)
    End Sub

    Private Sub frmComaker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = e.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = e.CloseReason
        If UnloadMode = CloseReason.UserClosing Then
            Me.Hide()
        End If
        e.Cancel = Cancel
    End Sub

    Private Sub frmComaker_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'list of comakers ni borrower
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        showAddCoMaker(True)
        'load all regular employees
    End Sub
    Private Sub showComakers()
        'edit?
        lvCoMakerList.Items.Clear()
        Try
            dr = db.ExecuteReader("SELECT tbl_clients.client_id , last_name || ', ' || first_name || ' ' || last_name as name, " & _
                "company_name || '/' || branch_name as comBran, employee_no from tbl_comakers " & _
                "inner join tbl_clients on tbl_comakers.client_id = tbl_clients.client_id inner join tbl_branches " & _
                "on tbl_clients.branch_id = tbl_branches.branch_id inner join tbl_company on tbl_branches.company_id = " & _
                "tbl_company.company_id WHERE loan_id=") 'saan ko kukunin ang loan ID
            If dr.HasRows Then

                Do While dr.Read()

                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose()
        End Try
    End Sub
    Private Sub showRegularEmployees()
        lvClientList.Items.Clear()
        Try

            dr = db.ExecuteReader("SELECT client_id, last_name  || ' ' || first_name || ' ' || middle_name as name, company_name || '/' || branch_name as comBran, employee_no FROM (" & _
                                  " SELECT *  from tbl_clients where client_id <> " & uscLoans.txtClientID.Text & " AND employee_type = 1) as tbl_C inner join tbl_branches on " & _
                                  " tbl_C.branch_id = tbl_branches.branch_id Inner join  tbl_company on tbl_branches.company_id = tbl_company.company_id " & _
                                  " WHERE first_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or last_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or middle_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or combran LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or employee_no LIKE '%" & txtSearchClient.Text.Trim & "%'")
            If dr.HasRows Then
                Do While dr.Read
                    itm = Me.lvClientList.Items.Add(dr.Item("client_id").ToString)
                    itm.SubItems.Add(dr.Item("name").ToString)
                    itm.SubItems.Add(dr.Item("employee_no").ToString)
                    itm.SubItems.Add(dr.Item("combran").ToString)
                Loop
            Else
                MsgBox("No record found", vbInformation + vbOKOnly, "Record not found")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose()
        End Try
    End Sub
    Private Sub btnSelectSearchClient_Click(sender As Object, e As EventArgs) Handles btnSelectSearchClient.Click
        If lvClientList.SelectedItems.Count = 0 Then
            MsgBox("Please select a client ", MsgBoxStyle.Exclamation + vbOKOnly, "No client selected")
            Exit Sub
        End If
        For x = 1 To lvCoMakerList.Items.Count Step 1
            If lvCoMakerList.Items(x - 1).Text = lvClientList.FocusedItem.Text Then
                MsgBox("Client is already added in the list of comakers", MsgBoxStyle.Exclamation + vbOKOnly)
                Exit Sub
            End If
        Next
        'validation 2 check in collectibles , loans
        'loan muna kung may utang ang comaker.
        If ComputeAvailableCredit(lvClientList.FocusedItem.Text) < uscLoans.txtPrincipal.Text Then
            MsgBox("Available credit is not enough to be a co-maker." & vbCrLf & _
                   "Available credit is " & ComputeAvailableCredit(lvClientList.FocusedItem.Text))
            Exit Sub
        End If

        itm = lvCoMakerList.Items.Add(lvClientList.FocusedItem.Text)
        itm.SubItems.Add(lvClientList.FocusedItem.SubItems(1).Text)
        itm.SubItems.Add(lvClientList.FocusedItem.SubItems(2).Text)
        itm.SubItems.Add(lvClientList.FocusedItem.SubItems(3).Text)
        showAddCoMaker(False)
    End Sub

    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub


    
    Private Sub btnOkExit_Click(sender As Object, e As EventArgs) Handles btnOkExit.Click
        'tengga muna saving nya sa save button ni loans
        uscLoans.txt_no_of_Comaker.Text = lvCoMakerList.Items.Count
        Me.Hide()
    End Sub
    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If lvCoMakerList.SelectedItems.Count = 0 Then
            MsgBox("Please select a client first", MsgBoxStyle.Exclamation + vbOKOnly, "No comaker selected")
            Exit Sub
        End If
        
        Select Case MessageBox.Show("Are you sure you want to remove " & _
            lvCoMakerList.FocusedItem.SubItems(1).Text & " as a co-maker?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case Windows.Forms.DialogResult.Yes
                lvCoMakerList.FocusedItem.Remove()
        End Select
    End Sub
    Private Function ComputeAvailableCredit(ClientID As String) As String
        'codes for available credit (isasama ko pa ba mga penalized o hiwalay na yun????)oo nga pala penalties pa.....
        Dim db As New DBHelper(My.Settings.ConnectionString)
        Dim dr As SQLite.SQLiteDataReader
        Dim con As New SQLite.SQLiteConnection
        Dim ds As New DataSet
        Dim da As SQLite.SQLiteDataAdapter
        Dim query As String
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
            'tignan natin kung may kinomake 1)tbl comakers
            'mga variables na gagamitin
            Dim remVal, totalval, overallcomake As Double
            remVal = 0
            totalval = 0
            overallcomake = 0
            con.ConnectionString = My.Settings.ConnectionString
            query = "select * from tbl_comakers where client_id=" & ClientID
            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "comakers")
            For z = 1 To ds.Tables("comakers").Rows.Count Step 1
                dr = db.ExecuteReader("select tbl_loans.loan_id, principal, sum(amount) as amt, loan_status, payment_status " & _
                                      " from tbl_loans inner join tbl_payments on tbl_loans.loan_id = tbl_payments.loan_id where tbl_loans.loan_id= " & _
                                      ds.Tables("comakers").Rows(z - 1).Item("loan_id").ToString & _
                                      " and loan_status = 1 and payment_status= 0")
                totalval = FormatNumber(dr.Item("amt").ToString, 2)
                totalval = Replace(remVal, ",", "")
                remVal = StrToNum(dr.Item("principal").ToString.ToString) - totalval
                If remVal < 0 Then
                    remVal = 0
                End If
                overallcomake += remVal
            Next



            dr = db.ExecuteReader("SELECT credit_limit FROM tbl_clients WHERE client_id = " & lvClientList.FocusedItem.Text)
            If dr.HasRows Then

                creditLimit = StrToNum(dr.Item(0).ToString)

                'creditLimit = dr.Item(0).ToString.Insert(6, ".")
            End If
            'Get all the active loans of the client.
            dr = db.ExecuteReader("SELECT loan_id, principal, interest_percentage, terms FROM tbl_loans INNER JOIN tbl_clients" & _
                                  " ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_clients.client_id =" & lvClientList.FocusedItem.Text & _
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
                                  "WHERE payment_status = 0 AND client_id= " & lvClientList.FocusedItem.Text & " AND loan_status= 1")
            If dr.HasRows Then

                If dr.Item("amt").ToString <> "" Then

                    overAllPayment = StrToNum(dr.Item("amt").ToString)
                End If

            End If
            dr = db.ExecuteReader("SELECT sum(penalty_amt) as amt, penalty_status FROM tbl_collectibles INNER JOIN tbl_loans ON tbl_collectibles.loan_id" & _
                                  " = tbl_loans.loan_id  WHERE client_id=" & lvClientList.FocusedItem.Text & " AND loan_status = 1 AND penalty_status = 1")

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
                conV = NumToStr((creditLimit - rembal) - overallcomake) 'minus ang kinomake kung merons
                '50000.5
                Return StrToNum(conV)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            db.Dispose()

        End Try
    End Function
End Class