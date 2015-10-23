Public Class MainMenu

    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Parent = PictureBox1
        lblTime.Parent = PictureBox1
        lblDate.Parent = PictureBox1
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
        uscLoans.LoadListView()
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
End Class
