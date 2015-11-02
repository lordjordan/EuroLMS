<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectibles
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblInfoSearch = New System.Windows.Forms.Label()
        Me.btnEnterPay = New System.Windows.Forms.Button()
        Me.btnPH = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btnSearchLoan = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSearchLoan = New System.Windows.Forms.TextBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Process = New System.Windows.Forms.Button()
        Me.lvCollectibles = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CMS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsmViewPH = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmInputAmount = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmManagePenalties = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbxAdvanceSearch = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbxCompany = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxBranch = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.gbxClientCollectible = New System.Windows.Forms.GroupBox()
        Me.lblPayableAmount = New System.Windows.Forms.Label()
        Me.lvDuedates = New System.Windows.Forms.ListView()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnManage = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPA = New System.Windows.Forms.Label()
        Me.btnCancelColl = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.gbxPH = New System.Windows.Forms.GroupBox()
        Me.txtDateStart = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalPenalties = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDateEnd = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCollectedAmt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPHback = New System.Windows.Forms.Button()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLoanid = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvPH = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.gbxPrint = New System.Windows.Forms.GroupBox()
        Me.crvPaymentCentralReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnPrintCR = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.CMS.SuspendLayout()
        Me.gbxAdvanceSearch.SuspendLayout()
        Me.gbxClientCollectible.SuspendLayout()
        Me.gbxPH.SuspendLayout()
        Me.gbxPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label1.Location = New System.Drawing.Point(25, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(276, 39)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Payment Central"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Gray
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(946, 20)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(123, 39)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Controls.Add(Me.lblInfoSearch)
        Me.pnlMain.Controls.Add(Me.btnEnterPay)
        Me.pnlMain.Controls.Add(Me.btnPH)
        Me.pnlMain.Controls.Add(Me.btnExport)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.LinkLabel1)
        Me.pnlMain.Controls.Add(Me.btnSearchLoan)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.txtSearchLoan)
        Me.pnlMain.Controls.Add(Me.btnPrint)
        Me.pnlMain.Controls.Add(Me.Process)
        Me.pnlMain.Controls.Add(Me.lvCollectibles)
        Me.pnlMain.Location = New System.Drawing.Point(16, 94)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1053, 599)
        Me.pnlMain.TabIndex = 48
        '
        'lblInfoSearch
        '
        Me.lblInfoSearch.AutoSize = True
        Me.lblInfoSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoSearch.Location = New System.Drawing.Point(108, 78)
        Me.lblInfoSearch.Name = "lblInfoSearch"
        Me.lblInfoSearch.Size = New System.Drawing.Size(20, 15)
        Me.lblInfoSearch.TabIndex = 86
        Me.lblInfoSearch.Text = "All"
        '
        'btnEnterPay
        '
        Me.btnEnterPay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEnterPay.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnEnterPay.FlatAppearance.BorderSize = 0
        Me.btnEnterPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnterPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnterPay.ForeColor = System.Drawing.Color.White
        Me.btnEnterPay.Location = New System.Drawing.Point(9, 518)
        Me.btnEnterPay.Name = "btnEnterPay"
        Me.btnEnterPay.Size = New System.Drawing.Size(108, 60)
        Me.btnEnterPay.TabIndex = 85
        Me.btnEnterPay.Text = "Enter payment"
        Me.btnEnterPay.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEnterPay.UseVisualStyleBackColor = False
        '
        'btnPH
        '
        Me.btnPH.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPH.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPH.FlatAppearance.BorderSize = 0
        Me.btnPH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPH.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPH.ForeColor = System.Drawing.Color.White
        Me.btnPH.Location = New System.Drawing.Point(237, 518)
        Me.btnPH.Name = "btnPH"
        Me.btnPH.Size = New System.Drawing.Size(108, 60)
        Me.btnPH.TabIndex = 84
        Me.btnPH.Text = "Payment his."
        Me.btnPH.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPH.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnExport.FlatAppearance.BorderSize = 0
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Location = New System.Drawing.Point(351, 518)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(108, 60)
        Me.btnExport.TabIndex = 83
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = False
        Me.btnExport.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(60, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 15)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Filtered:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(60, 57)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(95, 15)
        Me.LinkLabel1.TabIndex = 81
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Advance Search"
        '
        'btnSearchLoan
        '
        Me.btnSearchLoan.BackColor = System.Drawing.Color.Gray
        Me.btnSearchLoan.FlatAppearance.BorderSize = 0
        Me.btnSearchLoan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchLoan.ForeColor = System.Drawing.Color.White
        Me.btnSearchLoan.Location = New System.Drawing.Point(279, 22)
        Me.btnSearchLoan.Name = "btnSearchLoan"
        Me.btnSearchLoan.Size = New System.Drawing.Size(66, 23)
        Me.btnSearchLoan.TabIndex = 80
        Me.btnSearchLoan.Text = "Search"
        Me.btnSearchLoan.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 16)
        Me.Label7.TabIndex = 79
        Me.Label7.Text = "Search"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSearchLoan
        '
        Me.txtSearchLoan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchLoan.Location = New System.Drawing.Point(63, 23)
        Me.txtSearchLoan.Name = "txtSearchLoan"
        Me.txtSearchLoan.Size = New System.Drawing.Size(210, 22)
        Me.txtSearchLoan.TabIndex = 78
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(123, 518)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(108, 60)
        Me.btnPrint.TabIndex = 77
        Me.btnPrint.Text = "Print..."
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'Process
        '
        Me.Process.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Process.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Process.FlatAppearance.BorderSize = 0
        Me.Process.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Process.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Process.ForeColor = System.Drawing.Color.White
        Me.Process.Location = New System.Drawing.Point(932, 518)
        Me.Process.Name = "Process"
        Me.Process.Size = New System.Drawing.Size(108, 60)
        Me.Process.TabIndex = 76
        Me.Process.Text = "Process"
        Me.Process.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Process.UseVisualStyleBackColor = False
        '
        'lvCollectibles
        '
        Me.lvCollectibles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCollectibles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader1, Me.ColumnHeader10, Me.ColumnHeader13, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader2, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader14, Me.ColumnHeader16})
        Me.lvCollectibles.ContextMenuStrip = Me.CMS
        Me.lvCollectibles.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCollectibles.FullRowSelect = True
        Me.lvCollectibles.GridLines = True
        Me.lvCollectibles.Location = New System.Drawing.Point(9, 96)
        Me.lvCollectibles.Name = "lvCollectibles"
        Me.lvCollectibles.Size = New System.Drawing.Size(1031, 383)
        Me.lvCollectibles.TabIndex = 30
        Me.lvCollectibles.UseCompatibleStateImageBehavior = False
        Me.lvCollectibles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Loan ID"
        Me.ColumnHeader3.Width = 70
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Due Date"
        Me.ColumnHeader4.Width = 93
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Name"
        Me.ColumnHeader5.Width = 200
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Payable Amount"
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Collected Amount"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader10.Width = 120
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Inputted Amount"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader13.Width = 112
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Penalty Amount"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader11.Width = 120
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Previous Balance"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader12.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Principal Amount"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Interest"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Outstanding Balance"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "ctb_id"
        Me.ColumnHeader14.Width = 0
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "ctb_id specific"
        Me.ColumnHeader16.Width = 0
        '
        'CMS
        '
        Me.CMS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmViewPH, Me.tsmInputAmount, Me.tsmManagePenalties})
        Me.CMS.Name = "ContextMenuStrip1"
        Me.CMS.Size = New System.Drawing.Size(191, 70)
        Me.CMS.Text = "LMS"
        '
        'tsmViewPH
        '
        Me.tsmViewPH.Name = "tsmViewPH"
        Me.tsmViewPH.Size = New System.Drawing.Size(190, 22)
        Me.tsmViewPH.Text = "View Payment History"
        '
        'tsmInputAmount
        '
        Me.tsmInputAmount.Name = "tsmInputAmount"
        Me.tsmInputAmount.Size = New System.Drawing.Size(190, 22)
        Me.tsmInputAmount.Text = "Input amount"
        '
        'tsmManagePenalties
        '
        Me.tsmManagePenalties.Name = "tsmManagePenalties"
        Me.tsmManagePenalties.Size = New System.Drawing.Size(190, 22)
        Me.tsmManagePenalties.Text = "Manage penalties"
        '
        'gbxAdvanceSearch
        '
        Me.gbxAdvanceSearch.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbxAdvanceSearch.BackColor = System.Drawing.Color.LightGray
        Me.gbxAdvanceSearch.Controls.Add(Me.Label13)
        Me.gbxAdvanceSearch.Controls.Add(Me.cbxCompany)
        Me.gbxAdvanceSearch.Controls.Add(Me.Label3)
        Me.gbxAdvanceSearch.Controls.Add(Me.btnCancel)
        Me.gbxAdvanceSearch.Controls.Add(Me.Label6)
        Me.gbxAdvanceSearch.Controls.Add(Me.cbxBranch)
        Me.gbxAdvanceSearch.Controls.Add(Me.btnSearch)
        Me.gbxAdvanceSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAdvanceSearch.Location = New System.Drawing.Point(430, 83)
        Me.gbxAdvanceSearch.Name = "gbxAdvanceSearch"
        Me.gbxAdvanceSearch.Size = New System.Drawing.Size(277, 249)
        Me.gbxAdvanceSearch.TabIndex = 72
        Me.gbxAdvanceSearch.TabStop = False
        Me.gbxAdvanceSearch.Text = "Advanced Search"
        Me.gbxAdvanceSearch.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(27, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 16)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "Company"
        '
        'cbxCompany
        '
        Me.cbxCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCompany.FormattingEnabled = True
        Me.cbxCompany.Location = New System.Drawing.Point(30, 86)
        Me.cbxCompany.Name = "cbxCompany"
        Me.cbxCompany.Size = New System.Drawing.Size(176, 28)
        Me.cbxCompany.TabIndex = 129
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(27, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 16)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "Filter by:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(144, 183)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 60)
        Me.btnCancel.TabIndex = 69
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Branch"
        '
        'cbxBranch
        '
        Me.cbxBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBranch.FormattingEnabled = True
        Me.cbxBranch.Location = New System.Drawing.Point(30, 142)
        Me.cbxBranch.Name = "cbxBranch"
        Me.cbxBranch.Size = New System.Drawing.Size(176, 28)
        Me.cbxBranch.TabIndex = 66
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnSearch.FlatAppearance.BorderSize = 0
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(30, 183)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(108, 60)
        Me.btnSearch.TabIndex = 58
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'gbxClientCollectible
        '
        Me.gbxClientCollectible.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbxClientCollectible.BackColor = System.Drawing.Color.LightGray
        Me.gbxClientCollectible.Controls.Add(Me.lblPayableAmount)
        Me.gbxClientCollectible.Controls.Add(Me.lvDuedates)
        Me.gbxClientCollectible.Controls.Add(Me.btnManage)
        Me.gbxClientCollectible.Controls.Add(Me.Label11)
        Me.gbxClientCollectible.Controls.Add(Me.txtAmount)
        Me.gbxClientCollectible.Controls.Add(Me.Label10)
        Me.gbxClientCollectible.Controls.Add(Me.lblPA)
        Me.gbxClientCollectible.Controls.Add(Me.btnCancelColl)
        Me.gbxClientCollectible.Controls.Add(Me.btnOk)
        Me.gbxClientCollectible.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxClientCollectible.Location = New System.Drawing.Point(354, 83)
        Me.gbxClientCollectible.Name = "gbxClientCollectible"
        Me.gbxClientCollectible.Size = New System.Drawing.Size(446, 422)
        Me.gbxClientCollectible.TabIndex = 45
        Me.gbxClientCollectible.TabStop = False
        Me.gbxClientCollectible.Text = "Client Payment"
        Me.gbxClientCollectible.Visible = False
        '
        'lblPayableAmount
        '
        Me.lblPayableAmount.AutoSize = True
        Me.lblPayableAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblPayableAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayableAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPayableAmount.Location = New System.Drawing.Point(139, 35)
        Me.lblPayableAmount.Name = "lblPayableAmount"
        Me.lblPayableAmount.Size = New System.Drawing.Size(0, 20)
        Me.lblPayableAmount.TabIndex = 170
        Me.lblPayableAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvDuedates
        '
        Me.lvDuedates.CheckBoxes = True
        Me.lvDuedates.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader15})
        Me.lvDuedates.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDuedates.FullRowSelect = True
        Me.lvDuedates.GridLines = True
        Me.lvDuedates.Location = New System.Drawing.Point(31, 196)
        Me.lvDuedates.Name = "lvDuedates"
        Me.lvDuedates.Size = New System.Drawing.Size(379, 151)
        Me.lvDuedates.TabIndex = 77
        Me.lvDuedates.UseCompatibleStateImageBehavior = False
        Me.lvDuedates.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Due date"
        Me.ColumnHeader8.Width = 132
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Penalty Amount"
        Me.ColumnHeader9.Width = 241
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Id"
        '
        'btnManage
        '
        Me.btnManage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnManage.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnManage.FlatAppearance.BorderSize = 0
        Me.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManage.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManage.ForeColor = System.Drawing.Color.White
        Me.btnManage.Location = New System.Drawing.Point(30, 353)
        Me.btnManage.Name = "btnManage"
        Me.btnManage.Size = New System.Drawing.Size(108, 60)
        Me.btnManage.TabIndex = 75
        Me.btnManage.Text = "Manage Penalties"
        Me.btnManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnManage.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 16)
        Me.Label11.TabIndex = 73
        Me.Label11.Text = "Input Amount"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(31, 97)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(378, 44)
        Me.txtAmount.TabIndex = 72
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(27, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 16)
        Me.Label10.TabIndex = 71
        Me.Label10.Text = "Penalties"
        '
        'lblPA
        '
        Me.lblPA.AutoSize = True
        Me.lblPA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPA.Location = New System.Drawing.Point(27, 38)
        Me.lblPA.Name = "lblPA"
        Me.lblPA.Size = New System.Drawing.Size(106, 16)
        Me.lblPA.TabIndex = 70
        Me.lblPA.Text = "Payable amount"
        '
        'btnCancelColl
        '
        Me.btnCancelColl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelColl.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCancelColl.FlatAppearance.BorderSize = 0
        Me.btnCancelColl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelColl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelColl.ForeColor = System.Drawing.Color.White
        Me.btnCancelColl.Location = New System.Drawing.Point(258, 353)
        Me.btnCancelColl.Name = "btnCancelColl"
        Me.btnCancelColl.Size = New System.Drawing.Size(108, 60)
        Me.btnCancelColl.TabIndex = 69
        Me.btnCancelColl.Text = "Cancel"
        Me.btnCancelColl.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelColl.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Location = New System.Drawing.Point(144, 353)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(108, 60)
        Me.btnOk.TabIndex = 58
        Me.btnOk.Text = "OK"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'gbxPH
        '
        Me.gbxPH.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbxPH.BackColor = System.Drawing.Color.LightGray
        Me.gbxPH.Controls.Add(Me.txtDateStart)
        Me.gbxPH.Controls.Add(Me.Label16)
        Me.gbxPH.Controls.Add(Me.txtTotalPenalties)
        Me.gbxPH.Controls.Add(Me.Label15)
        Me.gbxPH.Controls.Add(Me.txtDateEnd)
        Me.gbxPH.Controls.Add(Me.Label12)
        Me.gbxPH.Controls.Add(Me.txtCollectedAmt)
        Me.gbxPH.Controls.Add(Me.Label14)
        Me.gbxPH.Controls.Add(Me.txtTerms)
        Me.gbxPH.Controls.Add(Me.Label5)
        Me.gbxPH.Controls.Add(Me.btnPHback)
        Me.gbxPH.Controls.Add(Me.txtBalance)
        Me.gbxPH.Controls.Add(Me.Label4)
        Me.gbxPH.Controls.Add(Me.txtLoanid)
        Me.gbxPH.Controls.Add(Me.txtname)
        Me.gbxPH.Controls.Add(Me.Label8)
        Me.gbxPH.Controls.Add(Me.Label2)
        Me.gbxPH.Controls.Add(Me.lvPH)
        Me.gbxPH.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxPH.Location = New System.Drawing.Point(236, 83)
        Me.gbxPH.Name = "gbxPH"
        Me.gbxPH.Size = New System.Drawing.Size(659, 533)
        Me.gbxPH.TabIndex = 73
        Me.gbxPH.TabStop = False
        Me.gbxPH.Text = "Payment History"
        Me.gbxPH.Visible = False
        '
        'txtDateStart
        '
        Me.txtDateStart.BackColor = System.Drawing.SystemColors.Control
        Me.txtDateStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateStart.Location = New System.Drawing.Point(497, 148)
        Me.txtDateStart.Name = "txtDateStart"
        Me.txtDateStart.ReadOnly = True
        Me.txtDateStart.Size = New System.Drawing.Size(129, 26)
        Me.txtDateStart.TabIndex = 176
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(424, 153)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 16)
        Me.Label16.TabIndex = 175
        Me.Label16.Text = "Date Start"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTotalPenalties
        '
        Me.txtTotalPenalties.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalPenalties.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPenalties.Location = New System.Drawing.Point(105, 179)
        Me.txtTotalPenalties.Name = "txtTotalPenalties"
        Me.txtTotalPenalties.ReadOnly = True
        Me.txtTotalPenalties.Size = New System.Drawing.Size(222, 26)
        Me.txtTotalPenalties.TabIndex = 174
        Me.txtTotalPenalties.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 183)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 16)
        Me.Label15.TabIndex = 173
        Me.Label15.Text = "Total penalties"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDateEnd
        '
        Me.txtDateEnd.BackColor = System.Drawing.SystemColors.Control
        Me.txtDateEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateEnd.Location = New System.Drawing.Point(497, 183)
        Me.txtDateEnd.Name = "txtDateEnd"
        Me.txtDateEnd.ReadOnly = True
        Me.txtDateEnd.Size = New System.Drawing.Size(129, 26)
        Me.txtDateEnd.TabIndex = 172
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(424, 189)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 16)
        Me.Label12.TabIndex = 171
        Me.Label12.Text = "Date end"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtCollectedAmt
        '
        Me.txtCollectedAmt.BackColor = System.Drawing.SystemColors.Control
        Me.txtCollectedAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectedAmt.Location = New System.Drawing.Point(105, 146)
        Me.txtCollectedAmt.Name = "txtCollectedAmt"
        Me.txtCollectedAmt.ReadOnly = True
        Me.txtCollectedAmt.Size = New System.Drawing.Size(222, 26)
        Me.txtCollectedAmt.TabIndex = 170
        Me.txtCollectedAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 150)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 16)
        Me.Label14.TabIndex = 169
        Me.Label14.Text = "Collected amt."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTerms
        '
        Me.txtTerms.BackColor = System.Drawing.SystemColors.Control
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(497, 114)
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.ReadOnly = True
        Me.txtTerms.Size = New System.Drawing.Size(87, 26)
        Me.txtTerms.TabIndex = 166
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(424, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Terms"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnPHback
        '
        Me.btnPHback.BackColor = System.Drawing.Color.Gray
        Me.btnPHback.FlatAppearance.BorderSize = 0
        Me.btnPHback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPHback.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPHback.ForeColor = System.Drawing.Color.White
        Me.btnPHback.Location = New System.Drawing.Point(569, 8)
        Me.btnPHback.Name = "btnPHback"
        Me.btnPHback.Size = New System.Drawing.Size(84, 33)
        Me.btnPHback.TabIndex = 164
        Me.btnPHback.Text = "Back"
        Me.btnPHback.UseVisualStyleBackColor = False
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.SystemColors.Control
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(105, 114)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(222, 26)
        Me.txtBalance.TabIndex = 86
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Balance"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLoanid
        '
        Me.txtLoanid.BackColor = System.Drawing.SystemColors.Control
        Me.txtLoanid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanid.Location = New System.Drawing.Point(105, 50)
        Me.txtLoanid.Name = "txtLoanid"
        Me.txtLoanid.ReadOnly = True
        Me.txtLoanid.Size = New System.Drawing.Size(222, 26)
        Me.txtLoanid.TabIndex = 84
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.SystemColors.Control
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(105, 82)
        Me.txtname.Name = "txtname"
        Me.txtname.ReadOnly = True
        Me.txtname.Size = New System.Drawing.Size(305, 26)
        Me.txtname.TabIndex = 83
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 16)
        Me.Label8.TabIndex = 82
        Me.Label8.Text = "Loan I.d"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lvPH
        '
        Me.lvPH.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader21})
        Me.lvPH.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPH.FullRowSelect = True
        Me.lvPH.GridLines = True
        Me.lvPH.Location = New System.Drawing.Point(8, 220)
        Me.lvPH.Name = "lvPH"
        Me.lvPH.Size = New System.Drawing.Size(645, 287)
        Me.lvPH.TabIndex = 77
        Me.lvPH.UseCompatibleStateImageBehavior = False
        Me.lvPH.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Payment I.D"
        Me.ColumnHeader17.Width = 114
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Date process"
        Me.ColumnHeader18.Width = 166
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Amount Collected"
        Me.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader19.Width = 173
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = ""
        Me.ColumnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader21.Width = 125
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'gbxPrint
        '
        Me.gbxPrint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxPrint.BackColor = System.Drawing.Color.LightGray
        Me.gbxPrint.Controls.Add(Me.crvPaymentCentralReport)
        Me.gbxPrint.Controls.Add(Me.Button2)
        Me.gbxPrint.Controls.Add(Me.btnPrintCR)
        Me.gbxPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxPrint.Location = New System.Drawing.Point(0, 83)
        Me.gbxPrint.Name = "gbxPrint"
        Me.gbxPrint.Size = New System.Drawing.Size(1079, 623)
        Me.gbxPrint.TabIndex = 74
        Me.gbxPrint.TabStop = False
        Me.gbxPrint.Text = "Print"
        Me.gbxPrint.Visible = False
        '
        'crvPaymentCentralReport
        '
        Me.crvPaymentCentralReport.ActiveViewIndex = -1
        Me.crvPaymentCentralReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvPaymentCentralReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvPaymentCentralReport.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvPaymentCentralReport.Location = New System.Drawing.Point(14, 34)
        Me.crvPaymentCentralReport.Name = "crvPaymentCentralReport"
        Me.crvPaymentCentralReport.Size = New System.Drawing.Size(1052, 509)
        Me.crvPaymentCentralReport.TabIndex = 80
        Me.crvPaymentCentralReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(128, 549)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 60)
        Me.Button2.TabIndex = 79
        Me.Button2.Text = "Cancel"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnPrintCR
        '
        Me.btnPrintCR.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintCR.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPrintCR.FlatAppearance.BorderSize = 0
        Me.btnPrintCR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintCR.ForeColor = System.Drawing.Color.White
        Me.btnPrintCR.Location = New System.Drawing.Point(14, 549)
        Me.btnPrintCR.Name = "btnPrintCR"
        Me.btnPrintCR.Size = New System.Drawing.Size(108, 60)
        Me.btnPrintCR.TabIndex = 78
        Me.btnPrintCR.Text = "Print"
        Me.btnPrintCR.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrintCR.UseVisualStyleBackColor = False
        '
        'frmCollectibles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.gbxPH)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbxAdvanceSearch)
        Me.Controls.Add(Me.gbxClientCollectible)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.gbxPrint)
        Me.Name = "frmCollectibles"
        Me.Size = New System.Drawing.Size(1079, 706)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.CMS.ResumeLayout(False)
        Me.gbxAdvanceSearch.ResumeLayout(False)
        Me.gbxAdvanceSearch.PerformLayout()
        Me.gbxClientCollectible.ResumeLayout(False)
        Me.gbxClientCollectible.PerformLayout()
        Me.gbxPH.ResumeLayout(False)
        Me.gbxPH.PerformLayout()
        Me.gbxPrint.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents lvCollectibles As System.Windows.Forms.ListView
    Friend WithEvents gbxAdvanceSearch As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxBranch As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents Process As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbxClientCollectible As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelColl As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblPA As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnManage As System.Windows.Forms.Button
    Friend WithEvents btnSearchLoan As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSearchLoan As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbxCompany As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvDuedates As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblPayableAmount As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents gbxPH As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvPH As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtLoanid As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPHback As System.Windows.Forms.Button
    Friend WithEvents btnPH As System.Windows.Forms.Button
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsmViewPH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInputAmount As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmManagePenalties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtCollectedAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPenalties As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtDateStart As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnEnterPay As System.Windows.Forms.Button
    Friend WithEvents lblInfoSearch As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents gbxPrint As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnPrintCR As System.Windows.Forms.Button
    Friend WithEvents crvPaymentCentralReport As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader

End Class
