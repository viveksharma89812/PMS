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


Public Class WebForm4
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String
    Dim review As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Dim xlApp As New Excel.Application
        'Dim xlWorkBook As excel.Workbook
        'Dim xlWorkSheet As excel.Worksheet
        'Dim range As Excel.Range
        '' xlApp = New Excel.Application
        'Dim filename As String = FileUpload1.PostedFile.FileName
        'Dim filePath As String = (Server.MapPath("~/Excel/") & filename)
        'FileUpload1.PostedFile.SaveAs((Server.MapPath("~/Excel/") & filename))
        '' xlWorkBook = xlApp.Workbooks.Open("D:\Emp Document\Attendance File.xlsx")
        'xlWorkBook = xlApp.Workbooks.Open(filePath)
        'xlWorkSheet = xlWorkBook.Worksheets("Sheet1")

        'range = xlWorkSheet.UsedRange
        'Dim rCnt As Integer = range.Rows.Count
        'Dim cCnt As Integer = range.Rows.Count
        '' Dim Obj As Object
        'Dim dt As New DataTable


        'For rCnt = 1 To range.Rows.Count
        '    If rCnt = 1 Then
        '        For cCnt = 1 To range.Columns.Count
        '            dt.Columns.Add(range.Cells(rCnt, cCnt).value2.ToString)
        '        Next
        '    Else

        '    End If
        'Next
        'Dim rowcounter As Integer
        'For rCnt = 2 To range.Rows.Count
        '    Dim row = dt.NewRow()
        '    rowcounter = 0
        '    For cCnt = 1 To range.Columns.Count

        '        If range.Cells(rCnt, cCnt) IsNot "" And range.Cells(rCnt, cCnt).value2 IsNot "" Then
        '            row(rowcounter) = range.Cells(rCnt, cCnt).value2.ToString()
        '        Else
        '            row(rCnt) = ""
        '        End If
        '        rowcounter = rowcounter + 1
        '    Next
        '    dt.Rows.Add(row)
        'Next

        'GridView1.DataSource = dt
        'GridView1.DataBind()
        'xlWorkBook.Close()
        'xlApp.Quit()

        'releaseObject(xlApp)
        'xlApp = Nothing
        'releaseObject(xlWorkBook)
        'releaseObject(xlWorkSheet)
        Try
            Dim filePath As String = Server.MapPath("~/Emp_File/") + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim FileExtension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName)
            If FileExtension = ".xlsx" Then
                FileUpload1.SaveAs(filePath)

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
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                End Using
            Else

            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try

        Try
            ' Dim strConnection As [String] = "Data Source=PC179006;Initial Catalog=HR_APP;User ID=sa;Password=maxxis@123"

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
                'strsql = "select * from Employee_Master where EmployeeCode='" & code & "'"
                strsql = "select * from Employee_Master1 where EmployeeCode='" & code & "'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        dept = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                        sect = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                        EmployeeName = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                    End If
                End If
                review = gvrow.Cells(1).Text
                Dim cl As Decimal = Decimal.Parse(gvrow.Cells(2).Text)
                Dim sl As Decimal = Decimal.Parse(gvrow.Cells(3).Text)
                Dim pl As Decimal = Decimal.Parse(gvrow.Cells(4).Text)
                Dim lwp As Decimal = Decimal.Parse(gvrow.Cells(5).Text)
                Dim otherleave As Decimal = Decimal.Parse(gvrow.Cells(6).Text)
                Dim actworking As Decimal = Decimal.Parse(gvrow.Cells(7).Text)
                Dim actpresent As Decimal = Decimal.Parse(gvrow.Cells(8).Text)
                Dim absent As Decimal = Decimal.Parse(gvrow.Cells(9).Text)
                Dim totscore As Decimal = Decimal.Parse(gvrow.Cells(10).Text)
                Dim score As Decimal = Decimal.Parse(gvrow.Cells(11).Text)
                Dim rev As String = gvrow.Cells(12).Text
                Dim revperiod As String = gvrow.Cells(13).Text
                Dim formstat As String = "PENDING"
                If revperiod = "&nbsp;" Then
                    revperiod = ""
                End If
                Dim yea As String = DateTime.Now.Year
                Dim mon As String = DateTime.Now.AddMonths(-1).Month
                'Dim prevMonth As Integer = mon.AddMonths(-1).Month
                If mon < 10 Then
                    mon = "0" + mon
                End If
                '  tot = yea + mon
                tot = yea
                Dim prevmon As String = Convert.ToDateTime(review).ToString("MM")
                'Dim prevmon As String = "12"

                If prevmon = "12" Then
                    tot = DateTime.Today.AddYears(-1)
                    tot = Convert.ToDateTime(tot).ToString("yyyy")
                    mon = "12"
                End If
                strsql = "select * from information_schema.tables where TABLE_NAME='" & tot & "' "
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                    Else
                        strsql = "create table[dbo].[" & tot & "](Month varchar(50),EmployeeCode nvarchar(50),EmployeeName nvarchar(50),ReviewMonth varchar(50),Department nvarchar(30),Section nvarchar(30),CL float,SL float,PL float,LWP float,OtherLeaves float,ActualWorkingDays float,ActualPresentDays float,AbsentDays float,LeavesScores float,TotScore float,Review_Dur varchar(50),Review varchar(50),Score1 int,Score2 int,Score3 int,Score4 int,Score5 int,Score6 int,Score7 int,Score8 int,Score9 int,Score10 int,Score11 int,Score12 int,Score13 int,Score14 int,Score15 int,Score16 int,Score17 int,Score18 int,TotalMarks int,Status nvarchar(50),Remark nvarchar(max),Ldr nvarchar(50), Shead nvarchar(50), Dhead nvarchar(50), Sshead nvarchar(50), Famnt int ,Amnt1 int , Empn varchar(50), Ldrn varchar(50), Sheadn varchar(50), Dheadn varchar(50), Empd varchar(50), Ldrd varchar(50), Sheadd varchar(50), Dheadd varchar(50), Remark1 nvarchar(max), Remark2 nvarchar(max), Remark3 nvarchar(max), Remark4 nvarchar(max), Emp_Accept1 varchar(20) , Emp_Accept2 varchar(20) ,Emp_Accept3 varchar(20) , Emp_Accept4 varchar(20) , Sameas varchar(50), Sincrease varchar(50), Sdecrease varchar(50),Form_Status varchar(50),Form_ID int,Emp_Accept varchar(20),Dept_Accept varchar(20),Sect_Accept varchar(20) , Plheadaccept varchar(20) , time nvarchar(50))"
                        If sqlexe(constr, strsql) Then
                        Else
                            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode("Invalid tablename") + "')</script>")
                        End If
                    End If
                End If
                'strsql = "select EmployeeCode from Employee_Master where EmployeeCode='" & code & "'"
                'If sqlselect(constr, strsql, "Abc") Then
                '    If ds.Tables("Abc").Rows.Count > 0 Then
                '        dt.Rows.Add(code, name, dept, sect, cl, sl, pl, lwp)
                '    Else
                '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(code + " " + "Is Incorrect") + "')</script>")
                '    End If
                'End If
                'strsql = "select EmployeeCode from Employee_Master where EmployeeCode='" & code & "' "
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
                                        strsql = "update" + tot + "Set EmployeeName=N'" & EmployeeName & "', Department=N'" & dept & "',Section=N'" & sect & "', CL='" & cl & "',SL='" & sl & "',PL='" & pl & "',LWP='" & lwp & "',OtherLeaves='" & otherleave & "',ActualWorkingDays='" & actworking & "',ActualPresentDays='" & actpresent & "',AbsentDays='" & absent & "',LeavesScores='" & totscore & "',TotScore='" & score & "',Review_Dur='" & rev & "',Review='" & revperiod & "',Form_Status='" & formstat & "'    where EmployeeCode='" & emcode & "' and Month='" & mon & "'"
                                        If sqlexe(constr, strsql) Then

                                        End If
                                    End If
                                Else
                                    dt.Rows.Add(mon, code, EmployeeName, review, dept, sect, cl, sl, pl, lwp, otherleave, actworking, actpresent, absent, totscore, score, rev, revperiod, formstat)
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
                'If mon = "01" Then
                '    tot = DateTime.Today.AddYears(-1)
                '    tot = Convert.ToDateTime(tot).ToString("yyyy")
                'End If
                strsql = "select * from information_schema.tables where TABLE_NAME='" & tot & "' "
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        Dim tbname As String = ds.Tables(0).Rows(0)("TABLE_NAME")
                        tbname = "[dbo]" + ". " + "[" + tbname + "]"
                        'tbname = "[" + tbname + "]"
                        'Dim tbschema As String = ds.Tables(0).Rows(0)("TABLE_SCHEMA")
                        'tbschema = "[" + tbschema + "]"
                        'Dim tt As String = tbschema + " . " + tbname
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

                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Details Inserted Successfully');", True)
                    Else
                        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode("Table does not found") + "')</script>")
                    End If
                End If
                '   con.Close()

            End Using
        Catch ex As Exception
            '  MsgBox(ex.ToString())
            'lblMsg.Text = ex.Message
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
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

    'Private Sub releaseObject(ByVal obj As Object)
    '    Try
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
    '        obj = Nothing
    '    Catch ex As Exception
    '        obj = Nothing
    '    Finally
    '        GC.Collect()
    '    End Try
    'End Sub
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
        Try

            'Dim OutlookMessage As Microsoft.Office.Interop.Outlook.MailItem
            'Dim AppOutlook As New Microsoft.Office.Interop.Outlook.Application
            'Response.Write("<script>Hello</script>")
            'OutlookMessage = AppOutlook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)
            'Dim Recipents As Microsoft.Office.Interop.Outlook.Recipients = OutlookMessage.Recipients
            'Recipents.Add("indmis5@mail.cst.com.tw")
            'OutlookMessage.Subject = "This mail is for testing "
            'OutlookMessage.HTMLBody = "Hello"
            'OutlookMessage.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML
            'OutlookMessage.Send()
            'Response.Write("<script> alert('Your Password Details Sent to your mail' );window.location = '" + Request.RawUrl + "';</script>")


            Dim SmtpClient As SmtpClient = New SmtpClient("zhcss009.cst.com.tw", 25)
            Dim MSG As New MailMessage
            Try
                SmtpClient.UseDefaultCredentials = True
                Dim fromAddress As New MailAddress("indmis5@mail.cst.com.tw")
                Dim toAddress As New MailAddress("indmis5@mail.cst.com.tw")
                MSG.From = fromAddress
                MSG.To.Add(toAddress)
                ' MSG.To.Add("indmis5@mail.cst.com.tw")
                MSG.Subject = "Testing"
                MSG.Body = "Testing"

                SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
                SmtpClient.Send(MSG)

            Catch ex As System.Exception
                Response.Write("Err " & ex.Message)
            End Try


        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub


    'Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    'End Sub

    'Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
    '    Dim con As New SqlConnection("Data Source=PC179006; Initial Catalog=testapp; User ID=sa;Password=maxxis@123")
    'Try
    '    con.Open()
    '    Dim cmd As New SqlCommand("create table Employee (empno int,empname varchar(50),salary money);", con)
    '    cmd.ExecuteNonQuery()
    '    lblMsg.Text = "SucessFully Connected"
    '    con.Close()

    'Catch ex As Exception
    '    MsgBox(ex.ToString())
    'End Try

    ' Try
    ' con.Open()

    '----- for check table And create New table----
    'Dim yea As String = DateTime.Now.Year
    'Dim mon As String = DateTime.Now.Month
    'If mon < 10 Then
    '    mon = "0" + mon
    'End If
    'Dim tot As String = yea + mon
    'strsql = "select * from information_schema.tables where TABLE_NAME='" & tot & "' "
    'If sqlselect(constr, strsql, "Abc") Then
    '    If ds.Tables("Abc").Rows.Count > 0 Then
    '    Else
    '        strsql = "create table[dbo].[" & tot & "](EmployeeCode varchar(50) primary Key,EmployeeName varchar(50),Department varchar(50),Section varchar(max),CL float,PL float,SL float,LWP float)"
    '        If sqlexe(constr, strsql) Then
    '        Else
    '            MsgBox("invalid")
    '        End If
    '    End If
    'End If


    'Dim cmd As New SqlCommand("create Database Leaves_Scores", con)
    'cmd.ExecuteNonQuery()
    '' Response.Write("SucessFully Connected")
    'Response.Write(" <script> alert('SucessFully Connected' );window.location = '" + Request.RawUrl + "';</script>")
    ' con.Close()
    '  ---- for create store procedure---
    'con.Open()
    'Dim cmd As New SqlCommand("dbo.Addnewtable", con)

    'cmd.CommandType = CommandType.StoredProcedure

    'cmd.Parameters.AddWithValue("@K_Tname", TextBox1.Text)
    'Dim rdr As SqlDataReader = cmd.ExecuteReader()

    'Catch ex As Exception
    '        Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
    '    End Try
    'End Sub
End Class



