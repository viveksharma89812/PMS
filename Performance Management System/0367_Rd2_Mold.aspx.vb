Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Path
Imports iTextSharp.text
Imports iTextSharp.text.html.simpleparser
Imports iTextSharp.text.pdf
Imports System.Drawing
Imports System.Drawing.Imaging
Public Class WebForm31
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim tot As String

    Dim mon As String
    Dim tyear As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("access power") = "" Then
                Response.Redirect("login.aspx")
            End If
            If IsPostBack Then
                result()
            End If

            strsql = "select * from Employee_Master where EmployeeCode='" & Session("empl code") & "'"
            If sqlselect(constr, strsql, "Abc") Then
                empcode.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                desc.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                Dim dept As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                Dim sect As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                doj.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                deptsect.Text = dept + "/" + sect

                Dim revperiod As String = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
                revperiod = revperiod.Trim()
                If revperiod = "Training" Then
                    ID1.Checked = True
                Else
                    ID2.Checked = True
                End If
            Else
                Label4.Visible = "true"
                Label4.Text = "Your detail not insereted "
            End If


            mon = DateTime.Now.AddMonths(-1).ToString("MMM")

            Dim yea As String = DateTime.Now.Year
            tyear = DateTime.Now.ToString("yy")
            If mon = "Dec" Then
                yea = DateTime.Now.AddYears(-1).ToString("yyyy")
                tyear = DateTime.Now.AddYears(-1).ToString("yy")
            End If


            tyear = mon + "-" + tyear
            tot = yea
            tot = "[dbo]" + ". " + "[" + tot + "]"

            strsql = "select * from" + " " + tot + " " + "where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlselect(constr, strsql, "Abc") Then
                Dim cl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("CL"))
                Dim sl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("SL"))
                Dim pl As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("PL"))
                Dim lwp As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("LWP"))
                Dim actwor As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("ActualWorkingDays"))
                Dim actpre As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("ActualPresentDays"))
                Dim abs As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("AbsentDays"))
                Dim leaves As Decimal = Convert.ToString(ds.Tables(0).Rows(0)("LeavesScores"))
                revmonth.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReviewMonth"))
                cla.Text = cl
                sla.Text = sl
                pla.Text = pl
                lwpa.Text = lwp
                actworking.Text = actwor
                actpresent.Text = actpre
                absentdays.Text = abs
                score.Text = leaves
            End If
        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")

        End Try
    End Sub
    Private Sub result()
        Dim Tot, Tot1, Tot2, Tot3, Gtot As Double
        Tot1 = Double.Parse(score1.SelectedIndex)
        If score1.SelectedIndex = "0" Then
            Tot1 = "20"
        ElseIf score1.SelectedIndex = "1" Then
            Tot1 = "15"
        ElseIf score1.SelectedIndex = "2" Then
            Tot1 = "10"
        ElseIf score1.SelectedIndex = "3" Then
            Tot1 = "5"
        ElseIf score1.SelectedIndex = "4" Then
            Tot1 = "0"
        End If
        Tot = Double.Parse(score.Text)
        If score2.Text <> "" Then
            Tot2 = Double.Parse(score2.Text)
        End If
        If score3.Text <> "" Then
            Tot3 = Double.Parse(score3.Text)
        End If
        Gtot = Tot + Tot1 + Tot2 + Tot3
        If score.Text <> "" And score2.Text <> "" And score3.Text <> "" Then
            totscore.InnerText = Gtot.ToString
        End If

    End Sub
    Protected Sub insert_Click(sender As Object, e As EventArgs) Handles insert.Click
        Try
            Dim marks As String = score1.SelectedIndex
            If score1.SelectedIndex = "0" Then
                marks = "20"
            ElseIf score1.SelectedIndex = "1" Then
                marks = "15"
            ElseIf score1.SelectedIndex = "2" Then
                marks = "10"
            ElseIf score1.SelectedIndex = "3" Then
                marks = "5"
            ElseIf score1.SelectedIndex = "4" Then
                marks = "0"
            End If
            Dim status As String = ""
            If pass.Checked = True Then
                status = "Pass"
            ElseIf extend.Checked = "true" Then
                status = "Extend"
            ElseIf fail.Checked = True Then
                status = "Fail"
            End If
            strsql = "update" + " " + tot + " " + "set Score1='" & marks & "',Score2='" & score2.Text & "',Score3='" & score3.Text & "',TotalMarks='" & totscore.InnerText & "',Remark='" & remark.Text & "',Status='" & status & "',Form_Status='DONE',Form_ID='15' where EmployeeCode='" & Session("empl code") & "' and ReviewMonth='" & tyear & "'"
            If sqlexe(constr, strsql) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Inserted successfully');window.close()", True)
            End If

        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    Protected Sub c4_CheckedChanged(sender As Object, e As EventArgs) Handles c4.CheckedChanged
        strsql = "update" + " " + tot + " " + "Set Emp_Accept='Done' where EmployeeCode='" & Session("form empid") & "' and ReviewMonth='" & tyear & "'"
        If sqlexe(constr, strsql) Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Submitted successfully');window.close()", True)
        End If
    End Sub
End Class