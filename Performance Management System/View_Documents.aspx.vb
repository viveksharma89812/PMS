Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Security.Policy
Imports System.Collections.Generic
Public Class WebForm7
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fill()

    End Sub
    Private Sub fill()
        strsql = "select * from FileUpload where EmployeeCode='" & Session("emp code") & "'"
        Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/Images/"))
        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            files.Add(New ListItem(Path.GetFileName(filePath), filePath))
        Next
        If sqlselect(constr, strsql, "Abc") Then
            GridView3.DataSource = ds.Tables("Abc")
            GridView3.DataBind()
        End If
    End Sub

    Protected Sub GridView3_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView3.RowCommand
        'If e.CommandName = "Download" Then
        '    Response.Clear()
        '    Response.ClearHeaders()
        '    Response.ClearContent()
        '    Response.ContentType = "Application /.xls"
        '    Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument)
        '    ' Response.TransmitFile(Server.MapPath("~/Images/") + e.CommandArgument)
        '    Response.WriteFile("~/Images/" + e.CommandArgument)
        '    Response.End()
        'End If
    End Sub
End Class