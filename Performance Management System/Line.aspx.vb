Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web.UI
Imports System.Collections.Specialized
Imports System.Web
Imports OfficeOpenXml
Public Class Line
    Inherits System.Web.UI.Page
    Dim currentDate As DateTime = DateTime.Now
    Dim strsql As String
    ' Format the date as "M/d" where M is the month and d is the day
    Dim formattedDate As String = currentDate.ToString("MM/dd")
    Dim onedayprvious As String = DateTime.Now.AddDays(-1).ToString("MM/dd")

    Dim datee As String = currentDate.ToString("dd")
    Dim year As String = currentDate.ToString("yyyy")
    Dim month As String = currentDate.ToString("MM")
    Dim a As String
    Dim formattedDated As String = $"{datee}/{month}/{year}"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        onedayprvious = onedayprvious.Replace("-", "/")
        formattedDate = formattedDate.Replace("-", "/")
        Label1.Text = formattedDate
        Label2.Text = onedayprvious
        Label3.Text = onedayprvious
        Label4.Text = onedayprvious
        Label5.Text = onedayprvious
        Label6.Text = onedayprvious
        Label7.Text = onedayprvious
        Label8.Text = onedayprvious
        Label9.Text = onedayprvious
        btnsendline.Visible = False
        btnsendtoself.Visible = False
        btnsendline2.Visible = False

    End Sub

    Protected Sub Unnamed2_Click(sender As Object, e As EventArgs) Handles btnsendline.Click

        Dim Token As String = "UW5utrx5MDaYDmEiuVCyneg7F1tshIACmBjxsIc0Rgj"
        send(Token)

    End Sub

    Protected Sub Unnamed1_Click(sender As Object, e As EventArgs)

        If textbox1.Text <> "" And textbox2.Text <> "" And textbox3.Text <> "" And textbox4.Text <> "" And textbox5.Text <> "" And textbox6.Text <> "" And textbox7.Text <> "" And textbox8.Text <> "" And textbox9.Text <> "" And textbox10.Text <> "" And textbox11.Text <> "" And textbox12.Text <> "" And textbox13.Text <> "" And textbox14.Text <> "" And textbox15.Text <> "" And textbox16.Text <> "" And textbox17.Text <> "" And textbox18.Text <> "" And textbox19.Text <> "" And textbox20.Text <> "" And textbox21.Text <> "" And textbox22.Text <> "" And textbox23.Text <> "" And textbox24.Text <> "" And textbox25.Text <> "" And textbox26.Text <> "" Then

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal1", "$(document).ready(function () {$('#myModal1').modal();});", True)

        Else

            ShowAlertMessage("Some textbox are not filled.!")

        End If
    End Sub

    Protected Sub ShowAlertMessage(message As String)
        Dim script As String = "alert('" & message.Replace("'", "\'") & "');"
        ClientScript.RegisterStartupScript(Me.GetType(), "alert", script, True)
    End Sub

    Protected Sub btnconfirm_Click(sender As Object, e As EventArgs)

        Dim Password As String = "Allen@321"
        If Password = txtpass.Text Then
            btnsendline.Visible = True
            btnsendtoself.Visible = True
            btnsendline2.Visible = True
            txtpass.Text = ""
            ShowAlertMessage("Correct password..!")
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "HidePopup", "$('#myModal1').modal('hide')", True)
        Else
            ShowAlertMessage("Wrong password..!")

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal1", "$(document).ready(function () {$('#myModal1').modal();});", True)
        End If

    End Sub

    Protected Sub Unnamed3_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#myModal').modal();});", True)
    End Sub
    Protected Sub btncancel_click(sender As Object, e As EventArgs)
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "HidePopup", "$('#myModal1').modal('hide')", True)
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs)

        If txtname.Text <> "" And txtcode.Text <> "" Then

            Dim empdetails As String = $"Emp Name : {txtname.Text}  Emp Code :{txtcode.Text}"

            If CheckBox1.Checked = True Then
                strsql = $"update Tbl_Line set textbox1='{textbox1.Text}' ,textbox2='{textbox2.Text}',text1='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then

                End If
            End If

            If CheckBox2.Checked = True Then
                strsql = $"update Tbl_Line set textbox3='{textbox3.Text}' ,text2='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox3.Checked = True Then
                strsql = $"update Tbl_Line set textbox4='{textbox4.Text}' ,text3='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox4.Checked = True Then
                strsql = $"update Tbl_Line set textbox5='{textbox3.Text}' ,text4='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox5.Checked = True Then
                strsql = $"update Tbl_Line set textbox6='{textbox6.Text}' ,textbox7='{textbox7.Text}',text5='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox6.Checked = True Then
                strsql = $"update Tbl_Line set textbox8='{textbox8.Text}' ,textbox9='{textbox9.Text}',text6='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox7.Checked = True Then
                strsql = $"update Tbl_Line set textbox10='{textbox10.Text}' ,text7='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox8.Checked = True Then
                strsql = $"update Tbl_Line set textbox11='{textbox11.Text}' ,text8='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox9.Checked = True Then
                strsql = $"update Tbl_Line set textbox12='{textbox12.Text}' ,text9='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox10.Checked = True Then
                strsql = $"update Tbl_Line set textbox13='{textbox13.Text}' ,text10='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox11.Checked = True Then
                strsql = $"update Tbl_Line set textbox14='{textbox14.Text}' ,text11='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox12.Checked = True Then
                strsql = $"update Tbl_Line set textbox15='{textbox15.Text}' ,text12='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox13.Checked = True Then
                strsql = $"update Tbl_Line set textbox16='{textbox16.Text}' ,textbox17='{textbox17.Text}'  ,textbox18='{textbox18.Text}',text13='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox14.Checked = True Then
                strsql = $"update Tbl_Line set textbox19='{textbox19.Text}' ,textbox20='{textbox20.Text}'  ,textbox21='{textbox21.Text}',text14='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox15.Checked = True Then
                strsql = $"update Tbl_Line set textbox22=N'{textbox22.Text}',textbox23=N'{textbox23.Text}' ,text15='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox16.Checked = True Then
                strsql = $"update Tbl_Line set textbox24=N'{textbox24.Text}',textbox25=N'{textbox25.Text}' ,text16='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox18.Checked = True Then
                strsql = $"update Tbl_Line set textbox27=N'{textbox27.Text}',textbox28=N'{textbox28.Text}' ,text18='{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If

            If CheckBox17.Checked = True Then
                strsql = $"update Tbl_Line set textbox26=N'{textbox26.Text}' ,text17=N'{empdetails}' where date='{formattedDated}'"
                If sqlexe(constr, strsql) Then
                End If
            End If
            txtcode.Text = ""
            txtname.Text = ""
            check()
            show()
            ShowAlertMessage("Submit Sucecessfully....!")
        Else
            ShowAlertMessage("Please fill your Employee code and Name!")
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$(document).ready(function () {$('#myModal').modal();});", True)

        End If
    End Sub
    Protected Sub btncancel1_click(sender As Object, e As EventArgs)
        check()
        txtcode.Text = ""
        txtname.Text = ""
        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "HidePopup", "$('#myModal').modal('hide')", True)
    End Sub

    Protected Sub Unnamed6_Click(sender As Object, e As EventArgs) Handles Button5.Click
        show()
    End Sub

    Public Sub show()
        strsql = $"select * from Tbl_Line where date='{formattedDated}'"


        If sqlselect(constr, strsql, "Userdata") Then
            If ds.Tables("Userdata").Rows.Count > 0 Then
                textbox1.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox1"))
                textbox2.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox2"))
                textbox3.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox3"))
                textbox4.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox4"))
                textbox5.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox5"))
                textbox6.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox6"))
                textbox7.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox7"))
                textbox8.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox8"))
                textbox9.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox9"))
                textbox10.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox10"))
                textbox11.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox11"))
                textbox12.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox12"))
                textbox13.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox13"))
                textbox14.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox14"))
                textbox15.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox15"))
                textbox16.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox16"))
                textbox17.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox17"))
                textbox18.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox18"))
                textbox19.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox19"))
                textbox20.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox20"))
                textbox21.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox21"))
                textbox22.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox22"))
                textbox23.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox23"))
                textbox24.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox24"))
                textbox25.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox25"))
                textbox26.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox26"))
                textbox27.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox27"))
                textbox28.Text = Convert.ToString(ds.Tables("Userdata").Rows(0)("textbox28"))
            Else
                strsql = $"INSERT INTO Tbl_Line (Date) VALUES ('{formattedDated}')"
                If sqlexe(constr, strsql) Then
                End If
            End If
        End If
    End Sub

    Protected Sub Unnamed112_Click(sender As Object, e As EventArgs) Handles btnsendtoself.Click
        'first
        Dim Token As String = "3xtpOTCoDSkiiglRIuzCEoTR5JYJKGb3wN4VMn8Q2DX"
        send(Token)
    End Sub

    Public Sub check()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False
        CheckBox12.Checked = False
        CheckBox13.Checked = False
        CheckBox14.Checked = False
        CheckBox15.Checked = False
        CheckBox16.Checked = False
        CheckBox17.Checked = False
        CheckBox18.Checked = False
    End Sub

    Protected Sub Unnamedg2_Click(sender As Object, e As EventArgs) Handles btnsendline2.Click
        ' third
        Dim Token As String = "UW5utrx5MDaYDmEiuVCyneg7F1tshIACmBjxsIc0Rgj"
        send(Token)
    End Sub


    Public Sub send(Token As String)
        Try

            formattedDate = formattedDate.Replace("-", "/")
            onedayprvious = onedayprvious.Replace("-", "/")
            Dim xyz As String = $"{formattedDate}印度廠日報告:" & vbCrLf &
                $"昨日出席出勤 {textbox1.Text}人/總人數 {textbox2.Text}人" & vbCrLf & vbCrLf &
    $"一.本日外包商件數:" & vbCrLf &
    $"1.一般作業: {textbox3.Text}件" & vbCrLf &
    $"2.明火作業: {textbox4.Text}件" & vbCrLf &
    $"3.高空作業: {textbox5.Text}件" & vbCrLf & vbCrLf &
    $"二.{onedayprvious}生產簡報:" & vbCrLf &
    $"1.成型: {textbox6.Text}條;達成率: {textbox7.Text}%" & vbCrLf &
    $"2.加硫: {textbox8.Text}條;達成率: {textbox9.Text}%" & vbCrLf &
    $"3.成品廢品不良率: {textbox10.Text}%" & vbCrLf &
    $"4.成品首次合格率: {textbox11.Text}%" & vbCrLf & vbCrLf &
    $"三.{onedayprvious}成品出貨:" & vbCrLf &
    $"1.累計內銷出貨量: {textbox12.Text}條" & vbCrLf &
    $"2.累計外銷出貨量: {textbox13.Text}條" & vbCrLf &
    $"3.截至昨日成品庫存量: {textbox14.Text}條" & vbCrLf &
    $"4.截至昨日原材料（膠料）庫存量：{textbox15.Text}噸" & vbCrLf & vbCrLf &
    $"四.{onedayprvious}混煉廠生產簡報:" & vbCrLf &
    $"1.開機台數 {textbox16.Text}台/總台數 {textbox17.Text}台/稼動率: {textbox18.Text}%" & vbCrLf &
    $"2.生產量 {textbox19.Text}手/設備產能 {textbox20.Text}手/稼動率: {textbox21.Text}%" & vbCrLf & vbCrLf &
    $"五.{onedayprvious}生產TOC:" & vbCrLf &
    $"1.描述: {textbox22.Text}/對策: {textbox23.Text}" & vbCrLf &
    $"2.描述: {textbox24.Text}/對策: {textbox25.Text}" & vbCrLf &
    $"3.描述: {textbox27.Text}/對策: {textbox28.Text}" & vbCrLf & vbCrLf &
    $"六.廠長自廠管理檢視重要報告:" & vbCrLf &
    $"1.描述: {textbox26.Text}"

            Using client As New WebClient()
                client.Headers.Add("Authorization", "Bearer " & Token)
                Dim values As New NameValueCollection()
                values("message") = xyz
                Dim response As Byte() = client.UploadValues("https://notify-api.line.me/api/notify", values)
                Dim responseString As String = System.Text.Encoding.Default.GetString(response)
                Console.WriteLine("Response: " & responseString)

            End Using

            ShowAlertMessage("Line Notify send successfully....!")
            btnsendline.Visible = True
            btnsendtoself.Visible = True
            btnsendline2.Visible = True
        Catch ex As Exception
            ShowAlertMessage("Line Notify send successfully not....!")
        End Try
    End Sub

End Class