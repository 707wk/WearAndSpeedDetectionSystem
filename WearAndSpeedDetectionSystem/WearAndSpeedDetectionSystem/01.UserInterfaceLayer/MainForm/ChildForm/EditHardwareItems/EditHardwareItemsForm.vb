Public Class EditHardwareItemsForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '输入检测
        For Each tmpRow As DataGridViewRow In DataGridView1.Rows

            If $"{tmpRow.Cells(0).Value}" = "" Then
                MsgBox($"第{tmpRow.Index + 1}行 刀具编号 不能为空", MsgBoxStyle.Information, "输入检测")
                Exit Sub
            End If

            If $"{tmpRow.Cells(1).Value}" = "" Then
                MsgBox($"第{tmpRow.Index + 1}行 设备ID 不能为空", MsgBoxStyle.Information, "输入检测")
                Exit Sub
            End If

        Next

        AppSettingHelper.Settings.HardwareItems.Clear()
        For Each tmpRow As DataGridViewRow In DataGridView1.Rows
            AppSettingHelper.Settings.HardwareItems.Add(New HardwareInfo With {
                                                        .Name = tmpRow.Cells(0).Value,
                                                        .ID = Val(tmpRow.Cells(1).Value)
                                                        })
        Next

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub EditHardwareItemsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With DataGridView1
            .BorderStyle = BorderStyle.None
            .RowHeadersVisible = False
            .AllowUserToResizeRows = True
            .AllowUserToOrderColumns = True
            .AllowUserToResizeColumns = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(&HE9, &HED, &HF4)
            .GridColor = Color.FromArgb(&HE5, &HE5, &HE5)
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical
            .ReadOnly = False
            .EditMode = DataGridViewEditMode.EditOnEnter
            .ContextMenuStrip = ContextMenuStrip1

            '启用双缓冲
            .GetType().
                GetProperty("DoubleBuffered", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).
                SetValue(DataGridView1, True, Nothing)
        End With

        For Each tmpHardware In AppSettingHelper.Settings.HardwareItems
            DataGridView1.Rows.Add({tmpHardware.Name, tmpHardware.ID})
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
        DataGridView1.Rows.Add()
    End Sub

    Private Sub 移除设备ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 移除设备ToolStripMenuItem.Click
        If DataGridView1.SelectedCells.Count = 0 Then
            Exit Sub
        End If

        DataGridView1.Rows.RemoveAt(DataGridView1.SelectedCells(0).RowIndex)

    End Sub
End Class