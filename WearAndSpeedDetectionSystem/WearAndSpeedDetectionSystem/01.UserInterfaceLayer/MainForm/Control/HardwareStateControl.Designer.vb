<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HardwareStateControl
    Inherits System.Windows.Forms.UserControl

    'UserControl 重写释放以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ListViewEx1 = New DevComponents.DotNetBar.Controls.ListViewEx()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "刀具编号:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "设备ID:"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 1, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(14, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(113, 58)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "未知"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(68, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "未知"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 42)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 12)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "电压:"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(68, 42)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "未知"
        '
        'ListView1
        '
        Me.ListView1.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(133, 29)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(608, 32)
        Me.ListView1.TabIndex = 3
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "传感器"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "磨损 mm"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 58
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "温度 °C"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "转速 r/s"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 72
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "频点1"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "频点1值"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "频点2"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "频点2值"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "频点3"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "频点3值"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(8, 66)
        Me.Label3.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Location = New System.Drawing.Point(8, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(736, 1)
        Me.Label8.TabIndex = 6
        '
        'ListViewEx1
        '
        Me.ListViewEx1.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        '
        '
        '
        Me.ListViewEx1.Border.Class = "ListViewBorder"
        Me.ListViewEx1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListViewEx1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20})
        Me.ListViewEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.ListViewEx1.Enabled = False
        Me.ListViewEx1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ListViewEx1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEx1.HideSelection = False
        Me.ListViewEx1.Location = New System.Drawing.Point(133, 3)
        Me.ListViewEx1.Name = "ListViewEx1"
        Me.ListViewEx1.Size = New System.Drawing.Size(608, 25)
        Me.ListViewEx1.TabIndex = 7
        Me.ListViewEx1.UseCompatibleStateImageBehavior = False
        Me.ListViewEx1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "传感器"
        Me.ColumnHeader11.Width = 51
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "磨损 mm"
        Me.ColumnHeader12.Width = 58
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "温度 °C"
        Me.ColumnHeader13.Width = 63
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "转速 r/s"
        Me.ColumnHeader14.Width = 75
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "频点1"
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "频点1值"
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "频点2"
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "频点2值"
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "频点3"
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "频点3值"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Location = New System.Drawing.Point(133, 29)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(608, 32)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'HardwareStateControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Controls.Add(Me.ListViewEx1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ListView1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Name = "HardwareStateControl"
        Me.Size = New System.Drawing.Size(744, 66)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ListViewEx1 As DevComponents.DotNetBar.Controls.ListViewEx
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents PictureBox1 As PictureBox
End Class
