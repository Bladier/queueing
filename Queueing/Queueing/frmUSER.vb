Public Class frmUSER

    Private Sub frmUSER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmService.Show()
        LOAD_TABLES()
    End Sub

    Private Sub LOAD_TABLES()
        Dim msyql As String = "SELECT * FROM TBL_TABLEQUEUE"
        Dim ds As DataSet = LoadSQL(msyql, "TBL_TABLEQUEUE")

        For Each dr As DataRow In ds.Tables(0).Rows
            cboTable.Items.Add(dr.Item("TableName"))
        Next
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmService.lvListnextToserve.Items.Add(cboTable.Text)
    End Sub
End Class