<%@ Page Language="vb" AutoEventWireup="false" EnableEventValidation="false" MasterPageFile="~/Site1.Master" CodeBehind="0386R1.aspx.vb" Inherits="Performance_Management_System._0386R1" %>


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
            width: 74px;
        }
        .auto-style31 {
            height: 22px;
        }
        .auto-style68 {
            margin-bottom: 0px;
        }
        table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style114 {
            width: 650px;
            font-style: normal;
        }
        .auto-style117 {
            border: 1px solid #000000;
            width: 145px;
        }
        .auto-style122 {
            border: 1px solid #000000;
        }
        .auto-style129 {
            width: 134px;
            border: 1px solid #000000;
        }
        .auto-style130 {
            width: 345px;
            border: 1px solid #000000;
            font-family: Calibri;
        }
        .auto-style131 {
            width: 67px;
        }
        .auto-style132 {
            width: 134px;
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
        }
        .auto-style133 {
            width: 345px;
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
        }
        .auto-style134 {
            border: 1px solid #000000;
            background-color: #D9E1F2;
            font-family: Calibri;
        }
        .auto-style137 {
            width: 407px;
            border: 1px solid #000000;
            font-family: Calibri;
        }
        .auto-style138 {
            width: 15px;
            border: 1px solid #000000;
        }
        .auto-style165 {
            font-size: small;
            font-family: Calibri;
        }
        .auto-style169 {
            width: 899px;
        }
        .auto-style172 {
            width: 405px;
            height: 23px;
        }
        .auto-style173 {
            height: 23px;
            font-family: Calibri;
        }
        .auto-style175 {
            width: 150px;
            font-family: Calibri;
        }
        .auto-style178 {
            width: 100px;
        }
        .auto-style180 {
            width: 100px;
            height: 69px;
        }
        .auto-style183 {
            font-family: call;
            font-style: normal;
            font-size: small;
        }
        .auto-style184 {
            font-family: call;
            font-size: small;
        }
        .auto-style209 {
            border: 1px dashed #000000;
        }
        .auto-style213 {
            border: 1px dashed #000000;
            font-size: small;
            font-family: Calibri;
        }
        .auto-style226 {
            border: 1px dashed #000000;
            width: 1626px;
        }
        .auto-style227 {
            border: 1px dashed #000000;
            width: 150px;
        }
        .auto-style228 {
            border: 1px dashed #000000;
            width: 549px;
        }
        .auto-style231 {
            border: 1px dashed #000000;
            width: 100px;
        }
        .auto-style280 {
            font-family: Calibri;
        }
        .auto-style281 {
            width: 100px;
            height: 69px;
            font-family: Calibri;
        }
        .auto-style282 {
            width: 405px;
            height: 23px;
            font-family: Calibri;
        }
        .auto-style283 {
            width: 351px;
            border: 1px solid #000000;
            font-family: Calibri;
        }
        .auto-style284 {
            border: 1px solid #000000;
            font-family: Calibri;
        }
        .auto-style285 {
            border: 1px dashed #000000;
            width: 549px;
            font-family: Calibri;
        }
        .auto-style286 {
            border: 1px dashed #000000;
            font-family: Calibri;
        }
        .auto-style287 {
            border: 1px dashed #000000;
            width: 1626px;
            font-family: Calibri;
        }
        .auto-style289 {
            font-weight: normal;
        }
        .auto-style291 {
            width: 407px;
            border: 1px solid #000000;
            font-family: Calibri;
            font-weight: normal;
        }
        .auto-style292 {
            font-family: call;
        }
        .auto-style293 {
            width: 67px;
            font-family: Calibri;
        }
        .auto-style297 {
            border: 1px solid #000000;
            height: 19px;
        }
        .auto-style298 {
            border: 1px solid #000000;
            width: 106px;
        }
        .auto-style299 {
            font-size: small;
        }
        .auto-style301 {
            border: 1px solid #000000;
            width: 158px;
        }
        .auto-style302 {
            border: 1px solid #000000;
            width: 139px;
        }
        .auto-style303 {
            border: 1px solid #000000;
            text-align: left;
        }
        .auto-style305 {
            border: 1px solid #000000;
            font-family: Calibri;
            background-color: #B4C6E7;
        }
        .auto-style307 {
            border: 1px dashed #000000;
            width: 100px;
            height: 38px;
        }
        .auto-style308 {
            border: 1px dashed #000000;
            width: 150px;
            height: 38px;
        }
        .auto-style312 {
            border: 1px solid #000000;
            font-family: Calibri;
            background-color: #8EA9DB;
            height: 20px;
        }
        .auto-style314 {
            border: 1px solid #000000;
            font-family: Calibri;
            background-color: #FFD966;
            height: 20px;
        }
        .auto-style315 {
            border: 1px solid #000000;
            background-color: #B4C6E7;
        }
        .auto-style316 {
            border: 1px solid #000000;
            width: 84px;
        }
        .auto-style317 {
            border: 1px solid #000000;
            width: 78px;
        }
        .auto-style318 {
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
            border-bottom: 1px solid #000000;
            height: 19px;
            width: 78px;
        }
        .auto-style319 {
            border-left: 1px solid #000000;
            border-right: 1px solid #000000;
        }
        .auto-style323 {
            font-style: normal;
        }
        .auto-style325 {
            border: 1px solid #000000;
            width: 71px;
        }
        .auto-style326 {
            width: 100%;
            height: 55px;
        }
        .auto-style327 {
            border: 1px solid #000000;
            width: 122px;
        }
        .auto-style328 {
            width: 100%;
            height: 99px;
        }
        .auto-style330 {
            width: 67px;
            font-family: Calibri;
            height: 32px;
        }
        .auto-style331 {
            width: 67px;
            height: 32px;
        }
        .auto-style333 {
            width: 61px;
        }
        .auto-style334 {
            border: 1px solid #000000;
            width: 139px;
            height: 20px;
        }
        .auto-style335 {
            border: 1px solid #000000;
            width: 158px;
            height: 20px;
        }
        .auto-style336 {
            border: 1px solid #000000;
            height: 20px;
        }
        .auto-style337 {
            width: 100px;
            margin-left: 80px;
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
       <center>
           
           <%-- <br class="auto-style184" />
            <span class="auto-style184">
            <script type="text/javascript">--%>
   <%-- function ValidateCheckBoxList(sender, args) {
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
        --%>
<%--</script>--%>
       
     </span>
            <asp:Panel ID="Panel1" runat="server" BackColor="#ffffff" BorderStyle="Solid" CssClass="auto-style183" Width="900px">
                <table id="1" border="1" class="auto-style21" style="width:895px">
                    <tr>
                        <td class="auto-style31" style="font-size: large; font-style: oblique; font-weight:bold">
                            <center>
                                <table class="nav-justified">
                                    <tr>
                                        <td class="auto-style114">Performance Review Form 绩效考核表 Mold</td>
                                        </em>
                                        <td class="auto-style323">
                                            <asp:CheckBox ID="supldr" runat="server" Font-Size="Medium" Text="Supervisior / Leader" AutoPostBack="True" />
                                            &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" Font-Size="Medium" Text="OP" AutoPostBack="True" Checked="True" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </td>
                    </tr>
                    </em></em><em>
                    <tr>
                        <td class="auto-style31" style="font-weight:bold">
                            <center class="auto-style68" style="background-color:#eea236 ">
                                A. Employee Information 員工信息</center>
                        </td>
                    </tr>
                    </em>
                </table>
                <em><em>
                <tr>
                    <td class="auto-style24">
                    </td>
                </tr>
             
                </em></em>
                <table id="2" border="1" class="auto-style20">
                    <tr>
                        <td class="auto-style280">
                            <table class="nav-justified">
                                <tr>
                                    <td class="auto-style122">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style334">Employee Name</td>
                                                <td class="auto-style335">
                                                    <asp:Label ID="empname" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style334">Employee Code</td>
                                                <em>
                                                <td class="auto-style335">
                                                    <asp:Label ID="empcode" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style334">Desgnation</td>
                                                <td class="auto-style336">
                                                    <asp:Label ID="desc" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                </em>
                                            </tr>
                                            <tr>
                                                <td class="auto-style302">Dept./ Section</td>
                                                <td class="auto-style301">
                                                    <asp:Label ID="deptsect" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style302">DOJ</td>
                                                <td class="auto-style301">
                                                    <asp:Label ID="doj" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                                <td class="auto-style302">Reporting To</td>
                                                <td class="auto-style122">
                                                    <asp:Label ID="repto" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style302">Review Time</td>
                                                <td class="auto-style122" colspan="2">
                                                    <asp:CheckBox ID="trai" runat="server" CssClass="auto-style280" Text="Training" AutoPostBack="True" />
                                                    &nbsp;<asp:CheckBox ID="prob" runat="server" CssClass="auto-style280" Text="Probation" AutoPostBack="True" />
                                                    &nbsp;<asp:CheckBox ID="Conf" runat="server" CssClass="auto-style280" Text="Confirm" AutoPostBack="True" />
                                                </td>
                                                <td class="auto-style122" colspan="3">Year : <em>
                                                    <asp:Label ID="revmonth" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                                    &nbsp;
                                                    </em>
                                                    <asp:CheckBox ID="month" runat="server" CssClass="auto-style280" Text="Monthly" AutoPostBack="True" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q1" runat="server" CssClass="auto-style280" Text="Q1" AutoPostBack="True" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q2" runat="server" CssClass="auto-style280" Text="Q2" AutoPostBack="True" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q3" runat="server" CssClass="auto-style280" Text="Q3" AutoPostBack="True" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q4" runat="server" CssClass="auto-style280" Text="Q4" AutoPostBack="True" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style284"><strong>Assessment Parameters</strong></td>
                    </tr>
                    <em>
                    <tr>
                        <td class="auto-style280">
                            <table class="nav-justified">
                                <tr>
                                    <td class="auto-style134"><strong>B. Fixed固定的</strong></td>
                                    <td class="auto-style132"><strong>76%</strong></td>
                                    <td class="auto-style133"><strong>C. Variable 可變的 </strong></td>
                                    <td class="auto-style132"><strong>8%</strong></td>
                                </tr>
                                <tr>
                                    <td class="auto-style284">1. Attendance 出勤率 </td>
                                    <td class="auto-style129">
                                        <em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">6%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score1" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em>
                                    </td>
                                    <td class="auto-style130">4. Environment 5S /Safety (環境5S/安全)<span class="auto-style289"> </span></td>
                                    <td class="auto-style129">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">4%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score7" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style284">
                                        <table class="auto-style326">
                                            <tr>
                                                <td class="auto-style325" rowspan="3">2.Mold Work 模具工作</td>
                                                <td class="auto-style122">Cleaning Achievement rate 生產達成率</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style122">Dredging Achievement rate 生產達成率</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style122">Checking Achievement rate 生產達成率</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style129">
                                        <table class="auto-style328">
                                            <tr>
                                                <td class="auto-style293">15%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score2" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <em>
                                                <td class="auto-style293">15%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score3" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                                </td>
                                                </em>
                                            </tr>
                                            <tr>
                                                <em>
                                                <td class="auto-style293">15%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score4" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                                </td>
                                                </em>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style130" rowspan="2">5.Observation Skill, Detailed feedback to supervisors, Shift start/close meeting communication （觀察技巧，給主管的詳細反饋，輪班開始/結束會議溝通）</td>
                                    <td class="auto-style129" rowspan="2">
                                        <em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style293">4%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score8" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        </em>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style284"><em>
                                        <table class="auto-style326">
                                            <tr>
                                                <td class="auto-style325" rowspan="2">3.Major Quality Violation 重大缺失</td>
                                                <td class="auto-style122">Near miss, accident, unsafe condition 工安事件</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style122">Mold Damage 模具损坏</td>
                                            </tr>
                                        </table>
                                        </em></td>
                                    <td class="auto-style129"><em>
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style330">10%</span></td>
                                                <td class="auto-style331">
                                                    <asp:TextBox ID="score5" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <em>
                                                <td class="auto-style293">15%</span></td>
                                                <td class="auto-style131">
                                                    <asp:TextBox ID="score6" runat="server" CssClass="auto-style165" Width="70px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                                </td>
                                                </em>
                                            </tr>
                                        </table>
                                        </em></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </em>
                </table>
                <em><em><em></td>
                </em>
                </tr>
                <em></em><em></em></em></em></em>
                <tr>
                    <td class="auto-style280">
                        <table class="nav-justified">
                            <tr>
                                <td class="auto-style312" colspan="2" rowspan="2"><strong>D. Leaders Review 領導者</strong></td>
                                <td class="auto-style314">16<strong>%</strong></td>
                            </tr>
                            <tr>
                                <td class="auto-style314">
                                    <table class="nav-justified">
                                        <tr>
                                            <td class="auto-style333">12%</td>
                                            <td class="auto-style284">4</td>
                                            <td class="auto-style284">3</td>
                                            <td class="auto-style284">2</td>
                                            <td class="auto-style284">1</td>
                                        </tr>
                                    </table>
                                </td>
                                <tr>
                                    <td class="auto-style137">1. Leader </td>
                                    <td class="auto-style138">
                                        <asp:TextBox ID="ldr" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                    </td>
                                    <td class="auto-style303" colspan="2">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style327">4</td>
                                                <td class="auto-style303">
                                                    <asp:CheckBoxList ID="score9" runat="server" RepeatDirection="Horizontal" Width="188px" AutoPostBack="True">
                                                        <asp:ListItem Value="4">4%</asp:ListItem>
                                                        <asp:ListItem Value="3">3%</asp:ListItem>
                                                        <asp:ListItem Value="2">2%</asp:ListItem>
                                                        <asp:ListItem Value="1">1%</asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style291">2. Section Head</td>
                                    <td class="auto-style138">
                                        <asp:TextBox ID="shead" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                    </td>
                                    <td class="auto-style122">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style327">4*3</td>
                                                <td class="auto-style303">
                                                    <asp:CheckBoxList ID="score10" runat="server" RepeatDirection="Horizontal" Width="188px" AutoPostBack="True">
                                                        <asp:ListItem Value="4">4%</asp:ListItem>
                                                        <asp:ListItem Value="3">3%</asp:ListItem>
                                                        <asp:ListItem Value="2">2%</asp:ListItem>
                                                        <asp:ListItem Value="1">1%</asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style291">3. Department Head</td>
                                    <td class="auto-style138">
                                        <asp:TextBox ID="dhead" runat="server" CssClass="auto-style165" Width="244px" AutoPostBack="True" style="text-align:center"></asp:TextBox>
                                    </td>
                                    <td class="auto-style122">
                                        <asp:TextBox ID="score11" runat="server" CssClass="auto-style165" Width="244px" style="text-align:center"></asp:TextBox>
                                    </td>
                                </tr>
                            </tr>
                        </table>
                        <span class="auto-style292"></span>
                    </td>
                </tr>
                </table>
                </em></em>
                <table class="nav-justified">
                    <tr>
                        <td class="auto-style284" colspan="2">
                            <table class="nav-justified">
                                <tr>
                                    <td class="auto-style315" colspan="5"><strong>Criteria of after Monthly /Quarterly /Yearly performance 月/季/年業績後標準</strong></td>
                                </tr>
                                <tr>
                                    <td class="auto-style122" rowspan="2">Performance Evaluation on base of&nbsp; <span class="auto-style289">
                                        <asp:Label ID="Label30" runat="server" CssClass="auto-style280" Text="Label"></asp:Label>
                                        </span></td>
                                    <td class="auto-style298"><strong>Status of Review Period</strong></td>
                                    <td class="auto-style316"><strong>
                                        <asp:CheckBox ID="pass" runat="server" CssClass="auto-style280" Text="Pass" AutoPostBack="True" />
                                        </strong></td>
                                    <td class="auto-style317">Total Score</td>
                                    <td class="auto-style122"><strong>
                                        <asp:CheckBox ID="extend" runat="server" CssClass="auto-style280" Text="Extend" AutoPostBack="True" />
                                        </strong></td>
                                </tr>
                                <tr>
                                    <td class="auto-style122" colspan="2">100
                                        <asp:Image ID="Image8" runat="server" Height="20px" ImageUrl="~/Images/messageImage_1662634718713.jpg" Width="160px" />
                                    </td>
                                    <td class="auto-style317">76</td>
                                    <td class="auto-style122">
                                        <asp:Image ID="Image9" runat="server" Height="20px" ImageUrl="~/Images/messageImage_1662634733964.jpg" Width="160px" />
                                        &nbsp;0</td>
                                </tr>
                                <tr>
                                    <td class="auto-style297">Coefficient 係數</td>
                                    <td class="auto-style122" colspan="2" rowspan="3">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style319">1.3</td>
                                                <td class="auto-style319">1.2</td>
                                                <td class="auto-style319">1.1</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style122">96-100</td>
                                                <td class="auto-style122">86-95</td>
                                                <td class="auto-style122">77-85</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style319">690</td>
                                                <td class="auto-style319">660</td>
                                                <td class="auto-style319">630</td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style318">1</td>
                                    <td class="auto-style122" rowspan="3">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style122">0.9</td>
                                                <td class="auto-style122">0.8</td>
                                                <td class="auto-style122">0.7</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style122">75-67</td>
                                                <td class="auto-style122">66-56</td>
                                                <td class="auto-style122">&gt;56</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style122">300</td>
                                                <td class="auto-style122">300</td>
                                                <td class="auto-style122">300</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style297">PMS Score PMS分數</td>
                                    <td class="auto-style318">76</td>
                                </tr>
                                <tr>
                                    <td class="auto-style297">Variable allowance +Semi grade 可變津贴+半級</td>
                                    <td class="auto-style318">300</td>
                                </tr>
                                <tr>
                                    <td class="auto-style122">Final amount (+/-) 最终金额 (+/-)&nbsp; </td>
                                    <td class="auto-style122" colspan="4">
                                        <asp:TextBox ID="famnt" runat="server" CssClass="auto-style214" Height="24px" style="font-family: Calibri; font-size: small; text-align: center;" Width="150px" AutoPostBack="True"></asp:TextBox>
                                        <asp:CheckBox ID="plus" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Small" Height="24px" Text="Increase" Width="65px" />
                                        <asp:TextBox ID="amnt2" runat="server" AutoPostBack="True" OnTextChanged="amnt2_TextChanged" ReadOnly="True" Width="32px"></asp:TextBox>
                                        <asp:CheckBox ID="Sub1" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="Small" Height="24px" Text=" Decrease" />
                                        <asp:TextBox ID="famnt1" runat="server" AutoPostBack="True" CssClass="auto-style214" Height="24px" style="font-family: Calibri; font-size: small" Width="150px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style305" colspan="2"><span class="auto-style289"><strong>If when you fail in Review Month 如果你在 Review Month 中失敗了</strong></span></td>
                    </tr>
                    <tr>
                        <td class="auto-style122" colspan="2">
                            <table class="nav-justified">
                                <tr>
                                    <td class="auto-style285"><strong>Evaluate By<br /> &nbsp;評估依據</strong></td>
                                    <td class="auto-style287"><strong>Salary Effect of Monthly base 月基工資效應</strong></td>
                                    <td class="auto-style227"><strong>Remarks /Comment<br class="auto-style299" />&nbsp;備註/評論</strong></td>
                                    <em>
                                    <td class="auto-style209"><span class="auto-style165"><strong>Employee Signature </strong></span><em><strong>
                                        <br class="auto-style213" />
                                        </strong></em><span class="auto-style165"><strong>員工簽名</strong></span></td>
                                    </em>
                                </tr>
                                <tr>
                                    <td class="auto-style228"><span class="auto-style165">By Own Self (Employee)</span><em><br class="auto-style213" /><span class="auto-style165">&nbsp;</span></em><span class="auto-style165">自己（員工）</span></td>
                                    <td class="auto-style226" rowspan="4">
                                        <table class="nav-justified">
                                            <tr>
                                                <td class="auto-style307">
                                                    <asp:CheckBox ID="empn" runat="server" CssClass="auto-style165" AutoPostBack="True" />
                                                </td>
                                                <em>
                                                <td class="auto-style308"><span class="auto-style280">Same as (No deduct)</span><em><br class="auto-style286" /><span class="auto-style280">&nbsp;</span></em><span class="auto-style280">與（不扣除）相同</span></td>
                                                <td class="auto-style307">
                                                    <asp:CheckBox ID="empd" runat="server" CssClass="auto-style165" AutoPostBack="True" />
                                                </td>
                                                <td class="auto-style308"><span class="auto-style280">Salary decrease (Deduct) </span><em>
                                                    <br class="auto-style286" />
                                                    </em><span class="auto-style280">減薪（扣除）</span></td>
                                                </em>
                                            </tr>
                                            <tr>
                                                <td class="auto-style231">
                                                    <asp:CheckBox ID="ldrn" runat="server" CssClass="auto-style165" AutoPostBack="True" />
                                                </td>
                                                <td class="auto-style227"><span class="auto-style280">Same as (No deduct)</span><em><br class="auto-style286" /><span class="auto-style280">&nbsp;</span></em><span class="auto-style280">與（不扣除）相同</span></td>
                                                <td class="auto-style231">
                                                    <asp:CheckBox ID="ldrd" runat="server" CssClass="auto-style165" />
                                                </td>
                                                <td class="auto-style227"><span class="auto-style280">Salary decrease (Deduct) </span><em>
                                                    <br class="auto-style286" />
                                                    </em><span class="auto-style280">減薪（扣除）</span></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style231">
                                                    <asp:CheckBox ID="sheadn" runat="server" CssClass="auto-style165" AutoPostBack="True" />
                                                </td>
                                                <td class="auto-style227"><span class="auto-style280">Same as (No deduct)</span><em><br class="auto-style286" /><span class="auto-style280">&nbsp;</span></em><span class="auto-style280">與（不扣除）相同</span></td>
                                                <td class="auto-style231">
                                                    <asp:CheckBox ID="sheadd" runat="server" CssClass="auto-style165" />
                                                </td>
                                                <td class="auto-style227"><span class="auto-style280">Salary decrease (Deduct) </span><em>
                                                    <br class="auto-style286" />
                                                    </em><span class="auto-style280">減薪（扣除）</span></td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style231">
                                                    <asp:CheckBox ID="dheadn" runat="server" CssClass="auto-style165" AutoPostBack="True" />
                                                </td>
                                                <td class="auto-style227"><span class="auto-style280">Same as (No deduct)</span><em><br class="auto-style286" /></em><span class="auto-style280">&nbsp;與（不扣除）相同</span></td>
                                                <td class="auto-style231">
                                                    <asp:CheckBox ID="dheadd" runat="server" CssClass="auto-style165" />
                                                </td>
                                                <td class="auto-style227"><span class="auto-style280">Salary decrease (Deduct) </span><em>
                                                    <br class="auto-style286" />
                                                    </em><span class="auto-style280">減薪（扣除）</span><em></span></em></td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="auto-style227">
                                        <asp:TextBox ID="remark1" runat="server" CssClass="auto-style214" Height="24px" style="font-family: Calibri; font-size: small" Width="150px" Font-Overline="True" TextMode="MultiLine" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td class="auto-style209"><span class="auto-style289">
                                        <asp:CheckBox ID="empsign" runat="server" AutoPostBack="true" CssClass="auto-style214" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" style="font-size: small; font-family: Calibri" />
                                        </span></td>
                                </tr>
                                <em>
                                <tr>
                                    <td class="auto-style285">By Leader<br /> &nbsp;主管</span><em></em></td>
                                    <td class="auto-style227">
                                        <asp:TextBox ID="remark2" runat="server" CssClass="auto-style214" Height="24px" style="font-family: Calibri; font-size: small" Width="150px" TextMode="MultiLine" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td class="auto-style209"><span class="auto-style289">
                                        <asp:CheckBox ID="ldrsign" runat="server" AutoPostBack="true" CssClass="auto-style214" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" style="font-size: small; font-family: Calibri" />
                                        </span></td>
                                </tr>
                                <em>
                                <tr>
                                    <td class="auto-style285">By Section Head
                                        <br />
                                        課長</span><em></em></td>
                                    <td class="auto-style227">
                                        <asp:TextBox ID="remark3" runat="server" CssClass="auto-style214" Height="24px" style="font-family: Calibri; font-size: small" Width="150px" TextMode="MultiLine" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td class="auto-style209"><span class="auto-style289">
                                        <asp:CheckBox ID="sheadsign" runat="server" AutoPostBack="true" CssClass="auto-style214" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" style="font-size: small; font-family: Calibri" />
                                        </span></td>
                                </tr>
                                <em>
                                <tr>
                                    <td class="auto-style285">By Dept. Head
                                        <br />
                                        部門經理</span><em></em></td>
                                    <td class="auto-style227">
                                        <asp:TextBox ID="remark4" runat="server" CssClass="auto-style214" Height="24px" style="font-family: Calibri; font-size: small" Width="150px" TextMode="MultiLine" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td class="auto-style209"><span class="auto-style289">
                                        <asp:CheckBox ID="dheadsign" runat="server" AutoPostBack="true" CssClass="auto-style214" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" style="font-size: small; font-family: Calibri" />
                                        </span></td>
                                </tr>
                                </em></em></em>
                            </table>
                        </td>
                    </tr>
                    <em>
                    <tr>
                        <td class="auto-style305" colspan="2"><strong>The final decision is taken by Department Head for deduction for salary 扣除工資的最終決定由部門負責人做出</strong></td>
                    </tr>
                    <tr>
                        <td class="auto-style283">Final Salary decision 薪酬</td>
                        <td class="auto-style122">
                            <table class="nav-justified">
                                <tr>
                                    <td class="auto-style117"><span class="auto-style280">Same as </span><em>
                                        <asp:CheckBox ID="sameas" runat="server" CssClass="auto-style280" AutoPostBack="True" onclick="if(!confirm('Are you sure salary will be Same as?'))return false;" />
                                        </em><span class="auto-style280">一樣 </span></td>
                                    <td class="auto-style117"><span class="auto-style280">Salary Increase </span><em>
                                        <asp:CheckBox ID="sincrease" runat="server" CssClass="auto-style280" AutoPostBack="True" onclick="if(!confirm('Are you sure salary will be Increase?'))return false;" />
                                        </em><span class="auto-style280">漲薪 </span></td>
                                    <td class="auto-style117"><span class="auto-style280">Salary decrease </span><em>
                                        <asp:CheckBox ID="sdecrease" runat="server" CssClass="auto-style280" AutoPostBack="True" onclick="if(!confirm('Are you sure salary will be Decrease?'))return false;" />
                                        </em><span class="auto-style280">減薪</span></td>
                                    <td class="auto-style122"><span class="auto-style280">Other： </span><em>
                                        <br class="auto-style280" />
                                        </em><span class="auto-style280">其他：</span><em></span><em></em></em></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    </em>
                </table>
                </td>
                </tr>
                </table>
                </em></em></em></em>
                <table border="1" class="auto-style169">
                    <tr>
                        <td class="auto-style282" style="background-color:#eea236"><strong>Remarks 評論</strong></td>
                        <td class="auto-style175" rowspan="2" style="background-color:#eea236"><strong>Total Score<br /> &nbsp;總得分<br /> &nbsp;100%</strong></td>
                        <td class="auto-style173" colspan="3" style="background-color:#eea236"><strong>Approvals 批准</strong></td>
                    </tr>
                    <em>
                    <tr>
                        <td class="auto-style172" rowspan="3" style="text-align:left; font-size:small"><span class="auto-style280">Performance status definition :考核結果說明 </span>
                            <br class="auto-style280" />
                            <span class="auto-style280">1.Pass: Score is 76 or more than 76 every time </span>
                            <br class="auto-style280" />
                            <span class="auto-style280">適任: 分數高於76分 </span>
                            <br class="auto-style280" />
                            <span class="auto-style280">2.Extend : Score is 75 or below 75, turn to extend period(PIP), employee has three months to improve his/her performance.(CW/FT is Not Included in Extend Process; They are directly eligible for fail criteria ) </span>
                            <br class="auto-style280" />
                            <span class="auto-style280">延長:分數低於75分，進入績效改善階段，共三個月之改善期間。（CW/FT 不包括在扩展过程中；它们直接符合失败标准）</span></td>
                        <td class="auto-style180"><span class="auto-style280"><strong>Department Head </strong> </span>
                            <strong>
                            <br class="auto-style280" />
                            </strong>
                            <span class="auto-style280"><strong>部門主管</strong></span></td>
                        <td class="auto-style281"><strong>Section Head<br /> &nbsp;課長</strong></td>
                        <td class="auto-style180"><span class="auto-style280"><strong>Employee Signature</strong></span><strong><br class="auto-style280" /> </strong> <span class="auto-style280"><strong>員工簽名</strong></span></td>
                    </tr>
                    <tr>
                        <td class="auto-style175" style="font-size:small">
                            <asp:Label ID="totmarks" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style178">
                            <asp:CheckBox ID="ch1" runat="server" CssClass="auto-style280" />
                        </td>
                        <td class="auto-style178">
                            <asp:CheckBox ID="ch2" runat="server" CssClass="auto-style280" />
                        </td>
                        <td class="auto-style337">
                            <asp:CheckBox ID="ch3" runat="server" AutoPostBack="true" CssClass="auto-style280" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                        </td>
                    </tr>
                    </em>
                    <tr>
                        <td class="auto-style280" colspan="4" style="font-size:small">
                            <asp:Label ID="Time" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
                 <center>
                <asp:Button ID="insert" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Submit" ValidationGroup="insert" />
                <span class="auto-style184"><%--<asp:Button ID="Button2" runat="server" CssClass="auto-style102" Height="43px" Text="Export To PDF" />--%></span>
      </center>
                <em><em></td>
                </tr>
                </em></em></em>
            </asp:Panel>
       </center>
        <br/>
        </ContentTemplate></asp:UpdatePanel>
</asp:Content>










