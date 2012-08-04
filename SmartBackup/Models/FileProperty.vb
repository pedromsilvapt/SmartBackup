Public Class FileProperty
    Private _type As String
    Private _name As String
    Private _value As Object
    Private _children As Dictionary(Of String, FileProperty)

    Public Property Name As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
        End Set
    End Property

    Public Property Value As Object
        Get
            If (Not Me.IsArray) Then
                Return Me._value
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As Object)
            If Not Me.IsArray Then
                Me._value = value
            End If
        End Set
    End Property

    Public ReadOnly Property IsArray As Boolean
        Get
            Return Me._type.Equals("array")
        End Get
    End Property

    Public ReadOnly Property ChildrenList As Dictionary(Of String, FileProperty).KeyCollection
        Get
            If (Me.IsArray) Then
                Return Me._children.Keys
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Property [Property](ByVal PropertyName As String) As FileProperty
        Get
            If (Me.HasChild(PropertyName)) Then
                Return Me._children(PropertyName)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal value As FileProperty)
            If (Me.HasChild(PropertyName)) Then
                Me._children(PropertyName) = value
            Else
                Me.AddProperty(value)
            End If
        End Set
    End Property

    Public Function HasChild(ByVal PropertyName As String) As Boolean
        Return Me._children.ContainsKey(PropertyName)
    End Function

    Public Sub AddProperty(ByVal NewProperty As FileProperty)
        If (Me.IsArray) Then
            If (Not Me.HasChild(NewProperty.Name)) Then
                Me._children.Add(NewProperty.Name, NewProperty)
            Else
                Throw New Exception("Trying to insert a duplicate property with the same name.")
            End If
        End If
    End Sub

    Public Sub AddProperty(ByVal PropertyName As String, ByVal NewProperty As FileProperty)
        If (Me.IsArray) Then
            If (Not Me.HasChild(PropertyName)) Then
                Me._children.Add(PropertyName, NewProperty)
                Me._children(PropertyName).Name = PropertyName
            Else
                Throw New Exception("Trying to insert a duplicate property with the same name.")
            End If
        End If
    End Sub

    Public Sub RegisterProperties(ByVal PropertiesList As Dictionary(Of String, FileProperty))
        For Each _P As KeyValuePair(Of String, FileProperty) In PropertiesList
            Me.AddProperty(_P.Key, _P.Value)
        Next
    End Sub

    Public Sub RemoveProperty(ByVal PropertyName As String)
        If (Me.IsArray) Then
            If (Me.HasChild(PropertyName)) Then
                Me._children.Remove(PropertyName)
            Else
                Throw New Exception("Trying to remove a property that doesn't exist.")
            End If
        End If
    End Sub

    Public Sub New(ByVal Name As String, ByVal Type As String, ByVal Value As Object)
        Me._name = Name
        Me._type = Type

        If (Me.IsArray) Then
            Me._children = New Dictionary(Of String, FileProperty)
        Else
            Me._value = Value
        End If
    End Sub

    Public Sub New(ByVal Name As String, ByVal Type As String)
        Me._type = Type
        Me._name = Name

        If (Me.IsArray) Then
            Me._children = New Dictionary(Of String, FileProperty)
        End If
    End Sub
End Class
