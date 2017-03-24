Public Class frmLoading

    Private Sub frmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Timer1.Start()



        Dim fileName$ = System.Reflection.Assembly.GetExecutingAssembly().Location

        Dim fvi As FileVersionInfo = FileVersionInfo.GetVersionInfo(fileName)
        ' now this fvi has all the properties for the FileVersion information.
        Dim fvAsString$ = fvi.FileVersion ' but other useful properties exist too.
        Label3.Text = "Version: " & fvAsString$
        Label2.Text = My.Application.Info.Copyright
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        ProgressBar1.Value = ProgressBar1.Value + 1
        Label4.Text = ProgressBar1.Value & " % "
        If ProgressBar1.Value >= 100 Then
            Timer1.Enabled = False : Me.Hide()
            frmLogin.Show()
        End If
    End Sub
End Class