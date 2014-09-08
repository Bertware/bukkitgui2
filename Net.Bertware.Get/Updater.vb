Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection
Imports System.Threading
Imports System.Security
Imports System.Net

Module Updater
    Public Event UpdateStarting()
    'Public ReadOnly BUKKITDEV As Boolean = False

    Public Function Update(upd As UpdateInfo, Optional ByVal limited As Boolean = False) As Boolean _
        'verify if dialog should be shown. If manual, always show. 
        Try
            If upd Is Nothing Then Return False : Exit Function
            Trace.WriteLine("preparing to update...")
            'Trace.WriteLine("Bukkitdev compliancy: " & BUKKITDEV)

            RaiseEvent UpdateStarting()
            'select mirror
            Dim url As String = ""
            If Ping(upd.URL_1) = False Then
                If Ping(upd.URL_2) = False Then
                    MessageBox.Show("All download links for this update are unavailable. Try again later.",
                                    "Download unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ShowFailedDialog()
                    Return False
                    Exit Function
                Else
                    url = upd.URL_2
                End If
            Else
                url = upd.URL_1
            End If

            Trace.WriteLine("got update url:" & url)

            Dim fname As String = upd.FileName
            If (String.IsNullOrEmpty(fname)) Then fname = "bukkitgui2.exe"

            Dim tmp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Bertware\Get"


            ' Updater tool to replace files is included in the assembly
            Dim fs As FileStream = File.Create(tmp & "\BertwareUpdater.exe")
            fs.Write(My.Resources.Updater, 0, My.Resources.Updater.Length)
            fs.Close()
            Trace.WriteLine("Extracted updater tool")

            'If (BUKKITDEV) Then
            '    If (url.StartsWith("http://") Or url.StartsWith("https://")) Then
            '        url = url.Substring(url.IndexOf("/", 10, StringComparison.Ordinal))
            '    End If

            '    ' BUKKITDEV COMPLIANCY
            '    ' all url's will start with a hard coded http://dev.bukkit.org/ part
            '    url = "http://dev.bukkit.org" + url
            '    Trace.WriteLine("Bukkitdev hardcoded url: " & url)
            'End If

            Dim fd As FileDownloader
            fd = New FileDownloader(url, tmp & "/" & fname)
            fd.ShowDialog()
            If fd.DialogResult = DialogResult.Cancel Then
                ShowFailedDialog("Download Cancelled")
                Return False
            ElseIf New FileInfo(tmp & "/" & fname).Length < 128 Then
                ShowFailedDialog("Downloaded file is corrupt. Restart the download")
                Return False
            End If


            Dim up As New Process
            up.StartInfo.FileName = tmp & "\BertwareUpdater.exe"
            up.StartInfo.Arguments = """" & tmp & "/" & fname & """ """ & Assembly.GetEntryAssembly.Location & """ " &
                                     Process.GetCurrentProcess.Id.ToString
            up.Start() 'Do update

            Process.GetCurrentProcess.CloseMainWindow()
            Thread.Sleep(50)
            Process.GetCurrentProcess.Close()
            Thread.Sleep(50)
            Process.GetCurrentProcess.Kill() 'kill this process, so file can be replaced

        Catch pex As SecurityException
            MessageBox.Show(
                "The update couldn't be installed. It seems like you don't have permissions to do this. Try running the GUI as administator, or install the update manually.",
                "Insufficient rights", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Trace.WriteLine("Security exception at update! " + pex.Message)
            ShowFailedDialog()
            Return False
        Catch ex As Exception
            ShowFailedDialog()
            Trace.WriteLine("Severe exception at update! " + ex.Message)
            Return False
        End Try
        Return True
    End Function

    Private Sub ShowFailedDialog()
        MessageBox.Show(
            "Something went wrong while trying to update. If the update keeps failing, download the latest version from get.bertware.net",
            "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ShowFailedDialog(details As String)
        MessageBox.Show(
            "Something went wrong while trying to update. If the update keeps failing, download the latest version from get.bertware.net" &
            vbCrLf & "detail:" & details, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Function Ping(url As String) As Boolean
        Dim result As HttpStatusCode = Nothing

        Dim request = HttpWebRequest.Create(url)
        request.Method = "HEAD"
        Using response = TryCast(request.GetResponse(), HttpWebResponse)
            If response IsNot Nothing Then
                result = response.StatusCode
                response.Close()
            Else
                result = HttpStatusCode.Forbidden
            End If
        End Using

        Return (result = HttpStatusCode.OK) Or (result = HttpStatusCode.Accepted) Or (result = HttpStatusCode.Continue)
    End Function
End Module
