Public Class PaymentHistory
    Dim itm As ListViewItem
    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim colorChanger As Boolean

    Public principal, monthlyRate, totalPaymentBiMonth, collectedAmount, rembal As Double
    Public biMonInterest As Decimal
    Public interest As Double
    Dim ctr As Integer
    Dim conV As String


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
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

    End Sub

    

    Private Sub btnClientBack_Click(sender As Object, e As EventArgs) Handles btnClientBack.Click
        showClient(False)
    End Sub


    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click
        Try
            lvClientList.Items.Clear()
            colorChanger = False
            dr = db.ExecuteReader("SELECT employee_no ,tbl_clients.client_id as clientid, tbl_loans.loan_id as loanid, " & _
                                  "last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                  "principal, company_name, branch_name FROM tbl_loans INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id " & _
                                  "INNER JOIN tbl_branches ON tbl_clients.branch_id = tbl_branches.branch_id INNER JOIN tbl_company ON tbl_branches.company_id= " & _
                                  "tbl_company.company_id " & _
                                  "WHERE tbl_loans.loan_id LIKE  '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or first_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or last_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or middle_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or branch_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or company_name LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or tbl_clients.client_id LIKE '%" & txtSearchLoan.Text.Trim & "%' " & _
                                          " or employee_no LIKE '%" & txtSearchLoan.Text.Trim & "%' ")
            If dr.HasRows Then
                Do While dr.Read
                    itm = lvClientList.Items.Add(dr.Item("employee_no").ToString)
                    itm.SubItems.Add(dr.Item("clientid").ToString)
                    itm.SubItems.Add(dr.Item("loanid").ToString)
                    itm.SubItems.Add(dr.Item("name").ToString)
                    itm.SubItems.Add(CDbl(dr.Item("principal").ToString.Insert(6, ".")))
                    itm.SubItems.Add(dr.Item("company_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_name").ToString)
                    If colorChanger = True Then
                        itm.BackColor = Color.LemonChiffon
                        colorChanger = False
                    Else
                        itm.BackColor = Color.LightCyan
                        colorChanger = True
                    End If

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

    Private Sub btnViewLoan_Click(sender As Object, e As EventArgs) Handles btnViewLoan.Click
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
            If lvClientList.SelectedItems.Count > 0 Then


                dr = db.ExecuteReader("Select tbl_loans.loan_id as loanid, payment_id, last_name || ', ' || first_name || ' ' || middle_name as name, " & _
                                      "date_stamp , amount FROM tbl_payments INNER JOIN tbl_loans ON tbl_payments.loan_id = tbl_loans.loan_id " & _
                                      "INNER JOIN tbl_clients ON tbl_loans.client_id = tbl_clients.client_id WHERE tbl_loans.loan_id = " & _
                                      lvClientList.FocusedItem.SubItems(2).Text)
                Do While dr.Read

                    itm = lvPH.Items.Add(dr.Item("payment_id").ToString)
                    itm.SubItems.Add(StrToDate(dr.Item("date_stamp").ToString))
                    itm.SubItems.Add(CDbl(dr.Item("amount").ToString.Insert(6, ".")))
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
                txtLoanid.Text = lvClientList.FocusedItem.SubItems(2).Text
                txtname.Text = lvClientList.FocusedItem.SubItems(3).Text

                dr = db.ExecuteReader("SELECT principal, terms, interest_percentage, date_end FROM tbl_loans WHERE loan_id =" & lvClientList.FocusedItem.SubItems(2).Text)


                principal = CDbl(dr.Item("principal").Insert(6, ".").ToString)
                monthlyRate = principal / (CInt(dr.Item("terms").ToString) * 2)
                biMonInterest = (CInt(dr.Item("interest_percentage").ToString) / 100) / 2
                interest = principal * biMonInterest
                totalPaymentBiMonth = monthlyRate + interest
                rembal = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
                txtPrincipalAmt.Text = principal
                txtTerms.Text = dr.Item("terms").ToString
                txtTotalLoanAmount.Text = totalPaymentBiMonth * (CInt(dr.Item("terms").ToString) * 2)
                txtDateEnd.Text = StrToDate(dr.Item("date_end").ToString)
                conV = collectedAmount
                If Not conV.Contains(".") Then
                    conV &= ".00"
                End If
                txtCollectedAmt.Text = conV
                txtBalance.Text = rembal - CDbl(txtCollectedAmt.Text)
                If Not txtBalance.Text.Contains(".") Then
                    txtBalance.Text &= ".00"
                End If
                If Not txtPrincipalAmt.Text.Contains(".") Then
                    txtPrincipalAmt.Text &= ".00"
                End If
                If Not txtTotalLoanAmount.Text.Contains(".") Then
                    txtTotalLoanAmount.Text &= ".00"
                End If
                'terms left
            Else
                MsgBox("Please select a loan", MsgBoxStyle.Exclamation + vbOKOnly)
            End If
            conV = ""
            rembal = 0

            ctr = 0
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

   
End Class
