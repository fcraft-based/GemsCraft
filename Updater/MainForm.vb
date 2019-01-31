Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Runtime.ExceptionServices

Public Class MainForm
    Dim _webserver As String = "http://gemscraft-download.christplay.x10host.com"

    Private Function FileName() As String
        If cboVersionSelector.SelectedIndex > -1 Then
            Return FileName(cboVersionSelector.SelectedItem.ToString())
        End If
        Return Nothing
    End Function

    Private Shared Function FileName(version As String) As String
        Return $"update{version}.zip"
    End Function

    Private Function Url() As String
        Dim x = _webserver + "/download/" + cboVersionSelector.SelectedItem.ToString().Replace(" ", "%20") + ".zip"
        MsgBox(x)
        Return x
    End Function


    Private Sub cboVersionSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVersionSelector.SelectedIndexChanged
        Dim result = False
        If File.Exists(UpdateInfo) Then
            Dim content = File.ReadAllText(UpdateInfo)
            If Not content = Nothing Then
                If cboVersionSelector.Items.Contains(content) Then
                    If cboVersionSelector.SelectedItem.ToString() = content Then
                        If cboVersionSelector.SelectedIndex > -1 Then result = False
                    End If
                Else
                    result = True
                End If
            Else
                result = True
            End If
        Else
            result = True
        End If

        If result = True Then
            If cboVersionSelector.SelectedIndex = -1 Then result = False
        End If

        btnDownload.Enabled = result
    End Sub

    Const LegacyFile = "update.zip"
    Const UpdateInfo = "update.txt"
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(LegacyFile) Then
            File.Delete(LegacyFile)
        End If

        For Each ver In cboVersionSelector.Items ' Deletes any updates previously downloaded
            Dim f = FileName(ver)
            If File.Exists(f) Then
                File.Delete(f)
            End If
        Next
        Dim temp = "checkfile.txt"
        If File.Exists(temp) Then File.Delete(temp)
        Dim c = File.CreateText(temp)
        c.Close()
        Using client As New WebClient
            Try
                client.DownloadFile(_webserver & "/releases.json", temp)
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try
        End Using
        Dim x = File.ReadAllLines(temp).ToList()
        For Each v In x
            cboVersionSelector.Items.Add(v)
        Next
        File.Delete(temp)
    End Sub
    Dim WithEvents WC As New WebClient
    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        WC.DownloadFileAsync(New Uri(url()), FileName())
    End Sub

    Private Sub WC_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        If (e.ProgressPercentage = 100) Then
            If HasDone Then Return
            Unzip()
        End If
    End Sub
    Dim HasDone = False


    Sub Unzip()
        HasDone = True
        Try
            Dim zipPath = FileName()
            Dim extractPath = AppDomain.CurrentDomain.BaseDirectory
            Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
                For Each entry As ZipArchiveEntry In archive.Entries
                    entry.ExtractToFile(Path.Combine(extractPath, entry.FullName), True)
                Next
            End Using
            Console.WriteLine("Update successful! You may now close this and open GemsCraft :D")
            MsgBox("Update successful! You may now close this and open GemsCraft :D")
            File.Delete(zipPath)
            Dim writer = File.CreateText(UpdateInfo)
            writer.Write(cboVersionSelector.SelectedItem.ToString())
            writer.Flush()
            writer.Close()
        Catch ex As Exception
            If Not Directory.Exists("Logs/") Then
                Directory.CreateDirectory("Logs/")
            End If
            Const updaterLog = "Logs/UpdaterLog.txt"
            Dim writer = File.AppendText(updaterLog)
            writer.WriteLine("----------------------------------") ' start a new log
            writer.WriteLine("Crash Log for " + Now.ToLongDateString() + " at " + Now.ToLongTimeString())
            writer.WriteLine(ex.Message)
            writer.WriteLine(ex.ToString())
            writer.Flush()
            writer.Close()
            MsgBox($"Failed to Update. Log saved in {updaterLog}")
        End Try
    End Sub
End Class
