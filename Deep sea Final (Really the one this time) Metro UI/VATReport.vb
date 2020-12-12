Imports ExcelInterop = Microsoft.Office.Interop.Excel

Public Class VATReport
    Private Sub VATReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VATSDateDTP.Value = New DateTime(Today.Year, Today.Month - 3, 1, 0, 0, 0)
        VATEDateDTP.Value = New DateTime(Today.Year, Today.Month - 1, Date.DaysInMonth(Today.Year, Today.Month - 1), 0, 0, 0)

        Using dt As DataTable = Main.DBOp.GetInvoiceDetailsForVAT(VATSDateDTP.Value, VATEDateDTP.Value)
            Dim dataView As DataView = dt.DefaultView

            VatDGV.DataSource = dt

            With VatDGV
                .Columns(0).FillWeight = 14.29
                .Columns(1).FillWeight = 48.57
                .Columns(2).FillWeight = 8.29
                .Columns(3).FillWeight = 15.43
                .Columns(4).FillWeight = 7.71
                .Columns(5).FillWeight = 20
                .Columns(6).FillWeight = 8.14
                .Columns(7).FillWeight = 4.86
                .Columns(8).FillWeight = 10.29
            End With

            AmmountDetailsLbl.Text = "Net Total: " & dt.Compute("SUM([Net total])", dataView.RowFilter) &
                " VAT: " & dt.Compute("SUM([VAT])", dataView.RowFilter) &
                " Grand total: " & dt.Compute("SUM([Grand total])", dataView.RowFilter)
        End Using
    End Sub

    Private Sub VATSDateDTP_ValueChanged(sender As Object, e As EventArgs) Handles VATSDateDTP.ValueChanged, VATEDateDTP.ValueChanged
        Using dt As DataTable = Main.DBOp.GetInvoiceDetailsForVAT(VATSDateDTP.Value, VATEDateDTP.Value)
            Dim dataView As DataView = dt.DefaultView

            VatDGV.DataSource = dt

            AmmountDetailsLbl.Text = "Net Total: " & dt.Compute("SUM([Net total])", dataView.RowFilter) &
                " VAT: " & dt.Compute("SUM([VAT])", dataView.RowFilter) &
                " Grand total: " & dt.Compute("SUM([Grand total])", dataView.RowFilter)
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim excel As ExcelInterop._Application = New ExcelInterop.Application()
        Dim workbook As ExcelInterop._Workbook = excel.Workbooks.Add(Type.Missing)
        Dim worksheet As ExcelInterop._Worksheet = Nothing

        Try

            worksheet = workbook.ActiveSheet
            worksheet.Name = "VAT Report"

            Dim CellRowIndex As Integer = 1
            Dim cellColumnIndex As Integer = 1

            For J As Integer = 0 To VatDGV.ColumnCount - 1
                worksheet.Cells(CellRowIndex, cellColumnIndex) = VatDGV.Columns(J).HeaderText
                cellColumnIndex += 1
            Next
            cellColumnIndex = 1
            CellRowIndex += 1

            For i As Integer = 0 To VatDGV.Rows.Count - 1
                For J As Integer = 0 To VatDGV.ColumnCount - 1
                    worksheet.Cells(CellRowIndex, cellColumnIndex) = VatDGV.Rows(i).Cells(J).Value
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

            Dim SaveDialog As New SaveFileDialog()
            SaveDialog.Filter = "Excel Files(*.xlsx)|*.xlsx|All files (*.*)|*.*"
            SaveDialog.FilterIndex = 1

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
    Private Sub releaseObject(ByVal obj As Object)
        Try
            Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class