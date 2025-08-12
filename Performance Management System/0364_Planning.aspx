

<%@ Page Title="" Language="vb" EnableEventValidation="false" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0364_Planning.aspx.vb" Inherits="Performance_Management_System._0364_Planning" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
            width: 232px;
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

        .auto-style86 {
            width: 602px;
        }

        .auto-style87 {
            width: 232px;
            height: 25px;
        }

        .auto-style88 {
            width: 273px;
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
        .auto-style115 {
            width: 197px;
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
            
              
            &nbsp;<br />
<center>
   <%-- <script type="text/javascript">
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
</script>--%>

          <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" EnableViewState="true" Width="920px" BackColor="#ffffff" CssClass="auto-style99">

            <table id="1" border="1" class="auto-style21" style="visibility: visible; width:915px; list-style-type: circle; table-layout: fixed; border-collapse: separate; border-spacing: inherit">
                <tr>
                    <td class="auto-style31" colspan="6" style="font-size:large; font-style: oblique; font-weight:bold ">
                       
                            Training / Probation Period During Review Form (For Staff) 訓練期/試用期期間評核表(大專人員)</td>
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
                    <td colspan="7" style="font-weight:bold;background-color:#eea236">
                       
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
                    <td class="auto-style93" id="absent" runat="server">                       
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
                    <td class="auto-style86" title="a" style="text-align:left" colspan="2"><b>1. Job Knowledge(工作知識) :</b> In-depth technical knowledge of related areas to his / her function and keeping abreast with the latest developments in his / her functional area.</td>
                    <td class="auto-style55" title="a" style="font-weight:bold">20%</td>
                    <td colspan="5" title="a"><em>
                        <asp:TextBox ID="score1" runat="server" AutoPostBack="True" CssClass="auto-style165" style="text-align:center" TabIndex="1" Width="70px"></asp:TextBox>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" colspan="2" style="text-align:left"><b>2. Planning, Organising & Resourcefulness (有組織性的規劃) :</b> Organizes activities in terms of importance and priority and establishes schedules to complete assignments in time and is also able to deliver results under stress conditions.</td>
                    <td class="auto-style55" colspan="1" style="font-weight:bold">20%</td>
                    <td colspan="5"><em>
                        <asp:TextBox ID="score2" runat="server" AutoPostBack="True" CssClass="auto-style165" style="text-align:center" TabIndex="1" Width="70px"></asp:TextBox>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>3. Technical Skills(工作技巧) :</b> Consider proficiency of technical/computer skills; ability to apply technical and computer skills to complete work.</td>
                    <td class="auto-style55" style="font-weight:bold">5%</td>
                    <td colspan="5"><em>
                        <asp:TextBox ID="score3" runat="server" AutoPostBack="True" CssClass="auto-style165" style="text-align:center" TabIndex="1" Width="70px"></asp:TextBox>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>4.Initiative Approach(積極主動性) :</b> Taking initiative to achieve goals and complete assignments.</td>
                    <td class="auto-style55" style="font-weight:bold">10%</td>
                    <td colspan="5"><em>
                        <asp:TextBox ID="score4" runat="server" AutoPostBack="True" CssClass="auto-style165" style="text-align:center" TabIndex="1" Width="70px"></asp:TextBox>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>5. Willingness to learn(學習動機) :</b> Being motivated to learn new skills &amp; technology.</td>
                    <td class="auto-style55" style="font-weight:bold">10%</td>
                    <td colspan="5"><em>
                        <asp:TextBox ID="score5" runat="server" AutoPostBack="True" CssClass="auto-style165" style="text-align:center" TabIndex="1" Width="70px"></asp:TextBox>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style86" style="text-align:left" colspan="2"><b>6. Communication skills(溝通技巧) :</b> Can effectively express ideas and opinions and provide information with clarity on a one to one level and to a group as a whole.</td>
                    <td class="auto-style55" style="font-weight:bold">5%</td>
                    <td colspan="5"><em>
                        <asp:TextBox ID="score6" runat="server" AutoPostBack="True" CssClass="auto-style165" style="text-align:center" TabIndex="1" Width="70px"></asp:TextBox>
                        </em>
                    </td>
                </tr>
                <tr>
                    <td colspan="8" style="text-align:left">*(1) Fill the appropriate Rating. 15= Excellent(傑出), 12=Good(良好), 9=mediocre(尚符需求), 6=Improvement Required(須改進), 3=Fail(不適任) （最高15分，最低3分.</td>
                </tr>
              
              
            </table>
           <table class="auto-style20" border="1" style="width:915px;"  >
                 <tr><td style="text-align:left;" class="auto-style115" >7. Recommendation &amp;
                     <br />
                     Areas of Improvement,<br /> Observation/Comment of
                     <br />
                     supervisor : 建議及改進項目: &nbsp;<%--<asp:Button ID="Button4" runat="server" Text="+" CssClass="btn btn-primary" />--%></td>
                     <td id="rema" runat="server" >
                         <asp:TextBox ID="remark" runat="server" Height="90px"   BackColor="White" BorderColor="White" BorderStyle="None" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                     </td>
                </tr>
           </table>

             

            <table id="3" border="1" class="auto-style114" style="width:915px;" >
             <tr>
                 <td style="background-color:#eea236">Remarks</td>
                  <td rowspan="2" style="background-color:#eea236">Total Scores</td>
                 <td colspan="3" style="background-color:#eea236">Approvals</td>
             </tr>
                 <tr>
                 <td  rowspan="3" style="text-align:left; width:500px; font-size:small"  >1. Part A & B provided by HR Dept. A及B部分由人資提供<br /> 2. Review employees&#39; performance in this period and give feedback or guidance in point 7. 評核該區間之表現並給予回饋。<br /> 3. Fail definition: 不適任說明：<br /> Training: 訓練期 
                   
                     (1) scores are 55 or below 55 in the three months continuously, (2)<br /> Average Score is 55 or below 55.<br /> 連續三次低於55分或平均低於55分 
                   
                     Probation:試用期 
                    
                     (1) scores are 60 or below 60 in the three months continuously (2)<br /> Average Score is 60 or below 60
                     <br />
                     連續三次低於60分或平均低於60分 
                  
                     In these two cases Employee services would be terminated.</td>
                  <td >Department
                      <br />
                      Head</td>
                  <td>Section
                      <br />
                      Head</td>
                  <td>Employee
                      <br />
                      Signature</td>
                    
             </tr>
                 <tr>
                  <td id="totmarks" runat="server" >
                    <%--  <asp:Label ID="totmarks" runat="server" Text="Label"></asp:Label>--%>
                     </td>
                  <td >
                      <asp:CheckBox ID="ch1" runat="server" />
                     </td>
                  <td>
                      <asp:CheckBox ID="ch2" runat="server" />
                     </td>
                  <td>
                      <asp:CheckBox ID="ch3" runat="server" AutoPostBack="true" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                     </td>
                     
             </tr>
                <%--<tr>
                    <td colspan="5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                    </td>
                </tr>--%>
                <tr>
                    <td runat="server" colspan="4">
                        <asp:Label ID="Time" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
              <center>
             <%--<asp:Button ID="Button3" runat="server" CssClass="auto-style102" Height="43px" Text="Export To Pdf" />--%>
                  <%-- <asp:LinkButton ID="export" runat="server" CssClass="btn btn-danger" ><i class="fa fa-file-excel-o "></i>  Export</asp:LinkButton>  --%>
                  <asp:Button ID="insert" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Submit" ValidationGroup="insert" />
                  <em></td>
                  </tr>
                  </em></em>&nbsp;<span class="auto-style184"><asp:Button ID="update" runat="server" cssclass="btn btn-primary" OnClick="update_Click" style="font-family: call; font-size: small;" Text="Update" ValidationGroup="insert" />
                  &nbsp;<asp:Button ID="show" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Show" ValidationGroup="insert" />
                  </span>
            </center>
        </asp:Panel>


        </ContentTemplate>
       
    </asp:UpdatePanel>
</asp:Content>


