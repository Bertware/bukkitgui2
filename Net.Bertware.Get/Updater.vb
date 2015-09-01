Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.IO

Module Updater
    Public Event UpdateStarting()

    Public Function Update(upd As UpdateInfo) As Boolean 'verify if dialog should be shown. If manual, always show. 
        Try
            If upd Is Nothing Then Return False
            Trace.WriteLine("preparing to update...")
            RaiseEvent UpdateStarting()
            'select mirror
            Dim url As String
            If Ping(upd.URL_1) = False Then
                If Ping(upd.URL_2) = False Then
                    MessageBox.Show("All download links for this update are unavailable. Try again later.", "Download unavailable", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ShowFailedDialog()
                    Return False
                Else
                    url = upd.URL_2
                End If
            Else
                url = upd.URL_1
            End If

            Dim fname As String = upd.FileName


            Dim si As New Sysinfo

            Dim tmp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Bertware\Get"

            If (Not Directory.Exists(tmp)) Then
                Directory.CreateDirectory(tmp)
            End If

            Dim fd As FileDownloader
            If File.Exists(tmp & "\BertwareUpdater.exe") Then
                If GetChecksum(tmp & "\BertwareUpdater.exe", New SHA256Managed) <> si.UpdateToolSha256 Then
                    fd = New FileDownloader(si.UpdateToolLocation, tmp & "\BertwareUpdater.exe")
                    fd.ShowDialog()
                    If fd.DialogResult = DialogResult.Cancel Then
                        ShowFailedDialog("Download Cancelled")
                        Return False
                    End If
                End If
            Else
                fd = New FileDownloader(si.UpdateToolLocation, tmp & "\BertwareUpdater.exe")
                fd.ShowDialog()
                If fd.DialogResult = DialogResult.Cancel Then
                    ShowFailedDialog("Download Cancelled")
                    Return False
                End If
            End If


            fd = New FileDownloader(url, tmp & "/" & fname)
            fd.ShowDialog()
            If fd.DialogResult = DialogResult.Cancel Then
                ShowFailedDialog("Download Cancelled")
                Return False
            ElseIf New FileInfo(tmp & "/" & fname).Length < 128 Then
                ShowFailedDialog("Downloaded file is corrupt. Restart the donwload")
                Return False
            End If


            Dim up As New Process
            up.StartInfo.FileName = tmp & "\BertwareUpdater.exe"
            up.StartInfo.Arguments = """" & tmp & "/" & fname & """ """ & Reflection.Assembly.GetEntryAssembly.Location & """ " & Process.GetCurrentProcess.Id.ToString
            up.Start() 'Do update

            Process.GetCurrentProcess.CloseMainWindow()
            Threading.Thread.Sleep(50)
            Process.GetCurrentProcess.Close()
            Threading.Thread.Sleep(50)
            Process.GetCurrentProcess.Kill() 'kill this process, so file can be replaced
            
        Catch pex As Security.SecurityException
            MessageBox.Show("The update couldn't be installed. It seems like you don't have permissions to do this. Try running the GUI as administator, or install the update manually.", "Insufficient rights", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        MessageBox.Show("Something went wrong while trying to update. If the update keeps failing, download the latest version from get.bertware.net", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub ShowFailedDialog(details As String)
        MessageBox.Show("Something went wrong while trying to update. If the update keeps failing, download the latest version from get.bertware.net" & vbCrLf & "detail:" & details, "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Function Ping(url As String) As Boolean
        Dim result As System.Net.HttpStatusCode

        Dim request = System.Net.HttpWebRequest.Create(url)
        request.Method = "HEAD"
        Using response = TryCast(request.GetResponse(), System.Net.HttpWebResponse)
            If response IsNot Nothing Then
                result = response.StatusCode
                response.Close()
            Else
                result = System.Net.HttpStatusCode.Forbidden
            End If
        End Using

        Return (result = System.Net.HttpStatusCode.OK) Or (result = System.Net.HttpStatusCode.Accepted) Or (result = System.Net.HttpStatusCode.Continue)
    End Function

    Private Function GetChecksum(filePath As String, algorithm As HashAlgorithm) As String
        If File.Exists(filePath) = False Then Return ""
        Using stream = New BufferedStream(File.OpenRead(filePath), 100000)
            Dim hash As Byte() = algorithm.ComputeHash(stream)
            Return BitConverter.ToString(hash).Replace("-", [String].Empty)
        End Using
    End Function
End Module
