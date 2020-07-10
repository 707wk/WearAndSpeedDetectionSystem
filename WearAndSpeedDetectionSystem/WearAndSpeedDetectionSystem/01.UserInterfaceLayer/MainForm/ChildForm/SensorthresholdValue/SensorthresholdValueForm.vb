Public Class SensorthresholdValueForm
    Private Sub SensorthresholdValueForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With NumericUpDown1
            .Minimum = 1
            .Maximum = 1000
            .Value = If(AppSettingHelper.GetInstance.WearMaximum / 10 = 0, 40, AppSettingHelper.GetInstance.WearMaximum / 10)
        End With
        With NumericUpDown2
            .Minimum = 1
            .Maximum = 1000
            .Value = If(AppSettingHelper.GetInstance.TempMaximum / 10 = 0, 100, AppSettingHelper.GetInstance.TempMaximum / 10)
        End With
        With NumericUpDown3
            .Minimum = 1
            .Maximum = 1000
            .Value = If(AppSettingHelper.GetInstance.SpeedMaximum / 10 = 0, 5, AppSettingHelper.GetInstance.SpeedMaximum / 10)
        End With

        With NumericUpDown4
            .Minimum = 1
            .Maximum = 1000
            .Value = If(AppSettingHelper.GetInstance.BatteryVoltageMinimum = 0, 22, AppSettingHelper.GetInstance.BatteryVoltageMinimum)
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddOrSaveButton.Click
        AppSettingHelper.GetInstance.WearMaximum = NumericUpDown1.Value * 10
        AppSettingHelper.GetInstance.TempMaximum = NumericUpDown2.Value * 10
        AppSettingHelper.GetInstance.SpeedMaximum = NumericUpDown3.Value * 10
        AppSettingHelper.GetInstance.BatteryVoltageMinimum = NumericUpDown4.Value

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub
End Class