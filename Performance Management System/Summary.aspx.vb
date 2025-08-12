Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Web.UI.DataVisualization.Charting
Imports System.Net.Mail
Public Class Summary
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            bind()
            bind1()
            filter()
        End If


    End Sub

    Function filter()
        Dim d As String = department.SelectedValue
        Dim y As String = ddlYear.SelectedValue
        Dim year As String = DateTime.Now.Year
        If d <> "All" Then
            d = $"and Department='{department.SelectedValue}'"
        Else
            d = ""
        End If
        If y <> "All" Then
            year = $"'{ddlYear.SelectedValue}'"
        End If

        strsql = $"select distinct Department from Employee_Master1 where  Department<>''"
        If sqlselectmaster(constr, strsql, "Department") Then
            If ds.Tables("Department").Rows.Count > 0 Then
                department.DataSource = ds
                department.DataTextField = "Department"
                department.DataValueField = "Department"
                department.DataBind()
            End If
        End If
        Sections.Items.Clear()
        Sections.Items.Add("All")
        strsql = $"select distinct Section from Employee_Master1 where  Section<>'' {d}"
        If sqlselectmaster(constr, strsql, "Section") Then
            If ds.Tables("Section").Rows.Count > 0 Then
                Sections.DataSource = ds
                Sections.DataTextField = "Section"
                Sections.DataValueField = "Section"
                Sections.DataBind()
            End If
        End If
        If month.SelectedValue = "All" Then
            month.Items.Clear()
            month.Items.Add("All")
            strsql = $"select distinct Reviewmonth from [{year}] "
            If sqlselectmaster(constr, strsql, "Reviewmonth") Then
                If ds.Tables("Reviewmonth").Rows.Count > 0 Then
                    month.DataSource = ds
                    month.DataTextField = "Reviewmonth"
                    month.DataValueField = "Reviewmonth"
                    month.DataBind()
                End If
            End If
        End If
        If ddlYear.SelectedValue = "All" Then
            ddlYear.Items.Clear()
            ddlYear.Items.Add("All")
            Dim currentYear As Integer = DateTime.Now.Year
            For years As Integer = 2016 To currentYear
                ddlYear.Items.Add(New ListItem(years.ToString(), years.ToString()))
            Next
        End If
    End Function

    Function bind1()
        Dim year As String = DateTime.Now.Year
        Dim mont As String = DateTime.Now.AddMonths(-1).ToString("MM")
        Dim revmonth As String = DateTime.Now.AddMonths(-1).ToString("MMM")
        If mont = "12" Then
            year = DateTime.Now.AddYears(-1).ToString("yyyy")
        End If
        year = "[" + year + "]"
        revmonth = revmonth + "-" + year.Substring(3, 2)
        Dim y As String = ddlYear.SelectedValue
        If y <> "All" Then
            year = $"[{ddlYear.SelectedValue}]"
        End If
        Dim d As String = department.SelectedValue
        Dim s As String = Sections.SelectedValue
        Dim m As String = month.SelectedValue
        d.Trim()
        If d <> "All" Then
            d = $"and Department='{department.SelectedValue}'"
        Else
            d = ""
        End If
        If s <> "All" Then
            s = $" and Section='{Sections.SelectedValue}'"
        Else
            s = ""
        End If
        If m <> "All" Then
            revmonth = $"{month.SelectedValue}"
        End If

        Dim strsql As String = $"
        select   COUNT(CASE WHEN Form_Status = 'DONE' THEN 1 END) AS DONE,
           COUNT(CASE WHEN Form_Status = 'PENDING' THEN 1 END) AS PENDING ,
         COUNT(CASE WHEN Sect_Accept = 'Done' THEN 1 END) AS Sect_Accept,
           COUNT(CASE WHEN Dept_Accept = 'Done' THEN 1 END) AS Dept_Accept ,
         COUNT(CASE WHEN Emp_Accept = 'Done' THEN 1 END) AS Emp_Accept
        from {year} where     ReviewMonth='{revmonth}' {d}{s}"



        If sqlselect(constr, strsql, "TBLSUMMARY") Then
            If ds.Tables("TBLSUMMARY").Rows.Count > 0 Then
                done.Text = ds.Tables("TBLSUMMARY").Rows(0)("DONE").ToString()
                Pending.Text = ds.Tables("TBLSUMMARY").Rows(0)("PENDING").ToString()
                section.Text = ds.Tables("TBLSUMMARY").Rows(0)("Sect_Accept").ToString()
                deptment.Text = ds.Tables("TBLSUMMARY").Rows(0)("Dept_Accept").ToString()
                employeee.Text = ds.Tables("TBLSUMMARY").Rows(0)("Emp_Accept").ToString()
            End If

        End If


    End Function
    Function bind()
        Dim year As String = DateTime.Now.Year
        Dim mont As String = DateTime.Now.AddMonths(-1).ToString("MM")
        Dim revmonth As String = DateTime.Now.AddMonths(-1).ToString("MMM")
        If mont = "12" Then
            year = DateTime.Now.AddYears(-1).ToString("yyyy")
        End If
        year = "[" + year + "]"
        revmonth = revmonth + "-" + year.Substring(3, 2)
        Dim y As String = ddlYear.SelectedValue
        If y <> "All" Then
            year = $"[{ddlYear.SelectedValue}]"
        End If
        Dim d As String = department.SelectedValue
        Dim s As String = Sections.SelectedValue
        Dim m As String = month.SelectedValue
        d.Trim()
        If d <> "All" Then
            d = $"and Department='{department.SelectedValue}'"
        Else
            d = ""
        End If
        If s <> "All" Then
            s = $" and Section='{Sections.SelectedValue}'"
        Else
            s = ""
        End If
        If m <> "All" Then
            revmonth = $"{month.SelectedValue}"
        End If
        Dim strsql As String = $"SELECT   Department, Section, COUNT(Section) AS Total,COUNT(CASE WHEN Form_Status = 'PENDING' THEN 1 END) AS Pending,  COUNT(CASE WHEN Form_Status = 'DONE' THEN 1 END) AS Done,
     COUNT(CASE WHEN Sect_Accept = 'Done' THEN 1 END) AS SectionHeadAccecpt,
    COUNT(CASE WHEN Dept_Accept = 'Done' THEN 1 END) AS DepartmentHeadAccecpt,
 COUNT(CASE WHEN Emp_Accept = 'Done' THEN 1 END) AS EmployeeHeadAccecpt
FROM 
    [HR_PMS_web].[dbo].{year}
where ReviewMonth='{revmonth}' {d}{s}
GROUP BY 
    Department, Section ORDER BY 
    Department"
        If sqlselect(constr, strsql, "TBLSUMMARY") Then
            If ds.Tables("TBLSUMMARY").Rows.Count > 0 Then
                GridView2.DataSource = ds.Tables("TBLSUMMARY")
                GridView2.DataBind()

            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Not find related data');window.location = '" + Request.RawUrl + "';", True)

        End If
    End Function
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"

        Using sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            GridView2.RenderControl(hw)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
        End Using
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub
    Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "GetRowData" Then
            Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)

            Dim row As GridViewRow = GridView2.Rows(rowIndex)

            Dim department As String = row.Cells(0).Text
            Dim section As String = row.Cells(1).Text
            Dim total As String = row.Cells(2).Text
            Dim pending As String = row.Cells(3).Text
            Dim done As String = row.Cells(4).Text
            Dim sectionHeadAccept As String = row.Cells(5).Text
            Dim departmentHeadAccept As String = row.Cells(6).Text
            Dim employeeHeadAccept As String = row.Cells(7).Text

            ' Call sendMail with values
            sendMail(department, section, total, pending, done, employeeHeadAccept, departmentHeadAccept, sectionHeadAccept)

        End If
    End Sub
    Private Sub sendMail(department As String, section As String, total As String, pending As String, done As String, employeeHeadAccept As String, departmentHeadAccept As String, sectionHeadAccept As String)

        Try
            Dim SmtpClient As New SmtpClient("smtp-mail.outlook.com", 587) ' Ethereal SMTP server
            Dim MSG As New MailMessage()

            Try
                Dim fromAddress As New MailAddress("hrtraining@in.maxxis.com")
                Dim toEmails As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                Dim sectionDecoded As String = section.Replace("&amp;", "&")
                Dim dt As DataTable = GetDepartmentSectionEmails(department, section.Replace("&amp;", "&"))
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        Dim id As Integer = Convert.ToInt32(row("ID"))
                        Dim departmentEmail As String = row("DepartmentEmail").ToString()
                        Dim sectionEmail As String = row("SectionEmail").ToString()
                        If Not String.IsNullOrWhiteSpace(departmentEmail) Then
                            toEmails.Add(departmentEmail)
                        End If
                        If Not String.IsNullOrWhiteSpace(sectionEmail) Then
                            toEmails.Add(sectionEmail)
                        End If
                    Next
                End If
                'toEmails.Add("")
                For Each email As String In toEmails
                    MSG.To.Add(email)
                Next

                ' Get credentials from Web.config
                Dim smtpUser As String = ConfigurationManager.AppSettings("SMTPUser")
                Dim smtpPass As String = ConfigurationManager.AppSettings("SMTPPassword")

                ' Use Ethereal username and password
                SmtpClient.Credentials = New NetworkCredential(smtpUser, smtpPass)
                SmtpClient.EnableSsl = True
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network

                MSG.From = fromAddress

                Dim Path As String = Server.MapPath("~/MailTemplate/ReminderEmailTemplate.html")
                Dim htmlBody As String = System.IO.File.ReadAllText(Path)

                Dim currentMonthName As String = Now.ToString("MMMM yyyy")

                'htmlBody = htmlBody.Replace("21st of this month", "21st " & currentMonthName)

                ' Replace placeholders with actual values
                htmlBody = htmlBody.Replace("#Department#", department)
                htmlBody = htmlBody.Replace("#Section#", section)
                htmlBody = htmlBody.Replace("#PendingCount#", pending)
                htmlBody = htmlBody.Replace("#CompliteCount#", done)
                htmlBody = htmlBody.Replace("#TotalCount#", total)
                'Dim fnlemployeeHeadAccept = total - employeeHeadAccept
                'htmlBody = htmlBody.Replace("#employeeHeadAccept#", fnlemployeeHeadAccept)
                'Dim fnlsectionHeadAccept = total - sectionHeadAccept
                'htmlBody = htmlBody.Replace("#sectionHeadAccept#", fnlsectionHeadAccept)
                'Dim fnldepartmentHeadAccept = total - departmentHeadAccept
                'htmlBody = htmlBody.Replace("#departmentHeadAccept#", fnldepartmentHeadAccept)
                Dim fnlemployeeHeadAccept = Convert.ToInt32(total) - Convert.ToInt32(employeeHeadAccept)
                Dim fnlsectionHeadAccept = Convert.ToInt32(total) - Convert.ToInt32(sectionHeadAccept)
                Dim fnldepartmentHeadAccept = Convert.ToInt32(total) - Convert.ToInt32(departmentHeadAccept)

                ' Format with red color if value <= 0
                Dim empAcceptFormatted As String = If(fnlemployeeHeadAccept > 0, $"<span style='color:red;'>{fnlemployeeHeadAccept}</span>", fnlemployeeHeadAccept.ToString())
                Dim secAcceptFormatted As String = If(fnlsectionHeadAccept > 0, $"<span style='color:red;'>{fnlsectionHeadAccept}</span>", fnlsectionHeadAccept.ToString())
                Dim depAcceptFormatted As String = If(fnldepartmentHeadAccept > 0, $"<span style='color:red;'>{fnldepartmentHeadAccept}</span>", fnldepartmentHeadAccept.ToString())

                htmlBody = htmlBody.Replace("#employeeHeadAccept#", empAcceptFormatted)
                htmlBody = htmlBody.Replace("#sectionHeadAccept#", secAcceptFormatted)
                htmlBody = htmlBody.Replace("#departmentHeadAccept#", depAcceptFormatted)


                MSG.Subject = "Warm Reminder for PMS form Submission-自動溫馨提醒信件:-"
                MSG.Body = htmlBody
                MSG.IsBodyHtml = True

                SmtpClient.Send(MSG)
                ' Show success alert after sending the email
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Email sent successfully');", True)

            Catch ex As Exception
                Response.Write("Err: " & ex.Message)
            End Try

        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub
    'Protected Sub GridView2_RowCommand(sender As Object, e As GridViewCommandEventArgs)
    '    If e.CommandName = "GetRowData" Then

    '        Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
    '        Dim row As GridViewRow = GridView2.Rows(rowIndex)
    '        Dim department As String = row.Cells(0).Text
    '        Dim section As String = row.Cells(1).Text
    '        Dim total As String = row.Cells(2).Text
    '        Dim pending As String = row.Cells(3).Text
    '        Dim done As String = row.Cells(4).Text
    '        Dim sectionHeadAccept As String = row.Cells(5).Text
    '        Dim departmentHeadAccept As String = row.Cells(6).Text
    '        Dim employeeHeadAccept As String = row.Cells(7).Text
    '        Using client As New WebClient()
    '            client.Headers.Add("Authorization", "Bearer " & "M15TFNEPwbhIm91oqzZ9SixQFRcoeCz9UT68BBizByw")
    '            Dim values As New NameValueCollection()
    '            values("message") = $"🛑 📢 Alert " & vbCrLf &
    '                         $"Total         : {total}" & vbCrLf &
    '                          $"Done          : {done}" & vbCrLf &
    '                          $"Section Done  : {sectionHeadAccept}" & vbCrLf &
    '                          $"Dept Done     : {departmentHeadAccept}" & vbCrLf &
    '                          $"Employee Done : {employeeHeadAccept}"

    '            Dim response As Byte() = client.UploadValues("https://notify-api.line.me/api/notify", values)
    '            Dim responseString As String = System.Text.Encoding.Default.GetString(response)
    '        End Using

    '    End If
    'End Sub


    Protected Sub department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles department.SelectedIndexChanged
        filter()
        bind()
        bind1()
    End Sub

    Protected Sub Sections_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Sections.SelectedIndexChanged

        bind()
        bind1()
    End Sub

    Protected Sub month_SelectedIndexChanged(sender As Object, e As EventArgs) Handles month.SelectedIndexChanged
        filter()
        bind()
        bind1()
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        filter()
        bind()
        bind1()
    End Sub
End Class

