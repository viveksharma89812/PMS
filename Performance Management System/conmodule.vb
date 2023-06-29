Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports System.String

Module conmodule
    Public constr As String = "Data Source=10.90.50.67;Initial Catalog=HR_PMS_Web;User ID=sa;Password=maxxis@123"
    'Public constr_con As String = "Data Source=10.90.117.10;Initial Catalog=HawkEyeEMSPlus_;User ID=sa;Password=incs@123"

    Dim sqlcon As SqlConnection
    Dim sqlcom As SqlCommand
    Dim sqladp As SqlDataAdapter
    Public ds As New DataSet
    Public sqlsdr As SqlDataReader
    Public errorMsg As String = ""

    'Public Function sqltable(ByVal cn As String, ByVal query As String) As Boolean
    '    Try
    '        Using sqlCon = New SqlConnection(cn)
    '            sqlCon.Open()
    '            sqlcom = New SqlCommand(query, sqlCon)
    '            sqlcom.ExecuteNonQuery()
    '            sqlsdr = sqlcom.ExecuteReader()
    '            sqlCon.Close()
    '        End Using
    '        sqltable = True
    '    Catch ex As Exception
    '        If sqlcon.State = 1 Then sqlcon.Close()
    '        sqltable = False
    '    End Try
    'End Function
    Public Function sqlselect(ByVal cn As String, ByVal query As String, ByVal tablename As String) As Boolean ' for select 
        Try
            If ds.Tables.Contains(tablename) Then
                ds.Tables.Remove(tablename)
            End If
            ds.Tables.Add(tablename)
            sqlcon = New SqlConnection(cn)
            sqlcon.Open()
            sqladp = New SqlDataAdapter(query, sqlcon)
            sqladp.Fill(ds, tablename)
            sqlcon.Close()
            sqlselect = True
        Catch ex As Exception
            errorMsg = ex.Message
            If sqlcon.State = 1 Then sqlcon.Close()
            sqlselect = False
        End Try
    End Function

    Public Function sqlexe(ByVal CN As String, ByVal query As String) As Boolean ' for update,insert,delete
        Try
            Using sqlCon = New SqlConnection(CN)
                sqlCon.Open()
                sqlcom = New SqlCommand(query, sqlCon)
                sqlcom.ExecuteNonQuery()
                sqlCon.Close()
            End Using
            sqlexe = True
        Catch ex As Exception
            errorMsg = ex.Message
            ' MsgBox(errorMsg)
            If sqlcon.State = 1 Then sqlcon.Close()
            sqlexe = False
        End Try
    End Function

End Module