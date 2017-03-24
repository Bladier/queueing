Public Class frmLogin
    Dim i As Integer

    Dim sUSER As New sys_user

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If Not isValid() Then Exit Sub

        Dim Uname As String = txtUsername.Text
        Dim Pwrd As String = txtPassword.Text

        If Not sUSER.UserLogin(Uname, Pwrd) Then
            i += 1
            If i > 3 Then
                MsgBox("You Reached the MAXIMUM logins this is a recording!", MsgBoxStyle.Critical, "Error")
                End
            End If

            MsgBox("Invalid username or password" & vbCrLf & "Please try again.", MsgBoxStyle.Exclamation, "Warning") : Exit Sub
        End If

        USERID = sUSER.USERID
        MsgBox("Welcome " & UppercaseFirstLetter(sUSER.USERNAME) & "you login as " _
               & UppercaseFirstLetter(sUSER.USERTYPE), MsgBoxStyle.Information, "Welcome")

        frmUSER.Show()
    End Sub

    Private Sub CLear()
        txtPassword.Text = ""
        txtUsername.Text = ""
    End Sub

    Private Function isValid() As Boolean
        If txtUsername.Text = "" Then txtUsername.Focus() : Return False
        If txtPassword.Text = "" Then txtPassword.Focus() : Return False
        Return True
    End Function

    Private Sub txtUsername_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        If isEnter(e) Then txtPassword.Focus()
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If isEnter(e) Then btnLogin.PerformClick()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub
End Class