Public Class frm_main
    Dim LoadedDataFile As DataFile

    Private Sub frm_main_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.LoadedDataFile.Save()
    End Sub

    Private Sub frm_main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LoadedDataFile = New DataFile(String.Format("{0}\data.xml", Application.StartupPath))
        Me.LoadedDataFile.Read()

        Me.pg_main.ApplicationStart(LoadedDataFile)
    End Sub
End Class
