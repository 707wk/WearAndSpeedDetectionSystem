''' <summary>
''' 硬件信息
''' </summary>
Public Class HardwareInfo
    ''' <summary>
    ''' 刀具编号
    ''' </summary>
    Public Name As String
    ''' <summary>
    ''' 设备ID
    ''' </summary>
    Public ID As Integer

    ''' <summary>
    ''' 设备电压值(格式 12.34V)
    ''' </summary>
    Public Voltage As Double

    ''' <summary>
    ''' 传感器值
    ''' </summary>
    Public SensorItems(2 - 1, 9 - 1) As UInt16

    ''' <summary>
    ''' 控件信息
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public HardwareStateControl As HardwareStateControl

End Class
