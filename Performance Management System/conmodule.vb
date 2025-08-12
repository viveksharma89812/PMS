Imports System.Data.SqlClient

Module conmodule
    'Public constr As String = "Data Source=10.90.50.67;Initial Catalog=HR_PMS_Web;User ID=sa;Password=maxxis@123"
    Public constr As String = "Data Source=10.90.1.11;Initial Catalog=HR_PMS_Web;User ID=sa;Password=incs@78;"
    'Public constr_con As String = "Data Source=10.90.117.10;Initial Catalog=HawkEyeEMSPlus_;User ID=sa;Password=incs@123"

    Dim sqlcon As SqlConnection
    Dim sqlcom As SqlCommand
    Dim sqladp As SqlDataAdapter
    Public ds As New DataSet
    Public sqlsdr As SqlDataReader
    Public errorMsg As String = ""

    'Public Function sqlselect(ByVal cn As String, ByVal query As String, ByVal tablename As String) As Boolean ' for select 
    '    sqlcon = Nothing
    '    sqladp = Nothing
    '    ds = Nothing
    '    Try
    '        If ds Is Nothing Then
    '            ds = New DataSet()
    '        ElseIf ds.Tables.Contains(tablename) Then
    '            ds.Tables.Remove(tablename)
    '        End If

    '        sqlcon = New SqlConnection(cn)
    '        sqlcon.Open()

    '        sqladp = New SqlDataAdapter(query, sqlcon)
    '        sqladp.Fill(ds, tablename)

    '        Return True
    '    Catch ex As Exception
    '        errorMsg = ex.Message
    '        Return False
    '    Finally
    '        If sqladp IsNot Nothing Then sqladp.Dispose()
    '        If sqlcon IsNot Nothing AndAlso sqlcon.State = ConnectionState.Open Then sqlcon.Close()
    '        If sqlcon IsNot Nothing Then sqlcon.Dispose()
    '    End Try
    'End Function

    Public Function sqlselect(ByVal cn As String, ByVal query As String, ByVal tablename As String) As Boolean

        sqlcon = Nothing
        sqladp = Nothing
        ds = Nothing

        Try
            ds = New DataSet()
            Using sqlcon = New SqlConnection(cn)
                sqlcon.Open()

                Using sqladp = New SqlDataAdapter(query, sqlcon)
                    If ds.Tables.Contains(tablename) Then
                        ds.Tables.Remove(tablename)
                    End If
                    sqladp.Fill(ds, tablename)
                End Using
            End Using

            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        End Try
    End Function

    'Public Function sqlselectmaster(ByVal cn As String, ByVal query As String, ByVal tablename As String) As Boolean ' for select 
    '    sqlcon = Nothing
    '    sqladp = Nothing
    '    ds = Nothing
    '    Try
    '        If ds Is Nothing Then
    '            ds = New DataSet()
    '        ElseIf ds.Tables.Contains(tablename) Then
    '            ds.Tables.Remove(tablename)
    '        End If

    '        sqlcon = New SqlConnection(cn)
    '        sqlcon.Open()

    '        sqladp = New SqlDataAdapter(query, sqlcon)
    '        sqladp.Fill(ds, tablename)

    '        Return True
    '    Catch ex As Exception
    '        errorMsg = ex.Message
    '        Return False
    '    Finally
    '        If sqladp IsNot Nothing Then sqladp.Dispose()
    '        If sqlcon IsNot Nothing AndAlso sqlcon.State = ConnectionState.Open Then sqlcon.Close()
    '        If sqlcon IsNot Nothing Then sqlcon.Dispose()
    '    End Try
    'End Function

    Public Function sqlselectmaster(ByVal cn As String, ByVal query As String, ByVal tablename As String) As Boolean
        ' Declare variables
        sqlcon = Nothing
        sqladp = Nothing
        ds = Nothing

        Try
            ds = New DataSet()
            Using sqlcon = New SqlConnection(cn)
                sqlcon.Open()
                Using sqladp = New SqlDataAdapter(query, sqlcon)
                    If ds.Tables.Contains(tablename) Then
                        ds.Tables.Remove(tablename)
                    End If

                    sqladp.Fill(ds, tablename)
                End Using
            End Using

            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        End Try
    End Function

    'Public Function sqlselect(ByVal cn As String, ByVal query As String, ByVal tablename As String) As Boolean ' for select 
    '    Try

    '        If ds.Tables.Contains(tablename) = True Then
    '            ds.Tables.Remove(tablename)
    '            ds.Tables.Add(tablename)
    '        Else
    '            ds.Tables.Add(tablename)
    '        End If
    '        sqlcon = New SqlConnection(cn)
    '        sqlcon.Open()
    '        sqladp = New SqlDataAdapter(query, sqlcon)
    '        sqladp.Fill(ds, tablename)
    '        sqladp.Dispose()
    '        sqlcon.Close()
    '        sqlselect = True

    '    Catch ex As Exception
    '        errorMsg = ex.Message
    '        If sqlcon.State = 1 Then sqlcon.Close()
    '        sqlselect = False
    '    Finally
    '        sqlcon.Close()
    '        sqlcon.Dispose()
    '    End Try
    'End Function

    'Public Function sqlexe(ByVal CN As String, ByVal query As String) As Boolean ' for update,insert,delete
    '    Try
    '        Using sqlCon = New SqlConnection(CN)
    '            sqlCon.Open()
    '            sqlcom = New SqlCommand(query, sqlCon)
    '            sqlcom.CommandTimeout = 500
    '            sqlcom.ExecuteNonQuery()
    '            sqlCon.Close()
    '        End Using
    '        sqlexe = True
    '    Catch ex As Exception
    '        errorMsg = ex.Message
    '        If sqlcon.State = 1 Then sqlcon.Close()
    '        sqlexe = False
    '    End Try

    'End Function

    Public Function sqlexe(ByVal CN As String, ByVal query As String) As Boolean
        Try
            Using sqlCon As New SqlConnection(CN)
                sqlCon.Open()
                Using sqlCom As New SqlCommand(query, sqlCon)
                    sqlCom.CommandTimeout = 500
                    sqlCom.ExecuteNonQuery()
                End Using
            End Using

            Return True
        Catch ex As Exception
            errorMsg = ex.Message
            Return False
        End Try
    End Function
    Public Function GetDepartmentSectionEmails(departmentName As String, sectionName As String) As DataTable
        Dim dt As New DataTable()

        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand("GetDepartmentSectionEmails", con)
                cmd.CommandType = CommandType.StoredProcedure

                ' Add parameters with DBNull if empty
                cmd.Parameters.AddWithValue("@DepartmentName", If(String.IsNullOrEmpty(departmentName), DBNull.Value, departmentName))
                cmd.Parameters.AddWithValue("@SectionName", If(String.IsNullOrEmpty(sectionName), DBNull.Value, sectionName))

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using

        Return dt
    End Function



End Module