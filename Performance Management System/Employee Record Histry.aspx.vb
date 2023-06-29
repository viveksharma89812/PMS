Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO.Path
Imports System.Web
Imports System.IO
Imports System.Drawing
Public Class WebForm21
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fill()
    End Sub

    Private Sub fill()

        strsql = "select * from Employee_Master_Histry"
        Dim TextStr As List(Of String) = New List(Of String)()
        If department.SelectedValue <> "All" Then TextStr.Add("Department='" & department.SelectedValue & "'")
        If Section.SelectedValue <> "All" Then TextStr.Add("Section='" & Section.SelectedValue & "'")

        Dim str As String = String.Join(" and ", TextStr.ToArray())

        strsql = strsql + " " + "where" + " " + str
        If sqlselect(constr, strsql, "Abc") Then
            GridView1.DataSource = ds
            GridView1.DataBind()
        End If
        If department.SelectedValue = "All" And Section.SelectedValue = "All" Then
            strsql = "Select * from Employee_Master_Histry"
            If sqlselect(constr, strsql, "Abc") Then
                GridView1.DataSource = ds
                GridView1.DataBind()
            End If
        End If
        'If department.SelectedValue <> "All" Then
        '    strsql = "select * from Employee_Master where Department='" & department.SelectedValue & "'"
        '    If sqlselect(constr, strsql, "Abc") Then
        '        GridView1.DataSource = ds.Tables("Abc")
        '        GridView1.DataBind()
        '    End If
        'End If
        'If Section.SelectedValue <> "All" And department.SelectedValue <> "All" Then
        '    strsql = "select * from Employee_Master where Section='" & Section.SelectedValue & "'"
        '    If sqlselect(constr, strsql, "Abc") Then
        '        GridView1.DataSource = ds.Tables("Abc")
        '        GridView1.DataBind()
        '    End If
        'End If

        If Not IsPostBack Then
            If department.SelectedValue = "All" Then
                strsql = "select distinct Department from Employee_Master_Histry"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        department.DataSource = ds
                        department.DataTextField = "Department"
                        department.DataValueField = "Department"
                        department.DataBind()
                    End If
                End If
            End If
        End If
        If IsPostBack Then
            If department.SelectedValue <> "All" And Section.SelectedValue = "All" Then
                Section.Items.Clear()
                Section.Items.Add("All")
                strsql = "select distinct Section from Employee_Master_Histry where Department='" & department.SelectedValue & "'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        Section.DataSource = ds
                        Section.DataTextField = "Section"
                        Section.DataValueField = "Section"
                        Section.DataBind()
                    End If
                End If
            End If
        End If
    End Sub

    Protected Sub department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles department.SelectedIndexChanged
        Section.Items.Clear()
        Section.Items.Add("All")
        fill()
    End Sub

    Protected Sub Section_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Section.SelectedIndexChanged
        fill()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            GridView1.PageIndex = 0
            GridView1.AllowPaging = "False"
            GridView1.HeaderStyle.CssClass = "gridviewout"
            GridView1.HeaderStyle.ForeColor = Color.Black
            GridView1.HeaderStyle.BorderStyle = BorderStyle.Solid
            GridView1.HeaderStyle.BorderColor = Color.Black
            GridView1.RowStyle.BorderStyle = BorderStyle.Solid
            GridView1.RowStyle.BorderColor = Color.Black
            GridView1.HeaderStyle.BackColor = Color.Thistle
            GridView1.Font.Size = "12"
            GridView1.DataBind()
            Response.Clear()
            Response.Buffer = True
            Response.ClearContent()
            Response.Charset = ""
            Dim dt As String = DateTime.Now.ToString("dd-MM-yyyy")
            Response.AddHeader("content-disposition", "attachment; filename=" & dt & " " + ".xls")
            Response.ContentType = "application/excel"
            Dim sw As New IO.StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            GridView1.RenderControl(htw)
            Dim html = sw.ToString()

            html = Right(html, Len(html) - InStr(html, "<table") + 1)
            html = Left(html, InStr(html, "</table>") + 7)
            Response.Write(sw.ToString())
            Response.Flush()
            Response.End()


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub
End Class