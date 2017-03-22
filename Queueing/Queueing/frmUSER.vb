﻿Public Class frmUSER
    Dim tbl As New queue
    Dim LOG As New LOGS

    Dim filldata As String = "tbl_log_serve"
    Dim mysql As String = String.Empty
    Dim val As String

    Private Sub frmUSER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmService.Show()
        LoadTable()

        load_pending()
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If cboTable.Text = "" Then Exit Sub

        If Not LOG.check_TABLE_IF_ALREADY_FILLIN(cboTable.Text) Then
            MsgBox("This table is already fill in.", MsgBoxStyle.Critical, "InValid") : Exit Sub
        End If

        tbl.load_tables(cboTable.Text)

        With LOG
            .TABLEID = tbl.ID
            .TABLENAME = cboTable.Text

            If Not LOG.check_queues Then
                .STATUS = "PENDING"
            Else
                .STATUS = "SERVING"
            End If
            .SAVE_LOG()
        End With

        frmService.lOAD_QUEUES()
      
    End Sub


    Private Sub load_pending()
        mysql = "SELECT * FROM " & filldata & " WHERE TIME_ADDED = '" & Now.ToShortDateString & "' ORDER BY LOGID ASC"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr As DataRow In ds.Tables(0).Rows
                With dr
                    If .Item("STATUS") = "SERVING" Then
                        On Error Resume Next
                    ElseIf .Item("STATUS") = "SERVED" Then
                        On Error Resume Next
                    Else
                        Dim lv As ListViewItem = lv_Tables.Items.Add(.Item("LOGID"))
                        lv.SubItems.Add(.Item("TABLE_NAME"))
                    End If
                End With
            Next
        End If

    End Sub


    Private Sub LoadTable()
        Dim mySql As String = "SELECT * FROM TBL_TABLEQUEUE ORDER BY ID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            cboTable.Items.Add(dr.Item("TABLENAME"))
        Next
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Not LOG.check_PENDING_TABLES Then
            Exit Sub
        End If

        For Each itm As ListViewItem In lv_Tables.Items
            If itm.SubItems(1).Text <> "" Then
                val = itm.SubItems(1).Text

                With LOG
                    .TABLEID = .Get_last_SErving
                    .STATUS = "SERVED"
                    .UPDATE_LOG("SERVING")
                End With


                tbl.load_tables(val)
                With LOG
                    .TABLEID = tbl.ID
                    .STATUS = "SERVING"
                    .UPDATE_LOG("SERVING")
                End With
                Exit For
            End If
        Next
    End Sub


    Private Sub cboTable_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboTable.KeyPress
        If isEnter(e) Then btnAdd.PerformClick()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.Enter
                btnAdd.PerformClick()
            Case Keys.F5
                btnNext.PerformClick()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class