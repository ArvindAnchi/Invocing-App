Imports System.Data.SqlClient

Public Class DatabaseOperations

    Public ConnectionString As String = "Server=.\SQLEXPRESS;Database=Deep Sea;Trusted_Connection=True;"
#Region "Read operations"
    Public Function GetNewInvoiceNumber() As String

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>

                    Select 
                        MAX(CAST([InvoiceNumber] AS INT))
        
                    From Invoices;

                </SQL>.Value

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
    Public Function GetCompanyId(CompanyName As String) As Integer
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
    Public Function GetOrderbyNamesListForCompany(CompanyName As String) As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT 
                        OrdbyName
                
                    FROM ordby
                    
                    Where CompID = @CompID
                </SQL>.Value

                cmd.Parameters.AddWithValue("@CompID", GetCompanyId(CompanyName))

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
    Public Function GetAllCompaniesList() As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT 
                        CompID,
                        CompName,
                        TRN,
                        Discount,
                        City,
                        Email,
                        Address
                
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
    Public Function GetCompanyEmailId(ByVal CompanyName As String) As String

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT                         
                        Email
                
                    FROM Companies
                    
                    Where CompID = @CompID
                </SQL>.Value

                cmd.Parameters.AddWithValue("@CompID", GetCompanyId(CompanyName))

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
    Public Function GetCompanyAddress(ByVal CompanyName As String) As String

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    SELECT                         
                        Address
                
                    FROM Companies
                    
                    Where CompID = @CompID
                </SQL>.Value

                cmd.Parameters.AddWithValue("@CompID", GetCompanyId(CompanyName))

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
    Public Function GetInvoiceListToPopulateInvoiceDGV() As DataTable
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>

                    SELECT
		                CAST(Invoices.InvoiceNumber AS int) AS [Invoice Number],
		                Invoices.InvoiceDate AS [Invoice Date],
		                Companies.CompName AS [Company name],
		                Invoices.LPONumber AS [LPO number],
		                CAST((Invoices.Total - (Invoices.Total * Invoices.Discount / 100)) + ((Invoices.Total -(Invoices.Total * Invoices.Discount / 100)) * 5 / 100) AS numeric(9, 2)) AS Total,
		                CAST((Invoices.Total - (Invoices.Total * Invoices.Discount / 100)) * 5 / 100 AS numeric(9, 2)) AS [VAT],
		                Invoices.Paid,
		                Invoices.PaidDate AS [Date of payment],
		                Invoices.ReturnedCanceled AS Canceled,
		                Invoices.Term AS [Terms of payment]
	                FROM	Invoices,
				            Companies
	                WHERE Invoices.CompID = Companies.CompID
	                ORDER BY CAST(Invoices.InvoiceNumber AS int) DESC;

                </SQL>.Value

                Dim dt As New DataTable
                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
                'Try
                '    cn.Open()
                '    dt.Load(cmd.ExecuteReader)
                '    cn.Close()
                'Catch ex As Exception
                '    MsgBox(ex.ToString)
                'End Try
                Return dt

            End Using
        End Using
    End Function
    Public Function GetCompanyListForStatement() As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>

	                SELECT
		                Companies.CompName AS [Company name],
		                SUM(Invoices.Total) AS [Amount]

	                FROM	Companies,
				                Invoices

	                WHERE Companies.CompID = Invoices.CompID
	                AND Invoices.Paid = 0

	                GROUP BY Companies.CompName;
                </SQL>.Value

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
    Public Function GetInvoicesForStatement(selectedcompindex As DataRowView) As DataTable

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>

                    SELECT
			            Invoices.InvoiceNumber AS [Invoice Number],
			            Invoices.InvoiceDate AS [Date],
			            Invoices.LPONumber AS [LPO Number],
			            Invoices.Total,
			            CAST(Invoices.Total * Invoices.Discount / 100 AS numeric(9, 2)) AS [Discount],
			            CAST((Invoices.Total - (Invoices.Total * Invoices.Discount / 100)) * 5 / 100 AS numeric(9, 2)) AS [VAT], 
			            CAST((Invoices.Total - (Invoices.Total * Invoices.Discount / 100)) + ((Invoices.Total -(Invoices.Total * Invoices.Discount / 100)) * 5 / 100) AS numeric(9, 2)) AS [Grand total] 

		            FROM	Invoices,
					        Companies

		            WHERE Invoices.CompID = Companies.CompID
		            AND Companies.CompID = @CompID
		            AND Invoices.Paid = 0
		            AND (Invoices.ReturnedCanceled = 0 OR Invoices.ReturnedCanceled IS NULL)

		            ORDER BY Invoices.InvoiceDate ASC;

                </SQL>.Value

                Dim dt As New DataTable


                cmd.Parameters.AddWithValue("@CompID", GetCompanyId(selectedcompindex.Item(0)))

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
    Public Function GetInvoiceData(Invoicenumber As String) As List(Of DataTable)
        Dim res As New List(Of DataTable)
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>	
                    SELECT
		                Invoices.InvoiceNumber,
		                Invoices.InvoiceDate,
		                Companies.CompName,
		                Companies.TRN,
		                Invoices.LPONumber,
		                OrdBy.OrdbyName,
		                Invoices.Term,
		                Invoices.Discount,
		                Invoices.Total,
		                Invoices.Total * Invoices.Discount / 100 AS [Discount],
		                Invoices.Total - (Invoices.Total * Invoices.Discount / 100) AS [Net Total],
		                --0 AS [VAT],
		                Invoices.Vat AS [VAT],
		                (Invoices.Total - (Invoices.Total * Invoices.Discount / 100)) + ((Invoices.Total - (Invoices.Total * Invoices.Discount / 100)) * 5 / 100) AS [Grand total]

	                FROM	Invoices,
				            Companies,
				            OrdBy

	                WHERE Invoices.CompID = Companies.CompID
	                    AND Invoices.InvoiceNumber = @InvoiceNumber
	                    AND Invoices.OrdById = OrdBy.OrdById;
                </SQL>.Value
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

                cmd.CommandText = <SQL>	
                    SELECT
		                ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS [S.N.],
		                [Description] AS [Description],
		                [Unit] AS [Unit],
		                [Quantity] AS [Quantity],
		                ROUND([Price], 2) AS [Price],
		                [Quantity] * [Price] AS [Total]

	                FROM Invoicedata

	                WHERE [InvoiceNumber] = @InvoiceNumber;
                </SQL>.Value

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
    Public Function GetOrderbyIdAndInsertIntoTableIfOneDoesntExist(OrdByName As String, compID As String) As Integer
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}

                Dim result As Integer
                cn.Open()

                cmd.CommandText = <SQL>	
                    IF (NOT EXISTS(SELECT [OrdById] FROM [Deep Sea].[dbo].[OrdBy] WHERE [CompID] = @CompID AND [OrdbyName] = @ODname))
		                INSERT INTO OrdBy (CompID, OrdbyName) VALUES (@CompID, @ODname)
	                SELECT [OrdById]
	                  FROM [Deep Sea].[dbo].[OrdBy]
	                  WHERE [CompID] = @CompID AND [OrdbyName] = @ODname
                </SQL>.Value

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

                cmd.CommandText = <SQL>

                    SELECT
                        Id AS [Reference Number],
                        Date AS [Date],
                        Supplier AS [Supplier Name],
                        Trn AS [TRN Number],
                        CAST(Amount - (Amount / (100/5 + 1)) AS numeric(9, 2)) AS [Amount before VAT],
                        CAST(Amount / (100/5 + 1) AS numeric(9, 2)) AS [VAT],
                        CAST(Amount AS numeric(9, 2)) AS [Final amount]
                    FROM Expense
                    ORDER BY Date DESC

                </SQL>.Value
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
    Public Function GetInvoiceDetailsForVAT(StartDate As Date, EndDate As Date) As DataTable
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}

                cmd.CommandText = <SQL>
                    SELECT
		                Invoices.InvoiceNumber AS [Invoice number],
		                Companies.CompName AS [Company],
	                    Companies.City AS [City],
		                Companies.TRN,
		                Invoices.InvoiceDate AS [Date],
		                Invoices.LPONumber AS [LPO number],
	                    CAST(Invoices.Total - (Invoices.Total * Invoices.Discount / 100) AS numeric(9, 2)) AS [Net total],
	                    CAST((Invoices.Total - (Invoices.Total * Invoices.Discount / 100)) * 5 / 100 AS numeric(9, 2)) AS [VAT], 
	                    CAST((Invoices.Total - (Invoices.Total * Invoices.Discount / 100)) + ((Invoices.Total -(Invoices.Total * Invoices.Discount / 100)) * 5 / 100) AS numeric(9, 2)) AS [Grand total] 

                    FROM Companies INNER JOIN Invoices ON Invoices.CompID = Companies.CompID

                    WHERE (Invoices.ReturnedCanceled = 0 OR Invoices.ReturnedCanceled IS NULL)
		                AND Invoices.InvoiceDate BETWEEN @StartDate AND @EndDate
                </SQL>.Value

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
#End Region
#Region "Write operations"
    Public Function WriteNewInvoice(invoicefrm As InvoiceForm) As Boolean
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}

                With invoicefrm
                    '//////////----Write Invoices table----//////////'

                    cmd.CommandText = <SQL>
                        IF (NOT EXISTS (SELECT invoicenumber FROM invoices WHERE invoicenumber = @InvoiceNumber))
		                    INSERT INTO invoices (invoicenumber, compid, lponumber, invoicedate, ordbyid, total, discount, term, Paid, Vat)
		                    VALUES (@InvoiceNumber, @CompID, @LPONumber, @InvoiceDate, @OrdBy, @Total, @Discount, @Term, 0, @Vat)
	                    ELSE
		                    UPDATE invoices
		                    SET	compid = @CompID, lponumber = @LPONumber, invoicedate = @InvoiceDate, ordbyid = @OrdBy, total = @Total, discount = @Discount, term = @Term, Vat = @Vat
		                    WHERE invoicenumber = @InvoiceNumber
                    </SQL>.Value


                    Dim comid As Integer = GetCompanyId(.cnametxt.Text)
                    cmd.Parameters.AddWithValue("@InvoiceNumber", .invnotxt.Text)
                    If comid = 0 Then
                        Dim NewCompFrm As New AddComp
                        NewCompFrm.ncnametxt.Text = .cnametxt.Text
                        NewCompFrm.ncnametxt.Enabled = False
                        NewCompFrm.ntrntxt.Text = .trntxt.Text
                        NewCompFrm.ntrntxt.Enabled = False
                        NewCompFrm.nDiscText.Text = .disctxt.Text
                        NewCompFrm.ShowDialog()
                        comid = GetCompanyId(.cnametxt.Text)
                    End If
                    cmd.Parameters.AddWithValue("@CompID", comid)
                    cmd.Parameters.AddWithValue("@LPONumber", .lpotxt.Text)
                    Try
                        cmd.Parameters.AddWithValue("@InvoiceDate", .DateTimePicker1.Value)
                    Catch ex As Exception
                        MsgBox(.DateTimePicker1.Value & "Error")
                        Return False
                    End Try

                    cmd.Parameters.AddWithValue("@OrdBy", GetOrderbyIdAndInsertIntoTableIfOneDoesntExist(.Ordbycb.Text, comid))
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
                        Console.WriteLine(String.Format("Total: {0}", .prcnos.Text.Split(vbNewLine)(0)))
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                        MsgBox(ex.ToString, MessageBoxIcon.Error, "Error")
                        cn.Close()
                        Return False
                    End Try

                    cmd.CommandText = <SQL>
                        IF (EXISTS (SELECT invoicenumber FROM Invoicedata WHERE invoicenumber = @InvoiceNumber))
		                    SELECT 1
	                    ELSE
		                    SELECT 0    
                    </SQL>.Value

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

                        For row As Integer = 0 To invoicefrm.InvoiceItemsDGV.Rows.Count - 2

                            cmd.CommandText = <SQL>
                                INSERT INTO 
                                    Invoicedata (InvoiceNumber, Description, Unit, Quantity, Price)
                 
                                VALUES 
                                    (@InvoiceNumber, @Description, @Unit, @Quantity, @Price)</SQL>.Value

                            cmd.CommandType = CommandType.Text
                            cmd.Parameters.Clear()

                            cmd.Parameters.AddWithValue("@InvoiceNumber", .invnotxt.Text)
                            cmd.Parameters.AddWithValue("@Description", .InvoiceItemsDGV.Rows(row).Cells(1).Value)
                            cmd.Parameters.AddWithValue("@Unit", .InvoiceItemsDGV.Rows(row).Cells(2).Value)
                            cmd.Parameters.AddWithValue("@Quantity", .InvoiceItemsDGV.Rows(row).Cells(3).Value)
                            cmd.Parameters.AddWithValue("@Price", .InvoiceItemsDGV.Rows(row).Cells(4).Value)

                            cmd.ExecuteNonQuery()

                        Next


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
    Public Function SetInvoicePaidStatus(InvoiceNumber As Integer, Paid As Boolean, pdate As String) As Boolean
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}

                cmd.CommandText = <SQL>
                    UPDATE Invoices SET Paid = @tf, PaidDate = @pda Where InvoiceNumber = @InvoiceNumber
                </SQL>.Value

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
    Public Function SetInvoiceCanceledStatus(InvoiceNumber As Integer, Canceled As Boolean) As Boolean
        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>
                    UPDATE Invoices SET ReturnedCanceled = @tf Where InvoiceNumber = @InvoiceNumber
                </SQL>.Value
                cmd.Parameters.AddWithValue("@tf", Canceled)
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
    Public Function AddNewCompany(cname As String, City As String, trn As String, email As String, Disc As Integer, Address As String) As Boolean

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>

                    INSERT INTO 
                        Companies (CompName, City, TRN, Email, Discount, Address)

                    VALUES 
                        (@cname, @City, @trn, @email, @Disc, @Address)</SQL>.Value

                cmd.Parameters.AddWithValue("@cname", cname)
                cmd.Parameters.AddWithValue("@City", City)
                cmd.Parameters.AddWithValue("@trn", trn)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@Disc", Disc)
                cmd.Parameters.AddWithValue("@Address", Address)


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
    Public Function UpdateCompanyDetails(cid As String, cname As String, City As String, trn As String, email As String, Disc As Integer, Address As String) As Boolean

        Using cn As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand With {.Connection = cn}
                cmd.CommandText = <SQL>

                    UPDATE Companies 
                    SET CompName = @cname, City = @City, TRN = @trn, Email = @email, Discount = @Disc, Address = @Address
                    WHERE CompID = @cid

                </SQL>.Value

                cmd.Parameters.AddWithValue("@cid", cid)
                cmd.Parameters.AddWithValue("@cname", cname)
                cmd.Parameters.AddWithValue("@City", City)
                cmd.Parameters.AddWithValue("@trn", trn)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@Disc", Disc)
                cmd.Parameters.AddWithValue("@Address", Address)


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
                        Expense (Id, Supplier, Amount, Date, Trn)

                    VALUES 
                        (@Id, @supplier, @amount, @date, @Trn)</SQL>.Value

                cmd.Parameters.AddWithValue("@Id", ExpFrm.aereftxt.Text)
                cmd.Parameters.AddWithValue("@supplier", ExpFrm.aecomptxt.Text)
                cmd.Parameters.AddWithValue("@amount", If(String.IsNullOrEmpty(ExpFrm.aeammounttxt.Text), DBNull.Value, CDbl(ExpFrm.aeammounttxt.Text)))
                cmd.Parameters.AddWithValue("@date", ExpFrm.aedtpicker.Value)
                cmd.Parameters.AddWithValue("@Trn", If(String.IsNullOrEmpty(ExpFrm.aetrntxt.Text), DBNull.Value, ExpFrm.aetrntxt.Text))


                Dim dt As New DataTable

                Try
                    cn.Open()
                    dt.Load(cmd.ExecuteReader)
                    cn.Close()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Return False
                End Try

                Return True

            End Using
        End Using

        Return False
    End Function
End Class
#End Region