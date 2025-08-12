Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting
Imports System.Web.UI.DataVisualization.Charting.DataPointCollection

Public Class WebForm19
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access power") = "" Then
            Response.Redirect("login.aspx")
        End If
        If Not IsPostBack Then
            strsql = "select dept_name,dept_id from Department"
            If sqlselect(constr, strsql, "Abc") Then

                Dim x As String() = New String(ds.Tables("Abc").Rows.Count - 1) {}
                Dim y As Integer() = New Integer(ds.Tables("Abc").Rows.Count - 1) {}
                For i As Integer = 0 To ds.Tables("Abc").Rows.Count - 1
                    x(i) = ds.Tables("Abc").Rows(i)(0).ToString()
                    y(i) = Convert.ToInt32(ds.Tables("Abc").Rows(i)(1))
                Next
                Chart1.Series(0).Points.DataBindXY(x, y)
            End If

            'Dim dt As New DataTable()
            'Using con As New SqlConnection("Data Source=SureshDasari;Integrated Security=true;Initial Catalog=MySampleDB")
            '    con.Open()
            '    Dim cmd As New SqlCommand("select name,total=value from countrydetails order by total desc", con)
            '    Dim da As New SqlDataAdapter(cmd)
            '    da.Fill(dt)
            '    con.Close()
            'End Using
            'Dim x As String() = New String(dt.Rows.Count - 1) {}
            'Dim y As Integer() = New Integer(dt.Rows.Count - 1) {}
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    x(i) = dt.Rows(i)(0).ToString()
            '    y(i) = Convert.ToInt32(dt.Rows(i)(1))
            'Next
            'Chart1.Series(0).Points.DataBindXY(x, y)
        End If
    End Sub

End Class