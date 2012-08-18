Public Class KryptonShadowTextBox
    Inherits ComponentFactory.Krypton.Toolkit.KryptonTextBox

    Private _ShowingShadow As Boolean = True
    Private _ShadowText As String = "Empty"

    Private _ShadowFont As Font
    Private _ShadowFontColor As Color = Color.Black

    Private _DefaultFont As Font
    Private _DefaultFontColor As Color = Color.Black


    Public ReadOnly Property ShowingShadow As Boolean
        Get
            Return Me._ShowingShadow
        End Get
    End Property

    Public Property ShadowText As String
        Get
            Return Me._ShadowText
        End Get
        Set(ByVal value As String)
            Me._ShadowText = value
        End Set
    End Property

    Public Property ShadowFont As Font
        Get
            Return Me._ShadowFont
        End Get
        Set(ByVal value As Font)
            Me._ShadowFont = value

            If (Me.ShowingShadow) Then
                Me.StateCommon.Content.Font = Me.ShadowFont
            End If
        End Set
    End Property

    Public Property ShadowFontColor As Color
        Get
            Return Me._ShadowFontColor
        End Get
        Set(ByVal value As Color)
            Me._ShadowFontColor = value

            If (Me.ShowingShadow) Then
                Me.StateCommon.Content.Color1 = Me._ShadowFontColor
            End If
        End Set
    End Property

    Public Property NormalFont As Font
        Get
            Return Me._DefaultFont
        End Get
        Set(ByVal value As Font)
            Me._DefaultFont = value

            If (Not Me.ShowingShadow) Then
                Me.StateCommon.Content.Font = Me._DefaultFont
            End If
        End Set
    End Property

    Public Property NormalFontColor As Color
        Get
            Return Me._DefaultFontColor
        End Get
        Set(ByVal value As Color)
            Me._DefaultFontColor = value

            If (Not Me.ShowingShadow) Then
                Me.StateCommon.Content.Color1 = Me._DefaultFontColor
            End If
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return Me.GetText(False)
        End Get
        Set(ByVal value As String)
            Me.SetText(value, True)
        End Set
    End Property

    Protected Friend Sub SetText(ByVal value As String, Optional ByVal IsInput As Boolean = True)
        If (IsInput) Then
            If (value = "" And Not Me.Focused) Then
                ShowShadow()
            Else
                HideShadow()
                Me.TextBox.Text = value
            End If
        Else
            Me.TextBox.Text = value
        End If
    End Sub

    Protected Friend Function GetText(Optional ByVal RealText As Boolean = False) As String
        If (Not RealText And Me.ShowingShadow) Then
            Return ""
        Else
            Return Me.TextBox.Text
        End If
    End Function

    Protected Friend Sub ShowShadow()
        Me._ShowingShadow = True

        Me.StateCommon.Content.Font = Me.ShadowFont
        Me.StateCommon.Content.Color1 = Me._ShadowFontColor

        Me.SetText(Me._ShadowText, False)
    End Sub

    Protected Friend Sub HideShadow()
        Me._ShowingShadow = False

        Me.StateCommon.Content.Font = Me.NormalFont
        Me.StateCommon.Content.Color1 = Me._DefaultFontColor

        Me.SetText("", False)
    End Sub

    Private Sub KryptonShadowTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If (Me.ShowingShadow) Then
            Me.HideShadow()
        End If
    End Sub

    Private Sub KryptonShadowTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        If (Me.Text = "") Then
            Me.ShowShadow()
        End If
    End Sub
End Class
