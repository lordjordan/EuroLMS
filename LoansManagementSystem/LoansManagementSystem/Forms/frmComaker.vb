Public Class frmComaker
    Dim itm As ListViewItem
    Dim db As New DBHelper("Data Source=" & My.Settings.ConString & "; Version=3;")
    Dim dr As SQLite.SQLiteDataReader

    Private Sub showAddCoMaker(mode As Boolean)
        gbxAddCoMaker.Visible = mode
        pnlComaker.Enabled = Not mode
    End Sub
    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click
        'pwede imodule
        lvClientList.Items.Clear()
        Try

            dr = db.ExecuteReader("SELECT client_id, last_name, first_name, middle_name, branch_id, employee_no FROM tbl_clients" & _
                                  " WHERE first_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or last_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or middle_name LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or branch_id LIKE '%" & txtSearchClient.Text.Trim & "%' " & _
                                  " or employee_no LIKE '%" & txtSearchClient.Text.Trim & "%' ")
            If dr.HasRows Then

                Do While dr.Read
                    itm = Me.lvClientList.Items.Add(dr.Item("client_id").ToString)
                    itm.SubItems.Add(dr.Item("last_name").ToString & ", " & dr.Item("first_name").ToString & ", " & dr.Item("middle_name").ToString)
                    itm.SubItems.Add(dr.Item("branch_id").ToString)
                    itm.SubItems.Add(dr.Item("employee_no").ToString)
                Loop

            Else
                MsgBox("No record found", vbInformation + vbOKOnly, "Record not found")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

   


   

    Private Sub btnClientBack_Click(sender As Object, e As EventArgs) Handles btnClientBack.Click
        showAddCoMaker(False)
    End Sub

    Private Sub frmComaker_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = e.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = e.CloseReason
        If UnloadMode = CloseReason.UserClosing Then
            Me.Hide()
        End If
        e.Cancel = Cancel
    End Sub

    Private Sub frmComaker_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        showAddCoMaker(True)
    End Sub
End Class