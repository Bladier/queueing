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
    Public Property TABLENAME() As String
        Get
            Return _TABLENAME
        End Get
        Set(ByVal value As String)
            _TABLENAME = value
        End Set
    End Property
#End Region

#Region "fUNCTIONS AND PROCEDURES"

    Friend Sub load_tables(ByVal table As String)
        mysql = "SELECT * FROM " & filldata & " WHERE TABLENAME = '" & table & "'"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        load_byrow(ds.Tables(0).Rows(0))
    End Sub

    Friend Sub load_byrow(ByVal dr As DataRow)
        With dr
            _ID = .Item("ID")
            _TABLENAME = .Item("TABLENAME")
        End With
    End Sub

    Friend Function save_table(ByVal STR As String) As Boolean
        mysql = "SELECT * FROM " & filldata & " WHERE UPPER(TABLENAME) =UPPER('" & STR & "')"
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count > 0 Then MsgBox("This table already exists.", MsgBoxStyle.Critical, "Error") : Return False

        Dim dsnewrow As DataRow
        dsnewrow = ds.Tables(0).NewRow
        With dsnewrow
            .Item("TABLENAME") = _TABLENAME
        End With
        ds.Tables(0).Rows.Add(dsnewrow)
        database.SaveEntry(ds)
        Return True
    End Function
#End Region
End Class
