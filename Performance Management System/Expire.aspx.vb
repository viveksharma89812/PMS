Public Class WebForm20
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Timeout Then
            Session.Remove("emp code")
        End If
        Label4.Text = "your session has been expire"
    End Sub

End Class