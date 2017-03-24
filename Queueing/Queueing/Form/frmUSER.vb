Public Class frmUSER
    Dim tbl As New queue
    Dim LOG As New LOGS

    Dim filldata As String = "tbl_log_serve"
    Dim mysql As String = String.Empty
    Dim val As String

    Dim trans_log As New transaction_log
    Dim stat As String

    Dim music As String = Application.StartupPath & "\music\Door_bell_sound_effect.wav"

    Private Sub frmUSER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsProcessRunning("Queueing.exe") Then
            Application.Exit()
        End If

        LoadTable()
        load_pending()

        Dim numberofmonitors As Integer = Screen.AllScreens.Length
        If numberofmonitors > 1 Then
            Display_extend_monitor(frmService)
        Else
            frmService.Show()
        End If

        Me.Focus()
    End Sub

    Public Function IsProcessRunning(ByVal name As String) As Boolean
        'here we're going to get a list of all running processes on
        'the computer
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                'process found so it's running so return true
                Return True
            End If
        Next
        'process not found, return false
        Return False
    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If cboTable.Text = "" Then Exit Sub

        If Not LOG.check_TABLE_IF_ALREADY_FILLIN(cboTable.Text) Then
            Exit Sub
        End If


        If Not LOG.check_TABLE_IF_PENDING(cboTable.Text) Then
            Exit Sub
        End If

        tbl.load_tables(cboTable.Text)

        With LOG
            .TABLEID = tbl.ID
            .TABLENAME = cboTable.Text

            If Not LOG.check_queues Then
                .STATUS = "PENDING"
                stat = "PENDING"
            Else
                .STATUS = "SERVING"
                stat = "SERVING"
            End If
            .SAVE_LOG()
        End With

        With trans_log
            .TABLE_ID_T = tbl.ID
            .REMARKS = stat
            .log_ID = .GetLOG_ID
            .SAVE_TRANSACTION_lOG()
        End With

        frmService.lOAD_QUEUES()
        load_pending()

        Dim numberofmonitors As Integer = Screen.AllScreens.Length
        If numberofmonitors > 1 Then
            Display_extend_monitor(frmService)
        Else
            frmService.Show()
        End If
        Me.Focus()
    End Sub


    Private Sub load_pending()
        mysql = "SELECT * FROM " & filldata & " WHERE DATE_ADDED = '" & Now.ToShortDateString & "' ORDER BY LOGID ASC"
        Dim ds As DataSet = LoadSQL(mysql, filldata)


        If ds.Tables(0).Rows.Count > 0 Then
            lv_Tables.Items.Clear()
            For Each dr As DataRow In ds.Tables(0).Rows
                With dr
                    If .Item("STATUS") = "SERVING" Then
                        Label2.Text = .Item("TABLE_NAME")
                        On Error Resume Next
                    ElseIf .Item("STATUS") = "SERVED" Then
                        On Error Resume Next
                    ElseIf .Item("STATUS") = "CANCEL" Then
                        On Error Resume Next
                    Else
                        Dim lv As ListViewItem = lv_Tables.Items.Add(.Item("TABLEID"))
                        lv.SubItems.Add(.Item("TABLE_NAME"))
                        lv.SubItems.Add(.Item("STATUS"))
                        lv.SubItems.Add(.Item("LOGID"))
                    End If
                End With
            Next
        End If
    End Sub


    Friend Sub LoadTable()
        Dim mySql As String = "SELECT * FROM TBL_TABLEQUEUE ORDER BY ID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        cboTable.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            cboTable.Items.Add(dr.Item("TABLENAME"))
        Next
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Not LOG.check_PENDING_TABLES Then
            Show_serving("TABLE #")
            Exit Sub
        End If

        My.Computer.Audio.Play(music)

        If lv_Tables.SelectedItems.Count > 0 Then
            With LOG
                .TABLEID = lv_Tables.FocusedItem.Text
                .STATUS = "SERVING"
                .UPDATE_LOG("PENDING")
            End With

            With trans_log
                .TABLE_ID_T = LOG.TABLEID
                .REMARKS = LOG.STATUS
                .log_ID = lv_Tables.SelectedItems(0).SubItems(3).Text
                .SAVE_TRANSACTION_lOG()
            End With

            '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""next line""""""""""''''''''''''''''''''''''''''''''''''''
            With LOG
                .TABLEID = .Get_last_SErving
                .STATUS = "SERVED"
                .UPDATE_LOG("SERVING")
            End With


            With trans_log
                .TABLE_ID_T = LOG.TABLEID
                .REMARKS = LOG.STATUS
                .log_ID = LOG.Get_last_served
                .SAVE_TRANSACTION_lOG()
            End With : GoTo NEXTLINETODO
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If lv_Tables.Items.Count = 0 Then
            Dim mysql As String = "SELECT * FROM TBL_LOG_SERVE WHERE DATE_ADDED = '" & Now.ToShortDateString & "' " & _
                                    "AND STATUS = 'SERVING'"
            Dim ds As DataSet = LoadSQL(mysql, filldata)

            For Each dr As DataRow In ds.Tables(0).Rows
                With dr
                   
                    With LOG
                        .TABLEID = dr.Item("TABLEID")
                        .STATUS = "SERVED"
                        .UPDATE_LOG("SERVING")
                    End With

                    With trans_log
                        .TABLE_ID_T = dr.Item("TABLEID")
                        .REMARKS = LOG.STATUS
                        .log_ID = dr.Item("LogID")
                        .SAVE_TRANSACTION_lOG()
                    End With

                    Display_extend_monitor(frmService)
                    Me.Focus()
                    Show_serving("TABLE #")

                    GoTo NEXTLINETODO
                End With
            Next
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For Each itm As ListViewItem In lv_Tables.Items
            If itm.SubItems(1).Text <> "" Then
                val = itm.SubItems(1).Text

                tbl.load_tables(val)
                With LOG
                    .TABLEID = tbl.ID
                    .STATUS = "SERVING"
                    .UPDATE_LOG("PENDING")
                End With

                With trans_log
                    .TABLE_ID_T = LOG.TABLEID
                    .REMARKS = LOG.STATUS
                    .log_ID = itm.SubItems(3).Text
                    .SAVE_TRANSACTION_lOG()
                End With

                '"""""""""""""""""""""""""""""""""""""""""""""""""""""""""""""next line""""""""""
                With LOG
                    .TABLEID = .Get_last_SErving
                    .STATUS = "SERVED"
                    .UPDATE_LOG("SERVING")
                End With


                With trans_log
                    .TABLE_ID_T = LOG.TABLEID
                    .REMARKS = LOG.STATUS
                    .log_ID = LOG.Get_last_served
                    .SAVE_TRANSACTION_lOG()
                End With
                Exit For
            End If
        Next

NEXTLINETODO:
        frmService.lOAD_QUEUES()
        load_pending()

        Dim numberofmonitors As Integer = Screen.AllScreens.Length
        If numberofmonitors > 1 Then
            Display_extend_monitor(frmService)
        Else
            frmService.Show()
        End If
        Me.Focus()
    End Sub

    Private Sub Show_serving(ByVal str As String)
        frmService.lblTableServe.Text = str
        Label2.Text = str
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
            Case Keys.F7
                cboTable.Focus()
            Case Keys.F9
                btnCancel.PerformClick()
            Case Keys.F12
                lv_Tables.Focus()
            Case Keys.Escape
                cboTable.Focus()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

  
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If lv_Tables.SelectedItems.Count = 0 Then Exit Sub
        With LOG
            .CANCEL(lv_Tables.SelectedItems(0).SubItems(3).Text)
        End With

        With trans_log
            .TABLE_ID_T = lv_Tables.FocusedItem.Text
            .REMARKS = "CANCEL"
            .log_ID = lv_Tables.SelectedItems(0).SubItems(3).Text
            .SAVE_TRANSACTION_lOG()
        End With

        lv_Tables.SelectedItems(0).Remove()
        frmService.lOAD_QUEUES()

        Dim numberofmonitors As Integer = Screen.AllScreens.Length
        If numberofmonitors > 1 Then
            Display_extend_monitor(frmService)
        Else
            frmService.Show()
        End If
        Me.Focus()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        frmAddTable.ShowDialog()
    End Sub

End Class