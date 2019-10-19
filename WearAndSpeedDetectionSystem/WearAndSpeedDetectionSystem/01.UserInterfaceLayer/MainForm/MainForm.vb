Imports System.ComponentModel
Imports System.IO
Imports System.Text

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

#Region "功能区"
        '串口号
        With ComboBoxItem1
            .Items.AddRange(IO.Ports.SerialPort.GetPortNames())

            If .Items.Contains(AppSettingHelper.Settings.SerialPort) Then
                .Text = AppSettingHelper.Settings.SerialPort
            ElseIf .Items.Count > 0 Then
                .SelectedIndex = 0
            End If

        End With

        '波特率
        With ComboBoxItem2
            .Items.AddRange({"9600bps", "19200bps", "115200bps"})

            If .Items.Contains(AppSettingHelper.Settings.BPS) Then
                .Text = AppSettingHelper.Settings.BPS
            Else
                .SelectedIndex = 0
            End If
        End With

        '设备轮询间隔
        With ComboBoxItem4
            For sec = 0 To 60 * 30
                .Items.Add($"{sec}s")
            Next

            If .Items.Contains($"{AppSettingHelper.Settings.pollingInterval}s") Then
                .Text = $"{AppSettingHelper.Settings.pollingInterval}s"
            Else
                .SelectedIndex = 20 - 1
            End If
        End With
#End Region

#Region "历史数据"
        '刀具编号
        With ComboBox1
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        '历史文件
        With ComboBox2
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With

        '历史数据参数类型
        With ComboBox3
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Items.AddRange({"模块电压",
                            "磨损",
                            "温度",
                            "转速",
                            "频点1",
                            "频点1值",
                            "频点2",
                            "频点2值",
                            "频点3",
                            "频点3值"})
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
            .AxisX.LabelStyle.Format = "HH:mm:ss"
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

        For i001 = 0 To 3 - 1
            SensorSeriesArray(i001) = New DataVisualization.Charting.Series
            With SensorSeriesArray(i001)
                .ChartArea = SensorChartArea.Name
                .ChartType = DataVisualization.Charting.SeriesChartType.FastLine
                .XValueType = DataVisualization.Charting.ChartValueType.DateTime
            End With
            Chart1.Series.Add(SensorSeriesArray(i001))

        Next

        With SensorSeriesArray(0)
            .Color = Color.OrangeRed
            .LegendText = "设备电压"
            .BorderWidth = 3
        End With
        With SensorSeriesArray(1)
            .Color = Color.LightGreen
            .LegendText = "1号传感器"
            .BorderWidth = 3
        End With
        With SensorSeriesArray(2)
            .Color = Color.DodgerBlue
            .LegendText = "2号传感器"
            .BorderWidth = 3
        End With

        System.IO.Directory.CreateDirectory($"SensorData")
        Button1_Click(Nothing, Nothing)

#End Region

#Region "隐藏历史模块"
        'TabControl2.Tabs.Remove(TabItem3)
        TabControl2.Tabs.Remove(TabItem4)
        TabControl2.SelectedTabIndex = 0
#End Region

        '更新时间
        Timer1.Interval = 1000
        Timer1.Start()
        Timer1_Tick(Nothing, Nothing)

        CreateHardwareStateControl()

        LinkControlState(False)

        ButtonItem2.Enabled = If(AppSettingHelper.Settings.HardwareItems.Count = 0, False, True)

        HardwareStateHelper.UIMainForm = Me

        CreateOverviewBackground()

        'AllocConsole()
        'Me.Width = 1600

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
        ComboBoxItem2.Enabled = Not value
        ComboBoxItem4.Enabled = Not value
        ButtonItem2.Enabled = Not value
        ButtonItem3.Enabled = value
        ButtonItem5.Enabled = value
        ButtonItem4.Enabled = Not value

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
        LabelItem6.Text = Now().ToString("yyyy/MM/dd HH:mm:ss")
    End Sub

#Region "创建硬件信息控件"
    ''' <summary>
    ''' 创建硬件信息控件
    ''' </summary>
    Private Sub CreateHardwareStateControl()

        FlowLayoutPanel1.Controls.Clear()

        For Each tmpHardware In AppSettingHelper.Settings.HardwareItems
            tmpHardware.HardwareStateControl = New HardwareStateControlByGDI With {
                .HardwareInfo = tmpHardware
            }

            FlowLayoutPanel1.Controls.Add(tmpHardware.HardwareStateControl)
            tmpHardware.HardwareStateControl.Show()
        Next
        'AppSettingHelper.Settings.HardwareItems(10).HardwareStateControl.IsReadData(True)
        'AppSettingHelper.Settings.HardwareItems(11).HardwareStateControl.IsReadData(False)
    End Sub
#End Region

#Region "创建硬件概览背景图片"
    ''' <summary>
    ''' 创建硬件概览背景图片
    ''' </summary>
    Private Sub CreateOverviewBackground()
        If Not IO.File.Exists(AppSetting.OverviewBackgroundLocation) Then
            Exit Sub
        End If

        Background = Bitmap.FromFile(AppSetting.OverviewBackgroundLocation)
        BackgroundGraphics = Graphics.FromImage(Background)

#Region "画笔及画刷"
        Dim boxPen As New Pen(Color.FromArgb(118, 118, 118), 1)
        Dim backgroundColorSolidBrush As New SolidBrush(Color.LimeGreen)
        Dim backgroundColorSolidBrush2 As New SolidBrush(Color.FromArgb(255, 127, 127))
        'Dim backgroundColorSolidBrush2 As New SolidBrush(Color.OrangeRed)
        Dim fontSolidBrush As New SolidBrush(Color.Black)
        Dim tmpRectangle As Rectangle
        With tmpRectangle
            .Width = 50
            .Height = 28
        End With
#End Region

        For Each tmpHardware In AppSettingHelper.Settings.HardwareItems
            With tmpRectangle
                .Location = tmpHardware.Location
            End With

            '填充底色
            If tmpHardware.SensorItems(0, 2) > 0 Then
                BackgroundGraphics.FillRectangle(backgroundColorSolidBrush, tmpRectangle)
            Else
                BackgroundGraphics.FillRectangle(backgroundColorSolidBrush2, tmpRectangle)
            End If

            'If AppSettingHelper.Settings.HardwareItems.IndexOf(tmpHardware) Mod 2 Then
            '    BackgroundGraphics.FillRectangle(backgroundColorSolidBrush, tmpRectangle)
            'Else
            '    BackgroundGraphics.FillRectangle(backgroundColorSolidBrush2, tmpRectangle)
            'End If

            '绘制箱体边框
            BackgroundGraphics.DrawRectangle(boxPen, tmpRectangle)
            '绘制连接信息
            BackgroundGraphics.DrawString($"{Math.Round(tmpHardware.Voltage, 2)}V
{Math.Round(tmpHardware.SensorItems(0, 0) / 10, 1)}mm",
                                  Me.Font,
                                  fontSolidBrush,
                                  tmpHardware.Location.X + 1,
                                  tmpHardware.Location.Y + 1)
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

            HardwareStateHelper.StartAsync(ComboBoxItem1.Text, Val(ComboBoxItem2.Text))

            AppSettingHelper.Settings.SerialPort = ComboBoxItem1.Text
            AppSettingHelper.Settings.BPS = ComboBoxItem2.Text
            AppSettingHelper.Settings.pollingInterval = Val(ComboBoxItem4.Text)

            AppSettingHelper.SaveToLocaltion()

            LinkControlState(True)

            Me.Log($"连接串口 {ComboBoxItem1.Text}({ComboBoxItem2.Text})")

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
            .ProgressBarStyle = ProgressBarStyle.Marquee
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
            CreateOverviewBackground()

            CreateHardwareStateControl()

            ButtonItem2.Enabled = (AppSettingHelper.Settings.HardwareItems.Count > 0)

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
                TabControl2.Tabs.Add(TabItem4)

                ButtonItem6.Enabled = False

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
        TextBox1.AppendText($"{Now().ToString("yyyy/MM/dd HH:mm:ss")}> {text}{vbCrLf}")

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
        Dim boxPen As New Pen(Color.FromArgb(118, 118, 118), 1)
        Dim backgroundColorSolidBrush As New SolidBrush(Color.LimeGreen)
        Dim backgroundColorSolidBrush2 As New SolidBrush(Color.FromArgb(255, 127, 127))
        Dim fontSolidBrush As New SolidBrush(Color.Black)
        Dim tmpRectangle As Rectangle
        With tmpRectangle
            .Width = 50
            .Height = 28
            .Location = value.Location
        End With
#End Region

        '填充底色
        If value.SensorItems(0, 2) > 0 Then
            BackgroundGraphics.FillRectangle(backgroundColorSolidBrush, tmpRectangle)
        Else
            BackgroundGraphics.FillRectangle(backgroundColorSolidBrush2, tmpRectangle)
        End If

        '绘制箱体边框
        BackgroundGraphics.DrawRectangle(boxPen, tmpRectangle)
        '绘制连接信息
        BackgroundGraphics.DrawString($"{Math.Round(value.Voltage, 2)}V
{Math.Round(value.SensorItems(0, 0) / 10, 1)}mm",
                                  Me.Font,
                                  fontSolidBrush,
                                  value.Location.X + 1,
                                  value.Location.Y + 1)

        PictureBox1.Image = Background

    End Sub
#End Region

    Private Sub ButtonItem5_Click_1(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        HardwareStateHelper.TestMode()
    End Sub

#Region "历史数据"
#Region "显示刀具文件夹列表"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim parentDirectoryInfo As New IO.DirectoryInfo("SensorData")
        Dim childtDirectoryInfoItems = parentDirectoryInfo.GetDirectories()

        With ComboBox1
            .Items.Clear()
            For Each tmpDirectory In childtDirectoryInfoItems
                .Items.Add(tmpDirectory.Name)
            Next
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Button2_Click(Nothing, Nothing)
    End Sub
#End Region

#Region "显示历史文件列表"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            Exit Sub
        End If

        With ComboBox2
            .Items.Clear()
            For Each tmpFileName In IO.Directory.GetFiles($"SensorData\{ComboBox1.Text}", "*.log")
                .Items.Add(IO.Path.GetFileNameWithoutExtension(tmpFileName))
            Next
            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
    End Sub
#End Region

#Region "加载数据"
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox1.Text = "" OrElse
            ComboBox2.Text = "" Then
            Exit Sub
        End If

        Using tmpDialog As New Wangk.Resource.UIWorkDialog With {
            .Text = "加载数据中"
        }

            tmpDialog.Start(Sub(uie As Wangk.Resource.UIWorkEventArgs)
                                With SensorChartArea
                                    .AxisX.Title = $"{ComboBox1.Text} {ComboBox2.Text} {ComboBox3.Text}"
                                End With

                                Dim dtFormat As Globalization.DateTimeFormatInfo = New Globalization.DateTimeFormatInfo
                                dtFormat.YearMonthPattern = "yyyy/MM/dd"

                                For i001 = 0 To SensorSeriesArray.Count - 1
                                    SensorSeriesArray(i001).Points.Clear()
                                Next

                                Dim filePath = $"SensorData\{ComboBox1.Text}\{ComboBox2.Text}.log"

                                Dim fileRowCount = GetFileRowCount(filePath)

                                Using tmpSR As IO.StreamReader = New IO.StreamReader(filePath)
                                    Dim IsSetDate As Boolean = False

                                    Dim fileRowID As Integer = 0
                                    Do
                                        Dim tmpStr = tmpSR.ReadLine()
                                        If tmpStr Is Nothing Then
                                            Exit Do
                                        End If

                                        fileRowID += 1
                                        If (fileRowID * 1000 \ fileRowCount) Mod 10 = 0 Then
                                            uie.Write($"加载进度{fileRowID * 100 \ fileRowCount}%")
                                        End If

                                        Dim tmpStrArray() = tmpStr.Split(">")
                                        Dim tmpStrArray2() = tmpStrArray(1).Split(" ")

                                        Dim tmpDateTime = Convert.ToDateTime(tmpStrArray(0),
                                                                             dtFormat)

                                        If ComboBox3.SelectedIndex = 0 Then

                                            SensorSeriesArray(0).Points.AddXY(tmpDateTime, Val(tmpStrArray2(1)))
                                        Else
                                            SensorSeriesArray(1).Points.AddXY(tmpDateTime, Val(tmpStrArray2(1 + ComboBox3.SelectedIndex)))

                                            SensorSeriesArray(2).Points.AddXY(tmpDateTime, Val(tmpStrArray2(1 + ComboBox3.SelectedIndex + 9)))
                                        End If

                                        If Not IsSetDate Then
                                            IsSetDate = True
                                            With SensorChartArea
                                                .AxisX.Minimum = tmpDateTime.Date.ToOADate
                                                .AxisX.Maximum = tmpDateTime.AddDays(1).Date.ToOADate
                                            End With
                                        End If

                                    Loop

                                End Using
                            End Sub,
                            Nothing)

        End Using

        'With SensorChartArea
        '    .AxisX.Title = $"{ComboBox1.Text} {ComboBox2.Text} {ComboBox3.Text}"
        'End With

        'Dim dtFormat As Globalization.DateTimeFormatInfo = New Globalization.DateTimeFormatInfo
        'dtFormat.YearMonthPattern = "yyyy/MM/dd"

        'For i001 = 0 To SensorSeriesArray.Count - 1
        '    SensorSeriesArray(i001).Points.Clear()
        'Next

        'Using tmpSR As IO.StreamReader = New IO.StreamReader($"SensorData\{ComboBox1.Text}\{ComboBox2.Text}.log")
        '    Dim IsSetDate As Boolean = False

        '    Do
        '        Dim tmpStr = tmpSR.ReadLine()
        '        If tmpStr Is Nothing Then
        '            Exit Do
        '        End If

        '        Dim tmpStrArray() = tmpStr.Split(">")
        '        Dim tmpStrArray2() = tmpStrArray(1).Split(" ")

        '        Dim tmpDateTime = Convert.ToDateTime(tmpStrArray(0),
        '                                             dtFormat)

        '        If ComboBox3.SelectedIndex = 0 Then

        '            SensorSeriesArray(0).Points.AddXY(tmpDateTime, Val(tmpStrArray2(1)))
        '        Else
        '            SensorSeriesArray(1).Points.AddXY(tmpDateTime, Val(tmpStrArray2(1 + ComboBox3.SelectedIndex)))

        '            SensorSeriesArray(2).Points.AddXY(tmpDateTime, Val(tmpStrArray2(1 + ComboBox3.SelectedIndex + 9)))
        '        End If

        '        If Not IsSetDate Then
        '            IsSetDate = True
        '            With SensorChartArea
        '                .AxisX.Minimum = tmpDateTime.Date.ToOADate
        '                .AxisX.Maximum = tmpDateTime.AddDays(1).Date.ToOADate
        '            End With
        '        End If

        '    Loop

        'End Using
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
End Class