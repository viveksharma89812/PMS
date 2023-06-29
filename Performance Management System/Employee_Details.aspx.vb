Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Public Class WebForm13
    Inherits System.Web.UI.Page

    Dim strsql As String = ""
    Dim strsql1 As String = ""

    Dim tot As String = ""
    Dim review_period As String = ""
     Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'strsql = "select * From Employee_Master where  Department='" & Session("department") & "' and Designation <> 'GM' and Designation <>'AVP'"
        ' strsql = "select a.*,b.* From Employee_Master a join dbo.[2021] b on a.employeeCode=b.employeeCode where  a.Department='" & Session("department") & "' and Designation <> 'GM' and Designation <>'AVP' and b.ReviewMonth='Feb-21' "
        'filter()
        Dim year As String = DateTime.Now.Year
        Dim mont As String = DateTime.Now.AddMonths(-1).ToString("MM")
        Dim revmonth As String = DateTime.Now.AddMonths(-1).ToString("MMM")

        If mont = "12" Then
            year = DateTime.Now.AddYears(-1).ToString("yyyy")
        End If
        year = "[" + year + "]"
        revmonth = revmonth + "-" + year.Substring(3, 2)




        'strsql = "select a.*,b.* From Employee_Master a join dbo." & year & " b on a.employeeCode=b.employeeCode where  a.Department='" & Session("department") & "' and  Access_Power<>'2' and b.ReviewMonth='" & revmonth & "' "
        'If sqlselect(constr, strsql, "Abc") Then
        '    If ds.Tables("Abc").Rows.Count > 0 Then

        '        GridView1.DataSource = ds.Tables("Abc")
        '        GridView1.DataBind()
        '    Else
        'strsql = "select * From Employee_Master where Department='" & Session("department") & "' and  Access_Power<>'2' " and Section='" & Session("section") & "'


        If Session("section") = "Mixing" Or Session("section") = "Calender" Or Session("section") = "Calender (Cutting)" Or Session("section") = "Extrusion" Or Session("section") = "Tire Building" Or Session("section") = "Curing " Then
            strsql = "select * From Employee_Master1 where Department='" & Session("department") & "' and Section='" & Session("section") & "' and  Access_Power <> '2'  and  Access_Power <> '4' "
            strsql1 = "select Count (Form_Status) from [HR_PMS_web].[dbo].[2022] where  Form_Status = 'PENDING' "
            'If sqlselect(constr, strsql1, "Abc") Then
            '    If ds.Tables("Abc").Rows.Count > 0 Then
            '        Label70.Text = ds.Tables("Abc").Rows(0).Item(0).ToString
            '    End If
            'End If
        Else

            strsql = "select * From Employee_Master1 where Department='" & Session("department") & "' and  Access_Power<>'2'  and  Access_Power <> '4' "

        End If


        ' strsql = "select * From Employee_Master1 where Department='" & Session("department") & "' and Section='" & Session("section") & "' and  Access_Power<>'2'"

        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then

                GridView1.DataSource = ds.Tables("Abc")
                GridView1.DataBind()
                'Label70.Text = GridView1.Rows.Count.ToString()
                'strsql = "select Count (Form_Status) from [HR_PMS_web].[dbo].[2022] where  Form_Status = 'DONE' "
                'If sqlselect(constr, strsql, "Abc") Then
                '    If ds.Tables("Abc").Rows.Count > 0 Then
                '        Label70.Text = ds.Tables("Abc").Rows(0).Item(0).ToString
                '    End If
                'End If

                'GridView1.Columns(2).Visible = False
                'GridView1.Columns(3).Visible=False

            End If
        End If


        '    End If
        'End If
    End Sub

    'Private Sub filter()
    '    If Not IsPostBack Then
    '        'strsql = "select distinct Department from Employee_Master where EmployeeCode<>'HR'"
    '        strsql = "select distinct Form_Status from [HR_PMS_web].[dbo].[2022]"
    '        If sqlselect(constr, strsql, "Abc") Then
    '            If ds.Tables("Abc").Rows.Count > 0 Then
    '                Status.DataSource = ds
    '                Status.DataTextField = "Form_Status"
    '                Status.DataValueField = "Form_Status"
    '                Status.DataBind()
    '            End If
    '        End If



    '    End If
    '    If IsPostBack Then
    '        If Status.SelectedValue = "DONE" Then
    '            'Status.Items.Clear()
    '            'Status.Items.Add("All")
    '            Dim TextStr As List(Of String) = New List(Of String)()
    '            'strsql = "select distinct Department from Employee_Master"

    '            strsql = "select Count (Form_Status) from [HR_PMS_web].[dbo].[2022] where  Form_Status = 'DONE' "

    '            'Dim Str As String = String.Join(" and ", TextStr.ToArray())
    '            'strsql = strsql + " " + "where" + " " + Str + "and EmployeeCode<>'HR'"
    '            If sqlselect(constr, strsql, "Abc") Then
    '                If ds.Tables("Abc").Rows.Count > 0 Then
    '                    ' Label70.Text = strsql
    '                    Status.DataSource = ds
    '                    Status.DataTextField = "Form_Status"
    '                    Status.DataValueField = "Form_Status"
    '                    Status.DataBind()
    '                End If
    '            End If

    '        End If


    '    End If

    'End Sub


    Protected Sub Display(sender As Object, e As EventArgs)
        Try
            Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            empcode.Text = TryCast(row.FindControl("Label3"), Label).Text
            'strsql = "select * from Employee_Master where EmployeeCode='" & empcode.Text & "'"
            strsql = "select * from Employee_Master1 where EmployeeCode='" & empcode.Text & "'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then

                    empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    desig.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                    grd.Text = Convert.ToString(ds.Tables(0).Rows(0)("Grade"))
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
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#myModal').modal();});", True)
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
                Dim yea As String = DateTime.Now.Year

                Dim mon As String = DateTime.Now.AddMonths(-1).ToString("MM")

                If mon = "12" Then
                    yea = DateTime.Now.AddYears(-1).ToString("yyyy")
                End If
                yea = "[" + yea + "]"
                'strsql = "select a.*,b.* from Employee_Master a join dbo." & yea & " b  on a.EmployeeCode=b.EmployeeCode where a.EmployeeCode='" & abc & "'"
                strsql = "select a.*,b.* from Employee_Master1 a join dbo." & yea & " b  on a.EmployeeCode=b.EmployeeCode where a.EmployeeCode='" & abc & "'"
                'strsql = "select * from Employee_Master where EmployeeCode='" & abc & "'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        empcode.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                        empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                        desig.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                        grd.Text = Convert.ToString(ds.Tables(0).Rows(0)("Grade"))
                        dept.Text = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                        sect.Text = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                        doj.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                        dop.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOP"))
                        doc.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOC"))
                        doe.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOE"))
                        quali.Text = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                        preexp.Text = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                        reporting.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                        Dim rev As String = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
                        PMS_Form_Category.Text = Convert.ToString(ds.Tables(0).Rows(0)("PMS_Form_Category"))
                        mon = Convert.ToString(ds.Tables(0).Rows(0)("Review"))
                        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
                        review.Text = rev.Trim()

                        Session("empl code") = empcode.Text


                        Dim quarter As String = DateTime.Now.ToString("MM")
                        quarter = "01"
                        If quarter = "01" Or quarter = "04" Or quarter = "07" Or quarter = "10" Then
                            quarter = True
                        End If

                        Dim level As String = ""
                        If grd.Text.Contains("M-") Then
                            level = 1
                        ElseIf grd.Text.Contains("T-") Then
                            level = 2
                        End If
                        'If desig.Text.Contains("Manager") Then
                        '    level = 1
                        'ElseIf desig.Text.Contains("Operator") Then
                        '    level = 2
                        'End If

                        'Dim section As String = ""
                        'section = "Mixing"

                        If e.CommandName = "Form" And e.CommandName <> "Download" Then
                            If sect.Text = "Mixing" Then
                                'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M1.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M4.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M2.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M3.aspx", False)
                                If PMS_Form_Category.Text = "Mixing OP" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386M5.aspx", False)
                                End If
                            End If
                            If sect.Text = "Calender" Then
                                'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M1.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M4.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M2.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M3.aspx", False)
                                If PMS_Form_Category.Text = "Calender OP" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386CO1.aspx", False)
                                    ' Response.Redirect("WebForm15.aspx", False)
                                End If
                                If PMS_Form_Category.Text = "Calender(Cutting) OP" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386CO2.aspx", False)
                                End If
                            End If
                            If sect.Text = "Extrusion" Then
                                'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M1.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M4.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M2.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M3.aspx", False)
                                If PMS_Form_Category.Text = "Extrusion OP" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386EO1.aspx", False)
                                    If PMS_Form_Category.Text = "CNC" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386EC1.aspx", False)
                                        ' Response.Redirect("WebForm15.aspx", False)
                                    End If

                                End If
                            End If
                            If sect.Text = "Tire Building" Then

                                'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M4.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M2.aspx", False)

                                If PMS_Form_Category.Text = "Building OP" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386TBO1.aspx", False)
                                ElseIf PMS_Form_Category.Text = "Building assistant" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386TA1.aspx", False)
                                ElseIf PMS_Form_Category.Text = "Spraying Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386TL2.aspx", False)
                                ElseIf PMS_Form_Category.Text = "Semi-product OP" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386TSPO2.aspx", False)
                                ElseIf PMS_Form_Category.Text = "RN Operator" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386TRON03.aspx", False)
                                ElseIf PMS_Form_Category.Text = "Spraying OP" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386TSO4.aspx", False)
                                ElseIf PMS_Form_Category.Text = "Building Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386TL1.aspx", False)
                                    ' Response.Redirect("WebForm15.aspx", False)
                                    'Response.Redirect("WebForm43.aspx", False)
                                End If

                                End If

                                If sect.Text = "Curing" Then
                                    'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M1.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M4.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M2.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M3.aspx", False)
                                    If PMS_Form_Category.Text = "Curing OP" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386CUO1.aspx", False)
                                        ' Response.Redirect("WebForm15.aspx", False)
                                    End If

                                End If

                                If sect.Text = "Quality Control" Or sect.Text = "Quality System" Then
                                    'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M1.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M4.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M2.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M3.aspx", False)
                                    If PMS_Form_Category.Text = "Visual Inspection" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386QVO1.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "DB Inspection" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386QDO2.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "Sorting (Tires Scanning)" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386QSTO4.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "PDI Inspection" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386QPO4.aspx", False)
                                    End If
                                End If
                                If sect.Text = "Utility" Then
                                    'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M1.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M4.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M2.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M3.aspx", False)
                                    If PMS_Form_Category.Text = "Electrical team /Maintenance team" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386UE1.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "Operation team" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386UO1.aspx", False)
                                        ' Response.Redirect("WebForm15.aspx", False)
                                    End If

                                End If
                                If sect.Text = "Maintenance" Then
                                    'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M1.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M4.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M2.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M3.aspx", False)
                                    If PMS_Form_Category.Text = "Welder,Lathe machine Team,hooklift operator" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386MO1.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "Mechanical OP" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386ME1.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "Repair Engineer" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386MR1.aspx", False)
                                        ' Response.Redirect("WebForm15.aspx", False)
                                    End If

                                End If

                                If sect.Text = "Mold" Then
                                    'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M1.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M4.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M2.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M3.aspx", False)
                                    If PMS_Form_Category.Text = "Mold OP" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0386R1.aspx", False)
                                        'ElseIf PMS_Form_Category.Text = "Operation team" And (doe.Text = "" Or doe.Text = "-") Then
                                        '    Response.Redirect("0386UO1.aspx", False)
                                        ' Response.Redirect("WebForm15.aspx", False)
                                    End If

                                End If
                            If sect.Text = "EHS" Then
                                'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M1.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M4.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M2.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M3.aspx", False)
                                If PMS_Form_Category.Text = "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386EHS.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Operation team" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386UO1.aspx", False)
                                    ' Response.Redirect("WebForm15.aspx", False)
                                End If

                            End If
                            If sect.Text = "GA" Then
                                'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M1.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M4.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M2.aspx", False)
                                'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                '    Response.Redirect("0386M3.aspx", False)
                                If PMS_Form_Category.Text = "Chef" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("0386_Chef.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Operation team" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386UO1.aspx", False)
                                    ' Response.Redirect("WebForm15.aspx", False)
                                End If

                            End If
                            If dept.Text = "Planning" Then
                                    'If PMS_Form_Category.Text = "Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M1.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M4.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M2.aspx", False)
                                    'ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                    '    Response.Redirect("0386M3.aspx", False)
                                    If PMS_Form_Category.Text = "Planning OP" And review.Text = "During" And mon <> "12" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0366_Planning.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "Planning OP" And review.Text = "Probation" And mon <> "6" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0366_Planning.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "Planning OP" And review.Text = "During" And mon = "12" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0367_Planning.aspx", False)
                                    ElseIf PMS_Form_Category.Text = "Planning OP" And review.Text = "Probation" And mon = "6" And (doe.Text = "" Or doe.Text = "-") Then
                                        Response.Redirect("0367_Planning.aspx", False)
                                    End If
                                End If

                            If review.Text = "Training" And review.Text = "During" And mon <> "12" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Building assistant" And PMS_Form_Category.Text <> "Building Leader" And PMS_Form_Category.Text <> "Chef" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0364.aspx", False)
                            ElseIf dept.Text = "Planning" And review.Text = "Training" And review.Text = "During" And mon <> "12" Then
                                Response.Redirect("0364_Planning.aspx", False)
                            ElseIf review.Text = "Probation" And mon <> "6" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Building assistant" And PMS_Form_Category.Text <> "Chef" And PMS_Form_Category.Text <> "Building Leader" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0364.aspx", False)
                            ElseIf dept.Text = "Planning" And review.Text = "Probation" And mon <> "6" Then
                                Response.Redirect("0364_Planning.aspx", False)
                            ElseIf review.Text = "Training" And review.Text = "During" And mon = "12" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Building assistant" And PMS_Form_Category.Text <> "Building Leader" And PMS_Form_Category.Text <> "Chef" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0365.aspx", False)
                            ElseIf dept.Text = "Planning" And review.Text = "Training" And review.Text = "During" And mon = "12" Then
                                Response.Redirect("0365_Planning.aspx", False)
                            ElseIf review.Text = "Probation" And mon = "6" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Chef" And PMS_Form_Category.Text <> "Building assistant" And PMS_Form_Category.Text <> "Building Leader" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0365.aspx", False)
                            ElseIf dept.Text = "Planning" And review.Text = "Probation" And mon = "6" Then
                                Response.Redirect("0365_Planning.aspx", False)
                            ElseIf review.Text = "Confirm" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Chef" And PMS_Form_Category.Text <> "Building assistant" And PMS_Form_Category.Text <> "Building Leader" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And quarter = "True" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "-" Or doe.Text = "") Then
                                Response.Redirect("0386.aspx", False)
                            ElseIf dept.Text = "Planning" And review.Text = "Confirm" And quarter = "True" And (doe.Text = "-" Or doe.Text = "") Then
                                Response.Redirect("0386_Planning.aspx", False)
                            ElseIf review.Text = "Managerial" And quarter = "True" And PMS_Form_Category.Text <> "Chef" And PMS_Form_Category.Text <> "Building assistant" And PMS_Form_Category.Text <> "Building Leader" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0475.aspx", False)
                            End If

                            End If

                        End If
                    '  If e.CommandName = "Form" And e.CommandName <> "Download" Then
                    '  Select Case level
                    '   Case ""
                    'If review.Text = "Training" And review.Text = "During" And mon <> "12" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                    '    Response.Redirect("0364.aspx", False)
                    'ElseIf dept.Text = "Planning" And review.Text = "Training" And review.Text = "During" And mon <> "12" Then
                    '    Response.Redirect("0364_Planning.aspx", False)
                    'ElseIf review.Text = "Probation" And mon <> "6" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                    '    Response.Redirect("0364.aspx", False)
                    'ElseIf dept.Text = "Planning" And review.Text = "Probation" And mon <> "6" Then
                    '    Response.Redirect("0364_Planning.aspx", False)
                    'ElseIf review.Text = "Training" And review.Text = "During" And mon = "12" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                    '    Response.Redirect("0365.aspx", False)
                    'ElseIf dept.Text = "Planning" And review.Text = "Training" And review.Text = "During" And mon = "12" Then
                    '    Response.Redirect("0365_Planning.aspx", False)
                    'ElseIf review.Text = "Probation" And mon = "6" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                    '    Response.Redirect("0365.aspx", False)
                    'ElseIf dept.Text = "Planning" And review.Text = "Probation" And mon = "6" Then
                    '    Response.Redirect("0365_Planning.aspx", False)
                    'ElseIf review.Text = "Confirm" And dept.Text <> "Planning" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And quarter = "True" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "-" Or doe.Text = "") Then
                    '    Response.Redirect("0386.aspx", False)
                    'ElseIf dept.Text = "Planning" And review.Text = "Confirm" And quarter = "True" And (doe.Text = "-" Or doe.Text = "") Then
                    '    Response.Redirect("0386_Planning.aspx", False)
                    'ElseIf review.Text = "Managerial" And quarter = "True" And PMS_Form_Category.Text <> "Mixing OP" And PMS_Form_Category.Text <> "Calender OP" And PMS_Form_Category.Text <> "Calender(Cutting) OP" And PMS_Form_Category.Text <> "Extrusion OP" And PMS_Form_Category.Text <> "Curing OP" And PMS_Form_Category.Text <> "Building OP" And PMS_Form_Category.Text <> "Semi-product OP" And PMS_Form_Category.Text <> "RN Operator" And PMS_Form_Category.Text <> "Spraying OP" And PMS_Form_Category.Text <> "Visual Inspection" And PMS_Form_Category.Text <> "DB Inspection" And PMS_Form_Category.Text <> "Sorting (Tires Scanning)" And PMS_Form_Category.Text <> "PDI Inspection" And PMS_Form_Category.Text <> "Electrical team /Maintenance team" And PMS_Form_Category.Text <> "Operation team" And PMS_Form_Category.Text <> "Welder,Lathe machine Team,hooklift operator" And PMS_Form_Category.Text <> "Mold OP" And PMS_Form_Category.Text <> "Mechanical OP" And PMS_Form_Category.Text <> "Repair Engineer" And PMS_Form_Category.Text <> "CNC" And PMS_Form_Category.Text <> "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                    '    Response.Redirect("0475.aspx", False)

                    'End If




                    '  End Select
                    '  End If
                    'If e.CommandName = "Form" And e.CommandName <> "Download" Then
                    '    Select Case level
                    '        Case ""
                    '            If review.Text = "Training" And mon <> "12" And (doe.Text = "" Or doe.Text = "-") Then
                    '                Response.Redirect("0364.aspx", False)
                    '            ElseIf review.Text = "Probation" And mon <> "6" And (doe.Text = "" Or doe.Text = "-") Then
                    '                Response.Redirect("0364.aspx", False)
                    '            ElseIf review.Text = "Training" And mon = "12" And (doe.Text = "" Or doe.Text = "-") Then
                    '                Response.Redirect("0365.aspx", False)
                    '            ElseIf review.Text = "Probation" And mon = "6" And (doe.Text = "" Or doe.Text = "-") Then
                    '                Response.Redirect("0365.aspx", False)
                    '            ElseIf dept.Text = "Planning" And review.Text = "Confirm" And quarter = "True" And (doe.Text = "-" Or doe.Text = "") Then
                    '                Response.Redirect("0386_Planning.aspx", False)
                    '                'ElseIf review.Text = "Confirm" And sect.Text = "Mixing" And quarter = "True" And (doe.Text = "-" Or doe.Text = "") Then
                    '                '    Response.Redirect("0386M1.aspx", False)
                    '            ElseIf review.Text = "Confirm" And quarter = "True" And (doe.Text = "-" Or doe.Text = "") Then
                    '                Response.Redirect("0386.aspx", False)
                    '                ' Response.Redirect("0386M1.aspx", False)

                    '            ElseIf review.Text = "Managerial" And quarter = "True" And (doe.Text = "" Or doe.Text = "-") Then
                    '                Response.Redirect("0475.aspx", False)
                    '            End If
                    '            'Case "1"
                    '            '    If quarter = "True" And level = "1" And level <> "2" And (doe.Text = "" Or doe.Text = "-") Then
                    '            '        Response.Redirect("0475.aspx", False)
                    '            '    End If
                    '        Case "2"
                    '            If review.Text = "Training" And mon <> "12" And (doe.Text = "" Or doe.Text = "-") Then
                    '                If dept.Text = "Production" And sect.Text = "Engineering" Then
                    '                    Response.Redirect("0366_Maintenance.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text = "Utility" Then
                    '                    Response.Redirect("0366_Utility.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text <> "Utility" And sect.Text <> "Engineering" Then
                    '                    Response.Redirect("0366_Production.aspx", False)
                    '                ElseIf dept.Text = "Planning" Then
                    '                    Response.Redirect("0366_Planning.aspx", False)
                    '                ElseIf dept.Text = "QA" Then
                    '                    Response.Redirect("0366_QA.aspx", False)
                    '                ElseIf dept.Text = "RD2" Then
                    '                    Response.Redirect("0366_RD2_Mold.aspx", False)
                    '                End If
                    '            End If
                    '            If review.Text = "Training" And mon = "12" And (doe.Text = "" Or doe.Text = "-") Then
                    '                If dept.Text = "Production" And sect.Text = "Engineering" Then
                    '                    Response.Redirect("0367_Maintenance.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text = "Utility" Then
                    '                    Response.Redirect("0367_Utility.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text <> "Utility" And sect.Text <> "Engineering" Then
                    '                    Response.Redirect("0367_Production.aspx", False)
                    '                ElseIf dept.Text = "Planning" Then
                    '                    Response.Redirect("0367_Planning.aspx", False)
                    '                ElseIf dept.Text = "QA" Then
                    '                    Response.Redirect("0367_QA.aspx", False)
                    '                ElseIf dept.Text = "RD2" Then
                    '                    Response.Redirect("0367_RD2_Mold.aspx", False)
                    '                End If
                    '            End If
                    '            If review.Text = "Probation" And mon <> "6" And (doe.Text = "" Or doe.Text = "-") Then
                    '                If dept.Text = "Production" And sect.Text = "Engineering" Then
                    '                    Response.Redirect("0366_Maintenance.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text = "Utility" Then
                    '                    Response.Redirect("0366_Utility.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text <> "Utility" And sect.Text <> "Engineering" Then
                    '                    Response.Redirect("0366_Production.aspx", False)
                    '                ElseIf dept.Text = "Planning" Then
                    '                    Response.Redirect("0365_Planning.aspx", False)
                    '                ElseIf dept.Text = "QA" Then
                    '                    Response.Redirect("0366_QA.aspx", False)
                    '                ElseIf dept.Text = "RD2" Then
                    '                    Response.Redirect("0366_RD2_Mold.aspx", False)
                    '                End If
                    '            End If
                    '            If review.Text = "Probation" And mon = "6" And (doe.Text = "" Or doe.Text = "-") Then
                    '                If dept.Text = "Production" And sect.Text = "Engineering" Then
                    '                    Response.Redirect("0367_Maintenance.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text = "Utility" Then
                    '                    Response.Redirect("0367_Utility.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text <> "Utility" And sect.Text <> "Engineering" Then
                    '                    Response.Redirect("0367_Production.aspx", False)
                    '                ElseIf dept.Text = "Planning" Then
                    '                    Response.Redirect("0367_Planning.aspx", False)
                    '                ElseIf dept.Text = "QA" Then
                    '                    Response.Redirect("0367_QA.aspx", False)
                    '                ElseIf dept.Text = "RD2" Then
                    '                    Response.Redirect("0367_RD2_Mold.aspx", False)
                    '                End If
                    '            End If
                    '            If review.Text = "Confirm" And quarter = "True" And (doe.Text = "-" Or doe.Text = "") Then
                    '                If dept.Text = "Production" And sect.Text = "Engineering" Then
                    '                    Response.Redirect("0399_Maintenance.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text = "Utility" Then
                    '                    Response.Redirect("0399_Utility.aspx", False)
                    '                ElseIf dept.Text = "Production" And sect.Text <> "Utility" And sect.Text <> "Engineering" Then
                    '                    Response.Redirect("0399_Production.aspx", False)
                    '                ElseIf dept.Text = "Planning" Then
                    '                    Response.Redirect("0399_Planning.aspx", False)
                    '                ElseIf dept.Text = "QA" Then
                    '                    Response.Redirect("0399_QA.aspx", False)
                    '                ElseIf dept.Text = "RD2" Then
                    '                    Response.Redirect("0399_RD2_Mold.aspx", False)
                    '                End If
                    '            End If

                    '    End Select
                    'End If

                End If
                    End If

            'End If
            'Dim des As Date
            'Dim age As String = ""
            'Dim month As String = ""
            'Dim day As String = ""
            'des = DateTime.Now.ToString("yyyy-MM-dd")
            'Dim dj As Date = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
            'If review.Text = "Training Period" And doj.Text <> "" And doe.Text = "" Then
            '    Dim dt3 As TimeSpan = (des - dj)
            '    Dim diff As Double = dt3.Days
            '    age = Str(Int(diff / 365)) & " Year "
            '    diff = diff Mod 365
            '    month = Str(Int(diff / 30)) & " Month(s)"
            '    diff = diff Mod 30
            '    day = Str(diff) & " Day(s)"
            'ElseIf review.Text = "Probation Period" And dop.Text <> "" And doe.Text = "" Then
            '    Dim dp As Date = Convert.ToString(ds.Tables(0).Rows(0)("DOP"))
            '    Dim dt3 As TimeSpan = (des - dp)
            '    Dim diff As Double = dt3.Days
            '    age = Str(Int(diff / 365)) & " Year "
            '    diff = diff Mod 365
            '    month = Str(Int(diff / 30)) & " Month(s)"
            '    diff = diff Mod 30
            '    day = Str(diff) & " Day(s)"
            'ElseIf review.Text = "Permanent Review Period" And doc.Text <> "" And doe.Text = "" Then
            '    Dim dc As Date = Convert.ToString(ds.Tables(0).Rows(0)("DOC"))
            '    Dim dt3 As TimeSpan = (des - dc)
            '    Dim diff As Double = dt3.Days
            '    age = Str(Int(diff / 365)) & " Year "
            '    diff = diff Mod 365
            '    month = Str(Int(diff / 30)) & " Month(s)"
            '    diff = diff Mod 30
            '    day = Str(diff) & " Day(s)"

            'ElseIf doe.Text <> "" Then
            '    Dim de As Date = Convert.ToString(ds.Tables(0).Rows(0)("DOE"))
            '    Dim dt3 As TimeSpan = (des - de)
            '    Dim diff As Double = dt3.Days
            '    age = Str(Int(diff / 365)) & " Year "
            '    diff = diff Mod 365
            '    month = Str(Int(diff / 30)) & " Month(s)"
            '    diff = diff Mod 30
            '    day = Str(diff) & " Day(s)"
            'End If


            'Dim yea As String
            'Dim mon1 As String = DateTime.Now.AddMonths(-3).Month
            'Dim mon2 As String = DateTime.Now.AddMonths(-2).Month
            'Dim mon3 As String = DateTime.Now.AddMonths(-1).Month
            'Dim tot As String = ""
            'Dim tot1 As String = ""
            'Dim tot2 As String = ""
            'Dim tot3 As String = ""
            'If mon1 < 10 Then
            '    mon1 = "0" + mon1
            'End If
            'If mon2 < 10 Then
            '    mon2 = "0" + mon2
            'End If
            'If mon3 < 10 Then
            '    mon3 = "0" + mon3
            'End If
            'Dim m1 As Integer
            'Dim m2 As Integer
            'Dim m3 As Integer
            'If mon1 Then
            '    If mon1 > "10" Then
            '        yea = DateTime.Now.AddYears(-1).Year
            '    Else
            '        yea = DateTime.Now.Year
            '    End If

            '    tot1 = yea + mon1
            '    tot1 = "[dbo]" + ". " + "[" + tot1 + "]"
            '    strsql = "select TotalMarks from" + " " + tot1 + " " + "where EmployeeCode='" & abc & "'"
            '    If sqlselect(constr, strsql, "Abc") Then
            '        If ds.Tables("Abc").Rows.Count > 0 Then
            '            m1 = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
            '        End If
            '    End If
            'End If
            'If mon2 Then
            '    If mon2 > "10" Then
            '        yea = DateTime.Now.AddYears(-1).Year
            '    Else
            '        yea = DateTime.Now.Year
            '    End If

            '    tot2 = yea + mon2
            '    tot2 = "[dbo]" + ". " + "[" + tot2 + "]"
            '    strsql = "select TotalMarks from" + " " + tot2 + " " + "where EmployeeCode='" & abc & "'"
            '    If sqlselect(constr, strsql, "Abc") Then
            '        If ds.Tables("Abc").Rows.Count > 0 Then
            '            m2 = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
            '        End If
            '    End If
            'End If
            'If mon3 Then
            '    If mon3 > "10" Then
            '        yea = DateTime.Now.AddYears(-1).Year
            '    Else
            '        yea = DateTime.Now.Year
            '    End If
            '    tot3 = yea + mon3
            '    tot3 = "[dbo]" + ". " + "[" + tot3 + "]"
            '    strsql = "select TotalMarks from" + " " + tot3 + " " + "where EmployeeCode='" & abc & "'"
            '    If sqlselect(constr, strsql, "Abc") Then
            '        If ds.Tables("Abc").Rows.Count > 0 Then
            '            m3 = Convert.ToString(ds.Tables(0).Rows(0)("TotalMarks"))
            '        End If
            '    End If
            'End If

            'age = age.Substring(1, 2)
            'month = month.Substring(1, 2)
            'day = day.Substring(1, 2)
            'Dim rev As String
            'rev = review.Text

            'If rev = "Training Period" And doe.Text = "" Then
            '    If tot = m1.ToString >= "55" And m2.ToString >= "55" And m3.ToString >= "55" Then
            '        tot = m1 + m2 + m3
            '        Convert.ToInt16(tot)
            '        tot = tot / 3
            '    End If
            '    rev = "Training Period"
            'ElseIf rev = "Probation Period" And doe.Text = "" Then
            '    If tot = m1.ToString >= "65" And m2.ToString >= "65" And m3.ToString >= "65" Then
            '        tot = m1 + m2 + m3
            '        Convert.ToInt16(tot)
            '        tot = tot / 3
            '    End If
            '    rev = "Probation Period"
            'ElseIf rev = "Permanent Review Period" And doe.Text = "" Then
            '    If tot = m1 + m2 + m3 >= "76" Then
            '        tot = m1 + m2 + m3
            '        Convert.ToInt16(tot)
            '        tot = tot / 3
            '    End If
            '    rev = "Permanent Review Period"
            'Else
            '    rev = "Extend"
            'End If

            'Select Case rev
            '    Case "Training Period"
            '        If age < "1" And month = "11" And day >= "1" And tot >= 66 Then
            '            Response.Redirect("0365.aspx", False)
            '        ElseIf age < "1" And tot >= 66 Then
            '            Response.Redirect("0364.aspx", False)
            '        End If
            '    Case "Probation Period"
            '        If Convert.ToInt16(month) = "5" And day >= "1" And tot >= 71 Then
            '            Response.Redirect("0365.aspx", False)
            '        ElseIf tot >= 71 Then
            '            Response.Redirect("0364.aspx", False)
            '        End If
            '    Case "Permanent Review Period"
            '        If month >= "1" And tot >= 76 Then
            '            Response.Redirect("0386.aspx", False)
            '        End If
            '    Case "Extend"
            '        If Convert.ToInt16(month) = "1" And Convert.ToInt16(day) = "0" Then
            '            Response.Redirect("0503.aspx", False)
            '        ElseIf month <= 4 Then
            '            Response.Redirect("0504.aspx", False)

            '        End If

            'End Select


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim year As String = DateTime.Now.Year
            Dim mont As String = DateTime.Now.AddMonths(-1).ToString("MM")
            Dim revmonth As String = DateTime.Now.AddMonths(-1).ToString("MMM")
            Dim formstat As Label = e.Row.FindControl("Label2")
            Dim lnk As LinkButton = e.Row.FindControl("revform")
            Dim lbl As Label = e.Row.FindControl("Label1")
            Dim rev As Label = e.Row.FindControl("Label3")
            If mont = "12" Then
                year = DateTime.Now.AddYears(-1).ToString("yyyy")
            End If
            year = "[" + year + "]"
            revmonth = revmonth + "-" + year.Substring(3, 2)
            strsql = "select * from dbo." & year & " where EmployeeCode='" & rev.Text & "' and ReviewMonth='" & revmonth & "'"
            'strsql = "select a.*,b.* From Employee_Master a join dbo." & year & " b on a.employeeCode=b.employeeCode where  a.Department='" & Session("department") & "' and  Access_Power<>'2' and b.ReviewMonth='" & revmonth & "' "
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    formstat.Text = Convert.ToString(ds.Tables(0).Rows(0)("Form_Status"))
                Else
                End If
                If formstat.Text = "" Then

                    lnk.Visible = False
                    rev.Text = "No Form"
                    rev.Visible = True
                    formstat.Text = "No Form"
                    formstat.ForeColor = System.Drawing.Color.Red
                    formstat.Font.Bold = True
                End If
            End If


            Dim revform As LinkButton = e.Row.FindControl("revform")
            If lbl.Text = "Confirm" Then
                Dim dt As String = DateTime.Now.ToString("MM")
                If (dt = "01" Or dt = "04" Or dt = "07" Or dt = "10") And rev.Text <> "No Form" Then
                    lnk.Visible = True
                ElseIf rev.Text = "No Form" Then
                    formstat.Text = "No Form"
                    formstat.ForeColor = System.Drawing.Color.Red
                    formstat.Font.Bold = True
                Else
                    lnk.Visible = False
                    rev.Visible = True
                    rev.Text = "Quarter Review"
                    formstat.Text = "Quarter Review"
                    formstat.ForeColor = System.Drawing.Color.HotPink
                    rev.ForeColor = System.Drawing.Color.HotPink
                End If
            End If

            If formstat.Text = "DONE" Then
                revform.Visible = False
                rev.Visible = True
                rev.Text = "CLOSED"
                formstat.ForeColor = System.Drawing.Color.Green
                formstat.Font.Bold = True
            ElseIf formstat.Text = "PENDING" Then
                formstat.ForeColor = System.Drawing.Color.Red
                formstat.Font.Bold = True
            End If

            If rev.Text = "CLOSED" Then
                rev.ForeColor = System.Drawing.Color.Blue
                rev.Font.Bold = True
            End If
        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
End Class