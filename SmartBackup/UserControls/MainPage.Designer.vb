<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainPage
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainPage))
        Me.KryptonDropButton1 = New ComponentFactory.Krypton.Toolkit.KryptonDropButton()
        Me.kpnl_background = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.KryptonTextBox1 = New ComponentFactory.Krypton.Toolkit.KryptonTextBox()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.KryptonButtonsList1 = New SmartBackup.KryptonButtonsList(Me.components)
        Me.KryptonButtonsList2 = New SmartBackup.KryptonButtonsList(Me.components)
        CType(Me.kpnl_background, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kpnl_background.SuspendLayout()
        CType(Me.KryptonButtonsList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KryptonButtonsList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'KryptonDropButton1
        '
        Me.KryptonDropButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.KryptonDropButton1.Location = New System.Drawing.Point(253, 361)
        Me.KryptonDropButton1.Name = "KryptonDropButton1"
        Me.KryptonDropButton1.Size = New System.Drawing.Size(368, 188)
        Me.KryptonDropButton1.Splitter = False
        Me.KryptonDropButton1.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
                    Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
                    Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.KryptonDropButton1.StateCommon.Border.Rounding = 60
        Me.KryptonDropButton1.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonDropButton1.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.KryptonDropButton1.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.[True]
        Me.KryptonDropButton1.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonDropButton1.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.KryptonDropButton1.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KryptonDropButton1.TabIndex = 1
        Me.KryptonDropButton1.Values.ExtraText = "Upload your files to the cloud!"
        Me.KryptonDropButton1.Values.Image = CType(resources.GetObject("KryptonDropButton1.Values.Image"), System.Drawing.Image)
        Me.KryptonDropButton1.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.KryptonDropButton1.Values.Text = "Dropbox"
        '
        'kpnl_background
        '
        Me.kpnl_background.Controls.Add(Me.KryptonButtonsList1)
        Me.kpnl_background.Controls.Add(Me.KryptonButton1)
        Me.kpnl_background.Controls.Add(Me.KryptonButtonsList2)
        Me.kpnl_background.Controls.Add(Me.KryptonTextBox1)
        Me.kpnl_background.Controls.Add(Me.KryptonDropButton1)
        Me.kpnl_background.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kpnl_background.Location = New System.Drawing.Point(0, 0)
        Me.kpnl_background.Name = "kpnl_background"
        Me.kpnl_background.Size = New System.Drawing.Size(875, 556)
        Me.kpnl_background.TabIndex = 4
        '
        'KryptonTextBox1
        '
        Me.KryptonTextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KryptonTextBox1.Location = New System.Drawing.Point(781, 19)
        Me.KryptonTextBox1.Name = "KryptonTextBox1"
        Me.KryptonTextBox1.Size = New System.Drawing.Size(91, 20)
        Me.KryptonTextBox1.TabIndex = 3
        Me.KryptonTextBox1.Text = "KryptonTextBox1"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.KryptonButton1.Location = New System.Drawing.Point(6, 499)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(140, 50)
        Me.KryptonButton1.TabIndex = 6
        Me.KryptonButton1.Values.Image = Global.SmartBackup.My.Resources.Resources.glyphicons_190_circle_plus
        Me.KryptonButton1.Values.Text = ""
        '
        'KryptonButtonsList1
        '
        Me.KryptonButtonsList1.ButtonsAutoSizeH = True
        Me.KryptonButtonsList1.ButtonsAutoSizeV = False
        Me.KryptonButtonsList1.CustomSize = New System.Drawing.Size(100, 50)
        Me.KryptonButtonsList1.Location = New System.Drawing.Point(147, 5)
        Me.KryptonButtonsList1.MouseWheelScroll = False
        Me.KryptonButtonsList1.Name = "KryptonButtonsList1"
        Me.KryptonButtonsList1.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.KryptonButtonsList1.Size = New System.Drawing.Size(630, 50)
        Me.KryptonButtonsList1.TabIndex = 4
        '
        'KryptonButtonsList2
        '
        Me.KryptonButtonsList2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.KryptonButtonsList2.ButtonsAutoSizeH = False
        Me.KryptonButtonsList2.ButtonsAutoSizeV = False
        Me.KryptonButtonsList2.CustomSize = New System.Drawing.Size(138, 50)
        Me.KryptonButtonsList2.Location = New System.Drawing.Point(6, 62)
        Me.KryptonButtonsList2.MouseWheelScroll = True
        Me.KryptonButtonsList2.Name = "KryptonButtonsList2"
        Me.KryptonButtonsList2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.KryptonButtonsList2.Size = New System.Drawing.Size(140, 431)
        Me.KryptonButtonsList2.TabIndex = 5
        '
        'MainPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kpnl_background)
        Me.Name = "MainPage"
        Me.Size = New System.Drawing.Size(875, 556)
        CType(Me.kpnl_background, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kpnl_background.ResumeLayout(False)
        Me.kpnl_background.PerformLayout()
        CType(Me.KryptonButtonsList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KryptonButtonsList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents KryptonDropButton1 As ComponentFactory.Krypton.Toolkit.KryptonDropButton
    Friend WithEvents kpnl_background As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents KryptonTextBox1 As ComponentFactory.Krypton.Toolkit.KryptonTextBox
    Friend WithEvents KryptonButtonsList1 As SmartBackup.KryptonButtonsList
    Friend WithEvents KryptonButtonsList2 As SmartBackup.KryptonButtonsList
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton

End Class
