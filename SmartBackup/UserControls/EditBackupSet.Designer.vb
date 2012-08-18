<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditBackupSet
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
        Me.kpnl_background = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.kbtn_cancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.kpbl_center = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.ktxt_backgupset_name = New SmartBackup.KryptonShadowTextBox()
        Me.kbtn_remove = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.kbtn_save = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        CType(Me.kpnl_background, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kpnl_background.SuspendLayout()
        CType(Me.kpbl_center, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.kpbl_center.SuspendLayout()
        Me.SuspendLayout()
        '
        'kpnl_background
        '
        Me.kpnl_background.Controls.Add(Me.kbtn_cancel)
        Me.kpnl_background.Controls.Add(Me.kpbl_center)
        Me.kpnl_background.Dock = System.Windows.Forms.DockStyle.Fill
        Me.kpnl_background.Location = New System.Drawing.Point(0, 0)
        Me.kpnl_background.Name = "kpnl_background"
        Me.kpnl_background.Size = New System.Drawing.Size(547, 323)
        Me.kpnl_background.TabIndex = 0
        '
        'kbtn_cancel
        '
        Me.kbtn_cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.kbtn_cancel.Location = New System.Drawing.Point(504, 3)
        Me.kbtn_cancel.Name = "kbtn_cancel"
        Me.kbtn_cancel.Size = New System.Drawing.Size(40, 40)
        Me.kbtn_cancel.TabIndex = 4
        Me.kbtn_cancel.Values.Image = Global.SmartBackup.My.Resources.Resources.glyphicons_192_circle_remove
        Me.kbtn_cancel.Values.Text = ""
        '
        'kpbl_center
        '
        Me.kpbl_center.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.kpbl_center.Controls.Add(Me.ktxt_backgupset_name)
        Me.kpbl_center.Controls.Add(Me.kbtn_remove)
        Me.kpbl_center.Controls.Add(Me.kbtn_save)
        Me.kpbl_center.Location = New System.Drawing.Point(86, 95)
        Me.kpbl_center.Name = "kpbl_center"
        Me.kpbl_center.Size = New System.Drawing.Size(362, 136)
        Me.kpbl_center.TabIndex = 3
        '
        'ktxt_backgupset_name
        '
        Me.ktxt_backgupset_name.Location = New System.Drawing.Point(3, 3)
        Me.ktxt_backgupset_name.Name = "ktxt_backgupset_name"
        Me.ktxt_backgupset_name.NormalFont = New System.Drawing.Font("Segoe UI", 21.75!)
        Me.ktxt_backgupset_name.NormalFontColor = System.Drawing.Color.Black
        Me.ktxt_backgupset_name.ShadowFont = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ktxt_backgupset_name.ShadowFontColor = System.Drawing.Color.DimGray
        Me.ktxt_backgupset_name.ShadowText = "Nome do BackupSet"
        Me.ktxt_backgupset_name.Size = New System.Drawing.Size(354, 43)
        Me.ktxt_backgupset_name.StateCommon.Content.Color1 = System.Drawing.Color.DimGray
        Me.ktxt_backgupset_name.StateCommon.Content.Font = New System.Drawing.Font("Segoe UI", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ktxt_backgupset_name.TabIndex = 4
        '
        'kbtn_remove
        '
        Me.kbtn_remove.Location = New System.Drawing.Point(3, 53)
        Me.kbtn_remove.Name = "kbtn_remove"
        Me.kbtn_remove.Size = New System.Drawing.Size(174, 80)
        Me.kbtn_remove.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.kbtn_remove.TabIndex = 3
        Me.kbtn_remove.Values.Text = "Remover"
        '
        'kbtn_save
        '
        Me.kbtn_save.Location = New System.Drawing.Point(183, 53)
        Me.kbtn_save.Name = "kbtn_save"
        Me.kbtn_save.Size = New System.Drawing.Size(174, 80)
        Me.kbtn_save.StateCommon.Content.ShortText.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kbtn_save.TabIndex = 0
        Me.kbtn_save.Values.Text = "Guardar"
        '
        'EditBackupSet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.kpnl_background)
        Me.Name = "EditBackupSet"
        Me.Size = New System.Drawing.Size(547, 323)
        CType(Me.kpnl_background, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kpnl_background.ResumeLayout(False)
        CType(Me.kpbl_center, System.ComponentModel.ISupportInitialize).EndInit()
        Me.kpbl_center.ResumeLayout(False)
        Me.kpbl_center.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents kpnl_background As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents kpbl_center As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents kbtn_remove As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents kbtn_save As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents ktxt_backgupset_name As SmartBackup.KryptonShadowTextBox
    Friend WithEvents kbtn_cancel As ComponentFactory.Krypton.Toolkit.KryptonButton

End Class
