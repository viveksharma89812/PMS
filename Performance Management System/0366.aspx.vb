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

Public Class WebForm15
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            strsql = "select * from Employee_Master where EmployeeCode='" & Session("emp code") & "'"
            If sqlselect(constr, strsql, "Abc") Then
                Dim code As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                Dim name As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                Dim desi As String = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                Dim dateofjoining As String = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))

                empname.Text = name
                empcode.Text = code
                desc.Text = desi
                deptsect.Text = dept
                deptsect.Text = sect
                deptsect.Text = dept + "/" + sect
                doj.Text = dateofjoining
                revmonth.Text = Now.Month

            Else
                Label18.Visible = "true"
                Label18.Text = "Your detail not insereted "
            End If
            Dim yea As String = DateTime.Now.Year
            Dim mon As String = DateTime.Now.Month
            If mon < 10 Then
                mon = "0" + mon
            End If
            tot = yea + mon
            tot = "[dbo]" + ". " + "[" + tot + "]"
            strsql = "select CL,SL,PL,LWP,ActualWorkingDays,ActualPresentDays,AbsentDays,LeavesScores from" + " " + tot + " " + "where EmployeeCode='" & Session("empl code") & "'"
            If sqlselect(constr, strsql, "Abc") Then
                Dim cl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("CL"))
                Dim sl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("SL"))
                Dim pl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("PL"))
                Dim lwp As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("LWP"))
                Dim actwor As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("ActualWorkingDays"))
                Dim actpre As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("ActualPresentDays"))
                Dim abs As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("AbsentDays"))
                Dim leaves As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("LeavesScores"))
                cla.Text = cl
                sla.Text = sl
                pla.Text = pl
                lwpa.Text = lwp
                actworking.Text = actwor
                actpresent.Text = actpre
                absentdays.Text = abs
                score.Text = leaves
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
            Dim pdfDoc As New Document(PageSize.A3, 8.0F, 10.0F, 100.0F, 0.0F)
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
End Class