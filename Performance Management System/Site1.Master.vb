Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.Web.Configuration


Public Class Site1
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("emp code") = "" Then

            Label1.Text = ""
            aeid.Visible = "false"
            beid.Visible = "false"
            ceid.Visible = "false"
            ' deid.Visible = "false"
            A1.Visible = "false"
            A2.Visible = "false"
            A3.Visible = "false"
            a4.Visible = "false"
            emphistry.Visible = "false"
            h1.Visible = False
            changpass.Visible = False
            Label1.Text = " " + Session("emp code") + "-" + Session("user name")
        Else
            Label1.Text = "Hello" + "&nbsp;&nbsp;" + Session("user name")
            Label1.Text = " " + "Welcome" + ", " + Session("emp code") + "-" + Session("user name")
            'If Session("User name") = "HR" Then
            If Session("access power") = "1" Then
                beid.Visible = "false"
                ' deid.Visible = "false"
                A1.Visible = "false"
                A2.Visible = "false"
                A3.Visible = "true"
                a4.Visible = "false"
                lnk.Attributes.Add("i class", "fa fa-sign-out")
                lnk.InnerText = "Logout"
                B1.Visible = False
                emphistry.Visible = "true"
                h1.Visible = True
                changpass.Visible = True
                'ElseIf Session("Designation") = "GM" Or Session("Designation") = "AVP" Then
            ElseIf Session("access power") = "2" Then
                aeid.Visible = "false"
                beid.Visible = "false"
                ceid.Visible = "false"
                ' deid.Visible = "false"
                A1.Visible = "false"
                A2.Visible = "true"
                A3.Visible = "false"
                a4.Visible = "false"
                lnk.Attributes.Add("i class", "fa fa-sign-out")
                lnk.InnerText = "Logout"
                B1.Visible = False
                emphistry.Visible = "false"
                h1.Visible = True
                changpass.Visible = True
            ElseIf Session("access power") = "4" Then
                aeid.Visible = "false"
                beid.Visible = "false"
                ceid.Visible = "false"
                ' deid.Visible = "false"
                A1.Visible = "false"
                A2.Visible = "true"
                A3.Visible = "false"
                a4.Visible = "false"
                lnk.Attributes.Add("i class", "fa fa-sign-out")
                lnk.InnerText = "Logout"
                B1.Visible = False
                emphistry.Visible = "false"
                h1.Visible = True
                changpass.Visible = True
            Else

                aeid.Visible = "false"
                ceid.Visible = "false"
                A1.Visible = "false"
                A2.Visible = "false"
                A3.Visible = "false"
                a4.Visible = "false"
                B1.Visible = False
                emphistry.Visible = "false"
                h1.Visible = False
                changpass.Visible = True
            End If
            Label2.Text = Session("emp code")
            lnk.Attributes.Add("i class", "fa fa-sign-out")
            lnk.InnerText = "Logout"
        End If
        If Session("emp code") <> "" Then
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            If Not Me.IsPostBack Then
                Session("Reset") = True
                Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration("~/Web.Config")
                Dim section As SessionStateSection = DirectCast(config.GetSection("system.web/sessionState"), SessionStateSection)
                Dim timeout As Integer = CInt(section.Timeout.TotalMinutes) * 1000 * 60
                Page.ClientScript.RegisterStartupScript(Me.GetType(), "SessionAlert", "SessionExpireAlert(" & timeout & ");", True)

            End If

        End If


    End Sub
    Protected Sub lnk_serverclick(sender As Object, e As EventArgs)

        Session.Abandon()
        Session.Clear()
        Session.RemoveAll()
        Session.Remove("emp code")
        Session.Remove("User name")
        Session.Remove("designation")
        Session.Remove("department")
        Session.Remove("section")
        Session.Remove("access power")
        Response.Redirect("login.aspx")
    End Sub
    'Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
    '    Session.Abandon()
    '    Session.Clear()
    '    Session.RemoveAll()
    '    Session.Remove("emp code")
    '    Session.Remove("User name")
    '    Session.Remove("designation")
    '    Session.Remove("department")
    '    Session.Remove("access power")
    '    Response.Redirect("login.aspx")
    'End Sub


End Class