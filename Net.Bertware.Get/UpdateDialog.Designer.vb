<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UpdateDialog))
        Me.LboxChangelog = New System.Windows.Forms.ListBox()
        Me.BtnInstall = New System.Windows.Forms.Button()
        Me.BtnIgnore = New System.Windows.Forms.Button()
        Me.lblCurrentVersion = New System.Windows.Forms.Label()
        Me.LblNewVersion = New System.Windows.Forms.Label()
        Me.lblReleaseDate = New System.Windows.Forms.Label()
        Me.LblSize = New System.Windows.Forms.Label()
        Me.lblChangelog = New System.Windows.Forms.Label()
        Me.LLblGetBertware = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'LboxChangelog
        '
        Me.LboxChangelog.FormattingEnabled = True
        Me.LboxChangelog.Location = New System.Drawing.Point(15, 104)
        Me.LboxChangelog.Name = "LboxChangelog"
        Me.LboxChangelog.Size = New System.Drawing.Size(531, 212)
        Me.LboxChangelog.TabIndex = 0
        '
        'BtnInstall
        '
        Me.BtnInstall.Location = New System.Drawing.Point(123, 322)
        Me.BtnInstall.Name = "BtnInstall"
        Me.BtnInstall.Size = New System.Drawing.Size(423, 23)
        Me.BtnInstall.TabIndex = 1
        Me.BtnInstall.Text = "Install now"
        Me.BtnInstall.UseVisualStyleBackColor = True
        '
        'BtnIgnore
        '
        Me.BtnIgnore.Location = New System.Drawing.Point(15, 322)
        Me.BtnIgnore.Name = "BtnIgnore"
        Me.BtnIgnore.Size = New System.Drawing.Size(102, 23)
        Me.BtnIgnore.TabIndex = 3
        Me.BtnIgnore.Text = "Ignore"
        Me.BtnIgnore.UseVisualStyleBackColor = True
        '
        'lblCurrentVersion
        '
        Me.lblCurrentVersion.AutoSize = True
        Me.lblCurrentVersion.Location = New System.Drawing.Point(12, 28)
        Me.lblCurrentVersion.Margin = New System.Windows.Forms.Padding(3)
        Me.lblCurrentVersion.Name = "lblCurrentVersion"
        Me.lblCurrentVersion.Size = New System.Drawing.Size(81, 13)
        Me.lblCurrentVersion.TabIndex = 4
        Me.lblCurrentVersion.Text = "Current version:"
        '
        'LblNewVersion
        '
        Me.LblNewVersion.AutoSize = True
        Me.LblNewVersion.Location = New System.Drawing.Point(12, 9)
        Me.LblNewVersion.Margin = New System.Windows.Forms.Padding(3)
        Me.LblNewVersion.Name = "LblNewVersion"
        Me.LblNewVersion.Size = New System.Drawing.Size(69, 13)
        Me.LblNewVersion.TabIndex = 5
        Me.LblNewVersion.Text = "New version:"
        '
        'lblReleaseDate
        '
        Me.lblReleaseDate.AutoSize = True
        Me.lblReleaseDate.Location = New System.Drawing.Point(12, 47)
        Me.lblReleaseDate.Margin = New System.Windows.Forms.Padding(3)
        Me.lblReleaseDate.Name = "lblReleaseDate"
        Me.lblReleaseDate.Size = New System.Drawing.Size(70, 13)
        Me.lblReleaseDate.TabIndex = 6
        Me.lblReleaseDate.Text = "Releasedate:"
        '
        'LblSize
        '
        Me.LblSize.AutoSize = True
        Me.LblSize.Location = New System.Drawing.Point(12, 66)
        Me.LblSize.Margin = New System.Windows.Forms.Padding(3)
        Me.LblSize.Name = "LblSize"
        Me.LblSize.Size = New System.Drawing.Size(30, 13)
        Me.LblSize.TabIndex = 7
        Me.LblSize.Text = "Size:"
        '
        'lblChangelog
        '
        Me.lblChangelog.AutoSize = True
        Me.lblChangelog.Location = New System.Drawing.Point(12, 85)
        Me.lblChangelog.Margin = New System.Windows.Forms.Padding(3)
        Me.lblChangelog.Name = "lblChangelog"
        Me.lblChangelog.Size = New System.Drawing.Size(61, 13)
        Me.lblChangelog.TabIndex = 8
        Me.lblChangelog.Text = "Changelog:"
        '
        'LLblGetBertware
        '
        Me.LLblGetBertware.AutoSize = True
        Me.LLblGetBertware.Location = New System.Drawing.Point(14, 348)
        Me.LLblGetBertware.Name = "LLblGetBertware"
        Me.LLblGetBertware.Size = New System.Drawing.Size(143, 13)
        Me.LLblGetBertware.TabIndex = 9
        Me.LLblGetBertware.TabStop = True
        Me.LLblGetBertware.Text = "Powered by get.bertware.net"
        '
        'UpdateDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 374)
        Me.Controls.Add(Me.LLblGetBertware)
        Me.Controls.Add(Me.lblChangelog)
        Me.Controls.Add(Me.LblSize)
        Me.Controls.Add(Me.lblReleaseDate)
        Me.Controls.Add(Me.LblNewVersion)
        Me.Controls.Add(Me.lblCurrentVersion)
        Me.Controls.Add(Me.BtnIgnore)
        Me.Controls.Add(Me.BtnInstall)
        Me.Controls.Add(Me.LboxChangelog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UpdateDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Update available"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LboxChangelog As System.Windows.Forms.ListBox
    Friend WithEvents BtnInstall As System.Windows.Forms.Button
    Friend WithEvents BtnIgnore As System.Windows.Forms.Button
    Friend WithEvents lblCurrentVersion As System.Windows.Forms.Label
    Friend WithEvents LblNewVersion As System.Windows.Forms.Label
    Friend WithEvents lblReleaseDate As System.Windows.Forms.Label
    Friend WithEvents LblSize As System.Windows.Forms.Label
    Friend WithEvents lblChangelog As System.Windows.Forms.Label
    Friend WithEvents LLblGetBertware As System.Windows.Forms.LinkLabel
End Class
