Public Class FilterManager
    Private _FilterList As New Dictionary(Of String, IFilter)

    Public Event FilterChanged(ByVal sender As Object, ByVal filter As IFilter)

    Public ReadOnly Property FiltersList As Dictionary(Of String, IFilter).KeyCollection
        Get
            Return _FilterList.Keys
        End Get
    End Property

    Public Property Filter(ByVal FilterName As String) As IFilter
        Get
            If (Me.FilterIsRegistered(FilterName)) Then
                Return Me._FilterList(FilterName)
            Else
                Throw New Exception(String.Format("The filter you're trying to access ({0}) doesn't exist.", FilterName))
            End If
        End Get
        Set(ByVal value As IFilter)
            If (Me.FilterIsRegistered(FilterName)) Then
                Me._FilterList(FilterName) = value
            Else
                Throw New Exception(String.Format("The filter you're trying to access ({0}) doesn't exist.", FilterName))
            End If
        End Set
    End Property


    Public Function FilterIsRegistered(ByVal FilterName As String) As Boolean
        Return Me._FilterList.ContainsKey(FilterName)
    End Function

    Public Sub RegisterFilter(ByVal NewFilter As IFilter, Optional ByVal Activate As Boolean = False)
        If (Not Me.FilterIsRegistered(NewFilter.Name)) Then
            _FilterList.Add(NewFilter.Name, NewFilter)
            NewFilter.Activated = Activate

            If (Activate) Then
                RaiseEvent FilterChanged(Me, _FilterList(NewFilter.Name))
            End If
        Else
            Throw New Exception(String.Format("There already exists a filter ({0}) with the same name. The current filter won't be added.", NewFilter.Name))
        End If
    End Sub

    Public Sub UnregisterFilter(ByVal FilterName As String)
        If (Me.FilterIsRegistered(FilterName)) Then
            Me._FilterList.Remove(FilterName)

            RaiseEvent FilterChanged(Me, Nothing)
        Else
            Throw New Exception(String.Format("There isn't any filter with that name ({0}).", FilterName))
        End If
    End Sub

    Public Sub ActivateFilter(ByVal FilterName)
        If (Me.FilterIsRegistered(FilterName)) Then
            If (Not Me._FilterList(FilterName).Activated) Then
                Me._FilterList(FilterName).Activated = True

                RaiseEvent FilterChanged(Me, _FilterList(FilterName))
            End If
        Else
            Throw New Exception(String.Format("The filter you're trying to activate ({0}) doesn't exist.", FilterName))
        End If
    End Sub

    Public Sub DeactivateFilter(ByVal FilterName)
        If (Me.FilterIsRegistered(FilterName)) Then
            If (Me._FilterList(FilterName).Activated) Then
                Me._FilterList(FilterName).Activated = False

                RaiseEvent FilterChanged(Me, _FilterList(FilterName))
            End If
        Else
            Throw New Exception(String.Format("The filter you're trying to deactivate ({0}) doesn't exist.", FilterName))
        End If
    End Sub

    Public Sub ToogleFilter(ByVal FilterName As String)
        If (Me.FilterIsRegistered(FilterName)) Then
            Me._FilterList(FilterName).Activated = Not Me._FilterList(FilterName).Activated

            RaiseEvent FilterChanged(Me, _FilterList(FilterName))
        Else
            Throw New Exception(String.Format("The filter you're trying to toggle ({0}) doesn't exist.", FilterName))
        End If
    End Sub

    Public Sub ToogleFilter(ByVal FilterName As String, ByVal state As Boolean)
        If (Me.FilterIsRegistered(FilterName)) Then
            If (Me.Filter(FilterName).Activated = Not state) Then
                Me._FilterList(FilterName).Activated = state

                RaiseEvent FilterChanged(Me, _FilterList(FilterName))
            End If
        Else
            Throw New Exception(String.Format("The filter you're trying to toggle ({0}) doesn't exist.", FilterName))
        End If
    End Sub

End Class
