<%@ Page Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/Site1.Master" CodeBehind="0386_Planning.aspx.vb" Inherits="Performance_Management_System._0386_Planning" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style20 {
            width: 100%;
        }
        .auto-style21 {
            width: 100%;
            height: 83px;
        }
        .auto-style24 {
            width: 145px;
        }
        .auto-style25 {
            width: 204px;
        }
        .auto-style26 {
            width: 154px;
        }
        .auto-style31 {
            height: 22px;
        }
        .auto-style43 {
            width: 392px;
        }
        .auto-style54 {
            width: 532px;
        }
        .auto-style56 {
            width: 21px;
        }
        .auto-style57 {
            width: 20px;
        }
        .auto-style58 {
            width: 18px;
        }
        .auto-style59 {
            width: 15px;
        }
        .auto-style61 {
            width: 536px;
        }
        .auto-style63 {
            width: 273px;
        }
        .auto-style64 {
            width: 159px;
        }
        .auto-style65 {
            width: 188px;
        }
        .auto-style66 {
            width: 189px;
        }
        .auto-style67 {
            width: 432px;
        }
        .auto-style68 {
            margin-bottom: 0px;
        }
        .auto-style69 {
            width: 173px;
        }
        .auto-style83 {
            height: 25px;
        }
        .auto-style84 {
            width: 15px;
            height: 25px;
        }
        .auto-style85 {
            width: 145px;
            height: 27px;
        }
        .auto-style86 {
            height: 27px;
        }
        .auto-style90 {
            width: 182px;
            height: 57px;
        }
        .auto-style92 {
            width: 100%;
            height: 139px;
        }
        .auto-style93 {
            height: 57px;
        }
        .auto-style94 {
            height: 57px;
            width: 142px;
        }
        .auto-style101 {
            width: 125px;
        }
        .auto-style103 {
            height: 44px;
        }
               table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        
        .auto-style104 {
            width: 298px;
        }
        .auto-style105 {
            width: 39px;
        }
        .auto-style107 {
            height: 57px;
            width: 82px;
        }
        .auto-style108 {
            width: 715px;
        }
        .auto-style111 {
            width: 82px;
        }
        .auto-style112 {
            width: 182px;
        }
        .auto-style113 {
            width: 142px;
        }
        .auto-style114 {
            height: 23px;
        }
        .auto-style115 {
            width: 392px;
            height: 23px;
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><%--<Triggers><asp:PostBackTrigger ControlID="Button2" /></Triggers>--%><ContentTemplate>
        <%--<asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True"></asp:TextBox>--%>
        <asp:Label ID="Label21" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label><br />
       <center>
          
<%--            <center>
           <asp:Button ID="insert" runat="server"  Text="Submit" ValidationGroup="insert" cssclass="btn btn-primary"/>
                    
                        <%--<asp:Button ID="Button2" runat="server" CssClass="auto-style102" Height="43px" Text="Export To PDF" />--%>
      <%--</center><br />--%>
            <script type="text/javascript">
    function ValidateCheckBoxList(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList1.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList1(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList2.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList2(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList3.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList3(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList4.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
         function ValidateCheckBoxList4(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList5.ClientID %>"); 
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
        }
        
</script>
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid"  Width="900px" BackColor="#ffffff">
            
            <table id="1" border="1" class="auto-style21" style="width:895px">
                <tr>
                    <td class="auto-style31" colspan="6" style="font-size: large; font-style: oblique; font-weight:bold">
                        <center>
                            Performance Review Form (For Permanent Staff) 正職人員績效考核表</center>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style31" colspan="6" style="font-weight:bold">
                        <center class="auto-style68" style="background-color:#eea236 ">
                            A.Employee Information</center>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Employee Name</td>
                    <td class="auto-style26" ID="empname" runat="server">
                       
                    </td>
                    <td class="auto-style25">Employee Code</td>
                    <td class="auto-style69" ID="empcode" runat="server">
                        
                    </td>
                    <td class="auto-style101">Designation</td>
                    <td ID="desc" runat="server">
                       
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Dept./Section</td>
                    <td class="auto-style26" ID="deptsect" runat="server">
                        
                    </td>
                    <td class="auto-style25">DOJ</td>
                    <td class="auto-style69" ID="doj" runat="server">
                        
                    </td>
                    <td class="auto-style101">Reporting To</td>
                    <td ID="repto" runat="server">
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style85">Review Time</td>
                    <td class="auto-style86" colspan="5" onclick="return false;">&nbsp; &nbsp;<asp:CheckBox ID="othe" runat="server"  Text="Other:" />
                        &nbsp;<asp:Label ID="currentyear" runat="server" Text="Label"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="q1" runat="server"  Text="Q1" />
                        &nbsp;<asp:CheckBox ID="q2" runat="server" Text="Q2" />
                        &nbsp;
                        <asp:CheckBox ID="q3" runat="server"  Text="Q3" />&nbsp;
                        <asp:CheckBox ID="q4" runat="server"  Text="Q4" />
                    </td>
                </tr>
            </table>
            <table id="2" border="1" class="auto-style20">
                <tr>
                    <td colspan="8" style="font-weight:bold" class="auto-style114">
                        <center class="auto-style68" style="background-color:#eea236 " >
                            B.Attendance Details</center>
                    </td>
                    <td class="auto-style115" style="background-color:#eea236 ">30%</td>
                </tr>
                <tr>
                    <td class="auto-style104">Actual Working Days</td>
                    <td class="auto-style63">Actual Present Days</td>
                    <td class="auto-style64">CL</td>
                    <td class="auto-style65">SL</td>
                    <td class="auto-style66">PL</td>
                    <td class="auto-style67">LWP</td>
                    <td class="auto-style67">Other Leaves</td>
                    <td class="auto-style61">Absent Days</td>
                    <td class="auto-style43">Scores</td>
                </tr>
                <tr>
                    <td  ID="actworking" runat="server" style="height:20px">
                        
                    </td>
                    <td  ID="actpresent" runat="server" style="height:20px">
                       
                    </td>
                    <td  ID="cla" runat="server" style="height:20px">
                       
                    </td>
                    <td  ID="sla" runat="server" style="height:20px">
                      
                    </td>
                    <td  ID="pla" runat="server" style="height:20px">
                        
                    </td>
                    <td  ID="lwpa" runat="server" style="height:20px">
                     
                    </td>
                    <td  ID="other" runat="server" style="height:20px">
                       
                    </td>
                    <td  ID="absentday" runat="server" style="height:20px">
                        
                    </td>
                    <td  ID="score" runat="server" style="height:20px">
                        
                    </td>
                </tr>
            </table>
            <table id="tb1" runat="server" border="1" class="auto-style20">
                <tr>
                    <td class="auto-style83" colspan="7" style="font-weight:bold;background-color:#eea236 ">
                        <center>
                            C.Performance Review</center>
                    </td>
                    <td class="auto-style84" style="background-color:#eea236 ">
                        <center>
                            70%</center>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style54" colspan="2">
                        <center>
                            Assessment Parameter</center>
                    </td>
                    <td class="auto-style105">%</td>
                    <td class="auto-style56">
                        <center>
                            5</center>
                    </td>
                    <td class="auto-style57">
                        <center>
                            4</center>
                    </td>
                    <td class="auto-style58">
                        <center>
                            3</center>
                    </td>
                    <td class="auto-style58">
                        <center>
                            2</center>
                    </td>
                    <td class="auto-style59">
                        <center>
                            1</center>
                    </td>
                </tr>
                <tr itemid="1">  
                    <td class="auto-style54" colspan="2" title="a" style="text-align:left"><b>1. Proficiency/competency in work(工作職能) :</b> The capacity to understand a situation and to act reasonably, Creativity &amp; innovatively..<asp:TextBox ID="scor1" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style105" title="a">15<asp:CustomValidator ID="CustomValidator1" ValidationGroup="insert" runat="server" ErrorMessage="select at least one item." Text="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList"></asp:CustomValidator></td>
                  
                    <td colspan="5" title="a">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" Height="27px" Width="173px" CausesValidation="true">
                             <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style54" colspan="2" style="text-align:left"><b>2. Problem analysis and resolution(問題分析及解決能力) :</b> Ability to gather and analyse relevant data to solve problems and make decisions within the scope of authority.<asp:TextBox ID="scor2" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style105">15<asp:CustomValidator ID="CustomValidator2" ValidationGroup="insert"  runat="server" ErrorMessage="select at least one item." Text="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList1"></asp:CustomValidator></td>
                    <td colspan="5">
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" Height="27px" Width="173px" CausesValidation="true">
                              <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style54" colspan="2" style="text-align:left"><b>3. Plan ability and Quality of Work(工作計畫與品質) :</b> Can prepare action plan for short-term or long-term also follow it and maintain &#39;Quality Standard&#39; of work.<asp:TextBox ID="scor3" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style105">20<asp:CustomValidator ID="CustomValidator3" ValidationGroup="insert" runat="server" ErrorMessage="select at least one item." Text="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList2"></asp:CustomValidator></td>
                    <td colspan="5">
                        <asp:CheckBoxList ID="CheckBoxList3" runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" Height="27px" Width="173px" CausesValidation="true">
                              <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style54" colspan="2" style="text-align:left"><b>4. Initiative(工作積極性) :</b> Shows a positive attitude &amp; motivation towards work and the organization. Consistently developing new initiatives to ensure continued growth.<asp:TextBox ID="scor4" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style105">15<asp:CustomValidator ID="CustomValidator4" ValidationGroup="insert" runat="server" ErrorMessage="select at least one item." Text="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList3"></asp:CustomValidator></td>
                    <td colspan="5">
                        <asp:CheckBoxList ID="CheckBoxList4" runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" Height="27px" Width="173px" CausesValidation="true">
                             <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style54" colspan="2" style="text-align:left"><b>5. Involvement/participation in team effort(團隊合作) :</b> Can inspire confidence in others and creates enthusiasm and ensures collaboration amongst team members to attain stated objectives.<asp:TextBox ID="scor5" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style105">5<asp:CustomValidator ID="CustomValidator5" ValidationGroup="insert" runat="server" ErrorMessage="select at least one item." Text="*" ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList4"></asp:CustomValidator></td>
                    <td colspan="5">
                        <asp:CheckBoxList ID="CheckBoxList5" runat="server"  AutoPostBack="True" RepeatDirection="Horizontal" Height="27px" Width="173px" CausesValidation="true">
                             <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style103" colspan="8" style="text-align:left">*(1) Mark a V (tick) against the appropriate rating. 5= Excellent(傑出), 4=Good(良好), 3=mediocre(尚符需求), 2=Improvement Required(須改進), 1=Fail(不適任) *(2) 評核項目轉換分數:勾選選項*3分 (最高為15分，最低為3分)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:Button ID="Button3" runat="server" Text="Button" />--%>
                    </td>
                </tr>
                <tr>
                    <td  style="text-align:left;width:150px">6. Summarise the overall performance or comment : 總評建議:</td>
                    <td class="auto-style83" colspan="7">
                        <asp:TextBox ID="remark" runat="server"  Height="70px"  TextMode="MultiLine" BackColor="White" BorderColor="White" BorderStyle="None" cssclass="form-control" ></asp:TextBox>
                    </td>
                </tr>
               
            </table>
            <table border="1" class="auto-style92">
                <tr>
                    <td class="auto-style108" style="font-weight:bold ;background-color:#eea236 ">
                        <center>
                            Remarks</center>
                    </td>
                    <td class="auto-style112" style="font-weight:bold">
                        <center>
                            Status of Review Period</center>
                    </td>
                    <td colspan="3" onclick="return false;"><asp:CheckBoxList ID="reviewstatus" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"  Width="202px" BorderStyle="None" Height="32px">
                        <asp:ListItem>Pass</asp:ListItem>
                        <asp:ListItem>Extend</asp:ListItem>
                        </asp:CheckBoxList>
                        </td>
                </tr>
                <tr>
                    <td class="auto-style108" rowspan="3" style="text-align:left;font-size:small">Performance status definition :考核結果說明 
                        <br />
                        1.Pass: Score is 76 or more than 76 every time
                        <br />
                        適任: 分數高於76分 
                        <br />
                        2.Extend : Score is 75 or below 75, turn to
                        <br />
                        extend period(PIP), employee has three
                        <br />
                        months to improve his/her performance.<br /> &nbsp;延長:分數低於75分，進入績效改善階段，共三個月之改善期間。</td>
                    <td class="auto-style112" rowspan="2" style="font-weight:bold ;background-color:#eea236 ">
                        <center>
                            Total Scores</center>
                    </td>
                    <td colspan="3" style="background-color:#eea236 ">
                        <center>
                            Approvals</center>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style113">
                        <center>
                            Department<br /> Head</center>
                    </td>
                    <td class="auto-style111">
                        <center>
                            Section
                            <br />
                            Head</center>
                    </td>
                    <td>
                        <center>
                            Employee Signature</center>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style90" id="totmarks" runat="server">
                    </td>
                    <td class="auto-style94"><asp:CheckBox ID="deptsign" runat="server" />
                    </td>
                    <td class="auto-style107">
                        <asp:CheckBox ID="sectsign" runat="server" />
                    </td>
                    <td class="auto-style93">
                        <asp:CheckBox ID="empsign" runat="server" AutoPostBack="true" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                    </td>
                </tr>
               
            </table>
            <br />
            <br />
                        <center>
           <asp:Button ID="insert" runat="server"  Text="Submit" ValidationGroup="insert" cssclass="btn btn-primary"/>
                    
                        <%--<asp:Button ID="Button2" runat="server" CssClass="auto-style102" Height="43px" Text="Export To PDF" />--%>
      </center><br />
        </asp:Panel>
       </center>
       
       
      
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>

