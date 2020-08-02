Public Class EditComp
    Dim dt As DataTable = Main.DBOp.LoadCompLST
    Private Sub ncokbtn_Click(sender As Object, e As EventArgs) Handles ncokbtn.Click
        If Main.DBOp.AddCompToDB(ecnametxt.Text, ecitytxt.Text, etrntxt.Text, eemailtxt.Text, eDiscText.Text) Then
            MsgBox("Saved", vbOKOnly, "Saved")
            Close()
        End If
    End Sub

    Private Sub XtraForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For value As Integer = 0 To dt.Rows.Count - 1
            ecnamelb.Items.Add(dt.Rows(value)(1))
        Next
    End Sub


    Private Sub nccnslbtn_Click(sender As Object, e As EventArgs) Handles nccnslbtn.Click
        Close()
    End Sub

    Private Sub ecnamelb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ecnamelb.SelectedIndexChanged
        ecnametxt.Text = dt.Rows(ecnamelb.SelectedIndex)(1)
        etrntxt.Text = dt.Rows(ecnamelb.SelectedIndex)(2)
        eDiscText.Text = dt.Rows(ecnamelb.SelectedIndex)(3)
        ecitytxt.Text = dt.Rows(ecnamelb.SelectedIndex)(4)
        eemailtxt.Text = dt.Rows(ecnamelb.SelectedIndex)(5)
    End Sub
End Class