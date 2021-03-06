﻿Imports System.Text
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Xml
Imports System.Data
Public Class frmClientReports
    Dim con As New SQLite.SQLiteConnection
    Dim ds As New DataSet
    Dim da As SQLite.SQLiteDataAdapter
    Dim query As String
    Dim rptClient As New ClientReportJournal

    'Dim db As New DBHelper(My.Settings.ConnectionString)
    'Dim dr As SQLite.SQLiteDataReader
    'Dim rec As Integer
    'Dim data As New Dictionary(Of String, Object)

    'Private Sub ClientReport(Optional ByVal xEmpCode As String = "")
    Private Sub LoanReport()

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
            Dim dt As DataTable
            Dim dr As DataRow
            dt = ds.Tables(0)
            For Each dr In dt.Rows
                Dim myNumber As Integer = dr("credit_limit")
                Dim cLimit As Integer = (myNumber * 0.01).ToString("N2")
            Next dr
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\Client.xml")
                'MsgBox("Creating xml file done.")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ProcessReport(Optional ByVal xEmpCode As String = "")
        Try
            'Generate XML
            'If Len(xEmpCode) <> 0 Then
            '    ClientReport(xEmpCode)
            'Else
            '    ClientReport()
            'End If

            If TabControl1.SelectedTab Is TabPage1 Then
                ClientReport()
            ElseIf TabControl1.SelectedTab Is TabPage2 Then
                
            ElseIf TabControl1.SelectedTab Is TabPage3 Then
                
            ElseIf TabControl1.SelectedTab Is TabPage3 Then

            ElseIf TabControl1.SelectedTab Is TabPage4 Then

            End If

            'Report for Client
            Dim dsClient As New DataSet
            dsClient = New DSreports
            Dim dsClientTemp As New DataSet
            dsClientTemp = New DataSet()

            dsClientTemp.ReadXml("XML\Client.xml")
            dsClient.Merge(dsClientTemp.Tables(0))
            rptClient = New ClientReportJournal
            rptClient.SetDataSource(dsClient.Tables(0))
            crvClientJournal.ReportSource = rptClient

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ProcessReport()
        If TabControl1.SelectedTab Is TabPage1 Then
            ProcessReport()
            lblHeader.Text = "Client Report"
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
            'ProcessCompanyReport()
            lblHeader.Text = "Company Report"
            'MsgBox("tab2 is selected")
        ElseIf TabControl1.SelectedTab Is TabPage3 Then
            'ProcessBranchReport()
            lblHeader.Text = "Branch Report"
            'MsgBox("tab3 is selected")
        ElseIf TabControl1.SelectedTab Is TabPage3 Then
            lblHeader.Text = "Loans Report"
        ElseIf TabControl1.SelectedTab Is TabPage4 Then
            lblHeader.Text = "Collectibles Report"
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'If TabControl1.SelectedTab Is TabPage1 Then
        '    ProcessReport()
        '    lblHeader.Text = "Client Report"
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
End Class