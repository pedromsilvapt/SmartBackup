Public Class FoldersFilter
    Implements IFilter

    Public ReadOnly Property Name As String Implements IFilter.Name
        Get
            Return "FoldersFilter"
        End Get
    End Property

    Public ReadOnly Property Label(ByVal Lang As String) As String Implements IFilter.Label
        Get
            Return "Mostrar Pastas"
        End Get
    End Property

    Public ReadOnly Property Required As Boolean Implements IFilter.Required
        Get
            Return False
        End Get
    End Property

    Public Property Activated As Boolean Implements IFilter.Activated


    Public Function Validate(ByVal TestFile As FileRecord) As Boolean Implements IFilter.Validate
        Return TestFile.IsFolder
    End Function

End Class
