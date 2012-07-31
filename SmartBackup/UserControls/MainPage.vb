Public Class MainPage
    Private WithEvents FiltersMng As New FilterManager

    Public Sub ApplicationStart()
        AddHandler FiltersMng.FilterChanged, AddressOf Me.FilterChanged

        RefreshFiltersBar()
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

        KryptonButtonsList2.AddCheckSet("kcks_backupsets")
        KryptonButtonsList2.AddCheckButton("btn_backupset_1", "BackUp Pen", Checked:=True, CheckSetName:="kcks_backupsets")
        KryptonButtonsList2.AddCheckButton("btn_backupset_2", "BackUp Escola", CheckSetName:="kcks_backupsets")
        KryptonButtonsList2.AddCheckButton("btn_backupset_3", "BackUp Trabalho", CheckSetName:="kcks_backupsets")
        KryptonButtonsList2.AddCheckButton("btn_backupset_4", "BackUp Pessoal", CheckSetName:="kcks_backupsets")
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
        Me.ApplicationStart()
    End Sub
End Class
