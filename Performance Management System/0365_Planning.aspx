

<%@ Page Title="" Language="vb" AutoEventWireup="false"  EnableEventValidation="false" MasterPageFile="~/Site1.Master" CodeBehind="0365_Planning.aspx.vb" Inherits="Performance_Management_System._0365_Planning" %>

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

        .auto-style27 {
            width: 251px;
        }

        .auto-style31 {
            height: 22px;
        }

        .auto-style43 {
            width: 392px;
        }

        .auto-style55 {
            width: 7px;
        }

        .auto-style56 {
            width: 33px;
        }

        .auto-style59 {
            width: 15px;
        }

        .auto-style61 {
            width: 536px;
        }

        .auto-style62 {
            width: 364px;
        }

        .auto-style63 {
            width: 420px;
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
            margin-left: 33px;
        }

        .auto-style86 {
            width: 602px;
        }

        .auto-style87 {
            width: 364px;
            height: 25px;
        }

        .auto-style88 {
            width: 420px;
            height: 25px;
        }

        .auto-style89 {
            width: 159px;
            height: 25px;
        }

        .auto-style90 {
            width: 188px;
            height: 25px;
        }

        .auto-style91 {
            width: 189px;
            height: 25px;
        }

        .auto-style92 {
            width: 432px;
            height: 25px;
        }

        .auto-style93 {
            width: 536px;
            height: 25px;
        }

        .auto-style94 {
            width: 392px;
            height: 25px;
        }

        .auto-style95 {
            width: 37px;
        }

        .auto-style96 {
            width: 35px;
        }

        .auto-style97 {
            width: 36px;
        }

        .auto-style99 {
            margin-top: 0px;
        }

        table, th, td {
            /*border: 1px solid black;*/
            align-content: center;
            text-align: center
        }
        .auto-style114 {
            width:100%;
        }
        .auto-style116 {
            height: 51px;
        }
        .auto-style117 {
            width: 406px;
        }
        .auto-style118 {
            width: 223px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          
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
            <%--<asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True"></asp:TextBox>--%>
        <asp:Label ID="Label22" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
            </center>
            <br />
            
<center>
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
         function ValidateCheckBoxList5(sender, args) {
        var checkBoxList = document.getElementById("<%=CheckBoxList6.ClientID %>"); 
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
          <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" EnableViewState="true" Width="920px" BackColor="#ffffff" CssClass="auto-style99">

            <table id="1" border="1" class="auto-style21" style="visibility: visible; width:915px; list-style-type: circle; table-layout: fixed; border-collapse: separate; border-spacing: inherit">
                <tr>
                    <td class="auto-style31" colspan="6" style="font-size:large; font-style: oblique; font-weight:bold ">
                       
                            Training Probation Period Final Review Form (For Staff) 訓練期/試用期期間評核表(大專人員)
                    </td>
                </tr>
                <tr>
                    <td class="auto-style31" colspan="6" style="font-weight:bold;background-color:#eea236 ">
                       
                            A.Employee Information
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Employee Name</td>
                    <td class="auto-style26" id="empname" runat="server">
                        
                    </td>
                    <td class="auto-style25">Employee Code</td>
                    <td class="auto-style69" id="empcode" runat="server">
                    
                    </td>
                    <td class="auto-style27">Designation</td>
                    <td id="desc" runat="server">
                     
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Dept./Section</td>
                    <td class="auto-style26" id="deptsec" runat="server">
                        
                    </td>
                    <td class="auto-style25">DOJ</td>
                    <td class="auto-style69" id="doj" runat="server">
                       
                    </td>
                    <td class="auto-style27">Review Month</td>
                    <td id="review" runat="server">
                       
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Qualification</td>
                    <td class="auto-style26" id="qual" runat="server">
                      
                    </td>
                    <td class="auto-style25">Previous Experience</td>
                    <td class="auto-style69" id="prev" runat="server">
                      
                    </td>
                    <td class="auto-style27" >Reporting To</td>
                    <td id="repto" runat="server">
                      
                    </td>
                </tr>
                <tr>
                    <td class="auto-style24">Period</td>
                    <td colspan="5"   onclick="return false;">
                        <asp:CheckBox ID="trai" runat="server"  Text="Training Period" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:CheckBox ID="prob" runat="server"  Text="Probation Period"  />
                    </td>
                </tr>
            </table>
            <table id="2" border="1" class="auto-style20" style="width:915px; ">
                <tr>
                    <td colspan="8" style="font-weight:bold;background-color:#eea236">
                       
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; B. Attendance Details
                    </td>
                    <td class="auto-style43" style="font-weight:bold;background-color:#eea236">30%</td>
                </tr>
                <tr>
                    <td class="auto-style62">Actual Working Days</td>
                    <td class="auto-style63">Actual Present Days</td>
                    <td class="auto-style64">CL</td>
                    <td class="auto-style65">SL</td>
                    <td class="auto-style66">PL</td>
                    <td class="auto-style67">LWP</td>
                    <td class="auto-style61">Other Leaves</td>
                    <td class="auto-style61">Absent Days</td>
                    <td class="auto-style43">Scores</td>
                </tr>
                <tr>
                    <td class="auto-style87" id="actwork" runat="server">                   
                    </td>
                    <td class="auto-style88" id="actpre" runat="server">                      
                    </td>
                    <td class="auto-style89" id="cla" runat="server">                        
                    </td>
                    <td class="auto-style90" id="sla" runat="server">                        
                    </td>
                    <td class="auto-style91" id="pla" runat="server">                      
                    </td>
                    <td class="auto-style92" id="lwpa" runat="server">                    
                    </td>
                    <td id="otherleaves" runat="server"></td>
                    <td class="auto-style93" id="absent" runat="server" >                       
                    </td>
                    <td class="auto-style94" id="scor" runat="server">                     
                    </td>
                </tr>
            </table>
            <table id="tb1" runat="server" border="1" class="auto-style20" style="width:915px; ">
                <tr>
                    <td class="auto-style83" colspan="7" style="font-weight:bold; background-color:#eea236">
                        
                            &nbsp;&nbsp;&nbsp;&nbsp; C. Performance Review
                    </td>
                    <td class="auto-style84" style="font-weight:bold; background-color:#eea236">
                        <center>
                            70%</center>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" colspan="2" >
                        <center>
                            Assessment Parameter</center>
                    </td>
                    <td class="auto-style55">%</td>
                    <td class="auto-style56">5</td>
                    <td class="auto-style95">4</td>
                    <td class="auto-style96">3</td>
                    <td class="auto-style97">2</td>
                    <td class="auto-style59">1</td>
                </tr>
                <tr itemid="1">
                    <td class="auto-style86" title="a" style="text-align:left" colspan="2"><b> 1. Proficiency/competency in work(工作職能) :</b> The capacity to understand a situation and to act reasonably, Creativity & innovatively.<asp:TextBox ID="scor1" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style55" title="a" style="font-weight:bold">20%</td>
                    <td colspan="5" title="a" id="a1" runat="server" ><asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="insert" ErrorMessage="Please select at least one item." ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" ></asp:CustomValidator>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" CssClass="auto-style85" RepeatDirection="Horizontal" Width="181px" CausesValidation="True">
                        <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" colspan="2" style="text-align:left"><b> 2. Quality of Work(工作品質) :</b> Gives considerable amount of effort and importance to maintain and upgrade quality standards of work for self and team.<asp:TextBox ID="scor2" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style55" colspan="1" style="font-weight:bold">20%</td>
                    <td colspan="5"><asp:CustomValidator ID="CustomValidator2" runat="server" ValidationGroup="insert" ErrorMessage="Please select at least one item." ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList1" ></asp:CustomValidator>
                        <asp:CheckBoxList ID="CheckBoxList2" runat="server" AutoPostBack="True" CssClass="auto-style85" RepeatDirection="Horizontal" Width="181px" CausesValidation="True">
                        <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b> 3. Problem Solving & Decision making(問題分析及解決能力) :</b> Ability to gather and analyse relevant data to solve problems and make decisions within the scope of authority.<asp:TextBox ID="scor3" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style55" style="font-weight:bold">5%</td>
                    <td colspan="5"><asp:CustomValidator ID="CustomValidator3" runat="server" ValidationGroup="insert" ErrorMessage="Please select at least one item." ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList2" ></asp:CustomValidator>
                        <asp:CheckBoxList ID="CheckBoxList3" runat="server" AutoPostBack="True" CssClass="auto-style85" RepeatDirection="Horizontal" Width="181px" CausesValidation="True">
                             <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b> 4. Initiative(工作積極性) :</b> Shows a positive attitude & motivation towards work and the organization. Consistently developing new initiatives to ensure continued growth.<asp:TextBox ID="scor4" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style55" style="font-weight:bold">10%</td>
                    <td colspan="5"><asp:CustomValidator ID="CustomValidator4" runat="server" ValidationGroup="insert" ErrorMessage="Please select at least one item." ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList3" ></asp:CustomValidator>
                        <asp:CheckBoxList ID="CheckBoxList4" runat="server" AutoPostBack="True" CssClass="auto-style85" RepeatDirection="Horizontal" Width="181px" CausesValidation="True">
                             <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b> 5. Ability to Learn (訓後運用效果) :</b> Ability to apply strategies which support learning and the ability to adapt to change.<asp:TextBox ID="scor5" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style55" style="font-weight:bold">10%</td>
                    <td colspan="5"><asp:CustomValidator ID="CustomValidator5" runat="server" ValidationGroup="insert" ErrorMessage="Please select at least one item." ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList4" ></asp:CustomValidator>
                        <asp:CheckBoxList ID="CheckBoxList5" runat="server" AutoPostBack="True" CssClass="auto-style85" RepeatDirection="Horizontal" Width="181px" CausesValidation="True">
                             <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b> 6. Involvement/participation in team effort(團隊合作) :</b> Can inspire confidence in others and creates enthusiasm and ensures collaboration amongst team members to attain stated objectives.<asp:TextBox ID="scor6" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style55" style="font-weight:bold">5%</td>
                    <td colspan="5"><asp:CustomValidator ID="CustomValidator6" runat="server" ValidationGroup="insert" ErrorMessage="Please select at least one item." ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList5" ></asp:CustomValidator>
                        <asp:CheckBoxList ID="CheckBoxList6" runat="server" AutoPostBack="True" CssClass="auto-style85" RepeatDirection="Horizontal" Width="181px" CausesValidation="True">
                            <asp:ListItem Value="5" ></asp:ListItem>
                        <asp:ListItem Value="4" ></asp:ListItem>
                        <asp:ListItem  Value="3"></asp:ListItem>
                        <asp:ListItem Value="2"></asp:ListItem>
                        <asp:ListItem Value="1"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align:left">*(1) Mark a V (tick) against the appropriate rating. 5= Excellent(傑出), 4=Good(良好), 3=mediocre(尚符需求), 2=Improvement Required(須改進), 1=Fail(不適任)
*(2) 評核項目轉換分數:勾選選項*3分 (最高為15分，最低為3分)</td>
                </tr>
              
              
            </table>
           <table class="auto-style20" border="1" style="width:915px;"  >
                 <tr><td style="text-align:left;" class="auto-style118" >7. Recommendation &amp;
                     <br />
                     Areas of Improvement,<br /> Observation/Comment of
                     <br />
                     supervisor : 建議及改進項目: &nbsp;</td>
                     <td  id="des" runat="server">
                         <asp:TextBox ID="remark" runat="server" Height="100px"   BackColor="White" BorderColor="White" BorderStyle="None" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                     </td>
                </tr>
           </table>

            <table id="3" border="1" class="auto-style114" style="width:915px;" >
                <tr>
                    <td style="background-color:#eea236" class="auto-style117">Remarks</td> <td rowspan="2" style="height:90px">Status of probation /<br /> &nbsp;Training period</td>
                    <td rowspan="2" id="pas" runat="server" >
                    <asp:CheckBox ID="pass" runat="server"  Text="Pass"/>
                    </td> <td rowspan="2" id="ext" runat="server" >
                        <asp:CheckBox ID="extend" runat="server" Text="Extend" />
                    </td> <td rowspan="2" id="fl" runat="server" >
                        <asp:CheckBox ID="fail" runat="server" text="Fail"/>
                    </td> 
                </tr>
                  <tr>
                    <td rowspan="4" class="auto-style117" style="text-align:left; font-size:small">*Performance result definition: 考核結果說明 <br />
1.Pass: 適任<br />
<b><u>Training:</u></b> Average score is 66 or more than 66.<br />
訓練期：平均高於66分<br />
<b><u>Probation:</u></b> Average score is 71 or more than 71.<br />
試用期：平均高於71分<br />
2.Extend: 延長<br />
<b><u>Training:</u></b> Average score is equal to or between 56-65 <br />
訓練期：平均落於56-65分<br />
<b><u>Probation:</u></b> Average score is equal to or between 61-70.<br />
試用期：平均落於61-70分<br />
3.In Extend plan Employee has three months to improve his/her performance.<br />
延長期間共有三個月可進行改善</td>  
                </tr>
                 <tr>
                     <td rowspan="2" style="background-color:#eea236">Total Score</td> <td colspan="4" style="background-color:#eea236">Approvals</td>  
                </tr>
                 <tr>
                     <td>Plant
                         <br />
                         Head / Director</td>
                     <td>Department
                         <br />
                         Head</td> <td>Section
                         <br />
                         Head</td> <td>Employee
                         <br />
                         Signature</td> 
                </tr>
                  <tr>
                      <td class="auto-style116" id="totmarks" runat="server"></td> <td class="auto-style116">
                      <asp:CheckBox ID="plheadsign" runat="server" />
                      </td> <td class="auto-style116">
                      <asp:CheckBox ID="deptsign" runat="server" />
                      </td> <td class="auto-style116">
                          <asp:CheckBox ID="sectsign" runat="server" />
                      </td> <td class="auto-style116">
                          <asp:CheckBox ID="empsig" runat="server" AutoPostBack="true"   onclick="if(!confirm('Are you sure you want to Accept?'))return false;"/>
                      </td> 
                </tr>
             
            </table>
                <center> <asp:Button ID="insert" runat="server"  Text="Submit" cssclass="btn btn-primary" ValidationGroup="insert"  />  
             <%--<asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To Pdf" />--%>
                  <%-- <asp:LinkButton ID="export" runat="server" CssClass="btn btn-danger" ><i class="fa fa-file-excel-o "></i>  Export</asp:LinkButton>  --%>
<asp:LinkButton runat="server" id="print" cssclass="btn btn-warning" OnClientClick = "return PrintPanel();"><i class="fa fa-print"></i> Print</asp:LinkButton>
            </center>
        </asp:Panel>
    <br />
        </ContentTemplate>
       
    </asp:UpdatePanel>
</asp:Content>
