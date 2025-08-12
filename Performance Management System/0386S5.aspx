<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="0386S5.aspx.vb" Inherits="Performance_Management_System._0386S5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style36 checkboxlist-spacing {
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
            height: 61px;        }
        .auto-style38 {
            width: 15%;
            height: 61px;
        }
    
   

   
</style>
  


       <script type="text/javascript">
    function MutExChkList1(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList2(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList3(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList4(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList5(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
                }
                 function MutExChkList6(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
           }
           function MutExChkList7(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
           }
           function MutExChkList8(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
           }
           function MutExChkList9(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
           }
           function MutExChkList10(chk) {
        var chkList = chk.parentNode.parentNode.parentNode;
        var chks = chkList.getElementsByTagName("input");
        for (var i = 0; i < chks.length; i++) {
            if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }
    }
</script>

<script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        // Select all checkboxes by their IDs
        var passCheckbox = $('#<%= pass.ClientID %>');
        var extendCheckbox = $('#<%= extend.ClientID %>');
        var failCheckbox = $('#<%= fail.ClientID %>');
        
        // Handle click event for Pass checkbox
        passCheckbox.click(function () {
            if ($(this).prop('checked')) {
                extendCheckbox.prop('checked', false);
                failCheckbox.prop('checked', false);
            }
        });
        
        // Handle click event for Extend checkbox
        extendCheckbox.click(function () {
            if ($(this).prop('checked')) {
                passCheckbox.prop('checked', false);
                failCheckbox.prop('checked', false);
            }
        });
        
        // Handle click event for Fail checkbox
        failCheckbox.click(function () {
            if ($(this).prop('checked')) {
                passCheckbox.prop('checked', false);
                extendCheckbox.prop('checked', false);
            }
        });
    });
</script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
     
    <br /><center>
     
                     <script>
                         function printDiv(divId) {
                             var printableContent = document.getElementById(divId).innerHTML;
                             var originalContent = document.body.innerHTML;

                             // Create a new window for printing
                             var printWindow = window.open('', '_blank');

                             printWindow.document.write('<html><head><title></title>');
                             printWindow.document.write('<style type="text/css">');
                             printWindow.document.write('@media print {');
                             printWindow.document.write('    body {');
                             printWindow.document.write('        font-family: Arial, sans-serif;');
                             printWindow.document.write('        color: #333; /* Text color */');
                             printWindow.document.write('        text-align: center; /* Center align text */');
                             // Add more CSS styles as needed
                             printWindow.document.write('    }');
                             printWindow.document.write('}');
                             printWindow.document.write('</style>');
                             printWindow.document.write('</head><body>');

                             // Write printable content into the new window
                             printWindow.document.write(printableContent);

                             printWindow.document.write('</body></html>');
                             printWindow.document.close();

                             // Focus and print the new window
                             printWindow.focus();
                             printWindow.print();
                             printWindow.close();

                             // Restore original content on the main page
                             document.body.innerHTML = originalContent;
                         }
                         $(function () {
                             var power = '<%= Session("access power") %>';
                             if (power == 3) {
                                 var webcamWidth = $('#webcam').width();
                                 var webcamHeight = $('#webcam').height();

                                 Webcam.set({
                                     width: webcamWidth,
                                     height: webcamHeight,
                                     image_format: 'jpeg',
                                     jpeg_quality: 90
                                 });

                                 Webcam.attach('#webcam');

                                 $("#btnCapture").click(function () {
                                     Webcam.snap(function (data_uri) {
                                         var img = new Image();
                                         img.src = data_uri;
                                         img.onload = function () {
                                             var canvas = document.createElement('canvas');
                                             var ctx = canvas.getContext('2d');

                                             canvas.width = img.width;
                                             canvas.height = img.height + 30;

                                             ctx.drawImage(img, 0, 0);

                                             ctx.font = '20px Arial';
                                             ctx.fillStyle = 'white';
                                             ctx.textAlign = 'center';

                                             var currentDate = new Date();
                                             var dateTimeText = currentDate.toLocaleString();

                                             ctx.fillText(dateTimeText, canvas.width / 2, canvas.height - 10);

                                             var finalImage = canvas.toDataURL('image/jpeg');

                                             $("#imgCapture")[0].src = finalImage;

                                         };
                                     });
                                 });

                                 $("#btnUpload").click(function () {
                                     var imageData = $("#imgCapture")[0].src;

                                     $.ajax({
                                         type: "POST",
                                         url: "Finance_Accounting_Payable_New.aspx/SaveCapturedImage",
                                         data: JSON.stringify({ data: imageData }),
                                         contentType: "application/json; charset=utf-8",
                                         dataType: "json",
                                         success: function (r) {
                                             alert('Image saved successfully!');
                                             chk3Display()
                                         },
                                         error: function (xhr, status, error) {
                                             alert("There was an error uploading the image.");
                                         }
                                     });
                                 });
                             }
                         });

                         function chk3Display() {
                             $(".emps").css("display", "block");
                         }

                       
                     </script>
    &nbsp;<asp:Label ID="Label12" runat="server" Text="Label" Visible="false"></asp:Label>
   
    <center>

                   
        
             <!-- Webcam Container -->
<div id="outerimgdiv" style="position:fixed;" runat="server">
    <div class="camera-container">
        <div id="webcam"></div>
         <button id="btnCapture" type="button" class="btn-success form-control">Capture</button>
    </div>
    <br />
    <div class="camera-container">
        <img id="imgCapture" />
        <button id="btnUpload" type="button" class="form-control btn-primary" >Upload</button>
    </div>
</div>
        <!-- Webcam Container -->
         <div id="printableContent">
        <asp:Panel ID="Panel1" runat="server" Width="970px" BorderStyle="Solid" BackColor="#ffffff">
        <table border="1" style="width:100%; text-align:center; border-collapse: collapse;font-size:large">
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
                                               &nbsp;<asp:CheckBox ID="q1" runat="server" CssClass="auto-style280" Text="Q1" />
                                                    <em>
                                                    &nbsp;</em><asp:CheckBox ID="q2" runat="server" CssClass="auto-style280" Text="Q2" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q3" runat="server" CssClass="auto-style280" Text="Q3" />
                                                    <em>&nbsp;</em><asp:CheckBox ID="q4" runat="server" CssClass="auto-style280" Text="Q4" />
                </td> 
            </tr>
        
        </table>
        <table border="1"  style="width:100%; text-align:center; border-collapse: collapse;">
            <tr >
                <td style="width:70%; font-weight:bold; background-color:#eea236">B. Assessment Parameter</td> <td style="width:5%">%</td><td style="width:5%">5</td><td style="width:5%">4</td><td style="width:5%">3</td><td style="width:5%">2</td><td style="width:5%">1&nbsp;</td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>1. Technical skills and Interpersonal Skills(專業能力及溝通技巧):</b> Knowledge for performing the task and the skills of interaction which describe through ease of taking task.
                </td>
              <td style="width:5%; font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="score1" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                      <asp:ListItem  Value="5" onclick="MutExChkList1(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList1(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList1(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList1(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList1(this);" />
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%; text-align:left"><b>2. Workforce Planning(人力掌控) :</b> Align the needs and priorities of the organization with workforce to ensure it can meet requirements of the organizational.
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                   <asp:CheckBoxList ID="score2" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                         <asp:ListItem  Value="5" onclick="MutExChkList2(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList2(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList2(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList2(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList2(this);" />
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%; text-align:left"><b>3. Project management (專案管理):</b> Capability to initiating, planning, executing, controlling, and closing the work of a team to achieve specific goals and meet specific success criteria at the specified time.
                </td>
             <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                 <asp:CheckBoxList ID="score3" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                          <asp:ListItem  Value="5" onclick="MutExChkList3(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList3(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList3(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList3(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList3(this);" />
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>4. Progress Evaluation(過程監控):</b> It covers critical assessment of your subordinates on the basis of task assigned, it also includes whether program activities have been implemented as intended.
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
             <asp:CheckBoxList ID="score4" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                         <asp:ListItem  Value="5" onclick="MutExChkList4(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList4(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList4(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList4(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList4(this);" />
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>5. Problem Analysis(問題分析):</b> Ability to understand the situation,task and also find cause through analytical skills.<br />
                </td>
           <td style="width:5%;font-weight:bold">10</td><td colspan="5">
              <asp:CheckBoxList ID="score5" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                          <asp:ListItem  Value="5" onclick="MutExChkList5(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList5(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList5(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList5(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList5(this);" />
                </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td style="width:70%; text-align:left"><b>6. Decision Making(決策能力):</b> Based on the problem and it&#39;s analysis the right and proper decision should be taken by him/her.
                </td>
           <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                <asp:CheckBoxList ID="score6" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                        <asp:ListItem  Value="5" onclick="MutExChkList6(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList6(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList6(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList6(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList6(this);" />
                </asp:CheckBoxList>

                        </em>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>7.Team Building(團隊建立):</b> Assign suitable task to team members which can Motivate and promote them to work together effectively.
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                  <asp:CheckBoxList ID="score7" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                        <asp:ListItem  Value="5" onclick="MutExChkList7(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList7(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList7(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList7(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList7(this);" />
                </asp:CheckBoxList>

                        </em>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>8.Leadership(領導技巧):</b> He/She must be capable to design, plan, manage, delegate, communicate the assigned work.
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                   <asp:CheckBoxList ID="score8" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                        <asp:ListItem  Value="5" onclick="MutExChkList8(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList8(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList8(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList8(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList8(this);" />
                </asp:CheckBoxList>

                        </em>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>9. Development of Subordinates(發展部屬能力):</b> He/She is obliged for the development of their subordinates through sharing knowledge and guide them to show their potential which help to achieve the design goals.
                </td>
              <td style="width:5%;font-weight:bold">10</td><td colspan="5">
                   <asp:CheckBoxList ID="score9" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                        <asp:ListItem  Value="5" onclick="MutExChkList9(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList9(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList9(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList9(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList9(this);" />
                </asp:CheckBoxList>

                        </em>
                </td>
            </tr>
            <tr>
                <td style="width:70%;  text-align:left"><b>10. Self- Learning(自我學習):</b> Capacity to learn, improve, and adapt changes independently which must help to achieve the desired goals.
                </td>
               <td style="width:5%;font-weight:bold ">10</td><td colspan="5">
                  <asp:CheckBoxList ID="score10" runat="server" AutoPostBack="True" CssClass="auto-style36 checkboxlist-spacing" RepeatDirection="Horizontal" Width="191px">
                        <asp:ListItem  Value="5" onclick="MutExChkList10(this);" />
    <asp:ListItem  Value="4" onclick="MutExChkList10(this);" />
    <asp:ListItem  Value="3" onclick="MutExChkList10(this);" />
    <asp:ListItem  Value="2" onclick="MutExChkList10(this);" />
    <asp:ListItem  Value="1" onclick="MutExChkList10(this);" />
                </asp:CheckBoxList>

                        </em>
                </td>
            </tr>
            <tr>
                <td colspan="7" >*(1) Mark a ü (tick) against the appropriate rating. 5= Excellent(傑出), 4=Good(良好), 3=Mediocre(尚符需求), 2=Improvement Required(須改進), 1=Fail(不適任) *(2) 評核項目轉換分數:勾選選項*2分 (最高為10分，最低為2分)&nbsp;&nbsp; </td>
            </tr>
        </table>
        <table class="auto-style20" border="1" style="width:100%;text-align:center;  border-collapse: collapse;font-size:large;height:13%">
            <tr>
                <td style="width:170px;font-size:x-large">11.Comment and Areas of Improvement, Observation 建議及改進項目:</td>  
                <td colspan="5" style="width:30%" id="descr" runat="server">
                <asp:TextBox ID="remark" runat="server" cssclass="form-control" Height="100%"   style="width:100%;font-size:x-large;height:100%"  BackColor="White" BorderColor="White" BorderStyle="None" TextMode="MultiLine"></asp:TextBox>
                </td>  
            </tr>
            <tr>
                <td colspan="2" style="background-color:#eea236;font-weight:bold" >Remarks</td>
                <td style="width:20%; background-color:#eea236" colspan="2">Total Scores</td>
                <td style="width:20%; background-color:#eea236" colspan="2">Review Status</td>
            </tr>
            <tr>
                <td style="text-align:left; font-size:large" colspan="2" rowspan="6">1. Review employees&#39; performance in this period and give feedback or guidance in <br /> point 11. 評核該區間之表現並給予回饋。 
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
<asp:CheckBox ID="pass" runat="server" Text="Pass" Font-Bold="true" AutoPostBack="True" CssClass="pass-group"  />

                </td>
                
            </tr>
            <tr>
                <td style="width:20%">
<asp:CheckBox ID="extend" runat="server" Text="Extend" Font-Bold="true" AutoPostBack="True" CssClass="pass-group"  />
                </td>
            </tr>
            <tr>
                <td style="width:20%">
<asp:CheckBox ID="fail" runat="server" Text="Fail" Font-Bold="true" AutoPostBack="True" CssClass="pass-group"  />
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
                </td>
                <td style="width:10%">
                    <asp:CheckBox ID="ch2" runat="server" />
                </td>
                <td style="width:15% ;" >
                    <asp:CheckBox ID="ch3" runat="server" />
                </td>
                <td style="width:15%">
                    <label id="lblEmpsign" runat="server"></label>
<label id="lblEmpDate" runat="server"></label>
                    <asp:CheckBox ID="ch4" runat="server" AutoPostBack="true" CssClass="emps" style="display:none" onclick="if(!confirm('Are you sure you want to Accept?'))return false;" />
                </td>
            </tr>
           
            <tr>
                <td colspan="4">
                    <asp:Label ID="Time" runat="server" Text="Label1"></asp:Label>
                </td>
            </tr>
           
            
        </table>
   
       
    </asp:Panel>
               <!-- This code for footer title -->
                <div style="display: flex; width:900px; justify-content: space-between; align-items: flex-end; text-align: center; margin-top:7px;">
    <div style="text-align: left;">
        Retention Period: Keep until <br />
        the employee's relieving <br />
        period is completed <br />
        label
    </div>
    <div style="text-align: center;">MAXXIS RUBBER INDIA PVT. LTD.</div>
    <div style="text-align: right;">A4/A3 No. 0399-1</div>
</div>
                <!-- This code for footer title  end-->
             </div>
        <br />
              <center>
               <asp:Button ID="insert" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Submit" ValidationGroup="insert" />
                  <em></td>
                  </tr>
               </em></em>&nbsp;<span class="auto-style184"><asp:Button ID="update" runat="server" cssclass="btn btn-primary" OnClick="update_Click" style="font-family: call; font-size: small;" Text="Update" ValidationGroup="insert" />
                  &nbsp;<asp:Button ID="show" runat="server" cssclass="btn btn-primary" style="font-family: call; font-size: small;" Text="Show" ValidationGroup="insert" />
                  </span>
            </center>
                      <asp:LinkButton runat="server" id="print" cssclass="btn btn-warning" OnClientClick = "printDiv('printableContent')"><i class="fa fa-print"></i> Print</asp:LinkButton>

   </center>

    <br /></ContentTemplate></asp:UpdatePanel>
</asp:Content>
