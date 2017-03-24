<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmService
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
        Me.components = New System.ComponentModel.Container()
        Me.lvListnextToserve = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblTableServe = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvListnextToserve
        '
        Me.lvListnextToserve.BackColor = System.Drawing.Color.Maroon
        Me.lvListnextToserve.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvListnextToserve.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvListnextToserve.Dock = System.Windows.Forms.DockStyle.Right
        Me.lvListnextToserve.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvListnextToserve.ForeColor = System.Drawing.Color.White
        Me.lvListnextToserve.FullRowSelect = True
        Me.lvListnextToserve.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvListnextToserve.Location = New System.Drawing.Point(732, 0)
        Me.lvListnextToserve.Margin = New System.Windows.Forms.Padding(5)
        Me.lvListnextToserve.Name = "lvListnextToserve"
        Me.lvListnextToserve.Size = New System.Drawing.Size(532, 538)
        Me.lvListnextToserve.TabIndex = 1
        Me.lvListnextToserve.UseCompatibleStateImageBehavior = False
        Me.lvListnextToserve.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "0"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "NEXT TO SERVE"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 529
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Controls.Add(Me.lblTableServe)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1264, 538)
        Me.Panel1.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTime})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 486)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1262, 50)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTime
        '
        Me.lblTime.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(87, 45)
        Me.lblTime.Text = "Time"
        '
        'lblTableServe
        '
        Me.lblTableServe.AutoSize = True
        Me.lblTableServe.Font = New System.Drawing.Font("Tahoma", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableServe.Location = New System.Drawing.Point(214, 347)
        Me.lblTableServe.Name = "lblTableServe"
        Me.lblTableServe.Size = New System.Drawing.Size(423, 116)
        Me.lblTableServe.TabIndex = 1
        Me.lblTableServe.Text = "TABLE #"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(87, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(687, 116)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NOW SERVING"
        '
        'Timer1
        '
        '
        'frmService
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1264, 538)
        Me.Controls.Add(Me.lvListnextToserve)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.Name = "frmService"
        Me.Text = "Customer Service"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvListnextToserve As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblTableServe As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lblTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader

End Class
