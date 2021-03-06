﻿Imports System.IO
Imports iText.Html2pdf
Imports Microsoft.Office.Interop

Public Class StatementForm

    Private Total As String
    Private Discount As String
    Private VAT As String
    Private Net As String

    Private Sub StatementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim companies As DataTable = Main.DBOp.GetCompanyListForStatement
        companies.Rows.Add("All companies")
        CompLB.DataSource = companies
        CompLB.DisplayMember = "Company name"
        SYearLBL.Text = Today.Year
        EYearLBL.Text = Today.Year
        For Month As Integer = 1 To 12
            SDateLB.Items.Add(MonthName(Month) & " (" & SYearLBL.Text & ")")
            EDateLB.Items.Add(MonthName(Month) & " (" & SYearLBL.Text & ")")
        Next
        EDateLB.SelectedIndex = 0
        SDateLB.SelectedIndex = 0
    End Sub

    Private Sub CompLB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CompLB.SelectedIndexChanged
        SetDGVFillWeight(StmtDGV, {6, 6, 10, 6, 6, 6, 6})
        Try
            Using dt As DataTable = Main.DBOp.GetInvoicesForStatement(CompLB.SelectedItem)
                Dim dataView As DataView = dt.DefaultView

                dataView.RowFilter = "[Date] >= '" & CDate("1/" & SDateLB.SelectedIndex + 1 & "/" & SYearLBL.Text) & "'" &
                    " And [Date] <= '" & CDate("31/" & EDateLB.SelectedIndex + 1 & "/" & EYearLBL.Text) & "'"

                StmtDGV.DataSource = dataView

                Total = dt.Compute("SUM(Total)", dataView.RowFilter)
                Discount = dt.Compute("SUM(Discount)", dataView.RowFilter)
                VAT = dt.Compute("SUM(VAT)", dataView.RowFilter)
                Net = dt.Compute("SUM([Grand Total])", dataView.RowFilter)

                StmtTotalLBL.Caption = "Total: " & Total &
                    " Discount: " & Discount &
                    " VAT: " & VAT &
                    " Net Total: " & Net
            End Using
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SDateLB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SDateLB.SelectedIndexChanged, EDateLB.SelectedIndexChanged

        If EDateLB.Items.Count < 10 Then

            For Month As Integer = 1 To 12
                EDateLB.Items.Add(MonthName(Month) & " (" & EYearLBL.Text & ")")
            Next

            EDateLB.SelectedIndex = 0
        End If
        Try
            Using dt As DataTable = Main.DBOp.GetInvoicesForStatement(CompLB.SelectedItem)
                Dim dataView As DataView = dt.DefaultView
                Dim cols As String = ""
                dataView.RowFilter = "[Date] >= '" & CDate("1/" & SDateLB.SelectedIndex + 1 & "/" & SYearLBL.Text) & "'" &
                    " And [Date] <= '" & CDate(Date.DaysInMonth(EYearLBL.Text, EDateLB.SelectedIndex + 1) & "/" & EDateLB.SelectedIndex + 1 & "/" & EYearLBL.Text) & "'"

                Total = dt.Compute("SUM(Total)", dataView.RowFilter)
                Discount = dt.Compute("SUM(Discount)", dataView.RowFilter)
                VAT = dt.Compute("SUM(VAT)", dataView.RowFilter)
                Net = dt.Compute("SUM([Grand Total])", dataView.RowFilter)

                StmtTotalLBL.Caption = "Total: " & FormatNumber(Total) &
                    " Discount: " & FormatNumber(Discount) &
                    " VAT: " & FormatNumber(VAT) &
                    " Net Total: " & FormatNumber(Net)

                StmtDGV.DataSource = dataView
            End Using
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SYearNBtn_Click(sender As Object, e As EventArgs) Handles SYearNBtn.Click

        If SYearLBL.Text < EYearLBL.Text Then
            SDateLB.Items.Clear()
            SYearLBL.Text += 1
            For Month As Integer = 1 To 12
                SDateLB.Items.Add(MonthName(Month) & " (" & SYearLBL.Text & ")")
            Next
        End If

    End Sub

    Private Sub SYearPBtn_Click(sender As Object, e As EventArgs) Handles SYearPBtn.Click
        SDateLB.Items.Clear()
        SYearLBL.Text -= 1
        For Month As Integer = 1 To 12
            SDateLB.Items.Add(MonthName(Month) & " (" & SYearLBL.Text & ")")
        Next
    End Sub

    Private Sub EYearNBtn_Click(sender As Object, e As EventArgs) Handles EYearNBtn.Click
        EDateLB.Items.Clear()
        EYearLBL.Text += 1
        For Month As Integer = 1 To 12
            EDateLB.Items.Add(MonthName(Month) & " (" & EYearLBL.Text & ")")
        Next
    End Sub

    Private Sub EYearPBtn_Click(sender As Object, e As EventArgs) Handles EYearPBtn.Click

        If EYearLBL.Text > SYearLBL.Text Then
            EDateLB.Items.Clear()
            EYearLBL.Text -= 1
            For Month As Integer = 1 To 12
                EDateLB.Items.Add(MonthName(Month) & " (" & EYearLBL.Text & ")")
            Next
        End If

    End Sub
    Function getStatementRange() As String
        Dim Range As String = ""
        If CDate(StmtDGV.Rows(0).Cells(1).Value).Month = CDate(StmtDGV.Rows(StmtDGV.RowCount - 1).Cells(1).Value).Month Then
            Range = String.Format("{0} {1}",
                          MonthName(CDate(StmtDGV.Rows(0).Cells(1).Value).Month),
                          CDate(StmtDGV.Rows(0).Cells(1).Value).Year)
        Else
            Range = String.Format("{0} {1} - {2} {3}",
                          MonthName(CDate(StmtDGV.Rows(0).Cells(1).Value).Month),
                          CDate(StmtDGV.Rows(0).Cells(1).Value).Year,
                          MonthName(CDate(StmtDGV.Rows(StmtDGV.RowCount - 1).Cells(1).Value).Month),
                          CDate(StmtDGV.Rows(StmtDGV.RowCount - 1).Cells(1).Value).Year)
        End If
        Return Range
    End Function

    Private Sub SendAsEmail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SendAsEmail.ItemClick

        Try
            Dim oApp As Outlook.Application = New Outlook.Application
            Dim mailItem As Outlook.MailItem = TryCast(oApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)

            Dim mySignature As String
            Dim message As String
            'Hide()
            TopMost = False
            With mailItem
                .Subject = String.Format("Statement {0}", getStatementRange())
                .To = Main.DBOp.GetCompanyEmailId(CompLB.Text)
                message = "Dear Sir,<br><br>Please find the statement below and kindly arrange the payment soon. <br><br>"
                message += "<table cellspacing = -1> <tr bgcolor = ""#D9E1F2"">"
                For i As Integer = 0 To StmtDGV.ColumnCount - 1
                    message += "<th style=""padding: 0 5px; border: 1px solid #AAAAAA;"">" & StmtDGV.Columns(i).HeaderText & "</th>"
                Next
                message += "</tr>"
                Dim total As Decimal
                Try
                    For i As Integer = 0 To StmtDGV.RowCount - 1
                        message += "<tr>"
                        For j As Integer = 0 To StmtDGV.ColumnCount - 1
                            If j = StmtDGV.ColumnCount - 1 AndAlso IsNumeric(StmtDGV.Rows(i).Cells(j).Value) Then
                                total += StmtDGV.Rows(i).Cells(j).Value
                            End If
                            message += "<td style=""padding: 0 5px; border-left: 1px solid #AAAAAA; border-right: 1px solid #AAAAAA;"" align='center'>" & StmtDGV.Rows(i).Cells(j).Value & "</td>"
                        Next
                        message += "</tr>"
                    Next
                    message += "<tr bgcolor = ""#D9E1F2""><td style=""padding: 0 5px; border: 1px solid #AAAAAA;"" align='right' colspan='6'><b>Total" & "</b></td><td style=""padding: 0 5px; border: 1px solid #AAAAAA;""><b>" & total & "</b></td></tr>"
                Catch ex As Exception
                    .Close(Outlook.OlInspectorClose.olDiscard)
                End Try

                message += "</table>"
                .Display()
                mySignature = .HTMLBody
                .HTMLBody = message + mySignature
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SendAsPDF_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SendAsPDF.ItemClick
        Using WForm As New DevExpress.Utils.WaitDialogForm("Please wait")
            WForm.Show()
            Try
                Console.WriteLine("Initialize Outlook")
                Dim oApp As Outlook.Application = New Outlook.Application
                Dim mailItem As Outlook.MailItem = TryCast(oApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)

                Dim mySignature As String
                Dim message As String
                Dim PDFData As String
                'Hide()
                TopMost = False
                'Enabled = False

                With mailItem
                    Console.WriteLine("Show Wait form")

                    .Subject = String.Format("Statement {0}", getStatementRange())
                    Console.WriteLine("Start HTML Data generation")
                    PDFData = "<table cellspacing = -1> <tr bgcolor = ""#D9E1F2"">"
                    For i As Integer = 0 To StmtDGV.ColumnCount - 1
                        PDFData += "<th style=""padding: 0 5px; border: 1px solid #AAAAAA;"">" & StmtDGV.Columns(i).HeaderText & "</th>"
                    Next
                    PDFData += "</tr>"
                    Try
                        For i As Integer = 0 To StmtDGV.RowCount - 1
                            PDFData += "<tr>"
                            For j As Integer = 0 To StmtDGV.ColumnCount - 1
                                PDFData += "<td style = ""font-family: Calibri, sans-serif; padding: 0 5px; border-left: 1px solid #AAAAAA; border-right: 1px solid #AAAAAA;"" align='center'>" & StmtDGV.Rows(i).Cells(j).Value & "</td>"
                            Next
                            PDFData += "</tr>"
                        Next
                        PDFData += "<tr bgcolor = ""#D9E1F2""><td style=""padding: 0 5px; border: 1px solid #AAAAAA;"" align='right' colspan='6'><b>Total" & "</b></td><td style=""padding: 0 5px; border: 1px solid #AAAAAA;""><b>" & Net & "</b></td></tr>"
                        Console.WriteLine("HTML data generated")
                    Catch ex As Exception
                        Console.WriteLine("Error: " & ex.ToString)
                        .Close(Outlook.OlInspectorClose.olDiscard)
                    End Try

                    PDFData += "</table>"

                    Console.WriteLine("Convert HTML to PDF")
                    WForm.Hide()
                    Dim pdfName As String = InputBox("Enter name of pdf", "Name", String.Format("{0} Statement {1}.pdf",
                                                             CompLB.SelectedItems(0)(0).ToString,
                                                             getStatementRange()))
                    WForm.Show()
                    If Not pdfName.Contains("Statement") Then
                        WForm.Close()
                        .Close(Outlook.OlInspectorClose.olDiscard)
                        Exit Sub
                    End If

                    If Not pdfName.EndsWith(".pdf") Then
                        pdfName = pdfName & ".pdf"
                    End If
                    HtmlConverter.ConvertToPdf(PDFData, New FileStream(
                                               String.Format("{0}\Ravi Flags\Statements\{1}",
                                                             Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                                             pdfName),
                                               FileMode.Create, FileAccess.Write))
                    Console.WriteLine("Attach file")
                    .Attachments.Add(String.Format("{0}\Ravi Flags\Statements\{1}",
                                                             Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                                             pdfName),,)
                    Console.WriteLine("Close Waitform")
                    WForm.Close()
                    Console.WriteLine("Show Outlook message")
                    .Display()
                    mySignature = .HTMLBody
                    message = "Dear Sir,<br><br>Please find the attached statement and kindly arrange the payment soon. <br><br>"
                    .HTMLBody = message + mySignature
                End With
            Catch ex As Exception
                Console.WriteLine("Error (Main): " & ex.ToString)
                WForm.Close()
            End Try
        End Using
    End Sub

    Private Sub StmtDGV_DoubleClick(sender As Object, e As EventArgs) Handles StmtDGV.DoubleClick
        For Each row As DataGridViewRow In StmtDGV.SelectedRows
            Using invfrm As New InvoiceForm
                invfrm.Enabled = False
                FillInvoiceData(invfrm, row)
                invfrm.Enabled = True
                invfrm.SaveBtnEnable = False
                invfrm.ShowDialog()
            End Using
        Next
    End Sub
End Class