Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Collections.Generic
Imports System.Net
Imports System.Linq
Imports System.ComponentModel
Imports System.IO.IOException
Imports System.IO.Path
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Security
Imports System.Net.Mail
Imports Outlook = Microsoft.Office.Interop.Outlook
Imports Microsoft.Office.Core
Imports Color = System.Drawing.Color
Imports Control = System.Web.UI.Control

Public Class Variablepay
    Inherits System.Web.UI.Page
    Dim standardyear As String = ""
    Dim PMSclass As New PMSClass()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access power") = "" Then
            Response.Redirect("login.aspx")
        End If

        bind()
        If Not IsPostBack Then
            Dim currentYear As Integer = DateTime.Now.Year
            Dim endYear As Integer = currentYear + 5 ' You can adjust this as needed to generate future years

            ' Loop through the years from current to the end year
            For year As Integer = currentYear To endYear
                ' Check if the year already exists in the dropdown
                If Not Yearr.Items.FindByValue(year.ToString()) Is Nothing Then
                    ' If it exists, skip it
                    Continue For
                End If

                ' Add year to the DropDownList if not already added
                Dim listItem As New ListItem(year.ToString(), year.ToString())
                Yearr.Items.Add(listItem)
            Next

            BindQuarterDropdown()
        End If



        Dim host As String = Dns.GetHostName()

        'If host = "PC194004" Or host = "PC17C001" Or host = "" Or host = "" Then
        '    GridView1.Columns(9).Visible = True
        '    GridView1.Columns(12).Visible = True
        '    GridView3.Columns(9).Visible = True
        'Else
        '    GridView1.Columns(9).Visible = False
        '    GridView1.Columns(12).Visible = False
        '    GridView3.Columns(9).Visible = False
        'End If
    End Sub

    Private Sub BindQuarterDropdown()
        Quater.Items.Clear()
        Quater.Items.Add(New ListItem("All", "All"))
        Dim Years As String = DateTime.Now.AddYears(0).ToString("yyyy")
        Dim Yearslast As String = DateTime.Now.AddYears(-1).ToString("yyyy")

        If Years = "2025" Then
            Quater.Items.Add(New ListItem("Q2 (Apr, May, Jun)", "Aug"))
            Quater.Items.Add(New ListItem("Q3 (Jul, Aug, Sep)", "Oct"))
            Quater.Items.Add(New ListItem("Q4 (Oct, Nov, Dec)", "Jan"))
        Else
            Quater.Items.Add(New ListItem("Q1 (Jan, Feb, Mar)", "Apr"))
            Quater.Items.Add(New ListItem("Q2 (Apr, May, Jun)", "Aug"))
            Quater.Items.Add(New ListItem("Q3 (Jul, Aug, Sep)", "Oct"))
            Quater.Items.Add(New ListItem("Q4 (Oct, Nov, Dec)", "Jan"))
        End If

    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Function bind()
        Dim revmonth As String = DateTime.Now.AddMonths(0).ToString("MMM")
        Dim year As String = ""
        If Yearr.SelectedValue <> "All" And Quater.SelectedValue <> "All" Then

            revmonth = Quater.SelectedValue

            year = Yearr.SelectedValue
        Else
            If revmonth = "Jan" Then
                year = DateTime.Now.AddYears(-1).ToString("yyyy")
            Else
                year = DateTime.Now.AddYears(0).ToString("yyyy")
            End If
        End If
        Dim months As String = ""
        If revmonth = "Jan" Then
            months = $"'Oct-{ year.Substring(2, 2)}','Nov-{ year.Substring(2, 2)}','Dec-{ year.Substring(2, 2)}'"
        ElseIf revmonth = "Apr" Then
            months = $"'Jan-{ year.Substring(2, 2)}','Feb-{ year.Substring(2, 2)}','Mar-{ year.Substring(2, 2)}'"
        ElseIf revmonth = "Aug" Then
            months = $"'Apr-{ year.Substring(2, 2)}','May-{ year.Substring(2, 2)}','Jun-{ year.Substring(2, 2)}'"
        ElseIf revmonth = "Oct" Then
            months = $"'Jul-{ year.Substring(2, 2)}','Aug-{ year.Substring(2, 2)}','Sep-{ year.Substring(2, 2)}'"
        End If

        standardyear = year
        Dim dt As DataTable = PMSclass.variablepay(year, months)
        Dim dt1 As DataTable = PMSclass.variablepayexport(year, months)
        Dim dt3 As DataTable = PMSclass.getpbvpemployee(year)

        If dt1 IsNot Nothing AndAlso dt1.Rows.Count > 0 Then
            GridView2.DataSource = dt1
            GridView2.DataBind()

            GridView3.DataSource = Nothing
            GridView3.DataBind()

        Else
            If dt3 IsNot Nothing AndAlso dt3.Rows.Count > 0 Then
                GridView3.DataSource = dt3
                GridView3.DataBind()
            Else
                GridView3.DataSource = Nothing
                GridView3.DataBind()
            End If
        End If
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView3.DataSource = Nothing
            GridView3.DataBind()
        Else
            If dt3 IsNot Nothing AndAlso dt3.Rows.Count > 0 Then
                GridView3.DataSource = dt3
                GridView3.DataBind()
            Else
                GridView3.DataSource = Nothing
                GridView3.DataBind()
            End If
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        End If


    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bind()
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("Variablepay.aspx")
    End Sub
    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("login.aspx")
    End Sub

    Protected Sub btnDownloadSample_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim filePath As String = Server.MapPath("~/Excel/SamplePvbp.xlsx")

        If File.Exists(filePath) Then
            Response.Clear()
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            Response.AddHeader("Content-Disposition", "attachment; filename=SamplePvbp.xlsx")
            Response.TransmitFile(filePath)
            Response.End()
        Else

        End If
    End Sub
    Protected Sub btnImportExcel_Click(sender As Object, e As EventArgs) Handles btnImportExcel.Click
        If FileUploadExcel.HasFile Then
            Try
                ' Save uploaded file
                Dim folderPath As String = Server.MapPath("~/UploadedFiles/")
                If Not Directory.Exists(folderPath) Then
                    Directory.CreateDirectory(folderPath)
                End If

                Dim filePath As String = Path.Combine(folderPath, Path.GetFileName(FileUploadExcel.FileName))
                FileUploadExcel.SaveAs(filePath)

                ' Call PMS class to process the Excel
                Dim pms As New PMSClass()
                Dim result As Boolean = pms.ImportVariablePayExcel(filePath)

                If result Then
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertSuccess", "alert('Import successful via Excel.');", True)
                Else
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertFail", "alert('Failed to import data.');", True)
                End If

            Catch ex As Exception
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertEx", "alert('Error: " & ex.Message.Replace("'", "") & "');", True)
            End Try
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alertNoFile", "alert('Please upload a file.');", True)
        End If
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "EditPopup" Then
            Dim empCode As String = e.CommandArgument.ToString()
            hiddenEmpCode.Value = empCode

            ' Determine review month and year
            Dim reviewMonth As String = Quater.SelectedValue
            Dim year As String = Yearr.SelectedValue

            ' Fetch employee-specific data
            Dim dt As DataTable = PMSclass.GetEmployeeDataById(empCode)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                txtEmpID.Text = row("EmployeeCode").ToString()
                txtEmpName.Text = row("EmployeeName").ToString()
                txtDepartment.Text = row("Department").ToString()
                txtSection.Text = row("Section").ToString()

                If ddlStatus.Items.FindByValue(row("EmpStatus").ToString()) IsNot Nothing Then
                    ddlStatus.SelectedValue = row("EmpStatus").ToString()
                End If
                If ddlEligibility.Items.FindByValue(row("PbvpStatus").ToString()) IsNot Nothing Then
                    ddlEligibility.SelectedValue = row("PbvpStatus").ToString()
                End If

                txtRemark.Text = row("Remark").ToString()
            End If

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowPopup", "$('#editPopup').show();", True)

        End If
    End Sub

    Protected Sub GridView3_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView3.RowCommand
        If e.CommandName = "EditPopup" Then
            Dim empCode As String = e.CommandArgument.ToString()
            hiddenEmpCode.Value = empCode

            ' Determine review month and year
            Dim reviewMonth As String = Quater.SelectedValue
            Dim year As String = Yearr.SelectedValue

            ' Fetch employee-specific data
            Dim dt As DataTable = PMSclass.GetEmployeeDataById(empCode)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                txtEmpID.Text = row("EmployeeCode").ToString()
                txtEmpName.Text = row("EmployeeName").ToString()
                txtDepartment.Text = row("Department").ToString()
                txtSection.Text = row("Section").ToString()

                If ddlStatus.Items.FindByValue(row("EmpStatus").ToString()) IsNot Nothing Then
                    ddlStatus.SelectedValue = row("EmpStatus").ToString()
                End If
                If ddlEligibility.Items.FindByValue(row("PbvpStatus").ToString()) IsNot Nothing Then
                    ddlEligibility.SelectedValue = row("PbvpStatus").ToString()
                End If

                txtRemark.Text = row("Remark").ToString()
            End If

            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "ShowPopup", "$('#editPopup').show();", True)

        End If
    End Sub


    Protected Sub pdfExport_Click(sender As Object, e As EventArgs) Handles pdfExport.Click
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=Varible pay list.xls")
        Response.Charset = ""
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        GridView2.AllowPaging = False
        GridView2.DataBind()
        GridView2.RenderControl(hw)
        Response.Write(sw.ToString())
        Response.End()
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' This method must be overridden to allow exporting GridView
    End Sub
    Protected Sub btnSubmitEdit_Click(sender As Object, e As EventArgs)
        Dim empCode As String = hiddenEmpCode.Value
        Dim status As String = ddlStatus.SelectedValue
        Dim eligibility As String = ddlEligibility.SelectedValue
        Dim hostName As String = System.Net.Dns.GetHostName()
        Dim remark As String = txtRemark.Text
        Dim doedate As DateTime? = If(String.IsNullOrEmpty(txtdoedate.Text), CType(Nothing, DateTime?), Convert.ToDateTime(txtdoedate.Text))
        Dim updated As Boolean = PMSclass.UpdateEmployeeData(empCode, standardyear, status, eligibility, remark, doedate, hostName)

        If updated Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "closePopup", "alert('Update successful.'); closePopup();", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "errorPopup", "alert('Update failed.');", True)
        End If

        bind()
    End Sub



End Class