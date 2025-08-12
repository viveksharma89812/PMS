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
Public Class _0364PS2
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim mon As String
    Dim tyear As String
    Dim uniqGrade As String
    Public PMSclass As New PMSClass()
    Dim fst As String
    Dim sec As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fst = If(Session("empl code") IsNot Nothing, Session("empl code").ToString(), String.Empty)
        sec = If(Session("form empid") IsNot Nothing, Session("form empid").ToString(), String.Empty)
        Try
            If Session("access power") = "" Then
                Response.Redirect("login.aspx")
            End If
            If Session("access power") = "3" Then
                outerimgdiv.Visible = True
            Else
                outerimgdiv.Visible = False
            End If
            If Session("access power") IsNot Nothing AndAlso Session("access power").ToString() = "1" Then
                ch3.Style("display") = "block"
            Else
                ch3.Style("display") = "none"
            End If
            If IsPostBack Then
                If Session("year") = "" Then
                    up()
                    eve()
                    result()
                End If
            Else
                If Session("year") <> "" Then
                    insert.Visible = False
                    update.Visible = False
                    show.Visible = False
                    ch3.Enabled = True
                    ch1.Enabled = True
                    ch2.Enabled = True
                    print.Visible = True

                End If

                If Session("access power") = "2" Then
                    ch3.Enabled = False
                    ch1.Enabled = False
                    ch2.Enabled = True
                    print.Visible = False
                ElseIf Session("access power") = "4" Then
                    ch3.Enabled = False
                    ch1.Enabled = True
                    ch2.Enabled = False

                    print.Visible = False
                Else
                    If Session("access power") = "3" Then
                        ch3.Enabled = True
                        ch1.Enabled = False
                        ch2.Enabled = False
                        score1.Enabled = False
                        score2.Enabled = False
                        score3.Enabled = False
                        score4.Enabled = False
                        print.Visible = False
                        score5.Enabled = False
                        score6.Enabled = False
                        Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                    End If
                End If

            End If
            Dim dtt As DataTable = PMSclass.Loadfirst(fst, sec)
            If dtt IsNot Nothing AndAlso dtt.Rows.Count > 0 Then
                empcode.InnerText = Convert.ToString(dtt.Rows(0)("EmployeeCode"))
                empname.InnerText = Convert.ToString(dtt.Rows(0)("EmployeeName"))
                desc.InnerText = Convert.ToString(dtt.Rows(0)("Designation"))
                Dim dept As String = Convert.ToString(dtt.Rows(0)("Department"))
                Dim sect As String = Convert.ToString(dtt.Rows(0)("Section"))
                doj.InnerText = Convert.ToString(dtt.Rows(0)("DOJ"))
                qual.InnerText = Convert.ToString(dtt.Rows(0)("Qualification"))
                prev.InnerText = Convert.ToString(dtt.Rows(0)("PreviousExperience"))
                repto.InnerText = Convert.ToString(dtt.Rows(0)("ReportingPersonName"))
                Dim revperiod As String = Convert.ToString(dtt.Rows(0)("Review_Period"))
                uniqGrade = Convert.ToString(dtt.Rows(0)("Grade"))
                Session("uniqGrade") = uniqGrade
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
            mon = DateTime.Now.AddMonths(-1).ToString("MMM")

            Dim yea As String = DateTime.Now.Year
            tyear = DateTime.Now.ToString("yy")
            If mon = "Dec" Then
                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
                tyear = DateTime.Now.AddYears(-1).ToString("yy")
            End If

            If Session("year") <> "" Then
                tyear = Session("year")
                Dim lastTwoNumbers As String = tyear.Substring(tyear.Length - 2)
                yea = $"20{lastTwoNumbers}"
            Else
                tyear = mon + "-" + tyear
            End If
            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"
            Dim dt1 As DataTable = PMSclass.Loadsecond(fst, sec, tot, tyear)
            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
                cla.InnerText = Convert.ToString(dt1.Rows(0)("CL"))
                sla.InnerText = Convert.ToString(dt1.Rows(0)("SL"))
                pla.InnerText = Convert.ToString(dt1.Rows(0)("PL"))
                lwpa.InnerText = Convert.ToString(dt1.Rows(0)("LWP"))
                actwork.InnerText = Convert.ToString(dt1.Rows(0)("ActualWorkingDays"))
                actpre.InnerText = Convert.ToString(dt1.Rows(0)("ActualPresentDays"))
                absent.InnerText = Convert.ToString(dt1.Rows(0)("AbsentDays"))
                scor.InnerText = Convert.ToString(dt1.Rows(0)("LeavesScores"))
                review.InnerText = Convert.ToString(dt1.Rows(0)("ReviewMonth"))
                Dim deptsi As String = Convert.ToString(dt1.Rows(0)("Dept_Accept"))
                Dim sectsi As String = Convert.ToString(dt1.Rows(0)("Sect_Accept"))
                Dim empsi As String = Convert.ToString(dt1.Rows(0)("Emp_Accept"))
                Dim sign As String = Convert.ToString(dt1.Rows(0)("time"))
                If deptsi = "Done" Then
                    ch1.Checked = True

                End If
                If Session("access power") IsNot Nothing AndAlso Session("access power").ToString() = "1" AndAlso empsi = "DONE" Or empsi = "Done" Then

                    lblEmpsign.InnerText = Convert.ToString(dt1.Rows(0)("EmployeeName"))
                    lblEmpDate.InnerText = Convert.ToString(dt1.Rows(0)("time"))

                    ch3.Style("display") = "none"
                Else
                    'ch3.Style("display") = "none"
                    lblEmpsign.Visible = False
                    lblEmpDate.Visible = False
                End If

                If sectsi = "Done" Then
                    ch2.Checked = True
                End If
                If Session("access power") <> "3" Then
                    If empsi = "Done" Then
                        ch3.Checked = True
                        Time.Text = sign
                    Else
                        If Session("access power") <> "2" And Session("access power") <> "4" Then
                            Time.Text = "The employee has not signed yet."
                            Time.ForeColor = Color.Red
                        End If

                    End If
                End If

                If Session("form empid") <> "" Or Session("year") <> "" Then
                    score1.Text = Convert.ToString(dt1.Rows(0)("Score1"))
                    score2.Text = Convert.ToString(dt1.Rows(0)("Score2"))
                    score3.Text = Convert.ToString(dt1.Rows(0)("Score3"))
                    score4.Text = Convert.ToString(dt1.Rows(0)("Score4"))
                    score5.Text = Convert.ToString(dt1.Rows(0)("Score5"))
                    score6.Text = Convert.ToString(dt1.Rows(0)("Score6"))
                    totmarks.InnerText = Convert.ToString(dt1.Rows(0)("TotalMarks"))
                    Dim stat As String = Convert.ToString(dt1.Rows(0)("Status"))
                    remark.Text = Convert.ToString(dt1.Rows(0)("Remark"))
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

        Dim dt1 As DataTable = PMSclass.Loadsecond(fst, sec, tot, tyear)
        If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then

            review.InnerText = Convert.ToString(dt1.Rows(0)("ReviewMonth"))
            Dim deptsi As String = Convert.ToString(dt1.Rows(0)("Dept_Accept"))
            Dim sectsi As String = Convert.ToString(dt1.Rows(0)("Sect_Accept"))
            If deptsi = "Done" Then
                ch1.Checked = True
            End If
            If sectsi = "Done" Then
                ch2.Checked = True
            End If
            If deptsi = "Done" Or sectsi = "Done" Then

                score1.Text = Convert.ToString(dt1.Rows(0)("Score1"))
                score2.Text = Convert.ToString(dt1.Rows(0)("Score2"))
                score3.Text = Convert.ToString(dt1.Rows(0)("Score3"))

                score4.Text = Convert.ToString(dt1.Rows(0)("Score4"))
                score5.Text = Convert.ToString(dt1.Rows(0)("Score5"))
                score6.Text = Convert.ToString(dt1.Rows(0)("Score6"))
                totmarks.InnerText = Convert.ToString(dt1.Rows(0)("TotalMarks"))
                Dim stat As String = Convert.ToString(dt1.Rows(0)("Status"))
                remark.Text = Convert.ToString(dt1.Rows(0)("Remark"))
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


        Dim deptaccept As String = ""
        Dim sectaccept As String = ""
        If ch1.Checked = True Then
            deptaccept = "Done"
        End If
        If ch2.Checked = True Then
            sectaccept = "Done"
        End If


        If ch1.Checked = True Then
            result()
            strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',  TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='79',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

            If sqlexe(constr, strsql) Then

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
            End If
        End If
    End Sub

    Private Sub result()

        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Gtot As Double
        If score1.Text <> "" And score1.Text = 1 Or score1.Text = 12 Or score1.Text = 3 Or score1.Text = 4 Or score1.Text = 5 Then
            Tot = Double.Parse(score1.Text) * 4
        End If
        If score2.Text <> "" And score2.Text = 1 Or score2.Text = 2 Or score2.Text = 3 Or score2.Text = 4 Or score2.Text = 5 Then
            Tot1 = Double.Parse(score2.Text) * 4
        End If
        If score3.Text <> "" And score3.Text = 5 Or score3.Text = 4 Or score3.Text = 3 Or score3.Text = 2 Or score3.Text = 1 Then
            Tot2 = Double.Parse(score3.Text) * 1
        End If
        If score4.Text <> "" And score4.Text = 1 Or score4.Text = 2 Or score4.Text = 3 Or score4.Text = 4 Or score4.Text = 5 Then
            Tot3 = Double.Parse(score4.Text) * 2
        End If
        If score5.Text <> "" And score5.Text = 1 Or score5.Text = 2 Or score5.Text = 3 Or score5.Text = 4 Or score5.Text = 5 Then
            Tot4 = Double.Parse(score5.Text) * 2
        End If
        If score6.Text <> "" And score6.Text = 5 Or score6.Text = 4 Or score6.Text = 3 Or score6.Text = 2 Or score6.Text = 1 Then
            Tot5 = Double.Parse(score6.Text) * 1
        End If
        Tot6 = Double.Parse(scor.InnerText)

        Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6
        If Gtot >= 101 Then
            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system 100% please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        Else
            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6


            If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And scor.InnerText <> "" Then
                totmarks.InnerText = Gtot.ToString
            End If

        End If
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles insert.Click
        Try
            Dim deptaccept As String = ""
            Dim sectaccept As String = ""
            If ch1.Checked = True Then
                deptaccept = "Done"
                ch2.Checked = True
            End If
            If ch2.Checked AndAlso Session("uniqGrade") IsNot Nothing AndAlso {"E-3", "E-4", "E-5", "T-1", "T-2", "T-3", "T-4", "T-5", "T-6"}.Contains(Session("uniqGrade").ToString()) Then
                sectaccept = "Done"
                ch1.Checked = True
                deptaccept = "Done"
            End If
            If ch2.Checked = True Then
                sectaccept = "Done"
            End If

            If ch1.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='79',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then


                End If
            End If

            If ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='PENDING',Form_ID='79',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then

                End If
            End If
            If ch1.Checked = True And ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='79',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then


                End If
            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
            ' clear()


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
        If Session("access power") = "3" Then
            Response.Redirect("View_Details.aspx")
        Else
            Response.Redirect("Employee_Details.aspx")
        End If
    End Sub
    Protected Sub ch3_CheckedChanged(sender As Object, e As EventArgs) Handles ch3.CheckedChanged
        Dim empcode As String = CType(Session("form empid"), String)
        Dim empmonth As String = tyear
        Dim picnames As String = empcode & "_" & DateTime.Now.ToString("MM-yyyy")

        ' Construct the file path
        Dim filePath As String = HttpContext.Current.Server.MapPath(String.Format("~/Captures/{0}.jpg", picnames))
        If File.Exists(filePath) Then
            strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' , time  = '" & Time.Text & "',SignPic = '" & picnames & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        Else
            strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' , time  = '" & Time.Text & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        End If

        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
        End If
    End Sub

    Protected Sub update_Click(sender As Object, e As EventArgs) Handles update.Click

        up()
    End Sub

    Protected Sub show_Click(sender As Object, e As EventArgs) Handles show.Click
        eve()
    End Sub

End Class
