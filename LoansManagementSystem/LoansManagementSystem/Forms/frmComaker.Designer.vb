﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComaker
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
        Me.btnOkExit = New System.Windows.Forms.Button()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlComaker = New System.Windows.Forms.Panel()
        Me.lvCoMakerList = New System.Windows.Forms.ListView()
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnSelectSearchClient = New System.Windows.Forms.Button()
        Me.gbxAddCoMaker = New System.Windows.Forms.GroupBox()
        Me.btnClientBack = New System.Windows.Forms.Button()
        Me.lvClientList = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearchClient = New System.Windows.Forms.Button()
        Me.txtSearchClient = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.pnlComaker.SuspendLayout()
        Me.gbxAddCoMaker.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOkExit
        '
        Me.btnOkExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOkExit.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnOkExit.FlatAppearance.BorderSize = 0
        Me.btnOkExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOkExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkExit.ForeColor = System.Drawing.Color.White
        Me.btnOkExit.Location = New System.Drawing.Point(234, 434)
        Me.btnOkExit.Name = "btnOkExit"
        Me.btnOkExit.Size = New System.Drawing.Size(108, 60)
        Me.btnOkExit.TabIndex = 138
        Me.btnOkExit.Text = "Ok /Exit"
        Me.btnOkExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnOkExit.UseVisualStyleBackColor = False
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Company/ Branch"
        Me.ColumnHeader3.Width = 147
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Employee No."
        Me.ColumnHeader4.Width = 188
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 239
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Client I.d"
        '
        'pnlComaker
        '
        Me.pnlComaker.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlComaker.Controls.Add(Me.btnOkExit)
        Me.pnlComaker.Controls.Add(Me.lvCoMakerList)
        Me.pnlComaker.Controls.Add(Me.Label26)
        Me.pnlComaker.Controls.Add(Me.btnAddNew)
        Me.pnlComaker.Controls.Add(Me.btnRemove)
        Me.pnlComaker.Location = New System.Drawing.Point(15, 17)
        Me.pnlComaker.Name = "pnlComaker"
        Me.pnlComaker.Size = New System.Drawing.Size(873, 500)
        Me.pnlComaker.TabIndex = 142
        '
        'lvCoMakerList
        '
        Me.lvCoMakerList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvCoMakerList.AutoArrange = False
        Me.lvCoMakerList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader10, Me.ColumnHeader12, Me.ColumnHeader11})
        Me.lvCoMakerList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCoMakerList.FullRowSelect = True
        Me.lvCoMakerList.GridLines = True
        Me.lvCoMakerList.Location = New System.Drawing.Point(6, 55)
        Me.lvCoMakerList.Name = "lvCoMakerList"
        Me.lvCoMakerList.Size = New System.Drawing.Size(854, 373)
        Me.lvCoMakerList.TabIndex = 135
        Me.lvCoMakerList.UseCompatibleStateImageBehavior = False
        Me.lvCoMakerList.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Client I.d"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Name"
        Me.ColumnHeader10.Width = 239
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Employee No."
        Me.ColumnHeader12.Width = 188
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Company / Branch"
        Me.ColumnHeader11.Width = 188
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(3, 25)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(90, 16)
        Me.Label26.TabIndex = 134
        Me.Label26.Text = "Co-maker List"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnAddNew
        '
        Me.btnAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddNew.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnAddNew.FlatAppearance.BorderSize = 0
        Me.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddNew.ForeColor = System.Drawing.Color.White
        Me.btnAddNew.Location = New System.Drawing.Point(6, 434)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(108, 60)
        Me.btnAddNew.TabIndex = 137
        Me.btnAddNew.Text = "Add Co-maker"
        Me.btnAddNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddNew.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnRemove.FlatAppearance.BorderSize = 0
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Location = New System.Drawing.Point(120, 434)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(108, 60)
        Me.btnRemove.TabIndex = 136
        Me.btnRemove.Text = "Remove Co-maker"
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnSelectSearchClient
        '
        Me.btnSelectSearchClient.BackColor = System.Drawing.Color.Gray
        Me.btnSelectSearchClient.FlatAppearance.BorderSize = 0
        Me.btnSelectSearchClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectSearchClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelectSearchClient.ForeColor = System.Drawing.Color.White
        Me.btnSelectSearchClient.Location = New System.Drawing.Point(241, 398)
        Me.btnSelectSearchClient.Name = "btnSelectSearchClient"
        Me.btnSelectSearchClient.Size = New System.Drawing.Size(192, 55)
        Me.btnSelectSearchClient.TabIndex = 170
        Me.btnSelectSearchClient.Text = "Select "
        Me.btnSelectSearchClient.UseVisualStyleBackColor = False
        '
        'gbxAddCoMaker
        '
        Me.gbxAddCoMaker.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbxAddCoMaker.BackColor = System.Drawing.Color.LightGray
        Me.gbxAddCoMaker.Controls.Add(Me.btnSelectSearchClient)
        Me.gbxAddCoMaker.Controls.Add(Me.btnClientBack)
        Me.gbxAddCoMaker.Controls.Add(Me.lvClientList)
        Me.gbxAddCoMaker.Controls.Add(Me.Label1)
        Me.gbxAddCoMaker.Controls.Add(Me.btnSearchClient)
        Me.gbxAddCoMaker.Controls.Add(Me.txtSearchClient)
        Me.gbxAddCoMaker.Controls.Add(Me.Label28)
        Me.gbxAddCoMaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gbxAddCoMaker.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxAddCoMaker.Location = New System.Drawing.Point(112, 51)
        Me.gbxAddCoMaker.Name = "gbxAddCoMaker"
        Me.gbxAddCoMaker.Size = New System.Drawing.Size(685, 466)
        Me.gbxAddCoMaker.TabIndex = 141
        Me.gbxAddCoMaker.TabStop = False
        Me.gbxAddCoMaker.Text = "Add New Co-maker"
        Me.gbxAddCoMaker.Visible = False
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
        'lvClientList
        '
        Me.lvClientList.AutoArrange = False
        Me.lvClientList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader3})
        Me.lvClientList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvClientList.FullRowSelect = True
        Me.lvClientList.GridLines = True
        Me.lvClientList.Location = New System.Drawing.Point(13, 96)
        Me.lvClientList.Name = "lvClientList"
        Me.lvClientList.Size = New System.Drawing.Size(659, 287)
        Me.lvClientList.TabIndex = 168
        Me.lvClientList.UseCompatibleStateImageBehavior = False
        Me.lvClientList.View = System.Windows.Forms.View.Details
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "Client List"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSearchClient
        '
        Me.btnSearchClient.BackColor = System.Drawing.Color.Gray
        Me.btnSearchClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchClient.ForeColor = System.Drawing.Color.White
        Me.btnSearchClient.Location = New System.Drawing.Point(252, 42)
        Me.btnSearchClient.Name = "btnSearchClient"
        Me.btnSearchClient.Size = New System.Drawing.Size(61, 24)
        Me.btnSearchClient.TabIndex = 166
        Me.btnSearchClient.Text = "Search"
        Me.btnSearchClient.UseVisualStyleBackColor = False
        '
        'txtSearchClient
        '
        Me.txtSearchClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchClient.Location = New System.Drawing.Point(80, 42)
        Me.txtSearchClient.Name = "txtSearchClient"
        Me.txtSearchClient.Size = New System.Drawing.Size(166, 22)
        Me.txtSearchClient.TabIndex = 165
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(10, 45)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(51, 16)
        Me.Label28.TabIndex = 164
        Me.Label28.Text = "Search"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmComaker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 535)
        Me.Controls.Add(Me.gbxAddCoMaker)
        Me.Controls.Add(Me.pnlComaker)
        Me.Name = "frmComaker"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Co-maker(s) of "
        Me.pnlComaker.ResumeLayout(False)
        Me.pnlComaker.PerformLayout()
        Me.gbxAddCoMaker.ResumeLayout(False)
        Me.gbxAddCoMaker.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOkExit As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlComaker As System.Windows.Forms.Panel
    Friend WithEvents lvCoMakerList As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnAddNew As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnSelectSearchClient As System.Windows.Forms.Button
    Friend WithEvents gbxAddCoMaker As System.Windows.Forms.GroupBox
    Friend WithEvents btnClientBack As System.Windows.Forms.Button
    Friend WithEvents lvClientList As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearchClient As System.Windows.Forms.Button
    Friend WithEvents txtSearchClient As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
End Class
