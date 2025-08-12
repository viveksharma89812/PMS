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
    Public PMSclass As New PMSClass()
    Dim access As String = ""
    Dim year As String = DateTime.Now.ToString("yyyy")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("access power") = "" Then
                Response.Redirect("login.aspx")
            End If

            filter()
            fill()
            filter()

            If Session("access power") = "1" Then
                stat.ReadOnly = False
                Scor1.ReadOnly = False
                Scor2.ReadOnly = False
                scor3.ReadOnly = False
                Scor4.ReadOnly = False
                Scor5.ReadOnly = False
                Scor6.ReadOnly = False
                Scor7.ReadOnly = False
                Scor8.ReadOnly = False
                Scor9.ReadOnly = False
                Scor10.ReadOnly = False
                Scor11.ReadOnly = False
                Scor12.ReadOnly = False
                Scor13.ReadOnly = False
                Scor14.ReadOnly = False
                Scor15.ReadOnly = False
                totmark.ReadOnly = False
                remark.ReadOnly = False
                famnt.ReadOnly = False
                amnt.ReadOnly = False

            End If
            If Session("access power") = "2" Or Session("access power") = "4" Then
                emplocode.Enabled = True
                empn.Enabled = True
                revimonth.Enabled = True
                dpta.Enabled = True
                scta.Enabled = True
                cl.ReadOnly = True
                sl.ReadOnly = True
                pl.ReadOnly = True
                lwp.ReadOnly = True
                otherleaves.ReadOnly = True
                actworking.ReadOnly = True
                actpresent.ReadOnly = True
                absentdays.ReadOnly = True
                leavesscor.ReadOnly = True
                reviduring.ReadOnly = True
                rev.ReadOnly = True
                Button2.Visible = False
                btnSave.Visible = False

            End If

            If Session("access power") = "2" Or Session("access power") = "4" Then
                GridView1.Columns(29).Visible = False
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
                    strsql = strsql + " " + "where" + " " + str + " " + "And Department='" & Session("department") & "' and Section='" & Session("Section") & "'"
                ElseIf Session("access power") = "4" And dept.SelectedValue = "All" And sect.SelectedValue = "All" And empcode.Text = "" And empname.Text = "" And revmonth.SelectedValue = "All" Then
                    strsql = strsql + " " + "where" + " " + str + " " + " Section in (" & Session("desg") & ")"
                ElseIf Session("access power") = "4" And (dept.SelectedValue <> "All" Or sect.SelectedValue <> "All" Or empcode.Text <> "" Or empname.Text <> "" Or revmonth.SelectedValue <> "All") Then
                    strsql = strsql + " " + "where" + " " + str + " "
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
                    strsql = "select * from (" & strsql & ") as Tb3 where Department='" & Session("department") & "' and Section='" & Session("Section") & "'"

                ElseIf Session("access power") = "4" Then

                    strsql = "select * from (" & strsql & ") as Tb3 where Section in (" & Session("desg") & ")"
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
                    alltbl.Add("select * from" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + " where EmployeeCode='" & emplocode.Text & "' and  ReviewMonth='" & revimonth.Text & "'")
                End If
            Next
            Dim result As String = String.Join(" ", alltbl)

            strsql = result
            If sqlselectmaster(constr, strsql, "Abc") Then
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
                    Dim empsignpic As String = Convert.ToString(ds.Tables(0).Rows(0)("SignPic"))

                    'This code is use for Get Picture ..
                    If Not String.IsNullOrEmpty(empsignpic) Then
                        Dim filePath As String = HttpContext.Current.Server.MapPath("~/Captures/" & empsignpic & ".jpg")

                        If System.IO.File.Exists(filePath) Then
                            Dim imageUrl As String = ResolveUrl("~/Captures/" & empsignpic & ".jpg")
                            imgDynamic.ImageUrl = imageUrl
                        Else
                            imgDynamic.ImageUrl = Nothing
                        End If
                    Else
                        imgDynamic.ImageUrl = Nothing
                    End If

                    Dim dt As DataTable = PMSClass.checkimage(emplocode.Text)


                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Dim IMG As String = dt.Rows(0)("Images").ToString()

                        If Not String.IsNullOrEmpty(IMG) Then
                            Dim filePath As String = HttpContext.Current.Server.MapPath("~/Captures/" & IMG & ".jpg")

                            If System.IO.File.Exists(filePath) Then
                                Dim imageUrl As String = ResolveUrl("~/Captures/" & IMG & ".jpg")

                                Image1.ImageUrl = imageUrl
                            Else
                                Image1.ImageUrl = Nothing
                            End If
                        Else
                            Image1.ImageUrl = Nothing
                        End If
                    End If




                    'This code is use for Get Picture ..
                End If
            End If
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Pop", "openModal();", True)

        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub


    Protected Sub viewresult(sender As Object, e As EventArgs)
        Try
            Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            emplocode.Text = TryCast(row.FindControl("Label1"), Label).Text
            empn.Text = TryCast(row.FindControl("Label3"), Label).Text
            revimonth.Text = TryCast(row.FindControl("Label2"), Label).Text
            Dim datte As String
            datte = Convert.ToString(tbla.SelectedValue).ToString()


            Session("year") = revimonth.Text
            Session("empl code") = emplocode.Text

            strsql = "select * from dbo.[" & datte & "] where EmployeeCode='" & emplocode.Text & "' and ReviewMonth='" & revimonth.Text & "'"
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    Dim status As String = Convert.ToString(ds.Tables(0).Rows(0)("Sect_Accept"))
                    Dim formid As String = Convert.ToString(ds.Tables(0).Rows(0)("Form_ID"))

                    If status = "Done" Then

                        If formid <> "" Then

                            If formid = "1" Then
                                Response.Redirect("0364.aspx", False)
                            ElseIf formid = "2" Then
                                Response.Redirect("0365.aspx", False)
                            ElseIf formid = "3" Then
                                Response.Redirect("0386.aspx", False)
                            ElseIf formid = "4" Then
                                Response.Redirect("0475.aspx", False)
                            ElseIf formid = "5" Then
                                Response.Redirect("0386M5.aspx", False)
                            ElseIf formid = "6" Then
                                Response.Redirect("0386CO1.aspx", False)
                            ElseIf formid = "7" Then
                                Response.Redirect("0386CO2.aspx", False)
                            ElseIf formid = "8" Then
                                Response.Redirect("0386EO1.aspx", False)
                            ElseIf formid = "9" Then
                                Response.Redirect("0386CUO1.aspx", False)
                            ElseIf formid = "10" Then
                                Response.Redirect("0386TBO1.aspx", False)
                            ElseIf formid = "11" Then
                                Response.Redirect("0386TSPO2.aspx", False)
                            ElseIf formid = "12" Then
                                Response.Redirect("0386TRON03.aspx", False)
                            ElseIf formid = "13" Then
                                Response.Redirect("0386TSO4.aspx", False)
                            ElseIf formid = "14" Then
                                Response.Redirect("0386QVO1.aspx", False)
                            ElseIf formid = "15" Then
                                Response.Redirect("0386QDO2.aspx", False)
                            ElseIf formid = "16" Then
                                Response.Redirect("0386QSTO3.aspx", False)
                            ElseIf formid = "17" Then
                                Response.Redirect("0386QPO4.aspx", False)
                            ElseIf formid = "18" Then
                                Response.Redirect("0386R1.aspx", False)
                            ElseIf formid = "19" Then
                                Response.Redirect("0386MO1.aspx", False)
                            ElseIf formid = "20" Then
                                Response.Redirect("0386ME1.aspx", False)
                            ElseIf formid = "21" Then
                                Response.Redirect("0386MR1.aspx", False)
                            ElseIf formid = "22" Then
                                Response.Redirect("0386UE1.aspx", False)
                            ElseIf formid = "23" Then
                                Response.Redirect("0386UO1.aspx", False)
                            ElseIf formid = "24" Then
                                Response.Redirect("0386EHS.aspx", False)
                            ElseIf formid = "25" Then
                                Response.Redirect("0386EC1.aspx", False)
                            ElseIf formid = "26" Then
                                Response.Redirect("0386_Chef.aspx", False)
                            ElseIf formid = "27" Then
                                Response.Redirect("0364_Planning.aspx", False)
                            ElseIf formid = "28" Then
                                Response.Redirect("0365_Planning.aspx", False)
                            ElseIf formid = "29" Then
                                Response.Redirect("0366_Planning.aspx", False)
                            ElseIf formid = "30" Then
                                Response.Redirect("0367_Planning.aspx", False)
                            ElseIf formid = "31" Then
                                Response.Redirect("0386TL1.aspx", False)
                            ElseIf formid = "32" Then
                                Response.Redirect("0386TA1.aspx", False)
                            ElseIf formid = "33" Then
                                Response.Redirect("0386TL2.aspx", False)
                            ElseIf formid = "34" Then
                                Response.Redirect("0386TAL3.aspx", False)
                            ElseIf formid = "35" Then
                                Response.Redirect("0386M1.aspx", False)
                            ElseIf formid = "36" Then
                                Response.Redirect("0386M4.aspx", False)
                            ElseIf formid = "37" Then
                                Response.Redirect("0386M2.aspx", False)
                            ElseIf formid = "38" Then
                                Response.Redirect("0386M3.aspx", False)
                            ElseIf formid = "39" Then
                                Response.Redirect("0386P1.aspx", False)
                            ElseIf formid = "40" Then
                                Response.Redirect("0386QPO5.aspx", False)
                            ElseIf formid = "41" Then
                                Response.Redirect("0364.aspx", False)
                            ElseIf formid = "42" Then
                                Response.Redirect("0386HCWO1.aspx", False)
                            ElseIf formid = "43" Then
                                Response.Redirect("0386WHO1.aspx", False)
                            ElseIf formid = "44" Then
                                Response.Redirect("0364_Planning.aspx", False)
                            ElseIf formid = "66" Then
                                Response.Redirect("0366GAORPS.aspx", False)
                            ElseIf formid = "81" Then
                                Response.Redirect("0386CL1.aspx", False)
                            ElseIf formid = "47" Then
                                Response.Redirect("0386CS1.aspx", False)
                            ElseIf formid = "45" Then
                                Response.Redirect("0386CST1.aspx", False)
                            ElseIf formid = "48" Then
                                Response.Redirect("0386CL2.aspx", False)
                            ElseIf formid = "49" Then
                                Response.Redirect("0386CNC2.aspx", False)
                            ElseIf formid = "50" Then
                                Response.Redirect("0386EL1.aspx", False)
                            ElseIf formid = "41" Then
                                Response.Redirect("0386EOS1.aspx", False)
                            ElseIf formid = "49" Then
                                Response.Redirect("0386CNC2.aspx", False)
                            ElseIf formid = "71" Then
                                Response.Redirect("0386ES1.aspx", False)
                            ElseIf formid = "50" Then
                                Response.Redirect("0386EL1.aspx", False)
                            ElseIf formid = "51" Then
                                Response.Redirect("0386EOS1.aspx", False)
                            ElseIf formid = "52" Then
                                Response.Redirect("0386TL2.aspx", False)
                            ElseIf formid = "54" Then
                                Response.Redirect("0386TA1.aspx", False)
                            ElseIf formid = "53" Then
                                Response.Redirect("0386TL1.aspx", False)
                            ElseIf formid = "55" Then
                                Response.Redirect("0386CA1.aspx", False)
                            ElseIf formid = "56" Then
                                Response.Redirect("0386CUL1.aspx", False)
                            ElseIf formid = "57" Then
                                Response.Redirect("0386ER2.aspx", False)
                            ElseIf formid = "58" Then
                                Response.Redirect("0386EM2.aspx", False)
                            ElseIf formid = "59" Then
                                Response.Redirect("0386WIOL1.aspx", False)
                            ElseIf formid = "60" Then
                                Response.Redirect("0386WPL1.aspx", False)
                            ElseIf formid = "61" Then
                                Response.Redirect("0386QCL1.aspx", False)
                            ElseIf formid = "62" Then
                                Response.Redirect("0386QIL2.aspx", False)
                            ElseIf formid = "63" Then
                                Response.Redirect("0386QPS2.aspx", False)
                            ElseIf formid = "64" Then
                                Response.Redirect("0386QDC1.aspx", False)
                            ElseIf formid = "65" Then
                                Response.Redirect("0386QPL2.aspx", False)
                            ElseIf formid = "72" Then
                                Response.Redirect("0386S1.aspx", False)
                            ElseIf formid = "73" Then
                                Response.Redirect("0386S2.aspx", False)
                            ElseIf formid = "74" Then
                                Response.Redirect("0386S3.aspx", False)
                            ElseIf formid = "75" Then
                                Response.Redirect("0386S4.aspx", False)
                            ElseIf formid = "76" Then
                                Response.Redirect("0386S5.aspx", False)
                            ElseIf formid = "77" Then
                                Response.Redirect("0364PS1.aspx", False)
                            ElseIf formid = "78" Then
                                Response.Redirect("0364PS3.aspx", False)
                            ElseIf formid = "79" Then
                                Response.Redirect("0364PS2.aspx", False)
                            ElseIf formid = "46" Then
                                Response.Redirect("0364FIO1.aspx", False)
                            ElseIf formid = "82" Then
                                Response.Redirect("Utility2or3.aspx", False)
                            ElseIf formid = "83" Then
                                Response.Redirect("Maintenannce2or3.aspx", False)
                            ElseIf formid = "84" Then
                                Response.Redirect("Cheff.aspx", False)
                            ElseIf formid = "85" Then                               'start from Finance Department and his five form..
                                Response.Redirect("Finance_Accounting_Payable_New.aspx", False)
                            ElseIf formid = "86" Then
                                Response.Redirect("Costing_New.aspx", False)
                            ElseIf formid = "87" Then
                                Response.Redirect("Tax_New.aspx", False)
                            ElseIf formid = "88" Then
                                Response.Redirect("Banking_New.aspx", False)
                            ElseIf formid = "89" Then
                                Response.Redirect("Auditing_New.aspx", False)
                            ElseIf formid = "91" Then
                                Response.Redirect("Final_Review_New.aspx", False)
                            ElseIf formid = "90" Then
                                Response.Redirect("Finance_Accounting_Receivable_New.aspx", False)
                            ElseIf formid = "92" Then
                                Response.Redirect("ReSales.aspx", False)
                            ElseIf formid = "93" Then
                                Response.Redirect("ReSalesStaff.aspx", False)
                            End If
                        Else
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('This form is not printable.');window.location = '" + Request.RawUrl + "';", True)
                        End If
                    Else
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Still form not filled.');window.location = '" + Request.RawUrl + "';", True)
                    End If
                End If

            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect(Request.RawUrl)
    End Sub
    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Try

            Dim tblname As String = revimonth.Text
            tblname = tblname.Substring(4, 2)
            tblname = "20" + tblname

            strsql = "update dbo." + "[" + tblname + "]" + " set CL='" & cl.Text & "',Sl='" & sl.Text & "',PL='" & pl.Text & "',LWP='" & lwp.Text & "',
                    OtherLeaves='" & otherleaves.Text & "',ActualWorkingDays='" & actworking.Text & "',ActualPresentDays='" & actpresent.Text & "',
                    AbsentDays='" & absentdays.Text & "',LeavesScores='" & leavesscor.Text & "',Review_Dur='" & reviduring.Text & "',Review='" & rev.Text & "',
                    Status = '" & stat.Text & "' ,Score1='" & Scor1.Text & "' ,Score2='" & Scor2.Text & "' ,Score3='" & scor3.Text & "' ,Score4='" & Scor4.Text & "' ,
                    Score5='" & Scor5.Text & "' ,Score6='" & Scor6.Text & "',Score7='" & Scor7.Text & "',Score8='" & Scor8.Text & "',Score9='" & Scor9.Text & "',
                    Score10='" & Scor10.Text & "',Score11='" & Scor11.Text & "',Score12='" & Scor12.Text & "',Score13='" & Scor13.Text & "',
                    Score14='" & Scor14.Text & "',Score15='" & Scor15.Text & "',TotalMarks='" & totmark.Text & "',Remark='" & remark.Text & "',Famnt='" & famnt.Text & "',
                    Amnt1='" & amnt.Text & "' where  EmployeeCode='" & emplocode.Text & "'and  ReviewMonth='" & revimonth.Text & "'"
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


    Private Sub filter()
        Try
            If Not IsPostBack Then
                tbla.Items.Clear()
                strsql = "select TABLE_NAME from information_schema.tables where TABLE_NAME like '20'+'%'"
                If sqlselectmaster(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        tbla.DataSource = ds
                        tbla.DataTextField = "TABLE_NAME"
                        tbla.DataValueField = "TABLE_NAME"
                        tbla.DataBind()
                    End If
                End If
            End If
            '    If IsPostBack Then
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
                            ElseIf Session("access power") = "2" Or Session("access power") = "4" Then
                                alltbl.Add("select distinct ReviewMonth,Section from" + " " + "[dbo]" + "." + "[" + item.ToString + "]" + " " + "union")
                            End If
                        End If
                    Next
                    Dim result As String = String.Join(" ", alltbl)

                    strsql = result.Substring(0, result.Length() - 5)
                    If Session("access power") = "1" Then
                        strsql = "select * from (" + strsql + ") as Tb3 " + "order by ReviewMonth Desc"
                    ElseIf Session("access power") = "2" Then
                        strsql = "select * from (" + strsql + ") as Tb3 where Section='" & Session("Section") & "' " + "order by ReviewMonth Desc"
                    ElseIf Session("access power") = "4" Then
                        strsql = "select distinct ReviewMonth from (" + strsql + ") as Tb3 where Section in (" & Session("desg") & ") " + "order by ReviewMonth Desc"
                    End If
                    If sqlselectmaster(constr, strsql, "Abc") Then
                        If ds.Tables("Abc").Rows.Count > 0 Then
                            revmonth.DataSource = ds
                            revmonth.DataTextField = "ReviewMonth"
                            revmonth.DataValueField = "ReviewMonth"
                            revmonth.DataBind()
                        End If
                    End If
                End If

                If dept.SelectedValue = "All" Then
                    dept.Items.Clear()
                    dept.Items.Add("All")
                    Dim alltbl As New List(Of String)
                    For Each item As ListItem In tbla.Items
                        If item.Selected = True Then
                            Dim dbo As String = "[dbo]." + "[" + item.ToString + "]"
                            alltbl.Add("select distinct Department from " & dbo & "" + "Union")
                        End If
                    Next
                    Dim result As String = String.Join(" ", alltbl)
                    strsql = result.Substring(0, result.Length() - 5)
                    If Session("access power") = "1" Then
                        strsql = "select * from (" + strsql + ") as Tb3 "
                    ElseIf Session("access power") = "2" Or Session("access power") = "4" Then

                        If Session("access power") = "4" Then
                            Dim desgData = Session("desg").ToString()
                            strsql = "select distinct Department from Employee_Master1 where Section IN (" & desgData & ")"
                        Else
                            strsql = "select * from (" & strsql & ") as Tb3 where Department='" & Session("department") & "'"
                        End If




                    End If
                    If sqlselectmaster(constr, strsql, "Abc") Then
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
                                If Session("access power") = "1" Then
                                    alltbl.Add("Select distinct Section from " & dbo & "" + "Union")
                                ElseIf Session("access power") = "2" Or Session("access power") = "4" Then
                                    alltbl.Add("Select distinct Department,Section from " & dbo & "" + "Union")
                                End If
                            ElseIf sect.SelectedValue = "All" And dept.SelectedValue <> "All" Then
                                If Session("access power") = "1" Then
                                    alltbl.Add("select distinct Section from " & dbo & " where Department='" & dept.SelectedValue.Trim() & "'" + "Union")
                                ElseIf Session("access power") = "2" Or Session("access power") = "4" Then
                                    alltbl.Add("select distinct Department,Section from " & dbo & " where Department='" & dept.SelectedValue.Trim() & "'" + "Union")

                                End If
                            End If
                        End If
                    Next
                    Dim result As String = String.Join(" ", alltbl)
                    strsql = result.Substring(0, result.Length() - 5)
                    If Session("access power") = "1" Then
                        strsql = "select * from (" + strsql + ") as Tb3 "
                    ElseIf Session("access power") = "2" Or Session("access power") = "4" Then
                        If Session("access power") = "4" Then
                            Dim desgData = Session("desg").ToString()
                            strsql = "select distinct Section from Employee_Master1 where Section IN (" & desgData & ")"
                        Else
                            strsql = "select * from (" + strsql + ") as Tb3  where Section='" & Session("Section") & "'"
                        End If

                    End If
                    If sqlselectmaster(constr, strsql, "Abc") Then
                        If ds.Tables("Abc").Rows.Count > 0 Then
                            sect.DataSource = ds
                            sect.DataTextField = "Section"
                            sect.DataValueField = "Section"
                            sect.DataBind()
                        End If
                    End If
                End If

            End If
            ' End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

End Class