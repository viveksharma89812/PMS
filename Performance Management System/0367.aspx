<%@ Page Title="" Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/Site1.Master" CodeBehind="0367.aspx.vb" Inherits="Performance_Management_System.WebForm16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            height: 23px;
        }
        table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style45 {
            width: 93px;
        }
        .auto-style46 {
            width: 233px;
        }
        .auto-style47 {
            width: 111px;
        }
        .auto-style48 {
            width: 124px;
        }
        .auto-style51 {
            width: 94px;
        }
        .auto-style54 {
            width: 796px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <br />
    <%--<asp:TextBox ID="TextBox2" runat="server"  AutoPostBack="true"></asp:TextBox>--%>
    <center><asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid"  Width="750px" BackColor="#ffffff">

            <table style="width:100%" border="1">
                <tr>
                    <td colspan="11" style="font-weight:bold">
                        <asp:CheckBox ID="ID1" runat="server" />
                        Training /
                        <asp:CheckBox ID="ID2" runat="server" />
                        Probation Period Review Form (For Operator)訓練期/試用期評核表(作業人員)</td>
                </tr>
                 <tr>
                      <td colspan="8" style="font-weight:bold">A. Employee Information(By HR)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                     <td colspan="3" style="font-weight:bold">&nbsp;
                         <asp:CheckBox ID="fireview" runat="server" Font-Bold="True" Text="Final Review" />
                      </td>
                 </tr>
                 <tr>
                      <td colspan="3">Employee Name</td>
                     <td colspan="2" class="auto-style47">
                         <asp:Label ID="empname" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td class="auto-style46">Employee Code</td>
                     <td colspan="2">
                         <asp:Label ID="empcode" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2">Designation</td>
                     <td>
                         <asp:Label ID="desc" runat="server" Text="Label"></asp:Label>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="3">Dept./Sect.</td>
                     <td colspan="2" class="auto-style47">
                         <asp:Label ID="deptsect" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td class="auto-style46">DOJ</td>
                     <td colspan="2">
                         <asp:Label ID="doj" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2">Review Month</td>
                     <td>
                         <asp:Label ID="revmonth" runat="server" Text="Label"></asp:Label>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="4" style="font-weight:bold">B. Attendance Details(By HR)</td>
                     <td colspan="7" style="font-weight:bold">&nbsp;C.Performance Review (To be filled by Appraiser )&nbsp;</td>
                 </tr>
                 <tr>
                      <td colspan="3" class="auto-style5">Actual Working Days</td>
                     <td class="auto-style5">
                         <asp:Label ID="actworking" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left" class="auto-style5">1. Attitude of work(Initiative)</td>
                      <td colspan="2" class="auto-style5">
                          <asp:CheckBox ID="ch1" runat="server" />
                      </td>
                     <td colspan="3" style="text-align:left" class="auto-style5">&nbsp; 2</td>
                 </tr>
                 <tr>
                      <td colspan="3">Actual Present Days</td>
                     <td>
                         <asp:Label ID="actpresent" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Excellent=_Point</td>
                      <td colspan="2">
                          <asp:CheckBox ID="ch2" runat="server" />
                      </td>
                     <td>_%</td>
                      <td colspan="2">
                          <asp:CheckBox ID="ch6" runat="server" />
                      </td>
                 </tr>
                 <tr>
                      <td colspan="3" >Absent&nbsp; Days</td>
                     <td>
                         <asp:Label ID="absentdays" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Good=_Point</td>
                      <td colspan="2">
                          <asp:CheckBox ID="ch3" runat="server" />
                      </td>
                     <td style="text-align:left" colspan="3">&nbsp; 3</td>
                 </tr>
                 <tr>
                      <td>CL</td>
                      <td>
                          <asp:Label ID="cla" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td>SL</td>
                     <td>
                         <asp:Label ID="sla" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Mediocre=_Point</td>
                      <td colspan="2">
                          <asp:CheckBox ID="ch4" runat="server" />
                      </td>
                     <td>_%</td>
                      <td colspan="2">
                          <asp:CheckBox ID="ch7" runat="server" />
                      </td>
                 </tr>
                 <tr>
                      <td>PL</td>
                      <td>
                          <asp:Label ID="pla" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td>LWP</td>
                     <td>
                         <asp:Label ID="lwpa" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Improvement Required=_Point</td>
                      <td colspan="2">
                          <asp:CheckBox ID="ch5" runat="server" />
                      </td>
                     <td rowspan="2" style="font-weight:bold">Total Scores&nbsp;</td>
                      <td colspan="2" rowspan="2">
                          <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="2">Score(&nbsp;%)</td>
                      <td colspan="2">
                          <asp:Label ID="score" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Fail=_Point</td>
                      <td colspan="2">
                          <asp:CheckBox ID="ch9" runat="server" />
                      </td>
                 </tr>
                 <tr>
                      <td colspan="4">4. Recommendation總評建議</td>
                     <td colspan="7">
                         <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="283px"></asp:TextBox>
                      </td>
                 </tr>
            </table>



            <table border="1" style="width:100%">
                <tr>
                    <td class="auto-style54">Remarks</td>
                    <td class="auto-style48" colspan="2">Status of probation / Training period</td>
                    <td class="auto-style45" style="font-weight:bold">
                        <asp:CheckBox ID="CheckBox8" runat="server" Text="Pass" />
                    </td>
                    <td class="auto-style45" style="font-weight:bold">
                        <asp:CheckBox ID="CheckBox9" runat="server" Text="Extend" />
                    </td>
                    <td colspan="2" style="font-weight:bold">
                        <asp:CheckBox ID="CheckBox10" runat="server" Text="Fail" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style54" rowspan="3" style="text-align:left">1.Pass 適任:Training: Average score is 66 or more than 66. 訓練期：平均高於66分 Probation: Average score is 71 or more than 71. 試用期：平均高於71分 2.Extend 延長: Training: Average score is equal to or between 56-65 訓練期：平均落於56-65分 Probation: Average score is equal to or between 61-70. 試用期：平均落於61-70分 4.In Extend plan Employee has three months to improve his/her performance.延長期間共有三個月可進行改善</td>
                    <td colspan="6">Approvals</td>
                </tr>
                <tr>
                    <td class="auto-style51">Plant Head</td>
                    <td class="auto-style48">Department Head</td>
                    <td colspan="3">Section
                        <br />
                        Head</td>
                    <td>Employee Signature</td>
                </tr>
                <tr>
                    <td class="auto-style48">
                        <asp:CheckBox ID="c5" runat="server" />
                    </td>
                    <td class="auto-style48">
                        <asp:CheckBox ID="c2" runat="server" />
                    </td>
                    <td colspan="3">
                        <asp:CheckBox ID="c3" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="c4" runat="server" />
                    </td>
                </tr>
            </table>
     
        
    </asp:Panel>
        <br />
       <center>
             <asp:Button ID="Button2" runat="server" Height="45px" Text="Submit" Width="122px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To Pdf" />
           </center>
        
        <%--<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Panel ID="Panel1" runat="server" BorderStyle="Solid"  Width="918px" BackColor="#ffffff">
    <table class="auto-style3" border="1">
        <tr>
            <td colspan="8" style="font-size: x-large; font-style: oblique">□Training / □Probation Period Review Form (For Operator)訓練期/試用期評核表(作業人員)</td>
        </tr>
        <tr>
            <td colspan="6"><center>A. Employee Information (by HR)</center></td>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ■ Final Review</td>
        </tr>
        <tr>
            <td colspan="3">Employee Name</td>
            <td class="auto-style14">
                <asp:Label ID="empname" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style8">Employee Code</td>
            <td>
                <asp:Label ID="empcode" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style6">Designation</td>
            <td>
                <asp:Label ID="desc" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3">Dept./ Sec.</td>
            <td class="auto-style14">
                <asp:Label ID="deptsect" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style8">DOJ</td>
            <td>
                <asp:Label ID="doj" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style6">Review Month</td>
            <td>
                <asp:Label ID="review" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">B. Attendance Detail (by HR)</td>
            <td colspan="4">C. Performance Review (To be filled by the Appraiser)</td>
        </tr>
        <tr>
            <td colspan="3">Actual working Days</td>
            <td class="auto-style14">
                <asp:Label ID="actwork" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style8">1. Attitude Of Work (Initiative)工作態度(√)</td>
            <td>
                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6">2</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">Actual Present Days</td>
            <td class="auto-style14">
                <asp:Label ID="actpresent" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style8">＊Excellent=___ point</td>
            <td>
                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6">_%</td>
            <td>
                <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="3">Absent days</td>
            <td class="auto-style14">
                <asp:Label ID="absent" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style8">＊Good= ___ point</td>
            <td>
                <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6">3</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">CL</td>
            <td class="auto-style5">
                <asp:Label ID="cla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style10">SL</td>
            <td class="auto-style15">
                <asp:Label ID="sla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style9">＊Mediocre= ___ point</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style7">_%</td>
            <td class="auto-style5">
                <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>PL</td>
            <td>
                <asp:Label ID="pla" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style11">LWP</td>
            <td class="auto-style14">
                <asp:Label ID="lwpa" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style8">＊Improvement Required= ___ point</td>
            <td>
                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style6" rowspan="2">Total Scores</td>
            <td rowspan="2">
                <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">Score( ___%)</td>
            <td colspan="2">
                <asp:Label ID="score" runat="server" Text="Label"></asp:Label>
            </td>
            <td class="auto-style8">＊Fail= ___ point</td>
            <td>
                <asp:TextBox ID="TextBox18" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">4.Recommendation 總評建議:</td>
            <td colspan="4">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="374px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">Remarks</td>
            <td rowspan="2" class="auto-style8">Status of probation / Training period</td>
            <td rowspan="2">
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Pass" />
            </td>
            <td class="auto-style6" rowspan="2">
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Extend" />
            </td>
            <td rowspan="2">
                <asp:CheckBox ID="CheckBox3" runat="server" Text="Fail" />
            </td>
        </tr>
        <tr>
            <td colspan="4" rowspan="4">1.Pass 適任:Training: Average score is 66 or more than 66. 訓練期：平均高於66分 Probation: Average score is 71 or more than 71. 試用期：平均高於71分 2.Extend 延長: Training: Average score is equal to or between 56-65 訓練期：平均落於56-65分 Probation: Average score is equal to or between 61-70. 試用期：平均落於61-70分 4.In Extend plan Employee has three months to improve his/her performance.延長期間共有三個月可進行改善</td>
        </tr>
        <tr>
            <td colspan="4">Approvals</td>
        </tr>
        <tr>
            <td class="auto-style8">Plant Head</td>
            <td>Department Head</td>
            <td class="auto-style6">Section Head</td>
            <td>Employee Signature</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:CheckBox ID="CheckBox4" runat="server" />
            </td>
            <td>
                <asp:CheckBox ID="CheckBox5" runat="server" />
            </td>
            <td class="auto-style6">
                <asp:CheckBox ID="CheckBox6" runat="server" />
            </td>
            <td>
                <asp:CheckBox ID="CheckBox7" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Height="45px" Text="Submit" Width="122px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To Pdf" />
            </td>
        </tr>
    </table></asp:Panel>--%></center>
    <br /></ContentTemplate></asp:UpdatePanel>
    </asp:Content>
