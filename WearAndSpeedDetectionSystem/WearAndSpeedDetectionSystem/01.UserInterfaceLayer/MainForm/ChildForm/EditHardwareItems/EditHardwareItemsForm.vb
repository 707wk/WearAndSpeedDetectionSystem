Imports Wangk.Resource

Public Class EditHardwareItemsForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AddOrSaveButton.Click

        '输入检测
        For Each tmpRow As DataGridViewRow In DataGridView1.Rows

            If $"{tmpRow.Cells(1).Value}" = "" Then
                MsgBox($"第{tmpRow.Index + 1}行 刀具编号 不能为空", MsgBoxStyle.Information, "输入检测")
                Exit Sub
            End If

            If $"{tmpRow.Cells(2).Value}" = "" Then
                MsgBox($"第{tmpRow.Index + 1}行 设备ID 不能为空", MsgBoxStyle.Information, "输入检测")
                Exit Sub
            End If

        Next

        AppSettingHelper.GetInstance.WallThicknessHardwareID = NumericUpDown1.Value

        AppSettingHelper.GetInstance.HardwareItems.Clear()
        For Each tmpRow As DataGridViewRow In DataGridView1.Rows

            Dim tmpPoint As New Point(Val(tmpRow.Cells(6).Value.Split(",")(0)), Val(tmpRow.Cells(6).Value.Split(",")(1)))

            Dim tmpAddHardwareInfo = New HardwareInfo With {
                .Name = tmpRow.Cells(1).Value,
                .ID = Val(tmpRow.Cells(2).Value),
                .IsSerratedKnife = tmpRow.Cells(3).Value,
                .Location = tmpPoint
            }
            tmpAddHardwareInfo.WearCalibrationValue(0) = Val(tmpRow.Cells(4).Value)
            tmpAddHardwareInfo.WearCalibrationValue(1) = Val(tmpRow.Cells(5).Value)

            AppSettingHelper.GetInstance.HardwareItems.Add(tmpAddHardwareInfo)
        Next

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Close()
    End Sub

    Private Sub EditHardwareItemsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With DataGridView1
            .BorderStyle = BorderStyle.None
            .RowHeadersVisible = True
            .RowHeadersWidth = 62

            .AllowUserToResizeRows = True
            .AllowUserToOrderColumns = True
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.CellSelect
            .MultiSelect = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(&HE9, &HED, &HF4)
            .GridColor = Color.FromArgb(&HE5, &HE5, &HE5)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
            .ReadOnly = False
            .EditMode = DataGridViewEditMode.EditOnEnter

            .RowTemplate.Height = 30

            ''启用双缓冲
            '.GetType().
            '    GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).
            '    SetValue(DataGridView1, True, Nothing)
        End With

        NumericUpDown1.Value = AppSettingHelper.GetInstance.WallThicknessHardwareID

        For Each tmpHardware In AppSettingHelper.GetInstance.HardwareItems
            With tmpHardware
                DataGridView1.Rows.Add({False,
                                       .Name,
                                       .ID,
                                       .IsSerratedKnife,
                                       .WearCalibrationValue(0),
                                       .WearCalibrationValue(1),
                                       $"{ .Location.X},{ .Location.Y}",
                                       "修改显示位置"})
            End With
        Next
    End Sub

    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
        If e.Button <> MouseButtons.Right OrElse
            e.RowIndex < 0 OrElse
            e.ColumnIndex < 0 OrElse
            DataGridView1.SelectedRows.Count > 1 Then
            Exit Sub
        End If

        With DataGridView1
            .CurrentCell = .Rows(e.RowIndex).Cells(e.ColumnIndex)
        End With
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        DataGridView1.Rows.Add({False, "", "", False, 0, 0, "0,0", "修改显示位置"})
    End Sub

    'Private Sub 移除设备ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移除设备ToolStripMenuItem.Click
    '    If DataGridView1.SelectedCells.Count = 0 Then
    '        Exit Sub
    '    End If

    '    DataGridView1.Rows.RemoveAt(DataGridView1.SelectedCells(0).RowIndex)

    'End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        '删除
        For rowID = DataGridView1.Rows.Count - 1 To 0 Step -1
            If DataGridView1.Rows(rowID).Cells(0).EditedFormattedValue Then
                DataGridView1.Rows.RemoveAt(rowID)
            End If
        Next
    End Sub

#Region "编辑位置"
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If DataGridView1.Columns(e.ColumnIndex).Name <> "Column4" Then Exit Sub
        If e.RowIndex < 0 Then Exit Sub

        Dim tmpPoint As New Point(Val(DataGridView1.Rows(e.RowIndex).Cells(6).Value.Split(",")(0)),
                                  Val(DataGridView1.Rows(e.RowIndex).Cells(6).Value.Split(",")(1)))

        Dim tmpList As New List(Of Point)
        For Each item In DataGridView1.Rows
            tmpList.Add(New Point(Val(item.Cells(6).Value.Split(",")(0)),
                                  Val(item.Cells(6).Value.Split(",")(1))))
        Next

        Using tmpDialog As New EditHardwareLocationForm With {
            .value = tmpPoint,
            .HardwarePointItems = tmpList
        }

            If tmpDialog.ShowDialog() <> DialogResult.OK Then
                Exit Sub
            End If

            DataGridView1.Rows(e.RowIndex).Cells(6).Value = $"{tmpDialog.value.X},{tmpDialog.value.Y}"

        End Using

    End Sub

#End Region
End Class