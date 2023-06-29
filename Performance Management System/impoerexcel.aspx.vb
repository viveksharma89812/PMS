Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class WebForm4
    Inherits System.Web.UI.Page
    Dim str As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
        Dim filePath As String = (Server.MapPath("~/Images/"))
        FileUpload1.PostedFile.SaveAs((Server.MapPath("~/Images/") & fileName))

        Dim appXL As New Application
        Dim wbXl As New Workbook
        Dim shXL As New Worksheet

        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet



    End Sub

End Class