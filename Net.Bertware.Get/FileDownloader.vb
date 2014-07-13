Imports System.Threading
Imports System.Net
Imports System.Windows.Forms

Public Class FileDownloader
    Public URL As String, target As String, message As String

    Dim speed As UInt64 = 0
    Dim ETA_s As TimeSpan = New TimeSpan(0)
    Dim ETA_str As String = ""
    Dim tmrspeed As New Timers.Timer
    Dim received As UInt64 = 0
    Dim ToReceive As UInt64 = 0
    Dim tmptarget As String = ""

    Dim webc As WebClient

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.URL = ""
        Me.target = ""
        Me.message = ""
    End Sub



    Public Sub New(URL As String, target As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.URL = URL
        Me.target = target
        Me.message = ""
    End Sub

    Public Sub New(URL As String, target As String, message As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.URL = URL
        Me.target = target
        Me.message = message
    End Sub

    Private Sub FileDownloader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            LblAction.Text = message
            LblStatus.Text = "Contacting server..."
            PBProgress.Value = 0
            speed = 0
            old_size = 0
            old_size_2 = 0
            received = 0

            tmptarget = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "/download.tmp"

            webc = New WebClient
            webc.Headers = api.RequestHeader

            AddHandler webc.DownloadProgressChanged, AddressOf DownloadProgressChange
            AddHandler webc.DownloadFileCompleted, AddressOf DownloadCompleted

            tmrspeed = New Timers.Timer
            tmrspeed.Interval = 500
            tmrspeed.AutoReset = True
            AddHandler tmrspeed.Elapsed, AddressOf UpdateSpeed
            webc.DownloadFileAsync(New Uri(URL), tmptarget)
            tmrspeed.Start()
        Catch ex As Exception
            MessageBox.Show("File download failed!" & vbCrLf & ex.Message, "Download failed!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Trace.WriteLine("File download failed!", ex.Message)
            DialogResult = Windows.Forms.DialogResult.Cancel
        End Try
    End Sub

    Private Sub DownloadProgressChange(s As Object, e As DownloadProgressChangedEventArgs)
        received = e.BytesReceived
        ToReceive = e.TotalBytesToReceive - e.BytesReceived
        setprogress(e)
    End Sub

    Private Sub DownloadCompleted()
        If Me.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf DownloadCompleted)
            Me.Invoke(d, New Object() {})
        Else
            Try
                tmrspeed.Enabled = False
                If FileIO.FileSystem.FileExists(tmptarget) Then FileIO.FileSystem.MoveFile(tmptarget, target, True)
                DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Catch ex As Exception
                Trace.WriteLine("The downloaded file could not be saved: " + ex.Message)
                MessageBox.Show("The downloaded file could not be saved. Are you allowed to write to this location? Try running as administrator", "Couldn't save file", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                DialogResult = Windows.Forms.DialogResult.Cancel
            End Try
        End If
    End Sub

    Private Sub setprogress(e As DownloadProgressChangedEventArgs)
        If Me.InvokeRequired Then
            Dim d As New ContextCallback(AddressOf setprogress)
            Me.Invoke(d, New Object() {e})
        Else
            LblStatus.Text = "Downloading:" & " " & e.ProgressPercentage & "% [" & Math.Round(e.BytesReceived / 1024) & "Kb/" & Math.Round(e.TotalBytesToReceive / 1024) & "Kb] @ " & speed & " Kb/s  -  ETA:" & ETA_str  'only translate static part, users will understand numeric values"
            PBProgress.Value = e.ProgressPercentage
        End If
    End Sub

    Dim old_size As UInt64 = 0, old_size_2 As UInt64 = 0, old_size_3 As UInt64 = 0, old_speed As UInt64

    Private Sub UpdateSpeed()
        old_speed = speed
        speed = Math.Round((((received - old_size) / 1024 * 2) + ((old_size - old_size_2) / 1024 * 2) + ((old_size_2 - old_size_3) / 1024 * 2)) / 2)
        old_size_3 = old_size_2
        old_size_2 = old_size
        old_size = received
        If speed > 0 Then
            ETA_s = New TimeSpan(0, 0, Math.Round((ToReceive / 1024) / ((speed + old_speed) / 2)))
            ETA_str = ETA_s.Minutes.ToString.PadLeft(2, "0") & ":" & ETA_s.Seconds.ToString.PadLeft(2, "0")
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Try
            webc.CancelAsync()
            webc.Dispose()
            If FileIO.FileSystem.FileExists(tmptarget) Then FileIO.FileSystem.DeleteFile(tmptarget, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
        Catch ex As Exception
            Trace.WriteLine("Something went wrong while cancelling a download: " + ex.Message)
        Finally
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Try
    End Sub

End Class