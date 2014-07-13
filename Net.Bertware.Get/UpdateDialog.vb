Imports System.Windows.Forms

Public Class UpdateDialog
    Private _update As UpdateInfo
    Private _changelog As ChangelogInfo
    Private _limitedUpdate As Boolean = False
    Public onlyGetUrl As Boolean = False

    Public Sub New(update As UpdateInfo, changelog As ChangelogInfo, Optional ByVal limitedUpdate As Boolean = False)
        InitializeComponent()
        _update = update
        _changelog = changelog
        _limitedUpdate = limitedUpdate
    End Sub

    Private Sub UpdateDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If _update Is Nothing Then _
                MessageBox.Show("Invalid update information! Check your internet connection.",
                                "Invalid update information", MessageBoxButtons.OK, MessageBoxIcon.Error) : Me.Close() : _
                    Exit Sub
            lblCurrentVersion.Text += " " + CurrentVersion
            LblNewVersion.Text += " " + _update.Version
            lblReleaseDate.Text += " " + _update.ReleaseDate
            If _update.Size < 1048576 Then
                LblSize.Text += " " + Math.Round(_update.Size/1024, 1).ToString + "Kb"
            Else
                LblSize.Text += " " + Math.Round(_update.Size/1048576, 1).ToString + "Mb"
            End If
            If _changelog IsNot Nothing AndAlso _changelog.Changes IsNot Nothing Then
                For Each entry In _changelog.Changes
                    LboxChangelog.Items.Add(entry.ToString)
                Next
            End If
        Catch ex As Exception
            Trace.WriteLine("Failed to load updatedialog! : " + ex.Message)
        End Try
    End Sub

    Private Sub LLblGetBertware_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles LLblGetBertware.LinkClicked
        Process.Start("http://get.bertware.net")
    End Sub

    Private Sub BtnInstall_Click(sender As Object, e As EventArgs) Handles BtnInstall.Click
        If _update Is Nothing Then Exit Sub
        If onlyGetUrl Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
            Exit Sub
        End If

        Updater.Update(_update, _limitedUpdate)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub BtnIgnore_Click(sender As Object, e As EventArgs) Handles BtnIgnore.Click
        Me.DialogResult = DialogResult.Ignore
        Me.Close()
    End Sub
End Class