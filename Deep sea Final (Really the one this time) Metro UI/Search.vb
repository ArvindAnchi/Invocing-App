Public Class Search
    Public mainfrm As Main
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Close()
    End Sub

    Private Sub SrchBtn_Click(sender As Object, e As EventArgs) Handles SrchBtn.Click
        Using dt As DataTable = mainfrm.DBOp.LoadInvoicesDGV()
            Dim searchtbtext As String = ""
            Dim dataView As DataView = dt.DefaultView
            Dim lastindex = DataGridView1.RowCount - 2
            If lastindex > 0 Then
                searchtbtext += "("
                If CheckBox1.Checked And Not CheckBox2.Checked Then
                    searchtbtext += "Invoice number is "
                ElseIf CheckBox2.Checked And Not CheckBox1.Checked Then
                    searchtbtext += "LPO number is "
                End If
                For i As Integer = 0 To lastindex
                    If CheckBox1.Checked And Not CheckBox2.Checked Then
                        Main.FilterString += String.Format("(CONVERT([Invoice Number], System.String) = '{0}')", DataGridView1.Rows(i).Cells(0).Value)
                    ElseIf CheckBox2.Checked And Not CheckBox1.Checked Then
                        Main.FilterString += String.Format("CONVERT([LPO Number], System.String) like '%{0}%')", DataGridView1.Rows(i).Cells(0).Value)
                    ElseIf CheckBox2.Checked And CheckBox1.Checked Then
                        Main.FilterString += String.Format("(CONVERT([Invoice Number], System.String) = '{0}' OR CONVERT([LPO Number], System.String) like '%{0}%')", DataGridView1.Rows(i).Cells(0).Value)
                    End If
                    searchtbtext += DataGridView1.Rows(i).Cells(0).Value
                    If i < lastindex Then
                        Main.FilterString += " OR "
                        searchtbtext += " Or "
                    End If
                Next
                searchtbtext += ")"
            End If
            Main.ISearchTB.Text = searchtbtext
        End Using
        Close()
    End Sub
End Class