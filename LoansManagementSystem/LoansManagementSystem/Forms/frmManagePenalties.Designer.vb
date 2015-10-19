<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManagePenalties
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
        Me.btnSaveExit = New System.Windows.Forms.Button()
        Me.btnEditPenalties = New System.Windows.Forms.Button()
        Me.btnRemovePenalties = New System.Windows.Forms.Button()
        Me.lvDuedate = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCancelPenalties = New System.Windows.Forms.Button()
        Me.btnRestore = New System.Windows.Forms.Button()
        Me.gbxEditAmount = New System.Windows.Forms.GroupBox()
        Me.btnCancelColl = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.btnClientBack = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.lblLoanID = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbxEditAmount.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSaveExit
        '
        Me.btnSaveExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveExit.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnSaveExit.FlatAppearance.BorderSize = 0
        Me.btnSaveExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveExit.ForeColor = System.Drawing.Color.White
        Me.btnSaveExit.Location = New System.Drawing.Point(354, 432)
        Me.btnSaveExit.Name = "btnSaveExit"
        Me.btnSaveExit.Size = New System.Drawing.Size(108, 60)
        Me.btnSaveExit.TabIndex = 86
        Me.btnSaveExit.Text = "Save / Exit"
        Me.btnSaveExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSaveExit.UseVisualStyleBackColor = False
        '
        'btnEditPenalties
        '
        Me.btnEditPenalties.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditPenalties.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnEditPenalties.FlatAppearance.BorderSize = 0
        Me.btnEditPenalties.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditPenalties.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditPenalties.ForeColor = System.Drawing.Color.White
        Me.btnEditPenalties.Location = New System.Drawing.Point(126, 432)
        Me.btnEditPenalties.Name = "btnEditPenalties"
        Me.btnEditPenalties.Size = New System.Drawing.Size(108, 60)
        Me.btnEditPenalties.TabIndex = 85
        Me.btnEditPenalties.Text = "Edit amount"
        Me.btnEditPenalties.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEditPenalties.UseVisualStyleBackColor = False
        '
        'btnRemovePenalties
        '
        Me.btnRemovePenalties.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemovePenalties.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnRemovePenalties.FlatAppearance.BorderSize = 0
        Me.btnRemovePenalties.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemovePenalties.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemovePenalties.ForeColor = System.Drawing.Color.White
        Me.btnRemovePenalties.Location = New System.Drawing.Point(12, 432)
        Me.btnRemovePenalties.Name = "btnRemovePenalties"
        Me.btnRemovePenalties.Size = New System.Drawing.Size(108, 60)
        Me.btnRemovePenalties.TabIndex = 84
        Me.btnRemovePenalties.Text = "Remove"
        Me.btnRemovePenalties.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemovePenalties.UseVisualStyleBackColor = False
        '
        'lvDuedate
        '
        Me.lvDuedate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvDuedate.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader13, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.lvDuedate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDuedate.FullRowSelect = True
        Me.lvDuedate.GridLines = True
        Me.lvDuedate.Location = New System.Drawing.Point(12, 83)
        Me.lvDuedate.Name = "lvDuedate"
        Me.lvDuedate.Size = New System.Drawing.Size(564, 343)
        Me.lvDuedate.TabIndex = 83
        Me.lvDuedate.UseCompatibleStateImageBehavior = False
        Me.lvDuedate.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Date"
        Me.ColumnHeader9.Width = 91
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Amount"
        Me.ColumnHeader13.Width = 197
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Status"
        Me.ColumnHeader5.Width = 229
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "id"
        Me.ColumnHeader6.Width = 10
        '
        'btnCancelPenalties
        '
        Me.btnCancelPenalties.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelPenalties.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCancelPenalties.FlatAppearance.BorderSize = 0
        Me.btnCancelPenalties.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelPenalties.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelPenalties.ForeColor = System.Drawing.Color.White
        Me.btnCancelPenalties.Location = New System.Drawing.Point(468, 432)
        Me.btnCancelPenalties.Name = "btnCancelPenalties"
        Me.btnCancelPenalties.Size = New System.Drawing.Size(108, 60)
        Me.btnCancelPenalties.TabIndex = 82
        Me.btnCancelPenalties.Text = "Cancel"
        Me.btnCancelPenalties.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancelPenalties.UseVisualStyleBackColor = False
        '
        'btnRestore
        '
        Me.btnRestore.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRestore.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnRestore.FlatAppearance.BorderSize = 0
        Me.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestore.ForeColor = System.Drawing.Color.White
        Me.btnRestore.Location = New System.Drawing.Point(240, 432)
        Me.btnRestore.Name = "btnRestore"
        Me.btnRestore.Size = New System.Drawing.Size(108, 60)
        Me.btnRestore.TabIndex = 81
        Me.btnRestore.Text = "Restore"
        Me.btnRestore.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRestore.UseVisualStyleBackColor = False
        '
        'gbxEditAmount
        '
        Me.gbxEditAmount.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbxEditAmount.BackColor = System.Drawing.Color.LightGray
        Me.gbxEditAmount.Controls.Add(Me.btnCancelColl)
        Me.gbxEditAmount.Controls.Add(Me.btnOk)
        Me.gbxEditAmount.Controls.Add(Me.Label11)
        Me.gbxEditAmount.Controls.Add(Me.txtAmount)
        Me.gbxEditAmount.Controls.Add(Me.btnClientBack)
        Me.gbxEditAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxEditAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxEditAmount.Location = New System.Drawing.Point(98, 61)
        Me.gbxEditAmount.Name = "gbxEditAmount"
        Me.gbxEditAmount.Size = New System.Drawing.Size(443, 201)
        Me.gbxEditAmount.TabIndex = 139
        Me.gbxEditAmount.TabStop = False
        Me.gbxEditAmount.Text = "Input amount"
        Me.gbxEditAmount.Visible = False
        '
        'btnCancelColl
        '
        Me.btnCancelColl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelColl.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnCancelColl.FlatAppearance.BorderSize = 0
        Me.btnCancelColl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelColl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelColl.ForeColor = System.Drawing.Color.White
        Me.btnCancelColl.Location = New System.Drawing.Point(147, 121)
        Me.btnCancelColl.Name = "btnCancelColl"
        Me.btnCancelColl.Size = New System.Drawing.Size(108, 60)
        Me.btnCancelColl.TabIndex = 174
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
        Me.btnOk.Location = New System.Drawing.Point(33, 121)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(108, 60)
        Me.btnOk.TabIndex = 173
        Me.btnOk.Text = "OK"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(30, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 16)
        Me.Label11.TabIndex = 172
        Me.Label11.Text = "Amount"
        '
        'txtAmount
        '
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(33, 62)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(378, 44)
        Me.txtAmount.TabIndex = 171
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnClientBack
        '
        Me.btnClientBack.BackColor = System.Drawing.Color.Gray
        Me.btnClientBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientBack.ForeColor = System.Drawing.Color.White
        Me.btnClientBack.Location = New System.Drawing.Point(572, 15)
        Me.btnClientBack.Name = "btnClientBack"
        Me.btnClientBack.Size = New System.Drawing.Size(60, 24)
        Me.btnClientBack.TabIndex = 169
        Me.btnClientBack.Text = "Back"
        Me.btnClientBack.UseVisualStyleBackColor = False
        '
        'pnlMain
        '
        Me.pnlMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMain.Controls.Add(Me.lvDuedate)
        Me.pnlMain.Controls.Add(Me.lblLoanID)
        Me.pnlMain.Controls.Add(Me.Label2)
        Me.pnlMain.Controls.Add(Me.Label1)
        Me.pnlMain.Controls.Add(Me.btnSaveExit)
        Me.pnlMain.Controls.Add(Me.btnRestore)
        Me.pnlMain.Controls.Add(Me.btnEditPenalties)
        Me.pnlMain.Controls.Add(Me.btnCancelPenalties)
        Me.pnlMain.Controls.Add(Me.btnRemovePenalties)
        Me.pnlMain.Location = New System.Drawing.Point(9, 12)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(587, 499)
        Me.pnlMain.TabIndex = 140
        '
        'lblLoanID
        '
        Me.lblLoanID.AutoSize = True
        Me.lblLoanID.BackColor = System.Drawing.Color.Transparent
        Me.lblLoanID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanID.Location = New System.Drawing.Point(65, 10)
        Me.lblLoanID.Name = "lblLoanID"
        Me.lblLoanID.Size = New System.Drawing.Size(0, 20)
        Me.lblLoanID.TabIndex = 175
        Me.lblLoanID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 16)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Loan ID:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Due date"
        '
        'frmManagePenalties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 524)
        Me.Controls.Add(Me.gbxEditAmount)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "frmManagePenalties"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Penalties"
        Me.gbxEditAmount.ResumeLayout(False)
        Me.gbxEditAmount.PerformLayout()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSaveExit As System.Windows.Forms.Button
    Friend WithEvents btnEditPenalties As System.Windows.Forms.Button
    Friend WithEvents btnRemovePenalties As System.Windows.Forms.Button
    Friend WithEvents lvDuedate As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCancelPenalties As System.Windows.Forms.Button
    Friend WithEvents btnRestore As System.Windows.Forms.Button
    Friend WithEvents gbxEditAmount As System.Windows.Forms.GroupBox
    Friend WithEvents btnClientBack As System.Windows.Forms.Button
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelColl As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLoanID As System.Windows.Forms.Label
End Class
