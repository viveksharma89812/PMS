Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Public Class WebForm39
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Dim pass As String = oldpass.Text
            oldpass.Attributes.Add("value", pass)
            pass = newpass.Text
            newpass.Attributes.Add("value", pass)
            pass = confirmpass.Text
            confirmpass.Attributes.Add("value", pass)
        End If
    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        strsql = "select Password from Employee_Master where Password='" & oldpass.Text & "' and EmployeeCode='" & Session("emp code") & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                If oldpass.Text = newpass.Text Then
                    Response.Write(" <script> alert('Old Password and New Password is same,Please enter different Password' );window.location = '" + Request.RawUrl + "';</script>")
                Else
                    strsql = "update Employee_Master set Password='" & newpass.Text & "' where EmployeeCode='" & Session("emp code") & "'"
                    If sqlexe(constr, strsql) Then
                        'Label3.Visible = "true"
                        'Label3.Text = "Updated successfully"
                        Dim url As String = "login.aspx"
                        Response.Write(" <script> alert('Updated successfully' );window.location.href = '" + url + "';</script>")
                        'Response.Write(" <script> alert('Updated successfully' );window.location = '" + Request.RawUrl + "';</script>")
                        Session.Remove("emp code")
                        'Response.Redirect("Login.aspx")
                    End If
                End If
            Else
                'Label3.Visible = "true"
                'Label3.Text = "OldPassword is incorrect "
                Response.Write(" <script> alert('OldPassword Is Incorrect' );window.location = '" + Request.RawUrl + "';</script>")
            End If
        End If

    End Sub
End Class