Option Strict On
Imports Microsoft.Office.Interop

Public Class Main
    Public FilterString As String = ""
    Public DBOp As New DatabaseOperations
    Private loading As Boolean = True
    'Dim thread As Threading.Thread = New Threading.Thread(AddressOf RefreshDGVthread) With {.IsBackground = True}
    Private Sub RefreshDGVthread()
        Try
            Using dt As DataTable = DBOp.LoadInvoicesDGV()
                With InvoicesDGV
                    .DataSource = dt
                    .Columns(4).DefaultCellStyle.Format() = "0.00"
                    .Columns(5).DefaultCellStyle.Format() = "0.00"
                End With

                Autoweight(InvoicesDGV, {8, 8, 32, 15, 8, 5, 8, 8, 8, 8})

                Refresh()
                ISDateDTP.Value = CDate("1/1/2020")
                BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                    " Total: " & dt.Compute("SUM(Total)", dt.DefaultView.RowFilter).ToString &
                    " VAT: " & dt.Compute("SUM(VAT)", dt.DefaultView.RowFilter).ToString
                loading = False
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Enabled = False
        AllowDrop = True
        InvoicesDGV.BackgroundColor = Color.White

        RefreshDGVthread()
        AllRB.Checked = True
        Enabled = True
    End Sub
    Private Sub NewInvBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NewInvBtnItm.ItemClick
        Using infrm As New InvoiceForm
            Try
                infrm.invnotxt.Text = DBOp.Getinvno
            Catch ex As Exception
                infrm.invnotxt.Text = "1"
            End Try
            infrm.TermTXT.Text = "30"
            infrm.ShowDialog()
        End Using
    End Sub
    Private Sub PrintBtnItm_ItemClick(sender As Object, e As EventArgs) Handles PrintBtnItm.ItemClick
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            Using printprev As New PrintPreview
                Dim invfrm As New InvoiceForm
                FillInvoiceData(invfrm, row)
                invfrm.Show()
                printprev.InvoiceForm = invfrm
                printprev.ShowDialog()
                printprev.PrintBtn.PerformClick()
                invfrm.Dispose()
            End Using
        Next
    End Sub
    Private Sub OpenBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenBtnItm.ItemClick
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            Using invfrm As New InvoiceForm
                invfrm.Enabled = False
                FillInvoiceData(invfrm, row)
                invfrm.Enabled = True
                invfrm.ShowDialog()
            End Using
        Next
    End Sub
    Private Sub PrintBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintBtnItm.ItemClick
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            Using printprev As New PrintPreview
                Using invfrm As New InvoiceForm
                    FillInvoiceData(invfrm, row)
                    printprev.InvoiceForm = invfrm
                End Using
            End Using
        Next
    End Sub
    Private Sub CanceledBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CanceledBtnItm.ItemClick
        If MsgBox("Invoice canceled?", vbYesNo, "Cancel") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                If row.Cells(6).Value.ToString = "True" Then
                    DBOp.InvoiceCanceled(CInt(row.Cells(0).Value.ToString), False)
                Else
                    DBOp.InvoiceCanceled(CInt(row.Cells(0).Value.ToString), True)
                End If
            Next
            RefreshDGV()
        End If
    End Sub
    Private Sub DeleteBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DeleteBtnItm.ItemClick
        If MsgBox("Are you sure you want to delete the invoice?", vbYesNo, "Delete invoice") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                If InputBox("Enter invoice number: " & row.Cells(0).Value.ToString &
                                    " to confirm deletion of invoice") = row.Cells(0).Value.ToString Then

                    DBOp.RemoveInvoice(CInt(row.Cells(0).Value.ToString))

                End If
            Next
            RefreshDGV()
        End If
    End Sub
    Private Sub PaidBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PaidBtnItm.ItemClick
        If MsgBox("Paid?", vbYesNo, "Paid") = vbYes Then
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                If row.Cells(5).Value.ToString <> "True" Then
                    DBOp.InvoicePaid(CInt(row.Cells(0).Value.ToString), True, CType(Now, String))
                End If
            Next
        Else
            For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
                DBOp.InvoicePaid(CInt(row.Cells(0).Value.ToString), False, Nothing)
            Next
        End If
        RefreshDGV()
    End Sub
    Private Sub GenStmtBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GenStmtBtnItm.ItemClick
        Using stfrm As New StatementForm
            stfrm.ShowDialog()
        End Using
    End Sub
    Function DVRowFilter(Paid As Boolean, RetCan As Boolean, UPaid As Boolean) As String

        Try
            If Not String.IsNullOrEmpty(ISearchTB.Text) Then
                If IsNumeric(ISearchTB.Text) Then
                    FilterString = String.Format("(CONVERT([Invoice Number], System.String) like '%{0}%' OR CONVERT([LPO Number], System.String) like '%{0}%') AND ([Invoice Date] >= '{1}' And [Invoice Date] <= '{2}')",
                                                  ISearchTB.Text, ISDateDTP.Value, IEDateDTP.Value)
                Else
                    FilterString = String.Format("[Company Name] LIKE '%{0}%' AND ([Invoice Date] >= '{1}' And [Invoice Date] <= '{2}')",
                                                  ISearchTB.Text, ISDateDTP.Value, IEDateDTP.Value)
                End If
                If Paid = True Then
                    FilterString += String.Format(" AND Paid = '{0}'", Paid)
                ElseIf RetCan = True Then
                    FilterString += String.Format(" AND Canceled = '{0}'", RetCan)
                ElseIf UPaid = True Then
                    FilterString += String.Format(" AND Paid = '{0}' AND Canceled = '{0}'", False)
                End If
            Else
                If Paid = True Then
                    FilterString = String.Format("Paid = '{0}'", Paid)
                ElseIf RetCan = True Then
                    FilterString = String.Format("Canceled = {0}", RetCan)
                ElseIf UPaid = True Then
                    FilterString = String.Format("Paid = '{0}' AND Canceled = '{0}'", False)
                End If
            End If
            Console.WriteLine(FilterString)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Return FilterString

    End Function

    Private Sub DataView_RowFilter(sender As Object, e As EventArgs) Handles ISDateDTP.ValueChanged, IEDateDTP.ValueChanged, ISearchTB.TextChanged, PaidRB.CheckedChanged, UPaidRB.CheckedChanged, RetcanRB.CheckedChanged
        If Not String.IsNullOrEmpty(ISearchTB.Text) Then
            Console.WriteLine(FilterString)
            Using dt As DataTable = DBOp.LoadInvoicesDGV()
                Dim dataView As DataView = dt.DefaultView
                dataView.RowFilter = If(ISearchTB.Text(0) <> "(", DVRowFilter(PaidRB.Checked, RetcanRB.Checked, UPaidRB.Checked), FilterString)
                InvoicesDGV.DataSource = dataView

                BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                    " Total: " & dt.Compute("SUM(Total)", dataView.RowFilter).ToString &
                    " VAT: " & dt.Compute("SUM(VAT)", dataView.RowFilter).ToString
            End Using
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles IClearBTN.Click
        ISearchTB.Clear()
        ISDateDTP.Value = CDate("1/1/2019")
        IEDateDTP.Value = Today
    End Sub
    Private Sub AllRB_CheckedChanged(sender As Object, e As EventArgs) Handles AllRB.CheckedChanged
        If Not String.IsNullOrEmpty(ISearchTB.Text) Then
            Console.WriteLine(FilterString)
            Using dt As DataTable = DBOp.LoadInvoicesDGV()
                Dim dataView As DataView = dt.DefaultView
                dataView.RowFilter = If(ISearchTB.Text(0) <> "(", DVRowFilter(PaidRB.Checked, RetcanRB.Checked, UPaidRB.Checked), FilterString)
                InvoicesDGV.DataSource = dataView
                BarStaticItem1.Caption = "Records: " & InvoicesDGV.RowCount &
                " Total: " & dt.Compute("SUM(Total)", dataView.RowFilter).ToString &
                " VAT: " & dt.Compute("SUM(VAT)", dataView.RowFilter).ToString
            End Using
        End If
    End Sub
    Private Sub InvoicesDGV_DoubleClick(sender As Object, e As EventArgs) Handles InvoicesDGV.DoubleClick
        For Each row As DataGridViewRow In InvoicesDGV.SelectedRows
            Using invfrm As New InvoiceForm
                invfrm.Enabled = False
                FillInvoiceData(invfrm, row)
                invfrm.Enabled = True
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
                        Invoicefrm.invnotxt.Text = DBOp.Getinvno
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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        With Search
            .mainfrm = Me
            .ShowDialog()
        End With
    End Sub
End Class