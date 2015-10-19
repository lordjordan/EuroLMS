Public Class Loan_Calculator
    Private Sub computeTotalLoan()
        If Val(txtTerms.Text) < 1 Or Val(cboInterest.Text) <= 0 Or Val(txtPrincipal.Text) < 1 Or _
            Not IsNumeric(txtPrincipal.Text) Or _
            Not IsNumeric(cboInterest.Text) Or _
            Not IsNumeric(txtTerms.Text) Then
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
    Private Sub ComputeEndDate()
        Dim petsa As Date = dtStart.Value
        If Val(txtTerms.Text.Trim) = 0 Then
            dtEnd.Value = petsa
            Exit Sub
        End If
        petsa = petsa.AddMonths(Val(txtTerms.Text.Trim))
        While petsa.DayOfWeek = DayOfWeek.Saturday OrElse petsa.DayOfWeek = DayOfWeek.Sunday
            petsa = petsa.AddDays(-1)
        End While
        dtEnd.Value = petsa

    End Sub
    Private Sub txtPrincipal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrincipal.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Or e.KeyChar = "." Or IsNumeric(txtPrincipal.Text) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtPrincipal_TextChanged(sender As Object, e As EventArgs) Handles txtPrincipal.TextChanged
        computeTotalLoan()
    End Sub
    Private Sub txtTerms_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTerms.KeyDown
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
    Private Sub cboInterest_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInterest.SelectedIndexChanged
        computeTotalLoan()
    End Sub
    Private Sub cboInterest_TextChanged(sender As Object, e As EventArgs) Handles cboInterest.TextChanged
        computeTotalLoan()
    End Sub
    Private Sub dtStart_ValueChanged(sender As Object, e As EventArgs) Handles dtStart.ValueChanged
        ComputeEndDate()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
     
    End Sub

    Private Sub btnOk_Click_1(sender As Object, e As EventArgs) Handles btnOk.Click
        showUSC(uscMainmenu)
    End Sub
End Class