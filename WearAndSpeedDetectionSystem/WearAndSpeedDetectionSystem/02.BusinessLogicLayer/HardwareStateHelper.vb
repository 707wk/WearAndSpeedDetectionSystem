''' <summary>
''' 硬件状态辅助类
''' </summary>
Public NotInheritable Class HardwareStateHelper
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 串口变量
    ''' </summary>
    Private Shared SP As IO.Ports.SerialPort

    ''' <summary>
    ''' 数据处理线程
    ''' </summary>
    Private Shared WorkThread As Threading.Thread

    ''' <summary>
    ''' 是否运行
    ''' </summary>
    Private Shared _IsRunning As Boolean = False

    ''' <summary>
    ''' 是否运行
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property IsRunning As Boolean
        Get
            Return _IsRunning
        End Get
    End Property

    ''' <summary>
    ''' 主窗体
    ''' </summary>
    Public Shared UIMainForm As MainForm

    ''' <summary>
    ''' 是否发送测试指令
    ''' </summary>
    Private Shared IsTestMode As Boolean = False
    Private ReadOnly _Run As Boolean

    ''' <summary>
    ''' 发送测试指令
    ''' </summary>
    Public Shared Sub TestMode()
        IsTestMode = True
    End Sub

#Region "开始检测硬件数据"
    ''' <summary>
    ''' 开始检测硬件数据
    ''' </summary>
    Public Shared Sub StartAsync(SerialPort As String, BPS As Integer)

        If _IsRunning Then
            Exit Sub
        End If
        _IsRunning = True

        SP = New IO.Ports.SerialPort
        With SP
            .PortName = SerialPort
            .BaudRate = BPS
            .Parity = IO.Ports.Parity.None
            .DataBits = 8
            .StopBits = 1
            .ReadTimeout = 1000
            .WriteTimeout = 1000
        End With

        Try
            SP.Open()
        Catch ex As Exception
            Throw ex
            Exit Sub
        End Try

        WorkThread = New Threading.Thread(AddressOf WorkFunction) With {
            .IsBackground = True
        }
        WorkThread.Start()

    End Sub
#End Region

#Region "停止检测硬件数据"
    ''' <summary>
    ''' 停止检测硬件数据
    ''' </summary>
    Public Shared Sub StopAsync()

        If Not _IsRunning Then
            Exit Sub
        End If
        _IsRunning = False

        WorkThread.Join()
        WorkThread = Nothing

        Try
            SP.Close()
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "检测线程"
    ''' <summary>
    ''' 检测线程
    ''' </summary>
    Private Shared Sub WorkFunction()
        Do

            For Each tmpHardware In AppSettingHelper.Settings.HardwareItems

                If Not _IsRunning Then Exit Sub

                '发送测试指令
                If IsTestMode Then
                    IsTestMode = False
                    UIMainForm.Log($"发送测试指令")

                    ReadSensorData()
                    Threading.Thread.Sleep(500)
                End If

                UIMainForm.Log($"检测刀具 {tmpHardware.Name}")
                tmpHardware.HardwareStateControl.IsReadData(True)

                If Not _IsRunning Then Exit Sub

                Try
                    GetSensorDataOf1(tmpHardware)
                    Threading.Thread.Sleep(500)

                    If Not _IsRunning Then Exit Sub

                    GetSensorDataOf2(tmpHardware)
                    Threading.Thread.Sleep(500)

                    If Not _IsRunning Then Exit Sub

                    GetHardwareState(tmpHardware)

                    Dim tmpStr = $"{Math.Round(tmpHardware.Voltage, 2)}"
                    For sensorID = 0 To 2 - 1
                        For itemID = 0 To 9 - 1

                            If itemID = 0 OrElse
                                itemID = 1 OrElse
                                itemID = 2 Then
                                tmpStr &= $" {tmpHardware.SensorItems(sensorID, itemID) / 10}"
                            Else
                                tmpStr &= $" {tmpHardware.SensorItems(sensorID, itemID)}"
                            End If

                        Next
                    Next

                    System.IO.Directory.CreateDirectory($"SensorData")
                    System.IO.Directory.CreateDirectory($"SensorData\{tmpHardware.Name}[{tmpHardware.ID}]")
                    Using tmp As IO.StreamWriter = New IO.StreamWriter($"SensorData\{tmpHardware.Name}[{tmpHardware.ID}]\{tmpHardware.Name}_{Format(Now(), "yyyyMMdd")}.log", True)
                        tmp.WriteLine($"{Now().ToString("yyyy/MM/dd HH:mm:ss")}> {tmpStr}")
                    End Using

                    '更新界面
                    tmpHardware.HardwareStateControl.IsReadData(False)
                    tmpHardware.HardwareStateControl.UpdateData()
                    UIMainForm.UpdateOverviewBackground(tmpHardware)

                Catch ex As Exception
                    UIMainForm.Log(ex.Message)
                    tmpHardware.HardwareStateControl.IsOnLine(False)
                End Try

                '延时查询下一个设备
                For i001 = 0 To AppSettingHelper.Settings.pollingInterval - 1
                    If Not _IsRunning Then Exit Sub

                    Threading.Thread.Sleep(1000)
                Next

            Next
        Loop

    End Sub
#End Region

#Region "立即采集"
    ''' <summary>
    ''' 立即采集
    ''' </summary>
    Private Shared Sub ReadSensorData()
        Try
            Dim sendData() = Wangk.Hash.Hex2Bin("FF100000000204000A00010000")
            Dim recData(128 - 1) As Byte

            '生成检测指令
            Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
            Dim CRCBytes = BitConverter.GetBytes(CRC)
            sendData(sendData.Count - 2) = CRCBytes(0)
            sendData(sendData.Count - 1) = CRCBytes(1)

            '发送检测指令
            SP.Write(sendData, 0, sendData.Count)
            '等待数据返回
            Threading.Thread.Sleep(500)
            Dim count = SP.Read(recData, 0, 128)

        Catch timeOut As TimeoutException

        Catch ex As Exception
            UIMainForm.Log($"立即采集异常:{ex.Message}")
        End Try

    End Sub
#End Region

#Region "采集1号传感器状态"
    ''' <summary>
    ''' 采集1号传感器状态
    ''' </summary>
    Private Shared Sub GetSensorDataOf1(value As HardwareInfo)
        Try
            Dim sendData() = Wangk.Hash.Hex2Bin("0003003500090000")
            Dim recData(128 - 1) As Byte

            '生成检测指令
            sendData(0) = value.ID
            Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
            Dim CRCBytes = BitConverter.GetBytes(CRC)
            sendData(6) = CRCBytes(0)
            sendData(7) = CRCBytes(1)

            '发送检测指令
            SP.Write(sendData, 0, sendData.Count)
            '等待数据返回
            Threading.Thread.Sleep(500)
            Dim count = SP.Read(recData, 0, 128)

            '判断CRC
            CRC = Wangk.Hash.GetCRC16Modbus(recData, 21)
            CRCBytes = BitConverter.GetBytes(CRC)
            If recData(21) <> CRCBytes(0) OrElse
                recData(22) <> CRCBytes(1) Then
                Throw New Exception($"1号传感器数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
            End If

            For byteID = 0 To 9 - 1
                value.SensorItems(0, byteID) = 0 Or recData(3 + byteID * 2)
                value.SensorItems(0, byteID) <<= 8
                value.SensorItems(0, byteID) = value.SensorItems(0, byteID) Or recData(3 + byteID * 2 + 1)
            Next

        Catch timeOut As TimeoutException
            Throw New Exception($"1号传感器 接收数据超时")
        Catch ex As Exception
            Throw New Exception($"1号传感器异常:{ex.Message}")
        End Try

    End Sub
#End Region

#Region "采集2号传感器状态"
    ''' <summary>
    ''' 采集2号传感器状态
    ''' </summary>
    Private Shared Sub GetSensorDataOf2(value As HardwareInfo)
        Try
            Dim sendData() = Wangk.Hash.Hex2Bin("0003003E00090000")
            Dim recData(128 - 1) As Byte

            '生成检测指令
            sendData(0) = value.ID
            Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
            Dim CRCBytes = BitConverter.GetBytes(CRC)
            sendData(6) = CRCBytes(0)
            sendData(7) = CRCBytes(1)

            '发送检测指令
            SP.Write(sendData, 0, sendData.Count)
            '等待数据返回
            Threading.Thread.Sleep(500)
            Dim count = SP.Read(recData, 0, 128)

            '判断CRC
            CRC = Wangk.Hash.GetCRC16Modbus(recData, 21)
            CRCBytes = BitConverter.GetBytes(CRC)
            If recData(21) <> CRCBytes(0) OrElse
                recData(22) <> CRCBytes(1) Then
                Throw New Exception($"2号传感器数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
            End If

            For byteID = 0 To 9 - 1
                value.SensorItems(1, byteID) = 0 Or recData(3 + byteID * 2)
                value.SensorItems(1, byteID) <<= 8
                value.SensorItems(1, byteID) = value.SensorItems(1, byteID) Or recData(3 + byteID * 2 + 1)
            Next

        Catch timeOut As TimeoutException
            Throw New Exception($"2号传感器 接收数据超时")
        Catch ex As Exception
            Throw New Exception($"2号传感器异常:{ex.Message}")
        End Try

    End Sub
#End Region

#Region "采集模块状态"
    ''' <summary>
    ''' 采集模块状态
    ''' </summary>
    Private Shared Sub GetHardwareState(value As HardwareInfo)
        Try
            Dim sendData() = Wangk.Hash.Hex2Bin("0003003300020000")
            Dim recData(128 - 1) As Byte

            '生成检测指令
            sendData(0) = value.ID
            Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
            Dim CRCBytes = BitConverter.GetBytes(CRC)
            sendData(6) = CRCBytes(0)
            sendData(7) = CRCBytes(1)

            '发送检测指令
            SP.Write(sendData, 0, sendData.Count)
            '等待数据返回
            Threading.Thread.Sleep(500)
            Dim count = SP.Read(recData, 0, 128)

            '判断CRC
            CRC = Wangk.Hash.GetCRC16Modbus(recData, 7)
            CRCBytes = BitConverter.GetBytes(CRC)
            If recData(7) <> CRCBytes(0) OrElse
                recData(8) <> CRCBytes(1) Then
                Throw New Exception($"模块状态数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
            End If

            value.IsMeasureSpeed = (recData(4) = &H1)

            Dim tmpVoltage As UInt16 = 0 Or recData(5)
            tmpVoltage <<= 8
            tmpVoltage = tmpVoltage Or recData(6)

            value.Voltage = tmpVoltage / 100

        Catch timeOut As TimeoutException
            Throw New Exception($"模块状态 接收数据超时")
        Catch ex As Exception
            Throw New Exception($"模块状态异常:{ex.Message}")
        End Try

    End Sub
#End Region

End Class
