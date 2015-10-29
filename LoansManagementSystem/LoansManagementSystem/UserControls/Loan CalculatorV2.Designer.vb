<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loan_CalculatorV2
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbxAddEdit = New System.Windows.Forms.GroupBox()
        Me.gpPrintOption = New System.Windows.Forms.GroupBox()
        Me.cboPrintOption = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtPrincipal = New System.Windows.Forms.TextBox()
        Me.gbxLoanData2 = New System.Windows.Forms.GroupBox()
        Me.txtMonthlyInterest = New System.Windows.Forms.TextBox()
        Me.txtTotalLoanAmount = New System.Windows.Forms.TextBox()
        Me.txtTotalInterest = New System.Windows.Forms.TextBox()
        Me.txtBiMonthlyAmort = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboInterest = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTerms = New System.Windows.Forms.TextBox()
        Me.dtEnd = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.gbxPreview = New System.Windows.Forms.GroupBox()
        Me.bntClose = New System.Windows.Forms.Button()
        Me.crvLoanCalculator = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gbxAddEdit.SuspendLayout()
        Me.gpPrintOption.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxLoanData2.SuspendLayout()
        Me.gbxPreview.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Tomato
        Me.Label2.Location = New System.Drawing.Point(15, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(259, 39)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Loan Calculator"
        '
        'gbxAddEdit
        '
        Me.gbxAddEdit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbxAddEdit.BackColor = System.Drawing.Color.LightGray
        Me.gbxAddEdit.Controls.Add(Me.gpPrintOption)
        Me.gbxAddEdit.Controls.Add(Me.DataGridView1)
        Me.gbxAddEdit.Controls.Add(Me.txtPrincipal)
        Me.gbxAddEdit.Controls.Add(Me.gbxLoanData2)
        Me.gbxAddEdit.Controls.Add(Me.cboInterest)
        Me.gbxAddEdit.Controls.Add(Me.Label16)
        Me.gbxAddEdit.Controls.Add(Me.txtTerms)
        Me.gbxAddEdit.Controls.Add(Me.dtEnd)
        Me.gbxAddEdit.Controls.Add(Me.Label15)
        Me.gbxAddEdit.Controls.Add(Me.Label8)
        Me.gbxAddEdit.Controls.Add(Me.dtStart)
        Me.gbxAddEdit.Controls.Add(Me.Label11)
        Me.gbxAddEdit.Controls.Add(Me.Label9)
        Me.gbxAddEdit.Controls.Add(Me.btnGenerate)
        Me.gbxAddEdit.Controls.Add(Me.btnOk)
        Me.gbxAddEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxAddEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAddEdit.Location = New System.Drawing.Point(92, 54)
        Me.gbxAddEdit.Name = "gbxAddEdit"
        Me.gbxAddEdit.Size = New System.Drawing.Size(750, 408)
        Me.gbxAddEdit.TabIndex = 57
        Me.gbxAddEdit.TabStop = False
        Me.gbxAddEdit.Text = "Calculate Loan"
        '
        'gpPrintOption
        '
        Me.gpPrintOption.Controls.Add(Me.cboPrintOption)
        Me.gpPrintOption.Location = New System.Drawing.Point(406, 273)
        Me.gpPrintOption.Name = "gpPrintOption"
        Me.gpPrintOption.Size = New System.Drawing.Size(324, 55)
        Me.gpPrintOption.TabIndex = 263
        Me.gpPrintOption.TabStop = False
        Me.gpPrintOption.Text = "Printing All Option"
        '
        'cboPrintOption
        '
        Me.cboPrintOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrintOption.FormattingEnabled = True
        Me.cboPrintOption.Items.AddRange(New Object() {"Print to Printer", "Export to PDF"})
        Me.cboPrintOption.Location = New System.Drawing.Point(6, 21)
        Me.cboPrintOption.Name = "cboPrintOption"
        Me.cboPrintOption.Size = New System.Drawing.Size(284, 28)
        Me.cboPrintOption.TabIndex = 247
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(408, 95)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(326, 172)
        Me.DataGridView1.TabIndex = 262
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipal.Location = New System.Drawing.Point(152, 26)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Size = New System.Drawing.Size(242, 26)
        Me.txtPrincipal.TabIndex = 252
        Me.txtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.gbxLoanData2.Location = New System.Drawing.Point(25, 123)
        Me.gbxLoanData2.Name = "gbxLoanData2"
        Me.gbxLoanData2.Size = New System.Drawing.Size(369, 199)
        Me.gbxLoanData2.TabIndex = 261
        Me.gbxLoanData2.TabStop = False
        '
        'txtMonthlyInterest
        '
        Me.txtMonthlyInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonthlyInterest.Location = New System.Drawing.Point(147, 14)
        Me.txtMonthlyInterest.Name = "txtMonthlyInterest"
        Me.txtMonthlyInterest.ReadOnly = True
        Me.txtMonthlyInterest.Size = New System.Drawing.Size(163, 26)
        Me.txtMonthlyInterest.TabIndex = 135
        Me.txtMonthlyInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalLoanAmount
        '
        Me.txtTotalLoanAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLoanAmount.Location = New System.Drawing.Point(146, 110)
        Me.txtTotalLoanAmount.MaxLength = 4
        Me.txtTotalLoanAmount.Name = "txtTotalLoanAmount"
        Me.txtTotalLoanAmount.ReadOnly = True
        Me.txtTotalLoanAmount.Size = New System.Drawing.Size(164, 26)
        Me.txtTotalLoanAmount.TabIndex = 172
        Me.txtTotalLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalInterest
        '
        Me.txtTotalInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalInterest.Location = New System.Drawing.Point(147, 78)
        Me.txtTotalInterest.MaxLength = 4
        Me.txtTotalInterest.Name = "txtTotalInterest"
        Me.txtTotalInterest.ReadOnly = True
        Me.txtTotalInterest.Size = New System.Drawing.Size(163, 26)
        Me.txtTotalInterest.TabIndex = 172
        Me.txtTotalInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBiMonthlyAmort
        '
        Me.txtBiMonthlyAmort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBiMonthlyAmort.Location = New System.Drawing.Point(147, 46)
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
        Me.Label14.Location = New System.Drawing.Point(13, 116)
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
        Me.Label17.Location = New System.Drawing.Point(13, 52)
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
        Me.Label19.Location = New System.Drawing.Point(13, 84)
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
        Me.Label20.Location = New System.Drawing.Point(13, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(100, 16)
        Me.Label20.TabIndex = 134
        Me.Label20.Text = "Monthly Interest"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboInterest
        '
        Me.cboInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInterest.FormattingEnabled = True
        Me.cboInterest.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
        Me.cboInterest.Location = New System.Drawing.Point(152, 58)
        Me.cboInterest.Name = "cboInterest"
        Me.cboInterest.Size = New System.Drawing.Size(163, 28)
        Me.cboInterest.TabIndex = 258
        Me.cboInterest.Text = "6"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(38, 64)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 257
        Me.Label16.Text = "Interest rate (%)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtTerms
        '
        Me.txtTerms.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTerms.Location = New System.Drawing.Point(152, 91)
        Me.txtTerms.MaxLength = 4
        Me.txtTerms.Name = "txtTerms"
        Me.txtTerms.Size = New System.Drawing.Size(163, 26)
        Me.txtTerms.TabIndex = 260
        '
        'dtEnd
        '
        Me.dtEnd.CustomFormat = "MM/dd/yyyy"
        Me.dtEnd.Enabled = False
        Me.dtEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEnd.Location = New System.Drawing.Point(487, 56)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(245, 26)
        Me.dtEnd.TabIndex = 256
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(405, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 16)
        Me.Label15.TabIndex = 255
        Me.Label15.Text = "Date end"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(38, 97)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 16)
        Me.Label8.TabIndex = 259
        Me.Label8.Text = "Terms (months)"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtStart
        '
        Me.dtStart.CustomFormat = ""
        Me.dtStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtStart.Location = New System.Drawing.Point(487, 24)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(245, 26)
        Me.dtStart.TabIndex = 254
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(403, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 253
        Me.Label11.Text = "Date start"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(38, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(108, 16)
        Me.Label9.TabIndex = 251
        Me.Label9.Text = "Principal Amount"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.ForeColor = System.Drawing.Color.White
        Me.btnGenerate.Location = New System.Drawing.Point(126, 336)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(108, 60)
        Me.btnGenerate.TabIndex = 179
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Location = New System.Drawing.Point(11, 337)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(108, 58)
        Me.btnOk.TabIndex = 179
        Me.btnOk.Text = "OK"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'gbxPreview
        '
        Me.gbxPreview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbxPreview.BackColor = System.Drawing.SystemColors.ControlDark
        Me.gbxPreview.Controls.Add(Me.bntClose)
        Me.gbxPreview.Controls.Add(Me.crvLoanCalculator)
        Me.gbxPreview.Location = New System.Drawing.Point(0, 54)
        Me.gbxPreview.Name = "gbxPreview"
        Me.gbxPreview.Size = New System.Drawing.Size(955, 449)
        Me.gbxPreview.TabIndex = 264
        Me.gbxPreview.TabStop = False
        Me.gbxPreview.Visible = False
        '
        'bntClose
        '
        Me.bntClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bntClose.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.bntClose.FlatAppearance.BorderSize = 0
        Me.bntClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntClose.ForeColor = System.Drawing.Color.White
        Me.bntClose.Location = New System.Drawing.Point(830, 19)
        Me.bntClose.Name = "bntClose"
        Me.bntClose.Size = New System.Drawing.Size(108, 58)
        Me.bntClose.TabIndex = 182
        Me.bntClose.Text = "Close"
        Me.bntClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bntClose.UseVisualStyleBackColor = False
        '
        'crvLoanCalculator
        '
        Me.crvLoanCalculator.ActiveViewIndex = -1
        Me.crvLoanCalculator.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvLoanCalculator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvLoanCalculator.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvLoanCalculator.Location = New System.Drawing.Point(0, 83)
        Me.crvLoanCalculator.Name = "crvLoanCalculator"
        Me.crvLoanCalculator.Size = New System.Drawing.Size(955, 366)
        Me.crvLoanCalculator.TabIndex = 181
        '
        'Loan_CalculatorV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbxPreview)
        Me.Controls.Add(Me.gbxAddEdit)
        Me.Name = "Loan_CalculatorV2"
        Me.Size = New System.Drawing.Size(955, 503)
        Me.gbxAddEdit.ResumeLayout(False)
        Me.gbxAddEdit.PerformLayout()
        Me.gpPrintOption.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxLoanData2.ResumeLayout(False)
        Me.gbxLoanData2.PerformLayout()
        Me.gbxPreview.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbxAddEdit As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents gpPrintOption As System.Windows.Forms.GroupBox
    Friend WithEvents cboPrintOption As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtPrincipal As System.Windows.Forms.TextBox
    Friend WithEvents gbxLoanData2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMonthlyInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalLoanAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtBiMonthlyAmort As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboInterest As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gbxPreview As System.Windows.Forms.GroupBox
    Friend WithEvents crvLoanCalculator As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents bntClose As System.Windows.Forms.Button

End Class
