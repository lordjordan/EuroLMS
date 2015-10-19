<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoansV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoansV2))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lvLoanList = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearchLoan = New System.Windows.Forms.Button()
        Me.btnUploadLoanApplcation = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSearchLoan = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbxAddEdit = New System.Windows.Forms.GroupBox()
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
        Me.gbxClientData = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAvailableCredit = New System.Windows.Forms.TextBox()
        Me.txtBranch = New System.Windows.Forms.TextBox()
        Me.txtCreditLimit = New System.Windows.Forms.TextBox()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtClientID = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblEmployeeNumber = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gbxLoanData1 = New System.Windows.Forms.GroupBox()
        Me.cboLoanStatus = New System.Windows.Forms.ComboBox()
        Me.cboApplicationStatus = New System.Windows.Forms.ComboBox()
        Me.txtPrincipal = New System.Windows.Forms.TextBox()
        Me.cboInterest = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.txtLoanRemarks = New System.Windows.Forms.TextBox()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gbxLoanData2 = New System.Windows.Forms.GroupBox()
        Me.txtMonthlyInterest = New System.Windows.Forms.TextBox()
        Me.txtTotalLoanAmount = New System.Windows.Forms.TextBox()
        Me.txtTotalInterest = New System.Windows.Forms.TextBox()
        Me.txtBiMonthlyAmort = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlMain.SuspendLayout()
        Me.gbxAddEdit.SuspendLayout()
        Me.gbxShowClient.SuspendLayout()
        Me.gbxClientData.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxLoanData1.SuspendLayout()
        Me.gbxLoanData2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkViolet
        Me.Label1.Location = New System.Drawing.Point(30, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(273, 39)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Loan Master List"
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Controls.Add(Me.lvLoanList)
        Me.pnlMain.Controls.Add(Me.btnSearchLoan)
        Me.pnlMain.Controls.Add(Me.btnUploadLoanApplcation)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.txtSearchLoan)
        Me.pnlMain.Controls.Add(Me.Button2)
        Me.pnlMain.Controls.Add(Me.btnEdit)
        Me.pnlMain.Controls.Add(Me.btnAddNew)
        Me.pnlMain.Location = New System.Drawing.Point(18, 62)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1079, 610)
        Me.pnlMain.TabIndex = 53
        '
        'lvLoanList
        '
        Me.lvLoanList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvLoanList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader18, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23})
        Me.lvLoanList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvLoanList.FullRowSelect = True
        Me.lvLoanList.GridLines = True
        Me.lvLoanList.Location = New System.Drawing.Point(22, 62)
        Me.lvLoanList.Name = "lvLoanList"
        Me.lvLoanList.Size = New System.Drawing.Size(1043, 458)
        Me.lvLoanList.TabIndex = 30
        Me.lvLoanList.UseCompatibleStateImageBehavior = False
        Me.lvLoanList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Loan id"
        Me.ColumnHeader1.Width = 81
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 182
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Principal"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 161
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Bi-Monthly Amort."
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 127
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Interest"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Terms"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Date Start"
        Me.ColumnHeader20.Width = 100
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Date End"
        Me.ColumnHeader21.Width = 104
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Application Status"
        Me.ColumnHeader22.Width = 118
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Loan Status"
        Me.ColumnHeader23.Width = 104
        '
        'btnSearchLoan
        '
        Me.btnSearchLoan.BackColor = System.Drawing.Color.Gray
        Me.btnSearchLoan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchLoan.ForeColor = System.Drawing.Color.White
        Me.btnSearchLoan.Location = New System.Drawing.Point(292, 15)
        Me.btnSearchLoan.Name = "btnSearchLoan"
        Me.btnSearchLoan.Size = New System.Drawing.Size(61, 24)
        Me.btnSearchLoan.TabIndex = 59
        Me.btnSearchLoan.Text = "Search"
        Me.btnSearchLoan.UseVisualStyleBackColor = False
        '
        'btnUploadLoanApplcation
        '
        Me.btnUploadLoanApplcation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUploadLoanApplcation.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnUploadLoanApplcation.FlatAppearance.BorderSize = 0
        Me.btnUploadLoanApplcation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadLoanApplcation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUploadLoanApplcation.ForeColor = System.Drawing.Color.White
        Me.btnUploadLoanApplcation.Location = New System.Drawing.Point(364, 529)
        Me.btnUploadLoanApplcation.Name = "btnUploadLoanApplcation"
        Me.btnUploadLoanApplcation.Size = New System.Drawing.Size(108, 60)
        Me.btnUploadLoanApplcation.TabIndex = 38
        Me.btnUploadLoanApplcation.Text = "Upload File"
        Me.btnUploadLoanApplcation.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUploadLoanApplcation.UseVisualStyleBackColor = False
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
        'txtSearchLoan
        '
        Me.txtSearchLoan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchLoan.Location = New System.Drawing.Point(76, 16)
        Me.txtSearchLoan.Name = "txtSearchLoan"
        Me.txtSearchLoan.Size = New System.Drawing.Size(210, 22)
        Me.txtSearchLoan.TabIndex = 34
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(250, 529)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 60)
        Me.Button2.TabIndex = 31
        Me.Button2.Text = "Disable Loan"
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
        Me.btnEdit.Location = New System.Drawing.Point(136, 529)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(108, 60)
        Me.btnEdit.TabIndex = 32
        Me.btnEdit.Text = "Edit Loan"
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
        Me.btnAddNew.Location = New System.Drawing.Point(22, 529)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(108, 60)
        Me.btnAddNew.TabIndex = 33
        Me.btnAddNew.Text = "Add Loan"
        Me.btnAddNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddNew.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Gray
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(962, 17)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(123, 39)
        Me.btnClose.TabIndex = 54
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'gbxAddEdit
        '
        Me.gbxAddEdit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbxAddEdit.BackColor = System.Drawing.Color.LightGray
        Me.gbxAddEdit.Controls.Add(Me.PictureBox2)
        Me.gbxAddEdit.Controls.Add(Me.PictureBox1)
        Me.gbxAddEdit.Controls.Add(Me.gbxShowClient)
        Me.gbxAddEdit.Controls.Add(Me.gbxClientData)
        Me.gbxAddEdit.Controls.Add(Me.gbxLoanData1)
        Me.gbxAddEdit.Controls.Add(Me.gbxLoanData2)
        Me.gbxAddEdit.Controls.Add(Me.btnSave)
        Me.gbxAddEdit.Controls.Add(Me.btnCancel)
        Me.gbxAddEdit.Controls.Add(Me.GroupBox1)
        Me.gbxAddEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxAddEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAddEdit.Location = New System.Drawing.Point(194, 8)
        Me.gbxAddEdit.Name = "gbxAddEdit"
        Me.gbxAddEdit.Size = New System.Drawing.Size(762, 661)
        Me.gbxAddEdit.TabIndex = 56
        Me.gbxAddEdit.TabStop = False
        Me.gbxAddEdit.Text = "New Loan Application"
        Me.gbxAddEdit.Visible = False
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
        Me.gbxShowClient.Location = New System.Drawing.Point(6, 220)
        Me.gbxShowClient.Name = "gbxShowClient"
        Me.gbxShowClient.Size = New System.Drawing.Size(750, 390)
        Me.gbxShowClient.TabIndex = 159
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
        Me.btnClientBack.Location = New System.Drawing.Point(634, 31)
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
        Me.lvClientList.Size = New System.Drawing.Size(686, 285)
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
        Me.btnSelectSearchClient.Location = New System.Drawing.Point(316, 360)
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
        'gbxClientData
        '
        Me.gbxClientData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxClientData.Controls.Add(Me.txtName)
        Me.gbxClientData.Controls.Add(Me.txtAvailableCredit)
        Me.gbxClientData.Controls.Add(Me.txtBranch)
        Me.gbxClientData.Controls.Add(Me.txtCreditLimit)
        Me.gbxClientData.Controls.Add(Me.txtCompany)
        Me.gbxClientData.Controls.Add(Me.Label7)
        Me.gbxClientData.Controls.Add(Me.txtClientID)
        Me.gbxClientData.Controls.Add(Me.Label22)
        Me.gbxClientData.Controls.Add(Me.Label5)
        Me.gbxClientData.Controls.Add(Me.btnFind)
        Me.gbxClientData.Controls.Add(Me.Label13)
        Me.gbxClientData.Controls.Add(Me.Label6)
        Me.gbxClientData.Controls.Add(Me.lblEmployeeNumber)
        Me.gbxClientData.Controls.Add(Me.Label4)
        Me.gbxClientData.Location = New System.Drawing.Point(11, 28)
        Me.gbxClientData.Name = "gbxClientData"
        Me.gbxClientData.Size = New System.Drawing.Size(738, 186)
        Me.gbxClientData.TabIndex = 173
        Me.gbxClientData.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(591, 7)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(122, 121)
        Me.PictureBox2.TabIndex = 171
        Me.PictureBox2.TabStop = False
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(133, 78)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(258, 26)
        Me.txtName.TabIndex = 170
        '
        'txtAvailableCredit
        '
        Me.txtAvailableCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvailableCredit.Location = New System.Drawing.Point(557, 142)
        Me.txtAvailableCredit.Name = "txtAvailableCredit"
        Me.txtAvailableCredit.ReadOnly = True
        Me.txtAvailableCredit.Size = New System.Drawing.Size(156, 26)
        Me.txtAvailableCredit.TabIndex = 170
        Me.txtAvailableCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBranch
        '
        Me.txtBranch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranch.Location = New System.Drawing.Point(133, 142)
        Me.txtBranch.Name = "txtBranch"
        Me.txtBranch.ReadOnly = True
        Me.txtBranch.Size = New System.Drawing.Size(258, 26)
        Me.txtBranch.TabIndex = 170
        '
        'txtCreditLimit
        '
        Me.txtCreditLimit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCreditLimit.Location = New System.Drawing.Point(557, 110)
        Me.txtCreditLimit.Name = "txtCreditLimit"
        Me.txtCreditLimit.ReadOnly = True
        Me.txtCreditLimit.Size = New System.Drawing.Size(156, 26)
        Me.txtCreditLimit.TabIndex = 170
        Me.txtCreditLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCompany
        '
        Me.txtCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompany.Location = New System.Drawing.Point(133, 110)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.ReadOnly = True
        Me.txtCompany.Size = New System.Drawing.Size(258, 26)
        Me.txtCompany.TabIndex = 170
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(437, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 16)
        Me.Label7.TabIndex = 167
        Me.Label7.Text = "Credit Limit"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtClientID
        '
        Me.txtClientID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientID.Location = New System.Drawing.Point(133, 46)
        Me.txtClientID.Name = "txtClientID"
        Me.txtClientID.ReadOnly = True
        Me.txtClientID.Size = New System.Drawing.Size(127, 26)
        Me.txtClientID.TabIndex = 170
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(21, 116)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 16)
        Me.Label22.TabIndex = 167
        Me.Label22.Text = "Company"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(437, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 16)
        Me.Label5.TabIndex = 139
        Me.Label5.Text = "Available Credit"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.Gray
        Me.btnFind.FlatAppearance.BorderSize = 0
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFind.ForeColor = System.Drawing.Color.White
        Me.btnFind.Location = New System.Drawing.Point(266, 43)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(125, 29)
        Me.btnFind.TabIndex = 162
        Me.btnFind.Text = "View All Clients..."
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(21, 148)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 16)
        Me.Label13.TabIndex = 139
        Me.Label13.Text = "Branch"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(21, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 16)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "Name"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblEmployeeNumber
        '
        Me.lblEmployeeNumber.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblEmployeeNumber.AutoSize = True
        Me.lblEmployeeNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeNumber.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblEmployeeNumber.Location = New System.Drawing.Point(437, 52)
        Me.lblEmployeeNumber.Name = "lblEmployeeNumber"
        Me.lblEmployeeNumber.Size = New System.Drawing.Size(136, 16)
        Me.lblEmployeeNumber.TabIndex = 127
        Me.lblEmployeeNumber.Text = "Employee Number"
        Me.lblEmployeeNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(21, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "Client I.D"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'gbxLoanData1
        '
        Me.gbxLoanData1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxLoanData1.Controls.Add(Me.DataGridView1)
        Me.gbxLoanData1.Controls.Add(Me.cboLoanStatus)
        Me.gbxLoanData1.Controls.Add(Me.cboApplicationStatus)
        Me.gbxLoanData1.Controls.Add(Me.txtPrincipal)
        Me.gbxLoanData1.Controls.Add(Me.cboInterest)
        Me.gbxLoanData1.Controls.Add(Me.Label16)
        Me.gbxLoanData1.Controls.Add(Me.txtTerms)
        Me.gbxLoanData1.Controls.Add(Me.txtLoanRemarks)
        Me.gbxLoanData1.Controls.Add(Me.dtEnd)
        Me.gbxLoanData1.Controls.Add(Me.Label21)
        Me.gbxLoanData1.Controls.Add(Me.Label15)
        Me.gbxLoanData1.Controls.Add(Me.Label8)
        Me.gbxLoanData1.Controls.Add(Me.Label10)
        Me.gbxLoanData1.Controls.Add(Me.dtStart)
        Me.gbxLoanData1.Controls.Add(Me.Label2)
        Me.gbxLoanData1.Controls.Add(Me.Label11)
        Me.gbxLoanData1.Controls.Add(Me.Label9)
        Me.gbxLoanData1.Location = New System.Drawing.Point(11, 209)
        Me.gbxLoanData1.Name = "gbxLoanData1"
        Me.gbxLoanData1.Size = New System.Drawing.Size(738, 272)
        Me.gbxLoanData1.TabIndex = 173
        Me.gbxLoanData1.TabStop = False
        '
        'cboLoanStatus
        '
        Me.cboLoanStatus.Enabled = False
        Me.cboLoanStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoanStatus.FormattingEnabled = True
        Me.cboLoanStatus.Items.AddRange(New Object() {"In process", "Active", "Completed", "Re-Structured", "Force Stop"})
        Me.cboLoanStatus.Location = New System.Drawing.Point(133, 143)
        Me.cboLoanStatus.Name = "cboLoanStatus"
        Me.cboLoanStatus.Size = New System.Drawing.Size(163, 28)
        Me.cboLoanStatus.TabIndex = 173
        Me.cboLoanStatus.Text = "In process"
        '
        'cboApplicationStatus
        '
        Me.cboApplicationStatus.Enabled = False
        Me.cboApplicationStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboApplicationStatus.FormattingEnabled = True
        Me.cboApplicationStatus.Items.AddRange(New Object() {"In process", "Approved", "Declined"})
        Me.cboApplicationStatus.Location = New System.Drawing.Point(133, 111)
        Me.cboApplicationStatus.Name = "cboApplicationStatus"
        Me.cboApplicationStatus.Size = New System.Drawing.Size(163, 28)
        Me.cboApplicationStatus.TabIndex = 173
        Me.cboApplicationStatus.Text = "In process"
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipal.Location = New System.Drawing.Point(133, 14)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Size = New System.Drawing.Size(258, 26)
        Me.txtPrincipal.TabIndex = 135
        Me.txtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboInterest
        '
        Me.cboInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInterest.FormattingEnabled = True
        Me.cboInterest.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboInterest.Location = New System.Drawing.Point(133, 46)
        Me.cboInterest.Name = "cboInterest"
        Me.cboInterest.Size = New System.Drawing.Size(163, 28)
        Me.cboInterest.TabIndex = 146
        Me.cboInterest.Text = "6"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(19, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 145
        Me.Label16.Text = "Interest rate (%)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTerms
        '
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(133, 79)
        Me.txtTerms.MaxLength = 4
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Size = New System.Drawing.Size(163, 26)
        Me.txtTerms.TabIndex = 172
        '
        'txtLoanRemarks
        '
        Me.txtLoanRemarks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanRemarks.Location = New System.Drawing.Point(133, 177)
        Me.txtLoanRemarks.Multiline = True
        Me.txtLoanRemarks.Name = "txtLoanRemarks"
        Me.txtLoanRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLoanRemarks.Size = New System.Drawing.Size(258, 76)
        Me.txtLoanRemarks.TabIndex = 160
        '
        'dtEnd
        '
        Me.dtEnd.CustomFormat = "MM/dd/yyyy"
        Me.dtEnd.Enabled = False
        Me.dtEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEnd.Location = New System.Drawing.Point(557, 44)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(156, 26)
        Me.dtEnd.TabIndex = 144
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(12, 182)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(99, 16)
        Me.Label21.TabIndex = 159
        Me.Label21.Text = "Loan Remarks:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(437, 52)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 16)
        Me.Label15.TabIndex = 143
        Me.Label15.Text = "Date end"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(19, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 16)
        Me.Label8.TabIndex = 171
        Me.Label8.Text = "Terms (months)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(12, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 16)
        Me.Label10.TabIndex = 150
        Me.Label10.Text = "Loan Status"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtStart
        '
        Me.dtStart.CustomFormat = ""
        Me.dtStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtStart.Location = New System.Drawing.Point(557, 12)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(156, 26)
        Me.dtStart.TabIndex = 142
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(12, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 16)
        Me.Label2.TabIndex = 150
        Me.Label2.Text = "Application Status"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(437, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "Date start"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(19, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 16)
        Me.Label9.TabIndex = 134
        Me.Label9.Text = "Principal Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'gbxLoanData2
        '
        Me.gbxLoanData2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxLoanData2.Controls.Add(Me.txtMonthlyInterest)
        Me.gbxLoanData2.Controls.Add(Me.txtTotalLoanAmount)
        Me.gbxLoanData2.Controls.Add(Me.txtTotalInterest)
        Me.gbxLoanData2.Controls.Add(Me.txtBiMonthlyAmort)
        Me.gbxLoanData2.Controls.Add(Me.Label14)
        Me.gbxLoanData2.Controls.Add(Me.Label17)
        Me.gbxLoanData2.Controls.Add(Me.Label19)
        Me.gbxLoanData2.Controls.Add(Me.Label20)
        Me.gbxLoanData2.Location = New System.Drawing.Point(11, 473)
        Me.gbxLoanData2.Name = "gbxLoanData2"
        Me.gbxLoanData2.Size = New System.Drawing.Size(738, 82)
        Me.gbxLoanData2.TabIndex = 173
        Me.gbxLoanData2.TabStop = False
        '
        'txtMonthlyInterest
        '
        Me.txtMonthlyInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonthlyInterest.Location = New System.Drawing.Point(133, 14)
        Me.txtMonthlyInterest.Name = "txtMonthlyInterest"
        Me.txtMonthlyInterest.ReadOnly = True
        Me.txtMonthlyInterest.Size = New System.Drawing.Size(163, 26)
        Me.txtMonthlyInterest.TabIndex = 135
        Me.txtMonthlyInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalLoanAmount
        '
        Me.txtTotalLoanAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLoanAmount.Location = New System.Drawing.Point(557, 46)
        Me.txtTotalLoanAmount.MaxLength = 4
        Me.txtTotalLoanAmount.Name = "txtTotalLoanAmount"
        Me.txtTotalLoanAmount.ReadOnly = True
        Me.txtTotalLoanAmount.Size = New System.Drawing.Size(156, 26)
        Me.txtTotalLoanAmount.TabIndex = 172
        Me.txtTotalLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalInterest
        '
        Me.txtTotalInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalInterest.Location = New System.Drawing.Point(557, 14)
        Me.txtTotalInterest.MaxLength = 4
        Me.txtTotalInterest.Name = "txtTotalInterest"
        Me.txtTotalInterest.ReadOnly = True
        Me.txtTotalInterest.Size = New System.Drawing.Size(156, 26)
        Me.txtTotalInterest.TabIndex = 172
        Me.txtTotalInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBiMonthlyAmort
        '
        Me.txtBiMonthlyAmort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBiMonthlyAmort.Location = New System.Drawing.Point(133, 46)
        Me.txtBiMonthlyAmort.MaxLength = 4
        Me.txtBiMonthlyAmort.Name = "txtBiMonthlyAmort"
        Me.txtBiMonthlyAmort.ReadOnly = True
        Me.txtBiMonthlyAmort.Size = New System.Drawing.Size(163, 26)
        Me.txtBiMonthlyAmort.TabIndex = 172
        Me.txtBiMonthlyAmort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(437, 52)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 143
        Me.Label14.Text = "Total Loan Amount"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(19, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 16)
        Me.Label17.TabIndex = 171
        Me.Label17.Text = "Bi-monthly Amort."
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(437, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 16)
        Me.Label19.TabIndex = 141
        Me.Label19.Text = "Total Interest"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(19, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 16)
        Me.Label20.TabIndex = 134
        Me.Label20.Text = "Monthly Interest"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(11, 592)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 60)
        Me.btnSave.TabIndex = 125
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(125, 592)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 60)
        Me.btnCancel.TabIndex = 123
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Location = New System.Drawing.Point(451, 561)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 98)
        Me.GroupBox1.TabIndex = 173
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gray
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(32, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(247, 29)
        Me.Button1.TabIndex = 163
        Me.Button1.Text = "Manage Co-makers"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(170, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(109, 26)
        Me.TextBox1.TabIndex = 135
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(29, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(139, 16)
        Me.Label23.TabIndex = 134
        Me.Label23.Text = "Number of Co-makers"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(440, 79)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(273, 174)
        Me.DataGridView1.TabIndex = 174
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PictureBox1.Location = New System.Drawing.Point(583, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(137, 132)
        Me.PictureBox1.TabIndex = 174
        Me.PictureBox1.TabStop = False
        '
        'LoansV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbxAddEdit)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "LoansV2"
        Me.Size = New System.Drawing.Size(1110, 674)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.gbxAddEdit.ResumeLayout(False)
        Me.gbxShowClient.ResumeLayout(False)
        Me.gbxShowClient.PerformLayout()
        Me.gbxClientData.ResumeLayout(False)
        Me.gbxClientData.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxLoanData1.ResumeLayout(False)
        Me.gbxLoanData1.PerformLayout()
        Me.gbxLoanData2.ResumeLayout(False)
        Me.gbxLoanData2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lvLoanList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearchLoan As System.Windows.Forms.Button
    Friend WithEvents btnUploadLoanApplcation As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearchLoan As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents gbxAddEdit As System.Windows.Forms.GroupBox
    Friend WithEvents gbxClientData As System.Windows.Forms.GroupBox
    Friend WithEvents cboApplicationStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents txtLoanRemarks As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboInterest As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPrincipal As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbxLoanData1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtBranch As System.Windows.Forms.TextBox
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents txtClientID As System.Windows.Forms.TextBox
    Friend WithEvents gbxShowClient As System.Windows.Forms.GroupBox
    Friend WithEvents btnClientBack As System.Windows.Forms.Button
    Friend WithEvents lvClientList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSearchClient As System.Windows.Forms.Button
    Friend WithEvents txtSearchClient As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnSelectSearchClient As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtAvailableCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEmployeeNumber As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbxLoanData2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMonthlyInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtBiMonthlyAmort As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtTotalLoanAmount As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cboLoanStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
