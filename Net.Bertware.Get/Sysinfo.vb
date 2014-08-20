Imports System.Xml

Public Class Sysinfo
    Public Version = ""
    Public Status = ""
    Public UpdateToolVersion = ""
    Public UpdateToolLocation = ""
    Public UpdateToolSha256 = ""

    Public Sub New()
        LoadXML(GetAPIResponse(APIAction.sysinfo))
    End Sub

    Public Sub LoadXML(xml As String)
        Try
            Dim xmldoc As New XmlDocument()
            xmldoc.LoadXml(xml)
            Version = xmldoc.DocumentElement.Item("version").InnerText
            Status = xmldoc.DocumentElement.Item("status").InnerText
            UpdateToolLocation = xmldoc.DocumentElement.Item("updater").Item("location").InnerText
            UpdateToolVersion = xmldoc.DocumentElement.GetElementsByTagName("updater")(0).Attributes("version").Value
            UpdateToolSha256 = xmldoc.DocumentElement.Item("updater").Item("sha256").InnerText
        Catch ex As Exception
            Trace.WriteLine("Failed to load XML for sysinfo!")
        End Try
    End Sub
End Class
