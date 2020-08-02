Option Strict Off
Imports System.Drawing.Printing

Public Class PrintPreview

    Private Const DM_IN_BUFFER As Integer = 8
    Private Const DM_OUT_BUFFER As Integer = 2
    Private Const DM_IN_PROMPT As Integer = 4

    Private Declare Auto Function GlobalLock Lib "kernel32.dll" (ByVal handle As IntPtr) As IntPtr
    Private Declare Auto Function GlobalUnlock Lib "kernel32.dll" (ByVal handle As IntPtr) As Integer
    Private Declare Auto Function GlobalFree Lib "kernel32.dll" (ByVal handle As IntPtr) As IntPtr
    Private Declare Auto Function DocumentProperties Lib "winspool.drv" (ByVal hWnd As IntPtr, ByVal hPrinter As IntPtr,
                                                                         ByVal pDeviceName As String,
                                                                         ByVal pDevModeOutput As IntPtr,
                                                                         ByVal pDevModeInput As IntPtr,
                                                                         ByVal fMode As Integer) As Integer
    Public mRow As Integer = 0
    Public newpage As Boolean = True
    Public pages As Integer = 0
    Public InvoiceForm As InvoiceForm

    Sub ShowPrinterProperties(ByVal Settings As PrinterSettings)

        ' PrinterSettings+PageSettings -hDEVMODE
        Dim hDevMode As IntPtr
        hDevMode = Settings.GetHdevmode(Settings.DefaultPageSettings)
        ' Show Dialog ( [In,Out] pDEVMODE )
        Dim pDevMode As IntPtr = GlobalLock(hDevMode)
        DocumentProperties(Handle, IntPtr.Zero, Settings.PrinterName, pDevMode, pDevMode,
                           DM_OUT_BUFFER Or DM_IN_BUFFER Or DM_IN_PROMPT)
        GlobalUnlock(hDevMode)
        ' hDEVMODE -PrinterSettings+PageSettings
        Settings.SetHdevmode(hDevMode)
        Settings.DefaultPageSettings.SetHdevmode(hDevMode)
        ' cleanup
        GlobalFree(hDevMode)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles PrintSettingsBtn.Click
        PrintDocument1.PrinterSettings.PrinterName = ComboBox1.Text
        If (PrintDocument1.PrinterSettings.IsValid) Then
            ShowPrinterProperties(PrintDocument1.PrinterSettings)
        Else
            MsgBox("Invalid Printer", MsgBoxStyle.Information)
        End If
    End Sub

    Dim col As Color = Color.Gray

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim brush As New SolidBrush(col)
            Dim custpen As New Pen(col)
            Using fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
                Using format As StringFormat = New StringFormat(StringFormatFlags.LineLimit)
                    format.Alignment = StringAlignment.Far
                    fmt.LineAlignment = StringAlignment.Center
                    fmt.Trimming = StringTrimming.EllipsisCharacter
                    Dim y As Integer = 325

                    Using newImage As Image = ResizeImage(Image.FromFile(Application.StartupPath & "\" & "Header.jpg"),
                                                            New Size(800, 143))
                        e.Graphics.DrawImage(newImage, 25, 50)
                    End Using

                    e.Graphics.DrawString("فاتورة ضريبية", New Font("times new roman", 16, FontStyle.Bold Or FontStyle.Underline), brush,
                                              e.PageBounds.Width / 2 - e.Graphics.MeasureString("فاتورة ضريبية",
                                                                       New Font("times new roman", 16, FontStyle.Bold Or FontStyle.Underline)).Width / 2, 200)
                    e.Graphics.DrawString("TAX INVOICE", New Font("Ariel", 16, FontStyle.Bold), brush,
                                              e.PageBounds.Width / 2 - e.Graphics.MeasureString("TAX INVOICE", New Font("Ariel", 16, FontStyle.Bold)).Width / 2,
                                              e.Graphics.MeasureString("TAX INVOICE", New Font("Ariel", 16, FontStyle.Bold)).Height + 200)
                    e.Graphics.DrawString("TRN: 100587677400003", New Font("Cambria", 14), brush, 40, 215)
                    e.Graphics.DrawString("No.: ", New Font("Cambria", 16), brush, 40, 235)

                    e.Graphics.DrawString(InvoiceForm.invnotxt.Text, New Font("Cambria", 16), brush,
                                              85.86859, 235)
                    e.Graphics.DrawString("Customer name: " & InvoiceForm.cnametxt.Text, New Font("Cambria", 12), brush, 40, 280)
                    e.Graphics.DrawString("Date: " & vbCrLf &
                                              "Cust. TRN: " & vbCrLf &
                                              "LPO No.: " & vbCrLf &
                                              "Order by: ", New Font("Cambria", 12), brush, 600, 200, format)
                    e.Graphics.DrawString(InvoiceForm.DateTimePicker1.Text & vbCrLf &
                                              InvoiceForm.trntxt.Text & vbCrLf &
                                              InvoiceForm.lpotxt.Text & vbCrLf &
                                              InvoiceForm.Ordbycb.Text, New Font("Cambria", 12), brush, 600, 200)


                    Dim h As Integer = 0
                    Dim rc As Rectangle


                    Dim row As DataGridViewRow

                    Dim cols As Integer() = {80, 400, 50, 75, 75, 95}
                    Dim x As Integer
                    Dim prcrec As Rectangle
                    If newpage Then
                        pages += 1
                        row = InvoiceForm.DGV1.Rows(mRow)
                        x = 30
                        fmt.Alignment = StringAlignment.Center
                        rc.Offset(1, 2)
                        Dim flag As Boolean = True
                        For Each colll As Integer In {0, 1, 2, 3, 4, 5}
                            If InvoiceForm.DGV1.Rows(0).Cells(colll).Visible Then
                                rc = New Rectangle(x, y, cols(colll),
                                                           InvoiceForm.DGV1.Rows(0).Cells(colll).Size.Height)
                                e.Graphics.DrawLine(custpen, rc.X, rc.Y, rc.X + rc.Width, rc.Y)
                                e.Graphics.DrawLine(custpen, rc.X, rc.Y + rc.Height, rc.X + rc.Width, rc.Y + rc.Height)

                                e.Graphics.DrawString(InvoiceForm.DGV1.Columns(colll).HeaderText,
                                                          New Font("Ariel Black", 11, FontStyle.Bold), brush, rc, fmt)

                                x += rc.Width
                                h = Math.Max(h, rc.Height)

                            End If
                        Next
                        y += h
                        prcrec.X = rc.X

                    End If
                    newpage = False


                    y += 5
                    Dim thisNDX As Integer

                    For thisNDX = mRow To InvoiceForm.DGV1.RowCount - 1
                        If InvoiceForm.DGV1.Rows(thisNDX).IsNewRow Then Exit For

                        row = InvoiceForm.DGV1.Rows(thisNDX)
                        x = 30
                        h = 0
                        rc.Offset(2, 2)
                        Dim flag As Boolean = True

                        For Each colll As Integer In {0, 1, 2, 3, 4, 5}
                            If InvoiceForm.DGV1.Rows(thisNDX).Cells(colll).Visible Then
                                rc = New Rectangle(x, y, cols(colll),
                                                           InvoiceForm.DGV1.Rows(0).Cells(colll).Size.Height)
                                If InvoiceForm.DGV1.Rows(thisNDX).Cells(colll).ColumnIndex = 1 Then
                                    fmt.Alignment = StringAlignment.Near
                                Else
                                    fmt.Alignment = StringAlignment.Center
                                End If

                                If InvoiceForm.DGV1.Rows(thisNDX).Cells(colll).ColumnIndex = 6 Then
                                    prcrec = rc
                                End If

                                e.Graphics.DrawString(InvoiceForm.DGV1.Rows(thisNDX).Cells(colll).FormattedValue.ToString(),
                                                      New Font("Calibria", 10, FontStyle.Regular), brush, rc, fmt)



                                x += rc.Width
                                h = Math.Max(h, rc.Height)
                            End If
                        Next


                        y += h
                        mRow = thisNDX + 1
                        If mRow Mod 26 = 0 Then
                            e.Graphics.DrawString("Continued in next page...", New Font("Cambria", 10), brush,
                                              e.MarginBounds.Right - 100, y + h)
                            e.Graphics.DrawLine(custpen, e.MarginBounds.Left - 70, e.MarginBounds.Bottom,
                                            e.MarginBounds.Right + 55, e.MarginBounds.Bottom)

                            'e.Graphics.DrawString(vbCrLf + "Beneficiary Name: DEEP SEA GENERAL TRADING L.L.C. | Bank Name: COMMERCIAL BANK INTERNATIONAL",
                            '                  New Font("Cambria", 10, FontStyle.Regular), brush,
                            '                                              e.PageBounds.Width / 2 -
                            '                  e.Graphics.MeasureString("Beneficiary Name: DEEP SEA GENERAL TRADING L.L.C. | Bank Name: COMMERCIAL BANK INTERNATIONAL",
                            '                                           New Font("Cambria", 10, FontStyle.Regular)
                            '                  ).Width / 2, e.MarginBounds.Bottom)
                            'e.Graphics.DrawString(vbCrLf + vbCrLf + "A/ C NO: 100130028399 | IBAN NO: AE680220000100130028399 | SWIFT CODE: CLBIAEAD",
                            '                  New Font("Cambria", 10, FontStyle.Regular), brush,
                            '                                              e.PageBounds.Width / 2 -
                            '                  e.Graphics.MeasureString("A/ C NO: 100130028399 | IBAN NO: AE680220000100130028399 | SWIFT CODE: CLBIAEAD",
                            '                                           New Font("Cambria", 10, FontStyle.Regular)
                            '                  ).Width / 2, e.MarginBounds.Bottom)
                            e.HasMorePages = True
                            newpage = True
                            Return
                        End If

                    Next
                    If rc.Y > e.MarginBounds.Bottom - 300 Then
                        e.Graphics.DrawString("Continued in next page...", New Font("Cambria", 10), brush,
                                              e.MarginBounds.Right - 100, y + h)
                        e.Graphics.DrawLine(custpen, e.MarginBounds.Left - 70, e.MarginBounds.Bottom,
                                            e.MarginBounds.Right + 55, e.MarginBounds.Bottom)

                        'e.Graphics.DrawString(vbCrLf + "Beneficiary Name: DEEP SEA GENERAL TRADING L.L.C. | Bank Name: COMMERCIAL BANK INTERNATIONAL",
                        '                      New Font("Cambria", 10, FontStyle.Regular), brush,
                        '                                                  e.PageBounds.Width / 2 -
                        '                      e.Graphics.MeasureString("Beneficiary Name: DEEP SEA GENERAL TRADING L.L.C. | Bank Name: COMMERCIAL BANK INTERNATIONAL",
                        '                                               New Font("Cambria", 10, FontStyle.Regular)
                        '                      ).Width / 2, e.MarginBounds.Bottom)
                        'e.Graphics.DrawString(vbCrLf + vbCrLf + "A/ C NO: 100130028399 | IBAN NO: AE680220000100130028399 | SWIFT CODE: CLBIAEAD",
                        '                      New Font("Cambria", 10, FontStyle.Regular), brush,
                        '                                                  e.PageBounds.Width / 2 -
                        '                      e.Graphics.MeasureString("A/ C NO: 100130028399 | IBAN NO: AE680220000100130028399 | SWIFT CODE: CLBIAEAD",
                        '                                               New Font("Cambria", 10, FontStyle.Regular)
                        '                      ).Width / 2, e.MarginBounds.Bottom)
                        e.HasMorePages = True
                        newpage = True
                        Return
                    End If

                    Dim ofset As Integer = -9

                    e.Graphics.DrawLine(custpen, 30, rc.Y + rc.Height, rc.X + rc.Width, rc.Y + rc.Height)
                    Dim xval As Integer = 747.29
                    e.Graphics.DrawString("Total" & vbNewLine &
                                              "Discount (" & InvoiceForm.disctxt.Text & "%)" & vbNewLine &
                                              "VAT" & vbNewLine &
                                              "Grand total", New Font("Calibria", 10, FontStyle.Bold),
                                              brush, xval - 5,
                                              y + h, format)

                    format.Alignment = StringAlignment.Near
                    prcrec.Y = y + h
                    '"Total:" & vbNewLine & "Discount:" & vbNewLine & "Net Total:" & vbNewLine & "VAT:" & vbNewLine & "Grand Total"
                    Dim prcdata As String() = InvoiceForm.prcnos.Text.Split(vbNewLine)
                    'MsgBox(prcrec.X + (prcrec.Width / 2) - e.Graphics.MeasureString(prcdata(2), New Font("Calibria", 10)).Width / 2)

                    e.Graphics.DrawString(prcdata(0) &
                                                  prcdata(1) & '(prcdata(2)) & 
                                                  prcdata(3) &
                                                  prcdata(4),
                                                  New Font("Calibria", 10), brush, xval, y + h, format)

                    If InvoiceForm.TrmCash.Checked Then
                        e.Graphics.DrawString("Terms: Cash", New Font("Cambria", 10), brush, e.MarginBounds.Left - 50, y + h + 25)
                    Else
                        e.Graphics.DrawString("Terms: " & InvoiceForm.TermTXT.Text & " Days",
                                                      New Font("Cambria", 10), brush, e.MarginBounds.Left - 50, y + h + 25)
                    End If

                    Dim num As New ClsConversion
                    'e.Graphics.DrawString("AED " & num.ConvertNumberToWords(Math.Round(CInt(prcdata(2)) + CInt(prcdata(3)), 2).ToString("N2")) & " Fils only",
                    '                              New Font("Cambria", 10), brush, e.MarginBounds.Left - 50, y + h + 60)

                    e.Graphics.DrawString(vbCrLf + "Received by", New Font("Cambria", 11, FontStyle.Bold Or
                                                                                   FontStyle.Underline),
                                                  brush, e.MarginBounds.Left - 50, y + h + 80)

                    e.Graphics.DrawString(vbCrLf + "For Ravindra Sumant curtains fixing", New Font("Cambria", 11,
                                                                                                FontStyle.Bold Or
                                                                                                FontStyle.Underline),
                                          brush, e.MarginBounds.Right - 185, y + h + 80)
                End Using
            End Using

            e.Graphics.DrawLine(custpen, e.MarginBounds.Left - 70, e.MarginBounds.Bottom,
                                e.MarginBounds.Right + 55, e.MarginBounds.Bottom)

            e.Graphics.DrawString(vbCrLf + "Beneficiary Name: RAVINDRA SUMANT CURTAINS FIXING | Bank Name: RAK BANK",
                                  New Font("Cambria", 10, FontStyle.Regular), brush,
                                                              e.PageBounds.Width / 2 -
                                  e.Graphics.MeasureString("Beneficiary Name: RAVINDRA SUMANT CURTAINS FIXING | Bank Name: RAK BANK",
                                                           New Font("Cambria", 10, FontStyle.Regular)
                                  ).Width / 2, e.MarginBounds.Bottom)
            e.Graphics.DrawString(vbCrLf + vbCrLf + "A/ C NO: 0032850670001 | IBAN NO: AE220400000032850670001 | SWIFT CODE: NRAKAEAK",
                                  New Font("Cambria", 10, FontStyle.Regular), brush,
                                                              e.PageBounds.Width / 2 -
                                  e.Graphics.MeasureString("A/ C NO: 0032850670001 | IBAN NO: AE220400000032850670001 | SWIFT CODE: NRAKAEAK",
                                                           New Font("Cambria", 10, FontStyle.Regular)
                                  ).Width / 2, e.MarginBounds.Bottom)

        Catch ex As Exception

            MsgBox(ex.ToString, vbOKOnly, "error")

        End Try


        If pages > 1 Then
            NumericUpDown1.Visible = True
            Label4.Visible = True
        End If
        NumericUpDown1.Maximum = pages - 1
        PrintPreviewControl1.StartPage = 1
        PrintPreviewControl1.Document = PrintDocument1

    End Sub

    Private Sub PrintPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MaximumSize = Screen.FromRectangle(Bounds).WorkingArea.Size
        Dim pkInstalledPrinters As String
        PrintPreviewControl1.AutoZoom = True
        TextBox1.Text = 1
        ' Find all printers installed
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            ComboBox1.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        'Set the combo to the first printer in the list
        If ComboBox1.ContainsItemWithSubstring("3630 series") Then
            ComboBox1.SelectedIndex = ComboBox1.FindSubStringIndex("3630 series")
        End If
        'PrintPreviewControl1.Document = PrintDocument1
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        PrintPreviewControl1.Zoom = TrackBar1.Value / 100
    End Sub

    Private Sub PrintPreview_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        TrackBar1.Minimum = PrintPreviewControl1.Zoom * 100
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click

        PrintDocument1.PrinterSettings.PrinterName = ComboBox1.Text
        PrintDocument1.DefaultPageSettings.Color = False
        PrintDocument1.PrinterSettings.Copies = CShort(TextBox1.Text)

        PrintDocument1.Print()

        Dim pset As PrinterSettings = PrintDocument1.PrinterSettings
        PrintDocument1.PrinterSettings.PrinterName = "Microsoft Print to PDF"
        PrintDocument1.PrinterSettings.PrintToFile = True
        If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Invoices-PDF\") Then
            IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Invoices-PDF\")
        End If
        PrintDocument1.PrinterSettings.PrintFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) &
            "\Invoices-PDF\" & InvoiceForm.invnotxt.Text & "," & InvoiceForm.cnametxt.Text & ".pdf"
        If (PrintDocument1.PrinterSettings.IsValid) Then
            PrintDocument1.Print()
        End If
        PrintDocument1.PrinterSettings = pset

        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles PrintCanBtn.Click
        Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        PrintDocument1.PrinterSettings.PrinterName = ComboBox1.Text
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        PrintPreviewControl1.StartPage = NumericUpDown1.Value
    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint

        mRow = 0
        newpage = True
        PrintPreviewControl1.StartPage = 0

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Select Case ComboBox2.SelectedIndex
            Case 0
                col = Color.DimGray
            Case 1
                col = Color.Gray
            Case 2
                col = Color.Black
            Case 3
                col = Color.Blue
            Case 4
                col = Color.Red
        End Select
        PrintPreviewControl1.InvalidatePreview()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        col = Color.Black
        PrintPreviewControl1.InvalidatePreview()
    End Sub
End Class