<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClientRequirement
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbxAddReq = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_remark = New System.Windows.Forms.TextBox()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.ListView3 = New System.Windows.Forms.ListView()
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnReqBack = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbxAddReq.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbxAddReq)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label27)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnReqBack)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label29)
        Me.SplitContainer1.Size = New System.Drawing.Size(1052, 519)
        Me.SplitContainer1.SplitterDistance = 478
        Me.SplitContainer1.TabIndex = 165
        '
        'gbxAddReq
        '
        Me.gbxAddReq.Controls.Add(Me.btnBrowse)
        Me.gbxAddReq.Controls.Add(Me.Label19)
        Me.gbxAddReq.Controls.Add(Me.Label1)
        Me.gbxAddReq.Controls.Add(Me.txt_remark)
        Me.gbxAddReq.Controls.Add(Me.Btn_Save)
        Me.gbxAddReq.Location = New System.Drawing.Point(9, 281)
        Me.gbxAddReq.Name = "gbxAddReq"
        Me.gbxAddReq.Size = New System.Drawing.Size(458, 233)
        Me.gbxAddReq.TabIndex = 167
        Me.gbxAddReq.TabStop = False
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.BackColor = System.Drawing.Color.Gray
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.ForeColor = System.Drawing.Color.White
        Me.btnBrowse.Location = New System.Drawing.Point(8, 49)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(104, 36)
        Me.btnBrowse.TabIndex = 166
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(143, 93)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 16)
        Me.Label19.TabIndex = 137
        Me.Label19.Text = "Remarks: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 16)
        Me.Label1.TabIndex = 141
        '
        'txt_remark
        '
        Me.txt_remark.Location = New System.Drawing.Point(146, 112)
        Me.txt_remark.Multiline = True
        Me.txt_remark.Name = "txt_remark"
        Me.txt_remark.Size = New System.Drawing.Size(306, 113)
        Me.txt_remark.TabIndex = 138
        '
        'Btn_Save
        '
        Me.Btn_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Btn_Save.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Btn_Save.FlatAppearance.BorderSize = 0
        Me.Btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Btn_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save.ForeColor = System.Drawing.Color.White
        Me.Btn_Save.Location = New System.Drawing.Point(8, 112)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(108, 60)
        Me.Btn_Save.TabIndex = 139
        Me.Btn_Save.Text = "Add"
        Me.Btn_Save.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Btn_Save.UseVisualStyleBackColor = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 19)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(129, 16)
        Me.Label27.TabIndex = 129
        Me.Label27.Text = "List of Requirements"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ListView3
        '
        Me.ListView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView3.AutoArrange = False
        Me.ListView3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader20})
        Me.ListView3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView3.FullRowSelect = True
        Me.ListView3.GridLines = True
        Me.ListView3.Location = New System.Drawing.Point(9, 48)
        Me.ListView3.Name = "ListView3"
        Me.ListView3.Size = New System.Drawing.Size(458, 227)
        Me.ListView3.TabIndex = 130
        Me.ListView3.UseCompatibleStateImageBehavior = False
        Me.ListView3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Image path"
        Me.ColumnHeader18.Width = 186
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Remarks"
        Me.ColumnHeader20.Width = 247
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(11, 48)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(542, 458)
        Me.PictureBox1.TabIndex = 165
        Me.PictureBox1.TabStop = False
        '
        'btnReqBack
        '
        Me.btnReqBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReqBack.BackColor = System.Drawing.Color.Gray
        Me.btnReqBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReqBack.ForeColor = System.Drawing.Color.White
        Me.btnReqBack.Location = New System.Drawing.Point(449, 6)
        Me.btnReqBack.Name = "btnReqBack"
        Me.btnReqBack.Size = New System.Drawing.Size(104, 36)
        Me.btnReqBack.TabIndex = 163
        Me.btnReqBack.Text = "Back"
        Me.btnReqBack.UseVisualStyleBackColor = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 18)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(56, 16)
        Me.Label29.TabIndex = 164
        Me.Label29.Text = "Preview"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmClientRequirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 519)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmClientRequirement"
        Me.Text = "Client (name) Requirements"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbxAddReq.ResumeLayout(False)
        Me.gbxAddReq.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ListView3 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnReqBack As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_Save As System.Windows.Forms.Button
    Friend WithEvents txt_remark As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents gbxAddReq As System.Windows.Forms.GroupBox
End Class
