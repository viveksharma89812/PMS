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

Public Class WebForm14
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim mon As String
    Dim tyear As String
    Dim rev_period As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If IsPostBack Then
                result()
            End If
            If Session("access power") = "2" Then
                ch4.Enabled = False
                ch3.Enabled = True
                ch2.Enabled = True
                ch1.Enabled = True
            Else
                If Session("access power") = "3" Then
                    ch4.Enabled = True
                    Label22.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                    ch3.Enabled = False
                    ch2.Enabled = False
                    ch1.Enabled = False
                End If
            End If
            checkdetail()
            ' Label22.Text = DateTime.Now.ToString("yyyy-mm-dd hh:mm:ss")
            'strsql = "select * from Employee_Master where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"
            strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"
            If sqlselect(constr, strsql, "Abc") Then
                empcode.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                empname.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                desi.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                doj.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                qual.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                preexpa.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                rept.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))

                rev_period = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
                deptsec.InnerText = dept + "/" + sect

            Else
                Label12.Visible = "true"
                Label12.Text = "Your detail not insereted "
            End If
            rev_period = rev_period.Trim()
            If rev_period = "Confirm" Then
                mon = DateTime.Now.AddMonths(-3).ToString("MMM")
                '  mon = DateTime.Now.AddMonths(-1).ToString("MMM")
            Else
                mon = DateTime.Now.AddMonths(-1).ToString("MMM")
            End If

            Dim yea As String = DateTime.Now.Year
            tyear = DateTime.Now.ToString("yy")
            'Dim mon As String = DateTime.Now.Month
            If mon = "Dec" Then
                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
                tyear = DateTime.Now.AddYears(-1).ToString("yy")
            End If


            tyear = mon + "-" + tyear

            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"
            strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
            If sqlselect(constr, strsql, "Abc") Then

                If ds.Tables("Abc").Rows.Count > 0 Then
                    revmonth.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
                    Dim during As String = Convert.ToString(ds.Tables(0).Rows(0)("Review_Dur"))
                    Dim quarterreview As Integer = DateTime.Now.AddMonths(-3).ToString("MM")
                    Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
                    Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
                    Dim plheadsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Plhead_Accept"))
                    If plheadsi = "Done" Then
                        ch1.Checked = True

                    End If
                    If deptsi = "Done" Then
                        ch2.Checked = True

                    End If
                    If sectsi = "Done" Then
                        ch3.Checked = True
                    End If
                    If during = "During" Then
                        dur.Checked = True
                    ElseIf during = "Final" Then
                        final.Checked = True
                    Else
                        other.Checked = "true"
                    End If
                    If other.Checked = True Then

                        If quarterreview <= "03" Then
                            q1.Checked = "true"
                        ElseIf quarterreview <= "06" Then
                            q2.Checked = "true"
                        ElseIf quarterreview <= "09" Then
                            q3.Checked = "true"
                        ElseIf quarterreview <= "12" Then
                            q4.Checked = "true"
                        End If
                    End If
                    Dim qmonth1 As Integer = DateTime.Now.Month
                        Dim qmonth2 As Integer = DateTime.Now.AddMonths(-1).Month
                        Dim qmonth3 As Integer = DateTime.Now.AddMonths(-2).Month
                    Dim qmonth4 As Integer = DateTime.Now.AddMonths(-3).Month

                    If plheadsi = "Done" Or deptsi = "Done" Or sectsi = "Done" Then

                        Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                        CheckBoxList1.SelectedValue = sco1 / 2
                        CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                        CheckBoxList2.SelectedValue = sco2 / 2
                        CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                        CheckBoxList3.SelectedValue = sco3 / 2
                        CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                        CheckBoxList4.SelectedValue = sco4 / 2
                        CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                        CheckBoxList5.SelectedValue = sco5 / 2
                        CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                        CheckBoxList6.SelectedValue = sco6 / 2
                        CheckBoxList6.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco7 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
                        CheckBoxList7.SelectedValue = sco7 / 2
                        CheckBoxList7.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                        CheckBoxList8.SelectedValue = sco8 / 2
                        CheckBoxList8.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                        CheckBoxList9.SelectedValue = sco9 / 2
                        CheckBoxList9.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco10 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
                        CheckBoxList10.SelectedValue = sco10 / 2
                        CheckBoxList10.SelectedItem.Attributes.Add("onclick", "return false")
                        totscore.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                        If stat = "Pass" Then
                            pass.Checked = True
                            pass.Attributes.Add("onclick", "return false")
                            extend.Attributes.Add("onclick", "return false")
                            fail.Attributes.Add("onclick", "return false")
                        ElseIf stat = "Extend" Then
                            extend.Checked = True
                            pass.Attributes.Add("onclick", "return false")
                            extend.Attributes.Add("onclick", "return false")
                            fail.Attributes.Add("onclick", "return false")
                        ElseIf stat = "Fail" Then
                            fail.Checked = True
                            pass.Attributes.Add("onclick", "return false")
                            extend.Attributes.Add("onclick", "return false")
                            fail.Attributes.Add("onclick", "return false")
                        End If
                        remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
                        remark.ReadOnly = True
                        remark.BackColor = System.Drawing.SystemColors.Window
                    End If

                    If Session("form empid") <> "" Then

                        Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                        CheckBoxList1.SelectedValue = sco1 / 2
                        CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                        CheckBoxList2.SelectedValue = sco2 / 2
                        CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                        CheckBoxList3.SelectedValue = sco3 / 2
                        CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                        CheckBoxList4.SelectedValue = sco4 / 2
                        CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                        CheckBoxList5.SelectedValue = sco5 / 2
                        CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                        CheckBoxList6.SelectedValue = sco6 / 2
                        CheckBoxList6.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco7 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
                        CheckBoxList7.SelectedValue = sco7 / 2
                        CheckBoxList7.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco8 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                        CheckBoxList8.SelectedValue = sco8 / 2
                        CheckBoxList8.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco9 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                        CheckBoxList9.SelectedValue = sco9 / 2
                        CheckBoxList9.SelectedItem.Attributes.Add("onclick", "return false")
                        Dim sco10 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
                        CheckBoxList10.SelectedValue = sco10 / 2
                        CheckBoxList10.SelectedItem.Attributes.Add("onclick", "return false")
                        totscore.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                        Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                        If stat = "Pass" Then
                            pass.Checked = True
                            pass.Attributes.Add("onclick", "return false")
                            extend.Attributes.Add("onclick", "return false")
                            fail.Attributes.Add("onclick", "return false")
                        ElseIf stat = "Extend" Then
                            extend.Checked = True
                            pass.Attributes.Add("onclick", "return false")
                            extend.Attributes.Add("onclick", "return false")
                            fail.Attributes.Add("onclick", "return false")
                        ElseIf stat = "Fail" Then
                            fail.Checked = True
                            pass.Attributes.Add("onclick", "return false")
                            extend.Attributes.Add("onclick", "return false")
                            fail.Attributes.Add("onclick", "return false")
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
    Private Sub checkdetail()
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
        For i As Integer = 0 To CheckBoxList7.Items.Count - 1
            CheckBoxList7.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
        For i As Integer = 0 To CheckBoxList8.Items.Count - 1
            CheckBoxList8.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
        For i As Integer = 0 To CheckBoxList9.Items.Count - 1
            CheckBoxList9.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
        For i As Integer = 0 To CheckBoxList10.Items.Count - 1
            CheckBoxList10.Items(i).Attributes.Add("onclick", "MutExChkList(this)")
        Next
    End Sub



    Private Sub result()
        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Tot7, Tot8, Tot9, Gtot As Double
        Tot = Double.Parse(CheckBoxList1.SelectedValue)
        Scor1.Text = Tot * 2
        Tot1 = Double.Parse(CheckBoxList2.SelectedValue)
        Scor2.Text = Tot1 * 2
        Tot2 = Double.Parse(CheckBoxList3.SelectedValue)
        Scor3.Text = Tot2 * 2
        Tot3 = Double.Parse(CheckBoxList4.SelectedValue)
        Scor4.Text = Tot3 * 2
        Tot4 = Double.Parse(CheckBoxList5.SelectedValue)
        Scor5.Text = Tot4 * 2
        Tot5 = Double.Parse(CheckBoxList6.SelectedValue)
        Scor6.Text = Tot5 * 2
        Tot6 = Double.Parse(CheckBoxList7.SelectedValue)
        Scor7.Text = Tot6 * 2
        Tot7 = Double.Parse(CheckBoxList8.SelectedValue)
        Scor8.Text = Tot7 * 2
        Tot8 = Double.Parse(CheckBoxList9.SelectedValue)
        Scor9.Text = Tot8 * 2
        Tot9 = Double.Parse(CheckBoxList10.SelectedValue)
        Scor10.Text = Tot9 * 2
        Dim totid As Integer = Tot + Tot1 + Tot2 + Tot3 + Tot4 + Tot5 + Tot6 + Tot7 + Tot8 + Tot9
        totid = totid * 2
        Gtot = totid
        totscore.InnerText = Gtot.ToString
        If totscore.InnerText >= 76 Then
            pass.Checked = True
            extend.Checked = False And extend.Enabled
        Else
            extend.Checked = True
            pass.Checked = False And pass.Enabled
        End If
    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub

    Protected Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click

        Dim stat As String = ""
        If pass.Checked = "true" Then
            stat = "Pass"
        ElseIf extend.Checked = "true" Then
            stat = "Extend"
        ElseIf fail.Checked = "true" Then
            stat = "Fail"
        End If
        Dim plheadaccept As String = ""
        Dim deptaccept As String = ""
        Dim sectaccept As String = ""
        If ch1.Checked = True Then
            plheadaccept = "Done"
        End If
        If ch2.Checked = True Then
            deptaccept = "Done"
        End If
        If ch3.Checked = True Then
            sectaccept = "Done"
        End If
        If ch1.Checked = True Then
            strsql = "update" + " " + tot + " " + "set Score1='" & Scor1.Text & "',Score2='" & Scor2.Text & "',Score3='" & Scor3.Text & "',Score4='" & Scor4.Text & "',Score5='" & Scor5.Text & "',Score6='" & Scor6.Text & "',Score7='" & Scor7.Text & "',Score8='" & Scor8.Text & "' ,Score9='" & Scor9.Text & "',Score10='" & Scor10.Text & "', TotalMarks='" & totscore.InnerText & "',Remark='" & remark.Text & "',Status='" & stat & "',Form_Status='DONE',Form_ID='4',Plheadaccept = '" & plheadaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If
        If ch2.Checked = True Then
            strsql = "update" + " " + tot + " " + "set Score1='" & Scor1.Text & "',Score2='" & Scor2.Text & "',Score3='" & Scor3.Text & "',Score4='" & Scor4.Text & "',Score5='" & Scor5.Text & "',Score6='" & Scor6.Text & "',Score7='" & Scor7.Text & "',Score8='" & Scor8.Text & "' ,Score9='" & Scor9.Text & "',Score10='" & Scor10.Text & "', TotalMarks='" & totscore.InnerText & "',Remark='" & remark.Text & "',Status='" & stat & "',Form_Status='DONE',Form_ID='4',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully ');window.close()", True)
                ' clear()
            End If
        End If
        If ch3.Checked = True Then
            strsql = "update" + " " + tot + " " + "set Score1='" & Scor1.Text & "',Score2='" & Scor2.Text & "',Score3='" & Scor3.Text & "',Score4='" & Scor4.Text & "',Score5='" & Scor5.Text & "',Score6='" & Scor6.Text & "',Score7='" & Scor7.Text & "',Score8='" & Scor8.Text & "' ,Score9='" & Scor9.Text & "',Score10='" & Scor10.Text & "', TotalMarks='" & totscore.InnerText & "',Remark='" & remark.Text & "',Status='" & stat & "',Form_Status='PENDING',Form_ID='4',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If
        If ch1.Checked = True And ch2.Checked = True And ch3.Checked = True Then
            strsql = "update" + " " + tot + " " + "set Score1='" & Scor1.Text & "',Score2='" & Scor2.Text & "',Score3='" & Scor3.Text & "',Score4='" & Scor4.Text & "',Score5='" & Scor5.Text & "',Score6='" & Scor6.Text & "',Score7='" & Scor7.Text & "',Score8='" & Scor8.Text & "' ,Score9='" & Scor9.Text & "',Score10='" & Scor10.Text & "', TotalMarks='" & totscore.InnerText & "',Remark='" & remark.Text & "',Status='" & stat & "',Form_Status='DONE',Form_ID='4',Plheadaccept = '" & plheadaccept & "',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then

                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If

    End Sub

    Protected Sub ch4_CheckedChanged(sender As Object, e As EventArgs) Handles ch4.CheckedChanged
        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
        End If
    End Sub
    'Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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


End Class