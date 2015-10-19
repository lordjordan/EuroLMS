Option Strict On
Imports System.IO
Imports System.Drawing.Imaging
Imports System.Data.SqlClient

Module ImgModule
    Public Sub Image2Byte(ByVal NewImage As Image, ByRef ByteArr() As Byte)
        '
        Dim ImageStream As MemoryStream

        Try
            ReDim ByteArr(0)
            If NewImage IsNot Nothing Then
                ImageStream = New MemoryStream
                NewImage.Save(ImageStream, ImageFormat.Jpeg)
                ReDim ByteArr(CInt(ImageStream.Length - 1))
                ImageStream.Position = 0
                ImageStream.Read(ByteArr, 0, CInt(ImageStream.Length))
                'MsgBox(ByteArr.Length) ' DEBUG
            End If
        Catch ex As Exception
            MsgBox(ex.Message) ' DEBUG
        End Try

    End Sub
    Public Sub Byte2Image(ByRef NewImage As Image, ByVal ByteArr As Byte())
        '
        Dim ImageStream As MemoryStream

        Try
            If ByteArr.GetUpperBound(0) > 0 Then
                ImageStream = New MemoryStream(ByteArr)
                NewImage = Image.FromStream(ImageStream)
            Else
                NewImage = Nothing
            End If
        Catch ex As Exception
            NewImage = Nothing
        End Try

    End Sub

End Module
