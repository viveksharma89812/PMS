Imports System.IO
Imports System.Text.RegularExpressions

Public Class PmsLogs
    Inherits System.Web.UI.Page
    Private WithEvents timer As New Timer()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access power") = "" Then
            Response.Redirect("login.aspx")
        End If

        logsTables.InnerHtml = PMS_Log_Get("", Nothing, Nothing)
    End Sub

    'Public Function PMS_Log_Get() As String
    '    Dim folderPath As String = "C:\PMS_Logs_LogIn_LogOut"
    '    Dim logFilePath As String = Path.Combine(folderPath, "LogFile.txt")
    '    Dim logs As New List(Of LogEntry)

    '    If File.Exists(logFilePath) Then
    '        Try
    '            Dim logLines As String() = File.ReadAllLines(logFilePath)
    '            Dim logEntry As LogEntry = Nothing

    '            For Each line In logLines
    '                ' Identify LogIn/LogOut status and map accordingly
    '                If line.Contains("HR LogIn Successfully") OrElse
    '               line.Contains("HR LogOut Successfully") OrElse
    '               line.Contains("Section Head LogIn Successfully") OrElse
    '               line.Contains("Section Head LogOut Successfully") OrElse
    '               line.Contains("Employee LogIn Successfully") OrElse
    '               line.Contains("Employee LogOut Successfully") OrElse
    '               line.Contains("Department Head LogIn Successfully") OrElse
    '               line.Contains("Department Head LogOut Successfully") Then
    '                    ' If there is already an existing log entry, save it and create a new one
    '                    If logEntry IsNot Nothing Then
    '                        logs.Add(logEntry)
    '                    End If
    '                    logEntry = New LogEntry()
    '                    logEntry.Panel = line

    '                    ' Extract various log details
    '                ElseIf line.Contains("LogIn ID =>") Then
    '                    logEntry.LogInID = ExtractLogInfo(line, "LogIn ID =>")

    '                ElseIf line.Contains("Employee Name =>") Then
    '                    logEntry.EmployeeName = ExtractLogInfo(line, "Employee Name =>")

    '                ElseIf line.Contains("PC Name =>") Then
    '                    logEntry.PCName = ExtractLogInfo(line, "PC Name =>")

    '                ElseIf line.Contains("IP Address =>") Then
    '                    logEntry.IPAddress = ExtractLogInfo(line, "IP Address =>")

    '                ElseIf line.Contains("Date =>") Then
    '                    logEntry.Dates = ExtractLogInfo(line, "Date =>")

    '                ElseIf line.Contains("Time =>") Then
    '                    logEntry.Time = ExtractLogInfo(line, "Time =>")

    '                ElseIf line.Contains("Browser Name =>") Then
    '                    logEntry.BrowserName = ExtractLogInfo(line, "Browser Name =>")

    '                ElseIf line.Contains("Status =>") Then
    '                    logEntry.Status = ExtractLogInfo(line, "Status =>")
    '                End If
    '            Next

    '            ' Add the last log entry if it's not null
    '            If logEntry IsNot Nothing Then
    '                logs.Add(logEntry)
    '            End If

    '        Catch ex As Exception
    '            Console.WriteLine("Error reading log file: " & ex.Message)
    '        End Try
    '    Else
    '        Console.WriteLine("Log file not found.")
    '    End If
    '    Dim html As New StringBuilder()
    '    html.AppendLine("<table class='table-container'>")
    '    html.AppendLine("<thead>")
    '    html.AppendLine("<tr>")
    '    html.AppendLine("<th>SrNo.</th>")
    '    html.AppendLine("<th>Employee Code</th>")
    '    html.AppendLine("<th>Employee Name</th>")
    '    html.AppendLine("<th>Message</th>")
    '    html.AppendLine("<th>PC Name</th>")
    '    html.AppendLine("<th>IP Address</th>")
    '    html.AppendLine("<th>Date</th>")
    '    html.AppendLine("<th>Time</th>")
    '    html.AppendLine("<th>Status</th>")
    '    html.AppendLine("</tr>")
    '    html.AppendLine("</thead>")
    '    html.AppendLine("<tbody>")

    '    ' Add rows for each log entry
    '    Dim index As Int32 = 1
    '    For Each log As LogEntry In logs
    '        html.AppendLine("<tr>")
    '        html.AppendLine("<td>" & index & "</td>")
    '        html.AppendLine("<td>" & log.LogInID & "</td>")
    '        html.AppendLine("<td>" & log.EmployeeName & "</td>")
    '        html.AppendLine("<td>" & log.Panel & "</td>")
    '        html.AppendLine("<td>" & log.PCName & "</td>")
    '        html.AppendLine("<td>" & log.IPAddress & "</td>")
    '        html.AppendLine("<td>" & log.Dates & "</td>")
    '        html.AppendLine("<td>" & log.Time & "</td>")
    '        html.AppendLine("<td>" & log.Status & "</td>")
    '        html.AppendLine("</tr>")
    '        index += 1
    '    Next

    '    html.AppendLine("</tbody>")
    '    html.AppendLine("</table>")

    '    ' Return the HTML table as a string
    '    Return html.ToString()




    'End Function

    '' Helper function to extract values from log lines
    'Private Function ExtractLogInfo(ByVal line As String, ByVal label As String) As String
    '    ' Extract the part after the label, assuming format "Label => Value"
    '    Dim parts As String() = line.Split(New String() {label}, StringSplitOptions.None)
    '    If parts.Length > 1 Then
    '        Return parts(1).Trim()
    '    End If
    '    Return String.Empty
    'End Function
    Protected Sub btnFind_Click(sender As Object, e As EventArgs)
        ' Clear any previous messages
        lblMessage.Visible = False

        ' Get inputs from user
        Dim employeeCode As String = TextBox1.Text.Trim()
        Dim fromDate As DateTime?
        Dim toDate As DateTime?

        ' Parse From Date and To Date if provided
        If Not String.IsNullOrEmpty(txtFromDate.Text) Then
            fromDate = Convert.ToDateTime(txtFromDate.Text)
        End If

        If Not String.IsNullOrEmpty(txtToDate.Text) Then
            toDate = Convert.ToDateTime(txtToDate.Text)
        End If

        ' Validate the dates
        If fromDate.HasValue AndAlso toDate.HasValue Then
            If fromDate.Value > toDate.Value Then
                lblMessage.Text = "Please enter correct From and To dates."
                lblMessage.Visible = True
                Return
            End If
        End If

        ' Fetch logs based on employee code and date range
        Dim logsHtml As String = PMS_Log_Get(employeeCode, fromDate, toDate)

        ' Display the logs table
        logsTables.InnerHtml = logsHtml
    End Sub

    ' Event for Reset button click
    Protected Sub btnReset_Click(sender As Object, e As EventArgs)
        ' Reset the fields and hide the message
        TextBox1.Text = ""
        txtFromDate.Text = ""
        txtToDate.Text = ""
        lblMessage.Visible = False

        ' Fetch and display the initial 200 records
        Dim logsHtml As String = PMS_Log_Get("", Nothing, Nothing)
        logsTables.InnerHtml = logsHtml
    End Sub
    Public Function PMS_Log_Get(ByVal employeeCode As String, ByVal fromDate As DateTime?, ByVal toDate As DateTime?) As String
        Dim folderPath As String = "C:\PMS_Logs_LogIn_LogOut"
        Dim logFilePath As String = Path.Combine(folderPath, "LogFile.txt")
        Dim logs As New List(Of LogEntry)()

        If File.Exists(logFilePath) Then
            Try
                ' Read all lines from the log file
                Dim logLines As String() = File.ReadAllLines(logFilePath)
                Dim logEntry As LogEntry = Nothing

                For Each line In logLines
                    ' Identify LogIn/LogOut status and map accordingly
                    If line.Contains("HR LogIn Successfully") OrElse
                   line.Contains("HR LogOut Successfully") OrElse
                   line.Contains("Section Head LogIn Successfully") OrElse
                   line.Contains("Section Head LogOut Successfully") OrElse
                   line.Contains("Employee LogIn Successfully") OrElse
                   line.Contains("Employee LogOut Successfully") OrElse
                   line.Contains("Department Head LogIn Successfully") OrElse
                   line.Contains("Department Head LogOut Successfully") Then
                        ' If there is already an existing log entry, save it and create a new one
                        If logEntry IsNot Nothing Then
                            logs.Add(logEntry)
                        End If
                        logEntry = New LogEntry()
                        logEntry.Panel = line

                        ' Extract log details based on each line
                    ElseIf line.Contains("LogIn ID =>") Then
                        logEntry.LogInID = ExtractLogInfo(line, "LogIn ID =>")

                    ElseIf line.Contains("Employee Name =>") Then
                        logEntry.EmployeeName = ExtractLogInfo(line, "Employee Name =>")

                    ElseIf line.Contains("PC Name =>") Then
                        logEntry.PCName = ExtractLogInfo(line, "PC Name =>")

                    ElseIf line.Contains("IP Address =>") Then
                        logEntry.IPAddress = ExtractLogInfo(line, "IP Address =>")

                    ElseIf line.Contains("Date =>") Then
                        logEntry.Dates = ExtractLogInfo(line, "Date =>")

                    ElseIf line.Contains("Time =>") Then
                        logEntry.Time = ExtractLogInfo(line, "Time =>")

                    ElseIf line.Contains("Browser Name =>") Then
                        logEntry.BrowserName = ExtractLogInfo(line, "Browser Name =>")

                    ElseIf line.Contains("Status =>") Then
                        logEntry.Status = ExtractLogInfo(line, "Status =>")
                    End If
                Next

                ' Add the last log entry if it's not null
                If logEntry IsNot Nothing Then
                    logs.Add(logEntry)
                End If

            Catch ex As Exception
                ' Handle errors if reading the file fails
                Console.WriteLine("Error reading log file: " & ex.Message)
            End Try
        Else
            Console.WriteLine("Log file not found.")
        End If

        ' Generate the HTML table for logs
        Dim html As New StringBuilder()
        html.AppendLine("<table class='table-container'>")
        html.AppendLine("<thead>")
        html.AppendLine("<tr>")
        html.AppendLine("<th>SrNo.</th>")
        html.AppendLine("<th>Employee Code</th>")
        html.AppendLine("<th>Employee Name</th>")
        html.AppendLine("<th>Message</th>")
        html.AppendLine("<th>IP Address</th>")
        html.AppendLine("<th>Date</th>")
        html.AppendLine("<th>Time</th>")
        html.AppendLine("<th>Status</th>")
        html.AppendLine("</tr>")
        html.AppendLine("</thead>")
        html.AppendLine("<tbody>")

        ' Add rows for each log entry
        Dim index As Int32 = 1
        For Each log As LogEntry In logs
            ' Filter based on employee code, from date, and to date if necessary
            If Not String.IsNullOrEmpty(employeeCode) AndAlso log.LogInID <> employeeCode Then
                Continue For
            End If

            If fromDate.HasValue AndAlso log.Dates < fromDate Then
                Continue For
            End If

            If toDate.HasValue AndAlso log.Dates > toDate Then
                Continue For
            End If

            html.AppendLine("<tr>")
            html.AppendLine("<td>" & index & "</td>")
            html.AppendLine("<td>" & log.LogInID & "</td>")
            html.AppendLine("<td>" & log.EmployeeName & "</td>")
            html.AppendLine("<td>" & log.Panel & "</td>")
            html.AppendLine("<td>" & log.IPAddress & "</td>")
            html.AppendLine("<td>" & log.Dates & "</td>")
            html.AppendLine("<td>" & log.Time & "</td>")
            html.AppendLine("<td>" & log.Status & "</td>")
            html.AppendLine("</tr>")
            index += 1
        Next

        html.AppendLine("</tbody>")
        html.AppendLine("</table>")

        ' Return the HTML table as a string
        Return html.ToString()
    End Function


    ' Helper function to extract values from log lines
    Private Function ExtractLogInfo(ByVal line As String, ByVal label As String) As String
        ' Extract the part after the label, assuming format "Label => Value"
        Dim parts As String() = line.Split(New String() {label}, StringSplitOptions.None)

        ' Check if the label exists and there is a value after the label
        If parts.Length > 1 Then
            ' Remove any leading or trailing spaces and return the extracted value
            Return parts(1).Trim()
        End If

        ' Return an empty string if label was not found or no value after the label
        Return String.Empty
    End Function













    Public Class LogEntry
        Public Property Panel As String
        Public Property LogInID As String
        Public Property EmployeeName As String
        Public Property PCName As String
        Public Property IPAddress As String
        Public Property Dates As String
        Public Property Time As String
        Public Property BrowserName As String
        Public Property Status As String
        Public Property Timestamp As DateTime
    End Class

End Class
