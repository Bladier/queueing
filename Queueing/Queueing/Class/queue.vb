Public Class queue
    Dim filldata As String = "tbl_tablequeue"
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

    Private _TABLENAME As String
    Public Property _ABLENAME() As String
        Get
            Return _TABLENAME
        End Get
        Set(ByVal value As String)
            _TABLENAME = value
        End Set
    End Property
#End Region

#Region "fUNCTIONS AND PROCEDURES"
    Friend Sub load_tables()
        mysql = "SELECT * FROM TBL"
    End Sub
#End Region
End Class
