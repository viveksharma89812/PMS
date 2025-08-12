
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

Public Class _0364_Planning
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim mon As String
    Dim tyear As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Session("access power") = "" Then
                Response.Redirect("login.aspx")
            End If
            If IsPostBack Then
                up()
                eve()
                result()


            Else

                If Session("access power") = "2" Then
                ch3.Enabled = False
                ch1.Enabled = False
                ch2.Enabled = True
            ElseIf Session("access power") = "4" Then
                ch3.Enabled = False
                ch1.Enabled = True
                ch2.Enabled = False
            Else
                If Session("access power") = "3" Then
                    ch3.Enabled = True
                    ch1.Enabled = False
                    ch2.Enabled = False
                    Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                End If
            End If

            End If
            Dim strsql As String

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


                    revperiod = revperiod.Trim()
                    If revperiod = "Training" Then
                        trai.Checked = "true"
                        prob.Checked = "false"
                    ElseIf revperiod = "Probation" Then
                        prob.Checked = "true"
                        trai.Checked = "false"
                    End If
                Else
                    Response.Write("<script>alert('Your detail not insereted');</script>")
                End If
            End If
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
                    ch1.Checked = True

                End If
                If sectsi = "Done" Then
                    ch2.Checked = True
                End If



                If Session("form empid") <> "" Then

                    score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))

                    score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
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
    Public Sub eve()

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

            review.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
            Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
            Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
            If deptsi = "Done" Then
                ch1.Checked = True

            End If
            If sectsi = "Done" Then
                ch2.Checked = True
            End If

            If deptsi = "Done" Or sectsi = "Done" Then

                score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))

                score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))

                remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
                'remark.ReadOnly = True
                'remark.BackColor = System.Drawing.SystemColors.Window

            End If

        End If

    End Sub

    Public Sub up()


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

        Dim s1 As String = score1.Text
        Dim s2 As String = score2.Text
        Dim s3 As String = score3.Text
        Dim s4 As String = score4.Text
        Dim s5 As String = score5.Text
        Dim s6 As String = score6.Text




        Dim deptaccept As String = ""
        Dim sectaccept As String = ""
        If ch1.Checked = True Then
            deptaccept = "Done"
        End If
        If ch2.Checked = True Then
            sectaccept = "Done"
        End If

        If ch1.Checked = True Then
            strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',  TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='44',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

            If sqlexe(constr, strsql) Then
                result()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
            End If
        End If
    End Sub

    Private Sub result()

        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Tot7, Tot8, Tot9, Tot10, Tot11, Tot12, Tot13, Gtot As Double
        If score1.Text <> "" And score1.Text = 20 Or score1.Text = 16 Or score1.Text = 12 Or score1.Text = 8 Or score1.Text = 4 Then
            Tot = Double.Parse(score1.Text)
            score1.BackColor = Color.White
            score1.ForeColor = Color.Black
        Else
            score1.ForeColor = Color.Red
            score1.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score2.Text <> "" And score2.Text = 20 Or score2.Text = 16 Or score2.Text = 12 Or score2.Text = 8 Or score2.Text = 4 Then
            Tot1 = Double.Parse(score2.Text)
            score2.BackColor = Color.White
            score2.ForeColor = Color.Black
        Else
            score2.ForeColor = Color.Red
            score2.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score3.Text <> "" And score3.Text = 5 Or score3.Text = 4 Or score3.Text = 3 Or score3.Text = 2 Or score3.Text = 1 Then
            Tot2 = Double.Parse(score3.Text)
            score3.BackColor = Color.White
            score3.ForeColor = Color.Black
        Else
            score3.ForeColor = Color.Red
            score3.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score4.Text <> "" And score4.Text = 10 Or score4.Text = 8 Or score4.Text = 6 Or score4.Text = 4 Or score4.Text = 2 Then
            Tot3 = Double.Parse(score4.Text)
            score4.BackColor = Color.White
            score4.ForeColor = Color.Black
        Else
            score4.ForeColor = Color.Red
            score4.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score5.Text <> "" And score5.Text = 10 Or score5.Text = 8 Or score5.Text = 6 Or score5.Text = 4 Or score5.Text = 2 Then
            Tot4 = Double.Parse(score5.Text)
            score5.BackColor = Color.White
            score5.ForeColor = Color.Black
        Else
            score5.ForeColor = Color.Red
            score5.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score6.Text <> "" And score6.Text = 5 Or score6.Text = 4 Or score6.Text = 3 Or score6.Text = 2 Or score6.Text = 1 Then
            Tot5 = Double.Parse(score6.Text)
            score6.BackColor = Color.White
            score6.ForeColor = Color.Black
        Else
            score6.ForeColor = Color.Red
            score6.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        Tot6 = Double.Parse(scor.InnerText)

        Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6
        If Gtot >= 101 Then
            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6
            'score1.ForeColor = Color.Red
            'score2.ForeColor = Color.Red
            'score3.ForeColor = Color.Red
            'score4.ForeColor = Color.Red
            'score5.ForeColor = Color.Red
            'score6.ForeColor = Color.Red
            'score1.BackColor = Color.Yellow
            'score2.BackColor = Color.Yellow
            'score3.BackColor = Color.Yellow
            'score4.BackColor = Color.Yellow
            'score5.BackColor = Color.Yellow
            'score6.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system 100% please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        Else
            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6
            'score1.ForeColor = Color.Black
            'score2.ForeColor = Color.Black
            'score3.ForeColor = Color.Black
            'score4.ForeColor = Color.Black
            'score5.ForeColor = Color.Black
            'score6.ForeColor = Color.Black
            'score1.BackColor = Color.White
            'score2.BackColor = Color.White
            'score3.BackColor = Color.White
            'score4.BackColor = Color.White
            'score5.BackColor = Color.White
            'score6.BackColor = Color.White

            If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And scor.InnerText <> "" Then
                totmarks.InnerText = Gtot.ToString
            End If

        End If

        'If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" Then
        '    totmarks.InnerText = Gtot.ToString
        'End If


    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles insert.Click

        Try

            Dim deptaccept As String = ""
            Dim sectaccept As String = ""
            If ch1.Checked = True Then
                deptaccept = "Done"
            End If
            If ch2.Checked = True Then
                sectaccept = "Done"
            End If

            If ch1.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='44',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                    ' clear()
                End If
            End If

            If ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='PENDING',Form_ID='44',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                    ' clear()
                End If
            End If
            If ch1.Checked = True And ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='44',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                    ' clear()
                End If
            End If

        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Protected Sub ch3_CheckedChanged(sender As Object, e As EventArgs) Handles ch3.CheckedChanged
        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
        End If
    End Sub
    Public Sub msg()
        MsgBox("Please enter only numeric 請輸入數字")
    End Sub
    Protected Sub score1_TextChanged(sender As Object, e As EventArgs) Handles score1.TextChanged
        If score1.Text.Length > 0 Then
            If Not IsNumeric(score1.Text) Then
                msg()
                score1.Text = 0
            End If
        End If
    End Sub
    Protected Sub score2_TextChanged(sender As Object, e As EventArgs) Handles score2.TextChanged
        If score2.Text.Length > 0 Then
            If Not IsNumeric(score2.Text) Then
                msg()
                score2.Text = 0
            End If
        End If
    End Sub
    Protected Sub score3_TextChanged(sender As Object, e As EventArgs) Handles score3.TextChanged
        If score3.Text.Length > 0 Then
            If Not IsNumeric(score3.Text) Then
                msg()
                score3.Text = 0
            End If
        End If
    End Sub
    Protected Sub score4_TextChanged(sender As Object, e As EventArgs) Handles score4.TextChanged
        If score4.Text.Length > 0 Then
            If Not IsNumeric(score4.Text) Then
                msg()
                score4.Text = 0
            End If
        End If
    End Sub
    Protected Sub score5_TextChanged(sender As Object, e As EventArgs) Handles score5.TextChanged
        If score5.Text.Length > 0 Then
            If Not IsNumeric(score5.Text) Then
                msg()
                score5.Text = 0
            End If
        End If
    End Sub
    Protected Sub score6_TextChanged(sender As Object, e As EventArgs) Handles score6.TextChanged
        If score6.Text.Length > 0 Then
            If Not IsNumeric(score6.Text) Then
                msg()
                score6.Text = 0
            End If
        End If
    End Sub

    Protected Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        Dim s1 As String = score1.Text
        Dim s2 As String = score2.Text
        Dim s3 As String = score3.Text
        Dim s4 As String = score4.Text
        Dim s5 As String = score5.Text
        Dim s6 As String = score6.Text



        up()
    End Sub

    Protected Sub show_Click(sender As Object, e As EventArgs) Handles show.Click
        eve()
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


    ''''Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    ''''    ' Verifies that the control is rendered
    ''''End Sub



End Class