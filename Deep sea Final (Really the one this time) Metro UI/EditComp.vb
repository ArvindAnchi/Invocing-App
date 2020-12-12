Public Class EditComp
    ReadOnly dt As DataTable = Main.DBOp.GetAllCompaniesList
    Private Sub Ncokbtn_Click(sender As Object, e As EventArgs) Handles ncokbtn.Click
        Console.Write(ecnamelb.SelectedValue)
        If Main.DBOp.UpdateCompanyDetails(dt.Rows(ecnamelb.SelectedIndex)(0), ecnametxt.Text, ecitytxt.Text, etrntxt.Text, eemailtxt.Text, eDiscText.Text, eAddrText.Text) Then
            MsgBox("Saved", vbOKOnly, "Saved")
            Close()
        End If
    End Sub

    Private Sub XtraForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For value As Integer = 0 To dt.Rows.Count - 1
            ecnamelb.Items.Add(dt.Rows(value)(1))
        Next
    End Sub


    Private Sub Nccnslbtn_Click(sender As Object, e As EventArgs) Handles nccnslbtn.Click
        Close()
    End Sub

    Private Function ValidateDbText(text As Object) As String
        Return If(IsDBNull(text), "", text)
    End Function

    Private Sub Ecnamelb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ecnamelb.SelectedIndexChanged

        ecnametxt.Text = ValidateDbText(dt.Rows(ecnamelb.SelectedIndex)(1))
        etrntxt.Text = ValidateDbText(dt.Rows(ecnamelb.SelectedIndex)(2))
        eDiscText.Text = ValidateDbText(dt.Rows(ecnamelb.SelectedIndex)(3))
        ecitytxt.Text = ValidateDbText(dt.Rows(ecnamelb.SelectedIndex)(4))
        eemailtxt.Text = ValidateDbText(dt.Rows(ecnamelb.SelectedIndex)(5))
        eAddrText.Text = ValidateDbText(dt.Rows(ecnamelb.SelectedIndex)(6))

    End Sub
End Class