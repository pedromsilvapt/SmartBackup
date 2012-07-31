Partial Class KryptonButtonsList
    Inherits ComponentFactory.Krypton.Toolkit.KryptonPanel

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()


        '
        Me.Controls.Add(Me.flpnl_main)
    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.flpnl_main = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flpnl_main
        '
        Me.flpnl_main.BackColor = System.Drawing.Color.Transparent
        Me.flpnl_main.Location = New System.Drawing.Point(0, 0)
        Me.flpnl_main.Name = "flpnl_main"
        Me.flpnl_main.Size = New System.Drawing.Size(300, 100)
        Me.flpnl_main.TabIndex = 0
        '
        'KryptonButtonsList
        '
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flpnl_main As System.Windows.Forms.FlowLayoutPanel

End Class
