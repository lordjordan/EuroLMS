Module GeneralMethods
    Public Function NumToStr(number As String, Optional size As Byte = 8) As String
        number = FormatNumber(number, 2)
        number = Replace(number, ".", "")
        number = Replace(number, ",", "")
        number = "00000000" & number
        Return number.Substring(number.Length - size)
    End Function

    Public Function StrToNum(str As String, Optional decimalplace As Byte = 2, Optional withComma As Boolean = True) As String
        str = str.Substring(0, str.Length - decimalplace) & "." & str.Substring(str.Length - decimalplace)
        If withComma Then
            Return FormatNumber(Val(str), 2)
        Else
            Return Val(str)
        End If
    End Function

    Public Function StrToDate(str As String) As Date
        str = str.Substring(4, 2) & "/" & str.Substring(6, 2) & "/" & str.Substring(0, 4)
        Return Format(str, "Short date")
    End Function

    Public Function DateToStr(petsa As Date) As String
        Return Format(petsa, "yyyyMMdd")
    End Function
End Module
