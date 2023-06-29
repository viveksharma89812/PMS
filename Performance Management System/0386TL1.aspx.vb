
'Imports System.Data
'    Imports System.Configuration
'    Imports System.String
'    Imports System.Data.SqlClient
'    Imports System.IO
'    Imports System.IO.Path
'    Imports iTextSharp.text
'    Imports iTextSharp.text.html.simpleparser
'    Imports iTextSharp.text.pdf
'    Imports System.Drawing
'    Imports System.Drawing.Imaging
'Public Class _0386TL1
'    Inherits System.Web.UI.Page
'    Dim strsql As String
'    Dim tot As String

'    Dim mon As String
'    Dim tyear As String
'    Dim amount As String
'    Dim empnaccept As String
'    Dim ldrnaccept As String
'    Dim sheadnaccept As String
'    Dim dheadnaccept As String
'    Dim empdaccept As String
'    Dim ldrdaccept As String
'    Dim sheaddaccept As String
'    Dim dheaddaccept As String
'    Dim empsignaccept As String
'    Dim ldrsignaccept As String
'    Dim sheadsignaccept As String
'    Dim dheadsignaccept As String
'    Dim sameasaccept As String
'    Dim sincreaseaccept As String
'    Dim sdecreaseaccept As String

'    'Private Property score_1 As Integer
'    'Private Property score_2 As Integer
'    'Private Property score_3 As Integer
'    'Private Property score_4 As Integer
'    'Private Property score_5 As Integer
'    'Private Property score_6 As Integer



'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        Try
'            supldr.Checked = False And supldr.Enabled = False
'            q1.Checked = False And q1.Enabled = False
'            q2.Checked = False And q2.Enabled = False
'            q3.Checked = False And q3.Enabled = False
'            q4.Checked = False And q4.Enabled = False
'            If IsPostBack Then
'                result()
'                amnt()
'                salary1()
'                fail1()
'            End If
'            ' fail1()
'            If Session("access power") = "2" Then
'                ch3.Enabled = False
'                ch1.Enabled = True
'                ch2.Enabled = True
'                'fail1()
'                empn.Enabled = False
'                'ldrn.Enabled = True
'                'sheadn.Enabled = True
'                'dheadn.Enabled = True
'                empd.Enabled = False
'                'ldrd.Enabled = True
'                'sheadd.Enabled = True
'                'dheadd.Enabled = True
'                famnt1.Enabled = True
'                famnt.Enabled = True
'                plus.Enabled = True
'                Sub1.Enabled = True
'                remark1.Enabled = False
'                remark2.Enabled = True
'                remark3.Enabled = True
'                remark4.Enabled = True
'                empsign.Enabled = False
'                ldrsign.Enabled = False
'                sheadsign.Enabled = False
'                dheadsign.Enabled = False
'                sameas.Enabled = True
'                sincrease.Enabled = True
'                sdecrease.Enabled = True
'            Else
'                If Session("access power") = "3" Then
'                    'fail1()
'                    empn.Enabled = True
'                    'ldrn.Enabled = False
'                    'sheadn.Enabled = False
'                    'dheadn.Enabled = False
'                    empd.Enabled = True
'                    'ldrd.Enabled = False
'                    'sheadd.Enabled = False
'                    'dheadd.Enabled = False
'                    remark1.Enabled = True
'                    remark2.Enabled = False
'                    remark3.Enabled = False
'                    remark4.Enabled = False
'                    empsign.Enabled = True
'                    ldrsign.Enabled = True
'                    sheadsign.Enabled = True
'                    dheadsign.Enabled = True
'                    famnt1.Enabled = False
'                    famnt.Enabled = False
'                    plus.Enabled = False
'                    Sub1.Enabled = False
'                    Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
'                    ch3.Enabled = True
'                    ch1.Enabled = False
'                    ch2.Enabled = False
'                    sameas.Enabled = False
'                    sincrease.Enabled = False
'                    sdecrease.Enabled = False
'                End If
'            End If

'            strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"

'            If sqlselect(constr, strsql, "Abc") Then
'                If ds.Tables("Abc").Rows.Count > 0 Then
'                    empcode.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
'                    empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
'                    desc.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
'                    Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
'                    Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
'                    doj.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
'                    repto.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
'                    deptsect.Text = dept + "/" + sect
'                    Dim revperiod As String = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
'                    revperiod = revperiod.Trim()
'                    If revperiod = "Training" Then
'                        trai.Checked = "true"
'                        prob.Checked = "false"
'                        conf.Checked = "false"
'                    ElseIf revperiod = "Probation" Then
'                        prob.Checked = "true"
'                        trai.Checked = "false"
'                        conf.Checked = "false"
'                    ElseIf revperiod = "Confirm" Then
'                        conf.Checked = "true"
'                        trai.Checked = "false"
'                        prob.Checked = "false"
'                    End If
'                Else
'                    Response.Write("<script>alert('Your detail not insereted');</script>")
'                End If
'            End If


'            mon = DateTime.Now.AddMonths(-1).ToString("MMM")

'            Dim yea As String = DateTime.Now.Year
'            tyear = DateTime.Now.ToString("yy")
'            If mon = "Dec" Then
'                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
'                tyear = DateTime.Now.AddYears(-1).ToString("yy")
'            End If


'            tyear = mon + "-" + tyear
'            revmonth.Text = tyear
'            Label30.Text = tyear
'            tot = yea
'            tot = "[dbo]" + ". " + "[" + tot + "]"

'            strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
'            If sqlselect(constr, strsql, "Abc") Then

'                revmonth.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
'                Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
'                Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
'                If deptsi = "Done" Then
'                    ch1.Checked = True

'                End If
'                If sectsi = "Done" Then
'                    ch2.Checked = True
'                End If

'                Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
'                If mont <= "12" Then
'                    Month.Checked = True
'                End If
'                If deptsi = "Done" Or sectsi = "Done" Then

'                    score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
'                    score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
'                    score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
'                    score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
'                    score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
'                    score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
'                    score7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
'                    score8.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
'                    score9.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
'                    score10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
'                    score11.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score11"))
'                    score12.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score12"))
'                    score13.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score13"))
'                    score14.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score14"))

'                    ldr.Text = Convert.ToString(ds.Tables(0).Rows(0)("Ldr"))
'                    shead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Shead"))
'                    dhead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dhead"))
'                    'sshead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sshead"))
'                    famnt.Text = Convert.ToString(ds.Tables(0).Rows(0)("Famnt"))
'                    '  amnt1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
'                    amnt2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
'                    Dim empn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empn"))
'                    If empn1 = "No deduct" Then
'                        empn.Checked = True
'                    End If
'                    Dim ldrn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrn"))
'                    If ldrn1 = "No deduct" Then
'                        ldrn.Checked = True
'                    End If
'                    Dim sheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadn"))
'                    If sheadn1 = "No deduct" Then
'                        sheadn.Checked = True
'                    End If
'                    Dim dheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadn"))

'                    If dheadn1 = "No deduct" Then
'                        dheadn.Checked = True

'                    End If
'                    Dim empd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empd"))
'                    If empd1 = "Deduct" Then
'                        empd.Checked = True
'                    End If
'                    Dim ldrd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrd"))
'                    If ldrd1 = "Deduct" Then
'                        ldrd.Checked = True
'                    End If
'                    Dim sheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadd"))
'                    If sheadd1 = "Deduct" Then
'                        sheadd.Checked = True
'                    End If
'                    Dim dheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadd"))
'                    If dheadd1 = "Deduct" Then
'                        dheadd.Checked = True
'                    End If

'                    Dim rem1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Remark1"))
'                    'remark1.Text = rem1
'                    remark2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark2"))
'                    remark3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark3"))
'                    remark4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark4"))
'                    Dim empsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept1"))
'                    If empsign1 = "DONE" Then
'                        empsign.Checked = True
'                    End If
'                    Dim ldrsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept2"))
'                    If ldrsign1 = "DONE" Then
'                        ldrsign.Checked = True
'                    End If
'                    Dim sheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept3"))
'                    If sheadsign1 = "DONE" Then
'                        sheadsign.Checked = True
'                    End If
'                    Dim dheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept4"))
'                    If dheadsign1 = "DONE" Then
'                        dheadsign.Checked = True

'                    End If
'                    Dim sameas1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sameas"))
'                    If sameas1 = "Same As" Then
'                        sameas.Checked = True

'                    End If
'                    Dim sincrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sincrease"))
'                    If sincrease1 = "Salary Increase" Then
'                        sincrease.Checked = True

'                    End If
'                    Dim sdecrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sdecrease"))
'                    If sdecrease1 = "Salary Decrease" Then
'                        sdecrease.Checked = True
'                        ' sdecrease.Attributes.Add("onclick", "return false")
'                    End If




'                    'Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
'                    'sco8 = Double.Parse(score8.Text)
'                    'Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
'                    'sco9 = Double.Parse(score9.Text)


'                    totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
'                    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
'                    If stat = "Pass" Then
'                        pass.Checked = True

'                    ElseIf stat = "Extend" Then
'                        extend.Checked = True


'                    End If
'                End If

'                If Session("form empid") <> "" Then

'                    score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
'                    score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
'                    score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
'                    score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
'                    score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
'                    score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
'                    score7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
'                    score8.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
'                    score9.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
'                    score10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
'                    score11.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score11"))
'                    score12.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score12"))
'                    score13.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score13"))
'                    score14.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score14"))

'                    ldr.Text = Convert.ToString(ds.Tables(0).Rows(0)("Ldr"))
'                    shead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Shead"))
'                    dhead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dhead"))
'                    'sshead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sshead"))
'                    famnt.Text = Convert.ToString(ds.Tables(0).Rows(0)("Famnt"))
'                    '  amnt1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
'                    amnt2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
'                    Dim empn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empn"))
'                    If empn1 = "No deduct" Then
'                        empn.Checked = True
'                    End If
'                    Dim ldrn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrn"))
'                    If ldrn1 = "No deduct" Then
'                        ldrn.Checked = True
'                    End If
'                    Dim sheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadn"))
'                    If sheadn1 = "No deduct" Then
'                        sheadn.Checked = True
'                    End If
'                    Dim dheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadn"))

'                    If dheadn1 = "No deduct" Then
'                        dheadn.Checked = True

'                    End If
'                    Dim empd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empd"))
'                    If empd1 = "Deduct" Then
'                        empd.Checked = True
'                    End If
'                    Dim ldrd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrd"))
'                    If ldrd1 = "Deduct" Then
'                        ldrd.Checked = True
'                    End If
'                    Dim sheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadd"))
'                    If sheadd1 = "Deduct" Then
'                        sheadd.Checked = True
'                    End If
'                    Dim dheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadd"))
'                    If dheadd1 = "Deduct" Then
'                        dheadd.Checked = True
'                    End If

'                    Dim rem1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Remark1"))
'                    'remark1.Text = rem1
'                    remark2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark2"))
'                    remark3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark3"))
'                    remark4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark4"))
'                    Dim empsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept1"))
'                    If empsign1 = "DONE" Then
'                        empsign.Checked = True
'                    End If
'                    Dim ldrsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept2"))
'                    If ldrsign1 = "DONE" Then
'                        ldrsign.Checked = True
'                    End If
'                    Dim sheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept3"))
'                    If sheadsign1 = "DONE" Then
'                        sheadsign.Checked = True
'                    End If
'                    Dim dheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept4"))
'                    If dheadsign1 = "DONE" Then
'                        dheadsign.Checked = True

'                    End If
'                    Dim sameas1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sameas"))
'                    If sameas1 = "Same As" Then
'                        sameas.Checked = True

'                    End If
'                    Dim sincrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sincrease"))
'                    If sincrease1 = "Salary Increase" Then
'                        sincrease.Checked = True

'                    End If
'                    Dim sdecrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sdecrease"))
'                    If sdecrease1 = "Salary Decrease" Then
'                        sdecrease.Checked = True
'                        ' sdecrease.Attributes.Add("onclick", "return false")
'                    End If




'                    'Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
'                    'sco8 = Double.Parse(score8.Text)
'                    'Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
'                    'sco9 = Double.Parse(score9.Text)


'                    totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
'                    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
'                    If stat = "Pass" Then
'                        pass.Checked = True

'                    ElseIf stat = "Extend" Then
'                        extend.Checked = True


'                    End If
'                End If

'            End If
'            ' ViewState["name"] = score1.Text;  
'            ' txtpwd.Attributes.Add("value", ViewState["VsPassword"].ToString());
'        Catch ex As Exception
'            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")

'        End Try
'    End Sub
'    Private Sub amnt()
'        Dim fa As Integer = 0
'        If totmarks.Text <= 76 Then
'            ' amnt1.Text = 300
'            amnt2.Text = 300
'        ElseIf totmarks.Text >= 77 And totmarks.Text <= 85 Then
'            'amnt1.Text = 630
'            amnt2.Text = 630
'        ElseIf totmarks.Text >= 86 And totmarks.Text <= 95 Then
'            'amnt1.Text = 660
'            amnt2.Text = 660
'        ElseIf totmarks.Text >= 96 And totmarks.Text <= 100 Then
'            'amnt1.Text = 690
'            amnt2.Text = 690
'        End If
'        If famnt.Text = "" Then
'            ' famnt.Text = amnt1.Text

'            famnt.Text = amnt2.Text
'        ElseIf famnt1.Text = "" Then
'            famnt.Text = amnt2.Text
'        Else
'            If famnt.Text <> "" Then

'                If plus.Checked = True Then
'                    add1()
'                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Final amount will be Increase');window.close()", True)
'                    plus.Checked = False
'                    Sub1.Checked = False
'                ElseIf Sub1.Checked = True Then
'                    minus1()
'                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Final amount will be Decrease');window.close()", True)
'                    Sub1.Checked = False
'                    plus.Checked = False
'                End If
'            ElseIf plus.Checked = False And Sub1.Checked = False Then

'                'famnt.Text = amnt1.Text
'                famnt.Text = amnt2.Text


'                'famnt1.Text = ""
'                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Final amount will be same as');window.close()", True)

'                'famnt.Text = amnt1.Text
'                famnt1.Text = ""
'            End If

'        End If
'        '    If plus.Checked = True Then
'        '    add1()
'        '    Sub1.Checked = False
'        'ElseIf Sub1.Checked = True Then
'        '    minus1()
'        '    plus.Checked = False
'        'Else
'        '    famnt.Text = amnt1.Text
'        'End If


'    End Sub


'    Public Sub add1()
'        If famnt.Text = "" Then
'            ' amount = Val(amnt1.Text) + Val(famnt1.Text)
'            If (Val(amnt2.Text) + Val(famnt1.Text)) >= 300 And (Val(amnt2.Text) + Val(famnt1.Text)) <= 690 Then
'                ' famnt.Text = amount
'                famnt.Text = (Val(amnt2.Text) + Val(famnt1.Text))
'            Else
'                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please enter a performance (PBVP)  final amount between INR 300 to 690. Otherwise, the Final amount Consider The FIxed PBVP amount.      請輸入介於 300 到 690 盧比之間的績效 (PBVP) 最終金額。否則，最終金額考慮固定 PBVP 金額。');window.close()", True)
'                famnt.Text = amnt2.Text
'            End If
'        Else

'            'amount = Val(famnt.Text) + Val(famnt1.Text)
'            If Val(famnt.Text) + Val(famnt1.Text) >= 300 And Val(famnt.Text) + Val(famnt1.Text) <= 690 Then
'                ' famnt.Text = amount
'                famnt.Text = Val(famnt.Text) + Val(famnt1.Text)
'            Else
'                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please enter a performance (PBVP)  final amount between INR 300 to 690. Otherwise, the Final amount Consider The FIxed PBVP amount.      請輸入介於 300 到 690 盧比之間的績效 (PBVP) 最終金額。否則，最終金額考慮固定 PBVP 金額。');window.close()", True)
'                famnt.Text = amnt2.Text
'            End If
'            ' famnt.Text = amount
'        End If

'    End Sub
'    Public Sub minus1()
'        If famnt.Text = "" Then
'            'famnt.Text = amnt1.Text - famnt1.Text
'            If (amnt2.Text - famnt1.Text) >= 300 And (amnt2.Text - famnt1.Text) <= 690 Then
'                famnt.Text = amnt2.Text - famnt1.Text
'            Else
'                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please enter a performance (PBVP)  final amount between INR 300 to 690. Otherwise, the Final amount Consider The FIxed PBVP amount.      請輸入介於 300 到 690 盧比之間的績效 (PBVP) 最終金額。否則，最終金額考慮固定 PBVP 金額。');window.close()", True)
'                famnt.Text = amnt2.Text
'            End If
'        Else
'            ' amount = famnt.Text - famnt1.Text
'            If (famnt.Text - famnt1.Text) >= 300 And (famnt.Text - famnt1.Text) <= 690 Then
'                famnt.Text = famnt.Text - famnt1.Text
'            Else
'                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please enter a performance (PBVP)  final amount between INR 300 to 690. Otherwise, the Final amount Consider The FIxed PBVP amount.      請輸入介於 300 到 690 盧比之間的績效 (PBVP) 最終金額。否則，最終金額考慮固定 PBVP 金額。');window.close()", True)
'                famnt.Text = amnt2.Text
'            End If
'            'famnt.Text = amount
'        End If
'    End Sub


'    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles add.Click

'    '    add1()
'    '    'famnt.Text = Label31.Text + famnt1.Text
'    'End Sub
'    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles minus.Click
'    '    minus1()


'    ' famnt.Text = Label31.Text - famnt1.Text
'    ' End Sub


'    'Public Sub calscore()
'    '    Dim Cal As Integer
'    '    If score1.Text = "" Then score1.Text = 0
'    '    If score2.Text = "" Then score2.Text = 0
'    '    If score3.Text = "" Then score3.Text = 0
'    '    If score4.Text = "" Then score4.Text = 0
'    '    If score5.Text = "" Then score5.Text = 0
'    '    If score6.Text = "" Then score6.Text = 0



'    '    score_1 = Convert.ToInt32(score1.Text)
'    '    score_2 = Convert.ToInt32(score2.Text)
'    '    score_3 = Convert.ToInt32(score3.Text)
'    '    score_4 = Convert.ToInt32(score4.Text)
'    '    score_5 = Convert.ToInt32(score5.Text)
'    '    score_6 = Convert.ToInt32(score6.Text)

'    '    Cal = (score_1 + score_2 + score_3 + score_4 + score_5 + score_6).ToString

'    '    If Cal >= "76" Then
'    '        pass.Checked = True
'    '        extend.Checked = False
'    '    Else
'    '        extend.Checked = True
'    '        pass.Checked = False
'    '    End If

'    '    totmarks.Text = Cal

'    'End Sub
'    Private Sub result()
'        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Tot7, Tot8, Tot9, Tot10, Tot11, Tot12, Tot13, Gtot As Double
'        If score1.Text <> "" And score1.Text <= 10 Then
'            Tot = Double.Parse(score1.Text)
'            score1.BackColor = Color.White
'            score1.ForeColor = Color.Black
'        Else
'            score1.ForeColor = Color.Red
'            score1.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score2.Text <> "" And score2.Text <= 15 Then
'            Tot1 = Double.Parse(score2.Text)
'            score2.BackColor = Color.White
'            score2.ForeColor = Color.Black
'        Else
'            score2.ForeColor = Color.Red
'            score2.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score3.Text <> "" And score3.Text <= 10 Then
'            Tot2 = Double.Parse(score3.Text)
'            score3.BackColor = Color.White
'            score3.ForeColor = Color.Black
'        Else
'            score3.ForeColor = Color.Red
'            score3.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score4.Text <> "" And score4.Text <= 10 Then
'            Tot3 = Double.Parse(score4.Text)
'            score4.BackColor = Color.White
'            score4.ForeColor = Color.Black
'        Else
'            score4.ForeColor = Color.Red
'            score4.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score5.Text <> "" And score5.Text <= 15 Then
'            Tot4 = Double.Parse(score5.Text)
'            score5.BackColor = Color.White
'            score5.ForeColor = Color.Black
'        Else
'            score5.ForeColor = Color.Red
'            score5.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If


'        If score6.Text <> "" And score6.Text <= 16 Then
'            Tot5 = Double.Parse(score6.Text)
'            score6.BackColor = Color.White
'            score6.ForeColor = Color.Black
'        Else
'            score6.ForeColor = Color.Red
'            score6.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score7.Text <> "" And score7.Text <= 2 Then
'            Tot6 = Double.Parse(score7.Text)
'            score7.BackColor = Color.White
'            score7.ForeColor = Color.Black
'        Else
'            score7.ForeColor = Color.Red
'            score7.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If

'        If score8.Text <> "" And score8.Text <= 2 Then
'            Tot7 = Double.Parse(score8.Text)
'            score8.BackColor = Color.White
'            score8.ForeColor = Color.Black
'        Else
'            score8.ForeColor = Color.Red
'            score8.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score9.Text <> "" And score9.Text <= 4 Then
'            Tot8 = Double.Parse(score9.Text)
'            score9.BackColor = Color.White
'            score9.ForeColor = Color.Black
'        Else
'            score9.ForeColor = Color.Red
'            score9.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score10.Text <> "" And score10.Text <= 2 Then
'            Tot9 = Double.Parse(score10.Text)
'            score10.BackColor = Color.White
'            score10.ForeColor = Color.Black
'        Else
'            score10.ForeColor = Color.Red
'            score10.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        Tot10 = Double.Parse(score11.SelectedIndex)

'        If score11.SelectedIndex = "0" Then
'            Tot10 = "4"
'        ElseIf score11.SelectedIndex = "1" Then
'            Tot10 = "3"
'        ElseIf score11.SelectedIndex = "2" Then
'            Tot10 = "2"
'        ElseIf score11.SelectedIndex = "3" Then
'            Tot10 = "1"
'        Else
'            ' score7.BackColor = Color.MediumPurple
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please select at least one item.');window.close()", True)
'        End If
'        For i As Integer = 0 To score11.Items.Count - 1
'            score11.Items(i).Attributes.Add("onclick", "MutExChkList(this)")

'        Next

'        Tot11 = Double.Parse(score12.SelectedIndex)

'        If score12.SelectedIndex = "0" Then
'            Tot11 = "4"
'        ElseIf score12.SelectedIndex = "1" Then
'            Tot11 = "3"
'        ElseIf score12.SelectedIndex = "2" Then
'            Tot11 = "2"
'        ElseIf score12.SelectedIndex = "3" Then
'            Tot11 = "1"
'        Else
'            ' score7.BackColor = Color.MediumPurple
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please select at least one item.');window.close()", True)
'        End If
'        For i As Integer = 0 To score12.Items.Count - 1
'            score12.Items(i).Attributes.Add("onclick", "MutExChkList(this)")

'        Next


'        Tot12 = Double.Parse(score13.SelectedIndex)

'        If score13.SelectedIndex = "0" Then
'            Tot12 = "4"
'        ElseIf score13.SelectedIndex = "1" Then
'            Tot12 = "3"
'        ElseIf score13.SelectedIndex = "2" Then
'            Tot12 = "2"
'        ElseIf score13.SelectedIndex = "3" Then
'            Tot12 = "1"
'        Else
'            ' score7.BackColor = Color.MediumPurple
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please select at least one item.');window.close()", True)
'        End If
'        For i As Integer = 0 To score13.Items.Count - 1
'            score13.Items(i).Attributes.Add("onclick", "MutExChkList(this)")

'        Next

'        'If score9.Text <> "" Then
'        '        Tot8 = Double.Parse(score9.Text)
'        '    End If
'        If score14.Text <> "" Then
'            Tot13 = Double.Parse(score14.Text)
'        End If
'        '    'If score9.Text <> "" Then
'        '    Tot8 = Double.Parse(score9.Text)
'        'End If
'        'If totmarks.Text <= "76" Then
'        '    If score10.Text = "" Then
'        '        Tot9 = Double.Parse(score10.Text)
'        '    End If
'        '    If score11.Text = "" Then
'        '        Tot10 = Double.Parse(score11.Text)
'        '    End If
'        'End If

'        Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11 + Tot12 + Tot13
'        '+ Tot6 + Tot7 + Tot8 + Tot9 + Tot10
'        If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And score7.Text <> "" And score8.Text <> "" And score9.Text <> "" And score10.Text <> "" And score11.SelectedValue <> "" And score12.SelectedValue <> "" And score13.SelectedValue <> "" Then
'            totmarks.Text = Gtot.ToString
'        End If
'        If totmarks.Text >= 76 Then
'            pass.Checked = True
'            extend.Checked = False And extend.Enabled
'        Else
'            extend.Checked = True
'            pass.Checked = False And pass.Enabled
'        End If
'        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('updated successfully');", True)
'    End Sub
'    Public Sub msg()
'        MsgBox("Please enter only numeric 請輸入數字")

'    End Sub
'    Public Sub fail1()
'        If totmarks.Text <= "76" Then
'            empn.Enabled = True
'            ldrn.Enabled = True
'            sheadn.Enabled = True
'            dheadd.Enabled = True
'            dheadn.Enabled = True
'            empd.Enabled = True
'            ldrd.Enabled = True
'            sheadd.Enabled = True
'            remark1.Enabled = True
'            remark2.Enabled = True
'            remark3.Enabled = True
'            remark4.Enabled = True
'            empsign.Enabled = True
'            ldrsign.Enabled = True
'            sheadsign.Enabled = True
'            dheadsign.Enabled = True
'        Else
'            empn.Enabled = False
'            ldrn.Enabled = False
'            sheadn.Enabled = False
'            dheadd.Enabled = False
'            dheadn.Enabled = False
'            empd.Enabled = False
'            ldrd.Enabled = False
'            sheadd.Enabled = False
'            remark1.Enabled = False
'            remark2.Enabled = False
'            remark3.Enabled = False
'            remark4.Enabled = False
'            empsign.Enabled = False
'            ldrsign.Enabled = False
'            sheadsign.Enabled = False
'            dheadsign.Enabled = False
'        End If
'    End Sub
'    Public Sub salary1()
'        'Dim empnaccept As String = ""
'        'Dim ldrnaccept As String = ""
'        'Dim sheadnaccept As String = ""
'        'Dim dheadnaccept As String = ""
'        'Dim empdaccept As String = ""
'        'Dim ldrdaccept As String = ""
'        'Dim sheaddaccept As String = ""
'        'Dim dheaddaccept As String = ""
'        'Dim empsignaccept As String = ""
'        'Dim ldrsignaccept As String = ""
'        'Dim sheadsignaccept As String = ""
'        'Dim dheadsignaccept As String = ""
'        'Dim sameasaccept As String = ""
'        'Dim sincreaseaccept As String = ""
'        'Dim sdecreaseaccept As String = ""
'        If empn.Checked = True Then
'            empnaccept = "No deduct"
'            empd.Checked = False
'        End If
'        If ldrn.Checked = True Then
'            ldrnaccept = "No deduct"
'            ldrd.Checked = False
'        End If
'        If sheadn.Checked = True Then
'            sheadnaccept = "No deduct"
'            sheadd.Checked = False
'        End If
'        If dheadn.Checked = True Then
'            dheadnaccept = "No deduct"
'            dheadd.Checked = False
'        End If
'        If empd.Checked = True Then
'            empdaccept = "Deduct"
'            empn.Checked = False
'        End If
'        If ldrd.Checked = True Then
'            ldrdaccept = "Deduct"
'            ldrn.Checked = False
'        End If
'        If sheadd.Checked = True Then
'            sheaddaccept = "Deduct"
'            sheadn.Checked = False
'        End If
'        If dheadd.Checked = True Then
'            dheaddaccept = "Deduct"
'            dheadn.Checked = False
'        End If
'        If empsign.Checked = True Then
'            empsignaccept = "Done"
'        End If
'        If ldrsign.Checked = True Then
'            ldrsignaccept = "Done"
'        End If
'        If sheadsign.Checked = True Then
'            sheadsignaccept = "Done"
'        End If
'        If dheadsign.Checked = True Then
'            dheadsignaccept = "Done"
'        End If
'        If sameas.Checked = True Then
'            sameasaccept = "Same As"
'        End If
'        If sincrease.Checked = True Then
'            sincreaseaccept = "Salary Increase"
'        End If
'        If sdecrease.Checked = True Then
'            sdecreaseaccept = "Salary Decrease"
'        End If
'    End Sub

'    Public Sub salary()
'        'fail1()
'        'Dim empnaccept As String = ""
'        'Dim ldrnaccept As String = ""
'        'Dim sheadnaccept As String = ""
'        'Dim dheadnaccept As String = ""
'        'Dim empdaccept As String = ""
'        'Dim ldrdaccept As String = ""
'        'Dim sheaddaccept As String = ""
'        'Dim dheaddaccept As String = ""
'        'Dim empsignaccept As String = ""
'        'Dim ldrsignaccept As String = ""
'        'Dim sheadsignaccept As String = ""
'        'Dim dheadsignaccept As String = ""
'        'If empn.Checked = True Then
'        '    empnaccept = "No deduct"
'        'End If
'        'If ldrn.Checked = True Then
'        '    ldrnaccept = "No deduct"
'        'End If
'        'If sheadn.Checked = True Then
'        '    sheadnaccept = "No deduct"
'        'End If
'        'If dheadn.Checked = True Then
'        '    dheadnaccept = "No deduct"
'        'End If
'        'If empd.Checked = True Then
'        '    empnaccept = "Deduct"
'        'End If
'        'If ldrd.Checked = True Then
'        '    ldrdaccept = "Deduct"
'        'End If
'        'If sheadd.Checked = True Then
'        '    sheaddaccept = "Deduct"
'        'End If
'        'If dheadd.Checked = True Then
'        '    dheaddaccept = "Deduct"
'        'End If
'        'If empsign.Checked = True Then
'        '    empsignaccept = "Done"
'        'End If
'        'If ldrsign.Checked = True Then
'        '    ldrsignaccept = "Done"
'        'End If
'        'If sheadsign.Checked = True Then
'        '    sheadsignaccept = "Done"
'        'End If
'        'If dheadsign.Checked = True Then
'        '    dheadsignaccept = "Done"
'        'End If
'    End Sub
'    Protected Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click
'        Try
'            result()
'            'fail1()
'            'salary()
'            'salary1()
'            'Dim empnaccept As String = ""
'            'Dim ldrnaccept As String = ""
'            'Dim sheadnaccept As String = ""
'            'Dim dheadnaccept As String = ""
'            'Dim empdaccept As String = ""
'            'Dim ldrdaccept As String = ""
'            'Dim sheaddaccept As String = ""
'            'Dim dheaddaccept As String = ""
'            'Dim empsignaccept As String = ""
'            'Dim ldrsignaccept As String = ""
'            'Dim sheadsignaccept As String = ""
'            'Dim dheadsignaccept As String = ""
'            'Dim sameasaccept As String = ""
'            'Dim sincreaseaccept As String = ""
'            'Dim sdecreaseaccept As String = ""

'            'If empn.Checked = True Then
'            '    empnaccept = "No deduct"
'            '    empd.Checked = False And empd.Enabled
'            'End If
'            'If ldrn.Checked = True Then
'            '    ldrnaccept = "No deduct"
'            '    ldrd.Checked = False
'            'End If
'            'If sheadn.Checked = True Then
'            '    sheadnaccept = "No deduct"
'            '    sheadd.Checked = False
'            'End If
'            'If dheadn.Checked = True Then
'            '    dheadnaccept = "No deduct"
'            '    dheadd.Checked = False
'            'End If
'            'If empd.Checked = True Then
'            '    empdaccept = "Deduct"
'            '    empn.Checked = False
'            'End If
'            'If ldrd.Checked = True Then
'            '    ldrdaccept = "Deduct"
'            '    ldrn.Checked = False
'            'End If
'            'If sheadd.Checked = True Then
'            '    sheaddaccept = "Deduct"
'            '    sheadn.Checked = False
'            ''End If
'            'If dheadd.Checked = True Then
'            '    dheaddaccept = "Deduct"
'            '    dheadn.Checked = False
'            'Else
'            '    dheaddaccept = ""
'            'End If
'            'If empsign.Checked = True Then
'            '    empsignaccept = "Done"
'            'End If
'            'If ldrsign.Checked = True Then
'            '    ldrsignaccept = "Done"
'            'End If
'            'If sheadsign.Checked = True Then
'            '    sheadsignaccept = "Done"
'            'End If
'            'If dheadsign.Checked = True Then
'            '    dheadsignaccept = "Done"
'            'End If
'            'If sameas.Checked = True Then
'            '    sameasaccept = "Same As"
'            'End If
'            'If sincrease.Checked = True Then
'            '    sincreaseaccept = "Salary Increase"
'            'End If
'            'If sdecrease.Checked = True Then
'            '    sdecreaseaccept = "Salary Decrease"
'            'End If
'            Dim deptaccept As String = ""
'            Dim sectaccept As String = ""
'            If ch1.Checked = True Then
'                deptaccept = "Done"
'            End If
'            If ch2.Checked = True Then
'                sectaccept = "Done"
'            End If
'            Dim status As String = ""
'            If pass.Checked = True Then
'                status = "Pass"
'            ElseIf extend.Checked = True Then
'                status = "Extend"

'            End If
'            If ch1.Checked = True Then
'                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "',Score8='" & score8.Text & "',Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.SelectedValue & "' , Score12='" & score12.SelectedValue & "', Score13='" & score13.SelectedValue & "',Score14='" & score14.Text & "',  TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='31',Dept_Accept='" & deptaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Famnt = '" & famnt.Text & "' , Amnt1 = '" & amnt2.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark2 = '" & remark2.Text & "' , Remark3 = '" & remark3.Text & "' , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

'                If sqlexe(constr, strsql) Then
'                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
'                End If
'            End If
'            If ch2.Checked = True Then
'                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "',Score8='" & score8.Text & "',Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.SelectedValue & "' , Score12='" & score12.SelectedValue & "', Score13='" & score13.SelectedValue & "',Score14='" & score14.Text & "',  TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='PENDING',Form_ID='31',Sect_Accept='" & sectaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Famnt = '" & famnt.Text & "' , Amnt1 = '" & amnt2.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark2 = '" & remark2.Text & "' , Remark3 = '" & remark3.Text & "' , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

'                If sqlexe(constr, strsql) Then
'                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
'                End If
'            End If
'            If ch1.Checked = True And ch2.Checked = True Then
'                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "',Score8='" & score8.Text & "',Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.SelectedValue & "' , Score12='" & score12.SelectedValue & "', Score13='" & score13.SelectedValue & "',Score14='" & score14.Text & "',  TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='31',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Famnt = '" & famnt.Text & "' , Amnt1 = '" & amnt2.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark2 = '" & remark2.Text & "' , Remark3 = '" & remark3.Text & "' , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

'                If sqlexe(constr, strsql) Then
'                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
'                End If
'            End If


'        Catch ex As Exception
'            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
'        End Try
'    End Sub

'    Protected Sub ch3_CheckedChanged(sender As Object, e As EventArgs) Handles ch3.CheckedChanged
'        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done', Empn = '" & empnaccept & "', Empd = '" & empdaccept & "'  , Remark1 = '" & remark1.Text.ToString() & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , time  = '" & Time.Text & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
'        If sqlexe(constr, strsql) Then
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
'        End If
'    End Sub

'    Protected Sub score1_TextChanged(sender As Object, e As EventArgs) Handles score1.TextChanged

'        If score1.Text.Length > 0 Then
'            If Not IsNumeric(score1.Text) Then
'                msg()
'                score1.Text = 0

'            End If
'        End If
'    End Sub

'    Protected Sub score2_TextChanged(sender As Object, e As EventArgs) Handles score2.TextChanged
'        If score2.Text.Length > 0 Then
'            If Not IsNumeric(score2.Text) Then
'                msg()
'                score2.Text = 0
'            End If
'        End If
'    End Sub

'    Protected Sub score3_TextChanged(sender As Object, e As EventArgs) Handles score3.TextChanged
'        If score3.Text.Length > 0 Then
'            If Not IsNumeric(score3.Text) Then
'                msg()
'                score3.Text = 0
'            End If
'        End If
'    End Sub

'    Protected Sub score4_TextChanged(sender As Object, e As EventArgs) Handles score4.TextChanged


'        If score4.Text.Length > 0 Then
'            If Not IsNumeric(score4.Text) Then
'                msg()
'                score4.Text = 0
'            End If
'        End If
'    End Sub

'    Protected Sub score5_TextChanged(sender As Object, e As EventArgs) Handles score5.TextChanged
'        If score5.Text.Length > 0 Then
'            If Not IsNumeric(score5.Text) Then
'                msg()
'                score5.Text = 0
'            End If
'        End If
'    End Sub

'    Protected Sub score6_TextChanged(sender As Object, e As EventArgs) Handles score6.TextChanged
'        If score6.Text.Length > 0 Then
'            If Not IsNumeric(score6.Text) Then
'                msg()
'                score6.Text = 0
'            End If
'        End If
'    End Sub
'    Protected Sub score7_TextChanged(sender As Object, e As EventArgs) Handles score7.TextChanged
'        If score7.Text.Length > 0 Then
'            If Not IsNumeric(score7.Text) Then
'                msg()
'                score7.Text = 0
'            End If
'        End If
'    End Sub
'    Protected Sub score8_TextChanged(sender As Object, e As EventArgs) Handles score8.TextChanged
'        If score8.Text.Length > 0 Then
'            If Not IsNumeric(score8.Text) Then
'                msg()
'                score8.Text = 0
'            End If
'        End If
'    End Sub
'    Protected Sub score9_TextChanged(sender As Object, e As EventArgs) Handles score9.TextChanged
'        If score9.Text.Length > 0 Then
'            If Not IsNumeric(score9.Text) Then
'                msg()
'                score9.Text = 0
'            End If
'        End If
'    End Sub
'    Protected Sub score10_TextChanged(sender As Object, e As EventArgs) Handles score10.TextChanged
'        If score10.Text.Length > 0 Then
'            If Not IsNumeric(score10.Text) Then
'                msg()
'                score10.Text = 0
'            End If
'        End If
'    End Sub
'    Protected Sub score14_TextChanged(sender As Object, e As EventArgs) Handles score14.TextChanged
'        If score14.Text.Length > 0 Then
'            If Not IsNumeric(score14.Text) Then
'                msg()
'                score14.Text = 0
'            End If
'        End If
'    End Sub


'    Protected Sub famnt_TextChanged(sender As Object, e As EventArgs) Handles famnt.TextChanged
'        If famnt.Text.Length > 0 Then
'            If Not IsNumeric(famnt.Text) Then
'                msg()
'                famnt.Text = 0
'            End If
'        End If
'    End Sub

'    Protected Sub famnt1_TextChanged(sender As Object, e As EventArgs) Handles famnt1.TextChanged
'        If famnt1.Text.Length > 0 Then
'            If Not IsNumeric(famnt1.Text) Then
'                msg()
'                famnt1.Text = 0
'            End If
'        End If
'    End Sub

'    Protected Sub amnt2_TextChanged(sender As Object, e As EventArgs) Handles amnt2.TextChanged
'        famnt.Text = amnt2.Text
'    End Sub



'    'Protected Sub Sub1_CheckedChanged(sender As Object, e As EventArgs) Handles Sub1.CheckedChanged
'    '    minus1()
'    'End Sub

'    'Protected Sub plus_CheckedChanged(sender As Object, e As EventArgs) Handles plus.CheckedChanged
'    '    add1()
'    'End Sub



'    'Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
'    '    ' Verifies that the control is rendered
'    'End Sub

'    'Protected Sub score6_TextChanged(sender As Object, e As EventArgs)
'    '    result()
'    'End Sub



'    'Protected Sub score1_TextChanged(sender As Object, e As EventArgs)
'    '    calscore()
'    'End Sub

'    'Protected Sub score3_TextChanged(sender As Object, e As EventArgs)
'    '    calscore()
'    'End Sub

'    'Protected Sub score6_TextChanged(sender As Object, e As EventArgs)
'    '    calscore()
'    'End Sub

'    'Protected Sub score2_TextChanged(sender As Object, e As EventArgs)
'    '    calscore()
'    'End Sub

'    'Protected Sub score5_TextChanged(sender As Object, e As EventArgs)
'    '    calscore()
'    'End Sub

'    'Protected Sub score4_TextChanged(sender As Object, e As EventArgs)
'    '    calscore()
'    'End Sub
'End Class




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
Public Class _0386TL1
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

    'Private Property score_1 As Integer
    'Private Property score_2 As Integer
    'Private Property score_3 As Integer
    'Private Property score_4 As Integer
    'Private Property score_5 As Integer
    'Private Property score_6 As Integer



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            supldr.Checked = False And supldr.Enabled = False
            q1.Checked = False And q1.Enabled = False
            q2.Checked = False And q2.Enabled = False
            q3.Checked = False And q3.Enabled = False
            q4.Checked = False And q4.Enabled = False
            ' If Session("access power") <> "4" Then
            If IsPostBack Then
                up()
                eve()
                result()
                'post()
                amnt()
                salary1()
                fail1()
                'post()

            Else


                If Session("access power") = "2" Then
                    ch3.Enabled = False
                    ch1.Enabled = False
                    ch2.Enabled = True
                    'fail1()

                    'show.Visible = False
                    'update.Visible = False
                    empn.Enabled = False
                    'ldrn.Enabled = True
                    'sheadn.Enabled = True
                    'dheadn.Enabled = True
                    empd.Enabled = False
                    'ldrd.Enabled = True
                    'sheadd.Enabled = True
                    'dheadd.Enabled = True
                    famnt1.Enabled = True
                    famnt.Enabled = True
                    plus.Enabled = True
                    Sub1.Enabled = True
                    remark1.Enabled = False
                    remark2.Enabled = True
                    remark3.Enabled = True
                    remark4.Enabled = False
                    empsign.Enabled = False
                    ldrsign.Enabled = False
                    sheadsign.Enabled = False
                    dheadsign.Enabled = False
                    sameas.Enabled = False
                    sincrease.Enabled = False
                    sdecrease.Enabled = False
                    dheadn.Enabled = False
                    dheadd.Enabled = False
                    score14.Enabled = False

                ElseIf Session("access power") = "4" Then
                    ch3.Enabled = False
                    score11.Enabled = False
                    score12.Enabled = False
                    score13.Enabled = False
                    ch1.Enabled = True
                    ch2.Enabled = False
                    'fail1()

                    empn.Enabled = False
                    sheadn.Enabled = False
                    sheadd.Enabled = False
                    ldrn.Enabled = False
                    ldrd.Enabled = False
                    'ldrn.Enabled = True
                    'sheadn.Enabled = True
                    'dheadn.Enabled = True
                    empd.Enabled = False
                    'ldrd.Enabled = True
                    'sheadd.Enabled = True
                    'dheadd.Enabled = True
                    famnt1.Enabled = True
                    famnt.Enabled = True
                    plus.Enabled = True
                    Sub1.Enabled = True
                    remark1.Enabled = False
                    remark2.Enabled = False
                    remark3.Enabled = False
                    remark4.Enabled = True
                    empsign.Enabled = False
                    ldrsign.Enabled = False
                    sheadsign.Enabled = False
                    dheadsign.Enabled = False
                    sameas.Enabled = True
                    sincrease.Enabled = True
                    sdecrease.Enabled = True

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

                        'show.Visible = False
                        'update.Visible = False
                        empn.Enabled = True
                        ldrn.Enabled = False
                        sheadn.Enabled = False
                        dheadn.Enabled = False
                        empd.Enabled = True
                        ldrd.Enabled = False
                        sheadd.Enabled = False
                        dheadd.Enabled = False
                        remark1.Enabled = True
                        remark2.Enabled = False
                        remark3.Enabled = False
                        remark4.Enabled = False
                        empsign.Enabled = True
                        ldrsign.Enabled = False
                        sheadsign.Enabled = False
                        dheadsign.Enabled = False
                        famnt1.Enabled = False
                        famnt.Enabled = False
                        plus.Enabled = False
                        Sub1.Enabled = False
                        Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                        ch3.Enabled = True
                        ch1.Enabled = False
                        ch2.Enabled = False
                        sameas.Enabled = False
                        sincrease.Enabled = False
                        sdecrease.Enabled = False

                    End If
                    If Session("access power") = "4" And ch2.Checked = True And ch2.Enabled = False Then
                        show.Visible = True
                        update.Visible = True
                    Else
                        show.Visible = False
                        update.Visible = False
                    End If
                End If

                strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"

                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        empcode.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                        empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                        desc.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                        Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                        Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                        doj.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                        repto.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                        deptsect.Text = dept + "/" + sect
                        Dim revperiod As String = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
                        revperiod = revperiod.Trim()
                        If revperiod = "Training" Then
                            trai.Checked = "true"
                            prob.Checked = "false"
                            conf.Checked = "false"
                        ElseIf revperiod = "Probation" Then
                            prob.Checked = "true"
                            trai.Checked = "false"
                            conf.Checked = "false"
                        ElseIf revperiod = "Confirm" Then
                            conf.Checked = "true"
                            trai.Checked = "false"
                            prob.Checked = "false"
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
                revmonth.Text = tyear
                Label30.Text = tyear
                tot = yea
                tot = "[dbo]" + ". " + "[" + tot + "]"

                strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
                If sqlselect(constr, strsql, "Abc") Then

                    revmonth.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
                    Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
                    Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
                    If deptsi = "Done" Then
                        ch1.Checked = True

                    End If
                    If sectsi = "Done" Then
                        ch2.Checked = True
                    End If

                    Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
                    If mont <= "12" Then
                        Month.Checked = True
                    End If
                    'If Session("access power") <> "4" Then
                    '    If deptsi = "Done" Or sectsi = "Done" Then

                    '        score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    '        score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    '        score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                    '        score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    '        score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    '        score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                    '        score7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
                    '        score8.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                    '        score9.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                    '        score10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))

                    '        ldr.Text = Convert.ToString(ds.Tables(0).Rows(0)("Ldr"))
                    '        shead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Shead"))
                    '        dhead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dhead"))
                    '        'sshead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sshead"))
                    '        famnt.Text = Convert.ToString(ds.Tables(0).Rows(0)("Famnt"))
                    '        '  amnt1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                    '        amnt2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                    '        Dim empn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empn"))
                    '        If empn1 = "No deduct" Then
                    '            empn.Checked = True
                    '        End If
                    '        Dim ldrn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrn"))
                    '        If ldrn1 = "No deduct" Then
                    '            ldrn.Checked = True
                    '        End If
                    '        Dim sheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadn"))
                    '        If sheadn1 = "No deduct" Then
                    '            sheadn.Checked = True
                    '        End If
                    '        Dim dheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadn"))

                    '        If dheadn1 = "No deduct" Then
                    '            dheadn.Checked = True

                    '        End If
                    '        Dim empd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empd"))
                    '        If empd1 = "Deduct" Then
                    '            empd.Checked = True
                    '        End If
                    '        Dim ldrd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrd"))
                    '        If ldrd1 = "Deduct" Then
                    '            ldrd.Checked = True
                    '        End If
                    '        Dim sheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadd"))
                    '        If sheadd1 = "Deduct" Then
                    '            sheadd.Checked = True
                    '        End If
                    '        Dim dheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadd"))
                    '        If dheadd1 = "Deduct" Then
                    '            dheadd.Checked = True
                    '        End If

                    '        Dim rem1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Remark1"))
                    '        'remark1.Text = rem1
                    '        remark2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark2"))
                    '        remark3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark3"))
                    '        remark4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark4"))
                    '        Dim empsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept1"))
                    '        If empsign1 = "DONE" Then
                    '            empsign.Checked = True
                    '        End If
                    '        Dim ldrsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept2"))
                    '        If ldrsign1 = "DONE" Then
                    '            ldrsign.Checked = True
                    '        End If
                    '        Dim sheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept3"))
                    '        If sheadsign1 = "DONE" Then
                    '            sheadsign.Checked = True
                    '        End If
                    '        Dim dheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept4"))
                    '        If dheadsign1 = "DONE" Then
                    '            dheadsign.Checked = True

                    '        End If
                    '        Dim sameas1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sameas"))
                    '        If sameas1 = "Same As" Then
                    '            sameas.Checked = True

                    '        End If
                    '        Dim sincrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sincrease"))
                    '        If sincrease1 = "Salary Increase" Then
                    '            sincrease.Checked = True

                    '        End If
                    '        Dim sdecrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sdecrease"))
                    '        If sdecrease1 = "Salary Decrease" Then
                    '            sdecrease.Checked = True
                    '            ' sdecrease.Attributes.Add("onclick", "return false")
                    '        End If




                    '        'Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                    '        'sco8 = Double.Parse(score8.Text)
                    '        'Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                    '        'sco9 = Double.Parse(score9.Text)


                    '        totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                    '        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                    '        If stat = "Pass" Then
                    '            pass.Checked = True

                    '        ElseIf stat = "Extend" Then
                    '            extend.Checked = True


                    '        End If
                    '    End If
                    'Else
                    '    If deptsi = "Done" Or sectsi = "Done" Then

                    '        score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    '        score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    '        score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                    '        score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    '        score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    '        score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                    '        score7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
                    '        score8.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                    '        score9.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                    '        score10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))

                    '        ldr.Text = Convert.ToString(ds.Tables(0).Rows(0)("Ldr"))
                    '        shead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Shead"))
                    '        dhead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dhead"))
                    '        'sshead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sshead"))
                    '        famnt.Text = Convert.ToString(ds.Tables(0).Rows(0)("Famnt"))
                    '        '  amnt1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                    '        amnt2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                    '        Dim empn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empn"))
                    '        If empn1 = "No deduct" Then
                    '            empn.Checked = True
                    '        End If
                    '        Dim ldrn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrn"))
                    '        If ldrn1 = "No deduct" Then
                    '            ldrn.Checked = True
                    '        End If
                    '        Dim sheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadn"))
                    '        If sheadn1 = "No deduct" Then
                    '            sheadn.Checked = True
                    '        End If
                    '        Dim dheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadn"))

                    '        If dheadn1 = "No deduct" Then
                    '            dheadn.Checked = True

                    '        End If
                    '        Dim empd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empd"))
                    '        If empd1 = "Deduct" Then
                    '            empd.Checked = True
                    '        End If
                    '        Dim ldrd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrd"))
                    '        If ldrd1 = "Deduct" Then
                    '            ldrd.Checked = True
                    '        End If
                    '        Dim sheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadd"))
                    '        If sheadd1 = "Deduct" Then
                    '            sheadd.Checked = True
                    '        End If
                    '        Dim dheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadd"))
                    '        If dheadd1 = "Deduct" Then
                    '            dheadd.Checked = True
                    '        End If

                    '        Dim rem1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Remark1"))
                    '        'remark1.Text = rem1
                    '        remark2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark2"))
                    '        remark3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark3"))
                    '        remark4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark4"))
                    '        Dim empsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept1"))
                    '        If empsign1 = "DONE" Then
                    '            empsign.Checked = True
                    '        End If
                    '        Dim ldrsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept2"))
                    '        If ldrsign1 = "DONE" Then
                    '            ldrsign.Checked = True
                    '        End If
                    '        Dim sheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept3"))
                    '        If sheadsign1 = "DONE" Then
                    '            sheadsign.Checked = True
                    '        End If
                    '        Dim dheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept4"))
                    '        If dheadsign1 = "DONE" Then
                    '            dheadsign.Checked = True

                    '        End If
                    '        Dim sameas1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sameas"))
                    '        If sameas1 = "Same As" Then
                    '            sameas.Checked = True

                    '        End If
                    '        Dim sincrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sincrease"))
                    '        If sincrease1 = "Salary Increase" Then
                    '            sincrease.Checked = True

                    '        End If
                    '        Dim sdecrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sdecrease"))
                    '        If sdecrease1 = "Salary Decrease" Then
                    '            sdecrease.Checked = True
                    '            ' sdecrease.Attributes.Add("onclick", "return false")
                    '        End If




                    '        'Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                    '        'sco8 = Double.Parse(score8.Text)
                    '        'Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                    '        'sco9 = Double.Parse(score9.Text)


                    '        totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                    '        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                    '        If stat = "Pass" Then
                    '            pass.Checked = True

                    '        ElseIf stat = "Extend" Then
                    '            extend.Checked = True


                    '        End If
                    '    End If
                    '    post()
                    '    up()
                    'End If

                    'If IsPostBack = True Then
                    '    eve()
                    'End If

                    If Session("form empid") <> "" Then

                        score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                        score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                        score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                        score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                        score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                        score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                        score7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))

                        score8.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                        score9.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                        score10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
                        score11.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score11"))
                        score12.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score12"))
                        score13.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score13"))
                        score14.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score14"))


                        ldr.Text = Convert.ToString(ds.Tables(0).Rows(0)("Ldr"))
                        shead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Shead"))
                        dhead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dhead"))
                        'sshead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sshead"))
                        famnt.Text = Convert.ToString(ds.Tables(0).Rows(0)("Famnt"))
                        '  amnt1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                        amnt2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                        Dim empn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empn"))
                        If empn1 = "No deduct" Then
                            empn.Checked = True
                        End If
                        Dim ldrn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrn"))
                        If ldrn1 = "No deduct" Then
                            ldrn.Checked = True
                        End If
                        Dim sheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadn"))
                        If sheadn1 = "No deduct" Then
                            sheadn.Checked = True
                        End If
                        Dim dheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadn"))

                        If dheadn1 = "No deduct" Then
                            dheadn.Checked = True

                        End If
                        Dim empd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empd"))
                        If empd1 = "Deduct" Then
                            empd.Checked = True
                        End If
                        Dim ldrd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrd"))
                        If ldrd1 = "Deduct" Then
                            ldrd.Checked = True
                        End If
                        Dim sheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadd"))
                        If sheadd1 = "Deduct" Then
                            sheadd.Checked = True
                        End If
                        Dim dheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadd"))
                        If dheadd1 = "Deduct" Then
                            dheadd.Checked = True
                        End If

                        Dim rem1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Remark1"))
                        'remark1.Text = rem1
                        remark2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark2"))
                        remark3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark3"))
                        remark4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark4"))
                        Dim empsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept1"))
                        If empsign1 = "DONE" Then
                            empsign.Checked = True
                        End If
                        Dim ldrsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept2"))
                        If ldrsign1 = "DONE" Then
                            ldrsign.Checked = True
                        End If
                        Dim sheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept3"))
                        If sheadsign1 = "DONE" Then
                            sheadsign.Checked = True
                        End If
                        Dim dheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept4"))
                        If dheadsign1 = "DONE" Then
                            dheadsign.Checked = True

                        End If
                        Dim sameas1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sameas"))
                        If sameas1 = "Same As" Then
                            sameas.Checked = True

                        End If
                        Dim sincrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sincrease"))
                        If sincrease1 = "Salary Increase" Then
                            sincrease.Checked = True

                        End If
                        Dim sdecrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sdecrease"))
                        If sdecrease1 = "Salary Decrease" Then
                            sdecrease.Checked = True
                            ' sdecrease.Attributes.Add("onclick", "return false")
                        End If




                        'Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                        'sco8 = Double.Parse(score8.Text)
                        'Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                        'sco9 = Double.Parse(score9.Text)


                        totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                        If stat = "Pass" Then
                            pass.Checked = True

                        ElseIf stat = "Extend" Then
                            extend.Checked = True


                        End If
                    End If

                End If
                ' ViewState["name"] = score1.Text;  
                ' txtpwd.Attributes.Add("value", ViewState["VsPassword"].ToString());

            End If
            'If ch2.Checked = True And ch2.Enabled = False Then
            '    show.Visible = True
            '    update.Visible = True
            'Else
            '    show.Visible = False
            '    update.Visible = False
            'End If

            ' End If

            ' fail1()

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

        strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
        If sqlselect(constr, strsql, "Abc") Then

            revmonth.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
            Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
            Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
            If deptsi = "Done" Then
                ch1.Checked = True

            End If
            If sectsi = "Done" Then
                ch2.Checked = True
            End If

            Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
            If mont <= "12" Then
                Month.Checked = True
            End If
            If deptsi = "Done" Or sectsi = "Done" Then

                score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                score7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
                score8.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                score9.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                score10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
                score11.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score11"))
                score12.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score12"))
                score13.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Score13"))
                score14.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score14"))


                ldr.Text = Convert.ToString(ds.Tables(0).Rows(0)("Ldr"))
                shead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Shead"))
                dhead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dhead"))
                'sshead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sshead"))
                famnt.Text = Convert.ToString(ds.Tables(0).Rows(0)("Famnt"))
                '  amnt1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                amnt2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                Dim empn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empn"))
                If empn1 = "No deduct" Then
                    empn.Checked = True
                End If
                Dim ldrn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrn"))
                If ldrn1 = "No deduct" Then
                    ldrn.Checked = True
                End If
                Dim sheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadn"))
                If sheadn1 = "No deduct" Then
                    sheadn.Checked = True
                End If
                Dim dheadn1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadn"))

                If dheadn1 = "No deduct" Then
                    dheadn.Checked = True

                End If
                Dim empd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Empd"))
                If empd1 = "Deduct" Then
                    empd.Checked = True
                End If
                Dim ldrd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Ldrd"))
                If ldrd1 = "Deduct" Then
                    ldrd.Checked = True
                End If
                Dim sheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sheadd"))
                If sheadd1 = "Deduct" Then
                    sheadd.Checked = True
                End If
                Dim dheadd1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Dheadd"))
                If dheadd1 = "Deduct" Then
                    dheadd.Checked = True
                End If

                Dim rem1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Remark1"))
                'remark1.Text = rem1
                remark2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark2"))
                remark3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark3"))
                remark4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark4"))
                Dim empsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept1"))
                If empsign1 = "DONE" Then
                    empsign.Checked = True
                End If
                Dim ldrsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept2"))
                If ldrsign1 = "DONE" Then
                    ldrsign.Checked = True
                End If
                Dim sheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept3"))
                If sheadsign1 = "DONE" Then
                    sheadsign.Checked = True
                End If
                Dim dheadsign1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept4"))
                If dheadsign1 = "DONE" Then
                    dheadsign.Checked = True

                End If
                Dim sameas1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sameas"))
                If sameas1 = "Same As" Then
                    sameas.Checked = True

                End If
                Dim sincrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sincrease"))
                If sincrease1 = "Salary Increase" Then
                    sincrease.Checked = True

                End If
                Dim sdecrease1 As String = Convert.ToString(ds.Tables(0).Rows(0)("Sdecrease"))
                If sdecrease1 = "Salary Decrease" Then
                    sdecrease.Checked = True
                    ' sdecrease.Attributes.Add("onclick", "return false")
                End If




                'Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                'sco8 = Double.Parse(score8.Text)
                'Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                'sco9 = Double.Parse(score9.Text)


                totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
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
        'score1.AutoPostBack = False
        'score2.AutoPostBack = False
        'score3.AutoPostBack = False
        'score4.AutoPostBack = False
        'score5.AutoPostBack = False
        'score6.AutoPostBack = False
        'score7.AutoPostBack = False
        'score8.AutoPostBack = False
        'score9.AutoPostBack = False
        'score10.AutoPostBack = False
        'ch1.AutoPostBack = False
        'ch2.AutoPostBack = False
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
        'Dim s8 As String = score8.SelectedValue
        'Dim s9 As String = score9.SelectedValue
        Dim s10 As String = score10.Text
        Dim s14 As String = score14.Text
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

            strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "',Score8='" & score8.Text & "',Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.SelectedValue & "' , Score12='" & score12.SelectedValue & "', Score13='" & score13.SelectedValue & "',Score14='" & score14.Text & "',  TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='PENDING',Form_ID='31',Dept_Accept='" & deptaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Famnt = '" & famnt.Text & "' , Amnt1 = '" & amnt2.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark2 = '" & remark2.Text & "' , Remark3 = '" & remark3.Text & "' , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then
                result()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
            End If
        End If
    End Sub
    Private Sub amnt()
        Dim fa As Integer = 0
        If totmarks.Text <= 76 Then
            ' amnt1.Text = 300
            amnt2.Text = 300
        ElseIf totmarks.Text >= 77 And totmarks.Text <= 85 Then
            'amnt1.Text = 630
            amnt2.Text = 630
        ElseIf totmarks.Text >= 86 And totmarks.Text <= 95 Then
            'amnt1.Text = 660
            amnt2.Text = 660
        ElseIf totmarks.Text >= 96 And totmarks.Text <= 100 Then
            'amnt1.Text = 690
            amnt2.Text = 690
        End If
        If famnt.Text = "" Then
            ' famnt.Text = amnt1.Text

            famnt.Text = amnt2.Text
        ElseIf famnt1.Text = "" Then
            famnt.Text = amnt2.Text
        Else
            If famnt.Text <> "" Then

                If plus.Checked = True Then
                    add1()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Final amount will be Increase');window.close()", True)
                    plus.Checked = False
                    Sub1.Checked = False
                ElseIf Sub1.Checked = True Then
                    minus1()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Final amount will be Decrease');window.close()", True)
                    Sub1.Checked = False
                    plus.Checked = False
                End If
            ElseIf plus.Checked = False And Sub1.Checked = False Then

                'famnt.Text = amnt1.Text
                famnt.Text = amnt2.Text


                'famnt1.Text = ""
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Final amount will be same as');window.close()", True)

                'famnt.Text = amnt1.Text
                famnt1.Text = ""
            End If

        End If
        '    If plus.Checked = True Then
        '    add1()
        '    Sub1.Checked = False
        'ElseIf Sub1.Checked = True Then
        '    minus1()
        '    plus.Checked = False
        'Else
        '    famnt.Text = amnt1.Text
        'End If


    End Sub


    Public Sub add1()
        If famnt.Text = "" Then
            ' amount = Val(amnt1.Text) + Val(famnt1.Text)
            If (Val(amnt2.Text) + Val(famnt1.Text)) >= 300 And (Val(amnt2.Text) + Val(famnt1.Text)) <= 690 Then
                ' famnt.Text = amount
                famnt.Text = (Val(amnt2.Text) + Val(famnt1.Text))
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please enter a performance (PBVP)  final amount between INR 300 to 690. Otherwise, the Final amount Consider The FIxed PBVP amount.      請輸入介於 300 到 690 盧比之間的績效 (PBVP) 最終金額。否則，最終金額考慮固定 PBVP 金額。');window.close()", True)
                famnt.Text = amnt2.Text
            End If
        Else

            'amount = Val(famnt.Text) + Val(famnt1.Text)
            If Val(famnt.Text) + Val(famnt1.Text) >= 300 And Val(famnt.Text) + Val(famnt1.Text) <= 690 Then
                ' famnt.Text = amount
                famnt.Text = Val(famnt.Text) + Val(famnt1.Text)
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please enter a performance (PBVP)  final amount between INR 300 to 690. Otherwise, the Final amount Consider The FIxed PBVP amount.      請輸入介於 300 到 690 盧比之間的績效 (PBVP) 最終金額。否則，最終金額考慮固定 PBVP 金額。');window.close()", True)
                famnt.Text = amnt2.Text
            End If
            ' famnt.Text = amount
        End If

    End Sub
    Public Sub minus1()
        If famnt.Text = "" Then
            'famnt.Text = amnt1.Text - famnt1.Text
            If (amnt2.Text - famnt1.Text) >= 300 And (amnt2.Text - famnt1.Text) <= 690 Then
                famnt.Text = amnt2.Text - famnt1.Text
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please enter a performance (PBVP)  final amount between INR 300 to 690. Otherwise, the Final amount Consider The FIxed PBVP amount.      請輸入介於 300 到 690 盧比之間的績效 (PBVP) 最終金額。否則，最終金額考慮固定 PBVP 金額。');window.close()", True)
                famnt.Text = amnt2.Text
            End If
        Else
            ' amount = famnt.Text - famnt1.Text
            If (famnt.Text - famnt1.Text) >= 300 And (famnt.Text - famnt1.Text) <= 690 Then
                famnt.Text = famnt.Text - famnt1.Text
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please enter a performance (PBVP)  final amount between INR 300 to 690. Otherwise, the Final amount Consider The FIxed PBVP amount.      請輸入介於 300 到 690 盧比之間的績效 (PBVP) 最終金額。否則，最終金額考慮固定 PBVP 金額。');window.close()", True)
                famnt.Text = amnt2.Text
            End If
            'famnt.Text = amount
        End If
    End Sub


    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles add.Click

    '    add1()
    '    'famnt.Text = Label31.Text + famnt1.Text
    'End Sub
    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles minus.Click
    '    minus1()


    ' famnt.Text = Label31.Text - famnt1.Text
    ' End Sub


    'Public Sub calscore()
    '    Dim Cal As Integer
    '    If score1.Text = "" Then score1.Text = 0
    '    If score2.Text = "" Then score2.Text = 0
    '    If score3.Text = "" Then score3.Text = 0
    '    If score4.Text = "" Then score4.Text = 0
    '    If score5.Text = "" Then score5.Text = 0
    '    If score6.Text = "" Then score6.Text = 0



    '    score_1 = Convert.ToInt32(score1.Text)
    '    score_2 = Convert.ToInt32(score2.Text)
    '    score_3 = Convert.ToInt32(score3.Text)
    '    score_4 = Convert.ToInt32(score4.Text)
    '    score_5 = Convert.ToInt32(score5.Text)
    '    score_6 = Convert.ToInt32(score6.Text)

    '    Cal = (score_1 + score_2 + score_3 + score_4 + score_5 + score_6).ToString

    '    If Cal >= "76" Then
    '        pass.Checked = True
    '        extend.Checked = False
    '    Else
    '        extend.Checked = True
    '        pass.Checked = False
    '    End If

    '    totmarks.Text = Cal

    'End Sub
    Private Sub result()
        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Tot7, Tot8, Tot9, Tot10, Tot11, Tot12, Tot13, Gtot As Double
        If score1.Text <> "" And score1.Text <= 10 Then
            Tot = Double.Parse(score1.Text)
            score1.BackColor = Color.White
            score1.ForeColor = Color.Black
        Else
            score1.ForeColor = Color.Red
            score1.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score2.Text <> "" And score2.Text <= 15 Then
            Tot1 = Double.Parse(score2.Text)
            score2.BackColor = Color.White
            score2.ForeColor = Color.Black
        Else
            score2.ForeColor = Color.Red
            score2.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score3.Text <> "" And score3.Text <= 10 Then
            Tot2 = Double.Parse(score3.Text)
            score3.BackColor = Color.White
            score3.ForeColor = Color.Black
        Else
            score3.ForeColor = Color.Red
            score3.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score4.Text <> "" And score4.Text <= 10 Then
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


        If score6.Text <> "" And score6.Text <= 16 Then
            Tot5 = Double.Parse(score6.Text)
            score6.BackColor = Color.White
            score6.ForeColor = Color.Black
        Else
            score6.ForeColor = Color.Red
            score6.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score7.Text <> "" And score7.Text <= 2 Then
            Tot6 = Double.Parse(score7.Text)
            score7.BackColor = Color.White
            score7.ForeColor = Color.Black
        Else
            score7.ForeColor = Color.Red
            score7.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If

        If score8.Text <> "" And score8.Text <= 2 Then
            Tot7 = Double.Parse(score8.Text)
            score8.BackColor = Color.White
            score8.ForeColor = Color.Black
        Else
            score8.ForeColor = Color.Red
            score8.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score9.Text <> "" And score9.Text <= 4 Then
            Tot8 = Double.Parse(score9.Text)
            score9.BackColor = Color.White
            score9.ForeColor = Color.Black
        Else
            score9.ForeColor = Color.Red
            score9.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        If score10.Text <> "" And score10.Text <= 2 Then
            Tot9 = Double.Parse(score10.Text)
            score10.BackColor = Color.White
            score10.ForeColor = Color.Black
        Else
            score10.ForeColor = Color.Red
            score10.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        End If
        Tot10 = Double.Parse(score11.SelectedIndex)

        If score11.SelectedIndex = "0" Then
            Tot10 = "4"
        ElseIf score11.SelectedIndex = "1" Then
            Tot10 = "3"
        ElseIf score11.SelectedIndex = "2" Then
            Tot10 = "2"
        ElseIf score11.SelectedIndex = "3" Then
            Tot10 = "1"
        Else
            ' score7.BackColor = Color.MediumPurple
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please select at least one item.');window.close()", True)
        End If
        For i As Integer = 0 To score11.Items.Count - 1
            score11.Items(i).Attributes.Add("onclick", "MutExChkList(this)")

        Next

        Tot11 = Double.Parse(score12.SelectedIndex)

        If score12.SelectedIndex = "0" Then
            Tot11 = "4"
        ElseIf score12.SelectedIndex = "1" Then
            Tot11 = "3"
        ElseIf score12.SelectedIndex = "2" Then
            Tot11 = "2"
        ElseIf score12.SelectedIndex = "3" Then
            Tot11 = "1"
        Else
            ' score7.BackColor = Color.MediumPurple
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please select at least one item.');window.close()", True)
        End If
        For i As Integer = 0 To score12.Items.Count - 1
            score12.Items(i).Attributes.Add("onclick", "MutExChkList(this)")

        Next


        Tot12 = Double.Parse(score13.SelectedIndex)

        If score13.SelectedIndex = "0" Then
            Tot12 = "4"
        ElseIf score13.SelectedIndex = "1" Then
            Tot12 = "3"
        ElseIf score13.SelectedIndex = "2" Then
            Tot12 = "2"
        ElseIf score13.SelectedIndex = "3" Then
            Tot12 = "1"
        Else
            ' score7.BackColor = Color.MediumPurple
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please select at least one item.');window.close()", True)
        End If
        For i As Integer = 0 To score13.Items.Count - 1
            score13.Items(i).Attributes.Add("onclick", "MutExChkList(this)")

        Next

        'If score9.Text <> "" Then
        '        Tot8 = Double.Parse(score9.Text)
        '    End If
        If score14.Text <> "" Then
            Tot13 = Double.Parse(score14.Text)
        End If
        '    'If score9.Text <> "" Then
        '    Tot8 = Double.Parse(score9.Text)
        'End If
        'If totmarks.Text <= "76" Then
        '    If score10.Text = "" Then
        '        Tot9 = Double.Parse(score10.Text)
        '    End If
        '    If score11.Text = "" Then
        '        Tot10 = Double.Parse(score11.Text)
        '    End If
        'End If

        Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11 + Tot12 + Tot13
        '+ Tot6 + Tot7 + Tot8 + Tot9 + Tot10
        If Gtot >= 101 Then
            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11 + Tot12
            score14.ForeColor = Color.Red
            score14.BackColor = Color.Yellow
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system 100% please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)

        Else
            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11 + Tot12 + Tot13
            score14.BackColor = Color.White
            score14.ForeColor = Color.Black
            If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And score7.Text <> "" And score8.Text <> "" And score9.Text <> "" And score10.Text <> "" And score11.SelectedValue <> "" And score12.SelectedValue <> "" And score13.SelectedValue <> "" Then
                totmarks.Text = Gtot.ToString
            End If
        End If
        If totmarks.Text >= 76 Then
            pass.Checked = True
            extend.Checked = False And extend.Enabled
        Else
            extend.Checked = True
            pass.Checked = False And pass.Enabled
        End If
        'If totmarks.Text >= 100 Then
        '    totmarks.Text = totmarks.Text
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system 100% please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
        'End If

        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('updated successfully');", True)
    End Sub
    Public Sub msg()
        MsgBox("Please enter only numeric 請輸入數字")

    End Sub
    Public Sub fail1()
        If totmarks.Text >= "76" Then
            empn.Enabled = False
            ldrn.Enabled = False
            sheadn.Enabled = False
            dheadd.Enabled = False
            dheadn.Enabled = False
            empd.Enabled = False
            ldrd.Enabled = False
            sheadd.Enabled = False
            remark1.Enabled = False
            remark2.Enabled = False
            remark3.Enabled = False
            remark4.Enabled = False
            empsign.Enabled = False
            ldrsign.Enabled = False
            sheadsign.Enabled = False
            dheadsign.Enabled = False


        End If
        'If totmarks.Text <= "76" Then
        '    empn.Enabled = True
        '    ldrn.Enabled = True
        '    sheadn.Enabled = True
        '    dheadd.Enabled = True
        '    dheadn.Enabled = True
        '    empd.Enabled = True
        '    ldrd.Enabled = True
        '    sheadd.Enabled = True
        '    remark1.Enabled = True
        '    remark2.Enabled = True
        '    remark3.Enabled = True
        '    remark4.Enabled = True
        '    empsign.Enabled = True
        '    ldrsign.Enabled = True
        '    sheadsign.Enabled = True
        '    dheadsign.Enabled = True
        'Else
        '    empn.Enabled = False
        '    ldrn.Enabled = False
        '    sheadn.Enabled = False
        '    dheadd.Enabled = False
        '    dheadn.Enabled = False
        '    empd.Enabled = False
        '    ldrd.Enabled = False
        '    sheadd.Enabled = False
        '    remark1.Enabled = False
        '    remark2.Enabled = False
        '    remark3.Enabled = False
        '    remark4.Enabled = False
        '    empsign.Enabled = False
        '    ldrsign.Enabled = False
        '    sheadsign.Enabled = False
        '    dheadsign.Enabled = False
        'End If
    End Sub
    Public Sub salary1()
        'Dim empnaccept As String = ""
        'Dim ldrnaccept As String = ""
        'Dim sheadnaccept As String = ""
        'Dim dheadnaccept As String = ""
        'Dim empdaccept As String = ""
        'Dim ldrdaccept As String = ""
        'Dim sheaddaccept As String = ""
        'Dim dheaddaccept As String = ""
        'Dim empsignaccept As String = ""
        'Dim ldrsignaccept As String = ""
        'Dim sheadsignaccept As String = ""
        'Dim dheadsignaccept As String = ""
        'Dim sameasaccept As String = ""
        'Dim sincreaseaccept As String = ""
        'Dim sdecreaseaccept As String = ""
        If empn.Checked = True Then
            empnaccept = "No deduct"
            empd.Checked = False
        End If
        If ldrn.Checked = True Then
            ldrnaccept = "No deduct"
            ldrd.Checked = False
        End If
        If sheadn.Checked = True Then
            sheadnaccept = "No deduct"
            sheadd.Checked = False
        End If
        If dheadn.Checked = True Then
            dheadnaccept = "No deduct"
            dheadd.Checked = False
        End If
        If empd.Checked = True Then
            empdaccept = "Deduct"
            empn.Checked = False
        End If
        If ldrd.Checked = True Then
            ldrdaccept = "Deduct"
            ldrn.Checked = False
        End If
        If sheadd.Checked = True Then
            sheaddaccept = "Deduct"
            sheadn.Checked = False
        End If
        If dheadd.Checked = True Then
            dheaddaccept = "Deduct"
            dheadn.Checked = False
        End If
        If empsign.Checked = True Then
            empsignaccept = "Done"
        End If
        If ldrsign.Checked = True Then
            ldrsignaccept = "Done"
        End If
        If sheadsign.Checked = True Then
            sheadsignaccept = "Done"
        End If
        If dheadsign.Checked = True Then
            dheadsignaccept = "Done"
        End If
        If sameas.Checked = True Then
            sameasaccept = "Same As"
        End If
        If sincrease.Checked = True Then
            sincreaseaccept = "Salary Increase"
        End If
        If sdecrease.Checked = True Then
            sdecreaseaccept = "Salary Decrease"
        End If
    End Sub

    Public Sub salary()
        'fail1()
        'Dim empnaccept As String = ""
        'Dim ldrnaccept As String = ""
        'Dim sheadnaccept As String = ""
        'Dim dheadnaccept As String = ""
        'Dim empdaccept As String = ""
        'Dim ldrdaccept As String = ""
        'Dim sheaddaccept As String = ""
        'Dim dheaddaccept As String = ""
        'Dim empsignaccept As String = ""
        'Dim ldrsignaccept As String = ""
        'Dim sheadsignaccept As String = ""
        'Dim dheadsignaccept As String = ""
        'If empn.Checked = True Then
        '    empnaccept = "No deduct"
        'End If
        'If ldrn.Checked = True Then
        '    ldrnaccept = "No deduct"
        'End If
        'If sheadn.Checked = True Then
        '    sheadnaccept = "No deduct"
        'End If
        'If dheadn.Checked = True Then
        '    dheadnaccept = "No deduct"
        'End If
        'If empd.Checked = True Then
        '    empnaccept = "Deduct"
        'End If
        'If ldrd.Checked = True Then
        '    ldrdaccept = "Deduct"
        'End If
        'If sheadd.Checked = True Then
        '    sheaddaccept = "Deduct"
        'End If
        'If dheadd.Checked = True Then
        '    dheaddaccept = "Deduct"
        'End If
        'If empsign.Checked = True Then
        '    empsignaccept = "Done"
        'End If
        'If ldrsign.Checked = True Then
        '    ldrsignaccept = "Done"
        'End If
        'If sheadsign.Checked = True Then
        '    sheadsignaccept = "Done"
        'End If
        'If dheadsign.Checked = True Then
        '    dheadsignaccept = "Done"
        'End If
    End Sub
    Protected Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click
        Try
            'If Session("access power") = "4" Then
            '    up()
            'End If
            result()
            'fail1()
            'salary()
            'salary1()
            'Dim empnaccept As String = ""
            'Dim ldrnaccept As String = ""
            'Dim sheadnaccept As String = ""
            'Dim dheadnaccept As String = ""
            'Dim empdaccept As String = ""
            'Dim ldrdaccept As String = ""
            'Dim sheaddaccept As String = ""
            'Dim dheaddaccept As String = ""
            'Dim empsignaccept As String = ""
            'Dim ldrsignaccept As String = ""
            'Dim sheadsignaccept As String = ""
            'Dim dheadsignaccept As String = ""
            'Dim sameasaccept As String = ""
            'Dim sincreaseaccept As String = ""
            'Dim sdecreaseaccept As String = ""

            'If empn.Checked = True Then
            '    empnaccept = "No deduct"
            '    empd.Checked = False And empd.Enabled
            'End If
            'If ldrn.Checked = True Then
            '    ldrnaccept = "No deduct"
            '    ldrd.Checked = False
            'End If
            'If sheadn.Checked = True Then
            '    sheadnaccept = "No deduct"
            '    sheadd.Checked = False
            'End If
            'If dheadn.Checked = True Then
            '    dheadnaccept = "No deduct"
            '    dheadd.Checked = False
            'End If
            'If empd.Checked = True Then
            '    empdaccept = "Deduct"
            '    empn.Checked = False
            'End If
            'If ldrd.Checked = True Then
            '    ldrdaccept = "Deduct"
            '    ldrn.Checked = False
            'End If
            'If sheadd.Checked = True Then
            '    sheaddaccept = "Deduct"
            '    sheadn.Checked = False
            ''End If
            'If dheadd.Checked = True Then
            '    dheaddaccept = "Deduct"
            '    dheadn.Checked = False
            'Else
            '    dheaddaccept = ""
            'End If
            'If empsign.Checked = True Then
            '    empsignaccept = "Done"
            'End If
            'If ldrsign.Checked = True Then
            '    ldrsignaccept = "Done"
            'End If
            'If sheadsign.Checked = True Then
            '    sheadsignaccept = "Done"
            'End If
            'If dheadsign.Checked = True Then
            '    dheadsignaccept = "Done"
            'End If
            'If sameas.Checked = True Then
            '    sameasaccept = "Same As"
            'End If
            'If sincrease.Checked = True Then
            '    sincreaseaccept = "Salary Increase"
            'End If
            'If sdecrease.Checked = True Then
            '    sdecreaseaccept = "Salary Decrease"
            'End If
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
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "',Score8='" & score8.Text & "',Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.SelectedValue & "' , Score12='" & score12.SelectedValue & "', Score13='" & score13.SelectedValue & "',Score14='" & score14.Text & "',  TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='31',Dept_Accept='" & deptaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Famnt = '" & famnt.Text & "' , Amnt1 = '" & amnt2.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark2 = '" & remark2.Text & "' , Remark3 = '" & remark3.Text & "' , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                End If
            End If
            If ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "',Score8='" & score8.Text & "',Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.SelectedValue & "' , Score12='" & score12.SelectedValue & "', Score13='" & score13.SelectedValue & "',Score14='" & score14.Text & "',  TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='PENDING',Form_ID='31',Sect_Accept='" & sectaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Famnt = '" & famnt.Text & "' , Amnt1 = '" & amnt2.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark2 = '" & remark2.Text & "' , Remark3 = '" & remark3.Text & "' , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                End If
            End If
            If ch1.Checked = True And ch2.Checked = True Then
                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "',Score8='" & score8.Text & "',Score9='" & score9.Text & "',Score10='" & score10.Text & "', Score11='" & score11.SelectedValue & "' , Score12='" & score12.SelectedValue & "', Score13='" & score13.SelectedValue & "',Score14='" & score14.Text & "',  TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='31',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Famnt = '" & famnt.Text & "' , Amnt1 = '" & amnt2.Text & "' ,Empn = '" & empnaccept & "', Ldrn = '" & ldrnaccept & "', Sheadn = '" & sheadnaccept & "' , Dheadn = '" & dheadnaccept & "' , Empd = '" & empdaccept & "' , Ldrd = '" & ldrdaccept & "', Sheadd = '" & sheaddaccept & "' , Dheadd = '" & dheaddaccept & "'  , Remark2 = '" & remark2.Text & "' , Remark3 = '" & remark3.Text & "' , Remark4 = '" & remark4.Text & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , Sameas = '" & sameasaccept & "', Sincrease ='" & sincreaseaccept & "' , Sdecrease = '" & sdecreaseaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

                If sqlexe(constr, strsql) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                End If
            End If


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try

    End Sub

    Protected Sub ch3_CheckedChanged(sender As Object, e As EventArgs) Handles ch3.CheckedChanged
        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done', Empn = '" & empnaccept & "', Empd = '" & empdaccept & "'  , Remark1 = '" & remark1.Text.ToString() & "' , Emp_Accept1 = '" & empsignaccept & "' , Emp_Accept2 = '" & ldrsignaccept & "', Emp_Accept3 = '" & sheadsignaccept & "' ,Emp_Accept4 = '" & dheadsignaccept & "' , time  = '" & Time.Text & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
        End If
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
    Protected Sub score14_TextChanged(sender As Object, e As EventArgs) Handles score14.TextChanged
        If score14.Text.Length > 0 Then
            If Not IsNumeric(score14.Text) Then
                msg()
                score14.Text = 0
            End If
        End If
    End Sub

    Protected Sub famnt_TextChanged(sender As Object, e As EventArgs) Handles famnt.TextChanged
        If famnt.Text.Length > 0 Then
            If Not IsNumeric(famnt.Text) Then
                msg()
                famnt.Text = 0
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

    Protected Sub amnt2_TextChanged(sender As Object, e As EventArgs) Handles amnt2.TextChanged
        famnt.Text = amnt2.Text
    End Sub

    Protected Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
        'If Page.IsPostBack = True Then
        '    post()
        'End If
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
        'Dim s8 As String = score8.SelectedValue
        'Dim s9 As String = score9.SelectedValue
        Dim s14 As String = score14.Text

        up()
    End Sub



    'Protected Sub Sub1_CheckedChanged(sender As Object, e As EventArgs) Handles Sub1.CheckedChanged
    '    minus1()
    'End Sub

    'Protected Sub plus_CheckedChanged(sender As Object, e As EventArgs) Handles plus.CheckedChanged
    '    add1()
    'End Sub



    'Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    '    'Verifies that the control Is rendered
    'End Sub

    Protected Sub show_Click(sender As Object, e As EventArgs) Handles show.Click
        eve()
    End Sub



    'Protected Sub score6_TextChanged(sender As Object, e As EventArgs)
    '    result()
    'End Sub



    'Protected Sub score1_TextChanged(sender As Object, e As EventArgs)
    '    calscore()
    'End Sub

    'Protected Sub score3_TextChanged(sender As Object, e As EventArgs)
    '    calscore()
    'End Sub

    'Protected Sub score6_TextChanged(sender As Object, e As EventArgs)
    '    calscore()
    'End Sub

    'Protected Sub score2_TextChanged(sender As Object, e As EventArgs)
    '    calscore()
    'End Sub

    'Protected Sub score5_TextChanged(sender As Object, e As EventArgs)
    '    calscore()
    'End Sub

    'Protected Sub score4_TextChanged(sender As Object, e As EventArgs)
    '    calscore()
    'End Sub
End Class