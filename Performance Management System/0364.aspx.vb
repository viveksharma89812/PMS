'Imports System.Data
'Imports System.Configuration
'Imports System.String
'Imports System.Data.SqlClient
'Imports System.IO
'Imports System.IO.Path
'Imports iTextSharp.text
'Imports iTextSharp.text.html.simpleparser
'Imports iTextSharp.text.pdf
'Imports System.Drawing
'Imports System.Drawing.Imaging
'Imports Excel = Microsoft.Office.Interop.Excel
'Imports DocumentFormat.OpenXml.Office
'Imports System.Runtime.InteropServices


Public Class WebForm8
    Inherits System.Web.UI.Page
    '    Dim strsql As String
    '    Dim tot As String
    '    Dim mon As String
    '    Dim tyear As String

    '    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '        Try

    '            If IsPostBack Then
    '                result()

    '            End If

    '            check()
    '            If Session("access power") = "2" Then
    '                ch3.Enabled = False
    '                ch1.Enabled = False
    '                ch2.Enabled = True
    '            ElseIf Session("access power") = "4" Then
    '                ch3.Enabled = False
    '                ch1.Enabled = True
    '                ch2.Enabled = False
    '            Else
    '                If Session("access power") = "3" Then
    '                    ch3.Enabled = True
    '                    Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
    '                    ch1.Enabled = False
    '                    ch2.Enabled = False
    '                End If
    '            End If

    '            Dim strsql As String
    '            If Session("access power") <> "2" Then
    '                CheckBoxList1.Enabled = "true"
    '                CheckBoxList2.Enabled = "true"
    '                CheckBoxList3.Enabled = "true"
    '                CheckBoxList4.Enabled = "true"
    '                CheckBoxList5.Enabled = "true"
    '                CheckBoxList6.Enabled = "true"
    '                'TextBox9.Enabled = "false"
    '                'Button4.Visible = "false"
    '            End If
    '            strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"
    '            If sqlselect(constr, strsql, "Abc") Then
    '                If ds.Tables("Abc").Rows.Count > 0 Then
    '                    empcode.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
    '                    empname.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
    '                    desc.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
    '                    Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
    '                    Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
    '                    doj.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
    '                    qual.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
    '                    prev.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
    '                    repto.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
    '                    Dim revperiod As String = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
    '                    deptsec.InnerText = dept + "/" + sect

    '                    'review.InnerText = Now.Month

    '                    'If desc.InnerText = "GET" Or desc.InnerText = "MGMT" Then
    '                    '    trai.Checked = "true"
    '                    '    prob.Checked = "false"
    '                    'Else
    '                    '    prob.Checked = "true"
    '                    '    trai.Checked = "false"
    '                    'End If
    '                    revperiod = revperiod.Trim()
    '                    If revperiod = "Training" Then
    '                        trai.Checked = "true"
    '                        prob.Checked = "false"
    '                    ElseIf revperiod = "Probation" Then
    '                        prob.Checked = "true"
    '                        trai.Checked = "false"
    '                    End If
    '                Else
    '                    'Label22.Visible = "true"
    '                    'Label22.Text = "Your detail not insereted "
    '                    Response.Write("<script>alert('Your detail not insereted');</script>")
    '                End If
    '            End If

    '            '   Dim mon As String = DateTime.Now.Month
    '            mon = DateTime.Now.AddMonths(-1).ToString("MMM")

    '            Dim yea As String = DateTime.Now.Year
    '            tyear = DateTime.Now.ToString("yy")
    '            If mon = "Dec" Then
    '                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
    '                tyear = DateTime.Now.AddYears(-1).ToString("yy")
    '            End If


    '            tyear = mon + "-" + tyear
    '            tot = yea
    '            tot = "[dbo]" + ". " + "[" + tot + "]"
    '            strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
    '            If sqlselect(constr, strsql, "Abc") Then
    '                cla.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("CL"))
    '                sla.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("SL"))
    '                pla.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("PL"))
    '                lwpa.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("LWP"))
    '                actwork.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ActualWorkingDays"))
    '                actpre.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ActualPresentDays"))
    '                absent.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("AbsentDays"))
    '                scor.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("LeavesScores"))
    '                review.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
    '                Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
    '                Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
    '                If deptsi = "Done" Then
    '                    ch1.Checked = True

    '                End If
    '                If sectsi = "Done" Then
    '                    ch2.Checked = True
    '                End If
    '                If deptsi = "Done" Or sectsi = "Done" Then

    '                    Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
    '                    CheckBoxList1.SelectedValue = sco1 / 3
    '                    'CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
    '                    CheckBoxList2.SelectedValue = sco2 / 3
    '                    'CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
    '                    CheckBoxList3.SelectedValue = sco3 / 3
    '                    ' CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
    '                    CheckBoxList4.SelectedValue = sco4 / 3
    '                    '  CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
    '                    CheckBoxList5.SelectedValue = sco5 / 3
    '                    ' CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
    '                    CheckBoxList6.SelectedValue = sco6 / 3
    '                    ' CheckBoxList6.SelectedItem.Attributes.Add("onclick", "return false")
    '                    totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
    '                    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))

    '                    remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
    '                    remark.ReadOnly = True
    '                    remark.BackColor = System.Drawing.SystemColors.Window
    '                End If
    '                If Session("form empid") <> "" Then

    '                    Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
    '                    CheckBoxList1.SelectedValue = sco1 / 3
    '                    ' CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
    '                    CheckBoxList2.SelectedValue = sco2 / 3
    '                    ' CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
    '                    CheckBoxList3.SelectedValue = sco3 / 3
    '                    ' CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
    '                    CheckBoxList4.SelectedValue = sco4 / 3
    '                    ' CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
    '                    CheckBoxList5.SelectedValue = sco5 / 3
    '                    'CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")
    '                    Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
    '                    CheckBoxList6.SelectedValue = sco6 / 3
    '                    'CheckBoxList6.SelectedItem.Attributes.Add("onclick", "return false")
    '                    totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
    '                    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))

    '                    remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
    '                    remark.ReadOnly = True
    '                    remark.BackColor = System.Drawing.SystemColors.Window
    '                End If
    '            End If


    '        Catch ex As Exception
    '            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")

    '        End Try
    '    End Sub
    '    Private Sub check()

    '        For i As Integer = 0 To CheckBoxList1.Items.Count - 1
    '            CheckBoxList1.Items(i).Attributes.Add("onclick", "MutExChkList(this)")

    '        Next
    '        For i As Integer = 0 To CheckBoxList2.Items.Count - 1
    '            CheckBoxList2.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '        Next
    '        For i As Integer = 0 To CheckBoxList3.Items.Count - 1
    '            CheckBoxList3.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '        Next
    '        For i As Integer = 0 To CheckBoxList4.Items.Count - 1
    '            CheckBoxList4.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '        Next
    '        For i As Integer = 0 To CheckBoxList5.Items.Count - 1
    '            CheckBoxList5.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '        Next
    '        For i As Integer = 0 To CheckBoxList6.Items.Count - 1
    '            CheckBoxList6.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
    '        Next
    '    End Sub
    '    'Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    '    'End Sub



    '    Private Sub result()
    '        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Gtot As Double
    '        Tot = Double.Parse(CheckBoxList1.SelectedValue)
    '        scor1.Text = Tot * 3
    '        Tot1 = Double.Parse(CheckBoxList2.SelectedValue)
    '        scor2.Text = Tot1 * 3
    '        Tot2 = Double.Parse(CheckBoxList3.SelectedValue)
    '        scor3.Text = Tot2 * 3
    '        Tot3 = Double.Parse(CheckBoxList4.SelectedValue)
    '        scor4.Text = Tot3 * 3
    '        Tot4 = Double.Parse(CheckBoxList5.SelectedValue)
    '        scor5.Text = Tot4 * 3
    '        Tot5 = Double.Parse(CheckBoxList6.SelectedValue)
    '        scor6.Text = Tot5 * 3
    '        Tot6 = Double.Parse(scor.InnerText)
    '        Dim totid As Integer = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5
    '        totid = totid * 3
    '        Gtot = totid + Tot6
    '        totmarks.InnerText = Gtot.ToString
    '    End Sub


    '    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles insert.Click

    '        Try

    '            Dim deptaccept As String = ""
    '            Dim sectaccept As String = ""
    '            If ch1.Checked = True Then
    '                deptaccept = "Done"
    '            End If
    '            If ch2.Checked = True Then
    '                sectaccept = "Done"
    '            End If
    '            If ch1.Checked = True Then
    '                strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='1',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
    '                If sqlexe(constr, strsql) Then

    '                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
    '                    ' clear()
    '                End If
    '            End If
    '            If ch2.Checked = True Then
    '                strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='PENDING',Form_ID='1',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
    '                If sqlexe(constr, strsql) Then

    '                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
    '                    ' clear()
    '                End If
    '            End If
    '            If ch1.Checked = True And ch2.Checked = True Then
    '                strsql = "update" + " " + tot + " " + "set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Form_Status='DONE',Form_ID='1',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

    '                If sqlexe(constr, strsql) Then

    '                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
    '                    ' clear()
    '                End If
    '            End If




    '        Catch ex As Exception
    '            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '        End Try
    '    End Sub

    '    Protected Sub empsign_CheckedChanged(sender As Object, e As EventArgs) Handles ch3.CheckedChanged
    '        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
    '        If sqlexe(constr, strsql) Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
    '        End If
    '    End Sub

    '    Private Sub clear()
    '        'empname.InnerText = ""
    '        'empcode.InnerText = ""
    '        'desc.InnerText = ""
    '        'deptsec.InnerText = ""
    '        'deptsec.InnerText = ""
    '        'deptsec.InnerText = ""
    '        'doj.InnerText = ""
    '        'review.InnerText = ""
    '        'qual.InnerText = ""
    '        'prev.InnerText = ""
    '        'repto.InnerText = ""
    '        'cla.InnerText = ""
    '        'sla.InnerText = ""
    '        'pla.InnerText = ""
    '        'lwpa.InnerText = ""
    '        strsql = "update" + " " + tot + " " + "Set Score1='',Score2='',Score3='',Score4='',Score5='',Score6='' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
    '        If sqlexe(constr, strsql) Then
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
    '        End If

    '    End Sub

    '    'Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles export.Click
    '    '    Try
    '    '        'Response.ContentType = "application/pdf"
    '    '        'Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf")
    '    '        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
    '    '        'Dim sw As New StringWriter()
    '    '        'Dim hw As New HtmlTextWriter(sw)
    '    '        'Panel1.RenderControl(hw)
    '    '        'Dim sr As New StringReader(sw.ToString())
    '    '        'Dim pdfDoc As New Document(PageSize.A3, 30.0F, 30.0F, 100.0F, 0.0F)
    '    '        'Dim pdfDoc As New Document(PageSize.A4, 0.0F, 0.0F, 0.0F, 0.0F)
    '    '        'Dim htmlparser As New HTMLWorker(pdfDoc)

    '    '        'PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
    '    '        'pdfDoc.Open()
    '    '        'htmlparser.Parse(sr)
    '    '        'pdfDoc.Close()
    '    '        'Dim html = sw.ToString()
    '    '        'html = Right(html, Len(html) - InStr(html, "<table") + 1)
    '    '        'html = Left(html, InStr(html, "</table>") + 7)
    '    '        'Response.Write(pdfDoc)
    '    '        'Response.End()


    '    '        Response.Clear()
    '    '        Response.Buffer = True
    '    '        Response.ClearContent()
    '    '        Response.Charset = ""
    '    '       Dim dt As String = "" = DateTime.Now.ToString("dd-MM-yyyy")
    '    '        Response.AddHeader("content-disposition", "attachment; filename=" & dt & " " + ".xls")
    '    '        Response.ContentType = "application/excel"
    '    '        Dim sw As New StringWriter()
    '    '        Dim htw As New HtmlTextWriter(sw)
    '    '        Panel1.RenderControl(htw)
    '    '        Dim html = sw.ToString()

    '    '        html = Right(html, Len(html) - InStr(html, "<table") + 1)
    '    '        html = Left(html, InStr(html, "</table>") + 7)
    '    '        Response.Write(sw.ToString())
    '    '        Response.Flush()
    '    '        Response.End()
    '    '    Catch ex As Exception
    '    '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '    '    End Try
    '    'End Sub

    '    'Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
    '    '    Try




    '    '    Catch ex As Exception
    '    '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '    '    End Try
    '    'End Sub


    '    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    '        ' Verifies that the control is rendered
    '    End Sub

    '    Protected Sub insert0_Click(sender As Object, e As EventArgs) Handles insert0.Click
    '        'clear()
    'End Sub
End Class

'Public Class WebForm8
'    Inherits System.Web.UI.Page
'    Dim strsql As String
'    Dim tot As String
'    Dim mon As String
'    Dim tyear As String


'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

'        Try


'            ' If Session("access power") <> "4" Then
'            If IsPostBack Then
'                up()
'                eve()

'                result()


'            Else






'                If Session("access power") = "2" Then
'                    ch3.Enabled = False
'                    ch1.Enabled = False
'                    ch2.Enabled = True
'                    remark.Enabled = True
'                    score12.Enabled = False

'                ElseIf Session("access power") = "4" Then
'                    ch3.Enabled = False
'                    ch1.Enabled = True
'                    ch2.Enabled = False
'                    remark.Enabled = True

'                Else
'                    If Session("access power") = "3" Then
'                        'fail1()
'                        score1.Enabled = False
'                        score2.Enabled = False
'                        score3.Enabled = False
'                        score4.Enabled = False
'                        score5.Enabled = False
'                        score6.Enabled = False
'                        score7.Enabled = False
'                        score8.Enabled = False
'                        score9.Enabled = False
'                        score10.Enabled = False
'                        score11.Enabled = False
'                        score12.Enabled = False
'                        remark.Enabled = False
'                        Time.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
'                        ch3.Enabled = True
'                        ch1.Enabled = False
'                        ch2.Enabled = False


'                    End If
'                    If Session("access power") = "4" And ch2.Checked = True And ch2.Enabled = False Then
'                        show.Visible = True
'                        update.Visible = True
'                    Else
'                        show.Visible = False
'                        update.Visible = False
'                    End If

'                End If

'                strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"

'                If sqlselect(constr, strsql, "Abc") Then
'                    If ds.Tables("Abc").Rows.Count > 0 Then
'                        empcode.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
'                        empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
'                        desc.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
'                        Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
'                        Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
'                        doj.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
'                        repto.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
'                        deptsect.Text = dept + "/" + sect
'                        Dim revperiod As String = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
'                        revperiod = revperiod.Trim()
'                        If revperiod = "Training" Then
'                            trai.Checked = "true"
'                            prob.Checked = "false"
'                            conf.Checked = "false"
'                        ElseIf revperiod = "Probation" Then
'                            prob.Checked = "true"
'                            trai.Checked = "false"
'                            conf.Checked = "false"
'                        ElseIf revperiod = "Confirm" Then
'                            conf.Checked = "true"
'                            trai.Checked = "false"
'                            prob.Checked = "false"
'                        End If
'                    Else
'                        Response.Write("<script>alert('Your detail not insereted');</script>")
'                    End If
'                End If


'                mon = DateTime.Now.AddMonths(-1).ToString("MMM")

'                Dim yea As String = DateTime.Now.Year
'                tyear = DateTime.Now.ToString("yy")
'                If mon = "Dec" Then
'                    yea = DateTime.Now.AddYears(-1).ToString("yyyy")
'                    tyear = DateTime.Now.AddYears(-1).ToString("yy")
'                End If


'                tyear = mon + "-" + tyear
'                revmonth.Text = tyear
'                tot = yea
'                tot = "[dbo]" + ". " + "[" + tot + "]"

'                strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
'                If sqlselect(constr, strsql, "Abc") Then

'                    revmonth.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
'                    Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
'                    Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
'                    If deptsi = "Done" Then
'                        ch1.Checked = True

'                    End If
'                    If sectsi = "Done" Then
'                        ch2.Checked = True
'                    End If

'                    Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
'                    If mont <= "12" Then
'                        Month.Checked = True
'                    End If


'                    If Session("form empid") <> "" Then

'                        score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
'                        score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
'                        score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
'                        score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
'                        score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
'                        score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
'                        score7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
'                        score8.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
'                        score9.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
'                        score10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
'                        score11.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score11"))
'                        score12.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score12"))
'                        ldr.Text = Convert.ToString(ds.Tables(0).Rows(0)("Ldr"))
'                        shead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Shead"))
'                        dhead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dhead"))
'                        'sshead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sshead"))
'                        remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark4"))
'                        totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
'                        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
'                        If stat = "Pass" Then
'                            pass.Checked = True

'                        ElseIf stat = "Extend" Then
'                            extend.Checked = True


'                        End If
'                    End If
'                End If

'            End If
'            ' ViewState["name"] = score1.Text;  
'            ' txtpwd.Attributes.Add("value", ViewState["VsPassword"].ToString());

'            ' End If
'            'If ch2.Checked = True And ch2.Enabled = False Then
'            '    show.Visible = True
'            '    update.Visible = True
'            'Else
'            '    show.Visible = False
'            '    update.Visible = False
'            'End If

'            ' End If

'            ' fail1()

'        Catch ex As Exception
'            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")

'        End Try
'    End Sub
'    Public Sub eve()
'        mon = DateTime.Now.AddMonths(-1).ToString("MMM")

'        Dim yea As String = DateTime.Now.Year
'        tyear = DateTime.Now.ToString("yy")
'        If mon = "Dec" Then
'            yea = DateTime.Now.AddYears(-1).ToString("yyyy")
'            tyear = DateTime.Now.AddYears(-1).ToString("yy")
'        End If


'        tyear = mon + "-" + tyear
'        revmonth.Text = tyear
'        tot = yea
'        tot = "[dbo]" + ". " + "[" + tot + "]"

'        strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
'        If sqlselect(constr, strsql, "Abc") Then

'            revmonth.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
'            Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
'            Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
'            If deptsi = "Done" Then
'                ch1.Checked = True

'            End If
'            If sectsi = "Done" Then
'                ch2.Checked = True
'            End If

'            Dim mont As Integer = DateTime.Now.AddMonths(-1).ToString("MM")
'            If mont <= "12" Then
'                Month.Checked = True
'            End If
'            If deptsi = "Done" Or sectsi = "Done" Then

'                score1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
'                score2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
'                score3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
'                score4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
'                score5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
'                score6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
'                score7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
'                score8.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
'                score9.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
'                score10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
'                score11.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score11"))
'                score12.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score12"))

'                ldr.Text = Convert.ToString(ds.Tables(0).Rows(0)("Ldr"))
'                shead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Shead"))
'                dhead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dhead"))
'                'sshead.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sshead"))
'                remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark4"))
'                totmarks.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
'                Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
'                If stat = "Pass" Then
'                    pass.Checked = True

'                ElseIf stat = "Extend" Then
'                    extend.Checked = True

'                End If
'            End If

'        End If

'    End Sub
'    Public Sub post()
'        'score1.AutoPostBack = False
'        'score2.AutoPostBack = False
'        'score3.AutoPostBack = False
'        'score4.AutoPostBack = False ,
'        'score5.AutoPostBack = False
'        'score6.AutoPostBack = False
'        'score7.AutoPostBack = False
'        'score8.AutoPostBack = False
'        'score9.AutoPostBack = False
'        'score10.AutoPostBack = False
'        'ch1.AutoPostBack = False
'        'ch2.AutoPostBack = False
'    End Sub

'    Public Sub up()


'        mon = DateTime.Now.AddMonths(-1).ToString("MMM")

'        Dim yea As String = DateTime.Now.Year
'        tyear = DateTime.Now.ToString("yy")
'        If mon = "Dec" Then
'            yea = DateTime.Now.AddYears(-1).ToString("yyyy")
'            tyear = DateTime.Now.AddYears(-1).ToString("yy")
'        End If


'        tyear = mon + "-" + tyear
'        revmonth.Text = tyear
'        tot = yea
'        tot = "[dbo]" + ". " + "[" + tot + "]"

'        Dim s1 As String = score1.Text
'        Dim s2 As String = score2.Text
'        Dim s3 As String = score3.Text
'        Dim s4 As String = score4.Text
'        Dim s5 As String = score5.Text
'        Dim s6 As String = score6.Text
'        Dim s7 As String = score7.Text
'        Dim s8 As String = score8.Text
'        Dim s9 As String = score9.Text
'        Dim s10 As String = score10.Text
'        Dim s11 As String = score11.Text
'        Dim s12 As String = score12.Text

'        Dim deptaccept As String = ""
'        Dim sectaccept As String = ""
'        If ch1.Checked = True Then
'            deptaccept = "Done"
'        End If
'        If ch2.Checked = True Then
'            sectaccept = "Done"
'        End If
'        Dim status As String = ""
'        If pass.Checked = True Then
'            status = "Pass"
'        ElseIf extend.Checked = True Then
'            status = "Extend"

'        End If
'        If ch1.Checked = True Then
'            strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "',  TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='35',Dept_Accept='" & deptaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Remark4 = '" & remark.Text & "'  where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

'            If sqlexe(constr, strsql) Then
'                result()
'                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
'            End If
'        End If
'    End Sub

'    Private Sub result()
'        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Tot7, Tot8, Tot9, Tot10, Tot11, Tot12, Tot13, Tot14, Tot15, Gtot As Double
'        If score1.Text <> "" And score1.Text <= 24 Then
'            Tot = Double.Parse(score1.Text)
'            score1.BackColor = Color.White
'            score1.ForeColor = Color.Black
'        Else
'            score1.ForeColor = Color.Red
'            score1.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score2.Text <> "" And score2.Text <= 12 Then
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
'        If score4.Text <> "" And score4.Text <= 24 Then
'            Tot3 = Double.Parse(score4.Text)
'            score4.BackColor = Color.White
'            score4.ForeColor = Color.Black
'        Else
'            score4.ForeColor = Color.Red
'            score4.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score5.Text <> "" And score5.Text <= 6 Then
'            Tot4 = Double.Parse(score5.Text)
'            score5.BackColor = Color.White
'            score5.ForeColor = Color.Black
'        Else
'            score5.ForeColor = Color.Red
'            score5.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If


'        If score6.Text <> "" And score6.Text <= 6 Then
'            Tot5 = Double.Parse(score6.Text)
'            score6.BackColor = Color.White
'            score6.ForeColor = Color.Black
'        Else
'            score6.ForeColor = Color.Red
'            score6.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score7.Text <> "" And score7.Text <= 7 Then
'            Tot6 = Double.Parse(score7.Text)
'            score7.BackColor = Color.White
'            score7.ForeColor = Color.Black
'        Else
'            score7.ForeColor = Color.Red
'            score7.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score8.Text <> "" And score8.Text <= 6 Then
'            Tot7 = Double.Parse(score8.Text)
'            score8.BackColor = Color.White
'            score8.ForeColor = Color.Black
'        Else
'            score8.ForeColor = Color.Red
'            score8.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If
'        If score9.Text <> "" And score9.Text <= 5 Then
'            Tot8 = Double.Parse(score9.Text)
'            score9.BackColor = Color.White
'            score9.ForeColor = Color.Black
'        Else
'            score9.ForeColor = Color.Red
'            score9.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system % please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        End If


'        If score10.Text <> "" Then
'            Tot9 = Double.Parse(score10.Text)
'        End If

'        If score11.Text <> "" Then
'            Tot10 = Double.Parse(score11.Text)
'        End If

'        If score12.Text <> "" Then
'            Tot11 = Double.Parse(score12.Text)
'        End If


'        Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11

'        If Gtot >= 101 Then
'            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8
'            score10.ForeColor = Color.Red
'            score10.BackColor = Color.Yellow

'            score11.ForeColor = Color.Red
'            score11.BackColor = Color.Yellow

'            score12.ForeColor = Color.Red
'            score12.BackColor = Color.Yellow
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system 100% please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)

'        Else
'            Gtot = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9 + Tot10 + Tot11
'            score10.BackColor = Color.White
'            score10.ForeColor = Color.Black

'            score11.BackColor = Color.White
'            score11.ForeColor = Color.Black

'            score12.BackColor = Color.White
'            score12.ForeColor = Color.Black
'            If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And score7.Text <> "" And score8.Text <> "" And score9.Text <> "" Then
'                totmarks.Text = Gtot.ToString
'            End If
'            If totmarks.Text >= 76 Then
'                pass.Checked = True
'                extend.Checked = False And extend.Enabled

'            Else
'                extend.Checked = True
'                pass.Checked = False And pass.Enabled

'            End If
'        End If
'        '+ Tot6 + Tot7 + Tot8 + Tot9 + Tot10
'        If score1.Text <> "" And score2.Text <> "" And score3.Text <> "" And score4.Text <> "" And score5.Text <> "" And score6.Text <> "" And score7.Text <> "" And score8.Text <> "" And score9.Text <> "" Then
'            totmarks.Text = Gtot.ToString
'        End If
'        If totmarks.Text >= 76 Then
'            pass.Checked = True
'            extend.Checked = False And extend.Enabled

'        Else
'            extend.Checked = True
'            pass.Checked = False And pass.Enabled

'        End If
'        'If totmarks.Text >= 100 Then
'        '    totmarks.Text = totmarks.Text
'        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your fill number is more the system 100% please according to Max fill.       你填寫的百分比高過制度，請重新確認與填寫');window.close()", True)
'        'End If

'        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('updated successfully');", True)
'    End Sub
'    Public Sub msg()
'        MsgBox("Please enter only numeric 請輸入數字")

'    End Sub

'    Protected Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click
'        Try

'            result()
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
'                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "', TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='35',Dept_Accept='" & deptaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Remark4 = '" & remark.Text & "'  where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

'                If sqlexe(constr, strsql) Then
'                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
'                End If
'            End If


'            If ch2.Checked = True Then
'                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "', TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='PENDING',Form_ID='35',Sect_Accept='" & sectaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "' , Remark4 = '" & remark.Text & "'  where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

'                If sqlexe(constr, strsql) Then
'                    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
'                End If
'            End If
'            If ch1.Checked = True And ch2.Checked = True Then
'                strsql = "update" + " " + tot + " " + "set Score1='" & score1.Text & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',Score4='" & score4.Text & "',Score5='" & score5.Text & "',Score6='" & score6.Text & "',Score7='" & score7.Text & "', Score8='" & score8.Text & "' , Score9='" & score9.Text & "',Score10='" & score10.Text & "',Score11='" & score11.Text & "',Score12='" & score12.Text & "', TotalMarks='" & totmarks.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='35',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "',Ldr ='" & ldr.Text & "' , Shead = '" & shead.Text & "', Dhead = '" & dhead.Text & "'  , Remark4 = '" & remark.Text & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"

'                If sqlexe(constr, strsql) Then
'                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
'                End If
'            End If
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
'        Catch ex As Exception
'            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
'        End Try

'    End Sub

'    Protected Sub ch3_CheckedChanged(sender As Object, e As EventArgs) Handles ch3.CheckedChanged

'        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' , time  = '" & Time.Text & "' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"

'        If sqlexe(constr, strsql) Then
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Data Entered successfully');window.close()", True)
'        End If
'        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Please First ');window.close()", True)
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

'    Protected Sub score11_TextChanged(sender As Object, e As EventArgs) Handles score11.TextChanged
'        If score11.Text.Length > 0 Then
'            If Not IsNumeric(score11.Text) Then
'                msg()
'                score11.Text = 0
'            End If
'        End If
'    End Sub
'    Protected Sub score12_TextChanged(sender As Object, e As EventArgs) Handles score12.TextChanged
'        If score12.Text.Length > 0 Then
'            If Not IsNumeric(score12.Text) Then
'                msg()
'                score12.Text = 0
'            End If
'        End If
'    End Sub


'    Protected Sub update_Click(sender As Object, e As EventArgs) Handles update.Click
'        'If Page.IsPostBack = True Then
'        '    post()
'        'End If
'        Dim s1 As String = score1.Text
'        Dim s2 As String = score2.Text
'        Dim s3 As String = score3.Text
'        Dim s4 As String = score4.Text
'        Dim s5 As String = score5.Text
'        Dim s6 As String = score6.Text
'        Dim s7 As String = score7.Text
'        Dim s8 As String = score8.Text
'        Dim s9 As String = score9.Text
'        Dim s10 As String = score10.Text
'        Dim s11 As String = score11.Text
'        Dim s12 As String = score12.Text

'        up()
'    End Sub

'    Protected Sub show_Click(sender As Object, e As EventArgs) Handles show.Click
'        eve()
'    End Sub

'End Class