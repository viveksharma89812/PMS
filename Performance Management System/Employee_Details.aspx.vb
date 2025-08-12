Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Public Class WebForm13
    Inherits System.Web.UI.Page

    '--------------------------------------- standartd variable declared here ---------------------------------------
    Dim PMSclass As New PMSClass()
    Dim strsql As String = ""
    Dim strsql1 As String = ""

    Dim tot As String = ""
    Dim review_period As String = ""


    '-------------------------------- Empolyee Details form load ------------------------------------------


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try


            If Session("access power") = "" Then
                Response.Redirect("login.aspx")
            End If
            Dim year As String = DateTime.Now.Year
            Dim mont As String = DateTime.Now.AddMonths(-1).ToString("MM")
            Dim revmonth As String = DateTime.Now.AddMonths(-1).ToString("MMM")
            If mont = "12" Then
                year = DateTime.Now.AddYears(-1).ToString("yyyy")
            End If
            year = year
            revmonth = revmonth + "-" + year.Substring(2, 2)
            Session("section").trim()
            ' List of sections that require the first query
            Dim validSections As String() = {"2-Wheeler", "4-Wheeler", "Accounting & Tax", "Branding & Communication", "Calender", "Cutting",
                                            "Channel Management", "Curing", "East Region", "EHS", "ER & IR", "Export",
                                            "Banking", "Extrusion", "Factory Affair", "Formulation Development",
                                            "GA", "HR", "HRM", "Import & Export", "IT Equipment", "Learning & Development",
                                            "Legal", "Logistics Solution", "Maintenance", "Mixing", "Mold", "North Region",
                                            "OE", "OES & FLEET", "Operation IT", "Plan & Audit Control", "Planning",
                                            "PPI", "Product Development", "Product Management", "Product Warehouse",
                                            "Production IT", "Project Management", "Purchase & Store", "Quality Control",
                                            "Quality System", "Raw Material", "Raw Material - Purchase", "Raw Material Management",
                                            "RE", "South Region", "Talent Acquisition", "Test", "Tire Building", "Utility", "Accounting", "CO", "Taxation", "Auditing",
                                            "West Region"}

            ' Check if the current section is in the list of valid sections
            If validSections.Contains(Session("section")) And Session("access power") = "2" Then
                Dim dt As DataTable = PMSclass.employeerecordssect(year, Session("department"), Session("section"), revmonth)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    lblcount.Text = dt.Rows.Count
                    GridView1.DataSource = dt
                    GridView1.DataBind()

                End If
            ElseIf Session("access power") = "4" Or Session("access power") = "2" Then
                Dim dt As DataTable
                If Session("access power") = "4" Then
                    dt = PMSclass.employeerecordsdept(year, Session("desg"), revmonth, Session("emp code").ToString)
                Else
                    dt = PMSclass.Sectionheadanother(year, Session("desg"), revmonth)
                End If



                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    GridView1.DataSource = dt
                    GridView1.DataBind()

                End If
            ElseIf Session("access power") = "5" Then
                Dim dt As DataTable = PMSclass.Plantheadapproved(year, revmonth)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    '--------------------------------- Employee details display popup----------------------------
    Protected Sub Display(sender As Object, e As EventArgs)
        Try

            Dim linkButton As LinkButton = CType(sender, LinkButton)
            Dim employeeCode As String = linkButton.CommandArgument


            Dim dt As DataTable = PMSclass.Getempdetails(employeeCode)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                empcode.Text = employeeCode
                empname.Text = Convert.ToString(dt.Rows(0)("EmployeeName"))
                desig.Text = Convert.ToString(dt.Rows(0)("Designation"))
                grd.Text = Convert.ToString(dt.Rows(0)("Grade"))
                dept.Text = Convert.ToString(dt.Rows(0)("Department"))
                sect.Text = Convert.ToString(dt.Rows(0)("Section"))
                doj.Text = Convert.ToString(dt.Rows(0)("DOJ"))
                dop.Text = Convert.ToString(dt.Rows(0)("DOP"))
                doc.Text = Convert.ToString(dt.Rows(0)("DOC"))
                doe.Text = Convert.ToString(dt.Rows(0)("DOE"))
                quali.Text = Convert.ToString(dt.Rows(0)("Qualification"))
                preexp.Text = Convert.ToString(dt.Rows(0)("PreviousExperience"))
                reporting.Text = Convert.ToString(dt.Rows(0)("ReportingPersonName"))
                review.Text = Convert.ToString(dt.Rows(0)("Review_Period"))
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#myModal').modal();});", True)

            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your Userid and Password is incorrect');window.location = '" + Request.RawUrl + "';", True)

            End If
        Catch ex As Exception

        End Try
    End Sub

    ' ----------------- ---------- Gridview rowcommand --------------------------------------------------

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


                Dim dt As DataTable = PMSclass.reviewclick(abc, yea)

                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                    empcode.Text = Convert.ToString(dt.Rows(0)("EmployeeCode"))
                    empname.Text = Convert.ToString(dt.Rows(0)("EmployeeName"))
                    desig.Text = Convert.ToString(dt.Rows(0)("Designation"))
                    grd.Text = Convert.ToString(dt.Rows(0)("Grade"))
                    dept.Text = Convert.ToString(dt.Rows(0)("Department"))
                    sect.Text = Convert.ToString(dt.Rows(0)("Section"))
                    doj.Text = Convert.ToString(dt.Rows(0)("DOJ"))
                    dop.Text = Convert.ToString(dt.Rows(0)("DOP"))
                    doc.Text = Convert.ToString(dt.Rows(0)("DOC"))
                    doe.Text = Convert.ToString(dt.Rows(0)("DOE"))
                    quali.Text = Convert.ToString(dt.Rows(0)("Qualification"))
                    preexp.Text = Convert.ToString(dt.Rows(0)("PreviousExperience"))
                    reporting.Text = Convert.ToString(dt.Rows(0)("ReportingPersonName"))
                    Dim rev As String = Convert.ToString(dt.Rows(0)("Review_Period"))
                    PMS_Form_Category.Text = Convert.ToString(dt.Rows(0)("PMS_Form_Category"))
                    mon = Convert.ToString(dt.Rows(0)("Review"))

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
                    If e.CommandName = "Form" And e.CommandName <> "Download" Then
                        sect.Text = sect.Text.Trim()
                        PMS_Form_Category.Text = PMS_Form_Category.Text.Trim()

                        ' -------------------------------------- Mixing section forms ----------------------------

                        If sect.Text = "Mixing" Then
                            If PMS_Form_Category.Text = "Mixing Control room supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386M1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Mixing Control room /office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386M4.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Mixing Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386M2.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Mixing Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386M3.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Mixing OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386M5.aspx", False)
                            End If
                        End If

                        ' -------------------------------------- Calender section forms ----------------------------

                        If sect.Text = "Calender" Or sect.Text = "Cutting" Then
                            If PMS_Form_Category.Text = "Calender Office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386CST1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Calendering Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386CS1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Calendering Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386CL1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "(Cutting Leader)" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386CL2.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Calender OP" And (doe.Text = "" Or doe.Text = "-" Or doe.Text = "0") Then
                                Response.Redirect("0386CO1.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Calender(Cutting) OP" And (doe.Text = "" Or doe.Text = "-" Or doe.Text = "0") Then
                                Response.Redirect("0386CO2.aspx", False)
                            End If
                        End If
                        ' -------------------------------------- Extrusion section forms ----------------------------

                        If sect.Text = "Extrusion" Then

                            If PMS_Form_Category.Text = "Extrusion Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386EL1.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "CNC" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386CNC2.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Extrusion OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386EO1.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Extrusion Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386ES1.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Extrusion Office staff" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386EOS1.aspx", False)
                            End If
                        End If

                        ' -------------------------------------- Curing section forms ----------------------------

                        If sect.Text = "Curing" Then

                            If PMS_Form_Category.Text = "Curing OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386CUO1.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Curing assistant" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386CA1.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Curing Leader /Bladder Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386CUL1.aspx", False)
                            End If
                        End If

                        ' -------------------------------------- Tire Building section forms ----------------------------

                        If sect.Text = "Tire Building" Then
                            If PMS_Form_Category.Text = "Building OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386TBO1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Building assistant Level 2" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386TA1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Building assistant Leavel3" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386TAL3.aspx", False)
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
                            End If
                        End If
                        ' -------------------------------------- Quality Control and Quality System section forms ----------------------------

                        If sect.Text = "Quality Control" Or sect.Text = "Quality System" Then


                            If PMS_Form_Category.Text = "Visual Inspection" Or PMS_Form_Category.Text = "DB Inspection" Or PMS_Form_Category.Text = "Visual Inspection OR DB Inspection" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QVO1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Sorting (Tires Scanning)" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QSTO3.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Pdi Shift supervisor Level 3" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QPO5.aspx", False)
                            ElseIf PMS_Form_Category.Text = "PDI OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QPO4.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Calibration" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QCL1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Pdi Shift Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QPS2.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Pdi Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QPL2.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Inspection leader & Supervisor" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QIL2.aspx", False)
                            ElseIf PMS_Form_Category.Text = "QA DCC" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386QDC1.aspx", False)
                            End If

                            If PMS_Form_Category.Text = "IQC TB & Cutting /IQC Extrusion)" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386P1.aspx", False)
                            End If
                        End If

                        ' -------------------------------------- Utility section forms ----------------------------------

                        'If sect.Text = "Utility" Then
                        '    If PMS_Form_Category.Text = "Electrical team /Maintenance team" And (doe.Text = "" Or doe.Text = "-") Then
                        '        Response.Redirect("0386UE1.aspx", False)
                        '    ElseIf PMS_Form_Category.Text = "Operation team" And (doe.Text = "" Or doe.Text = "-") Then
                        '        Response.Redirect("0386UO1.aspx", False)
                        '    End If
                        'End If

                        ' -------------------------------------- Maintenance  section forms ------------------------------

                        If sect.Text = "Maintenance" Or sect.Text = "Utility" Then

                            If PMS_Form_Category.Text = "Maintenance Level 2 and 3" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("Maintenannce2or3.aspx", False)
                            End If

                            If PMS_Form_Category.Text = "Utility Level 2 and 3" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("Utility2or3.aspx", False)
                            End If
                        End If

                        ' -------------------------------------- Mold section forms --------------------------------------

                        If sect.Text = "Mold" Then
                            If PMS_Form_Category.Text = "Mold OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386R1.aspx", False)
                            End If
                        End If

                        ' -------------------------------------- EHS section forms ------------------------------------------

                        If sect.Text = "EHS" Then
                            If PMS_Form_Category.Text = "EHS" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386EHS.aspx", False)
                            End If
                        End If

                        ' -------------------------------------- GA section forms ----------------------------

                        If sect.Text = "GA" Then
                            If PMS_Form_Category.Text = "Chef" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("Cheff.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "GA OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0366GAORPS.aspx", False)
                            End If
                        End If
                        ' -------------------------------------- PPI section forms ----------------------------
                        If sect.Text = "PPI" Then
                            If PMS_Form_Category.Text = "IQC TB & Cutting /IQC Extrusion)" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386P1.aspx", False)
                            End If
                        End If
                        ' -------------------------------------- Raw material Management section forms ----------------------------

                        If sect.Text = "Raw material Management" Then
                            If PMS_Form_Category.Text = "Planning OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0366_Planning.aspx", False)
                            End If
                        End If

                        ' -------------------------------------- Product Warehouse section forms ----------------------------

                        If sect.Text = "Product Warehouse" Then
                            If PMS_Form_Category.Text = "Warehouse OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386WHO1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Packing / Loading Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386WPL1.aspx", False)
                            ElseIf PMS_Form_Category.Text = "Inward/Outward Leader" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386WIOL1.aspx", False)
                            End If
                        End If

                        ' --------------------------------------ER & IR section forms ----------------------------

                        If sect.Text = "ER & IR" Then
                            If PMS_Form_Category.Text = "HR CW Level - 3" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0386HCWO1.aspx", False)
                            End If
                        End If

                        ' -------------------------------------Export-Import & Banking section forms ----------------------------

                        If sect.Text = "Banking" Or sect.Text = "CO" Or sect.Text = "Taxation" Or sect.Text = "Auditing" Or sect.Text = "Accounting" Or sect.Text = "Channel Management" Then
                            If PMS_Form_Category.Text = "Finance OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0364FIO1.aspx", False)
                            Else
                                If PMS_Form_Category.Text = "Banking Level 2" And (doe.Text = "" Or doe.Text = "-") Then
                                    Response.Redirect("Banking_New.aspx", False)
                                End If
                            End If
                            If PMS_Form_Category.Text = "CO Level 2" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("Costing_New.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Taxation Level 2" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("Tax_New.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Auditing Level 2" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("Auditing_New.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Accounting Level  Payable Level 2" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("Finance_Accounting_Payable_New.aspx", False)
                            End If
                            If PMS_Form_Category.Text = "Accounting Level  Receivable Level 2" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("Finance_Accounting_Receivable_New.aspx", False)
                            End If
                        End If



                        ' -------------------------------------Purchase & Store section forms ----------------------------

                        If sect.Text = "Purchase & Store" Then
                            If PMS_Form_Category.Text = "Purchase & Store OP" And (doe.Text = "" Or doe.Text = "-") Then
                                Response.Redirect("0366GAORPS.aspx", False)
                            End If
                        End If

                        ' ------------------------------------- Staff section forms ----------------------------

                        ' If sect.Text = "Staff" Then
                        If PMS_Form_Category.Text = "Training_Probation Period During Review Form (For Staff)" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0386S1.aspx", False)
                        ElseIf PMS_Form_Category.Text = "Training_Probation Period During Review Form (For Staff)" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0386S1.aspx", False)
                        ElseIf PMS_Form_Category.Text = "Apprenticeship Period During Review" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0386S2.aspx", False)
                        ElseIf PMS_Form_Category.Text = "Performance Review Form (For Confirmed Staff)" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0386S4.aspx", False)
                        ElseIf PMS_Form_Category.Text = "Performance review Form (For Managerial level)" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0386S5.aspx", False)
                        ElseIf PMS_Form_Category.Text = "FTE Staff During Review Form" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0386S3.aspx", False)
                        End If
                        '  End If

                        ' ------------------------------------- Planning Staff section forms ----------------------------

                        '    If sect.Text = "Planning staff" Then
                        If PMS_Form_Category.Text = "Training_Probation Period During Review Form (For Planning)" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0364PS1.aspx", False)
                        ElseIf PMS_Form_Category.Text = "FTE Staff During Review Form (For Planning)" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0364PS2.aspx", False)
                        ElseIf PMS_Form_Category.Text = "Performance Review Form (For Confirmed Planning Staff)" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("0364PS3.aspx", False)
                        ElseIf PMS_Form_Category.Text = "Final Review Form" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("Final_Review_New.aspx", False)
                        ElseIf PMS_Form_Category.Text = "Final Review ReSales Leader Form" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("ReSales.aspx", False)
                        ElseIf PMS_Form_Category.Text = "Final Review ReSales Staff Form" And (doe.Text = "" Or doe.Text = "-") Then
                            Response.Redirect("ReSalesStaff.aspx", False)
                        End If
                    End If

                End If

            End If


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    ' -------------------------------------gridview row wise editor-------------------------------------
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim year As String = DateTime.Now.Year
                Dim mont As String = DateTime.Now.AddMonths(-1).ToString("MM")
                Dim revmonth As String = DateTime.Now.AddMonths(-1).ToString("MMM")
                Dim formstat As Label = e.Row.FindControl("Label2")
                Dim shstat As Label = e.Row.FindControl("Label4")
                Dim lnk As LinkButton = e.Row.FindControl("revform")
                Dim lbl As Label = e.Row.FindControl("Label1")
                Dim rev As Label = e.Row.FindControl("Label3")

                Dim grade As String = ""

                If mont = "12" Then
                    year = DateTime.Now.AddYears(-1).ToString("yyyy")
                End If

                revmonth = revmonth + "-" + year.Substring(2, 2)

                Dim dtt As DataTable = PMSclass.Filterdata(rev.Text, revmonth, year)

                If dtt IsNot Nothing AndAlso dtt.Rows.Count > 0 Then

                    formstat.Text = Convert.ToString(dtt.Rows(0)("Form_Status"))
                    shstat.Text = Convert.ToString(dtt.Rows(0)("Sect_Accept"))
                    grade = Convert.ToString(dtt.Rows(0)("Grade"))
                    If formstat.Text = "" Then
                        lnk.Visible = False
                        rev.Text = "No Form"
                        rev.Visible = True
                        formstat.Text = "No Form"
                        formstat.ForeColor = System.Drawing.Color.Red
                        formstat.Font.Bold = True
                    End If
                End If


                If shstat.Text = "" Then
                    shstat.Text = "PENDING"
                    shstat.ForeColor = System.Drawing.Color.Red
                    If Label7.Text = "Label" Then
                        Label7.Text = 0
                        Label7.Text = (CInt(Label7.Text) + 1).ToString
                    Else
                        Label7.Text = (CInt(Label7.Text) + 1).ToString
                    End If
                End If
                If Label18.Text = "Label" Then
                    Label18.Text = 0
                End If
                If shstat.Text = "Done" Then
                    Label18.Text = (CInt(Label18.Text) + 1).ToString
                End If
                grade.Trim()
                Dim revform As LinkButton = e.Row.FindControl("revform")
                If lbl.Text = "Confirm" And (grade <> "T-1" And grade <> "T-2" And grade <> "T-3" And grade <> "T-4" And grade <> "T-5" And grade <> "T-6") Then
                    Dim dt As String = DateTime.Now.AddMonths(-1).ToString("MM")
                    If (dt = "03" Or dt = "06" Or dt = "09" Or dt = "12") And rev.Text <> "No Form" Then
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

                If Label16.Text = "Label" Then
                    Label16.Text = 0
                End If
                If formstat.Text = "DONE" Then
                    revform.Visible = False
                    rev.Visible = True
                    rev.Text = "CLOSED"
                    formstat.ForeColor = System.Drawing.Color.Green
                    formstat.Font.Bold = True
                    If Label16.Text = "Label" Then
                        Label16.Text = 0
                    Else
                        Label16.Text = (CInt(Label16.Text) + 1).ToString
                    End If

                ElseIf formstat.Text = "PENDING" Then
                    formstat.ForeColor = System.Drawing.Color.Red
                    formstat.Font.Bold = True
                End If

                If rev.Text = "CLOSED" Then
                    rev.ForeColor = System.Drawing.Color.Blue
                    rev.Font.Bold = True
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub



    'Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
    '    Try
    '        If e.Row.RowType <> DataControlRowType.DataRow Then Exit Sub

    '        Dim year As Integer = DateTime.Now.Year
    '        Dim mont As String = DateTime.Now.AddMonths(-1).ToString("MM")
    '        Dim revmonth As String = DateTime.Now.AddMonths(-1).ToString("MMM")

    '        If mont = "12" Then
    '            year -= 1
    '        End If

    '        Dim yearStr As String = "[" & year.ToString() & "]"
    '        revmonth &= "-" & year.ToString().Substring(2, 2)

    '        Dim formstat As Label = e.Row.FindControl("Label2")
    '        Dim shstat As Label = e.Row.FindControl("Label4")
    '        Dim lnk As LinkButton = e.Row.FindControl("revform")
    '        Dim lbl As Label = e.Row.FindControl("Label1")
    '        Dim rev As Label = e.Row.FindControl("Label3")

    '        Dim revQuery As String = $"SELECT * FROM dbo.{yearStr} AS a 
    '                               INNER JOIN Employee_Master1 e ON e.EmployeeCode = a.EmployeeCode 
    '                               WHERE a.EmployeeCode = '{rev.Text}' AND a.ReviewMonth = '{revmonth}' 
    '                               ORDER BY a.Form_Status DESC"

    '        If sqlselect(constr, revQuery, "Abc") Then
    '            If ds.Tables("Abc").Rows.Count > 0 Then
    '                Dim row As DataRow = ds.Tables("Abc").Rows(0)
    '                formstat.Text = row("Form_Status").ToString()
    '                shstat.Text = row("Sect_Accept").ToString()
    '                Dim grade As String = row("Grade").ToString()

    '                HandleFormStatus(formstat, lnk, rev, shstat, lbl, grade)
    '            Else
    '                SetNoFormStatus(formstat, lnk, rev)
    '            End If
    '        End If

    '        UpdatePendingAndDoneLabels(shstat)
    '    Catch ex As Exception
    '        ' Log or handle the exception as necessary
    '    End Try
    'End Sub

    'Private Sub HandleFormStatus(formstat As Label, lnk As LinkButton, rev As Label, shstat As Label, lbl As Label, grade As String)
    '    If String.IsNullOrEmpty(formstat.Text) Then
    '        SetNoFormStatus(formstat, lnk, rev)
    '    ElseIf formstat.Text.Equals("DONE", StringComparison.OrdinalIgnoreCase) Then
    '        lnk.Visible = False
    '        rev.Text = "CLOSED"
    '        formstat.ForeColor = Color.Green
    '        formstat.Font.Bold = True
    '    ElseIf formstat.Text.Equals("PENDING", StringComparison.OrdinalIgnoreCase) Then
    '        formstat.ForeColor = Color.Red
    '        formstat.Font.Bold = True
    '    End If

    '    ' Additional handling for confirmed reviews
    '    If lbl.Text = "Confirm" AndAlso grade <> "T-3" Then
    '        HandleQuarterReview(lnk, rev)
    '    End If
    'End Sub

    'Private Sub SetNoFormStatus(formstat As Label, lnk As LinkButton, rev As Label)
    '    lnk.Visible = False
    '    rev.Text = "No Form"
    '    rev.Visible = True
    '    formstat.Text = "No Form"
    '    formstat.ForeColor = Color.Red
    '    formstat.Font.Bold = True
    'End Sub

    'Private Sub HandleQuarterReview(lnk As LinkButton, rev As Label)
    '    Dim dt As String = DateTime.Now.AddMonths(-1).ToString("MM")
    '    If {"03", "06", "09", "12"}.Contains(dt) AndAlso rev.Text <> "No Form" Then
    '        lnk.Visible = True
    '    Else
    '        lnk.Visible = False
    '        rev.Text = "Quarter Review"
    '        rev.ForeColor = Color.HotPink
    '    End If
    'End Sub

    'Private Sub UpdatePendingAndDoneLabels(shstat As Label)
    '    If String.IsNullOrEmpty(shstat.Text) Then
    '        shstat.Text = "PENDING"
    '        shstat.ForeColor = Color.Red
    '    End If

    '    ' Update other labels based on conditions
    '    ' This logic should be based on your requirements
    '    If shstat.Text.Equals("Done", StringComparison.OrdinalIgnoreCase) Then
    '        Label18.Text = (CInt(Label18.Text) + 1).ToString()
    '    End If
    'End Sub

End Class

