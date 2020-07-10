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

        SP.DiscardInBuffer()

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
        Dim hardwareID As Integer = 0
        Dim sleepCount As Integer = 0

        Do
            If Not _IsRunning Then Exit Sub

#Region "检测设备状态"

            If sleepCount Mod AppSettingHelper.GetInstance.pollingInterval = 0 Then
                Dim hardwareItem = AppSettingHelper.GetInstance.HardwareItems(hardwareID)
                If Not _IsRunning Then Exit Sub

                '发送测试指令
                If IsTestMode Then
                    IsTestMode = False
                    UIMainForm.Log($"发送测试指令")

                    ReadSensorData()
                    Threading.Thread.Sleep(500)
                End If

                UIMainForm.Log($"检测设备 {hardwareItem.Name} [{hardwareItem.ID}] ")

                If Not _IsRunning Then Exit Sub

                Try

                    GetHardwareData(hardwareItem)

                    Dim tmpStr = $"{Math.Round(hardwareItem.Voltage, 2)}"
                    For sensorID = 0 To 2 - 1
                        For itemID = 0 To 9 - 1

                            If itemID = 0 OrElse
                                itemID = 1 OrElse
                                itemID = 2 Then
                                tmpStr &= $" {hardwareItem.SensorDataItems(sensorID, itemID) / 10}"
                            Else
                                tmpStr &= $" {hardwareItem.SensorDataItems(sensorID, itemID)}"
                            End If

                        Next
                    Next

                    tmpStr &= $" {hardwareItem.WearCalibrationValue(0)} {hardwareItem.WearCalibrationValue(1)}"

                    For sensorID = 2 To 4 - 1
                        For itemID = 0 To 9 - 1

                            If itemID = 0 OrElse
                                itemID = 1 OrElse
                                itemID = 2 Then
                                tmpStr &= $" {hardwareItem.SensorDataItems(sensorID, itemID) / 10}"
                            Else
                                tmpStr &= $" {hardwareItem.SensorDataItems(sensorID, itemID)}"
                            End If

                        Next
                    Next

                    tmpStr &= $" {hardwareItem.SensorAverageItems(0)} {hardwareItem.SensorAverageItems(1)}"

                    System.IO.Directory.CreateDirectory($".\SensorData")
                    System.IO.Directory.CreateDirectory($".\SensorData\{hardwareItem.Name}")
                    Using tmp As IO.StreamWriter = New IO.StreamWriter($".\SensorData\{hardwareItem.Name}\{hardwareItem.Name}_{Format(Now(), "yyyyMMdd")}.log", True)
                        tmp.WriteLine($"{Now():yyyy/MM/dd HH:mm:ss}> {tmpStr}")
                    End Using

                Catch ex As Exception
                    UIMainForm.Log(ex.Message)
                    hardwareItem.IsOnline = False
                End Try

                If Not _IsRunning Then Exit Sub

                '上传数据至监控平台
                UploadToJKPT()

                '更新界面
                UIMainForm.UpdateOverviewBackground(hardwareItem)

                hardwareID = (hardwareID + 1) Mod AppSettingHelper.GetInstance.HardwareItems.Count
            End If
#End Region

#Region "回读刀盘转速"
            UpdateTBMCutterRev(sleepCount)
#End Region

#Region "发送测试指令"
            If (sleepCount Mod (20 * 60)) = 0 AndAlso
                AppSettingHelper.GetInstance.IsTBMCutterTurn Then

                UIMainForm.Log($"发送测试指令")

                Try
                    ReadSensorData()

                Catch ex As Exception
                    UIMainForm.Log(ex.Message)
                End Try
            End If
#End Region

            sleepCount = (sleepCount + 1) Mod 100000
            Threading.Thread.Sleep(1000)

        Loop

    End Sub
#End Region

#Region "更新转速"
    ''' <summary>
    ''' 更新转速
    ''' </summary>
    Public Shared Sub UpdateTBMCutterRev(sleepCount As Integer)
        If (sleepCount Mod 10) = 0 Then
            UIMainForm.Log($"检测转速")

            Try
                GetRotationAngle()

                UIMainForm.UpdateTBMCutterRev()

                '写入文件
                System.IO.Directory.CreateDirectory($".\SensorData")
                System.IO.Directory.CreateDirectory($".\SensorData\IsTBMCutterTurn")
                Using tmp As IO.StreamWriter = New IO.StreamWriter($".\SensorData\IsTBMCutterTurn\IsTBMCutterTurn_{Format(Now(), "yyyyMMdd")}.log", True)
                    tmp.WriteLine($"{Now():yyyy/MM/dd HH:mm:ss}> {If(AppSettingHelper.GetInstance.IsTBMCutterTurn, 1, 0)}")
                End Using

            Catch ex As Exception
                UIMainForm.Log(ex.Message)
            End Try
        End If
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

#Region "采集设备数据"
    ''' <summary>
    ''' 采集设备数据
    ''' </summary>
    Private Shared Sub GetHardwareData(value As HardwareInfo)
        Try
            Dim sendData() = Wangk.Hash.Hex2Bin("0003003300280000")
            Dim recvData(128 - 1) As Byte

            sendData(0) = value.ID

            Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
            Dim CRCBytes = BitConverter.GetBytes(CRC)
            sendData(sendData.Count - 2) = CRCBytes(0)
            sendData(sendData.Count - 1) = CRCBytes(1)

            '发送检测指令
            SP.Write(sendData, 0, sendData.Count)
            '等待数据返回
            Threading.Thread.Sleep(1500)
            Dim recvCount = SP.Read(recvData, 0, 128)

            If recvCount < 80 Then
                Throw New Exception($"设备 {value.Name} [{value.ID}] 数据接收不完整: {recvCount}")
            End If

            '判断CRC
            CRC = Wangk.Hash.GetCRC16Modbus(recvData, recvCount - 2)
            CRCBytes = BitConverter.GetBytes(CRC)
            If recvData(recvCount - 2) <> CRCBytes(0) OrElse
                recvData(recvCount - 1) <> CRCBytes(1) Then
                Throw New Exception($"设备 {value.Name} [{value.ID}] 数据校验失败:{Wangk.Hash.Bin2Hex(recvData)}[{recvCount}]")
            End If

            '状态
            value.IsMeasureSpeed = (recvData(4) = &H1)

            '电压
            Dim tmpValue As UInt16 = 0 Or recvData(5)
            tmpValue <<= 8
            tmpValue = tmpValue Or recvData(6)

            value.Voltage = tmpValue / 100

            '传感器1/2数据
            For sensorID = 0 To 2 - 1
                For dataID = 0 To 9 - 1
                    value.SensorDataItems(sensorID, dataID) = 0 Or recvData(7 + 9 * 2 * sensorID + dataID * 2)
                    value.SensorDataItems(sensorID, dataID) <<= 8
                    value.SensorDataItems(sensorID, dataID) = value.SensorDataItems(sensorID, dataID) Or recvData(7 + 9 * 2 * sensorID + dataID * 2 + 1)
                Next

                value.SensorDataItems(sensorID, 0) = value.SensorDataItems(sensorID, 0) - value.WearCalibrationValue(sensorID Mod 2)
            Next

            '传感器1/2均值
            For sensorID = 0 To 2 - 1
                value.SensorAverageItems(sensorID) = 0 Or recvData(7 + 9 * 2 * 2 + sensorID * 2)
                value.SensorAverageItems(sensorID) <<= 8
                value.SensorAverageItems(sensorID) = value.SensorAverageItems(sensorID) Or recvData(7 + 9 * 2 * 2 + sensorID * 2 + 1)
            Next

            '传感器3/4数据
            For sensorID = 2 To 4 - 1
                For dataID = 0 To 9 - 1
                    value.SensorDataItems(sensorID, dataID) = 0 Or recvData(7 + 2 + 2 + 9 * 2 * sensorID + dataID * 2)
                    value.SensorDataItems(sensorID, dataID) <<= 8
                    value.SensorDataItems(sensorID, dataID) = value.SensorDataItems(sensorID, dataID) Or recvData(7 + 2 + 2 + 9 * 2 * sensorID + dataID * 2 + 1)
                Next

                value.SensorDataItems(sensorID, 0) = value.SensorDataItems(sensorID, 0) - value.WearCalibrationValue(sensorID Mod 2)
            Next

            value.IsOnline = True

            value.UpdateTime = Now

        Catch timeOut As TimeoutException
            Throw New Exception($"设备 {value.Name} [{value.ID}] 接收数据超时")
        Catch ex As Exception
            Throw New Exception($"设备 {value.Name} [{value.ID}] 异常:{ex.Message}")
        End Try

    End Sub
#End Region

#Region "采集传感器状态"
    '''' <summary>
    '''' 采集传感器状态
    '''' </summary>
    'Private Shared Sub GetSensorData(value As HardwareInfo, sensorID As Integer)
    '    Try
    '        Dim sendData() = Wangk.Hash.Hex2Bin({"0003003500090000",
    '                                             "0003003E00090000",
    '                                             "0003004900090000",
    '                                             "0003005200090000"}(sensorID))
    '        Dim recData(128 - 1) As Byte

    '        '生成检测指令
    '        sendData(0) = value.ID
    '        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
    '        Dim CRCBytes = BitConverter.GetBytes(CRC)
    '        sendData(6) = CRCBytes(0)
    '        sendData(7) = CRCBytes(1)

    '        '发送检测指令
    '        SP.Write(sendData, 0, sendData.Count)
    '        '等待数据返回
    '        Threading.Thread.Sleep(500)
    '        Dim count = SP.Read(recData, 0, 128)

    '        '判断CRC
    '        CRC = Wangk.Hash.GetCRC16Modbus(recData, 21)
    '        CRCBytes = BitConverter.GetBytes(CRC)
    '        If recData(21) <> CRCBytes(0) OrElse
    '            recData(22) <> CRCBytes(1) Then
    '            Throw New Exception($"{sensorID}号传感器数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
    '        End If

    '        For byteID = 0 To 9 - 1
    '            value.SensorDataItems(sensorID, byteID) = 0 Or recData(3 + byteID * 2)
    '            value.SensorDataItems(sensorID, byteID) <<= 8
    '            value.SensorDataItems(sensorID, byteID) = value.SensorDataItems(sensorID, byteID) Or recData(3 + byteID * 2 + 1)
    '        Next

    '        value.SensorDataItems(sensorID, 0) = value.SensorDataItems(sensorID, 0) - value.WearCalibrationValue(sensorID Mod 2)

    '    Catch timeOut As TimeoutException
    '        Throw New Exception($"{sensorID}号传感器 接收数据超时")
    '    Catch ex As Exception
    '        Throw New Exception($"{sensorID}号传感器异常:{ex.Message}")
    '    End Try

    'End Sub
#End Region

#Region "采集1号传感器状态"
    '''' <summary>
    '''' 采集1号传感器状态
    '''' </summary>
    'Private Shared Sub GetSensorDataOf1(value As HardwareInfo)
    '    Try
    '        Dim sendData() = Wangk.Hash.Hex2Bin(If(value.IsSerratedKnife, "0003004900090000", "0003003500090000"))
    '        Dim recData(128 - 1) As Byte

    '        '生成检测指令
    '        sendData(0) = value.ID
    '        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
    '        Dim CRCBytes = BitConverter.GetBytes(CRC)
    '        sendData(6) = CRCBytes(0)
    '        sendData(7) = CRCBytes(1)

    '        '发送检测指令
    '        SP.Write(sendData, 0, sendData.Count)
    '        '等待数据返回
    '        Threading.Thread.Sleep(500)
    '        Dim count = SP.Read(recData, 0, 128)

    '        '判断CRC
    '        CRC = Wangk.Hash.GetCRC16Modbus(recData, 21)
    '        CRCBytes = BitConverter.GetBytes(CRC)
    '        If recData(21) <> CRCBytes(0) OrElse
    '            recData(22) <> CRCBytes(1) Then
    '            Throw New Exception($"1号传感器数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
    '        End If

    '        Dim serratedKnifeCount = If(value.IsSerratedKnife, 2, 0)

    '        For byteID = 0 To 9 - 1
    '            value.SensorItems(0 + serratedKnifeCount, byteID) = 0 Or recData(3 + byteID * 2)
    '            value.SensorItems(0 + serratedKnifeCount, byteID) <<= 8
    '            value.SensorItems(0 + serratedKnifeCount, byteID) = value.SensorItems(0 + serratedKnifeCount, byteID) Or recData(3 + byteID * 2 + 1)
    '        Next

    '        value.SensorItems(0 + serratedKnifeCount, 0) = value.SensorItems(0 + serratedKnifeCount, 0) - value.WearCalibrationValue(0)

    '    Catch timeOut As TimeoutException
    '        Throw New Exception($"1号传感器 接收数据超时")
    '    Catch ex As Exception
    '        Throw New Exception($"1号传感器异常:{ex.Message}")
    '    End Try

    'End Sub
#End Region

#Region "采集2号传感器状态"
    '''' <summary>
    '''' 采集2号传感器状态
    '''' </summary>
    'Private Shared Sub GetSensorDataOf2(value As HardwareInfo)
    '    Try
    '        Dim sendData() = Wangk.Hash.Hex2Bin(If(value.IsSerratedKnife, "0003005200090000", "0003003E00090000"))
    '        Dim recData(128 - 1) As Byte

    '        '生成检测指令
    '        sendData(0) = value.ID
    '        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
    '        Dim CRCBytes = BitConverter.GetBytes(CRC)
    '        sendData(6) = CRCBytes(0)
    '        sendData(7) = CRCBytes(1)

    '        '发送检测指令
    '        SP.Write(sendData, 0, sendData.Count)
    '        '等待数据返回
    '        Threading.Thread.Sleep(500)
    '        Dim count = SP.Read(recData, 0, 128)

    '        '判断CRC
    '        CRC = Wangk.Hash.GetCRC16Modbus(recData, 21)
    '        CRCBytes = BitConverter.GetBytes(CRC)
    '        If recData(21) <> CRCBytes(0) OrElse
    '            recData(22) <> CRCBytes(1) Then
    '            Throw New Exception($"2号传感器数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
    '        End If

    '        Dim serratedKnifeCount = If(value.IsSerratedKnife, 2, 0)

    '        For byteID = 0 To 9 - 1
    '            value.SensorItems(1 + serratedKnifeCount, byteID) = 0 Or recData(3 + byteID * 2)
    '            value.SensorItems(1 + serratedKnifeCount, byteID) <<= 8
    '            value.SensorItems(1 + serratedKnifeCount, byteID) = value.SensorItems(1 + serratedKnifeCount, byteID) Or recData(3 + byteID * 2 + 1)
    '        Next

    '        value.SensorItems(1 + serratedKnifeCount, 0) = value.SensorItems(1 + serratedKnifeCount, 0) - value.WearCalibrationValue(0)


    '    Catch timeOut As TimeoutException
    '        Throw New Exception($"2号传感器 接收数据超时")
    '    Catch ex As Exception
    '        Throw New Exception($"2号传感器异常:{ex.Message}")
    '    End Try

    'End Sub
#End Region

#Region "采集模块状态"
    '''' <summary>
    '''' 采集模块状态
    '''' </summary>
    'Private Shared Sub GetHardwareState(value As HardwareInfo)
    '    Try
    '        Dim sendData() = Wangk.Hash.Hex2Bin("0003003300020000")
    '        Dim recData(128 - 1) As Byte

    '        '生成检测指令
    '        sendData(0) = value.ID
    '        Dim CRC = Wangk.Hash.GetCRC16Modbus(sendData, sendData.Count - 2)
    '        Dim CRCBytes = BitConverter.GetBytes(CRC)
    '        sendData(6) = CRCBytes(0)
    '        sendData(7) = CRCBytes(1)

    '        '发送检测指令
    '        SP.Write(sendData, 0, sendData.Count)
    '        '等待数据返回
    '        Threading.Thread.Sleep(500)
    '        Dim count = SP.Read(recData, 0, 128)

    '        '判断CRC
    '        CRC = Wangk.Hash.GetCRC16Modbus(recData, 7)
    '        CRCBytes = BitConverter.GetBytes(CRC)
    '        If recData(7) <> CRCBytes(0) OrElse
    '            recData(8) <> CRCBytes(1) Then
    '            Throw New Exception($"模块状态数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
    '        End If

    '        value.IsMeasureSpeed = (recData(4) = &H1)

    '        Dim tmpVoltage As UInt16 = 0 Or recData(5)
    '        tmpVoltage <<= 8
    '        tmpVoltage = tmpVoltage Or recData(6)

    '        value.Voltage = tmpVoltage / 100

    '    Catch timeOut As TimeoutException
    '        Throw New Exception($"模块状态 接收数据超时")
    '    Catch ex As Exception
    '        Throw New Exception($"模块状态异常:{ex.Message}")
    '    End Try

    'End Sub
#End Region

#Region "获取转动角度"
    ''' <summary>
    ''' 获取转动角度
    ''' </summary>
    Private Shared Sub GetRotationAngle()
        Try
            Dim sendData() = Wangk.Hash.Hex2Bin("0003005D000255ea")
            Dim recData(128 - 1) As Byte

            '生成检测指令
            sendData(0) = AppSettingHelper.GetInstance.WallThicknessHardwareID
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
                Throw New Exception($"转动角度数据校验失败:{Wangk.Hash.Bin2Hex(recData)}")
            End If

            Dim tmpRotationAngle As UInt16 = 0 Or recData(5)
            tmpRotationAngle <<= 8
            tmpRotationAngle = tmpRotationAngle Or recData(6)

            With AppSettingHelper.GetInstance
                .IsTBMCutterTurn = Math.Abs(tmpRotationAngle - .OldYRotationAngle) >= 600
            End With
            AppSettingHelper.GetInstance.OldYRotationAngle = tmpRotationAngle

            'AppSettingHelper.Settings.OldYRotationAngle = AppSettingHelper.Settings.YRotationAngle
            'AppSettingHelper.Settings.OldYRotationAngleUpdateDateTime = AppSettingHelper.Settings.YRotationAngleUpdateDateTime
            'AppSettingHelper.Settings.YRotationAngle = tmpRotationAngle
            'AppSettingHelper.Settings.YRotationAngleUpdateDateTime = Now

        Catch timeOut As TimeoutException
            Throw New Exception($"转动角度 接收数据超时")
        Catch ex As Exception
            Throw New Exception($"模块状态异常:{ex.Message}")
        End Try
    End Sub
#End Region

#Region "上传数据至监控平台"
    ''' <summary>
    ''' 上传数据至监控平台
    ''' </summary>
    Public Shared Sub UploadToJKPT()

        If Not AppSettingHelper.GetInstance.EnabledUploadToJKPT Then
            Exit Sub
        End If

        UIMainForm.Log($"提交数据至监控平台")

        Try
            Dim tmp = New Uploadpackage With {
                .Key = AppSettingHelper.GetInstance.UploadKeyJKPT
            }

            For Each item In AppSettingHelper.GetInstance.HardwareItems
                tmp.SensorItems.Add(New UploadHardwareInfo With {
                                    .CID = item.Name,
                                    .CutterType = If(item.IsSerratedKnife, "齿刀", "滚刀"),
                                    .State = If(item.IsOnline, "在线", "离线"),
                                    .Voltage = item.Voltage,
                                    .VoltageMinimum = AppSettingHelper.GetInstance.BatteryVoltageMinimum,
                                    .Sensor1Wear = Math.Round(item.SensorDataItems(0 + If(item.IsSerratedKnife, 2, 0), 0) / 10, 1),
                                    .Sensor1State = If(item.SensorDataItems(0 + If(item.IsSerratedKnife, 2, 0), 2) > 0, "转动", "静止"),
                                    .Sensor2Wear = Math.Round(item.SensorDataItems(1 + If(item.IsSerratedKnife, 2, 0), 0) / 10, 1),
                                    .Sensor2State = If(item.SensorDataItems(1 + If(item.IsSerratedKnife, 2, 0), 2) > 0, "转动", "静止"),
                                    .SensorWearMaximum = AppSettingHelper.GetInstance.WearMaximum / 10,
                                    .UpdateTime = item.UpdateTime.ToString("yyyy/MM/dd HH:mm:ss")
                                    })
            Next

            WebAPIHelper.HttpPostData(tmp,
                                      AppSettingHelper.GetInstance.UploadPathJKPT,
                                      False)
        Catch ex As Exception
            UIMainForm.Log(ex.Message)
        End Try

    End Sub
#End Region

End Class
