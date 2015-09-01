Public Class ChangelogInfo
    Public Changes As List(Of Change)

    Public Sub Load(program As String, startversion As String, stopversion As String)
        Dim p As New Dictionary(Of String, String)
        p.Add("program", program)
        p.Add("start", startversion)
        p.Add("stop", stopversion)
        Dim response = api.GetAPIResponse(APIAction.changelog, p)
        If response IsNot Nothing AndAlso response <> "" Then LoadXML(response)
    End Sub

    Public Sub LoadThis(startversion As String, stopversion As String)
        Load(Reflection.Assembly.GetEntryAssembly.GetName.Name, startversion, stopversion)
    End Sub

    Private Sub LoadXML(xml As String)
        Try
            Dim xmldoc As New Xml.XmlDocument
            xmldoc.LoadXml(xml)
            Changes = New List(Of Change)
            For Each element As Xml.XmlElement In xmldoc.DocumentElement.GetElementsByTagName("change")
                Try
                    Changes.Add(New Change([Enum].Parse(GetType(Change.changeType), element.Attributes("type").Value), element.Attributes("version").Value, element.InnerText))
                Catch slex As Exception
                    Trace.WriteLine("Failed to load change! : " + slex.Message)
                End Try

            Next
        Catch ex As Exception
            Trace.WriteLine("Failed to load XML for changelog! : " + ex.Message)
        End Try
    End Sub
End Class

Public Class Change
    Public Id
    Public Version
    Public Type As changeType
    Public Description As String

    Public Enum changeType
        fix
        addition
    End Enum

    Public Sub New()

    End Sub

    Public Sub New(Type As changeType, version As String, description As String)
        Me.Type = Type
        Me.Version = version
        Me.Description = description
    End Sub

    Public Overrides Function ToString() As String
        If Description.Length > 50 Then Return Type.ToString + ": " + Description.Substring(0, 47) + "..." Else Return Type.ToString + ": " + Description
    End Function

End Class