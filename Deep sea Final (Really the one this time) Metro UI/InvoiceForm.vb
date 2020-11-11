Imports System.ComponentModel
Imports System.IO

Public Class InvoiceForm
    Private WithEvents EditControl As DataGridViewTextBoxEditingControl 'you need this declared in your other app
    Public InvoiceFlagList As New DataTable
    Dim dt As DataTable = Main.DBOp.LoadCompLST
    Dim flags As String() = File.ReadAllLines(Application.StartupPath + "\Flags")
    Public term As Integer = 30

    Private Sub InvoiceForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        AllowDrop = True
        If DGV1.RowCount > 13 Then
            For Each Line As FLine In {FLine1, FLine2, FLine4, FLine6, FLine7, FLine8, FLine9}
                Line.Hide()
            Next
        End If
        If Not String.IsNullOrEmpty(cnametxt.Text) Then
            Ordbycb.Items.Clear()
            For Each item In Main.DBOp.LoadOrdByName(cnametxt.Text).Rows
                Ordbycb.Items.Add(item(0))
            Next
        End If
        SaveRibBtn.Enabled = False
        For value As Integer = 0 To dt.Rows.Count - 1
            cnametxt.Items.Add(dt.Rows(value)(1))
        Next
    End Sub
    Private Sub Cnametxt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cnametxt.SelectedIndexChanged

        If (dt.Rows(cnametxt.SelectedIndex)(2) IsNot DBNull.Value) Then
            trntxt.Text = dt.Rows(cnametxt.SelectedIndex)(2)
            disctxt.Text = Math.Floor(dt.Rows(cnametxt.SelectedIndex)(3))
        Else
            trntxt.Text = ""
        End If


        If Not cnametxt.Items.Contains(cnametxt.Text) Then

            If MsgBox("Add new company " & cnametxt.Text & "?", vbYesNo, "Add company") = vbYes Then
                Using addcmp As New AddComp
                    addcmp.ShowDialog()
                End Using
                dt = Main.DBOp.LoadCompLST
                trntxt.Text = dt.Rows(cnametxt.SelectedIndex)(2)
                disctxt.Text = Math.Floor(dt.Rows(cnametxt.SelectedIndex)(3))
            End If

        Else
            Ordbycb.Items.Clear()
            For Each item In Main.DBOp.LoadOrdByName(cnametxt.Text).Rows
                Ordbycb.Items.Add(item(0))
            Next
        End If

        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If

    End Sub

    Private Sub InvoiceForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        InvoiceFlagList.Dispose()
        dt.Dispose()
        With Main
            .RefreshDGVthread()
            .ISearchTB.Clear()
            .ISDateDTP.Value = CDate("1/1/2020")
            .IEDateDTP.Value = Today
            Dim dataView As DataView = .InvoicesDataTable.DefaultView
            .InvoicesDGV.DataSource = dataView
            dataView.RowFilter = ""
            .BarStaticItem1.Caption = "Records: " & .InvoicesDGV.RowCount &
                        " Total: " & .InvoicesDataTable.Compute("SUM(Total)", dataView.RowFilter).ToString &
                        " VAT: " & .InvoicesDataTable.Compute("SUM(VAT)", dataView.RowFilter).ToString
        End With
    End Sub

    Private Sub Main_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Or e.Data.GetDataPresent("FileGroupDescriptor") Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub InvoiceForm_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim pathoffile As String = ""
        'MsgBox(e.Data.GetDataPresent("FileGroupDescriptor"))
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String

            ' Assign the files to an array.
            MyFiles = TryCast(e.Data.GetData(DataFormats.FileDrop), String())
            'If there are more than one file, set first only
            'If you want another restrictment, please edit this.
            pathoffile = MyFiles(0)
        ElseIf e.Data.GetDataPresent("FileGroupDescriptor") Then
            ' We have a embedded file. First lets try to get the file name out of memory
            Dim theStream As IO.Stream = CType(e.Data.GetData("FileGroupDescriptor"), IO.Stream)
            Dim fileGroupDescriptor(512) As Byte
            theStream.Read(fileGroupDescriptor, 0, 512)
            Dim fileName As System.Text.StringBuilder = New System.Text.StringBuilder("")
            Dim i As Integer = 76
            While Not (fileGroupDescriptor(i) = 0)
                fileName.Append(Convert.ToChar(fileGroupDescriptor(i)))
                System.Math.Min(System.Threading.Interlocked.Increment(i), i - 1)
            End While
            theStream.Close()
            ' We should have the file name or if its a email the subject line. Create our temp file based on the temp path and this info
            pathoffile = "C:\Users\Arvind\AppData\Local\Microsoft\Windows\INetCache\Content.Outlook\Y01PTS19\" & fileName.ToString
        End If
        If Not String.IsNullOrEmpty(pathoffile) Then

            If pathoffile.ToUpper.Contains("XLS") Then
                Readmefexcel(Me, pathoffile)
            ElseIf pathoffile.ToUpper.Contains("PDF") Then
                ReadPDF(Me, pathoffile)
            End If
            'End If
        End If
    End Sub
    Private Sub ButtonItem18_Click(sender As Object, e As EventArgs) Handles PrintPrevRibBtn.Click
        If DGV1.RowCount > 1 Then
            Using printprev As New PrintPreview
                printprev.InvoiceForm = Me
                printprev.ShowDialog()
            End Using
        Else
            MsgBox("Flag list is empty")
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles TrmCash.CheckedChanged
        If TrmCash.Checked Then
            TermTXT.Text = 0
            TermTXT.Enabled = False
        Else
            TermTXT.Enabled = True
            TermTXT.Text = term
        End If

        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub


    Private Sub ButtonItem14_Click(sender As Object, e As EventArgs) Handles SaveRibBtn.Click
        If DGV1.RowCount > 1 Then
            If Main.DBOp.WriteInvoice(Me) Then
                SaveRibBtn.ImageOptions.SvgImage = My.Resources.actions_checkcircled
                SaveRibBtn.Enabled = False
            End If
            RefreshDGV()
            Using invfrm As New InvoiceForm
                FillInvoiceData(Me)
                invfrm.SaveRibBtn.ImageOptions.SvgImage = My.Resources.actions_checkcircled
                invfrm.SaveRibBtn.Enabled = False
            End Using
        Else
            MsgBox("Flag list is empty")
        End If
    End Sub

    'Private Sub ButtonItem15_Click(sender As Object, e As EventArgs) Handles DiscardRibBtn.Click
    '    Close()
    'End Sub

    Private Sub DGV1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellValueChanged

        Try
            If e.RowIndex <> -1 Then
                'calculate the total from price And quantity
                If CDbl(DGV1.Rows(e.RowIndex).Cells(3).Value) > 0 And CDbl(DGV1.Rows(e.RowIndex).Cells(4).Value) > 0 Then

                    DGV1.Rows(e.RowIndex).Cells(5).Value = CDbl(DGV1.Rows(e.RowIndex).Cells(3).Value) * CDbl(DGV1.Rows(e.RowIndex).Cells(4).Value)

                End If

            End If
            If DGV1.Rows(0).Cells(3).Value IsNot Nothing AndAlso DGV1.Rows(0).Cells(4).Value IsNot Nothing Then
                Dim total As Double = 0
                Dim disc As Double = 0

                For Each row As DataGridViewRow In DGV1.Rows
                    total += CDbl(row.Cells(5).Value)

                Next
                disc = total * CInt(disctxt.Text) / 100
                prcnos.Text = FormatNumber(total) & vbNewLine &
                FormatNumber(disc) & vbNewLine &
                FormatNumber(total - disc) & vbNewLine &
                If(VatCB.Checked, FormatNumber((total - disc) * 5 / 100), FormatNumber(0)) & vbNewLine &
                If(VatCB.Checked, FormatNumber((total - disc) + ((total - disc) * 5 / 100)), FormatNumber(total - disc))
            End If

            With DGV1
                .Columns(4).DefaultCellStyle.Format = "0.00"
                .Columns(5).DefaultCellStyle.Format = "0.00"
            End With

        Catch ex As Exception
            'MsgBox(ex.ToString)
            If String.IsNullOrEmpty(disctxt.Text) Then
                disctxt.Text = 0
                disctxt.SelectAll()
            End If
        End Try

        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub
    Private Sub Disctxt_TextChanged(sender As Object, e As EventArgs) Handles disctxt.TextChanged
        Try
            Dim total As Double = 0
            Dim disc As Double = 0
            For Each row As DataGridViewRow In DGV1.Rows
                If DGV1.Rows(0).Cells(3).Value IsNot Nothing AndAlso DGV1.Rows(0).Cells(4).Value IsNot Nothing Then
                    'calculate the total from price And quantity
                    If CDbl(DGV1.Rows(row.Index).Cells(3).Value) > 0 And CDbl(DGV1.Rows(row.Index).Cells(4).Value) > 0 Then

                        DGV1.Rows(row.Index).Cells(5).Value = CDbl(DGV1.Rows(row.Index).Cells(3).Value) * CDbl(DGV1.Rows(row.Index).Cells(4).Value)

                    End If

                    total += CDbl(row.Cells(5).Value)

                End If
            Next
            disc = total * CInt(disctxt.Text) / 100

            With DGV1
                .Columns(4).DefaultCellStyle.Format() = "0.00"
                .Columns(5).DefaultCellStyle.Format() = "0.00"
            End With

            prcnos.Text = FormatNumber(total) & vbNewLine &
                FormatNumber(disc) & vbNewLine &
                FormatNumber(total - disc) & vbNewLine &
                If(VatCB.Checked, FormatNumber((total - disc) * 5 / 100), FormatNumber(0)) & vbNewLine &
                If(VatCB.Checked, FormatNumber((total - disc) + ((total - disc) * 5 / 100)), FormatNumber(total - disc))

        Catch ex As Exception
            disctxt.Text = 0
            disctxt.SelectAll()
        End Try

        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If

    End Sub

    Private Sub DGV1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DGV1.EditingControlShowing
        If EditControl Is Nothing AndAlso DGV1.CurrentCell.ColumnIndex = 1 Then '4 should be the 5th column
            EditControl = DirectCast(e.Control, DataGridViewTextBoxEditingControl)
            AddHandler EditControl.PreviewKeyDown, AddressOf TextBox_PreviewKeyDown
        End If
    End Sub

    Private Sub TextBox_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs)
        If e.KeyCode = Keys.Space Then
            If AutoCompleteLB.Items.Count > 0 Then
                AutoCompleteLB.SelectedIndex = 0
                Dim ec As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
                Dim Total As String = ec.Text
                If Total.ToString.IndexOf(" ") >= 0 Then
                    ec.Text = Total.ToString.Substring(0, Total.ToString.LastIndexOf(" ") + 1) & AutoCompleteLB.SelectedItem.ToString()
                Else
                    ec.Text = AutoCompleteLB.SelectedItem.ToString()
                End If
                AutoCompleteLB.Items.Clear()
                ec.SelectionStart = ec.TextLength + 1
            End If
        End If
    End Sub

    Private Sub EditControl_Leave(sender As Object, e As EventArgs) Handles EditControl.Leave
        EditControl = Nothing
    End Sub
    Private Sub EditControl_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EditControl.TextChanged
        Dim ec As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
        Dim Total As String = ec.Text
        Dim lastword As String
        If Total.ToString.IndexOf(" ") >= 0 Then
            lastword = Total.ToString.Substring(Total.ToString.IndexOf(" ") + 1)
        Else
            lastword = Total.ToString
        End If
        AutoCompleteLB.Items.Clear()
        For Each flag In flags
            If flag.ToUpper.StartsWith(lastword.ToUpper) AndAlso lastword IsNot "" Then
                AutoCompleteLB.Items.Add(flag)
            End If
        Next



        If AutoCompleteLB.Items.Count > 0 Then
            AutoCompleteLB.Visible = True
        Else
            AutoCompleteLB.Visible = False
        End If
    End Sub

    Private Function GetIntValue(StrValue As String) As Integer
        Dim tmp As Integer = 0
        Integer.TryParse(StrValue, tmp)
        Return tmp
    End Function

    Private Sub DGV1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellEnter
        If e.RowIndex <> -1 Then
            DGV1.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
            If e.RowIndex > 11 Then
                For Each Line As FLine In {FLine1, FLine2, FLine4, FLine6, FLine7, FLine8, FLine9}
                    Line.Hide()
                Next
            End If
        End If
    End Sub

    Private Sub DGV1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DGV1.CellBeginEdit
        If e.ColumnIndex = 1 Then
            Dim RowHeight1 As Integer = DGV1.Rows(e.RowIndex).Height
            Dim CellRectangle1 As Rectangle = DGV1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)

            CellRectangle1.X += DGV1.Left
            CellRectangle1.Y += DGV1.Top + RowHeight1

            Dim CurLoc As Point = PointToScreen(New Point(CellRectangle1.X - 267, CellRectangle1.Y - 135))

            AutoCompleteLB.Location = CurLoc
            AutoCompleteLB.Width = DGV1.Columns(1).Width
        Else
            AutoCompleteLB.Hide()
        End If
    End Sub

    Private Sub AutoCompleteLB_DoubleClick(sender As Object, e As EventArgs) Handles AutoCompleteLB.DoubleClick
        Dim Total As String = DGV1.CurrentCell.Value
        If Total.ToString.IndexOf(" ") >= 0 Then
            DGV1.CurrentCell.Value = Total.ToString.Substring(0, Total.ToString.LastIndexOf(" ") + 1) & AutoCompleteLB.SelectedItem.ToString()
        Else
            DGV1.CurrentCell.Value = AutoCompleteLB.SelectedItem.ToString()
        End If
        AutoCompleteLB.Items.Clear()
        DGV1.BeginEdit(False)
    End Sub

    Private Sub TermTXT_TextChanged(sender As Object, e As EventArgs) Handles TermTXT.TextChanged
        If TrmCred.Checked Then
            term = TermTXT.Text
        End If

        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub

    Private Sub SavePDFRibBtn_Click(sender As Object, e As EventArgs) Handles SavePDFRibBtn.Click
        DGV1.Rows.Clear()
        invnotxt.Text = Main.DBOp.Getinvno()
        Ordbycb.Text = ""
        lpotxt.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles VatCB.CheckedChanged
        Try
            Dim total As Double = 0
            Dim disc As Double = 0
            For Each row As DataGridViewRow In DGV1.Rows
                If DGV1.Rows(0).Cells(3).Value IsNot Nothing AndAlso DGV1.Rows(0).Cells(4).Value IsNot Nothing Then
                    'calculate the total from price And quantity
                    If CDbl(DGV1.Rows(row.Index).Cells(3).Value) > 0 And CDbl(DGV1.Rows(row.Index).Cells(4).Value) > 0 Then

                        DGV1.Rows(row.Index).Cells(5).Value = CDbl(DGV1.Rows(row.Index).Cells(3).Value) * CDbl(DGV1.Rows(row.Index).Cells(4).Value)

                    End If

                    total += CDbl(row.Cells(5).Value)

                End If
            Next
            disc = total * CInt(disctxt.Text) / 100

            With DGV1
                .Columns(4).DefaultCellStyle.Format() = "0.00"
                .Columns(5).DefaultCellStyle.Format() = "0.00"
            End With

            prcnos.Text = FormatNumber(total) & vbNewLine &
                FormatNumber(disc) & vbNewLine &
                FormatNumber(total - disc) & vbNewLine &
                If(VatCB.Checked, FormatNumber((total - disc) * 5 / 100), FormatNumber(0)) & vbNewLine &
                If(VatCB.Checked, FormatNumber((total - disc) + ((total - disc) * 5 / 100)), FormatNumber(total - disc))

        Catch ex As Exception
            disctxt.Text = 0
            disctxt.SelectAll()
        End Try

        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub

    Private Sub ReloadRibBtn_Click(sender As Object, e As EventArgs) Handles ReloadRibBtn.Click
        FillInvoiceData(Me)
    End Sub


    Private Sub NewInvoiceRibBtn_Click(sender As Object, e As EventArgs) Handles NewInvoiceRibBtn.Click
        DGV1.Rows.Clear()
        invnotxt.Text = Main.DBOp.Getinvno()
        Ordbycb.Text = ""
        lpotxt.Text = ""
        cnametxt.Text = ""
        trntxt.Text = ""
        DateTimePicker1.Value = Today
        disctxt.Text = 0
    End Sub

    Private Sub SaveCreditRibBtn_Click(sender As Object, e As EventArgs) Handles SaveCreditRibBtn.Click
        If DGV1.RowCount > 1 Then
            Using printprev As New PrintCredNote
                printprev.InvoiceForm = Me
                printprev.ShowDialog()
            End Using
        Else
            MsgBox("Flag list is empty")
        End If
    End Sub

    Private Sub invnotxt_TextChanged(sender As Object, e As EventArgs) Handles invnotxt.TextChanged
        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub

    Private Sub Ordbycb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Ordbycb.SelectedIndexChanged
        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub

    Private Sub lpotxt_TextChanged(sender As Object, e As EventArgs) Handles lpotxt.TextChanged
        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub

    Private Sub trntxt_TextChanged(sender As Object, e As EventArgs) Handles trntxt.TextChanged
        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub
End Class
