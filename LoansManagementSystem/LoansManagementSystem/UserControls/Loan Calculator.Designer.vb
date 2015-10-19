<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loan_Calculator
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
        Me.gbxAddEdit = New System.Windows.Forms.GroupBox()
        Me.gbxLoanData1 = New System.Windows.Forms.GroupBox()
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
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.gbxAddEdit.SuspendLayout()
        Me.gbxLoanData1.SuspendLayout()
        Me.gbxLoanData2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Tomato
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(259, 39)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Loan Calculator"
        '
        'gbxAddEdit
        '
        Me.gbxAddEdit.BackColor = System.Drawing.Color.LightGray
        Me.gbxAddEdit.Controls.Add(Me.gbxLoanData1)
        Me.gbxAddEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxAddEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAddEdit.Location = New System.Drawing.Point(23, 72)
        Me.gbxAddEdit.Name = "gbxAddEdit"
        Me.gbxAddEdit.Size = New System.Drawing.Size(792, 346)
        Me.gbxAddEdit.TabIndex = 60
        Me.gbxAddEdit.TabStop = False
        Me.gbxAddEdit.Text = "View Loans"
        '
        'gbxLoanData1
        '
        Me.gbxLoanData1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxLoanData1.Controls.Add(Me.txtPrincipal)
        Me.gbxLoanData1.Controls.Add(Me.gbxLoanData2)
        Me.gbxLoanData1.Controls.Add(Me.cboInterest)
        Me.gbxLoanData1.Controls.Add(Me.Label16)
        Me.gbxLoanData1.Controls.Add(Me.txtTerms)
        Me.gbxLoanData1.Controls.Add(Me.dtEnd)
        Me.gbxLoanData1.Controls.Add(Me.Label15)
        Me.gbxLoanData1.Controls.Add(Me.Label8)
        Me.gbxLoanData1.Controls.Add(Me.dtStart)
        Me.gbxLoanData1.Controls.Add(Me.Label11)
        Me.gbxLoanData1.Controls.Add(Me.Label9)
        Me.gbxLoanData1.Location = New System.Drawing.Point(6, 25)
        Me.gbxLoanData1.Name = "gbxLoanData1"
        Me.gbxLoanData1.Size = New System.Drawing.Size(780, 321)
        Me.gbxLoanData1.TabIndex = 174
        Me.gbxLoanData1.TabStop = False
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipal.Location = New System.Drawing.Point(133, 14)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Size = New System.Drawing.Size(300, 26)
        Me.txtPrincipal.TabIndex = 135
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
        Me.gbxLoanData2.Location = New System.Drawing.Point(0, 175)
        Me.gbxLoanData2.Name = "gbxLoanData2"
        Me.gbxLoanData2.Size = New System.Drawing.Size(741, 98)
        Me.gbxLoanData2.TabIndex = 175
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
        Me.txtTotalLoanAmount.Location = New System.Drawing.Point(475, 46)
        Me.txtTotalLoanAmount.MaxLength = 4
        Me.txtTotalLoanAmount.Name = "txtTotalLoanAmount"
        Me.txtTotalLoanAmount.ReadOnly = True
        Me.txtTotalLoanAmount.Size = New System.Drawing.Size(247, 26)
        Me.txtTotalLoanAmount.TabIndex = 172
        Me.txtTotalLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalInterest
        '
        Me.txtTotalInterest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalInterest.Location = New System.Drawing.Point(475, 14)
        Me.txtTotalInterest.MaxLength = 4
        Me.txtTotalInterest.Name = "txtTotalInterest"
        Me.txtTotalInterest.ReadOnly = True
        Me.txtTotalInterest.Size = New System.Drawing.Size(247, 26)
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
        Me.Label14.Location = New System.Drawing.Point(344, 52)
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
        Me.Label19.Location = New System.Drawing.Point(344, 20)
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
        'dtEnd
        '
        Me.dtEnd.CustomFormat = "MM/dd/yyyy"
        Me.dtEnd.Enabled = False
        Me.dtEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtEnd.Location = New System.Drawing.Point(133, 143)
        Me.dtEnd.Name = "dtEnd"
        Me.dtEnd.Size = New System.Drawing.Size(300, 26)
        Me.dtEnd.TabIndex = 144
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(19, 151)
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
        'dtStart
        '
        Me.dtStart.CustomFormat = ""
        Me.dtStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtStart.Location = New System.Drawing.Point(133, 111)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(300, 26)
        Me.dtStart.TabIndex = 142
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(19, 119)
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
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOk.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnOk.FlatAppearance.BorderSize = 0
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.Color.White
        Me.btnOk.Location = New System.Drawing.Point(29, 428)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(108, 58)
        Me.btnOk.TabIndex = 177
        Me.btnOk.Text = "OK"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnPrint.FlatAppearance.BorderSize = 0
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.White
        Me.btnPrint.Location = New System.Drawing.Point(148, 428)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(108, 58)
        Me.btnPrint.TabIndex = 176
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'Loan_Calculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.gbxAddEdit)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Loan_Calculator"
        Me.Size = New System.Drawing.Size(975, 533)
        Me.gbxAddEdit.ResumeLayout(False)
        Me.gbxLoanData1.ResumeLayout(False)
        Me.gbxLoanData1.PerformLayout()
        Me.gbxLoanData2.ResumeLayout(False)
        Me.gbxLoanData2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbxAddEdit As System.Windows.Forms.GroupBox
    Friend WithEvents gbxLoanData1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrincipal As System.Windows.Forms.TextBox
    Friend WithEvents cboInterest As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTerms As System.Windows.Forms.TextBox
    Friend WithEvents dtEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gbxLoanData2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMonthlyInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalLoanAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtBiMonthlyAmort As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button

    
   
End Class
