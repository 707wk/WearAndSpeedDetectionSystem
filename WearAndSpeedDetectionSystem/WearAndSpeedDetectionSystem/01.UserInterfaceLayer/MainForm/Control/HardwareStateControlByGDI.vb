Public Class HardwareStateControlByGDI
    Inherits Panel

    ''' <summary>
    ''' 设备信息
    ''' </summary>
    Public HardwareInfo As HardwareInfo

    Private Shared ReadOnly StrSolidBrush As New SolidBrush(Color.FromArgb(215, 215, 215))
    Private Shared ReadOnly StrWarningSolidBrush As New SolidBrush(Color.FromArgb(246, 86, 98))
    Private Shared ReadOnly StrStringFormat As New StringFormat()
    Private Shared ReadOnly StrValueStringFormat As New StringFormat()
    Private Shared ReadOnly BaseLinePen As New Pen(Color.FromArgb(123, 123, 123), 1)
    'Private Shared ReadOnly BaseLineWarningPen As New Pen(Color.FromArgb(246, 86, 98), 1)
    Private Shared ReadOnly TableTitle() As String = {"磨损 mm", "温度 °C", "转速 r/s"} ', "频点1", "频点1值", "频点2", "频点2值", "频点3", "频点3值"}
    Private TmpPoint As New Point

    Public Sub New()
        Me.Size = New Size(385, 66)
        Me.BackColor = Color.FromArgb(71, 71, 71)
        Me.Font = New Font("微软雅黑", 9)
        Me.DoubleBuffered = True
        Me.BackgroundImage = My.Resources.sensor_48px
        Me.BackgroundImageLayout = ImageLayout.None
        StrStringFormat.Alignment = StringAlignment.Far
        StrValueStringFormat.Alignment = StringAlignment.Center
    End Sub

    Private Sub HardwareStateControl_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        'e.Graphics.DrawImage(My.Resources.sensor_48px, 1, 1)

        With TmpPoint
            .X = 110
            .Y = 6
            e.Graphics.DrawString("刀具编号:", Me.Font, StrSolidBrush, TmpPoint, StrStringFormat)
            e.Graphics.DrawString(HardwareInfo.Name, Me.Font, StrSolidBrush, TmpPoint)
            .X = 110
            .Y = 25
            e.Graphics.DrawString("设备ID:", Me.Font, StrSolidBrush, TmpPoint, StrStringFormat)
            e.Graphics.DrawString(HardwareInfo.ID, Me.Font, StrSolidBrush, TmpPoint)
            .X = 110
            .Y = 44
            e.Graphics.DrawString("电压:", Me.Font, StrSolidBrush, TmpPoint, StrStringFormat)
            e.Graphics.DrawString($"{Math.Round(HardwareInfo.Voltage, 2)}V", Me.Font, StrSolidBrush, TmpPoint)

            For i001 = 0 To TableTitle.Count - 1
                .X = 165 + 58 + 55 * i001
                .Y = 6
                e.Graphics.DrawString(TableTitle(i001), Me.Font, StrSolidBrush, TmpPoint)
            Next

            For sensorID = 0 To 2 - 1
                .Y = 25 + sensorID * 19

                .X = 165
                e.Graphics.DrawString($"传感器{sensorID + 1}", Me.Font, StrSolidBrush, TmpPoint)
                '磨损
                '.X += 30
                .X += 55 + 16
                'e.Graphics.FillRectangle(StrWarningSolidBrush, .X - 25, .Y + 1, 53, 19 - 2)
                If HardwareInfo.SensorItems(sensorID, 0) <= AppSettingHelper.Settings.WearMaximum Then
                    e.Graphics.DrawString(Math.Round(HardwareInfo.SensorItems(sensorID, 0) / 10, 1), Me.Font, StrSolidBrush, TmpPoint)
                    'e.Graphics.DrawString("100", Me.Font, StrSolidBrush, TmpPoint)
                Else
                    e.Graphics.DrawImage(My.Resources.warning_16px, .X - 16, .Y)
                    e.Graphics.DrawString(Math.Round(HardwareInfo.SensorItems(sensorID, 0) / 10, 1), Me.Font, StrWarningSolidBrush, TmpPoint)
                End If

                '温度
                .X += 55
                'e.Graphics.FillRectangle(StrWarningSolidBrush, .X - 25, .Y + 1, 53, 19 - 2)
                If HardwareInfo.SensorItems(sensorID, 1) <= AppSettingHelper.Settings.TempMaximum Then
                    e.Graphics.DrawString(Math.Round(HardwareInfo.SensorItems(sensorID, 1) / 10, 1), Me.Font, StrSolidBrush, TmpPoint, StrValueStringFormat)
                    'e.Graphics.DrawString("100", Me.Font, StrSolidBrush, TmpPoint)
                Else
                    e.Graphics.DrawImage(My.Resources.warning_16px, .X - 16, .Y)
                    e.Graphics.DrawString(Math.Round(HardwareInfo.SensorItems(sensorID, 1) / 10, 1), Me.Font, StrWarningSolidBrush, TmpPoint)
                End If

                '转速
                .X += 55
                'e.Graphics.FillRectangle(StrWarningSolidBrush, .X - 25, .Y + 1, 53, 19 - 2)
                If HardwareInfo.SensorItems(sensorID, 2) <= AppSettingHelper.Settings.SpeedMaximum Then
                    e.Graphics.DrawString(Math.Round(HardwareInfo.SensorItems(sensorID, 2) / 10, 1), Me.Font, StrSolidBrush, TmpPoint, StrValueStringFormat)
                    'e.Graphics.DrawString("100", Me.Font, StrSolidBrush, TmpPoint)
                Else
                    e.Graphics.DrawImage(My.Resources.warning_16px, .X - 16, .Y)
                    e.Graphics.DrawString(Math.Round(HardwareInfo.SensorItems(sensorID, 2) / 10, 1), Me.Font, StrWarningSolidBrush, TmpPoint)
                End If

                ''频点1
                '.X = 165 + 55 * 4
                'e.Graphics.DrawString(HardwareInfo.SensorItems(sensorID, 3), Me.Font, StrSolidBrush, TmpPoint)
                '.X = 165 + 55 * 5
                'e.Graphics.DrawString(HardwareInfo.SensorItems(sensorID, 4), Me.Font, StrSolidBrush, TmpPoint)
                ''频点2
                '.X = 165 + 55 * 6
                'e.Graphics.DrawString(HardwareInfo.SensorItems(sensorID, 5), Me.Font, StrSolidBrush, TmpPoint)
                '.X = 165 + 55 * 7
                'e.Graphics.DrawString(HardwareInfo.SensorItems(sensorID, 6), Me.Font, StrSolidBrush, TmpPoint)
                ''频点3
                '.X = 165 + 55 * 8
                'e.Graphics.DrawString(HardwareInfo.SensorItems(sensorID, 7), Me.Font, StrSolidBrush, TmpPoint)
                '.X = 165 + 55 * 9
                'e.Graphics.DrawString(HardwareInfo.SensorItems(sensorID, 8), Me.Font, StrSolidBrush, TmpPoint)
            Next
        End With

        e.Graphics.DrawLine(BaseLinePen, 0, Me.Height - 1, Me.Width, Me.Height - 1)
    End Sub

#Region "是否在读取数据"
    Public Delegate Sub IsReadDataCallback(value As Boolean)
    Public Sub IsReadData(value As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New IsReadDataCallback(AddressOf IsReadData), value)
            Exit Sub
        End If

        Try
            Me.BackgroundImage = If(value, My.Resources.sensor1_48px, My.Resources.sensor_48px)
        Catch ex As Exception
        End Try

    End Sub
#End Region

#Region "是否在读取数据"
    Public Delegate Sub IsOnLineCallback(value As Boolean)
    Public Sub IsOnLine(value As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New IsOnLineCallback(AddressOf IsOnLine), value)
            Exit Sub
        End If

        Try
            Me.BackgroundImage = If(value, My.Resources.sensor_48px, My.Resources.sensor2_48px)
        Catch ex As Exception
        End Try

    End Sub
#End Region

#Region "更新显示数据"
    Public Delegate Sub UpdateDataCallback()
    Public Sub UpdateData()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateDataCallback(AddressOf UpdateData))
            Exit Sub
        End If

        Try
            Me.Refresh()
        Catch ex As Exception
        End Try

    End Sub
#End Region

End Class
