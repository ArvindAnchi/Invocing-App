Imports System.ComponentModel
Imports System.IO

Public Class InvoiceForm
    Private WithEvents EditControl As DataGridViewTextBoxEditingControl 'you need this declared in your other app
    Public InvoiceFlagList As New DataTable
    Dim dt As DataTable = Main.DBOp.GetAllCompaniesList
    ReadOnly flags As String() = File.ReadAllLines(Application.StartupPath + "\Flags")
    Public term As Integer = 30
    Public SaveBtnEnable As Boolean = True
    Private Sub InvoiceForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        AllowDrop = True 'Allow Dragdrop
        'Hide lines if scrolbar is visible in invoices DGV
        If InvoiceItemsDGV.RowCount > 13 Then
            For Each Line As FLine In {FLine1, FLine2, FLine4, FLine6, FLine7, FLine8, FLine9}
                Line.Hide()
            Next
        End If
        'Populate orderby names if existing invoice is opened
        If Not String.IsNullOrEmpty(cnametxt.Text) Then
            Ordbycb.Items.Clear()
            For Each item In Main.DBOp.GetOrderbyNamesListForCompany(cnametxt.Text).Rows
                Ordbycb.Items.Add(item(0))
            Next
        End If
        'Disable save button is existing invoice is opened
        If SaveBtnEnable Then
            SaveRibBtn.Enabled = True
        Else
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.actions_checkcircled
            SaveRibBtn.Enabled = False
        End If
        'Populate company names
        For RowIndex As Integer = 0 To dt.Rows.Count - 1
            cnametxt.Items.Add(dt.Rows(RowIndex)(1))
        Next
        InvoiceItemsDGV.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
    Private Sub Cnametxt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cnametxt.SelectedIndexChanged

        trntxt.Text = If(dt.Rows(cnametxt.SelectedIndex)(2) IsNot DBNull.Value, dt.Rows(cnametxt.SelectedIndex)(2), "")
        disctxt.Text = If(dt.Rows(cnametxt.SelectedIndex)(3) IsNot DBNull.Value, dt.Rows(cnametxt.SelectedIndex)(3), 0)

        If Not cnametxt.Items.Contains(cnametxt.Text) Then
            Using addcmp As New AddComp
                addcmp.ShowDialog()
            End Using
            dt = Main.DBOp.GetAllCompaniesList
            trntxt.Text = dt.Rows(cnametxt.SelectedIndex)(2)
            disctxt.Text = Math.Floor(dt.Rows(cnametxt.SelectedIndex)(3))
        Else
            Ordbycb.Items.Clear()
            For Each item In Main.DBOp.GetOrderbyNamesListForCompany(cnametxt.Text).Rows
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
        RefreshMainDGV()
    End Sub
    Private Sub Main_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Or e.Data.GetDataPresent("FileGroupDescriptor") Then
            e.Effect = DragDropEffects.All
        End If
    End Sub
    Private Sub InvoiceForm_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim pathoffile As String = ""
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            ' Assign the files to an array.
            MyFiles = TryCast(e.Data.GetData(DataFormats.FileDrop), String())
            'If there are more than one file, set first only
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
            pathoffile = "C:\Users\Arvind\AppData\Local\Microsoft\Windows\INetCache\Content.Outlook\QYI4A50A\" & fileName.ToString
        End If
        If Not String.IsNullOrEmpty(pathoffile) Then
            If pathoffile.ToUpper.Contains("XLS") Then
                Readmefexcel(Me, pathoffile)
            ElseIf pathoffile.ToUpper.Contains("PDF") Then
                ReadPDF(Me, pathoffile)
            End If
        End If
    End Sub
    Private Sub PrintPrevRibBtn_Click(sender As Object, e As EventArgs) Handles PrintPrevRibBtn.Click
        If SaveRibBtn.Enabled = True Then
            If MsgBox("Save Changes?", MsgBoxStyle.YesNo, "Save") = MsgBoxResult.Yes Then
                If Main.DBOp.WriteNewInvoice(Me) Then
                    SaveRibBtn.ImageOptions.SvgImage = My.Resources.actions_checkcircled
                    SaveRibBtn.Enabled = False
                End If
                RefreshMainDGV()
                Cursor = Cursors.WaitCursor
                FillInvoiceData(Me)
                Cursor = Cursors.Default
                SaveRibBtn.ImageOptions.SvgImage = My.Resources.actions_checkcircled
                SaveRibBtn.Enabled = False
            End If
        End If
        If InvoiceItemsDGV.RowCount > 1 Then
            Using printprev As New PrintPreview
                printprev.InvoiceForm = Me
                printprev.ShowDialog()
            End Using
        Else
            MsgBox("Flag list is empty")
        End If
    End Sub
    Private Sub TrmCash_CheckedChanged(sender As Object, e As EventArgs) Handles TrmCash.CheckedChanged

        TermTXT.Text = If(TrmCash.Checked, 0, term)
        TermTXT.Enabled = Not TrmCash.Checked

        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub
    Private Sub SaveRibBtn_Click(sender As Object, e As EventArgs) Handles SaveRibBtn.Click
        If InvoiceItemsDGV.RowCount > 1 Then
            If Main.DBOp.WriteNewInvoice(Me) Then
                SaveRibBtn.ImageOptions.SvgImage = My.Resources.actions_checkcircled
                SaveRibBtn.Enabled = False
            End If
            RefreshMainDGV()
            Cursor = Cursors.WaitCursor
            FillInvoiceData(Me)
            Cursor = Cursors.Default
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.actions_checkcircled
            SaveRibBtn.Enabled = False

            Using printprev As New PrintPreview
                printprev.InvoiceForm = Me
                printprev.ShowDialog()
            End Using
        Else
            MsgBox("Cannot save empty invoice", MsgBoxStyle.Exclamation)
        End If

    End Sub
    Private Sub InvoiceItemsDGV_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles InvoiceItemsDGV.CellValueChanged

        Try
            If e.RowIndex <> -1 Then
                'calculate the total from price And quantity
                If CDbl(InvoiceItemsDGV.Rows(e.RowIndex).Cells(3).Value) > 0 And CDbl(InvoiceItemsDGV.Rows(e.RowIndex).Cells(4).Value) > 0 Then
                    InvoiceItemsDGV.Rows(e.RowIndex).Cells(5).Value = CDbl(InvoiceItemsDGV.Rows(e.RowIndex).Cells(3).Value) * CDbl(InvoiceItemsDGV.Rows(e.RowIndex).Cells(4).Value)
                    UpdateInvoiceAmmountsDetails(Me)
                End If

            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
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
            UpdateInvoiceAmmountsDetails(Me)
        Catch ex As Exception
            disctxt.Text = 0
            disctxt.SelectAll()
        End Try

        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If

    End Sub

    Private Sub InvoiceItemsDGV_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles InvoiceItemsDGV.EditingControlShowing
        If EditControl Is Nothing AndAlso InvoiceItemsDGV.CurrentCell.ColumnIndex = 1 Then
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

    Private Sub InvoiceItemsDGV_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles InvoiceItemsDGV.CellEnter
        If e.RowIndex <> -1 Then
            InvoiceItemsDGV.Rows(e.RowIndex).Cells(0).Value = e.RowIndex + 1
            If e.RowIndex > 11 Then
                For Each Line As FLine In {FLine1, FLine2, FLine4, FLine6, FLine7, FLine8, FLine9}
                    Line.Hide()
                Next
            End If
        End If
    End Sub

    Private Sub InvoiceItemsDGV_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles InvoiceItemsDGV.CellBeginEdit
        If e.ColumnIndex = 1 Then
            Dim RowHeight1 As Integer = InvoiceItemsDGV.Rows(e.RowIndex).Height
            Dim CellRectangle1 As Rectangle = InvoiceItemsDGV.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, False)

            CellRectangle1.X += InvoiceItemsDGV.Left
            CellRectangle1.Y += InvoiceItemsDGV.Top + RowHeight1

            Dim CurLoc As Point = PointToScreen(New Point(CellRectangle1.X - 267, CellRectangle1.Y - 135))

            AutoCompleteLB.Location = CurLoc
            AutoCompleteLB.Width = InvoiceItemsDGV.Columns(1).Width
        Else
            AutoCompleteLB.Hide()
        End If
    End Sub

    Private Sub AutoCompleteLB_DoubleClick(sender As Object, e As EventArgs) Handles AutoCompleteLB.DoubleClick
        Dim Total As String = InvoiceItemsDGV.CurrentCell.Value
        If Total.ToString.IndexOf(" ") >= 0 Then
            InvoiceItemsDGV.CurrentCell.Value = Total.ToString.Substring(0, Total.ToString.LastIndexOf(" ") + 1) & AutoCompleteLB.SelectedItem.ToString()
        Else
            InvoiceItemsDGV.CurrentCell.Value = AutoCompleteLB.SelectedItem.ToString()
        End If
        AutoCompleteLB.Items.Clear()
        InvoiceItemsDGV.BeginEdit(False)
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
        InvoiceItemsDGV.Rows.Clear()
        invnotxt.Text = Main.DBOp.GetNewInvoiceNumber()
        Ordbycb.Text = ""
        lpotxt.Text = ""
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles VatCB.CheckedChanged
        Try
            UpdateInvoiceAmmountsDetails(Me)

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
        SaveRibBtn.ImageOptions.SvgImage = My.Resources.actions_checkcircled
        SaveRibBtn.Enabled = False
        FillInvoiceData(Me)
    End Sub


    Private Sub NewInvoiceRibBtn_Click(sender As Object, e As EventArgs) Handles NewInvoiceRibBtn.Click
        InvoiceItemsDGV.Rows.Clear()
        invnotxt.Text = Main.DBOp.GetNewInvoiceNumber()
        Ordbycb.Text = ""
        lpotxt.Text = ""
        cnametxt.Text = ""
        trntxt.Text = ""
        DateTimePicker1.Value = Today
        disctxt.Text = 0
    End Sub

    Private Sub SaveCreditRibBtn_Click(sender As Object, e As EventArgs) Handles SaveCreditRibBtn.Click
        If InvoiceItemsDGV.RowCount > 1 Then
            Using printprev As New PrintCredNote
                printprev.InvoiceForm = Me
                printprev.ShowDialog()
            End Using
        Else
            MsgBox("Flag list is empty")
        End If
    End Sub

    Private Sub Invnotxt_TextChanged(sender As Object, e As EventArgs) Handles invnotxt.TextChanged, DateTimePicker1.ValueChanged, Ordbycb.SelectedIndexChanged, lpotxt.TextChanged, trntxt.TextChanged
        If Not SaveRibBtn.Enabled Then
            SaveRibBtn.ImageOptions.SvgImage = My.Resources.save
            SaveRibBtn.Enabled = True
        End If
    End Sub

    '---------Write existing invoices to seperate folders by date--------------
    'Private Sub Button1_Click(sender As Object, e As EventArgs) 'Handles Button1.Click
    '    For Each Invoice In Main.DBOp.ReadAllInvocies
    '        Try
    '            'Clear all rows from DGV to add datasource
    '            DGV1.Rows.Clear()
    '            'Console.Write(Invoice)
    '            Dim InvoiceData As DataTable = Invoice(0)
    '            With InvoiceData
    '                Dim invno = .Rows(0).Item(0).ToString()
    '                Dim cname = .Rows(0).Item(2).ToString()
    '                Dim invDate = CDate(.Rows(0).Item(1).ToString)

    '                Dim savePath As String = String.Format("{0}\Invoices-PDF\{1}\{2}\",
    '                                           Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
    '                                           invDate.Year,
    '                                           MonthName(invDate.Month))

    '                If Not IO.Directory.Exists(savePath) Then
    '                    IO.Directory.CreateDirectory(savePath)
    '                End If

    '                File.Move(String.Format("{0}\Invoices-PDF\{1},{2}.pdf",
    '                                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop), invno, cname),
    '                          String.Format("{0}\{1},{2}.pdf", savePath, invno, cname))
    '            End With

    '        Catch ex As Exception
    '            Console.WriteLine(ex.ToString)
    '            Continue For
    '        End Try
    '    Next
    'End Sub
End Class
