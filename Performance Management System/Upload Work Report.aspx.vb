Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Public Class WebForm18
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles department.SelectedIndexChanged
        Section.Items.Clear()
        Section.Items.Add("All")
        strsql = "select d.dept_id,s.section_name from Department d INNER JOIN Section1 s  ON d.dept_id=s.dept_id where d.dept_name='" & department.SelectedValue & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Section.DataSource = ds
                Section.DataTextField = "section_name"
                Section.DataValueField = "section_name"
                Section.DataBind()
            End If
        End If
    End Sub
End Class