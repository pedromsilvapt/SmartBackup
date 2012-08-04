Public Class BackupSet
    Private _ID As Integer
    Private _Name As String
    Private _Items As New Dictionary(Of Integer, FileRecord)

    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            Me._ID = value
        End Set
    End Property

    Public Property Name As String
        Get
            Return Me._Name
        End Get
        Set(ByVal value As String)
            Me._Name = value
        End Set
    End Property

    Public Property Item(ByVal ItemID As Integer) As FileRecord
        Get
            If (Me.ItemExists(ItemID)) Then
                Return Me._Items(ItemID)
            Else
                Throw New Exception(String.Format("The ID you specified ({0}) doesn't exist in the list!", ItemID))
            End If
        End Get
        Set(ByVal value As FileRecord)
            If (Me.ItemExists(ItemID)) Then
                Me._Items(ItemID) = value
            Else
                Throw New Exception(String.Format("The ID you specified ({0}) doesn't exist in the list!", ItemID))
            End If
        End Set
    End Property


    Public ReadOnly Property ItemsList As Dictionary(Of Integer, FileRecord).KeyCollection
        Get
            Return Me._Items.Keys
        End Get
    End Property

    Public Function ItemExists(ByVal ID As Integer) As Boolean
        Return Me._Items.ContainsKey(ID)
    End Function

    Public Sub AddItem(ByVal ID As Integer, ByVal FileInfo As FileRecord)
        If (Not Me.ItemExists(ID)) Then
            Me._Items.Add(ID, FileInfo)
        Else
            Throw New Exception(String.Format("Already exists a item in this set ({0}) with the same ID({1}).", Me.ID, ID))
        End If
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Name As String)
        Me._ID = ID
        Me._Name = Name
    End Sub
End Class
