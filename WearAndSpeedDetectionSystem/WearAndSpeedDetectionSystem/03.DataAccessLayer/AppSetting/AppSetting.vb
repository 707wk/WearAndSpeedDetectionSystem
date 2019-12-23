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
    ''' 设备轮询间隔(s)
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
    Public Shared OverviewBackgroundLocation As String = ".\Data\OverviewBackground"

    ''' <summary>
    ''' 刀盘转速测量设备ID
    ''' </summary>
    Public WallThicknessHardwareID As Integer

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
    ''' <summary>
    ''' 电池最小值
    ''' </summary>
    Public BatteryVoltageMinimum As Integer

    ''' <summary>
    ''' 是否开机自启
    ''' </summary>
    Public IsAutoRun As Boolean

    ''' <summary>
    ''' y轴转动角度
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public OldYRotationAngle As Integer = 0
    '<Newtonsoft.Json.JsonIgnore>
    'Public OldYRotationAngleUpdateDateTime As DateTime

    '''' <summary>
    '''' y轴转动角度
    '''' </summary>
    '<Newtonsoft.Json.JsonIgnore>
    'Public YRotationAngle As Integer

    ''' <summary>
    ''' 刀盘是否转动
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public IsTBMCutterTurn As Boolean
    '<Newtonsoft.Json.JsonIgnore>
    'Public YRotationAngleUpdateDateTime As DateTime = Now

End Class
