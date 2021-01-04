Option Strict Off
Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop
Module General
    ReadOnly dbop As New DatabaseOperations
    Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio _
                                  As Boolean = True) As Image
        Try
            Dim newWidth As Integer
            Dim newHeight As Integer
            If preserveAspectRatio Then
                Dim originalWidth As Integer = image.Width
                Dim originalHeight As Integer = image.Height
                Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
                Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
                Dim percent As Single = CSng(IIf(percentHeight < percentWidth, percentHeight, percentWidth))
                newWidth = CInt(originalWidth * percent)
                newHeight = CInt(originalHeight * percent)
            Else
                newWidth = size.Width
                newHeight = size.Height
            End If

            Dim newImage As Image = New Bitmap(newWidth, newHeight)
            Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
            End Using

            Return newImage

        Catch
            Return image
        End Try
    End Function
    Function RefreshMainDGV() As Boolean
        Try
            With Main
                Using dt As DataTable = dbop.GetInvoiceListToPopulateInvoiceDGV()
                    With .InvoicesDGV
                        Dim dataView As DataView = dt.DefaultView
                        If Not String.IsNullOrEmpty(Main.ISearchTB.Text) Then
                            Dim MultiLineFilter As String = ""
                            Dim items As String() = Main.ISearchTB.Text.Split(";"c)
                            For entryIndex As Integer = 0 To items.Count - 1
                                MultiLineFilter += If(entryIndex = 0, "", If(String.IsNullOrEmpty(items(entryIndex)), "", " OR ")) + Main.DVRowFilter(Main.PaidRB.Checked, Main.RetcanRB.Checked, Main.UPaidRB.Checked, items(entryIndex))
                            Next
                            Console.WriteLine("FilterString: " & Main.FilterString & vbNewLine & "MultiLineFilter: " & MultiLineFilter)
                            dataView.RowFilter = If(Main.ISearchTB.Text(0) <> "(", MultiLineFilter, Main.FilterString)
                        End If
                        .DataSource = dataView
                        .Columns(4).DefaultCellStyle.Format() = "0.00"
                        .Columns(5).DefaultCellStyle.Format() = "0.00"
                    End With
                    .InvoicesDataTable = dt
                    SetDGVFillWeight(.InvoicesDGV, {8, 8, 32, 15, 8, 5, 8, 8, 8, 8})
                    .ISDateDTP.Value = CDate("1/1/2020")
                    .BarStaticItem1.Caption = "Records: " & .InvoicesDGV.RowCount &
                        " Total: " & dt.Compute("SUM(Total)", dt.DefaultView.RowFilter).ToString &
                        " VAT: " & dt.Compute("SUM(VAT)", dt.DefaultView.RowFilter).ToString
                End Using
            End With
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
    Function FillInvoiceData(invfrm As InvoiceForm, Optional InvoicesDGVRow As DataGridViewRow = Nothing) As Boolean
        Try
            'Clear all rows from DGV to add datasource
            invfrm.InvoiceItemsDGV.Rows.Clear()
            'Populate details of invoice
            Dim Invoice As List(Of DataTable)
            If InvoicesDGVRow IsNot Nothing Then
                Invoice = dbop.GetInvoiceData(InvoicesDGVRow.Cells(0).Value.ToString)
            Else
                Invoice = dbop.GetInvoiceData(Main.InvoicesDGV.Rows(0).Cells(0).Value.ToString)
            End If
            'Console.Write(Invoice)
            Dim InvoiceData As DataTable = Invoice(0)
            With InvoiceData
                invfrm.invnotxt.Text = .Rows(0).Item(0).ToString()
                invfrm.DateTimePicker1.Value = CDate(.Rows(0).Item(1).ToString)
                invfrm.cnametxt.Text = .Rows(0).Item(2).ToString()
                invfrm.trntxt.Text = .Rows(0).Item(3).ToString()
                invfrm.lpotxt.Text = .Rows(0).Item(4).ToString()
                invfrm.Ordbycb.Text = .Rows(0).Item(5).ToString()

                If .Rows(0).Item(6).ToString() = "0" Then
                    invfrm.TermTXT.Text = 0
                    invfrm.term = 30
                    invfrm.TrmCash.Checked = True
                Else
                    invfrm.TermTXT.Text = .Rows(0).Item(6).ToString()
                End If

                Dim vat As Boolean = If(.Rows(0).Item(11) Is DBNull.Value, True, .Rows(0).Item(11))

                If vat Then
                    invfrm.VatCB.Checked = True
                Else
                    invfrm.VatCB.Checked = False
                End If
                'Console.WriteLine(.Rows.Count)
                For Each dataRow As DataRow In .Rows
                    For Each item In dataRow.ItemArray
                        'Console.WriteLine(item)
                    Next
                Next

                invfrm.disctxt.Text = Math.Floor(.Rows(0).Item(7))
            End With
            'Fill invoice flag list and fix decimal, column size
            For row As Integer = 0 To Invoice(1).Rows.Count - 1
                invfrm.InvoiceItemsDGV.Rows.Add(Invoice(1).Rows(row).ItemArray)
            Next
            'invfrm.DGV1.DataSource = Invoice(1)
            With invfrm.InvoiceItemsDGV
                .Columns(4).DefaultCellStyle.Format() = "0.00"
                .Columns(5).DefaultCellStyle.Format() = "0.00"
            End With
            UpdateInvoiceAmmountsDetails(invfrm)
            SetDGVFillWeight(invfrm.InvoiceItemsDGV, {4, 20, 6, 6, 6, 6})
            invfrm.InvoiceFlagList = Invoice(1) 'Assign for changing datatable
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return True
    End Function
    Public Function FormatNumber(ByVal s As String) As String
        Dim pos As Integer = s.IndexOf("."c)
        If pos = -1 Then ' No decimal point
            Return s & ".00"
        Else
            Return (s & "00").Substring(0, pos + 3)
        End If
    End Function
    Function SetDGVFillWeight(ByRef DGV As DataGridView, ByRef Weights As Integer()) As Boolean
        For col As Integer = 0 To DGV.ColumnCount - 1
            'MsgBox(DGV.Columns(col).HeaderText)
            Try
                DGV.Columns(col).FillWeight = Weights(col)
            Catch ex As Exception

            End Try
        Next
        Return True
    End Function
    Function Readmefexcel(InvoiceForm As InvoiceForm, Optional filepath As String = Nothing) As Boolean
        If filepath Is Nothing Then
            filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End If
        Main.Cursor = Cursors.WaitCursor
        Using WForm As New DevExpress.Utils.WaitDialogForm("Please wait")
            Try
                InvoiceForm.InvoiceItemsDGV.CurrentCell = InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.Rows.Count - 1).Cells(0)

                WForm.Show()

                Dim xlApp As New Excel.Application
                Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Open(filepath)
                xlWorkBook = xlApp.Workbooks.Open(filepath)
                Dim xlsheets As Excel.Sheets = DirectCast(xlWorkBook.Worksheets, Excel.Sheets)
                Dim xlsheet As Excel.Worksheet = DirectCast(xlWorkBook.Worksheets(1), Excel.Worksheet)
                'Dim xlSheet = xlWorkBook.Worksheets(1)
                InvoiceForm.disctxt.Text = "0"
                InvoiceForm.TrmCred.Checked = True
                InvoiceForm.TermTXT.Text = "30"
                InvoiceForm.cnametxt.Text = "Middle east Fuji LLC"
                InvoiceForm.lpotxt.Text = xlsheet.Range("h9").Value.ToString & "/" & xlsheet.Range("h10").Value.ToString
                InvoiceForm.DateTimePicker1.Text = xlsheet.Range("h8").Value.ToString
                InvoiceForm.trntxt.Text = xlsheet.Range("h11").Value.ToString
                InvoiceForm.Ordbycb.Text = xlsheet.Range("a12").Value.ToString.Split(":"c)(1).Substring(1)
                Dim i As Integer = 16
                Dim sno As Integer = 1
                While True
                    If xlsheet.Range("d" & i).Value IsNot Nothing Then
                        If xlsheet.Range("a" & i).Value IsNot Nothing Then
                            InvoiceForm.InvoiceItemsDGV.Rows.Add(sno, xlsheet.Range("d" & i).Value, "PCS", CInt(xlsheet.Range("g" & i).Value),
                                                          xlsheet.Range("i" & i).Value, 0)
                            sno += 1
                            If InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.CurrentRow.Index - 1).Cells(0).RowIndex <>
                                    -1 Then
                                'calculate the total from price and quantity
                                If InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.CurrentRow.Index - 1).Cells(3).Value IsNot "" And
                                    InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.CurrentRow.Index - 1).Cells(4).Value IsNot "" Then

                                    InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.CurrentRow.Index - 1).Cells(5).Value =
                                       InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.CurrentRow.Index - 1).Cells(3).Value *
                                       InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.CurrentRow.Index - 1).Cells(4).Value
                                End If
                            End If
                        Else
                            InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.CurrentRow.Index - 1).Cells(1).Value =
                                CStr(InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.CurrentRow.Index - 1).Cells(1).Value) &
                                " " & CStr(xlsheet.Range("d" & i).Value)
                        End If
                    Else
                        If xlsheet.Range("a" & i + 4).Value.ToString = "ACC" Then
                            i += 4
                        Else
                            Exit While
                        End If
                    End If
                    i += 1

                End While
                With InvoiceForm.InvoiceItemsDGV
                    .Columns(3).DefaultCellStyle.Format() = "0.00"
                    .Columns(4).DefaultCellStyle.Format() = "0.00"
                    .Columns(5).DefaultCellStyle.Format() = "0.00"
                End With
                xlWorkBook.Close()
                xlApp.Quit()
                WForm.Close()
                'InvoiceForm.Hide()
            Catch ex As Exception
                WForm.Close()
                MsgBox(ex.ToString)
                Return False
            Finally
                'Force clean up
                GC.Collect()
                GC.WaitForPendingFinalizers()
                Main.Cursor = Cursors.Default
            End Try
        End Using
        Return True

    End Function
    Function ReadPDF(InvoiceForm As InvoiceForm, targetFileName As String) As Boolean
        Main.Cursor = Cursors.WaitCursor
        Dim fileReader As String()
        fileReader = File.ReadAllLines(targetFileName)

        For Each Line1 As String In fileReader
            If (Line1.ToUpper().Contains("SAIFEE")) Then
                Dim Output As String = ""
                For Each Line As String In fileReader
                    If (Regex.IsMatch(Line, "\((.*)\).*")) Then
                        Output += (Regex.Replace(Regex.Replace(Line, "\((.*)\).*", "$1" + vbNewLine), "^ ", ""))
                        If Line.Contains("mention our TRN No in your invoice") Then
                            Exit For
                        End If
                    End If
                Next
                Debug.Write(Output)
                Return True
            End If
        Next

        Dim sourceFileName As String = Application.StartupPath & "\output.txt"
        Using pro As New Process
            pro.StartInfo.FileName = Application.StartupPath & "\mutool.exe"
            pro.StartInfo.Arguments = " draw -F txt -o """ & sourceFileName & """ """ & targetFileName & ""
            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            pro.Start()
            If pro.WaitForExit(5000) Then
                Dim lines As String() = IO.File.ReadAllLines(Application.StartupPath & "\output.txt")
                InvoiceForm.disctxt.Text = "15"
                InvoiceForm.cnametxt.Text = "Techno Marine Equipment Services LLC."
                InvoiceForm.lpotxt.Text = lines(3).Split(" "c)(2)
                InvoiceForm.DateTimePicker1.Text = lines(23)
                InvoiceForm.trntxt.Text = "100293529200003"
                InvoiceForm.Ordbycb.Text = InputBox("Order by", "", "Mr. Shyam")
                InvoiceForm.InvoiceItemsDGV.CurrentCell = InvoiceForm.InvoiceItemsDGV.Rows(InvoiceForm.InvoiceItemsDGV.Rows.Count - 1).Cells(0)

                Dim flagline As New List(Of Integer)

                For line As Integer = 0 To lines.Length - 1
                    If lines(line).ToUpper.Contains("FLAG") Then
                        flagline.Add(line)
                    End If
                    If lines(line).ToLower.Contains("subtotal") Then
                        flagline.Add(line)
                        Exit For
                    End If
                Next
                Dim qty As String
                Dim disc As String
                Dim unit As String
                Dim price As String
                Dim flgnsize As String
                Dim splita As String()
                For Each line As Integer In flagline
                    If lines(line).ToLower.Contains("subtotal") Then
                        Exit For
                    End If
                    flgnsize = lines(line)
                    line += 2

                    While True
                        qty = lines(line)
                        line += 1
                        unit = lines(line)
                        line += 1
                        splita = Split(flgnsize, " ", 2)
                        disc = splita(0) & " " & lines(line) & " " & splita(1)
                        line += 1
                        price = lines(line)
                        line += 4
                        InvoiceForm.InvoiceItemsDGV.Rows.Add("", disc, unit, qty, price)
                        If lines(line).ToUpper.Contains("FLAG") Or lines(line).ToLower.Contains("subtotal") Then
                            Exit While
                        End If
                    End While
                Next
                IO.File.Delete(Application.StartupPath & "\output.txt")
            Else
                Return False
            End If
        End Using
        Main.Cursor = Cursors.Default
        Return True
    End Function

    <System.Runtime.CompilerServices.Extension>
    Public Function FindSubStringIndex(combo As ComboBox, subString As String, Optional comparer As StringComparison = StringComparison.CurrentCulture) As Integer
        ' Sanity check parameters
        If combo Is Nothing Then
            Throw New ArgumentNullException("combo")
        End If
        If subString Is Nothing Then
            Return -1
        End If

        For index As Integer = 0 To combo.Items.Count - 1
            Dim obj As Object = combo.Items(index)
            If obj Is Nothing Then
                Continue For
            End If
            Dim item As String = Convert.ToString(obj, CultureInfo.CurrentCulture)
            If String.IsNullOrWhiteSpace(item) AndAlso String.IsNullOrWhiteSpace(subString) Then
                Return index
            End If
            Dim indexInItem As Integer = item.IndexOf(subString, comparer)
            If indexInItem >= 0 Then
                Return index
            End If
        Next

        Return -1
    End Function
    <Runtime.CompilerServices.Extension>
    Public Function ContainsItemWithSubstring(cb As ComboBox, substring As String) As Boolean

        If cb.Items.Count <> 0 Then

            Dim v As Boolean = TypeOf cb.Items(0) Is DataRowView

            If v Then
                If cb.DisplayMember IsNot Nothing AndAlso TypeOf DirectCast(cb.Items(0), DataRowView)(cb.DisplayMember) Is String Then
                    For i = 0 To cb.Items.Count - 1
                        Dim item As Object = cb.Items(i)

                        Dim v1 As String = DirectCast(DirectCast(item, DataRowView)(cb.DisplayMember), String)

                        If v1.Contains(substring) Then
                            Return True
                        End If
                    Next
                End If
            Else
                For i = 0 To cb.Items.Count - 1
                    Dim item As Object = cb.Items(i)

                    If TypeOf item Is String AndAlso DirectCast(item, String).Contains(substring) Then
                        Return True
                    End If
                Next
            End If

            Return False
        End If
        Return False

    End Function
    Function UpdateInvoiceAmmountsDetails(InvoiceForm As InvoiceForm)
        Try

            With InvoiceForm
                If .InvoiceItemsDGV.Rows(0).Cells(3).Value IsNot Nothing AndAlso .InvoiceItemsDGV.Rows(0).Cells(4).Value IsNot Nothing Then
                    Dim total As Double = 0
                    Dim disc As Double = 0
                    'Console.WriteLine(.InvoiceItemsDGV.Rows.Count)
                    For rowindex As Integer = 0 To .InvoiceItemsDGV.Rows.Count - 1
                        total += CDbl(.InvoiceItemsDGV.Rows(rowindex).Cells(5).Value)
                        'Console.WriteLine(String.Format("Row index: {0} | Ammount: {1}", .InvoiceItemsDGV.Rows(rowindex).Index, CDbl(.InvoiceItemsDGV.Rows(rowindex).Cells(5).Value)))
                    Next

                    disc = total * CInt(.disctxt.Text) / 100
                    .prcnos.Text = FormatNumber(total) & vbNewLine &
                        FormatNumber(disc) & vbNewLine &
                        FormatNumber(total - disc) & vbNewLine &
                        If(.VatCB.Checked, FormatNumber((total - disc) * 5 / 100), FormatNumber(0)) & vbNewLine &
                        If(.VatCB.Checked, FormatNumber((total - disc) + ((total - disc) * 5 / 100)), FormatNumber(total - disc))

                    'Console.WriteLine("Total: " & total)
                End If

                With .InvoiceItemsDGV
                    .Columns(4).DefaultCellStyle.Format = "0.00"
                    .Columns(5).DefaultCellStyle.Format = "0.00"
                End With
            End With
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function
End Module
