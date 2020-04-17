<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GUI
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtBoxEntry = New System.Windows.Forms.TextBox()
        Me.TxtBoxResult = New System.Windows.Forms.TextBox()
        Me.TxtTweetResult = New System.Windows.Forms.TextBox()
        Me.TxtTweet = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 66)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtBoxEntry
        '
        Me.TxtBoxEntry.Location = New System.Drawing.Point(13, 30)
        Me.TxtBoxEntry.Name = "TxtBoxEntry"
        Me.TxtBoxEntry.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBoxEntry.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoxEntry.TabIndex = 1
        '
        'TxtBoxResult
        '
        Me.TxtBoxResult.Location = New System.Drawing.Point(13, 111)
        Me.TxtBoxResult.Name = "TxtBoxResult"
        Me.TxtBoxResult.ReadOnly = True
        Me.TxtBoxResult.Size = New System.Drawing.Size(100, 20)
        Me.TxtBoxResult.TabIndex = 2
        '
        'TxtTweetResult
        '
        Me.TxtTweetResult.Location = New System.Drawing.Point(205, 111)
        Me.TxtTweetResult.Name = "TxtTweetResult"
        Me.TxtTweetResult.ReadOnly = True
        Me.TxtTweetResult.Size = New System.Drawing.Size(100, 20)
        Me.TxtTweetResult.TabIndex = 8
        '
        'TxtTweet
        '
        Me.TxtTweet.Location = New System.Drawing.Point(205, 30)
        Me.TxtTweet.Name = "TxtTweet"
        Me.TxtTweet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTweet.Size = New System.Drawing.Size(100, 20)
        Me.TxtTweet.TabIndex = 7
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(205, 66)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(380, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 285)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.TxtTweetResult)
        Me.Controls.Add(Me.TxtTweet)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TxtBoxResult)
        Me.Controls.Add(Me.TxtBoxEntry)
        Me.Controls.Add(Me.Button1)
        Me.Name = "GUI"
        Me.Text = "GUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TxtBoxEntry As TextBox
    Friend WithEvents TxtBoxResult As TextBox
    Friend WithEvents TxtTweetResult As TextBox
    Friend WithEvents TxtTweet As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
End Class
