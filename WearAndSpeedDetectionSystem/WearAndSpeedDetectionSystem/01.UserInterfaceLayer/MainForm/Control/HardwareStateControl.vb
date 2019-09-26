Public Class HardwareStateControl
    ''' <summary>
    ''' 设备信息
    ''' </summary>
    Public HardwareInfo As HardwareInfo

    Private ShowBitmap As Bitmap

    Private Sub HardwareStateControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.DoubleBuffered = True

        '创建列表
        For itemID = 0 To 2 - 1
            Dim tmpListViewItem As New ListViewItem($"{itemID + 1}")

            For subItemID = 0 To 9 - 1
                tmpListViewItem.SubItems.Add("0")
            Next

            ListView1.Items.Add(tmpListViewItem)
        Next

        '创建显示缓存
        ShowBitmap = New Bitmap(ListView1.Width, ListView1.Height)

        Label4.Text = HardwareInfo.Name
        Label5.Text = HardwareInfo.ID

        UpdateData()

    End Sub

#Region "更新显示数据"
    Public Delegate Sub UpdateDataCallback()
    Public Sub UpdateData()
        If Me.InvokeRequired Then
            Me.Invoke(New UpdateDataCallback(AddressOf UpdateData))
            Exit Sub
        End If

        '电压值
        Label7.Text = $"{Math.Round(HardwareInfo.Voltage, 2)}V"

        For sensorID = 0 To 2 - 1
            '磨损
            ListView1.Items(sensorID).SubItems(1).Text = Math.Round(HardwareInfo.SensorItems(sensorID, 0) / 10, 1)
            '温度
            ListView1.Items(sensorID).SubItems(2).Text = Math.Round(HardwareInfo.SensorItems(sensorID, 1) / 10, 1)
            '转速
            ListView1.Items(sensorID).SubItems(3).Text = Math.Round(HardwareInfo.SensorItems(sensorID, 2) / 10, 1)

            '频点1
            ListView1.Items(sensorID).SubItems(4).Text = HardwareInfo.SensorItems(sensorID, 3)
            ListView1.Items(sensorID).SubItems(5).Text = HardwareInfo.SensorItems(sensorID, 4)

            '频点2
            ListView1.Items(sensorID).SubItems(6).Text = HardwareInfo.SensorItems(sensorID, 5)
            ListView1.Items(sensorID).SubItems(7).Text = HardwareInfo.SensorItems(sensorID, 6)

            '频点3
            ListView1.Items(sensorID).SubItems(8).Text = HardwareInfo.SensorItems(sensorID, 7)
            ListView1.Items(sensorID).SubItems(9).Text = HardwareInfo.SensorItems(sensorID, 8)

        Next

        ListView1.DrawToBitmap(ShowBitmap, New Rectangle(0, 0, ShowBitmap.Width, ShowBitmap.Height))
        Panel1.BackgroundImage = ShowBitmap
        Panel1.Refresh()

    End Sub
#End Region

End Class
