Public Class VATReport
    Private Sub VATReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Using dt As DataTable = Main.DBOp.GetVATReport(VATSDateDTP.Value, VATEDateDTP.Value)
            Dim dataView As DataView = dt.DefaultView

            VatDGV.DataSource = dt

            AmmountDetailsLbl.Text = "Net Total: " & dt.Compute("SUM([Net total])", dataView.RowFilter) &
                " VAT: " & dt.Compute("SUM([VAT])", dataView.RowFilter) &
                " Grand total: " & dt.Compute("SUM([Grand total])", dataView.RowFilter)
        End Using
    End Sub

    Private Sub VATSDateDTP_ValueChanged(sender As Object, e As EventArgs) Handles VATSDateDTP.ValueChanged
        Using dt As DataTable = Main.DBOp.GetVATReport(VATSDateDTP.Value, VATEDateDTP.Value)
            Dim dataView As DataView = dt.DefaultView

            VatDGV.DataSource = dt

            AmmountDetailsLbl.Text = "Net Total: " & dt.Compute("SUM([Net total])", dataView.RowFilter) &
                " VAT: " & dt.Compute("SUM([VAT])", dataView.RowFilter) &
                " Grand total: " & dt.Compute("SUM([Grand total])", dataView.RowFilter)
        End Using
    End Sub
End Class