Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim x = Process.GetProcessesByName("GemsCraftUpdater")
        For Each item In x
            Console.WriteLine(item.StartInfo.WorkingDirectory)
            Console.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory)
            item.Close() ' Close the Updater
            Console.WriteLine("Closed Updater")
        Next
        Console.ReadLine()
    End Sub

End Module
