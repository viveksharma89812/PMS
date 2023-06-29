Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO
Public Class WebForm5
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        fill()
    End Sub
    Private Sub bind()
        strsql = "select EmployeeCode,EmployeeName,Designation,Department,Section,DOJ,DOP,DOC,DOE,Qualification,PreviousExperience,ReportingPersonName,Review_Period from Employee_Master where EmployeeCode='" & Session("emp code") & "'"
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
                repperson.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                review.Text = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))


            End If

        End If
    End Sub

    Private Sub fill()
        strsql = "select * from FileUpload where EmployeeCode='" & Session("emp code") & "'"
        Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/Images/"))
        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            files.Add(New ListItem(Path.GetFileName(filePath), filePath))
        Next
        If sqlselect(constr, strsql, "Abc") Then
            GridView3.DataSource = ds.Tables("Abc")
            GridView3.DataBind()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bind()
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)
    End Sub
End Class