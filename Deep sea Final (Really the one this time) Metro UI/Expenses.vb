Public Class Expenses
    Private Sub ExpDGV_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles ExpDGV.CellEnter
        If e.RowIndex <> -1 Then
            ExpDGV.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
            If e.RowIndex > 11 Then
                For Each Line As FLine In {FLine1, FLine2, FLine4}
                    Line.Hide()
                Next
            End If
        End If
    End Sub 'Hide lines when necessary

    Private Sub Expenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ExpDGV.DataSource = Main.DBOp.GetExpenses
        Autoweight(ExpDGV, {30, 100, 30, 30})

    End Sub

    Private Sub aeclrlbtn_Click(sender As Object, e As EventArgs) Handles aeclrlbtn.Click
        For Each Ctrl In Controls
            If TryCast(Ctrl, TextBox) IsNot Nothing Then
                Ctrl.text = String.Empty
            End If
        Next
        aedtpicker.Value = Today
    End Sub

    Private Sub aeaddbtn_Click(sender As Object, e As EventArgs) Handles aeaddbtn.Click
        Dim IstbEmp As Boolean = False
        For Each Ctrl In Controls
            If TryCast(Ctrl, TextBox) IsNot Nothing Then
                If String.IsNullOrEmpty(TryCast(Ctrl, TextBox).Text) Then
                    IstbEmp = True
                    Ctrl.Focus
                End If
            End If
        Next
        If Not IstbEmp Then
            Main.DBOp.AddExpenses(Me)
            For Each Ctrl In Controls
                If TryCast(Ctrl, TextBox) IsNot Nothing Then
                    Ctrl.text = String.Empty
                End If
            Next
            ExpDGV.DataSource = Main.DBOp.GetExpenses
        End If
    End Sub
End Class