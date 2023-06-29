<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0475.aspx.vb" Inherits="Performance_Management_System.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style36 {
            /*margin-right: 58px;*/
            margin-left: 21px;
        }
          table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style37 {
            width: 10%;
            height: 61px;
        }
        .auto-style38 {
            width: 15%;
            height: 61px;
        }
        </style>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800,toolbar=0');
            printWindow.document.write('<html><head><title</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
      
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
     
    <br /><center>
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
      <br />   
                   <%--  <asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To PDF" />--%><br />
    <%--<asp:TextBox ID="TextBox12" runat="server" AutoPostBack="True"></asp:TextBox>--%>
    &nbsp;<asp:Label ID="Label12" runat="server" Text="Label" Visible="false"></asp:Label>
   
    <center><asp:Panel ID="Panel1" runat="server" Width="970px" BorderStyle="Solid" BackColor="#ffffff">
        <table border="1" style="width:100%">
            <tr>
                <td colspan="7" style="font-size: large; font-weight: normal;  font-weight:bold; font-style: oblique">Performance review Form of Probation Period During/Final Review / Permanent Period (For Managerial level) 管理職人員績效考核表&nbsp;</td> 
            </tr>
             <tr>
                 <td colspan="7" style="font-weight:bold; background-color:#eea236">A. Employee Information</td>
            </tr>
             <tr>
                <td style="width:17%">Employee Name</td> <td id="empname" runat="server" style="width:17%"></td> <td style="width:17%">Employee Code</td> <td id="empcode" runat="server" style="width:17%"></td> <td style="width:17%" colspan="2">Designation</td> <td id="desi" runat="server" style="width:15%"></td>
            </tr>
                <tr>
                <td style="width:17%" >Dept./Section</td> <td id="deptsec" runat="server" style="width:17%"></td> <td style="width:17%">DOJ</td> <td id="doj" runat="server" style="width:17%"></td> <td style="width:17%" colspan="2">Review Month</td> <td id="revmonth" runat="server" style="width:15%"></td>
            </tr>
                <tr>
                <td style="width:17%">Qualification</td> <td id="qual" runat="server" style="width:17%"></td> <td style="width:17%">Previous Experience</td> <td id="preexpa" runat="server" style="width:17%"></td> <td style="width:17%" colspan="2">Reporting To</td> <td id="rept" runat="server" style="width:15%"></td>
            </tr>
            <tr>
                <td style="width:17%">Period</td> <td colspan="6" style="width:83%" onclick="return false;">
                <asp:CheckBox ID="dur" runat="server" Text="During Review" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="final" runat="server" Text="Final Review" />
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="other" runat="server" Text="Others" />
                &nbsp;: Permanent Period&nbsp;
                <asp:CheckBox ID="q1" runat="server" Text="Q1" />
                &nbsp;
                <asp:CheckBox ID="q2" runat="server" Text="Q2" />
                &nbsp;
                <asp:CheckBox ID="q3" runat="server" Text="Q3" />
                &nbsp;
                <asp:CheckBox ID="q4" runat="server" Text="Q4" />
                </td> 
            </tr>
        
        </table>
        <table border="1" style="width:100%">
            <tr >
                <td style="width:70%; font-weight:bold; background-color:#eea236">B. Assessment Parameter</td> <td style="width:5%">%</td><td style="width:5%">5</td><td style="width:5%">4</td><td style="width:5%">3</td><td style="width:5%">2</td><td style="width:5%">1&nbsp;</td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>1. Technical skills and Interpersonal Skills(專業能力及溝通技巧):</b> Knowledge for performing the task and the skills of interaction which describe through ease of taking task.<asp:TextBox ID="Scor1" runat="server" Visible="false"></asp:TextBox>
                </td>
              <td style="width:5%; font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" CssClass="auto-style36" RepeatDirection="Horizontal" Width="191px">
                       <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%; text-align:left"><b>2. Workforce Planning(人力掌控) :</b> Align the needs and priorities of the organization with workforce to ensure it can meet requirements of the organizational.<asp:TextBox ID="Scor2" runat="server" Visible="false"></asp:TextBox>
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass="auto-style36" AutoPostBack="True" RepeatDirection="Horizontal" Width="191px">
                     <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%; text-align:left"><b>3. Project management (專案管理):</b> Capability to initiating, planning, executing, controlling, and closing the work of a team to achieve specific goals and meet specific success criteria at the specified time.
                    <asp:TextBox ID="Scor3" runat="server" Visible="false"></asp:TextBox>
                </td>
             <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList3" runat="server" CssClass="auto-style36" AutoPostBack="True" RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>4. Progress Evaluation(過程監控):</b> It covers critical assessment of your subordinates on the basis of task assigned, it also includes whether program activities have been implemented as intended.<asp:TextBox ID="Scor4" runat="server" Visible="false"></asp:TextBox>
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList4" runat="server" CssClass="auto-style36" AutoPostBack="True"  RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>5. Problem Analysis(問題分析):</b> Ability to understand the situation,task and also find cause through analytical skills.<br />
                    <asp:TextBox ID="Scor5" runat="server" Visible="false"></asp:TextBox>
                </td>
           <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList5" runat="server" CssClass="auto-style36" AutoPostBack="True" RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%; text-align:left"><b>6. Decision Making(決策能力):</b> Based on the problem and it&#39;s analysis the right and proper decision should be taken by him/her.
                    <asp:TextBox ID="Scor6" runat="server" Visible="false"></asp:TextBox>
                </td>
           <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList6" runat="server" CssClass="auto-style36" AutoPostBack="True" RepeatDirection="Horizontal" Width="191px">
                       <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>7.Team Building(團隊建立):</b> Assign suitable task to team members which can Motivate and promote them to work together effectively.
                    <asp:TextBox ID="Scor7" runat="server" Visible="false"></asp:TextBox>
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList7" runat="server" CssClass="auto-style36" AutoPostBack="True" RepeatDirection="Horizontal" Width="191px">
                       <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>8.Leadership(領導技巧):</b> He/She must be capable to design, plan, manage, delegate, communicate the assigned work.
                    <asp:TextBox ID="Scor8" runat="server" Visible="false"></asp:TextBox>
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList8" runat="server" CssClass="auto-style36" AutoPostBack="True" RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>9. Development of Subordinates(發展部屬能力):</b> He/She is obliged for the development of their subordinates through sharing knowledge and guide them to show their potential which help to achieve the design goals.
                    <asp:TextBox ID="Scor9" runat="server" Visible="false"></asp:TextBox>
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList9" runat="server" CssClass="auto-style36" AutoPostBack ="True" RepeatDirection="Horizontal" Width="191px">
                       <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>10. Self- Learning(自我學習):</b> Capacity to learn, improve, and adapt changes independently which must help to achieve the desired goals.
                    <asp:TextBox ID="Scor10" runat="server" Visible="false"></asp:TextBox>
                </td>
               <td style="width:5%;font-weight:bold ">10</td><td colspan="5">
                <asp:CheckBoxList ID="CheckBoxList10" runat="server" CssClass="auto-style36" AutoPostBack="True" RepeatDirection="Horizontal" Width="191px">
                     <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td colspan="7" >*(1) Mark a ü (tick) against the appropriate rating. 5= Excellent(傑出), 4=Good(良好), 3=Mediocre(尚符需求), 2=Improvement Required(須改進), 1=Fail(不適任) *(2) 評核項目轉換分數:勾選選項*2分 (最高為10分，最低為2分)&nbsp;&nbsp; </td>
            </tr>
        </table>
        <table border="1"  style="width:100%">
            <tr>
                <td style="text-align:left; width:30%" >11.Comment and Areas of Improvement, Observation 建議及改進項目:</td>  
                <td colspan="5" style="width:70%" id="descr" runat="server">
                <asp:TextBox ID="remark" runat="server" cssclass="form-control" Height="100%"  BackColor="White" BorderColor="White" BorderStyle="None" TextMode="MultiLine"></asp:TextBox>
                </td>  
            </tr>
            <tr>
                <td colspan="2" style="background-color:#eea236;font-weight:bold" >Remarks</td>
                <td style="width:20%; background-color:#eea236" colspan="2">Total Scores</td>
                <td style="width:20%; background-color:#eea236" colspan="2">Review Status</td>
            </tr>
            <tr>
                <td style="text-align:left; font-size:small" colspan="2" rowspan="6">1. Review employees&#39; performance in this period and give feedback or guidance in <br /> point 11. 評核該區間之表現並給予回饋。 
                    <br />
                    2.Extend definition(考核延長):
                    <br />
                    Probation: Average score is equal to or between 61-70, 試用期: 平均分數落於61-70分 
                    <br />
                    Permanent: Score is 75 or below 75, 正職考核: 分數低於75分 
                    <br />
                    They turn to extend period(PIP),employee has three months to improve his/her performance. 考核延長者進入績效改善期間，共三個月。<br /> &nbsp;3. Fail in PIP period definition(延長考核不適任):
                    <br />
                    For Probation &amp; Permanent: If Employee score below 75 in each parameter in each month, employee services would be terminated.
                    <br />
                    若延長考核結果仍低於75分，則視為不適任。</td>
                <td style="width:20%" id="totscore" runat="server" colspan="2" rowspan="3">&nbsp;</td>
                <td style="width:10% ; text-align:left" rowspan="3">Required final review and quarter review only</td> <td style="width:20%">
                <asp:CheckBox ID="pass" runat="server" Text="Pass" Font-Bold="true" />
                </td>
                
            </tr>
            <tr>
                <td style="width:20%">
                    <asp:CheckBox ID="extend" runat="server" Text="Extend" Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td style="width:20%">
                    <asp:CheckBox ID="fail" runat="server" Text="Fail" Font-Bold="true" />
                </td>
            </tr>
            <tr>
                <td class="auto-style37">Plant Head/ Director</td>
                <td class="auto-style37">Department Head</td>
                <td class="auto-style38">Section&nbsp; Head</td>
                <td class="auto-style38">
                    Employee Signature</td>
            </tr>
            <tr>
                <td style="width:10%">
                    <asp:CheckBox ID="ch1" runat="server" />
                </td>
                <td style="width:10%">
                    <asp:CheckBox ID="ch2" runat="server" />
                </td>
                <td style="width:15% ;" >
                    <asp:CheckBox ID="ch3" runat="server" />
                </td>
                <td style="width:15%">
                    <asp:CheckBox ID="ch4" runat="server" AutoPostBack="true" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                </td>
            </tr>
           
            <tr>
                <td colspan="4">
                    <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <caption>
                <br />
                <br />
            </caption>
            
        </table>
   
       


   
        
         <asp:Button ID="insert" runat="server" Text="Submit"  CssClass="btn btn-primary" /></center> 
    </asp:Panel>
   </center>
    <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
