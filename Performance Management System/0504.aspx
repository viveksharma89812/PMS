<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0504.aspx.vb" Inherits="Performance_Management_System.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style24 {
            width: 185px;
        }
        .auto-style25 {
            width: 161px;
        }
          table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style26 {
            width: 268435520px;
        }
        .auto-style27 {
            width: 103px;
        }
        </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><Triggers><asp:PostBackTrigger ControlID="Button2" /></Triggers><ContentTemplate>
    <br />
    <%--<asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>--%>
    &nbsp;&nbsp;<asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
    <br />
   <center> <asp:Panel ID="Panel1" runat="server"  BorderStyle="Solid" Width="900px" BackColor="#ffffff">
       
        <table class="ui-accordion" border="1" style="width:100%">

            <tr>
                <td style=" font-size: x-large; font-style: italic; font-weight:bold" colspan="13">Performance improvement Plan Form (PIP) 績效改善計畫表</td>
               
                
            </tr>
             <tr>
                <td class="auto-style24" style="font-weight:bold">Emp Name</td>
                <td colspan="9">
                    <asp:Label ID="emplname" runat="server" Text="Label"></asp:Label>
                 </td>
                <td class="auto-style26" style="font-weight:bold">Emp Code</td>
                 <td colspan="2">
                     <asp:Label ID="emplcode" runat="server" Text="Label"></asp:Label>
                 </td>
            </tr>
             <tr>
                <td class="auto-style24" style="font-weight:bold">Department</td>
                <td colspan="9">
                    <asp:Label ID="deptn" runat="server" Text="Label"></asp:Label>
                 </td>
                <td class="auto-style26" style="font-weight:bold">Section</td>
                 <td colspan="2">
                     <asp:Label ID="sectn" runat="server" Text="Label"></asp:Label>
                 </td>
            </tr>
             <tr>
                <td rowspan="2" class="auto-style24">PIP Plan</td>
                <td colspan="3" class="auto-style25">Month</td>
                 <td colspan="5" class="auto-style27">Month</td>
                 <td>Month</td>
                <td class="auto-style26">D.O.J</td>
                 <td colspan="2">
                     <asp:Label ID="dojn" runat="server" Text="Label"></asp:Label>
                 </td>
            </tr>
             <tr>
                 <td colspan="3" class="auto-style25">
                     <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td colspan="5" class="auto-style27">
                     <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td>
                     <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td class="auto-style26">Extend Period</td>
                 <td colspan="2">
                     <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                 </td>
            </tr>
             <tr>
                <td class="auto-style24" style="font-weight:bold">Reporting Person</td>
                 <td colspan="8">
                     <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                 </td>
                 <td colspan="2" style="font-weight:bold">Under Observation</td>
                 <td colspan="2">
                     <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                 </td>
            </tr>
             <tr>
                <td colspan="13" style="font-weight:bold">A.PIP Plan Work</td>
            </tr>
             <tr>
                <td colspan="13">
                    <asp:TextBox ID="TextBox1" runat="server" Height="55px" TextMode="MultiLine" cssclass="form-control"></asp:TextBox>
                 </td>
            </tr>
             <tr>
                <td colspan="9" rowspan="2" style="font-weight:bold">Work Plan Approval</td>
                 <td colspan="2" style="font-weight:bold">Supervisor</td>
                 <td colspan="2" style="font-weight:bold">Employee</td>
            </tr>
             <tr>
                 <td colspan="2">
                     <asp:CheckBox ID="CheckBox1" runat="server" />
                 </td>
                 <td colspan="2">
                     <asp:CheckBox ID="CheckBox2" runat="server" />
                 </td>
                 
            </tr>
            <tr>
                <td colspan="13" style="font-weight:bold">B. PIP Evaluation</td>
            </tr>
            <tr>
                <td colspan="9" style="font-weight:bold">Evaluation Parameter</td>
                <td colspan="2" style="font-weight:bold">Month-1</td>
                <td colspan="2" style="font-weight:bold">Month-2</td>
            </tr>
            <tr>
                <td style="text-align:left" colspan="9">1. <asp:TextBox ID="eval1" runat="server"  CssClass="form-control" ></asp:TextBox>
                </td>
                <td colspan="2" >&nbsp;</td>
                <td colspan="2" >&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:left" colspan="9">2. <asp:TextBox ID="eval2" runat="server" CssClass="form-control"  ></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr >
                <td style="text-align:left" colspan="9">3. <asp:TextBox ID="eval3" runat="server" CssClass="form-control"  ></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:left" colspan="9">4. <asp:TextBox ID="eval4" runat="server" CssClass="form-control"  ></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:left" colspan="9">5. <asp:TextBox ID="eval5" runat="server" CssClass="form-control"  ></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align:left" colspan="9">6. <asp:TextBox ID="eval6" runat="server"  CssClass="form-control"  ></asp:TextBox>
                </td>
                <td colspan="2">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="9" rowspan="2" style="font-weight:bold">Monthly Approval</td>
                <td style="font-weight:bold">Supervisor</td>
                <td class="auto-style26" style="font-weight:bold">Employee</td>
                <td style="font-weight:bold">Supervisor</td>
                <td style="font-weight:bold">Employee</td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="Ch1" runat="server" />
                </td>
                <td class="auto-style26">
                    <asp:CheckBox ID="Ch2" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="Ch3" runat="server" />
                </td>
                <td>
                    <asp:CheckBox ID="Ch4" runat="server" />
                </td>
            </tr>
            <tr><td colspan="13" style="font-weight:bold ; text-align:left">Comments: <asp:TextBox ID="remark" runat="server" CssClass="form-control"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="10" style="font-weight:bold">
                    Result: </td>
                <td colspan="3" style="font-weight:bold">Final Approval</td>
            </tr>
            <tr>
                <td colspan="2">
                    Pass</td>
                <td colspan="3">
                    <asp:CheckBox ID="pass" runat="server" />
                </td>
                <td colspan="3">Fails</td>
                <td colspan="2">
                    <asp:CheckBox ID="fail" runat="server" />
                </td>
                <td class="auto-style26" style="font-weight:bold">Plant Head</td>
                <td style="font-weight:bold" >Department Head</td>
                <td style="font-weight:bold">Section Head</td>
            </tr>
            <tr>
                <td colspan="10" style="font-weight:bold">Remarks: Evaluation Criteria</td>
                <td class="auto-style26" rowspan="2">
                    <asp:CheckBox ID="c1" runat="server" />
                </td>
                <td rowspan="2">
                    <asp:CheckBox ID="c2" runat="server" />
                </td>
                <td rowspan="2">
                    <asp:CheckBox ID="c3" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3" style="font-weight:bold">25%</td>
                <td colspan="3" style="font-weight:bold">50%</td>
                <td style="font-weight:bold">75%</td>
                <td colspan="3" style="font-weight:bold">100%</td>
            </tr>
            <tr>
                <td colspan="3" style="font-weight:bold">Low Performance</td>
                <td colspan="3" style="font-weight:bold">Middle Level Performance</td>
                <td style="font-weight:bold">Satisfactory Performance</td>
                <td colspan="3" style="font-weight:bold">Excellent Performance</td>
                <td colspan="3" style="text-align:left; font-size:small">1. In &quot;B&quot; part Columns can add as per improvement plan. B部分依照改善計畫提出評核項目。<br /> 2. Evaluate the performance continuously for 2 months&#39; under PIP. 持續評核兩個月。<br /> 3.Pass definition : Required 75% or more in every PIP period (2 months).
                    <br />
                    通過: 每月評核結果高於75%。 
                    <br />
                    4.Fail definition : less than 75% in any evaluation item . 未通過: 任一評核項目結果小於75%。</td>
            </tr>
          
        </table>
       
    </asp:Panel></center><br /><center>
          <asp:Button ID="Button1" runat="server" Height="43px" Text="Submit" Width="123px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Height="38px" Text="Export To PDF" />
                               </center> <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
