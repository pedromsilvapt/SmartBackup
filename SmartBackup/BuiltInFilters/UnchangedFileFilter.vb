Public Class UnchangedFileFilter
    Implements IFilter

    Public ReadOnly Property Name As String Implements IFilter.Name
        Get
            Return "UnchangedFileFilter"
        End Get
    End Property

    Public ReadOnly Property Label(ByVal Lang As String) As String Implements IFilter.Label
        Get
            Return "Mostrar Items Inalterados"
        End Get
    End Property

    Public ReadOnly Property Required As Boolean Implements IFilter.Required
        Get
            Return False
        End Get
    End Property

    Public Property Activated As Boolean Implements IFilter.Activated

    Public Function Validate(ByVal TestFile As FileRecord) As Boolean Implements IFilter.Validate
        Return Not TestFile.Changed
    End Function

End Class
