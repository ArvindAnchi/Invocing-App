Option Strict Off
Imports System.Drawing.Printing
Imports DevExpress.Data.Filtering
Imports DevExpress.XtraEditors.Filtering.Templates
Public Class PrintCredNote
    Public mRow As Integer = 0
    Public newpage As Boolean = True
    Public pages As Integer = 0
    Public InvoiceForm As InvoiceForm



    ReadOnly col As Color = Color.Gray
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

                    e.Graphics.DrawString("CREDIT", New Font("Ariel", 16, FontStyle.Bold), brush,
                                              e.PageBounds.Width / 2 - e.Graphics.MeasureString("CREDIT",
                                                                       New Font("Ariel", 16, FontStyle.Bold)).Width / 2, 200)
                    e.Graphics.DrawString("NOTE", New Font("Ariel", 16, FontStyle.Bold), brush,
                                              e.PageBounds.Width / 2 - e.Graphics.MeasureString("NOTE", New Font("Ariel", 16, FontStyle.Bold)).Width / 2,
                                              e.Graphics.MeasureString("NOTE", New Font("Ariel", 16, FontStyle.Bold)).Height + 200)
                    e.Graphics.DrawString("TRN: 100587677400003", New Font("Cambria", 14), brush, 40, 215)
                    e.Graphics.DrawString("No.: ", New Font("Cambria", 16), brush, 40, 235)

                    e.Graphics.DrawString(String.Format("CN{0}", InvoiceForm.invnotxt.Text), New Font("Cambria", 16), brush,
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

                    Dim cols As Integer() = {80, 400, 50, 50, 50, 50, 50, 50}
                    Dim x As Integer
                    Dim prcrec As Rectangle
                    If newpage Then
                        pages += 1
                        row = InvoiceForm.InvoiceItemsDGV.Rows(mRow)
                        x = 30
                        fmt.Alignment = StringAlignment.Center
                        rc.Offset(1, 2)
                        Dim flag As Boolean = True
                        Dim colll As Integer = 0
                        While colll <= 7
                            rc = New Rectangle(x, y, cols(colll),
                                                   InvoiceForm.InvoiceItemsDGV.Rows(0).Cells(0).Size.Height)

                            e.Graphics.DrawLine(custpen, rc.X, rc.Y, rc.X + rc.Width, rc.Y)
                            e.Graphics.DrawLine(custpen, rc.X, rc.Y + rc.Height, rc.X + rc.Width, rc.Y + rc.Height)

                            If InvoiceForm.InvoiceItemsDGV.Rows(0).Cells(If(colll > 5, colll - 2, colll)).Visible And (colll < 5 Or colll > 6) Then
                                e.Graphics.DrawString(InvoiceForm.InvoiceItemsDGV.Columns(If(colll > 6, colll - 2, colll)).HeaderText,
                                                              New Font("Ariel Black", 11, FontStyle.Bold), brush, rc, fmt)
                            ElseIf colll = 5 Then
                                'Console.WriteLine("Write ""Disc.""")
                                e.Graphics.DrawString("Disc.", New Font("Ariel Black", 11, FontStyle.Bold), brush, rc, fmt)
                            ElseIf colll = 6 Then
                                'Console.WriteLine("Write ""VAT""")
                                e.Graphics.DrawString("VAT", New Font("Ariel Black", 11, FontStyle.Bold), brush, rc, fmt)
                            End If

                            x += rc.Width
                            h = Math.Max(h, rc.Height)
                            colll += 1
                        End While
                        y += h
                        prcrec.X = rc.X

                    End If
                    newpage = False


                    y += 5
                    Dim thisNDX As Integer

                    For thisNDX = mRow To InvoiceForm.InvoiceItemsDGV.RowCount - 1
                        If InvoiceForm.InvoiceItemsDGV.Rows(thisNDX).IsNewRow Then Exit For

                        row = InvoiceForm.InvoiceItemsDGV.Rows(thisNDX)
                        x = 30
                        h = 0
                        rc.Offset(2, 2)
                        Dim flag As Boolean = True

                        Dim colll As Integer = 0

                        While colll <= 7

                            If InvoiceForm.InvoiceItemsDGV.Rows(thisNDX).Cells(If(colll > 5, colll - 2, colll)).Visible Then
                                rc = New Rectangle(x, y, cols(colll),
                                                       InvoiceForm.InvoiceItemsDGV.Rows(0).Cells(If(colll > 5, colll - 2, colll)).Size.Height)
                                If InvoiceForm.InvoiceItemsDGV.Rows(thisNDX).Cells(If(colll > 5, colll - 2, colll)).ColumnIndex = 1 Then
                                    fmt.Alignment = StringAlignment.Near
                                Else
                                    fmt.Alignment = StringAlignment.Center
                                End If

                                If InvoiceForm.InvoiceItemsDGV.Rows(thisNDX).Cells(If(colll > 5, colll - 2, colll)).ColumnIndex = 6 Then
                                    prcrec = rc
                                End If

                                If (colll < 5 Or colll > 6) Then
                                    e.Graphics.DrawString(InvoiceForm.InvoiceItemsDGV.Rows(thisNDX).Cells(If(colll > 5, colll - 2, colll)).FormattedValue.ToString(),
                                                  New Font("Calibria", 10, FontStyle.Regular), brush, rc, fmt)
                                ElseIf colll = 5 Then
                                    'Console.WriteLine((InvoiceForm.DGV1.Rows(thisNDX).Cells(5).FormattedValue.ToString() - (InvoiceForm.DGV1.Rows(thisNDX).Cells(5).FormattedValue.ToString() * InvoiceForm.disctxt.Text / 100)) & " * 5 / 100 = " & (InvoiceForm.DGV1.Rows(thisNDX).Cells(5).FormattedValue.ToString() - (InvoiceForm.DGV1.Rows(thisNDX).Cells(5).FormattedValue.ToString() * InvoiceForm.disctxt.Text / 100)) * 5 / 100)

                                    e.Graphics.DrawString((InvoiceForm.InvoiceItemsDGV.Rows(thisNDX).Cells(5).FormattedValue.ToString() * InvoiceForm.disctxt.Text / 100).ToString("N2"), New Font("Calibria", 10, FontStyle.Regular), brush, rc, fmt)
                                ElseIf colll = 6 Then
                                    e.Graphics.DrawString(((InvoiceForm.InvoiceItemsDGV.Rows(thisNDX).Cells(5).FormattedValue.ToString() - (InvoiceForm.InvoiceItemsDGV.Rows(thisNDX).Cells(5).FormattedValue.ToString() * InvoiceForm.disctxt.Text / 100)) * 5 / 100).ToString("N2"), New Font("Calibria", 10, FontStyle.Regular), brush, rc, fmt)
                                End If

                                x += rc.Width
                                h = Math.Max(h, rc.Height)
                            End If
                            colll += 1
                        End While

                        y += h
                        mRow = thisNDX + 1
                        If mRow Mod 26 = 0 Then
                            e.Graphics.DrawString("Continued in next page...", New Font("Cambria", 10), brush,
                                              e.MarginBounds.Right - 100, y + h)
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
                        e.HasMorePages = True
                        newpage = True
                        Return
                    End If

                    Dim ofset As Integer = -9

                    e.Graphics.DrawLine(custpen, 30, rc.Y + rc.Height, rc.X + rc.Width, rc.Y + rc.Height)
                    Dim xval As Integer = 747.29
                    e.Graphics.DrawString("Total (AED)" & vbNewLine &
                                              "Discount (" & InvoiceForm.disctxt.Text & "%)" & vbNewLine &
                                              "VAT (5%)" & vbNewLine &
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

    Private Sub PrintCredNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MaximumSize = Screen.FromRectangle(Bounds).WorkingArea.Size
        PrintPreviewControl1.AutoZoom = True
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click

        Dim pset As PrinterSettings = PrintDocument1.PrinterSettings
        PrintDocument1.PrinterSettings.PrinterName = "Microsoft Print to PDF"
        PrintDocument1.PrinterSettings.PrintToFile = True
        If Not IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Invoices-PDF\") Then
            IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Invoices-PDF\")
        End If
        PrintDocument1.PrinterSettings.PrintFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) &
            "\CreditNote-PDF\" & "CN" & InvoiceForm.invnotxt.Text & "," & InvoiceForm.cnametxt.Text & ".pdf"
        If (PrintDocument1.PrinterSettings.IsValid) Then
            PrintDocument1.Print()
        End If
        PrintDocument1.PrinterSettings = pset
        Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) &
            "\CreditNote-PDF\" & "CN" & InvoiceForm.invnotxt.Text & "," & InvoiceForm.cnametxt.Text & ".pdf")
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles PrintCanBtn.Click
        Close()
    End Sub



    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument1.BeginPrint

        mRow = 0
        newpage = True
        PrintPreviewControl1.StartPage = 0

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        PrintPreviewControl1.StartPage = NumericUpDown1.Value
    End Sub
End Class