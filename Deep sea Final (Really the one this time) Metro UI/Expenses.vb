Imports ExcelInterop = Microsoft.Office.Interop.Excel

Public Class Expenses
    Private expDataTeable As DataTable
    Private clickToFillFlag As Boolean = False
    Private Sub Expenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = New DateTime(Today.Year, Today.Month - 3, 1, 0, 0, 0)
        DateTimePicker2.Value = New DateTime(Today.Year, Today.Month - 1, Date.DaysInMonth(Today.Year, Today.Month - 1), 0, 0, 0)
        expDataTeable = Main.DBOp.GetExpenses
        ExpDGV.DataSource = expDataTeable
        ExpDGV.ClearSelection()
        For Each Ctrl In Controls
            If TryCast(Ctrl, TextBox) IsNot Nothing Then
                Ctrl.text = String.Empty
            End If
        Next
        SetDGVFillWeight(ExpDGV, {30, 30, 100, 50, 30, 30, 30})
        If ExpDGV.RowCount > 0 Then
            If ExpDGV.RowCount > 11 Then
                For Each Line As FLine In {FLine1, FLine2, FLine3, FLine4, FLine5, FLine6, FLine8, FLine9}
                    Line.Hide() '5,1,7
                Next
            End If
        End If
        ToolStripStatusLabel1.Text = "Records: " & ExpDGV.RowCount &
                    " Total: " & expDataTeable.Compute("SUM([Final amount])", expDataTeable.DefaultView.RowFilter).ToString &
                    " VAT: " & expDataTeable.Compute("SUM(VAT)", expDataTeable.DefaultView.RowFilter).ToString

    End Sub

    Private Sub Aeclrlbtn_Click(sender As Object, e As EventArgs) Handles aeclrlbtn.Click
        For Each Ctrl In Controls
            If TryCast(Ctrl, TextBox) IsNot Nothing Then
                Ctrl.text = String.Empty
            End If
        Next
        aedtpicker.Value = Today
    End Sub

    Private Sub Aeaddbtn_Click(sender As Object, e As EventArgs) Handles aeaddbtn.Click

        Main.DBOp.AddExpenses(Me)
        ExpDGV.DataSource = Main.DBOp.GetExpenses
        If FLine1.Visible AndAlso ExpDGV.RowCount > 0 Then
            If ExpDGV.RowCount > 11 Then
                For Each Line As FLine In {FLine1, FLine2, FLine3, FLine4, FLine5, FLine6, FLine8, FLine9}
                    Line.Hide()
                Next
            End If
        End If
        aereftxt.Focus()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim excel As ExcelInterop._Application = New ExcelInterop.Application()
        Dim workbook As ExcelInterop._Workbook = excel.Workbooks.Add(Type.Missing)
        Dim worksheet As ExcelInterop._Worksheet = Nothing

        Try

            worksheet = workbook.ActiveSheet
            worksheet.Name = "Sales table"

            Dim CellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1

            For J As Integer = 0 To ExpDGV.ColumnCount - 1
                worksheet.Cells(CellRowIndex, cellColumnIndex) = ExpDGV.Columns(J).HeaderText
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            CellRowIndex += 1

            For i As Integer = 0 To ExpDGV.Rows.Count - 1
                For J As Integer = 0 To ExpDGV.ColumnCount - 1
                    worksheet.Cells(CellRowIndex, cellColumnIndex) = ExpDGV.Rows(i).Cells(J).Value
                    cellColumnIndex += 1
                Next
                cellColumnIndex = 1
                CellRowIndex += 1
            Next

            worksheet.Rows("1:1").Font.FontStyle = "Bold"
            worksheet.Rows("1:1").HorizontalAlignment = ExcelInterop.Constants.xlLeft
            worksheet.Columns("A:I").VerticalAlignment = ExcelInterop.Constants.xlCenter
            worksheet.Columns("A:I").HorizontalAlignment = ExcelInterop.Constants.xlLeft
            worksheet.Columns("D").NumberFormat = "0"
            worksheet.Columns("G").NumberFormat = "0.00"
            worksheet.Columns("H").NumberFormat = "0.00"
            worksheet.Columns("I").NumberFormat = "0.00"

            worksheet.Cells.Columns.AutoFit()
            worksheet.Cells.Select()
            worksheet.Cells.EntireColumn.AutoFit()
            worksheet.Cells(1, 1).Select()

            Dim SaveDialog As New SaveFileDialog With {
                .Filter = "Excel Files(*.xlsx)|*.xlsx|All files (*.*)|*.*",
                .FilterIndex = 1
            }

            If SaveDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                workbook.SaveAs(SaveDialog.FileName)
                Process.Start(SaveDialog.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            excel.Quit()

            releaseObject(excel)
            releaseObject(workbook)
            releaseObject(worksheet)
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Filter()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Filter()
    End Sub

    Private Sub Filter()
        If ExpDGV.RowCount > 0 Then
            Dim dataView As DataView = expDataTeable.DefaultView
            dataView.RowFilter = String.Format("[Date] >= '{0}' And [Date] <= '{1}'",
                                               DateTimePicker1.Value, DateTimePicker2.Value)
            ExpDGV.DataSource = dataView
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DateTimePicker1.Value = New DateTime(Today.Year, Today.Month - 3, 1, 0, 0, 0)
        DateTimePicker2.Value = New DateTime(Today.Year, Today.Month - 1, Date.DaysInMonth(Today.Year, Today.Month - 1), 0, 0, 0)
    End Sub

    Private Sub Aereftxt_GotFocus(sender As Object, e As EventArgs) Handles aereftxt.GotFocus
        aereftxt.SelectAll()
    End Sub

    Private Sub Aecomptxt_GotFocus(sender As Object, e As EventArgs) Handles aecomptxt.GotFocus
        aecomptxt.SelectAll()
    End Sub

    Private Sub Aeammounttxt_GotFocus(sender As Object, e As EventArgs) Handles aeammounttxt.GotFocus
        aeammounttxt.SelectAll()
    End Sub

    Private Sub Aetrntxt_GotFocus(sender As Object, e As EventArgs) Handles aetrntxt.GotFocus
        aetrntxt.SelectAll()
    End Sub

    Private Sub ExpDGV_SelectionChanged(sender As Object, e As EventArgs) Handles ExpDGV.SelectionChanged

        If clickToFillFlag AndAlso ExpDGV.SelectedRows.Count > 0 Then
            aereftxt.Text = ExpDGV.SelectedRows(0).Cells(0).Value
            aedtpicker.Value = ExpDGV.SelectedRows(0).Cells(1).Value
            aetrntxt.Text = ExpDGV.SelectedRows(0).Cells(3).Value
            aecomptxt.Text = ExpDGV.SelectedRows(0).Cells(2).Value
            aeammounttxt.Text = ExpDGV.SelectedRows(0).Cells(6).Value
        End If

        'Id AS [Reference Number],
        'Date As [Date],
        'Supplier AS [Supplier Name],
        'Trn As [TRN Number],
        'CAST(Amount - (Amount / (100 / 5 + 1)) As numeric(9, 2)) As [Amount before VAT],
        'CAST(Amount / (100 / 5 + 1) As numeric(9, 2)) As [VAT],
        'CAST(Amount As numeric(9, 2)) As [Final amount]

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        clickToFillFlag = CheckBox1.Checked
    End Sub
End Class