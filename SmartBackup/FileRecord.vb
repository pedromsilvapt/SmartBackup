Public Class FileRecord
    Private _FileURL As String
    Private _isFile As Boolean
    Private _isFolder As Boolean
    Private _oldMD5Checksum As String
    Private _oldLastModify As DateTime

    Public Property FileURL As String
        Get
            Return Me._FileURL
        End Get
        Set(ByVal value As String)
            Me._FileURL = value
        End Set
    End Property

    Public ReadOnly Property IsFile As Boolean
        Get
            Return True
        End Get
    End Property

    Public ReadOnly Property IsFolder As Boolean
        Get
            Return Me._isFolder
        End Get
    End Property

    Public ReadOnly Property FileExists As Boolean
        Get
            Return My.Computer.FileSystem.FileExists(_FileURL)
        End Get
    End Property

    Public ReadOnly Property Changed As Boolean
        Get
            Return Not MD5.VerifyMd5Hashes(Me.MD5Checksum, Me.OldMD5Checksum) Or Not Me.OldLastModify.Equals(Me.LastModify)
        End Get
    End Property

    Public ReadOnly Property LastModify As DateTime
        Get
            If (Me.FileExists) Then
                Return My.Computer.FileSystem.GetFileInfo(FileURL).LastWriteTime
            End If
            Return Nothing
        End Get
    End Property

    Public Property OldLastModify As DateTime
        Get
            Return Me._oldLastModify
        End Get
        Set(ByVal value As DateTime)
            Me._oldLastModify = value
        End Set
    End Property

    Public ReadOnly Property MD5Checksum As String
        Get
            If (Me.FileExists) Then
                Return MD5.MD5FileHash(Me.FileURL)
            End If
            Return Nothing
        End Get
    End Property

    Public Property OldMD5Checksum As String
        Get
            Return Me._oldMD5Checksum
        End Get
        Set(ByVal value As String)
            Me._oldMD5Checksum = value
        End Set
    End Property


    Public Sub New(ByVal FileURL As String, ByVal IsFile As Boolean)
        Me._FileURL = FileURL
        Me._isFile = IsFile
        Me._isFolder = Not IsFile

        Me._oldMD5Checksum = ""
        Me._oldLastModify = Nothing
    End Sub

    Public Sub New(ByVal FileURL As String, ByVal IsFile As Boolean, ByVal OldMD5Checksum As String, ByVal OldLastModify As DateTime)
        Me._FileURL = FileURL
        Me._isFile = IsFile
        Me._isFolder = Not IsFile

        Me._oldMD5Checksum = OldMD5Checksum
        Me._oldLastModify = OldLastModify
    End Sub
End Class
