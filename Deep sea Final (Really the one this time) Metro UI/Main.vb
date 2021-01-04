Option Strict On
Imports System.ComponentModel
Imports Microsoft.Office.Interop

Public Class Main
    Public FilterString As String = ""
    Public DBOp As New DatabaseOperations
    Public InvoicesDataTable As DataTable

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        AllowDrop = True
        InvoicesDGV.Enabled = False
        InvoicesDGV.BackgroundColor = Color.White
        RefreshMainDGV()
        AllRB.Checked = True
        InvoicesDGV.Enabled = True
    End Sub
    Private Sub NewInvBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NewInvBtnItm.ItemClick
        Using infrm As New InvoiceForm
            Try
                infrm.invnotxt.Text = DBOp.GetNewInvoiceNumber
            Catch ex As Exception
                infrm.invnotxt.Text = "1"
            End Try
            infrm.TermTXT.Text = "30"
            infrm.ShowDialog()
        End Using
    End Sub

    Private Sub PrintBtnItm_ItemClick(sender As Object, e As EventArgs) Handles PrintBtnItm.ItemClick
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            If IsDBNull(row.Cells(8).Value) OrElse Not CBool(row.Cells(8).Value) Then
                Using printprev As New PrintPreview
                    Using invfrm As New InvoiceForm
                        FillInvoiceData(invfrm, row)
                        invfrm.Show()
                        printprev.InvoiceForm = invfrm
                        printprev.ShowDialog()
                        printprev.PrintBtn.PerformClick()
                    End Using
                End Using
            End If
        Next
    End Sub
    Private Sub OpenBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenBtnItm.ItemClick
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            Using invfrm As New InvoiceForm
                invfrm.Enabled = False
                FillInvoiceData(invfrm, row)
                invfrm.Enabled = True
                invfrm.SaveBtnEnable = False
                invfrm.ShowDialog()
            End Using
        Next
    End Sub

    Private Sub CanceledBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CanceledBtnItm.ItemClick
        If MsgBox("Invoice canceled?", vbYesNo, "Cancel") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                DBOp.SetInvoiceCanceledStatus(CInt(row.Cells(0).Value.ToString), True)
            Next
        Else
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                DBOp.SetInvoiceCanceledStatus(CInt(row.Cells(0).Value.ToString), False)
            Next
        End If
        RefreshMainDGV()
    End Sub
    Private Sub DeleteBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DeleteBtnItm.ItemClick
        If MsgBox("Are you sure you want to delete the invoice?", vbYesNo, "Delete invoice") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                If InputBox("Enter invoice number: " & row.Cells(0).Value.ToString &
                                    " to confirm deletion of invoice") = row.Cells(0).Value.ToString Then

                    DBOp.RemoveInvoice(CInt(row.Cells(0).Value.ToString))

                End If
            Next
            RefreshMainDGV()
        End If
    End Sub
    Private Sub PaidBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PaidBtnItm.ItemClick
        If MsgBox("Paid?", vbYesNo, "Paid") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                If row.Cells(5).Value.ToString <> "True" Then
                    DBOp.SetInvoicePaidStatus(CInt(row.Cells(0).Value.ToString), True, CType(Now, String))
                End If
            Next

        Else
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                DBOp.SetInvoicePaidStatus(CInt(row.Cells(0).Value.ToString), False, Nothing)
            Next
        End If
        RefreshMainDGV()
    End Sub
    Private Sub GenStmtBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GenStmtBtnItm.ItemClick
        Using stfrm As New StatementForm
            stfrm.ShowDialog()
        End Using
    End Sub
    Function DVRowFilter(Paid As Boolean, RetCan As Boolean, UPaid As Boolean, SearchString As String) As String

        Try
            If Not String.IsNullOrEmpty(SearchString) Then
                SearchString = SearchString.Trim
                If IsNumeric(SearchString) Then
                    FilterString = String.Format("({0} {1} {2}) AND ([Invoice Date] >= '{3}' And [Invoice Date] <= '{4}')",
                                                  If(InvoiceRB.Checked, String.Format("CONVERT([Invoice Number], System.String) like '%{0}%'", SearchString), ""),
                                                  If(LPORB.Checked, String.Format("CONVERT([LPO Number], System.String) like '%{0}%'", SearchString), ""),
                                                  If(AllSearchRB.Checked, String.Format("CONVERT([Invoice Number], System.String) like '%{0}%' OR CONVERT([LPO Number], System.String) like '%{0}%'", SearchString), ""),
                                                  ISDateDTP.Value,
                                                  IEDateDTP.Value)
                Else
                    FilterString = String.Format("[Company Name] Like '%{0}%' AND ([Invoice Date] >= '{1}' And [Invoice Date] <= '{2}')",
                    SearchString, ISDateDTP.Value, IEDateDTP.Value)
                End If
                If Paid = True Then
                    FilterString += String.Format(" AND Paid = '{0}'", Paid)
                ElseIf RetCan = True Then
                    FilterString += String.Format(" AND Canceled = '{0}'", RetCan)
                ElseIf UPaid = True Then
                    FilterString += String.Format(" AND Paid = '{0}' AND Canceled = '{0}'", False)
                Else
                    FilterString += ""
                End If
            Else
                If Paid = True Then
                    FilterString = String.Format("Paid = '{0}'", Paid)
                ElseIf RetCan = True Then
                    FilterString = String.Format("Canceled = {0}", RetCan)
                ElseIf UPaid = True Then
                    FilterString = String.Format("(Paid = {0}) AND (Canceled = {0})", 0)
                Else
                    FilterString = ""
                End If
            End If
            'Console.WriteLine(FilterString)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Return FilterString

    End Function

    Private Sub DataView_RowFilter(sender As Object, e As EventArgs) Handles ISDateDTP.ValueChanged, IEDateDTP.ValueChanged, ISearchTB.TextChanged, PaidRB.CheckedChanged, UPaidRB.CheckedChanged, RetcanRB.CheckedChanged, InvoiceRB.CheckedChanged, LPORB.CheckedChanged, AllSearchRB.CheckedChanged
        If Not String.IsNullOrEmpty(ISearchTB.Text) Then
            Dim dataView As DataView = InvoicesDataTable.DefaultView
            Dim MultiLineFilter As String = ""
            Dim items As String() = ISearchTB.Text.Split(";"c)
            For entryIndex As Integer = 0 To items.Count - 1
                MultiLineFilter += If(entryIndex = 0, "", If(String.IsNullOrEmpty(items(entryIndex)), "", " OR ")) + DVRowFilter(PaidRB.Checked, RetcanRB.Checked, UPaidRB.Checked, items(entryIndex))
            Next
            'Console.WriteLine("FilterString: " & FilterString & vbNewLine & "MultiLineFilter: " & MultiLineFilter)
            dataView.RowFilter = If(ISearchTB.Text(0) <> "(", MultiLineFilter, FilterString)
            InvoicesDGV.DataSource = dataView

            BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                    " Total: " & InvoicesDataTable.Compute("SUM(Total)", dataView.RowFilter).ToString &
                    " VAT: " & InvoicesDataTable.Compute("SUM(VAT)", dataView.RowFilter).ToString
        ElseIf Not IsNothing(InvoicesDataTable) Then
            Dim dataView As DataView = InvoicesDataTable.DefaultView
            InvoicesDGV.DataSource = dataView
            dataView.RowFilter = DVRowFilter(PaidRB.Checked, RetcanRB.Checked, UPaidRB.Checked, ISearchTB.Text)
            BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                    " Total: " & InvoicesDataTable.Compute("SUM(Total)", dataView.RowFilter).ToString &
                    " VAT: " & InvoicesDataTable.Compute("SUM(VAT)", dataView.RowFilter).ToString
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles IClearBTN.Click
        ISearchTB.Clear()
        ISDateDTP.Value = CDate("1/1/2020")
        IEDateDTP.Value = Today
        Dim dataView As DataView = InvoicesDataTable.DefaultView
        InvoicesDGV.DataSource = dataView
        dataView.RowFilter = ""
        BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                    " Total: " & InvoicesDataTable.Compute("SUM(Total)", dataView.RowFilter).ToString &
                    " VAT: " & InvoicesDataTable.Compute("SUM(VAT)", dataView.RowFilter).ToString
    End Sub
    Private Sub AllRB_CheckedChanged(sender As Object, e As EventArgs) Handles AllRB.CheckedChanged
        If Not String.IsNullOrEmpty(ISearchTB.Text) Then
            Console.WriteLine(FilterString)
            Dim dataView As DataView = InvoicesDataTable.DefaultView
            Dim MultiLineFilter As String = ""
            Dim items As String() = ISearchTB.Text.Split(";"c)
            For entryIndex As Integer = 0 To items.Count - 1
                MultiLineFilter += If(entryIndex = 0, "", If(String.IsNullOrEmpty(items(entryIndex)), "", " OR ")) + DVRowFilter(PaidRB.Checked, RetcanRB.Checked, UPaidRB.Checked, items(entryIndex))
            Next
            Console.WriteLine("FilterString: " & FilterString & vbNewLine & "MultiLineFilter: " & MultiLineFilter)
            dataView.RowFilter = If(ISearchTB.Text(0) <> "(", MultiLineFilter, FilterString)
            InvoicesDGV.DataSource = dataView
            BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                " Total: " & InvoicesDataTable.Compute("SUM(Total)", dataView.RowFilter).ToString &
                " VAT: " & InvoicesDataTable.Compute("SUM(VAT)", dataView.RowFilter).ToString
        End If
    End Sub
    Private Sub InvoicesDGV_DoubleClick(sender As Object, e As EventArgs) Handles InvoicesDGV.DoubleClick
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            Using invfrm As New InvoiceForm
                invfrm.Enabled = False
                FillInvoiceData(invfrm, row)
                invfrm.Enabled = True
                invfrm.SaveBtnEnable = False
                invfrm.ShowDialog()
            End Using
        Next
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Using EditComp As New EditComp
            EditComp.ShowDialog()
        End Using
    End Sub

    Private Sub Main_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim pathoffile As String() = {}
        'MsgBox(e.Data.GetDataPresent("FileGroupDescriptor"))
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            ' Assign the files to an array.
            MyFiles = TryCast(e.Data.GetData(DataFormats.FileDrop), String())
            'If there are more than one file, set first only
            'If you want another restrictment, please edit this.
            pathoffile = MyFiles
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
        End If
        If pathoffile.Length > 0 Then
            For Each file In pathoffile
                Using Invoicefrm As New InvoiceForm
                    Try
                        Invoicefrm.invnotxt.Text = DBOp.GetNewInvoiceNumber
                    Catch ex As Exception
                        Invoicefrm.invnotxt.Text = "1"
                    End Try
                    If file.ToUpper.Contains("XLS") Then
                        Readmefexcel(Invoicefrm, file)
                    ElseIf file.ToUpper.Contains("PDF") Then
                        ReadPDF(Invoicefrm, file)
                    End If
                    Invoicefrm.ShowDialog()
                End Using
            Next
        End If
    End Sub

    Private Sub Main_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Or e.Data.GetDataPresent("FileGroupDescriptor") Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Using exp As New Expenses
            exp.ShowDialog()
        End Using
    End Sub


    Private Sub VATAccBtn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles VATAccBtn.ItemClick
        Using VATReport As New VATReport
            VATReport.ShowDialog()
        End Using
    End Sub

    Private Sub InvoicesDGV_SelectionChanged(sender As Object, e As EventArgs) Handles InvoicesDGV.SelectionChanged
        Dim Total As Decimal = 0
        Dim VAT As Decimal = 0
        If InvoicesDGV.SelectedRows.Count <= 1 Then
            For Each Row As DataGridViewRow In InvoicesDGV.Rows
                Total += CDec(Row.Cells(4).Value)
                VAT += CDec(Row.Cells(5).Value)
            Next
            BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                " Total: " & Total.ToString &
                " VAT: " & VAT.ToString
        Else
            For Each Row As DataGridViewRow In InvoicesDGV.SelectedRows
                Total += CDec(Row.Cells(4).Value)
                VAT += CDec(Row.Cells(5).Value)
            Next
            BarStaticItem1.Caption = "Records: " & InvoicesDGV.SelectedRows.Count &
                " Total: " & Total.ToString &
                " VAT: " & VAT.ToString
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        InvoicesDGV.Enabled = False
        RefreshMainDGV()
        ISearchTB.Clear()
        ISDateDTP.Value = CDate("1/1/2020")
        IEDateDTP.Value = Today
        Dim dataView As DataView = InvoicesDataTable.DefaultView
        InvoicesDGV.DataSource = dataView
        dataView.RowFilter = ""
        BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                    " Total: " & InvoicesDataTable.Compute("SUM(Total)", dataView.RowFilter).ToString &
                    " VAT: " & InvoicesDataTable.Compute("SUM(VAT)", dataView.RowFilter).ToString
        InvoicesDGV.Enabled = True
    End Sub

    Private Sub InvoicesDGV_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles InvoicesDGV.CellMouseDown
        If e.Button = MouseButtons.Right Then
            InvoicesDGV.CurrentCell = InvoicesDGV.Rows(e.RowIndex).Cells(0)
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            Using invfrm As New InvoiceForm
                invfrm.Enabled = False
                FillInvoiceData(invfrm, row)
                invfrm.Enabled = True
                invfrm.SaveBtnEnable = False
                invfrm.ShowDialog()
            End Using
        Next
    End Sub

    Private Sub AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AToolStripMenuItem.Click
        If MsgBox("Paid?", vbYesNo, "Paid") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                If row.Cells(5).Value.ToString <> "True" Then
                    DBOp.SetInvoicePaidStatus(CInt(row.Cells(0).Value.ToString), True, CType(Now, String))
                End If
            Next

        Else
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                DBOp.SetInvoicePaidStatus(CInt(row.Cells(0).Value.ToString), False, Nothing)
            Next
        End If
        RefreshMainDGV()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If MsgBox("Invoice canceled?", vbYesNo, "Cancel") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                DBOp.SetInvoiceCanceledStatus(CInt(row.Cells(0).Value.ToString), True)
            Next
        Else
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                DBOp.SetInvoiceCanceledStatus(CInt(row.Cells(0).Value.ToString), False)
            Next
        End If
        RefreshMainDGV()
    End Sub

    Private Sub DeleteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem1.Click
        If MsgBox("Are you sure you want to delete the invoice?", vbYesNo, "Delete invoice") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                If InputBox("Enter invoice number: " & row.Cells(0).Value.ToString &
                                    " to confirm deletion of invoice") = row.Cells(0).Value.ToString Then

                    DBOp.RemoveInvoice(CInt(row.Cells(0).Value.ToString))

                End If
            Next
            RefreshMainDGV()
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            If IsDBNull(row.Cells(8).Value) OrElse Not CBool(row.Cells(8).Value) Then
                Using printprev As New PrintPreview
                    Using invfrm As New InvoiceForm
                        FillInvoiceData(invfrm, row)
                        invfrm.Show()
                        printprev.InvoiceForm = invfrm
                        printprev.ShowDialog()
                    End Using
                End Using
            End If
        Next
    End Sub

    Private Sub Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Hide()
        e.Cancel = True
        Dim psi As ProcessStartInfo = New ProcessStartInfo With {
            .FileName = String.Format("C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"),
            .UseShellExecute = True,
            .WindowStyle = ProcessWindowStyle.Hidden,
            .Arguments = String.Format("-file ""{0}\BackupSQL.ps1""", Application.StartupPath)
        }
        Dim proc As Process = Process.Start(psi)
        proc.WaitForExit()
        e.Cancel = False
    End Sub

    Private Sub BatchSavePDFButton_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BatchSavePDFButton.ItemClick
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            If IsDBNull(row.Cells(8).Value) OrElse Not CBool(row.Cells(8).Value) Then
                Using printprev As New PrintPreview
                    Using invfrm As New InvoiceForm
                        FillInvoiceData(invfrm, row)
                        invfrm.Show()
                        printprev.InvoiceForm = invfrm
                        printprev.NotPdf = False
                        printprev.ShowDialog()
                    End Using
                End Using
            End If
        Next
    End Sub
End Class