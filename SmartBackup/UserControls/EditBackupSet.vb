Public Class EditBackupSet

    Private _ID As Integer
    Private _dataSource As DataFile

    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            Me._ID = value
        End Set
    End Property

    Public Property BackupSetName As String
        Get
            Return Me.ktxt_backgupset_name.Text
        End Get
        Set(ByVal value As String)
            Me.ktxt_backgupset_name.Text = value
        End Set
    End Property

    Public Event PanelClosed(ByVal sender As Object, ByVal source As String)
    Public Event BackupSetSaved(ByVal sender As Object, ByVal BakupSetID As Integer)
    Public Event BackupSetRemoved(ByVal sender As Object, ByVal BakupSetID As Integer)


    Private Sub kbtn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_save.Click
        If (Not Me.BackupSetName.Equals("")) Then
            Me._dataSource.BackupSet(Me.ID).Name = Me.BackupSetName

            RaiseEvent BackupSetSaved(Me, Me.ID)
        End If
    End Sub

    Private Sub kbtn_remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_remove.Click
        If (MessageBox.Show(String.Format("Tem a certeza que pretende remover o grupo '{0}'?", Me._dataSource.BackupSet(Me.ID).Name), "Remoção do Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
            Me._dataSource.RemoveBackupSet(Me.ID)

            RaiseEvent BackupSetRemoved(Me, Me.ID)
        End If
    End Sub

    Private Sub ktxt_backgupset_name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ktxt_backgupset_name.TextChanged
        Me.kbtn_save.Enabled = Not Me.ktxt_backgupset_name.Text.Equals("")
    End Sub

    Private Sub kbtn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_cancel.Click
        RaiseEvent PanelClosed(Me, "cancel")
    End Sub

    Public Sub New(ByVal backupSetID As Integer, ByRef dataSource As DataFile)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.ID = backupSetID
        Me.BackupSetName = dataSource.BackupSet(Me.ID).Name
        Me._dataSource = dataSource
    End Sub
End Class
