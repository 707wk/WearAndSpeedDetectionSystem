Imports System.ComponentModel
Imports System.IO

Public Class EditHardwareLocationForm

    Public value As Point

    Public HardwarePointItems As List(Of Point)

    Private Background As Bitmap
    Private BackgroundGraphics As Graphics
    Private HardwareRectangle As Rectangle

    Private BoxPen As New Pen(Color.FromArgb(51, 51, 51), 1)

    Private Sub EditHardwareLocationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists(AppSettingHelper.OverviewBackgroundLocation) Then
            Background = Bitmap.FromFile(AppSettingHelper.OverviewBackgroundLocation)
            BackgroundGraphics = Graphics.FromImage(Background)
            PictureBox1.Size = Background.Size
            PictureBox1.Image = Background
        End If

        With HardwareRectangle
            .Width = 50
            .Height = 48
        End With

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        value = New Point(Val(ToolStripStatusLabel1.Text.Split(",")(0)),
                          Val(ToolStripStatusLabel1.Text.Split(",")(1)))
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        PictureBox1.Refresh()
        Dim tmpGraphics = PictureBox1.CreateGraphics
        With HardwareRectangle
            .X = e.X
            .Y = e.Y
        End With

        tmpGraphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 127, 127)),
                                         HardwareRectangle)

        ToolStripStatusLabel1.Text = $"{e.X},{e.Y}"
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim tmpDialog As New OpenFileDialog With {
            .Filter = "背景图片|*.jpg;*.bmp;*.png"
        }
        If tmpDialog.ShowDialog() <> DialogResult.OK Then
            Exit Sub
        End If

        If BackgroundGraphics IsNot Nothing Then BackgroundGraphics.Dispose()
        If Background IsNot Nothing Then Background.Dispose()

        Try
            System.IO.Directory.CreateDirectory($".\Data")
            File.Copy(tmpDialog.FileName, AppSettingHelper.OverviewBackgroundLocation, True)
            Background = Bitmap.FromFile(AppSettingHelper.OverviewBackgroundLocation)
            BackgroundGraphics = Graphics.FromImage(Background)
            PictureBox1.Size = Background.Size
            PictureBox1.Image = Background
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "导入背景图片")
        End Try

    End Sub

    Private Sub EditHardwareLocationForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If Not IO.File.Exists(AppSettingHelper.OverviewBackgroundLocation) Then
            Exit Sub
        End If

        For Each item In HardwarePointItems
            With HardwareRectangle
                .X = item.X
                .Y = item.Y
            End With
            If value = item Then
                BackgroundGraphics.FillRectangle(New SolidBrush(Color.LimeGreen),
                                                 HardwareRectangle)
            Else
                BackgroundGraphics.FillRectangle(New SolidBrush(Color.FromArgb(18, 150, 219)),
                                                 HardwareRectangle)
            End If

            BackgroundGraphics.DrawRectangle(BoxPen, HardwareRectangle)

        Next

        'With HardwareRectangle
        '    .X = value.X
        '    .Y = value.Y
        'End With

        'BackgroundGraphics.FillRectangle(New SolidBrush(Color.LimeGreen),
        '                                 HardwareRectangle)
        PictureBox1.Image = Background

    End Sub

    Private Sub EditHardwareLocationForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If BackgroundGraphics IsNot Nothing Then BackgroundGraphics.Dispose()
        If Background IsNot Nothing Then Background.Dispose()

    End Sub
End Class