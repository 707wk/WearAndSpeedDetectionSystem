Imports Wangk.Resource

Public Class UploadSettingForm
    Private Sub UploadSettingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
#Region "监控平台"
        EnabledUploadToJKPT.Checked = AppSettingHelper.GetInstance.EnabledUploadToJKPT
        UploadPathJKPTText.Text = AppSettingHelper.GetInstance.UploadPathJKPT
        UploadKeyJKPTText.Text = AppSettingHelper.GetInstance.UploadKeyJKPT
#End Region
    End Sub

    Private Sub AddOrSaveButton_Click(sender As Object, e As EventArgs) Handles AddOrSaveButton.Click
#Region "监控平台"
        AppSettingHelper.GetInstance.EnabledUploadToJKPT = EnabledUploadToJKPT.Checked
        AppSettingHelper.GetInstance.UploadPathJKPT = UploadPathJKPTText.Text
        AppSettingHelper.GetInstance.UploadKeyJKPT = UploadKeyJKPTText.Text
#End Region

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

#Region "测试连接"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Using tmpDialog As New Wangk.Resource.BackgroundWorkDialog With {
            .Text = "测试中",
            .IsPercent = False
        }

            tmpDialog.Start(Sub(uie As Wangk.Resource.BackgroundWorkEventArgs)

                                uie.Write("生成测试数据")

                                Dim tmp = New Uploadpackage With {.Key = uie.Args(1)}
                                For i001 = 0 To 10 - 1
                                    tmp.SensorItems.Add(New UploadHardwareInfo With {
                            .CID = $"测试数据{i001 + 1}",
                            .CutterType = If(i001 Mod 2, "齿刀", "滚刀"),
                            .State = If(i001 Mod 2, "在线", "离线"),
                            .Voltage = 20 + i001 * 0.1,
                            .VoltageMinimum = 20,
                            .Sensor1Wear = i001 Mod 2,
                            .Sensor1State = If(i001 Mod 2, "转动", "静止"),
                            .Sensor2Wear = i001 Mod 2,
                            .Sensor2State = If(i001 Mod 2, "转动", "静止"),
                            .SensorWearMaximum = 40 + i001 * 0.1,
                            .UpdateTime = Now.ToString("yyyy/MM/dd HH:mm:ss")
                            })
                                    Threading.Thread.Sleep(100)
                                Next

                                uie.Write("提交测试数据")

                                uie.Result = WebAPIHelper.HttpPostData(tmp,
                                                                       uie.Args(0),
                                                                       False)

                            End Sub,
                            {
                            UploadPathJKPTText.Text,
                            UploadKeyJKPTText.Text
                            })

            If tmpDialog.Error IsNot Nothing Then
                MsgBox(tmpDialog.Error.Message, MsgBoxStyle.Critical, "连接错误")
                Exit Sub
            End If

            Dim tmpValue As ResultMsg = tmpDialog.Result
            If tmpValue.Code <> 200 Then
                MsgBox(tmpValue.Message, MsgBoxStyle.Critical, "测试失败")
                Exit Sub
            End If

            MsgBox("测试成功", MsgBoxStyle.Information, "测试连接")

        End Using

    End Sub

#End Region

End Class