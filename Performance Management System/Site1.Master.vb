Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Net
Imports System.Net.Sockets

Public Class Site1
    Inherits System.Web.UI.MasterPage
    Dim PMSclass As New PMSClass()
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
            A5.Visible = "True"
            a4.Visible = "false"
            summary.Visible = "False"
            emphistry.Visible = "false"
            h1.Visible = False
            changpass.Visible = False
            Plog.Visible = False
            Label1.Text = " " + Session("emp code") + "-" + Session("user name")
        Else
            A5.Visible = "false"
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
                Plog.Visible = True
                'ElseIf Session("Designation") = "GM" Or Session("Designation") = "AVP" Then
            ElseIf Session("access power") = "2" Then
                aeid.Visible = "false"
                beid.Visible = "false"
                summary.Visible = "False"
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
                Plog.Visible = False
            ElseIf Session("access power") = "4" Then
                aeid.Visible = "false"
                beid.Visible = "false"
                ceid.Visible = "false"
                ' deid.Visible = "false"
                A1.Visible = "false"
                summary.Visible = "False"
                A2.Visible = "true"
                A3.Visible = "false"
                a4.Visible = "false"
                lnk.Attributes.Add("i class", "fa fa-sign-out")
                lnk.InnerText = "Logout"
                B1.Visible = False
                emphistry.Visible = "false"
                h1.Visible = True
                changpass.Visible = True
                Plog.Visible = False
            ElseIf Session("access power") = "5" Then
                aeid.Visible = "false"
                beid.Visible = "false"
                ceid.Visible = "false"
                ' deid.Visible = "false"
                A1.Visible = "false"
                summary.Visible = "False"
                A2.Visible = "true"
                A3.Visible = "false"
                a4.Visible = "false"
                lnk.Attributes.Add("i class", "fa fa-sign-out")
                lnk.InnerText = "Logout"
                B1.Visible = False
                emphistry.Visible = "false"
                h1.Visible = True
                changpass.Visible = True
                Plog.Visible = False
            Else

                summary.Visible = "False"
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
                Plog.Visible = False
            End If
            Label2.Text = Session("emp code")
            lnk.Attributes.Add("i class", "fa fa-sign-out")
            lnk.InnerText = "Logout"
        End If
        'If Session("emp code") <> "" Then
        '    Response.Cache.SetCacheability(HttpCacheability.NoCache)
        '    If Not Me.IsPostBack Then
        '        Session("Reset") = True
        '        Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration("~/Web.Config")
        '        Dim section As SessionStateSection = DirectCast(config.GetSection("system.web/sessionState"), SessionStateSection)
        '        Dim timeout As Integer = CInt(section.Timeout.TotalMinutes) * 1000 * 60
        '        Page.ClientScript.RegisterStartupScript(Me.GetType(), "SessionAlert", "SessionExpireAlert(" & timeout & ");", True)

        '    End If

        'End If


    End Sub
    Protected Sub lnk_serverclick(sender As Object, e As EventArgs)
        ' call the function for save log for login in database... for HR side.
        Dim empid As String
        Dim empname As String
        empid = Session("emp code")
        empname = Session("user name")
        Dim pcName As String = Environment.MachineName
        Dim ipAddress As String = PMSclass.GetLocalIPAddress()
        Dim logDate As String = DateTime.Now
        Dim Status As String = "LogOut"
        Dim AccessPowerName As String = ""

        Select Case Session("access power")
            Case "1"
                AccessPowerName = "HR"
            Case "2"
                AccessPowerName = "Section Head"
            Case "3"
                AccessPowerName = "Employee"
            Case "4"
                AccessPowerName = "Department Head"
            Case Else
                AccessPowerName = "Unknown"


        End Select

        PMSclass.PMS_Log_Save(empid, empname, pcName, ipAddress, logDate, Status, AccessPowerName)


        Session.Abandon()
        Session.Clear()
        Session.RemoveAll()

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