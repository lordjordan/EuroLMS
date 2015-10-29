<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentHistory
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
        Me.radVoid = New System.Windows.Forms.RadioButton()
        Me.radNorm = New System.Windows.Forms.RadioButton()
        Me.radAll = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDateStart = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_void = New System.Windows.Forms.Button()
        Me.txtTotalPenalties = New System.Windows.Forms.TextBox()
        Me.txtDateEnd = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPrincipalAmt = New System.Windows.Forms.TextBox()
        Me.txtTotalLoanAmount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnViewLoan = New System.Windows.Forms.Button()
        Me.txtCollectedAmt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
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
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbxShowClient = New System.Windows.Forms.GroupBox()
        Me.btnClientBack = New System.Windows.Forms.Button()
        Me.lvClientList = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSelectSearchClient = New System.Windows.Forms.Button()
        Me.btnSearchClient = New System.Windows.Forms.Button()
        Me.txtSearchLoan = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlMain.SuspendLayout()
        Me.gbxShowClient.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumTurquoise
        Me.Label1.Location = New System.Drawing.Point(25, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 39)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Payment History"
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Controls.Add(Me.radVoid)
        Me.pnlMain.Controls.Add(Me.radNorm)
        Me.pnlMain.Controls.Add(Me.radAll)
        Me.pnlMain.Controls.Add(Me.Label9)
        Me.pnlMain.Controls.Add(Me.Label7)
        Me.pnlMain.Controls.Add(Me.txtDateStart)
        Me.pnlMain.Controls.Add(Me.Label3)
        Me.pnlMain.Controls.Add(Me.btn_void)
        Me.pnlMain.Controls.Add(Me.txtTotalPenalties)
        Me.pnlMain.Controls.Add(Me.txtDateEnd)
        Me.pnlMain.Controls.Add(Me.Label12)
        Me.pnlMain.Controls.Add(Me.txtPrincipalAmt)
        Me.pnlMain.Controls.Add(Me.txtTotalLoanAmount)
        Me.pnlMain.Controls.Add(Me.Label6)
        Me.pnlMain.Controls.Add(Me.Label19)
        Me.pnlMain.Controls.Add(Me.btnViewLoan)
        Me.pnlMain.Controls.Add(Me.txtCollectedAmt)
        Me.pnlMain.Controls.Add(Me.Label14)
        Me.pnlMain.Controls.Add(Me.txtTerms)
        Me.pnlMain.Controls.Add(Me.Label5)
        Me.pnlMain.Controls.Add(Me.txtBalance)
        Me.pnlMain.Controls.Add(Me.Label4)
        Me.pnlMain.Controls.Add(Me.txtLoanid)
        Me.pnlMain.Controls.Add(Me.txtname)
        Me.pnlMain.Controls.Add(Me.Label8)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.lvPH)
        Me.pnlMain.Enabled = False
        Me.pnlMain.Location = New System.Drawing.Point(4, 91)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(772, 599)
        Me.pnlMain.TabIndex = 49
        '
        'radVoid
        '
        Me.radVoid.AutoSize = True
        Me.radVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radVoid.Location = New System.Drawing.Point(186, 195)
        Me.radVoid.Name = "radVoid"
        Me.radVoid.Size = New System.Drawing.Size(70, 20)
        Me.radVoid.TabIndex = 224
        Me.radVoid.Text = "Voided"
        Me.radVoid.UseVisualStyleBackColor = True
        '
        'radNorm
        '
        Me.radNorm.AutoSize = True
        Me.radNorm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radNorm.Location = New System.Drawing.Point(110, 195)
        Me.radNorm.Name = "radNorm"
        Me.radNorm.Size = New System.Drawing.Size(70, 20)
        Me.radNorm.TabIndex = 223
        Me.radNorm.Text = "Normal"
        Me.radNorm.UseVisualStyleBackColor = True
        '
        'radAll
        '
        Me.radAll.AutoSize = True
        Me.radAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radAll.Location = New System.Drawing.Point(60, 195)
        Me.radAll.Name = "radAll"
        Me.radAll.Size = New System.Drawing.Size(41, 20)
        Me.radAll.TabIndex = 222
        Me.radAll.TabStop = True
        Me.radAll.Text = "All"
        Me.radAll.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 221
        Me.Label9.Text = "View:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 16)
        Me.Label7.TabIndex = 220
        Me.Label7.Text = "Total Penalties"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtDateStart
        '
        Me.txtDateStart.BackColor = System.Drawing.SystemColors.Control
        Me.txtDateStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateStart.Location = New System.Drawing.Point(495, 110)
        Me.txtDateStart.Name = "txtDateStart"
        Me.txtDateStart.ReadOnly = True
        Me.txtDateStart.Size = New System.Drawing.Size(205, 26)
        Me.txtDateStart.TabIndex = 219
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(400, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 218
        Me.Label3.Text = "Date start"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btn_void
        '
        Me.btn_void.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_void.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btn_void.FlatAppearance.BorderSize = 0
        Me.btn_void.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_void.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_void.ForeColor = System.Drawing.Color.White
        Me.btn_void.Location = New System.Drawing.Point(17, 524)
        Me.btn_void.Name = "btn_void"
        Me.btn_void.Size = New System.Drawing.Size(108, 60)
        Me.btn_void.TabIndex = 217
        Me.btn_void.Text = "Void payment"
        Me.btn_void.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_void.UseVisualStyleBackColor = False
        '
        'txtTotalPenalties
        '
        Me.txtTotalPenalties.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalPenalties.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPenalties.Location = New System.Drawing.Point(123, 142)
        Me.txtTotalPenalties.Name = "txtTotalPenalties"
        Me.txtTotalPenalties.ReadOnly = True
        Me.txtTotalPenalties.Size = New System.Drawing.Size(235, 26)
        Me.txtTotalPenalties.TabIndex = 216
        Me.txtTotalPenalties.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDateEnd
        '
        Me.txtDateEnd.BackColor = System.Drawing.SystemColors.Control
        Me.txtDateEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateEnd.Location = New System.Drawing.Point(495, 142)
        Me.txtDateEnd.Name = "txtDateEnd"
        Me.txtDateEnd.ReadOnly = True
        Me.txtDateEnd.Size = New System.Drawing.Size(205, 26)
        Me.txtDateEnd.TabIndex = 214
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(400, 148)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 16)
        Me.Label12.TabIndex = 213
        Me.Label12.Text = "Date end"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPrincipalAmt
        '
        Me.txtPrincipalAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipalAmt.Location = New System.Drawing.Point(495, 14)
        Me.txtPrincipalAmt.MaxLength = 4
        Me.txtPrincipalAmt.Name = "txtPrincipalAmt"
        Me.txtPrincipalAmt.ReadOnly = True
        Me.txtPrincipalAmt.Size = New System.Drawing.Size(205, 26)
        Me.txtPrincipalAmt.TabIndex = 212
        Me.txtPrincipalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalLoanAmount
        '
        Me.txtTotalLoanAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLoanAmount.Location = New System.Drawing.Point(495, 46)
        Me.txtTotalLoanAmount.MaxLength = 4
        Me.txtTotalLoanAmount.Name = "txtTotalLoanAmount"
        Me.txtTotalLoanAmount.ReadOnly = True
        Me.txtTotalLoanAmount.Size = New System.Drawing.Size(205, 26)
        Me.txtTotalLoanAmount.TabIndex = 211
        Me.txtTotalLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(400, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 16)
        Me.Label6.TabIndex = 210
        Me.Label6.Text = "Gross Amt."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(400, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 16)
        Me.Label19.TabIndex = 209
        Me.Label19.Text = "Principal Amt."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnViewLoan
        '
        Me.btnViewLoan.BackColor = System.Drawing.Color.Gray
        Me.btnViewLoan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewLoan.ForeColor = System.Drawing.Color.White
        Me.btnViewLoan.Location = New System.Drawing.Point(267, 16)
        Me.btnViewLoan.Name = "btnViewLoan"
        Me.btnViewLoan.Size = New System.Drawing.Size(91, 24)
        Me.btnViewLoan.TabIndex = 208
        Me.btnViewLoan.Text = "View loans"
        Me.btnViewLoan.UseVisualStyleBackColor = False
        '
        'txtCollectedAmt
        '
        Me.txtCollectedAmt.BackColor = System.Drawing.SystemColors.Control
        Me.txtCollectedAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectedAmt.Location = New System.Drawing.Point(123, 110)
        Me.txtCollectedAmt.Name = "txtCollectedAmt"
        Me.txtCollectedAmt.ReadOnly = True
        Me.txtCollectedAmt.Size = New System.Drawing.Size(235, 26)
        Me.txtCollectedAmt.TabIndex = 207
        Me.txtCollectedAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 16)
        Me.Label14.TabIndex = 206
        Me.Label14.Text = "Collected amt."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTerms
        '
        Me.txtTerms.BackColor = System.Drawing.SystemColors.Control
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(495, 78)
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.ReadOnly = True
        Me.txtTerms.Size = New System.Drawing.Size(87, 26)
        Me.txtTerms.TabIndex = 205
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(400, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "Terms"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.SystemColors.Control
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(123, 78)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(235, 26)
        Me.txtBalance.TabIndex = 203
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Balance"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLoanid
        '
        Me.txtLoanid.BackColor = System.Drawing.SystemColors.Control
        Me.txtLoanid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanid.Location = New System.Drawing.Point(123, 14)
        Me.txtLoanid.Name = "txtLoanid"
        Me.txtLoanid.ReadOnly = True
        Me.txtLoanid.Size = New System.Drawing.Size(138, 26)
        Me.txtLoanid.TabIndex = 201
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.SystemColors.Control
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(123, 46)
        Me.txtname.Name = "txtname"
        Me.txtname.ReadOnly = True
        Me.txtname.Size = New System.Drawing.Size(235, 26)
        Me.txtname.TabIndex = 200
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 16)
        Me.Label8.TabIndex = 199
        Me.Label8.Text = "Loan I.d"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 198
        Me.Label2.Text = "Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lvPH
        '
        Me.lvPH.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPH.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader1, Me.ColumnHeader9})
        Me.lvPH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPH.FullRowSelect = True
        Me.lvPH.GridLines = True
        Me.lvPH.Location = New System.Drawing.Point(11, 216)
        Me.lvPH.Name = "lvPH"
        Me.lvPH.Size = New System.Drawing.Size(750, 280)
        Me.lvPH.TabIndex = 196
        Me.lvPH.UseCompatibleStateImageBehavior = False
        Me.lvPH.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Payment I.D"
        Me.ColumnHeader17.Width = 81
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Date process"
        Me.ColumnHeader18.Width = 137
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Amount Collected"
        Me.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader19.Width = 195
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 4
        Me.ColumnHeader1.Text = "Penalized?"
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader1.Width = 93
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.DisplayIndex = 3
        Me.ColumnHeader9.Text = "Voided?"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 93
        '
        'gbxShowClient
        '
        Me.gbxShowClient.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbxShowClient.BackColor = System.Drawing.Color.DarkGray
        Me.gbxShowClient.Controls.Add(Me.btnClientBack)
        Me.gbxShowClient.Controls.Add(Me.lvClientList)
        Me.gbxShowClient.Controls.Add(Me.btnSelectSearchClient)
        Me.gbxShowClient.Controls.Add(Me.btnSearchClient)
        Me.gbxShowClient.Controls.Add(Me.txtSearchLoan)
        Me.gbxShowClient.Controls.Add(Me.Label28)
        Me.gbxShowClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxShowClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxShowClient.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbxShowClient.Location = New System.Drawing.Point(15, 239)
        Me.gbxShowClient.Name = "gbxShowClient"
        Me.gbxShowClient.Size = New System.Drawing.Size(753, 457)
        Me.gbxShowClient.TabIndex = 183
        Me.gbxShowClient.TabStop = False
        Me.gbxShowClient.Text = "Select a Client"
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
        Me.lvClientList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader10, Me.ColumnHeader5, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvClientList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvClientList.FullRowSelect = True
        Me.lvClientList.GridLines = True
        Me.lvClientList.Location = New System.Drawing.Point(19, 68)
        Me.lvClientList.Name = "lvClientList"
        Me.lvClientList.Size = New System.Drawing.Size(713, 312)
        Me.lvClientList.TabIndex = 130
        Me.lvClientList.UseCompatibleStateImageBehavior = False
        Me.lvClientList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Employee Number"
        Me.ColumnHeader6.Width = 121
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Client ID"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Loan ID"
        Me.ColumnHeader4.Width = 103
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Name"
        Me.ColumnHeader10.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Principal Amount"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Company name"
        Me.ColumnHeader7.Width = 123
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Branch"
        Me.ColumnHeader8.Width = 127
        '
        'btnSelectSearchClient
        '
        Me.btnSelectSearchClient.BackColor = System.Drawing.Color.Gray
        Me.btnSelectSearchClient.FlatAppearance.BorderSize = 0
        Me.btnSelectSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectSearchClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectSearchClient.ForeColor = System.Drawing.Color.White
        Me.btnSelectSearchClient.Location = New System.Drawing.Point(271, 396)
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
        'txtSearchLoan
        '
        Me.txtSearchLoan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchLoan.Location = New System.Drawing.Point(99, 36)
        Me.txtSearchLoan.Name = "txtSearchLoan"
        Me.txtSearchLoan.Size = New System.Drawing.Size(166, 22)
        Me.txtSearchLoan.TabIndex = 57
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
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Gray
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(642, 20)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(123, 39)
        Me.btnClose.TabIndex = 183
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'PaymentHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbxShowClient)
        Me.Name = "PaymentHistory"
        Me.Size = New System.Drawing.Size(779, 706)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.gbxShowClient.ResumeLayout(False)
        Me.gbxShowClient.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents gbxShowClient As System.Windows.Forms.GroupBox
    Friend WithEvents btnClientBack As System.Windows.Forms.Button
    Friend WithEvents lvClientList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSelectSearchClient As System.Windows.Forms.Button
    Friend WithEvents btnSearchClient As System.Windows.Forms.Button
    Friend WithEvents txtSearchLoan As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvPH As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTotalPenalties As System.Windows.Forms.TextBox
    Friend WithEvents txtDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPrincipalAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalLoanAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnViewLoan As System.Windows.Forms.Button
    Friend WithEvents txtCollectedAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtLoanid As System.Windows.Forms.TextBox
    Friend WithEvents txtname As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_void As System.Windows.Forms.Button
    Friend WithEvents txtDateStart As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents radVoid As System.Windows.Forms.RadioButton
    Friend WithEvents radNorm As System.Windows.Forms.RadioButton
    Friend WithEvents radAll As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label

End Class
