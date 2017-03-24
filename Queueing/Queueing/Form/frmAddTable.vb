Public Class frmAddTable
    Dim addTable As New queue

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtTableName.Text = "" Then Exit Sub

        Dim result As DialogResult = MsgBox("Do you want to save this table?", MsgBoxStyle.YesNo, "Save")
        If result = vbNo Then Exit Sub

        With addTable
            .TABLENAME = txtTableName.Text.ToUpper
        End With

        If Not addTable.save_table(txtTableName.Text) Then Exit Sub

        txtTableName.Text = ""
        frmUSER.LoadTable()
        load_table()
        MsgBox("Succesfully saved.", MsgBoxStyle.Information, "Save")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmAddTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_table()
        DISABLED(False)
    End Sub

    Private Sub load_table()
        Dim mysql As String = "SELECT * FROM TBL_TABLEQUEUE"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_TABLEQUEUE")

        If ds.Tables(0).Rows.Count = 0 Then lvlist_table.Items.Clear() : Exit Sub

        lvlist_table.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvlist_table.Items.Add(dr.Item("ID"))
            lv.SubItems.Add(dr.Item("TABLENAME"))
        Next
    End Sub

    Private Sub lvlist_table_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvlist_table.DoubleClick
        txtTableName.Text = lvlist_table.SelectedItems(0).SubItems(1).Text
        DISABLED(True)
        btnSave.Enabled = False
    End Sub

    Private Sub DISABLED(ByVal ST As Boolean)
        btnEdit.Enabled = ST
        btnDelete.Enabled = ST
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtTableName.Text = "" Then Exit Sub

        Dim result As DialogResult = MsgBox("Do you want to update this table?", MsgBoxStyle.YesNo, "Update")
        If result = vbNo Then Exit Sub

        With addTable
            .ID = lvlist_table.FocusedItem.Text
            .TABLENAME = txtTableName.Text.ToUpper
        End With

        If Not addTable.update_table() Then Exit Sub

        txtTableName.Text = ""
        frmUSER.LoadTable()
        load_table()
        MsgBox("Succesfully updated.", MsgBoxStyle.Information, "Update")
        btnSave.Enabled = True
        DISABLED(False)
        txtTableName.Text = ""
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If lvlist_table.SelectedItems.Count = 0 Then Exit Sub

        addTable.ID = lvlist_table.FocusedItem.Text

        addTable.delete_table()

        MsgBox("Successfully deleted.", MsgBoxStyle.Information, "Delete")
        btnSave.Enabled = True
        DISABLED(False)
        frmUSER.LoadTable()
        load_table()
        txtTableName.Text = ""
    End Sub

    Private Sub txtTableName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTableName.KeyPress
        If isEnter(e) Then btnSave.PerformClick()
    End Sub
End Class