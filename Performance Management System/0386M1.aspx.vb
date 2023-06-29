
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

Public Class _0386M1
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

            If Session("access power") = "2" Then
                ch3.Enabled = False
                ch1.Enabled = True
                ch2.Enabled = True
            Else
                If Session("access power") = "3" Then
                    GetIPAddress()
                    Label34.Text = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss")
                    ch3.Enabled = True
                    ch1.Enabled = False
                    ch2.Enabled = False
                End If
            End If
            ' check()
            ' result()
            'strsql = "select * from Employee_Master where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"
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
            revmonth.Text = tyear
            Label30.Text = tyear
            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"
            strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then

                    Dim review As String = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))


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
                        month.Checked = True
                    End If
                    'Dim quarterreview As Integer = DateTime.Now.AddMonths(-3).ToString("MM")
                    'If quarterreview <= "03" Then
                    '    q1.Checked = "true"
                    'ElseIf quarterreview <= "06" Then
                    '    q2.Checked = "true"
                    'ElseIf quarterreview <= "09" Then
                    '    q3.Checked = "true"
                    'ElseIf quarterreview <= "12" Then
                    '    q4.Checked = "true"
                    'End If
                    'Dim qmonth1 As Integer = DateTime.Now.Month
                    'Dim qmonth2 As Integer = DateTime.Now.AddMonths(-1).Month
                    'Dim qmonth3 As Integer = DateTime.Now.AddMonths(-2).Month
                    'Dim qmonth4 As Integer = DateTime.Now.AddMonths(-3).Month

                    'If Session("form empid") <> "" Then

                    '    Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    '    CheckBoxList1.SelectedValue = sco1 / 4
                    '    CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
                    '    Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    '    CheckBoxList2.SelectedValue = sco2 / 4
                    '    CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
                    '    Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                    '    CheckBoxList3.SelectedValue = sco3 / 4
                    '    CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                    '    Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    '    CheckBoxList4.SelectedValue = sco4 / 3
                    '    CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                    '    Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    '    CheckBoxList5.SelectedValue = sco5 / 3
                    '    CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")

                    '    totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                    '    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                    '    If stat = "Pass" Then
                    '        reviewstatus.SelectedValue = "Pass"

                    '        reviewstatus.Attributes.Add("onclick", "return false")
                    '    ElseIf stat = "Fail" Then
                    '        reviewstatus.SelectedValue = "Fail"
                    '        reviewstatus.Attributes.Add("onclick", "return false")

                    '    End If
                    '    remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
                    '    remark.ReadOnly = True
                    '    remark.BackColor = System.Drawing.SystemColors.Window
                    'End If


                    If Session("form empid") <> "" Then

                        Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                        sco1 = Double.Parse(score1.Text)
                        Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                        sco2 = Double.Parse(score2.Text)
                        Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                        sco3 = Double.Parse(score3.Text)
                        Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                        sco4 = Double.Parse(score4.Text)
                        Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                        sco5 = Double.Parse(score5.Text)
                        Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                        sco6 = Double.Parse(score6.Text)
                        Dim sco7 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
                        sco7 = Double.Parse(score7.Text)
                        Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                        sco8 = Double.Parse(score8.Text)
                        Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                        sco9 = Double.Parse(score9.Text)
                        Dim sco10 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
                        sco10 = Double.Parse(score10.Text)
                        Dim sco11 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score11"))
                        sco11 = Double.Parse(score11.Text)
                        totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                        If stat = "Pass" Then
                            pass.Checked = "Pass"
                            pass.Attributes.Add("onclick", "return false")
                        ElseIf stat = "Fail" Then
                            extend.Checked = "Fail"
                            extend.Attributes.Add("onclick", "return false")

                        End If
                    End If


                End If
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")

        End Try
    End Sub
    'Private Sub check()
    '    For i As Integer = 0 To CheckBoxList1.Items.Count - 1
    '        CheckBoxList1.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '    Next
    '    For i As Integer = 0 To CheckBoxList2.Items.Count - 1
    '        CheckBoxList2.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '    Next
    '    For i As Integer = 0 To CheckBoxList3.Items.Count - 1
    '        CheckBoxList3.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '    Next
    '    For i As Integer = 0 To CheckBoxList4.Items.Count - 1
    '        CheckBoxList4.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '    Next
    '    For i As Integer = 0 To CheckBoxList5.Items.Count - 1
    '        CheckBoxList5.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '    Next
    '    'For i As Integer = 0 To reviewstatus.Items.Count - 1
    '    '    reviewstatus.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '    'Next
    'End Sub

    Private Sub result()



        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Tot7, Tot8, Tot9, Tot10, Gtot As Double
        ' leader review checkboxlist marks
        'Tot1 = Double.Parse(checkboxlist1.SelectedIndex)
        'If CheckBoxList1.SelectedIndex = "0" Then
        '    Tot1 = "4"
        'ElseIf score1.SelectedIndex = "1" Then
        '    Tot1 = "3"
        'ElseIf score1.SelectedIndex = "2" Then
        '    Tot1 = "2"
        'ElseIf score1.SelectedIndex = "3" Then
        '    Tot1 = "1"

        'End If

        If score1.Text <> "" Then
            Tot = Double.Parse(score1.Text)
        End If
        If score2.Text <> "" Then
            Tot1 = Double.Parse(score2.Text)
        End If
        If score3.Text <> "" Then
            Tot2 = Double.Parse(score3.Text)
        End If
        If score4.Text <> "" Then
            Tot3 = Double.Parse(score4.Text)
        End If
        If score5.Text <> "" Then
            Tot4 = Double.Parse(score5.Text)
        End If
        If score6.Text <> "" Then
            Tot5 = Double.Parse(score6.Text)
        End If
        If score7.Text <> "" Then
            Tot6 = Double.Parse(score7.Text)
        End If
        If score8.Text <> "" Then
            Tot7 = Double.Parse(score8.Text)
        End If
        If score9.Text <> "" Then
            Tot8 = Double.Parse(score9.Text)
        End If
        If totmarks.Text <= "76" Then
            If score10.Text = "" Then
                Tot9 = Double.Parse(score10.Text)
            End If
            If score11.Text = "" Then
                Tot10 = Double.Parse(score11.Text)
            End If
        End If

        Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10
        totmarks.Text = Gtot.ToString
        'If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And score7.Text <> "" And score8.Text <> "" And score9.Text <> "" And score10.Text = "" And score11.Text = "" Then
        '    totmarks.Text = Gtot
        'End If
        If totmarks.Text >= "76" Then
            pass.Checked = True
        Else
            extend.Checked = True
        End If
        ' Dim status As String = ""
        'If totmarks.Text >= "76" Then
        '    pass.Checked = "Pass"
        'Else
        '    extend.Text = "Extend"
        'End If
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
        If ch1.Checked = True Then
            deptaccept = "Done"
        End If
        If ch2.Checked = True Then
            sectaccept = "Done"
        End If
        Dim status As String = ""
        If pass.Checked = True Then
            status = "Pass"
        ElseIf extend.Checked = "true" Then
            status = "Extend"

        End If
        strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "',Score8='" & score8.Text & "',Score9='" & score9.Text & "', TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='3',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
        If sqlexe(constr, strsql) Then

            Response.Write(" <script> alert('Inserted successfully' );window.location = '" + Request.RawUrl + "';</script>")
            ' clear()
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

    Private Sub GetIPAddress()

        Dim strHostName As String

        Dim strIPAddress As String



        strHostName = System.Net.Dns.GetHostName()

        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()



        Label32.Text = "Host Name: " & strHostName & ", IP Address: " & strIPAddress & ""
    End Sub
End Class