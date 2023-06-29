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
Imports Excel = Microsoft.Office.Interop.Excel
Imports DocumentFormat.OpenXml.Office
Imports System.Runtime.InteropServices

Public Class WebForm8
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim mon As String
    Dim tyear As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack Then
                result()

            End If

            check()
            If Session("access power") = "2" Then
                empsign.Enabled = False
                deptsign.Enabled = True
                sectsign.Enabled = True
            Else
                If Session("access power") = "3" Then
                    empsign.Enabled = True
                    Label23.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                    deptsign.Enabled = False
                    sectsign.Enabled = False
                End If
            End If

            Dim strsql As String
            If Session("access power") <> "2" Then
                CheckBoxList1.Enabled = "true"
                CheckBoxList2.Enabled = "true"
                CheckBoxList3.Enabled = "true"
                CheckBoxList4.Enabled = "true"
                CheckBoxList5.Enabled = "true"
                CheckBoxList6.Enabled = "true"
                'TextBox9.Enabled = "false"
                'Button4.Visible = "false"
            End If
            strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    empcode.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                    empname.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    desc.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                    Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                    Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                    doj.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                    qual.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                    prev.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                    repto.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                    Dim revperiod As String = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
                    deptsec.InnerText = dept + "/" + sect

                    'review.InnerText = Now.Month

                    'If desc.InnerText = "GET" Or desc.InnerText = "MGMT" Then
                    '    trai.Checked = "true"
                    '    prob.Checked = "false"
                    'Else
                    '    prob.Checked = "true"
                    '    trai.Checked = "false"
                    'End If
                    revperiod = revperiod.Trim()
                    If revperiod = "Training" Then
                        trai.Checked = "true"
                        prob.Checked = "false"
                    ElseIf revperiod = "Probation" Then
                        prob.Checked = "true"
                        trai.Checked = "false"
                    End If
                Else
                    'Label22.Visible = "true"
                    'Label22.Text = "Your detail not insereted "
                    Response.Write("<script>alert('Your detail not insereted');</script>")
                End If
            End If

            '   Dim mon As String = DateTime.Now.Month
            mon = DateTime.Now.AddMonths(-1).ToString("MMM")

            Dim yea As String = DateTime.Now.Year
            tyear = DateTime.Now.ToString("yy")
            If mon = "Dec" Then
                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
                tyear = DateTime.Now.AddYears(-1).ToString("yy")
            End If


            tyear = mon + "-" + tyear
            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"
            strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
            If sqlselect(constr, strsql, "Abc") Then
                cla.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("CL"))
                sla.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("SL"))
                pla.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("PL"))
                lwpa.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("LWP"))
                actwork.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ActualWorkingDays"))
                actpre.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ActualPresentDays"))
                absent.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("AbsentDays"))
                scor.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("LeavesScores"))
                review.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
                Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
                Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
                If deptsi = "Done" Then
                    deptsign.Checked = True

                End If
                If sectsi = "Done" Then
                    sectsign.Checked = True
                End If
                If deptsi = "Done" Or sectsi = "Done" Then

                    Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    CheckBoxList1.SelectedValue = sco1 / 3
                    CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    CheckBoxList2.SelectedValue = sco2 / 3
                    CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                    CheckBoxList3.SelectedValue = sco3 / 3
                    CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    CheckBoxList4.SelectedValue = sco4 / 3
                    CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    CheckBoxList5.SelectedValue = sco5 / 3
                    CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                    CheckBoxList6.SelectedValue = sco6 / 3
                    CheckBoxList6.SelectedItem.Attributes.Add("onclick", "return false")
                    totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))

                    remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
                    remark.ReadOnly = True
                    remark.BackColor = System.Drawing.SystemColors.Window
                End If
                If Session("form empid") <> "" Then

                    Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    CheckBoxList1.SelectedValue = sco1 / 3
                    CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    CheckBoxList2.SelectedValue = sco2 / 3
                    CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                    CheckBoxList3.SelectedValue = sco3 / 3
                    CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    CheckBoxList4.SelectedValue = sco4 / 3
                    CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    CheckBoxList5.SelectedValue = sco5 / 3
                    CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                    CheckBoxList6.SelectedValue = sco6 / 3
                    CheckBoxList6.SelectedItem.Attributes.Add("onclick", "return false")
                    totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))

                    remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
                    remark.ReadOnly = True
                    remark.BackColor = System.Drawing.SystemColors.Window
                End If
            End If


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")

        End Try
    End Sub
    Private Sub check()

        For i As Integer = 0 To CheckBoxList1.Items.Count - 1
            CheckBoxList1.Items(i).Attributes.Add("onclick", "MutExChkList(this)")

        Next
        For i As Integer = 0 To CheckBoxList2.Items.Count - 1
            CheckBoxList2.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
        For i As Integer = 0 To CheckBoxList3.Items.Count - 1
            CheckBoxList3.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
        For i As Integer = 0 To CheckBoxList4.Items.Count - 1
            CheckBoxList4.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
        For i As Integer = 0 To CheckBoxList5.Items.Count - 1
            CheckBoxList5.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
        For i As Integer = 0 To CheckBoxList6.Items.Count - 1
            CheckBoxList6.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
    End Sub
    'Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    'End Sub



    Private Sub result()
        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Gtot As Double
        Tot = Double.Parse(CheckBoxList1.SelectedValue)
        scor1.Text = Tot * 3
        Tot1 = Double.Parse(CheckBoxList2.SelectedValue)
        scor2.Text = Tot1 * 3
        Tot2 = Double.Parse(CheckBoxList3.SelectedValue)
        scor3.Text = Tot2 * 3
        Tot3 = Double.Parse(CheckBoxList4.SelectedValue)
        scor4.Text = Tot3 * 3
        Tot4 = Double.Parse(CheckBoxList5.SelectedValue)
        scor5.Text = Tot4 * 3
        Tot5 = Double.Parse(CheckBoxList6.SelectedValue)
        scor6.Text = Tot5 * 3
        Tot6 = Double.Parse(scor.InnerText)
        Dim totid As Integer = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5
        totid = totid * 3
        Gtot = totid + Tot6
        totmarks.InnerText = Gtot.ToString
    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles insert.Click

        Try

            Dim deptaccept As String = ""
            Dim sectaccept As String = ""
            If deptsign.Checked = True Then
                deptaccept = "Done"
            End If
            If sectsign.Checked = True Then
                sectaccept = "Done"
            End If
            If deptsign.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='1',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                    ' clear()
                End If
            End If
            If sectsign.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='PENDING',Form_ID='1',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                    ' clear()
                End If
            End If
            If deptsign.Checked = True And sectsign.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='1',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                    ' clear()
                End If
            End If




        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    Protected Sub empsign_CheckedChanged(sender As Object, e As EventArgs) Handles empsign.CheckedChanged
        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
        End If
    End Sub

    Private Sub clear()
        empname.InnerText = ""
        empcode.InnerText = ""
        desc.InnerText = ""
        deptsec.InnerText = ""
        deptsec.InnerText = ""
        deptsec.InnerText = ""
        doj.InnerText = ""
        review.InnerText = ""
        qual.InnerText = ""
        prev.InnerText = ""
        repto.InnerText = ""
        cla.InnerText = ""
        sla.InnerText = ""
        pla.InnerText = ""
        lwpa.InnerText = ""

    End Sub

    'Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles export.Click
    '    Try
    '        'Response.ContentType = "application/pdf"
    '        'Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf")
    '        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '        'Dim sw As New StringWriter()
    '        'Dim hw As New HtmlTextWriter(sw)
    '        'Panel1.RenderControl(hw)
    '        'Dim sr As New StringReader(sw.ToString())
    '        'Dim pdfDoc As New Document(PageSize.A3, 30.0F, 30.0F, 100.0F, 0.0F)
    '        'Dim pdfDoc As New Document(PageSize.A4, 0.0F, 0.0F, 0.0F, 0.0F)
    '        'Dim htmlparser As New HTMLWorker(pdfDoc)

    '        'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
    '        'pdfDoc.Open()
    '        'htmlparser.Parse(sr)
    '        'pdfDoc.Close()
    '        'Dim html = sw.ToString()
    '        'html = Right(html, Len(html) - InStr(html, "<table") + 1)
    '        'html = Left(html, InStr(html, "</table>") + 7)
    '        'Response.Write(pdfDoc)
    '        'Response.End()


    '        Response.Clear()
    '        Response.Buffer = True
    '        Response.ClearContent()
    '        Response.Charset = ""
    '        Dim dt As String = DateTime.Now.ToString("dd-MM-yyyy")
    '        Response.AddHeader("content-disposition", "attachment; filename=" & dt & " " + ".xls")
    '        Response.ContentType = "application/excel"
    '        Dim sw As New StringWriter()
    '        Dim htw As New HtmlTextWriter(sw)
    '        Panel1.RenderControl(htw)
    '        Dim html = sw.ToString()

    '        html = Right(html, Len(html) - InStr(html, "<table") + 1)
    '        html = Left(html, InStr(html, "</table>") + 7)
    '        Response.Write(sw.ToString())
    '        Response.Flush()
    '        Response.End()
    '    Catch ex As Exception
    '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '    End Try
    'End Sub

    'Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    '    Try




    '    Catch ex As Exception
    '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '    End Try
    'End Sub


    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub

End Class