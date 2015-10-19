Module MainPanelController

    Public uscMainmenu As New MainMenu
    Public uscCollectibles As New frmCollectibles
    Public uscSystemUser As New System_User
    Public uscAttachments As New Attachments
    Public uscClients As New Clients
    Public uscBranches As New Branches
    Public uscLoans As New LoansV2
    Public uscCompanies As New Company
    Public uscExtra As New Loan_Calculator
    Public uscPaymentHistory As New PaymentHistory


    'Public uscClientList As New ClientList

    Public currentUSC As Control

    Sub clearMainPanel()
        frmMainPanel.pnlMain.Controls.Clear()
    End Sub



    Sub showUSC(usc As Control)
        currentUSC = usc
        clearMainPanel()
        currentUSC.Parent = frmMainPanel.pnlMain
        currentUSC.Width = frmMainPanel.pnlMain.Width
        currentUSC.Height = frmMainPanel.pnlMain.Height
    End Sub
End Module
