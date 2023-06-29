Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO
Public Class WebForm5
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim year As String = DateTime.Now.Year
    Dim mon As String = DateTime.Now.AddMonths("-1").ToString("MM")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        fill()

        If mon = "12" Then
            year = DateTime.Now.AddYears(-1).ToString("yyyy")
        End If
        year = "[" + year + "]"


        strsql = "select * from dbo.[" & year & "] where EmployeeCode='" & Session("emp code") & "' and Month='" & mon & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Dim empaccept As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept"))
                Dim formstat As String = Convert.ToString(ds.Tables(0).Rows(0)("Form_Status"))

                If formstat <> "PENDING" Then

                    If empaccept <> "" Then
                        revform.Visible = False
                    End If
                Else
                    revform.Visible = False
                End If
            End If
        End If
    End Sub
    Private Sub bind()
        strsql = "select EmployeeCode,EmployeeName,Designation,Department,Section,DOJ,DOP,DOC,DOE,Qualification,PreviousExperience,ReportingPersonName,Review_Period from Employee_Master1 where EmployeeCode='" & Session("emp code") & "'"
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
        Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/DocFile/"))
        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            files.Add(New ListItem(Path.GetFileName(filePath), filePath))
        Next
        If sqlselect(constr, strsql, "Abc") Then
            GridView1.DataSource = ds.Tables("Abc")
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "download" Then
                'Dim filepath As String = "D:\DocFile"

                Dim strpath As String = Server.MapPath("~/DocFile/") + e.CommandArgument
                If e.CommandArgument <> "" Then
                    If File.Exists(strpath) Then

                        Dim cph As ContentPlaceHolder = Me.Master.FindControl("ContentPlaceHolder1")
                        Dim MyFrame As HtmlControl = cph.FindControl("urlframe")
                        Dim FileExtension = System.IO.Path.GetExtension(e.CommandArgument)
                        MyFrame.Attributes("src") = "DocFile\" + e.CommandArgument + "#toolbar=1"
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal1", "$(document).ready(function () {$('#myModal1').modal();});", True)
                    Else
                        Response.Write("<script> alert('File Not Found');window.close(); </script>")
                    End If
                End If
            End If
            'If e.CommandName = "Review" Then
            '    Dim year As String = DateTime.Now.Year
            '    Dim mon As String = DateTime.Now.AddMonths("-1").ToString("MM")
            '    strsql = "select * from dbo.[" & year & "] where EmployeeCode='" & Session("emp code") & "' and Month='" & mon & "'"
            '    If sqlselect(constr, strsql, "Abc") Then
            '        If ds.Tables("Abc").Rows.Count > 0 Then
            '            Session("form empid") = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
            '            Dim formid As String = Convert.ToString(ds.Tables(0).Rows(0)("Form_ID"))
            '            If formid = "2" Then
            '                Response.Redirect("0365.aspx", False)

            '            End If
            '        End If
            '    End If

            'End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bind()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#myModal').modal();});", True)
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Pop", "openModal();", True)

    End Sub





    Protected Sub revform_Click(sender As Object, e As EventArgs) Handles revform.Click
        Dim year As String = DateTime.Now.Year
        Dim mon As String = DateTime.Now.AddMonths("-1").ToString("MM")
        If mon = "12" Then
            year = DateTime.Now.AddYears(-1).ToString("yyyy")
        End If
        strsql = "select * from dbo.[" & year & "] where EmployeeCode='" & Session("emp code") & "' and Month='" & mon & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Session("form empid") = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                Dim formid As String = Convert.ToString(ds.Tables(0).Rows(0)("Form_ID"))
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
                    Response.Redirect("0386QSTO4.aspx", False)
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
                End If
                'ElseIf formid = "16" Then
                '    Response.Redirect("WebForm43.aspx", False)

            End If
        End If
    End Sub
End Class