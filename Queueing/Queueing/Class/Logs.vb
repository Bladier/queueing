Public Class LOGS
    Dim filldata As String = "tbl_log_serve"
    Dim mysql As String = String.Empty

#Region "Property and variables"
    Private _LOGID As Integer
    Public Property LOGID() As Integer
        Get
            Return _LOGID
        End Get
        Set(ByVal value As Integer)
            _LOGID = value
        End Set
    End Property

    Private _TIMESERVE As Date
    Public Property TIMESERVE() As Date
        Get
            Return _TIMESERVE
        End Get
        Set(ByVal value As Date)
            _TIMESERVE = value
        End Set
    End Property

    Private _TIMEADDED As Date
    Public Property TIMEADDED() As Date
        Get
            Return _TIMEADDED
        End Get
        Set(ByVal value As Date)
            _TIMEADDED = value
        End Set
    End Property

    Private _TABLEID As Integer
    Public Property TABLEID() As Integer
        Get
            Return _TABLEID
        End Get
        Set(ByVal value As Integer)
            _TABLEID = value
        End Set
    End Property

    Private _TABLENAME As String
    Public Property TABLENAME() As String
        Get
            Return _TABLENAME
        End Get
        Set(ByVal value As String)
            _TABLENAME = value
        End Set
    End Property

    Private _USERID As Integer
    Public Property USERID() As Integer
        Get
            Return _USERID
        End Get
        Set(ByVal value As Integer)
            _USERID = value
        End Set
    End Property

    Private _STATUS As String
    Public Property STATUS() As String
        Get
            Return _STATUS
        End Get
        Set(ByVal value As String)
            _STATUS = value
        End Set
    End Property
#End Region

#Region "fUNCTIONS AND PROCEDURES"
    Friend Sub SAVE_LOG()
        mysql = "SELECT * FROM " & filldata
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        Dim dsnewrow As DataRow
        dsnewrow = ds.Tables(0).NewRow
        With dsnewrow
            .Item("TIME_SERVED") = Now
            .Item("TABLEID") = _TABLEID
            .Item("USERID") = 1
            .Item("TABLE_NAME") = _TABLENAME
            .Item("STATUS") = _STATUS
            .Item("DATE_ADDED") = Now
        End With
        ds.Tables(0).Rows.Add(dsnewrow)
        database.SaveEntry(ds)
    End Sub

    Friend Sub UPDATE_LOG(ByVal st As String)
        mysql = "SELECT * FROM " & filldata & " WHERE TABLEID = " & _TABLEID & " AND STATUS = '" & st & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        With ds.Tables(0).Rows(0)
            .Item("TIME_SERVED") = Now
            .Item("USERID") = 1
            .Item("STATUS") = _STATUS
        End With
        database.SaveEntry(ds, False)
    End Sub
#End Region

    Friend Function check_queues() As Boolean
        mysql = "SELECT * FROM " & filldata & " WHERE DATE_ADDED = '" & Now.ToShortDateString & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count > 0 Then
            mysql = "SELECT * FROM " & filldata & " WHERE STATUS = 'PENDING' OR STATUS = 'SERVING'"
            Dim ds1 As DataSet = LoadSQL(mysql, filldata)

            If ds1.Tables(0).Rows.Count >= 1 Then
                Return False
            End If
        End If
        Return True
    End Function


    Friend Function check_TABLE_IF_ALREADY_FILLIN(ByVal STR As String) As Boolean
        mysql = "SELECT * FROM " & filldata & " WHERE TABLE_NAME = '" & STR & "' " & _
                "AND STATUS = 'SERVING'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    Friend Function check_TABLE_IF_PENDING(ByVal STR As String) As Boolean
        mysql = "SELECT * FROM " & filldata & " WHERE TABLE_NAME = '" & STR & "' " & _
                "AND STATUS = 'PENDING'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        End If
        Return True
    End Function

    Friend Function check_PENDING_TABLES() As Boolean
        mysql = "SELECT * FROM " & filldata & " WHERE DATE_ADDED = '" & Now.ToShortDateString & "'" & _
                "AND STATUS = 'PENDING' OR STATUS = 'SERVING'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function

    Friend Function Get_last_SErving() As String
        mysql = "SELECT * FROM " & filldata & " WHERE DATE_ADDED = '" & Now.ToShortDateString & "'" & _
                "AND STATUS = 'SERVING' ORDER BY TIME_SERVED ASC ROWS 1"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then
            Return Nothing
        End If
        Return ds.Tables(0).Rows(0).Item("TABLEID")
    End Function

    Friend Sub CANCEL(ByVal IDX As Integer)
        mysql = "SELECT * FROM " & filldata & " WHERE LOGID = " & IDX & ""
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        With ds.Tables(0).Rows(0)
            .Item("TIME_SERVED") = Now
            .Item("STATUS") = "CANCEL"
        End With
        database.SaveEntry(ds, False)
    End Sub

End Class
