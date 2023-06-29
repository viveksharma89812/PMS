<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0399.aspx.vb" Inherits="Performance_Management_System.WebForm17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            height: 22px;
        }
        .auto-style6 {
            height: 40px;
        }
         table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style9 {
            width: 14%;
        }
        .auto-style11 {
            height: 22px;
            width: 10%;
        }
        .auto-style14 {
            width: 1074px;
        }
        .auto-style15 {
            width: 8%;
        }
        .auto-style16 {
            width: 10%;
        }
        .auto-style17 {
            width: 126px;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><Triggers><asp:PostBackTrigger ControlID="Button2" /></Triggers><ContentTemplate>
    <br />

    <%--<asp:TextBox ID="TextBox8" runat="server" AutoPostBack="True"></asp:TextBox>--%>
    &nbsp;<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <br />
  <center>  <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid"  Width="900px" BackColor="#ffffff">
        <table class="auto-style4" border="1">
            <tr>
                <td colspan="14" style="font-size: large; font-style: oblique; font-weight:bold "><center>Permanent Period Review Form (For Operator) 正式期評核表(作業人員)</center></td>
            </tr>
            <tr>
                <td colspan="14" style="font-weight:bold"><center>A. Employee Information (by HR)</center></td>
            </tr>
            <tr>
                <td colspan="6">Employee Name</td>
                <td class="auto-style15">
                    <asp:Label ID="empname" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="3">Employee Code</td>
                <td class="auto-style16">
                    <asp:Label ID="empcode" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="2">Designation</td>
                <td class="auto-style9">
                    <asp:Label ID="desc" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">Dept./ Sec.</td>
                <td class="auto-style15">
                    <asp:Label ID="deptsect" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="3">DOJ</td>
                <td class="auto-style16">
                    <asp:Label ID="doja" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="2">Review Month </td>
                <td class="auto-style9">
                    <asp:Label ID="rev" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="font-weight:bold"><center>B. Attendance Detail (by HR)</center></td>
                <td colspan="8" style="font-weight:bold">
                    <center>
                        C. Performance Review (To be filled by the Appraiser)</center>
                </td>
            </tr>
            <tr>
                <td colspan="4">Actual working Days</td>
                <td colspan="2">
                    <asp:Label ID="actwork" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="4" style="text-align:left">
                    1. Attitude Of Work (Initiative)工作態度(√)</td>
                <td class="auto-style16">10%</td>
                <td colspan="3" style="text-align:left">2. Accuracy of Work</td>
            </tr>
            <tr>
                <td colspan="4">Actual Present Days</td>
                <td colspan="2">
                    <asp:Label ID="actpre" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="4" style="text-align:left">
                    ＊Excellent= 10 point</td>
                <td class="auto-style16">
                    <asp:CheckBox ID="c1" runat="server" />
                </td>
                <td colspan="2">30%</td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5" colspan="4">Absent days</td>
                <td class="auto-style5" colspan="2">
                    <asp:Label ID="absent" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5" colspan="4" style="text-align:left">
                    ＊Good= 8 point</td>
                <td class="auto-style11">
                    <asp:CheckBox ID="c2" runat="server" />
                </td>
                <td class="auto-style5" colspan="3" style="text-align:left">3. Quality and Productivity of work</td>
            </tr>
            <tr>
                <td>CL</td>
                <td colspan="2">
                    <asp:Label ID="cla" runat="server" Text="Label"></asp:Label>
                </td>
                <td>SL</td>
                <td colspan="2">
                    <asp:Label ID="sla" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="4" style="text-align:left">
                    ＊Satisfactoryt= 5 point</td>
                <td class="auto-style16">
                    <asp:CheckBox ID="c3" runat="server" />
                </td>
                <td colspan="2">30%</td>
                <td class="auto-style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>PL</td>
                <td>
                    <asp:Label ID="pla" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="3">LWP</td>
                <td>
                    <asp:Label ID="lwpa" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="4" style="text-align:left">
                    ＊Improvement Required= 3 point</td>
                <td class="auto-style16">
                    <asp:CheckBox ID="c4" runat="server" />
                </td>
                <td colspan="2" rowspan="2" style="font-weight:bold">Total Scores</td>
                <td rowspan="2" class="auto-style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">Score( 20%)</td>
                <td colspan="3">
                    <asp:Label ID="score" runat="server" Text="Label"></asp:Label>
                </td>
                <td colspan="4" style="text-align:left">＊Fail= 0 point</td>
                <td class="auto-style16">
                    <asp:CheckBox ID="c5" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style6" colspan="6" style="text-align:left">&nbsp; 4.Recommendation 總評建議:</td>
                <td class="auto-style6" colspan="8" style="text-align:left">
                    <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" Width="309px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="8">Remarks</td>
                <td colspan="2" class="auto-style14">Status of probation / Training period</td>
                <td class="auto-style16" style="font-weight:bold">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Pass" />
                </td>
                <td colspan="2" style="font-weight:bold">
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Extend" />
                </td>
                <td class="auto-style9" style="font-weight:bold">
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="Fail" />
                </td>
            </tr>
            <tr>
                <td colspan="8" rowspan="3" style="text-align:left">Performance status definition :考核結果說明 1.Pass: Score is 76 or more than 76 every time 適任: 分數高於76分 2.Extend : Score is 75 or below 75, turn to extend period(PIP), employee has three months to improve his/her performance. 延長:分數低於75分，進入績效改善階段，共三個月之改善期間。</td>
                <td colspan="6">Approvals</td>
            </tr>
            <tr>
                <td>Department Head</td>
                <td colspan="3">Section Head</td>
                <td colspan="2">Employee Signature</td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ch1" runat="server" />
                </td>
                <td colspan="3">
                    <asp:CheckBox ID="ch2" runat="server" />
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="ch3" runat="server" />
                </td>
            </tr>
          
        </table>

    </asp:Panel></center>
    <br />
        <center> <asp:Button ID="Button1" runat="server" Height="45px" Text="Submit" Width="122px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" CssClass="auto-style102" Height="43px" Text="Export To PDF" /></center>
    <br />    </ContentTemplate></asp:UpdatePanel>
</asp:Content>
