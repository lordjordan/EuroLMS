

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Clients
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Clients))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchClient = New System.Windows.Forms.TextBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Client_id = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.btnDisable = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.gbxAddEdit = New System.Windows.Forms.GroupBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSecurity_info = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtEmpNum = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxCompany = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbxEmpType = New System.Windows.Forms.ComboBox()
        Me.btn_browse = New System.Windows.Forms.Button()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.cbxBranch = New System.Windows.Forms.ComboBox()
        Me.txt_client = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_Credit = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txt_Contact = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_address = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_MName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_LName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_FName = New System.Windows.Forms.TextBox()
        Me.txtpicID = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ServiceController1 = New System.ServiceProcess.ServiceController()
        Me.ofdPic = New System.Windows.Forms.OpenFileDialog()
        Me.Picturebox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlMain.SuspendLayout()
        Me.gbxAddEdit.SuspendLayout()
        CType(Me.Picturebox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Controls.Add(Me.btnSearch)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.txtSearchClient)
        Me.pnlMain.Controls.Add(Me.btnExport)
        Me.pnlMain.Controls.Add(Me.ListView1)
        Me.pnlMain.Controls.Add(Me.btnDisable)
        Me.pnlMain.Controls.Add(Me.btnEdit)
        Me.pnlMain.Controls.Add(Me.btnAddNew)
        Me.pnlMain.Location = New System.Drawing.Point(15, 79)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1028, 504)
        Me.pnlMain.TabIndex = 50
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Gray
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(294, 17)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(61, 24)
        Me.btnSearch.TabIndex = 87
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Search"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSearchClient
        '
        Me.txtSearchClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchClient.Location = New System.Drawing.Point(78, 18)
        Me.txtSearchClient.Name = "txtSearchClient"
        Me.txtSearchClient.Size = New System.Drawing.Size(210, 22)
        Me.txtSearchClient.TabIndex = 85
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(361, 427)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(108, 60)
        Me.btnExport.TabIndex = 84
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Client_id, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(19, 47)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(982, 374)
        Me.ListView1.TabIndex = 30
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Client_id
        '
        Me.Client_id.Text = "Client ID"
        Me.Client_id.Width = 70
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Company Name"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Branch Name"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Full Name"
        Me.ColumnHeader3.Width = 250
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Address"
        Me.ColumnHeader4.Width = 300
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Contact Number"
        Me.ColumnHeader5.Width = 200
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Credit Limit"
        Me.ColumnHeader6.Width = 100
        '
        'btnDisable
        '
        Me.btnDisable.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDisable.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnDisable.FlatAppearance.BorderSize = 0
        Me.btnDisable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisable.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDisable.ForeColor = System.Drawing.Color.White
        Me.btnDisable.Location = New System.Drawing.Point(247, 427)
        Me.btnDisable.Name = "btnDisable"
        Me.btnDisable.Size = New System.Drawing.Size(108, 60)
        Me.btnDisable.TabIndex = 31
        Me.btnDisable.Text = "Disable Client"
        Me.btnDisable.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDisable.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnEdit.FlatAppearance.BorderSize = 0
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.Color.White
        Me.btnEdit.Location = New System.Drawing.Point(133, 427)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(108, 60)
        Me.btnEdit.TabIndex = 32
        Me.btnEdit.Text = "Edit Client"
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
        Me.btnAddNew.Location = New System.Drawing.Point(19, 427)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(108, 60)
        Me.btnAddNew.TabIndex = 33
        Me.btnAddNew.Text = "Add Client"
        Me.btnAddNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddNew.UseVisualStyleBackColor = False
        '
        'gbxAddEdit
        '
        Me.gbxAddEdit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbxAddEdit.BackColor = System.Drawing.Color.LightGray
        Me.gbxAddEdit.Controls.Add(Me.txtStatus)
        Me.gbxAddEdit.Controls.Add(Me.Label17)
        Me.gbxAddEdit.Controls.Add(Me.txtSecurity_info)
        Me.gbxAddEdit.Controls.Add(Me.Label21)
        Me.gbxAddEdit.Controls.Add(Me.Picturebox1)
        Me.gbxAddEdit.Controls.Add(Me.txtEmpNum)
        Me.gbxAddEdit.Controls.Add(Me.Label16)
        Me.gbxAddEdit.Controls.Add(Me.cbxCompany)
        Me.gbxAddEdit.Controls.Add(Me.Label15)
        Me.gbxAddEdit.Controls.Add(Me.cbxEmpType)
        Me.gbxAddEdit.Controls.Add(Me.btn_browse)
        Me.gbxAddEdit.Controls.Add(Me.DateTimePicker2)
        Me.gbxAddEdit.Controls.Add(Me.DateTimePicker1)
        Me.gbxAddEdit.Controls.Add(Me.cbxBranch)
        Me.gbxAddEdit.Controls.Add(Me.txt_client)
        Me.gbxAddEdit.Controls.Add(Me.Label14)
        Me.gbxAddEdit.Controls.Add(Me.txt_Credit)
        Me.gbxAddEdit.Controls.Add(Me.Label13)
        Me.gbxAddEdit.Controls.Add(Me.Label8)
        Me.gbxAddEdit.Controls.Add(Me.Label11)
        Me.gbxAddEdit.Controls.Add(Me.txt_Contact)
        Me.gbxAddEdit.Controls.Add(Me.Label12)
        Me.gbxAddEdit.Controls.Add(Me.Label9)
        Me.gbxAddEdit.Controls.Add(Me.txt_address)
        Me.gbxAddEdit.Controls.Add(Me.Label10)
        Me.gbxAddEdit.Controls.Add(Me.btnCancel)
        Me.gbxAddEdit.Controls.Add(Me.btnSave)
        Me.gbxAddEdit.Controls.Add(Me.Label7)
        Me.gbxAddEdit.Controls.Add(Me.txt_MName)
        Me.gbxAddEdit.Controls.Add(Me.Label6)
        Me.gbxAddEdit.Controls.Add(Me.txt_LName)
        Me.gbxAddEdit.Controls.Add(Me.Label5)
        Me.gbxAddEdit.Controls.Add(Me.Label4)
        Me.gbxAddEdit.Controls.Add(Me.txt_FName)
        Me.gbxAddEdit.Controls.Add(Me.PictureBox2)
        Me.gbxAddEdit.Controls.Add(Me.txtpicID)
        Me.gbxAddEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxAddEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAddEdit.Location = New System.Drawing.Point(217, 68)
        Me.gbxAddEdit.Name = "gbxAddEdit"
        Me.gbxAddEdit.Size = New System.Drawing.Size(735, 585)
        Me.gbxAddEdit.TabIndex = 49
        Me.gbxAddEdit.TabStop = False
        Me.gbxAddEdit.Text = "Add New Client"
        Me.gbxAddEdit.Visible = False
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStatus.Location = New System.Drawing.Point(493, 471)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(52, 26)
        Me.txtStatus.TabIndex = 180
        Me.txtStatus.Text = "active"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(446, 475)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 16)
        Me.Label17.TabIndex = 179
        Me.Label17.Text = "Status"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSecurity_info
        '
        Me.txtSecurity_info.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSecurity_info.Location = New System.Drawing.Point(491, 389)
        Me.txtSecurity_info.Multiline = True
        Me.txtSecurity_info.Name = "txtSecurity_info"
        Me.txtSecurity_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSecurity_info.Size = New System.Drawing.Size(228, 76)
        Me.txtSecurity_info.TabIndex = 12
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(367, 395)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(124, 16)
        Me.Label21.TabIndex = 178
        Me.Label21.Text = "Security Information"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtEmpNum
        '
        Me.txtEmpNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpNum.Location = New System.Drawing.Point(491, 310)
        Me.txtEmpNum.Name = "txtEmpNum"
        Me.txtEmpNum.Size = New System.Drawing.Size(228, 26)
        Me.txtEmpNum.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(367, 318)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 16)
        Me.Label16.TabIndex = 70
        Me.Label16.Text = "Employee Number"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbxCompany
        '
        Me.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCompany.FormattingEnabled = True
        Me.cbxCompany.Location = New System.Drawing.Point(133, 72)
        Me.cbxCompany.Name = "cbxCompany"
        Me.cbxCompany.Size = New System.Drawing.Size(228, 28)
        Me.cbxCompany.TabIndex = 0
        Me.cbxCompany.Tag = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(25, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(106, 16)
        Me.Label15.TabIndex = 69
        Me.Label15.Text = "Company Name"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbxEmpType
        '
        Me.cbxEmpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxEmpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxEmpType.FormattingEnabled = True
        Me.cbxEmpType.Items.AddRange(New Object() {"Contractual", "Regular", "Probationary"})
        Me.cbxEmpType.Location = New System.Drawing.Point(491, 347)
        Me.cbxEmpType.Name = "cbxEmpType"
        Me.cbxEmpType.Size = New System.Drawing.Size(228, 28)
        Me.cbxEmpType.TabIndex = 11
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(612, 275)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(104, 28)
        Me.btn_browse.TabIndex = 62
        Me.btn_browse.Text = "Browse Photo"
        Me.btn_browse.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker2.Location = New System.Drawing.Point(133, 430)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(228, 26)
        Me.DateTimePicker2.TabIndex = 8
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Location = New System.Drawing.Point(133, 233)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(228, 26)
        Me.DateTimePicker1.TabIndex = 5
        '
        'cbxBranch
        '
        Me.cbxBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxBranch.FormattingEnabled = True
        Me.cbxBranch.Location = New System.Drawing.Point(133, 104)
        Me.cbxBranch.Name = "cbxBranch"
        Me.cbxBranch.Size = New System.Drawing.Size(228, 28)
        Me.cbxBranch.TabIndex = 1
        '
        'txt_client
        '
        Me.txt_client.Enabled = False
        Me.txt_client.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_client.Location = New System.Drawing.Point(133, 40)
        Me.txt_client.Name = "txt_client"
        Me.txt_client.Size = New System.Drawing.Size(228, 26)
        Me.txt_client.TabIndex = 59
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(54, 469)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(73, 16)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Credit Limit"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_Credit
        '
        Me.txt_Credit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Credit.Location = New System.Drawing.Point(133, 460)
        Me.txt_Credit.Name = "txt_Credit"
        Me.txt_Credit.Size = New System.Drawing.Size(228, 26)
        Me.txt_Credit.TabIndex = 9
        Me.txt_Credit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(62, 440)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 16)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Date Hire"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(383, 354)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 16)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "Employee Type"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 271)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 16)
        Me.Label11.TabIndex = 45
        Me.Label11.Text = "Contact Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_Contact
        '
        Me.txt_Contact.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Contact.Location = New System.Drawing.Point(133, 265)
        Me.txt_Contact.MaxLength = 11
        Me.txt_Contact.Name = "txt_Contact"
        Me.txt_Contact.Size = New System.Drawing.Size(228, 26)
        Me.txt_Contact.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(38, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 16)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Branch Name"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(72, 302)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 16)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Address"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_address
        '
        Me.txt_address.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_address.Location = New System.Drawing.Point(133, 296)
        Me.txt_address.Multiline = True
        Me.txt_address.Name = "txt_address"
        Me.txt_address.Size = New System.Drawing.Size(228, 130)
        Me.txt_address.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(69, 239)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 16)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Birthdate"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(151, 511)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 60)
        Me.btnCancel.TabIndex = 14
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
        Me.btnSave.Location = New System.Drawing.Point(28, 509)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 60)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(44, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 16)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Middle Name"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_MName
        '
        Me.txt_MName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MName.Location = New System.Drawing.Point(133, 169)
        Me.txt_MName.Name = "txt_MName"
        Me.txt_MName.Size = New System.Drawing.Size(228, 26)
        Me.txt_MName.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(59, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 16)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Last Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_LName
        '
        Me.txt_LName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_LName.Location = New System.Drawing.Point(133, 201)
        Me.txt_LName.Name = "txt_LName"
        Me.txt_LName.Size = New System.Drawing.Size(228, 26)
        Me.txt_LName.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(75, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Client ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(59, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 16)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "First Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txt_FName
        '
        Me.txt_FName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FName.Location = New System.Drawing.Point(133, 137)
        Me.txt_FName.Name = "txt_FName"
        Me.txt_FName.Size = New System.Drawing.Size(228, 26)
        Me.txt_FName.TabIndex = 2
        '
        'txtpicID
        '
        Me.txtpicID.Enabled = False
        Me.txtpicID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpicID.Location = New System.Drawing.Point(460, 50)
        Me.txtpicID.Name = "txtpicID"
        Me.txtpicID.Size = New System.Drawing.Size(48, 26)
        Me.txtpicID.TabIndex = 71
        Me.txtpicID.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Gray
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(909, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(123, 39)
        Me.btnClose.TabIndex = 48
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(26, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 39)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Client List"
        '
        'ofdPic
        '
        Me.ofdPic.FileName = "OpenFileDialog1"
        '
        'Picturebox1
        '
        Me.Picturebox1.BackgroundImage = CType(resources.GetObject("Picturebox1.BackgroundImage"), System.Drawing.Image)
        Me.Picturebox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Picturebox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picturebox1.Location = New System.Drawing.Point(442, 27)
        Me.Picturebox1.Name = "Picturebox1"
        Me.Picturebox1.Size = New System.Drawing.Size(274, 241)
        Me.Picturebox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.Picturebox1.TabIndex = 51
        Me.Picturebox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PictureBox2.Location = New System.Drawing.Point(437, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(284, 247)
        Me.PictureBox2.TabIndex = 177
        Me.PictureBox2.TabStop = False
        '
        'Clients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbxAddEdit)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "Clients"
        Me.Size = New System.Drawing.Size(1056, 673)
        Me.pnlMain.ResumeLayout(false)
        Me.pnlMain.PerformLayout
        Me.gbxAddEdit.ResumeLayout(false)
        Me.gbxAddEdit.PerformLayout
        CType(Me.Picturebox1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.PictureBox2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnDisable As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txt_Contact As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_address As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_MName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_LName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_FName As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gbxAddEdit As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Picturebox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_Credit As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_client As System.Windows.Forms.TextBox
    Friend WithEvents cbxBranch As System.Windows.Forms.ComboBox
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Client_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbxEmpType As System.Windows.Forms.ComboBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cbxCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ServiceController1 As System.ServiceProcess.ServiceController
    Friend WithEvents txtEmpNum As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearchClient As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ofdPic As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtpicID As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtSecurity_info As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class

