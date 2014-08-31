Imports System.Security.Cryptography
Imports System.Net
Imports System.Reflection
Imports System.IO

Public Module api
    Const API As String = "http://get.bertware.net/api/1.0/api.php"
    Const MAIL As String = "contact@bertware.net"
    Private cpp As New SHA1CryptoServiceProvider

    ''' <summary>
    '''     User agent:
    '''     Bertware x.y/application_name application_version [DEBUG]/hash/mail
    '''     Hash is set to 0 for debug, and is used to detect fake distributions (evt. banning them from the server)
    ''' </summary>
    ''' <remarks></remarks>

        Friend ReadOnly _
        UA As String = "Bertware 1.3/" & My.Application.Info.AssemblyName & " " & My.Application.Info.Version.ToString &
                       "/" & MAIL


    Public Enum releasechannel
        recommended
        beta
        development
    End Enum

    Public Enum APIAction
        sysinfo
        program_all
        changelog
    End Enum

    Public Event UpdateAvailable(upd As UpdateInfo)
    Public Event LatestVersionLoaded(upd As UpdateInfo)

    Public ReadOnly Property RequestHeader As WebHeaderCollection
        Get
            Dim c As New WebHeaderCollection
            c.Add(HttpRequestHeader.UserAgent, UA)
            c.Add(HttpRequestHeader.From, MAIL)
            'c.Add(HttpRequestHeader.Authorization, "bertware:bukkitgui")
            Return c
        End Get
    End Property

    Public ReadOnly Property CurrentVersion
        Get
            Return Assembly.GetEntryAssembly().GetName().Version.ToString
        End Get
    End Property

    Dim _latestversion As UpdateInfo = Nothing

    Public ReadOnly Property LatestVersion() As UpdateInfo
        Get
            Dim pi = New ProgramInfo(Assembly.GetEntryAssembly().GetName().Name)
            If pi Is Nothing OrElse pi.updates Is Nothing Then Return Nothing : Exit Property
            If _latestversion Is Nothing Then _latestversion = pi.updates(0)
            If _latestversion IsNot Nothing Then RaiseEvent LatestVersionLoaded(_latestversion)
            Return _latestversion
        End Get
    End Property

    Dim _latestRecommendedVersion As UpdateInfo = Nothing

    Public ReadOnly Property LatestRecommendedVersion() As UpdateInfo
        Get
            Dim pi = New ProgramInfo(Assembly.GetEntryAssembly().GetName().Name)
            If pi Is Nothing OrElse pi.updates Is Nothing Then Return Nothing : Exit Property
            If _latestRecommendedVersion Is Nothing Then
                For Each update As UpdateInfo In pi.updates
                    If update.Channel = releasechannel.recommended Then _latestRecommendedVersion = update
                Next
            End If
            Return _latestRecommendedVersion
        End Get
    End Property


    Public Function RunUpdateCheck(Optional ByVal showUpdaterForm As Boolean = False, Optional recommendedVersionsOnly As Boolean = True) As Boolean
        Dim lrv = LatestVersion
        If (recommendedVersionsOnly) Then lrv = LatestRecommendedVersion

        If lrv Is Nothing OrElse lrv.Version Is Nothing Then Return False
        If CheckVersion(CurrentVersion, lrv.Version) = 1 Then
            Trace.WriteLine("Update available!")
            RaiseEvent UpdateAvailable(LatestVersion)
            If showUpdaterForm Then ShowUpdater()
            Return True
        Else
            Trace.WriteLine("No update available!")
            Return False
        End If
    End Function

    Public Function ShowUpdater(Optional ByVal limitedUpdate As Boolean = False)
        Dim lrv = LatestVersion
        If lrv Is Nothing OrElse lrv.Version Is Nothing Then Return False : Exit Function
        Dim changelog As New ChangelogInfo
        changelog.LoadThis(CurrentVersion, LatestVersion.Version)
        Dim ud As New UpdateDialog(LatestVersion, changelog, limitedUpdate)
        ud.ShowDialog()
        Return True
    End Function


    Public Function GetLatestVersionByChannel(channel As releasechannel) As UpdateInfo
        Dim pi = New ProgramInfo(Assembly.GetEntryAssembly().GetName().Name)
        If pi Is Nothing OrElse pi.updates Is Nothing Then Return Nothing : Exit Function
        Dim updlist = pi.updates
        If updlist Is Nothing OrElse updlist.Count = 0 Then Return Nothing
        For i = 0 To updlist.Count - 1
            If updlist(i).Channel = channel Then Return updlist(i)
        Next
        Return Nothing
    End Function

    Public Function UpdateToLatest()
        Return Update(LatestVersion)
    End Function

    Public Function UpdateToLatestRelease()
        Return Update(LatestRecommendedVersion)
    End Function

    Public Function PerformUpdate(update As UpdateInfo)
        Return Updater.Update(update)
    End Function

    Public Function GetApiResponse(action As APIAction,
                                   Optional ByVal parameters As Dictionary(Of String, String) = Nothing) As String
        Dim response = DownloadText(CreateUrl(action, parameters)).Trim
        If Not (response.StartsWith("<") And response.EndsWith(">")) Then Return ""
        Return response
    End Function

    Private Function CreateUrl(action As APIAction, Optional ByVal parameters As Dictionary(Of String, String) = Nothing) _
        As String
        Dim url As String = API + "?act=" & action.ToString
        If parameters IsNot Nothing Then
            For Each entry In parameters
                If entry.Key IsNot Nothing AndAlso entry.Value IsNot Nothing Then _
                    url += "&" + entry.Key + "=" + entry.Value
            Next
        End If
        Trace.WriteLine("API url:" & url)
        Return url
    End Function

    Private Function DownloadText(url As String) As String
        Try
            If url Is Nothing Then Return ""

            If My.Computer.Network.IsAvailable = False Then
                Trace.WriteLine("Request to " & url & " cancelled, no internet available or page not available")
                Return ""
                Exit Function
            End If

            Dim httpreq As HttpWebRequest
            httpreq = HttpWebRequest.Create(url)
            httpreq.Timeout = 10000
            httpreq.Proxy = Nothing
            httpreq.UserAgent = UA
            Dim responseStr = ""
            Using sr As StreamReader = New StreamReader(httpreq.GetResponse.GetResponseStream)
                responseStr = sr.ReadToEnd
            End Using
            Return responseStr

        Catch tm As TimeoutException
            Trace.WriteLine("Could not download data from " & url & " : Timed Out : " & tm.Message)
            Return ""
        Catch webex As WebException
            If webex.Message.Contains("503") Then
                Trace.WriteLine("Could not download data from " & url & " : WebException/503 : " & webex.Message)
                Return ""
            ElseIf webex.Message.Contains("502") Then
                Trace.WriteLine("Could not download data from " & url & " : WebException/502 : " & webex.Message)
                Return ""
            ElseIf webex.Message.Contains("timed out") Then
                Trace.WriteLine("Could not download data from " & url & " : WebException/TimedOut : " & webex.Message)
                Return ""
            Else
                Trace.WriteLine("Could not download data from " & url & " : WebException/Unknown : " & webex.Message)
                Return ""
            End If
        Catch ex As Exception
            Trace.WriteLine("Could not download data from " & url & " : " & ex.Message)
            Return ""
        End Try
    End Function

    
    ''' <summary>
    '''     Check which from 2 versions is newer. returns -1 if old version is newer, 0 if equal, 1 if new version is newer
    ''' </summary>
    ''' <param name="oldversion">the old version, x.x, x.x.x or x.x.x.x format</param>
    ''' <param name="newversion">the new version, x.x, x.x.x or x.x.x.x format</param>
    ''' <returns>-1 if old version is newer, 0 if equal, 1 if new version is newer</returns>
    ''' <remarks>This function can handle version numbers with parts up to 65535</remarks>
    Private Function CheckVersion(oldversion As String, newversion As String) As SByte
        Try
            Trace.WriteLine("get.bertware", "Comparing versions: " & oldversion & " - " & newversion)

            If oldversion Is Nothing OrElse oldversion = "" OrElse newversion Is Nothing OrElse newversion = "" Then
                Trace.WriteLine("get.bertware", "Invalid version supplied!")
                Return 0
                Exit Function
            End If

            For Each C As Char In oldversion.ToCharArray
                If (Char.IsPunctuation(C) = False And Char.IsNumber(C) = False) Then _
                    Trace.WriteLine("get.bertware", "Invalid version supplied! oldversion:" & oldversion) : Return 0 : _
                        Exit Function
            Next

            For Each C As Char In newversion.ToCharArray
                If (Char.IsPunctuation(C) = False And Char.IsNumber(C) = False) Then _
                    Trace.WriteLine("get.bertware", "Invalid version supplied! newversion:" & newversion) : Return 0 : _
                        Exit Function
            Next

            If Not oldversion.Contains(".") Then oldversion += ".0.0.0"
            Select Case oldversion.Split(".").Length
                Case 2
                    oldversion += ".0.0"
                Case 3
                    oldversion += ".0"
            End Select

            If Not newversion.Contains(".") Then newversion += ".0.0.0"
            Select Case newversion.Split(".").Length
                Case 2
                    newversion += ".0.0"
                Case 3
                    newversion += ".0"
            End Select

            Trace.WriteLine("get.bertware", "Normalized versions: " & oldversion & " - " & newversion)

            Dim ov As New Version(oldversion)
            Dim nv As New Version(newversion)
            Dim res As SByte = nv.CompareTo(ov)
            Trace.WriteLine("get.bertware", "Result of version compare:" & res.ToString)
            Return res
        Catch ex As Exception
            Trace.WriteLine("get.bertware", "Couldn't compare versions! " + ex.Message)
            Return 0
        End Try
    End Function
End Module
