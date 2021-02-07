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
    Public InvoiceForm As InvoiceForm
    Public NotPdf As Boolean = True

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

    Private col As Color = Color.Gray
    Private CurrentDGVRow As Integer = 0
    Private NextPage As Boolean = False
    Private Pages As Integer = 0

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument.PrintPage
        Try
            Dim Brush As New SolidBrush(col)
            Dim Pen As New Pen(col)
            Dim Bounds As Rectangle = e.PageBounds
            Dim RightAlignFormat As New StringFormat With {.Alignment = StringAlignment.Far}
            Dim LeftAlignFormat As New StringFormat With {.Alignment = StringAlignment.Near}
            Dim CenterAlignFormat As New StringFormat With {.Alignment = StringAlignment.Center}
            Dim PrintFooterOnPage As Boolean = True
            Dim PrintTillEnd As Boolean = True
            Dim PrintHeadder As Boolean = True
            With e.Graphics
#Region "Headder"
                Using HeadderImage As Image = Image.FromFile(Application.StartupPath & "\" & "Header.png")
                    .DrawImage(HeadderImage, CSng(Bounds.Width * 5 / 100), CSng(Bounds.Height * 0.03))
                End Using
                Using H1Font As New Font("Calibri", 28.25, FontStyle.Bold)
                    .DrawString("TAX INVOICE",
                                H1Font,
                                Brush,
                                Bounds.Width - .MeasureString("TAX INVOICE", H1Font).Width - (Bounds.Width * 0.05),
                                .MeasureString("TAX INVOICE", H1Font).Height + CSng(Bounds.Height * 0.0075))
                End Using
                Using H1Font As New Font("Calibri", 10, FontStyle.Bold)
                    .DrawString("Mob.: 055 768 9616 | Tel: 04 333 7487 | E-Mail: raviflags@gmail.com | TRN: 100587677400003 | Dubai, United arab emirates",
                                H1Font,
                                Brush,
                                Bounds.Width * 0.5,
                                Bounds.Height * 0.116,
                                CenterAlignFormat)
                End Using
                .DrawLine(Pen,
                          CSng(Bounds.Width * 0.02),
                          CSng(Bounds.Height * 0.1359),
                          CSng(Bounds.Width - Bounds.Width * 0.02),
                          CSng(Bounds.Height * 0.1359))
#End Region
#Region "Customer and our details"
                If Not NextPage Then
                    Using H2Font As New Font("Calibri", 11, FontStyle.Bold)
                        .DrawString("BILL TO", H2Font, Brush,
                                    Bounds.Width * 0.0379,
                                    Bounds.Height * 0.1532)
                    End Using
                    Using H2Font As New Font("Calibri", 11)
                        .DrawString(String.Format(
                                                  "{1}{0}TRN: {2}{0}{3}",
                                                  vbNewLine,
                                                  InvoiceForm.cnametxt.Text,
                                                  InvoiceForm.trntxt.Text,
                                                  Main.DBOp.GetCompanyAddress(InvoiceForm.cnametxt.Text)
                                                  ),
                                    H2Font,
                                    Brush,
                                    Bounds.Width * 0.0379,
                                    Bounds.Height * 0.17)
                    End Using
                    Using H3Font As New Font("Calibri", 10, FontStyle.Bold)
                        .DrawString("INVOICE #", H3Font, Brush,
                                    Bounds.Width - (Bounds.Width * 0.2419),
                                    Bounds.Height * 0.1604,
                                    RightAlignFormat)
                        .DrawString("DATE", H3Font, Brush,
                                    Bounds.Width - (Bounds.Width * 0.2419),
                                    Bounds.Height * 0.1838,
                                    RightAlignFormat)
                        .DrawString("ORDER BY", H3Font, Brush,
                                    Bounds.Width - (Bounds.Width * 0.2419),
                                    Bounds.Height * 0.2069,
                                    RightAlignFormat)
                        .DrawString("LPO NUMBER", H3Font, Brush,
                                    Bounds.Width - (Bounds.Width * 0.2419),
                                    Bounds.Height * 0.231,
                                    RightAlignFormat)
                    End Using
                    Using H3Font As New Font("Calibri", 10)
                        .DrawString(InvoiceForm.invnotxt.Text, H3Font, Brush,
                                    Bounds.Width * 0.7671,
                                    Bounds.Height * 0.1604,
                                    LeftAlignFormat)
                        .DrawString(InvoiceForm.DateTimePicker1.Value, H3Font, Brush,
                                    Bounds.Width * 0.7671,
                                    Bounds.Height * 0.1838,
                                    LeftAlignFormat)
                        .DrawString(InvoiceForm.Ordbycb.Text, H3Font, Brush,
                                    Bounds.Width * 0.7671,
                                    Bounds.Height * 0.2069,
                                    LeftAlignFormat)
                        .DrawString(InvoiceForm.lpotxt.Text, H3Font, Brush,
                                    Bounds.Width * 0.7671,
                                    Bounds.Height * 0.231,
                                    LeftAlignFormat)
                    End Using
                    .DrawLine(Pen,
                              CSng(Bounds.Width * 0.02),
                              CSng(Bounds.Height * 0.2718),
                              CSng(Bounds.Width - Bounds.Width * 0.02),
                              CSng(Bounds.Height * 0.2718))
                Else
                    PrintHeadder = False
                End If
#End Region
#Region "Invoice Items table"
                Using H2Font As New Font("Calibri", 11, FontStyle.Bold)
                    Dim TextHeight As Single = e.Graphics.MeasureString("Test String for Height", H2Font).Height
                    Dim CellWeights As Double() = {0.071428, 0.571428, 0.071428, 0.071428, 0.071428, 0.071428, 0.071428}
                    Dim CellTopLocation As Single = If(NextPage, Bounds.Height * 0.1532, Bounds.Height * 0.281)
                    Dim HeadderCellLeftLocation As Single = Bounds.Width * 0.02
                    Dim HeadderCellValues As String() = {"S.NO", "DESCRIPTION", "UNIT", "QTY.", "PRICE", "VAT", "TOTAL"}
                    Dim PreviousCellTopLocation As Single = TextHeight
                    'Print Headder row
                    For HeadderColumnIndex As Integer = 0 To HeadderCellValues.Count - 1
                        Dim CellWidth As Single = (Bounds.Width - Bounds.Width * 0.02 - (Bounds.Width * 0.02)) * CellWeights(HeadderColumnIndex)
                        .DrawString(HeadderCellValues(HeadderColumnIndex),
                                    H2Font,
                                    Brush,
                                    HeadderCellLeftLocation + (CellWidth / 2),
                                    CellTopLocation,
                                    CenterAlignFormat)
                        HeadderCellLeftLocation += CellWidth
                    Next
                    Using H2FontRegular As New Font("Calibri", 11)
                        PrintFooterOnPage = True
                        'Calculate Total Height of all cells
                        Dim TotalHeight As Double = 0
                        For RowIndex As Integer = CurrentDGVRow To InvoiceForm.InvoiceItemsDGV.Rows.Count - 1
                            Dim CellRectangle As New RectangleF(0,
                                PreviousCellTopLocation + CellTopLocation,
                                5,
                                e.Graphics.MeasureString(InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(1).Value,
                                                        H2FontRegular,
                                                        (Bounds.Width - Bounds.Width * 0.02 - (Bounds.Width * 0.02)) * CellWeights(1)).Height)
                            TotalHeight += CellRectangle.Height
                        Next
                        Dim MinBound As Double = Bounds.Height * 0.7128 - e.Graphics.MeasureString("Test String for Height", H2FontRegular).Height - CellTopLocation
                        Dim MaxBound As Double = Bounds.Height * 0.9424 - CellTopLocation
                        Console.WriteLine(String.Format("Min Bounds: {0}{1}Max Bounds: {2}{1}TotalHeight: {3}{1}NextPage: {4}",
                                                        MinBound,
                                                        vbNewLine,
                                                        MaxBound,
                                                        TotalHeight,
                                                        MinBound <= TotalHeight AndAlso TotalHeight <= MaxBound))

                        For RowIndex As Integer = CurrentDGVRow To InvoiceForm.InvoiceItemsDGV.Rows.Count
                            Dim InvoiceDGVRowData As New List(Of String)
                            Dim InvoiceDGVColumnStringFormat As New List(Of StringFormat)
                            Dim CellLeftLocation As Single = Bounds.Width * 0.02
                            Dim RectangleHeight As Double = 0
                            If InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(1).Value = "" Then
                                Exit For
                            End If
                            InvoiceDGVRowData.AddRange({InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(0).Value.ToString(),
                                        InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(1).Value,
                                        InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(2).Value,
                                        InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(3).Value.ToString(),
                                        CDbl(InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(4).Value).ToString("N2"),
                                        ((CDbl(InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(5).FormattedValue) -
                                                                   (CDbl(InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(5).FormattedValue) *
                                                                    InvoiceForm.disctxt.Text / 100)) * 5 / 100).ToString("N2"),
                                        CDbl(InvoiceForm.InvoiceItemsDGV.Rows(RowIndex).Cells(5).Value).ToString("N2")})
                            InvoiceDGVColumnStringFormat.AddRange({CenterAlignFormat,
                                                                  LeftAlignFormat,
                                                                  CenterAlignFormat,
                                                                  CenterAlignFormat,
                                                                  CenterAlignFormat,
                                                                  CenterAlignFormat,
                                                                  CenterAlignFormat})
                            Console.WriteLine(If(NextPage, 0.1359, 0.2856))
                            If Bounds.Height * If(MinBound <= TotalHeight AndAlso TotalHeight <= MaxBound, 0.7128, 0.9424) - (Bounds.Height * If(PrintHeadder, 0.2856, 0.1359) + TextHeight) <= PreviousCellTopLocation Then
                                PrintFooterOnPage = False
                                CurrentDGVRow = RowIndex
                                PreviousCellTopLocation = CellTopLocation
                                e.HasMorePages = True
                                Pages += 1
                                NextPage = True
                                Return
                            Else
                                NextPage = False
                            End If
                            For ColumnIndex As Integer = 0 To InvoiceDGVRowData.Count - 1
                                Dim CellWidth As Single = (Bounds.Width - Bounds.Width * 0.02 - (Bounds.Width * 0.02)) * CellWeights(ColumnIndex)
                                Dim CellRectangle As New RectangleF(CellLeftLocation,
                                                           PreviousCellTopLocation + CellTopLocation,
                                                           CellWidth,
                                                           e.Graphics.MeasureString(InvoiceDGVRowData(ColumnIndex),
                                                                                    H2FontRegular,
                                                                                    CellWidth).Height)
                                .DrawString(InvoiceDGVRowData(ColumnIndex),
                                                H2FontRegular,
                                                Brush,
                                                CellRectangle,
                                                InvoiceDGVColumnStringFormat(ColumnIndex))
                                CellLeftLocation += CellWidth
                                RectangleHeight = If(CellRectangle.Height > RectangleHeight, CellRectangle.Height, RectangleHeight)
                            Next
                            PreviousCellTopLocation += RectangleHeight
                        Next
                    End Using
                End Using
#End Region
#Region "Draw Footer"
                If PrintFooterOnPage Then
                    .DrawLine(Pen,
                              CSng(Bounds.Width * 0.02),
                              CSng(Bounds.Height * 0.7128),
                              CSng(Bounds.Width - Bounds.Width * 0.02),
                              CSng(Bounds.Height * 0.7128))
                    Using H3Font As New Font("Calibri", 10, FontStyle.Bold)
                        .DrawString(String.Format("TOTAL (AED){0}DISCOUNT ({1}%){0}VAT (5%){0}NET TOTAL",
                                                  vbNewLine,
                                                  InvoiceForm.disctxt.Text),
                                    H3Font,
                                    Brush,
                                    Bounds.Width - (Bounds.Width * 0.1099),
                                    Bounds.Height * 0.7325,
                                    RightAlignFormat)
                    End Using
                    Using H3Font As New Font("Calibri", 10)
                        Dim prcdata As String() = InvoiceForm.prcnos.Text.Split(vbNewLine)
                        .DrawString(String.Format("{0}{1}{2}{3}",
                                                  prcdata(0),
                                                  prcdata(1),
                                                  prcdata(3),
                                                  prcdata(4)),
                                    H3Font,
                                    Brush,
                                    Bounds.Width - (Bounds.Width * 0.0955),
                                    Bounds.Height * 0.7325)
                        .DrawString(String.Format("Terms: {1}",'{0}Ammount: {2}",
                                                  vbNewLine,
                                                  If(InvoiceForm.TrmCred.Checked, InvoiceForm.TermTXT.Text & " days", "Cash"),
                                                  NumericStrings.GetNumberWords(CDec(prcdata(4)))),
                                    H3Font,
                                    Brush,
                                    Bounds.Width * 0.0413,
                                    Bounds.Height * 0.7325)
                    End Using
                    .DrawLine(Pen,
                              CSng(Bounds.Width * 0.02),
                              CSng(Bounds.Height * 0.8049),
                              CSng(Bounds.Width - Bounds.Width * 0.02),
                              CSng(Bounds.Height * 0.8049))
                    Using H4Font As New Font("Calibri", 9, FontStyle.Bold)
                        .DrawString("RECIEVED BY",
                                    H4Font,
                                    Brush,
                                    Bounds.Width * 0.0413,
                                    Bounds.Height * 0.8237)
                        .DrawString("FOR RAVINDRA SUMANT CURTAINS FIXING",
                                    H4Font,
                                    Brush,
                                    Bounds.Width - (Bounds.Width * 0.0364),
                                    Bounds.Height * 0.8237,
                                    RightAlignFormat)
                    End Using
                    Using H4Font As New Font("Calibri", 8.5, FontStyle.Bold)
                        .DrawString("Beneficiary Name: RAVINDRA SUMANT CURTAINS FIXING | Bank Name: RAK BANK | A/ C NO: 0032850670001 | IBAN NO: AE220400000032850670001",
                                    H4Font,
                                    Brush,
                                    Bounds.Width * 0.5,
                                    Bounds.Height * 0.9424,
                                    CenterAlignFormat)
                    End Using
                End If
#End Region
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, vbOKOnly, "error")
        End Try

        PrintPreviewControl.StartPage = 0
        PrintPreviewControl.Document = PrintDocument
        TotalPagesTextBox.Text = 1
        TotalPagesLabel.Text = "of " & Pages + 1
        ZoomSlider.Minimum = PrintPreviewControl.Zoom * 100
    End Sub

    Private Sub PrintPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximumSize = Screen.FromRectangle(Bounds).WorkingArea.Size
        Dim pkInstalledPrinters As String
        ZoomSlider.Minimum = PrintPreviewControl.Zoom * 100
        ' Find all printers installed
        For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
            PrinterComboBox.Items.Add(pkInstalledPrinters)
        Next pkInstalledPrinters

        For Each Res In PrintDocument.PrinterSettings.PrinterResolutions
            PrintQualityComboBox.Items.Add(Res)
        Next

        'Set the combo to the first printer in the list
        If PrinterComboBox.ContainsItemWithSubstring("3630 series") Then
            PrinterComboBox.SelectedIndex = PrinterComboBox.FindSubStringIndex("3630 series")
            PrintQualityComboBox.SelectedIndex = 3
        End If
        'PrintPreviewControl1.Document = PrintDocument1
        TextColorComboBox.SelectedIndex = 0
        If Not NotPdf Then
            PrintPreviewControl.Visible = False
            PrintBtn.PerformClick()
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles ZoomSlider.Scroll
        PrintPreviewControl.Zoom = ZoomSlider.Value / 100
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        Console.WriteLine("Start print")
        PrintDocument.PrinterSettings.PrinterName = PrinterComboBox.Text
        If BlackWhiteCheckBox.Checked Then
            PrintDocument.DefaultPageSettings.Color = True
        Else
            PrintDocument.DefaultPageSettings.Color = False
        End If
        PrintDocument.PrinterSettings.Copies = CShort(CopiesTextBox.Text)
        PrintDocument.DefaultPageSettings.Color = False
        PrintDocument.DefaultPageSettings.PaperSize = (From s As PaperSize In PrintDocument.PrinterSettings.PaperSizes.Cast(Of PaperSize) Where s.RawKind = PaperKind.A4).FirstOrDefault
        PrintDocument.DefaultPageSettings.PrinterResolution = PrintDocument.PrinterSettings.PrinterResolutions(PrintQualityComboBox.SelectedIndex)
        Console.WriteLine("Set print settings")
        'MsgBox(PrintDocument1.PrinterSettings.ToString + vbNewLine + PrintDocument1.DefaultPageSettings.ToString)
        If NotPdf Then
            Console.WriteLine("Not pdf")
            PrintDocument.Print()
        End If
        Dim pset As PrinterSettings = PrintDocument.PrinterSettings
        PrintDocument.PrinterSettings.PrinterName = "Microsoft Print to PDF"
        PrintDocument.PrinterSettings.PrintToFile = True
        Console.WriteLine("Set Save PDF Settings")
        Dim savePath As String = String.Format("{0}\Invoices-PDF\{1}\{2}\",
                                               Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                               InvoiceForm.DateTimePicker1.Value.Year,
                                               MonthName(InvoiceForm.DateTimePicker1.Value.Month))
        Console.WriteLine(String.Format("Save to file: Desktop\Invoices-PDF\{0}\{1}\",
                                               InvoiceForm.DateTimePicker1.Value.Year,
                                               MonthName(InvoiceForm.DateTimePicker1.Value.Month)))
        If Not IO.Directory.Exists(savePath) Then
            Console.WriteLine("Directory does not exist... Creating")
            IO.Directory.CreateDirectory(savePath)
        End If
        Console.WriteLine("Set printer to save PDF")
        PrintDocument.PrinterSettings.PrintFileName = String.Format("{0}\{1},{2}.pdf",
                                                                     savePath,
                                                                     InvoiceForm.invnotxt.Text,
                                                                     InvoiceForm.cnametxt.Text)
        Console.WriteLine("Check if settings are valid")
        If (PrintDocument.PrinterSettings.IsValid) Then
            Console.WriteLine("Save PDF")
            PrintDocument.Print()
        End If
        PrintDocument.PrinterSettings = pset
        Console.WriteLine("Close form")
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles PrintCanBtn.Click
        Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PrinterComboBox.SelectedIndexChanged
        PrintDocument.PrinterSettings.PrinterName = PrinterComboBox.Text
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)
        'PrintPreviewControl.StartPage = PageNumberUpDown.Value
    End Sub

    Private Sub PrintDocument1_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintDocument.BeginPrint

        CurrentDGVRow = 0
        PrintPreviewControl.StartPage = 0

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TextColorComboBox.SelectedIndexChanged
        Select Case TextColorComboBox.SelectedIndex
            Case 0
                col = Color.Gray
            Case 1
                col = Color.DimGray
            Case 2
                col = Color.Black
            Case 3
                col = Color.Blue
            Case 4
                col = Color.Red
        End Select
        PrintPreviewControl.InvalidatePreview()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        col = Color.Black
        PrintPreviewControl.InvalidatePreview()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TotalPagesTextBox.TextChanged
        If Not String.IsNullOrEmpty(TotalPagesTextBox.Text) AndAlso (TotalPagesTextBox.Text > 1 And TotalPagesTextBox.Text < Pages) Then
            PrintPreviewControl.StartPage = TotalPagesTextBox.Text - 1
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TotalPagesTextBox.KeyDown
        If Not String.IsNullOrEmpty(TotalPagesTextBox.Text) Then
            If TotalPagesTextBox.Text > Pages + 1 Then
                TotalPagesTextBox.Text = Pages + 1
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub CheckTotalPagesTextbox()
        If String.IsNullOrEmpty(TotalPagesTextBox.Text) Then
            TotalPagesTextBox.Text = 1
        End If
        If TotalPagesTextBox.Text <= 1 Then
            TotalPagesTextBox.Text = 1
            PreviousPageButton.Enabled = False
        ElseIf TotalPagesTextBox.Text >= Pages + 1 Then
            TotalPagesTextBox.Text = Pages + 1
            NextPageButton.Enabled = False
        End If
        PrintPreviewControl.StartPage = TotalPagesTextBox.Text - 1
    End Sub
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles NextPageButton.Click
        If TotalPagesTextBox.Text >= 1 And TotalPagesTextBox.Text < Pages + 1 Then
            TotalPagesTextBox.Text += 1
            If Not PreviousPageButton.Enabled Then
                PreviousPageButton.Enabled = True
            End If
        End If
        CheckTotalPagesTextbox()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles PreviousPageButton.Click
        If TotalPagesTextBox.Text > 1 And TotalPagesTextBox.Text <= Pages + 1 Then
            TotalPagesTextBox.Text -= 1
            If Not NextPageButton.Enabled Then
                NextPageButton.Enabled = True
            End If
        End If
        CheckTotalPagesTextbox()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        PrintDocument.PrinterSettings.PrinterName = PrinterComboBox.Text
        If (PrintDocument.PrinterSettings.IsValid) Then
            ShowPrinterProperties(PrintDocument.PrinterSettings)
            PrintPreviewControl.InvalidatePreview() 'Refresh the print preview control to display changes.
        Else
            MsgBox("Invalid Printer", MsgBoxStyle.Information)
        End If
    End Sub

End Class