'GO! GO! GO! Software PRODCOM TEAM! 1 week!
Imports Microsoft.Office.Interop

Public Class frmCollectibles
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
        uscCollectibles = New frmCollectibles
    End Sub

    Private Sub showPrintAttack(mode As Boolean)
        gbxPrint.BringToFront()
        gbxPrint.Visible = mode
        pnlMain.Enabled = Not mode
    End Sub
    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        showAdvanceSearch(False)
        'gbxAdvanceSearch.Visible = False
    End Sub

    Private Sub btnSearchLoan_Click(sender As Object, e As EventArgs) Handles btnSearchLoan.Click
        lblInfoSearch.Text = "All"

        lvCollectibles.Items.Clear()
        con.ConnectionString = My.Settings.ConnectionString
        Try
            query = "SELECT ctb_id,tblCol.loan_id as LoanID, MAX(due_date) as petsa, last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
                    "payable_amt, previous_balance as previ, principal, date_start, date_end , interest_percentage,collected_amt as colsi,terms, penalty_status,penalty_amt " & _
                    "FROM  (SELECT ctb_id , loan_id , due_date , payable_amt, previous_balance,collected_amt,penalty_status,penalty_amt " & _
                "FROM tbl_collectibles  WHERE due_date <= '" & Format(Date.Now, "yyyyMMdd") & "') as tblCol " & _
                "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
                "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tblCol.loan_id LIKE '%" & _
                 txtSearchLoan.Text & "%' AND last_name LIKE '%" & txtSearchLoan.Text & "%' " & _
                 "AND first_name LIKE '%" & txtSearchLoan.Text & "%' AND middle_name LIKE '%" & txtSearchLoan.Text & _
                 "%' AND tbl_loans.loan_status = 1 GROUP BY tblCol.loan_id"
            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "collectibles")
            For x = 1 To ds.Tables("collectibles").Rows.Count Step 1
                'kapag equal dapat next date
              
                Select Case ds.Tables("collectibles").Rows(x - 1).Item("penalty_status").ToString
                  

                    Case 2
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
                'convert all value to currency
                For z = 1 To lvCollectibles.Items.Count Step 1
                    lvCollectibles.Items(z - 1).SubItems(4).Text = CDbl(lvCollectibles.Items(z - 1).SubItems(4).Text)
                    lvCollectibles.Items(z - 1).SubItems(7).Text = CDbl(lvCollectibles.Items(z - 1).SubItems(7).Text)
                    lvCollectibles.Items(z - 1).SubItems(9).Text = CDbl(lvCollectibles.Items(z - 1).SubItems(9).Text)
                    If Not lvCollectibles.Items(z - 1).SubItems(4).Text.Contains(".") Then
                        lvCollectibles.Items(z - 1).SubItems(4).Text &= ".00"
                    End If
                    If Not lvCollectibles.Items(z - 1).SubItems(7).Text.Contains(".") Then
                        lvCollectibles.Items(z - 1).SubItems(7).Text &= ".00"
                    End If
                    If Not lvCollectibles.Items(z - 1).SubItems(8).Text.Contains(".") Then
                        lvCollectibles.Items(z - 1).SubItems(8).Text &= ".00"
                    End If
                    If Not lvCollectibles.Items(z - 1).SubItems(9).Text.Contains(".") Then
                        lvCollectibles.Items(z - 1).SubItems(9).Text &= ".00"
                    End If
                Next
                'payable amount , penalty , previous balance kung meron
                Dim pangIlan As Integer
                Dim penaltyVal As Double


                pangIlan = 0

                penaltyVal = 0

                For y = 1 To lvCollectibles.Items.Count Step 1
                    dr = db.ExecuteReader("SELECT * FROM tbl_collectibles WHERE loan_id = " & lvCollectibles.Items(y - 1).SubItems(0).Text & _
                                          " ORDER BY due_date ASC")
                    If dr.HasRows Then

                        Do While dr.Read
                            dueDate = StrToDate(dr.Item("due_date").ToString)

                            If dueDate = lvCollectibles.Items(y - 1).SubItems(1).Text Then
                                If dr.Item("penalty_status").ToString = 0 Then
                                    concats &= dr.Item("ctb_id").ToString
                                End If
                                lvCollectibles.Items(y - 1).SubItems(7).Text = CDbl(StrToNum(dr.Item("previous_balance").ToString))
                                If dr.Item("penalty_status").ToString = 1 Or dr.Item("penalty_status").ToString = 2 Then
                                    lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal
                                    lvCollectibles.Items(y - 1).SubItems(3).Text = CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal
                                Else
                                    If dueDate >= CDate(Format(Date.Now, "MM/dd/yyyyy")) Then
                                        lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal
                                        lvCollectibles.Items(y - 1).SubItems(3).Text = CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal
                                    Else
                                        lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal + CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                                        lvCollectibles.Items(y - 1).SubItems(3).Text = CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + CDbl(StrToNum(dr.Item("penalty_amt").ToString)) + penaltyVal
                                    End If
                                End If
                                lvCollectibles.Items(y - 1).SubItems(11).Text = concats
                                If Not lvCollectibles.Items(y - 1).SubItems(3).Text.Contains(".") Then
                                    lvCollectibles.Items(y - 1).SubItems(3).Text &= ".00"
                                End If
                                If Not lvCollectibles.Items(y - 1).SubItems(6).Text.Contains(".") Then
                                    lvCollectibles.Items(y - 1).SubItems(6).Text &= ".00"
                                End If
                                If Not lvCollectibles.Items(y - 1).SubItems(7).Text.Contains(".") Then
                                    lvCollectibles.Items(y - 1).SubItems(7).Text &= ".00"
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
            If lvCollectibles.Items.Count = 0 Then
                MsgBox("No collectibles found", vbInformation + vbOKOnly, "E.M.C inc.")
            End If
            ds.Clear()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
    End Sub
    Public Sub ShowData()
        Cursor = Cursors.WaitCursor
        Dim pangIlan As Integer
        Dim penaltyVal As Double
        lvCollectibles.Items.Clear()
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
                For y = 1 To lvCollectibles.Items.Count Step 1
                    dr = db.ExecuteReader("SELECT * FROM tbl_collectibles WHERE loan_id = " & lvCollectibles.Items(y - 1).SubItems(0).Text & _
                                          " ORDER BY due_date ASC")
                    If dr.HasRows Then

                        Do While dr.Read
                            dueDate = StrToDate(dr.Item("due_date").ToString)

                            If dueDate = lvCollectibles.Items(y - 1).SubItems(1).Text Then
                                If dr.Item("penalty_status").ToString = 0 Then
                                    concats &= dr.Item("ctb_id").ToString
                                End If
                                lvCollectibles.Items(y - 1).SubItems(7).Text = CDbl(StrToNum(dr.Item("previous_balance").ToString))
                                If dr.Item("penalty_status").ToString = 2 Then
                                    lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal
                                    lvCollectibles.Items(y - 1).SubItems(3).Text = (CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString))
                                Else
                                    If dueDate >= CDate(Format(Date.Now, "MM/dd/yyyyy")) Then
                                        lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal
                                        lvCollectibles.Items(y - 1).SubItems(3).Text = (CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString))
                                    Else
                                        lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal + CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                                        lvCollectibles.Items(y - 1).SubItems(3).Text = (CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + CDbl(StrToNum(dr.Item("penalty_amt").ToString)) + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString))
                                    End If
                                End If
                                lvCollectibles.Items(y - 1).SubItems(11).Text = concats
                                If Not lvCollectibles.Items(y - 1).SubItems(3).Text.Contains(".") Then
                                    lvCollectibles.Items(y - 1).SubItems(3).Text &= ".00"
                                End If
                                If Not lvCollectibles.Items(y - 1).SubItems(6).Text.Contains(".") Then
                                    lvCollectibles.Items(y - 1).SubItems(6).Text &= ".00"
                                End If
                                If Not lvCollectibles.Items(y - 1).SubItems(7).Text.Contains(".") Then
                                    lvCollectibles.Items(y - 1).SubItems(7).Text &= ".00"
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
            For y = 1 To lvCollectibles.Items.Count Step 1
                dr = db.ExecuteReader("SELECT * FROM tbl_collectibles WHERE loan_id = " & lvCollectibles.Items(y - 1).SubItems(0).Text & _
                                      " ORDER BY due_date ASC")
                If dr.HasRows Then
                    Do While dr.Read
                        dueDate = StrToDate(dr.Item("due_date").ToString)
                        If dueDate = lvCollectibles.Items(y - 1).SubItems(1).Text Then
                            If dr.Item("penalty_status").ToString = 0 Then
                                concats &= dr.Item("ctb_id").ToString
                            End If
                            lvCollectibles.Items(y - 1).SubItems(7).Text = CDbl(StrToNum(dr.Item("previous_balance").ToString))
                            If dr.Item("penalty_status").ToString = 2 Then
                                lvCollectibles.Items(y - 1).SubItems(6).Text = FormatNumber(penaltyVal, 2)
                                lvCollectibles.Items(y - 1).SubItems(3).Text = FormatNumber((CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString)), 2)
                            Else
                                If dueDate >= CDate(Format(Date.Now, "MM/dd/yyyyy")) Then
                                    lvCollectibles.Items(y - 1).SubItems(6).Text = FormatNumber(penaltyVal, 2)
                                    lvCollectibles.Items(y - 1).SubItems(3).Text = FormatNumber((CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString)), 2)
                                Else
                                    lvCollectibles.Items(y - 1).SubItems(6).Text = FormatNumber(penaltyVal + CDbl(StrToNum(dr.Item("penalty_amt").ToString)), 2)
                                    lvCollectibles.Items(y - 1).SubItems(3).Text = FormatNumber((CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + CDbl(StrToNum(dr.Item("penalty_amt").ToString)) + penaltyVal) - CDbl(StrToNum(dr.Item("collected_amt").ToString)), 2)
                                End If
                            End If
                            lvCollectibles.Items(y - 1).SubItems(11).Text = concats
                            If Not lvCollectibles.Items(y - 1).SubItems(3).Text.Contains(".") Then
                                lvCollectibles.Items(y - 1).SubItems(3).Text &= ".00"
                            End If
                            If Not lvCollectibles.Items(y - 1).SubItems(6).Text.Contains(".") Then
                                lvCollectibles.Items(y - 1).SubItems(6).Text &= ".00"
                            End If
                            If Not lvCollectibles.Items(y - 1).SubItems(7).Text.Contains(".") Then
                                lvCollectibles.Items(y - 1).SubItems(7).Text &= ".00"
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
        itm = lvCollectibles.Items.Add(dr.Item("loanID").ToString)

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
        itm = lvCollectibles.Items.Add(ds.Tables("collectibles").Rows(num - 1).Item("loanID").ToString)

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

    Private Sub frmCollectibles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvwColumnSorter = New ListViewColumnSorter()
        Me.lvCollectibles.ListViewItemSorter = lvwColumnSorter
        lvwColumnSorter1 = New ListViewColumnSorter()
        Me.lvPH.ListViewItemSorter = lvwColumnSorter1
        showCollectibles(False)
        ShowData()
    End Sub


    Private Sub btnCancelColl_Click(sender As Object, e As EventArgs) Handles btnCancelColl.Click
        showCollectibles(False)

    End Sub

    Private Sub btnManage_Click(sender As Object, e As EventArgs) Handles btnManage.Click
        frmManagePenalties.ShowDialog()

        

    End Sub


    Private Sub txtAmount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAmount.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If e.Handled = (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".") Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub lvCollectibles_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvCollectibles.ColumnClick
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
        Me.lvCollectibles.Sort()

    End Sub








    Private Sub lvCollectibles_DoubleClick(sender As Object, e As EventArgs) Handles lvCollectibles.DoubleClick
        Try

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

                        itm = lvDuedates.Items.Add(StrToDate(dr.Item("due_date").ToString)) 'casted
                        itm.SubItems.Add(StrToNum(dr.Item("penalty_amt").ToString))
                        itm.SubItems.Add(dr.Item("ctb_id").ToString)
                       
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
        Dim totalInPayment, totalLoanAmount, payable_amt As Double
        totalInPayment = 0
        penalty = 0
        penalty1 = 0
        payable_amt = 0
        Try
            dr = db.ExecuteReader("SELECT penalty_amt,penalty_status FROM tbl_collectibles WHERE loan_id = " & lvCollectibles.FocusedItem.Text & _
                                  " AND due_date = " & Format(CDate(lvCollectibles.FocusedItem.SubItems(1).Text), "yyyyMMdd"))
            If dr.HasRows Then

                Do While dr.Read
                    If dr.Item("penalty_status").ToString = 1 Then
                        penalty1 = CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                    End If

                Loop

            End If
            For x = 1 To lvDuedates.Items.Count Step 1

                If lvDuedates.Items(x - 1).Checked Then
                    tagakuhaNgID &= lvDuedates.Items(x - 1).SubItems(2).Text & ","
                    penalty += CDbl(lvDuedates.Items(x - 1).SubItems(1).Text)
                End If


            Next
            'pagmalaki ang input validate :>
            'una kunin ang mga payments
            dr = db.ExecuteReader("SELECT SUM(amount) as TotalAmount FROM tbl_payments WHERE loan_id = " & lvCollectibles.FocusedItem.Text & " AND payment_status= 0")
            If dr.HasRows Then

                If dr.Item("TotalAmount").ToString <> "" Then
                    conV = dr.Item("TotalAmount").ToString
                    totalInPayment = CDbl(StrToNum(conV))
                End If

            End If
            conV = ""
            dr = db.ExecuteReader("select sum(payable_amt) as payables from tbl_collectibles where loan_id = " & lvCollectibles.FocusedItem.Text)
            Dim val1 As Double
            val1 = 0
            If dr.HasRows Then
                If dr.Item("payables").ToString <> "" Then
                    conV = dr.Item("payables").ToString
                    val1 = CDbl(StrToNum(conV))
                End If
            End If
            val1 = val1 - totalInPayment
            'dr = db.ExecuteReader("SELECT principal, terms, interest_percentage, date_end, date_start FROM tbl_loans WHERE loan_id =" & lvCollectibles.FocusedItem.Text)


            'principal = CDbl(StrToNum(dr.Item("principal").ToString))
            'monthlyRate = principal / (CInt(dr.Item("terms").ToString) * 2)
            'biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
            'interest = principal * biMonInterest
            'totalPaymentBiMonth = monthlyRate + interest
            'rembal = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
            'totalLoanAmount = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
            'payable_amt = (totalLoanAmount + penalty + penalty1) - totalInPayment

            If txtAmount.Text <> "" Then
                If CDbl(txtAmount.Text) > val1 Then
                    Dim x As String = CStr(val1)
                    If Not x.Contains(".") Then
                        x &= ".00"
                    End If
                    MsgBox("The input amount is greater than remaining balance." & vbCrLf & "Remaining balance: " & x, vbExclamation + vbOKOnly, "Invalid amount")
                    Exit Sub
                End If
            End If


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
                    If CDbl(txtAmount.Text) > CDbl(lvCollectibles.FocusedItem.SubItems(3).Text) Then
                        MsgBox("This is the last payment for this loan please input an exact amount.", MsgBoxStyle.Exclamation + vbOKOnly, "Input amount is greater than payable amount.")
                        txtAmount.Focus()
                        Exit Sub
                    Else
                        lvCollectibles.FocusedItem.SubItems(5).Text = CDbl(txtAmount.Text)
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
            dr = db.ExecuteReader("SELECT previous_balance,payable_amt,due_date,collected_amt FROM tbl_collectibles WHERE due_date = '" & _
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

            End If
            'validations
            lvCollectibles.FocusedItem.SubItems(7).Text = FormatNumber(CDbl(StrToNum(dr.Item("previous_balance").ToString)), 2)
            lvCollectibles.FocusedItem.SubItems(6).Text = FormatNumber(penalty + penalty1, 2)
            lvCollectibles.FocusedItem.SubItems(3).Text = FormatNumber(CDbl(StrToNum(dr.Item("payable_amt").ToString)) + penalty + penalty1 + CDbl(StrToNum(dr.Item("previous_balance").ToString)) - CDbl(StrToNum(dr.Item("collected_amt").ToString)), 2)
            lvCollectibles.FocusedItem.SubItems(11).Text = tagakuhaNgID

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
        'version 2
        'Try

        Cursor = Cursors.WaitCursor
        If MsgBox("Are you sure you want to process the collectibles?", vbExclamation + vbYesNo + vbDefaultButton2, "Proceed?") = MsgBoxResult.Yes Then
            Dim overallAmount As Double
            Dim totalInPayment, payableAmt As Double
            totalInPayment = 0
            'process mode
            If lvCollectibles.Items.Count <> 0 Then
                For x = 1 To lvCollectibles.Items.Count Step 1 'every items in listview

                    'pagsamahin ang collected amount at inputted amount
                    If lvCollectibles.Items(x - 1).SubItems(5).Text = "" Or lvCollectibles.Items(x - 1).SubItems(5).Text = "0.00" Then
                        Continue For
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

                    ''need update ng collected amount
                    'conV = FormatNumber(overallAmount, 2)
                    'conV = Replace(conV, ",", "")

                    'If Not conV.Contains(".") Then
                    '    conV &= ".00"
                    'End If
                    'splitter = Split(conV, ".")
                    'If splitter(1).Length = 1 Then
                    '    splitter(1) &= "0"
                    'End If
                    'Do Until splitter(0).Length = 6
                    '    splitter(0) = splitter(0).Insert(0, "0")
                    'Loop
                    'data.Add("collected_amt", splitter(0) & splitter(1))
                    'rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt WHERE due_date='" _
                    '                         & Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & _
                    '                         "' AND loan_id= " & lvCollectibles.Items(x - 1).SubItems(0).Text, data)
                    'data.Clear()

                    'data set ulit para sa adjustment note: tbl_collectibles ay nag babago bago ng data.....


                    'insert
                    data.Add("loan_id", lvCollectibles.Items(x - 1).Text)

                    conV = lvCollectibles.Items(x - 1).SubItems(5).Text

                    data.Add("amount", NumToStr(conV))
                    data.Add("date_stamp", Format(Date.Now, "yyyyMMdd"))
                    data.Add("ctb_id", lvCollectibles.Items(x - 1).SubItems(12).Text)
                    data.Add("payment_status", "0")
                    rec = db.ExecuteNonQuery("INSERT INTO tbl_payments (loan_id, amount, date_stamp, ctb_id, payment_status) VALUES " & _
                                          "(@loan_id, @amount, @date_stamp, @ctb_id, @payment_status)", data)


                    data.Clear()

                    dr = db.ExecuteReader("SELECT SUM(amount) as TotalAmount FROM tbl_payments WHERE loan_id = " & lvCollectibles.Items(x - 1).Text & " AND payment_status= 0")
                    If dr.HasRows Then

                        If dr.Item("TotalAmount").ToString <> "" Then
                            conV = dr.Item("TotalAmount").ToString

                            totalInPayment = CDbl(StrToNum(conV))

                        End If
                    End If
                    ''
                    con.ConnectionString = My.Settings.ConnectionString
                    query = "SELECT ctb_id, due_date, penalty_status, payable_amt , collected_amt, previous_balance, penalty_amt FROM tbl_collectibles WHERE" & _
                                          " loan_id = " & lvCollectibles.Items(x - 1).Text & " ORDER by due_date ASC"
                    da = New SQLite.SQLiteDataAdapter(query, con)
                    da.Fill(ds, "collectibles")
                    For z = 1 To ds.Tables("collectibles").Rows.Count Step 1
                        If ds.Tables("collectibles").Rows(z - 1).Item("penalty_status").ToString = 1 Then
                            payableAmt = CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("payable_amt").ToString)) + _
                                CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("penalty_amt").ToString))
                            If totalInPayment >= payableAmt Then
                                totalInPayment = totalInPayment - payableAmt
                                conV = FormatNumber(payableAmt, 2)
                                conV = Replace(conV, ",", "")

                                data.Add("collected_amt", NumToStr(conV))
                                data.Add("previous_balance", "00000000")
                                rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET collected_amt=@collected_amt,previous_balance=@previous_balance " & _
                                                         "WHERE ctb_id=" & ds.Tables("collectibles").Rows(z - 1).Item("ctb_id").ToString, data)


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
                                                         "WHERE ctb_id=" & ds.Tables("collectibles").Rows(z - 1).Item("ctb_id").ToString, data)
                                totalInPayment = 0
                            End If
                            data.Clear()
                        Else
                            payableAmt = CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("payable_amt").ToString))
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
                                                         "WHERE ctb_id=" & ds.Tables("collectibles").Rows(z - 1).Item("ctb_id").ToString, data)


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
                                                         "WHERE ctb_id=" & ds.Tables("collectibles").Rows(z - 1).Item("ctb_id").ToString, data)
                                totalInPayment = 0
                            End If
                            data.Clear()
                        End If
                    Next

                    ds.Clear()
                    'previous balance

                    previousBalance = 0
                    query = "SELECT ctb_id, previous_balance, payable_amt, penalty_status, penalty_amt, collected_amt FROM tbl_collectibles WHERE loan_id = " & _
                        uscCollectibles.lvCollectibles.FocusedItem.SubItems(0).Text & " ORDER BY due_date ASC"
                    da = New SQLite.SQLiteDataAdapter(query, con)
                    da.Fill(ds, "collectibles")
                    For z = 1 To ds.Tables("collectibles").Rows.Count Step 1
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
                        ds.Tables("collectibles").Rows(z - 1).Item("previous_balance") = splitter(0) & splitter(1)
                        data.Add("previous_balance", splitter(0) & splitter(1))

                        rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET  previous_balance=@previous_balance " & _
                                             " WHERE ctb_id=" & ds.Tables("collectibles").Rows(z - 1).Item(0), data)
                        data.Clear()
                        If ds.Tables("collectibles").Rows(z - 1).Item("penalty_status").ToString = 1 Then

                            If CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("collected_amt").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("payable_amt").ToString)) _
                                                  + CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("previous_balance").ToString)) Then
                                previousBalance += 0
                            Else
                                previousBalance += (CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("payable_amt").ToString)) + _
                                CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("penalty_amt").ToString))) - CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("collected_amt").ToString))
                            End If

                        Else
                            If CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("collected_amt").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("payable_amt").ToString)) Then
                                previousBalance += 0
                            Else
                                previousBalance += (CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("payable_amt").ToString))) - CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("collected_amt").ToString))
                            End If

                        End If

                    Next

                    ds.Clear()

                    'update penalty status mga date na sumunod
                    query = "SELECT collected_amt, payable_amt, ctb_id FROM tbl_collectibles WHERE due_date >  '" & Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & "'"
                    da = New SQLite.SQLiteDataAdapter(query, con)
                    da.Fill(ds, "collectibles")
                    If ds.Tables("collectibles").Rows.Count <> 0 Then
                        For z = 1 To ds.Tables("collectibles").Rows.Count Step 1
                            If CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("collected_amt").ToString)) = _
                               CDbl(StrToNum(ds.Tables("collectibles").Rows(z - 1).Item("payable_amt").ToString)) Then
                                rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET penalty_status = 2 WHERE ctb_id =" & _
                                                         ds.Tables("collectibles").Rows(z - 1).Item("ctb_id").ToString)
                            End If
                        Next
                    End If
                    '---------------------here's penalty status? new codes added -----------------

                    dr = db.ExecuteReader("SELECT penalty_status,payable_amt , previous_balance, collected_amt FROM tbl_collectibles WHERE due_date = '" & _
                                          Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & "' AND " & _
                                          "loan_id = " & lvCollectibles.Items(x - 1).Text)
                    
                    If dr.Item("penalty_status").ToString = "0" And CDbl(StrToNum(dr.Item("payable_amt").ToString)) + CDbl(StrToNum(dr.Item("previous_balance").ToString)) = _
                        CDbl(StrToNum(dr.Item("collected_amt").ToString)) Then
                        rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET penalty_status = 2 WHERE due_date = '" & _
                                          Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & "' AND " & _
                                          "loan_id = " & lvCollectibles.Items(x - 1).Text)
                    End If
                    '-------------------------------end of added code----------------------------'
                    '
                    'get min for previousbal
                    'tignan natin here kung equal or greater than na ang last payment nya at kapag ganoon loan status will equal
                    'to 2 means COMPLETED. code starts here
                    'store the ID

                    'data.Add("collected_amt",) computationS
                    dr = db.ExecuteReader("SELECT max(due_date) as petsa, max(ctb_id) as high,payable_amt, collected_amt, previous_balance, penalty_amt,penalty_status  FROM tbl_collectibles WHERE due_date >= '" & _
                                             Format(CDate(lvCollectibles.Items(x - 1).SubItems(1).Text), "yyyyMMdd") & "' AND loan_id= " & _
                                             lvCollectibles.Items(x - 1).Text)

                    If dr.HasRows Then
                        If dr.Item("petsa").ToString <> "" Then
                            If dr.Item("penalty_status").ToString = 1 Then
                                If CDbl(StrToNum(dr.Item("collected_amt").ToString)) = CDbl(StrToNum(dr.Item("payable_amt").ToString)) _
                                        + CDbl(StrToNum(dr.Item("penalty_amt").ToString)) + CDbl(StrToNum(dr.Item("previous_balance").ToString)) Then
                                    rec = db.ExecuteNonQuery("UPDATE tbl_loans SET loan_status = 2  WHERE loan_id =" & lvCollectibles.Items(x - 1).Text)
                                End If
                            Else
                                If CDbl(StrToNum(dr.Item("collected_amt").ToString)) = CDbl(StrToNum(dr.Item("payable_amt").ToString)) _
                                         + CDbl(StrToNum(dr.Item("previous_balance").ToString)) Then
                                    rec = db.ExecuteNonQuery("UPDATE tbl_loans SET loan_status =2  WHERE loan_id =" & lvCollectibles.Items(x - 1).Text)
                                End If
                            End If
                        End If

                    End If
                    ds.Clear()
                    con.Close()
                Next

                ShowData()
                MsgBox("Process completed!", MsgBoxStyle.Information, "EMS")
            End If
        End If
        Cursor = Cursors.Arrow

        'Catch ex As Exception
        '    MsgBox(ex.ToString, MsgBoxStyle.Critical)
        'Finally
        '    db.Dispose()
        '    con.Dispose() ' pag may error eto lang huli kong dinagdag
        'End Try



        'try catch don't forget

        'END of VERSION 2


    End Sub

  



    Private Sub lvDuedates_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lvDuedates.ItemChecked
        'plan b refresh icon sa tabi o sa baba ni amount
        ' saka na itu
        On Error GoTo brgy
        Dim val, val3 As Double
        val = 0

        val3 = 0
        payableAmount = CDbl(lvCollectibles.FocusedItem.SubItems(3).Text) - CDbl(lvCollectibles.FocusedItem.SubItems(6).Text)
        If gbxClientCollectible.Enabled = True Then '
            For x = 1 To lvDuedates.Items.Count Step 1


                If lvDuedates.Items(x - 1).Checked = True Then
                    val += lvDuedates.Items(x - 1).SubItems(1).Text
                End If
            Next
            val3 = payableAmount + val

            

            lblPayableAmount.Text = val3
        End If
        Exit Sub

brgy:
        ' MsgBox("yo!")
        Exit Sub
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
                            penalty += CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                        End If
                        txtTotalPenalties.Text = penalty
                        If Not txtTotalPenalties.Text.Contains(".") Then
                            txtTotalPenalties.Text &= ".00"
                        End If
                    Loop

                End If
                'balance calculate terms left also please get the gross amt :D
                dr = db.ExecuteReader("SELECT principal, terms, interest_percentage,date_end, date_start FROM tbl_loans WHERE loan_id=" & lvCollectibles.FocusedItem.Text)


                principal = CDbl(StrToNum(dr.Item("principal").ToString))
                monthlyRate = principal / (CInt(dr.Item("terms").ToString) * 2)
                biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
                interest = principal * biMonInterest
                totalPaymentBiMonth = monthlyRate + interest
                rembal = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
                txtTerms.Text = dr.Item("terms").ToString
                txtDateStart.Text = StrToDate(dr.Item("date_start").ToString)
                txtDateEnd.Text = StrToDate(dr.Item("date_end").ToString)
                showPaymentHistory(True)
                dr = db.ExecuteReader("SELECT payment_id, date_stamp ,  tbl_payments.ctb_id, amount,payment_status FROM tbl_payments " & _
                                      "INNER JOIN tbl_collectibles on tbl_payments.ctb_id = tbl_collectibles.ctb_id " & _
                                      " WHERE tbl_collectibles.loan_id=" & txtLoanid.Text)

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
        cbxCompany.Items.Clear()
        cbxBranch.Items.Clear()

        dr = db.ExecuteReader("SELECT company_name,company_id FROM tbl_company")
        If dr.HasRows Then
            Do While dr.Read
                cbxCompany.Items.Add(dr.Item("company_name").ToString & "                                                             #" & dr.Item("company_id").ToString)
            Loop
        End If
        cbxCompany.Sorted = True


        showAdvanceSearch(True)
        db.Dispose()
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



    Private Sub btnEnterPay_Click(sender As Object, e As EventArgs) Handles btnEnterPay.Click
        If lvCollectibles.SelectedItems.Count > 0 Then
            lvCollectibles_DoubleClick(sender, e)
        Else
            MsgBox("No selected data.", vbExclamation + vbOKOnly, "Please select a record.")
        End If
    End Sub







    Private Sub cbxCompany_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCompany.SelectedIndexChanged

    End Sub



    Private Sub cbxBranch_Click(sender As Object, e As EventArgs) Handles cbxBranch.Click
        cbxBranch.Items.Clear()
        If cbxCompany.Text = "" Then
            MsgBox("Please choose a company before the branch", MsgBoxStyle.Exclamation + vbOKOnly)
            Exit Sub
        Else
            Dim cID() As String
            cID = Split(cbxCompany.Text, "#")
            dr = db.ExecuteReader("SELECT branch_name,branch_id FROM tbl_branches WHERE company_id = '" & cID(1) & "'")

            If dr.HasRows Then
                Do While dr.Read
                    cbxBranch.Items.Add(dr.Item("branch_name").ToString & "                                                             #" & dr.Item("branch_id").ToString)
                Loop

            End If
            cbxBranch.Sorted = True
        End If
        db.Dispose()
    End Sub


    Private Sub cbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged

    End Sub




    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            If cbxCompany.Text = "" Then
                MsgBox("Please choose at least company to filter", MsgBoxStyle.Exclamation + vbOKOnly, "Blank fields")
                Exit Sub
            Else
                lvCollectibles.Items.Clear()
                con.ConnectionString = My.Settings.ConnectionString
                cID = Split(cbxCompany.Text, "#")
                If cbxBranch.Text = "" Then
                    query = "SELECT ctb_id,tblCol.loan_id as LoanID, MAX(due_date) as petsa, last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
                        "payable_amt, previous_balance, principal, date_start, date_end , interest_percentage,collected_amt,terms, penalty_status,penalty_amt " & _
                        "FROM  (SELECT ctb_id , loan_id , due_date , payable_amt, previous_balance,collected_amt,penalty_status,penalty_amt " & _
                    "FROM tbl_collectibles  WHERE due_date <= '" & Format(Date.Now, "yyyyMMdd") & "') as tblCol " & _
                    "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
                    "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id INNER JOIN tbl_branches ON tbl_clients.branch_id " & _
                    "= tbl_branches.branch_id WHERE " & _
                    "tbl_loans.loan_status = 1 AND company_id = " & cID(1) & " GROUP BY tblCol.loan_id"
                Else
                    bID = Split(cbxBranch.Text, "#")
                    query = "SELECT ctb_id,tblCol.loan_id as LoanID, MAX(due_date) as petsa, last_name || ', ' || first_name || ' ' || middle_name as Name, " & _
                        "payable_amt, previous_balance, principal, date_start, date_end , interest_percentage,collected_amt,terms, penalty_status,penalty_amt " & _
                        "FROM  (SELECT ctb_id , loan_id , due_date , payable_amt, previous_balance,collected_amt,penalty_status,penalty_amt " & _
                    "FROM tbl_collectibles  WHERE due_date <= '" & Format(Date.Now, "yyyyMMdd") & "') as tblCol " & _
                    "INNER JOIN tbl_loans ON tbl_loans.loan_id = tblCol.loan_id INNER JOIN " & _
                    "tbl_clients ON tbl_loans.client_id = tbl_clients.client_id INNER JOIN tbl_branches ON tbl_clients.branch_id " & _
                    "= tbl_branches.branch_id WHERE " & _
                    "tbl_loans.loan_status = 1 AND company_id = " & cID(1) & " AND tbl_branches.branch_id = " & bID(1) & " GROUP BY tblCol.loan_id"
                End If


                da = New SQLite.SQLiteDataAdapter(query, con)
                da.Fill(ds, "collectibles")
                For x = 1 To ds.Tables("collectibles").Rows.Count Step 1
                    'kapag equal dapat next date
                    Select Case ds.Tables("collectibles").Rows(x - 1).Item("penalty_status").ToString

                        Case 2
                            If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) _
                                + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("previous_balance").ToString)) Then
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
                        Case 1
                            If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) _
                                 + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("previous_balance").ToString)) + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("penalty_amt").ToString)) Then
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

                            If CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("collected_amt").ToString)) = CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("payable_amt").ToString)) _
                            + CDbl(StrToNum(ds.Tables("collectibles").Rows(x - 1).Item("previous_balance").ToString)) Then
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
                    'convert all value to currency
                    For z = 1 To lvCollectibles.Items.Count Step 1
                        lvCollectibles.Items(z - 1).SubItems(4).Text = CDbl(lvCollectibles.Items(z - 1).SubItems(4).Text)
                        lvCollectibles.Items(z - 1).SubItems(7).Text = CDbl(lvCollectibles.Items(z - 1).SubItems(7).Text)
                        lvCollectibles.Items(z - 1).SubItems(9).Text = CDbl(lvCollectibles.Items(z - 1).SubItems(9).Text)
                        If Not lvCollectibles.Items(z - 1).SubItems(4).Text.Contains(".") Then
                            lvCollectibles.Items(z - 1).SubItems(4).Text &= ".00"
                        End If
                        If Not lvCollectibles.Items(z - 1).SubItems(7).Text.Contains(".") Then
                            lvCollectibles.Items(z - 1).SubItems(7).Text &= ".00"
                        End If
                        If Not lvCollectibles.Items(z - 1).SubItems(8).Text.Contains(".") Then
                            lvCollectibles.Items(z - 1).SubItems(8).Text &= ".00"
                        End If
                        If Not lvCollectibles.Items(z - 1).SubItems(9).Text.Contains(".") Then
                            lvCollectibles.Items(z - 1).SubItems(9).Text &= ".00"
                        End If

                    Next
                    'payable amount , penalty , previous balance kung meron
                    Dim pangIlan As Integer
                    Dim penaltyVal As Double


                    pangIlan = 0

                    penaltyVal = 0

                    For y = 1 To lvCollectibles.Items.Count Step 1
                        dr = db.ExecuteReader("SELECT * FROM tbl_collectibles WHERE loan_id = " & lvCollectibles.Items(y - 1).SubItems(0).Text & _
                                              " ORDER BY due_date ASC")
                        If dr.HasRows Then

                            Do While dr.Read
                                dueDate = StrToDate(dr.Item("due_date").ToString)

                                If dueDate = lvCollectibles.Items(y - 1).SubItems(1).Text Then
                                    If dr.Item("penalty_status").ToString = 0 Then
                                        concats &= dr.Item("ctb_id").ToString
                                    End If
                                    lvCollectibles.Items(y - 1).SubItems(7).Text = CDbl(StrToNum(dr.Item("previous_balance").ToString))
                                    If dr.Item("penalty_status").ToString = 1 Or dr.Item("penalty_status").ToString = 2 Then
                                        lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal
                                        lvCollectibles.Items(y - 1).SubItems(3).Text = CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal
                                    Else
                                        If dueDate >= CDate(Format(Date.Now, "MM/dd/yyyyy")) Then
                                            lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal
                                            lvCollectibles.Items(y - 1).SubItems(3).Text = CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + penaltyVal
                                        Else
                                            lvCollectibles.Items(y - 1).SubItems(6).Text = penaltyVal + CDbl(StrToNum(dr.Item("penalty_amt").ToString))
                                            lvCollectibles.Items(y - 1).SubItems(3).Text = CDbl(StrToNum(dr.Item("payable_amt").ToString)) + lvCollectibles.Items(y - 1).SubItems(7).Text + CDbl(StrToNum(dr.Item("penalty_amt").ToString)) + penaltyVal
                                        End If
                                    End If
                                    lvCollectibles.Items(y - 1).SubItems(11).Text = concats
                                    If Not lvCollectibles.Items(y - 1).SubItems(3).Text.Contains(".") Then
                                        lvCollectibles.Items(y - 1).SubItems(3).Text &= ".00"
                                    End If
                                    If Not lvCollectibles.Items(y - 1).SubItems(6).Text.Contains(".") Then
                                        lvCollectibles.Items(y - 1).SubItems(6).Text &= ".00"
                                    End If
                                    If Not lvCollectibles.Items(y - 1).SubItems(7).Text.Contains(".") Then
                                        lvCollectibles.Items(y - 1).SubItems(7).Text &= ".00"
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
                con.Close()
            End If
            If cbxBranch.Text <> "" Then
                lblInfoSearch.Text = Trim(cID(0)) & " >>> " & Trim(bID(0))
            Else
                lblInfoSearch.Text = Trim(cID(0))
            End If

            showAdvanceSearch(False)


        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
    End Sub


    Private Sub cbxCompany_TextChanged(sender As Object, e As EventArgs) Handles cbxCompany.TextChanged
        cbxBranch.Items.Clear()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        'with excel

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim row As DataRow = Nothing
        Dim DS As New DataSet
        Dim rptPaymentCentral As New PaymentCentral
        'ADD A TABLE TO THE DATASET
        DS.Tables.Add("ListViewData")
        'ADD THE COLUMNS TO THE TABLE
        With DS.Tables(0).Columns
            .Add("loan_ID")
            .Add("Due_date")
            .Add("Name")
            .Add("Payable_amount")
            .Add("Collected_amount")
            .Add("Inputted_amount")
            .Add("Penalty_amount")
            .Add("Previous_balance")
            .Add("Principal_amount")
            .Add("Interest")

        End With

        'LOOP THE LISTVIEW AND ADD A ROW TO THE TABLE FOR EACH LISTVIEWITEM
        For x = 1 To lvCollectibles.Items.Count
            row = DS.Tables(0).NewRow
            row(0) = lvCollectibles.Items(x - 1).Text
            row(1) = lvCollectibles.Items(x - 1).SubItems(1).Text
            row(2) = lvCollectibles.Items(x - 1).SubItems(2).Text
            row(3) = lvCollectibles.Items(x - 1).SubItems(3).Text
            row(4) = lvCollectibles.Items(x - 1).SubItems(4).Text
            row(5) = lvCollectibles.Items(x - 1).SubItems(5).Text
            row(6) = lvCollectibles.Items(x - 1).SubItems(6).Text
            row(7) = lvCollectibles.Items(x - 1).SubItems(7).Text
            row(8) = lvCollectibles.Items(x - 1).SubItems(8).Text
            row(9) = lvCollectibles.Items(x - 1).SubItems(9).Text
            DS.Tables(0).Rows.Add(row)

        Next
        DS.WriteXml("XML\ListViewData.xml")

        Dim dsListViewData As New DataSet
        dsListViewData = New DSreports
        Dim dsListViewDataTemp As New DataSet
        dsListViewDataTemp = New DataSet()
        showPrintAttack(True)
        dsListViewDataTemp.ReadXml("XML\ListViewData.xml")
        dsListViewData.Merge(dsListViewDataTemp.Tables(0))
        rptPaymentCentral = New PaymentCentral
        rptPaymentCentral.SetDataSource(dsListViewData)
        crvPaymentCentralReport.ReportSource = rptPaymentCentral


    End Sub

    
    Private Sub btnPrintCR_Click(sender As Object, e As EventArgs) Handles btnPrintCR.Click
        crvPaymentCentralReport.PrintReport()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showPrintAttack(False)
    End Sub

    Private Sub lvCollectibles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvCollectibles.SelectedIndexChanged

    End Sub

    Private Sub lvPH_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvPH.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwColumnSorter1.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter1.Order = SortOrder.Ascending) Then
                lvwColumnSorter1.Order = SortOrder.Descending
            Else
                lvwColumnSorter1.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter1.SortColumn = e.Column
            lvwColumnSorter1.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.lvPH.Sort()
    End Sub
    
  
    Private Sub lvDuedates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvDuedates.SelectedIndexChanged

    End Sub
End Class