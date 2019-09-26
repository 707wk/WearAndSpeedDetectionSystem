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

    ''' <summary>
    ''' 硬件列表
    ''' </summary>
    Public HardwareItems As List(Of HardwareInfo)

End Class
