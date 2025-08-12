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
Imports DocumentFormat.OpenXml.Bibliography


Public Class WebForm4
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim review As String = ""
    Public PMSclass As New PMSClass()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access power") = "" Then
            Response.Redirect("login.aspx")
        End If



    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim filePath As String = Server.MapPath("~/Emp_File/") + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim FileExtension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName)
            If FileExtension = ".xlsx" Then
                FileUpload1.SaveAs(filePath)
                Using doc As SpreadsheetDocument = GetDoc(filePath)
                    Dim sheet As Sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild(Of Sheet)()
                    Dim worksheet As Worksheet = TryCast(doc.WorkbookPart.GetPartById(sheet.Id.Value), WorksheetPart).Worksheet
                    Dim rows As IEnumerable(Of Row) = worksheet.GetFirstChild(Of SheetData)().Descendants(Of Row)()
                    Dim dt1 As New DataTable()
                    For Each row As Row In rows
                        If row.RowIndex.Value = 1 Then
                            For Each cell As Cell In row.Descendants(Of Cell)()
                                dt1.Columns.Add(GetValue(doc, cell))
                            Next
                        Else
                            dt1.Rows.Add()
                            Dim i As Integer = 0
                            For Each cell As Cell In row.Descendants(Of Cell)()
                                dt1.Rows(dt1.Rows.Count - 1)(i) = GetValue(doc, cell)
                                i += 1
                            Next
                        End If
                    Next
                    GridView1.DataSource = dt1
                    GridView1.DataBind()
                End Using
            Else

            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
        Dim dt As New DataTable()
        dt.Columns.Add("Month", GetType(String))
        dt.Columns.Add("EmployeeCode", GetType(String))
        dt.Columns.Add("EmployeeName", GetType(String))
        dt.Columns.Add("ReviewMonth", GetType(String))
        dt.Columns.Add("Department", GetType(String))
        dt.Columns.Add("Section", GetType(String))
        dt.Columns.Add("CL", GetType(Decimal))
        dt.Columns.Add("SL", GetType(Decimal))
        dt.Columns.Add("PL", GetType(Decimal))
        dt.Columns.Add("LWP", GetType(Decimal))
        dt.Columns.Add("Other Leaves", GetType(Decimal))
        dt.Columns.Add("Actual Working Days", GetType(Decimal))
        dt.Columns.Add("Actual Present Days", GetType(Decimal))
        dt.Columns.Add("Absent Days", GetType(Decimal))
        dt.Columns.Add("Attend Score", GetType(Decimal))
        dt.Columns.Add("Score", GetType(Decimal))
        dt.Columns.Add("Review (During/Final)", GetType(String))
        dt.Columns.Add("Review Period (Month)", GetType(String))
        dt.Columns.Add("Form_Status", GetType(String))

        For Each gvrow As GridViewRow In GridView1.Rows
            Dim month As String = DateTime.Now.Month
            Dim code As String = gvrow.Cells(0).Text
            Dim dept As String = ""
            Dim sect As String = ""
            Dim EmployeeName As String = ""
            If code <> "&nbsp;" And code <> "" Then
                strsql = "select * from Employee_Master1 where EmployeeCode='" & code & "'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        dept = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                        sect = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                        EmployeeName = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    End If
                End If


                review = gvrow.Cells(1).Text
                Dim cl As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(2).Text, cl) Then
                    cl = 0 ' Default value or handle the error
                End If

                Dim sl As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(3).Text, sl) Then
                    sl = 0 ' Default value or handle the error
                End If

                Dim pl As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(4).Text, pl) Then
                    pl = 0 ' Default value or handle the error
                End If

                Dim lwp As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(5).Text, lwp) Then
                    lwp = 0 ' Default value or handle the error
                End If

                Dim otherleave As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(6).Text, otherleave) Then
                    otherleave = 0 ' Default value or handle the error
                End If

                Dim actworking As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(7).Text, actworking) Then
                    actworking = 0 ' Default value or handle the error
                End If

                Dim actpresent As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(8).Text, actpresent) Then
                    actpresent = 0 ' Default value or handle the error
                End If

                Dim absent As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(9).Text, absent) Then
                    absent = 0 ' Default value or handle the error
                End If

                Dim totscore As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(10).Text, totscore) Then
                    totscore = 0 ' Default value or handle the error
                End If

                Dim score As Decimal = 0
                If Not Decimal.TryParse(gvrow.Cells(11).Text, score) Then
                    score = 0 ' Default value or handle the error
                End If

                Dim rev As String = gvrow.Cells(12).Text
                Dim revperiod As String = gvrow.Cells(13).Text
                Dim formstat As String = "PENDING"
                If revperiod = "&nbsp;" Then
                    revperiod = ""
                End If
                Dim yea As String = DateTime.Now.Year
                Dim mon As String = DateTime.Now.AddMonths(-1).Month
                If mon < 10 Then
                    mon = "0" + mon
                End If
                tot = yea
                Dim prevmon As String = Convert.ToDateTime(review).ToString("MM")

                If prevmon = "12" Then
                    tot = DateTime.Today.AddYears(-1)
                    tot = Convert.ToDateTime(tot).ToString("yyyy")
                    mon = "12"
                End If
                strsql = "select * from information_schema.tables where TABLE_NAME='" & tot & "' "
                If sqlselectmaster(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                    Else
                        strsql = "create table[dbo].[" & tot & "](Month varchar(50),EmployeeCode nvarchar(50),EmployeeName nvarchar(50),ReviewMonth varchar(50),Department nvarchar(30),Section nvarchar(30),CL float,SL float,PL float,LWP float,OtherLeaves float,ActualWorkingDays float,ActualPresentDays float,AbsentDays float,LeavesScores float,TotScore float,Review_Dur varchar(50),Review varchar(50),Score1 int,Score2 int,Score3 int,Score4 int,Score5 int,Score6 int,Score7 int,Score8 int,Score9 int,Score10 int,Score11 int,Score12 int,Score13 int,Score14 int,Score15 int,Score16 int,Score17 int,Score18 int,Score19 int, Score20 int,TotalMarks int,Status nvarchar(50),Remark nvarchar(max),Ldr nvarchar(50), Shead nvarchar(50), Dhead nvarchar(50), Sshead nvarchar(50), Famnt int ,Amnt1 int , Empn varchar(50), Ldrn varchar(50), Sheadn varchar(50), Dheadn varchar(50), Empd varchar(50), Ldrd varchar(50), Sheadd varchar(50), Dheadd varchar(50), Remark1 nvarchar(max), Remark2 nvarchar(max), Remark3 nvarchar(max), Remark4 nvarchar(max), Emp_Accept1 varchar(20) , Emp_Accept2 varchar(20) ,Emp_Accept3 varchar(20) , Emp_Accept4 varchar(20) , Sameas varchar(50), Sincrease varchar(50), Sdecrease varchar(50),Form_Status varchar(50),Form_ID int,Emp_Accept varchar(20),Dept_Accept varchar(20),Sect_Accept varchar(20) , Plheadaccept varchar(20) ,Dhead_EmpId nvarchar(50),Shead_EmpId nvarchar(50),Dhead_IP nvarchar(100),Shead_IP nvarchar(100),SignPic nvarchar(200),EmpPic nvarchar(200),time nvarchar(50),Final_Desition nvarchar(100))"
                        If sqlexe(constr, strsql) Then
                        Else
                            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode("Invalid tablename") + "')</script>")
                        End If
                    End If
                End If

                strsql = "select EmployeeCode from Employee_Master1 where EmployeeCode='" & code & "' "
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        Dim empcode As String = Convert.ToString(ds.Tables("Abc").Rows(0)("EmployeeCode"))
                        If empcode = code Then
                            tot = "[dbo]" + ". " + "[" + tot + "]"
                            strsql = "select EmployeeCode from " + tot + "where EmployeeCode='" & code & "' and Month='" & mon & "'"
                            If sqlselect(constr, strsql, "Abc") Then
                                If ds.Tables("Abc").Rows.Count > 0 Then
                                    Dim emcode As String = Convert.ToString(ds.Tables("Abc").Rows(0)("EmployeeCode"))
                                    If emcode = code Then
                                        strsql = "update" + tot + "Set EmployeeName=N'" & EmployeeName & "', Department=N'" & dept & "',Section=N'" & sect & "', CL='" & cl & "',SL='" & sl & "',PL='" & pl & "',LWP='" & lwp & "',OtherLeaves='" & otherleave & "',ActualWorkingDays='" & actworking & "',ActualPresentDays='" & actpresent & "',AbsentDays='" & absent & "',LeavesScores='" & score & "',TotScore='" & totscore & "',Review_Dur='" & rev & "',Review='" & revperiod & "',Form_Status='" & formstat & "',ReviewMonth = '" & review & "'    where EmployeeCode='" & emcode & "' and Month='" & mon & "'"
                                        If sqlexe(constr, strsql) Then

                                        End If
                                    End If
                                Else
                                    dt.Rows.Add(mon, code, EmployeeName, review, dept, sect, cl, sl, pl, lwp, otherleave, actworking, actpresent, absent, score, totscore, rev, revperiod, formstat)
                                    ' strsql = "insert into " & tot & "(Month,EmployeeCode,ReviewMonth,CL,SL,PL,LWP,OtherLeaves,ActualWorkingDays,ActualPresentDays,AbsentDays,LeavesScores,TotScore,Review_Dur,Review,Form_Status)
                                    'values('" & mon & "','" & code & "','" & review & "','" & cl & "','" & sl & "','" & pl & "','" & lwp & "','" & otherleave & "','" & actworking & "','" & actpresent & "','" & absent & "','" & totscore & "','" & score & "','" & rev & "','" & revperiod & "','PENDING')"
                                    ' If sqlexe(constr, strsql) Then
                                    '     'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Details Inserted Successfully');", True)
                                    ' End If
                                End If

                            End If
                        End If
                    Else
                        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(code + " " + "Is Incorrect") + "')</script>")
                    End If
                End If
            End If
        Next

        Using con As New SqlConnection(constr)
            '  con.Open()
            Dim sqlBulk As New SqlBulkCopy(constr)
            Dim yea As String = DateTime.Now.Year
            Dim mon As String = DateTime.Now.Month
            If mon < 10 Then
                mon = "0" + mon
            End If
            ' Dim tot As String = yea + mon
            tot = yea
            Dim prevmon As String = Convert.ToDateTime(review).ToString("MM")

            If prevmon = "12" Then
                tot = DateTime.Today.AddYears(-1)
                tot = Convert.ToDateTime(tot).ToString("yyyy")
                mon = "12"
            End If
            strsql = "select * from information_schema.tables where TABLE_NAME='" & tot & "' "
            If sqlselectmaster(constr, strsql, "Abc") Then
                If ds.Tables("Abc").Rows.Count > 0 Then
                    Dim tbname As String = ds.Tables(0).Rows(0)("TABLE_NAME")
                    tbname = "[dbo]" + "." + "[" + tbname + "]"
                    sqlBulk.DestinationTableName = tbname
                    sqlBulk.ColumnMappings.Add("Month", "Month")
                    sqlBulk.ColumnMappings.Add("EmployeeCode", "EmployeeCode")
                    sqlBulk.ColumnMappings.Add("ReviewMonth", "ReviewMonth")
                    sqlBulk.ColumnMappings.Add("cl", "CL")
                    sqlBulk.ColumnMappings.Add("sl", "SL")
                    sqlBulk.ColumnMappings.Add("pl", "PL")
                    sqlBulk.ColumnMappings.Add("lwp", "LWP")
                    sqlBulk.ColumnMappings.Add("Other Leaves", "OtherLeaves")
                    sqlBulk.ColumnMappings.Add("Actual Working Days", "ActualWorkingDays")
                    sqlBulk.ColumnMappings.Add("Actual Present Days", "ActualPresentDays")
                    sqlBulk.ColumnMappings.Add("Absent Days", "AbsentDays")
                    sqlBulk.ColumnMappings.Add("Attend Score", "LeavesScores")
                    sqlBulk.ColumnMappings.Add("Score", "TotScore")
                    sqlBulk.ColumnMappings.Add("Review (During/Final)", "Review_Dur")
                    sqlBulk.ColumnMappings.Add("Review Period (Month)", "Review")
                    sqlBulk.ColumnMappings.Add("Form_Status", "Form_Status")
                    sqlBulk.ColumnMappings.Add("Department", "Department")
                    sqlBulk.ColumnMappings.Add("Section", "Section")
                    sqlBulk.ColumnMappings.Add("EmployeeName", "EmployeeName")
                    sqlBulk.WriteToServer(dt)


                    If linechecked.Checked = True Then

                        Using client As New WebClient()
                            client.Headers.Add("Authorization", "Bearer " & "M15TFNEPwbhIm91oqzZ9SixQFRcoeCz9UT68BBizByw")
                            Dim values As New NameValueCollection()
                            values("message") = " 📢 Dear PMS Website User," & vbCrLf & vbCrLf &
    "Please be informed that you can now begin filling out the monthly PMS forms." & vbCrLf & vbCrLf &
    "Should you have any queries or require assistance regarding the PMS website, kindly reach out to the respective teams listed below:" & vbCrLf & vbCrLf &
    "🔹 IT Team" & vbCrLf &
    "   - Contact: Bharat Shete" & vbCrLf &
    "   - Extension: 2007" & vbCrLf & vbCrLf &
    "🔹 HR Team" & vbCrLf &
    "   - Contact: Janvi Mam" & vbCrLf &
    "   - Extension: 1175" & vbCrLf & vbCrLf &
    "Thank you for your cooperation!" & vbCrLf & vbCrLf &
    "Best regards," & vbCrLf &
    "HR Team"

                            Dim response As Byte() = client.UploadValues("https://notify-api.line.me/api/notify", values)
                            Dim responseString As String = System.Text.Encoding.Default.GetString(response)
                        End Using
                    End If



                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Details Inserted Successfully');", True)
                Else
                    Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode("Table does not found") + "')</script>")
                End If
            End If

        End Using
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

                If formatId = CUInt(Formats.DateShort) OrElse formatId = CUInt(Formats.DateLong) Then
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
    Protected Sub send_Click(sender As Object, e As EventArgs) Handles send.Click

        Dim SmtpClient As New SmtpClient("smtp-mail.outlook.com", 587) ' Ethereal SMTP server
            Dim MSG As New MailMessage()


        Dim fromAddress As New MailAddress("hrtraining@in.maxxis.com")
        Dim toEmails As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim Department As String = ""
        Dim section As String = ""
        Dim dt As DataTable = GetDepartmentSectionEmails(Department, section.Replace("&amp;", "&"))
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
        Dim smtpUser As String = ConfigurationManager.AppSettings("SMTPUser")
                Dim smtpPass As String = ConfigurationManager.AppSettings("SMTPPassword")

                ' Use Ethereal username and password
                SmtpClient.Credentials = New NetworkCredential(smtpUser, smtpPass)
                SmtpClient.EnableSsl = True
                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network

                MSG.From = fromAddress

                Dim Path As String = Server.MapPath("~/MailTemplate/TemplateOfAttendance.html")
                Dim htmlBody As String = System.IO.File.ReadAllText(Path)

                Dim currentMonthName As String = Now.ToString("MMMM yyyy")

        htmlBody = htmlBody.Replace("25th May 2025", "25th " & currentMonthName)

        Dim currentYear As String = Now.Year.ToString()
        Dim currentMonth As String = Now.Month.ToString("D2") ' "D2" ensures two-digit formatting for months like "05" for May

        ' Replace the placeholder in htmlBody with the dynamic year and month
        htmlBody = htmlBody.Replace("請務必於2025年5月25日或之前完整填寫並提交表格", "請務必於" & currentYear & "年" & currentMonth & "月25日或之前完整填寫並提交表格")


        MSG.Subject = "Reminder: PMS Form Filling Process Has Started - 提醒：- 自動溫馨提醒信件：績效管理系統（PMS）填寫程序已開始"
        MSG.Body = htmlBody
                MSG.IsBodyHtml = True

        SmtpClient.Send(MSG)
        ' Show success alert after sending the email
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert", "alert('Email sent successfully');", True)



    End Sub


    'Protected Sub send_Click(sender As Object, e As EventArgs) Handles send.Click
    '    Try


    '        'Dim SmtpClient As SmtpClient = New SmtpClient("zhcss009.cst.com.tw", 25)
    '        Dim SmtpClient As SmtpClient = New SmtpClient("smtp.office365.com", 587)
    '        Dim MSG As New MailMessage
    '        Try

    '            'SmtpClient.UseDefaultCredentials = True
    '            ' Dim fromAddress As New MailAddress("indmis5@mail.cst.com.tw")
    '            Dim fromAddress As New MailAddress("330i001@in.maxxis.com")
    '            Dim mailClient As NetworkCredential = New NetworkCredential("330i001@in.maxxis.com", "Mri@74587")
    '            SmtpClient.EnableSsl = True
    '            'mailClient.Credentials = New NetworkCredential("330i001@in.maxxis.com", "Mri@74587")
    '            ' Dim toAddress As New MailAddress("indmis5@mail.cst.com.tw")
    '            ' Dim toAddress As New MailAddress("itequipment@in.maxxis.com")
    '            Dim toAddress As New MailAddress("yidadov701@miracle3.com")
    '            MSG.From = fromAddress
    '            MSG.To.Add(toAddress)

    '            Dim Path As String = Server.MapPath("~/MailTemplate/TemplateOfAttendance.html")

    '            ' MSG.To.ASerdd("indmis5@mail.cst.com.tw")
    '            Dim htmlBody As String = System.IO.File.ReadAllText(Path)

    '            ' Get current month name
    '            Dim currentMonthName As String = Now.ToString("MMMM") ' Example: "April"

    '            htmlBody = htmlBody.Replace("25th April", "25th " & currentMonthName)

    '            MSG.Subject = "Gentle Reminder for PMS(Performance Management System) form"
    '            MSG.Body = htmlBody

    '            SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
    '            SmtpClient.Send(MSG)

    '        Catch ex As System.Exception
    '            Response.Write("Err " & ex.Message)
    '        End Try


    '    Catch ex As Exception
    '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '    End Try
    'End Sub

    Protected Sub RefreshBtn_Click(sender As Object, e As EventArgs)
        Response.Redirect(Request.RawUrl) ' Reloads the current page
    End Sub
    Protected Sub DownloadSampleBtn_Click(sender As Object, e As EventArgs)
        Try
            Dim filePath As String = Server.MapPath("~/Excel/ReSalesDummy.xlsx")

            If System.IO.File.Exists(filePath) Then
                Response.Clear()
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                Response.AddHeader("Content-Disposition", "attachment; filename=ReSalesDummy.xlsx")
                Response.WriteFile(filePath)
                Response.Flush()

                ' Use CompleteRequest to avoid ThreadAbortException
                HttpContext.Current.ApplicationInstance.CompleteRequest()
                Return ' Stop executing further code in this method
            Else
                lblStatus.ForeColor = System.Drawing.Color.Red
                lblStatus.Text = "Sample file not found: " & filePath
            End If
        Catch ex As Exception
            lblStatus.ForeColor = System.Drawing.Color.Red
            lblStatus.Text = "Error downloading file: " & ex.Message
        End Try
    End Sub



    'Protected Sub ReSalesImportbtn_Click(sender As Object, e As EventArgs)
    '    lblStatus.Text = ""
    '    lblStatus.ForeColor = System.Drawing.Color.Red

    '    If Not FileUpload2.HasFile Then
    '        lblStatus.Text = "Please select a file to upload."
    '        Return
    '    End If

    '    Dim ext As String = System.IO.Path.GetExtension(FileUpload2.FileName).ToLower()
    '    If ext <> ".xlsx" Then
    '        lblStatus.Text = "Only .xlsx files are supported."
    '        Return
    '    End If

    '    Dim fileName As String = System.IO.Path.GetFileName(FileUpload2.FileName)

    '    Dim path As String = Server.MapPath("~/Emp_File/" & fileName)

    '    Try
    '        FileUpload2.SaveAs(path)

    '        Dim dt As New DataTable()

    '        Using doc As SpreadsheetDocument = SpreadsheetDocument.Open(path, False)
    '            Dim sheet As Sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild(Of Sheet)()
    '            Dim worksheetPart As WorksheetPart = CType(doc.WorkbookPart.GetPartById(sheet.Id), WorksheetPart)
    '            Dim rows As IEnumerable(Of Row) = worksheetPart.Worksheet.Descendants(Of Row)()
    '            Dim sharedStrings = doc.WorkbookPart.SharedStringTablePart?.SharedStringTable

    '            Dim isHeader As Boolean = True
    '            For Each row As Row In rows
    '                If isHeader Then
    '                    For Each cell As Cell In row.Elements(Of Cell)()
    '                        Dim colName As String = GetCellValue(doc, cell, sharedStrings).Trim()
    '                        If Not String.IsNullOrEmpty(colName) Then
    '                            If Not dt.Columns.Contains(colName) Then
    '                                dt.Columns.Add(colName)
    '                            Else
    '                                dt.Columns.Add(colName & "_1") ' Avoid duplicate column names
    '                            End If
    '                        End If
    '                    Next
    '                    isHeader = False
    '                Else
    '                    Dim dr As DataRow = dt.NewRow()
    '                    Dim i As Integer = 0
    '                    For Each cell As Cell In row.Elements(Of Cell)()
    '                        If i < dt.Columns.Count Then
    '                            dr(i) = GetCellValue(doc, cell, sharedStrings).Trim()
    '                        End If
    '                        i += 1
    '                    Next
    '                    dt.Rows.Add(dr)
    '                End If
    '            Next
    '        End Using

    '        If dt.Rows.Count = 0 Then
    '            lblStatus.Text = "No data found in the Excel file."
    '            Return
    '        End If

    '        Using con As New SqlConnection(constr)
    '            con.Open()

    '            For Each row As DataRow In dt.Rows
    '                ' Check if all columns in this row are empty or DBNull
    '                Dim allEmpty As Boolean = True
    '                For Each col As DataColumn In dt.Columns
    '                    Dim value = row(col)
    '                    If Not (value Is DBNull.Value OrElse String.IsNullOrWhiteSpace(value.ToString())) Then
    '                        allEmpty = False
    '                        Exit For
    '                    End If
    '                Next

    '                If allEmpty Then
    '                    ' Skip this row because all values are empty
    '                    Continue For
    '                End If

    '                Using cmd As New SqlCommand("ManageReSales", con)
    '                    cmd.CommandType = CommandType.StoredProcedure
    '                    cmd.Parameters.AddWithValue("@Flag", "InsertReSalesData")

    '                    ' Map parameters as before
    '                    cmd.Parameters.AddWithValue("@QuarterType", If(row.Table.Columns.Contains("QuarterType"), row("QuarterType"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@empCode", If(row.Table.Columns.Contains("empCode"), row("empCode"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Months", If(row.Table.Columns.Contains("Months"), row("Months"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@TeamMembers", If(row.Table.Columns.Contains("TeamMembers"), row("TeamMembers"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@TW_Value", If(row.Table.Columns.Contains("TW_Value"), row("TW_Value"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Indian_Value", If(row.Table.Columns.Contains("Indian_Value"), row("Indian_Value"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Average_Value", If(row.Table.Columns.Contains("Average_Value"), row("Average_Value"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Plan_Percentage", If(row.Table.Columns.Contains("Plan_Percentage"), row("Plan_Percentage"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Expect_Percentage", If(row.Table.Columns.Contains("Expect_Percentage"), row("Expect_Percentage"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Expect_Tires", If(row.Table.Columns.Contains("Expect_Tires"), row("Expect_Tires"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Actual_Value", If(row.Table.Columns.Contains("Actual_Value"), row("Actual_Value"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Achievement_Percentage", If(row.Table.Columns.Contains("Achievement_Percentage"), row("Achievement_Percentage"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Extra_Tires", If(row.Table.Columns.Contains("Extra_Tires"), row("Extra_Tires"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Rate", If(row.Table.Columns.Contains("Rate"), row("Rate"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@PieceRateAmount", If(row.Table.Columns.Contains("PieceRateAmount"), row("PieceRateAmount"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@VariablePay", If(row.Table.Columns.Contains("VariablePay"), row("VariablePay"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Coefficient", If(row.Table.Columns.Contains("Coefficient"), row("Coefficient"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@PieceRatePlusVP", If(row.Table.Columns.Contains("PieceRatePlusVP"), row("PieceRatePlusVP"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Score", If(row.Table.Columns.Contains("Score"), row("Score"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Incentive", If(row.Table.Columns.Contains("Incentive"), row("Incentive"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@Remarks", If(row.Table.Columns.Contains("Remarks"), row("Remarks"), DBNull.Value))
    '                    cmd.Parameters.AddWithValue("@OverallComment", If(row.Table.Columns.Contains("OverallComment"), row("OverallComment"), DBNull.Value))

    '                    cmd.ExecuteNonQuery()
    '                End Using
    '            Next

    '        End Using



    '        lblStatus.ForeColor = System.Drawing.Color.Green
    '        lblStatus.Text = "Imported successfully."

    '    Catch ex As Exception
    '        lblStatus.Text = "Error: " & ex.Message
    '    End Try
    'End Sub
    'Private Function GetCellValue(doc As SpreadsheetDocument, cell As Cell, sharedStrings As SharedStringTable) As String
    '    If cell Is Nothing OrElse cell.CellValue Is Nothing Then
    '        Return ""
    '    End If

    '    Dim value = cell.CellValue.InnerText

    '    If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
    '        If sharedStrings IsNot Nothing AndAlso Integer.TryParse(value, Nothing) Then
    '            Dim index As Integer = Integer.Parse(value)
    '            If index < sharedStrings.ChildElements.Count Then
    '                Return sharedStrings.ElementAt(index).InnerText
    '            End If
    '        End If
    '    End If

    '    Return value
    'End Function
    Protected Sub ReSalesImportbtn_Click(sender As Object, e As EventArgs)
        lblStatus.Text = ""
        lblStatus.ForeColor = System.Drawing.Color.Red

        If Not FileUpload2.HasFile Then
            lblStatus.Text = "Please select a file to upload."
            Return
        End If

        Dim ext As String = System.IO.Path.GetExtension(FileUpload2.FileName).ToLower()
        If ext <> ".xlsx" Then
            lblStatus.Text = "Only .xlsx files are supported."
            Return
        End If

        Dim fileName As String = System.IO.Path.GetFileName(FileUpload2.FileName)
        Dim path As String = Server.MapPath("~/Emp_File/" & fileName)

        Try
            FileUpload2.SaveAs(path)

            Dim dt As New DataTable()

            Using doc As SpreadsheetDocument = SpreadsheetDocument.Open(path, False)
                Dim sheet As Sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild(Of Sheet)()
                Dim worksheetPart As WorksheetPart = CType(doc.WorkbookPart.GetPartById(sheet.Id), WorksheetPart)
                Dim rows As IEnumerable(Of Row) = worksheetPart.Worksheet.Descendants(Of Row)()
                Dim sharedStrings = doc.WorkbookPart.SharedStringTablePart?.SharedStringTable

                Dim isHeader As Boolean = True
                For Each row As Row In rows
                    If isHeader Then
                        For Each cell As Cell In row.Elements(Of Cell)()
                            Dim colName As String = GetCellValue(doc, cell, sharedStrings).Trim()
                            If Not String.IsNullOrEmpty(colName) Then
                                If Not dt.Columns.Contains(colName) Then
                                    dt.Columns.Add(colName)
                                Else
                                    dt.Columns.Add(colName & "_1") ' Avoid duplicate column names
                                End If
                            End If
                        Next
                        isHeader = False
                    Else
                        Dim dr As DataRow = dt.NewRow()
                        Dim i As Integer = 0
                        For Each cell As Cell In row.Elements(Of Cell)()
                            If i < dt.Columns.Count Then
                                dr(i) = GetCellValue(doc, cell, sharedStrings).Trim()
                            End If
                            i += 1
                        Next
                        dt.Rows.Add(dr)
                    End If
                Next
            End Using

            If dt.Rows.Count = 0 Then
                lblStatus.Text = "No data found in the Excel file."
                Return
            End If

            Using con As New SqlConnection(constr)
                con.Open()

                For Each row As DataRow In dt.Rows
                    Dim allEmpty As Boolean = True
                    For Each col As DataColumn In dt.Columns
                        Dim value = row(col)
                        If Not (value Is DBNull.Value OrElse String.IsNullOrWhiteSpace(value.ToString())) Then
                            allEmpty = False
                            Exit For
                        End If
                    Next

                    If allEmpty Then Continue For

                    Using cmd As New SqlCommand("ManageReSales", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@Flag", "InsertReSalesData")

                        Try
                            ' Add validated parameters
                            cmd.Parameters.AddWithValue("@QuarterType", row("QuarterType"))
                            cmd.Parameters.AddWithValue("@empCode", row("empCode"))
                            cmd.Parameters.AddWithValue("@Months", row("Months"))
                            cmd.Parameters.AddWithValue("@TeamMembers", GetDecimalValue("TeamMembers", row))
                            cmd.Parameters.AddWithValue("@TW_Value", GetDecimalValue("TW_Value", row))
                            cmd.Parameters.AddWithValue("@Indian_Value", GetDecimalValue("Indian_Value", row))
                            cmd.Parameters.AddWithValue("@Average_Value", GetDecimalValue("Average_Value", row))
                            cmd.Parameters.AddWithValue("@Plan_Percentage", GetDecimalValue("Plan_Percentage", row))
                            cmd.Parameters.AddWithValue("@Expect_Percentage", GetDecimalValue("Expect_Percentage", row))
                            cmd.Parameters.AddWithValue("@Expect_Tires", GetDecimalValue("Expect_Tires", row))
                            cmd.Parameters.AddWithValue("@Actual_Value", GetDecimalValue("Actual_Value", row))
                            cmd.Parameters.AddWithValue("@Achievement_Percentage", GetDecimalValue("Achievement_Percentage", row))
                            cmd.Parameters.AddWithValue("@Extra_Tires", GetDecimalValue("Extra_Tires", row))
                            cmd.Parameters.AddWithValue("@Rate", GetDecimalValue("Rate", row))
                            cmd.Parameters.AddWithValue("@PieceRateAmount", GetDecimalValue("PieceRateAmount", row))
                            cmd.Parameters.AddWithValue("@VariablePay", GetDecimalValue("VariablePay", row))
                            cmd.Parameters.AddWithValue("@Coefficient", GetDecimalValue("Coefficient", row))
                            cmd.Parameters.AddWithValue("@PieceRatePlusVP", GetDecimalValue("PieceRatePlusVP", row))
                            cmd.Parameters.AddWithValue("@Score", GetDecimalValue("Score", row))
                            cmd.Parameters.AddWithValue("@Incentive", GetDecimalValue("Incentive", row))
                            cmd.Parameters.AddWithValue("@Remarks", If(row.Table.Columns.Contains("Remarks"), row("Remarks"), DBNull.Value))
                            cmd.Parameters.AddWithValue("@OverallComment", If(row.Table.Columns.Contains("OverallComment"), row("OverallComment"), DBNull.Value))

                            cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            lblStatus.Text = "Row Error: " & ex.Message
                            lblStatus.ForeColor = System.Drawing.Color.Red
                            Exit Sub
                        End Try
                    End Using
                Next
            End Using

            lblStatus.ForeColor = System.Drawing.Color.Green
            lblStatus.Text = "Imported successfully."

        Catch ex As Exception
            lblStatus.Text = "Error: " & ex.Message
        End Try
    End Sub
    Private Function GetDecimalValue(colName As String, row As DataRow) As Object
        Try
            If Not row.Table.Columns.Contains(colName) Then Return DBNull.Value
            Dim val = row(colName)
            If val Is DBNull.Value OrElse String.IsNullOrWhiteSpace(val.ToString()) Then Return DBNull.Value
            Dim cleaned As String = val.ToString().Replace(",", "").Trim()
            Dim result As Decimal
            If Decimal.TryParse(cleaned, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, result) Then
                Return result
            Else
                Throw New Exception($"Invalid decimal in column '{colName}': '{val}'")
            End If
        Catch ex As Exception
            Throw New Exception($"Error in column '{colName}': {ex.Message}")
        End Try
    End Function

    Private Function GetIntValue(colName As String, row As DataRow) As Object
        Try
            If Not row.Table.Columns.Contains(colName) Then Return DBNull.Value
            Dim val = row(colName)
            If val Is DBNull.Value OrElse String.IsNullOrWhiteSpace(val.ToString()) Then Return DBNull.Value
            Dim result As Integer
            If Integer.TryParse(val.ToString().Trim(), result) Then
                Return result
            Else
                Throw New Exception($"Invalid integer in column '{colName}': '{val}'")
            End If
        Catch ex As Exception
            Throw New Exception($"Error in column '{colName}': {ex.Message}")
        End Try
    End Function
    Private Function GetCellValue(doc As SpreadsheetDocument, cell As Cell, sharedStrings As SharedStringTable) As String
        If cell Is Nothing OrElse cell.CellValue Is Nothing Then
            Return String.Empty
        End If

        Dim value As String = cell.CellValue.InnerText

        ' Check if the cell data type is SharedString
        If cell.DataType IsNot Nothing AndAlso cell.DataType.Value = CellValues.SharedString Then
            Dim index As Integer
            If Integer.TryParse(value, index) AndAlso index < sharedStrings.ChildElements.Count Then
                Return sharedStrings.ChildElements(index).InnerText
            End If
        End If

        Return value
    End Function



    'Protected Sub reopenBtn_Click(sender As Object, e As EventArgs)
    '    Dim empId As String = Request.Form("employeeId")
    '    Dim RevMonth As String = String.Format("{0:MMM-yy}", DateTime.Now.AddMonths(-1))

    '    If PMSclass.ReOpenEmployee(empId, RevMonth) Then
    '        lblStatus.Text = "ReOpen processed Successfully of :" & empId
    '    Else
    '        lblStatus.Text = "Failed to process ReOpen for :" & empId
    '    End If

    '    lblStatus.Text = "ReOpen processed Successfully of : " & empId




    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "refreshPage", "setTimeout(function(){ location.reload(); }, 2000);", True)
    'End Sub

    Protected Sub reopenBtn_Click(sender As Object, e As EventArgs)
        Dim empId As String = Request.Form("employeeId")
        Dim revMonth As String = String.Format("{0:MMM-yy}", DateTime.Now.AddMonths(-1))

        Dim success As Boolean = False
        Dim pcName As String = System.Environment.MachineName
        Dim ipAddress As String = PMSclass.GetLocalIPAddress()
        Dim empName As String = HttpContext.Current.Session("user name").ToString()
        Dim browserName As String = PMSclass.GetBrowser()
        Dim accessPowerName As String = "ReOpen Employee"
        Dim statusText As String

        ' 🔹 Call ReOpenEmployee
        If PMSclass.ReOpenEmployee(empId, revMonth) Then
            lblStatus.Text = "ReOpen processed Successfully of :" & empId
            success = True
        Else
            lblStatus.Text = "Failed to process ReOpen for :" & empId
            success = False
        End If

        ' ✅ Set status text
        statusText = If(success, "ReOpen", "ReOpen Failed")

        ' =========================
        ' 🔹 LOG FILE SAVE
        ' =========================
        Dim folderPath As String = "C:\PMS_Logs_LogIn_LogOut"
        Dim logFilePath As String = Path.Combine(folderPath, "LogFile.txt")
        If Not System.IO.Directory.Exists(folderPath) Then
            System.IO.Directory.CreateDirectory(folderPath)
        End If

        Dim logDate As String = DateTime.Now.ToString("yyyy-MM-dd")
        Dim logTime As String = DateTime.Now.ToString("HH:mm:ss")

        Dim logContent As String =
            $"{accessPowerName} {statusText} Successfully{vbCrLf}" &
            $"LogIn ID => {empId}{vbCrLf}" &
            $"Employee Name => {empName}{vbCrLf}" &
            $"PC Name => {pcName}{vbCrLf}" &
            $"IP Address => {ipAddress}{vbCrLf}" &
            $"Date => {logDate}{vbCrLf}" &
            $"Time => {logTime}{vbCrLf}" &
            $"Browser Name => {browserName}{vbCrLf}" &
            $"Status => {statusText}{vbCrLf}" &
            "===================================================================" & vbCrLf

        Try
            Using writer As New System.IO.StreamWriter(logFilePath, True)
                writer.WriteLine(logContent)
            End Using
        Catch ex As Exception
            Console.WriteLine("Error writing log file: " & ex.Message)
        End Try

        ' =========================
        ' 🔹 SAVE LOG TO DATABASE
        ' =========================
        Dim connectionString As String = "Data Source=10.90.1.11;Initial Catalog=HR_PMS_Web;User ID=sa;Password=incs@78;"
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "PMS_Log_Save")
                    command.Parameters.AddWithValue("@LoginId", empId)
                    command.Parameters.AddWithValue("@EmpName", empName)
                    command.Parameters.AddWithValue("@PcName", pcName)
                    command.Parameters.AddWithValue("@PcIp", ipAddress)
                    command.Parameters.AddWithValue("@LoginDate", DateTime.Now)
                    command.Parameters.AddWithValue("@Status", statusText)
                    command.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Console.WriteLine("Error saving log to database: " & ex.Message)
            End Try
        End Using

        ' 🔄 Refresh page after 2 seconds
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "refreshPage",
                                            "setTimeout(function(){ location.reload(); }, 2000);", True)
    End Sub


End Class



