
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports DocumentFormat.OpenXml.Wordprocessing

Public Class PMSClass

    Dim connectionString As String = "Data Source=10.90.1.11;Initial Catalog=HR_PMS_Web;User ID=sa;Password=incs@78;"

    'Dim connectionString As String = "Data Source=10.90.50.67;Initial Catalog=HR_PMS_Web;User ID=sa;Password=maxxis@123"
    Public Function variablepay(year As String, review As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "variablepay")
                    command.Parameters.AddWithValue("@Reviewmonth", review)
                    command.Parameters.AddWithValue("@Year", year)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dtt As New DataTable()
                    adapter.Fill(dtt)
                    Return dtt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    Public Function variablepayexport(year As String, review As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "variablepayexport")
                    command.Parameters.AddWithValue("@Reviewmonth", review)
                    command.Parameters.AddWithValue("@Year", year)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dtt As New DataTable()
                    adapter.Fill(dtt)
                    Return dtt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    Public Function getpbvpemployee(year As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "getpbvpemployee")

                    command.Parameters.AddWithValue("@Year", year)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dtt As New DataTable()
                    adapter.Fill(dtt)
                    Return dtt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    Public Function GetEmployeeDataById(empCode As String) As DataTable
        Dim dt As New DataTable()

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("PMS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Flag", "variablepayById")
                cmd.Parameters.AddWithValue("@EMPcode", empCode)

                Using sda As New SqlDataAdapter(cmd)
                    Try
                        sda.Fill(dt)
                    Catch ex As Exception
                        ' Handle/log error
                    End Try
                End Using
            End Using
        End Using

        Return dt
    End Function
    Public Function UpdateEmployeeData(empCode As String, year As String, status As String, eligibility As String, remark As String, doe As DateTime?, PChostname As String) As Boolean
        Dim rowsAffected As Integer = 0

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand("PMS", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Flag", "UpdateVariablePay")
                cmd.Parameters.AddWithValue("@EMPcode", empCode)
                cmd.Parameters.AddWithValue("@Year", year)
                cmd.Parameters.AddWithValue("@EmpStatus", status)
                cmd.Parameters.AddWithValue("@PbvpStatus", eligibility)
                cmd.Parameters.AddWithValue("@Remark", remark)
                cmd.Parameters.AddWithValue("@DOE", doe)
                cmd.Parameters.AddWithValue("@PCHOST", PChostname)
                Try
                    con.Open()
                    rowsAffected = cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
            End Using
        End Using

        Return rowsAffected > 0
    End Function



    Public Function ImportVariablePayExcel(filePath As String) As Boolean
        Try
            Dim dt As New DataTable()
            Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"

            Using excelConn As New OleDbConnection(connStr)
                excelConn.Open()
                Dim schemaTable = excelConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                Dim sheetName As String = schemaTable.Rows(0)("TABLE_NAME").ToString()
                Dim cmd As New OleDbCommand("SELECT * FROM [" & sheetName & "]", excelConn)
                Dim da As New OleDbDataAdapter(cmd)
                da.Fill(dt)
            End Using

            Using sqlConn As New SqlConnection(connectionString)
                sqlConn.Open()

                For Each row As DataRow In dt.Rows
                    Using cmd As New SqlCommand("PMS", sqlConn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@Flag", "variablepayInsertData")
                        cmd.Parameters.AddWithValue("@EMPcode", row("EmployeeCode").ToString())
                        cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(row("Amount")))
                        cmd.Parameters.AddWithValue("@EmpStatus", row("EmpStatus").ToString())
                        cmd.Parameters.AddWithValue("@PbvpStatus", row("PbvpStatus").ToString())
                        cmd.Parameters.AddWithValue("@Remark", row("Remark").ToString())
                        cmd.Parameters.AddWithValue("@Year", row("Years").ToString())
                        cmd.Parameters.AddWithValue("@DOE", row("DOE"))
                        cmd.ExecuteNonQuery()
                    End Using
                Next
            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function Login(EMPcodeID As String, pwd As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "Login")
                    command.Parameters.AddWithValue("@EMPcode", EMPcodeID)
                    command.Parameters.AddWithValue("@password", pwd)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    Return dt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function


    Public Function checkimage(EMPcodeID As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "Imployeeempage")
                    command.Parameters.AddWithValue("@EMPcode", EMPcodeID)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    Return dt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function




    Public Function employeerecordssect(Year As String, dept As String, sec As String, Revmonth As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "employeerecords")
                    command.Parameters.AddWithValue("@Year", Year)
                    command.Parameters.AddWithValue("@Department", dept)
                    command.Parameters.AddWithValue("@Section", sec)
                    command.Parameters.AddWithValue("@Reviewmonth", Revmonth)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    Return dt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    Public Function employeerecordsdept(Year As String, dept As String, Revmonth As String, empcode As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    If empcode = "159022" Then  'there is static id of specific department head.
                        command.Parameters.AddWithValue("@Flag", "employeerecorddept1")
                    Else
                        command.Parameters.AddWithValue("@Flag", "employeerecorddept2")
                    End If
                    command.Parameters.AddWithValue("@Year", Year)
                    command.Parameters.AddWithValue("@Department", dept)
                    command.Parameters.AddWithValue("@Reviewmonth", Revmonth)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    Return dt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function



    Public Function Sectionheadanother(Year As String, dept As String, Revmonth As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "Sectionheadanother")
                    command.Parameters.AddWithValue("@Year", Year)
                    command.Parameters.AddWithValue("@Department", dept)
                    command.Parameters.AddWithValue("@Reviewmonth", Revmonth)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    Return dt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function
    Public Function Getempdetails(EMPcodeID As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try

                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "Getempdetails")
                    command.Parameters.AddWithValue("@EMPcode", EMPcodeID)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    Return dt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using

    End Function


    Public Function reviewclick(EMPcodeID As String, Year As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try

                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "reviewclick")
                    command.Parameters.AddWithValue("@EMPcode", EMPcodeID)
                    command.Parameters.AddWithValue("@Year", Year)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    Return dt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using

    End Function

    Public Function Filterdata(EMPcodeID As String, review As String, year As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try

                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "filterempdetails")
                    command.Parameters.AddWithValue("@EMPcode", EMPcodeID)
                    command.Parameters.AddWithValue("@Reviewmonth", review)
                    command.Parameters.AddWithValue("@Year", year)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dtt As New DataTable()
                    adapter.Fill(dtt)
                    Return dtt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using

    End Function
    Public Function Loadfirst(EMPcodeID As String, empid2 As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try

                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "Loadfirst")
                    command.Parameters.AddWithValue("@EMPcode", EMPcodeID)
                    command.Parameters.AddWithValue("@EMPcode1", empid2)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dtt As New DataTable()
                    adapter.Fill(dtt)
                    Return dtt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function
    Public Function Loadsecond(EMPcodeID As String, empid2 As String, year As String, review As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "Loadsecond")
                    command.Parameters.AddWithValue("@EMPcode", EMPcodeID)
                    command.Parameters.AddWithValue("@EMPcode1", empid2)
                    command.Parameters.AddWithValue("@Year", year)
                    command.Parameters.AddWithValue("@Reviewmonth", review)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dtt As New DataTable()
                    adapter.Fill(dtt)
                    Return dtt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    Public Function PMS_Log_Save(LoginId As String, EmpName As String, pcName As String, PcIp As String, LoginDate As DateTime, Status As String, AccessPowerName As String) As DataTable

        Dim folderPath As String = "C:\PMS_Logs_LogIn_LogOut"
        Dim logFilePath As String = Path.Combine(folderPath, "LogFile.txt")
        If Not System.IO.Directory.Exists(folderPath) Then
            System.IO.Directory.CreateDirectory(folderPath)
        End If
        Dim logContent As String
        Dim logDate As String = DateTime.Now.ToString("yyyy-MM-dd") ' Current Date
        Dim logTime As String = DateTime.Now.ToString("HH:mm:ss") ' Current Time
        Dim browserName = GetBrowser()
        If Status = "LogIn" Then
            logContent = $"{AccessPowerName} LogIn Successfully{vbCrLf}" &
                 $"LogIn ID => {LoginId}{vbCrLf}" &
                 $"Employee Name => {EmpName}{vbCrLf}" &
                 $"PC Name => {pcName}{vbCrLf}" &
                 $"IP Address => {PcIp}{vbCrLf}" &
                 $"Date => {logDate}{vbCrLf}" &
                 $"Time => {logTime}{vbCrLf}" &
                 $"Browser Name => {browserName}{vbCrLf}" &
                 $"Status => {Status}{vbCrLf}" &
                 "===================================================================" & vbCrLf
        ElseIf Status = "LogOut" Then
            logContent = $"{AccessPowerName} LogOut Successfully{vbCrLf}" &
                 $"LogIn ID => {LoginId}{vbCrLf}" &
                 $"Employee Name => {EmpName}{vbCrLf}" &
                 $"PC Name => {pcName}{vbCrLf}" &
                 $"IP Address => {PcIp}{vbCrLf}" &
                 $"Date => {logDate}{vbCrLf}" &
                 $"Time => {logTime}{vbCrLf}" &
                 $"Browser Name => {browserName}{vbCrLf}" &
                 $"Status => {Status}{vbCrLf}" &
                 "===================================================================" & vbCrLf
        Else
            logContent = "Unknown status, cannot log."
        End If
        Try
            Using writer As New System.IO.StreamWriter(logFilePath, True)
                writer.WriteLine(logContent)
            End Using
        Catch ex As Exception
            Console.WriteLine("Error writing log file: " & ex.Message)
        End Try

        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "PMS_Log_Save")
                    command.Parameters.AddWithValue("@LoginId", LoginId)
                    command.Parameters.AddWithValue("@EmpName", EmpName)
                    command.Parameters.AddWithValue("@PcName", pcName)
                    command.Parameters.AddWithValue("@PcIp", PcIp)
                    command.Parameters.AddWithValue("@LoginDate", LoginDate)
                    command.Parameters.AddWithValue("@Status", Status)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    Return dt
                End Using
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    'Public Function GetLocalIPAddress() As String
    '    Dim hostName As String = Dns.GetHostName()
    '    Dim ipAddresses As IPAddress() = Dns.GetHostAddresses(hostName)
    '    For Each ip As IPAddress In ipAddresses
    '        If ip.AddressFamily = AddressFamily.InterNetwork Then
    '            Return ip.ToString()
    '        End If
    '    Next

    '    Return "No IPv4 Address Found"
    'End Function
    Public Function GetLocalIPAddress() As String
        Dim clientIP As String = HttpContext.Current.Request.ServerVariables("REMOTE_ADDR")

        ' Check if the request was forwarded by a proxy or load balancer
        If Not String.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")) Then
            clientIP = HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        End If

        ' If multiple proxies are involved, we may get a list of IPs, so take the first one
        Dim ipList As String() = clientIP.Split(","c)
        Return ipList(0).Trim()
    End Function

    Public Function GetBrowser() As String
        Dim userAgent As String = HttpContext.Current.Request.UserAgent.ToLower()
        If userAgent.Contains("edge") Then
            Return "Microsoft Edge"
        ElseIf userAgent.Contains("chrome") Then
            Return "Google Chrome"
        ElseIf userAgent.Contains("firefox") Then
            Return "Mozilla Firefox"
        ElseIf userAgent.Contains("safari") Then
            Return "Safari"
        ElseIf userAgent.Contains("msie") OrElse userAgent.Contains("trident") Then
            Return "Internet Explorer"
        ElseIf userAgent.Contains("edge") Then
            Return "Microsoft Edge"
        Else
            Return "Unknown Browser .."
        End If
    End Function


    Public Function Plantheadapproved(year As String, review As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "Plantheadapproved")
                    command.Parameters.AddWithValue("@Year", year)
                    command.Parameters.AddWithValue("@Reviewmonth", review)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dtt As New DataTable()
                    adapter.Fill(dtt)
                    Return dtt
                End Using
                connection.Close()
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function
    Public Function LoadReSales(fst As String, tyear As String) As DataTable
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure

                    ' Add your parameters here
                    command.Parameters.AddWithValue("@Flag", "LoadReSales")
                    command.Parameters.AddWithValue("@EMPcode", fst)
                    command.Parameters.AddWithValue("@Months", tyear)
                    Dim adapter As New SqlDataAdapter(command)
                    Dim dtt As New DataTable()
                    adapter.Fill(dtt)
                    Return dtt
                End Using
            Catch ex As Exception
                ' Optionally log the error here
                Return Nothing
            End Try
        End Using
    End Function

    Public Function ReOpenEmployee(empId As String, revMonth As String) As Boolean
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Using command As New SqlCommand("PMS", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@Flag", "ReOpen")
                    command.Parameters.AddWithValue("@EMPcode", empId)
                    command.Parameters.AddWithValue("@Reviewmonth", revMonth)

                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Return rowsAffected > 0
                End Using
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function
End Class
