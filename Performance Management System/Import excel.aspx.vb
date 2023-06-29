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
            Dim filePath As String = Server.MapPath("~/DocFile/") + Path.GetFileName(FileUpload1.PostedFile.FileName)
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
            dt.Columns.Add("EmployeeCode", GetType(String))
            dt.Columns.Add("EmployeeName", GetType(String))
            dt.Columns.Add("Department", GetType(String))
            dt.Columns.Add("Section", GetType(String))
            dt.Columns.Add("CL", GetType(Decimal))
            dt.Columns.Add("SL", GetType(Decimal))
            dt.Columns.Add("PL", GetType(Decimal))
            dt.Columns.Add("LWP", GetType(Decimal))
            dt.Columns.Add("Actual Working Days", GetType(Decimal))
            dt.Columns.Add("Actual Present Days", GetType(Decimal))
            dt.Columns.Add("Absent Days", GetType(Decimal))
            dt.Columns.Add("Total Score", GetType(Decimal))



            For Each gvrow As GridViewRow In GridView1.Rows
                Dim code As String = gvrow.Cells(0).Text
                Dim name As String = gvrow.Cells(1).Text
                Dim dept As String = gvrow.Cells(2).Text
                Dim sect As String = gvrow.Cells(3).Text
                Dim cl As Decimal = Decimal.Parse(gvrow.Cells(4).Text)
                Dim sl As Decimal = Decimal.Parse(gvrow.Cells(5).Text)
                Dim pl As Decimal = Decimal.Parse(gvrow.Cells(6).Text)
                Dim lwp As Decimal = Decimal.Parse(gvrow.Cells(7).Text)
                Dim actworking As Decimal = Decimal.Parse(gvrow.Cells(8).Text)
                Dim actpresent As Decimal = Decimal.Parse(gvrow.Cells(9).Text)
                Dim absent As Decimal = Decimal.Parse(gvrow.Cells(10).Text)
                Dim totscore As Decimal = Decimal.Parse(gvrow.Cells(11).Text)

                Dim yea As String = DateTime.Now.Year
                Dim mon As String = DateTime.Now.Month
                If mon < 10 Then
                    mon = "0" + mon
                End If
                tot = yea + mon
                strsql = "select * from information_schema.tables where TABLE_NAME='" & tot & "' "
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                    Else
                        strsql = "create table[dbo].[" & tot & "](EmployeeCode varchar(50) primary Key,EmployeeName nvarchar(50),Department varchar(50),Section varchar(max),ReviewMonth varchar(50),CL float,SL float,PL float,LWP float,OtherLeaves float,ActualWorkingDays float,ActualPresentDays float,AbsentDays float,LeavesScores float,Score1 int,Score2 int,Score3 int,Score4 int,Score5 int,Score6 int,Score7 int,Score8 int,Score9 int,Score10 int,TotalMarks int)"
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
                strsql = "select EmployeeCode from Employee_Master where EmployeeCode='" & code & "'"
                If sqlselect(constr, strsql, "Abc") Then
                    If ds.Tables("Abc").Rows.Count > 0 Then
                        Dim empcode As String = Convert.ToString(ds.Tables("Abc").Rows(0)("EmployeeCode"))
                        If empcode = code Then
                            tot = "[dbo]" + ". " + "[" + tot + "]"
                            strsql = "select EmployeeCode from " + tot + "where EmployeeCode='" & code & "'"
                            If sqlselect(constr, strsql, "Abc") Then
                                If ds.Tables("Abc").Rows.Count > 0 Then
                                    Dim emcode As String = Convert.ToString(ds.Tables("Abc").Rows(0)("EmployeeCode"))
                                    If emcode = code Then
                                        strsql = "update" + tot + "Set CL='" & cl & "',SL='" & sl & "',PL='" & pl & "',LWP='" & lwp & "',ActualWorkingDays='" & actworking & "',ActualPresentDays='" & actpresent & "',AbsentDays='" & absent & "',LeavesScores='" & totscore & "'    where EmployeeCode='" & emcode & "'"
                                        If sqlexe(constr, strsql) Then

                                        End If
                                    End If
                                Else
                                    dt.Rows.Add(code, name, dept, sect, cl, sl, pl, lwp, actworking, actpresent, absent, totscore)
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
                Dim tot As String = yea + mon

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
                        sqlBulk.WriteToServer(dt)
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Details Inserted Successfully');window.location = '" + Request.RawUrl + "';", True)
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
            End If
            Return value
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
                Dim fromAddress As New MailAddress("indmis5@mail.cst.com.tw", "TestIT")
                Dim toAddress As New MailAddress("indmis5@mail.cst.com.tw", "Test_Monitor")
                MSG.From = fromAddress
                MSG.To.Add(toAddress)
                ' MSG.To.Add("indmis5@mail.cst.com.tw")
                MSG.Subject = "Test Subject"
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



