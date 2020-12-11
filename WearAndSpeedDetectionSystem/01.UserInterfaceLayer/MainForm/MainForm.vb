Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms.DataVisualization.Charting
Imports DevComponents.DotNetBar
Imports Microsoft.Win32

Public Class MainForm

#Region "控制台窗口"
    '调用控制台窗口
    <Runtime.InteropServices.DllImport(”kernel32.dll”)>
    Private Shared Function AllocConsole() As Boolean
    End Function
    '释放控制台窗口
    <Runtime.InteropServices.DllImport(”kernel32.dll”)>
    Private Shared Function FreeConsole() As Boolean
    End Function
#End Region

    Private SensorChartArea As DataVisualization.Charting.ChartArea
    Private SensorSeriesArray(3 - 1) As DataVisualization.Charting.Series
    Private Background As Bitmap
    Private BackgroundGraphics As Graphics

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Region "产品版本号"
        Dim assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim versionStr = System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductVersion
        Me.Text = $"{My.Application.Info.Title} V{versionStr}"
#End Region

        'Wangk.Resource.ConsoleDebug.Open()

        AppSettingHelper.GetInstance.Logger.Info("程序启动")

#Region "功能区"
        '串口号
        With ComboBoxItem1
            .Items.AddRange(IO.Ports.SerialPort.GetPortNames())

            If .Items.Contains(AppSettingHelper.GetInstance.SerialPort) Then
                .Text = AppSettingHelper.GetInstance.SerialPort
            ElseIf .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

        ''波特率
        'With ComboBoxItem2
        '    .Items.AddRange({"9600bps", "19200bps", "115200bps"})

        '    If .Items.Contains(AppSettingHelper.GetInstance.BPS) Then
        '        .Text = AppSettingHelper.GetInstance.BPS
        '    Else
        '        .SelectedIndex = 0
        '    End If
        'End With

        '设备轮询间隔
        With ComboBoxItem4
            For sec = 10 To 60 * 30
                .Items.Add($"{sec}s")
            Next

            If .Items.Contains($"{AppSettingHelper.GetInstance.pollingInterval}s") Then
                .Text = $"{AppSettingHelper.GetInstance.pollingInterval}s"
            Else
                .SelectedIndex = 20 - 1
            End If
        End With
#End Region

#Region "概览"
        'With DataGridView1
        '    .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        '    .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        '    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
        '    .DefaultCellStyle.BackColor = Color.FromArgb(71, 71, 71)
        'End With
#End Region

#Region "设备状态"
        With CheckBoxDataGridView1
            '.BorderStyle = BorderStyle.None
            '.RowHeadersVisible = True
            '.RowHeadersWidth = 62

            '.AllowUserToResizeRows = True
            '.AllowUserToOrderColumns = True
            '.AllowUserToResizeColumns = True
            '.SelectionMode = DataGridViewSelectionMode.CellSelect
            '.MultiSelect = False
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(&HE9, &HED, &HF4)
            '.GridColor = Color.FromArgb(&HE5, &HE5, &HE5)
            '.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
            .ReadOnly = True
            '.EditMode = DataGridViewEditMode.EditOnEnter

            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .BackgroundColor = Color.FromArgb(71, 71, 71)
            .SelectionMode = DataGridViewSelectionMode.CellSelect

            '.RowHeadersVisible = False
            .EnableHeadersVisualStyles = False
            .RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(71, 71, 71)
            .RowHeadersDefaultCellStyle.ForeColor = SystemColors.Window
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .RowHeadersWidth = 90
            '.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
            '.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            .AllowUserToResizeRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = True
            .DefaultCellStyle.BackColor = Color.FromArgb(71, 71, 71)

            '.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders

            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(56, 56, 60)
            .EditMode = DataGridViewEditMode.EditOnEnter
            .GridColor = Color.FromArgb(45, 45, 48)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical

            '.RowTemplate.Height = 30
        End With
#End Region

#Region "历史数据"
        '刀具编号
        With ComboBox1
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        '历史文件
        Button2_Click(Nothing, Nothing)

        '历史数据参数类型
        With ComboBox3
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.Add("模块电压")
            For i001 = 1 To 4
                .Items.AddRange({$"{i001}号传感器磨损",
                                $"{i001}号传感器温度",
                                $"{i001}号传感器转速",
                                $"{i001}号传感器频点1",
                                $"{i001}号传感器频点1值",
                                $"{i001}号传感器频点2",
                                $"{i001}号传感器频点2值",
                                $"{i001}号传感器频点3",
                                $"{i001}号传感器频点3值"})
            Next

            .SelectedIndex = 0
        End With

        '显示图表
        SensorChartArea = New DataVisualization.Charting.ChartArea
        With SensorChartArea
            .BackColor = Color.FromArgb(71, 71, 71)
            .AxisX.TitleForeColor = Color.FromArgb(215, 215, 215)
            .AxisX.LabelStyle.ForeColor = Color.FromArgb(215, 215, 215)
            .AxisX.LineColor = Color.FromArgb(215, 215, 215)
            .AxisX.MajorGrid.LineColor = Color.FromArgb(215, 215, 215)
            .AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
            .AxisX.MajorTickMark.LineColor = Color.FromArgb(215, 215, 215)
            .AxisX.LabelStyle.Format = "yyyy/MM/dd HH:mm:ss"
            .AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds

            .AxisY.LabelStyle.ForeColor = Color.FromArgb(215, 215, 215)
            .AxisY.LineColor = Color.FromArgb(215, 215, 215)
            .AxisY.MajorGrid.LineColor = Color.FromArgb(215, 215, 215)
            .AxisY.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
            .AxisY.MajorTickMark.LineColor = Color.FromArgb(215, 215, 215)

            '.AxisX.ScrollBar.LineColor = System.Drawing.Color.Red     
            .AxisX.ScrollBar.LineColor = Color.FromArgb(51, 51, 51)
            .AxisX.ScrollBar.BackColor = Color.FromArgb(51, 51, 51)
            .AxisX.ScrollBar.ButtonColor = Color.FromArgb(84, 89, 98)
            '设置滚动条宽度大小
            .AxisX.ScrollBar.Size = 20
            '设置滚动条在图像内还是在图像外
            .AxisX.ScrollBar.IsPositionedInside = False
            .AxisX.ScrollBar.Enabled = True
            .AxisX.ScrollBar.ButtonStyle = DataVisualization.Charting.ScrollBarButtonStyles.All
            .AxisX.ScaleView.SmallScrollMinSize = 1
            .AxisX.ScaleView.SmallScrollMinSizeType = DataVisualization.Charting.DateTimeIntervalType.Seconds
            '此项设置将可以采用MSChart图形中鼠标点击移动滚动条功能
            .CursorX.IsUserEnabled = True
            .CursorX.IsUserSelectionEnabled = True
            .CursorX.Interval = 0
            .CursorX.IntervalOffset = 0
            .CursorX.IntervalType = DataVisualization.Charting.DateTimeIntervalType.Seconds
            .AxisX.ScaleView.Zoomable = True      '启用用户缩放数据

            .AxisX.Minimum = Now.Date.ToOADate
            .AxisX.Maximum = Now.AddDays(1).Date.ToOADate
            .AxisX.Title = "未定义"
            .Name = "SensorChartArea"
        End With
        Chart1.ChartAreas.Add(SensorChartArea)

        For i001 = 0 To 1 - 1
            SensorSeriesArray(i001) = New DataVisualization.Charting.Series
            With SensorSeriesArray(i001)
                .ChartArea = SensorChartArea.Name
                '.ChartType = DataVisualization.Charting.SeriesChartType.FastLine
                .ChartType = DataVisualization.Charting.SeriesChartType.Line
                '.IsValueShownAsLabel = True
                .LabelForeColor = Color.FromArgb(215, 215, 215)
                .XValueType = DataVisualization.Charting.ChartValueType.DateTime
            End With
            Chart1.Series.Add(SensorSeriesArray(i001))

        Next

        With SensorSeriesArray(0)
            .Color = Color.OrangeRed
            .LegendText = "传感器数值"
            .BorderWidth = 3
        End With
        'With SensorSeriesArray(1)
        '    .Color = Color.LightGreen
        '    .LegendText = "1号传感器"
        '    .BorderWidth = 3
        'End With
        'With SensorSeriesArray(2)
        '    .Color = Color.DodgerBlue
        '    .LegendText = "2号传感器"
        '    .BorderWidth = 3
        'End With

        System.IO.Directory.CreateDirectory($".\SensorData")
        Button1_Click(Nothing, Nothing)

#End Region

        'CheckBoxItem1.Checked = AppSettingHelper.Settings.IsAutoRun

#Region "隐藏历史模块"
        TabControl2.Tabs.Remove(TabItem4)
        TabControl2.SelectedTabIndex = 0
#End Region

        '更新时间
        Timer1.Interval = 1000
        Timer1.Start()
        Timer1_Tick(Nothing, Nothing)

        CreateHardwareStateControl()

        LinkControlState(False)

        ButtonItem2.Enabled = AppSettingHelper.GetInstance.HardwareItems.Count <> 0

        HardwareStateHelper.UIMainForm = Me

        CreateOverviewBackground()

        'AllocConsole()
        'Me.Width = 1600

        'Dim tmp = New Uploadpackage With {.Key = "88899EFF-1934-4DCA-83C9-716B93EC4961"}
        'For Each item In AppSettingHelper.GetInstance.HardwareItems
        '    tmp.SensorItems.Add(New UploadHardwareInfo With {
        '                        .ID = item.Name,
        '                        .Type = If(item.IsSerratedKnife, "齿刀", "滚刀"),
        '                        .State = If(item.IsOnline, "在线", "离线"),
        '                        .Voltage = item.Voltage,
        '                        .VoltageMinimum = AppSettingHelper.GetInstance.BatteryVoltageMinimum,
        '                        .Sensor1Wear = Math.Round(item.SensorDataItems(0 + If(item.IsSerratedKnife, 2, 0), 0) / 10, 1),
        '                        .Sensor1State = If(item.SensorDataItems(0 + If(item.IsSerratedKnife, 2, 0), 2) > 0, "转动", "静止"),
        '                        .Sensor2Wear = Math.Round(item.SensorDataItems(1 + If(item.IsSerratedKnife, 2, 0), 0) / 10, 1),
        '                        .Sensor2State = If(item.SensorDataItems(1 + If(item.IsSerratedKnife, 2, 0), 2) > 0, "转动", "静止"),
        '                        .SensorWearMaximum = AppSettingHelper.GetInstance.WearMaximum / 10,
        '                        .UpdateTime = item.UpdateTime.ToString("yyyy/MM/dd HH:mm:ss")
        '                        })
        'Next

        'Using t As System.IO.StreamWriter = New System.IO.StreamWriter(
        '           $"upload.json",
        '           False,
        '           System.Text.Encoding.UTF8)

        '    t.Write(Newtonsoft.Json.JsonConvert.SerializeObject(tmp))
        'End Using

    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If HardwareStateHelper.IsRunning Then
            e.Cancel = True
        End If

        'FreeConsole()
    End Sub

#Region "连接后控件状态"
    ''' <summary>
    ''' 连接后控件状态
    ''' </summary>
    Private Sub LinkControlState(value As Boolean)
        ItemContainer2.Enabled = Not value
        ComboBoxItem1.Enabled = Not value
        'ComboBoxItem2.Enabled = Not value
        ComboBoxItem4.Enabled = Not value
        ButtonItem2.Enabled = Not value
        ButtonItem3.Enabled = value
        ButtonItem5.Enabled = value
        ButtonItem4.Enabled = Not value
        ButtonItem7.Enabled = Not value
        ButtonItem8.Enabled = Not value
    End Sub
#End Region

#Region "重新检测串口号"
    ''' <summary>
    ''' 重新检测串口号
    ''' </summary>
    Private Sub ButtonItem1_Click(sender As Object, e As EventArgs) Handles ButtonItem1.Click
        '串口号
        With ComboBoxItem1
            .Items.Clear()
            .Items.AddRange(IO.Ports.SerialPort.GetPortNames())

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With
    End Sub
#End Region

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = Now().ToString("yyyy/MM/dd HH:mm:ss")
    End Sub

#Region "创建硬件信息控件"
    ''' <summary>
    ''' 创建硬件信息控件
    ''' </summary>
    Private Sub CreateHardwareStateControl()

        'FlowLayoutPanel1.Controls.Clear()
        CheckBoxDataGridView1.Rows.Clear()

        For Each item In AppSettingHelper.GetInstance.HardwareItems
            'tmpHardware.HardwareStateControl = New HardwareStateControlByGDI With {
            '    .HardwareInfo = tmpHardware
            '}

            'FlowLayoutPanel1.Controls.Add(tmpHardware.HardwareStateControl)
            'tmpHardware.HardwareStateControl.Show()

            Dim addRowID = CheckBoxDataGridView1.Rows.Add(1)
            '{False,
            '                                              item.Name,
            '                                              item.ID,
            '                                              If(item.IsSerratedKnife, My.Resources.knife02_20px, My.Resources.knife01_20px),
            '                                              If(item.IsOnline, If(item.IsMeasureSpeed, My.Resources.state03_20px, My.Resources.state01_20px), My.Resources.state02_20px),
            '                                              $"{Math.Round(item.Voltage, 2)} V",
            '                                              $"{Math.Round(item.SensorDataItems(0, 0) / 10, 1)} mm",
            '                                              $"{Math.Round(item.SensorDataItems(0, 2) / 10, 1)} r/s",
            '                                              $"{Math.Round(item.SensorDataItems(1, 0) / 10, 1)} mm",
            '                                              $"{Math.Round(item.SensorDataItems(1, 2) / 10, 1)} r/s"})

            item.HardwareStateControl = CheckBoxDataGridView1.Rows(addRowID)

        Next

    End Sub
#End Region

#Region "创建硬件概览背景图片"
    ''' <summary>
    ''' 创建硬件概览背景图片
    ''' </summary>
    Private Sub CreateOverviewBackground()
        If Not IO.File.Exists(AppSettingHelper.OverviewBackgroundLocation) Then
            Exit Sub
        End If

        Background = Bitmap.FromFile(AppSettingHelper.OverviewBackgroundLocation)
        BackgroundGraphics = Graphics.FromImage(Background)

        For Each tmpHardware In AppSettingHelper.GetInstance.HardwareItems
            UpdateOverviewBackground(tmpHardware)
        Next

        PictureBox1.Image = Background

    End Sub
#End Region

#Region "连接串口"
    Private Sub ButtonItem2_Click(sender As Object, e As EventArgs) Handles ButtonItem2.Click

        Try
            If ComboBoxItem1.Text = "" Then
                Exit Sub
            End If

            HardwareStateHelper.StartAsync(ComboBoxItem1.Text, AppSettingHelper.BPS)

            AppSettingHelper.GetInstance.SerialPort = ComboBoxItem1.Text
            'AppSettingHelper.GetInstance.BPS = ComboBoxItem2.Text
            AppSettingHelper.GetInstance.pollingInterval = Val(ComboBoxItem4.Text)

            AppSettingHelper.SaveToLocaltion()

            LinkControlState(True)

            Me.Log($"连接串口 {ComboBoxItem1.Text}({AppSettingHelper.BPS})")

        Catch ex As Exception
            MsgBox(ex.Message,
                   MsgBoxStyle.Information,
                   "连接串口失败")
        End Try

    End Sub
#End Region

#Region "断开串口"
    Private Sub ButtonItem3_Click(sender As Object, e As EventArgs) Handles ButtonItem3.Click

        Using tmpDialog As New Wangk.Resource.BackgroundWorkDialog With {
            .Text = "断开中",
            .IsPercent = False
        }
            tmpDialog.Start(Sub()
                                HardwareStateHelper.StopAsync()
                            End Sub,
                            Nothing)

        End Using

        LinkControlState(False)

        Me.Log($"断开串口")

    End Sub
#End Region

#Region "编辑设备列表"
    Private Sub ButtonItem4_Click(sender As Object, e As EventArgs) Handles ButtonItem4.Click
        If BackgroundGraphics IsNot Nothing Then BackgroundGraphics.Dispose()
        If Background IsNot Nothing Then Background.Dispose()

        Using tmpDialog As New EditHardwareItemsForm
            If tmpDialog.ShowDialog <> DialogResult.OK Then
                CreateOverviewBackground()
                Exit Sub
            End If

            CreateHardwareStateControl()

            CreateOverviewBackground()

            ButtonItem2.Enabled = (AppSettingHelper.GetInstance.HardwareItems.Count > 0)

            AppSettingHelper.SaveToLocaltion()

        End Using

    End Sub
#End Region

#Region "显示历史数据模块"
    Private Sub ButtonItem6_Click(sender As Object, e As EventArgs) Handles ButtonItem6.Click
        Using tmpDialog As New Wangk.Resource.InputTextDialog With {
            .Text = "输入查看密码",
            .PasswordChar = "●"
        }

            If tmpDialog.ShowDialog("确定", "取消") <> DialogResult.OK Then
                Exit Sub
            End If

            If tmpDialog.Value = "20191009" Then
                'TabControl2.Tabs.Add(TabItem3)
                If TabControl2.Tabs.Contains(TabItem4) Then
                    Exit Sub
                End If

                TabControl2.Tabs.Add(TabItem4)

                'ButtonItem6.Enabled = False

                TabControl2.RecalcLayout()
            End If

        End Using

    End Sub
#End Region

#Region "输出日志"
    Public Delegate Sub LogCallback(text As String)
    Public Sub Log(text As String)
        If Me.InvokeRequired Then
            Me.Invoke(New LogCallback(AddressOf Log),
                      New Object() {text})
            Exit Sub
        End If

        If TextBox1.Lines().Count > 200 Then
            TextBox1.Text = TextBox1.Text.Remove(0, TextBox1.Text.Count \ 2)
        End If
        TextBox1.AppendText($"{Now():yyyy/MM/dd HH:mm:ss}> {text}{vbCrLf}")

        AppSettingHelper.GetInstance.Logger.Info(text)

    End Sub
#End Region

#Region "更新概览图片"
    Public Delegate Sub UpdateOverviewBackgroundCallback(value As HardwareInfo)
    Public Sub UpdateOverviewBackground(value As HardwareInfo)
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateOverviewBackgroundCallback(AddressOf UpdateOverviewBackground),
                      New Object() {value})
            Exit Sub
        End If

#Region "画笔及画刷"
        Dim boxPen As New Pen(Color.FromArgb(51, 51, 51), 1)
        Dim backgroundColorSolidBrush As New SolidBrush(Color.LimeGreen)
        Dim backgroundColorSolidBrush2 As New SolidBrush(Color.FromArgb(255, 127, 127))
        'Dim backgroundColorSolidBrush3 As New SolidBrush(Color.FromArgb(18, 150, 219))
        'Dim backgroundColorSolidBrush2 As New SolidBrush(Color.OrangeRed)
        Dim fontSolidBrush As New SolidBrush(Color.FromArgb(51, 51, 51))
        Dim tmpRectangle As Rectangle
        With tmpRectangle
            .Width = 50
            .Height = 48
            .Location = value.Location
        End With
#End Region

        Dim serratedKnifeCount = If(value.IsSerratedKnife, 2, 0)

        '填充底色
        If value.IsOnline Then
            '在线
            If value.SensorDataItems(0 + serratedKnifeCount, 2) > 0 OrElse
                value.SensorDataItems(1 + serratedKnifeCount, 2) > 0 Then
                '转动
                BackgroundGraphics.FillRectangle(backgroundColorSolidBrush, tmpRectangle)
            Else
                '静止
                BackgroundGraphics.FillRectangle(backgroundColorSolidBrush2, tmpRectangle)
            End If

        Else
            '离线
            BackgroundGraphics.FillRectangle(backgroundColorSolidBrush, tmpRectangle)
        End If

        '绘制箱体边框
        BackgroundGraphics.DrawRectangle(boxPen, tmpRectangle)
        '绘制连接信息
        BackgroundGraphics.DrawString($"{value.Name}
{Math.Round(value.SensorDataItems(0 + serratedKnifeCount, 0) / 10, 1)}mm
{Math.Round(value.SensorDataItems(1 + serratedKnifeCount, 0) / 10, 1)}mm",
                                  Me.Font,
                                  fontSolidBrush,
                                  value.Location.X + 1,
                                  value.Location.Y + 1)

        If value.IsSerratedKnife Then
            BackgroundGraphics.DrawImage(My.Resources.serratedKnife_16px,
                                         value.Location.X + tmpRectangle.Width - 16 - 1,
                                         value.Location.Y + 1 + 1)
        End If

        PictureBox1.Image = Background

        '更新设备列表
        value.HardwareStateControl.Cells(1).Value = value.Name
        value.HardwareStateControl.Cells(2).Value = value.ID
        value.HardwareStateControl.Cells(3).Value = If(value.IsSerratedKnife, My.Resources.knife02_20px, My.Resources.knife01_20px)
        value.HardwareStateControl.Cells(4).Value = If(value.IsOnline, If(value.IsMeasureSpeed, My.Resources.state03_20px, My.Resources.state01_20px), My.Resources.state02_20px)

        'If value.IsOnline Then
        '    '在线显示数值
        '电压
        value.HardwareStateControl.Cells(5).Value = $"{Math.Round(value.Voltage, 2)} V"
        If value.Voltage < AppSettingHelper.GetInstance.BatteryVoltageMinimum AndAlso
                value.IsOnline Then

            value.HardwareStateControl.Cells(5).Style.BackColor = Color.FromArgb(216, 99, 68)
        Else
            value.HardwareStateControl.Cells(5).Style.BackColor = Nothing
        End If

        '传感器1磨损
        value.HardwareStateControl.Cells(6).Value = $"{Math.Round(value.SensorDataItems(0 + serratedKnifeCount, 0) / 10, 1)} mm"
        If AppSettingHelper.GetInstance.WearMaximum < value.SensorDataItems(0 + serratedKnifeCount, 0) AndAlso
                value.IsOnline Then

            value.HardwareStateControl.Cells(6).Style.BackColor = Color.FromArgb(216, 99, 68)
        Else
            value.HardwareStateControl.Cells(6).Style.BackColor = Nothing
        End If

        '传感器1转速
        value.HardwareStateControl.Cells(7).Value = $"{Math.Round(value.SensorDataItems(0 + serratedKnifeCount, 2) / 10, 1)} r/s"
        If AppSettingHelper.GetInstance.SpeedMaximum < value.SensorDataItems(0 + serratedKnifeCount, 2) AndAlso
                value.IsOnline Then

            value.HardwareStateControl.Cells(7).Style.BackColor = Color.FromArgb(216, 99, 68)
        Else
            value.HardwareStateControl.Cells(7).Style.BackColor = Nothing
        End If

        '传感器2磨损
        value.HardwareStateControl.Cells(8).Value = $"{Math.Round(value.SensorDataItems(1 + serratedKnifeCount, 0) / 10, 1)} mm"
        If AppSettingHelper.GetInstance.WearMaximum < value.SensorDataItems(1 + serratedKnifeCount, 0) AndAlso
                value.IsOnline Then

            value.HardwareStateControl.Cells(8).Style.BackColor = Color.FromArgb(216, 99, 68)
        Else
            value.HardwareStateControl.Cells(8).Style.BackColor = Nothing
        End If

        '传感器1转速
        value.HardwareStateControl.Cells(9).Value = $"{Math.Round(value.SensorDataItems(1 + serratedKnifeCount, 2) / 10, 1)} r/s"
        If AppSettingHelper.GetInstance.SpeedMaximum < value.SensorDataItems(1 + serratedKnifeCount, 2) AndAlso
                value.IsOnline Then

            value.HardwareStateControl.Cells(9).Style.BackColor = Color.FromArgb(216, 99, 68)
        Else
            value.HardwareStateControl.Cells(9).Style.BackColor = Nothing
        End If

        '更新时间
        If value.UpdateTime.Year = 1 Then
            value.HardwareStateControl.Cells(10).Value = "-"
        Else
            value.HardwareStateControl.Cells(10).Value = value.UpdateTime.ToString("yyyy/MM/dd HH:mm:ss")
        End If

        'Else
        '    '离线显示空
        '    value.HardwareStateControl.Cells(5).Value = "-"
        '    value.HardwareStateControl.Cells(6).Value = "-"
        '    value.HardwareStateControl.Cells(7).Value = "-"
        '    value.HardwareStateControl.Cells(8).Value = "-"
        '    value.HardwareStateControl.Cells(9).Value = "-"
        '    Exit Sub
        'End If

    End Sub
#End Region

#Region "更新告警信息"
    '''' <summary>
    '''' 更新告警信息
    '''' </summary>
    'Private Sub UpdateWarningMessage(value As HardwareInfo)
    '    Dim rowID As Integer = -1
    '    For Each item As DataGridViewRow In DataGridView1.Rows
    '        If $"{item.Cells(1).Value}" = $"{value.ID}" Then
    '            rowID = DataGridView1.Rows.IndexOf(item)
    '            Exit For
    '        End If
    '    Next

    '    If value.Voltage < AppSettingHelper.Settings.BatteryVoltageMinimum Then
    '        If rowID = -1 Then
    '            rowID = DataGridView1.Rows.Add({$"{value.Name}", $"{value.ID}", $"电池低于{AppSettingHelper.Settings.BatteryVoltageMinimum}V"})
    '            DataGridView1.Rows(rowID).DefaultCellStyle.BackColor = Color.FromArgb(221, 101, 114)
    '        End If
    '    Else
    '        If rowID <> -1 Then
    '            DataGridView1.Rows.RemoveAt(rowID)
    '        End If
    '    End If

    '    DataGridView1.ClearSelection()

    'End Sub
#End Region

#Region "更新转速"
    Public Delegate Sub UpdateTBMCutterRevCallback()
    Public Sub UpdateTBMCutterRev()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateTBMCutterRevCallback(AddressOf UpdateTBMCutterRev))
            Exit Sub
        End If

        'Dim ts As TimeSpan = AppSettingHelper.Settings.YRotationAngleUpdateDateTime - AppSettingHelper.Settings.OldYRotationAngleUpdateDateTime
        'Dim sec As Integer = ts.TotalSeconds

        With AppSettingHelper.GetInstance
            Label5.Text = $"刀盘状态: {If(.IsTBMCutterTurn, "转动", "静止")}"
        End With

    End Sub
#End Region

    Private Sub ButtonItem5_Click_1(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        HardwareStateHelper.TestMode()
    End Sub

#Region "历史数据"
#Region "显示刀具文件夹列表"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim parentDirectoryInfo As New IO.DirectoryInfo(".\SensorData")
        'Dim childtDirectoryInfoItems = parentDirectoryInfo.GetDirectories()

        With ComboBox1
            .Items.Clear()

            'For Each tmpDirectory In childtDirectoryInfoItems
            '    .Items.Add(tmpDirectory.Name)
            'Next

            For Each item In AppSettingHelper.GetInstance.HardwareItems
                .Items.Add(item.Name)
            Next

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With

    End Sub

    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
    '    Button2_Click(Nothing, Nothing)
    'End Sub
#End Region

#Region "刷新日期"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EndDateTimePicker.MaxDate = Now
        StartDateTimePicker.MaxDate = EndDateTimePicker.Value
    End Sub
#End Region

#Region "显示历史文件列表"
    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    If ComboBox1.Text = "" Then
    '        Exit Sub
    '    End If

    '    With ComboBox2
    '        .Items.Clear()
    '        For Each tmpFileName In IO.Directory.GetFiles($".\SensorData\{ComboBox1.Text}", "*.log")
    '            .Items.Add(IO.Path.GetFileNameWithoutExtension(tmpFileName))
    '        Next
    '        If .Items.Count > 0 Then
    '            .SelectedIndex = 0
    '        End If
    '    End With
    'End Sub
#End Region

#Region "加载数据"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" Then
            Exit Sub
        End If

        Using tmpDialog As New Wangk.Resource.UIWorkDialog With {
            .Text = "加载数据中"
        }

            tmpDialog.Start(Sub(uie As Wangk.Resource.UIWorkEventArgs)
                                With SensorChartArea
                                    .AxisX.Title = $"{uie.Args} {ComboBox3.Text}"
                                    .AxisX.Minimum = StartDateTimePicker.Value.Date.ToOADate
                                    .AxisX.Maximum = EndDateTimePicker.Value.AddDays(1).Date.ToOADate

                                    If ComboBox3.SelectedIndex = 0 Then
                                        .AxisY.Minimum = 18
                                        .AxisY.Maximum = 28
                                    Else
                                        .AxisY.Minimum = Double.NaN
                                        .AxisY.Maximum = Double.NaN
                                    End If

                                End With

                                Dim dtFormat As Globalization.DateTimeFormatInfo = New Globalization.DateTimeFormatInfo With {
                                    .YearMonthPattern = "yyyy/MM/dd"
                                }

                                'For i001 = 0 To SensorSeriesArray.Count - 1
                                SensorSeriesArray(0).Points.Clear()
                                'Next

                                Dim tmpDate As Date = StartDateTimePicker.Value.Date
                                Do

                                    uie.Write($"加载 {uie.Args}_{tmpDate:yyyyMMdd}.log")

                                    Dim filePath = $".\SensorData\{ComboBox1.Text}\{uie.Args}_{tmpDate:yyyyMMdd}.log"
                                    tmpDate = tmpDate.AddDays(1)

                                    If Not IO.File.Exists(filePath) Then
                                        Continue Do
                                    End If

                                    Using tmpSR As IO.StreamReader = New IO.StreamReader(filePath)
                                        Do
                                            Dim tmpStr = tmpSR.ReadLine()
                                            If tmpStr Is Nothing Then
                                                Exit Do
                                            End If

                                            Dim tmpStrArray() = tmpStr.Split(">")
                                            Dim tmpStrArray2() = tmpStrArray(1).Split(" ")

                                            Dim tmpDateTime = Convert.ToDateTime(tmpStrArray(0),
                                                                             dtFormat)

                                            Dim pointValue As Double
                                            If ComboBox3.SelectedIndex < 19 Then
                                                '电压/传感器1/传感器2
                                                pointValue = Val(tmpStrArray2.ElementAtOrDefault(1 + ComboBox3.SelectedIndex))
                                            Else
                                                '传感器3/传感器4
                                                pointValue = Val(tmpStrArray2.ElementAtOrDefault(1 + ComboBox3.SelectedIndex + 2))
                                                ''传感器数值
                                                'If String.IsNullOrWhiteSpace(tmpStrArray2.ElementAtOrDefault(1 + 9 + 9 + 2 + 1)) Then
                                                '    '普通刀
                                                '    pointValue = Val(tmpStrArray2.ElementAtOrDefault(1 + ComboBox3.SelectedIndex))
                                                'Else
                                                '    '齿刀
                                                '    pointValue = Val(tmpStrArray2.ElementAtOrDefault(1 + 9 + 9 + 2 + ComboBox3.SelectedIndex))
                                                'End If
                                            End If

                                            If CheckBox1.Checked AndAlso pointValue <= 0 Then
                                                Continue Do
                                            End If

                                            SensorSeriesArray(0).Points.AddXY(tmpDateTime, pointValue)

                                        Loop

                                    End Using

                                Loop While tmpDate <= EndDateTimePicker.Value.Date

                            End Sub,
                            ComboBox1.Text)

        End Using

    End Sub

#Region "获取文件行数"
    ''' <summary>
    ''' 获取文件行数
    ''' </summary>
    Private Function GetFileRowCount(path As String) As Integer
        Dim rowCount = 0

        Using reader As New StreamReader(path, Encoding.UTF8)
            Do While reader.ReadLine IsNot Nothing
                rowCount += 1
            Loop
        End Using

        Return rowCount
    End Function


#End Region

#End Region
#End Region

#Region "传感器阈值"
    Private Sub ButtonItem7_Click(sender As Object, e As EventArgs) Handles ButtonItem7.Click
        Using tmpDialog As New SensorthresholdValueForm
            If tmpDialog.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            AppSettingHelper.SaveToLocaltion()
        End Using
    End Sub

    Private Sub EndDateTimePicker_ValueChanged(sender As Object, e As EventArgs) Handles EndDateTimePicker.ValueChanged
        StartDateTimePicker.MaxDate = EndDateTimePicker.Value
    End Sub

    'Private Sub Chart1_AxisViewChanged(sender As Object, e As ViewEventArgs) Handles Chart1.AxisViewChanged
    '    Try
    '        Dim tmpDateTime = DateTime.FromOADate(SensorChartArea.AxisX.ScaleView.Size)
    '        Dim isValueShown = tmpDateTime.Year = 1899 AndAlso
    '            tmpDateTime.Month = 12 AndAlso
    '            tmpDateTime.Day = 30 AndAlso
    '            tmpDateTime.Hour <= 5

    '        For i001 = 0 To 3 - 1
    '            SensorSeriesArray(i001).IsValueShownAsLabel = isValueShown
    '        Next
    '    Catch ex As Exception
    '    End Try

    'End Sub

#End Region

    Private Sub TabControl2_TabItemClose(sender As Object, e As TabStripActionEventArgs) Handles TabControl2.TabItemClose
        e.Cancel = True

        TabControl2.Tabs.Remove(e.TabItem)
        TabControl2.SelectedTabIndex = 0
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(sender As Object, e As EventArgs)
        'DataGridView1.ClearSelection()
    End Sub

#Region "加载刀盘状态"
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Using tmpDialog As New Wangk.Resource.UIWorkDialog With {
            .Text = "加载数据中"
        }

            tmpDialog.Start(Sub(uie As Wangk.Resource.UIWorkEventArgs)
                                With SensorChartArea
                                    .AxisX.Title = $"刀盘状态 0停止 1转动"
                                    .AxisX.Minimum = StartDateTimePicker.Value.Date.ToOADate
                                    .AxisX.Maximum = EndDateTimePicker.Value.AddDays(1).Date.ToOADate

                                    .AxisY.Minimum = Double.NaN
                                    .AxisY.Maximum = Double.NaN

                                End With

                                Dim dtFormat As Globalization.DateTimeFormatInfo = New Globalization.DateTimeFormatInfo With {
                                    .YearMonthPattern = "yyyy/MM/dd"
                                }

                                'For i001 = 0 To SensorSeriesArray.Count - 1
                                SensorSeriesArray(0).Points.Clear()
                                'Next

                                Dim tmpDate As Date = StartDateTimePicker.Value.Date
                                Do

                                    uie.Write($"加载 IsTBMCutterTurn_{tmpDate:yyyyMMdd}.log")

                                    Dim filePath = $".\SensorData\IsTBMCutterTurn\IsTBMCutterTurn_{tmpDate:yyyyMMdd}.log"
                                    tmpDate = tmpDate.AddDays(1)

                                    If Not IO.File.Exists(filePath) Then
                                        Continue Do
                                    End If

                                    Using tmpSR As IO.StreamReader = New IO.StreamReader(filePath)
                                        Do
                                            Dim tmpStr = tmpSR.ReadLine()
                                            If tmpStr Is Nothing Then
                                                Exit Do
                                            End If

                                            Dim tmpStrArray() = tmpStr.Split(">")
                                            Dim tmpStrArray2() = tmpStrArray(1).Split(" ")

                                            Dim tmpDateTime = Convert.ToDateTime(tmpStrArray(0),
                                                                             dtFormat)

                                            Dim pointValue = Val(tmpStrArray2(1))

                                            SensorSeriesArray(0).Points.AddXY(tmpDateTime, pointValue)

                                        Loop

                                    End Using

                                Loop While tmpDate <= EndDateTimePicker.Value.Date

                            End Sub)

        End Using
    End Sub

#End Region

#Region "数据上传设置"
    Private Sub ButtonItem8_Click(sender As Object, e As EventArgs) Handles ButtonItem8.Click
        Using tmpDialog As New UploadSettingForm
            If tmpDialog.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            AppSettingHelper.SaveToLocaltion()
        End Using
    End Sub
#End Region

End Class