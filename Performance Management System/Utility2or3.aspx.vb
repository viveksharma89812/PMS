
Imports System.Drawing
Imports System.IO

Public Class Utility2or3
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim mon As String
    Dim tyear As String
    Dim amount As String
    Dim empnaccept As String
    Dim ldrnaccept As String
    Dim sheadnaccept As String
    Dim dheadnaccept As String
    Dim empdaccept As String
    Dim ldrdaccept As String
    Dim sheaddaccept As String
    Dim dheaddaccept As String
    Dim empsignaccept As String
    Dim ldrsignaccept As String
    Dim sheadsignaccept As String
    Dim dheadsignaccept As String
    Dim sameasaccept As String
    Dim sincreaseaccept As String
    Dim sdecreaseaccept As String
    Dim uniqGrade As String

    Public PMSclass As New PMSClass()

    Dim fst As String
    Dim sec As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fst = If(Session("empl code") IsNot Nothing, Session("empl code").ToString(), String.Empty)
        sec = If(Session("form empid") IsNot Nothing, Session("form empid").ToString(), String.Empty)
        Try
            If Not IsPostBack Then
                ' Initially set all score fields to read-only on first load
                SetScoresReadOnly(True)
            Else
                ' Handle state after a postback (checkboxes may have been checked/unchecked)

            End If


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
            ' If Session("access power") <> "4" Then
            If IsPostBack Then
                If Session("year") = "" Then
                    up()
                    eve()

                    result()
                    'post()
                    amnt()
                    salary1()
                    fail1()
                    'post()
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
                    'fail1()
                    print.Visible = False
                    'show.Visible = False
                    'update.Visible = False
                    'ldrn.Enabled = True
                    'sheadn.Enabled = True
                    'dheadn.Enabled = True
                    'ldrd.Enabled = True
                    'sheadd.Enabled = True
                    'dheadd.Enabled = True
                    dhead.Enabled = False
                    score19.Enabled = True
                    score20.Enabled = False
                    famnt1.Enabled = True
                    remark4.Enabled = True
                    Eligible.Enabled = True
                    'sdecrease.Enabled = False

                ElseIf Session("access power") = "4" Then
                    ch3.Enabled = False
                    'score8.Enabled = False
                    'score9.Enabled = False
                    ch1.Enabled = True
                    ch2.Enabled = False
                    'fail1()
                    print.Visible = False
                    'ldrn.Enabled = True
                    'sheadn.Enabled = True
                    'dheadn.Enabled = True
                    'ldrd.Enabled = True
                    'sheadd.Enabled = True
                    'dheadd.Enabled = True
                    famnt1.Enabled = True
                    remark4.Enabled = True
                    'Eligible.Enabled = True
                    'sdecrease.Enabled = True

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
                        score13.Enabled = False
                        score14.Enabled = False
                        score15.Enabled = False
                        score16.Enabled = False
                        score17.Enabled = False
                        score18.Enabled = False
                        print.Visible = False
                        ldr.Enabled = False
                        shead.Enabled = False
                        'show.Visible = False
                        'update.Visible = False
                        remark4.Enabled = False
                        famnt1.Enabled = False
                        Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                        ch3.Enabled = True
                        ch1.Enabled = False
                        ch2.Enabled = False
                        Eligible.Enabled = False
                        'sdecrease.Enabled = False
                        dhead.Enabled = False
                        score19.Enabled = False
                        score20.Enabled = False
                        Not_Eligible.Enabled = False
                        CheckBox6.Enabled = False
                        CheckBox7.Enabled = False
                        CheckBox8.Enabled = False

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
                    Dim DOT = Convert.ToString(dtt.Rows(0)("DOT"))
                    If String.IsNullOrEmpty(DOT) Then
                        Session("DOT") = Convert.ToString(dtt.Rows(0)("DOJ"))
                    Else
                        Session("DOT") = DOT
                    End If
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

                        If dt = "03" Or dt = "06" Or dt = "09" Or dt = "12" Then
                            quaterly.Checked = True
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
            Label30.Text = tyear
            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"

            Dim dt1 As DataTable = PMSclass.Loadsecond(fst, sec, tot, tyear)
            If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
                revmonth.Text = Convert.ToString(dt1.Rows(0)("ReviewMonth"))
                Dim deptsi As String = Convert.ToString(dt1.Rows(0)("Dept_Accept"))
                Dim sectsi As String = Convert.ToString(dt1.Rows(0)("Sect_Accept"))
                Dim empsi As String = Convert.ToString(dt1.Rows(0)("Emp_Accept"))
                Dim sign As String = Convert.ToString(dt1.Rows(0)("time"))
                actwork.InnerText = Convert.ToString(dt1.Rows(0)("ActualWorkingDays"))
                actpre.InnerText = Convert.ToString(dt1.Rows(0)("ActualPresentDays"))
                absent.InnerText = Convert.ToString(dt1.Rows(0)("AbsentDays"))
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
                    score13.Text = Convert.ToString(dt1.Rows(0)("Score13"))
                    score14.Text = Convert.ToString(dt1.Rows(0)("Score14"))
                    score15.Text = Convert.ToString(dt1.Rows(0)("Score15"))
                    score16.Text = Convert.ToString(dt1.Rows(0)("Score16"))
                    score17.Text = Convert.ToString(dt1.Rows(0)("Score17"))
                    score18.Text = Convert.ToString(dt1.Rows(0)("Score18"))
                    score19.Text = Convert.ToString(dt1.Rows(0)("Score19"))
                    score20.Text = Convert.ToString(dt1.Rows(0)("Score20"))
                    remark4.Text = Convert.ToString(dt1.Rows(0)("remark4"))
                    actwork.InnerText = Convert.ToString(dt1.Rows(0)("ActualWorkingDays"))
                    actpre.InnerText = Convert.ToString(dt1.Rows(0)("ActualPresentDays"))
                    absent.InnerText = Convert.ToString(dt1.Rows(0)("AbsentDays"))
                    ldr.Text = Convert.ToString(dt1.Rows(0)("ldr"))
                    shead.Text = Convert.ToString(dt1.Rows(0)("Shead"))
                    dhead.Text = Convert.ToString(dt1.Rows(0)("Dhead"))
                    'sshead.Text = Convert.ToString(dt1.Rows(0)("Sshead"))
                    '  amnt1.Text = Convert.ToString(dt1.Rows(0)("Amnt1"))
                    Dim sameas1 As String = Convert.ToString(dt1.Rows(0)("Sameas"))


                    totmarks.Text = Convert.ToString(dt1.Rows(0)("TotalMarks"))
                    Dim Eligibles = Convert.ToString(dt1.Rows(0)("Final_Desition"))
                    If Session("access power") = "3" Then
                        Dim totalScore As Int32 = 0 ' Default score
                        If (Eligibles = "Eligible") Then
                            Eligible.Checked = True
                            ' CheckBox6.Checked = True

                            ' Parse the total marks to an integer
                            Dim marks As Integer
                            If Integer.TryParse(totmarks.Text, marks) Then
                                ' Assign score based on the marks
                                If (marks >= 85) Then
                                    totalScore = 60
                                ElseIf (marks >= 80 AndAlso marks <= 84) Then
                                    totalScore = 40
                                ElseIf (marks >= 76 AndAlso marks <= 79) Then
                                    totalScore = 30
                                ElseIf (marks >= 0 AndAlso marks < 76) Then
                                    totalScore = 0
                                End If

                                ' Calculate the final amount
                                ' Dim finalamount = Convert.ToDouble(actpre.InnerText) * totalScore
                                Dim finalamount As Double = Convert.ToDouble(Math.Floor(Convert.ToDouble(actpre.InnerText))) * totalScore
                                ' Display the calculated final amount
                                famnt1.Text = finalamount

                            End If
                        Else
                            ' If not eligible, set famnt1.Text to "0"
                            famnt1.Text = "0"
                        End If
                    End If
                    If Eligibles = "Not_Eligible" Then
                        Eligible.Checked = False
                        Not_Eligible.Checked = True
                        'CheckBox6.Checked = True
                        famnt1.Text = "0"
                    End If
                    If Eligibles = "Resign" Then
                        Eligible.Checked = False
                        Not_Eligible.Checked = False
                        CheckBox7.Checked = True
                        CheckBox6.Checked = True
                        famnt1.Text = "0"
                    End If
                    If Eligibles = "Disciplinary action" Then
                        CheckBox6.Checked = True
                        CheckBox8.Checked = True
                        famnt1.Text = "0"
                    End If
                    ' Check if the total marks are greater than or equal to 76
                    If (Convert.ToInt32(totmarks.Text) >= 76) Then
                        ' Enable eligibility if condition is met
                        If (Eligibles = "Eligible") Then
                            Eligible.Checked = True
                            'CheckBox6.Checked = True


                            Dim totalScore As Int32 = 0 ' Default score

                            ' Parse the total marks to an integer
                            Dim marks As Integer
                            If Integer.TryParse(totmarks.Text, marks) Then
                                ' Assign score based on the marks
                                If (marks >= 85) Then
                                    totalScore = 60
                                ElseIf (marks >= 80 AndAlso marks <= 84) Then
                                    totalScore = 40
                                ElseIf (marks >= 76 AndAlso marks <= 79) Then
                                    totalScore = 30
                                ElseIf (marks >= 0 AndAlso marks < 76) Then
                                    totalScore = 0
                                End If

                                ' Calculate the final amount
                                ' Dim finalamount = Convert.ToDouble(actpre.InnerText) * totalScore
                                Dim finalamount As Double = Convert.ToDouble(Math.Floor(Convert.ToDouble(actpre.InnerText))) * totalScore

                                ' Display the calculated final amount
                                famnt1.Text = finalamount
                                'Dim a As String = $"update [2024] set famnt='{finalamount}',Amnt1='{finalamount}' where  ( EmployeeCode ='{fst}' or  EmployeeCode ='{sec}') and ReviewMonth='Nov-24' "

                                'If sqlexe(constr, a) Then

                                'End If
                            End If
                        End If

                    End If
                    ' First condition for checking score4, score5, score6, score7
                    If (Convert.ToDecimal(score4.Text) > 0) Or
           (Convert.ToDecimal(score5.Text) > 0) Or
           (Convert.ToDecimal(score6.Text) > 0) Or
           (Convert.ToDecimal(score7.Text) > 0) Then
                        CheckBox3.Checked = True
                        CheckBox1.Checked = True
                    End If

                    ' Second condition for checking score8, score9, score10, score11
                    If (Convert.ToDecimal(score8.Text) > 0) Or
           (Convert.ToDecimal(score9.Text) > 0) Or
           (Convert.ToDecimal(score10.Text) > 0) Or
           (Convert.ToDecimal(score11.Text) > 0) Then
                        CheckBox4.Checked = True
                        CheckBox2.Checked = True
                    End If

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
        Label30.Text = tyear
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

            Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
            If mont <= "12" Then
                month.Checked = True
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
                score13.Text = Convert.ToString(dt1.Rows(0)("Score13"))
                score14.Text = Convert.ToString(dt1.Rows(0)("Score14"))
                score15.Text = Convert.ToString(dt1.Rows(0)("Score15"))
                score16.Text = Convert.ToString(dt1.Rows(0)("Score16"))
                score17.Text = Convert.ToString(dt1.Rows(0)("Score17"))
                score18.Text = Convert.ToString(dt1.Rows(0)("Score18"))
                score19.Text = Convert.ToString(dt1.Rows(0)("Score19"))
                score20.Text = Convert.ToString(dt1.Rows(0)("Score20"))
                remark4.Text = Convert.ToString(dt1.Rows(0)("remark4"))
                actwork.InnerText = Convert.ToString(dt1.Rows(0)("ActualWorkingDays"))
                actpre.InnerText = Convert.ToString(dt1.Rows(0)("ActualPresentDays"))
                absent.InnerText = Convert.ToString(dt1.Rows(0)("AbsentDays"))
                ldr.Text = Convert.ToString(dt1.Rows(0)("ldr"))
                shead.Text = Convert.ToString(dt1.Rows(0)("Shead"))
                dhead.Text = Convert.ToString(dt1.Rows(0)("Dhead"))
                'sshead.Text = Convert.ToString(dt1.Rows(0)("Sshead"))
                Dim sameas1 As String = Convert.ToString(dt1.Rows(0)("Sameas"))

                Dim sincrease1 As String = Convert.ToString(dt1.Rows(0)("Sincrease"))

                Dim sdecrease1 As String = Convert.ToString(dt1.Rows(0)("Sdecrease"))


                'Dim sco8 As Integer = Convert.ToString(dt1.Rows(0)("Score8"))
                'sco8 = Double.Parse(score8.Text)
                'Dim sco9 As Integer = Convert.ToString(dt1.Rows(0)("Score9"))
                'sco9 = Double.Parse(score9.Text)


                totmarks.Text = Convert.ToString(dt1.Rows(0)("TotalMarks"))
                Dim Eligibles = Convert.ToString(dt1.Rows(0)("Final_Desition"))

                If (Convert.ToInt32(totmarks.Text) >= 76) Then
                    If (Eligibles = "Eligible") Then
                        Eligible.Checked = True
                        'CheckBox6.Checked = True
                        Dim totalScore As Int32 = 0
                        Dim marks As Integer
                        If Integer.TryParse(totmarks.Text, marks) Then
                            If (marks >= 85) Then
                                totalScore = 60
                            ElseIf (marks >= 80 AndAlso marks <= 84) Then
                                totalScore = 40
                            ElseIf (marks >= 76 AndAlso marks <= 79) Then
                                totalScore = 30
                            ElseIf (marks >= 0 AndAlso marks < 76) Then
                                totalScore = 0
                            End If
                            'Dim finalamount = Convert.ToDouble(actpre.InnerText) * totalScore
                            Dim finalamount As Double = Convert.ToDouble(Math.Floor(Convert.ToDouble(actpre.InnerText))) * totalScore
                            famnt1.Text = finalamount
                        End If
                    Else
                        famnt1.Text = "0"
                    End If
                End If

                If Eligibles = "Not_Eligible" Then
                    Eligible.Checked = False
                    Not_Eligible.Checked = True
                    'CheckBox6.Checked = True
                    famnt1.Text = "0"
                End If
                If Eligibles = "Resign" Then
                    Eligible.Checked = False
                    Not_Eligible.Checked = False
                    CheckBox7.Checked = True
                    CheckBox6.Checked = True
                    famnt1.Text = "0"
                End If
                If Eligibles = "Disciplinary action" Then
                    CheckBox6.Checked = True
                    CheckBox8.Checked = True
                    famnt1.Text = "0"
                End If
                ' First condition for checking score4, score5, score6, score7
                If (Convert.ToDecimal(score4.Text) > 0) Or
               (Convert.ToDecimal(score5.Text) > 0) Or
               (Convert.ToDecimal(score6.Text) > 0) Or
               (Convert.ToDecimal(score7.Text) > 0) Then
                    CheckBox3.Checked = True
                    CheckBox1.Checked = True
                End If

                ' Second condition for checking score8, score9, score10, score11
                If (Convert.ToDecimal(score8.Text) > 0) Or
               (Convert.ToDecimal(score9.Text) > 0) Or
               (Convert.ToDecimal(score10.Text) > 0) Or
               (Convert.ToDecimal(score11.Text) > 0) Then
                    CheckBox4.Checked = True
                    CheckBox2.Checked = True
                End If



                Dim stat As String = Convert.ToString(dt1.Rows(0)("Status"))
                If stat = "Pass" Then
                    pass.Checked = True

                ElseIf stat = "Extend" Then
                    extend.Checked = True


                End If

            End If
            ' post()

        End If
        'End If
        'End If
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
        Label30.Text = tyear
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
            strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.Text & "',Score12='" & score12.Text & "',Score13='" & score13.Text & "',Score14='" & score14.Text & "', Score15='" & score15.Text & "',Score16='" & score16.Text & "',Score17='" & score17.Text & "',Score18='" & score18.Text & "', Score19='" & score19.Text & "',Score20='" & score20.Text & "',TotalMarks='" & totmarks.Text & "',Famnt='" & famnt1.Text & "',Amnt1='" & famnt1.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='82',Dept_Accept='" & deptaccept & "',Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' ,Final_Desition = '" & Eligible.Text & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

            If sqlexe(constr, strsql) Then

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');", True)
            End If
        End If
    End Sub
    Private Sub amnt()


    End Sub

    Private Sub result()
        Dim Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Tot7, Tot8, Tot9, Tot10, Tot11, Tot12, Tot13, Tot14, Tot15, Tot16, Tot17, Tot18, Tot19, Tot20, Gtot As Double

        ' Helper method for score validation
        Dim validateScore = Sub(scoreField As TextBox, maxValue As Double, ByRef total As Double)
                                If scoreField.Text <> "" Then
                                    If Double.Parse(scoreField.Text) <= maxValue Then
                                        total = Double.Parse(scoreField.Text)
                                        scoreField.BackColor = Color.White
                                        scoreField.ForeColor = Color.Black
                                    Else
                                        scoreField.ForeColor = Color.Red
                                        scoreField.BackColor = Color.Yellow
                                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more than the system % please according to Max fill. 你填寫的百分比高過制度，請重新確認與填寫');", True)
                                    End If
                                End If
                            End Sub

        ' Validate all score fields
        validateScore(score1, 20, Tot1)
        validateScore(score2, 5, Tot2)
        validateScore(score3, 5, Tot3)
        validateScore(score4, 15, Tot4)
        validateScore(score5, 10, Tot5)
        validateScore(score6, 6, Tot6)
        validateScore(score7, 5, Tot7)
        validateScore(score8, 5, Tot8)
        validateScore(score9, 20, Tot9)
        validateScore(score10, 6, Tot10)
        validateScore(score11, 5, Tot11)
        validateScore(score12, 5, Tot12)
        validateScore(score13, 5, Tot13)
        validateScore(score14, 6, Tot14)
        validateScore(score15, 6, Tot15)
        validateScore(score16, 6, Tot16)
        validateScore(score17, 6, Tot17)

        ' Directly assign remaining score values if not empty
        If score18.Text <> "" Then Tot18 = Double.Parse(score18.Text)
        If score19.Text <> "" Then Tot19 = Double.Parse(score19.Text)
        If score20.Text <> "" Then Tot20 = Double.Parse(score20.Text)

        ' Calculate total score including only non-empty scores
        Gtot = Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11 + Tot12 + Tot13 + Tot14 + Tot15 + Tot16 + Tot17 + Tot18 + Tot19 + Tot20

        Dim dotdate As String = Session("DOT").ToString()
        Dim currentDate As DateTime = DateTime.Now

        Try
            Dim dotDateTime As DateTime = DateTime.ParseExact(dotdate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)

            Dim dateDifference As TimeSpan = currentDate.AddMonths(-1) - dotDateTime

            If dateDifference.Days > 365 Then
                totmarks.Text = Gtot.ToString()
                If (totmarks.Text >= "76") Then
                    Eligible.Checked = True
                    Not_Eligible.Checked = False
                Else
                    Eligible.Checked = False
                    Not_Eligible.Checked = True
                End If
                Dim totalScore As Int32 = 0 ' Default score

                Dim marks As Integer
                If Integer.TryParse(totmarks.Text, marks) Then
                    If (marks >= 85) Then
                        totalScore = 60
                    ElseIf (marks >= 80 AndAlso marks <= 84) Then
                        totalScore = 40
                    ElseIf (marks >= 76 AndAlso marks <= 79) Then
                        totalScore = 30
                    ElseIf (marks >= 0 AndAlso marks < 76) Then
                        totalScore = 0
                    End If

                    Dim finalamount As Double = Convert.ToDouble(Math.Floor(Convert.ToDouble(actpre.InnerText))) * totalScore

                    famnt1.Text = finalamount
                End If
            Else
                Not_Eligible.Checked = True
                totmarks.Text = Gtot
                famnt1.Text = 0
            End If
        Catch ex As Exception

        End Try





        'Dim DOT As DateTime
        'Dim dotdate As String = Session("DOT").ToString()
        'Dim currentDate As DateTime = DateTime.Now

        'Dim yearsDifference As Integer = currentDate.Year - DOT.Year
        'If currentDate.Month < DOT.Month OrElse (currentDate.Month = DOT.Month AndAlso currentDate.Day < DOT.Day) Then
        '    yearsDifference -= 1
        'End If
        'If yearsDifference >= 1 Then
        '    totmarks.Text = Gtot.ToString()
        '    If (totmarks.Text >= "76") Then
        '        Eligible.Checked = True
        '        Not_Eligible.Checked = False
        '    Else
        '        Eligible.Checked = False
        '        Not_Eligible.Checked = True
        '    End If
        '    Dim totalScore As Int32 = 0 ' Default score

        '    Dim marks As Integer
        '    If Integer.TryParse(totmarks.Text, marks) Then
        '        If (marks >= 85) Then
        '            totalScore = 60
        '        ElseIf (marks >= 80 AndAlso marks <= 84) Then
        '            totalScore = 40
        '        ElseIf (marks >= 76 AndAlso marks <= 79) Then
        '            totalScore = 30
        '        ElseIf (marks >= 0 AndAlso marks < 76) Then
        '            totalScore = 0
        '        End If

        '        Dim finalamount As Double = Convert.ToDouble(Math.Floor(Convert.ToDouble(actpre.InnerText))) * totalScore

        '        famnt1.Text = finalamount
        '    End If
        'Else
        '    Not_Eligible.Checked = True
        '    totmarks.Text = Gtot
        '    famnt1.Text = 0
        'End If








        ' If total score exceeds 100, adjust and show alert
        If Gtot >= 101 Then
            Gtot = Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11 + Tot12 + Tot13 + Tot14 + Tot15 + Tot16 + Tot17 + Tot18 + Tot19 + Tot20

            ' Highlight scores exceeding limit
            score19.ForeColor = Color.Red
            score19.BackColor = Color.Yellow

            score18.ForeColor = Color.Red
            score18.BackColor = Color.Yellow

            score20.ForeColor = Color.Red
            score20.BackColor = Color.Yellow

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more than the system 100% please according to Max fill. 你填寫的百分比高過制度，請重新確認與填寫');", True)
        Else
            ' Reset the color if within the valid range
            score19.BackColor = Color.White
            score19.ForeColor = Color.Black

            score18.BackColor = Color.White
            score18.ForeColor = Color.Black

            score20.BackColor = Color.White
            score20.ForeColor = Color.Black
        End If

        ' Handle pass/extend logic based on total score
        If Gtot >= 76 Then
            pass.Checked = True
            extend.Checked = False
            extend.Enabled = False
        Else
            extend.Checked = True
            pass.Checked = False
            pass.Enabled = False
        End If

        ' Handle access permissions based on session
        If Session("access power") = "2" Then
            famnt1.Enabled = True
            remark4.Enabled = True
            Eligible.Enabled = True
        ElseIf Session("access power") = "4" Then
            famnt1.Enabled = True
            remark4.Enabled = True
            Eligible.Enabled = True
        End If
    End Sub
    'Private Sub Eligible_CheckedChanged(sender As Object, e As EventArgs) Handles Eligible.CheckedChanged
    '    If Eligible.Checked Then
    '        CheckBox6.Checked = True
    '        Not_Eligible.Checked = False
    '        CheckBox7.Checked = False
    '        CheckBox8.Checked = False
    '    Else
    '        CheckBox6.Checked = False
    '    End If
    'End Sub

    'Private Sub Not_Eligible_CheckedChanged(sender As Object, e As EventArgs) Handles Not_Eligible.CheckedChanged
    '    If Not_Eligible.Checked Then
    '        CheckBox6.Checked = True
    '        Eligible.Checked = False
    '        CheckBox7.Checked = False
    '        CheckBox8.Checked = False
    '        famnt1.Text = "0"
    '    Else
    '        CheckBox6.Checked = False
    '    End If
    'End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked Then
            CheckBox6.Checked = True
            Eligible.Checked = False
            Not_Eligible.Checked = False
            CheckBox8.Checked = False
            famnt1.Text = "0"
        Else
            CheckBox6.Checked = False
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked Then
            CheckBox6.Checked = True
            Eligible.Checked = False
            Not_Eligible.Checked = False
            CheckBox7.Checked = False
            famnt1.Text = "0"
        Else
            CheckBox6.Checked = False
        End If
    End Sub

    Private Sub SetScoresReadOnly(ds As Boolean)
        ' Disable all score fields initially
        score4.ReadOnly = ds
        score5.ReadOnly = ds
        score6.ReadOnly = ds
        score7.ReadOnly = ds
        score8.ReadOnly = ds
        score9.ReadOnly = ds
        score10.ReadOnly = ds
        score11.ReadOnly = ds
    End Sub


    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            ' Enable score fields 4 to 7
            score4.ReadOnly = False
            score5.ReadOnly = False
            score6.ReadOnly = False
            score7.ReadOnly = False

            ' No need to reset values here since the fields are enabled
            CheckBox4.Enabled = False
        Else
            ' Disable score fields 4 to 7 and set them to 0
            score4.ReadOnly = True
            score5.ReadOnly = True
            score6.ReadOnly = True
            score7.ReadOnly = True

            ' Set values to 0 if the fields are read-only
            If score4.ReadOnly Then score4.Text = "0"
            If score5.ReadOnly Then score5.Text = "0"
            If score6.ReadOnly Then score6.Text = "0"
            If score7.ReadOnly Then score7.Text = "0"

            CheckBox4.Enabled = True
        End If
    End Sub


    ' Event handler for Checkbox 4
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            ' Enable score fields 8 to 11
            score8.ReadOnly = False
            score9.ReadOnly = False
            score10.ReadOnly = False
            score11.ReadOnly = False

            ' No need to reset values here since the fields are enabled
            CheckBox3.Enabled = False
        Else
            ' Disable score fields 8 to 11 and set them to 0
            score8.ReadOnly = True
            score9.ReadOnly = True
            score10.ReadOnly = True
            score11.ReadOnly = True

            ' Set values to 0 if the fields are read-only
            If score8.ReadOnly Then score8.Text = "0"
            If score9.ReadOnly Then score9.Text = "0"
            If score10.ReadOnly Then score10.Text = "0"
            If score11.ReadOnly Then score11.Text = "0"

            CheckBox3.Enabled = True
        End If
    End Sub






    Public Sub msg()
        MsgBox("Please enter only numeric 請輸入數字")

    End Sub
    Public Sub fail1()
        If totmarks.Text >= "76" Then
            ' remark4.Enabled = False

        End If

    End Sub
    Public Sub salary1()

    End Sub

    Public Sub salary()

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
            If ch2.Checked = True Then
                sectaccept = "Done"
            End If
            Dim status As String = ""
            If pass.Checked = True Then
                status = "Pass"
            ElseIf extend.Checked = True Then
                status = "Extend"

            End If
            If Eligible.Checked Then
                Eligible.Text = "Eligible"
            End If

            If Not_Eligible.Checked Then
                Eligible.Text = "Not_Eligible"
            End If

            If CheckBox7.Checked Then
                Eligible.Text = "Resign"
            End If

            If CheckBox8.Checked Then
                Eligible.Text = "Disciplinary action"
            End If


            If ch1.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.Text & "',Score12='" & score12.Text & "',Score13='" & score13.Text & "', Score14='" & score14.Text & "',Score15='" & score15.Text & "',Score16='" & score16.Text & "',Score17='" & score17.Text & "',Score18='" & score18.Text & "',Score19='" & score19.Text & "',Score20='" & score20.Text & "', TotalMarks='" & totmarks.Text & "',Famnt='" & famnt1.Text & "',Amnt1='" & famnt1.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='82',Dept_Accept='" & deptaccept & "', Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' ,Final_Desition = '" & Eligible.Text & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');", True)
                End If
            End If
            If ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "',Score13='" & score13.Text & "', Score14='" & score14.Text & "',Score15='" & score15.Text & "',Score16='" & score16.Text & "',Score17='" & score17.Text & "',Score18='" & score18.Text & "',Score19='" & score19.Text & "',Score20='" & score20.Text & "', TotalMarks='" & totmarks.Text & "',Famnt='" & famnt1.Text & "',Amnt1='" & famnt1.Text & "',Status='" & status & "',Form_Status='PENDING',Form_ID='82',Sect_Accept='" & sectaccept & "',Shead = '" & shead.Text & "',Ldr = '" & ldr.Text & "', Dhead = '" & dhead.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  ,Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' ,Final_Desition = '" & Eligible.Text & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');", True)
                End If
            End If
            If ch1.Checked = True And ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "',Score13='" & score13.Text & "', Score14='" & score14.Text & "',Score15='" & score15.Text & "',Score16='" & score16.Text & "',Score17='" & score17.Text & "',Score18='" & score18.Text & "',Score19='" & score19.Text & "',Score20='" & score20.Text & "',  TotalMarks='" & totmarks.Text & "',Famnt='" & famnt1.Text & "',Amnt1='" & famnt1.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='82',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "',Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  ,Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' ,Final_Desition = '" & Eligible.Text & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                End If
            End If
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');", True)
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
            strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done', Empn = '" & empnaccept & "', Empd = '" & empdaccept & "'  ,Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , time  = '" & Time.Text & "',SignPic = '" & picnames & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        Else
            strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done', Empn = '" & empnaccept & "', Empd = '" & empdaccept & "'  ,Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , time  = '" & Time.Text & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        End If


        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');", True)
        End If
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please First ');", True)
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
        If score10.Text.Length > 0 Then
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
                score12.Text = "0"
            End If
        End If
    End Sub

    Protected Sub score13_TextChanged(sender As Object, e As EventArgs) Handles score13.TextChanged
        If score13.Text.Length > 0 Then
            If Not IsNumeric(score13.Text) Then
                msg()
                score13.Text = "0"
            End If
        End If
    End Sub

    Protected Sub score14_TextChanged(sender As Object, e As EventArgs) Handles score14.TextChanged
        If score14.Text.Length > 0 Then
            If Not IsNumeric(score14.Text) Then
                msg()
                score14.Text = "0"
            End If
        End If
    End Sub

    Protected Sub score15_TextChanged(sender As Object, e As EventArgs) Handles score15.TextChanged
        If score15.Text.Length > 0 Then
            If Not IsNumeric(score15.Text) Then
                msg()
                score15.Text = "0"
            End If
        End If
    End Sub

    Protected Sub score16_TextChanged(sender As Object, e As EventArgs) Handles score16.TextChanged
        If score16.Text.Length > 0 Then
            If Not IsNumeric(score16.Text) Then
                msg()
                score16.Text = "0"
            End If
        End If
    End Sub

    Protected Sub score17_TextChanged(sender As Object, e As EventArgs) Handles score17.TextChanged
        If score17.Text.Length > 0 Then
            If Not IsNumeric(score17.Text) Then
                msg()
                score17.Text = "0"
            End If
        End If
    End Sub

    Protected Sub score18_TextChanged(sender As Object, e As EventArgs) Handles score18.TextChanged
        If score18.Text.Length > 0 Then
            If Not IsNumeric(score18.Text) Then
                msg()
                score18.Text = "0"
            End If
        End If
    End Sub

    Protected Sub score19_TextChanged(sender As Object, e As EventArgs) Handles score19.TextChanged
        If score19.Text.Length > 0 Then
            If Not IsNumeric(score19.Text) Then
                msg()
                score19.Text = "0"
            End If
        End If
    End Sub

    Protected Sub score20_TextChanged(sender As Object, e As EventArgs) Handles score20.TextChanged
        If score20.Text.Length > 0 Then
            If Not IsNumeric(score20.Text) Then
                msg()
                score20.Text = "0"
            End If
        End If
    End Sub

    Protected Sub famnt1_TextChanged(sender As Object, e As EventArgs) Handles famnt1.TextChanged
        If famnt1.Text.Length > 0 Then
            If Not IsNumeric(famnt1.Text) Then
                msg()
                famnt1.Text = 0
            End If
        End If
    End Sub

    Protected Sub update_Click(sender As Object, e As EventArgs) Handles update.Click

        up()
    End Sub

    Protected Sub show_Click(sender As Object, e As EventArgs) Handles show.Click
        eve()
    End Sub

End Class