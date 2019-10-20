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
    ''' 显示位置
    ''' </summary>
    Public Location As Point

    ''' <summary>
    ''' 设备电压值(格式 12.34V)
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public Voltage As Double

    ''' <summary>
    ''' 是否在测量转速
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public IsMeasureSpeed As Boolean

    ''' <summary>
    ''' 传感器值
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public SensorItems(2 - 1, 9 - 1) As UInt16

    ''' <summary>
    ''' 控件信息
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public HardwareStateControl As HardwareStateControlByGDI

End Class
