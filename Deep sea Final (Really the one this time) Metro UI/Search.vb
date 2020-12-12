Public Class Search
    Public mainfrm As Main
    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Close()
    End Sub

    Private Sub SrchBtn_Click(sender As Object, e As EventArgs) Handles SrchBtn.Click
        Using dt As DataTable = mainfrm.DBOp.GetInvoiceListToPopulateInvoiceDGV()
            Dim searchtbtext As String = ""
            Dim dataView As DataView = dt.DefaultView
            Dim lastindex = DataGridView1.RowCount - 2
            If lastindex > 0 Then
                searchtbtext += "("
                If CheckBox1.Checked And Not CheckBox2.Checked Then
                    searchtbtext += "Invoice number = ["
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
                        searchtbtext += ", "
                    End If
                Next
                searchtbtext += "])"
            End If
            Main.ISearchTB.Text = searchtbtext
        End Using
        Close()
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            Try
                For Each line As String In Clipboard.GetText.Split(vbNewLine)
                    If Not line.Trim.ToString = "" Then
                        Dim item() As String = line.Trim.Split(vbTab)
                        DataGridView1.Rows.Add(item)
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

End Class