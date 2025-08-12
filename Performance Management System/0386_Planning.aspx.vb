
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

Public Class _0386_Planning
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
                result()
            End If

            If Session("access power") = "2" Then
                empsign.Enabled = False
                deptsign.Enabled = True
                sectsign.Enabled = True
            Else
                If Session("access power") = "3" Then
                    empsign.Enabled = True
                    deptsign.Enabled = False
                    sectsign.Enabled = False
                End If
            End If
            check()
            'strsql = "select * from Employee_Master where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"
            strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"

            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    empcode.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                    empname.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    desc.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                    Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                    Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                    doj.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                    Dim qualification As String = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                    Dim preexperience As String = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                    repto.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                    deptsect.InnerText = dept + "/" + sect
                Else
                    Label21.Visible = "true"
                    Label21.Text = "Your detail not insereted "
                End If
            End If
            'mon = DateTime.Now.AddMonths(-3).ToString("MMM")
            mon = DateTime.Now.AddMonths(-1).ToString("MMM")
            Dim yea As String = DateTime.Now.Year
            tyear = DateTime.Now.ToString("yy")
            'Dim mon As String = DateTime.Now.Month
            If mon = "Dec" Then
                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
                tyear = DateTime.Now.AddYears(-1).ToString("yy")
            End If
            'If mon < 10 Then
            '    mon = "0" + mon
            'End If

            tyear = mon + "-" + tyear
            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"
            strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    Dim cl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("CL"))
                    Dim sl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("SL"))
                    Dim pl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("PL"))
                    Dim lwp As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("LWP"))
                    Dim actwor As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("ActualWorkingDays"))
                    Dim actpre As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("ActualPresentDays"))
                    Dim abs As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("AbsentDays"))
                    Dim leaves As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("LeavesScores"))
                    Dim review As String = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
                    other.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("OtherLeaves"))

                    Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
                    Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
                    If deptsi = "Done" Then
                        deptsign.Checked = True

                    End If
                    If sectsi = "Done" Then
                        sectsign.Checked = True
                    End If
                    cla.InnerText = cl
                    sla.InnerText = sl
                    pla.InnerText = pl
                    lwpa.InnerText = lwp
                    actworking.InnerText = actwor
                    actpresent.InnerText = actpre
                    absentday.InnerText = abs
                    score.InnerText = leaves
                    othe.Checked = "true"
                    currentyear.Text = yea
                    Dim quarterreview As Integer = DateTime.Now.AddMonths(-3).ToString("MM")
                    If quarterreview <= "03" Then
                        q1.Checked = "true"
                    ElseIf quarterreview <= "06" Then
                        q2.Checked = "true"
                    ElseIf quarterreview <= "09" Then
                        q3.Checked = "true"
                    ElseIf quarterreview <= "12" Then
                        q4.Checked = "true"
                    End If
                    Dim qmonth1 As Integer = DateTime.Now.Month
                    Dim qmonth2 As Integer = DateTime.Now.AddMonths(-1).Month
                    Dim qmonth3 As Integer = DateTime.Now.AddMonths(-2).Month
                    Dim qmonth4 As Integer = DateTime.Now.AddMonths(-3).Month

                    If deptsi = "Done" Or sectsi = "Done" Then

                        Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                        CheckBoxList1.SelectedValue = sco1 / 3
                        CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                        CheckBoxList2.SelectedValue = sco2 / 3
                        CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                        CheckBoxList3.SelectedValue = sco3 / 4
                        CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                        CheckBoxList4.SelectedValue = sco4 / 3
                        CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                        CheckBoxList5.SelectedValue = sco5 / 1
                        CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")

                        totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                        If stat = "Pass" Then
                            reviewstatus.SelectedValue = "Pass"

                            reviewstatus.Attributes.Add("onclick", "return false")
                        ElseIf stat = "Fail" Then
                            reviewstatus.SelectedValue = "Fail"
                            reviewstatus.Attributes.Add("onclick", "return false")

                        End If
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
                        CheckBoxList3.SelectedValue = sco3 / 4
                        CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                        CheckBoxList4.SelectedValue = sco4 / 3
                        CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                        CheckBoxList5.SelectedValue = sco5 / 1
                        CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")

                        totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                        If stat = "Pass" Then
                            reviewstatus.SelectedValue = "Pass"

                            reviewstatus.Attributes.Add("onclick", "return false")
                        ElseIf stat = "Fail" Then
                            reviewstatus.SelectedValue = "Fail"
                            reviewstatus.Attributes.Add("onclick", "return false")

                        End If
                        remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
                        remark.ReadOnly = True
                        remark.BackColor = System.Drawing.SystemColors.Window
                    End If
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
        'For i As Integer = 0 To reviewstatus.Items.Count - 1
        '    reviewstatus.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        'Next
    End Sub

    Private Sub result()
        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Gtot As Double
        Tot = Double.Parse(CheckBoxList1.SelectedValue)
        scor1.Text = Tot * 3
        Tot1 = Double.Parse(CheckBoxList2.SelectedValue)
        scor2.Text = Tot1 * 3
        Tot2 = Double.Parse(CheckBoxList3.SelectedValue)
        scor3.Text = Tot2 * 4
        Tot3 = Double.Parse(CheckBoxList4.SelectedValue)
        scor4.Text = Tot3 * 3
        Tot4 = Double.Parse(CheckBoxList5.SelectedValue)
        scor5.Text = Tot4 * 1
        Tot5 = Double.Parse(score.InnerText)
        Dim totid As Integer = Tot2
        Dim totid3 As Integer = Tot4
        Dim totid2 As Integer = Tot + Tot1 + Tot3

        totid = totid * 4
        totid2 = totid2 * 3
        totid3 = totid3 * 1
        Gtot = totid + totid2 + totid3 + Tot5
        totmarks.InnerText = Gtot.ToString
        If totmarks.InnerText >= "76" Then
            reviewstatus.SelectedValue = "Pass"
        Else
            reviewstatus.SelectedValue = "Extend"
        End If
    End Sub
    'Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    Dim Tot, Tot1, Tot2, Tot3, Tot4, Gtot As Double
    '    Tot = Double.Parse(scor1.Text)
    '    Tot1 = Double.Parse(scor2.Text)
    '    Tot2 = Double.Parse(scor3.Text)
    '    Tot3 = Double.Parse(scor4.Text)
    '    Tot4 = Double.Parse(scor5.Text)


    '    Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4
    '    Label20.Text = Gtot.ToString
    'End Sub
    'Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    '    ' Verifies that the control is rendered
    'End Sub
    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Try
    '        Response.ContentType = "application/pdf"
    '        Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf")
    '        Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '        Dim sw As New StringWriter()
    '        Dim hw As New HtmlTextWriter(sw)
    '        Panel1.RenderControl(hw)
    '        Dim sr As New StringReader(sw.ToString())
    '        Dim pdfDoc As New Document(PageSize.A3, 8.0F, 10.0F, 100.0F, 0.0F)
    '        Dim htmlparser As New HTMLWorker(pdfDoc)
    '        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
    '        pdfDoc.Open()
    '        htmlparser.Parse(sr)
    '        pdfDoc.Close()
    '        Response.Write(pdfDoc)
    '        Response.End()
    '    Catch ex As Exception
    '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '    End Try
    'End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles insert.Click


        'If CheckBoxList1.SelectedValue = "" Then
        '    Label21.Visible = "true"
        '    Label21.Text = "Please select filed1"
        'ElseIf CheckBoxList2.SelectedValue = "" Then
        '    Label21.Visible = "true"
        '    Label21.Text = "Please select filed2"
        'ElseIf CheckBoxList3.SelectedValue = "" Then
        '    Label21.Visible = "true"
        '    Label21.Text = "Please select filed3"
        'ElseIf CheckBoxList4.SelectedValue = "" Then
        '    Label21.Visible = "true"
        '    Label21.Text = "Please select field4"
        'ElseIf CheckBoxList5.SelectedValue = "" Then
        '    Label21.Visible = "true"
        '    Label21.Text = "Please select filed5"

        'Else
        'End If
        Dim deptaccept As String = ""
        Dim sectaccept As String = ""
        If deptsign.Checked = True Then
            deptaccept = "Done"
        End If
        If sectsign.Checked = True Then
            sectaccept = "Done"
        End If
        If deptsign.Checked = True Then
            strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Status='" & reviewstatus.SelectedValue & "',Form_Status='DONE',Form_ID='3',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

            If sqlexe(constr, strsql) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If
        If sectsign.Checked = True Then
            strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Status='" & reviewstatus.SelectedValue & "',Form_Status='PENDING',Form_ID='3',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

            If sqlexe(constr, strsql) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If
        If deptsign.Checked = True And sectsign.Checked = True Then
            strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Status='" & reviewstatus.SelectedValue & "',Form_Status='DONE',Form_ID='3',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

            If sqlexe(constr, strsql) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If

    End Sub

    Protected Sub empsign_CheckedChanged(sender As Object, e As EventArgs) Handles empsign.CheckedChanged
        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
        End If
    End Sub

    'Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    'End Sub
End Class