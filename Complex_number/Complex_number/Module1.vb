Imports Complex_number

Module Module1
    'todo split on +/- not J
    Sub Main()
        Dim n1 = New Complex_Num("3+j2")
        Dim n2 = New Complex_Num("J2")

        Console.WriteLine((n1 / n2))

        Console.ReadKey()

    End Sub

End Module
Class Complex_Num

    Public num As String

    Public Sub New(num As String)
        Me.num = num
    End Sub

    Structure ComplexNumPair
        Dim re, img As Double
        Public Sub New(re As Double, img As Double)
            Me.re = re
            Me.img = img
        End Sub


    End Structure

    Private parseOut As KeyValuePair(Of ComplexNumPair, ComplexNumPair)
    Private Shared Function StringToComplex(ByVal n1 As Complex_Num)
        Dim res = New ComplexNumPair(1, 1)
        Dim s() As String
        If (n1.num(0) = "j") Or (n1.num(0) = "J") Then
            n1.num = n1.num.Insert(0, "+")

        End If


        If (n1.num.Contains("+J")) Then
            s = Split(n1.num, "+J")
        ElseIf (n1.num.Contains("+j")) Then
            s = Split(n1.num, "+j")
        ElseIf (n1.num.Contains("-J")) Then
            s = Split(n1.num, "-J")
            res.img *= -1
        ElseIf (n1.num.Contains("-j")) Then
            s = Split(n1.num, "-j")
            res.img *= -1
        Else
            Return New ComplexNumPair(Double.Parse(n1.num), 0)
        End If


        If (s(0).Length > 0) Then
            res.re *= Double.Parse(s(0))
        Else
            res.re = 0
        End If


        If (s(1).Length > 0) Then
            res.img *= Double.Parse(s(1))
        End If


        Return res
    End Function
    Private Shared Function ComplexToString(n1 As ComplexNumPair)
        Dim res As String
        res = n1.re.ToString()
        If (n1.img < 0) Then
            n1.img *= -1
            res += "-"
        Else
            res += "+"
        End If
        res += "J" + n1.img.ToString()
        Return res
    End Function

    Shared Function Add(ByVal n1 As Complex_Num, ByVal n2 As Complex_Num)

        Dim np1 As ComplexNumPair = StringToComplex(n1)
        Dim np2 As ComplexNumPair = StringToComplex(n2)

        Return ComplexToString(New ComplexNumPair(np1.re + np2.re, np1.img + np2.img))

    End Function
    Shared Function Subb(ByVal n1 As Complex_Num, ByVal n2 As Complex_Num)
        Dim np1 As ComplexNumPair = StringToComplex(n1)
        Dim np2 As ComplexNumPair = StringToComplex(n2)

        Return ComplexToString(New ComplexNumPair(np1.re - np2.re, np1.img - np2.img))

    End Function
    Shared Function Mul(ByVal n1 As Complex_Num, ByVal n2 As Complex_Num)
        Dim np1 As ComplexNumPair = StringToComplex(n1)
        Dim np2 As ComplexNumPair = StringToComplex(n2)

        Return ComplexToString(New ComplexNumPair(np1.re * np2.re - np1.img * np2.img, np1.img * np2.re + np1.re * np2.img))

    End Function

    Shared Function Div(ByVal n1 As Complex_Num, ByVal n2 As Complex_Num)
        Dim np2 As ComplexNumPair = StringToComplex(n2)
        Dim np2Conj = New ComplexNumPair(np2.re, -1 * np2.img)
        Dim n2Conj = New Complex_Num(ComplexToString(np2Conj))

        Return (n1 * n2Conj) / (np2.re * np2.re + np2.img * np2.img)

    End Function



    Public Shared Operator +(ByVal n1 As Complex_Num, ByVal n2 As Complex_Num) As Complex_Num
        Return New Complex_Num(Add(n1, n2))
    End Operator
    Public Shared Operator -(ByVal n1 As Complex_Num, ByVal n2 As Complex_Num) As Complex_Num
        Return New Complex_Num(Subb(n1, n2))
    End Operator
    Public Shared Operator /(ByVal n1 As Complex_Num, ByVal n2 As Complex_Num) As Complex_Num
        Return (Div(n1, n2))
    End Operator
    Public Shared Operator /(ByVal n1 As Complex_Num, ByVal n2 As Double) As Complex_Num
        Dim np1 As ComplexNumPair = StringToComplex(n1)
        Return New Complex_Num(ComplexToString(New ComplexNumPair(np1.re / n2, np1.img / n2)))
    End Operator
    Public Shared Operator *(ByVal n1 As Complex_Num, ByVal n2 As Complex_Num) As Complex_Num
        Return New Complex_Num(Mul(n1, n2))
    End Operator

    Public Shared Widening Operator CType(ByVal s As Complex_Num) As String
        Return s.num
    End Operator
    Public Shared Narrowing Operator CType(ByVal c As Byte) As Complex_Num
        Return New Complex_Num(c)
    End Operator

End Class