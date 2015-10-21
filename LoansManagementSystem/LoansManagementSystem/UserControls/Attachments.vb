Imports System.Drawing.Imaging
Imports System.IO
Public Class Attachments
    Dim itm As ListViewItem

    Dim db As New DBHelper(My.Settings.ConnectionString)
    Dim dr As SQLite.SQLiteDataReader
    Dim cmd As SQLite.SQLiteCommand
    Private Sub showRequirement(mode As Boolean)
        gbxAddEdit.Visible = mode
        pnlMain.Enabled = Not mode

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        showUSC(uscMainmenu)
    End Sub
    Private Sub clearAll()
        txtClientID.Text = ""
        txtName.Text = ""
        txt_Remarks.Text = ""
        cbxReqType.SelectedItem = ""
        PictureBox1.Image = Nothing
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        clearAll()
        AddItemToListView()
    End Sub

    Private Sub AddItemToListView()
        gbxAddEdit.Text = "Add New Requirement"
        showRequirement(True)
        txtClientID.Focus()
    End Sub

    Private Function strToDate(str As String) As Date
        str = str.Substring(4, 2) & "/" & str.Substring(6, 2) & "/" & str.Substring(0, 4)
        Return str 'Format(str, "Short date")
    End Function

    Private Sub LoadListview()
        ListView1.Items.Clear()
        showRequirement(False)
        Try
            dr = db.ExecuteReader("SELECT requirement_id,filename,requirement_type,date_upload,remarks,first_name,middle_name,last_name from tbl_requirements as R LEFT JOIN tbl_clients as C on R.client_id=C.client_id")
            If dr.HasRows Then

                Do While dr.Read
                    Dim rType = (CInt(dr.Item("requirement_type")))
                    itm = Me.ListView1.Items.Add(dr.Item("requirement_id").ToString)
                    itm.SubItems.Add(dr.Item("filename").ToString)
                    'itm.SubItems.Add(dr.Item("client_id").ToString)
                    itm.SubItems.Add(dr.Item("first_name").ToString & " " & dr.Item("middle_name").ToString & " " & dr.Item("last_name").ToString)
                    itm.SubItems.Add(strToDate(dr.Item("date_upload").ToString))
                    'itm.SubItems.Add(dr.Item("requirement_type").ToString)
                    If rType = 0 Then
                        itm.SubItems.Add("Loan application requirements")
                    ElseIf rType = 1 Then
                        itm.SubItems.Add("Promisory requirements")
                    End If

                    itm.SubItems.Add(dr.Item("remarks").ToString)
                Loop
            Else
                MsgBox("No Record Of Attachment.", vbInformation + vbOKOnly, "No Record")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub
    Dim pic As Byte()
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        PictureBox1.Image = Nothing
        txtReqID.Focus()
        gbxAddEdit.Text = "Edit Requirement"
        If ListView1.SelectedItems.Count > 0 Then
            Try
                dr = db.ExecuteReader("SELECT requirement_id,R.client_id,picture,requirement_type,date_upload,remarks,first_name,middle_name,last_name from tbl_requirements as R LEFT JOIN tbl_clients as C on R.client_id=C.client_id WHERE requirement_id=" & ListView1.FocusedItem.Text)

                If dr.HasRows Then
                    showRequirement(True)

                    txtReqID.Text = dr.Item("requirement_id").ToString
                    txtClientID.Text = dr.Item("client_id").ToString
                    txt_Remarks.Text = dr.Item("remarks").ToString
                    Dim name As String = (dr.Item("first_name").ToString & " " & dr.Item("middle_name").ToString & " " & dr.Item("last_name").ToString)
                    txtName.Text = name
                    DateTimePicker1.Value = strToDate(dr.Item("date_upload"))
                    If dr.Item("requirement_type") = 0 Then 'in process
                        cbxReqType.Text = "Loan application requirements"
                    ElseIf dr.Item("requirement_type") = 1 Then
                        cbxReqType.Text = "Promisory requirements"
                    End If

                    Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream
                    pic = dr.Item("picture")
                    imagestream = New System.IO.MemoryStream(pic)
                    PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                    PictureBox1.Image = Drawing.Image.FromStream(imagestream)


                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try

            'PictureBox1.Image = ListView1.SelectedItems(0).SubItems(1).Tag           

        Else
            MessageBox.Show("Please select record to edit.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Dim imgbyte As Byte() = Nothing
    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If gbxAddEdit.Text = "Add New Requirement" Then
            If OpenFileDialog1.ShowDialog = vbOK Then
                Dim myimage As Image = Image.FromFile(OpenFileDialog1.FileName)
                Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream

                myimage.Save(imagestream, System.Drawing.Imaging.ImageFormat.Jpeg)
                imgbyte = imagestream.GetBuffer()

                'MsgBox(imgbyte)
                'txtFilename.Text = imgbyte.ToString
                'Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream

                imagestream = New System.IO.MemoryStream(imgbyte)
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                PictureBox1.Image = Drawing.Image.FromStream(imagestream)
                'txtFilename.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName)

            End If
            Exit Sub
        ElseIf gbxAddEdit.Text = "Edit Requirement" Then
            If OpenFileDialog1.ShowDialog = vbOK Then
                Dim myimage As Image = Image.FromFile(OpenFileDialog1.FileName)
                Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream

                myimage.Save(imagestream, System.Drawing.Imaging.ImageFormat.Jpeg)
                pic = imagestream.GetBuffer()

                'MsgBox(imgbyte)
                'txtFilename.Text = imgbyte.ToString
                'Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream

                imagestream = New System.IO.MemoryStream(pic)
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                PictureBox1.Image = Drawing.Image.FromStream(imagestream)
                'txtFilename.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            End If
            Exit Sub
        End If
        If OpenFileDialog1.ShowDialog = vbOK Then
            Dim myimage As Image = Image.FromFile(OpenFileDialog1.FileName)
            Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream

            myimage.Save(imagestream, System.Drawing.Imaging.ImageFormat.Jpeg)
            imgbyte = imagestream.GetBuffer()

            'MsgBox(imgbyte)
            'txtFilename.Text = imgbyte.ToString
            'Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream

            imagestream = New System.IO.MemoryStream(imgbyte)
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            PictureBox1.Image = Drawing.Image.FromStream(imagestream)
            'txtFilename.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If gbxAddEdit.Text = "Add New Requirement" Then
            If txtClientID.Text = "" Or cbxReqType.Text = "" Or txt_Remarks.Text = "" Or PictureBox1.Image Is Nothing Then
                MsgBox("Some fields are empty.", MsgBoxStyle.Exclamation, "Please fill up")
                Exit Sub
            End If

            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Try
                data.Add("requirement_id", txtReqID.Text)
                data.Add("client_id", txtClientID.Text)
                data.Add("picture", imgbyte)
                If cbxReqType.Text = "Loan application requirements" Then 'in process
                    data.Add("requirement_type", "0")
                ElseIf cbxReqType.Text = "Promisory requirements" Then
                    data.Add("requirement_type", "1")
                End If
                data.Add("date_upload", Format(DateTimePicker1.Value, "yyyyMMdd"))
                data.Add("remarks", txt_Remarks.Text)
                data.Add("filename", System.IO.Path.GetFileName(OpenFileDialog1.FileName))

                rec = db.ExecuteNonQuery("INSERT INTO tbl_requirements values(NULL,@client_id,@picture,@filename,@requirement_type,@date_upload,@remarks)", data)

                If Not rec < 1 Then
                    MessageBox.Show("Saving Attachment Record...", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    showRequirement(False)
                    LoadListview()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try


        ElseIf gbxAddEdit.Text = "Edit Requirement" Then

            Dim rec As Integer
            Dim data As New Dictionary(Of String, Object)
            Try
                data.Add("requirement_id", txtReqID.Text)
                'data.Add("client_id", txtClientID.Text)
                data.Add("picture", pic)
                data.Add("filename", System.IO.Path.GetFileName(OpenFileDialog1.FileName))
                If cbxReqType.Text = "Loan application requirements" Then
                    data.Add("requirement_type", "0")
                ElseIf cbxReqType.Text = "Promisory requirements" Then
                    data.Add("requirement_type", "1")
                End If
                data.Add("date_upload", Format(DateTimePicker1.Value, "yyyyMMdd"))
                data.Add("remarks", txt_Remarks.Text)

                rec = db.ExecuteNonQuery("UPDATE tbl_requirements SET requirement_id=@requirement_id,picture=@picture,filename=@filename,requirement_type=@requirement_type, date_upload=@date_upload, remarks=@remarks WHERE requirement_id=" & txtReqID.Text, data)

                If Not rec < 1 Then
                    MessageBox.Show("Updating Record...", "Important Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    showRequirement(False)
                    LoadListview()
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try
        End If
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        showRequirement(False)
        ListView1.SelectedItems.Clear()
        clearAll()
    End Sub

    Private Sub Attachments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadListview()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        toggleClientSearch(True)
    End Sub
    Private Sub toggleClientSearch(Optional mode As Boolean = False)
        gbxShowClient.Visible = mode
        gbxShowClient.Enabled = mode
        If mode Then
            gbxShowClient.BringToFront()
        Else
            gbxShowClient.SendToBack()
        End If

        gbxAddEdit.Enabled = Not mode

    End Sub

    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click

        lvClientList.Items.Clear()

        Dim data As New Dictionary(Of String, Object)
        data.Add("searchkey1", "%" + txtSearchClient.Text + "%")
        data.Add("searchkey2", "%" & txtSearchClient.Text & "%")
        data.Add("searchkey3", "%" + txtSearchClient.Text + "%")

        Dim db As New DBHelper(My.Settings.ConnectionString)
        Dim dr As SQLite.SQLiteDataReader

        Try
            dr = db.ExecuteReader("select client_id, employee_no, last_name, first_name, middle_name, company_name, branch_name, credit_limit " & _
                            "from tbl_clients as A " & _
                            "left join tbl_branches as B on A.branch_id=B.branch_id " & _
                            "left join tbl_company as C on B.company_id=C.company_id " & _
                            "where last_name like '%" & txtSearchClient.Text & "%' or " & _
                            "first_name like '%" & txtSearchClient.Text & "%' or " & _
                            "middle_name like '%" & txtSearchClient.Text & "%' or " & _
                            "company_name like '%" & txtSearchClient.Text & "%' or " & _
                            "branch_name like '%" & txtSearchClient.Text & "%' ")

            If dr.HasRows Then
                Do While dr.Read
                    Dim itmx As ListViewItem = lvClientList.Items.Add(dr.Item("client_id").ToString)
                    itmx.SubItems.Add(dr.Item("last_name").ToString & ", " & dr.Item("first_name").ToString & " " & dr.Item("middle_name").ToString)
                    itmx.SubItems.Add(dr.Item("company_name").ToString)
                    itmx.SubItems.Add(dr.Item("branch_name").ToString)
                    itmx.SubItems.Add(dr.Item("employee_no").ToString)

                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try

    End Sub

    Private Sub btnClientBack_Click(sender As Object, e As EventArgs) Handles btnClientBack.Click
        toggleClientSearch()
    End Sub

    Private Sub btnSelectSearchClient_Click(sender As Object, e As EventArgs) Handles btnSelectSearchClient.Click
        Try
            txtClientID.Text = lvClientList.SelectedItems.Item(0).Text
            txtName.Text = lvClientList.SelectedItems.Item(0).SubItems(1).Text
            toggleClientSearch()

        Catch ex As Exception
            MsgBox("Please select a valid client first. You can filter or search client data through the 'search box' and then click the 'search button'", MsgBoxStyle.Exclamation)
        Finally
            db.Dispose() '<--------CHECK THIS!
        End Try
    End Sub
    Public Sub PreviewPic()
        PreviewImg.PictureBox1.Image = Nothing
        If ListView1.SelectedItems.Count > 0 Then
            PreviewImg.Show()
            Try
                dr = db.ExecuteReader("SELECT requirement_id,R.client_id,picture,requirement_type,date_upload,remarks,first_name,middle_name,last_name from tbl_requirements as R LEFT JOIN tbl_clients as C on R.client_id=C.client_id WHERE requirement_id=" & ListView1.FocusedItem.Text)

                If dr.HasRows Then
                    'Dim name As String = (dr.Item("first_name").ToString & " " & dr.Item("middle_name").ToString & " " & dr.Item("last_name").ToString)
                    'txtName.Text = name
                    Dim imagestream As System.IO.MemoryStream = New System.IO.MemoryStream
                    Dim imgbyte As Byte()
                    imgbyte = dr.Item("picture")
                    imagestream = New System.IO.MemoryStream(imgbyte)
                    PreviewImg.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
                    PreviewImg.PictureBox1.Image = Drawing.Image.FromStream(imagestream)

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                db.Dispose() '<--------CHECK THIS!
            End Try
        Else
            MessageBox.Show("Please select record to Preview.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End If
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        PreviewPic()
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        PreviewPic()
    End Sub

End Class
