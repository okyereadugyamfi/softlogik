


Public Enum HashTypeEnum
    htMD5 = 4
End Enum

Public Enum EncryptAlgorithmsEnum
    eaRC4 = 1
    eaRC2
    eaDES
    ea3DES
    ea3DES112
End Enum

Public Module SPEncrypt

    Public Function EncryptByte(ByVal Algorithm As EncryptAlgorithmsEnum, ByVal SourceText As String, ByVal CaseSensitive As Boolean, ByVal Key As String, ByVal Salt As String) As Byte()
        Dim objCrypto As New CryptKci.clsCryptoAPI

        Try
            With objCrypto
                .InputData = .StringToByteArray(CType(SourceText, Object))
                .EnhancedProvider = True
                .Password = .StringToByteArray(CType(Key, Object))
                .Encrypt(CType(HashTypeEnum.htMD5, Short), CType(Algorithm, Short))
                Return .OutputData
            End With

        Catch ex As Exception
            Throw ex
        Finally
            objCrypto = Nothing
        End Try

    End Function

    Public Function EncryptString(ByVal Algorithm As EncryptAlgorithmsEnum, ByVal SourceText As String, ByVal CaseSensitive As Boolean, ByVal Key As String, ByVal Salt As String) As String
        Dim objCrypto As New CryptKci.clsCryptoAPI

        Try
            With objCrypto
                .InputData = .StringToByteArray(CType(SourceText, String))
                .EnhancedProvider = True
                .Password = .StringToByteArray(CType(Key, String))
                .Encrypt(CType(HashTypeEnum.htMD5, Short), CType(Algorithm, Short))
                Return .ByteArrayToString(.OutputData)
            End With

        Catch ex As Exception
            Throw ex
        Finally
            objCrypto = Nothing
        End Try

    End Function
    Public Function ToByte(ByVal SourceString As String) As Byte()
        Dim objCrypto As New CryptKci.clsCryptoAPI

        Return objCrypto.StringToByteArray(CType(SourceString, String))
        objCrypto = Nothing

    End Function

    Public Function CreateSaltValue(Optional ByVal ReturnLength As Integer = 20, _
    Optional ByVal UseLettersNumbersOnly As Boolean = True) As String
        Dim objCrypto As New CryptKci.clsCryptoAPI

        Return CType(objCrypto.CreateSaltValue(ReturnLength, UseLettersNumbersOnly), String)
        objCrypto = Nothing

    End Function
End Module

