Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Security.Policy
Imports System.Collections.Generic
Public Class WebForm6
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim FileName As String
    Dim errorms As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fill()
        ScriptManager.GetCurrent(Me).RegisterPostBackControl(Me.GridView1)
        If Not IsPostBack Then
            empid.Focus()
        End If
    End Sub
    'Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    If e.CommandName = "Download" Then
    '        Response.Clear()
    '        Response.ClearHeaders()
    '        Response.ClearContent()
    '        Response.ContentType = "Application /.xls"
    '        Response.AddHeader("content-disposition", "inline; filename=" + e.CommandArgument)
    '        Response.WriteFile("~/Images/" + e.CommandArgument)
    '        Response.End()
    '    End If
    'End Sub

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
            If emplid.Text = "" Then
                strsql = "select * from FileUpload "
                Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/Images/"))
                Dim files As List(Of ListItem) = New List(Of ListItem)
                For Each filePath As String In filePaths
                    files.Add(New ListItem(Path.GetFileName(filePath), filePath))
                Next
            Else
                strsql = "select * from FileUpload where EmployeeCode Like '%'+'" & emplid.Text & "'+'%'"
            End If
            If sqlselect(constr, strsql, "Abc") Then
                GridView1.DataSource = ds.Tables("Abc")
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles upload.Click
        Try

            Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim filePath As String = (Server.MapPath("~/Images/"))
            FileUpload1.PostedFile.SaveAs((Server.MapPath("~/Images/") & fileName))
            strsql = "Insert Into FileUpload(EmployeeCode,EmployeeName,fileName,filePath,Date) values ('" & empid.Text & "','" & empname.Text & "','" & FileUpload1.FileName & "','" & filePath & "','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
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

    'Protected Sub empname_TextChanged(sender As Object, e As EventArgs) Handles empname.TextChanged
    '    strsql = "select EmployeeName,EmployeeCode from Employee_Master where EmployeeName='" & empname.Text & "'"
    '    If sqlselect(constr, strsql, "Abc") Then
    '        If ds.Tables("Abc").Rows.Count > 0 Then
    '        Else
    '            Response.Write(" <script> alert('EmployeeName is not correct' );window.location = '" + Request.RawUrl + "';</script>")
    '        End If
    '    End If

    'End Sub

    Protected Sub empid_TextChanged(sender As Object, e As EventArgs) Handles empid.TextChanged
        Try
            strsql = "select EmployeeCode,EmployeeName from Employee_Master where EmployeeCode='" & empid.Text & "'"
            If sqlselect(constr, strsql, "Abc") Then
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
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    emplnm.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    'flname.Text = CType(GridView1.Rows(rowIndex).FindControl("HyperLink1"), HyperLink).Text
                    dat.Text = Convert.ToString(ds.Tables(0).Rows(0)("Date"))

                End If
            End If

            Dim url As String = "/Images/" + CType(GridView1.Rows(rowIndex).FindControl("HyperLink1"), HyperLink).Text
            flname.NavigateUrl = String.Format("javascript:void(window.open('" + url + "'));")
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "Pop", "openModal();", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs)
        Try
            'strsql = "Select * from Employee_Master where EmployeeCode='" & emplcode.Text & "'"
            'If sqlselect(constr, strsql, "Abc") Then
            '    If ds.Tables("Abc").Rows.Count > 0 Then
            '        strsql = "insert into Employee_Master_Histry select EmployeeCode,EmployeeName,Designation,Department,Section,DOJ,DOP,DOC,DOE,Qualification,PreviousExperience,ReportingPersonName,Review_Period from Employee_Master where EmployeeCode='" & emplcode.Text & "'"
            '        If sqlselect(constr, strsql, "Abc") Then
            '            If ds.Tables("Abc").Rows.Count > 0 Then
            '                ' Response.Write(" <script> alert('Updated successfully' );window.location = '" + Request.RawUrl + "';</script>")
            '            End If
            '        End If
            '    End If
            'End If

            If docfile.HasFile Then
                FileName = Path.GetFileName(docfile.PostedFile.FileName)

                Dim filePath As String = (Server.MapPath("~/Images/") & FileName)

                docfile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/"), FileName))
            Else
                FileName = flname.Text
            End If
            Dim dt2 As DateTime = dat.Text
            dt2.ToString("MM-dd-yyyy hh:mm:ss tt")
            Dim aid As String = ""
            strsql = "select * from FileUpload where EmployeeCode='" & emplcode.Text & "' and FileName='" & flname.Text & "'"
            If sqlselect(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    aid = Convert.ToInt16(ds.Tables(0).Rows(0)("id"))
                End If
            End If

            strsql = "Update FileUpload set EmployeeName='" & emplnm.Text & "',FileName='" & FileName & "',Date='" & dt2.ToString("MM-dd-yyyy hh:mm:ss tt") & "' where EmployeeCode='" & emplcode.Text & "' and id='" & aid & "' "
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
    Protected Sub emplid_TextChanged(sender As Object, e As EventArgs) Handles emplid.TextChanged
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
End Class