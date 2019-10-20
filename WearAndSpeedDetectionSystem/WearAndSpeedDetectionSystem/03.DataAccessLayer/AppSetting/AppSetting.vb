''' <summary>
''' 全局配置类
''' </summary>
Public Class AppSetting

    ''' <summary>
    ''' 串口号
    ''' </summary>
    Public SerialPort As String
    ''' <summary>
    ''' 波特率
    ''' </summary>
    Public BPS As String

    ''' <summary>
    ''' 设备轮询间隔
    ''' </summary>
    Public pollingInterval As Integer

    '''' <summary>
    '''' 是否显示历史数据模块
    '''' </summary>
    '<Newtonsoft.Json.JsonIgnore>
    'Public IsShowHistoryModule As Boolean

    ''' <summary>
    ''' 概览背景图路径
    ''' </summary>
    Public Shared OverviewBackgroundLocation As String = "Data\OverviewBackground"

    ''' <summary>
    ''' 硬件列表
    ''' </summary>
    Public HardwareItems As List(Of HardwareInfo)

    ''' <summary>
    ''' 磨损量最大值(10/mm)
    ''' </summary>
    Public WearMaximum As Integer
    ''' <summary>
    ''' 温度最大值
    ''' </summary>
    Public TempMaximum As Integer
    ''' <summary>
    ''' 转速最大值
    ''' </summary>
    Public SpeedMaximum As Integer

    '''' <summary>
    '''' 是否开机自启
    '''' </summary>
    'Public IsAutoRun As Boolean

End Class
