Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Public Class WebForm9
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label13.Text = ""
        fill()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        strsql = "Insert into Employee_Basic_Details(EmployeeCode,EmployeeName,Designation,Department,Section,DOJ,DOP,DOC,DOE,Qualification,PreviousExperience,Reg) values('" & empcode.Text & "','" & empname.Text & "','" & desig.Text & "','" & dept.SelectedValue & "','" & sect.SelectedValue & "','" & doj.Text & "','" & doe.Text & "','" & doc.Text & "','" & doe.Text & "','" & quali.Text & "','" & preexp.Text & "','" & False & "')"
        If sqlexe(constr, strsql) Then
            clear()
            fill()
        End If
    End Sub
    Private Sub clear()
        empcode.Text = ""
        empname.Text = ""
        desig.Text = ""
        dept.SelectedValue = "---Select---"
        ' sect.SelectedValue = "---Select---"
        doj.Text = ""
        doc.Text = ""
        doe.Text = ""
        doe.Text = ""
        quali.Text = ""
        preexp.Text = ""
    End Sub
    Private Sub fill()
        strsql = "select EmployeeCode,EmployeeName,Designation,Department,Section,DOJ,DOP,DOC,DOE,Qualification,PreviousExperience from Employee_Basic_Details"
        If sqlselect(constr, strsql, "Abc") Then
            GridView1.DataSource = ds.Tables("Abc")
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles department.SelectedIndexChanged
        section.Items.Clear()
        section.Items.Add("---Select---")
        strsql = "select d.dept_id,s.section_name from dept d INNER JOIN section s  ON d.dept_id=s.dept_id where d.dept_name='" & department.SelectedValue & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                section.DataSource = ds
                section.DataTextField = "section_name"
                section.DataValueField = "section_name"
                section.DataBind()
            End If
        End If
        strsql = "select * from Employee_Basic_Details where Department='" & department.SelectedValue & "'"
        If sqlselect(constr, strsql, "Abc") Then
            GridView1.DataSource = ds.Tables("Abc")
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub section_SelectedIndexChanged(sender As Object, e As EventArgs) Handles section.SelectedIndexChanged
        strsql = "select * from Employee_Basic_Details where Section='" & section.SelectedValue & "'"
        If sqlselect(constr, strsql, "Abc") Then
            GridView1.DataSource = ds.Tables("Abc")
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub dept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dept.SelectedIndexChanged
        sect.Items.Clear()
        sect.Items.Add("---Select---")
        strsql = "select d.dept_id,s.section_name from dept d INNER JOIN section s  ON d.dept_id=s.dept_id where d.dept_name='" & dept.SelectedValue & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                sect.DataSource = ds
                sect.DataTextField = "section_name"
                sect.DataValueField = "section_name"
                sect.DataBind()
            End If
        End If
    End Sub

    Protected Sub empcode_TextChanged(sender As Object, e As EventArgs) Handles empcode.TextChanged
        strsql = "select * from Employee_Basic_Details where EmployeeCode='" & empcode.Text & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Dim empid As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                Session("emp id ") = empid
                Label13.Visible = "true"
                Label13.Text = "" + empid + ", " + "already inserted this record"
            End If
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex()
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Dim row As GridViewRow = GridView1.Rows(e.RowIndex)
        Dim EmployeeCode As String = Convert.ToString(GridView1.DataKeys(e.RowIndex).Values(0).ToString())
        Dim EmployeeName As String = (TryCast(row.FindControl("empname"), TextBox)).Text
        Dim Designation As String = (TryCast(row.FindControl("designation"), TextBox)).Text
        Dim Department As String = (TryCast(row.FindControl("dept"), TextBox)).Text
        Dim Section As String = (TryCast(row.FindControl("sect"), TextBox)).Text
        Dim DOJ As String = (TryCast(row.FindControl("doj"), TextBox)).Text
        Dim DOE As String = (TryCast(row.FindControl("doe"), TextBox)).Text
        Dim Status As String = (TryCast(row.FindControl(""), TextBox)).Text


        strsql = "update Employee_Basic_Details set EmployeeName='" & EmployeeName & "',Designation='" & Designation & "',Department='" & Department & "',Section='" & Section & "',DOJ='" & DOJ & "',DOP='" & DOP & "',DOC='" & DOC & "',DOE='" & DOE & "',Qualification='" & Qualification & "',PreviousExperience='" & PreviousExperience & "',ReportingPersonName='" & ReportingPersonName & "',Review_Period='" & Review_Period & "' where EmployeeCode='" & EmployeeCode & "'"
        sqlexe(constr, strsql)
        GridView1.EditIndex = -1
        Response.Redirect(Request.RawUrl)
    End Sub

    Protected Sub GridView1_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        GridView1.DataBind()
    End Sub
End Class