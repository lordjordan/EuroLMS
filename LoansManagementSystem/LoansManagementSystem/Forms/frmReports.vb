Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Xml
Imports System.Data

Public Class frmReports
    Dim con As New SQLite.SQLiteConnection
    Dim ds As New DataSet
    Dim da As SQLite.SQLiteDataAdapter
    Dim query As String
    Dim rptClient As New ClientReport
    Dim rptBranch As New BranchReport
    Dim rptCompany As New CompanyReport
    Dim rptLoan As New LoanReportJournal
    Private Sub BranchReport()
        crvMasterListReport.ReportSource = Nothing
        crvMasterListReport.Refresh()
        ds.Tables.Clear()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select branch_id, company_name, branch_name, branch_contact, branch_address, payroll_master from tbl_branches as B LEFT JOIN tbl_company as C on B.company_id = C.company_id where company_name LIKE'%" & txtSearch.Text & "%' or " & _
                            "branch_name LIKE '%" & txtSearch.Text & "%' or " & _
                            "branch_contact LIKE '%" & txtSearch.Text & "%' or " & _
                            "branch_address LIKE '%" & txtSearch.Text & "%' or " & _
                            "payroll_master LIKE '%" & txtSearch.Text & "%' "

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Branch")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\BranchReport.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Branch
            Dim dsBranch As New DataSet
            dsBranch = New DSreports
            Dim dsBranchTemp As New DataSet
            dsBranchTemp = New DataSet()
            dsBranchTemp.ReadXml("XML\BranchReport.xml")
            dsBranch.Merge(dsBranchTemp.Tables(0))
            rptBranch = New BranchReport
            rptBranch.SetDataSource(dsBranch)
            crvMasterListReport.ReportSource = rptBranch
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub CompanyReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "Select company_id, company_name, company_address, company_contact_number, company_contact_person, company_remarks from tbl_company where company_name like '%" & txtSearch.Text & "%' or " & _
            "company_address like '%" & txtSearch.Text & "%' or " & _
            "company_contact_number like '%" & txtSearch.Text & "%' or " & _
            "company_contact_person like '%" & txtSearch.Text & "%' or " & _
            "company_remarks like '%" & txtSearch.Text & "%' "

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Company")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\CompanyReport.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Company
            Dim dsCompany As New DataSet
            dsCompany = New DSreports
            Dim dsCompanyTemp As New DataSet
            dsCompanyTemp = New DataSet()
            dsCompanyTemp.ReadXml("XML\CompanyReport.xml")
            dsCompany.Merge(dsCompanyTemp.Tables(0))
            rptCompany = New CompanyReport
            rptCompany.SetDataSource(dsCompany)
            crvMasterListReport.ReportSource = rptCompany
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
                            "WHERE last_name like '%" & txtSearch.Text & "%' or " & _
                            "first_name like '%" & txtSearch.Text & "%' or " & _
                            "middle_name like '%" & txtSearch.Text & "%' or " & _
                            "company_name like '%" & txtSearch.Text & "%' or " & _
                            "branch_name like '%" & txtSearch.Text & "%' "

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Client")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\ClientReport.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Client
            Dim dsclient As New DataSet
            dsclient = New DSreports
            Dim dsclienttemp As New DataSet
            dsclienttemp = New DataSet()
            dsclienttemp.ReadXml("XML\ClientReport.xml")
            dsclient.Merge(dsclienttemp.Tables(0))
            rptClient = New ClientReport
            rptClient.SetDataSource(dsclient)
            crvMasterListReport.ReportSource = rptClient
            dsclienttemp.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcessReport()
        Try
            If TabControl1.SelectedTab Is TabPage1 Then
                'wala
            ElseIf TabControl1.SelectedTab Is TabPage2 Then
                'wala pa :) :)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        crvMasterListReport.ReportSource = Nothing
        crvMasterListReport.Refresh()

        'If Branch is selected in combobox
        If cmbList.SelectedItem = "Branch" Then
            BranchReport()
            ds.Tables.Clear()

            'If Client is selected in combobox
        ElseIf cmbList.SelectedItem = "Client" Then
            ClientReport()
            ds.Tables.Clear()

            'If Company is selected in combobox
        ElseIf cmbList.SelectedItem = "Company" Then
            CompanyReport()
            ds.Tables.Clear()
        Else
            MsgBox("Please select List in the combobox.")
        End If
    End Sub

    Private Sub btnSearchLoan_Click(sender As Object, e As EventArgs) Handles btnSearchLoan.Click
        crvExLoanReport.ReportSource = Nothing
        crvExLoanReport.Refresh()

        If cmbLoans.SelectedItem = "In process" Then
            InProcessReport()
            ds.Tables.Clear()
        ElseIf cmbLoans.SelectedItem = "Active" Then
            ActiveReport()
            ds.Tables.Clear()
        ElseIf cmbLoans.SelectedItem = "Completed" Then
            CompletedReport()
            ds.Tables.Clear()
        ElseIf cmbLoans.SelectedItem = "Restructured" Then
            RestructuredReport()
            ds.Tables.Clear()
        ElseIf cmbLoans.SelectedItem = "Force Stop" Then
            ForceStopReport()
            ds.Tables.Clear()
        Else
            MsgBox("Please Select Loan Status first.")
        End If
    End Sub
    Private Sub InProcessReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, company_name, branch_name " & _
                                "from (SELECT * from tbl_loans where loan_status=0) as L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id like '%" & txtSearchLoan.Text & "%'  or first_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or middle_name like '%" & txtSearchLoan.Text & "%' or last_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or branch_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or company_name like '%" & txtSearchLoan.Text & "%'"

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Loan")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\InprocessLoanReport.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Active Loan
            Dim dsloan As New DataSet
            dsloan = New DSreports
            Dim dsloantemp As New DataSet
            dsloantemp = New DataSet()
            dsloantemp.ReadXml("XML\InprocessLoanReport.xml")
            dsloan.Merge(dsloantemp.Tables(0))
            rptLoan = New LoanReportJournal
            rptLoan.SetDataSource(dsloan)
            crvExLoanReport.ReportSource = rptLoan
            dsloantemp.Clear()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("No results containing all your search terms were found.")
        End Try
    End Sub
    Private Sub ActiveReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, company_name, branch_name " & _
                                "from (SELECT * from tbl_loans where loan_status=1) as L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id like '%" & txtSearchLoan.Text & "%'  or first_name like '%" & txtSearchLoan.Text & "%' " & _
                                " or middle_name like '%" & txtSearchLoan.Text & "%' or last_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or branch_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or company_name like '%" & txtSearchLoan.Text & "%'"

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Loan")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\ActiveLoanReport.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Active Loan
            Dim dsloan As New DataSet
            dsloan = New DSreports
            Dim dsloantemp As New DataSet
            dsloantemp = New DataSet()
            dsloantemp.ReadXml("XML\ActiveLoanReport.xml")
            dsloan.Merge(dsloantemp.Tables(0))
            rptLoan = New LoanReportJournal
            rptLoan.SetDataSource(dsloan)
            crvExLoanReport.ReportSource = rptLoan
            dsloantemp.Clear()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("No results containing all your search terms were found.")
        End Try
    End Sub
    Private Sub CompletedReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, company_name, branch_name " & _
                                "from (SELECT * from tbl_loans where loan_status=2) as L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id like '%" & txtSearchLoan.Text & "%'  or first_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or middle_name like '%" & txtSearchLoan.Text & "%' or last_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or branch_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or company_name like '%" & txtSearchLoan.Text & "%'"

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Loan")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\CompletedLoanReport.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Active Loan
            Dim dsloan As New DataSet
            dsloan = New DSreports
            Dim dsloantemp As New DataSet
            dsloantemp = New DataSet()
            dsloantemp.ReadXml("XML\CompletedLoanReport.xml")
            dsloan.Merge(dsloantemp.Tables(0))
            rptLoan = New LoanReportJournal
            rptLoan.SetDataSource(dsloan)
            crvExLoanReport.ReportSource = rptLoan
            dsloantemp.Clear()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("No results containing all your search terms were found.")
        End Try
    End Sub
    Private Sub RestructuredReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, company_name, branch_name " & _
                                "from (SELECT * from tbl_loans where loan_status=3) as L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id like '%" & txtSearchLoan.Text & "%'  or first_name like '%" & txtSearchLoan.Text & "%' " & _
                                " or middle_name like '%" & txtSearchLoan.Text & "%' or last_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or branch_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or company_name like '%" & txtSearchLoan.Text & "%'"

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Loan")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\RestructuredLoanReport.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Active Loan
            Dim dsloan As New DataSet
            dsloan = New DSreports
            Dim dsloantemp As New DataSet
            dsloantemp = New DataSet()
            dsloantemp.ReadXml("XML\RestructuredLoanReport.xml")
            dsloan.Merge(dsloantemp.Tables(0))
            rptLoan = New LoanReportJournal
            rptLoan.SetDataSource(dsloan)
            crvExLoanReport.ReportSource = rptLoan
            dsloantemp.Clear()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("No results containing all your search terms were found.")
        End Try
    End Sub
    Private Sub ForceStopReport()
        Try
            con.ConnectionString = My.Settings.ConnectionString

            'query = "Select client_id ,company_name, branch_name, first_name || ' ' || middle_name || ' ' || last_name as name, address, contact_number, credit_limit from tbl_clients as A left join tbl_branches as B on A.branch_id=B.branch_id left join tbl_company as C on B.company_id=C.company_id WHERE status_info=1"
            query = "select loan_id, last_name || ', ' || first_name || ' ' || middle_name [name], principal, amortization, interest_percentage, " & _
                                "terms, date_start, date_end, company_name, branch_name " & _
                                "from (SELECT * from tbl_loans where loan_status=4) as L " & _
                                "left join tbl_clients C on L.client_id = C.client_id " & _
                                "left join tbl_branches B on C.branch_id = B.branch_id " & _
                                "left join tbl_company Co on B.company_id = Co.company_id " & _
                                "where loan_id like '%" & txtSearchLoan.Text & "%'  or first_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or middle_name like '%" & txtSearchLoan.Text & "%' or last_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or branch_name like '%" & txtSearchLoan.Text & "%' " & _
                                "or company_name like '%" & txtSearchLoan.Text & "%'"

            da = New SQLite.SQLiteDataAdapter(query, con)
            da.Fill(ds, "Loan")
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\ForceStopLoanReport.xml")
                'MsgBox("Creating xml file done.")
            End If

            'Report for Active Loan
            Dim dsloan As New DataSet
            dsloan = New DSreports
            Dim dsloantemp As New DataSet
            dsloantemp = New DataSet()
            dsloantemp.ReadXml("XML\ForceStopLoanReport.xml")
            dsloan.Merge(dsloantemp.Tables(0))
            rptLoan = New LoanReportJournal
            rptLoan.SetDataSource(dsloan)
            crvExLoanReport.ReportSource = rptLoan
            dsloantemp.Clear()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            MsgBox("No results containing all your search terms were found.")
        End Try
    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TabControl1.SelectedTab Is TabPage1 Then
            'ProcessReport()
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
        End If
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If TabControl1.SelectedTab Is TabPage1 Then
            crvMasterListReport.PrintReport()
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            crvExLoanReport.PrintReport()
        End If
    End Sub

End Class