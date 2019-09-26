Imports System.ComponentModel

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Region "产品版本号"
        Dim assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim versionStr = System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductVersion
        Me.Text = $"{My.Application.Info.Title} V{versionStr}"
#End Region

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

        '更新时间
        Timer1.Interval = 1000
        Timer1.Start()
        Timer1_Tick(Nothing, Nothing)

        CreateHardwareStateControl()

        LinkControlState(False)

        ButtonItem2.Enabled = If(AppSettingHelper.Settings.HardwareItems.Count = 0, False, True)

        HardwareStateHelper.UIMainForm = Me

    End Sub

    Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not ButtonItem2.Enabled Then
            e.Cancel = True
        End If
    End Sub

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
        RibbonBar2.Enabled = Not value

    End Sub

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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel1.Text = Now().ToString("yyyy/MM/dd HH:mm:ss")
    End Sub

    ''' <summary>
    ''' 创建硬件信息控件
    ''' </summary>
    Private Sub CreateHardwareStateControl()

        FlowLayoutPanel1.Controls.Clear()

        For Each tmpHardware In AppSettingHelper.Settings.HardwareItems
            tmpHardware.HardwareStateControl = New HardwareStateControl With {
                .HardwareInfo = tmpHardware
            }

            FlowLayoutPanel1.Controls.Add(tmpHardware.HardwareStateControl)
            tmpHardware.HardwareStateControl.Show()

        Next

    End Sub

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
            .Text = "等待停止",
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
        Using tmpDialog As New EditHardwareItemsForm
            If tmpDialog.ShowDialog <> DialogResult.OK Then
                Exit Sub
            End If

            CreateHardwareStateControl()

            ButtonItem2.Enabled = If(AppSettingHelper.Settings.HardwareItems.Count = 0, False, True)

            AppSettingHelper.SaveToLocaltion()

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

    Private Sub ButtonItem5_Click_1(sender As Object, e As EventArgs) Handles ButtonItem5.Click
        HardwareStateHelper.TestMode()
    End Sub

End Class