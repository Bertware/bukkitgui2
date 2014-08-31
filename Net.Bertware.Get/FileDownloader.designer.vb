
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileDownloader
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
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.PBProgress = New System.Windows.Forms.ProgressBar()
        Me.LblAction = New System.Windows.Forms.Label()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.Location = New System.Drawing.Point(13, 25)
        Me.LblStatus.Margin = New System.Windows.Forms.Padding(3)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(40, 13)
        Me.LblStatus.TabIndex = 0
        Me.LblStatus.Text = "Status:"
        '
        'PBProgress
        '
        Me.PBProgress.BackColor = System.Drawing.SystemColors.Control
        Me.PBProgress.Location = New System.Drawing.Point(16, 41)
        Me.PBProgress.Name = "PBProgress"
        Me.PBProgress.Size = New System.Drawing.Size(308, 23)
        Me.PBProgress.TabIndex = 1
        '
        'LblAction
        '
        Me.LblAction.AutoSize = True
        Me.LblAction.Location = New System.Drawing.Point(12, 9)
        Me.LblAction.Name = "LblAction"
        Me.LblAction.Size = New System.Drawing.Size(78, 13)
        Me.LblAction.TabIndex = 2
        Me.LblAction.Text = "Downloading..."
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(330, 41)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FileDownloader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 78)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.LblAction)
        Me.Controls.Add(Me.PBProgress)
        Me.Controls.Add(Me.LblStatus)
        Me.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FileDownloader"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "File Download"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents PBProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents LblAction As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
