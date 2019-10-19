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
            Dim tmpListViewItem As New ListViewItem($"{itemID + 1}") With {
                .UseItemStyleForSubItems = False
            }

            For subItemID = 0 To 9 - 1
                tmpListViewItem.SubItems.Add("0")
            Next

            ListView1.Items.Add(tmpListViewItem)
        Next

        '创建显示缓存
        ShowBitmap = New Bitmap(ListView1.Width, ListView1.Height)

        Label4.Text = HardwareInfo.Name
        Label5.Text = HardwareInfo.ID
        ListView1.ForeColor = Me.ForeColor
        ListViewEx1.ForeColor = Me.ForeColor

        UpdateData()

    End Sub

#Region "是否在读取数据"
    Public Delegate Sub IsReadDataCallback(value As Boolean)
    Public Sub IsReadData(value As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New IsReadDataCallback(AddressOf IsReadData), value)
            Exit Sub
        End If

        Try
            Label3.Image = If(value, My.Resources.sensor1_48px, My.Resources.sensor_48px)

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
            '电压值
            Label7.Text = $"{Math.Round(HardwareInfo.Voltage, 2)}V"

            With ListView1
                For sensorID = 0 To 2 - 1

                    '磨损
                    .Items(sensorID).SubItems(1).Text = Math.Round(HardwareInfo.SensorItems(sensorID, 0) / 10, 1)
                    '温度
                    .Items(sensorID).SubItems(2).Text = Math.Round(HardwareInfo.SensorItems(sensorID, 1) / 10, 1)
                    '转速
                    .Items(sensorID).SubItems(3).Text = Math.Round(HardwareInfo.SensorItems(sensorID, 2) / 10, 1)

                    '频点1
                    .Items(sensorID).SubItems(4).Text = HardwareInfo.SensorItems(sensorID, 3)
                    .Items(sensorID).SubItems(5).Text = HardwareInfo.SensorItems(sensorID, 4)

                    '频点2
                    .Items(sensorID).SubItems(6).Text = HardwareInfo.SensorItems(sensorID, 5)
                    .Items(sensorID).SubItems(7).Text = HardwareInfo.SensorItems(sensorID, 6)

                    '频点3
                    .Items(sensorID).SubItems(8).Text = HardwareInfo.SensorItems(sensorID, 7)
                    .Items(sensorID).SubItems(9).Text = HardwareInfo.SensorItems(sensorID, 8)

                Next

                .DrawToBitmap(ShowBitmap, New Rectangle(0, 0, ShowBitmap.Width, ShowBitmap.Height))
            End With

            PictureBox1.Image = ShowBitmap
            PictureBox1.Refresh()
        Catch ex As Exception

        End Try

    End Sub
#End Region

End Class
