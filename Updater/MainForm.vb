Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Runtime.ExceptionServices

Public Class MainForm
    Dim _webserver As String = "http://gemscraft-download.christplay.x10host.com"

    Private Function url() As String
        Dim x = _webserver + "/download/" + cboVersionSelector.SelectedItem.ToString().Replace(" ", "%20") + ".zip"
        MsgBox(x)
        Return x
    End Function
    Private Sub cboVersionSelector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVersionSelector.SelectedIndexChanged
        btnDownload.Enabled = cboVersionSelector.SelectedIndex > -1
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        WC.DownloadFileAsync(New Uri(url()), "update.zip")
    End Sub

    Private Sub WC_DownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        If (e.ProgressPercentage = 100) Then
            Unzip()
        End If
    End Sub

    Sub Unzip()
        Try
            Dim startPath As String = ""
            Dim zipPath As String = "update.zip"
            Dim extractPath As String = ""

            ZipFile.CreateFromDirectory(startPath, zipPath)

            ZipFile.ExtractToDirectory(zipPath, extractPath)
            MsgBox("Update successful! You may now close this and open GemsCraft :D")
        Catch
            MsgBox("Update failed. Try again")
        End Try
    End Sub
End Class
