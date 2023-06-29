Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Public Class WebForm13
    Inherits System.Web.UI.Page
    Dim strsql As String = ""
    Dim tot As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        strsql = "select * From Employee_Master where  Department='" & Session("department") & "' and Designation <> 'GM' and Designation <>'AVP'"
        If sqlselect(constr, strsql, "Abc") Then
            GridView1.DataSource = ds.Tables("Abc")
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub Display(sender As Object, e As EventArgs)
        Try
            Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            empcode.Text = TryCast(row.FindControl("Label3"), Label).Text
            strsql = "select * from Employee_Master where EmployeeCode='" & empcode.Text & "'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then

                    empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    desig.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                    dept.Text = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                    sect.Text = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                    doj.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                    dop.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOP"))
                    doc.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOC"))
                    doe.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOE"))
                    quali.Text = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                    preexp.Text = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                    reporting.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                    review.Text = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
                End If
            End If

            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "Pop", "openModal();", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "Download" Or e.CommandName = "Form" Then
                'tb1.Visible = "True"
                Dim btndetails As LinkButton = TryCast(sender, LinkButton)
                Dim gvrow As GridViewRow = DirectCast(GridView1.Rows(0), GridViewRow)
                Dim row As GridViewRow = GridView1.SelectedRow
                Dim abc As String = Convert.ToString(e.CommandArgument)
                strsql = "select * from Employee_Master where EmployeeCode='" & abc & "'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        empcode.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                        empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                        desig.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                        dept.Text = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                        sect.Text = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                        doj.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                        dop.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOP"))
                        doc.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOC"))
                        doe.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOE"))
                        quali.Text = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                        preexp.Text = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                        reporting.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                        review.Text = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))

                        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)

                        Session("empl code") = empcode.Text
                        If e.CommandName = "Form" And e.CommandName <> "Download" Then

                            Dim des As Date
                            Dim age As String = ""
                            Dim month As String = ""
                            Dim day As String = ""
                            des = DateTime.Now.ToString("yyyy-MM-dd")
                            Dim dj As Date = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                            If review.Text = "Training Period" And doj.Text <> "" And doe.Text = "" Then
                                Dim dt3 As TimeSpan = (des - dj)
                                Dim diff As Double = dt3.Days
                                age = Str(Int(diff / 365)) & " Year "
                                diff = diff Mod 365
                                month = Str(Int(diff / 30)) & " Month(s)"
                                diff = diff Mod 30
                                day = Str(diff) & " Day(s)"
                            ElseIf review.Text = "Probation Period" And dop.Text <> "" And doe.Text = "" Then
                                Dim dp As Date = Convert.ToString(ds.Tables(0).Rows(0)("DOP"))
                                Dim dt3 As TimeSpan = (des - dp)
                                Dim diff As Double = dt3.Days
                                age = Str(Int(diff / 365)) & " Year "
                                diff = diff Mod 365
                                month = Str(Int(diff / 30)) & " Month(s)"
                                diff = diff Mod 30
                                day = Str(diff) & " Day(s)"
                            ElseIf review.Text = "Permanent Review Period" And doc.Text <> "" And doe.Text = "" Then
                                Dim dc As Date = Convert.ToString(ds.Tables(0).Rows(0)("DOC"))
                                Dim dt3 As TimeSpan = (des - dc)
                                Dim diff As Double = dt3.Days
                                age = Str(Int(diff / 365)) & " Year "
                                diff = diff Mod 365
                                month = Str(Int(diff / 30)) & " Month(s)"
                                diff = diff Mod 30
                                day = Str(diff) & " Day(s)"

                            ElseIf doe.Text <> "" Then
                                Dim de As Date = Convert.ToString(ds.Tables(0).Rows(0)("DOE"))
                                Dim dt3 As TimeSpan = (des - de)
                                Dim diff As Double = dt3.Days
                                age = Str(Int(diff / 365)) & " Year "
                                diff = diff Mod 365
                                month = Str(Int(diff / 30)) & " Month(s)"
                                diff = diff Mod 30
                                day = Str(diff) & " Day(s)"
                            End If


                            Dim yea As String
                            Dim mon1 As String = DateTime.Now.AddMonths(-3).Month
                            Dim mon2 As String = DateTime.Now.AddMonths(-2).Month
                            Dim mon3 As String = DateTime.Now.AddMonths(-1).Month
                            Dim tot As String = ""
                            Dim tot1 As String = ""
                            Dim tot2 As String = ""
                            Dim tot3 As String = ""
                            If mon1 < 10 Then
                                mon1 = "0" + mon1
                            End If
                            If mon2 < 10 Then
                                mon2 = "0" + mon2
                            End If
                            If mon3 < 10 Then
                                mon3 = "0" + mon3
                            End If
                            Dim m1 As Integer
                            Dim m2 As Integer
                            Dim m3 As Integer
                            If mon1 Then
                                If mon1 > "10" Then
                                    yea = DateTime.Now.AddYears(-1).Year
                                Else
                                    yea = DateTime.Now.Year
                                End If

                                tot1 = yea + mon1
                                tot1 = "[dbo]" + ". " + "[" + tot1 + "]"
                                strsql = "select TotalMarks from" + " " + tot1 + " " + "where EmployeeCode='" & abc & "'"
                                If sqlselect(constr, strsql, "Abc") Then
                                    If ds.Tables("Abc").Rows.Count > 0 Then
                                        m1 = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                                    End If
                                End If
                            End If
                            If mon2 Then
                                If mon2 > "10" Then
                                    yea = DateTime.Now.AddYears(-1).Year
                                Else
                                    yea = DateTime.Now.Year
                                End If

                                tot2 = yea + mon2
                                tot2 = "[dbo]" + ". " + "[" + tot2 + "]"
                                strsql = "select TotalMarks from" + " " + tot2 + " " + "where EmployeeCode='" & abc & "'"
                                If sqlselect(constr, strsql, "Abc") Then
                                    If ds.Tables("Abc").Rows.Count > 0 Then
                                        m2 = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                                    End If
                                End If
                            End If
                            If mon3 Then
                                If mon3 > "10" Then
                                    yea = DateTime.Now.AddYears(-1).Year
                                Else
                                    yea = DateTime.Now.Year
                                End If
                                tot3 = yea + mon3
                                tot3 = "[dbo]" + ". " + "[" + tot3 + "]"
                                strsql = "select TotalMarks from" + " " + tot3 + " " + "where EmployeeCode='" & abc & "'"
                                If sqlselect(constr, strsql, "Abc") Then
                                    If ds.Tables("Abc").Rows.Count > 0 Then
                                        m3 = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
                                    End If
                                End If
                            End If

                            age = age.Substring(1, 2)
                            month = month.Substring(1, 2)
                            day = day.Substring(1, 2)
                            Dim rev As String
                            rev = review.Text

                            If rev = "Training Period" And doe.Text = "" Then
                                If tot = m1.ToString >= "55" And m2.ToString >= "55" And m3.ToString >= "55" Then
                                    tot = m1 + m2 + m3
                                    Convert.ToInt16(tot)
                                    tot = tot / 3
                                End If
                                rev = "Training Period"
                            ElseIf rev = "Probation Period" And doe.Text = "" Then
                                If tot = m1.ToString >= "65" And m2.ToString >= "65" And m3.ToString >= "65" Then
                                    tot = m1 + m2 + m3
                                    Convert.ToInt16(tot)
                                    tot = tot / 3
                                End If
                                rev = "Probation Period"
                            ElseIf rev = "Permanent Review Period" And doe.Text = "" Then
                                If tot = m1 + m2 + m3 >= "76" Then
                                    tot = m1 + m2 + m3
                                    Convert.ToInt16(tot)
                                    tot = tot / 3
                                End If
                                rev = "Permanent Review Period"
                            Else
                                rev = "Extend"
                            End If

                            Select Case rev
                                Case "Training Period"
                                    If age < "1" And month = "11" And day >= "1" And tot >= 66 Then
                                        Response.Redirect("0365.aspx", False)
                                    ElseIf age < "1" And tot >= 66 Then
                                        Response.Redirect("0364.aspx", False)
                                    End If
                                Case "Probation Period"
                                    If Convert.ToInt16(month) = "5" And day >= "1" And tot >= 71 Then
                                        Response.Redirect("0365.aspx", False)
                                    ElseIf tot >= 71 Then
                                        Response.Redirect("0364.aspx", False)
                                    End If
                                Case "Permanent Review Period"
                                    If month >= "1" And tot >= 76 Then
                                        Response.Redirect("0386.aspx", False)
                                    End If
                                Case "Extend"
                                    If Convert.ToInt16(month) = "1" And Convert.ToInt16(day) = "0" Then
                                        Response.Redirect("0503.aspx", False)
                                    ElseIf month <= 4 Then
                                        Response.Redirect("0504.aspx", False)

                                    End If

                            End Select

                        End If
                    End If
                    End If

            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
End Class