Imports System.Net
Imports System.Reflection

Module Module1

    Sub Main()
        Console.WriteLine("+----------------------------------------------------------------------+")
        Console.WriteLine("|  Downloading all Math Pathways mini-lessons to the below directory.  |")
        Console.WriteLine("|           If files already exist, they will be overwritten.          |")
        Console.WriteLine("+----------------------------------------------------------------------+")
        Dim Path As String = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
        Path = New Uri(Path).LocalPath
        Path = Path + "\pathways_mini_lessons"
        System.IO.Directory.CreateDirectory(Path)
        Console.WriteLine(Path)
        downloadModules(Path)
    End Sub
    Sub downloadModules(ByVal Path As String)
        Dim i As Int32 = 0
        While i <= 1000 'For i = 1000
            Dim client As New WebClient()
            Dim sheetUrl As String = "https://mpcontent.blob.core.windows.net/activities/" + i.ToString + ".pdf"
            Dim localUrl As String = Path + "\" + i.ToString + ".pdf"
            Dim exc As Exception = Nothing
            Try
                client.DownloadFile(sheetUrl, localUrl)
            Catch ex As Exception
                exc = ex
                Console.Write("-")
            Finally
                If exc Is Nothing Then
                    Console.WriteLine()
                    Console.WriteLine("Download of " + sheetUrl + " to " + localUrl + " success.")
                End If
            End Try
            i = i + 1
        End While
    End Sub
End Module