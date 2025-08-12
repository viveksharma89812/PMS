
Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Redirect to the login page
        Dim httpContext As HttpContext = HttpContext.Current
        If httpContext IsNot Nothing Then
            httpContext.Response.Redirect("~/login.aspx")
        End If
    End Sub

End Class

'Public Class Global_asax
'    Inherits HttpApplication

'    Sub Application_Start(sender As Object, e As EventArgs)
'        ' Fires when the application is started

'    End Sub


'End Class