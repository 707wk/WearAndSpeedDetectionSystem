Public Class SensorthresholdValueForm
    Private Sub SensorthresholdValueForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With NumericUpDown1
            .Minimum = 1
            .Maximum = 1000
            .Value = If(AppSettingHelper.Settings.WearMaximum / 10 = 0, 40, AppSettingHelper.Settings.WearMaximum / 10)
        End With
        With NumericUpDown2
            .Minimum = 1
            .Maximum = 1000
            .Value = If(AppSettingHelper.Settings.TempMaximum / 10 = 0, 100, AppSettingHelper.Settings.TempMaximum / 10)
        End With
        With NumericUpDown3
            .Minimum = 1
            .Maximum = 1000
            .Value = If(AppSettingHelper.Settings.SpeedMaximum / 10 = 0, 5, AppSettingHelper.Settings.SpeedMaximum / 10)
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AppSettingHelper.Settings.WearMaximum = NumericUpDown1.Value * 10
        AppSettingHelper.Settings.TempMaximum = NumericUpDown2.Value * 10
        AppSettingHelper.Settings.SpeedMaximum = NumericUpDown3.Value * 10

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class