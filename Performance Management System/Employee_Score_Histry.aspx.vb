Imports System.Data
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Collections.Generic
Imports System.Net
Imports System.Linq
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.String
Imports System.IO.IOException
Public Class WebForm22
    Inherits System.Web.UI.Page
    Dim strsql As String = ""
    Dim errorms As String
    Dim access As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fill()
            filter()
            'If Session("access power") = "1" Then
            '    ' del()

            'End If

            If Session("access power") = "2" Then
                GridView1.Columns(29).Visible = False
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    'Private Sub del()
    '    stat.Text = ""
    '    Scor1.Text = ""
    '    Scor2.Text = ""
    '    scor3.Text = ""
    '    Scor4.Text = ""
    '    Scor5.Text = ""
    '    Scor6.Text = ""
    '    Scor7.Text = ""
    '    Scor8.Text = ""
    '    Scor9.Text = ""
    '    Scor10.Text = ""
    '    Scor11.Text = ""
    '    Scor12.Text = ""
    '    Scor13.Text = ""
    '    Scor14.Text = ""
    '    Scor15.Text = ""
    '    totmark.Text = ""
    '    remark.Text = ""
    '    famnt.Text = ""
    '    amnt.Text = ""
    '    Dheadsi.Text = ""
    '    Sheadsi.Text = ""
    '    Plheadsi.Text = ""
    '    empsi.Text = ""
    'End Sub

    Private Sub filter()
        Try
            If Not IsPostBack Then
                tbla.Items.Clear()
                'tbla.Items.Add("All")
                strsql = "select TABLE_NAME from information_schema.tables where TABLE_NAME like '20'+'%'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        tbla.DataSource = ds
                        tbla.DataTextField = "TABLE_NAME"
                        tbla.DataValueField = "TABLE_NAME"
                        tbla.DataBind()
                    End If
                End If
            End If
            If IsPostBack Then
                If tbla.SelectedValue <> "" Then
                    Dim tb As String = "dbo." + "[" + tbla.SelectedValue + "]"
                    If revmonth.SelectedValue = "All" Then
                        revmonth.Items.Clear()
                        revmonth.Items.Add("All")
                        Dim alltbl As New List(Of String)
                        For Each item As ListItem In tbla.Items
                            If item.Selected = True Then
                                If Session("access power") = "1" Then
                                    alltbl.Add("select distinct ReviewMonth from" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "union")
                                ElseIf Session("access power") = "2" Then
                                    alltbl.Add("select distinct ReviewMonth,Department from" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "union")
                                End If
                            End If
                        Next
                        Dim result As String = String.Join(" ", alltbl)

                        'Dim tbl As String = "[dbo]" + "." + "[" + item.ToString + "]"
                        strsql = result.Substring(0, result.Length() - 5)
                        If Session("access power") = "1" Then
                            strsql = "select * from (" + strsql + ") as Tb3 " + "order by ReviewMonth Desc"
                        ElseIf Session("access power") = "2" Then
                            strsql = "select * from (" + strsql + ") as Tb3 where Department='" & Session("department") & "' " + "order by ReviewMonth Desc"
                        End If
                        ' strsql = "select distinct ReviewMonth from " & tb & " order by ReviewMonth desc"
                        If sqlselect(constr, strsql, "Abc") Then
                            If ds.Tables("Abc").Rows.Count > 0 Then
                                revmonth.DataSource = ds
                                revmonth.DataTextField = "ReviewMonth"
                                revmonth.DataValueField = "ReviewMonth"
                                revmonth.DataBind()
                            End If
                        End If
                    End If
                    'If revmonth2.SelectedValue = "All" Then
                    '    revmonth2.Items.Clear()
                    '    revmonth2.Items.Add("All")
                    '    Dim alltbl As New List(Of String)
                    '    For Each item As ListItem In tbla.Items
                    '        If item.Selected = True Then
                    '            alltbl.Add("select distinct ReviewMonth from" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "union")
                    '        End If
                    '    Next
                    '    Dim result As String = String.Join(" ", alltbl)
                    '    strsql = result.Substring(0, result.Length() - 5) + "order by ReviewMonth Desc"
                    '    If sqlselect(constr, strsql, "Abc") Then
                    '        If ds.Tables("Abc").Rows.Count > 0 Then
                    '            revmonth2.DataSource = ds
                    '            revmonth2.DataTextField = "ReviewMonth"
                    '            revmonth2.DataValueField = "ReviewMonth"
                    '            revmonth2.DataBind()
                    '        End If
                    '    End If
                    'End If
                    If dept.SelectedValue = "All" Then
                        dept.Items.Clear()
                        dept.Items.Add("All")
                        Dim alltbl As New List(Of String)
                        For Each item As ListItem In tbla.Items
                            If item.Selected = True Then
                                Dim dbo As String = "[dbo]." + "[" + item.ToString + "]"
                                'alltbl.Add("select distinct a.department from Employee_Master a join " + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "b on a.EmployeeCode=b.EmployeeCode " + "union")
                                alltbl.Add("select distinct Department from " & dbo & "" + "Union")
                            End If
                        Next
                        Dim result As String = String.Join(" ", alltbl)
                        strsql = result.Substring(0, result.Length() - 5)
                        If Session("access power") = "1" Then
                            strsql = "select * from (" + strsql + ") as Tb3 "
                        ElseIf Session("access power") = "2" Then
                            strsql = "select * from (" + strsql + ") as Tb3  where Department='" & Session("department") & "'"
                        End If
                        '  strsql = "Select distinct a.department from Employee_Master a join " & tb & " b On a.EmployeeCode=b.EmployeeCode"
                        If sqlselect(constr, strsql, "Abc") Then
                            If ds.Tables("Abc").Rows.Count > 0 Then
                                dept.DataSource = ds
                                dept.DataTextField = "department"
                                dept.DataValueField = "department"
                                dept.DataBind()
                            End If
                        End If
                    End If
                    If sect.SelectedValue = "All" Then
                        sect.Items.Clear()
                        sect.Items.Add("All")
                        Dim alltbl As New List(Of String)
                        For Each item As ListItem In tbla.Items
                            If item.Selected = True Then
                                Dim dbo As String = "[dbo]." + "[" + item.ToString + "]"
                                If sect.SelectedValue = "All" And dept.SelectedValue = "All" Then
                                    ' alltbl.Add("Select distinct a.Section from Employee_Master a join " + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "b On a.EmployeeCode=b.EmployeeCode " + "union")
                                    If Session("access power") = "1" Then
                                        alltbl.Add("Select distinct Section from " & dbo & "" + "Union")
                                    ElseIf Session("access power") = "2" Then
                                        alltbl.Add("Select distinct Department,Section from " & dbo & "" + "Union")
                                    End If

                                ElseIf sect.SelectedValue = "All" And dept.SelectedValue <> "All" Then
                                    'alltbl.Add("Select distinct a.Section from Employee_Master a join " + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "b On a.EmployeeCode=b.EmployeeCode where a.Department='" & dept.SelectedValue & "' " + "union")
                                    If Session("access power") = "1" Then
                                        alltbl.Add("select distinct Section from " & dbo & " where Department='" & dept.SelectedValue & "'" + "Union")
                                    ElseIf Session("access power") = "2" Then
                                        alltbl.Add("select distinct Department,Section from " & dbo & " where Department='" & dept.SelectedValue & "'" + "Union")

                                    End If
                                End If
                            End If
                        Next
                        Dim result As String = String.Join(" ", alltbl)
                        strsql = result.Substring(0, result.Length() - 5)
                        If Session("access power") = "1" Then
                            strsql = "select * from (" + strsql + ") as Tb3 "
                        ElseIf Session("access power") = "2" Then
                            strsql = "select * from (" + strsql + ") as Tb3  where Department='" & Session("department") & "'"
                        End If
                        ' strsql = "select distinct a.Section from Employee_Master a join " & tb & " b on a.EmployeeCode=b.EmployeeCode"
                        If sqlselect(constr, strsql, "Abc") Then
                            If ds.Tables("Abc").Rows.Count > 0 Then
                                sect.DataSource = ds
                                sect.DataTextField = "Section"
                                sect.DataValueField = "Section"
                                sect.DataBind()
                            End If
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Private Sub fill()
        Try
            Dim tb As String = "[dbo]" + "." + "[" + tbla.SelectedValue + "]"
            If tbla.SelectedValue <> "" Then
                Dim alltbl As New List(Of String)
                For Each item As ListItem In tbla.Items
                    If item.Selected = True Then
                        Dim dbo As String = "[dbo]." + "[" + item.ToString + "]"
                        'alltbl.Add("select a.department,a.section,b.* from Employee_Master a join" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "b on a.EmployeeCode=b.EmployeeCode " + "union")
                        alltbl.Add("select * from " & dbo & "" + "Union")
                    End If
                Next
                Dim result As String = String.Join(" ", alltbl)
                'Dim tbl As String = "[dbo]" + "." + "[" + item.ToString + "]"
                strsql = result.Substring(0, result.Length() - 5)
                strsql = "select * from (" + strsql + ") as Tb3"
                'strsql = "select a.department,a.section,b.* from Employee_Master a join " & tb & " b on a.EmployeeCode=b.EmployeeCode "
                Dim TextStr As List(Of String) = New List(Of String)()
                If dept.SelectedValue <> "All" Then TextStr.Add("Department='" & dept.SelectedValue & "'")
                If sect.SelectedValue <> "All" Then TextStr.Add("Section='" & sect.SelectedValue & "'")
                If empcode.Text <> "" Then TextStr.Add("EmployeeCode like '" & empcode.Text & "'+'%'")
                If empname.Text <> "" Then TextStr.Add("EmployeeName like '" & empname.Text & "'+'%'")
                'If revmonth.SelectedValue <> "All" And revmonth2.SelectedValue = "All" Then TextStr.Add("b.ReviewMonth='" & revmonth.SelectedValue & "'")
                'If revmonth.SelectedValue = "All" And revmonth2.SelectedValue <> "All" Then TextStr.Add("b.ReviewMonth='" & revmonth2.SelectedValue & "'")
                'If revmonth.SelectedValue <> "All" And revmonth2.SelectedValue <> "All" Then TextStr.Add("b.ReviewMonth between '" & revmonth.SelectedValue & "' and '" & revmonth2.SelectedValue & "'")
                If revmonth.SelectedValue <> "All" Then TextStr.Add("ReviewMonth='" & revmonth.SelectedValue & "'")
                Dim str As String = String.Join(" and ", TextStr.ToArray())
                If Session("access power") = "1" Then
                    strsql = strsql + " " + "where" + " " + str
                ElseIf Session("access power") = "2" Then
                    strsql = strsql + " " + "where" + " " + str + " " + "And Department='" & Session("department") & "'"
                End If

                If sqlselect(constr, strsql, "Abc") Then
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                Else
                    GridView1.Visible = False
                End If
                GridView1.Visible = True
            End If
            If tbla.SelectedValue <> "" And dept.SelectedValue = "All" And sect.SelectedValue = "All" And empcode.Text = "" And empname.Text = "" And revmonth.SelectedValue = "All" Then
                Dim alltbl As New List(Of String)
                For Each item As ListItem In tbla.Items
                    If item.Selected = True Then
                        alltbl.Add("select * from" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "union")
                    End If
                Next
                Dim result As String = String.Join(" ", alltbl)

                'Dim tbl As String = "[dbo]" + "." + "[" + item.ToString + "]"
                strsql = result.Substring(0, result.Length() - 5)
                If Session("access power") = "2" Then
                    strsql = "select * from (" + strsql + ") as Tb3 where Department='" & Session("department") & "'"
                End If

                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        GridView1.DataSource = ds
                        GridView1.DataBind()
                        'Label392.Text = GridView1.Rows.Count.ToString()
                    Else
                        GridView1.Visible = False
                    End If

                End If

                GridView1.Visible = True

            End If

        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
        'If tbl.SelectedValue <> "All" And revmonth.SelectedValue = "All" Then
        '    strsql = "select * from  " & tb & ""
        '    If sqlselect(constr, strsql, "Abc") Then
        '        If ds.Tables("Abc").Rows.Count > 0 Then
        '            GridView1.DataSource = ds
        '            GridView1.DataBind()
        '        End If

        '    End If
        '    GridView1.Visible = True
        'ElseIf tbl.SelectedValue <> "All" And revmonth.SelectedValue <> "All" Then
        '    strsql = "select * from  " & tb & " where ReviewMonth='" & revmonth.SelectedValue & "'"
        '    If sqlselect(constr, strsql, "Abc") Then
        '        If ds.Tables("Abc").Rows.Count > 0 Then
        '            GridView1.DataSource = ds
        '            GridView1.DataBind()
        '        End If

        '    End If
        '    GridView1.Visible = True
        'Else
        '    GridView1.Visible = False
        'End If
    End Sub

    Protected Sub Display(sender As Object, e As EventArgs)
        Try
            Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            emplocode.Text = TryCast(row.FindControl("Label1"), Label).Text
            empn.Text = TryCast(row.FindControl("Label3"), Label).Text
            revimonth.Text = TryCast(row.FindControl("Label2"), Label).Text
            Dim alltbl As New List(Of String)
            For Each item As ListItem In tbla.Items
                If item.Selected = True Then
                    'alltbl.Add("select * from" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + " where EmployeeCode='" & emplocode.Text & "'and EmployeeName = '" & empn.Text & "' and  ReviewMonth='" & revimonth.Text & "'" + "union")
                    alltbl.Add("select * from" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + " where EmployeeCode='" & emplocode.Text & "' and  ReviewMonth='" & revimonth.Text & "'")
                End If
            Next
            Dim result As String = String.Join(" ", alltbl)

            'Dim tbl As String = "[dbo]" + "." + "[" + item.ToString + "]"
            'strsql = result.Substring(0, result.Length() - 5)
            strsql = result
            ' strsql = "select * from Employee_Master where EmployeeCode='" & emplocode.Text & "' and EmployeeCode<>'HR'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    empn.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    dpta.Text = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                    scta.Text = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                    cl.Text = Convert.ToString(ds.Tables(0).Rows(0)("CL"))
                    pl.Text = Convert.ToString(ds.Tables(0).Rows(0)("PL"))
                    sl.Text = Convert.ToString(ds.Tables(0).Rows(0)("SL"))
                    lwp.Text = Convert.ToString(ds.Tables(0).Rows(0)("LWP"))
                    otherleaves.Text = Convert.ToString(ds.Tables(0).Rows(0)("OtherLeaves"))
                    actworking.Text = Convert.ToString(ds.Tables(0).Rows(0)("ActualWorkingDays"))
                    actpresent.Text = Convert.ToString(ds.Tables(0).Rows(0)("ActualPresentDays"))
                    absentdays.Text = Convert.ToString(ds.Tables(0).Rows(0)("AbsentDays"))
                    leavesscor.Text = Convert.ToString(ds.Tables(0).Rows(0)("LeavesScores"))
                    reviduring.Text = Convert.ToString(ds.Tables(0).Rows(0)("Review_Dur"))
                    rev.Text = Convert.ToString(ds.Tables(0).Rows(0)("Review"))
                    stat.Text = Convert.ToString(ds.Tables(0).Rows(0)("Status"))
                    Scor1.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score1"))
                    Scor2.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score2"))
                    scor3.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score3"))
                    Scor4.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score4"))
                    Scor5.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score5"))
                    Scor6.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score6"))
                    Scor7.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score7"))
                    Scor8.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score8"))
                    Scor9.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score9"))
                    Scor10.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score10"))
                    Scor11.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score11"))
                    Scor12.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score12"))
                    Scor13.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score13"))
                    Scor14.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score14"))
                    Scor15.Text = Convert.ToString(ds.Tables(0).Rows(0)("Score15"))
                    famnt.Text = Convert.ToString(ds.Tables(0).Rows(0)("Famnt"))
                    amnt.Text = Convert.ToString(ds.Tables(0).Rows(0)("Amnt1"))
                    remark.Text = Convert.ToString(ds.Tables(0).Rows(0)("Remark"))
                    totmark.Text = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                    Dheadsi.Text = Convert.ToString(ds.Tables(0).Rows(0)("Dept_Accept"))
                    Sheadsi.Text = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
                    Plheadsi.Text = Convert.ToString(ds.Tables(0).Rows(0)("Plheadaccept"))
                    empsi.Text = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept"))
                End If
            End If
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Pop", "openModal();", True)

            ' ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'tbl.SelectedValue = "All"
        'fill()
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Try

            Dim tblname As String = revimonth.Text
            tblname = tblname.Substring(4, 2)
            tblname = "20" + tblname

            strsql = "update dbo." + "[" + tblname + "]" + " set CL='" & cl.Text & "',Sl='" & sl.Text & "',PL='" & pl.Text & "',LWP='" & lwp.Text & "',OtherLeaves='" & otherleaves.Text & "',ActualWorkingDays='" & actworking.Text & "',ActualPresentDays='" & actpresent.Text & "',AbsentDays='" & absentdays.Text & "',LeavesScores='" & leavesscor.Text & "',Review_Dur='" & reviduring.Text & "',Review='" & rev.Text & "' where  EmployeeCode='" & emplocode.Text & "'and  ReviewMonth='" & revimonth.Text & "'"
            If sqlexe(constr, strsql) Then
                fill()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Record Updated Successfully');", True)
            Else
                errorms = errorMsg
                Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(errorms) + "')</script>")

            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex()
        GridView1.DataBind()
    End Sub
    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered
    End Sub
    Protected Sub export_Click(sender As Object, e As EventArgs) Handles export.Click
        Try
            GridView1.PageIndex = 0
            GridView1.AllowPaging = "False"
            GridView1.HeaderStyle.CssClass = "gridviewout"
            GridView1.HeaderStyle.ForeColor = System.Drawing.Color.Black
            GridView1.HeaderStyle.BorderStyle = BorderStyle.Solid
            GridView1.HeaderStyle.BorderColor = Color.Black
            GridView1.RowStyle.BorderStyle = BorderStyle.Solid
            GridView1.RowStyle.BorderColor = Color.Black
            GridView1.HeaderStyle.BackColor = Color.Thistle
            GridView1.Columns(29).Visible = False
            GridView1.Font.Size = "12"
            GridView1.DataBind()
            Response.Clear()
            Response.Buffer = True
            Response.ClearContent()
            Response.Charset = ""
            Dim dt As String = DateTime.Now.ToString("dd-MM-yyyy")
            Response.AddHeader("content-disposition", "attachment; filename=" & dt & " " + ".xls")
            Response.ContentType = "application/excel"
            Dim sw As New IO.StringWriter()
            Dim htw As New HtmlTextWriter(sw)
            GridView1.RenderControl(htw)
            Dim html = sw.ToString()

            html = Right(html, Len(html) - InStr(html, "<table") + 1)
            html = Left(html, InStr(html, "</table>") + 7)
            Response.Write(sw.ToString())
            Response.Flush()
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.SuppressContent = True
            HttpContext.Current.ApplicationInstance.CompleteRequest()


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    Protected Sub btndel_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim tblname As String = revimonth.Text
            tblname = tblname.Substring(4, 2)
            tblname = "20" + tblname

            strsql = "update dbo." + "[" + tblname + "]" + " set Score1=""  where  EmployeeCode='" & emplocode.Text & "'and  ReviewMonth='" & revimonth.Text & "'"
            If sqlexe(constr, strsql) Then
                'Score1, Score2, Score3, Score4, Score5, Score6, Score7, Score8, Score9, Score10, Score11, Score12, Score13, Score14, Score15, Score16, Score17, Score18, TotalMarks, Status, remark, SLdr, Ldr, Shead, Dhead, Sshead,
                '         Phead, famnt, Amnt1, empn, Ldrn, Sheadn,
                'Emp_Accept, Dept_Accept, Sect_Accept, Plheadaccept

                ' stat.Text = ""
                'Scor1.Text = ""
                'Scor2.Text = ""
                'scor3.Text = ""
                'Scor4.Text = ""
                'Scor5.Text = ""
                'Scor6.Text = ""
                'Scor7.Text = ""
                'Scor8.Text = ""
                'Scor9.Text = ""
                'Scor10.Text = ""
                'Scor11.Text = ""
                'Scor12.Text = ""
                'Scor13.Text = ""
                'Scor14.Text = ""
                'Scor15.Text = ""
                'totmark.Text = ""
                'remark.Text = ""
                'famnt.Text = ""
                'amnt.Text = ""
                'Dheadsi.Text = ""
                'Sheadsi.Text = ""
                'Plheadsi.Text = ""
                'empsi.Text = ""



                fill()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Record Deleted Successfully');", True)
            Else
                errorms = errorMsg
                Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(errorms) + "')</script>")

            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    'Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    If e.CommandName = "Editform" Then
    '        Dim btndetails As LinkButton = TryCast(sender, LinkButton)
    '        Dim gvrow As GridViewRow = DirectCast(GridView1.Rows(0), GridViewRow)
    '        Dim row As GridViewRow = GridView1.SelectedRow
    '        Dim empcode As String = Convert.ToString(e.CommandArgument)
    '        Dim rev As Label = gvrow.FindControl("Label2")


    '    End If
    'End Sub
End Class