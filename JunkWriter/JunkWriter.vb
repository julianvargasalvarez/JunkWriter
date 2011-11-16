''' <summary>
''' This routine creates text files full of '@' with the purpose of
''' write free sectors in a disk, thus no information can be recovered
''' with tools such as Recuva or Get Data Back.
''' </summary>
''' <remarks></remarks>
Module JunkWriter

    Sub Main()

        Dim content As String = String.Empty

        Console.WriteLine("Creating junk content...")
        'Creates a string with length = 1MB
        For i As Integer = 1 To 1024 * 1024 'bytes
            content = content & "@"
        Next

        Try
            While True
                'Writes the content untill an exception is thrown
                WriteSomeJunk(content)
            End While

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

    Public Sub WriteSomeJunk(ByVal content As String)
        'Creates a file with the current time
        Dim fileName As String = Now.Ticks & ".junk"
        Dim archivo As New IO.StreamWriter(fileName, False)

        'writes the 1MB content
        archivo.Write(content)

        archivo.Close()

        Console.WriteLine(fileName)

    End Sub

End Module
