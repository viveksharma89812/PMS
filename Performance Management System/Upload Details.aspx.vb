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
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Security
Imports System.Net.Mail
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Core
Imports Color = System.Drawing.Color

Public Class WebForm3
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim errorms As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = ""
        fill()
        ScriptManager.GetCurrent(Me).RegisterPostBackControl(Me.GridView1)
        'If Not IsPostBack Then
        '    Session("CheckRefresh") = Server.UrlDecode(System.DateTime.Now.ToString())
        'End If

        'If Not IsPostBack Then
        '    empcode.Focus()
        'End If

        'If Page.IsPostBack Then
        '    Dim wcICausedPostBack As WebControl = CType(GetControlThatCausedPostBack(TryCast(sender, Page)), WebControl)
        '    Dim indx As Integer = wcICausedPostBack.TabIndex
        '    Dim ctrl =
        '     From control In wcICausedPostBack.Parent.Controls.OfType(Of WebControl)()
        '     Where control.TabIndex > indx
        '     Select control
        '    ctrl.DefaultIfEmpty(wcICausedPostBack).First().Focus()
        'End If
    End Sub

    'Protected Function GetControlThatCausedPostBack(ByVal page As Page) As Control
    '    Dim control As Control = Nothing

    '    Dim ctrlname As String = page.Request.Params.Get("__EVENTTARGET")
    '    If ctrlname IsNot Nothing AndAlso ctrlname <> String.Empty Then
    '        control = page.FindControl(ctrlname)
    '    Else
    '        For Each ctl As String In page.Request.Form
    '            Dim c As Control = page.FindControl(ctl)
    '            If TypeOf c Is System.Web.UI.WebControls.Button OrElse TypeOf c Is System.Web.UI.WebControls.ImageButton Then
    '                control = c
    '                Exit For
    '            End If
    '        Next ctl
    '    End If
    '    Return control

    'End Function
    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles submit.Click
    '    Try
    '        Dim str As String = desi.Text
    '        If str = "GM" Or str = "AVP" Then
    '            str = "2"
    '        Else
    '            str = "3"
    '        End If
    '        Dim doja As String = Convert.ToDateTime(doj.Text).ToString("dd-MM-yyyy")
    '        Dim dopa As String
    '        Dim doca As String
    '        Dim doea As String
    '        If dop.Text <> "" Then
    '            dopa = Convert.ToDateTime(dop.Text).ToString("dd-MM-yyyy")
    '        Else
    '            dopa = dop.Text
    '        End If
    '        If doc.Text <> "" Then
    '            doca = Convert.ToDateTime(doc.Text).ToString("dd-MM-yyyy")
    '        Else
    '            doca = doc.Text
    '        End If
    '        If doe.Text <> "" Then
    '            doea = Convert.ToDateTime(doe.Text).ToString("dd-MM-yyyy")
    '        Else
    '            doea = doe.Text
    '        End If
    '        strsql = "Insert into Employee_Master(EmployeeCode,EmployeeName,Designation,Department,Section,DOJ,DOP,DOC,DOE,Qualification,PreviousExperience,ReportingPersonName,Review_Period,Reg,Access_Power) values('" & empcode.Text & "','" & emplname.Text & "','" & desi.Text & "','" & Dept.SelectedValue & "','" & sect.SelectedValue & "','" & doja & "','" & dopa & "','" & doca & "','" & doea & "','" & qualification.Text & "','" & preexp.Text & "','" & reporpersonname.Text & "','" & Review.SelectedValue & "','" & False & "','" & str & "')"
    '        If sqlexe(constr, strsql) Then
    '            clear()
    '            Label2.Visible = "true"
    '            Label2.Text = "Inserted Successfully"
    '            fill()
    '        End If
    '    Catch ex As Exception
    '        ' Dim st As New StackTrace(True)
    '        ' st = New StackTrace(ex, True)
    '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '    End Try
    'End Sub
    'Private Sub clear()
    '    empcode.Text = ""
    '    emplname.Text = ""
    '    desi.Text = ""
    '    Dept.SelectedValue = "---Select---"
    '    sect.SelectedValue = "---Select---"
    '    doj.Text = ""
    '    doc.Text = ""
    '    doe.Text = ""
    '    dop.Text = ""
    '    qualification.Text = ""
    '    preexp.Text = ""
    '    reporpersonname.Text = ""
    '    Review.SelectedValue = "---Select---"
    'End Sub
    Private Sub fill()

        strsql = "select * from Employee_Master"
        Dim TextStr As List(Of String) = New List(Of String)()
        If department.SelectedValue <> "All" Then TextStr.Add("Department='" & department.SelectedValue & "'")
        If Section.SelectedValue <> "All" Then TextStr.Add("Section='" & Section.SelectedValue & "'")

        Dim str As String = String.Join(" and ", TextStr.ToArray())

        strsql = strsql + " " + "where" + " " + str
        If sqlselect(constr, strsql, "Abc") Then
            GridView1.DataSource = ds
            GridView1.DataBind()
        End If
        If department.SelectedValue = "All" And Section.SelectedValue = "All" Then
            strsql = "Select * from Employee_Master"
            If sqlselect(constr, strsql, "Abc") Then
                GridView1.DataSource = ds
                GridView1.DataBind()
            End If
        End If
        'If department.SelectedValue <> "All" Then
        '    strsql = "select * from Employee_Master where Department='" & department.SelectedValue & "'"
        '    If sqlselect(constr, strsql, "Abc") Then
        '        GridView1.DataSource = ds.Tables("Abc")
        '        GridView1.DataBind()
        '    End If
        'End If
        'If Section.SelectedValue <> "All" And department.SelectedValue <> "All" Then
        '    strsql = "select * from Employee_Master where Section='" & Section.SelectedValue & "'"
        '    If sqlselect(constr, strsql, "Abc") Then
        '        GridView1.DataSource = ds.Tables("Abc")
        '        GridView1.DataBind()
        '    End If
        'End If

        If Not IsPostBack Then
            If department.SelectedValue = "All" Then
                strsql = "select distinct Department from Employee_Master"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        department.DataSource = ds
                        department.DataTextField = "Department"
                        department.DataValueField = "Department"
                        department.DataBind()
                    End If
                End If
            End If
        End If
        If IsPostBack Then
            If department.SelectedValue <> "All" And Section.SelectedValue = "All" Then
                Section.Items.Clear()
                Section.Items.Add("All")
                strsql = "select distinct Section from Employee_Master where Department='" & department.SelectedValue & "'"
                If sqlselect(constr, strsql, "Abc") Then
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

    Protected Sub department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles department.SelectedIndexChanged
        Section.Items.Clear()
        Section.Items.Add("All")
        fill()
    End Sub

    Protected Sub Section_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Section.SelectedIndexChanged
        fill()
    End Sub

    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim empcode As String = Convert.ToString(GridView1.DataKeys(e.RowIndex).Values(0).ToString())
        strsql = "Delete from Employee_Master where EmployeeCode='" & empcode & "'"
        sqlexe(constr, strsql)
        ' Response.Redirect(Request.RawUrl)
        fill()
    End Sub


    'Protected Sub Dept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Dept.SelectedIndexChanged
    '    sect.Items.Clear()
    '    sect.Items.Add("---Select---")
    '    strsql = "select d.dept_id,s.section_name from Department d INNER JOIN Section1 s  ON d.dept_id=s.dept_id where d.dept_name='" & Dept.SelectedValue & "'"
    '    If sqlselect(constr, strsql, "Abc") Then
    '        If ds.Tables("Abc").Rows.Count > 0 Then
    '            sect.DataSource = ds
    '            sect.DataTextField = "section_name"
    '            sect.DataValueField = "section_name"
    '            sect.DataBind()
    '        End If
    '    End If
    '    Dept.Focus()
    'End Sub

    'Protected Sub empcode_TextChanged(sender As Object, e As EventArgs) Handles empcode.TextChanged
    '    strsql = "select * from Employee_Master where EmployeeCode='" & empcode.Text & "'"
    '    If sqlselect(constr, strsql, "Abc") Then
    '        If ds.Tables("Abc").Rows.Count > 0 Then
    '            Dim empid As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
    '            Session("emp id ") = empid
    '            Label2.Visible = "true"
    '            Label2.Text = "" + empid + ", " + "already inserted this record"
    '        End If
    '    End If
    '    empcode.Focus()
    'End Sub


    Protected Sub deptb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles deptb.SelectedIndexChanged
        sectb.Items.Clear()
        strsql = "select d.dept_id,s.section_name from Department d INNER JOIN Section1 s  ON d.dept_id=s.dept_id where d.dept_name='" & deptb.SelectedValue & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                sectb.DataSource = ds
                sectb.DataTextField = "section_name"
                sectb.DataValueField = "section_name"
                sectb.DataBind()
            End If
        End If
    End Sub
    Protected Sub Display(sender As Object, e As EventArgs)
        Try
            Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            emplcode.Text = TryCast(row.FindControl("Label1"), Label).Text
            strsql = "select * from Employee_Master where EmployeeCode='" & emplcode.Text & "'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then

                    emplnm.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    designation.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                    deptb.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                    sectb.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                    ' machno.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Machine_No"))
                    doja.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                    dopa.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOP"))
                    doca.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOC"))
                    doea.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOE"))
                    qualific.Text = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                    preexpa.Text = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                    reportingperson.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                    reviewper1.SelectedValue = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
                End If
            End If
            sectb.Items.Clear()
            strsql = "select d.dept_id,s.section_name from Department d INNER JOIN Section1 s  ON d.dept_id=s.dept_id where d.dept_name='" & deptb.SelectedValue & "'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    sectb.DataSource = ds
                    sectb.DataTextField = "section_name"
                    sectb.DataValueField = "section_name"
                    sectb.DataBind()
                End If
            End If
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "Pop", "openModal();", True)
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        strsql = "Select * from Employee_Master where EmployeeCode='" & emplcode.Text & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                strsql = "insert into Employee_Master_Histry select EmployeeCode,EmployeeName,Designation,Department,Section,DOJ,DOP,DOC,DOE,Qualification,PreviousExperience,ReportingPersonName,Review_Period from Employee_Master where EmployeeCode='" & emplcode.Text & "'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        ' Response.Write(" <script> alert('Updated successfully' );window.location = '" + Request.RawUrl + "';</script>")
                    End If
                End If
            End If
        End If

        strsql = "UPDATE Employee_Master Set EmployeeCode='" & emplcode.Text & "', EmployeeName='" & emplnm.Text & "', Designation='" & designation.Text & "',Department='" & deptb.SelectedValue & "',Section='" & sectb.SelectedValue & "',DOJ='" & doja.Text & "',DOP='" & dopa.Text & "',DOC='" & doca.Text & "',DOE='" & doea.Text & "',Qualification='" & qualific.Text & "',ReportingPersonName='" & reportingperson.Text & "',Review_Period='" & reviewper1.SelectedValue & "'  WHERE EmployeeCode='" & emplcode.Text & "' "
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
            Dim DOP As String = (TryCast(row.FindControl("dop"), TextBox)).Text
            Dim DOC As String = (TryCast(row.FindControl("doc"), TextBox)).Text
            Dim DOE As String = (TryCast(row.FindControl("doe"), TextBox)).Text
            Dim Qualification As String = (TryCast(row.FindControl("quali"), TextBox)).Text
            Dim PreviousExperience As String = (TryCast(row.FindControl("preexp"), TextBox)).Text
            Dim ReportingPersonName As String = (TryCast(row.FindControl("reppersonname"), TextBox)).Text
            Dim Review_Period As String = (TryCast(row.FindControl("review"), DropDownList)).SelectedValue

            strsql = "Update Employee_Master set EmployeeName='" & EmployeeName & "',Designation='" & Designation & "',Department='" & Department & "',Section='" & Section & "',DOJ='" & DOJ & "',DOP='" & DOP & "',DOC='" & DOC & "',DOE='" & DOE & "',Qualification='" & Qualification & "',PreviousExperience='" & PreviousExperience & "',ReportingPersonName='" & ReportingPersonName & "',Review_Period='" & Review_Period & "' where EmployeeCode='" & EmployeeCode & "'"
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

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
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
            GridView1.Columns(14).Visible = "False"
            GridView1.Columns(15).Visible = "false"
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
            Response.End()


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    'Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    '    ' Verifies that the control is rendered
    'End Sub

    'Protected Sub sect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sect.SelectedIndexChanged
    '    sect.Focus()
    'End Sub

    Protected Sub dispall_Click(sender As Object, e As EventArgs) Handles dispall.Click
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles import.Click
        Try
            Dim filenm As String = uploadfile.PostedFile.FileName
            If filenm <> "" Then
                Dim filePath As String = Server.MapPath("~/DocFile/") + Path.GetFileName(uploadfile.PostedFile.FileName)
                Dim FileExtension = System.IO.Path.GetExtension(uploadfile.PostedFile.FileName)
                If FileExtension = ".xlsx" Then
                    uploadfile.SaveAs(filePath)

                    'Open the Excel file in Read Mode using OpenXml.
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
                                    dt.Rows(dt.Rows.Count - 1)(i) = GetValue(doc, cell)
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
            dt.Columns.Add("Employee Code", GetType(String))
            dt.Columns.Add("Employee Name", GetType(String))
            dt.Columns.Add("Department", GetType(String))
            dt.Columns.Add("Section", GetType(String))
            dt.Columns.Add("Designation", GetType(String))
            dt.Columns.Add("DOJ", GetType(String))
            dt.Columns.Add("DOP", GetType(String))
            dt.Columns.Add("DOC", GetType(String))
            dt.Columns.Add("DOE", GetType(String))
            dt.Columns.Add("Qualification", GetType(String))
            dt.Columns.Add("Previous Experience", GetType(String))
            dt.Columns.Add("Reporting PersonName", GetType(String))
            dt.Columns.Add("Review Period", GetType(String))
            dt.Columns.Add("Increment Paid/Not Paid", GetType(String))
            dt.Columns.Add("Percentage of Getting", GetType(String))
            dt.Columns.Add("Increment Effective date", GetType(String))
            dt.Columns.Add("No of Extension", GetType(Int16))


            For Each gvrow As GridViewRow In GridView2.Rows
                Dim code As String = gvrow.Cells(0).Text
                Dim name As String = gvrow.Cells(1).Text
                Dim dept As String = gvrow.Cells(2).Text
                Dim sect As String = gvrow.Cells(3).Text
                Dim desig As String = gvrow.Cells(4).Text
                Dim doj As String = gvrow.Cells(5).Text
                Dim dop As String = gvrow.Cells(6).Text
                Dim doc As String = gvrow.Cells(7).Text
                Dim doe As String = gvrow.Cells(8).Text
                Dim quali As String = gvrow.Cells(9).Text
                Dim preexp As String = gvrow.Cells(10).Text
                Dim reppername As String = gvrow.Cells(11).Text
                Dim review As String = gvrow.Cells(12).Text
                Dim incredetail As String = gvrow.Cells(13).Text
                Dim percentofget As String = gvrow.Cells(14).Text
                Dim incrementdate As String = gvrow.Cells(15).Text
                Dim noextend As Int16 = gvrow.Cells(16).Text
                Dim reg As String = False
                Dim str As String = desig
                If str = "GM" Or str = "AVP" Then
                    str = "2"
                Else
                    str = "3"
                End If

                strsql = "select EmployeeCode from Employee_Master where EmployeeCode='" & code & "'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        Dim empcode As String = Convert.ToString(ds.Tables("Abc").Rows(0)("EmployeeCode"))
                        If empcode = code Then

                            strsql = "select EmployeeCode from  Employee_Master  where EmployeeCode='" & code & "'"
                            If sqlselect(constr, strsql, "Abc") Then
                                If ds.Tables("Abc").Rows.Count > 0 Then
                                    Dim emcode As String = Convert.ToString(ds.Tables("Abc").Rows(0)("EmployeeCode"))
                                    If emcode = code Then
                                        strsql = "Update Employee_Master set EmployeeName='" & name & "',Designation='" & desig & "',Department='" & dept & "',Section='" & sect & "',DOJ='" & doj & "',DOP='" & dop & "',DOC='" & doc & "',DOE='" & doe & "',Qualification='" & quali & "',PreviousExperience='" & preexp & "',ReportingPersonName='" & reppername & "',Review_Period='" & review & "',IncrementDetail='" & incredetail & "',PercentOfGet='" & percentofget & "',Increment_EffectiveDate='" & incrementdate & "',NoOfExtension='" & noextend & "',Access_Power='" & str & "'  where EmployeeCode='" & emcode & "'"
                                        If sqlexe(constr, strsql) Then

                                        End If
                                    End If
                                Else
                                    dt.Rows.Add(code, name, dept, sect, desig, doj, dop, doc, doe, quali, preexp, reppername, review, incredetail, percentofget, incrementdate, noextend, reg, str)
                                End If

                            End If
                        End If
                    Else
                        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(code + " " + "Is Incorrect") + "')</script>")
                    End If
                End If

            Next

            Using con As New SqlConnection(constr)
                con.Open()
                Dim sqlBulk As New SqlBulkCopy(constr)
                ' Dim str As String = "[dbo]" + "." + "[" + "application1" + "]"
                sqlBulk.DestinationTableName = "Employee_Master"
                sqlBulk.WriteToServer(dt)
                Response.Write("<script language='javascript'>alert('Inserted Successfully')</script>")
                con.Close()
            End Using

        Catch ex As Exception
            '  MsgBox(ex.ToString())
            'lblMsg.Text = ex.Message
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
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
            End If
            Return value
        Catch ex As Exception
            Return ""
        End Try
    End Function
    'Protected Sub btn_Edit_Click(sender As Object, e As EventArgs)
    '    Dim LinkButton1 As LinkButton = TryCast(sender, LinkButton)
    '    Dim gvrow As GridViewRow = DirectCast(LinkButton1.NamingContainer, GridViewRow)
    '    lblID.Text = gvrow.Cells(0).Text
    '    txtempname.Text = gvrow.Cells(1).Text
    '    txtdept.Text = gvrow.Cells(2).Text
    '    txtsect.Text = gvrow.Cells(3).Text
    '    txtDesg.Text = gvrow.Cells(4).Text
    '    txtdoj.Text = gvrow.Cells(5).Text
    '    If gvrow.Cells(6).Text = "&nbsp;" Then
    '        txtdop.Text = ""
    '    Else
    '        txtdop.Text = gvrow.Cells(6).Text
    '    End If
    '    If gvrow.Cells(7).Text = "&nbsp;" Then
    '        txtdoc.Text = ""
    '    Else
    '        txtdoc.Text = gvrow.Cells(7).Text
    '    End If
    '    If gvrow.Cells(8).Text = "&nbsp;" Then
    '        txtdoe.Text = ""
    '    Else
    '        txtdoe.Text = gvrow.Cells(8).Text
    '    End If
    '    txtquali.Text = gvrow.Cells(9).Text
    '    txtpreexp.Text = gvrow.Cells(10).Text
    '    If gvrow.Cells(11).Text = "&nbsp;" Then
    '        txtrepperson.Text = ""
    '    Else
    '        txtrepperson.Text = gvrow.Cells(11).Text
    '    End If
    '    txtreview.Text = gvrow.Cells(12).Text
    '    Me.ModalPopupExtender1.Show()
    'End Sub
    'Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    strsql = "update Employee_Master set EmployeeName='" & txtempname.Text & "',Department='" & txtdept.Text & "',Section='" & txtsect.Text & "',Designation='" & txtDesg.Text & "',DOJ='" & txtdoj.Text & "',DOP='" & txtdop.Text & "',DOC='" & txtdoc.Text & "',DOE='" & txtdoe.Text & "',Qualification='" & txtquali.Text & "',PreviousExperience='" & txtpreexp.Text & "',ReportingPersonName='" & txtrepperson.Text & "',Review_Period='" & txtreview.Text & "' where EmployeeCode='" & lblID.Text & "'"
    '    If sqlexe(constr, strsql) Then
    '        GridView1.EditIndex = -1
    '        fill()
    '    End If

    '    lblresult.Text = "Details Updated Successfully"
    '    lblresult.ForeColor = Color.Green

    'End Sub


End Class
