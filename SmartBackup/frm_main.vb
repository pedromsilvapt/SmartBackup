Public Class frm_main
    Dim LoadedDataFile As DataFile


    Private Sub frm_main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LoadedDataFile = New DataFile(String.Format("{0}\data.xml", Application.StartupPath))
        Me.LoadedDataFile.Read()

        Me.MainPage1.ApplicationStart(LoadedDataFile)
    End Sub
End Class
