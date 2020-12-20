''' <summary>
''' Converts Integer or Decimal numbers into their textual String representations (converts numbers to words).
''' </summary>
''' <remarks></remarks>
Public NotInheritable Class NumericStrings
    Public Const MAX_DECIMAL_VALUE As Decimal = 2147483647.2147483647D

    Public Shared DecimalSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Public Shared GroupSeparator As String = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator
    Public Shared SpaceString As String = " "
    Public Shared AndString As String = "Dirhams and"
    Public Shared DashString As String = "-"
    Public Shared DecimalString As String = "Fils Olny"
    Public Shared NegativeString As String = ""

    Protected Sub New()
    End Sub

    Public Enum RootNumbers
        zero
        one
        two
        three
        four
        five
        six
        seven
        eight
        nine
        ten
        eleven
        twelve
        thirteen
        fourteen
        fifteen
        sixteen
        seventeen
        eighteen
        nineteen
        twenty
        thirty = 30
        forty = 40
        fifty = 50
        sixty = 60
        seventy = 70
        eighty = 80
        ninety = 90
        hundred = 100
        thousand = 1000
        million = 1000000
        billion = 1000000000
    End Enum

    Public Shared Function GetRootNumberWord(ByVal number As RootNumbers) As String
        Return [Enum].GetName(GetType(RootNumbers), number)
    End Function

    Public Shared Function GetRootNumberWord(ByVal number As Integer) As String
        Return [Enum].GetName(GetType(RootNumbers), number)
    End Function

    Public Shared Function GetDigitWords(ByVal number As Integer) As String
        Dim result As New System.Text.StringBuilder
        Dim digits() As Char = number.ToString.ToCharArray
        For Each digit As Char In digits
            If result.Length > 0 Then
                result.Append(SpaceString)
            End If
            result.Append(GetRootNumberWord(Val(digit)))
        Next
        Return result.ToString
    End Function

    Public Shared Function GetNumberWords(ByVal number As Decimal) As String
        If number > MAX_DECIMAL_VALUE Then
            Return "Overflow"
        End If
        Dim result As New System.Text.StringBuilder
        Dim parts() As String = number.ToString.Split({DecimalSeparator}, StringSplitOptions.None)
        result.Append(GetNumberWords(CInt(parts(0))))
        If parts.Length > 1 Then
            result.Append(SpaceString)
            result.Append(DecimalString)
            result.Append(SpaceString)
            Dim mantissaString As String = parts(1) '.TrimEnd("0"c)
            If mantissaString.Length > 9 Then mantissaString = mantissaString.Substring(0, 9)
            For i = 0 To mantissaString.Length - 1
                If mantissaString(i) = "0"c Then
                    result.Append(GetDigitWords(0))
                    result.Append(" "c)
                Else
                    Exit For
                End If
            Next
            result.Append(GetDigitWords(CInt(mantissaString)))
        End If
        Return result.ToString
    End Function

    Public Shared Function GetNumberWords(ByVal number As Integer) As String
        If number = 0 Then Return GetRootNumberWord(0)

        If number < 0 Then
            Return NegativeString & SpaceString & GetNumberWords(System.Math.Abs(number))
        End If

        Dim result As New System.Text.StringBuilder
        Dim digitIndex As Integer = 9
        While digitIndex > 1
            Dim digitValue As Integer = CInt(10 ^ digitIndex)
            If number \ digitValue > 0 Then
                result.Append(GetNumberWords(number \ digitValue))
                result.Append(SpaceString)
                result.Append(GetRootNumberWord(digitValue))
                result.Append(SpaceString)
                number = number Mod digitValue
            End If

            If digitIndex = 9 Then
                digitIndex = 6
            ElseIf digitIndex = 6 Then
                digitIndex = 3
            ElseIf digitIndex = 3 Then
                digitIndex = 2
            Else
                digitIndex = 0
            End If
        End While

        If number > 0 Then
            If result.Length > 0 Then
                result.Append(AndString)
                result.Append(SpaceString)
            End If

            If number < 20 Then
                result.Append(GetRootNumberWord(number))
            Else
                result.Append(GetRootNumberWord((number \ 10) * 10))
                Dim modTen As Integer = number Mod 10
                If modTen > 0 Then
                    result.Append(DashString)
                    result.Append(GetRootNumberWord(modTen))
                End If
            End If
        End If

        Return result.ToString
    End Function
End Class