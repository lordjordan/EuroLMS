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
        Me.txtDateEnd = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
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
        'txtPrincipalAmt
        '
        Me.txtPrincipalAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipalAmt.Location = New System.Drawing.Point(488, 17)
        Me.txtPrincipalAmt.MaxLength = 4
        Me.txtPrincipalAmt.Name = "txtPrincipalAmt"
        Me.txtPrincipalAmt.ReadOnly = True
        Me.txtPrincipalAmt.Size = New System.Drawing.Size(205, 26)
        Me.txtPrincipalAmt.TabIndex = 193
        Me.txtPrincipalAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalLoanAmount
        '
        Me.txtTotalLoanAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLoanAmount.Location = New System.Drawing.Point(488, 49)
        Me.txtTotalLoanAmount.MaxLength = 4
        Me.txtTotalLoanAmount.Name = "txtTotalLoanAmount"
        Me.txtTotalLoanAmount.ReadOnly = True
        Me.txtTotalLoanAmount.Size = New System.Drawing.Size(205, 26)
        Me.txtTotalLoanAmount.TabIndex = 192
        Me.txtTotalLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(393, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 16)
        Me.Label6.TabIndex = 190
        Me.Label6.Text = "Gross Amt."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(393, 23)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(89, 16)
        Me.Label19.TabIndex = 189
        Me.Label19.Text = "Principal Amt."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnViewLoan
        '
        Me.btnViewLoan.BackColor = System.Drawing.Color.Gray
        Me.btnViewLoan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewLoan.ForeColor = System.Drawing.Color.White
        Me.btnViewLoan.Location = New System.Drawing.Point(265, 19)
        Me.btnViewLoan.Name = "btnViewLoan"
        Me.btnViewLoan.Size = New System.Drawing.Size(91, 24)
        Me.btnViewLoan.TabIndex = 184
        Me.btnViewLoan.Text = "View loans"
        Me.btnViewLoan.UseVisualStyleBackColor = False
        '
        'txtCollectedAmt
        '
        Me.txtCollectedAmt.BackColor = System.Drawing.SystemColors.Control
        Me.txtCollectedAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectedAmt.Location = New System.Drawing.Point(121, 113)
        Me.txtCollectedAmt.Name = "txtCollectedAmt"
        Me.txtCollectedAmt.ReadOnly = True
        Me.txtCollectedAmt.Size = New System.Drawing.Size(235, 26)
        Me.txtCollectedAmt.TabIndex = 182
        Me.txtCollectedAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(15, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 16)
        Me.Label14.TabIndex = 181
        Me.Label14.Text = "Collected amt."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTerms
        '
        Me.txtTerms.BackColor = System.Drawing.SystemColors.Control
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(488, 81)
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.ReadOnly = True
        Me.txtTerms.Size = New System.Drawing.Size(87, 26)
        Me.txtTerms.TabIndex = 178
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(393, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "Terms"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtBalance
        '
        Me.txtBalance.BackColor = System.Drawing.SystemColors.Control
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(121, 81)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(235, 26)
        Me.txtBalance.TabIndex = 176
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 16)
        Me.Label4.TabIndex = 175
        Me.Label4.Text = "Balance"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLoanid
        '
        Me.txtLoanid.BackColor = System.Drawing.SystemColors.Control
        Me.txtLoanid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanid.Location = New System.Drawing.Point(121, 17)
        Me.txtLoanid.Name = "txtLoanid"
        Me.txtLoanid.ReadOnly = True
        Me.txtLoanid.Size = New System.Drawing.Size(138, 26)
        Me.txtLoanid.TabIndex = 174
        '
        'txtname
        '
        Me.txtname.BackColor = System.Drawing.SystemColors.Control
        Me.txtname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtname.Location = New System.Drawing.Point(121, 49)
        Me.txtname.Name = "txtname"
        Me.txtname.ReadOnly = True
        Me.txtname.Size = New System.Drawing.Size(235, 26)
        Me.txtname.TabIndex = 173
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 16)
        Me.Label8.TabIndex = 172
        Me.Label8.Text = "Loan I.d"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 171
        Me.Label2.Text = "Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lvPH
        '
        Me.lvPH.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvPH.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19})
        Me.lvPH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPH.FullRowSelect = True
        Me.lvPH.GridLines = True
        Me.lvPH.Location = New System.Drawing.Point(16, 145)
        Me.lvPH.Name = "lvPH"
        Me.lvPH.Size = New System.Drawing.Size(737, 427)
        Me.lvPH.TabIndex = 85
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
        Me.ColumnHeader18.Width = 192
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Amount Collected"
        Me.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader19.Width = 195
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
        'txtDateEnd
        '
        Me.txtDateEnd.BackColor = System.Drawing.SystemColors.Control
        Me.txtDateEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateEnd.Location = New System.Drawing.Point(488, 113)
        Me.txtDateEnd.Name = "txtDateEnd"
        Me.txtDateEnd.ReadOnly = True
        Me.txtDateEnd.Size = New System.Drawing.Size(205, 26)
        Me.txtDateEnd.TabIndex = 195
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(393, 119)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 16)
        Me.Label12.TabIndex = 194
        Me.Label12.Text = "Date end"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PaymentHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbxShowClient)
        Me.Controls.Add(Me.pnlMain)
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
    Friend WithEvents lvPH As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
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
    Friend WithEvents btnViewLoan As System.Windows.Forms.Button
    Friend WithEvents txtPrincipalAmt As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalLoanAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDateEnd As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label

End Class
