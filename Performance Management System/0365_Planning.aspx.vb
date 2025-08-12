
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


Public Class _0365_Planning
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim mon As String
    Dim tyear As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Session("access power") = "" Then
            '    Response.Redirect("login.aspx")
            'End If
            If IsPostBack Then
                result()
            End If

            check()
            If Session("access power") = "2" Then
                plheadsign.Enabled = True
                empsig.Enabled = False
                deptsign.Enabled = True
                sectsign.Enabled = True
            Else
                If Session("access power") = "3" Then
                    empsig.Enabled = True
                    plheadsign.Enabled = False
                    deptsign.Enabled = False
                    sectsign.Enabled = False
                End If
            End If

            'strsql = "select * from Employee_Master where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"
            strsql = "select * from Employee_Master1 where EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "'"
            If sqlselect(constr, strsql, "Abc") Then
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
            'Dim mon As String = DateTime.Now.Month
            tyear = DateTime.Now.ToString("yy")
            If mon = "Dec" Then
                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
                tyear = DateTime.Now.AddYears(-1).ToString("yy")
            End If


            tyear = mon + "-" + tyear
            tot = yea
            tot = "[" + "dbo" + "]" + ". " + "[" + tot + "]"
            strsql = "select * from" + " " + tot + " " + "where (EmployeeCode='" & Session("empl code") & "' or EmployeeCode='" & Session("form empid") & "') and ReviewMonth='" & tyear & "'"
            If sqlselect(constr, strsql, "Abc") Then
                Dim cl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("CL"))
                Dim sl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("SL"))
                Dim pl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("PL"))
                Dim lwp As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("LWP"))
                Dim actwor As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("ActualWorkingDays"))
                Dim actpret As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("ActualPresentDays"))
                Dim abs As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("AbsentDays"))
                Dim leaves As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("LeavesScores"))
                review.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
                otherleaves.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("OtherLeaves"))
                Dim deptsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
                Dim sectsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
                Dim plheadsi As String = Convert.ToString(ds.Tables(0).Rows(0)("Plhead_Accept"))
                If plheadsi = "Done" Then
                    plheadsign.Checked = True

                End If
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
                actwork.InnerText = actwor
                actpre.InnerText = actpret
                absent.InnerText = abs
                scor.InnerText = leaves

                If plheadsi = "Done" Or deptsi = "Done" Or sectsi = "Done" Then

                    Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    CheckBoxList1.SelectedValue = sco1 / 4
                    CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    CheckBoxList2.SelectedValue = sco2 / 4
                    CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                    CheckBoxList3.SelectedValue = sco3 / 1
                    CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    CheckBoxList4.SelectedValue = sco4 / 2
                    CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    CheckBoxList5.SelectedValue = sco5 / 2
                    CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                    CheckBoxList6.SelectedValue = sco6 / 1
                    CheckBoxList6.SelectedItem.Attributes.Add("onclick", "return false")
                    totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                    If stat = "Pass" Then
                        pass.Checked = True
                        ext.Attributes.Add("onclick", "return false")
                        fl.Attributes.Add("onclick", "return false")
                        pas.Attributes.Add("onclick", "return false")
                    ElseIf stat = "Extend" Then
                        extend.Checked = True
                        pas.Attributes.Add("onclick", "return false")
                        fl.Attributes.Add("onclick", "return false")
                        ext.Attributes.Add("onclick", "return false")
                    ElseIf stat = "Fail" Then
                        fail.Checked = True
                        pas.Attributes.Add("onclick", "return false")
                        ext.Attributes.Add("onclick", "return false")
                        fl.Attributes.Add("onclick", "return false")
                    End If
                    remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
                    remark.ReadOnly = True
                    remark.BackColor = System.Drawing.SystemColors.Window
                End If

                If Session("form empid") <> "" Then

                    Dim sco1 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    CheckBoxList1.SelectedValue = sco1 / 4
                    CheckBoxList1.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco2 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    CheckBoxList2.SelectedValue = sco2 / 4
                    CheckBoxList2.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco3 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                    CheckBoxList3.SelectedValue = sco3 / 1
                    CheckBoxList3.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco4 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    CheckBoxList4.SelectedValue = sco4 / 2
                    CheckBoxList4.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco5 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    CheckBoxList5.SelectedValue = sco5 / 2
                    CheckBoxList5.SelectedItem.Attributes.Add("onclick", "return false")
                    Dim sco6 As Integer = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                    CheckBoxList6.SelectedValue = sco6 / 1
                    CheckBoxList6.SelectedItem.Attributes.Add("onclick", "return false")
                    totmarks.InnerText = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                    Dim stat As String = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                    If stat = "Pass" Then
                        pass.Checked = True
                        ext.Attributes.Add("onclick", "return false")
                        fl.Attributes.Add("onclick", "return false")
                        pas.Attributes.Add("onclick", "return false")
                    ElseIf stat = "Extend" Then
                        extend.Checked = True
                        pas.Attributes.Add("onclick", "return false")
                        fl.Attributes.Add("onclick", "return false")
                        ext.Attributes.Add("onclick", "return false")
                    ElseIf stat = "Fail" Then
                        fail.Checked = True
                        pas.Attributes.Add("onclick", "return false")
                        ext.Attributes.Add("onclick", "return false")
                        fl.Attributes.Add("onclick", "return false")
                    End If
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


    Private Sub result()
        Dim Tot, Tot1, Tot2, Tot3, Tot4, Tot5, Tot6, Gtot As Double
        Tot = Double.Parse(CheckBoxList1.SelectedValue)
        scor1.Text = Tot * 4
        Tot1 = Double.Parse(CheckBoxList2.SelectedValue)
        scor2.Text = Tot1 * 4
        Tot2 = Double.Parse(CheckBoxList3.SelectedValue)
        scor3.Text = Tot2 * 1
        Tot3 = Double.Parse(CheckBoxList4.SelectedValue)
        scor4.Text = Tot3 * 2
        Tot4 = Double.Parse(CheckBoxList5.SelectedValue)
        scor5.Text = Tot4 * 2
        Tot5 = Double.Parse(CheckBoxList6.SelectedValue)
        scor6.Text = Tot5 * 1
        Tot6 = Double.Parse(scor.InnerText)
        Dim totid As Integer = Tot + Tot1
        Dim totid1 As Integer = Tot3 + Tot4
        Dim totid2 As Integer = Tot2 + Tot5
        totid = totid * 4
        totid1 = totid1 * 2
        totid1 = totid1 * 1
        Gtot = totid + totid1 + totid2 + Tot6
        totmarks.InnerText = Gtot.ToString
        If totmarks.InnerText >= 76 Then
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

    Protected Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click

        Dim stat As String = ""
        If pass.Checked = "true" Then
            stat = "Pass"
        ElseIf fail.Checked = "true" Then
            stat = "Fail"
        ElseIf extend.Checked = "true" Then
            stat = "Extend"
        End If
        Dim plheadaccept As String = ""
        Dim deptaccept As String = ""
        Dim sectaccept As String = ""
        If plheadsign.Checked = True Then
            plheadaccept = "Done"
        End If
        If deptsign.Checked = True Then
            deptaccept = "Done"
        End If
        If sectsign.Checked = True Then
            sectaccept = "Done"
        End If
        If plheadsign.Checked = True Then
            strsql = "update" + " " + tot + " " + "Set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Status='" & stat & "',Form_Status='DONE',Form_ID='28',Plheadaccept = '" & plheadaccept & "'  where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If
        If deptsign.Checked = True Then
            strsql = "update" + " " + tot + " " + "Set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Status='" & stat & "',Form_Status='PENDING',Form_ID='28',Dept_Accept='" & deptaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If
        If sectsign.Checked = True Then
            strsql = "update" + " " + tot + " " + "Set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Status='" & stat & "',Form_Status='PENDING',Form_ID='28',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                ' clear()
            End If
        End If
        If plheadsign.Checked = True And deptsign.Checked = True And sectsign.Checked = True Then
                strsql = "update" + " " + tot + " " + "Set Score1='" & scor1.Text & "',Score2='" & scor2.Text & "',Score3='" & scor3.Text & "',Score4='" & scor4.Text & "',Score5='" & scor5.Text & "',Score6='" & scor6.Text & "',TotalMarks='" & totmarks.InnerText & "',Remark='" & remark.Text & "',Status='" & stat & "',Form_Status='DONE',Form_ID='28',Plheadaccept = '" & plheadaccept & "',Dept_Accept='" & deptaccept & "',Sect_Accept='" & sectaccept & "' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
                If sqlexe(constr, strsql) Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
                    ' clear()
                End If
            End If

    End Sub

    Protected Sub empsig_CheckedChanged(sender As Object, e As EventArgs) Handles empsig.CheckedChanged
        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
        End If
    End Sub

    'Protected Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    'End Sub
End Class