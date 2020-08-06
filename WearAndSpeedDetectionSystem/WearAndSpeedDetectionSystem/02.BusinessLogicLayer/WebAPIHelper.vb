Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json
Imports Wangk.Resource
''' <summary>
''' 请求辅助模块
''' </summary>
Public NotInheritable Class WebAPIHelper
    Private Sub WebAPIHelper()
    End Sub

    Public Shared Function HttpPostData(value As Object,
                                        url As String,
                                        Optional isIncludeToken As Boolean = True) As ResultMsg
        Try
            '请求头
            Dim request As System.Net.HttpWebRequest = WebRequest.Create(url)
            'request.Proxy = Nothing
            request.Method = "POST"
            request.ContentType = "application/json"
            If isIncludeToken Then
                'request.Headers.Add("token", AppSettingHelper.GetInstance.Cache.Token)
            End If

            If value IsNot Nothing Then
                '参数
                Dim data As Byte() = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value))

                'MsgBox(JsonConvert.SerializeObject(value))
                'Console.WriteLine(JsonConvert.SerializeObject(value))

                'post 数据
                request.ContentLength = data.Length
                Using reqStream As Stream = request.GetRequestStream()
                    reqStream.Write(data, 0, data.Length)
                End Using
            Else
                request.ContentLength = 0
            End If

            '接收数据
            Using resp As HttpWebResponse = request.GetResponse()
                Using Stream As Stream = resp.GetResponseStream()
                    Using reader As StreamReader = New StreamReader(Stream, Encoding.UTF8)
                        Return JsonConvert.DeserializeObject(Of ResultMsg)(reader.ReadToEnd())
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Return New ResultMsg With {.Code = 404, .Message = ex.Message}
        End Try

    End Function

End Class
