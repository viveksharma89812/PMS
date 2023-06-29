<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0367_Utility.aspx.vb" Inherits="Performance_Management_System.WebForm32" %>
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
        .auto-style55 {
            width: 268435424px;
        }
        .auto-style59 {
            width: 108px;
        }
        .auto-style60 {
            width: 204px;
        }
          .auto-style61 {
              width: 216px;
          }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
         <center>
             <asp:Button ID="insert" runat="server"  Text="Submit"  cssclass="btn btn-primary" />
                    
                    <%--<asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To Pdf" />--%>
           </center>
    <br />
    <%--<asp:TextBox ID="TextBox2" runat="server"  AutoPostBack="true"></asp:TextBox>--%>
    <center><asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid"  Width="892px" BackColor="#ffffff">

            <table style="width:100%" border="1">
                <tr>
                    <td colspan="11" style="font-weight:bold" onclick="return false">
                        <asp:CheckBox ID="ID1" runat="server" />
                        Training /
                        <asp:CheckBox ID="ID2" runat="server" />
                        Probation Period Review Form (For Engineering(Utility) Operator)訓練期/試用期評核表(作業人員)</td>
                </tr>
                 <tr>
                      <td colspan="7" style="font-weight:bold;background-color:#eea236">A. Employee Information(By HR)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                     <td colspan="4" style="font-weight:bold; background-color:#eea236">&nbsp;
                         <asp:CheckBox ID="fireview" runat="server" Font-Bold="True" Text="Final Review" />
                      </td>
                 </tr>
                 <tr>
                      <td colspan="3">Employee Name</td>
                     <td colspan="2" class="auto-style47">
                         <asp:Label ID="empname" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td class="auto-style61" >Employee Code</td>
                     <td>
                         <asp:Label ID="empcode" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="3">Designation</td>
                     <td>
                         <asp:Label ID="desc" runat="server" Text="Label"></asp:Label>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="3">Dept./Sect.</td>
                     <td colspan="2" class="auto-style47">
                         <asp:Label ID="deptsect" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td class="auto-style61" >DOJ</td>
                     <td>
                         <asp:Label ID="doj" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="3">Review Month</td>
                     <td>
                         <asp:Label ID="revmonth" runat="server" Text="Label"></asp:Label>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="4" style="font-weight:bold; background-color:#eea236">B. Attendance Details(By HR)</td>
                     <td colspan="7" style="font-weight:bold; background-color:#eea236">&nbsp;C.Performance Review (To be filled by Appraiser )&nbsp;</td>
                 </tr>
                 <tr>
                      <td colspan="3" class="auto-style5">Actual Working Days</td>
                     <td class="auto-style5">
                         <asp:Label ID="actworking" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left" class="auto-style5">1. Attitude of work(Initiative)</td>
                      <td class="auto-style5">
                          10%</td>
                     <td colspan="4" style="text-align:left" rowspan="2">2.Maintenance achieving rate維修達成率</td>
                 </tr>
                 <tr>
                      <td colspan="3">Actual Present Days</td>
                     <td>
                         <asp:Label ID="actpresent" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Excellent=10 Point</td>
                      <td rowspan="5">
                          
                          <asp:CheckBoxList ID="score1" runat="server" AutoPostBack="True" RepeatLayout="Flow">
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                          </asp:CheckBoxList>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="3" >Absent&nbsp; Days</td>
                     <td>
                         <asp:Label ID="absentdays" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Good=8 Point</td>
                     <td style="text-align:left" colspan="2" rowspan="2">60 %</td>
                      <td colspan="2" rowspan="2" style="text-align:left">
                          <asp:TextBox ID="score2" runat="server" CssClass="form-control"></asp:TextBox>
                      </td>
                 </tr>
                 <tr>
                      <td>CL</td>
                      <td>
                          <asp:Label ID="cla" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td class="auto-style59">SL</td>
                     <td>
                         <asp:Label ID="sla" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Satisfactoryt= 5 point</td>
                 </tr>
                 <tr>
                      <td>PL</td>
                      <td>
                          <asp:Label ID="pla" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td class="auto-style59">LWP</td>
                     <td>
                         <asp:Label ID="lwpa" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Improvement Required=3 Point</td>
                     <td rowspan="2" style="font-weight:bold; background-color:#eea236">Total Scores&nbsp;</td>
                      <td colspan="3" rowspan="2" id="totscore" runat="server">
                          
                      </td>
                 </tr>
                 <tr>
                      <td colspan="2">Score(30 %)</td>
                      <td colspan="2">
                          <asp:Label ID="score" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Fail=0 Point</td>
                 </tr>
                 <tr>
                      <td colspan="4">4. Recommendation總評建議</td>
                     <td colspan="7">
                         <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" cssclass="form-control"></asp:TextBox>
                      </td>
                 </tr>
            </table>



            <table border="1" style="width:100%">
                <tr>
                    <td class="auto-style54" style="background-color:#eea236">Remarks</td>
                    <td class="auto-style48" colspan="2">Status of probation / Training period</td>
                    <td class="auto-style45" style="font-weight:bold">
                        <asp:CheckBox ID="pass" runat="server" Text="Pass" />
                    </td>
                    <td class="auto-style45" style="font-weight:bold">
                        <asp:CheckBox ID="extend" runat="server" Text="Extend" />
                    </td>
                    <td colspan="2" style="font-weight:bold">
                        <asp:CheckBox ID="fail" runat="server" Text="Fail" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style54" rowspan="3" style="text-align:left; font-size:small">1.Pass 適任:Training: Average score is 66 or more than<br /> &nbsp;66.<br /> &nbsp;訓練期：平均高於66分 
                        <br />
                        Probation: Average score is 71 or more than 71.<br /> &nbsp;試用期：平均高於71分 
                        <br />
                        2.Extend 延長: Training: Average score is equal to or<br /> &nbsp;between 56-65
                        <br />
                        訓練期：平均落於56-65分 
                        <br />
                        Probation: Average score is equal to or between 61-70.<br /> &nbsp;試用期：平均落於61-70分<br /> &nbsp;4.In Extend plan Employee has three months to improve<br /> &nbsp;his/her performance.延長期間共有三個月可進行改善</td>
                    <td colspan="6" style="background-color:#eea236">Approvals</td>
                </tr>
                <tr>
                    <td class="auto-style51">Plant Head</td>
                    <td class="auto-style48">Department Head</td>
                    <td colspan="3" class="auto-style55">Section
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
                    <td colspan="3" class="auto-style55">
                        <asp:CheckBox ID="c3" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="c4" runat="server" AutoPostBack="true" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                    </td>
                </tr>
            </table>
     
        
    </asp:Panel>
        <br />
        </center>
    <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
