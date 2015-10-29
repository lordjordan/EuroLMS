Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Xml
Imports System.Data
Public Class frmPrintReports
    Dim con As New SQLite.SQLiteConnection
    Dim ds As New DataSet
    Dim da As SQLite.SQLiteDataAdapter
    Dim query As String
    Dim rptClient As New ClientReportJournal
    Dim rptCompany As New CompanyReport
    Dim rptBranch As New BranchReport
    'Dim db As New DBHelper(My.Settings.ConnectionString)
    'Dim dr As SQLite.SQLiteDataReader
    'Dim rec As Integer
    'Dim data As New Dictionary(Of String, Object)

    'Private Sub ClientReport(Optional ByVal xEmpCode As String = "")
    Private Sub CompanyReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "Select company_id, company_name, company_address, company_contact_number, company_contact_person, company_remarks from tbl_company where company_name like '%" & uscCompanies.txtSearch.Text & "%' or " & _
            "company_address like '%" & uscCompanies.txtSearch.Text & "%' or " & _
            "company_contact_number like '%" & uscCompanies.txtSearch.Text & "%' or " & _
            "company_contact_person like '%" & uscCompanies.txtSearch.Text & "%' or " & _
            "company_remarks like '%" & uscCompanies.txtSearch.Text & "%' "

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Company")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\Branch.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Company
            Dim dsCompany As New DataSet
            dsCompany = New DSreports
            Dim dsCompanyTemp As New DataSet
            dsCompanyTemp = New DataSet()
            dsCompanyTemp.ReadXml("XML\Branch.xml")
            dsCompany.Merge(dsCompanyTemp.Tables(0))
            rptCompany = New CompanyReport
            rptCompany.SetDataSource(dsCompany)
            crvCompanyJournal.ReportSource = rptCompany
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClientReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select client_id, employee_no, first_name || ' ' || middle_name || ' ' || last_name as name, company_name, branch_name, address,contact_number, credit_limit " & _
                            "from (SELECT * FROM tbl_clients WHERE status_info = 1) as A " & _
                            "left join tbl_branches as B on A.branch_id=B.branch_id " & _
                            "left join tbl_company as C on B.company_id=C.company_id " & _
                            "WHERE last_name like '%" & uscClients.txtSearchClient.Text & "%' or " & _
                            "first_name like '%" & uscClients.txtSearchClient.Text & "%' or " & _
                            "middle_name like '%" & uscClients.txtSearchClient.Text & "%' or " & _
                            "company_name like '%" & uscClients.txtSearchClient.Text & "%' or " & _
                            "branch_name like '%" & uscClients.txtSearchClient.Text & "%' "

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Client")
            'da.Fill(ds)
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\Client.xml")
                'MsgBox("Creating xml file done.")
            End If


            'Report for Client
            Dim dsClient As New DataSet
            dsClient = New DSreports
            Dim dsClientTemp As New DataSet
            dsClientTemp = New DataSet()

            dsClientTemp.ReadXml("XML\Client.xml")
            dsClient.Merge(dsClientTemp.Tables(0))
            rptClient = New ClientReportJournal
            rptClient.SetDataSource(dsClient)
            crvClientJournal.ReportSource = rptClient

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub BranchReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select branch_id, company_name, branch_name, branch_contact, branch_address, payroll_master from tbl_branches as B LEFT JOIN tbl_company as C on B.company_id = C.company_id where company_name LIKE'%" & uscBranches.txtSearch.Text & "%' or " & _
                            "branch_name LIKE '%" & uscBranches.txtSearch.Text & "%' or " & _
                            "branch_contact LIKE '%" & uscBranches.txtSearch.Text & "%' or " & _
                            "branch_address LIKE '%" & uscBranches.txtSearch.Text & "%' or " & _
                            "payroll_master LIKE '%" & uscBranches.txtSearch.Text & "%' "

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Branch")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\Branch.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Branch
            Dim dsBranch As New DataSet
            dsBranch = New DSreports
            Dim dsBranchTemp As New DataSet
            dsBranchTemp = New DataSet()
            dsBranchTemp.ReadXml("XML\Branch.xml")
            dsBranch.Merge(dsBranchTemp.Tables(0))
            rptBranch = New BranchReport
            rptBranch.SetDataSource(dsBranch)
            crvBranchJournal.ReportSource = rptBranch
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoanReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, application_status, loan_status, loan_remarks, company_name, branch_name " & _
                                "from tbl_loans L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id like '%" & uscLoans.txtSearchLoan.Text & "%'  or first_name like '%" & uscLoans.txtSearchLoan.Text & "%' " & _
                                " or middle_name like '%" & uscLoans.txtSearchLoan.Text & "%' or last_name like '%" & uscLoans.txtSearchLoan.Text & "%' " & _
                                "or L.client_id like '%" & uscLoans.txtSearchLoan.Text & "%' or branch_name like '%" & uscLoans.txtSearchLoan.Text & "%' " & _
                                "or company_name like '%" & uscLoans.txtSearchLoan.Text & "%'"

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Branch")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\Loan.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Branch
            Dim dsBranch As New DataSet
            dsBranch = New DSreports
            Dim dsBranchTemp As New DataSet
            dsBranchTemp = New DataSet()
            dsBranchTemp.ReadXml("XML\Loan.xml")
            dsBranch.Merge(dsBranchTemp.Tables(0))
            rptBranch = New BranchReport
            rptBranch.SetDataSource(dsBranch)
            crvBranchJournal.ReportSource = rptBranch
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ProcessReport(Optional ByVal xEmpCode As String = "")
        Try
            'IF TABPAGE1 IS SELECTED
            If TabControl1.SelectedTab Is TabPage1 Then
                ClientReport()

                'IF TABPAGE2 IS SELECTED
            ElseIf TabControl1.SelectedTab Is TabPage2 Then
                CompanyReport()

                'IF TABPAGE3 IS SELECTED
            ElseIf TabControl1.SelectedTab Is TabPage3 Then
                BranchReport()

                'IF TABPAGE4 IS SELECTED
            ElseIf TabControl1.SelectedTab Is TabPage4 Then
                LoanReport()

                'IF TABPAGE5 IS SELECTED
            ElseIf TabControl1.SelectedTab Is TabPage5 Then
                'ProcessPCReport
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If lblHeader.Text = "Client Report" Then
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
            TabControl1.TabPages.Remove(TabPage5)
        ElseIf lblHeader.Text = "Company Report" Then
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
            TabControl1.TabPages.Remove(TabPage5)
        ElseIf lblHeader.Text = "Branch Report" Then
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage4)
            TabControl1.TabPages.Remove(TabPage5)
        ElseIf lblHeader.Text = "Loans Report" Then
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage5)
        ElseIf lblHeader.Text = "Collectibles Report" Then
            TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
        End If

        crvClientJournal.ReportSource = Nothing
        crvClientJournal.Refresh()
        ds.Tables.Clear()
        ProcessReport()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.SelectedTab Is TabPage1 Then
        '    TabPage2.Hide()
        'ElseIf TabControl1.SelectedTab Is TabPage2 Then
        '    'ProcessCompanyReport()
        '    lblHeader.Text = "Company Report"
        '    'MsgBox("tab2 is selected")
        'ElseIf TabControl1.SelectedTab Is TabPage3 Then
        '    'ProcessBranchReport()
        '    lblHeader.Text = "Branch Report"
        '    'MsgBox("tab3 is selected")
        'ElseIf TabControl1.SelectedTab Is TabPage3 Then
        '    lblHeader.Text = "Loans Report"
        'End If
    End Sub

    Private Sub TabControl1_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabControl1.Selecting
    End Sub
End Class