Public Class zoomImg
    
   

    
    Dim imgbyte As Byte()
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If OpenFileDialog1.ShowDialog = vbOK Then
            Dim myimage As Image = Image.FromFile(OpenFileDialog1.FileName)
            Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom

            myimage.Save(imagestream, System.Drawing.Imaging.ImageFormat.Jpeg)
            imgbyte = imagestream.GetBuffer()

            imagestream = New System.IO.MemoryStream(imgbyte)
            PictureBox1.Image = Drawing.Image.FromStream(imagestream)
            'txtFilename.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox1_SizeChanged(sender As Object, e As EventArgs) Handles PictureBox1.SizeChanged
        Me.Size = New Size(Me.Width + Me.PictureBox1.Width - Me.Panel1.Width,
                       Me.Height + Me.PictureBox1.Height - Me.Panel1.Height)
    End Sub
End Class