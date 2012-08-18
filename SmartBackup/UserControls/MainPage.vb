Public Class MainPage
    Private WithEvents FiltersMng As New FilterManager
    Private _Data As DataFile

    Public Sub ApplicationStart(ByRef DataFile As DataFile)
        Me._Data = DataFile

        AddHandler FiltersMng.FilterChanged, AddressOf Me.FilterChanged

        RefreshFiltersBar()
        RefreshBackupSets()
    End Sub

    Public Function CreateNewFilterButton(ByVal Filter As IFilter, ByVal btn_name As String, ByVal Checked As Boolean)
        Dim newBTN As New ComponentFactory.Krypton.Toolkit.KryptonCheckButton
        newBTN.Name = btn_name
        newBTN.Tag = Filter.Name
        newBTN.AutoSize = True
        newBTN.Text = Filter.Label("pt-PT")
        newBTN.Size = newBTN.PreferredSize
        newBTN.Height = 47
        newBTN.AutoSize = False
        newBTN.Checked = Checked

        AddHandler newBTN.CheckedChanged, AddressOf Me.FilterButtonChanged

        Return newBTN
    End Function

    Public Sub RefreshFiltersBar()
        Dim newFilter As IFilter = New FoldersFilter
        FiltersMng.RegisterFilter(newFilter)
        kbtnl_filters.AddCheckButton("kcbtn_show_folders", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler kbtnl_filters.CheckButton("kcbtn_show_folders").CheckedChanged, AddressOf Me.FilterButtonChanged

        newFilter = New FilesFilter
        FiltersMng.RegisterFilter(newFilter)
        kbtnl_filters.AddCheckButton("kcbtn_show_files", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler kbtnl_filters.CheckButton("kcbtn_show_files").CheckedChanged, AddressOf Me.FilterButtonChanged

        newFilter = New UnchangedFileFilter
        FiltersMng.RegisterFilter(newFilter)
        kbtnl_filters.AddCheckButton("kcbtn_show_unchanged", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler kbtnl_filters.CheckButton("kcbtn_show_unchanged").CheckedChanged, AddressOf Me.FilterButtonChanged

        newFilter = New ChangedFileFilter
        FiltersMng.RegisterFilter(newFilter)
        kbtnl_filters.AddCheckButton("kcbtn_show_changed", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler kbtnl_filters.CheckButton("kcbtn_show_changed").CheckedChanged, AddressOf Me.FilterButtonChanged

        newFilter = New MissingFileFilter
        FiltersMng.RegisterFilter(newFilter)
        kbtnl_filters.AddCheckButton("kcbtn_show_missing", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler kbtnl_filters.CheckButton("kcbtn_show_missing").CheckedChanged, AddressOf Me.FilterButtonChanged
    End Sub

    Public Sub AddBackUpSetButton(ByVal btnID As Integer, ByVal btnName As String, ByVal text As String, ByVal CheckSetName As String)
        kbtnl_backupsets.AddCheckButton(btnName, text, CheckSetName:=CheckSetName)
        kbtnl_backupsets.Button(btnName).Tag = btnID
        kbtnl_backupsets.CheckButton(btnName).KryptonContextMenu = kctm_backupsets_actions
    End Sub

    Public Sub ChangeSetName(ByVal BackupSetID As Integer, ByVal NewName As String)
        If (Me._Data.BackupSetExists(BackupSetID)) Then
            If (Me.kbtnl_backupsets.ButtonExists(String.Format("btn_backupset_{0}", BackupSetID))) Then
                Me.kbtnl_backupsets.Button(String.Format("btn_backupset_{0}", BackupSetID)).Text = NewName
            Else
                Me.AddBackUpSetButton(Me._Data.BackupSet(BackupSetID).ID, String.Format("btn_backupset_{0}", Me._Data.BackupSet(BackupSetID).ID), Me._Data.BackupSet(BackupSetID).Name, "kcks_backupsets")
            End If
        End If
    End Sub

    Public Sub RemoveSet(ByVal BackupSetID As Integer)
        If (Me.kbtnl_backupsets.ButtonExists(String.Format("btn_backupset_{0}", BackupSetID))) Then
            Me.kbtnl_backupsets.RemoveButton(String.Format("btn_backupset_{0}", BackupSetID))
        End If
    End Sub

    Public Sub RefreshBackupSets()
        kbtnl_backupsets.AddCheckSet("kcks_backupsets")

        For Each _BS As String In Me._Data.BackupSetsList
            Me.AddBackUpSetButton(Me._Data.BackupSet(_BS).ID, String.Format("btn_backupset_{0}", Me._Data.BackupSet(_BS).ID), Me._Data.BackupSet(_BS).Name, "kcks_backupsets")
        Next
    End Sub

    Public Sub RefreshFiles(ByRef FilesList As List(Of FileRecord))

    End Sub

    Public Sub DisableNavigation()

    End Sub

    Public Sub EnableNavigation()

    End Sub

    Public Sub EditBackupSet(ByVal BackupSetID As Integer)
        If (Me._Data.BackupSetExists(BackupSetID)) Then
            Dim newPNL As EditBackupSet = New EditBackupSet(BackupSetID, Me._Data)

            AddCenterPanel(newPNL, True)
            AddHandler newPNL.PanelClosed, AddressOf ClosePanel
            AddHandler newPNL.BackupSetRemoved, AddressOf BackupSetRemove_Click
            AddHandler newPNL.BackupSetSaved, AddressOf BackupSetSave_Click
        End If
    End Sub

    Public Sub AddCenterPanel(ByVal NewPanel As UserControl, Optional ByVal DisableNavigation As Boolean = True)
        If (DisableNavigation) Then
            Me.DisableNavigation()
        End If

        For Each _Control As Control In Me.kpnl_mainarea.Controls
            _Control.Visible = False
        Next

        NewPanel.Dock = DockStyle.Fill
        NewPanel.Visible = True
        Me.kpnl_mainarea.Controls.Add(NewPanel)
    End Sub

    Public Sub ClosePanel(ByVal panel As UserControl, ByVal source As String)
        If (Me.kpnl_mainarea.Controls.ContainsKey(panel.Name)) Then
            Me.kpnl_mainarea.Controls.Remove(panel)
            Me.kpnl_mainarea.Controls("kpnl_fileslist").Visible = True
        End If
    End Sub

    Public Sub BackupSetRemove_Click(ByVal sender As UserControl, ByVal ID As String)
        Me.RemoveSet(ID)

        Me.ClosePanel(sender, "remove")
    End Sub

    Public Sub BackupSetSave_Click(ByVal sender As UserControl, ByVal ID As Integer)
        Me.ChangeSetName(ID, CType(sender, EditBackupSet).BackupSetName)

        Me.ClosePanel(sender, "save")
    End Sub

    Public Sub FilterButtonChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        FiltersMng.ToogleFilter(sender.Tag, sender.Checked)
    End Sub

    Public Sub FilterChanged(ByVal sender As Object, ByVal filter As IFilter)
        'RefreshFiles()
    End Sub

    Private Sub kctmi_editbackupset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kctmi_editbackupset.Click
        EditBackupSet(Me.kctm_backupsets_actions.Caller.Tag)
    End Sub

    Private Sub kctmi_removebackupset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles kctmi_removebackupset.Click
        Dim id As Integer = CType(Me.kctm_backupsets_actions.Caller, ComponentFactory.Krypton.Toolkit.KryptonButton).Tag
        If (Me._Data.BackupSetExists(id)) Then
            If (MessageBox.Show(String.Format("Tem a certeza que pretende remover o grupo '{0}'?", Me._Data.BackupSet(id).Name), "Remoção do Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
                Me._Data.RemoveBackupSet(id)

                Me.RemoveSet(id)
            End If
        End If
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub kbtn_backupsets_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kbtn_backupsets_add.Click
        Dim str As String = "Grupo "
        Dim number As Integer = 1
        Dim id As Integer = 1

        While (Me._Data.BackupSetExists(String.Format("{0}{1}", str, number)))
            number += 1
        End While

        While (Me._Data.BackupSetExists(id))
            id += 1
        End While

        Me._Data.AddBackupSet(id, String.Format("{0}{1}", str, number))
        Me.AddBackUpSetButton(id, String.Format("btn_backupset_{0}", id), String.Format("{0}{1}", str, number), "kcks_backupsets")

        Me.EditBackupSet(id)
    End Sub
End Class
