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
Public Class _0386CNC2
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim mon As String
    Dim tyear As String
    Public PMSclass As New PMSClass()
    Dim fst As String
    Dim sec As String
    Dim uniqGrade As String
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

            q1.Checked = False And q1.Enabled = False
            q2.Checked = False And q2.Enabled = False
            q3.Checked = False And q3.Enabled = False
            q4.Checked = False And q4.Enabled = False
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
                    remark.Enabled = True
                    score12.Enabled = False
                    print.Visible = False
                ElseIf Session("access power") = "4" Then
                    ch3.Enabled = False
                    ch1.Enabled = True
                    ch2.Enabled = False
                    remark.Enabled = True
                    print.Visible = False
                Else
                    If Session("access power") = "3" Then
                        'fail1()
                        score1.Enabled = False
                        score2.Enabled = False
                        score3.Enabled = False
                        score4.Enabled = False
                        score5.Enabled = False
                        score6.Enabled = False
                        score7.Enabled = False
                        score8.Enabled = False
                        score9.Enabled = False
                        score10.Enabled = False
                        score11.Enabled = False
                        score12.Enabled = False
                        print.Visible = False
                        remark.Enabled = False
                        Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                        ch3.Enabled = True
                        ch1.Enabled = False
                        ch2.Enabled = False


                    End If
                    If Session("access power") = "4" And ch2.Checked = True And ch2.Enabled = False Then
                        show.Visible = True
                        update.Visible = True
                    Else
                        show.Visible = False
                        update.Visible = False
                    End If

                End If

                Dim dtt As DataTable = PMSclass.Loadfirst(fst, sec)
                If dtt IsNot Nothing AndAlso dtt.Rows.Count > 0 Then
                    empcode.Text = Convert.ToString(dtt.Rows(0)("EmployeeCode"))
                    empname.Text = Convert.ToString(dtt.Rows(0)("EmployeeName"))
                    desc.Text = Convert.ToString(dtt.Rows(0)("Designation"))
                    Dim dept As String = Convert.ToString(dtt.Rows(0)("Department"))
                    Dim sect As String = Convert.ToString(dtt.Rows(0)("Section"))
                    doj.Text = Convert.ToString(dtt.Rows(0)("DOJ"))
                    repto.Text = Convert.ToString(dtt.Rows(0)("ReportingPersonName"))
                    uniqGrade = Convert.ToString(dtt.Rows(0)("Grade"))
                    Session("uniqGrade") = uniqGrade
                    deptsect.Text = dept + "/" + sect
                    Dim revperiod As String = Convert.ToString(dtt.Rows(0)("Review_Period"))
                    revperiod = revperiod.Trim()
                    Dim dt As String
                    If revperiod = "Training" Then
                        trai.Checked = "true"
                        prob.Checked = "false"
                        conf.Checked = "false"
                        Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
                        If mont <= "12" Then
                            month.Checked = True
                        End If
                    ElseIf revperiod = "Probation" Then
                        prob.Checked = "true"
                        trai.Checked = "false"
                        conf.Checked = "false"
                        Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
                        If mont <= "12" Then
                            month.Checked = True
                        End If
                    ElseIf revperiod = "Confirm" Then
                        If Session("year") <> "" Then
                            Dim str As String = Session("year")
                            Dim f As String = str.Substring(0, 2)
                            If f = "Ma" Then
                                dt = "03"
                            ElseIf f = "Ju" Then
                                dt = "06"
                            ElseIf f = "Se" Then
                                dt = "09"
                            ElseIf f = "De" Then
                                dt = "12"
                            End If
                        Else
                            Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
                            dt = DateTime.Now.AddMonths(-1).ToString("MM")
                        End If

                        If dt = "03" Then
                            q1.Checked = True
                        ElseIf dt = "06" Then
                            q2.Checked = True
                        ElseIf dt = "09" Then
                            q3.Checked = True
                        ElseIf dt = "12" Then
                            q4.Checked = True
                        End If

                        conf.Checked = "true"
                        trai.Checked = "false"
                        prob.Checked = "false"


                    Else
                        Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
                        If mont <= "12" Then
                            month.Checked = True
                        End If
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

            If Session("year") <> "" Then
                tyear = Session("year")
                Dim lastTwoNumbers As String = tyear.Substring(tyear.Length - 2)
                yea = $"20{lastTwoNumbers}"
            Else
                tyear = mon + "-" + tyear
            End If
            revmonth.Text = tyear
            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"
            Dim dt1 As DataTable = PMSclass.Loadsecond(fst, sec, tot, tyear)
            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then

                revmonth.Text = Convert.ToString(dt1.Rows(0)("ReviewMonth"))
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
                    score7.Text = Convert.ToString(dt1.Rows(0)("Score7"))
                    score8.Text = Convert.ToString(dt1.Rows(0)("Score8"))
                    score9.Text = Convert.ToString(dt1.Rows(0)("Score9"))
                    score10.Text = Convert.ToString(dt1.Rows(0)("Score10"))
                    score11.Text = Convert.ToString(dt1.Rows(0)("Score11"))
                    score12.Text = Convert.ToString(dt1.Rows(0)("Score12"))
                    ldr.Text = Convert.ToString(dt1.Rows(0)("Ldr"))
                    shead.Text = Convert.ToString(dt1.Rows(0)("Shead"))
                    dhead.Text = Convert.ToString(dt1.Rows(0)("Dhead"))
                    shead.Text = Convert.ToString(dt1.Rows(0)("Sshead"))
                    remark.Text = Convert.ToString(dt1.Rows(0)("Remark4"))
                    totmarks.Text = Convert.ToString(dt1.Rows(0)("TotalMarks"))
                    Dim stat As String = Convert.ToString(dt1.Rows(0)("Status"))
                    If stat = "Pass" Then
                        pass.Checked = True

                    ElseIf stat = "Extend" Then
                        extend.Checked = True
                    End If
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
        revmonth.Text = tyear
        tot = yea
        tot = "[dbo]" + ". " + "[" + tot + "]"
        Dim dt1 As DataTable = PMSclass.Loadsecond(fst, sec, tot, tyear)
        If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then

            revmonth.Text = Convert.ToString(dt1.Rows(0)("ReviewMonth"))
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
                score7.Text = Convert.ToString(dt1.Rows(0)("Score7"))
                score8.Text = Convert.ToString(dt1.Rows(0)("Score8"))
                score9.Text = Convert.ToString(dt1.Rows(0)("Score9"))
                score10.Text = Convert.ToString(dt1.Rows(0)("Score10"))
                score11.Text = Convert.ToString(dt1.Rows(0)("Score11"))
                score12.Text = Convert.ToString(dt1.Rows(0)("Score12"))


                ldr.Text = Convert.ToString(dt1.Rows(0)("Ldr"))
                shead.Text = Convert.ToString(dt1.Rows(0)("Shead"))
                dhead.Text = Convert.ToString(dt1.Rows(0)("Dhead"))
                'sshead.Text = Convert.ToString(dt1.Rows(0)("Sshead"))
                remark.Text = Convert.ToString(dt1.Rows(0)("Remark4"))
                totmarks.Text = Convert.ToString(dt1.Rows(0)("TotalMarks"))
                Dim stat As String = Convert.ToString(dt1.Rows(0)("Status"))
                If stat = "Pass" Then
                    pass.Checked = True

                ElseIf stat = "Extend" Then
                    extend.Checked = True

                End If
            End If

        End If

    End Sub
    Public Sub post()

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
        revmonth.Text = tyear
        tot = yea
        tot = "[dbo]" + ". " + "[" + tot + "]"

        Dim s1 As String = score1.Text
        Dim s2 As String = score2.Text
        Dim s3 As String = score3.Text
        Dim s4 As String = score4.Text
        Dim s5 As String = score5.Text
        Dim s6 As String = score6.Text
        Dim s7 As String = score7.Text
        Dim s8 As String = score8.Text
        Dim s9 As String = score9.Text
        Dim s10 As String = score10.Text
        Dim s11 As String = score11.Text
        Dim s12 As String = score12.Text

        Dim deptaccept As String = ""
        Dim sectaccept As String = ""
        If ch1.Checked = True Then
            deptaccept = "Done"
        End If
        If ch2.Checked = True Then
            sectaccept = "Done"
        End If
        Dim status As String = ""
        If pass.Checked = True Then
            status = "Pass"
        ElseIf extend.Checked = True Then
            status = "Extend"

        End If
        If ch1.Checked = True Then
            result()
            strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "', TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='49',Dept_Accept='" & deptaccept & "' ,Ldr ='" & ldr.Text & "', Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Remark4 = '" & remark.Text & "'  where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

            If sqlexe(constr, strsql) Then

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
            End If
        End If
    End Sub
    Private Sub result()
        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Tot7, Tot8, Tot9, Tot10, Tot11, Gtot As Double
        If score1.Text <> "" And score1.Text <= 25 Then
            Tot = Double.Parse(score1.Text)
            score1.BackColor = Color.White
            score1.ForeColor = Color.Black
        Else
            score1.ForeColor = Color.Red
            score1.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score2.Text <> "" And score2.Text <= 5 Then
            Tot1 = Double.Parse(score2.Text)
            score2.BackColor = Color.White
            score2.ForeColor = Color.Black
        Else
            score2.ForeColor = Color.Red
            score2.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score3.Text <> "" And score3.Text <= 16 Then
            Tot2 = Double.Parse(score3.Text)
            score3.BackColor = Color.White
            score3.ForeColor = Color.Black
        Else
            score3.ForeColor = Color.Red
            score3.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score4.Text <> "" And score4.Text <= 15 Then
            Tot3 = Double.Parse(score4.Text)
            score4.BackColor = Color.White
            score4.ForeColor = Color.Black
        Else
            score4.ForeColor = Color.Red
            score4.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score5.Text <> "" And score5.Text <= 15 Then
            Tot4 = Double.Parse(score5.Text)
            score5.BackColor = Color.White
            score5.ForeColor = Color.Black
        Else
            score5.ForeColor = Color.Red
            score5.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If


        If score6.Text <> "" And score6.Text <= 5 Then
            Tot5 = Double.Parse(score6.Text)
            score6.BackColor = Color.White
            score6.ForeColor = Color.Black
        Else
            score6.ForeColor = Color.Red
            score6.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score7.Text <> "" And score7.Text <= 5 Then
            Tot6 = Double.Parse(score7.Text)
            score7.BackColor = Color.White
            score7.ForeColor = Color.Black
        Else
            score7.ForeColor = Color.Red
            score7.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score8.Text <> "" And score8.Text <= 5 Then
            Tot7 = Double.Parse(score8.Text)
            score8.BackColor = Color.White
            score8.ForeColor = Color.Black
        Else
            score8.ForeColor = Color.Red
            score8.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score9.Text <> "" And score9.Text <= 5 Then
            Tot8 = Double.Parse(score9.Text)
            score9.BackColor = Color.White
            score9.ForeColor = Color.Black
        Else
            score9.ForeColor = Color.Red
            score9.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score10.Text <> "" And score10.Text <= 4 Then
            Tot9 = Double.Parse(score10.Text)
            score10.BackColor = Color.White
            score10.ForeColor = Color.Black
        Else
            score10.ForeColor = Color.Red
            score10.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If




        If score11.Text <> "" Then
            Tot10 = Double.Parse(score11.Text)
        End If

        If score12.Text <> "" Then
            Tot11 = Double.Parse(score12.Text)
        End If



        Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11


        If Gtot >= 101 Then
            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9
            score11.ForeColor = Color.Red
            score11.BackColor = Color.Yellow

            score12.ForeColor = Color.Red
            score12.BackColor = Color.Yellow

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system 100% please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)

        Else
            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11
            score11.BackColor = Color.White
            score11.ForeColor = Color.Black

            score12.BackColor = Color.White
            score12.ForeColor = Color.Black


            If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And score7.Text <> "" And score8.Text <> "" And score9.Text <> "" And score10.Text <> "" Then
                totmarks.Text = Gtot.ToString
            End If
            If totmarks.Text >= 76 Then
                pass.Checked = True
                extend.Checked = False And extend.Enabled

            Else
                extend.Checked = True
                pass.Checked = False And pass.Enabled

            End If
        End If

        If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And score7.Text <> "" And score8.Text <> "" And score9.Text <> "" And score10.Text <> "" Then
            totmarks.Text = Gtot.ToString
        End If
        If totmarks.Text >= 76 Then
            pass.Checked = True
            extend.Checked = False And extend.Enabled
        Else
            extend.Checked = True
            pass.Checked = False And pass.Enabled
        End If

    End Sub


    Public Sub msg()
        MsgBox("Please enter only numeric 請輸入數字")

    End Sub
    Protected Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click
        Try

            result()
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
            Dim status As String = ""
            If pass.Checked = True Then
                status = "Pass"
            ElseIf extend.Checked = True Then
                status = "Extend"
            End If
            If ch1.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "', TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='49',Ldr ='" & ldr.Text & "',Dept_Accept='" & deptaccept & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Remark4 = '" & remark.Text & "'  where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                End If
            End If


            If ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "', TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='PENDING',Form_ID='49',Ldr ='" & ldr.Text & "',Sect_Accept='" & sectaccept & "', Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Remark4 = '" & remark.Text & "'  where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                End If
            End If
            If ch1.Checked = True And ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "', TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='49',Ldr ='" & ldr.Text & "',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "'  , Remark4 = '" & remark.Text & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                End If
            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)

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
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
        End If
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please First ');window.close()", True)
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
    Protected Sub score7_TextChanged(sender As Object, e As EventArgs) Handles score7.TextChanged
        If score7.Text.Length > 0 Then
            If Not IsNumeric(score7.Text) Then
                msg()
                score7.Text = 0
            End If
        End If
    End Sub
    Protected Sub score8_TextChanged(sender As Object, e As EventArgs) Handles score8.TextChanged
        If score8.Text.Length > 0 Then
            If Not IsNumeric(score8.Text) Then
                msg()
                score8.Text = 0
            End If
        End If
    End Sub

    Protected Sub score9_TextChanged(sender As Object, e As EventArgs) Handles score9.TextChanged
        If score9.Text.Length > 0 Then
            If Not IsNumeric(score9.Text) Then
                msg()
                score9.Text = 0
            End If
        End If
    End Sub

    Protected Sub score10_TextChanged(sender As Object, e As EventArgs) Handles score10.TextChanged
        If score10.Text.Length > 0 Then
            If Not IsNumeric(score10.Text) Then
                msg()
                score10.Text = 0
            End If
        End If
    End Sub

    Protected Sub score11_TextChanged(sender As Object, e As EventArgs) Handles score11.TextChanged
        If score11.Text.Length > 0 Then
            If Not IsNumeric(score11.Text) Then
                msg()
                score11.Text = 0
            End If
        End If
    End Sub
    Protected Sub score12_TextChanged(sender As Object, e As EventArgs) Handles score12.TextChanged
        If score12.Text.Length > 0 Then
            If Not IsNumeric(score12.Text) Then
                msg()
                score12.Text = 0
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
        Dim s7 As String = score7.Text
        Dim s8 As String = score8.Text
        Dim s9 As String = score9.Text
        Dim s10 As String = score10.Text
        Dim s11 As String = score11.Text
        Dim s12 As String = score12.Text


        up()
    End Sub

    Protected Sub show_Click(sender As Object, e As EventArgs) Handles show.Click
        eve()
    End Sub
End Class