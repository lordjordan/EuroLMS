Public Class frmClientRequirement
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmClientRequirement_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = e.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = e.CloseReason
        If UnloadMode = CloseReason.UserClosing Then
            Me.Hide()
        End If
        e.Cancel = Cancel
    End Sub

   
End Class