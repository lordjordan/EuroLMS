Public Class MainMenu
  

    'Dim dateFrom, getLastmonth As DateTime

    Dim splitter() As String



    '### Change the "Data Source" path to point to our own LMS Database
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim rec As Integer
    Dim data As New Dictionary(Of String, Object)

    'adjustments
    Dim previousBalance As Double

    Dim conV As String
    Dim con As New SQLite.SQLiteConnection
    Dim ds, ds1 As New DataSet
    Dim da, da1 As SQLite.SQLiteDataAdapter
    Dim query, query1 As String
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        
        Cursor = Cursors.WaitCursor
        Label1.Parent = PictureBox1
        lblTime.Parent = PictureBox1
        lblDate.Parent = PictureBox1
        con.ConnectionString = My.Settings.ConnectionString
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
            'update ng previous balance para kung hindi na process ang last payments nya, yun nasalisihan

            For x = 1 To ds.Tables("collectibles").Rows.Count Step 1
                previousBalance = 0
                query1 = "SELECT ctb_id, previous_balance, payable_amt, penalty_status, penalty_amt, collected_amt FROM tbl_collectibles WHERE loan_id = " & _
                    ds.Tables("collectibles").Rows(x - 1).Item("LoanID").ToString & ""
                'MsgBox(ds.Tables("collectibles").Rows(x - 1).Item("previ").ToString)
                da1 = New SQLite.SQLiteDataAdapter(query1, con)
                da1.Fill(ds1, "z")
                For z = 1 To ds1.Tables("z").Rows.Count Step 1
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
                    ds1.Tables("z").Rows(z - 1).Item("previous_balance") = splitter(0) & splitter(1)
                    data.Add("previous_balance", splitter(0) & splitter(1))

                    rec = db.ExecuteNonQuery("UPDATE tbl_collectibles SET  previous_balance=@previous_balance " & _
                                         " WHERE ctb_id=" & ds1.Tables("z").Rows(z - 1).Item(0), data)
                    data.Clear()
                    If ds1.Tables("z").Rows(z - 1).Item("penalty_status").ToString = 1 Then

                        If CDbl(ds1.Tables("z").Rows(z - 1).Item("collected_amt").ToString.Insert(6, ".")) = CDbl(ds1.Tables("z").Rows(z - 1).Item("payable_amt").ToString.Insert(6, ".")) _
                                              + CDbl(ds1.Tables("z").Rows(z - 1).Item("previous_balance").ToString.Insert(6, ".")) Then
                            previousBalance += 0
                        Else
                            previousBalance += (CDbl(ds1.Tables("z").Rows(z - 1).Item("payable_amt").ToString.Insert(6, ".")) + _
                            CDbl(ds1.Tables("z").Rows(z - 1).Item("penalty_amt").ToString.Insert(6, "."))) - CDbl(ds1.Tables("z").Rows(z - 1).Item("collected_amt").ToString.Insert(6, "."))
                        End If

                    Else
                        If CDbl(ds1.Tables("z").Rows(z - 1).Item("collected_amt").ToString.Insert(6, ".")) = CDbl(ds1.Tables("z").Rows(z - 1).Item("payable_amt").ToString.Insert(6, ".")) Then
                            previousBalance += 0
                        Else
                            previousBalance += (CDbl(ds1.Tables("z").Rows(z - 1).Item("payable_amt").ToString.Insert(6, "."))) - CDbl(ds1.Tables("z").Rows(z - 1).Item("collected_amt").ToString.Insert(6, "."))
                        End If

                    End If

                Next
                ds1.Clear()


            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        Finally
            db.Dispose()
        End Try
        Cursor = Cursors.Arrow
    End Sub

    Private Sub tmrTimeDate_Tick(sender As Object, e As EventArgs) Handles tmrTimeDate.Tick
        tmrTimeDate.Enabled = False
        'lblDate.Text = Now.DayOfWeek.ToString & ", " & Now.Day.ToString & " " & Now.mo.ToString
        lblTime.Text = Format(Now, "long time") 'Now.Hour.ToString & ":" & Now.Minute.ToString
        'lblDate.Text = Format(Now, "dddd, d MMMM")
        lblDate.Text = Format(Now, "long date")

        tmrTimeDate.Enabled = True
    End Sub


    Private Sub btnCollectibles_Click(sender As Object, e As EventArgs) Handles btnCollectibles.Click
        'uscCollectibles = New frmCollectibles
        showUSC(uscCollectibles)

        'uscCollectibles.ShowData()
    End Sub

    Private Sub btnSystemUser_Click(sender As Object, e As EventArgs)
        showUSC(uscSystemUser)
    End Sub

    Private Sub btnLoans_Click(sender As Object, e As EventArgs) Handles btnLoans.Click
        showUSC(uscLoans)
        uscLoans.lvLoanList.Items.Clear()
        Using db As New DBHelper(My.Settings.ConnectionString)
            Dim dr As SQLite.SQLiteDataReader
            dr = db.ExecuteReader("select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, application_status, loan_status, loan_remarks, company_name, branch_name " & _
                                "from tbl_loans L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_status= 1 or loan_status= 0 or loan_status = 3")

            If dr.HasRows Then
                Do While dr.Read
                    Dim itmx As ListViewItem = uscLoans.lvLoanList.Items.Add(dr.Item("loan_id").ToString)
                    itmx.SubItems.Add(dr.Item("name").ToString)
                    itmx.SubItems.Add(FormatNumber(StrToNum(dr.Item("principal").ToString), 2))
                    itmx.SubItems.Add(FormatNumber(StrToNum(dr.Item("amortization").ToString), 2))
                    itmx.SubItems.Add(dr.Item("interest_percentage").ToString)
                    itmx.SubItems.Add(dr.Item("terms").ToString)
                    itmx.SubItems.Add(StrToDate(dr.Item("date_start").ToString))
                    itmx.SubItems.Add(StrToDate(dr.Item("date_end").ToString))
                    itmx.SubItems.Add(uscLoans.cboApplicationStatus.Items(dr.Item("application_status").ToString))
                    itmx.SubItems.Add(uscLoans.cboLoanStatus.Items(dr.Item("loan_status").ToString))
                    itmx.SubItems.Add(dr.Item("loan_remarks").ToString)
                    itmx.SubItems.Add(dr.Item("company_name").ToString)
                    itmx.SubItems.Add(dr.Item("branch_name").ToString)


                Loop
            End If
        End Using
    End Sub

    Private Sub btnClients_Click(sender As Object, e As EventArgs)
        showUSC(uscClients)
    End Sub

    Private Sub btnBranches_Click(sender As Object, e As EventArgs)
        showUSC(uscBranches)
    End Sub

    Private Sub btnAttachments_Click(sender As Object, e As EventArgs)
        showUSC(uscAttachments)
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Application.Exit()
    End Sub

    Private Sub btnClients_Click_1(sender As Object, e As EventArgs) Handles btnClients.Click
        showUSC(uscClients)
    End Sub

    Private Sub btnBranches_Click_1(sender As Object, e As EventArgs) Handles btnBranches.Click
        showUSC(uscBranches)
    End Sub

    Private Sub btnCompany_Click(sender As Object, e As EventArgs) Handles btnCompany.Click
        showUSC(uscCompanies)
    End Sub

    Private Sub btnSystemUser_Click_1(sender As Object, e As EventArgs) Handles btnSystemUser.Click
        showUSC(uscSystemUser)
    End Sub

    Private Sub btnAttachments_Click_1(sender As Object, e As EventArgs) Handles btnAttachments.Click
        showUSC(uscAttachments)
    End Sub

    Private Sub btnExtra_Click(sender As Object, e As EventArgs) Handles btnExtra.Click
        showUSC(uscExtra)
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        showUSC(uscPaymentHistory)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmReports.Show()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        If MsgBox("Create Backup of database?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Database Backup") = MsgBoxResult.Yes Then

            Dim FileToCopy As String
            Dim NewCopy As String

            FileToCopy = My.Settings.DB_location 'address 
            NewCopy = My.Settings.BU_location & "LMSbackup" & DateToStr(Date.Now) & ".s3db"
            Try
                If System.IO.File.Exists(FileToCopy) = True Then
                    If System.IO.File.Exists(NewCopy) Then
                        If MsgBox("Existing backup file will be overwritten. Continue?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Overwrite Backup") = MsgBoxResult.Ok Then
                            System.IO.File.Copy(FileToCopy, NewCopy, True)
                            log("Database backup created")
                            MsgBox("Database backup complete.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Backup Complete")
                        Else
                            Exit Sub
                        End If

                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class
