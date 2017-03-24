Public Class transaction_log
    Dim filldata As String = "tbl_transaction_Log"
    Dim mysql As String = String.Empty

#Region "Property and variables"
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _USERIDS As Integer
    Public Property USERIDS() As Integer
        Get
            Return _USERIDS
        End Get
        Set(ByVal value As Integer)
            _USERIDS = value
        End Set
    End Property


    Private _log_ID As Integer
    Public Property log_ID() As Integer
        Get
            Return _log_ID
        End Get
        Set(ByVal value As Integer)
            _log_ID = value
        End Set
    End Property


    Private _TABLE_ID_T As Integer
    Public Property TABLE_ID_T() As Integer
        Get
            Return _TABLE_ID_T
        End Get
        Set(ByVal value As Integer)
            _TABLE_ID_T = value
        End Set
    End Property

    Private _cREATE_AT As Date
    Public Property cREATE_AT() As Date
        Get
            Return _cREATE_AT
        End Get
        Set(ByVal value As Date)
            _cREATE_AT = value
        End Set
    End Property

    Private _REMARKS As String
    Public Property REMARKS() As String
        Get
            Return _REMARKS
        End Get
        Set(ByVal value As String)
            _REMARKS = value
        End Set
    End Property

#End Region

#Region "fUNCTIONS AND PROCEDURES"
    Friend Sub SAVE_TRANSACTION_lOG()
        mysql = "SELECT * FROM " & filldata
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        Dim dsnewrow As DataRow
        dsnewrow = ds.Tables(0).NewRow
        With dsnewrow
            .Item("USERID") = _USERIDS
            .Item("TABLEID") = _TABLE_ID_T
            .Item("CREATED_AT") = Now
            .Item("REMARKS") = _REMARKS
            .Item("LOG_ID") = _log_ID
        End With
        ds.Tables(0).Rows.Add(dsnewrow)
        database.SaveEntry(ds)
    End Sub

    Friend Function GetLOG_ID() As Integer
        Dim i As Integer
        mysql = "SELECT * FROM TBL_LOG_SERVE ORDER BY LOGID DESC ROWS 1"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then Return 0

        i = ds.Tables(0).Rows(0).Item("LOGID")
        Return i
    End Function
#End Region
End Class
