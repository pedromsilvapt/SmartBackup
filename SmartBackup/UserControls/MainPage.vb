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
        KryptonButtonsList1.AddCheckButton("kcbtn_show_folders", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler KryptonButtonsList1.CheckButton("kcbtn_show_folders").CheckedChanged, AddressOf Me.FilterButtonChanged

        newFilter = New FilesFilter
        FiltersMng.RegisterFilter(newFilter)        
        KryptonButtonsList1.AddCheckButton("kcbtn_show_files", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler KryptonButtonsList1.CheckButton("kcbtn_show_files").CheckedChanged, AddressOf Me.FilterButtonChanged

        newFilter = New UnchangedFileFilter
        FiltersMng.RegisterFilter(newFilter)
        KryptonButtonsList1.AddCheckButton("kcbtn_show_unchanged", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler KryptonButtonsList1.CheckButton("kcbtn_show_unchanged").CheckedChanged, AddressOf Me.FilterButtonChanged

        newFilter = New ChangedFileFilter
        FiltersMng.RegisterFilter(newFilter)
        KryptonButtonsList1.AddCheckButton("kcbtn_show_changed", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler KryptonButtonsList1.CheckButton("kcbtn_show_changed").CheckedChanged, AddressOf Me.FilterButtonChanged

        newFilter = New MissingFileFilter
        FiltersMng.RegisterFilter(newFilter)
        KryptonButtonsList1.AddCheckButton("kcbtn_show_missing", newFilter.Label("pt-PT"), newFilter.Name)
        AddHandler KryptonButtonsList1.CheckButton("kcbtn_show_missing").CheckedChanged, AddressOf Me.FilterButtonChanged
    End Sub

    Public Sub RefreshBackupSets()
        KryptonButtonsList2.AddCheckSet("kcks_backupsets")

        For Each _BS As String In Me._Data.BackupSetsList
            KryptonButtonsList2.AddCheckButton(String.Format("btn_backupset_{0}", Me._Data.BackupSet(_BS).ID), Me._Data.BackupSet(_BS).Name, CheckSetName:="kcks_backupsets")
        Next
    End Sub

    Public Sub RefreshFiles(ByRef FilesList As List(Of FileRecord))

    End Sub

    Public Sub FilterButtonChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        FiltersMng.ToogleFilter(sender.Tag, sender.Checked)
    End Sub

    Public Sub FilterChanged(ByVal sender As Object, ByVal filter As IFilter)
        'RefreshFiles()
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class
