<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintReports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.crvClientJournal = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.crvCompanyJournal = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.crvBranchJournal = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.crvCollectibleJournal = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.crvLoanJournal = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TabControl1.Location = New System.Drawing.Point(23, 124)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(885, 401)
        Me.TabControl1.TabIndex = 237
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.crvClientJournal)
        Me.TabPage1.Location = New System.Drawing.Point(4, 30)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(877, 367)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Clients"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'crvClientJournal
        '
        Me.crvClientJournal.ActiveViewIndex = -1
        Me.crvClientJournal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvClientJournal.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvClientJournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvClientJournal.Location = New System.Drawing.Point(3, 3)
        Me.crvClientJournal.Name = "crvClientJournal"
        Me.crvClientJournal.Size = New System.Drawing.Size(871, 361)
        Me.crvClientJournal.TabIndex = 0
        Me.crvClientJournal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.crvCompanyJournal)
        Me.TabPage2.Location = New System.Drawing.Point(4, 30)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(877, 367)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Companies"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'crvCompanyJournal
        '
        Me.crvCompanyJournal.ActiveViewIndex = -1
        Me.crvCompanyJournal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvCompanyJournal.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvCompanyJournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvCompanyJournal.Location = New System.Drawing.Point(3, 3)
        Me.crvCompanyJournal.Name = "crvCompanyJournal"
        Me.crvCompanyJournal.Size = New System.Drawing.Size(871, 361)
        Me.crvCompanyJournal.TabIndex = 1
        Me.crvCompanyJournal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.crvBranchJournal)
        Me.TabPage3.Location = New System.Drawing.Point(4, 30)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(877, 367)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Branches"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'crvBranchJournal
        '
        Me.crvBranchJournal.ActiveViewIndex = -1
        Me.crvBranchJournal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvBranchJournal.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvBranchJournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvBranchJournal.Location = New System.Drawing.Point(0, 0)
        Me.crvBranchJournal.Name = "crvBranchJournal"
        Me.crvBranchJournal.Size = New System.Drawing.Size(877, 367)
        Me.crvBranchJournal.TabIndex = 2
        Me.crvBranchJournal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.crvLoanJournal)
        Me.TabPage4.Location = New System.Drawing.Point(4, 30)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(877, 367)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Loans"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.crvCollectibleJournal)
        Me.TabPage5.Location = New System.Drawing.Point(4, 30)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(877, 367)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Collectibles"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'crvCollectibleJournal
        '
        Me.crvCollectibleJournal.ActiveViewIndex = -1
        Me.crvCollectibleJournal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvCollectibleJournal.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvCollectibleJournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvCollectibleJournal.Location = New System.Drawing.Point(3, 3)
        Me.crvCollectibleJournal.Name = "crvCollectibleJournal"
        Me.crvCollectibleJournal.Size = New System.Drawing.Size(871, 361)
        Me.crvCollectibleJournal.TabIndex = 2
        Me.crvCollectibleJournal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblHeader)
        Me.Panel1.Location = New System.Drawing.Point(-4, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(935, 63)
        Me.Panel1.TabIndex = 252
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeader.ForeColor = System.Drawing.Color.Black
        Me.lblHeader.Location = New System.Drawing.Point(22, 21)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(145, 26)
        Me.lblHeader.TabIndex = 20
        Me.lblHeader.Text = "Client Report"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Gray
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(780, 106)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(123, 39)
        Me.btnClose.TabIndex = 254
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'crvLoanJournal
        '
        Me.crvLoanJournal.ActiveViewIndex = -1
        Me.crvLoanJournal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvLoanJournal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvLoanJournal.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvLoanJournal.DisplayToolbar = False
        Me.crvLoanJournal.Location = New System.Drawing.Point(3, 3)
        Me.crvLoanJournal.Name = "crvLoanJournal"
        Me.crvLoanJournal.Size = New System.Drawing.Size(871, 358)
        Me.crvLoanJournal.TabIndex = 11
        Me.crvLoanJournal.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmPrintReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 527)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPrintReports"
        Me.Text = "frmReports"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents crvClientJournal As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents crvCompanyJournal As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents crvBranchJournal As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents crvCollectibleJournal As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents crvLoanJournal As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
