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
    Private Shared IsRunning As Boolean = False

    ''' <summary>
    ''' 主窗体
    ''' </summary>
    Public Shared UIMainForm As MainForm

    ''' <summary>
    ''' 是否发送测试指令
    ''' </summary>
    Private Shared IsTestMode As Boolean = False
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

        If IsRunning Then
            Exit Sub
        End If
        IsRunning = True

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

        If Not IsRunning Then
            Exit Sub
        End If
        IsRunning = False

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

                If Not IsRunning Then
                    Exit Sub
                End If

                '发送测试指令
                If IsTestMode Then
                    IsTestMode = False
                    UIMainForm.Log($"发送测试指令")

                    ReadSensorData()
                    Threading.Thread.Sleep(500)
                End If

                UIMainForm.Log($"检测刀具 {tmpHardware.Name}")

                GetSensorDataOf1(tmpHardware)
                Threading.Thread.Sleep(500)
                GetSensorDataOf2(tmpHardware)
                Threading.Thread.Sleep(500)
                GetHardwareVoltage(tmpHardware)

                Dim tmpStr = $" {Math.Round(tmpHardware.Voltage, 2)}"
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
                tmpHardware.HardwareStateControl.UpdateData()

                '延时查询下一个设备
                For i001 = 0 To AppSettingHelper.Settings.pollingInterval - 1
                    If Not IsRunning Then
                        Exit Sub
                    End If

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
            UIMainForm.Log($"立即采集异常:{ex.ToString}")
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
                UIMainForm.Log($"1号传感器数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
            End If

            For byteID = 0 To 9 - 1
                value.SensorItems(0, byteID) = 0 Or recData(3 + byteID * 2)
                value.SensorItems(0, byteID) <<= 8
                value.SensorItems(0, byteID) = value.SensorItems(0, byteID) Or recData(3 + byteID * 2 + 1)
            Next

        Catch timeOut As TimeoutException
            UIMainForm.Log($"1号传感器 接收数据超时")
        Catch ex As Exception
            UIMainForm.Log($"1号传感器异常:{ex.ToString}")
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
                UIMainForm.Log($"2号传感器数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
            End If

            For byteID = 0 To 9 - 1
                value.SensorItems(1, byteID) = 0 Or recData(3 + byteID * 2)
                value.SensorItems(1, byteID) <<= 8
                value.SensorItems(1, byteID) = value.SensorItems(1, byteID) Or recData(3 + byteID * 2 + 1)
            Next

        Catch timeOut As TimeoutException
            UIMainForm.Log($"2号传感器 接收数据超时")
        Catch ex As Exception
            UIMainForm.Log($"2号传感器异常:{ex.ToString}")
        End Try

    End Sub
#End Region

#Region "采集模块电池电压"
    ''' <summary>
    ''' 采集模块电池电压
    ''' </summary>
    Private Shared Sub GetHardwareVoltage(value As HardwareInfo)
        Try
            Dim sendData() = Wangk.Hash.Hex2Bin("0003003400020000")
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
                UIMainForm.Log($"模块电池电压数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
            End If

            Dim tmpVoltage As UInt16 = 0 Or recData(3)
            tmpVoltage <<= 8
            tmpVoltage = tmpVoltage Or recData(4)

            value.Voltage = tmpVoltage / 100

        Catch timeOut As TimeoutException
            UIMainForm.Log($"模块电池电压 接收数据超时")
        Catch ex As Exception
            UIMainForm.Log($"模块电池电压异常:{ex.ToString}")
        End Try

    End Sub
#End Region

End Class
