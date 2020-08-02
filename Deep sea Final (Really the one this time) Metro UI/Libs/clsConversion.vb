'Option Strict Off
Public Class ClsConversion
    ReadOnly mOnesArray(8) As String
    ReadOnly mOneTensArray(9) As String
    ReadOnly mTensArray(7) As String
    ReadOnly mPlaceValues(4) As String


    Public Sub New()

        mOnesArray(0) = "one"
        mOnesArray(1) = "two"
        mOnesArray(2) = "three"
        mOnesArray(3) = "four"
        mOnesArray(4) = "five"
        mOnesArray(5) = "six"
        mOnesArray(6) = "seven"
        mOnesArray(7) = "eight"
        mOnesArray(8) = "nine"

        mOneTensArray(0) = "ten"
        mOneTensArray(1) = "eleven"
        mOneTensArray(2) = "twelve"
        mOneTensArray(3) = "thirteen"
        mOneTensArray(4) = "fourteen"
        mOneTensArray(5) = "fifteen"
        mOneTensArray(6) = "sixteen"
        mOneTensArray(7) = "seventeen"
        mOneTensArray(8) = "eightteen"
        mOneTensArray(9) = "nineteen"

        mTensArray(0) = "twenty"
        mTensArray(1) = "thirty"
        mTensArray(2) = "forty"
        mTensArray(3) = "fifty"
        mTensArray(4) = "sixty"
        mTensArray(5) = "seventy"
        mTensArray(6) = "eighty"
        mTensArray(7) = "ninety"

        mPlaceValues(0) = "hundred"
        mPlaceValues(1) = "thousand"
        mPlaceValues(2) = "million"
        mPlaceValues(3) = "billion"
        mPlaceValues(4) = "trillion"

    End Sub


    Protected Function GetOnes(ByVal OneDigit As Integer) As String

        GetOnes = ""

        If OneDigit = 0 Then
            Exit Function
        End If

        GetOnes = mOnesArray(OneDigit - 1)

    End Function


    Protected Function GetTens(ByVal TensDigit As Integer) As String

        GetTens = ""

        If TensDigit = 0 Or TensDigit = 1 Then
            Exit Function
        End If

        GetTens = mTensArray(TensDigit - 2)

    End Function


    Public Function ConvertNumberToWords(ByVal NumberValue As String) As String

        Dim Delimiter As String = " "
        Dim TensDelimiter As String = "-"
        Dim mNumWord As String = ""
        Dim mFraction As String = ""
        Dim mNumberStack() As String = {}
        Dim i As Integer = 0
        Dim mOneTens As Boolean = False


        Dim j As Double
        ' validate input
        Try
            j = CDbl(NumberValue)
        Catch ex As Exception
            ConvertNumberToWords = "Invalid input."
            Exit Function
        End Try

        Dim mNumberValue As String
        ' get fractional part {if any}
        If InStr(NumberValue, ".") = 0 Then
            ' no fraction
            mNumberValue = NumberValue
        Else
            mNumberValue = Left(NumberValue, InStr(NumberValue, ".") - 1)
            mFraction = Mid(NumberValue, InStr(NumberValue, ".")) ' + 1)
            mFraction = (Math.Round(CSng(mFraction), 2) * 100).ToString

            If CInt(mFraction) = 0 Then
                mFraction = ""
            Else
                mFraction = " and " & ConvertNumberToWords(mFraction)
            End If
        End If
        Dim mNumbers As String = mNumberValue.ToCharArray

        ' move numbers to stack/array backwards
        For j = mNumbers.Length - 1 To 0 Step -1
            ReDim Preserve mNumberStack(i)

            mNumberStack(i) = mNumbers(CInt(j))
            i += 1
        Next

        For j = mNumbers.Length - 1 To 0 Step -1
            Select Case j
                Case 0, 3, 6, 9, 12
                    ' ones  value
                    If Not mOneTens Then
                        mNumWord &= GetOnes(CInt(Val(mNumberStack(CInt(j))))) & Delimiter
                    End If

                    Select Case j
                        Case 3
                            ' thousands
                            mNumWord &= mPlaceValues(1) & Delimiter

                        Case 6
                            ' millions
                            mNumWord &= mPlaceValues(2) & Delimiter

                        Case 9
                            ' billions
                            mNumWord &= mPlaceValues(3) & Delimiter

                        Case 12
                            ' trillions
                            mNumWord &= mPlaceValues(4) & Delimiter
                    End Select


                Case Is = 1, 4, 7, 10, 13
                    ' tens value
                    If Val(mNumberStack(CInt(j))) = 0 Then
                        mNumWord &= GetOnes(CInt(Val(mNumberStack(CInt(j - 1))))) & Delimiter
                        mOneTens = True
                        Exit Select
                    End If

                    If Val(mNumberStack(CInt(j))) = 1 Then
                        mNumWord &= mOneTensArray(CInt(Val(mNumberStack(CInt(j - 1))))) & Delimiter
                        mOneTens = True
                        Exit Select
                    End If

                    mNumWord &= GetTens(CInt(Val(mNumberStack(CInt(j)))))

                    ' this places the tensdelimiter; check for succeeding 0
                    If Val(mNumberStack(CInt(j - 1))) <> 0 Then
                        mNumWord &= TensDelimiter
                    End If
                    mOneTens = False

                Case Else
                    ' hundreds value 
                    mNumWord &= GetOnes(CInt(Val(mNumberStack(CInt(j))))) & Delimiter

                    If Val(mNumberStack(CInt(j))) <> 0 Then
                        mNumWord &= mPlaceValues(0) & Delimiter
                    End If
            End Select
        Next

        Return mNumWord & mFraction

    End Function



End Class