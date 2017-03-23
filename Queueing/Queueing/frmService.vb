Public Class frmService
    Dim filldata As String = "tbl_log_serve"
    Dim mysql As String = String.Empty

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = Now
    End Sub


    Friend Sub lOAD_QUEUES()
        mysql = "SELECT * FROM " & filldata & " WHERE DATE_ADDED = '" & Now.ToShortDateString & "' ORDER BY LOGID ASC"

        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        lvListnextToserve.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                If .Item("STATUS") = "SERVING" Then
                    lblTableServe.Text = .Item("TABLE_NAME")
                    On Error Resume Next
                ElseIf .Item("STATUS") = "SERVED" Then
                    On Error Resume Next
                Else
                    lvListnextToserve.Items.Add(.Item("TABLE_NAME"))
                End If
            End With
        Next


    End Sub

    Private Sub frmService_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lOAD_QUEUES()
    End Sub
End Class
