Imports System.Security.Cryptography
Imports System.Text

Module MD5

    Public Function MD5Hash(ByVal value As String) As String
        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        Using currentMD5 As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()
            ' Convert the input string to a byte array and compute the hash.
            Dim data As Byte() = currentMD5.ComputeHash(Encoding.UTF8.GetBytes(value))

            ' Loop through each byte of the hashed data 
            ' and format each one as a hexadecimal string.
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i

            ' Return the hexadecimal string.
        End Using
        Return sBuilder.ToString()
    End Function

    Public Function MD5FileHash(ByVal FileURL As String) As String
        ' Create a new Stringbuilder to collect the bytes
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        Using currentMD5 As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()
            ' Convert the input string to a byte array and compute the hash.
            Dim data As Byte() = currentMD5.ComputeHash(My.Computer.FileSystem.ReadAllBytes(FileURL))

            ' Loop through each byte of the hashed data 
            ' and format each one as a hexadecimal string.
            Dim i As Integer
            For i = 0 To data.Length - 1
                sBuilder.Append(data(i).ToString("x2"))
            Next i

            ' Return the hexadecimal string.
        End Using
        Return sBuilder.ToString()
    End Function

    Public Function VerifyMd5FilesHash(ByVal FileURL As String, ByVal SecondFileURL As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = MD5FileHash(FileURL)
        Dim hash As String = MD5FileHash(SecondFileURL)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerifyMd5FileHash(ByVal FileURL As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = MD5FileHash(FileURL)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerifyMd5Hash(ByVal input As String, ByVal hash As String) As Boolean
        ' Hash the input.
        Dim hashOfInput As String = MD5Hash(input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function VerifyMd5Hashes(ByVal hash1 As String, ByVal hash2 As String) As Boolean
        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hash1, hash2) Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
