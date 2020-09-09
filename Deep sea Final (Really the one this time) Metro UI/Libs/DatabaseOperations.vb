Imports System.Data.SqlClient

Public Class DatabaseOperations

    Public ConnectionString As String = "Server=.\SQLEXPRESS;Database=Deep Sea;Trusted_Connection=True;"
    Public filesupdatedlist As New List(Of String)
    'Read operations
    Public Function Getinvno() As String

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    Select 
                        MAX(CAST([InvoiceNumber] AS INT))
        
                    From Invoices;</SQL>.Value

                Dim dt As New DataTable
                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Return (dt.Rows(0).Item(0) + 1).ToString

            End Using
        End Using
    End Function
    Public Function Getcompid(CompanyName As String) As Integer
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    Select 
                        CompID
        
                    From Companies
                    
                    Where CompName = @cname;</SQL>.Value

                cmd.Parameters.AddWithValue("@cname", CompanyName)

                Dim dt As New DataTable
                Dim result As Integer
                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                    result = dt.Rows(0).Item(0)
                Catch ex As Exception
                    result = 0
                End Try
                Return result

            End Using
        End Using
    End Function
    Public Function LoadOrdByName(CompanyName As String) As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT 
                        OrdbyName
                
                    FROM ordby
                    
                    Where CompID = @CompID
                </SQL>.Value

                cmd.Parameters.AddWithValue("@CompID", Getcompid(CompanyName))

                Using dt As New DataTable
                    Try
                        cn.Open()
                        dt.Load(cmd.ExecuteReader)
                        cn.Close()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                    End Try

                    Return dt
                End Using

            End Using
        End Using
    End Function
    Public Function LoadCompLST() As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT 
                        CompID,
                        CompName,
                        TRN,
                        Discount,
                        City,
                        Email
                
                    FROM Companies

                    ORDER BY CompName
                
                </SQL>.Value

                Using dt As New DataTable
                    Try
                        cn.Open()
                        dt.Load(cmd.ExecuteReader)
                        cn.Close()
                    Catch ex As Exception
                        MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                    End Try

                    Return dt
                End Using

            End Using
        End Using
    End Function
    Public Function LoadCompEmail(ByVal CompanyName As String) As String

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT                         
                        Email
                
                    FROM Companies
                    
                    Where CompID = @CompID
                </SQL>.Value

                cmd.Parameters.AddWithValue("@CompID", Getcompid(CompanyName))

                Using dt As New DataTable
                    Try
                        cn.Open()
                        dt.Load(cmd.ExecuteReader)
                        cn.Close()
                    Catch ex As Exception
                        MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                    End Try

                    Return dt.Rows(0).ItemArray(0).ToString()
                End Using

            End Using
        End Using
    End Function
    Public Function LoadInvoicesDGV() As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "GetInvoices"
                cmd.CommandType = CommandType.StoredProcedure
                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Return dt

            End Using
        End Using
    End Function
    Public Function LoadVATDGV() As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "GetVATDetails"
                cmd.CommandType = CommandType.StoredProcedure
                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                End Try

                Return dt

            End Using
        End Using
    End Function
    Public Function LoadCompLSTDGV() As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "GetCompanies"
                cmd.CommandType = CommandType.StoredProcedure

                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception

                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                End Try

                Return dt

            End Using
        End Using
    End Function
    Public Function LoadStmntDGV(selectedcompindex As DataRowView) As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "GenStatement"
                cmd.CommandType = CommandType.StoredProcedure

                Dim dt As New DataTable


                cmd.Parameters.AddWithValue("@compID", Getcompid(selectedcompindex.Item(0)))

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                End Try

                Return dt

            End Using
        End Using
    End Function
    Public Function ReadInvocie(Invoicenumber As String) As List(Of DataTable)
        Dim res As New List(Of DataTable)
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "GetInvoiceHeadder"
                cmd.CommandType = CommandType.StoredProcedure
                Dim dt As New DataTable
                cmd.Parameters.AddWithValue("@InvoiceNumber", Invoicenumber)
                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                Catch ex As Exception
                    cn.Close()
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                End Try
                cmd.Parameters.Clear()
                cmd.CommandText = "GetInvoiceFlags"

                Dim dtinvdata As New DataTable
                cmd.Parameters.AddWithValue("@InvoiceNumber", Invoicenumber)
                Try
                    dtinvdata.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    cn.Close()
                    MsgBox(ex.ToString)
                End Try
                res.Add(dt)
                res.Add(dtinvdata)
            End Using
        End Using
        Return res
    End Function
    Public Function GetOrdById(OrdByName As String, compID As String) As Integer
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}

                Dim result As Integer
                cn.Open()

                cmd.CommandText = "GetOrdByID"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@CompID", compID)
                cmd.Parameters.AddWithValue("@ODname", OrdByName)

                Try
                    result = cmd.ExecuteScalar()
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    cn.Close()
                End Try

                Return result

            End Using
        End Using
    End Function
    Public Function GetExpenses() As DataTable
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}

                cmd.CommandText = "SELECT Id AS [Reference Number], Company AS [Company Name], Amount, Date AS [Date] FROM Expense"
                cmd.CommandType = CommandType.Text

                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                End Try

                Return dt

            End Using
        End Using
    End Function

    Public Function GetVATReport(StartDate As Date, EndDate As Date) As DataTable
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}


                cmd.CommandText = "GetVATDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@StartDate", StartDate)
                cmd.Parameters.AddWithValue("@EndDate", EndDate)

                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                End Try

                Return dt

            End Using
        End Using
    End Function
    'Write operations
    Public Function WriteInvoice(invoicefrm As InvoiceForm) As Boolean
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}

                With invoicefrm
                    '//////////----Write Invoices table----//////////'

                    cmd.CommandText = "WriteInvoicesTable"
                    cmd.CommandType = CommandType.StoredProcedure

                    Dim comid As Integer = Getcompid(.cnametxt.Text)
                    cmd.Parameters.AddWithValue("@InvoiceNumber", .invnotxt.Text)
                    If comid = 0 Then
                        Dim NewCompFrm As New AddComp
                        NewCompFrm.ncnametxt.Text = .cnametxt.Text
                        NewCompFrm.ncnametxt.Enabled = False
                        NewCompFrm.ntrntxt.Text = .trntxt.Text
                        NewCompFrm.ntrntxt.Enabled = False
                        NewCompFrm.nDiscText.Text = .disctxt.Text
                        NewCompFrm.ShowDialog()
                        comid = Getcompid(.cnametxt.Text)
                    End If
                    cmd.Parameters.AddWithValue("@CompID", comid)
                    cmd.Parameters.AddWithValue("@LPONumber", .lpotxt.Text)
                    Try
                        cmd.Parameters.AddWithValue("@InvoiceDate", .DateTimePicker1.Value)
                    Catch ex As Exception
                        MsgBox(.DateTimePicker1.Value & "Error")
                        Return False
                    End Try

                    cmd.Parameters.AddWithValue("@OrdBy", GetOrdById(.Ordbycb.Text, comid))
                    cmd.Parameters.AddWithValue("@Total", .prcnos.Text.Split(vbNewLine)(0))
                    cmd.Parameters.AddWithValue("@Discount", .disctxt.Text)

                    If invoicefrm.TrmCash.Checked Then
                        cmd.Parameters.AddWithValue("@Term", 0)
                    Else
                        cmd.Parameters.AddWithValue("@Term", CInt(.TermTXT.Text))
                    End If

                    If invoicefrm.VatCB.Checked Then
                        cmd.Parameters.AddWithValue("@Vat", 1)
                    Else
                        cmd.Parameters.AddWithValue("@Vat", 0)
                    End If

                    cn.Open()
                    Try
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                        cn.Close()
                        Return False
                    End Try

                    cmd.CommandText = "CheckInvoiceData"
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@InvoiceNumber", .invnotxt.Text)
                    Dim invoicePresent As String = cmd.ExecuteScalar()
                    Try

                        If invoicePresent = 1 Then
                            cmd.CommandText = <SQL>
                                DELETE FROM Invoicedata
                                WHERE invoicenumber = @InvoiceNumber;</SQL>.Value

                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("@InvoiceNumber", .invnotxt.Text)
                            cmd.CommandType = CommandType.Text
                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox(ex.ToString)
                                MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                                cn.Close()
                                Return False
                            End Try
                        End If
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                        cn.Close()
                        Return False
                    End Try

                    '//////////----Write Invoicedata table----//////////'
                    Try

                        For row As Integer = 0 To invoicefrm.DGV1.Rows.Count - 2

                            cmd.CommandText = <SQL>
                                INSERT INTO 
                                    Invoicedata (InvoiceNumber, Description, Unit, Quantity, Price)
                 
                                VALUES 
                                    (@InvoiceNumber, @Description, @Unit, @Quantity, @Price)</SQL>.Value

                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.Clear()

                            cmd.Parameters.AddWithValue("@InvoiceNumber", .invnotxt.Text)
                            cmd.Parameters.AddWithValue("@Description", .DGV1.Rows(row).Cells(1).Value)
                            cmd.Parameters.AddWithValue("@Unit", .DGV1.Rows(row).Cells(2).Value)
                            cmd.Parameters.AddWithValue("@Quantity", .DGV1.Rows(row).Cells(3).Value)
                            cmd.Parameters.AddWithValue("@Price", .DGV1.Rows(row).Cells(4).Value)

                            cmd.ExecuteNonQuery()

                        Next

                        MsgBox("Saved!", vbOKOnly, "Done")

                    Catch ex As Exception
                        MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                        cn.Close()
                        Return False
                    End Try

                End With
                cn.Close()
                Return True

            End Using
        End Using
    End Function
    Public Function InvoicePaid(InvoiceNumber As Integer, Paid As Boolean, pdate As String) As Boolean
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}

                cmd.CommandText = "UPDATE Invoices SET Paid = @tf, PaidDate = @pda Where InvoiceNumber = @InvoiceNumber"

                cmd.Parameters.AddWithValue("@tf", Paid)

                If pdate IsNot Nothing Then
                    cmd.Parameters.AddWithValue("@pda", CDate(pdate))
                Else
                    cmd.Parameters.AddWithValue("@pda", DBNull.Value)
                End If

                cmd.Parameters.AddWithValue("@InvoiceNumber", InvoiceNumber)
                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                End Try

            End Using
        End Using
        Return True
    End Function
    Public Function InvoiceCanceled(InvoiceNumber As Integer, Paid As Boolean) As Boolean
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = "UPDATE Invoices SET ReturnedCanceled = @tf Where InvoiceNumber = @InvoiceNumber"
                cmd.Parameters.AddWithValue("@tf", Paid)
                cmd.Parameters.AddWithValue("@InvoiceNumber", InvoiceNumber)
                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                End Try

            End Using
        End Using
        Return True
    End Function
    Public Function RemoveInvoice(InvoiceNumber As Integer) As Boolean

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    DELETE
                        
                    FROM
                        Invoices
                    
                    WHERE Invoices.InvoiceNumber = @InvoiceNumber
                </SQL>.Value
                cmd.Parameters.AddWithValue("@InvoiceNumber", InvoiceNumber)
                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
                cmd.Parameters.Clear()
                cmd.CommandText = <SQL>
                    DELETE
                        
                    FROM
                        Invoicedata
                    
                    WHERE Invoicedata.InvoiceNumber = @InvoiceNumber
                </SQL>.Value
                cmd.Parameters.AddWithValue("@InvoiceNumber", InvoiceNumber)
                Try
                    cn.Open()
                    cmd.ExecuteNonQuery()
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End Using
        End Using
        Return True
    End Function
    Public Function AddCompToDB(cname As String, City As String, trn As String, email As String, Disc As Integer) As Boolean

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>

                    INSERT INTO 
                        Companies (CompName, City, TRN, Email, Discount)

                    VALUES 
                        (@cname, @City, @trn, @email, @Disc)</SQL>.Value

                cmd.Parameters.AddWithValue("@cname", cname)
                cmd.Parameters.AddWithValue("@City", City)
                cmd.Parameters.AddWithValue("@trn", trn)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@Disc", Disc)


                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                    Return False
                End Try

                Return True

            End Using
        End Using
    End Function
    Public Function AddExpenses(ExpFrm As Expenses) As Boolean
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>

                    INSERT INTO 
                        Expense (Id, Company, Amount, Date)

                    VALUES 
                        (@Id, @company, @amount, @date)</SQL>.Value

                cmd.Parameters.AddWithValue("@Id", ExpFrm.aereftxt.Text)
                cmd.Parameters.AddWithValue("@company", ExpFrm.aecomptxt.Text)
                cmd.Parameters.AddWithValue("@amount", ExpFrm.aeammounttxt.Text)
                cmd.Parameters.AddWithValue("@date", ExpFrm.aedtpicker.Value)


                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                    Return False
                End Try

                Return True

            End Using
        End Using

        Return False
    End Function

End Class