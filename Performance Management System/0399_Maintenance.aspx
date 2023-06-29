<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0399_Maintenance.aspx.vb" Inherits="Performance_Management_System.WebForm17" %>
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
        .auto-style59 {
            width: 108px;
            height: 38px;
        }
        .auto-style61 {
            width: 108px;
            height: 23px;
        }
        .auto-style63 {
            height: 23px;
            width: 45px;
        }
        .auto-style64 {
            width: 43px;
            height: 38px;
        }
        .auto-style65 {
            height: 23px;
            width: 43px;
        }
        .auto-style66 {
            width: 70px;
        }
        .auto-style67 {
            width: 223px;
        }
        .auto-style68 {
            width: 102px;
        }
        .auto-style69 {
            height: 23px;
            width: 102px;
        }
        .auto-style70 {
            height: 38px;
        }
        .auto-style71 {
           width: 429px;
       }
       .auto-style72 {
           width: 167px;
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
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid"  Width="883px" BackColor="#ffffff">

            <table style="width:100%" border="1">
                <tr>
                    <td colspan="10" style="font-weight:bold">
                        Permanent Period Review Form (For Engineering(Maintenance) Operator)</td>
                </tr>
                 <tr>
                      <td colspan="10" style="font-weight:bold;background-color:#eea236">A. Employee Information(By HR)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                 </tr>
                 <tr>
                      <td colspan="3">Employee Name</td>
                     <td colspan="2" class="auto-style66">
                         <asp:Label ID="empname" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td class="auto-style67" >Employee Code</td>
                     <td class="auto-style68">
                         <asp:Label ID="empcode" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2">Designation</td>
                     <td>
                         <asp:Label ID="desc" runat="server" Text="Label"></asp:Label>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="3">Dept./Sect.</td>
                     <td colspan="2" class="auto-style66">
                         <asp:Label ID="deptsect" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td class="auto-style67" >DOJ</td>
                     <td class="auto-style68">
                         <asp:Label ID="doj" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2">Review Month</td>
                     <td>
                         <asp:Label ID="revmonth" runat="server" Text="Label"></asp:Label>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="4" style="font-weight:bold; background-color:#eea236">B. Attendance Details(By HR)</td>
                     <td colspan="6" style="font-weight:bold; background-color:#eea236">&nbsp;C.Performance Review (To be filled by Appraiser )&nbsp;</td>
                 </tr>
                 <tr>
                      <td colspan="3" class="auto-style5">Actual Working Days</td>
                     <td class="auto-style5">
                         <asp:Label ID="actworking" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left" class="auto-style5">1. Attitude of work(Initiative)</td>
                      <td class="auto-style69">
                          10%</td>
                     <td colspan="3" style="text-align:left" class="auto-style5">&nbsp;2.Maintenance reaching rate維修達成率</td>
                 </tr>
                 <tr>
                      <td colspan="3">Actual Present Days</td>
                     <td>
                         <asp:Label ID="actpresent" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Excellent=10 Point</td>
                      <td rowspan="5" class="auto-style68">
                           
                          <asp:CheckBoxList ID="score1" runat="server" AutoPostBack="True" RepeatLayout="Flow"  Height="112px">
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                              <asp:ListItem onclick="MutExChkList(this);"></asp:ListItem>
                          </asp:CheckBoxList>
                      </td>
                     <td>40 %</td>
                      <td colspan="2">
                          <asp:TextBox ID="score2" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                      </td>
                 </tr>
                 <tr>
                      <td colspan="3" >Absent&nbsp; Days</td>
                     <td>
                         <asp:Label ID="absentdays" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left">* Good=8 Point</td>
                     <td style="text-align:left" colspan="3">&nbsp;3.Mechanical maintenance機械保養完成率</td>
                 </tr>
                 <tr>
                      <td class="auto-style70">CL</td>
                      <td class="auto-style64">
                          <asp:Label ID="cla" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td class="auto-style59">SL</td>
                     <td class="auto-style70">
                         <asp:Label ID="sla" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left" class="auto-style70">* Satisfactoryt= 5 point</td>
                     <td class="auto-style70">20 %</td>
                      <td colspan="2" class="auto-style70">
                          <asp:TextBox ID="score3" runat="server" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                      </td>
                 </tr>
                 <tr>
                      <td class="auto-style63">PL</td>
                      <td class="auto-style65">
                          <asp:Label ID="pla" runat="server" Text="Label"></asp:Label>
                      </td>
                      <td class="auto-style61">LWP</td>
                     <td class="auto-style5">
                         <asp:Label ID="lwpa" runat="server" Text="Label"></asp:Label>
                      </td>
                     <td colspan="2" style="text-align:left" class="auto-style5">* Improvement Required=3 Point</td>
                     <td rowspan="2" style="font-weight:bold; background-color:#eea236">Total Scores&nbsp;</td>
                      <td colspan="2" rowspan="2" id="totscore" runat="server">
                          
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
                     <td colspan="6">
                         <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" cssclass="form-control"></asp:TextBox>
                      </td>
                 </tr>
            </table>



            <table border="1" style="width:100%">
                <tr>
                    <td class="auto-style71" style="background-color:#eea236">Remarks</td>
                    <td class="auto-style72">Status of probation / Training period</td>
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
                    <td class="auto-style71" rowspan="3" style="text-align:left; font-size:small">Performance status definition :考核結果說明 <br /> 1.Pass: Score is 76 or more than 76 every time<br /> &nbsp;適任: 分數高於76分 
                        <br />
                        2.Extend : Score is 75 or below 75, turn to extend
                        <br />
                        period(PIP), employee has three months to improve
                        <br />
                        his/her performance.<br /> &nbsp;延長:分數低於75分，進入績效改善階段，<br /> 共三個月之改善期間。</td>
                    <td colspan="5" style="background-color:#eea236">Approvals</td>
                </tr>
                <tr>
                    <td class="auto-style72">Department Head</td>
                    <td colspan="3">Section
                        <br />
                        Head</td>
                    <td>Employee Signature</td>
                </tr>
                <tr>
                    <td class="auto-style72">
                        <asp:CheckBox ID="c2" runat="server" />
                    </td>
                    <td colspan="3">
                        <asp:CheckBox ID="c3" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="c4" runat="server" AutoPostBack="true" onclick="if(!confirm('Are you sure you want to Accept?'))return false;"  />
                    </td>
                </tr>
            </table>
     
        
    </asp:Panel>
        <br />
      
        
      </center>
    <br /></ContentTemplate></asp:UpdatePanel>
    </asp:Content>
