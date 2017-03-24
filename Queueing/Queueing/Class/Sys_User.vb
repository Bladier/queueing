Public Class sys_user
    Dim filldata As String = "tbl_user"
    Dim mysql As String = String.Empty

#Region "Property and variables"
    Private _USERID As Integer
    Public Property USERID() As Integer
        Get
            Return _USERID
        End Get
        Set(ByVal value As Integer)
            _USERID = value
        End Set
    End Property

    Private _USERNAME As String
    Public Property USERNAME() As String
        Get
            Return _USERNAME
        End Get
        Set(ByVal value As String)
            _USERNAME = value
        End Set
    End Property

    Private _NAME As String
    Public Property NAME() As String
        Get
            Return _NAME
        End Get
        Set(ByVal value As String)
            _NAME = value
        End Set
    End Property

    Private _PASSWRD As String
    Public Property PASSWRD() As String
        Get
            Return _PASSWRD
        End Get
        Set(ByVal value As String)
            _PASSWRD = value
        End Set
    End Property

    Private _LastLogin As Date
    Public Property LastLogin() As Date
        Get
            Return _LastLogin
        End Get
        Set(ByVal value As Date)
            _LastLogin = value
        End Set
    End Property

    Private _SYSTEMINFO As Date
    Public Property SYSTEMINFO() As Date
        Get
            Return _SYSTEMINFO
        End Get
        Set(ByVal value As Date)
            _SYSTEMINFO = value
        End Set
    End Property

    Private _STATUS As Integer
    Public Property STATUS() As Integer
        Get
            Return _STATUS
        End Get
        Set(ByVal value As Integer)
            _STATUS = value
        End Set
    End Property

    Private _USERTYPE As String
    Public Property USERTYPE() As String
        Get
            Return _USERTYPE
        End Get
        Set(ByVal value As String)
            _USERTYPE = value
        End Set
    End Property


#End Region

#Region "fUNCTIONS AND PROCEDURES"
    Friend Sub load_USERS(ByVal idx As Integer)
        mysql = String.Format("SELECT * FROM " & filldata & "WHERE ID = {0}", idx)
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("Unable to load user.", MsgBoxStyle.Critical, "Error")

        lOAD_BY_ROWS(ds.Tables(0).Rows(0))
    End Sub

    Private Sub lOAD_BY_ROWS(ByVal DR As DataRow)
        With DR
            _USERID = .Item("ID")
            _USERNAME = .Item("USERNAME")
            _NAME = .Item("NAME")
            _PASSWRD = .Item("PASSWRD")
            _LastLogin = .Item("LASTLOGIN")
            _SYSTEMINFO = .Item("SYSTEMINFO")
            _STATUS = .Item("STATUS")
            _USERTYPE = .Item("USERTYPE")
        End With
    End Sub

    Friend Function UserLogin(ByVal uName As String, ByVal pWrd As String) As Boolean
        mysql = "SELECT ID,USERNAME,PASSWRD FROM " & filldata & " " & _
                String.Format("WHERE UPPER(USERNAME) =UPPER('{0}') AND PASSWRD = '{1}'", uName, EncryptString(pWrd))
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        If ds.Tables(0).Rows.Count = 0 Then Return False

        load_USERS(ds.Tables(0).Rows(0).Item("ID"))
        Return True
    End Function


    Friend Sub uSAVE()
        mysql = "SELECT * FROM " & filldata
        Dim ds As DataSet = LoadSQL(mysql, filldata)

        Dim dsnewrow As DataRow
        dsnewrow = ds.Tables(0).NewRow

        With dsnewrow
            .Item("USERNAME") = _USERNAME
            .Item("NAME") = _NAME
            .Item("PASSWRD") = _PASSWRD
            .Item("LASTLOGIN") = Now
            .Item("SYSTEMINFO") = Now
            .Item("STATUS") = 1
            .Item("USERTYPE") = _USERTYPE
        End With
        ds.Tables(0).Rows.Add(dsnewrow)
        database.SaveEntry(ds)
    End Sub
#End Region


End Class
