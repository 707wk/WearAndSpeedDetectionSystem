Imports Newtonsoft.Json
''' <summary>
''' 全局配置辅助类
''' </summary>
Public Class AppSettingHelper
    Private Sub New()
    End Sub

#Region "程序集GUID"
    <Newtonsoft.Json.JsonIgnore>
    Private _GUID As String
    ''' <summary>
    ''' 程序集GUID
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public ReadOnly Property GUID As String
        Get
            Return _GUID
        End Get
    End Property
#End Region

#Region "程序集文件版本"
    <Newtonsoft.Json.JsonIgnore>
    Private _ProductVersion As String
    ''' <summary>
    ''' 程序集文件版本
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public ReadOnly Property ProductVersion As String
        Get
            Return _ProductVersion
        End Get
    End Property
#End Region

#Region "配置参数"
    ''' <summary>
    ''' 实例
    ''' </summary>
    Private Shared instance As AppSettingHelper
    ''' <summary>
    ''' 获取实例
    ''' </summary>
    Public Shared ReadOnly Property GetInstance As AppSettingHelper
        Get
            If instance Is Nothing Then
                LoadFromLocaltion()

                '程序集GUID
                Dim guid_attr As Attribute = Attribute.GetCustomAttribute(Reflection.Assembly.GetExecutingAssembly(), GetType(Runtime.InteropServices.GuidAttribute))
                instance._GUID = CType(guid_attr, Runtime.InteropServices.GuidAttribute).Value

                '程序集文件版本
                Dim assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location
                instance._ProductVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(assemblyLocation).ProductVersion

            End If

            Return instance
        End Get
    End Property
#End Region

#Region "从本地读取配置"
    ''' <summary>
    ''' 从本地读取配置
    ''' </summary>
    Private Shared Sub LoadFromLocaltion()
        Dim Path As String = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)

        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech")
        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}")
        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data")

        '反序列化
        Try
            instance = JsonConvert.DeserializeObject(Of AppSettingHelper)(
                System.IO.File.ReadAllText($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data\Setting.json",
                                           System.Text.Encoding.UTF8))

        Catch ex As Exception
            '使用默认参数
            instance = New AppSettingHelper

        End Try

    End Sub
#End Region

#Region "保存配置到本地"
    ''' <summary>
    ''' 保存配置到本地
    ''' </summary>
    Public Shared Sub SaveToLocaltion()
        Dim Path As String = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)

        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech")
        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}")
        System.IO.Directory.CreateDirectory($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data")

        '序列化
        Try
            Using t As System.IO.StreamWriter = New System.IO.StreamWriter(
                    $"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data\Setting.json",
                    False,
                    System.Text.Encoding.UTF8)

                t.Write(JsonConvert.SerializeObject(instance))
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, My.Application.Info.Title)

        End Try

    End Sub
#End Region

#Region "日志记录"
    ''' <summary>
    ''' 日志记录
    ''' </summary>
    <Newtonsoft.Json.JsonIgnore>
    Public Logger As NLog.Logger = NLog.LogManager.GetCurrentClassLogger()
#End Region

    ''' <summary>
    ''' 串口号
    ''' </summary>
    Public SerialPort As String
    ''' <summary>
    ''' 波特率
    ''' </summary>
    Public Shared BPS As Integer = 9600

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

#Region "监控平台参数"
    ''' <summary>
    ''' 启用上传至监控平台
    ''' </summary>
    Public EnabledUploadToJKPT As Boolean
    ''' <summary>
    ''' 监控平台上传地址
    ''' </summary>
    Public UploadPathJKPT As String
    ''' <summary>
    ''' 监控平台上传Key
    ''' </summary>
    Public UploadKeyJKPT As String
#End Region

End Class
