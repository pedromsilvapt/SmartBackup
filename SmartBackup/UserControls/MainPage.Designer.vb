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
        Me.kbtn_execute = New ComponentFactory.Krypton.Toolkit.KryptonDropButton()
        Me.kpnl_background = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.kstxt_filtertext = New SmartBackup.KryptonShadowTextBox()
        Me.kpnl_mainarea = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.kpnl_fileslist = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.kbtnl_filters = New SmartBackup.KryptonButtonsList(Me.components)
        Me.kbtn_backupsets_add = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.kbtnl_backupsets = New SmartBackup.KryptonButtonsList(Me.components)
        Me.kctm_backupsets_actions = New ComponentFactory.Krypton.Toolkit.KryptonContextMenu()
        Me.kctmis_backupsets = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.kctmi_editbackupset = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        Me.kctmi_removebackupset = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem()
        CType(Me.kpnl_background, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kpnl_background.SuspendLayout()
        CType(Me.kpnl_mainarea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kpnl_mainarea.SuspendLayout()
        CType(Me.kpnl_fileslist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kbtnl_filters, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.kbtnl_backupsets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'kbtn_execute
        '
        Me.kbtn_execute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.kbtn_execute.Location = New System.Drawing.Point(152, 361)
        Me.kbtn_execute.Name = "kbtn_execute"
        Me.kbtn_execute.Size = New System.Drawing.Size(368, 188)
        Me.kbtn_execute.Splitter = False
        Me.kbtn_execute.StateCommon.Border.DrawBorders = CType((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) _
                    Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) _
                    Or ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right), ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)
        Me.kbtn_execute.StateCommon.Border.Rounding = 60
        Me.kbtn_execute.StateCommon.Content.Image.ImageH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.kbtn_execute.StateCommon.Content.Image.ImageV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center
        Me.kbtn_execute.StateCommon.Content.LongText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.[True]
        Me.kbtn_execute.StateCommon.Content.LongText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.kbtn_execute.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far
        Me.kbtn_execute.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kbtn_execute.TabIndex = 1
        Me.kbtn_execute.Values.ExtraText = "Upload your files to the cloud!"
        Me.kbtn_execute.Values.Image = CType(resources.GetObject("kbtn_execute.Values.Image"), System.Drawing.Image)
        Me.kbtn_execute.Values.ImageTransparentColor = System.Drawing.Color.White
        Me.kbtn_execute.Values.Text = "Dropbox"
        '
        'kpnl_background
        '
        Me.kpnl_background.Controls.Add(Me.kstxt_filtertext)
        Me.kpnl_background.Controls.Add(Me.kpnl_mainarea)
        Me.kpnl_background.Controls.Add(Me.kbtnl_filters)
        Me.kpnl_background.Controls.Add(Me.kbtn_backupsets_add)
        Me.kpnl_background.Controls.Add(Me.kbtnl_backupsets)
        Me.kpnl_background.Controls.Add(Me.kbtn_execute)
        Me.kpnl_background.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kpnl_background.Location = New System.Drawing.Point(0, 0)
        Me.kpnl_background.Name = "kpnl_background"
        Me.kpnl_background.Size = New System.Drawing.Size(893, 556)
        Me.kpnl_background.TabIndex = 4
        '
        'kstxt_filtertext
        '
        Me.kstxt_filtertext.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.kstxt_filtertext.Location = New System.Drawing.Point(793, 21)
        Me.kstxt_filtertext.Name = "kstxt_filtertext"
        Me.kstxt_filtertext.NormalFont = Nothing
        Me.kstxt_filtertext.NormalFontColor = System.Drawing.Color.Black
        Me.kstxt_filtertext.ShadowFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kstxt_filtertext.ShadowFontColor = System.Drawing.Color.DimGray
        Me.kstxt_filtertext.ShadowText = "Ola"
        Me.kstxt_filtertext.Size = New System.Drawing.Size(97, 20)
        Me.kstxt_filtertext.StateCommon.Content.Color1 = System.Drawing.Color.Black
        Me.kstxt_filtertext.TabIndex = 8
        Me.kstxt_filtertext.Text = "KryptonShadowTextBox1"
        '
        'kpnl_mainarea
        '
        Me.kpnl_mainarea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.kpnl_mainarea.Controls.Add(Me.kpnl_fileslist)
        Me.kpnl_mainarea.Location = New System.Drawing.Point(152, 62)
        Me.kpnl_mainarea.Name = "kpnl_mainarea"
        Me.kpnl_mainarea.Size = New System.Drawing.Size(738, 293)
        Me.kpnl_mainarea.TabIndex = 7
        '
        'kpnl_fileslist
        '
        Me.kpnl_fileslist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kpnl_fileslist.Location = New System.Drawing.Point(0, 0)
        Me.kpnl_fileslist.Name = "kpnl_fileslist"
        Me.kpnl_fileslist.Size = New System.Drawing.Size(738, 293)
        Me.kpnl_fileslist.TabIndex = 0
        '
        'kbtnl_filters
        '
        Me.kbtnl_filters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.kbtnl_filters.ButtonsAutoSizeH = True
        Me.kbtnl_filters.ButtonsAutoSizeV = False
        Me.kbtnl_filters.CustomSize = New System.Drawing.Size(100, 50)
        Me.kbtnl_filters.Location = New System.Drawing.Point(152, 5)
        Me.kbtnl_filters.MouseWheelScroll = False
        Me.kbtnl_filters.Name = "kbtnl_filters"
        Me.kbtnl_filters.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.kbtnl_filters.Size = New System.Drawing.Size(650, 50)
        Me.kbtnl_filters.TabIndex = 4
        '
        'kbtn_backupsets_add
        '
        Me.kbtn_backupsets_add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.kbtn_backupsets_add.Location = New System.Drawing.Point(6, 499)
        Me.kbtn_backupsets_add.Name = "kbtn_backupsets_add"
        Me.kbtn_backupsets_add.Size = New System.Drawing.Size(140, 50)
        Me.kbtn_backupsets_add.TabIndex = 6
        Me.kbtn_backupsets_add.Values.Image = Global.SmartBackup.My.Resources.Resources.glyphicons_190_circle_plus
        Me.kbtn_backupsets_add.Values.Text = ""
        '
        'kbtnl_backupsets
        '
        Me.kbtnl_backupsets.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.kbtnl_backupsets.ButtonsAutoSizeH = False
        Me.kbtnl_backupsets.ButtonsAutoSizeV = False
        Me.kbtnl_backupsets.CustomSize = New System.Drawing.Size(138, 50)
        Me.kbtnl_backupsets.Location = New System.Drawing.Point(6, 62)
        Me.kbtnl_backupsets.MouseWheelScroll = True
        Me.kbtnl_backupsets.Name = "kbtnl_backupsets"
        Me.kbtnl_backupsets.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.kbtnl_backupsets.Size = New System.Drawing.Size(140, 431)
        Me.kbtnl_backupsets.TabIndex = 5
        '
        'kctm_backupsets_actions
        '
        Me.kctm_backupsets_actions.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.kctmis_backupsets})
        '
        'kctmis_backupsets
        '
        Me.kctmis_backupsets.Items.AddRange(New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItemBase() {Me.kctmi_editbackupset, Me.kctmi_removebackupset})
        '
        'kctmi_editbackupset
        '
        Me.kctmi_editbackupset.Image = Global.SmartBackup.My.Resources.Resources.pencil
        Me.kctmi_editbackupset.Text = "Editar Grupo"
        '
        'kctmi_removebackupset
        '
        Me.kctmi_removebackupset.Image = Global.SmartBackup.My.Resources.Resources.cross
        Me.kctmi_removebackupset.Text = "Eliminar Grupo"
        '
        'MainPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kpnl_background)
        Me.Name = "MainPage"
        Me.Size = New System.Drawing.Size(893, 556)
        CType(Me.kpnl_background, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kpnl_background.ResumeLayout(False)
        Me.kpnl_background.PerformLayout()
        CType(Me.kpnl_mainarea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kpnl_mainarea.ResumeLayout(False)
        CType(Me.kpnl_fileslist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.kbtnl_filters, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.kbtnl_backupsets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents kbtn_execute As ComponentFactory.Krypton.Toolkit.KryptonDropButton
    Friend WithEvents kpnl_background As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents kbtnl_filters As SmartBackup.KryptonButtonsList
    Friend WithEvents kbtnl_backupsets As SmartBackup.KryptonButtonsList
    Friend WithEvents kbtn_backupsets_add As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents kctm_backupsets_actions As ComponentFactory.Krypton.Toolkit.KryptonContextMenu
    Friend WithEvents kctmis_backupsets As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents kctmi_editbackupset As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents kctmi_removebackupset As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItem
    Friend WithEvents kpnl_mainarea As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents kpnl_fileslist As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents kstxt_filtertext As SmartBackup.KryptonShadowTextBox

End Class
