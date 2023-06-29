Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class WebForm2
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label1.Text = ""
        If IsPostBack Then
            Dim password As String = pass.Text
            pass.Attributes.Add("value", password)
        End If
        'If IsPostBack Then
        '    Dim script As String = "$(document).ready(function () { $('[id*=Button1]').click(); });"
        '    ClientScript.RegisterStartupScript(Me.GetType, "load", script, True)
        'End If
        Dim masterPageBody As HtmlControl = Master.FindControl("masterbody")
        masterPageBody.Style.Add("background-image", "/Bck_Img/New3.png")
        masterPageBody.Style.Add("background-size", "100%")

        empcode.Focus()
        If Page.IsPostBack Then
            Session.Remove("emp code")
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles login.Click
        'strsql = "select EmployeeCode,Password,Designation,EmployeeName,Department,Access_Power from Employee_Master where EmployeeCode='" & empcode.Text & "' and Password='" & pass.Text & "' collate Latin1_General_CS_AS"
        strsql = "select EmployeeCode,Password,Designation,EmployeeName,Department,Section,Access_Power from Employee_Master1 where EmployeeCode='" & empcode.Text & "' and Password='" & pass.Text & "' collate Latin1_General_CS_AS"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Dim empid As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                Dim name As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                Dim desc As String = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                Dim access As String = Convert.ToString(ds.Tables(0).Rows(0)("Access_Power"))

                Session("emp code") = empid
                Session("user name") = name
                Session("designation") = desc
                Session("department") = dept
                Session("section") = sect
                Session("access power") = access

                If Session("access power") = "1" Then
                    Response.Redirect("Upload_Details.aspx")
                ElseIf Session("access power") = "2" Then
                    Response.Redirect("Employee_Details.aspx")
                ElseIf Session("access power") = "4" Then
                    Response.Redirect("Employee_Details.aspx")
                ElseIf Session("access power") = "5" Then
                    Response.Redirect("Employee_Details.aspx")
                ElseIf Session("access power") = "3" Then
                    Response.Redirect("View_Details.aspx")

                End If
            Else
                'Label1.Visible = "true"
                'Label1.Text = "Your Userid and Password is incorrect"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your Userid and Password is incorrect');window.location = '" + Request.RawUrl + "';", True)
                'empcode.Text = ""
                'Dim Password As String = pass.Text
                'pass.Attributes.Add("value", "")

            End If
        End If
    End Sub

    'Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    '    If CheckBox1.Checked = "True" Then
    '        pass.TextMode = TextBoxMode.SingleLine
    '    ElseIf CheckBox1.Checked = "False" Then
    '        pass.TextMode = TextBoxMode.Password
    '    End If
    'End Sub


End Class