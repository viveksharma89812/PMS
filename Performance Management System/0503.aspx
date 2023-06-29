<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0503.aspx.vb" Inherits="Performance_Management_System.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style28 {
            width: 169px;
        }
        .auto-style30 {
            width: 131px;
        }
        .auto-style31 {
            width: 205px;
        }
        .auto-style32 {
            width: 235px;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><Triggers><asp:PostBackTrigger ControlID="Button3" /></Triggers><ContentTemplate>
    &nbsp;&nbsp;&nbsp;
    <br />
    <%--    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
&nbsp;<asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
    <br />
    <center> <asp:Panel ID="Panel1" runat="server"  Width="775px" BorderStyle="Solid" BackColor="#ffffff">
            
         <table class="ui-accordion" border="1">
             <tr>
                 <td colspan="4" style=" font-size: x-large; font-style: italic;font-weight:bold"><center>Extend Analysis Report 績效延長考核分析報告</center></td>
             </tr>
             <tr>
                 <td class="auto-style32" style="font-weight:bold">Employee Name</td>
                 <td class="auto-style31">
                     <asp:Label ID="emplname" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td class="auto-style30" style="font-weight:bold">Department</td>
                 <td>
                     <asp:Label ID="deptn" runat="server" Text="Label"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td class="auto-style32" style="font-weight:bold">Employee Code</td>
                 <td class="auto-style31">
                     <asp:Label ID="emplcode" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td class="auto-style30" style="font-weight:bold">Section</td>
                 <td>
                     <asp:Label ID="sectn" runat="server" Text="Label"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left;font-weight:bold">*Evaluation items</td>
             </tr>
             <tr>
                 <td colspan="4" style="font-weight:bold">Assessment Parameters</td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left"><b>1. Proficiency/competency in work(工作職能) :</b> The capacity to understand a situation and to act reasonably, Creativity &amp; innovatively.</td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left"><b>2. Plan ability and Quality of Work(工作計畫與品質) :</b> Can prepare action plan for short-term or long-term also follow it and maintain &#39;Quality Standard&#39; of work. </td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left"><b>3. Problem analysis and resolution(問題分析及解決能力) :</b> Ability to gather and analyse relevant data to solve problems and make decisions within the scope of authority.</td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left"><b>4. Initiative(工作積極性) :</b> Shows a positive attitude &amp; motivation towards work and the organization. Consistently developing new initiatives to ensure continued growth.</td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left"><b>5. Involvement/participation in team effort(團隊合作) :</b> Can inspire confidence in others and creates enthusiasm and ensures collaboration amongst team members to attain stated objectives.</td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left">&nbsp;</td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left;font-weight:bold">*Analysis Chart </td>
             </tr>
             <tr>
                 <td colspan="4" style="font-weight:bold; font-size:large"> Performance Analysis<br />
                     <asp:Chart ID="Chart1" runat="server" Width="631px">
                         <Series>
                             <asp:Series Name="Series1" XValueMember="0" XValueType="String" YValueMembers="2" YValueType="String">
                             </asp:Series>
                         </Series>
                         <ChartAreas>
                             <asp:ChartArea Name="ChartArea1">
                                  <AxisY Title="Month" TitleAlignment="Center"></AxisY> 
                                        <AxisX Title="Month"></AxisX>
                             </asp:ChartArea>
                         </ChartAreas>
                        

           
                     </asp:Chart>
                     <br />
                     &nbsp;&nbsp;&nbsp;&nbsp;
                     <br />
                     <br />
                 </td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left; font-weight:bold">*Remarks (comments by department head) </td>
             </tr>
             <tr>
                 <td colspan="4">
                     <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" cssclass="form-control"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td colspan="4" style="text-align:left;font-weight:bold">*Evaluation </td>
             </tr>
              <tr>
                 <td colspan="4" style="text-align:left">
                     On the basis of your past performance we observed that you required necessary improvement in the  Plan ability & quality of work, Involvement/ Participation in team effort and problem analysis and resolution and initiative.</td>
             </tr>
              <tr>
                 <td class="auto-style32" rowspan="3" style="text-align:left"><b>*Note :</b> <br />As per previous performance record, HR mention the content to find the employee&#39;s weakness and supervisor confirm the PIP item. 依據考核紀錄，人資部列出其內容並協助確認員工弱項。</td>
                 <td colspan="3" style="font-weight:bold">Approval </td>
             </tr>
             <tr>
                 <td class="auto-style31">Department Head</td>
                 <td class="auto-style30">Section Head</td>
                 <td>Employee Sign </td>
             </tr>
             <tr>
                 <td class="auto-style31">
                     <asp:CheckBox ID="CheckBox1" runat="server" />
                 </td>
                 <td class="auto-style30">
                     <asp:CheckBox ID="CheckBox2" runat="server" />
                 </td>
                 <td>
                     <asp:CheckBox ID="CheckBox3" runat="server" />
                 </td>
             </tr>
          
         </table>
            
        </asp:Panel></center>
        <br />
        <center>
             <asp:Button ID="Button2" runat="server" Height="45px" Text="Submit" Width="122px" />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To PDF" />
        </center>
    <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
