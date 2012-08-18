Public Class KryptonButtonsList

    Private _Orientation As Orientation = Orientation.Horizontal
    Private _CheckSets As New Dictionary(Of String, ComponentFactory.Krypton.Toolkit.KryptonCheckSet)
    Private _CustomSize As Size = New Size(100, 50)


    Public Property Orientation As Orientation
        Get
            Return Me._Orientation
        End Get
        Set(ByVal value As Orientation)
            If (Me._Orientation <> value) Then
                Me._Orientation = value
                If (Me._Orientation = Windows.Forms.Orientation.Horizontal) Then
                    Me.flpnl_main.FlowDirection = Windows.Forms.FlowDirection.LeftToRight
                Else
                    Me.flpnl_main.FlowDirection = Windows.Forms.FlowDirection.TopDown
                End If

                RenderButtons()
            End If
        End Set
    End Property

    Public Property Button(ByVal ButtonName As String) As ComponentFactory.Krypton.Toolkit.KryptonButton
        Get
            If Me.ButtonExists(ButtonName) Then
                Return Me.flpnl_main.Controls(ButtonName)
            Else
                Throw New Exception("The button doesn't exists.")
            End If
        End Get
        Set(ByVal value As ComponentFactory.Krypton.Toolkit.KryptonButton)
            If Me.ButtonExists(ButtonName) Then
                Dim item = Me.flpnl_main.Controls.Find(ButtonName, True).First()
                item = value
            Else
                Throw New Exception("The button doesn't exists.")
            End If
        End Set
    End Property

    Public Property CheckButton(ByVal ButtonName As String) As ComponentFactory.Krypton.Toolkit.KryptonCheckButton
        Get
            If Me.ButtonExists(ButtonName) Then
                Return Me.flpnl_main.Controls(ButtonName)
            Else
                Throw New Exception("The button doesn't exists.")
            End If
        End Get
        Set(ByVal value As ComponentFactory.Krypton.Toolkit.KryptonCheckButton)
            If Me.ButtonExists(ButtonName) Then
                Dim item = Me.flpnl_main.Controls.Find(ButtonName, True).First()
                item = value
            Else
                Throw New Exception("The button doesn't exists.")
            End If
        End Set
    End Property

    Public Property CheckSet(ByVal CheckSetName As String) As ComponentFactory.Krypton.Toolkit.KryptonCheckSet
        Get
            If (Me.CheckSetExists(CheckSetName)) Then
                Return Me._CheckSets(CheckSetName)
            Else
                Throw New Exception("The CheckSet doesn't exists.")
            End If
        End Get
        Set(ByVal value As ComponentFactory.Krypton.Toolkit.KryptonCheckSet)
            If (Me.CheckSetExists(CheckSetName)) Then
                Me._CheckSets(CheckSetName) = value
            Else
                Throw New Exception("The CheckSet doesn't exists.")
            End If
        End Set
    End Property

    'Public ReadOnly Property ListHeight As Single
    'Get
    '   If Not Me.ButtonsAutoSizeV Then
    '       Return Me.Height * Me.flpnl_main.Controls.Count
    '   Else
    'Dim sum As Single = 0
    '            For Each _Buttons As ComponentFactory.Krypton.Toolkit.KryptonButton In Me.flpnl_main.Controls
    '                sum += _Buttons.Height
    '            Next
    '            Return sum
    '        End If
    '    End Get
    'End Property

    Public ReadOnly Property ListHeight As Single
        Get
            If Me.ButtonsAutoSizeV Then
                If (Me.Orientation = Windows.Forms.Orientation.Vertical) Then
                    Dim avg As Single = 0
                    For Each _Button As ComponentFactory.Krypton.Toolkit.KryptonButton In Me.flpnl_main.Controls
                        If (_Button.Height > avg) Then
                            avg = _Button.Height
                        End If
                    Next
                    Return avg
                Else
                    Dim sum As Single = 0
                    For Each _Button As ComponentFactory.Krypton.Toolkit.KryptonButton In Me.flpnl_main.Controls
                        sum += _Button.Height
                    Next
                    Return sum
                End If
            Else
                If (Me.Orientation = Windows.Forms.Orientation.Vertical) Then
                    Return Me.CustomSize.Height * Me.flpnl_main.Controls.Count
                Else
                    Return Me.CustomSize.Height
                End If
            End If
        End Get
    End Property

    Public ReadOnly Property ListWidth As Single
        Get
            If Me.ButtonsAutoSizeH Then
                If (Me.Orientation = Windows.Forms.Orientation.Vertical) Then
                    Dim avg As Single = 0
                    For Each _Button As ComponentFactory.Krypton.Toolkit.KryptonButton In Me.flpnl_main.Controls
                        If (_Button.Width > avg) Then
                            avg = _Button.Width
                        End If
                    Next
                    Return avg
                Else
                    Dim sum As Single = 0
                    For Each _Button As ComponentFactory.Krypton.Toolkit.KryptonButton In Me.flpnl_main.Controls
                        sum += _Button.Width
                    Next
                    Return sum
                End If
            Else
                If (Me.Orientation = Windows.Forms.Orientation.Vertical) Then
                    Return Me.CustomSize.Width
                Else
                    Return Me.CustomSize.Width * Me.flpnl_main.Controls.Count
                End If
            End If
        End Get
    End Property

    Public Property CustomSize As Size
        Get
            Return Me._CustomSize
        End Get
        Set(ByVal value As Size)
            Me._CustomSize = value
        End Set
    End Property

    Public Property ButtonsAutoSizeH As Boolean = True

    Public Property ButtonsAutoSizeV As Boolean = False

    Public Property MouseWheelScroll As Boolean = True


    Public Sub RenderButtons()
        If (Me.Orientation = Windows.Forms.Orientation.Vertical) Then
            For Each _Button As ComponentFactory.Krypton.Toolkit.KryptonButton In Me.flpnl_main.Controls
                If (Me.flpnl_main.Controls.GetChildIndex(_Button) = 0) Then
                    _Button.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.All
                Else
                    _Button.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.BottomLeftRight
                End If

                If (Me.Orientation = Windows.Forms.Orientation.Vertical) Then
                    _Button.Width = Me.Width
                End If

                If (Me.ButtonsAutoSizeH Or Me.ButtonsAutoSizeV) Then
                    _Button.AutoSize = True
                    _Button.Size = _Button.PreferredSize
                    _Button.AutoSize = False
                End If
                If (Not Me.ButtonsAutoSizeH) Then
                    _Button.Width = Me.CustomSize.Width
                End If
                If (Not Me.ButtonsAutoSizeV) Then
                    _Button.Height = Me.CustomSize.Height
                End If
            Next
        Else
            For Each _Button As ComponentFactory.Krypton.Toolkit.KryptonButton In Me.flpnl_main.Controls
                If (Me.flpnl_main.Controls.GetChildIndex(_Button) = 0) Then
                    _Button.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.All
                Else
                    _Button.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.TopBottomRight
                End If

                If (Me.ButtonsAutoSizeH Or Me.ButtonsAutoSizeV) Then
                    _Button.AutoSize = True
                    _Button.Size = _Button.PreferredSize
                    _Button.AutoSize = False
                End If
                If (Not Me.ButtonsAutoSizeH) Then
                    _Button.Width = Me.CustomSize.Width
                End If
                If (Not Me.ButtonsAutoSizeV) Then
                    _Button.Height = Me.CustomSize.Height
                End If
            Next
        End If

        Me.RefreshPanelSize()
    End Sub

    Public Sub RefreshPanelSize()
        Me.flpnl_main.Height = Me.ListHeight
        Me.flpnl_main.Width = Me.ListWidth
    End Sub

    Public Function CheckSetExists(ByVal CheckSetName As String) As Boolean
        Return Me._CheckSets.ContainsKey(CheckSetName)
    End Function

    Public Function ButtonExists(ByVal ButtonName As String) As Boolean
        Return Me.flpnl_main.Controls.ContainsKey(ButtonName)
    End Function

    Public Sub AddCheckSet(ByVal CheckSetName As String)
        If Not Me.CheckSetExists(CheckSetName) Then
            Dim newCKS As New ComponentFactory.Krypton.Toolkit.KryptonCheckSet

            newCKS.AllowUncheck = False
            Me._CheckSets.Add(CheckSetName, newCKS)
        Else
            Throw New Exception(String.Format("There already exists a Button with the same name ({0}).", CheckSetName))
        End If
    End Sub

    Public Sub AddButton(ByVal ButtonName As String, ByVal ButtonText As String, Optional ByVal Tag As String = "")
        If Not Me.ButtonExists(ButtonName) Then
            Dim kbtnNew As New ComponentFactory.Krypton.Toolkit.KryptonButton
            kbtnNew.Name = ButtonName
            kbtnNew.Text = ButtonText
            kbtnNew.Tag = Tag
            kbtnNew.Text = ButtonText
            kbtnNew.Margin = New Padding(0)
            kbtnNew.StateCommon.Border.Rounding = 0

            Me.flpnl_main.Controls.Add(kbtnNew)

            Me.RenderButtons()
        Else
            Throw New Exception(String.Format("There already exists a Button with the same name ({0}).", ButtonName))
        End If
    End Sub

    Public Sub AddCheckButton(ByVal ButtonName As String, ByVal ButtonText As String, Optional ByVal Tag As String = "", Optional ByVal Checked As Boolean = False, Optional ByVal CheckSetName As String = "")
        If Not Me.flpnl_main.Controls.ContainsKey(ButtonName) Then
            Dim kbtnNew As New ComponentFactory.Krypton.Toolkit.KryptonCheckButton
            kbtnNew.Name = ButtonName
            kbtnNew.Text = ButtonText
            kbtnNew.Tag = Tag
            kbtnNew.Text = ButtonText
            kbtnNew.Margin = New Padding(0)
            kbtnNew.StateCommon.Border.Rounding = 0
            kbtnNew.Checked = Checked

            If (Me.Orientation = Windows.Forms.Orientation.Horizontal) Then
                kbtnNew.AutoSize = True
                kbtnNew.Size = kbtnNew.PreferredSize
                kbtnNew.AutoSize = False
            End If

            Me.flpnl_main.Controls.Add(kbtnNew)

            If (Not CheckSetName.Equals("")) Then
                If (Me.CheckSetExists(CheckSetName)) Then
                    Me._CheckSets(CheckSetName).CheckButtons.Add(kbtnNew)
                    If (Checked) Then
                        Me._CheckSets(CheckSetName).CheckedButton = kbtnNew
                    End If
                Else
                    Throw New Exception("There isn't any CheckSet with that name.")
                End If
            End If

            Me.RenderButtons()
        Else
            Throw New Exception(String.Format("There already exists a Button with the same name ({0}).", ButtonName))
        End If
    End Sub

    Public Sub RemoveButton(ByVal buttonName As String)
        If (Me.ButtonExists(buttonName)) Then
            Me.flpnl_main.Controls.RemoveByKey(buttonName)
        Else
            Throw New Exception(String.Format("The item you're trying to remove ({0}) doesn't exist.", buttonName))
        End If
    End Sub

    Private Sub KryptonButtonsList_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        RefreshPanelSize()
    End Sub

    Private Sub flpnl_main_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles flpnl_main.MouseWheel
        If Me.MouseWheelScroll Then
            Debug.WriteLine(e.Delta)
        End If
    End Sub
End Class
