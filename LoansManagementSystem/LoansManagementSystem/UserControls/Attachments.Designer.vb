<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Attachments
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnSearchAttachment = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbxAddEdit = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtClientID = New System.Windows.Forms.TextBox()
        Me.txtReqID = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.cbxReqType = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Remarks = New System.Windows.Forms.TextBox()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ServiceController1 = New System.ServiceProcess.ServiceController()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.gbxShowClient = New System.Windows.Forms.GroupBox()
        Me.btnClientBack = New System.Windows.Forms.Button()
        Me.lvClientList = New System.Windows.Forms.ListView()
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSelectSearchClient = New System.Windows.Forms.Button()
        Me.btnSearchClient = New System.Windows.Forms.Button()
        Me.txtSearchClient = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.pnlMain.SuspendLayout()
        Me.gbxAddEdit.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxShowClient.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(21, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 39)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Attachments"
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Controls.Add(Me.ListView1)
        Me.pnlMain.Controls.Add(Me.btnPreview)
        Me.pnlMain.Controls.Add(Me.btnSearchAttachment)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.TextBox1)
        Me.pnlMain.Controls.Add(Me.Button2)
        Me.pnlMain.Controls.Add(Me.btnEdit)
        Me.pnlMain.Controls.Add(Me.btnAddNew)
        Me.pnlMain.ForeColor = System.Drawing.SystemColors.WindowText
        Me.pnlMain.Location = New System.Drawing.Point(25, 75)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1107, 544)
        Me.pnlMain.TabIndex = 51
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader17})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(22, 44)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1025, 401)
        Me.ListView1.TabIndex = 61
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Requirement ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Picture"
        Me.ColumnHeader2.Width = 250
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 250
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Date Uploaded"
        Me.ColumnHeader8.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Requirement Type"
        Me.ColumnHeader9.Width = 350
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Remarks"
        Me.ColumnHeader17.Width = 250
        '
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPreview.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPreview.FlatAppearance.BorderSize = 0
        Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.ForeColor = System.Drawing.Color.White
        Me.btnPreview.Location = New System.Drawing.Point(250, 467)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(108, 60)
        Me.btnPreview.TabIndex = 60
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        'btnSearchAttachment
        '
        Me.btnSearchAttachment.BackColor = System.Drawing.Color.Gray
        Me.btnSearchAttachment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchAttachment.ForeColor = System.Drawing.Color.White
        Me.btnSearchAttachment.Location = New System.Drawing.Point(292, 17)
        Me.btnSearchAttachment.Name = "btnSearchAttachment"
        Me.btnSearchAttachment.Size = New System.Drawing.Size(61, 24)
        Me.btnSearchAttachment.TabIndex = 59
        Me.btnSearchAttachment.Text = "Search"
        Me.btnSearchAttachment.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Search"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(76, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(210, 22)
        Me.TextBox1.TabIndex = 34
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(364, 467)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 60)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Disable"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(136, 467)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(108, 60)
        Me.btnEdit.TabIndex = 32
        Me.btnEdit.Text = "Edit Picture"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnAddNew
        '
        Me.btnAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddNew.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnAddNew.FlatAppearance.BorderSize = 0
        Me.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.ForeColor = System.Drawing.Color.White
        Me.btnAddNew.Location = New System.Drawing.Point(22, 467)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(108, 60)
        Me.btnAddNew.TabIndex = 33
        Me.btnAddNew.Text = "Add Picture"
        Me.btnAddNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddNew.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Gray
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(974, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(123, 39)
        Me.btnClose.TabIndex = 53
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'gbxAddEdit
        '
        Me.gbxAddEdit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbxAddEdit.BackColor = System.Drawing.Color.LightGray
        Me.gbxAddEdit.Controls.Add(Me.Label8)
        Me.gbxAddEdit.Controls.Add(Me.txtClientID)
        Me.gbxAddEdit.Controls.Add(Me.txtReqID)
        Me.gbxAddEdit.Controls.Add(Me.txtName)
        Me.gbxAddEdit.Controls.Add(Me.btnFind)
        Me.gbxAddEdit.Controls.Add(Me.cbxReqType)
        Me.gbxAddEdit.Controls.Add(Me.DateTimePicker1)
        Me.gbxAddEdit.Controls.Add(Me.Label7)
        Me.gbxAddEdit.Controls.Add(Me.Label6)
        Me.gbxAddEdit.Controls.Add(Me.Label4)
        Me.gbxAddEdit.Controls.Add(Me.Label2)
        Me.gbxAddEdit.Controls.Add(Me.Label5)
        Me.gbxAddEdit.Controls.Add(Me.txt_Remarks)
        Me.gbxAddEdit.Controls.Add(Me.btnUpload)
        Me.gbxAddEdit.Controls.Add(Me.PictureBox1)
        Me.gbxAddEdit.Controls.Add(Me.btnCancel)
        Me.gbxAddEdit.Controls.Add(Me.btnSave)
        Me.gbxAddEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxAddEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAddEdit.Location = New System.Drawing.Point(141, 58)
        Me.gbxAddEdit.Name = "gbxAddEdit"
        Me.gbxAddEdit.Size = New System.Drawing.Size(832, 456)
        Me.gbxAddEdit.TabIndex = 62
        Me.gbxAddEdit.TabStop = False
        Me.gbxAddEdit.Text = "Add New Requirement"
        Me.gbxAddEdit.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(26, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 16)
        Me.Label8.TabIndex = 175
        Me.Label8.Text = "Name"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtClientID
        '
        Me.txtClientID.Enabled = False
        Me.txtClientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientID.Location = New System.Drawing.Point(153, 92)
        Me.txtClientID.Name = "txtClientID"
        Me.txtClientID.ReadOnly = True
        Me.txtClientID.Size = New System.Drawing.Size(163, 26)
        Me.txtClientID.TabIndex = 174
        '
        'txtReqID
        '
        Me.txtReqID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReqID.Location = New System.Drawing.Point(153, 60)
        Me.txtReqID.Name = "txtReqID"
        Me.txtReqID.ReadOnly = True
        Me.txtReqID.Size = New System.Drawing.Size(163, 26)
        Me.txtReqID.TabIndex = 173
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(153, 126)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(286, 26)
        Me.txtName.TabIndex = 172
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.Gray
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ForeColor = System.Drawing.Color.White
        Me.btnFind.Location = New System.Drawing.Point(321, 90)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(117, 29)
        Me.btnFind.TabIndex = 171
        Me.btnFind.Text = "View All Clients..."
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'cbxReqType
        '
        Me.cbxReqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxReqType.FormattingEnabled = True
        Me.cbxReqType.Items.AddRange(New Object() {"Loan application requirements", "Promisory requirements"})
        Me.cbxReqType.Location = New System.Drawing.Point(153, 160)
        Me.cbxReqType.Name = "cbxReqType"
        Me.cbxReqType.Size = New System.Drawing.Size(286, 28)
        Me.cbxReqType.TabIndex = 81
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(155, 193)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(284, 26)
        Me.DateTimePicker1.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(26, 225)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 80
        Me.Label7.Text = "Remarks"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Date Upload"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Requirement Type"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 16)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Client ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 16)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Requirement ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_Remarks
        '
        Me.txt_Remarks.Location = New System.Drawing.Point(153, 225)
        Me.txt_Remarks.Multiline = True
        Me.txt_Remarks.Name = "txt_Remarks"
        Me.txt_Remarks.Size = New System.Drawing.Size(286, 93)
        Me.txt_Remarks.TabIndex = 4
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpload.ForeColor = System.Drawing.SystemColors.Window
        Me.btnUpload.Location = New System.Drawing.Point(695, 327)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(119, 32)
        Me.btnUpload.TabIndex = 70
        Me.btnUpload.Text = "Browse Image"
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(456, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(358, 260)
        Me.PictureBox1.TabIndex = 69
        Me.PictureBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(282, 354)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 60)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(153, 354)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 60)
        Me.btnSave.TabIndex = 27
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "ofd1"
        '
        'gbxShowClient
        '
        Me.gbxShowClient.BackColor = System.Drawing.Color.DarkGray
        Me.gbxShowClient.Controls.Add(Me.btnClientBack)
        Me.gbxShowClient.Controls.Add(Me.lvClientList)
        Me.gbxShowClient.Controls.Add(Me.btnSelectSearchClient)
        Me.gbxShowClient.Controls.Add(Me.btnSearchClient)
        Me.gbxShowClient.Controls.Add(Me.txtSearchClient)
        Me.gbxShowClient.Controls.Add(Me.Label28)
        Me.gbxShowClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxShowClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxShowClient.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbxShowClient.Location = New System.Drawing.Point(230, 43)
        Me.gbxShowClient.Name = "gbxShowClient"
        Me.gbxShowClient.Size = New System.Drawing.Size(753, 374)
        Me.gbxShowClient.TabIndex = 160
        Me.gbxShowClient.TabStop = False
        Me.gbxShowClient.Text = "Select a Client"
        Me.gbxShowClient.Visible = False
        '
        'btnClientBack
        '
        Me.btnClientBack.BackColor = System.Drawing.Color.Gray
        Me.btnClientBack.FlatAppearance.BorderSize = 0
        Me.btnClientBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClientBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientBack.ForeColor = System.Drawing.Color.White
        Me.btnClientBack.Location = New System.Drawing.Point(638, 25)
        Me.btnClientBack.Name = "btnClientBack"
        Me.btnClientBack.Size = New System.Drawing.Size(84, 33)
        Me.btnClientBack.TabIndex = 163
        Me.btnClientBack.Text = "Back"
        Me.btnClientBack.UseVisualStyleBackColor = False
        '
        'lvClientList
        '
        Me.lvClientList.AutoArrange = False
        Me.lvClientList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16})
        Me.lvClientList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvClientList.FullRowSelect = True
        Me.lvClientList.GridLines = True
        Me.lvClientList.Location = New System.Drawing.Point(32, 68)
        Me.lvClientList.Name = "lvClientList"
        Me.lvClientList.Size = New System.Drawing.Size(690, 216)
        Me.lvClientList.TabIndex = 130
        Me.lvClientList.UseCompatibleStateImageBehavior = False
        Me.lvClientList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Client ID"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Name"
        Me.ColumnHeader10.Width = 239
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Company"
        Me.ColumnHeader11.Width = 93
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Branch"
        Me.ColumnHeader12.Width = 188
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Employee No."
        Me.ColumnHeader13.Width = 93
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "CreditLimit"
        Me.ColumnHeader14.Width = 100
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "AvailableCredit"
        Me.ColumnHeader15.Width = 120
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "pic"
        Me.ColumnHeader16.Width = 0
        '
        'btnSelectSearchClient
        '
        Me.btnSelectSearchClient.BackColor = System.Drawing.Color.Gray
        Me.btnSelectSearchClient.FlatAppearance.BorderSize = 0
        Me.btnSelectSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectSearchClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectSearchClient.ForeColor = System.Drawing.Color.White
        Me.btnSelectSearchClient.Location = New System.Drawing.Point(280, 298)
        Me.btnSelectSearchClient.Name = "btnSelectSearchClient"
        Me.btnSelectSearchClient.Size = New System.Drawing.Size(192, 55)
        Me.btnSelectSearchClient.TabIndex = 58
        Me.btnSelectSearchClient.Text = "Select "
        Me.btnSelectSearchClient.UseVisualStyleBackColor = False
        '
        'btnSearchClient
        '
        Me.btnSearchClient.BackColor = System.Drawing.Color.Gray
        Me.btnSearchClient.FlatAppearance.BorderSize = 0
        Me.btnSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchClient.ForeColor = System.Drawing.Color.White
        Me.btnSearchClient.Location = New System.Drawing.Point(271, 36)
        Me.btnSearchClient.Name = "btnSearchClient"
        Me.btnSearchClient.Size = New System.Drawing.Size(61, 24)
        Me.btnSearchClient.TabIndex = 58
        Me.btnSearchClient.Text = "Search"
        Me.btnSearchClient.UseVisualStyleBackColor = False
        '
        'txtSearchClient
        '
        Me.txtSearchClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchClient.Location = New System.Drawing.Point(99, 36)
        Me.txtSearchClient.Name = "txtSearchClient"
        Me.txtSearchClient.Size = New System.Drawing.Size(166, 22)
        Me.txtSearchClient.TabIndex = 57
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(29, 39)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(51, 16)
        Me.Label28.TabIndex = 56
        Me.Label28.Text = "Search"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Attachments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbxAddEdit)
        Me.Controls.Add(Me.gbxShowClient)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "Attachments"
        Me.Size = New System.Drawing.Size(1135, 798)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.gbxAddEdit.ResumeLayout(False)
        Me.gbxAddEdit.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxShowClient.ResumeLayout(False)
        Me.gbxShowClient.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnSearchAttachment As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbxAddEdit As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txt_Remarks As System.Windows.Forms.TextBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

    Private Sub txtReqID_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub txtClientID_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub txtReqType_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub txtDateUpload_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub txt_Remarks_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ServiceController1 As System.ServiceProcess.ServiceController
    Friend WithEvents cbxReqType As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtClientID As System.Windows.Forms.TextBox
    Friend WithEvents txtReqID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents gbxShowClient As System.Windows.Forms.GroupBox
    Friend WithEvents btnClientBack As System.Windows.Forms.Button
    Friend WithEvents lvClientList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSelectSearchClient As System.Windows.Forms.Button
    Friend WithEvents btnSearchClient As System.Windows.Forms.Button
    Friend WithEvents txtSearchClient As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
End Class
