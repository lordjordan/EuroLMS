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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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
            'da.Fill(ds)
            'Dim dt As DataTable
            'Dim dr As DataRow
            'dt = ds.Tables(0)
            'For Each dr In dt.Rows
            '    Dim myNumber As Integer = dr("credit_limit")
            '    Dim cLimit As Integer = (myNumber * 0.01).ToString("N2")
            'Next dr
            If ds.Tables.Count <> 0 Then
                'Creating xml file
                ds.WriteXml("XML\ClientReport.xml")
                'MsgBox("Creating xml file done.")
            End If
            ds.Clear()
            con.Close()
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
            End If

            'Report for Client
            Dim dsClient As New DataSet
            dsClient = New DSreports
            Dim dsClientTemp As New DataSet
            dsClientTemp = New DataSet()

            dsClientTemp.ReadXml("XML\ClientReport.xml")
            dsClient.Merge(dsClientTemp.Tables(0))
            rptClient = New ClientReport
            rptClient.SetDataSource(dsClient.Tables(0))
            crvClientReport.ReportSource = rptClient
            
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        '
        If cmbList.SelectedItem = "Branch" Then

        ElseIf cmbList.SelectedItem = "Client" Then
            ProcessReport()

        ElseIf cmbList.SelectedItem = "Company" Then

        End If

    End Sub

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TabControl1.SelectedTab Is TabPage1 Then
            'ProcessReport()
        ElseIf TabControl1.SelectedTab Is TabPage2 Then
        End If
    End Sub
End Class