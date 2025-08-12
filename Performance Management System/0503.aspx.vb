Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Path
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports System.Drawing
Imports System.Drawing.Imaging


Public Class WebForm11
    Inherits System.Web.UI.Page
    Dim strsql As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("access power") = "" Then
                Response.Redirect("login.aspx")
            End If
            strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "'"
            If sqlselect(constr, strsql, "Abc") Then
                Dim code As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                Dim name As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                Dim desi As String = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                Dim dateofjoining As String = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))

                emplname.Text = name
                emplcode.Text = code
                deptn.Text = dept
                sectn.Text = sect
            Else
                Label7.Visible = "true"
                Label7.Text = "Your detail not insereted "
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")

        End Try
    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub
    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Response.ContentType = "application/pdf"
            Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf")
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Panel1.RenderControl(hw)
            Dim sr As New StringReader(sw.ToString())
            Dim pdfDoc As New Document(PageSize.A4, 8.0F, 10.0F, 100.0F, 0.0F)
            Dim htmlparser As New HTMLWorker(pdfDoc)
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
            pdfDoc.Open()
            htmlparser.Parse(sr)
            pdfDoc.Close()
            Response.Write(pdfDoc)
            Response.End()
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    'Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged


    'End Sub


End Class