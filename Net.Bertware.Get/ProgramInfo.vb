Public Class ProgramInfo

    Public Id As UInt16 = 0
    Public Name As String = ""
    Public Added_Date As String = ""
    Public Allow_View_Site As Boolean = 1
    Public Allow_Download_Site As Boolean = 1
    Public Allow_Download_Updater As Boolean = 1
    Public Icon As String = ""

    Public Description As String = ""
    Public Platform As String = ""
    Public Price As Single = 0

    Public updates As New List(Of UpdateInfo)

    Public Sub New()

    End Sub

    Public Sub New(name As String)
        Load(name)
    End Sub

    Public Sub LoadThis()
        Load(Reflection.Assembly.GetEntryAssembly.GetName.Name)
    End Sub

    Public Sub Load(name As String)
        Dim p As New Dictionary(Of String, String)
        p.Add("program", name)
        Dim response = api.GetAPIResponse(APIAction.program_all, p)
        If response IsNot Nothing AndAlso response <> "" Then LoadXML(response)
    End Sub

    Public Sub LoadXML(xml As String)
        Try
            Dim xmldoc As New Xml.XmlDocument()
            xmldoc.LoadXml(xml)

            Name = xmldoc.GetElementsByTagName("program")(0).Attributes("name").Value
            Id = CInt(xmldoc.GetElementsByTagName("pid")(0).Value)
            Platform = xmldoc.GetElementsByTagName("platform")(0).Value
            Price = CSng(xmldoc.GetElementsByTagName("price")(0).Value)
            Description = xmldoc.GetElementsByTagName("description")(0).Value
            Icon = xmldoc.GetElementsByTagName("icon")(0).Value
            Added_Date = xmldoc.GetElementsByTagName("added_date")(0).Value
            Allow_Download_Site = (xmldoc.GetElementsByTagName("allow_download_site")(0).Value = "1")
            Allow_Download_Updater = (xmldoc.GetElementsByTagName("allow_download_updater")(0).Value = "1")
            Allow_View_Site = (xmldoc.GetElementsByTagName("allow_view_site")(0).Value = "1")

            updates = New List(Of UpdateInfo)
            For Each update As Xml.XmlElement In xmldoc.GetElementsByTagName("update")
                Try
                    Dim ui As New UpdateInfo
                    ui.LoadXML(update)
                    updates.Add(ui)
                Catch slex As Exception
                    Trace.WriteLine("Failed to load update for programinfo! : " + slex.Message)
                End Try
            Next
        Catch ex As Exception
            Trace.WriteLine("Failed to load XML for programinfo! : " + ex.Message)
        End Try
    End Sub


End Class
