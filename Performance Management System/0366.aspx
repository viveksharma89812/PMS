<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/Site1.Master" CodeBehind="0366.aspx.vb" Inherits="Performance_Management_System.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 100%;
        }
        .auto-style5 {
            width: 145px;
        }
        .auto-style8 {
            width: 57px;
        }
        .auto-style10 {
            width: 131px;
        }
         table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style16 {
            width: 78px;
        }
        .auto-style23 {
            width: 190px;
        }
        .auto-style25 {
            width: 225px;
        }
        .auto-style26 {
            width: 158px;
        }
        .auto-style27 {
            width: 415px;
        }
        .auto-style28 {
            width: 130px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><Triggers><asp:PostBackTrigger ControlID="Button3" /> </Triggers><ContentTemplate>
    <br />
    <br />
    <%--<asp:TextBox ID="TextBox11" runat="server" AutoPostBack="True"></asp:TextBox>--%>
    <asp:Label ID="Label18" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
<center><asp:Panel ID="Panel1" runat="server" BorderStyle="Solid"  Width="789px" BackColor="#ffffff">
        <table class="auto-style3" border="1">
            <tr>
                <td colspan="6" style="font-size: large; font-style: oblique; font-weight:bold"><asp:CheckBox ID="CheckBox5" runat="server"></asp:CheckBox> Training / <asp:CheckBox ID="CheckBox6" runat="server"></asp:CheckBox> Probation Period Review Form (For Operator)訓練期/試用期評核表(作業人員)</td>
            </tr>
            <tr>
                <td colspan="6" style="font-weight:bold"><center>A. Employee Information(By HR)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="CheckBox4" runat="server" Text="During Review" />
                    </center> </td>
            </tr>
            <tr>
                <td>Employee Name</td>
                <td>
                    <asp:Label ID="empname" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Employee Code</td>
                <td>
                    <asp:Label ID="empcode" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Designation</td>
                <td>
                    <asp:Label ID="desc" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Dept./Sect.</td>
                <td>
                    <asp:Label ID="deptsect" runat="server" Text="Label"></asp:Label>
                </td>
                <td>DOJ</td>
                <td>
                    <asp:Label ID="doj" runat="server" Text="Label"></asp:Label>
                </td>
                <td>Review Month</td>
                <td>
                    <asp:Label ID="revmonth" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="auto-style3" border="1">
        <tr>
            <td colspan="4" style="font-weight:bold">B. Attendance Details (By HR)</td>
            <td colspan="4" style="font-weight:bold">C. Performance Review (To be filled by Appraiser )</td>
        </tr>
        <tr>
            <td colspan="3">Actual Working Days</td>
            <td class="auto-style10">
                <asp:Label ID="actworking" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style27" style="text-align:left">1. Attitude of work(Initiative)</td>
            <td class="auto-style23">
                <asp:CheckBox ID="chk1" runat="server" />
          </td>
            <td colspan="2">2</td>
        </tr>
        <tr>
            <td colspan="3">Actual Present Days</td>
            <td class="auto-style10">
                <asp:Label ID="actpresent" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style27" style="text-align:left">* Excellent=_Point</td>
            <td class="auto-style23">
                <asp:CheckBox ID="chk2" runat="server" />
            </td>
            <td class="auto-style25">_%</td>
            <td>
                <asp:CheckBox ID="chk7" runat="server" />
            </td>
        </tr>
            <tr>
                <td colspan="3">Absent&nbsp; Days</td>
                <td class="auto-style10">
                    <asp:Label ID="absentdays" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style27" style="text-align:left">* Good=_Point</td>
                <td class="auto-style23">
                    <asp:CheckBox ID="chk3" runat="server" />
                </td>
                <td colspan="2">&nbsp; 3&nbsp;</td>
            </tr>
        <tr>
            <td class="auto-style28">CL</td>
            <td class="auto-style8">
                <asp:Label ID="cla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style16">SL</td>
            <td class="auto-style10">
                <asp:Label ID="sla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style27" style="text-align:left">* Mediocre=_Point</td>
            <td class="auto-style23">
                <asp:CheckBox ID="chk4" runat="server" />
            </td>
            <td class="auto-style25">_%</td>
            <td>
                <asp:CheckBox ID="chk8" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style28">PL</td>
            <td class="auto-style8">
                <asp:Label ID="pla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style16">LWP</td>
            <td class="auto-style10">
                <asp:Label ID="lwpa" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style27" style="text-align:left">* Improvement Required=_Point</td>
            <td class="auto-style23">
                <asp:CheckBox ID="chk5" runat="server" />
            </td>
            <td class="auto-style25" rowspan="2" style="font-weight:bold">Total Scores</td>
            <td rowspan="2">
                <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">Score(<asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>
                &nbsp;%)</td>
            <td colspan="2">
                <asp:Label ID="score" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style27" style="text-align:left">* Fail=_Point</td>
            <td class="auto-style23">
                <asp:CheckBox ID="chk6" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style28" style="text-align:left">4. Recommendation總評建議:</td>
            <td colspan="7">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="506px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="5">Remarks</td>
            <td colspan="3">Approvals</td>
        </tr>
        <tr>
            <td colspan="5" rowspan="2" style="text-align:left">1.Review employees' performance in this period and give feedback <br /> or guidance. 評核該區間之表現並給予回饋。<br /> 2. Fail definition: 不適任說明：<br /> Training: (1) scores are 55 or below 55 in the three months <br /> continuously,(2) Average Score is 55 or below 55.<br /> 連續三次低於55分或平均低於55分 <br /> Probation: (1) scores are 60 or below 60 in the three months <br /> continuously (2) Average Score is 60 or below 60 <br /> 連續三次低於60分或平均低於60分 <br /> In these two cases Employee services would be terminated.</td>
            <td class="auto-style23">Department
                <br />
                Head</td>
            <td class="auto-style25">Section
                <br />
                Head</td>
            <td>Employee Signature</td>
        </tr>
            <tr>
                <td class="auto-style23">
                    <asp:CheckBox ID="ch1" runat="server" />
                </td>
                <td class="auto-style25">
                    <asp:CheckBox ID="ch2" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="ch3" runat="server" />
                </td>

            </tr>
           <%-- <tr>
                <td colspan="8">
                   
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   
                  
                    &nbsp;</td>

            </tr>--%>
    </table>
        
    </asp:Panel></center><br />
        <center>
             <asp:Button ID="Button2" runat="server" Height="45px" Text="Submit" Width="122px" />  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To Pdf" />
        </center>
    
    <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
