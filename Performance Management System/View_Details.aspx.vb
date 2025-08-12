Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing


Public Class WebForm5
    Inherits System.Web.UI.Page
    Dim strsql As String
    Dim strsql2 As String
    Dim year As String = DateTime.Now.Year
    Dim mon As String = DateTime.Now.AddMonths("-1").ToString("MM")
    Dim PMSclass As New PMSClass()
    Dim emp As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("access power") = "" Then
            Response.Redirect("login.aspx")
        End If

        Dim dt As DataTable = PMSClass.checkimage(Session("emp code").ToString())
        Session("access powersss") = ""
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim IMG As String = dt.Rows(0)("Images").ToString()
            If IMG <> "" Then
                outerimgdiv.Visible = False
            Else
                Session("access powersss") = "ok"
                outerimgdiv.Visible = True
            End If

        End If

        fill()

        If mon = "12" Then
            year = DateTime.Now.AddYears(-1).ToString("yyyy")
        End If
        year = "[" + year + "]"
        emp = Session("emp code").ToString

        strsql = "select * from dbo." & year & " where EmployeeCode='" & Session("emp code") & "' and Month='" & mon & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Dim empaccept As String = Convert.ToString(ds.Tables(0).Rows(0)("Emp_Accept"))
                Dim formstat As String = Convert.ToString(ds.Tables(0).Rows(0)("Form_Status"))

                If formstat <> "PENDING" Then

                    If empaccept <> "" Then
                        revform.Visible = False
                    End If
                Else
                    revform.Visible = False
                End If
            End If
        End If



    End Sub

    <System.Web.Services.WebMethod()>
    Public Shared Function SaveCapturedImage(ByVal data As String) As Boolean
        Try

            Dim empcode As String = CType(HttpContext.Current.Session("emp code"), String)
            Dim yea As String = DateTime.Now.Year
            Dim picnames As String = empcode
            Dim fileName As String = picnames
            Dim imageBytes() As Byte = Convert.FromBase64String(data.Split(","c)(1))
            Dim filePath As String = HttpContext.Current.Server.MapPath("~/Captures/" & fileName & ".jpg")
            Dim dirPath As String = Path.GetDirectoryName(filePath)
            If Not Directory.Exists(dirPath) Then
                Directory.CreateDirectory(dirPath)
            End If
            File.WriteAllBytes(filePath, imageBytes)
            Dim strsql As String = $"UPdate Employee_Master1 set Images='{empcode}' where EmployeeCode='{empcode}'"
            If sqlexe(constr, strsql) Then
            End If
        Catch ex As Exception
        End Try
        Return True
    End Function

    Private Sub bind()
        strsql = "select EmployeeCode,EmployeeName,Designation,Department,Section,DOJ,DOP,DOC,DOE,Qualification,PreviousExperience,ReportingPersonName,Review_Period from Employee_Master1 where EmployeeCode='" & Session("emp code") & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                empcode.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                empname.Text = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                desig.Text = Convert.ToString(ds.Tables(0).Rows(0)("Designation"))
                dept.Text = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                sect.Text = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                doj.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOJ"))
                dop.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOP"))
                doc.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOC"))
                doe.Text = Convert.ToString(ds.Tables(0).Rows(0)("DOE"))
                quali.Text = Convert.ToString(ds.Tables(0).Rows(0)("Qualification"))
                preexp.Text = Convert.ToString(ds.Tables(0).Rows(0)("PreviousExperience"))
                repperson.Text = Convert.ToString(ds.Tables(0).Rows(0)("ReportingPersonName"))
                review.Text = Convert.ToString(ds.Tables(0).Rows(0)("Review_Period"))
            End If

        End If
    End Sub

    Private Sub fill()
        strsql = "select * from FileUpload where EmployeeCode='" & Session("emp code") & "'"
        Dim filePaths() As String = Directory.GetFiles(Server.MapPath("~/DocFile/"))
        Dim files As List(Of ListItem) = New List(Of ListItem)
        For Each filePath As String In filePaths
            files.Add(New ListItem(Path.GetFileName(filePath), filePath))
        Next

    End Sub
    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "download" Then

                Dim strpath As String = Server.MapPath("~/DocFile/") + e.CommandArgument
                If e.CommandArgument <> "" Then
                    If File.Exists(strpath) Then

                        Dim cph As ContentPlaceHolder = Me.Master.FindControl("ContentPlaceHolder1")
                        Dim MyFrame As HtmlControl = cph.FindControl("urlframe")
                        Dim FileExtension = System.IO.Path.GetExtension(e.CommandArgument)
                        MyFrame.Attributes("src") = "DocFile\" + e.CommandArgument + "#toolbar=1"
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal1", "$(document).ready(function () {$('#myModal1').modal();});", True)
                    Else
                        Response.Write("<script> alert('File Not Found');window.close(); </script>")
                    End If
                End If
            End If

        Catch ex As Exception
            Response.Write("<script language='javascript'>alert('" + Server.HtmlEncode(ex.Message) + "')</script>")
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        bind()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#myModal').modal();});", True)

    End Sub
    Protected Sub revform_Click(sender As Object, e As EventArgs) Handles revform.Click
        Dim year As String = DateTime.Now.Year
        Dim mon As String = DateTime.Now.AddMonths("-1").ToString("MM")
        If mon = "12" Then
            year = DateTime.Now.AddYears(-1).ToString("yyyy")
        End If
        strsql = "select * from dbo.[" & year & "] where EmployeeCode='" & Session("emp code") & "' and Month='" & mon & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Session("form empid") = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                Dim formid As String = Convert.ToString(ds.Tables(0).Rows(0)("Form_ID"))
                If formid = "1" Then
                    Response.Redirect("0364.aspx", False)
                ElseIf formid = "2" Then
                    Response.Redirect("0365.aspx", False)
                ElseIf formid = "3" Then
                    Response.Redirect("0386.aspx", False)
                ElseIf formid = "4" Then
                    Response.Redirect("0475.aspx", False)
                ElseIf formid = "5" Then
                    Response.Redirect("0386M5.aspx", False)
                ElseIf formid = "6" Then
                    Response.Redirect("0386CO1.aspx", False)
                ElseIf formid = "7" Then
                    Response.Redirect("0386CO2.aspx", False)
                ElseIf formid = "8" Then
                    Response.Redirect("0386EO1.aspx", False)
                ElseIf formid = "9" Then
                    Response.Redirect("0386CUO1.aspx", False)
                ElseIf formid = "10" Then
                    Response.Redirect("0386TBO1.aspx", False)
                ElseIf formid = "11" Then
                    Response.Redirect("0386TSPO2.aspx", False)
                ElseIf formid = "12" Then
                    Response.Redirect("0386TRON03.aspx", False)
                ElseIf formid = "13" Then
                    Response.Redirect("0386TSO4.aspx", False)
                ElseIf formid = "14" Then
                    Response.Redirect("0386QVO1.aspx", False)
                ElseIf formid = "15" Then
                    Response.Redirect("0386QDO2.aspx", False)
                ElseIf formid = "16" Then
                    Response.Redirect("0386QSTO3.aspx", False)
                ElseIf formid = "17" Then
                    Response.Redirect("0386QPO4.aspx", False)
                ElseIf formid = "18" Then
                    Response.Redirect("0386R1.aspx", False)
                ElseIf formid = "19" Then
                    Response.Redirect("0386MO1.aspx", False)
                ElseIf formid = "20" Then
                    Response.Redirect("0386ME1.aspx", False)
                ElseIf formid = "21" Then
                    Response.Redirect("0386MR1.aspx", False)
                ElseIf formid = "22" Then
                    Response.Redirect("0386UE1.aspx", False)
                ElseIf formid = "23" Then
                    Response.Redirect("0386UO1.aspx", False)
                ElseIf formid = "24" Then
                    Response.Redirect("0386EHS.aspx", False)
                ElseIf formid = "25" Then
                    Response.Redirect("0386EC1.aspx", False)
                ElseIf formid = "26" Then
                    Response.Redirect("0386_Chef.aspx", False)
                ElseIf formid = "27" Then
                    Response.Redirect("0364_Planning.aspx", False)
                ElseIf formid = "28" Then
                    Response.Redirect("0365_Planning.aspx", False)
                ElseIf formid = "29" Then
                    Response.Redirect("0366_Planning.aspx", False)
                ElseIf formid = "30" Then
                    Response.Redirect("0367_Planning.aspx", False)
                ElseIf formid = "31" Then
                    Response.Redirect("0386TL1.aspx", False)
                ElseIf formid = "32" Then
                    Response.Redirect("0386TA1.aspx", False)
                ElseIf formid = "33" Then
                    Response.Redirect("0386TL2.aspx", False)
                ElseIf formid = "34" Then
                    Response.Redirect("0386TAL3.aspx", False)
                ElseIf formid = "35" Then
                    Response.Redirect("0386M1.aspx", False)
                ElseIf formid = "36" Then
                    Response.Redirect("0386M4.aspx", False)
                ElseIf formid = "37" Then
                    Response.Redirect("0386M2.aspx", False)
                ElseIf formid = "38" Then
                    Response.Redirect("0386M3.aspx", False)
                ElseIf formid = "39" Then
                    Response.Redirect("0386P1.aspx", False)
                ElseIf formid = "40" Then
                    Response.Redirect("0386QPO5.aspx", False)
                ElseIf formid = "41" Then
                    Response.Redirect("0364.aspx", False)
                ElseIf formid = "42" Then
                    Response.Redirect("0386HCWO1.aspx", False)
                ElseIf formid = "43" Then
                    Response.Redirect("0386WHO1.aspx", False)
                ElseIf formid = "44" Then
                    Response.Redirect("0364_Planning.aspx", False)
                ElseIf formid = "66" Then
                    Response.Redirect("0366GAORPS.aspx", False)
                ElseIf formid = "81" Then
                    Response.Redirect("0386CL1.aspx", False)
                ElseIf formid = "47" Then
                    Response.Redirect("0386CS1.aspx", False)
                ElseIf formid = "45" Then
                    Response.Redirect("0386CST1.aspx", False)
                ElseIf formid = "48" Then
                    Response.Redirect("0386CL2.aspx", False)
                ElseIf formid = "49" Then
                    Response.Redirect("0386CNC2.aspx", False)
                ElseIf formid = "50" Then
                    Response.Redirect("0386EL1.aspx", False)
                ElseIf formid = "41" Then
                    Response.Redirect("0386EOS1.aspx", False)
                ElseIf formid = "49" Then
                    Response.Redirect("0386CNC2.aspx", False)
                ElseIf formid = "71" Then
                    Response.Redirect("0386ES1.aspx", False)
                ElseIf formid = "50" Then
                    Response.Redirect("0386EL1.aspx", False)
                ElseIf formid = "51" Then
                    Response.Redirect("0386EOS1.aspx", False)
                ElseIf formid = "52" Then
                    Response.Redirect("0386TL2.aspx", False)
                ElseIf formid = "54" Then
                    Response.Redirect("0386TA1.aspx", False)
                ElseIf formid = "53" Then
                    Response.Redirect("0386TL1.aspx", False)
                ElseIf formid = "55" Then
                    Response.Redirect("0386CA1.aspx", False)
                ElseIf formid = "56" Then
                    Response.Redirect("0386CUL1.aspx", False)
                ElseIf formid = "57" Then
                    Response.Redirect("0386ER2.aspx", False)
                ElseIf formid = "58" Then
                    Response.Redirect("0386EM2.aspx", False)
                ElseIf formid = "59" Then
                    Response.Redirect("0386WIOL1.aspx", False)
                ElseIf formid = "60" Then
                    Response.Redirect("0386WPL1.aspx", False)
                ElseIf formid = "61" Then
                    Response.Redirect("0386QCL1.aspx", False)
                ElseIf formid = "62" Then
                    Response.Redirect("0386QIL2.aspx", False)
                ElseIf formid = "63" Then
                    Response.Redirect("0386QPS2.aspx", False)
                ElseIf formid = "64" Then
                    Response.Redirect("0386QDC1.aspx", False)
                ElseIf formid = "65" Then
                    Response.Redirect("0386QPL2.aspx", False)
                ElseIf formid = "72" Then
                    Response.Redirect("0386S1.aspx", False)
                ElseIf formid = "73" Then
                    Response.Redirect("0386S2.aspx", False)
                ElseIf formid = "74" Then
                    Response.Redirect("0386S3.aspx", False)
                ElseIf formid = "75" Then
                    Response.Redirect("0386S4.aspx", False)
                ElseIf formid = "76" Then
                    Response.Redirect("0386S5.aspx", False)
                ElseIf formid = "77" Then
                    Response.Redirect("0364PS1.aspx", False)
                ElseIf formid = "78" Then
                    Response.Redirect("0364PS3.aspx", False)
                ElseIf formid = "79" Then
                    Response.Redirect("0364PS2.aspx", False)
                ElseIf formid = "46" Then
                    Response.Redirect("0364FIO1.aspx", False)
                ElseIf formid = "82" Then
                    Response.Redirect("Utility2or3.aspx", False)
                ElseIf formid = "83" Then
                    Response.Redirect("Maintenannce2or3.aspx", False)
                ElseIf formid = "84" Then
                    Response.Redirect("Cheff.aspx", False)
                ElseIf formid = "85" Then
                    Response.Redirect("Finance_Accounting_Payable_New.aspx", False)
                ElseIf formid = "86" Then
                    Response.Redirect("Costing_New.aspx", False)
                ElseIf formid = "87" Then
                    Response.Redirect("Tax_New.aspx", False)
                ElseIf formid = "88" Then
                    Response.Redirect("Banking_New.aspx", False)
                ElseIf formid = "89" Then
                    Response.Redirect("Auditing_New.aspx", False)
                ElseIf formid = "91" Then
                    Response.Redirect("Final_Review_New.aspx", False)
                ElseIf formid = "90" Then
                    Response.Redirect("Finance_Accounting_Receivable_New.aspx", False)
                ElseIf formid = "92" Then
                    Response.Redirect("ReSales.aspx", False)
                ElseIf formid = "93" Then
                    Response.Redirect("ReSalesStaff.aspx", False)
                End If

            End If

            End If

    End Sub
End Class