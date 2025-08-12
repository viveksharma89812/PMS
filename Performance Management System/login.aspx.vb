Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System
Imports System.Text
Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Net.Sockets
Imports System.Xml

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim Position As String
    Dim PMSclass As New PMSClass()
    Public ReadOnly Property ViewBag As Object
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = ""
        If IsPostBack Then
            Dim password As String = pass.Text
            pass.Attributes.Add("value", password)
        End If

        Dim masterPageBody As HtmlControl = Master.FindControl("masterbody")
        masterPageBody.Style.Add("background-image", "/Bck_Img/New3.png")
        masterPageBody.Style.Add("background-size", "100%")


        Session("emp code") = ""
        If Page.IsPostBack Then
            Session.Clear()
            Session.RemoveAll()
            Session.Remove("emp code")
        End If
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles login.Click

        Dim dt As DataTable = PMSclass.Login(empcode.Text, pass.Text)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            Dim empid As String = dt.Rows(0)("EmployeeCode").ToString()
            Dim name As String = dt.Rows(0)("EmployeeName").ToString()
            Dim desc As String = dt.Rows(0)("Designation").ToString()
            Dim dept As String = dt.Rows(0)("Department").ToString()
            Dim sect As String = dt.Rows(0)("Section").ToString()
            Dim access As String = dt.Rows(0)("Access_Power").ToString()
            Session("emp code") = empid
            Session("user name") = name
            Session("designation") = desc
            Session("department") = dept
            Session("section") = sect
            Session("access power") = access

            Dim pcName As String = Environment.MachineName
                Dim ipAddress As String = PMSclass.GetLocalIPAddress()
                Dim logDate As String = DateTime.Now
                Dim Status As String = "LogIn"
                Dim AccessPowerName As String = String.Empty
                Dim empname As String = Session("user name")

                If Session("access power") = "4" Or Session("access power") = "2" Then

                    Dim Designation As String = dt.Rows(0)("Designation").ToString()
                    Dim output As String = "'" & String.Join("','", Designation.Split(",")) & "'"
                    Session("desg") = output
                End If
                ' Determine AccessPowerName based on session value
                Select Case Session("access power")
                    Case "1"
                        AccessPowerName = "HR"
                        If Not String.IsNullOrEmpty(AccessPowerName) Then
                            PMSclass.PMS_Log_Save(empid, empname, pcName, ipAddress, logDate, Status, AccessPowerName)
                        End If
                        Response.Redirect("Upload_Details.aspx")
                    Case "2"
                        AccessPowerName = "Section Head"
                        If Not String.IsNullOrEmpty(AccessPowerName) Then
                            PMSclass.PMS_Log_Save(empid, empname, pcName, ipAddress, logDate, Status, AccessPowerName)
                        End If
                        Response.Redirect("Employee_Details.aspx")
                    Case "4"
                        AccessPowerName = "Department Head"
                        If Not String.IsNullOrEmpty(AccessPowerName) Then
                            PMSclass.PMS_Log_Save(empid, empname, pcName, ipAddress, logDate, Status, AccessPowerName)
                        End If
                        Response.Redirect("Employee_Details.aspx")
                    Case "5"
                        AccessPowerName = "Plant Head"
                        If Not String.IsNullOrEmpty(AccessPowerName) Then
                            PMSclass.PMS_Log_Save(empid, empname, pcName, ipAddress, logDate, Status, AccessPowerName)
                        End If
                    Response.Redirect("Employee_Details.aspx")
                Case "6"
                    AccessPowerName = "HRM"
                    If Not String.IsNullOrEmpty(AccessPowerName) Then
                        PMSclass.PMS_Log_Save(empid, empname, pcName, ipAddress, logDate, Status, AccessPowerName)
                    End If
                    Response.Redirect("Variablepay.aspx")
                Case "3"
                        AccessPowerName = "Employee"
                        If Not String.IsNullOrEmpty(AccessPowerName) Then
                            PMSclass.PMS_Log_Save(empid, empname, pcName, ipAddress, logDate, Status, AccessPowerName)
                        End If
                        Response.Redirect("View_Details.aspx")
                    Case Else
                        ' Handle unexpected values, if necessary
                        Exit Sub
                End Select

                ' Call the log save function after determining the access power
                If Not String.IsNullOrEmpty(AccessPowerName) Then
                    PMSclass.PMS_Log_Save(empid, empname, pcName, ipAddress, logDate, Status, AccessPowerName)
                End If

            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your Userid and Password is incorrect');window.location = '" + Request.RawUrl + "';", True)

        End If
    End Sub

End Class