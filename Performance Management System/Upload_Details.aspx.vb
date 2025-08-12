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
Imports System.IO.Path
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Security
Imports System.Net.Mail
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Core
Imports Color = System.Drawing.Color
Imports System.Web.UI
Imports System.Configuration
Imports Control = System.Web.UI.Control

Public Class WebForm3
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim errorms As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = ""
        If Session("access power") = "" Then
            Response.Redirect("login.aspx")
        End If


        fill()
        filter()

    End Sub


    Private Sub fill()

        'strsql = "select * from Employee_Master"
        strsql = "select * from Employee_Master1"
        Dim TextStr As List(Of String) = New List(Of String)()
        If department.SelectedValue <> "All" Then TextStr.Add("Department='" & department.SelectedValue & "'")
        If Section.SelectedValue <> "All" Then TextStr.Add("Section='" & Section.SelectedValue & "'")
        If empcode.Text <> "" Then TextStr.Add("EmployeeCode like '" & empcode.Text & "'+'%'")
        Dim str As String = String.Join(" and ", TextStr.ToArray())

        strsql = strsql + " " + "where" + " " + str + "and EmployeeCode<>'HR'"
        If sqlselectmaster(constr, strsql, "Abc") Then
            GridView1.DataSource = ds
            GridView1.DataBind()
        End If
        If department.SelectedValue = "All" And Section.SelectedValue = "All" And empcode.Text = "" Then
            'strsql = "Select * from Employee_Master where EmployeeCode<>'HR'"
            strsql = "Select * from Employee_Master1 where EmployeeCode<>'HR'"
            If sqlselectmaster(constr, strsql, "Abc") Then
                GridView1.DataSource = ds
                GridView1.DataBind()
            End If
        End If

    End Sub
    Private Sub filter()
        If Not IsPostBack Then
            'strsql = "select distinct Department from Employee_Master where EmployeeCode<>'HR'"
            strsql = "select distinct Department from Employee_Master1 where EmployeeCode<>'HR'"
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    department.DataSource = ds
                    department.DataTextField = "Department"
                    department.DataValueField = "Department"
                    department.DataBind()
                End If
            End If

            'strsql = "select distinct Section from Employee_Master where EmployeeCode<>'HR'"
            strsql = "select distinct Section from Employee_Master1 where EmployeeCode<>'HR'"
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    Section.DataSource = ds
                    Section.DataTextField = "Section"
                    Section.DataValueField = "Section"
                    Section.DataBind()
                End If
            End If

        End If
        If IsPostBack Then
            If department.SelectedValue = "All" Then
                department.Items.Clear()
                department.Items.Add("All")
                Dim TextStr As List(Of String) = New List(Of String)()
                'strsql = "select distinct Department from Employee_Master"
                strsql = "select distinct Department from Employee_Master1"
                If Section.SelectedValue <> "All" Then TextStr.Add("Section='" & Section.SelectedValue & "'")
                If empcode.Text <> "" Then TextStr.Add("EmployeeCode like '" & empcode.Text & "'+'%'")
                Dim Str As String = String.Join(" and ", TextStr.ToArray())
                strsql = strsql + " " + "where" + " " + Str + "and EmployeeCode<>'HR'"
                If sqlselectmaster(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        department.DataSource = ds
                        department.DataTextField = "Department"
                        department.DataValueField = "Department"
                        department.DataBind()
                    End If
                End If

            End If
            If Section.SelectedValue = "All" Then
                Section.Items.Clear()
                Section.Items.Add("All")
                Dim TextStr As List(Of String) = New List(Of String)()
                'strsql = "select distinct Section from Employee_Master"
                strsql = "select distinct Section from Employee_Master1"
                If department.SelectedValue <> "All" Then TextStr.Add("Department='" & department.SelectedValue & "'")
                If empcode.Text <> "" Then TextStr.Add("EmployeeCode like '" & empcode.Text & "'+'%'")
                Dim Str As String = String.Join(" and ", TextStr.ToArray())
                strsql = strsql + " " + "where" + " " + Str + "and EmployeeCode<>'HR'"
                If sqlselectmaster(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        Section.DataSource = ds
                        Section.DataTextField = "Section"
                        Section.DataValueField = "Section"
                        Section.DataBind()
                    End If
                End If

            End If
        End If
    End Sub
    Protected Sub empcode_TextChanged(sender As Object, e As EventArgs) Handles empcode.TextChanged

        fill()
        filter()
    End Sub
    Protected Sub department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles department.SelectedIndexChanged

        filter()
        fill()
    End Sub

    Protected Sub Section_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Section.SelectedIndexChanged

        filter()
        fill()
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim empcode As String = Convert.ToString(GridView1.DataKeys(e.RowIndex).Values(0).ToString())
        'strsql = "Delete from Employee_Master where EmployeeCode='" & empcode & "'"
        strsql = "Delete from Employee_Master1 where EmployeeCode='" & empcode & "'"
        sqlexe(constr, strsql)
        ' Response.Redirect(Request.RawUrl)
        fill()
    End Sub



    Protected Sub Display(sender As Object, e As EventArgs)
        Try
            Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            emplcode.Text = TryCast(row.FindControl("Label1"), Label).Text
            'strsql = "select * from Employee_Master where EmployeeCode='" & emplcode.Text & "' and EmployeeCode<>'HR'"
            strsql = "select * from Employee_Master1 where EmployeeCode='" & emplcode.Text & "' and EmployeeCode<>'HR'"
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then

                    emplnm.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    designation.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                    grad.Text = Convert.ToString(ds.Tables(0).Rows(0)("Grade"))
                    depta.Text = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                    secta.Text = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                    ' machno.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Machine_No"))
                    doja.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                    dota.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOT"))
                    dopa.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOP"))
                    doca.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOC"))
                    Contract_Renew.Text = Convert.ToString(ds.Tables(0).Rows(0)("Contract_Renew"))
                    Contract_Expire.Text = Convert.ToString(ds.Tables(0).Rows(0)("Contract_Expire"))
                    doea.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOE"))
                    qualific.Text = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                    preexpa.Text = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                    reportingperson.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                    reviewperioda.Text = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
                    incredetail.Text = Convert.ToString(ds.Tables(0).Rows(0)("IncrementDetail"))
                    perget.Text = Convert.ToString(ds.Tables(0).Rows(0)("PercentOfGet"))
                    incredate.Text = Convert.ToString(ds.Tables(0).Rows(0)("Increment_EffectiveDate"))
                    noofextend.Text = Convert.ToString(ds.Tables(0).Rows(0)("NoOfExtension"))
                    mriexperience.Text = Convert.ToString(ds.Tables(0).Rows(0)("MRIExperience"))
                    PMS_Form_Category.Text = Convert.ToString(ds.Tables(0).Rows(0)("PMS_Form_Category"))
                    'leftdate.Text = Convert.ToString(ds.Tables(0).Rows(0)("LeftDate"))
                End If
            End If

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Pop", "openModal();", True)
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        'strsql = "Select * from Employee_Master where EmployeeCode='" & emplcode.Text & "'"
        strsql = "Select * from Employee_Master1 where EmployeeCode='" & emplcode.Text & "'"

        If doja.Text <> "" And doja.Text <> "-" Then
            doja.Text = Convert.ToDateTime(doja.Text).ToString("dd/MM/yyyy")
        End If
        If dota.Text <> "" And dota.Text <> "-" Then
            dota.Text = Convert.ToDateTime(dota.Text).ToString("dd/MM/yyyy")
        End If
        If dopa.Text <> "" And dopa.Text <> "-" Then
            dopa.Text = Convert.ToDateTime(dopa.Text).ToString("dd/MM/yyyy")
        End If
        If doca.Text <> "" And doca.Text <> "-" Then
            doca.Text = Convert.ToDateTime(doca.Text).ToString("dd/MM/yyyy")
        End If
        If Contract_Renew.Text <> "" And Contract_Renew.Text <> "-" Then
            Contract_Renew.Text = Convert.ToDateTime(Contract_Renew.Text).ToString("dd/MM/yyyy")
        End If
        If Contract_Expire.Text <> "" And Contract_Expire.Text <> "-" Then
            Contract_Expire.Text = Convert.ToDateTime(Contract_Expire.Text).ToString("dd/MM/yyyy")
        End If
        If doea.Text <> "" And doea.Text <> "-" Then
            doea.Text = Convert.ToDateTime(doea.Text).ToString("dd/MM/yyyy")
        End If

        If incredate.Text <> "" And doea.Text <> "-" Then
            incredate.Text = Convert.ToDateTime(incredate.Text).ToString("dd/MM/yyyy")
        End If
        'strsql = "UPDATE Employee_Master Set EmployeeCode='" & emplcode.Text & "', EmployeeName=N'" & emplnm.Text & "', Designation=N'" & designation.Text & "',Grade='" & grad.Text & "',Department=N'" & depta.Text & "',Section=N'" & secta.Text & "',DOJ='" & doja.Text & "',DOP='" & dopa.Text & "',DOC='" & doca.Text & "',DOE='" & doea.Text & "',Qualification=N'" & qualific.Text & "',ReportingPersonName=N'" & reportingperson.Text & "',Review_Period='" & reviewperioda.Text & "',IncrementDetail='" & incredetail.Text & "',PercentOfGet='" & perget.Text & "',Increment_EffectiveDate='" & incredate.Text & "',NoOfExtension='" & noofextend.Text & "',MRIExperience=N'" & mriexperience.Text & "',LeftDate='" & leftdate.Text & "'  WHERE EmployeeCode='" & emplcode.Text & "' "
        strsql = "UPDATE Employee_Master1 Set EmployeeCode='" & emplcode.Text & "', EmployeeName=N'" & emplnm.Text & "', Designation=N'" & designation.Text & "',Grade='" & grad.Text & "',Department=N'" & depta.Text & "',Section=N'" & secta.Text & "',DOJ='" & doja.Text & "',DOT= '" & dota.Text & "',DOP='" & dopa.Text & "',DOC='" & doca.Text & "',Contract_Renew = '" & Contract_Renew.Text & "',Contract_Expire = '" & Contract_Expire.Text & "',DOE='" & doea.Text & "',Qualification=N'" & qualific.Text & "',ReportingPersonName=N'" & reportingperson.Text & "',Review_Period='" & reviewperioda.Text & "',IncrementDetail='" & incredetail.Text & "',PercentOfGet='" & perget.Text & "',Increment_EffectiveDate='" & incredate.Text & "',NoOfExtension='" & noofextend.Text & "',MRIExperience=N'" & mriexperience.Text & "',PMS_Form_Category=N'" & PMS_Form_Category.Text & "'   WHERE EmployeeCode='" & emplcode.Text & "' "
        If sqlexe(constr, strsql) Then
            fill()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Record Updated Successfully');", True)

        Else
            errorms = errorMsg
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(errorms) + "')</script>")

        End If

    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        fill()

    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        fill()
    End Sub



    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex()
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Try
            Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
            Dim EmployeeCode As String = Convert.ToString(GridView1.DataKeys(e.RowIndex).Values(0).ToString())
            Dim EmployeeName As String = (TryCast(row.FindControl("empname"), TextBox)).Text
            Dim Designation As String = (TryCast(row.FindControl("desc"), TextBox)).Text
            Dim Department As String = (TryCast(row.FindControl("dept"), TextBox)).Text
            Dim Section As String = (TryCast(row.FindControl("sect"), TextBox)).Text
            Dim DOJ As String = (TryCast(row.FindControl("doj"), TextBox)).Text
            Dim DOT As String = (TryCast(row.FindControl("dot"), TextBox)).Text
            Dim DOP As String = (TryCast(row.FindControl("dop"), TextBox)).Text
            Dim DOC As String = (TryCast(row.FindControl("doc"), TextBox)).Text
            Dim Contract_Renew As String = (TryCast(row.FindControl("Contract_Renew"), TextBox)).Text
            Dim Contract_Expire As String = (TryCast(row.FindControl("Contract_Expire"), TextBox)).Text
            Dim DOE As String = (TryCast(row.FindControl("doe"), TextBox)).Text
            Dim Qualification As String = (TryCast(row.FindControl("quali"), TextBox)).Text
            Dim PreviousExperience As String = (TryCast(row.FindControl("preexp"), TextBox)).Text
            Dim ReportingPersonName As String = (TryCast(row.FindControl("reppersonname"), TextBox)).Text
            Dim Review_Period As String = (TryCast(row.FindControl("review"), DropDownList)).SelectedValue

            Dim PMS_Form_Category As String = (TryCast(row.FindControl("PMS_Form_Category"), TextBox)).Text

            'strsql = "Update Employee_Master set EmployeeName='" & EmployeeName & "',Designation='" & Designation & "',Department='" & Department & "',Section='" & Section & "',DOJ='" & DOJ & "',DOP='" & DOP & "',DOC='" & DOC & "',DOE='" & DOE & "',Qualification='" & Qualification & "',PreviousExperience='" & PreviousExperience & "',ReportingPersonName='" & ReportingPersonName & "',Review_Period='" & Review_Period & "' where EmployeeCode='" & EmployeeCode & "'"
            strsql = "Update Employee_Master1 set EmployeeName='" & EmployeeName & "',Designation='" & Designation & "',Department='" & Department & "',Section='" & Section & "',DOJ='" & DOJ & "',DOT= '" & DOT & "',DOP='" & DOP & "',DOC='" & DOC & "',Contract_Renew = '" & Contract_Renew & "',Contract_Expire = '" & Contract_Expire & "',DOE='" & DOE & "',Qualification='" & Qualification & "',PreviousExperience='" & PreviousExperience & "',ReportingPersonName='" & ReportingPersonName & "',Review_Period='" & Review_Period & "',PMS_Form_Category = '" & PMS_Form_Category & "' where EmployeeCode='" & EmployeeCode & "'"
            If sqlexe(constr, strsql) Then
                GridView1.EditIndex = -1
                fill()
            End If
        Catch ex As Exception
            Dim st As New StackTrace(True)
            st = New StackTrace(ex, True)
            Label2.Visible = "true"
            Label2.Text = "Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "Error"
        End Try
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
            GridView1.Font.Size = "12"
            GridView1.DataBind()
            GridView1.Columns(20).Visible = "False"
            GridView1.Columns(21).Visible = "false"
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




    Protected Sub dispall_Click(sender As Object, e As EventArgs) Handles dispall.Click
        Response.Redirect(Request.RawUrl)
    End Sub

    Private Function GetCellValue(document As SpreadsheetDocument, cell As Cell) As String

        Dim stringTablePart As SharedStringTablePart = document.WorkbookPart.SharedStringTablePart
        Dim value As String = cell.CellValue.InnerXml
        If cell.DataType <> "" & cell.DataType.Value = CellValues.SharedString Then
            Return stringTablePart.SharedStringTable.ChildElements(Int32.Parse(value)).InnerText
        Else
            Return value
        End If

    End Function


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles import.Click
        Try
            Dim filenm As String = uploadfile.PostedFile.FileName
            If filenm <> "" Then
                Dim filePath As String = Server.MapPath("~/Emp_File/") + Path.GetFileName(uploadfile.PostedFile.FileName)
                Dim FileExtension = System.IO.Path.GetExtension(uploadfile.PostedFile.FileName)
                If FileExtension = ".xlsx" Then
                    uploadfile.SaveAs(filePath)

                    Using doc As SpreadsheetDocument = GetDoc(filePath)
                        'Read the first Sheet from Excel file.
                        Dim sheet As Sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild(Of Sheet)()

                        'Get the Worksheet instance.
                        Dim worksheet As Worksheet = TryCast(doc.WorkbookPart.GetPartById(sheet.Id.Value), WorksheetPart).Worksheet

                        'Fetch all the rows present in the Worksheet.
                        Dim rows As IEnumerable(Of Row) = worksheet.GetFirstChild(Of SheetData)().Descendants(Of Row)()

                        'Create a new DataTable.
                        Dim dt As New DataTable()


                        'Loop through the Worksheet rows.
                        For Each row As Row In rows

                            'Use the first row to add columns to DataTable.
                            If row.RowIndex.Value = 1 Then
                                For Each cell As Cell In row.Descendants(Of Cell)()
                                    dt.Columns.Add(GetValue(doc, cell))
                                Next
                            Else
                                'Add rows to DataTable.
                                dt.Rows.Add()
                                Dim i As Integer = 0
                                For Each cell As Cell In row.Descendants(Of Cell)()
                                    dt.Rows(dt.Rows.Count - 1)(i) = GetValue(doc, cell).ToString()
                                    i += 1
                                Next
                            End If
                        Next
                        GridView2.DataSource = dt
                        GridView2.DataBind()
                    End Using
                Else

                End If
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try

        Try
            ' Dim strConnection As [String] = "Data Source=PC179006;Initial Catalog=HR_APP;User ID=sa;Password=maxxis@123"

            Dim dt As New DataTable()
            dt.Columns.Add("Category", GetType(String))
            dt.Columns.Add("Employee Code", GetType(String))
            dt.Columns.Add("Department", GetType(String))
            dt.Columns.Add("Section", GetType(String))
            dt.Columns.Add("Designation", GetType(String))
            dt.Columns.Add("Grade", GetType(String))
            dt.Columns.Add("Employee Name", GetType(String))
            dt.Columns.Add("DOJ", GetType(String))
            dt.Columns.Add("DOT", GetType(String))
            dt.Columns.Add("DOP", GetType(String))
            dt.Columns.Add("DOC", GetType(String))
            dt.Columns.Add("Contract_Renew", GetType(String))
            dt.Columns.Add("Contract_Expire", GetType(String))
            dt.Columns.Add("DOE", GetType(String))
            dt.Columns.Add("Review Period", GetType(String))
            dt.Columns.Add("Qualification", GetType(String))
            dt.Columns.Add("Previous Experience", GetType(String))
            dt.Columns.Add("MRI Experience", GetType(String))
            dt.Columns.Add("Reporting PersonName", GetType(String))
            dt.Columns.Add("Increment Paid/Not Paid", GetType(String))
            dt.Columns.Add("Percentage of Getting", GetType(String))
            dt.Columns.Add("Increment Effective date", GetType(String))
            dt.Columns.Add("No of Extension", GetType(String))
            dt.Columns.Add("PMS_Form_Category", GetType(String))
            '  dt.Columns.Add("Left date", GetType(String))
            dt.Columns.Add("Reg", GetType(Boolean))
            dt.Columns.Add("Access Power", GetType(String))

            For Each gvrow As GridViewRow In GridView2.Rows
                Dim category As String = gvrow.Cells(0).Text
                Dim code As String = gvrow.Cells(1).Text
                Dim dept As String = WebUtility.HtmlDecode(gvrow.Cells(2).Text)
                Dim sect As String = WebUtility.HtmlDecode(gvrow.Cells(3).Text)
                sect = sect.Replace("&amp;", "&")
                Dim desig As String = WebUtility.HtmlDecode(gvrow.Cells(4).Text)
                Dim grade As String = gvrow.Cells(5).Text
                Dim name As String = gvrow.Cells(6).Text

                Dim doj As String = gvrow.Cells(7).Text
                doj = doj.Replace("&nbsp;", "")
                Dim dot As String = gvrow.Cells(8).Text
                dot = dot.Replace("&nbsp;", "")
                Dim dop As String = gvrow.Cells(9).Text
                dop = dop.Replace("&nbsp;", "")
                Dim doc As String = gvrow.Cells(10).Text
                doc = doc.Replace("&nbsp;", "")

                Dim Contract_Renew As String = gvrow.Cells(11).Text
                Contract_Renew = Contract_Renew.Replace("&nbsp;", "") ' adding new replace function here..
                Dim Contract_Expire As String = gvrow.Cells(12).Text
                Contract_Expire = Contract_Expire.Replace("&nbsp;", "") ' adding new replace function here..

                Dim doe As String = gvrow.Cells(13).Text
                doe = doe.Replace("&nbsp;", "")
                Dim review As String = gvrow.Cells(14).Text
                review = review.Replace("&nbsp;", "")
                Dim quali As String = WebUtility.HtmlDecode(gvrow.Cells(15).Text)
                quali = quali.Replace("&nbsp;", "")
                Dim preexp As String = gvrow.Cells(16).Text
                preexp = preexp.Replace("&nbsp;", "")
                Dim mriexp As String = gvrow.Cells(17).Text
                mriexp = mriexp.Replace("&nbsp;", "")
                Dim reppername As String = gvrow.Cells(18).Text
                reppername = reppername.Replace("&nbsp;", "")
                Dim incredetail As String = gvrow.Cells(19).Text
                incredetail = incredetail.Replace("&nbsp;", "")
                Dim percentofget As String = gvrow.Cells(20).Text
                percentofget = percentofget.Replace("&nbsp;", "")
                Dim incrementdate As String = gvrow.Cells(21).Text
                incrementdate = incrementdate.Replace("&nbsp;", "")
                Dim noextend As String = gvrow.Cells(22).Text
                noextend = noextend.Replace("&nbsp;", "")
                Dim PMS_Form_Category As String = gvrow.Cells(23).Text
                PMS_Form_Category = PMS_Form_Category.Replace("&amp;", "&")

                ' Dim leftdt As String = gvrow.Cells(20).Text
                Dim reg As String = False
                Dim str As String = desig
                Dim empgrad As String = grade
                'If str = "GM" Or str = "AVP" Then
                '    str = "2"
                'Else
                '    str = "3"
                'End If
                If empgrad = "" Then
                    empgrad = "2"
                Else
                    empgrad = "3"
                End If


                'strsql = "select EmployeeCode from Employee_Master where EmployeeCode='" & code & "'"
                strsql = "select EmployeeCode from Employee_Master1 where EmployeeCode='" & code & "'"
                If sqlselectmaster(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        Dim empcode As String = Convert.ToString(ds.Tables("Abc").Rows(0)("EmployeeCode"))
                        If empcode = code Then
                            strsql = "insert into Employee_Master select Category,EmployeeCode,Department,Section,Designation,Grade,EmployeeName,DOJ,DOP,DOC,DOE,Review_Period,Qualification,PreviousExperience,MRIExperience,ReportingPersonName,IncrementDetail,PercentOfGet,Increment_EffectiveDate,NoOfExtension,LeftDate from Employee_Master1 where EmployeeCode='" & empcode & "'"
                            'strsql = "insert into Employee_Master_Histry1 select Category,EmployeeCode,Department,Section,Designation,Grade,EmployeeName,DOJ,DOP,DOT,DOC,Contract_Renew,Contract_Expire,DOE,Review_Period,Qualification,PreviousExperience,MRIExperience,ReportingPersonName,IncrementDetail,PercentOfGet,Increment_EffectiveDate,NoOfExtension,PMS_Form_Category from Employee_Master1 where EmployeeCode='" & empcode & "'"
                            If sqlselect(constr, strsql, "Abc") Then
                                If ds.Tables("Abc").Rows.Count > 0 Then
                                    ' Response.Write(" <script> alert('Updated successfully' );window.location = '" + Request.RawUrl + "';</script>")
                                End If
                            End If

                            'strsql = "Update Employee_Master set Category='" & category & "',EmployeeName='" & name & "',Designation='" & desig & "',Grade='" & grade & "',Department='" & dept & "',Section='" & sect & "',DOJ='" & doj & "',DOP='" & dop & "',DOC='" & doc & "',DOE='" & doe & "',Qualification='" & quali & "',PreviousExperience='" & preexp & "',ReportingPersonName='" & reppername & "',Review_Period='" & review & "',IncrementDetail='" & incredetail & "',PercentOfGet='" & percentofget & "',Increment_EffectiveDate='" & incrementdate & "',NoOfExtension='" & noextend & "',LeftDate='" & leftdt & "',MRIExperience='" & mriexp & "',Access_Power='" & empgrad & "'  where EmployeeCode='" & empcode & "'"
                            strsql = "Update Employee_Master1 set Category='" & category.Trim & "',EmployeeName='" & name.Trim & "',Designation='" & desig.Trim & "',Grade='" & grade & "',Department='" & dept.Trim & "',Section='" & sect.Trim & "',DOJ='" & doj & "',DOT = '" & dot & "',DOP='" & dop & "',DOC='" & doc & "',Contract_Renew = '" & Contract_Renew & "',Contract_Expire = '" & Contract_Expire & "',DOE='" & doe & "',Qualification='" & quali & "',PreviousExperience='" & preexp & "',ReportingPersonName='" & reppername & "',Review_Period='" & review & "',IncrementDetail='" & incredetail & "',PercentOfGet='" & percentofget & "',Increment_EffectiveDate='" & incrementdate & "',NoOfExtension='" & noextend & "',MRIExperience='" & mriexp & "',PMS_Form_Category='" & PMS_Form_Category.Trim & "',Access_Power='" & empgrad & "'  where EmployeeCode='" & empcode & "'"
                            If sqlexe(constr, strsql) Then

                            End If
                        Else
                            dt.Rows.Add(category, code, dept, sect, desig, grade, name, doj, dot, dop, doc, Contract_Renew, Contract_Expire, doe, review, quali, preexp, mriexp, reppername, incredetail, percentofget, incrementdate, noextend, PMS_Form_Category, reg, empgrad)
                        End If
                    Else
                        dt.Rows.Add(category, code, dept, sect, desig, grade, name, doj, dot, dop, doc, Contract_Renew, Contract_Expire, doe, review, quali, preexp, mriexp, reppername, incredetail, percentofget, incrementdate, noextend, PMS_Form_Category, reg, empgrad)
                    End If
                Else
                    GridView2.DataSource = ds
                    GridView2.DataBind()
                    ds.Clear()
                End If
            Next

            Using con As New SqlConnection(constr)
                con.Open()
                Dim sqlBulk As New SqlBulkCopy(constr)
                ' Dim str As String = "[dbo]" + "." + "[" + "application1" + "]"
                sqlBulk.DestinationTableName = "Employee_Master1"


                sqlBulk.ColumnMappings.Add("Category", "Category")
                sqlBulk.ColumnMappings.Add("Employee Code", "EmployeeCode")
                sqlBulk.ColumnMappings.Add("Department", "Department")
                sqlBulk.ColumnMappings.Add("Section", "Section")
                sqlBulk.ColumnMappings.Add("Designation", "Designation")
                sqlBulk.ColumnMappings.Add("Grade", "Grade")
                sqlBulk.ColumnMappings.Add("Employee Name", "EmployeeName")
                sqlBulk.ColumnMappings.Add("DOJ", "DOJ")
                sqlBulk.ColumnMappings.Add("DOT", "DOT")
                sqlBulk.ColumnMappings.Add("DOP", "DOP")
                sqlBulk.ColumnMappings.Add("DOC", "DOC")
                sqlBulk.ColumnMappings.Add("Contract_Renew", "Contract_Renew")
                sqlBulk.ColumnMappings.Add("Contract_Expire", "Contract_Expire")
                sqlBulk.ColumnMappings.Add("DOE", "DOE")
                sqlBulk.ColumnMappings.Add("Review Period", "Review_Period")
                sqlBulk.ColumnMappings.Add("Qualification", "Qualification")
                sqlBulk.ColumnMappings.Add("Previous Experience", "PreviousExperience")
                sqlBulk.ColumnMappings.Add("MRI Experience", "MRIExperience")
                sqlBulk.ColumnMappings.Add("Reporting PersonName", "ReportingPersonName")
                sqlBulk.ColumnMappings.Add("Increment Paid/Not Paid", "IncrementDetail")
                sqlBulk.ColumnMappings.Add("Percentage of Getting", "PercentOfGet")
                sqlBulk.ColumnMappings.Add("Increment Effective date", "Increment_EffectiveDate")
                sqlBulk.ColumnMappings.Add("No of Extension", "NoOfExtension")
                sqlBulk.ColumnMappings.Add("PMS_Form_Category", "PMS_Form_Category")
                'sqlBulk.ColumnMappings.Add("Left date", "LeftDate")
                sqlBulk.ColumnMappings.Add("Reg", "Reg")
                sqlBulk.ColumnMappings.Add("Access Power", "Access_Power")

                sqlBulk.WriteToServer(dt)

                Response.Write("<script language='javascript'>alert('Inserted Successfully');window.location = '" + Request.RawUrl + "';</script>")
                con.Close()
                ds.Clear()

            End Using

            fill()
        Catch ex As Exception
            '  MsgBox(ex.ToString())
            'lblMsg.Text = ex.Message
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    Private Enum Formats
        General = 0
        Number = 1
        [Decimal] = 2
        Currency = 164
        Accounting = 44
        DateShort = 14
        DateLong = 165
        Time = 166
        Percentage = 10
        Fraction = 12
        Scientific = 11
        Text = 49
        'numberformatID = 164
    End Enum
    Private Shared Function GetDoc(filePath As String) As SpreadsheetDocument
        Return SpreadsheetDocument.Open(filePath, False)
    End Function


    Private Function GetValue(doc As SpreadsheetDocument, cell As Cell) As String
        Try
            If IsNothing(cell.CellValue) Then
                Return ""
            End If
            Dim value As String = cell.CellValue.InnerText

            If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
                Return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(Integer.Parse(value)).InnerText
            ElseIf cell.DataType Is Nothing Then ' number & dates.
                Dim styleIndex As Integer = CInt(cell.StyleIndex.Value)
                Dim cellFormat As CellFormat = TryCast(doc.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats.ChildElements(Integer.Parse(cell.StyleIndex.InnerText)), CellFormat)
                Dim formatId As UInteger = cellFormat.NumberFormatId.Value

                If formatId = CUInt(Formats.DateShort) OrElse formatId = CUInt(Formats.DateLong) OrElse formatId = CUInt(Formats.Currency) Then
                    Dim oaDate As Double

                    If Double.TryParse(cell.InnerText, oaDate) Then
                        value = DateTime.FromOADate(oaDate).ToShortDateString()
                    End If
                Else
                    value = cell.CellValue.InnerText
                End If
            End If
            Return value
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function RemoveSpecialCharacters(ByVal text As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(text, "(\s+|\*|\#|\@|\$|\&)", "")
    End Function


End Class
