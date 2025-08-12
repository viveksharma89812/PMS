Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Security.Policy
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Security
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.IO.Path
Public Class WebForm6
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim FileName As String
    Dim errorms As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fill()
        filter()
        ' ScriptManager.GetCurrent(Me).RegisterPostBackControl(Me.GridView1)
        If Not IsPostBack Then
            empid.Focus()
        End If
    End Sub


    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Try
            Dim FileName As String = Convert.ToString(GridView1.DataKeys(e.RowIndex).Values(0).ToString())
            strsql = "Delete from FileUpload where FileName='" & FileName & "'"
            If sqlexe(constr, strsql) Then
                fill()
                Response.Write(" <script> alert('Deleted Successfully' );</script>")
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
        ' Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex()
        GridView1.DataBind()
    End Sub
    Private Sub fill()
        Try
            'If emplid.Text = "" Then
            '    strsql = "select * from FileUpload "
            '    Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/Images/"))
            '    Dim files As List(Of ListItem) = New List(Of ListItem)
            '    For Each filePath As String In filePaths
            '        files.Add(New ListItem(Path.GetFileName(filePath), filePath))
            '    Next
            'Else
            '    strsql = "select * from FileUpload where EmployeeCode Like '%'+'" & emplid.Text & "'+'%'"
            'End If
            'If sqlselect(constr, strsql, "Abc") Then
            '    GridView1.DataSource = ds.Tables("Abc")
            '    GridView1.DataBind()
            'End If

            strsql = "select a.Department,a.Section,b.* from Employee_Master a join FileUpload b on a.EmployeeCode=b.EmployeeCode"
            Dim TextStr As List(Of String) = New List(Of String)()
            If department.SelectedValue <> "All" Then TextStr.Add("Department='" & department.SelectedValue & "'")
            If Section.SelectedValue <> "All" Then TextStr.Add("Section='" & Section.SelectedValue & "'")
            If emplid.Text <> "" Then TextStr.Add("b.EmployeeCode like '" & emplid.Text & "'+'%'")
            Dim str As String = String.Join(" and ", TextStr.ToArray())

            strsql = strsql + " " + "where" + " " + str
            If sqlselectmaster(constr, strsql, "Abc") Then
                GridView1.DataSource = ds
                GridView1.DataBind()
            End If

            If emplid.Text = "" And department.SelectedValue = "All" And Section.SelectedValue = "All" Then
                strsql = "select a.Department,a.Section,b.* from Employee_Master a join FileUpload b on a.EmployeeCode=b.EmployeeCode"
                If sqlselectmaster(constr, strsql, "Abc") Then
                    GridView1.DataSource = ds
                    GridView1.DataBind()
                End If
            End If



        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Private Sub filter()
        If Not IsPostBack Then
            strsql = "select distinct a.Department  from Employee_Master a join FileUpload b on a.EmployeeCode=b.EmployeeCode"
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    department.DataSource = ds
                    department.DataTextField = "Department"
                    department.DataValueField = "Department"
                    department.DataBind()
                End If
            End If

            strsql = "select distinct a.Section from Employee_Master a join FileUpload b on a.EmployeeCode=b.EmployeeCode"
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
                strsql = "select distinct a.Department  from Employee_Master a join FileUpload b on a.EmployeeCode=b.EmployeeCode"
                If Section.SelectedValue <> "All" Then TextStr.Add("Section='" & Section.SelectedValue & "'")
                If emplid.Text <> "" Then TextStr.Add("b.EmployeeCode like '" & emplid.Text & "'+'%'")
                Dim Str As String = String.Join(" and ", TextStr.ToArray())
                strsql = strsql + " " + "where" + " " + Str
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
                strsql = "select distinct a.Section from Employee_Master a join FileUpload b on a.EmployeeCode=b.EmployeeCode"
                If department.SelectedValue <> "All" Then TextStr.Add("a.Department='" & department.SelectedValue & "'")
                If emplid.Text <> "" Then TextStr.Add("b.EmployeeCode like '" & emplid.Text & "'+'%'")
                Dim Str As String = String.Join(" and ", TextStr.ToArray())
                strsql = strsql + " " + "where" + " " + Str
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
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles upload.Click
        Try

            Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim filePath As String = (Server.MapPath("~/Emp_File/"))
            FileUpload1.PostedFile.SaveAs((Server.MapPath("~/Emp_File/") & fileName))
            strsql = "Insert Into FileUpload(EmployeeCode,EmployeeName,FileName,FilePath,Date) values ('" & empid.Text & "',N'" & empname.Text & "',N'" & FileUpload1.FileName & "',N'" & filePath & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
            If FileUpload1.FileName <> "" Then
                Dim FileExtension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName)
                If FileExtension = ".xlsx" Or FileExtension = ".pdf" Or FileExtension = ".docx" Then

                ElseIf FileExtension <> ".xlsx" Or FileExtension <> ".pdf" Or FileExtension <> ".docx" Then
                    Label3.Visible = "true"
                    Label3.Text = "Please enter valid file,only excel, pdf and word file are allowed"
                    clear()
                    Exit Sub
                End If
            End If
            If sqlexe(constr, strsql) Then
                Response.Write(" <script> alert('Inserted Successfully' );window.location = '" + Request.RawUrl + "';</script>")
                'clear()
                fill()
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Private Sub clear()
        empid.Text = ""
        empname.Text = ""
    End Sub

    Protected Sub empid_TextChanged(sender As Object, e As EventArgs) Handles empid.TextChanged
        Try
            strsql = "select EmployeeCode,EmployeeName from Employee_Master where EmployeeCode='" & empid.Text & "'"
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    Dim emplid As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                    Dim emplname As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    Session("employeename") = emplname
                    empname.Text = emplname
                Else
                    Response.Write(" <script> alert('EmployeeCode is not correct' );window.location = '" + Request.RawUrl + "';</script>")
                End If
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub


    Protected Sub Display(sender As Object, e As EventArgs)
        Try
            Dim rowIndex As Integer = Convert.ToInt32(TryCast(TryCast(sender, LinkButton).NamingContainer, GridViewRow).RowIndex)
            Dim row As GridViewRow = GridView1.Rows(rowIndex)
            emplcode.Text = TryCast(row.FindControl("Label2"), Label).Text
            flname.Text = TryCast(row.FindControl("HyperLink1"), HyperLink).Text
            'emplnm.Text = TryCast(row.FindControl("Label3"), Label).Text
            'dat.Text = TryCast(row.FindControl("Label5"), Label).Text

            strsql = "select * from FileUpload where EmployeeCode='" & emplcode.Text & "' and FileName='" & flname.Text & "'"
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    emplnm.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    'flname.Text = CType(GridView1.Rows(rowIndex).FindControl("HyperLink1"), HyperLink).Text
                    dat.Text = Convert.ToString(ds.Tables(0).Rows(0)("Date"))

                End If
            End If

            Dim url As String = "/Emp_File/" + CType(GridView1.Rows(rowIndex).FindControl("HyperLink1"), HyperLink).Text
            flname.NavigateUrl = String.Format("javascript:void(window.open('" + url + "'));")
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "Pop", "openModal();", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Try


            If docfile.HasFile Then
                FileName = Path.GetFileName(docfile.PostedFile.FileName)

                Dim filePath As String = (Server.MapPath("~/Emp_File/") & FileName)

                docfile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Emp_File/"), FileName))
            Else
                FileName = flname.Text
            End If
            Dim dt2 As DateTime = dat.Text
            dt2.ToString("MM-dd-yyyy hh:mm:ss tt")
            Dim aid As String = ""
            strsql = "select * from FileUpload where EmployeeCode='" & emplcode.Text & "' and FileName='" & flname.Text & "'"
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    aid = Convert.ToInt16(ds.Tables(0).Rows(0)("id"))
                End If
            End If

            strsql = "Update FileUpload set EmployeeName=N'" & emplnm.Text & "',FileName=N'" & FileName & "',Date='" & dt2.ToString("MM-dd-yyyy hh:mm:ss tt") & "' where EmployeeCode='" & emplcode.Text & "' and id='" & aid & "' "
            If sqlexe(constr, strsql) Then
                fill()
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Record Updated Successfully');", True)
                'Response.Write("<script>alert('Record Updated Successfully');</script>")
            Else
                errorms = errorMsg
                Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(errorms) + "')</script>")

            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        fill()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Try
            Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
            Dim EmployeeCode As String = (TryCast(row.FindControl("txtempcode"), TextBox)).Text
            Dim EmployeeName As String = (TryCast(row.FindControl("txtempname"), TextBox)).Text
            Dim FilePath As String = (TryCast(row.FindControl("txtfpath"), TextBox)).Text
            Dim dt As Date = (TryCast(row.FindControl("txtdate"), TextBox)).Text
            Dim flname As HyperLink = CType(GridView1.Rows(e.RowIndex).FindControl("HyperLink2"), HyperLink)
            Dim FileUpload2 As FileUpload = CType(GridView1.Rows(e.RowIndex).FindControl("FileUpload2"), FileUpload)
            If FileUpload2.HasFile Then
                FileName = Path.GetFileName(FileUpload2.PostedFile.FileName)
                Dim filePaths As String = (Server.MapPath("~/Images/") & FileName)

                FileUpload2.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), FileName))
            Else
                FileName = flname.Text
            End If
            strsql = "Update FileUpload set EmployeeName='" & EmployeeName & "',FilePath='" & FilePath & "',Date='" & dt.ToString("MM/dd/yyyy") & "',FileName='" & FileName & "' where EmployeeCode='" & EmployeeCode & "'"
            If sqlexe(constr, strsql) Then
                GridView1.EditIndex = -1
                fill()
            End If
        Catch ex As Exception
            'Dim st As New StackTrace(True)
            'st = New StackTrace(ex, True)
            'MsgBox(ex.ToString())
            'Label4.Visible = "true"
            'Label4.Text = "Line: " & st.GetFrame(0).GetFileLineNumber().ToString + "Error"

        End Try
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click1(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect(Request.RawUrl)
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
            GridView1.Columns(5).Visible = "False"
            GridView1.Columns(6).Visible = "false"
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

    Protected Sub department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles department.SelectedIndexChanged
        fill()
        filter()
    End Sub

    Protected Sub Section_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Section.SelectedIndexChanged
        fill()
        filter()
    End Sub
    Protected Sub emplid_TextChanged(sender As Object, e As EventArgs) Handles emplid.TextChanged
        fill()
        filter()
    End Sub
End Class