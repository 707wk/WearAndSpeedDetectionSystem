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
    ''' 是否为齿刀
    ''' </summary>
    Public IsSerratedKnife As Boolean

    ''' <summary>
    ''' 设备电压值(格式 12.34V)
    ''' </summary>
    Public Voltage As Double

    ''' <summary>
    ''' 是否在测量转速
    ''' </summary>
    Public IsMeasureSpeed As Boolean

    ''' <summary>
    ''' 是否在线
    ''' </summary>
    Public IsOnline As Boolean

    ''' <summary>
    ''' 传感器值,普通刀具显示0/1,齿刀显示2/3
    ''' </summary>
    Public SensorDataItems(4 - 1, 9 - 1) As UInt16

    ''' <summary>
    ''' 磨损校准值
    ''' </summary>
    Public WearCalibrationValue(2 - 1) As Integer

    ''' <summary>
    ''' 采集均值
    ''' </summary>
    Public SensorAverageItems(2 - 1) As UInt16

    ''' <summary>
    ''' 控件信息
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public HardwareStateControl As DataGridViewRow

    ''' <summary>
    ''' 更新时间
    ''' </summary>
    Public UpdateTime As DateTime

End Class
