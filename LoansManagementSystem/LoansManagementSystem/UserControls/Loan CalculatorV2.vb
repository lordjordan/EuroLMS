Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Xml


Public Class Loan_CalculatorV2
    Dim active_loan_id As Long = 0
    Dim isLOADING As Boolean = False
    Dim RPTCalculator As New LoanCalculator

    Private Sub computeTotalLoan()
        If Val(txtTerms.Text) < 1 Or Val(cboInterest.Text) <= 0 Or Val(txtPrincipal.Text) < 1 Or _
            Not IsNumeric(txtPrincipal.Text) Or _
            Not IsNumeric(cboInterest.Text) Or _
            Not IsNumeric(txtTerms.Text) Or _
            isLOADING Then
            txtTotalLoanAmount.Text = 0
            txtTotalInterest.Text = 0
            txtMonthlyInterest.Text = 0
            txtBiMonthlyAmort.Text = 0

            Exit Sub
        End If

        Dim TotalLoanAmount As Double = 0
        Dim TotalInterest As Double = 0
        Dim principal As Long, interest_rate As Double, terms As Integer

        principal = Val(txtPrincipal.Text)
        interest_rate = Val(cboInterest.Text) / 100
        terms = Val(txtTerms.Text)
        TotalInterest = (principal * interest_rate * terms)
        TotalLoanAmount = principal + TotalInterest

        txtTotalLoanAmount.Text = FormatNumber(TotalLoanAmount, 2)
        txtTotalInterest.Text = FormatNumber(TotalInterest, 2)
        txtMonthlyInterest.Text = FormatNumber(Val(TotalInterest / terms), 2)
        txtBiMonthlyAmort.Text = FormatNumber((TotalLoanAmount / terms / 2), 2)
    End Sub

    Private Sub clearClientProfileBox()
        'For Each Control In gbxAddEdit.Controls
        '    If TypeOf Control Is TextBox Then
        '        Control.Text = ""     'Clear all text
        '    End If
        'Next Control

        For Each Control In Me.Controls
            If TypeOf Control Is TextBox Then
                Control.Text = ""     'Clear all text
            End If
        Next Control

        'For Each Control In gbxLoanData2.Controls
        '    If TypeOf Control Is TextBox Then
        '        Control.Text = ""     'Clear all text
        '    End If
        'Next Control
    End Sub
    Private Sub showReport(mode As Boolean)
        gbxPreview.Visible = mode
        gbxPreview.Enabled = mode
        gbxAddEdit.Enabled = Not mode
    End Sub

    Private Function validateInputs() As Boolean

        If txtPrincipal.Text.Trim = "" Then
            MsgBox("Cannot save this record. Please put a value for principal first.", MsgBoxStyle.Critical, "New Loan Application - Error")
            txtPrincipal.Select()
            Return False
        End If

        If cboInterest.Text.Trim = "" Then
            MsgBox("Cannot save this record. Please put an interest rate first.", MsgBoxStyle.Critical, "New Loan Application - Error")
            cboInterest.Select()
            Return False
        End If

        If txtTerms.Text.Trim = "" Then
            MsgBox("Cannot save this record. Please put a value for terms first.", MsgBoxStyle.Critical, "New Loan Application - Error")
            txtTerms.Select()
            Return False
        End If

        If Val(txtTotalLoanAmount.Text.Trim) = 0 Then
            MsgBox("Cannot save this record. Please put a valid loan.", MsgBoxStyle.Critical, "New Loan Application - Error")
            txtPrincipal.Select()
            Return False
        End If
        Return True
    End Function


    'Private Sub toggleClientSearch(Optional mode As Boolean = False)
    '    gbxShowClient.Visible = mode
    '    gbxShowClient.Enabled = mode
    '    If mode Then
    '        gbxShowClient.BringToFront()
    '    Else
    '        gbxShowClient.SendToBack()
    '    End If

    '    gbxClientData.Enabled = Not mode

    'End Sub

    'Private Sub toggleLoanApplication(Optional mode As Boolean = False)
    '    gbxAddEdit.Visible = mode
    '    gbxAddEdit.Enabled = mode
    '    If mode Then
    '        gbxAddEdit.BringToFront()
    '    Else
    '        gbxAddEdit.SendToBack()
    '    End If

    '    gbxAddEdit.Enabled = Not mode

    '    pnlMain.Enabled = Not mode
    'End Sub

    'Private Sub toggleVerifyActivation(Optional mode As Boolean = False)
    '    gbxVerifyActivation.Visible = mode
    '    gbxVerifyActivation.Enabled = mode
    '    If mode Then
    '        gbxVerifyActivation.BringToFront()
    '    Else
    '        gbxVerifyActivation.SendToBack()
    '    End If

    '    gbxClientData.Enabled = Not mode

    '    pnlMain.Enabled = Not mode
    'End Sub
    'Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    '    toggleLoanApplication()
    'End Sub

    'Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    If validateInputs() = False Then Exit Sub

    '    If gbxAddEdit.Text = "New Loan Application" Then
    '        saveNewForm()
    '    Else
    '        saveEditForm()
    '    End If

    '    saveCollectibles()

    '    MsgBox("Record saved!", MsgBoxStyle.Information)
    '    toggleLoanApplication()
    '    LoadListView()
    '    'toggleLoanApplication()
    'End Sub

    Private Function computeLateFee(principal As Double) As String
        Dim fee As String = "0"
        If principal <= 10000 Then
            fee = "300.00"
        ElseIf principal <= 20000 Then
            fee = "400.00"
        Else
            fee = "500.00"
        End If

        Return fee

    End Function
    Private Sub saveCollectibles()
        If gbxAddEdit.Text = "Edit Loan Application" Then
            'Dim ddate(DataGridView1.RowCount - 1) As DueDateObj
            Using db1 As New DBHelper(My.Settings.ConnectionString)
                'Dim dr As SQLite.SQLiteDataReader
                Dim rec As Integer
                Try
                    Dim data As New Dictionary(Of String, Object)
                    data.Add("loan_id", active_loan_id)
                    rec = db1.ExecuteNonQuery("delete from tbl_collectibles where loan_id = @loan_id", data)
                Catch ex As Exception

                End Try
            End Using

        End If

        Dim rows As Byte = DataGridView1.RowCount - 1
        For i = 0 To rows - 1
            Using db2 As New DBHelper(My.Settings.ConnectionString)
                Dim rec As Integer
                Try
                    Dim data As New Dictionary(Of String, Object)
                    data.Add("loan_id", active_loan_id)
                    data.Add("due_date", DateToStr(Format(DataGridView1.Item(1, i).Value, "short date")))
                    data.Add("payable_amt", NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2)))
                    data.Add("collected_amt", "000000000000")
                    data.Add("penalty_amt", NumToStr(computeLateFee(Val(txtPrincipal.Text.Trim.Replace(",", "")))))
                    data.Add("penalty_status", "0")
                    data.Add("previous_balance", "000000000000")

                    rec = db2.ExecuteNonQuery("insert into tbl_collectibles values(NULL, @loan_id, @due_date, @payable_amt, " & _
                                             "@collected_amt, @penalty_amt, @penalty_status, @previous_balance) ", data)

                    If Not rec < 1 Then

                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    db2.Dispose()
                End Try

            End Using
        Next

    End Sub
    Private Sub saveNewForm()
        Using db As New DBHelper(My.Settings.ConnectionString)
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Try

                'data.Add("client_id", txtClientID.Text)
                data.Add("principal", NumToStr(FormatNumber(txtPrincipal.Text, 2)))
                data.Add("amortization", NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2)))
                data.Add("date_start", Format(dtStart.Value, "yyyyMMdd"))
                data.Add("date_end", Format(dtEnd.Value, "yyyyMMdd"))
                data.Add("interest_percentage", cboInterest.Text)
                data.Add("date_approved", "00000000")
                data.Add("date_enrolled", Format(Now, "yyyyMMdd"))
                data.Add("terms", Val(txtTerms.Text))


                rec = db.ExecuteNonQuery("insert into tbl_loans values(NULL, @client_id, @principal, @amortization, @date_start, @date_end, " & _
                                         "@interest_percentage, @date_approved, @date_enrolled , @terms, @application_status, @loan_status, " & _
                                         "@loan_remarks)", data)

                If Not rec < 1 Then
                    'MsgBox("Record saved!", MsgBoxStyle.Information)
                    'toggleLoanApplication()
                    'LoadListView()
                    Dim dr As SQLite.SQLiteDataReader
                    dr = db.ExecuteReader("select max(loan_id) as id from tbl_loans")
                    active_loan_id = dr.Item("id")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose()
            End Try

        End Using
    End Sub

    Private Sub saveEditForm()
        Using db As New DBHelper(My.Settings.ConnectionString)
            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Try

                ' data.Add("client_id", txtClientID.Text)
                data.Add("principal", NumToStr(FormatNumber(txtPrincipal.Text, 2)))
                data.Add("amortization", NumToStr(FormatNumber(txtBiMonthlyAmort.Text, 2)))
                data.Add("date_start", Format(dtStart.Value, "yyyyMMdd"))
                data.Add("date_end", Format(dtEnd.Value, "yyyyMMdd"))
                data.Add("interest_percentage", cboInterest.Text)
                data.Add("date_approved", "00000000")
                data.Add("date_enrolled", Format(Now, "yyyyMMdd"))
                data.Add("terms", Val(txtTerms.Text))
                ' data.Add("application_status", cboApplicationStatus.SelectedIndex)
                ' data.Add("loan_status", cboLoanStatus.SelectedIndex)
                ' data.Add("loan_remarks", txtLoanRemarks.Text)
                data.Add("loan_id", active_loan_id)


                rec = db.ExecuteNonQuery("update tbl_loans set client_id = @client_id, principal = @principal, amortization = @amortization, date_start = @date_start, date_end = @date_end, " & _
                                         "interest_percentage = @interest_percentage, date_approved = @date_approved, date_enrolled = @date_enrolled , terms = @terms, application_status = @application_status, loan_status = @loan_status, " & _
                                         "loan_remarks = @loan_remarks where loan_id = @loan_id;", data)

                If Not rec < 1 Then
                    'MsgBox("Record saved!", MsgBoxStyle.Information)
                    'toggleLoanApplication()
                    'LoadListView()
                    'Dim dr As SQLite.SQLiteDataReader
                    'dr = db.ExecuteReader("select max(loan_id) as id from tbl_loans")
                    'active_loan_id = dr.Item("id")
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose()
            End Try

        End Using

    End Sub

    Private Sub selectUser(listindex As Long)

    End Sub
    Private Function evadeWeekends(petsa As Date) As Date
        'petsa = petsa.AddMonths(Val(txtTerms.Text.Trim))
        While petsa.DayOfWeek = DayOfWeek.Saturday OrElse petsa.DayOfWeek = DayOfWeek.Sunday
            petsa = petsa.AddDays(1)
        End While
        Return petsa
    End Function

    Private Sub ComputeEndDate()
        Dim petsa As Date = dtStart.Value
        If Val(txtTerms.Text.Trim) = 0 Then
            dtEnd.Value = petsa
            Exit Sub
        End If


        Dim size As Byte = Val(txtTerms.Text) * 2
        Dim DueDates(size) As Date
        Dim startDate As Date = dtStart.Value
        Dim endDate As Date = dtStart.Value
        Dim xDay As Byte = Format(startDate, "dd")
        Dim yDay As Byte '= IIf(xDay < 28, (xDay + 15) Mod 30, 15)

        If xDay <= 7 Then
            xDay = 5
            yDay = 20
        ElseIf xDay <= 12 Then
            xDay = 10
            yDay = 25
        ElseIf xDay <= 17 Then
            xDay = 15
            yDay = 31
        ElseIf xDay <= 22 Then
            xDay = 20
            yDay = 5
        ElseIf xDay <= 27 Then
            xDay = 25
            yDay = 10
        Else
            xDay = 31
            yDay = 15
            'yDay = (xDay + 15) Mod 30
        End If
        DueDates(0) = startDate
        For i = 1 To size Step 2
            Dim dayfixer As Byte = 0

            'DueDates(i) = New Date()
            If xDay < yDay Then
Fix1:
                Try
                    DueDates(i) = New Date(DueDates(i - 1).Year, DueDates(i - 1).Month, yDay - dayfixer)

                Catch ex As Exception
                    dayfixer = dayfixer + 1
                    GoTo Fix1
                End Try
            Else
                DueDates(i) = New Date(DueDates(i - 1).Year, DueDates(i - 1).Month, yDay).AddMonths(1)
                'DueDates(i).AddMonths(1)
            End If

            DueDates(i + 1) = DueDates(i - 1).AddMonths(1)
            dayfixer = 0
Fix2:
            Try
                DueDates(i + 1) = New Date(DueDates(i + 1).Year, DueDates(i + 1).Month, xDay - dayfixer)

            Catch ex As Exception
                dayfixer = dayfixer + 1
                GoTo Fix2
            End Try

            DueDates(i) = evadeWeekends(DueDates(i))
            DueDates(i + 1) = evadeWeekends(DueDates(i + 1))
        Next
        Dim ddates(size) As DueDateObj
        For id = 0 To size
            ddates(id) = New DueDateObj(id + 1, DueDates(id).Date)
        Next
        ddates(size) = Nothing
        'ReDim ddates(size - 1)
        DataGridView1.DataSource = ddates ' DueDates  '
        DataGridView1.Columns(0).HeaderText = "#"
        DataGridView1.Columns(0).Width = 40
        DataGridView1.Columns(1).HeaderText = "Due Date"
        DataGridView1.Columns(1).Width = 140

        dtEnd.Value = DueDates(size - 1)
    End Sub

    Private Sub txtPrincipal_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or IsNumeric(txtPrincipal.Text) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPrincipal_TextChanged(sender As Object, e As EventArgs)
        computeTotalLoan()
    End Sub

    Private Sub txtTerms_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Up Then
            txtTerms.Text = Val(txtTerms.Text) + 1
        ElseIf e.KeyCode = Keys.Down And Val(txtTerms.Text.Trim) > 0 Then
            txtTerms.Text = Val(txtTerms.Text) - 1

        End If
    End Sub

    Private Sub txtTerms_TextChanged(sender As Object, e As EventArgs) Handles txtTerms.TextChanged
        computeTotalLoan()
        ComputeEndDate()
       

    End Sub

    Private Sub cboInterest_SelectedIndexChanged(sender As Object, e As EventArgs)
        computeTotalLoan()
    End Sub

    Private Sub cboInterest_TextChanged(sender As Object, e As EventArgs)
        computeTotalLoan()
    End Sub

    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs)
        ComputeEndDate()

    End Sub

    Private Const EM_SETCUEBANNER As Integer = &H1501

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Private Sub SetCueText(ByVal control As Control, ByVal text As String)
        SendMessage(control.Handle, EM_SETCUEBANNER, 0, text)
    End Sub
    Private Shared DES As New TripleDESCryptoServiceProvider
    Private Shared MD5 As New MD5CryptoServiceProvider

    Public Shared Function MD5Hash(ByVal value As String) As Byte()
        Return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value))
    End Function

    Public Shared Function Encrypt(ByVal stringToEncrypt As String, ByVal key As String) As String
        DES.Key = frmLogin.MD5Hash(key)
        DES.Mode = CipherMode.ECB
        Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt)
        Return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length))
    End Function


    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        showUSC(uscMainmenu)
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'codes
        Dim row As DataRow = Nothing
        Dim DS As New DataSet
        Dim rptLoanCalculateAttack As New LoanCalculator
        'mag a-add na sa dataset (DS)
        DS.Tables.Add("LoanCalculator")
        'lagay tayo ng columns
        With DS.Tables(0).Columns
            .Add("PrincipalAmount")
            .Add("InterestRate")
            .Add("Term")
            .Add("DateStart")
            .Add("DateEnd")
            .Add("MonthlyInterest")
            .Add("BiMonthlyInterest")
            .Add("TotalInterest")
            .Add("TotalLoanAmount")
        End With

        row = DS.Tables(0).NewRow
        row(0) = txtPrincipal.Text
        row(1) = cboInterest.Text
        row(2) = txtTerms.Text
        row(3) = Format(dtStart.Value, "MM/dd/yyyy")
        row(4) = Format(dtEnd.Value, "MM/dd/yyyy")
        row(5) = txtMonthlyInterest.Text
        row(6) = txtBiMonthlyAmort.Text
        row(7) = txtTotalInterest.Text
        row(8) = txtTotalLoanAmount.Text
        DS.Tables(0).Rows.Add(row)

        DS.WriteXml("XML\LoanCalculator.xml")

        Dim dsLoanCalculator As New DataSet
        dsLoanCalculator = New DSreports
        Dim dsLoanCalculatorTemp As New DataSet
        dsLoanCalculatorTemp = New DataSet()
        dsLoanCalculatorTemp.ReadXml("XML\LoanCalculator.xml")
        dsLoanCalculator.Merge(dsLoanCalculatorTemp.Tables(0))
        rptLoanCalculateAttack = New LoanCalculator
        rptLoanCalculateAttack.SetDataSource(dsLoanCalculator)
        crvLoanCalculator.ReportSource = (rptLoanCalculateAttack)
        showReport(True)

    End Sub
    Private Sub ExportToPDF()
        Try
            Dim Calculator As ExportOptions
            Dim DFDOCalculator As New DiskFileDestinationOptions()
            Dim FTOCalculator As New PdfRtfWordFormatOptions()
            DFDOCalculator.DiskFileName = Application.StartupPath() & "\Report Generated\PDF\Loan CalculatorV2 - " & txtPrincipal.Text & ".pdf"
            Calculator = RPTCalculator.ExportOptions
            With Calculator
                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat
                .DestinationOptions = DFDOCalculator
                .ExportFormatOptions = FTOCalculator
            End With
            RPTCalculator.Export()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Loan_calculatorV2(xEmpCode As String)
        Throw New NotImplementedException
    End Sub

    Private Sub Loan_calculatorV2()
        Throw New NotImplementedException
    End Sub

    Private Sub Loan_CalculatorV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
     
    End Sub

    Private Sub report_load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub


    Private Sub bntClose_Click(sender As Object, e As EventArgs) Handles bntClose.Click
        showReport(False)
    End Sub
End Class
