Imports Microsoft.Office.Interop

Public Class Main
    Public DBOp As New DatabaseOperations
    Private loading As Boolean = True
    'Dim thread As Threading.Thread = New Threading.Thread(AddressOf RefreshDGVthread) With {.IsBackground = True}
    Private Sub RefreshDGVthread()
        Try

            With InvoicesDGV
                .DataSource = DBOp.LoadInvoicesDGV()
                .Columns(4).DefaultCellStyle.Format() = "0.00"
            End With

            Autoweight(InvoicesDGV, {8, 8, 32, 15, 8, 5, 8, 8, 8})

            Refresh()
            loading = False

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        Enabled = False
        AllowDrop = True
        InvoicesDGV.BackgroundColor = Color.White
        'thread
        'CheckForIllegalCrossThreadCalls = False
        'thread.Start()

        RefreshDGVthread()
        AllRB.Checked = True
        Enabled = True
    End Sub
    Private Sub NewInvBtnItm_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NewInvBtnItm.ItemClick
        Using infrm As New InvoiceForm
            Try
                infrm.invnotxt.Text = DBOp.Getinvno
            Catch ex As Exception
                infrm.invnotxt.Text = 1
            End Try
            infrm.TermTXT.Text = 30
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
                    DBOp.InvoicePaid(CInt(row.Cells(0).Value.ToString), True, Now)
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

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles ISDateDTP.ValueChanged
        Using dt As DataTable = DBOp.LoadInvoicesDGV()
            Dim dataView As DataView = dt.DefaultView

            dataView.RowFilter = "[Invoice Date] >= '" & ISDateDTP.Value & "'" & " And [Invoice Date] <= '" & IEDateDTP.Value & "'"
            InvoicesDGV.DataSource = dataView
        End Using
    End Sub
    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles IEDateDTP.ValueChanged
        Using dt As DataTable = DBOp.LoadInvoicesDGV()
            Dim dataView As DataView = dt.DefaultView

            dataView.RowFilter = "[Invoice Date]  >= '" & ISDateDTP.Value & "'" & " And [Invoice Date]  <= '" & IEDateDTP.Value & "'"

            InvoicesDGV.DataSource = dataView
        End Using
    End Sub
    Private Sub ISearchTB_TextChanged(sender As Object, e As EventArgs) Handles ISearchTB.TextChanged
        Using dt As DataTable = DBOp.LoadInvoicesDGV()
            Dim dataView As DataView = dt.DefaultView

            Try
                If Not String.IsNullOrEmpty(ISearchTB.Text) Then
                    If IsNumeric(ISearchTB.Text) Then
                        dataView.RowFilter = String.Format("CONVERT([Invoice Number], System.String) like '%{0}%'  OR 
                                                   CONVERT([LPO Number], System.String) like '%{0}%'",
                                                                     ISearchTB.Text)
                    Else
                        dataView.RowFilter = String.Format("[Company Name] LIKE '%{0}%'", ISearchTB.Text)
                    End If
                End If
            Catch ex As Exception

            End Try

            InvoicesDGV.DataSource = dataView
        End Using
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles IClearBTN.Click
        ISearchTB.Clear()
        ISDateDTP.Value = CDate("1/1/2019")
        IEDateDTP.Value = Today
    End Sub
    Private Sub AllRB_CheckedChanged(sender As Object, e As EventArgs) Handles AllRB.CheckedChanged
        If Not loading Then
            InvoicesDGV.DataSource = DBOp.LoadInvoicesDGV()
        End If
    End Sub
    Private Sub PaidRB_CheckedChanged(sender As Object, e As EventArgs) Handles PaidRB.CheckedChanged
        Using dt As DataTable = DBOp.LoadInvoicesDGV()
            Dim dataView As DataView = dt.DefaultView

            dataView.RowFilter = "Paid = 'True'"

            InvoicesDGV.DataSource = dataView
        End Using
    End Sub
    Private Sub UnpaidRB_CheckedChanged(sender As Object, e As EventArgs) Handles UPaidRB.CheckedChanged
        Using dt As DataTable = DBOp.LoadInvoicesDGV()
            Dim dataView As DataView = dt.DefaultView

            dataView.RowFilter = "Paid = 'False'"

            InvoicesDGV.DataSource = dataView
        End Using
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
                        Invoicefrm.invnotxt.Text = 1
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

    Private Sub RetcanRB_CheckedChanged(sender As Object, e As EventArgs) Handles RetcanRB.CheckedChanged
        Using dt As DataTable = DBOp.LoadInvoicesDGV()
            Dim dataView As DataView = dt.DefaultView

            dataView.RowFilter = "[Returned or cancled] = 'True'"

            InvoicesDGV.DataSource = dataView
        End Using
    End Sub
End Class