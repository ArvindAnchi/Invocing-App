Public Class AddComp
    Private Sub Ncokbtn_Click(sender As Object, e As EventArgs) Handles ncokbtn.Click
        If MsgBox("Add Company " & ncnametxt.Text & "?", vbYesNo) = vbYes Then
            If Main.DBOp.AddNewCompany(ncnametxt.Text, ncitytxt.Text, ntrntxt.Text, nemailtxt.Text, nDiscText.Text, nAddrText.Text) Then
                MsgBox("Saved", vbOKOnly, "Saved")
                Close()
            End If
        End If
    End Sub

    Private Sub Nccnslbtn_Click(sender As Object, e As EventArgs) Handles nccnslbtn.Click
        Close()
    End Sub
End Class