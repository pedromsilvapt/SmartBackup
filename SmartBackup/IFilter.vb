Public Interface IFilter

    ReadOnly Property Name As String
    ReadOnly Property Label(ByVal Lang As String) As String
    ReadOnly Property Required As Boolean
    Property Activated As Boolean

    Function Validate(ByVal TestFile As FileRecord) As Boolean

End Interface
