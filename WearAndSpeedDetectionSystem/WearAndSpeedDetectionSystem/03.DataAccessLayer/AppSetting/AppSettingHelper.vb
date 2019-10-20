Imports Newtonsoft.Json
''' <summary>
''' 全局配置辅助类
''' </summary>
Public Class AppSettingHelper
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 实例
    ''' </summary>
    Private Shared instance As AppSetting

    ''' <summary>
    ''' 识别码
    ''' </summary>
    Public Shared GUID As String

    ''' <summary>
    ''' 参数
    ''' </summary>
    Public Shared ReadOnly Property Settings As AppSetting
        Get
            If instance Is Nothing Then

                '获取程序集GUID
                Dim guid_attr As Attribute = Attribute.GetCustomAttribute(Reflection.Assembly.GetExecutingAssembly(), GetType(Runtime.InteropServices.GuidAttribute))
                GUID = CType(guid_attr, Runtime.InteropServices.GuidAttribute).Value

                LoadFromLocaltion()

                '初始化
                With instance
                    ''语言包
                    'Wangk.Resource.MultiLanguageHelper.Init(.SelectLang, My.Application.Info.Title)

                    '日志
                    'Wangk.Tools.LoggerHelper.Init(saveDaysMax:=900)

                End With

            End If

            Return instance
        End Get
    End Property

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
            instance = JsonConvert.DeserializeObject(Of AppSetting)(
                System.IO.File.ReadAllText($"{Path}\Hunan Yestech\{My.Application.Info.ProductName}\Data\Setting.json",
                                           System.Text.Encoding.UTF8))

        Catch ex As Exception
            '使用默认参数
            instance = New AppSetting
            With instance
                .SerialPort = ""
                .BPS = ""
                .pollingInterval = 2
                .HardwareItems = New List(Of HardwareInfo)
                .WearMaximum = 40
                .TempMaximum = 100
                .SpeedMaximum = 5
            End With

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

End Class
