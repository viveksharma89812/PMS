Imports System.Data
Imports System.Configuration
Imports System.String
Imports System.Data.SqlClient
Public Class WebForm1
    Inherits System.Web.UI.Page
    Dim strsql As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Label9.Text = ""
        If IsPostBack Then
            Dim password As String = pass.Text
            pass.Attributes.Add("value", password)
            password = confirmpass.Text
            confirmpass.Attributes.Add("value", password)
        End If

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        strsql = "select EmployeeName,EmployeeCode,Department,Section,Reg from Employee_Master1 where EmployeeCode='" & empcode.Text & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Dim name As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                Dim employeecode As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeCode"))
                Dim Depart As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                Dim sec As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                Dim reg As String = Convert.ToString(ds.Tables(0).Rows(0)("Reg"))
                Session("User name") = name
                Session("emplcode") = employeecode
                Session("dept") = Depart
                Session("sect") = sec
                Session("reg") = reg
                checkdetail()
            End If

        End If

    End Sub
    Private Sub clear()
        empcode.Text = ""
        empname.Text = ""
        dept.Text = ""
        section.Text = ""
        pass.Text = ""
        confirmpass.Text = ""
        Dim password As String = pass.Text
        pass.Attributes.Add("value", "")
    End Sub

    Private Sub checkdetail()

        'If Session("User name") <> empname.Text Then
        '    MsgBox("incorrect lname")
        '    clear()
        'ElseIf Session("emplcode") <> empcode.Text Then
        '    MsgBox("incorrect empname")
        '    clear()
        'ElseIf Session("dept") <> dept.Text Then
        '    MsgBox("incorrect dept")
        '    clear()
        'ElseIf Session("sect") <> section.Text Then
        '    MsgBox("incorrect sect")
        '    clear()
        If pass.Text <> confirmpass.Text Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Password and Confirm Password in not same');window.location = '" + Request.RawUrl + "';", True)
            'Label9.Text = "Password and Confirm Password in not same"
            'confirmpass.Text = ""
        Else
            insert()
            clear()
        End If
    End Sub
    Private Sub insert()
        strsql = "Update Employee_Master1 set Password='" & pass.Text & "',Reg='True' where EmployeeCode='" & empcode.Text & "' "
        If Session("reg") = "False" Then
            If sqlexe(constr, strsql) Then
                'Label9.Visible = "true"
                'Label9.Text = "Inserted successfully"
                Session.RemoveAll()
                Response.Redirect("Login.aspx")
            End If
        Else
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your EmployeeID'+''+'" & Session("emplcode") & "'+'already Registered');window.location = '" + Request.RawUrl + "';", True)
            'Label9.Visible = "true"
            'Label9.Text = "Your EmployeeID" + " , " + Session("emplcode") + " " + "already Registered"
        End If
    End Sub

    Protected Sub empcode_TextChanged(sender As Object, e As EventArgs) Handles empcode.TextChanged
        strsql = "select EmployeeName,Department,Section from Employee_Master1 where EmployeeCode='" & empcode.Text & "'"
        If sqlselect(constr, strsql, "Abc") Then
            If ds.Tables("Abc").Rows.Count > 0 Then
                Dim name As String = Convert.ToString(ds.Tables(0).Rows(0)("EmployeeName"))
                Dim Depart As String = Convert.ToString(ds.Tables(0).Rows(0)("Department"))
                Dim sec As String = Convert.ToString(ds.Tables(0).Rows(0)("Section"))
                Session("name") = name
                Session("department") = Depart
                Session("section") = sec
                empname.Text = Session("name")
                dept.Text = Session("department")
                section.Text = Session("section")
                If IsPostBack Then
                    Dim password As String = pass.Text
                    pass.Attributes.Add("value", "")
                End If
            Else
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Messagebox", "alert('Your Detail is not correct');window.location = '" + Request.RawUrl + "';", True)
            End If

        End If
    End Sub

    ''Protected Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
    ''    If CheckBox1.Checked = "True" Then
    ''        pass.TextMode = TextBoxMode.SingleLine
    ''    ElseIf CheckBox1.Checked = "False" Then
    ''        pass.TextMode = TextBoxMode.Password
    ''    End If
    ''    If CheckBox1.Checked = "True" Then
    ''        confirmpass.TextMode = TextBoxMode.SingleLine
    ''    ElseIf CheckBox1.Checked = "False" Then
    ''        confirmpass.TextMode = TextBoxMode.Password
    ''    End If
    'End Sub


    'Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
    '    Session.Abandon()
    '    Session.Clear()
    '    Session.RemoveAll()
    '    Session.Remove("emp code")
    '    Session.Remove("User name")
    '    Response.Redirect("login.aspx")
    'End Sub

    'Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
    '    Session.RemoveAll()
    'End Sub
End Class